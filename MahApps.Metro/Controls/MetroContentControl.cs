using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200005E RID: 94
	public class MetroContentControl : ContentControl
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000FC20 File Offset: 0x0000DE20
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000FC32 File Offset: 0x0000DE32
		public bool ReverseTransition
		{
			get
			{
				return (bool)base.GetValue(MetroContentControl.ReverseTransitionProperty);
			}
			set
			{
				base.SetValue(MetroContentControl.ReverseTransitionProperty, value);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000FC45 File Offset: 0x0000DE45
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000FC57 File Offset: 0x0000DE57
		public bool TransitionsEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroContentControl.TransitionsEnabledProperty);
			}
			set
			{
				base.SetValue(MetroContentControl.TransitionsEnabledProperty, value);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000FC6A File Offset: 0x0000DE6A
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000FC7C File Offset: 0x0000DE7C
		public bool OnlyLoadTransition
		{
			get
			{
				return (bool)base.GetValue(MetroContentControl.OnlyLoadTransitionProperty);
			}
			set
			{
				base.SetValue(MetroContentControl.OnlyLoadTransitionProperty, value);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000401 RID: 1025 RVA: 0x0000FC8F File Offset: 0x0000DE8F
		// (remove) Token: 0x06000402 RID: 1026 RVA: 0x0000FC9D File Offset: 0x0000DE9D
		public event RoutedEventHandler TransitionCompleted
		{
			add
			{
				base.AddHandler(MetroContentControl.TransitionCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroContentControl.TransitionCompletedEvent, value);
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000FCAB File Offset: 0x0000DEAB
		public MetroContentControl()
		{
			base.DefaultStyleKey = typeof(MetroContentControl);
			base.Loaded += this.MetroContentControlLoaded;
			base.Unloaded += this.MetroContentControlUnloaded;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000FCE8 File Offset: 0x0000DEE8
		private void MetroContentControlIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.TransitionsEnabled && !this.transitionLoaded)
			{
				if (!base.IsVisible)
				{
					VisualStateManager.GoToState(this, this.ReverseTransition ? "AfterUnLoadedReverse" : "AfterUnLoaded", false);
					return;
				}
				VisualStateManager.GoToState(this, this.ReverseTransition ? "AfterLoadedReverse" : "AfterLoaded", true);
			}
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000FD48 File Offset: 0x0000DF48
		private void MetroContentControlUnloaded(object sender, RoutedEventArgs e)
		{
			if (this.TransitionsEnabled)
			{
				this.UnsetStoryboardEvents();
				if (this.transitionLoaded)
				{
					VisualStateManager.GoToState(this, this.ReverseTransition ? "AfterUnLoadedReverse" : "AfterUnLoaded", false);
				}
				base.IsVisibleChanged -= this.MetroContentControlIsVisibleChanged;
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0000FD9C File Offset: 0x0000DF9C
		private void MetroContentControlLoaded(object sender, RoutedEventArgs e)
		{
			if (this.TransitionsEnabled)
			{
				if (!this.transitionLoaded)
				{
					this.SetStoryboardEvents();
					this.transitionLoaded = this.OnlyLoadTransition;
					VisualStateManager.GoToState(this, this.ReverseTransition ? "AfterLoadedReverse" : "AfterLoaded", true);
				}
				base.IsVisibleChanged -= this.MetroContentControlIsVisibleChanged;
				base.IsVisibleChanged += this.MetroContentControlIsVisibleChanged;
				return;
			}
			Grid grid = (Grid)base.GetTemplateChild("root");
			if (grid != null)
			{
				grid.Opacity = 1.0;
				TranslateTransform translateTransform = (TranslateTransform)grid.RenderTransform;
				if (translateTransform.IsFrozen)
				{
					TranslateTransform translateTransform2 = translateTransform.Clone();
					translateTransform2.X = 0.0;
					grid.RenderTransform = translateTransform2;
					return;
				}
				translateTransform.X = 0.0;
			}
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000FE70 File Offset: 0x0000E070
		public void Reload()
		{
			if (!this.TransitionsEnabled || this.transitionLoaded)
			{
				return;
			}
			if (this.ReverseTransition)
			{
				VisualStateManager.GoToState(this, "BeforeLoaded", true);
				VisualStateManager.GoToState(this, "AfterUnLoadedReverse", true);
				return;
			}
			VisualStateManager.GoToState(this, "BeforeLoaded", true);
			VisualStateManager.GoToState(this, "AfterLoaded", true);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x0000FECB File Offset: 0x0000E0CB
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.afterLoadedStoryboard = (base.GetTemplateChild("AfterLoadedStoryboard") as Storyboard);
			this.afterLoadedReverseStoryboard = (base.GetTemplateChild("AfterLoadedReverseStoryboard") as Storyboard);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0000FEFF File Offset: 0x0000E0FF
		private void AfterLoadedStoryboardCompleted(object sender, EventArgs e)
		{
			if (this.transitionLoaded)
			{
				this.UnsetStoryboardEvents();
			}
			base.InvalidateVisual();
			base.RaiseEvent(new RoutedEventArgs(MetroContentControl.TransitionCompletedEvent));
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000FF25 File Offset: 0x0000E125
		private void SetStoryboardEvents()
		{
			if (this.afterLoadedStoryboard != null)
			{
				this.afterLoadedStoryboard.Completed += this.AfterLoadedStoryboardCompleted;
			}
			if (this.afterLoadedReverseStoryboard != null)
			{
				this.afterLoadedReverseStoryboard.Completed += this.AfterLoadedStoryboardCompleted;
			}
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000FF65 File Offset: 0x0000E165
		private void UnsetStoryboardEvents()
		{
			if (this.afterLoadedStoryboard != null)
			{
				this.afterLoadedStoryboard.Completed -= this.AfterLoadedStoryboardCompleted;
			}
			if (this.afterLoadedReverseStoryboard != null)
			{
				this.afterLoadedReverseStoryboard.Completed -= this.AfterLoadedStoryboardCompleted;
			}
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
		// Note: this type is marked as 'beforefieldinit'.
		static MetroContentControl()
		{
			MetroContentControl.TransitionCompletedEvent = EventManager.RegisterRoutedEvent("TransitionCompleted", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MetroContentControl));
		}

		// Token: 0x04000188 RID: 392
		public static readonly DependencyProperty ReverseTransitionProperty = DependencyProperty.Register("ReverseTransition", typeof(bool), typeof(MetroContentControl), new FrameworkPropertyMetadata(false));

		// Token: 0x04000189 RID: 393
		public static readonly DependencyProperty TransitionsEnabledProperty = DependencyProperty.Register("TransitionsEnabled", typeof(bool), typeof(MetroContentControl), new FrameworkPropertyMetadata(true));

		// Token: 0x0400018A RID: 394
		public static readonly DependencyProperty OnlyLoadTransitionProperty = DependencyProperty.Register("OnlyLoadTransition", typeof(bool), typeof(MetroContentControl), new FrameworkPropertyMetadata(false));

		// Token: 0x0400018C RID: 396
		private Storyboard afterLoadedStoryboard;

		// Token: 0x0400018D RID: 397
		private Storyboard afterLoadedReverseStoryboard;

		// Token: 0x0400018E RID: 398
		private bool transitionLoaded;
	}
}
