using System;
using System.Windows;
using System.Windows.Interactivity;
using Microsoft.Practices.ServiceLocation;
using Prism.Common;
using Prism.Interactivity.DefaultPopupWindows;
using Prism.Interactivity.InteractionRequest;

namespace Prism.Interactivity
{
	// Token: 0x02000071 RID: 113
	public class PopupWindowAction : TriggerAction<FrameworkElement>
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600035D RID: 861 RVA: 0x00008CBE File Offset: 0x00006EBE
		// (set) Token: 0x0600035E RID: 862 RVA: 0x00008CD0 File Offset: 0x00006ED0
		public FrameworkElement WindowContent
		{
			get
			{
				return (FrameworkElement)base.GetValue(PopupWindowAction.WindowContentProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.WindowContentProperty, value);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600035F RID: 863 RVA: 0x00008CDE File Offset: 0x00006EDE
		// (set) Token: 0x06000360 RID: 864 RVA: 0x00008CF0 File Offset: 0x00006EF0
		public Type WindowContentType
		{
			get
			{
				return (Type)base.GetValue(PopupWindowAction.WindowContentTypeProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.WindowContentTypeProperty, value);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00008CFE File Offset: 0x00006EFE
		// (set) Token: 0x06000362 RID: 866 RVA: 0x00008D10 File Offset: 0x00006F10
		public bool IsModal
		{
			get
			{
				return (bool)base.GetValue(PopupWindowAction.IsModalProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.IsModalProperty, value);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000363 RID: 867 RVA: 0x00008D23 File Offset: 0x00006F23
		// (set) Token: 0x06000364 RID: 868 RVA: 0x00008D35 File Offset: 0x00006F35
		public bool CenterOverAssociatedObject
		{
			get
			{
				return (bool)base.GetValue(PopupWindowAction.CenterOverAssociatedObjectProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.CenterOverAssociatedObjectProperty, value);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000365 RID: 869 RVA: 0x00008D48 File Offset: 0x00006F48
		// (set) Token: 0x06000366 RID: 870 RVA: 0x00008D5A File Offset: 0x00006F5A
		public WindowStartupLocation? WindowStartupLocation
		{
			get
			{
				return (WindowStartupLocation?)base.GetValue(PopupWindowAction.WindowStartupLocationProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.WindowStartupLocationProperty, value);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00008D6D File Offset: 0x00006F6D
		// (set) Token: 0x06000368 RID: 872 RVA: 0x00008D7F File Offset: 0x00006F7F
		public Style WindowStyle
		{
			get
			{
				return (Style)base.GetValue(PopupWindowAction.WindowStyleProperty);
			}
			set
			{
				base.SetValue(PopupWindowAction.WindowStyleProperty, value);
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00008D90 File Offset: 0x00006F90
		protected override void Invoke(object parameter)
		{
			InteractionRequestedEventArgs interactionRequestedEventArgs = parameter as InteractionRequestedEventArgs;
			if (interactionRequestedEventArgs == null)
			{
				return;
			}
			if (this.WindowContent != null && this.WindowContent.Parent != null)
			{
				return;
			}
			Window wrapperWindow = this.GetWindow(interactionRequestedEventArgs.Context);
			Action callback = interactionRequestedEventArgs.Callback;
			EventHandler handler = null;
			handler = delegate(object o, EventArgs e)
			{
				wrapperWindow.Closed -= handler;
				wrapperWindow.Content = null;
				if (callback != null)
				{
					callback();
				}
			};
			wrapperWindow.Closed += handler;
			if (this.CenterOverAssociatedObject && base.AssociatedObject != null)
			{
				SizeChangedEventHandler sizeHandler = null;
				sizeHandler = delegate(object o, SizeChangedEventArgs e)
				{
					wrapperWindow.SizeChanged -= sizeHandler;
					Window owner = wrapperWindow.Owner;
					if (owner != null && owner.WindowState == WindowState.Minimized)
					{
						wrapperWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
						return;
					}
					FrameworkElement associatedObject = this.AssociatedObject;
					Point point = associatedObject.PointToScreen(new Point(0.0, 0.0));
					point = PresentationSource.FromVisual(associatedObject).CompositionTarget.TransformFromDevice.Transform(point);
					Point point2 = new Point(point.X + associatedObject.ActualWidth / 2.0, point.Y + associatedObject.ActualHeight / 2.0);
					wrapperWindow.Left = point2.X - wrapperWindow.ActualWidth / 2.0;
					wrapperWindow.Top = point2.Y - wrapperWindow.ActualHeight / 2.0;
				};
				wrapperWindow.SizeChanged += sizeHandler;
			}
			if (this.IsModal)
			{
				wrapperWindow.ShowDialog();
				return;
			}
			wrapperWindow.Show();
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00008E80 File Offset: 0x00007080
		protected virtual Window GetWindow(INotification notification)
		{
			Window window;
			if (this.WindowContent != null || this.WindowContentType != null)
			{
				window = this.CreateWindow();
				if (window == null)
				{
					throw new NullReferenceException("CreateWindow cannot return null");
				}
				window.DataContext = notification;
				window.Title = notification.Title;
				this.PrepareContentForWindow(notification, window);
			}
			else
			{
				window = this.CreateDefaultWindow(notification);
			}
			if (base.AssociatedObject != null)
			{
				window.Owner = Window.GetWindow(base.AssociatedObject);
			}
			if (this.WindowStyle != null)
			{
				window.Style = this.WindowStyle;
			}
			if (this.WindowStartupLocation != null)
			{
				window.WindowStartupLocation = this.WindowStartupLocation.Value;
			}
			return window;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00008F30 File Offset: 0x00007130
		protected virtual void PrepareContentForWindow(INotification notification, Window wrapperWindow)
		{
			if (this.WindowContent != null)
			{
				wrapperWindow.Content = this.WindowContent;
			}
			else
			{
				if (!(this.WindowContentType != null))
				{
					return;
				}
				wrapperWindow.Content = ServiceLocator.Current.GetInstance(this.WindowContentType);
			}
			Action <>9__1;
			Action<IInteractionRequestAware> action = delegate(IInteractionRequestAware iira)
			{
				iira.Notification = notification;
				Action finishInteraction;
				if ((finishInteraction = <>9__1) == null)
				{
					finishInteraction = (<>9__1 = delegate()
					{
						wrapperWindow.Close();
					});
				}
				iira.FinishInteraction = finishInteraction;
			};
			MvvmHelpers.ViewAndViewModelAction<IInteractionRequestAware>(wrapperWindow.Content, action);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00008FB6 File Offset: 0x000071B6
		protected virtual Window CreateWindow()
		{
			return new DefaultWindow();
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00008FC0 File Offset: 0x000071C0
		protected Window CreateDefaultWindow(INotification notification)
		{
			Window result;
			if (notification is IConfirmation)
			{
				result = new DefaultConfirmationWindow
				{
					Confirmation = (IConfirmation)notification
				};
			}
			else
			{
				result = new DefaultNotificationWindow
				{
					Notification = notification
				};
			}
			return result;
		}

		// Token: 0x040000A2 RID: 162
		public static readonly DependencyProperty WindowContentProperty = DependencyProperty.Register("WindowContent", typeof(FrameworkElement), typeof(PopupWindowAction), new PropertyMetadata(null));

		// Token: 0x040000A3 RID: 163
		public static readonly DependencyProperty WindowContentTypeProperty = DependencyProperty.Register("WindowContentType", typeof(Type), typeof(PopupWindowAction), new PropertyMetadata(null));

		// Token: 0x040000A4 RID: 164
		public static readonly DependencyProperty IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(PopupWindowAction), new PropertyMetadata(null));

		// Token: 0x040000A5 RID: 165
		public static readonly DependencyProperty CenterOverAssociatedObjectProperty = DependencyProperty.Register("CenterOverAssociatedObject", typeof(bool), typeof(PopupWindowAction), new PropertyMetadata(null));

		// Token: 0x040000A6 RID: 166
		public static readonly DependencyProperty WindowStartupLocationProperty = DependencyProperty.Register("WindowStartupLocation", typeof(WindowStartupLocation?), typeof(PopupWindowAction), new PropertyMetadata(null));

		// Token: 0x040000A7 RID: 167
		public static readonly DependencyProperty WindowStyleProperty = DependencyProperty.Register("WindowStyle", typeof(Style), typeof(PopupWindowAction), new PropertyMetadata(null));
	}
}
