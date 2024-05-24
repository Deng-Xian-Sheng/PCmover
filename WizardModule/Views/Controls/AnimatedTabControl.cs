using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WizardModule.Views.Controls
{
	// Token: 0x02000056 RID: 86
	public class AnimatedTabControl : TabControl
	{
		// Token: 0x060004BC RID: 1212 RVA: 0x0000AD92 File Offset: 0x00008F92
		public AnimatedTabControl()
		{
			base.DefaultStyleKey = typeof(AnimatedTabControl);
			this.pageStack = new Stack();
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060004BD RID: 1213 RVA: 0x0000ADB5 File Offset: 0x00008FB5
		// (set) Token: 0x060004BE RID: 1214 RVA: 0x0000ADC7 File Offset: 0x00008FC7
		public bool Animate
		{
			get
			{
				return (bool)base.GetValue(AnimatedTabControl.AnimateProperty);
			}
			set
			{
				base.SetValue(AnimatedTabControl.AnimateProperty, value);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060004BF RID: 1215 RVA: 0x0000ADDA File Offset: 0x00008FDA
		// (remove) Token: 0x060004C0 RID: 1216 RVA: 0x0000ADE8 File Offset: 0x00008FE8
		public event RoutedEventHandler SelectionChanging
		{
			add
			{
				base.AddHandler(AnimatedTabControl.SelectionChangingEvent, value);
			}
			remove
			{
				base.RemoveHandler(AnimatedTabControl.SelectionChangingEvent, value);
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060004C1 RID: 1217 RVA: 0x0000ADF6 File Offset: 0x00008FF6
		// (remove) Token: 0x060004C2 RID: 1218 RVA: 0x0000AE04 File Offset: 0x00009004
		public event RoutedEventHandler SelectionChangingBack
		{
			add
			{
				base.AddHandler(AnimatedTabControl.SelectionChangingEventBack, value);
			}
			remove
			{
				base.RemoveHandler(AnimatedTabControl.SelectionChangingEventBack, value);
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x0000AE14 File Offset: 0x00009014
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (!this.Animate)
			{
				base.OnSelectionChanged(e);
			}
			else
			{
				base.Dispatcher.BeginInvoke(new Action(delegate()
				{
					RoutedEventArgs e2 = new RoutedEventArgs(AnimatedTabControl.SelectionChangingEvent);
					if (e.AddedItems.Count != 0)
					{
						if (this.pageStack.Count != 0)
						{
							this.presentPage = (string)this.pageStack.Pop();
						}
						else
						{
							this.presentPage = null;
						}
						if (this.pageStack.Count != 0 && string.Compare((string)this.pageStack.Peek(), e.AddedItems[0].ToString()) == 0)
						{
							e2 = new RoutedEventArgs(AnimatedTabControl.SelectionChangingEventBack);
						}
						else
						{
							if (this.presentPage != null)
							{
								this.pageStack.Push(this.presentPage);
							}
							this.pageStack.Push(e.AddedItems[0].ToString());
						}
					}
					this.RaiseEvent(e2);
					this.StopTimer();
					this.timer = new DispatcherTimer
					{
						Interval = new TimeSpan(0, 0, 0, 0, 500)
					};
					EventHandler value = delegate(object sender, EventArgs args)
					{
						this.StopTimer();
						this.<>n__0(e);
					};
					this.timer.Tick += value;
					this.timer.Start();
				}), Array.Empty<object>());
			}
			base.Focus();
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x0000AE6F File Offset: 0x0000906F
		private void StopTimer()
		{
			if (this.timer != null)
			{
				this.timer.Stop();
				this.timer = null;
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0000AE8C File Offset: 0x0000908C
		// Note: this type is marked as 'beforefieldinit'.
		static AnimatedTabControl()
		{
			AnimatedTabControl.SelectionChangingEvent = EventManager.RegisterRoutedEvent("SelectionChanging", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(AnimatedTabControl));
			AnimatedTabControl.SelectionChangingEventBack = EventManager.RegisterRoutedEvent("SelectionChangingBack", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(AnimatedTabControl));
			AnimatedTabControl.AnimateProperty = DependencyProperty.Register("Animate", typeof(bool), typeof(AnimatedTabControl), new PropertyMetadata(null));
		}

		// Token: 0x040000B3 RID: 179
		public static readonly RoutedEvent SelectionChangingEventBack;

		// Token: 0x040000B4 RID: 180
		private DispatcherTimer timer;

		// Token: 0x040000B5 RID: 181
		private Stack pageStack;

		// Token: 0x040000B6 RID: 182
		private string presentPage;

		// Token: 0x040000B7 RID: 183
		public static readonly DependencyProperty AnimateProperty;
	}
}
