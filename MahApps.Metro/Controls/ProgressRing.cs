using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000077 RID: 119
	[TemplateVisualState(Name = "Large", GroupName = "SizeStates")]
	[TemplateVisualState(Name = "Small", GroupName = "SizeStates")]
	[TemplateVisualState(Name = "Inactive", GroupName = "ActiveStates")]
	[TemplateVisualState(Name = "Active", GroupName = "ActiveStates")]
	public class ProgressRing : Control
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x0001774C File Offset: 0x0001594C
		static ProgressRing()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressRing), new FrameworkPropertyMetadata(typeof(ProgressRing)));
			UIElement.VisibilityProperty.OverrideMetadata(typeof(ProgressRing), new FrameworkPropertyMetadata(delegate(DependencyObject ringObject, DependencyPropertyChangedEventArgs e)
			{
				if (e.NewValue != e.OldValue)
				{
					ProgressRing progressRing = (ProgressRing)ringObject;
					if ((Visibility)e.NewValue != Visibility.Visible)
					{
						progressRing.SetCurrentValue(ProgressRing.IsActiveProperty, false);
						return;
					}
					progressRing.SetCurrentValue(ProgressRing.IsActiveProperty, true);
				}
			}));
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x00017933 File Offset: 0x00015B33
		public ProgressRing()
		{
			base.SizeChanged += this.OnSizeChanged;
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00017958 File Offset: 0x00015B58
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0001796A File Offset: 0x00015B6A
		public double MaxSideLength
		{
			get
			{
				return (double)base.GetValue(ProgressRing.MaxSideLengthProperty);
			}
			private set
			{
				base.SetValue(ProgressRing.MaxSideLengthProperty, value);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0001797D File Offset: 0x00015B7D
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0001798F File Offset: 0x00015B8F
		public double EllipseDiameter
		{
			get
			{
				return (double)base.GetValue(ProgressRing.EllipseDiameterProperty);
			}
			private set
			{
				base.SetValue(ProgressRing.EllipseDiameterProperty, value);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x000179A2 File Offset: 0x00015BA2
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x000179B4 File Offset: 0x00015BB4
		public double EllipseDiameterScale
		{
			get
			{
				return (double)base.GetValue(ProgressRing.EllipseDiameterScaleProperty);
			}
			set
			{
				base.SetValue(ProgressRing.EllipseDiameterScaleProperty, value);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x000179C7 File Offset: 0x00015BC7
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x000179D9 File Offset: 0x00015BD9
		public Thickness EllipseOffset
		{
			get
			{
				return (Thickness)base.GetValue(ProgressRing.EllipseOffsetProperty);
			}
			private set
			{
				base.SetValue(ProgressRing.EllipseOffsetProperty, value);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x000179EC File Offset: 0x00015BEC
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x000179FE File Offset: 0x00015BFE
		public double BindableWidth
		{
			get
			{
				return (double)base.GetValue(ProgressRing.BindableWidthProperty);
			}
			private set
			{
				base.SetValue(ProgressRing.BindableWidthProperty, value);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x00017A11 File Offset: 0x00015C11
		// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00017A23 File Offset: 0x00015C23
		public bool IsActive
		{
			get
			{
				return (bool)base.GetValue(ProgressRing.IsActiveProperty);
			}
			set
			{
				base.SetValue(ProgressRing.IsActiveProperty, value);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x00017A36 File Offset: 0x00015C36
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x00017A48 File Offset: 0x00015C48
		public bool IsLarge
		{
			get
			{
				return (bool)base.GetValue(ProgressRing.IsLargeProperty);
			}
			set
			{
				base.SetValue(ProgressRing.IsLargeProperty, value);
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00017A5C File Offset: 0x00015C5C
		private static void BindableWidthCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ProgressRing ring = dependencyObject as ProgressRing;
			if (ring == null)
			{
				return;
			}
			Action action = delegate()
			{
				ring.SetEllipseDiameter((double)dependencyPropertyChangedEventArgs.NewValue);
				ring.SetEllipseOffset((double)dependencyPropertyChangedEventArgs.NewValue);
				ring.SetMaxSideLength((double)dependencyPropertyChangedEventArgs.NewValue);
			};
			if (ring._deferredActions != null)
			{
				ring._deferredActions.Add(action);
				return;
			}
			action();
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00017ABD File Offset: 0x00015CBD
		private void SetMaxSideLength(double width)
		{
			base.SetCurrentValue(ProgressRing.MaxSideLengthProperty, (width <= 20.0) ? 20.0 : width);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00017AE7 File Offset: 0x00015CE7
		private void SetEllipseDiameter(double width)
		{
			base.SetCurrentValue(ProgressRing.EllipseDiameterProperty, width / 8.0 * this.EllipseDiameterScale);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00017B0B File Offset: 0x00015D0B
		private void SetEllipseOffset(double width)
		{
			base.SetCurrentValue(ProgressRing.EllipseOffsetProperty, new Thickness(0.0, width / 2.0, 0.0, 0.0));
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00017B48 File Offset: 0x00015D48
		private static void IsLargeChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ProgressRing progressRing = dependencyObject as ProgressRing;
			if (progressRing == null)
			{
				return;
			}
			progressRing.UpdateLargeState();
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00017B68 File Offset: 0x00015D68
		private void UpdateLargeState()
		{
			Action action;
			if (this.IsLarge)
			{
				action = delegate()
				{
					VisualStateManager.GoToState(this, "Large", true);
				};
			}
			else
			{
				action = delegate()
				{
					VisualStateManager.GoToState(this, "Small", true);
				};
			}
			if (this._deferredActions != null)
			{
				this._deferredActions.Add(action);
				return;
			}
			action();
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00017BB4 File Offset: 0x00015DB4
		private void OnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
		{
			base.SetCurrentValue(ProgressRing.BindableWidthProperty, base.ActualWidth);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00017BCC File Offset: 0x00015DCC
		private static void IsActiveChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			ProgressRing progressRing = dependencyObject as ProgressRing;
			if (progressRing == null)
			{
				return;
			}
			progressRing.UpdateActiveState();
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00017BEC File Offset: 0x00015DEC
		private void UpdateActiveState()
		{
			Action action;
			if (this.IsActive)
			{
				action = delegate()
				{
					VisualStateManager.GoToState(this, "Active", true);
				};
			}
			else
			{
				action = delegate()
				{
					VisualStateManager.GoToState(this, "Inactive", true);
				};
			}
			if (this._deferredActions != null)
			{
				this._deferredActions.Add(action);
				return;
			}
			action();
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00017C38 File Offset: 0x00015E38
		public override void OnApplyTemplate()
		{
			this.UpdateLargeState();
			this.UpdateActiveState();
			base.OnApplyTemplate();
			if (this._deferredActions != null)
			{
				foreach (Action action in this._deferredActions)
				{
					action();
				}
			}
			this._deferredActions = null;
		}

		// Token: 0x0400025E RID: 606
		public static readonly DependencyProperty BindableWidthProperty = DependencyProperty.Register("BindableWidth", typeof(double), typeof(ProgressRing), new PropertyMetadata(0.0, new PropertyChangedCallback(ProgressRing.BindableWidthCallback)));

		// Token: 0x0400025F RID: 607
		public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(ProgressRing), new PropertyMetadata(true, new PropertyChangedCallback(ProgressRing.IsActiveChanged)));

		// Token: 0x04000260 RID: 608
		public static readonly DependencyProperty IsLargeProperty = DependencyProperty.Register("IsLarge", typeof(bool), typeof(ProgressRing), new PropertyMetadata(true, new PropertyChangedCallback(ProgressRing.IsLargeChangedCallback)));

		// Token: 0x04000261 RID: 609
		public static readonly DependencyProperty MaxSideLengthProperty = DependencyProperty.Register("MaxSideLength", typeof(double), typeof(ProgressRing), new PropertyMetadata(0.0));

		// Token: 0x04000262 RID: 610
		public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register("EllipseDiameter", typeof(double), typeof(ProgressRing), new PropertyMetadata(0.0));

		// Token: 0x04000263 RID: 611
		public static readonly DependencyProperty EllipseOffsetProperty = DependencyProperty.Register("EllipseOffset", typeof(Thickness), typeof(ProgressRing), new PropertyMetadata(default(Thickness)));

		// Token: 0x04000264 RID: 612
		public static readonly DependencyProperty EllipseDiameterScaleProperty = DependencyProperty.Register("EllipseDiameterScale", typeof(double), typeof(ProgressRing), new PropertyMetadata(1.0));

		// Token: 0x04000265 RID: 613
		private List<Action> _deferredActions = new List<Action>();
	}
}
