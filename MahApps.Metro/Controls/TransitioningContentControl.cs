using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000094 RID: 148
	public class TransitioningContentControl : ContentControl
	{
		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000807 RID: 2055 RVA: 0x00020A4C File Offset: 0x0001EC4C
		// (remove) Token: 0x06000808 RID: 2056 RVA: 0x00020A84 File Offset: 0x0001EC84
		public event RoutedEventHandler TransitionCompleted;

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x00020AB9 File Offset: 0x0001ECB9
		// (set) Token: 0x0600080A RID: 2058 RVA: 0x00020ACB File Offset: 0x0001ECCB
		public ObservableCollection<VisualState> CustomVisualStates
		{
			get
			{
				return (ObservableCollection<VisualState>)base.GetValue(TransitioningContentControl.CustomVisualStatesProperty);
			}
			set
			{
				base.SetValue(TransitioningContentControl.CustomVisualStatesProperty, value);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600080B RID: 2059 RVA: 0x00020AD9 File Offset: 0x0001ECD9
		// (set) Token: 0x0600080C RID: 2060 RVA: 0x00020AEB File Offset: 0x0001ECEB
		public string CustomVisualStatesName
		{
			get
			{
				return (string)base.GetValue(TransitioningContentControl.CustomVisualStatesNameProperty);
			}
			set
			{
				base.SetValue(TransitioningContentControl.CustomVisualStatesNameProperty, value);
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x0600080D RID: 2061 RVA: 0x00020AF9 File Offset: 0x0001ECF9
		// (set) Token: 0x0600080E RID: 2062 RVA: 0x00020B0B File Offset: 0x0001ED0B
		public bool IsTransitioning
		{
			get
			{
				return (bool)base.GetValue(TransitioningContentControl.IsTransitioningProperty);
			}
			private set
			{
				this.allowIsTransitioningPropertyWrite = true;
				base.SetValue(TransitioningContentControl.IsTransitioningProperty, value);
				this.allowIsTransitioningPropertyWrite = false;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x0600080F RID: 2063 RVA: 0x00020B2C File Offset: 0x0001ED2C
		// (set) Token: 0x06000810 RID: 2064 RVA: 0x00020B3E File Offset: 0x0001ED3E
		public TransitionType Transition
		{
			get
			{
				return (TransitionType)base.GetValue(TransitioningContentControl.TransitionProperty);
			}
			set
			{
				base.SetValue(TransitioningContentControl.TransitionProperty, value);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000811 RID: 2065 RVA: 0x00020B51 File Offset: 0x0001ED51
		// (set) Token: 0x06000812 RID: 2066 RVA: 0x00020B63 File Offset: 0x0001ED63
		public bool RestartTransitionOnContentChange
		{
			get
			{
				return (bool)base.GetValue(TransitioningContentControl.RestartTransitionOnContentChangeProperty);
			}
			set
			{
				base.SetValue(TransitioningContentControl.RestartTransitionOnContentChangeProperty, value);
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00020B78 File Offset: 0x0001ED78
		private static void OnIsTransitioningPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TransitioningContentControl transitioningContentControl = (TransitioningContentControl)d;
			if (!transitioningContentControl.allowIsTransitioningPropertyWrite)
			{
				transitioningContentControl.IsTransitioning = (bool)e.OldValue;
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x00020BAC File Offset: 0x0001EDAC
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x00020BB4 File Offset: 0x0001EDB4
		private Storyboard CurrentTransition
		{
			get
			{
				return this.currentTransition;
			}
			set
			{
				if (this.currentTransition != null)
				{
					this.currentTransition.Completed -= this.OnTransitionCompleted;
				}
				this.currentTransition = value;
				if (this.currentTransition != null)
				{
					this.currentTransition.Completed += this.OnTransitionCompleted;
				}
			}
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00020C08 File Offset: 0x0001EE08
		private static void OnTransitionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TransitioningContentControl transitioningContentControl = (TransitioningContentControl)d;
			TransitionType transitionType = (TransitionType)e.OldValue;
			TransitionType transitionType2 = (TransitionType)e.NewValue;
			if (transitioningContentControl.IsTransitioning)
			{
				transitioningContentControl.AbortTransition();
			}
			Storyboard storyboard = transitioningContentControl.GetStoryboard(transitionType2);
			if (storyboard != null)
			{
				transitioningContentControl.CurrentTransition = storyboard;
				return;
			}
			if (VisualStates.TryGetVisualStateGroup(transitioningContentControl, "PresentationStates") == null)
			{
				transitioningContentControl.CurrentTransition = null;
				return;
			}
			transitioningContentControl.SetValue(TransitioningContentControl.TransitionProperty, transitionType);
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Temporary removed exception message", transitionType2));
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00020C97 File Offset: 0x0001EE97
		private static void OnRestartTransitionOnContentChangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TransitioningContentControl)d).OnRestartTransitionOnContentChangeChanged((bool)e.OldValue, (bool)e.NewValue);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00020CBC File Offset: 0x0001EEBC
		protected virtual void OnRestartTransitionOnContentChangeChanged(bool oldValue, bool newValue)
		{
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00020CBE File Offset: 0x0001EEBE
		public TransitioningContentControl()
		{
			this.CustomVisualStates = new ObservableCollection<VisualState>();
			base.DefaultStyleKey = typeof(TransitioningContentControl);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00020CE4 File Offset: 0x0001EEE4
		public override void OnApplyTemplate()
		{
			if (this.IsTransitioning)
			{
				this.AbortTransition();
			}
			if (this.CustomVisualStates != null && this.CustomVisualStates.Any<VisualState>())
			{
				VisualStateGroup visualStateGroup = VisualStates.TryGetVisualStateGroup(this, "PresentationStates");
				if (visualStateGroup != null)
				{
					foreach (VisualState value in this.CustomVisualStates)
					{
						visualStateGroup.States.Add(value);
					}
				}
			}
			base.OnApplyTemplate();
			this.previousContentPresentationSite = (base.GetTemplateChild("PreviousContentPresentationSite") as ContentPresenter);
			this.currentContentPresentationSite = (base.GetTemplateChild("CurrentContentPresentationSite") as ContentPresenter);
			if (this.currentContentPresentationSite != null)
			{
				if (base.ContentTemplateSelector != null)
				{
					this.currentContentPresentationSite.ContentTemplate = base.ContentTemplateSelector.SelectTemplate(base.Content, this);
				}
				else
				{
					this.currentContentPresentationSite.ContentTemplate = base.ContentTemplate;
				}
				this.currentContentPresentationSite.Content = base.Content;
			}
			Storyboard storyboard = this.GetStoryboard(this.Transition);
			this.CurrentTransition = storyboard;
			if (storyboard == null)
			{
				TransitionType transition = this.Transition;
				this.Transition = TransitionType.Default;
				throw new ArgumentException(string.Format("'{0}' Transition could not be found!", transition), "Transition");
			}
			VisualStateManager.GoToState(this, "Normal", false);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00020E3C File Offset: 0x0001F03C
		protected override void OnContentChanged(object oldContent, object newContent)
		{
			base.OnContentChanged(oldContent, newContent);
			this.StartTransition(oldContent, newContent);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00020E50 File Offset: 0x0001F050
		private void StartTransition(object oldContent, object newContent)
		{
			if (this.currentContentPresentationSite != null && this.previousContentPresentationSite != null)
			{
				if (this.RestartTransitionOnContentChange)
				{
					this.CurrentTransition.Completed -= this.OnTransitionCompleted;
				}
				if (base.ContentTemplateSelector != null)
				{
					this.previousContentPresentationSite.ContentTemplate = base.ContentTemplateSelector.SelectTemplate(oldContent, this);
					this.currentContentPresentationSite.ContentTemplate = base.ContentTemplateSelector.SelectTemplate(newContent, this);
				}
				else
				{
					this.previousContentPresentationSite.ContentTemplate = base.ContentTemplate;
					this.currentContentPresentationSite.ContentTemplate = base.ContentTemplate;
				}
				this.currentContentPresentationSite.Content = newContent;
				this.previousContentPresentationSite.Content = oldContent;
				if (!this.IsTransitioning || this.RestartTransitionOnContentChange)
				{
					if (this.RestartTransitionOnContentChange)
					{
						this.CurrentTransition.Completed += this.OnTransitionCompleted;
					}
					this.IsTransitioning = true;
					VisualStateManager.GoToState(this, "Normal", false);
					VisualStateManager.GoToState(this, this.GetTransitionName(this.Transition), true);
				}
			}
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00020F60 File Offset: 0x0001F160
		public void ReloadTransition()
		{
			if (this.currentContentPresentationSite != null && this.previousContentPresentationSite != null)
			{
				if (this.RestartTransitionOnContentChange)
				{
					this.CurrentTransition.Completed -= this.OnTransitionCompleted;
				}
				if (!this.IsTransitioning || this.RestartTransitionOnContentChange)
				{
					if (this.RestartTransitionOnContentChange)
					{
						this.CurrentTransition.Completed += this.OnTransitionCompleted;
					}
					this.IsTransitioning = true;
					VisualStateManager.GoToState(this, "Normal", false);
					VisualStateManager.GoToState(this, this.GetTransitionName(this.Transition), true);
				}
			}
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00020FF4 File Offset: 0x0001F1F4
		private void OnTransitionCompleted(object sender, EventArgs e)
		{
			ClockGroup clockGroup = sender as ClockGroup;
			this.AbortTransition();
			if (clockGroup == null || clockGroup.CurrentState == ClockState.Stopped)
			{
				RoutedEventHandler transitionCompleted = this.TransitionCompleted;
				if (transitionCompleted == null)
				{
					return;
				}
				transitionCompleted(this, new RoutedEventArgs());
			}
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00021030 File Offset: 0x0001F230
		public void AbortTransition()
		{
			VisualStateManager.GoToState(this, "Normal", false);
			this.IsTransitioning = false;
			if (this.previousContentPresentationSite != null)
			{
				this.previousContentPresentationSite.ContentTemplate = null;
				this.previousContentPresentationSite.Content = null;
			}
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00021068 File Offset: 0x0001F268
		private Storyboard GetStoryboard(TransitionType newTransition)
		{
			VisualStateGroup visualStateGroup = VisualStates.TryGetVisualStateGroup(this, "PresentationStates");
			Storyboard result = null;
			if (visualStateGroup != null)
			{
				string transitionName = this.GetTransitionName(newTransition);
				result = (from state in visualStateGroup.States.OfType<VisualState>()
				where state.Name == transitionName
				select state.Storyboard).FirstOrDefault<Storyboard>();
			}
			return result;
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x000210E0 File Offset: 0x0001F2E0
		private string GetTransitionName(TransitionType transition)
		{
			switch (transition)
			{
			default:
				return "DefaultTransition";
			case TransitionType.Normal:
				return "Normal";
			case TransitionType.Up:
				return "UpTransition";
			case TransitionType.Down:
				return "DownTransition";
			case TransitionType.Right:
				return "RightTransition";
			case TransitionType.RightReplace:
				return "RightReplaceTransition";
			case TransitionType.Left:
				return "LeftTransition";
			case TransitionType.LeftReplace:
				return "LeftReplaceTransition";
			case TransitionType.Custom:
				return this.CustomVisualStatesName;
			}
		}

		// Token: 0x04000374 RID: 884
		internal const string PresentationGroup = "PresentationStates";

		// Token: 0x04000375 RID: 885
		internal const string NormalState = "Normal";

		// Token: 0x04000376 RID: 886
		internal const string PreviousContentPresentationSitePartName = "PreviousContentPresentationSite";

		// Token: 0x04000377 RID: 887
		internal const string CurrentContentPresentationSitePartName = "CurrentContentPresentationSite";

		// Token: 0x04000378 RID: 888
		private ContentPresenter currentContentPresentationSite;

		// Token: 0x04000379 RID: 889
		private ContentPresenter previousContentPresentationSite;

		// Token: 0x0400037A RID: 890
		private bool allowIsTransitioningPropertyWrite;

		// Token: 0x0400037B RID: 891
		private Storyboard currentTransition;

		// Token: 0x0400037D RID: 893
		public const TransitionType DefaultTransitionState = TransitionType.Default;

		// Token: 0x0400037E RID: 894
		public static readonly DependencyProperty IsTransitioningProperty = DependencyProperty.Register("IsTransitioning", typeof(bool), typeof(TransitioningContentControl), new PropertyMetadata(new PropertyChangedCallback(TransitioningContentControl.OnIsTransitioningPropertyChanged)));

		// Token: 0x0400037F RID: 895
		public static readonly DependencyProperty TransitionProperty = DependencyProperty.Register("Transition", typeof(TransitionType), typeof(TransitioningContentControl), new FrameworkPropertyMetadata(TransitionType.Default, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(TransitioningContentControl.OnTransitionPropertyChanged)));

		// Token: 0x04000380 RID: 896
		public static readonly DependencyProperty RestartTransitionOnContentChangeProperty = DependencyProperty.Register("RestartTransitionOnContentChange", typeof(bool), typeof(TransitioningContentControl), new PropertyMetadata(false, new PropertyChangedCallback(TransitioningContentControl.OnRestartTransitionOnContentChangePropertyChanged)));

		// Token: 0x04000381 RID: 897
		public static readonly DependencyProperty CustomVisualStatesProperty = DependencyProperty.Register("CustomVisualStates", typeof(ObservableCollection<VisualState>), typeof(TransitioningContentControl), new PropertyMetadata(null));

		// Token: 0x04000382 RID: 898
		public static readonly DependencyProperty CustomVisualStatesNameProperty = DependencyProperty.Register("CustomVisualStatesName", typeof(string), typeof(TransitioningContentControl), new PropertyMetadata("CustomTransition"));
	}
}
