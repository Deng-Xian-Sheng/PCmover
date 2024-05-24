using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200007E RID: 126
	[DefaultEvent("RangeSelectionChanged")]
	[TemplatePart(Name = "PART_Container", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_RangeSliderContainer", Type = typeof(StackPanel))]
	[TemplatePart(Name = "PART_LeftEdge", Type = typeof(RepeatButton))]
	[TemplatePart(Name = "PART_LeftThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_MiddleThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_RightThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_RightEdge", Type = typeof(RepeatButton))]
	public class RangeSlider : RangeBase
	{
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000625 RID: 1573 RVA: 0x00017DEB File Offset: 0x00015FEB
		// (remove) Token: 0x06000626 RID: 1574 RVA: 0x00017DF9 File Offset: 0x00015FF9
		public event RangeSelectionChangedEventHandler RangeSelectionChanged
		{
			add
			{
				base.AddHandler(RangeSlider.RangeSelectionChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.RangeSelectionChangedEvent, value);
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000627 RID: 1575 RVA: 0x00017E07 File Offset: 0x00016007
		// (remove) Token: 0x06000628 RID: 1576 RVA: 0x00017E15 File Offset: 0x00016015
		public event RangeParameterChangedEventHandler LowerValueChanged
		{
			add
			{
				base.AddHandler(RangeSlider.LowerValueChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.LowerValueChangedEvent, value);
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000629 RID: 1577 RVA: 0x00017E23 File Offset: 0x00016023
		// (remove) Token: 0x0600062A RID: 1578 RVA: 0x00017E31 File Offset: 0x00016031
		public event RangeParameterChangedEventHandler UpperValueChanged
		{
			add
			{
				base.AddHandler(RangeSlider.UpperValueChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.UpperValueChangedEvent, value);
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x0600062B RID: 1579 RVA: 0x00017E3F File Offset: 0x0001603F
		// (remove) Token: 0x0600062C RID: 1580 RVA: 0x00017E4D File Offset: 0x0001604D
		public event DragStartedEventHandler LowerThumbDragStarted
		{
			add
			{
				base.AddHandler(RangeSlider.LowerThumbDragStartedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.LowerThumbDragStartedEvent, value);
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600062D RID: 1581 RVA: 0x00017E5B File Offset: 0x0001605B
		// (remove) Token: 0x0600062E RID: 1582 RVA: 0x00017E69 File Offset: 0x00016069
		public event DragCompletedEventHandler LowerThumbDragCompleted
		{
			add
			{
				base.AddHandler(RangeSlider.LowerThumbDragCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.LowerThumbDragCompletedEvent, value);
			}
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x0600062F RID: 1583 RVA: 0x00017E77 File Offset: 0x00016077
		// (remove) Token: 0x06000630 RID: 1584 RVA: 0x00017E85 File Offset: 0x00016085
		public event DragStartedEventHandler UpperThumbDragStarted
		{
			add
			{
				base.AddHandler(RangeSlider.UpperThumbDragStartedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.UpperThumbDragStartedEvent, value);
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000631 RID: 1585 RVA: 0x00017E93 File Offset: 0x00016093
		// (remove) Token: 0x06000632 RID: 1586 RVA: 0x00017EA1 File Offset: 0x000160A1
		public event DragCompletedEventHandler UpperThumbDragCompleted
		{
			add
			{
				base.AddHandler(RangeSlider.UpperThumbDragCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.UpperThumbDragCompletedEvent, value);
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x06000633 RID: 1587 RVA: 0x00017EAF File Offset: 0x000160AF
		// (remove) Token: 0x06000634 RID: 1588 RVA: 0x00017EBD File Offset: 0x000160BD
		public event DragStartedEventHandler CentralThumbDragStarted
		{
			add
			{
				base.AddHandler(RangeSlider.CentralThumbDragStartedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.CentralThumbDragStartedEvent, value);
			}
		}

		// Token: 0x1400002A RID: 42
		// (add) Token: 0x06000635 RID: 1589 RVA: 0x00017ECB File Offset: 0x000160CB
		// (remove) Token: 0x06000636 RID: 1590 RVA: 0x00017ED9 File Offset: 0x000160D9
		public event DragCompletedEventHandler CentralThumbDragCompleted
		{
			add
			{
				base.AddHandler(RangeSlider.CentralThumbDragCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.CentralThumbDragCompletedEvent, value);
			}
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000637 RID: 1591 RVA: 0x00017EE7 File Offset: 0x000160E7
		// (remove) Token: 0x06000638 RID: 1592 RVA: 0x00017EF5 File Offset: 0x000160F5
		public event DragDeltaEventHandler LowerThumbDragDelta
		{
			add
			{
				base.AddHandler(RangeSlider.LowerThumbDragDeltaEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.LowerThumbDragDeltaEvent, value);
			}
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000639 RID: 1593 RVA: 0x00017F03 File Offset: 0x00016103
		// (remove) Token: 0x0600063A RID: 1594 RVA: 0x00017F11 File Offset: 0x00016111
		public event DragDeltaEventHandler UpperThumbDragDelta
		{
			add
			{
				base.AddHandler(RangeSlider.UpperThumbDragDeltaEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.UpperThumbDragDeltaEvent, value);
			}
		}

		// Token: 0x1400002D RID: 45
		// (add) Token: 0x0600063B RID: 1595 RVA: 0x00017F1F File Offset: 0x0001611F
		// (remove) Token: 0x0600063C RID: 1596 RVA: 0x00017F2D File Offset: 0x0001612D
		public event DragDeltaEventHandler CentralThumbDragDelta
		{
			add
			{
				base.AddHandler(RangeSlider.CentralThumbDragDeltaEvent, value);
			}
			remove
			{
				base.RemoveHandler(RangeSlider.CentralThumbDragDeltaEvent, value);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x00017F3B File Offset: 0x0001613B
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x00017F4D File Offset: 0x0001614D
		[Bindable(true)]
		[Category("Behavior")]
		public int Interval
		{
			get
			{
				return (int)base.GetValue(RangeSlider.IntervalProperty);
			}
			set
			{
				base.SetValue(RangeSlider.IntervalProperty, value);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00017F60 File Offset: 0x00016160
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x00017F72 File Offset: 0x00016172
		[Bindable(true)]
		[Category("Appearance")]
		public int AutoToolTipPrecision
		{
			get
			{
				return (int)base.GetValue(RangeSlider.AutoToolTipPrecisionProperty);
			}
			set
			{
				base.SetValue(RangeSlider.AutoToolTipPrecisionProperty, value);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00017F85 File Offset: 0x00016185
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x00017F97 File Offset: 0x00016197
		[Bindable(true)]
		[Category("Behavior")]
		public IValueConverter AutoToolTipTextConverter
		{
			get
			{
				return (IValueConverter)base.GetValue(RangeSlider.AutoToolTipTextConverterProperty);
			}
			set
			{
				base.SetValue(RangeSlider.AutoToolTipTextConverterProperty, value);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x00017FA5 File Offset: 0x000161A5
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x00017FB7 File Offset: 0x000161B7
		[Bindable(true)]
		[Category("Behavior")]
		public AutoToolTipPlacement AutoToolTipPlacement
		{
			get
			{
				return (AutoToolTipPlacement)base.GetValue(RangeSlider.AutoToolTipPlacementProperty);
			}
			set
			{
				base.SetValue(RangeSlider.AutoToolTipPlacementProperty, value);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x00017FCA File Offset: 0x000161CA
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x00017FDC File Offset: 0x000161DC
		[Bindable(true)]
		[Category("Appearance")]
		public TickPlacement TickPlacement
		{
			get
			{
				return (TickPlacement)base.GetValue(RangeSlider.TickPlacementProperty);
			}
			set
			{
				base.SetValue(RangeSlider.TickPlacementProperty, value);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00017FEF File Offset: 0x000161EF
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00018001 File Offset: 0x00016201
		[Bindable(true)]
		[Category("Appearance")]
		public double TickFrequency
		{
			get
			{
				return (double)base.GetValue(RangeSlider.TickFrequencyProperty);
			}
			set
			{
				base.SetValue(RangeSlider.TickFrequencyProperty, value);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x00018014 File Offset: 0x00016214
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x00018026 File Offset: 0x00016226
		[Bindable(true)]
		[Category("Appearance")]
		public DoubleCollection Ticks
		{
			get
			{
				return (DoubleCollection)base.GetValue(RangeSlider.TicksProperty);
			}
			set
			{
				base.SetValue(RangeSlider.TicksProperty, value);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00018034 File Offset: 0x00016234
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x00018046 File Offset: 0x00016246
		[Bindable(true)]
		[Category("Behavior")]
		public bool IsMoveToPointEnabled
		{
			get
			{
				return (bool)base.GetValue(RangeSlider.IsMoveToPointEnabledProperty);
			}
			set
			{
				base.SetValue(RangeSlider.IsMoveToPointEnabledProperty, value);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00018059 File Offset: 0x00016259
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x0001806B File Offset: 0x0001626B
		[Bindable(true)]
		[Category("Common")]
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(RangeSlider.OrientationProperty);
			}
			set
			{
				base.SetValue(RangeSlider.OrientationProperty, value);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0001807E File Offset: 0x0001627E
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x00018090 File Offset: 0x00016290
		[Bindable(true)]
		[Category("Appearance")]
		public bool IsSnapToTickEnabled
		{
			get
			{
				return (bool)base.GetValue(RangeSlider.IsSnapToTickEnabledProperty);
			}
			set
			{
				base.SetValue(RangeSlider.IsSnapToTickEnabledProperty, value);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x000180A3 File Offset: 0x000162A3
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x000180B5 File Offset: 0x000162B5
		[Bindable(true)]
		[Category("Behavior")]
		public bool ExtendedMode
		{
			get
			{
				return (bool)base.GetValue(RangeSlider.ExtendedModeProperty);
			}
			set
			{
				base.SetValue(RangeSlider.ExtendedModeProperty, value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x000180C8 File Offset: 0x000162C8
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x000180DA File Offset: 0x000162DA
		[Bindable(true)]
		[Category("Behavior")]
		public bool MoveWholeRange
		{
			get
			{
				return (bool)base.GetValue(RangeSlider.MoveWholeRangeProperty);
			}
			set
			{
				base.SetValue(RangeSlider.MoveWholeRangeProperty, value);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x000180ED File Offset: 0x000162ED
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x000180FF File Offset: 0x000162FF
		[Bindable(true)]
		[Category("Common")]
		public double MinRangeWidth
		{
			get
			{
				return (double)base.GetValue(RangeSlider.MinRangeWidthProperty);
			}
			set
			{
				base.SetValue(RangeSlider.MinRangeWidthProperty, value);
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x00018112 File Offset: 0x00016312
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x00018124 File Offset: 0x00016324
		[Bindable(true)]
		[Category("Common")]
		public double LowerValue
		{
			get
			{
				return (double)base.GetValue(RangeSlider.LowerValueProperty);
			}
			set
			{
				base.SetValue(RangeSlider.LowerValueProperty, value);
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x00018137 File Offset: 0x00016337
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x00018149 File Offset: 0x00016349
		[Bindable(true)]
		[Category("Common")]
		public double UpperValue
		{
			get
			{
				return (double)base.GetValue(RangeSlider.UpperValueProperty);
			}
			set
			{
				base.SetValue(RangeSlider.UpperValueProperty, value);
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x0001815C File Offset: 0x0001635C
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x0001816E File Offset: 0x0001636E
		[Bindable(true)]
		[Category("Common")]
		public double MinRange
		{
			get
			{
				return (double)base.GetValue(RangeSlider.MinRangeProperty);
			}
			set
			{
				base.SetValue(RangeSlider.MinRangeProperty, value);
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00018181 File Offset: 0x00016381
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x00018193 File Offset: 0x00016393
		[Bindable(true)]
		[Category("Appearance")]
		public bool IsSelectionRangeEnabled
		{
			get
			{
				return (bool)base.GetValue(RangeSlider.IsSelectionRangeEnabledProperty);
			}
			set
			{
				base.SetValue(RangeSlider.IsSelectionRangeEnabledProperty, value);
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x000181A6 File Offset: 0x000163A6
		// (set) Token: 0x06000660 RID: 1632 RVA: 0x000181B8 File Offset: 0x000163B8
		[Bindable(true)]
		[Category("Appearance")]
		public double SelectionStart
		{
			get
			{
				return (double)base.GetValue(RangeSlider.SelectionStartProperty);
			}
			set
			{
				base.SetValue(RangeSlider.SelectionStartProperty, value);
			}
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x000181CB File Offset: 0x000163CB
		private static void OnSelectionStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((RangeSlider)d).CoerceValue(RangeSlider.SelectionEndProperty);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000181E0 File Offset: 0x000163E0
		private static object CoerceSelectionStart(DependencyObject d, object value)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			double num = (double)value;
			double minimum = rangeSlider.Minimum;
			double maximum = rangeSlider.Maximum;
			if (num < minimum)
			{
				return minimum;
			}
			if (num > maximum)
			{
				return maximum;
			}
			return value;
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000663 RID: 1635 RVA: 0x0001821E File Offset: 0x0001641E
		// (set) Token: 0x06000664 RID: 1636 RVA: 0x00018230 File Offset: 0x00016430
		[Bindable(true)]
		[Category("Appearance")]
		public double SelectionEnd
		{
			get
			{
				return (double)base.GetValue(RangeSlider.SelectionEndProperty);
			}
			set
			{
				base.SetValue(RangeSlider.SelectionEndProperty, value);
			}
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00018243 File Offset: 0x00016443
		private static void OnSelectionEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00018248 File Offset: 0x00016448
		private static object CoerceSelectionEnd(DependencyObject d, object value)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			double num = (double)value;
			double selectionStart = rangeSlider.SelectionStart;
			double maximum = rangeSlider.Maximum;
			if (num < selectionStart)
			{
				return selectionStart;
			}
			if (num > maximum)
			{
				return maximum;
			}
			return value;
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000667 RID: 1639 RVA: 0x00018286 File Offset: 0x00016486
		public double MovableRange
		{
			get
			{
				return base.Maximum - base.Minimum - this.MinRange;
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001829C File Offset: 0x0001649C
		public RangeSlider()
		{
			base.CommandBindings.Add(new CommandBinding(RangeSlider.MoveBack, new ExecutedRoutedEventHandler(this.MoveBackHandler)));
			base.CommandBindings.Add(new CommandBinding(RangeSlider.MoveForward, new ExecutedRoutedEventHandler(this.MoveForwardHandler)));
			base.CommandBindings.Add(new CommandBinding(RangeSlider.MoveAllForward, new ExecutedRoutedEventHandler(this.MoveAllForwardHandler)));
			base.CommandBindings.Add(new CommandBinding(RangeSlider.MoveAllBack, new ExecutedRoutedEventHandler(this.MoveAllBackHandler)));
			this.actualWidthPropertyChangeNotifier = new PropertyChangeNotifier(this, FrameworkElement.ActualWidthProperty);
			this.actualWidthPropertyChangeNotifier.ValueChanged += delegate(object s, EventArgs e)
			{
				this.ReCalculateSize();
			};
			this.actualHeightPropertyChangeNotifier = new PropertyChangeNotifier(this, FrameworkElement.ActualHeightProperty);
			this.actualHeightPropertyChangeNotifier.ValueChanged += delegate(object s, EventArgs e)
			{
				this.ReCalculateSize();
			};
			this._timer = new DispatcherTimer();
			this._timer.Tick += this.MoveToNextValue;
			this._timer.Interval = TimeSpan.FromMilliseconds((double)this.Interval);
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x000183C0 File Offset: 0x000165C0
		static RangeSlider()
		{
			RangeSlider.RangeSelectionChangedEvent = EventManager.RegisterRoutedEvent("RangeSelectionChanged", RoutingStrategy.Bubble, typeof(RangeSelectionChangedEventHandler), typeof(RangeSlider));
			RangeSlider.LowerValueChangedEvent = EventManager.RegisterRoutedEvent("LowerValueChanged", RoutingStrategy.Bubble, typeof(RangeParameterChangedEventHandler), typeof(RangeSlider));
			RangeSlider.UpperValueChangedEvent = EventManager.RegisterRoutedEvent("UpperValueChanged", RoutingStrategy.Bubble, typeof(RangeParameterChangedEventHandler), typeof(RangeSlider));
			RangeSlider.LowerThumbDragStartedEvent = EventManager.RegisterRoutedEvent("LowerThumbDragStarted", RoutingStrategy.Bubble, typeof(DragStartedEventHandler), typeof(RangeSlider));
			RangeSlider.LowerThumbDragCompletedEvent = EventManager.RegisterRoutedEvent("LowerThumbDragCompleted", RoutingStrategy.Bubble, typeof(DragCompletedEventHandler), typeof(RangeSlider));
			RangeSlider.UpperThumbDragStartedEvent = EventManager.RegisterRoutedEvent("UpperThumbDragStarted", RoutingStrategy.Bubble, typeof(DragStartedEventHandler), typeof(RangeSlider));
			RangeSlider.UpperThumbDragCompletedEvent = EventManager.RegisterRoutedEvent("UpperThumbDragCompleted", RoutingStrategy.Bubble, typeof(DragCompletedEventHandler), typeof(RangeSlider));
			RangeSlider.CentralThumbDragStartedEvent = EventManager.RegisterRoutedEvent("CentralThumbDragStarted", RoutingStrategy.Bubble, typeof(DragStartedEventHandler), typeof(RangeSlider));
			RangeSlider.CentralThumbDragCompletedEvent = EventManager.RegisterRoutedEvent("CentralThumbDragCompleted", RoutingStrategy.Bubble, typeof(DragCompletedEventHandler), typeof(RangeSlider));
			RangeSlider.LowerThumbDragDeltaEvent = EventManager.RegisterRoutedEvent("LowerThumbDragDelta", RoutingStrategy.Bubble, typeof(DragDeltaEventHandler), typeof(RangeSlider));
			RangeSlider.UpperThumbDragDeltaEvent = EventManager.RegisterRoutedEvent("UpperThumbDragDelta", RoutingStrategy.Bubble, typeof(DragDeltaEventHandler), typeof(RangeSlider));
			RangeSlider.CentralThumbDragDeltaEvent = EventManager.RegisterRoutedEvent("CentralThumbDragDelta", RoutingStrategy.Bubble, typeof(DragDeltaEventHandler), typeof(RangeSlider));
			RangeSlider.UpperValueProperty = DependencyProperty.Register("UpperValue", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RangeSlider.RangesChanged), new CoerceValueCallback(RangeSlider.CoerceUpperValue)));
			RangeSlider.LowerValueProperty = DependencyProperty.Register("LowerValue", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RangeSlider.RangesChanged), new CoerceValueCallback(RangeSlider.CoerceLowerValue)));
			RangeSlider.MinRangeProperty = DependencyProperty.Register("MinRange", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(RangeSlider.MinRangeChanged), new CoerceValueCallback(RangeSlider.CoerceMinRange)), new ValidateValueCallback(RangeSlider.IsValidMinRange));
			RangeSlider.MinRangeWidthProperty = DependencyProperty.Register("MinRangeWidth", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(30.0, new PropertyChangedCallback(RangeSlider.MinRangeWidthChanged), new CoerceValueCallback(RangeSlider.CoerceMinRangeWidth)), new ValidateValueCallback(RangeSlider.IsValidMinRange));
			RangeSlider.MoveWholeRangeProperty = DependencyProperty.Register("MoveWholeRange", typeof(bool), typeof(RangeSlider), new PropertyMetadata(false));
			RangeSlider.ExtendedModeProperty = DependencyProperty.Register("ExtendedMode", typeof(bool), typeof(RangeSlider), new PropertyMetadata(false));
			RangeSlider.IsSnapToTickEnabledProperty = DependencyProperty.Register("IsSnapToTickEnabled", typeof(bool), typeof(RangeSlider), new PropertyMetadata(false));
			RangeSlider.OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(RangeSlider), new FrameworkPropertyMetadata(Orientation.Horizontal));
			RangeSlider.TickPlacementProperty = DependencyProperty.Register("TickPlacement", typeof(TickPlacement), typeof(RangeSlider), new FrameworkPropertyMetadata(TickPlacement.None));
			RangeSlider.TickFrequencyProperty = DependencyProperty.Register("TickFrequency", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(1.0), new ValidateValueCallback(RangeSlider.IsValidDoubleValue));
			RangeSlider.TicksProperty = DependencyProperty.Register("Ticks", typeof(DoubleCollection), typeof(RangeSlider), new FrameworkPropertyMetadata(null));
			RangeSlider.IsMoveToPointEnabledProperty = DependencyProperty.Register("IsMoveToPointEnabled", typeof(bool), typeof(RangeSlider), new PropertyMetadata(false));
			RangeSlider.AutoToolTipPlacementProperty = DependencyProperty.Register("AutoToolTipPlacement", typeof(AutoToolTipPlacement), typeof(RangeSlider), new FrameworkPropertyMetadata(AutoToolTipPlacement.None));
			RangeSlider.AutoToolTipPrecisionProperty = DependencyProperty.Register("AutoToolTipPrecision", typeof(int), typeof(RangeSlider), new FrameworkPropertyMetadata(0), new ValidateValueCallback(RangeSlider.IsValidPrecision));
			RangeSlider.AutoToolTipTextConverterProperty = DependencyProperty.Register("AutoToolTipTextConverter", typeof(IValueConverter), typeof(RangeSlider), new FrameworkPropertyMetadata(null));
			RangeSlider.IntervalProperty = DependencyProperty.Register("Interval", typeof(int), typeof(RangeSlider), new FrameworkPropertyMetadata(100, new PropertyChangedCallback(RangeSlider.IntervalChangedCallback)), new ValidateValueCallback(RangeSlider.IsValidPrecision));
			RangeSlider.IsSelectionRangeEnabledProperty = DependencyProperty.Register("IsSelectionRangeEnabled", typeof(bool), typeof(RangeSlider), new FrameworkPropertyMetadata(false));
			RangeSlider.SelectionStartProperty = DependencyProperty.Register("SelectionStart", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RangeSlider.OnSelectionStartChanged), new CoerceValueCallback(RangeSlider.CoerceSelectionStart)), new ValidateValueCallback(RangeSlider.IsValidDoubleValue));
			RangeSlider.SelectionEndProperty = DependencyProperty.Register("SelectionEnd", typeof(double), typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(RangeSlider.OnSelectionEndChanged), new CoerceValueCallback(RangeSlider.CoerceSelectionEnd)), new ValidateValueCallback(RangeSlider.IsValidDoubleValue));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(RangeSlider), new FrameworkPropertyMetadata(typeof(RangeSlider)));
			RangeBase.MinimumProperty.OverrideMetadata(typeof(RangeSlider), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(RangeSlider.MinPropertyChangedCallback), new CoerceValueCallback(RangeSlider.CoerceMinimum)));
			RangeBase.MaximumProperty.OverrideMetadata(typeof(RangeSlider), new FrameworkPropertyMetadata(100.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(RangeSlider.MaxPropertyChangedCallback), new CoerceValueCallback(RangeSlider.CoerceMaximum)));
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x00018B8D File Offset: 0x00016D8D
		protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
		{
			base.CoerceValue(RangeSlider.SelectionStartProperty);
			this.ReCalculateSize();
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00018BA0 File Offset: 0x00016DA0
		protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
		{
			base.CoerceValue(RangeSlider.SelectionStartProperty);
			base.CoerceValue(RangeSlider.SelectionEndProperty);
			this.ReCalculateSize();
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x00018BBE File Offset: 0x00016DBE
		private void MoveAllBackHandler(object sender, ExecutedRoutedEventArgs e)
		{
			this.ResetSelection(true);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00018BC7 File Offset: 0x00016DC7
		private void MoveAllForwardHandler(object sender, ExecutedRoutedEventArgs e)
		{
			this.ResetSelection(false);
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00018BD0 File Offset: 0x00016DD0
		private void MoveBackHandler(object sender, ExecutedRoutedEventArgs e)
		{
			this.MoveSelection(true);
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00018BD9 File Offset: 0x00016DD9
		private void MoveForwardHandler(object sender, ExecutedRoutedEventArgs e)
		{
			this.MoveSelection(false);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x00018BE4 File Offset: 0x00016DE4
		private static void MoveThumb(FrameworkElement x, FrameworkElement y, double change, Orientation orientation)
		{
			RangeSlider.Direction direction = RangeSlider.Direction.Increase;
			RangeSlider.MoveThumb(x, y, change, orientation, out direction);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00018C00 File Offset: 0x00016E00
		private static void MoveThumb(FrameworkElement x, FrameworkElement y, double change, Orientation orientation, out RangeSlider.Direction direction)
		{
			direction = RangeSlider.Direction.Increase;
			if (orientation == Orientation.Horizontal)
			{
				direction = ((change < 0.0) ? RangeSlider.Direction.Decrease : RangeSlider.Direction.Increase);
				RangeSlider.MoveThumbHorizontal(x, y, change);
				return;
			}
			if (orientation == Orientation.Vertical)
			{
				direction = ((change < 0.0) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease);
				RangeSlider.MoveThumbVertical(x, y, change);
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x00018C50 File Offset: 0x00016E50
		private static void MoveThumbHorizontal(FrameworkElement x, FrameworkElement y, double horizonalChange)
		{
			if (!double.IsNaN(x.Width) && !double.IsNaN(y.Width))
			{
				if (horizonalChange < 0.0)
				{
					double changeKeepPositive = RangeSlider.GetChangeKeepPositive(x.Width, horizonalChange);
					if (!(x.Name == "PART_MiddleThumb"))
					{
						x.Width += changeKeepPositive;
						y.Width -= changeKeepPositive;
						return;
					}
					if (x.Width > x.MinWidth)
					{
						if (x.Width + changeKeepPositive < x.MinWidth)
						{
							double num = x.Width - x.MinWidth;
							x.Width = x.MinWidth;
							y.Width += num;
							return;
						}
						x.Width += changeKeepPositive;
						y.Width -= changeKeepPositive;
						return;
					}
				}
				else if (horizonalChange > 0.0)
				{
					double num2 = -RangeSlider.GetChangeKeepPositive(y.Width, -horizonalChange);
					if (y.Name == "PART_MiddleThumb")
					{
						if (y.Width > y.MinWidth)
						{
							if (y.Width - num2 < y.MinWidth)
							{
								double num3 = y.Width - y.MinWidth;
								y.Width = y.MinWidth;
								x.Width += num3;
								return;
							}
							x.Width += num2;
							y.Width -= num2;
							return;
						}
					}
					else
					{
						x.Width += num2;
						y.Width -= num2;
					}
				}
			}
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x00018DE0 File Offset: 0x00016FE0
		private static void MoveThumbVertical(FrameworkElement x, FrameworkElement y, double verticalChange)
		{
			if (!double.IsNaN(x.Height) && !double.IsNaN(y.Height))
			{
				if (verticalChange < 0.0)
				{
					double num = -RangeSlider.GetChangeKeepPositive(y.Height, verticalChange);
					if (!(y.Name == "PART_MiddleThumb"))
					{
						x.Height += num;
						y.Height -= num;
						return;
					}
					if (y.Height > y.MinHeight)
					{
						if (y.Height - num < y.MinHeight)
						{
							double num2 = y.Height - y.MinHeight;
							y.Height = y.MinHeight;
							x.Height += num2;
							return;
						}
						x.Height += num;
						y.Height -= num;
						return;
					}
				}
				else if (verticalChange > 0.0)
				{
					double changeKeepPositive = RangeSlider.GetChangeKeepPositive(x.Height, -verticalChange);
					if (x.Name == "PART_MiddleThumb")
					{
						if (x.Height > y.MinHeight)
						{
							if (x.Height + changeKeepPositive < x.MinHeight)
							{
								double num3 = x.Height - x.MinHeight;
								x.Height = x.MinHeight;
								y.Height += num3;
								return;
							}
							x.Height += changeKeepPositive;
							y.Height -= changeKeepPositive;
							return;
						}
					}
					else
					{
						x.Height += changeKeepPositive;
						y.Height -= changeKeepPositive;
					}
				}
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00018F70 File Offset: 0x00017170
		private void ReCalculateSize()
		{
			if (this._leftButton != null && this._rightButton != null && this._centerThumb != null)
			{
				if (this.Orientation == Orientation.Horizontal)
				{
					this._movableWidth = Math.Max(base.ActualWidth - this._rightThumb.ActualWidth - this._leftThumb.ActualWidth - this.MinRangeWidth, 1.0);
					if (this.MovableRange <= 0.0)
					{
						this._leftButton.Width = double.NaN;
						this._rightButton.Width = double.NaN;
					}
					else
					{
						this._leftButton.Width = Math.Max(this._movableWidth * (this.LowerValue - base.Minimum) / this.MovableRange, 0.0);
						this._rightButton.Width = Math.Max(this._movableWidth * (base.Maximum - this.UpperValue) / this.MovableRange, 0.0);
					}
					if (RangeSlider.IsValidDouble(this._rightButton.Width) && RangeSlider.IsValidDouble(this._leftButton.Width))
					{
						this._centerThumb.Width = Math.Max(base.ActualWidth - (this._leftButton.Width + this._rightButton.Width + this._rightThumb.ActualWidth + this._leftThumb.ActualWidth), 0.0);
					}
					else
					{
						this._centerThumb.Width = Math.Max(base.ActualWidth - (this._rightThumb.ActualWidth + this._leftThumb.ActualWidth), 0.0);
					}
				}
				else if (this.Orientation == Orientation.Vertical)
				{
					this._movableWidth = Math.Max(base.ActualHeight - this._rightThumb.ActualHeight - this._leftThumb.ActualHeight - this.MinRangeWidth, 1.0);
					if (this.MovableRange <= 0.0)
					{
						this._leftButton.Height = double.NaN;
						this._rightButton.Height = double.NaN;
					}
					else
					{
						this._leftButton.Height = Math.Max(this._movableWidth * (this.LowerValue - base.Minimum) / this.MovableRange, 0.0);
						this._rightButton.Height = Math.Max(this._movableWidth * (base.Maximum - this.UpperValue) / this.MovableRange, 0.0);
					}
					if (RangeSlider.IsValidDouble(this._rightButton.Height) && RangeSlider.IsValidDouble(this._leftButton.Height))
					{
						this._centerThumb.Height = Math.Max(base.ActualHeight - (this._leftButton.Height + this._rightButton.Height + this._rightThumb.ActualHeight + this._leftThumb.ActualHeight), 0.0);
					}
					else
					{
						this._centerThumb.Height = Math.Max(base.ActualHeight - (this._rightThumb.ActualHeight + this._leftThumb.ActualHeight), 0.0);
					}
				}
				this._density = this._movableWidth / this.MovableRange;
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x000192E0 File Offset: 0x000174E0
		private void ReCalculateRangeSelected(bool reCalculateLowerValue, bool reCalculateUpperValue, RangeSlider.Direction direction)
		{
			this._internalUpdate = true;
			if (direction == RangeSlider.Direction.Increase)
			{
				if (reCalculateUpperValue)
				{
					this._oldUpper = this.UpperValue;
					double num = (this.Orientation == Orientation.Horizontal) ? this._rightButton.Width : this._rightButton.Height;
					if (RangeSlider.IsValidDouble(num))
					{
						double num2 = object.Equals(num, 0.0) ? base.Maximum : Math.Min(base.Maximum, base.Maximum - this.MovableRange * num / this._movableWidth);
						this.UpperValue = (this._isMoved ? num2 : (this._roundToPrecision ? Math.Round(num2, this._precision) : num2));
					}
				}
				if (reCalculateLowerValue)
				{
					this._oldLower = this.LowerValue;
					double num3 = (this.Orientation == Orientation.Horizontal) ? this._leftButton.Width : this._leftButton.Height;
					if (RangeSlider.IsValidDouble(num3))
					{
						double num4 = object.Equals(num3, 0.0) ? base.Minimum : Math.Max(base.Minimum, base.Minimum + this.MovableRange * num3 / this._movableWidth);
						this.LowerValue = (this._isMoved ? num4 : (this._roundToPrecision ? Math.Round(num4, this._precision) : num4));
					}
				}
			}
			else
			{
				if (reCalculateLowerValue)
				{
					this._oldLower = this.LowerValue;
					double num5 = (this.Orientation == Orientation.Horizontal) ? this._leftButton.Width : this._leftButton.Height;
					if (RangeSlider.IsValidDouble(num5))
					{
						double num6 = object.Equals(num5, 0.0) ? base.Minimum : Math.Max(base.Minimum, base.Minimum + this.MovableRange * num5 / this._movableWidth);
						this.LowerValue = (this._isMoved ? num6 : (this._roundToPrecision ? Math.Round(num6, this._precision) : num6));
					}
				}
				if (reCalculateUpperValue)
				{
					this._oldUpper = this.UpperValue;
					double num7 = (this.Orientation == Orientation.Horizontal) ? this._rightButton.Width : this._rightButton.Height;
					if (RangeSlider.IsValidDouble(num7))
					{
						double num8 = object.Equals(num7, 0.0) ? base.Maximum : Math.Min(base.Maximum, base.Maximum - this.MovableRange * num7 / this._movableWidth);
						this.UpperValue = (this._isMoved ? num8 : (this._roundToPrecision ? Math.Round(num8, this._precision) : num8));
					}
				}
			}
			this._roundToPrecision = false;
			this._internalUpdate = false;
			RangeSlider.RaiseValueChangedEvents(this, reCalculateLowerValue, reCalculateUpperValue);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x000195C8 File Offset: 0x000177C8
		private void ReCalculateRangeSelected(bool reCalculateLowerValue, bool reCalculateUpperValue, double value, RangeSlider.Direction direction)
		{
			this._internalUpdate = true;
			string text = this.TickFrequency.ToString(CultureInfo.InvariantCulture);
			if (reCalculateLowerValue)
			{
				this._oldLower = this.LowerValue;
				double num = 0.0;
				if (this.IsSnapToTickEnabled)
				{
					num = ((direction == RangeSlider.Direction.Increase) ? Math.Min(this.UpperValue - this.MinRange, value) : Math.Max(base.Minimum, value));
				}
				if (!text.ToLower().Contains("e+") && text.Contains("."))
				{
					string[] array = text.Split(new char[]
					{
						'.'
					});
					this.LowerValue = Math.Round(num, array[1].Length, MidpointRounding.AwayFromZero);
				}
				else
				{
					this.LowerValue = num;
				}
			}
			if (reCalculateUpperValue)
			{
				this._oldUpper = this.UpperValue;
				double num2 = 0.0;
				if (this.IsSnapToTickEnabled)
				{
					num2 = ((direction == RangeSlider.Direction.Increase) ? Math.Min(value, base.Maximum) : Math.Max(this.LowerValue + this.MinRange, value));
				}
				if (!text.ToLower().Contains("e+") && text.Contains("."))
				{
					string[] array2 = text.Split(new char[]
					{
						'.'
					});
					this.UpperValue = Math.Round(num2, array2[1].Length, MidpointRounding.AwayFromZero);
				}
				else
				{
					this.UpperValue = num2;
				}
			}
			this._internalUpdate = false;
			RangeSlider.RaiseValueChangedEvents(this, reCalculateLowerValue, reCalculateUpperValue);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00019738 File Offset: 0x00017938
		private void ReCalculateRangeSelected(double newLower, double newUpper, RangeSlider.Direction direction)
		{
			this._internalUpdate = true;
			this._oldLower = this.LowerValue;
			this._oldUpper = this.UpperValue;
			if (this.IsSnapToTickEnabled)
			{
				double num;
				double num2;
				if (direction == RangeSlider.Direction.Increase)
				{
					num = Math.Min(newLower, base.Maximum - (this.UpperValue - this.LowerValue));
					num2 = Math.Min(newUpper, base.Maximum);
				}
				else
				{
					num = Math.Max(newLower, base.Minimum);
					num2 = Math.Max(base.Minimum + (this.UpperValue - this.LowerValue), newUpper);
				}
				string text = this.TickFrequency.ToString(CultureInfo.InvariantCulture);
				if (!text.ToLower().Contains("e+") && text.Contains("."))
				{
					string[] array = text.Split(new char[]
					{
						'.'
					});
					if (direction == RangeSlider.Direction.Decrease)
					{
						this.LowerValue = Math.Round(num, array[1].Length, MidpointRounding.AwayFromZero);
						this.UpperValue = Math.Round(num2, array[1].Length, MidpointRounding.AwayFromZero);
					}
					else
					{
						this.UpperValue = Math.Round(num2, array[1].Length, MidpointRounding.AwayFromZero);
						this.LowerValue = Math.Round(num, array[1].Length, MidpointRounding.AwayFromZero);
					}
				}
				else if (direction == RangeSlider.Direction.Decrease)
				{
					this.LowerValue = num;
					this.UpperValue = num2;
				}
				else
				{
					this.UpperValue = num2;
					this.LowerValue = num;
				}
			}
			this._internalUpdate = false;
			RangeSlider.RaiseValueChangedEvents(this, true, true);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x000198B2 File Offset: 0x00017AB2
		private void OnRangeParameterChanged(RangeParameterChangedEventArgs e, RoutedEvent Event)
		{
			e.RoutedEvent = Event;
			base.RaiseEvent(e);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x000198C4 File Offset: 0x00017AC4
		public void MoveSelection(bool isLeft)
		{
			double num = base.SmallChange * (this.UpperValue - this.LowerValue) * this._movableWidth / this.MovableRange;
			num = (isLeft ? (-num) : num);
			RangeSlider.MoveThumb(this._leftButton, this._rightButton, num, this.Orientation, out this._direction);
			this.ReCalculateRangeSelected(true, true, this._direction);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0001992C File Offset: 0x00017B2C
		public void ResetSelection(bool isStart)
		{
			double num = base.Maximum - base.Minimum;
			num = (isStart ? (-num) : num);
			RangeSlider.MoveThumb(this._leftButton, this._rightButton, num, this.Orientation, out this._direction);
			this.ReCalculateRangeSelected(true, true, this._direction);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0001997C File Offset: 0x00017B7C
		private void OnRangeSelectionChanged(RangeSelectionChangedEventArgs e)
		{
			e.RoutedEvent = RangeSlider.RangeSelectionChangedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00019990 File Offset: 0x00017B90
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._container = (base.GetTemplateChild("PART_Container") as FrameworkElement);
			this._visualElementsContainer = (base.GetTemplateChild("PART_RangeSliderContainer") as StackPanel);
			this._centerThumb = (base.GetTemplateChild("PART_MiddleThumb") as Thumb);
			this._leftButton = (base.GetTemplateChild("PART_LeftEdge") as RepeatButton);
			this._rightButton = (base.GetTemplateChild("PART_RightEdge") as RepeatButton);
			this._leftThumb = (base.GetTemplateChild("PART_LeftThumb") as Thumb);
			this._rightThumb = (base.GetTemplateChild("PART_RightThumb") as Thumb);
			this.InitializeVisualElementsContainer();
			this.ReCalculateSize();
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x00019A4C File Offset: 0x00017C4C
		private void InitializeVisualElementsContainer()
		{
			if (this._visualElementsContainer != null && this._leftThumb != null && this._rightThumb != null && this._centerThumb != null)
			{
				this._leftThumb.DragCompleted -= this.LeftThumbDragComplete;
				this._rightThumb.DragCompleted -= this.RightThumbDragComplete;
				this._leftThumb.DragStarted -= this.LeftThumbDragStart;
				this._rightThumb.DragStarted -= this.RightThumbDragStart;
				this._centerThumb.DragStarted -= this.CenterThumbDragStarted;
				this._centerThumb.DragCompleted -= this.CenterThumbDragCompleted;
				this._centerThumb.DragDelta -= this.CenterThumbDragDelta;
				this._leftThumb.DragDelta -= this.LeftThumbDragDelta;
				this._rightThumb.DragDelta -= this.RightThumbDragDelta;
				this._visualElementsContainer.PreviewMouseDown -= this.VisualElementsContainerPreviewMouseDown;
				this._visualElementsContainer.PreviewMouseUp -= this.VisualElementsContainerPreviewMouseUp;
				this._visualElementsContainer.MouseLeave -= this.VisualElementsContainerMouseLeave;
				this._visualElementsContainer.MouseDown -= this.VisualElementsContainerMouseDown;
				this._leftThumb.DragCompleted += this.LeftThumbDragComplete;
				this._rightThumb.DragCompleted += this.RightThumbDragComplete;
				this._leftThumb.DragStarted += this.LeftThumbDragStart;
				this._rightThumb.DragStarted += this.RightThumbDragStart;
				this._centerThumb.DragStarted += this.CenterThumbDragStarted;
				this._centerThumb.DragCompleted += this.CenterThumbDragCompleted;
				this._centerThumb.DragDelta += this.CenterThumbDragDelta;
				this._leftThumb.DragDelta += this.LeftThumbDragDelta;
				this._rightThumb.DragDelta += this.RightThumbDragDelta;
				this._visualElementsContainer.PreviewMouseDown += this.VisualElementsContainerPreviewMouseDown;
				this._visualElementsContainer.PreviewMouseUp += this.VisualElementsContainerPreviewMouseUp;
				this._visualElementsContainer.MouseLeave += this.VisualElementsContainerMouseLeave;
				this._visualElementsContainer.MouseDown += this.VisualElementsContainerMouseDown;
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00019CDC File Offset: 0x00017EDC
		private void VisualElementsContainerPreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			Point position = Mouse.GetPosition(this._visualElementsContainer);
			if (this.Orientation == Orientation.Horizontal)
			{
				if (position.X < this._leftButton.ActualWidth)
				{
					this.LeftButtonMouseDown();
					return;
				}
				if (position.X > base.ActualWidth - this._rightButton.ActualWidth)
				{
					this.RightButtonMouseDown();
					return;
				}
				if (position.X > this._leftButton.ActualWidth + this._leftThumb.ActualWidth && position.X < base.ActualWidth - (this._rightButton.ActualWidth + this._rightThumb.ActualWidth))
				{
					this.CentralThumbMouseDown();
					return;
				}
			}
			else
			{
				if (position.Y > base.ActualHeight - this._leftButton.ActualHeight)
				{
					this.LeftButtonMouseDown();
					return;
				}
				if (position.Y < this._rightButton.ActualHeight)
				{
					this.RightButtonMouseDown();
					return;
				}
				if (position.Y > this._rightButton.ActualHeight + this._rightButton.ActualHeight && position.Y < base.ActualHeight - (this._leftButton.ActualHeight + this._leftThumb.ActualHeight))
				{
					this.CentralThumbMouseDown();
				}
			}
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00019E1B File Offset: 0x0001801B
		private void VisualElementsContainerMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.MiddleButton == MouseButtonState.Pressed)
			{
				this.MoveWholeRange = !this.MoveWholeRange;
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00019E35 File Offset: 0x00018035
		private void VisualElementsContainerMouseLeave(object sender, MouseEventArgs e)
		{
			this._tickCount = 0U;
			this._timer.Stop();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00019E49 File Offset: 0x00018049
		private void VisualElementsContainerPreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			this._tickCount = 0U;
			this._timer.Stop();
			this._centerThumbBlocked = false;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00019E64 File Offset: 0x00018064
		private void LeftButtonMouseDown()
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				Point position = Mouse.GetPosition(this._visualElementsContainer);
				double num = (this.Orientation == Orientation.Horizontal) ? (this._leftButton.ActualWidth - position.X + this._leftThumb.ActualWidth / 2.0) : (-(this._leftButton.ActualHeight - (base.ActualHeight - (position.Y + this._leftThumb.ActualHeight / 2.0))));
				if (!this.IsSnapToTickEnabled)
				{
					if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
					{
						RangeSlider.MoveThumb(this._leftButton, this._centerThumb, -num, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(true, false, this._direction);
					}
					else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
					{
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, -num, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(true, true, this._direction);
					}
				}
				else if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
				{
					this.JumpToNextTick(RangeSlider.Direction.Decrease, RangeSlider.ButtonType.BottomLeft, -num, this.LowerValue, true);
				}
				else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
				{
					this.JumpToNextTick(RangeSlider.Direction.Decrease, RangeSlider.ButtonType.Both, -num, this.LowerValue, true);
				}
				if (!this.IsMoveToPointEnabled)
				{
					this._position = Mouse.GetPosition(this._visualElementsContainer);
					this._bType = (this.MoveWholeRange ? RangeSlider.ButtonType.Both : RangeSlider.ButtonType.BottomLeft);
					this._currentpoint = ((this.Orientation == Orientation.Horizontal) ? this._position.X : this._position.Y);
					this._currenValue = this.LowerValue;
					this._isInsideRange = false;
					this._direction = RangeSlider.Direction.Decrease;
					this._timer.Start();
				}
			}
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0001A034 File Offset: 0x00018234
		private void RightButtonMouseDown()
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				Point position = Mouse.GetPosition(this._visualElementsContainer);
				double num = (this.Orientation == Orientation.Horizontal) ? (this._rightButton.ActualWidth - (base.ActualWidth - (position.X + this._rightThumb.ActualWidth / 2.0))) : (-(this._rightButton.ActualHeight - (position.Y - this._rightThumb.ActualHeight / 2.0)));
				if (!this.IsSnapToTickEnabled)
				{
					if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
					{
						RangeSlider.MoveThumb(this._centerThumb, this._rightButton, num, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(false, true, this._direction);
					}
					else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
					{
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, num, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(true, true, this._direction);
					}
				}
				else if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
				{
					this.JumpToNextTick(RangeSlider.Direction.Increase, RangeSlider.ButtonType.TopRight, num, this.UpperValue, true);
				}
				else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
				{
					this.JumpToNextTick(RangeSlider.Direction.Increase, RangeSlider.ButtonType.Both, num, this.UpperValue, true);
				}
				if (!this.IsMoveToPointEnabled)
				{
					this._position = Mouse.GetPosition(this._visualElementsContainer);
					this._bType = (this.MoveWholeRange ? RangeSlider.ButtonType.Both : RangeSlider.ButtonType.TopRight);
					this._currentpoint = ((this.Orientation == Orientation.Horizontal) ? this._position.X : this._position.Y);
					this._currenValue = this.UpperValue;
					this._direction = RangeSlider.Direction.Increase;
					this._isInsideRange = false;
					this._timer.Start();
				}
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0001A1FC File Offset: 0x000183FC
		private void CentralThumbMouseDown()
		{
			if (this.ExtendedMode)
			{
				if (Mouse.LeftButton == MouseButtonState.Pressed && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
				{
					this._centerThumbBlocked = true;
					Point position = Mouse.GetPosition(this._visualElementsContainer);
					double num = (this.Orientation == Orientation.Horizontal) ? (position.X + this._leftThumb.ActualWidth / 2.0 - (this._leftButton.ActualWidth + this._leftThumb.ActualWidth)) : (-(base.ActualHeight - (position.Y + this._leftThumb.ActualHeight / 2.0 + this._leftButton.ActualHeight)));
					if (!this.IsSnapToTickEnabled)
					{
						if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
						{
							RangeSlider.MoveThumb(this._leftButton, this._centerThumb, num, this.Orientation, out this._direction);
							this.ReCalculateRangeSelected(true, false, this._direction);
						}
						else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
						{
							RangeSlider.MoveThumb(this._leftButton, this._rightButton, num, this.Orientation, out this._direction);
							this.ReCalculateRangeSelected(true, true, this._direction);
						}
					}
					else if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
					{
						this.JumpToNextTick(RangeSlider.Direction.Increase, RangeSlider.ButtonType.BottomLeft, num, this.LowerValue, true);
					}
					else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
					{
						this.JumpToNextTick(RangeSlider.Direction.Increase, RangeSlider.ButtonType.Both, num, this.LowerValue, true);
					}
					if (!this.IsMoveToPointEnabled)
					{
						this._position = Mouse.GetPosition(this._visualElementsContainer);
						this._bType = (this.MoveWholeRange ? RangeSlider.ButtonType.Both : RangeSlider.ButtonType.BottomLeft);
						this._currentpoint = ((this.Orientation == Orientation.Horizontal) ? this._position.X : this._position.Y);
						this._currenValue = this.LowerValue;
						this._direction = RangeSlider.Direction.Increase;
						this._isInsideRange = true;
						this._timer.Start();
						return;
					}
				}
				else if (Mouse.RightButton == MouseButtonState.Pressed && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
				{
					this._centerThumbBlocked = true;
					Point position2 = Mouse.GetPosition(this._visualElementsContainer);
					double num2 = (this.Orientation == Orientation.Horizontal) ? (base.ActualWidth - (position2.X + this._rightThumb.ActualWidth / 2.0 + this._rightButton.ActualWidth)) : (-(position2.Y + this._rightThumb.ActualHeight / 2.0 - (this._rightButton.ActualHeight + this._rightThumb.ActualHeight)));
					if (!this.IsSnapToTickEnabled)
					{
						if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
						{
							RangeSlider.MoveThumb(this._centerThumb, this._rightButton, -num2, this.Orientation, out this._direction);
							this.ReCalculateRangeSelected(false, true, this._direction);
						}
						else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
						{
							RangeSlider.MoveThumb(this._leftButton, this._rightButton, -num2, this.Orientation, out this._direction);
							this.ReCalculateRangeSelected(true, true, this._direction);
						}
					}
					else if (this.IsMoveToPointEnabled && !this.MoveWholeRange)
					{
						this.JumpToNextTick(RangeSlider.Direction.Decrease, RangeSlider.ButtonType.TopRight, -num2, this.UpperValue, true);
					}
					else if (this.IsMoveToPointEnabled && this.MoveWholeRange)
					{
						this.JumpToNextTick(RangeSlider.Direction.Decrease, RangeSlider.ButtonType.Both, -num2, this.UpperValue, true);
					}
					if (!this.IsMoveToPointEnabled)
					{
						this._position = Mouse.GetPosition(this._visualElementsContainer);
						this._bType = (this.MoveWholeRange ? RangeSlider.ButtonType.Both : RangeSlider.ButtonType.TopRight);
						this._currentpoint = ((this.Orientation == Orientation.Horizontal) ? this._position.X : this._position.Y);
						this._currenValue = this.UpperValue;
						this._direction = RangeSlider.Direction.Decrease;
						this._isInsideRange = true;
						this._timer.Start();
					}
				}
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0001A5E8 File Offset: 0x000187E8
		private void LeftThumbDragStart(object sender, DragStartedEventArgs e)
		{
			this._isMoved = true;
			if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
			{
				if (this._autoToolTip == null)
				{
					this._autoToolTip = new ToolTip();
					this._autoToolTip.Placement = PlacementMode.Custom;
					this._autoToolTip.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(this.PopupPlacementCallback);
				}
				this._autoToolTip.Content = this.GetLowerToolTipNumber();
				this._autoToolTip.PlacementTarget = this._leftThumb;
				this._autoToolTip.IsOpen = true;
			}
			this._basePoint = Mouse.GetPosition(this._container);
			e.RoutedEvent = RangeSlider.LowerThumbDragStartedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0001A68C File Offset: 0x0001888C
		private void LeftThumbDragDelta(object sender, DragDeltaEventArgs e)
		{
			double num = (this.Orientation == Orientation.Horizontal) ? e.HorizontalChange : e.VerticalChange;
			if (!this.IsSnapToTickEnabled)
			{
				RangeSlider.MoveThumb(this._leftButton, this._centerThumb, num, this.Orientation, out this._direction);
				this.ReCalculateRangeSelected(true, false, this._direction);
			}
			else
			{
				Point position = Mouse.GetPosition(this._container);
				if (this.Orientation == Orientation.Horizontal)
				{
					if (position.X >= 0.0 && position.X < this._container.ActualWidth - (this._rightButton.ActualWidth + this._rightThumb.ActualWidth + this._centerThumb.MinWidth))
					{
						RangeSlider.Direction direction = (position.X > this._basePoint.X) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
						this.JumpToNextTick(direction, RangeSlider.ButtonType.BottomLeft, num, this.LowerValue, false);
					}
				}
				else if (position.Y <= this._container.ActualHeight && position.Y > this._rightButton.ActualHeight + this._rightThumb.ActualHeight + this._centerThumb.MinHeight)
				{
					RangeSlider.Direction direction = (position.Y < this._basePoint.Y) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
					this.JumpToNextTick(direction, RangeSlider.ButtonType.BottomLeft, -num, this.LowerValue, false);
				}
			}
			this._basePoint = Mouse.GetPosition(this._container);
			if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
			{
				this._autoToolTip.Content = this.GetLowerToolTipNumber();
				this.RelocateAutoToolTip();
			}
			e.RoutedEvent = RangeSlider.LowerThumbDragDeltaEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0001A824 File Offset: 0x00018A24
		private void LeftThumbDragComplete(object sender, DragCompletedEventArgs e)
		{
			if (this._autoToolTip != null)
			{
				this._autoToolTip.IsOpen = false;
				this._autoToolTip = null;
			}
			e.RoutedEvent = RangeSlider.LowerThumbDragCompletedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0001A854 File Offset: 0x00018A54
		private void RightThumbDragStart(object sender, DragStartedEventArgs e)
		{
			this._isMoved = true;
			if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
			{
				if (this._autoToolTip == null)
				{
					this._autoToolTip = new ToolTip();
					this._autoToolTip.Placement = PlacementMode.Custom;
					this._autoToolTip.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(this.PopupPlacementCallback);
				}
				this._autoToolTip.Content = this.GetUpperToolTipNumber();
				this._autoToolTip.PlacementTarget = this._rightThumb;
				this._autoToolTip.IsOpen = true;
			}
			this._basePoint = Mouse.GetPosition(this._container);
			e.RoutedEvent = RangeSlider.UpperThumbDragStartedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0001A8F8 File Offset: 0x00018AF8
		private void RightThumbDragDelta(object sender, DragDeltaEventArgs e)
		{
			double num = (this.Orientation == Orientation.Horizontal) ? e.HorizontalChange : e.VerticalChange;
			if (!this.IsSnapToTickEnabled)
			{
				RangeSlider.MoveThumb(this._centerThumb, this._rightButton, num, this.Orientation, out this._direction);
				this.ReCalculateRangeSelected(false, true, this._direction);
			}
			else
			{
				Point position = Mouse.GetPosition(this._container);
				if (this.Orientation == Orientation.Horizontal)
				{
					if (position.X < this._container.ActualWidth && position.X > this._leftButton.ActualWidth + this._leftThumb.ActualWidth + this._centerThumb.MinWidth)
					{
						RangeSlider.Direction direction = (position.X > this._basePoint.X) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
						this.JumpToNextTick(direction, RangeSlider.ButtonType.TopRight, num, this.UpperValue, false);
					}
				}
				else if (position.Y >= 0.0 && position.Y < this._container.ActualHeight - (this._leftButton.ActualHeight + this._leftThumb.ActualHeight + this._centerThumb.MinHeight))
				{
					RangeSlider.Direction direction = (position.Y < this._basePoint.Y) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
					this.JumpToNextTick(direction, RangeSlider.ButtonType.TopRight, -num, this.UpperValue, false);
				}
				this._basePoint = Mouse.GetPosition(this._container);
			}
			if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
			{
				this._autoToolTip.Content = this.GetUpperToolTipNumber();
				this.RelocateAutoToolTip();
			}
			e.RoutedEvent = RangeSlider.UpperThumbDragDeltaEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0001AA90 File Offset: 0x00018C90
		private void RightThumbDragComplete(object sender, DragCompletedEventArgs e)
		{
			if (this._autoToolTip != null)
			{
				this._autoToolTip.IsOpen = false;
				this._autoToolTip = null;
			}
			e.RoutedEvent = RangeSlider.UpperThumbDragCompletedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001AAC0 File Offset: 0x00018CC0
		private void CenterThumbDragStarted(object sender, DragStartedEventArgs e)
		{
			this._isMoved = true;
			if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
			{
				if (this._autoToolTip == null)
				{
					this._autoToolTip = new ToolTip
					{
						Placement = PlacementMode.Custom,
						CustomPopupPlacementCallback = new CustomPopupPlacementCallback(this.PopupPlacementCallback)
					};
				}
				this._autoToolTip.Content = this.GetLowerToolTipNumber() + " ; " + this.GetUpperToolTipNumber();
				this._autoToolTip.PlacementTarget = this._centerThumb;
				this._autoToolTip.IsOpen = true;
			}
			this._basePoint = Mouse.GetPosition(this._container);
			e.RoutedEvent = RangeSlider.CentralThumbDragStartedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0001AB6C File Offset: 0x00018D6C
		private void CenterThumbDragDelta(object sender, DragDeltaEventArgs e)
		{
			if (!this._centerThumbBlocked)
			{
				double num = (this.Orientation == Orientation.Horizontal) ? e.HorizontalChange : e.VerticalChange;
				if (!this.IsSnapToTickEnabled)
				{
					RangeSlider.MoveThumb(this._leftButton, this._rightButton, num, this.Orientation, out this._direction);
					this.ReCalculateRangeSelected(true, true, this._direction);
				}
				else
				{
					Point position = Mouse.GetPosition(this._container);
					if (this.Orientation == Orientation.Horizontal)
					{
						if (position.X >= 0.0 && position.X < this._container.ActualWidth)
						{
							RangeSlider.Direction direction = (position.X > this._basePoint.X) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
							this.JumpToNextTick(direction, RangeSlider.ButtonType.Both, num, (direction == RangeSlider.Direction.Increase) ? this.UpperValue : this.LowerValue, false);
						}
					}
					else if (position.Y >= 0.0 && position.Y < this._container.ActualHeight)
					{
						RangeSlider.Direction direction = (position.Y < this._basePoint.Y) ? RangeSlider.Direction.Increase : RangeSlider.Direction.Decrease;
						this.JumpToNextTick(direction, RangeSlider.ButtonType.Both, -num, (direction == RangeSlider.Direction.Increase) ? this.UpperValue : this.LowerValue, false);
					}
				}
				this._basePoint = Mouse.GetPosition(this._container);
				if (this.AutoToolTipPlacement != AutoToolTipPlacement.None)
				{
					this._autoToolTip.Content = this.GetLowerToolTipNumber() + " ; " + this.GetUpperToolTipNumber();
					this.RelocateAutoToolTip();
				}
			}
			e.RoutedEvent = RangeSlider.CentralThumbDragDeltaEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0001ACF7 File Offset: 0x00018EF7
		private void CenterThumbDragCompleted(object sender, DragCompletedEventArgs e)
		{
			if (this._autoToolTip != null)
			{
				this._autoToolTip.IsOpen = false;
				this._autoToolTip = null;
			}
			e.RoutedEvent = RangeSlider.CentralThumbDragCompletedEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0001AD26 File Offset: 0x00018F26
		private static double GetChangeKeepPositive(double width, double increment)
		{
			return Math.Max(width + increment, 0.0) - width;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001AD3C File Offset: 0x00018F3C
		private double UpdateEndPoint(RangeSlider.ButtonType type, RangeSlider.Direction dir)
		{
			double result = 0.0;
			if (dir == RangeSlider.Direction.Increase)
			{
				if (type == RangeSlider.ButtonType.BottomLeft || (type == RangeSlider.ButtonType.Both && this._isInsideRange))
				{
					result = ((this.Orientation == Orientation.Horizontal) ? (this._leftButton.ActualWidth + this._leftThumb.ActualWidth) : (base.ActualHeight - (this._leftButton.ActualHeight + this._leftThumb.ActualHeight)));
				}
				else if (type == RangeSlider.ButtonType.TopRight || (type == RangeSlider.ButtonType.Both && !this._isInsideRange))
				{
					result = ((this.Orientation == Orientation.Horizontal) ? (base.ActualWidth - this._rightButton.ActualWidth) : this._rightButton.ActualHeight);
				}
			}
			else if (dir == RangeSlider.Direction.Decrease)
			{
				if (type == RangeSlider.ButtonType.BottomLeft || (type == RangeSlider.ButtonType.Both && !this._isInsideRange))
				{
					result = ((this.Orientation == Orientation.Horizontal) ? this._leftButton.ActualWidth : (base.ActualHeight - this._leftButton.ActualHeight));
				}
				else if (type == RangeSlider.ButtonType.TopRight || (type == RangeSlider.ButtonType.Both && this._isInsideRange))
				{
					result = ((this.Orientation == Orientation.Horizontal) ? (base.ActualWidth - this._rightButton.ActualWidth - this._rightThumb.ActualWidth) : (this._rightButton.ActualHeight + this._rightThumb.ActualHeight));
				}
			}
			return result;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0001AE81 File Offset: 0x00019081
		private bool GetResult(double currentPoint, double endPoint, RangeSlider.Direction direction)
		{
			if (direction == RangeSlider.Direction.Increase)
			{
				return (this.Orientation == Orientation.Horizontal && currentPoint > endPoint) || (this.Orientation == Orientation.Vertical && currentPoint < endPoint);
			}
			return (this.Orientation == Orientation.Horizontal && currentPoint < endPoint) || (this.Orientation == Orientation.Vertical && currentPoint > endPoint);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0001AEC4 File Offset: 0x000190C4
		private void MoveToNextValue(object sender, EventArgs e)
		{
			this._position = Mouse.GetPosition(this._visualElementsContainer);
			this._currentpoint = ((this.Orientation == Orientation.Horizontal) ? this._position.X : this._position.Y);
			double endPoint = this.UpdateEndPoint(this._bType, this._direction);
			bool result = this.GetResult(this._currentpoint, endPoint, this._direction);
			if (!this.IsSnapToTickEnabled)
			{
				double num = base.SmallChange;
				if (this._tickCount > 5U)
				{
					num = base.LargeChange;
				}
				this._roundToPrecision = true;
				if (!num.ToString(CultureInfo.InvariantCulture).ToLower().Contains("e") && num.ToString(CultureInfo.InvariantCulture).Contains("."))
				{
					string[] array = num.ToString(CultureInfo.InvariantCulture).Split(new char[]
					{
						'.'
					});
					this._precision = array[1].Length;
				}
				else
				{
					this._precision = 0;
				}
				num = ((this.Orientation == Orientation.Horizontal) ? num : (-num));
				num = ((this._direction == RangeSlider.Direction.Increase) ? num : (-num));
				if (result)
				{
					switch (this._bType)
					{
					case RangeSlider.ButtonType.BottomLeft:
						RangeSlider.MoveThumb(this._leftButton, this._centerThumb, num * this._density, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(true, false, this._direction);
						break;
					case RangeSlider.ButtonType.TopRight:
						RangeSlider.MoveThumb(this._centerThumb, this._rightButton, num * this._density, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(false, true, this._direction);
						break;
					case RangeSlider.ButtonType.Both:
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, num * this._density, this.Orientation, out this._direction);
						this.ReCalculateRangeSelected(true, true, this._direction);
						break;
					}
				}
			}
			else
			{
				double num = this.CalculateNextTick(this._direction, this._currenValue, 0.0, true);
				double num2 = num;
				num = ((this.Orientation == Orientation.Horizontal) ? num : (-num));
				if (this._direction == RangeSlider.Direction.Increase)
				{
					if (result)
					{
						switch (this._bType)
						{
						case RangeSlider.ButtonType.BottomLeft:
							RangeSlider.MoveThumb(this._leftButton, this._centerThumb, num * this._density, this.Orientation);
							this.ReCalculateRangeSelected(true, false, this.LowerValue + num2, this._direction);
							break;
						case RangeSlider.ButtonType.TopRight:
							RangeSlider.MoveThumb(this._centerThumb, this._rightButton, num * this._density, this.Orientation);
							this.ReCalculateRangeSelected(false, true, this.UpperValue + num2, this._direction);
							break;
						case RangeSlider.ButtonType.Both:
							RangeSlider.MoveThumb(this._leftButton, this._rightButton, num * this._density, this.Orientation);
							this.ReCalculateRangeSelected(this.LowerValue + num2, this.UpperValue + num2, this._direction);
							break;
						}
					}
				}
				else if (this._direction == RangeSlider.Direction.Decrease && result)
				{
					switch (this._bType)
					{
					case RangeSlider.ButtonType.BottomLeft:
						RangeSlider.MoveThumb(this._leftButton, this._centerThumb, -num * this._density, this.Orientation);
						this.ReCalculateRangeSelected(true, false, this.LowerValue - num2, this._direction);
						break;
					case RangeSlider.ButtonType.TopRight:
						RangeSlider.MoveThumb(this._centerThumb, this._rightButton, -num * this._density, this.Orientation);
						this.ReCalculateRangeSelected(false, true, this.UpperValue - num2, this._direction);
						break;
					case RangeSlider.ButtonType.Both:
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, -num * this._density, this.Orientation);
						this.ReCalculateRangeSelected(this.LowerValue - num2, this.UpperValue - num2, this._direction);
						break;
					}
				}
			}
			this._tickCount += 1U;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0001B2B4 File Offset: 0x000194B4
		private void SnapToTickHandle(RangeSlider.ButtonType type, RangeSlider.Direction direction, double difference)
		{
			double num = difference;
			difference = ((this.Orientation == Orientation.Horizontal) ? difference : (-difference));
			if (direction == RangeSlider.Direction.Increase)
			{
				switch (type)
				{
				case RangeSlider.ButtonType.BottomLeft:
					if (this.LowerValue < this.UpperValue - this.MinRange)
					{
						RangeSlider.MoveThumb(this._leftButton, this._centerThumb, difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(true, false, this.LowerValue + num, direction);
						return;
					}
					break;
				case RangeSlider.ButtonType.TopRight:
					if (this.UpperValue < base.Maximum)
					{
						RangeSlider.MoveThumb(this._centerThumb, this._rightButton, difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(false, true, this.UpperValue + num, direction);
						return;
					}
					break;
				case RangeSlider.ButtonType.Both:
					if (this.UpperValue < base.Maximum)
					{
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(this.LowerValue + num, this.UpperValue + num, direction);
						return;
					}
					break;
				default:
					return;
				}
			}
			else
			{
				switch (type)
				{
				case RangeSlider.ButtonType.BottomLeft:
					if (this.LowerValue > base.Minimum)
					{
						RangeSlider.MoveThumb(this._leftButton, this._centerThumb, -difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(true, false, this.LowerValue - num, direction);
						return;
					}
					break;
				case RangeSlider.ButtonType.TopRight:
					if (this.UpperValue > this.LowerValue + this.MinRange)
					{
						RangeSlider.MoveThumb(this._centerThumb, this._rightButton, -difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(false, true, this.UpperValue - num, direction);
						return;
					}
					break;
				case RangeSlider.ButtonType.Both:
					if (this.LowerValue > base.Minimum)
					{
						RangeSlider.MoveThumb(this._leftButton, this._rightButton, -difference * this._density, this.Orientation);
						this.ReCalculateRangeSelected(this.LowerValue - num, this.UpperValue - num, direction);
					}
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001B4A0 File Offset: 0x000196A0
		private double CalculateNextTick(RangeSlider.Direction direction, double checkingValue, double distance, bool moveDirectlyToNextTick)
		{
			double num = checkingValue - base.Minimum;
			if (!this.IsMoveToPointEnabled)
			{
				double num2 = num / this.TickFrequency;
				if (!this.IsDoubleCloseToInt(num2))
				{
					distance = this.TickFrequency * (double)((int)num2);
					if (direction == RangeSlider.Direction.Increase)
					{
						distance += this.TickFrequency;
					}
					distance -= Math.Abs(num);
					this._currenValue = 0.0;
					return Math.Abs(distance);
				}
			}
			if (moveDirectlyToNextTick)
			{
				distance = this.TickFrequency;
			}
			else
			{
				double num3 = (num + distance / this._density) / this.TickFrequency;
				if (direction == RangeSlider.Direction.Increase)
				{
					distance = (num3.ToString(CultureInfo.InvariantCulture).ToLower().Contains("e+") ? (num3 * this.TickFrequency + this.TickFrequency) : ((double)((int)num3) * this.TickFrequency + this.TickFrequency)) - Math.Abs(num);
				}
				else
				{
					double num4 = num3.ToString(CultureInfo.InvariantCulture).ToLower().Contains("e+") ? (num3 * this.TickFrequency) : ((double)((int)num3) * this.TickFrequency);
					distance = Math.Abs(num) - num4;
				}
			}
			return Math.Abs(distance);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0001B5BC File Offset: 0x000197BC
		private void JumpToNextTick(RangeSlider.Direction direction, RangeSlider.ButtonType type, double distance, double checkingValue, bool jumpDirectlyToTick)
		{
			double num = this.CalculateNextTick(direction, checkingValue, distance, false);
			Point position = Mouse.GetPosition(this._visualElementsContainer);
			double num2 = (this.Orientation == Orientation.Horizontal) ? position.X : position.Y;
			double num3 = (this.Orientation == Orientation.Horizontal) ? base.ActualWidth : base.ActualHeight;
			double num4 = (direction == RangeSlider.Direction.Increase) ? (this.TickFrequency * this._density) : (-this.TickFrequency * this._density);
			if (jumpDirectlyToTick)
			{
				this.SnapToTickHandle(type, direction, num);
				return;
			}
			if (direction == RangeSlider.Direction.Increase)
			{
				if (!this.IsDoubleCloseToInt(checkingValue / this.TickFrequency))
				{
					if (distance > num * this._density / 2.0 || distance >= num3 - num2 || distance >= num2)
					{
						this.SnapToTickHandle(type, direction, num);
						return;
					}
				}
				else if (distance > num4 / 2.0 || distance >= num3 - num2 || distance >= num2)
				{
					this.SnapToTickHandle(type, direction, num);
					return;
				}
			}
			else if (!this.IsDoubleCloseToInt(checkingValue / this.TickFrequency))
			{
				if (distance <= -(num * this._density) / 2.0 || this.UpperValue - this.LowerValue < num)
				{
					this.SnapToTickHandle(type, direction, num);
					return;
				}
			}
			else if (distance < num4 / 2.0 || this.UpperValue - this.LowerValue < num)
			{
				this.SnapToTickHandle(type, direction, num);
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0001B710 File Offset: 0x00019910
		private void RelocateAutoToolTip()
		{
			double horizontalOffset = this._autoToolTip.HorizontalOffset;
			this._autoToolTip.HorizontalOffset = horizontalOffset + 0.001;
			this._autoToolTip.HorizontalOffset = horizontalOffset;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0001B74B File Offset: 0x0001994B
		private bool ApproximatelyEquals(double value1, double value2)
		{
			return Math.Abs(value1 - value2) <= 1.53E-06;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001B763 File Offset: 0x00019963
		private bool IsDoubleCloseToInt(double val)
		{
			return this.ApproximatelyEquals(Math.Abs(val - Math.Round(val)), 0.0);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001B784 File Offset: 0x00019984
		private string GetLowerToolTipNumber()
		{
			double lowerValue = this.LowerValue;
			return this.GetToolTipNumber(lowerValue);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001B7A0 File Offset: 0x000199A0
		private string GetUpperToolTipNumber()
		{
			double upperValue = this.UpperValue;
			return this.GetToolTipNumber(upperValue);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0001B7BC File Offset: 0x000199BC
		private string GetToolTipNumber(double value)
		{
			IValueConverter autoToolTipTextConverter = this.AutoToolTipTextConverter;
			if (autoToolTipTextConverter != null)
			{
				object obj = autoToolTipTextConverter.Convert(value, typeof(string), null, CultureInfo.InvariantCulture);
				if (obj != null)
				{
					return obj.ToString();
				}
			}
			NumberFormatInfo numberFormatInfo = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
			numberFormatInfo.NumberDecimalDigits = this.AutoToolTipPrecision;
			return value.ToString("N", numberFormatInfo);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0001B824 File Offset: 0x00019A24
		private CustomPopupPlacement[] PopupPlacementCallback(Size popupSize, Size targetSize, Point offset)
		{
			AutoToolTipPlacement autoToolTipPlacement = this.AutoToolTipPlacement;
			if (autoToolTipPlacement != AutoToolTipPlacement.TopLeft)
			{
				if (autoToolTipPlacement != AutoToolTipPlacement.BottomRight)
				{
					return new CustomPopupPlacement[0];
				}
				if (this.Orientation == Orientation.Horizontal)
				{
					return new CustomPopupPlacement[]
					{
						new CustomPopupPlacement(new Point((targetSize.Width - popupSize.Width) * 0.5, targetSize.Height), PopupPrimaryAxis.Horizontal)
					};
				}
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(targetSize.Width, (targetSize.Height - popupSize.Height) * 0.5), PopupPrimaryAxis.Vertical)
				};
			}
			else
			{
				if (this.Orientation == Orientation.Horizontal)
				{
					return new CustomPopupPlacement[]
					{
						new CustomPopupPlacement(new Point((targetSize.Width - popupSize.Width) * 0.5, -popupSize.Height), PopupPrimaryAxis.Horizontal)
					};
				}
				return new CustomPopupPlacement[]
				{
					new CustomPopupPlacement(new Point(-popupSize.Width, (targetSize.Height - popupSize.Height) * 0.5), PopupPrimaryAxis.Vertical)
				};
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0001B944 File Offset: 0x00019B44
		private static bool IsValidDoubleValue(object value)
		{
			return value is double && RangeSlider.IsValidDouble((double)value);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0001B95B File Offset: 0x00019B5B
		private static bool IsValidDouble(double d)
		{
			return !double.IsNaN(d) && !double.IsInfinity(d);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0001B970 File Offset: 0x00019B70
		private static bool IsValidPrecision(object value)
		{
			return (int)value >= 0;
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0001B97E File Offset: 0x00019B7E
		private static bool IsValidMinRange(object value)
		{
			return value is double && RangeSlider.IsValidDouble((double)value) && (double)value >= 0.0;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0001B9AC File Offset: 0x00019BAC
		private static object CoerceMinimum(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			if ((double)basevalue > rangeSlider.Maximum)
			{
				return rangeSlider.Maximum;
			}
			return basevalue;
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0001B9DC File Offset: 0x00019BDC
		private static object CoerceMaximum(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			if ((double)basevalue < rangeSlider.Minimum)
			{
				return rangeSlider.Minimum;
			}
			return basevalue;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0001BA0C File Offset: 0x00019C0C
		private static object CoerceLowerValue(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			double num = (double)basevalue;
			if (num < rangeSlider.Minimum || rangeSlider.UpperValue - rangeSlider.MinRange < rangeSlider.Minimum)
			{
				return rangeSlider.Minimum;
			}
			if (num > rangeSlider.UpperValue - rangeSlider.MinRange)
			{
				return rangeSlider.UpperValue - rangeSlider.MinRange;
			}
			return basevalue;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001BA78 File Offset: 0x00019C78
		private static object CoerceUpperValue(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			double num = (double)basevalue;
			if (num > rangeSlider.Maximum || rangeSlider.LowerValue + rangeSlider.MinRange > rangeSlider.Maximum)
			{
				return rangeSlider.Maximum;
			}
			if (num < rangeSlider.LowerValue + rangeSlider.MinRange)
			{
				return rangeSlider.LowerValue + rangeSlider.MinRange;
			}
			return basevalue;
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001BAE4 File Offset: 0x00019CE4
		private static object CoerceMinRange(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			double num = (double)basevalue;
			if (rangeSlider.LowerValue + num > rangeSlider.Maximum)
			{
				return rangeSlider.Maximum - rangeSlider.LowerValue;
			}
			return basevalue;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001BB24 File Offset: 0x00019D24
		private static object CoerceMinRangeWidth(DependencyObject d, object basevalue)
		{
			RangeSlider rangeSlider = (RangeSlider)d;
			if (rangeSlider._leftThumb != null && rangeSlider._rightThumb != null)
			{
				double num;
				if (rangeSlider.Orientation == Orientation.Horizontal)
				{
					num = rangeSlider.ActualWidth - rangeSlider._leftThumb.ActualWidth - rangeSlider._rightThumb.ActualWidth;
				}
				else
				{
					num = rangeSlider.ActualHeight - rangeSlider._leftThumb.ActualHeight - rangeSlider._rightThumb.ActualHeight;
				}
				return ((double)basevalue > num / 2.0) ? (num / 2.0) : ((double)basevalue);
			}
			return basevalue;
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001BBBD File Offset: 0x00019DBD
		private static void MaxPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			dependencyObject.CoerceValue(RangeBase.MaximumProperty);
			dependencyObject.CoerceValue(RangeBase.MinimumProperty);
			dependencyObject.CoerceValue(RangeSlider.UpperValueProperty);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0001BBE0 File Offset: 0x00019DE0
		private static void MinPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			dependencyObject.CoerceValue(RangeBase.MinimumProperty);
			dependencyObject.CoerceValue(RangeBase.MaximumProperty);
			dependencyObject.CoerceValue(RangeSlider.LowerValueProperty);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001BC04 File Offset: 0x00019E04
		private static void RangesChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			RangeSlider rangeSlider = (RangeSlider)dependencyObject;
			if (rangeSlider._internalUpdate)
			{
				return;
			}
			dependencyObject.CoerceValue(RangeSlider.UpperValueProperty);
			dependencyObject.CoerceValue(RangeSlider.LowerValueProperty);
			RangeSlider.RaiseValueChangedEvents(dependencyObject, true, true);
			rangeSlider._oldLower = rangeSlider.LowerValue;
			rangeSlider._oldUpper = rangeSlider.UpperValue;
			rangeSlider.ReCalculateSize();
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0001BC60 File Offset: 0x00019E60
		private static void MinRangeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			double num = (double)e.NewValue;
			if (num < 0.0)
			{
				num = 0.0;
			}
			RangeSlider rangeSlider = (RangeSlider)dependencyObject;
			dependencyObject.CoerceValue(RangeSlider.MinRangeProperty);
			rangeSlider._internalUpdate = true;
			rangeSlider.UpperValue = Math.Max(rangeSlider.UpperValue, rangeSlider.LowerValue + num);
			rangeSlider.UpperValue = Math.Min(rangeSlider.UpperValue, rangeSlider.Maximum);
			rangeSlider._internalUpdate = false;
			rangeSlider.CoerceValue(RangeSlider.UpperValueProperty);
			RangeSlider.RaiseValueChangedEvents(dependencyObject, true, true);
			rangeSlider._oldLower = rangeSlider.LowerValue;
			rangeSlider._oldUpper = rangeSlider.UpperValue;
			rangeSlider.ReCalculateSize();
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001BD11 File Offset: 0x00019F11
		private static void MinRangeWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			((RangeSlider)sender).ReCalculateSize();
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001BD1E File Offset: 0x00019F1E
		private static void IntervalChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			((RangeSlider)dependencyObject)._timer.Interval = TimeSpan.FromMilliseconds((double)((int)e.NewValue));
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x0001BD44 File Offset: 0x00019F44
		private static void RaiseValueChangedEvents(DependencyObject dependencyObject, bool lowerValueReCalculated = true, bool upperValueReCalculated = true)
		{
			RangeSlider rangeSlider = (RangeSlider)dependencyObject;
			bool flag = object.Equals(rangeSlider._oldLower, rangeSlider.LowerValue);
			bool flag2 = object.Equals(rangeSlider._oldUpper, rangeSlider.UpperValue);
			if ((lowerValueReCalculated || upperValueReCalculated) && (!flag || !flag2))
			{
				rangeSlider.OnRangeSelectionChanged(new RangeSelectionChangedEventArgs(rangeSlider.LowerValue, rangeSlider.UpperValue, rangeSlider._oldLower, rangeSlider._oldUpper));
			}
			if (lowerValueReCalculated && !flag)
			{
				rangeSlider.OnRangeParameterChanged(new RangeParameterChangedEventArgs(RangeParameterChangeType.Lower, rangeSlider._oldLower, rangeSlider.LowerValue), RangeSlider.LowerValueChangedEvent);
			}
			if (upperValueReCalculated && !flag2)
			{
				rangeSlider.OnRangeParameterChanged(new RangeParameterChangedEventArgs(RangeParameterChangeType.Upper, rangeSlider._oldUpper, rangeSlider.UpperValue), RangeSlider.UpperValueChangedEvent);
			}
		}

		// Token: 0x04000270 RID: 624
		public static RoutedUICommand MoveBack = new RoutedUICommand("MoveBack", "MoveBack", typeof(RangeSlider), new InputGestureCollection(new InputGesture[]
		{
			new KeyGesture(Key.B, ModifierKeys.Control)
		}));

		// Token: 0x04000271 RID: 625
		public static RoutedUICommand MoveForward = new RoutedUICommand("MoveForward", "MoveForward", typeof(RangeSlider), new InputGestureCollection(new InputGesture[]
		{
			new KeyGesture(Key.F, ModifierKeys.Control)
		}));

		// Token: 0x04000272 RID: 626
		public static RoutedUICommand MoveAllForward = new RoutedUICommand("MoveAllForward", "MoveAllForward", typeof(RangeSlider), new InputGestureCollection(new InputGesture[]
		{
			new KeyGesture(Key.F, ModifierKeys.Alt)
		}));

		// Token: 0x04000273 RID: 627
		public static RoutedUICommand MoveAllBack = new RoutedUICommand("MoveAllBack", "MoveAllBack", typeof(RangeSlider), new InputGestureCollection(new InputGesture[]
		{
			new KeyGesture(Key.B, ModifierKeys.Alt)
		}));

		// Token: 0x04000280 RID: 640
		public static readonly DependencyProperty UpperValueProperty;

		// Token: 0x04000281 RID: 641
		public static readonly DependencyProperty LowerValueProperty;

		// Token: 0x04000282 RID: 642
		public static readonly DependencyProperty MinRangeProperty;

		// Token: 0x04000283 RID: 643
		public static readonly DependencyProperty MinRangeWidthProperty;

		// Token: 0x04000284 RID: 644
		public static readonly DependencyProperty MoveWholeRangeProperty;

		// Token: 0x04000285 RID: 645
		public static readonly DependencyProperty ExtendedModeProperty;

		// Token: 0x04000286 RID: 646
		public static readonly DependencyProperty IsSnapToTickEnabledProperty;

		// Token: 0x04000287 RID: 647
		public static readonly DependencyProperty OrientationProperty;

		// Token: 0x04000288 RID: 648
		public static readonly DependencyProperty TickPlacementProperty;

		// Token: 0x04000289 RID: 649
		public static readonly DependencyProperty TickFrequencyProperty;

		// Token: 0x0400028A RID: 650
		public static readonly DependencyProperty TicksProperty;

		// Token: 0x0400028B RID: 651
		public static readonly DependencyProperty IsMoveToPointEnabledProperty;

		// Token: 0x0400028C RID: 652
		public static readonly DependencyProperty AutoToolTipPlacementProperty;

		// Token: 0x0400028D RID: 653
		public static readonly DependencyProperty AutoToolTipPrecisionProperty;

		// Token: 0x0400028E RID: 654
		public static readonly DependencyProperty AutoToolTipTextConverterProperty;

		// Token: 0x0400028F RID: 655
		public static readonly DependencyProperty IntervalProperty;

		// Token: 0x04000290 RID: 656
		public static readonly DependencyProperty IsSelectionRangeEnabledProperty;

		// Token: 0x04000291 RID: 657
		public static readonly DependencyProperty SelectionStartProperty;

		// Token: 0x04000292 RID: 658
		public static readonly DependencyProperty SelectionEndProperty;

		// Token: 0x04000293 RID: 659
		private const double Epsilon = 1.53E-06;

		// Token: 0x04000294 RID: 660
		private bool _internalUpdate;

		// Token: 0x04000295 RID: 661
		private Thumb _centerThumb;

		// Token: 0x04000296 RID: 662
		private Thumb _leftThumb;

		// Token: 0x04000297 RID: 663
		private Thumb _rightThumb;

		// Token: 0x04000298 RID: 664
		private RepeatButton _leftButton;

		// Token: 0x04000299 RID: 665
		private RepeatButton _rightButton;

		// Token: 0x0400029A RID: 666
		private StackPanel _visualElementsContainer;

		// Token: 0x0400029B RID: 667
		private FrameworkElement _container;

		// Token: 0x0400029C RID: 668
		private double _movableWidth;

		// Token: 0x0400029D RID: 669
		private readonly DispatcherTimer _timer;

		// Token: 0x0400029E RID: 670
		private uint _tickCount;

		// Token: 0x0400029F RID: 671
		private double _currentpoint;

		// Token: 0x040002A0 RID: 672
		private bool _isInsideRange;

		// Token: 0x040002A1 RID: 673
		private bool _centerThumbBlocked;

		// Token: 0x040002A2 RID: 674
		private RangeSlider.Direction _direction;

		// Token: 0x040002A3 RID: 675
		private RangeSlider.ButtonType _bType;

		// Token: 0x040002A4 RID: 676
		private Point _position;

		// Token: 0x040002A5 RID: 677
		private Point _basePoint;

		// Token: 0x040002A6 RID: 678
		private double _currenValue;

		// Token: 0x040002A7 RID: 679
		private double _density;

		// Token: 0x040002A8 RID: 680
		private ToolTip _autoToolTip;

		// Token: 0x040002A9 RID: 681
		private double _oldLower;

		// Token: 0x040002AA RID: 682
		private double _oldUpper;

		// Token: 0x040002AB RID: 683
		private bool _isMoved;

		// Token: 0x040002AC RID: 684
		private bool _roundToPrecision;

		// Token: 0x040002AD RID: 685
		private int _precision;

		// Token: 0x040002AE RID: 686
		private readonly PropertyChangeNotifier actualWidthPropertyChangeNotifier;

		// Token: 0x040002AF RID: 687
		private readonly PropertyChangeNotifier actualHeightPropertyChangeNotifier;

		// Token: 0x02000103 RID: 259
		private enum ButtonType
		{
			// Token: 0x0400052B RID: 1323
			BottomLeft,
			// Token: 0x0400052C RID: 1324
			TopRight,
			// Token: 0x0400052D RID: 1325
			Both
		}

		// Token: 0x02000104 RID: 260
		private enum Direction
		{
			// Token: 0x0400052F RID: 1327
			Increase,
			// Token: 0x04000530 RID: 1328
			Decrease
		}
	}
}
