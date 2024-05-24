using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000070 RID: 112
	[TemplatePart(Name = "PART_NumericUp", Type = typeof(RepeatButton))]
	[TemplatePart(Name = "PART_NumericDown", Type = typeof(RepeatButton))]
	[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
	public class NumericUpDown : Control
	{
		// Token: 0x0600054F RID: 1359 RVA: 0x00014B9C File Offset: 0x00012D9C
		private static void IsReadOnlyPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			if (e.OldValue != e.NewValue && e.NewValue != null)
			{
				NumericUpDown numericUpDown = (NumericUpDown)dependencyObject;
				bool flag = (bool)e.NewValue;
				numericUpDown.ToggleReadOnlyMode(flag || !numericUpDown.InterceptManualEnter);
			}
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00014BEC File Offset: 0x00012DEC
		private static void InterceptManualEnterChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			if (e.OldValue != e.NewValue && e.NewValue != null)
			{
				NumericUpDown numericUpDown = (NumericUpDown)dependencyObject;
				bool flag = (bool)e.NewValue;
				numericUpDown.ToggleReadOnlyMode(!flag || numericUpDown.IsReadOnly);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00014C38 File Offset: 0x00012E38
		static NumericUpDown()
		{
			NumericUpDown.ValueIncrementedEvent = EventManager.RegisterRoutedEvent("ValueIncremented", RoutingStrategy.Bubble, typeof(NumericUpDownChangedRoutedEventHandler), typeof(NumericUpDown));
			NumericUpDown.ValueDecrementedEvent = EventManager.RegisterRoutedEvent("ValueDecremented", RoutingStrategy.Bubble, typeof(NumericUpDownChangedRoutedEventHandler), typeof(NumericUpDown));
			NumericUpDown.DelayChangedEvent = EventManager.RegisterRoutedEvent("DelayChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
			NumericUpDown.MaximumReachedEvent = EventManager.RegisterRoutedEvent("MaximumReached", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
			NumericUpDown.MinimumReachedEvent = EventManager.RegisterRoutedEvent("MinimumReached", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NumericUpDown));
			NumericUpDown.ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double?>), typeof(NumericUpDown));
			NumericUpDown.DelayProperty = DependencyProperty.Register("Delay", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(500, new PropertyChangedCallback(NumericUpDown.OnDelayChanged)), new ValidateValueCallback(NumericUpDown.ValidateDelay));
			NumericUpDown.TextAlignmentProperty = TextBox.TextAlignmentProperty.AddOwner(typeof(NumericUpDown));
			NumericUpDown.SpeedupProperty = DependencyProperty.Register("Speedup", typeof(bool), typeof(NumericUpDown), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(NumericUpDown.OnSpeedupChanged)));
			NumericUpDown.IsReadOnlyProperty = TextBoxBase.IsReadOnlyProperty.AddOwner(typeof(NumericUpDown), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(NumericUpDown.IsReadOnlyPropertyChangedCallback)));
			NumericUpDown.StringFormatProperty = DependencyProperty.Register("StringFormat", typeof(string), typeof(NumericUpDown), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(NumericUpDown.OnStringFormatChanged), new CoerceValueCallback(NumericUpDown.CoerceStringFormat)));
			NumericUpDown.InterceptArrowKeysProperty = DependencyProperty.Register("InterceptArrowKeys", typeof(bool), typeof(NumericUpDown), new FrameworkPropertyMetadata(true));
			NumericUpDown.ValueProperty = DependencyProperty.Register("Value", typeof(double?), typeof(NumericUpDown), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(NumericUpDown.OnValueChanged), new CoerceValueCallback(NumericUpDown.CoerceValue)));
			NumericUpDown.ButtonsAlignmentProperty = DependencyProperty.Register("ButtonsAlignment", typeof(ButtonsAlignment), typeof(NumericUpDown), new FrameworkPropertyMetadata(ButtonsAlignment.Right, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
			NumericUpDown.MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(NumericUpDown), new FrameworkPropertyMetadata(double.MinValue, new PropertyChangedCallback(NumericUpDown.OnMinimumChanged)));
			NumericUpDown.MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(NumericUpDown), new FrameworkPropertyMetadata(double.MaxValue, new PropertyChangedCallback(NumericUpDown.OnMaximumChanged), new CoerceValueCallback(NumericUpDown.CoerceMaximum)));
			NumericUpDown.IntervalProperty = DependencyProperty.Register("Interval", typeof(double), typeof(NumericUpDown), new FrameworkPropertyMetadata(1.0, new PropertyChangedCallback(NumericUpDown.IntervalChanged)));
			NumericUpDown.InterceptMouseWheelProperty = DependencyProperty.Register("InterceptMouseWheel", typeof(bool), typeof(NumericUpDown), new FrameworkPropertyMetadata(true));
			NumericUpDown.TrackMouseWheelWhenMouseOverProperty = DependencyProperty.Register("TrackMouseWheelWhenMouseOver", typeof(bool), typeof(NumericUpDown), new FrameworkPropertyMetadata(false));
			NumericUpDown.HideUpDownButtonsProperty = DependencyProperty.Register("HideUpDownButtons", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false));
			NumericUpDown.UpDownButtonsWidthProperty = DependencyProperty.Register("UpDownButtonsWidth", typeof(double), typeof(NumericUpDown), new PropertyMetadata(20.0));
			NumericUpDown.InterceptManualEnterProperty = DependencyProperty.Register("InterceptManualEnter", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(true, new PropertyChangedCallback(NumericUpDown.InterceptManualEnterChangedCallback)));
			NumericUpDown.CultureProperty = DependencyProperty.Register("Culture", typeof(CultureInfo), typeof(NumericUpDown), new PropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
			{
				if (e.NewValue != e.OldValue)
				{
					NumericUpDown numericUpDown = (NumericUpDown)o;
					numericUpDown.OnValueChanged(numericUpDown.Value, numericUpDown.Value);
				}
			}));
			NumericUpDown.SelectAllOnFocusProperty = DependencyProperty.Register("SelectAllOnFocus", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(true, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
			{
				TextBoxHelper.SetSelectAllOnFocus(o, (bool)e.NewValue);
			}));
			NumericUpDown.HasDecimalsProperty = DependencyProperty.Register("HasDecimals", typeof(bool), typeof(NumericUpDown), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(NumericUpDown.OnHasDecimalsChanged)));
			NumericUpDown.NumericInputModeProperty = DependencyProperty.Register("NumericInputMode", typeof(NumericInput), typeof(NumericUpDown), new FrameworkPropertyMetadata(NumericInput.All, new PropertyChangedCallback(NumericUpDown.OnNumericInputModeChanged)));
			NumericUpDown.SnapToMultipleOfIntervalProperty = DependencyProperty.Register("SnapToMultipleOfInterval", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false, new PropertyChangedCallback(NumericUpDown.OnSnapToMultipleOfIntervalChanged)));
			NumericUpDown.RegexStringFormatHexadecimal = new Regex("^(?<complexHEX>.*{\\d:X\\d+}.*)?(?<simpleHEX>X\\d+)?$", RegexOptions.Compiled);
			NumericUpDown.RegexStringFormatNumber = new Regex("[-+]?(?<![0-9][.,])\\b[0-9]+(?:[.,\\s][0-9]+)*[.,]?[0-9]?(?:[eE][-+]?[0-9]+)?\\b(?!\\.[0-9])", RegexOptions.Compiled);
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(typeof(NumericUpDown)));
			Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(VerticalAlignment.Center));
			Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(NumericUpDown), new FrameworkPropertyMetadata(HorizontalAlignment.Right));
			EventManager.RegisterClassHandler(typeof(NumericUpDown), UIElement.GotFocusEvent, new RoutedEventHandler(NumericUpDown.OnGotFocus));
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000552 RID: 1362 RVA: 0x00015266 File Offset: 0x00013466
		// (remove) Token: 0x06000553 RID: 1363 RVA: 0x00015274 File Offset: 0x00013474
		public event RoutedPropertyChangedEventHandler<double?> ValueChanged
		{
			add
			{
				base.AddHandler(NumericUpDown.ValueChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.ValueChangedEvent, value);
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000554 RID: 1364 RVA: 0x00015282 File Offset: 0x00013482
		// (remove) Token: 0x06000555 RID: 1365 RVA: 0x00015290 File Offset: 0x00013490
		public event RoutedEventHandler MaximumReached
		{
			add
			{
				base.AddHandler(NumericUpDown.MaximumReachedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.MaximumReachedEvent, value);
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000556 RID: 1366 RVA: 0x0001529E File Offset: 0x0001349E
		// (remove) Token: 0x06000557 RID: 1367 RVA: 0x000152AC File Offset: 0x000134AC
		public event RoutedEventHandler MinimumReached
		{
			add
			{
				base.AddHandler(NumericUpDown.MinimumReachedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.MinimumReachedEvent, value);
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000558 RID: 1368 RVA: 0x000152BA File Offset: 0x000134BA
		// (remove) Token: 0x06000559 RID: 1369 RVA: 0x000152C8 File Offset: 0x000134C8
		public event NumericUpDownChangedRoutedEventHandler ValueIncremented
		{
			add
			{
				base.AddHandler(NumericUpDown.ValueIncrementedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.ValueIncrementedEvent, value);
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x0600055A RID: 1370 RVA: 0x000152D6 File Offset: 0x000134D6
		// (remove) Token: 0x0600055B RID: 1371 RVA: 0x000152E4 File Offset: 0x000134E4
		public event NumericUpDownChangedRoutedEventHandler ValueDecremented
		{
			add
			{
				base.AddHandler(NumericUpDown.ValueDecrementedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.ValueDecrementedEvent, value);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600055C RID: 1372 RVA: 0x000152F2 File Offset: 0x000134F2
		// (remove) Token: 0x0600055D RID: 1373 RVA: 0x00015300 File Offset: 0x00013500
		public event RoutedEventHandler DelayChanged
		{
			add
			{
				base.AddHandler(NumericUpDown.DelayChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(NumericUpDown.DelayChangedEvent, value);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600055E RID: 1374 RVA: 0x0001530E File Offset: 0x0001350E
		// (set) Token: 0x0600055F RID: 1375 RVA: 0x00015320 File Offset: 0x00013520
		[Bindable(true)]
		[DefaultValue(500)]
		[Category("Behavior")]
		public int Delay
		{
			get
			{
				return (int)base.GetValue(NumericUpDown.DelayProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.DelayProperty, value);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000560 RID: 1376 RVA: 0x00015333 File Offset: 0x00013533
		// (set) Token: 0x06000561 RID: 1377 RVA: 0x00015345 File Offset: 0x00013545
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool InterceptArrowKeys
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.InterceptArrowKeysProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.InterceptArrowKeysProperty, value);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x00015358 File Offset: 0x00013558
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0001536A File Offset: 0x0001356A
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool InterceptMouseWheel
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.InterceptMouseWheelProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.InterceptMouseWheelProperty, value);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001537D File Offset: 0x0001357D
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0001538F File Offset: 0x0001358F
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool TrackMouseWheelWhenMouseOver
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.TrackMouseWheelWhenMouseOverProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.TrackMouseWheelWhenMouseOverProperty, value);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x000153A2 File Offset: 0x000135A2
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x000153B4 File Offset: 0x000135B4
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool InterceptManualEnter
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.InterceptManualEnterProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.InterceptManualEnterProperty, value);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x000153C7 File Offset: 0x000135C7
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x000153D9 File Offset: 0x000135D9
		[Category("Behavior")]
		[DefaultValue(null)]
		public CultureInfo Culture
		{
			get
			{
				return (CultureInfo)base.GetValue(NumericUpDown.CultureProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.CultureProperty, value);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x000153E7 File Offset: 0x000135E7
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x000153F9 File Offset: 0x000135F9
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool HideUpDownButtons
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.HideUpDownButtonsProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.HideUpDownButtonsProperty, value);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0001540C File Offset: 0x0001360C
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0001541E File Offset: 0x0001361E
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(20.0)]
		public double UpDownButtonsWidth
		{
			get
			{
				return (double)base.GetValue(NumericUpDown.UpDownButtonsWidthProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.UpDownButtonsWidthProperty, value);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x00015431 File Offset: 0x00013631
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x00015443 File Offset: 0x00013643
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(ButtonsAlignment.Right)]
		public ButtonsAlignment ButtonsAlignment
		{
			get
			{
				return (ButtonsAlignment)base.GetValue(NumericUpDown.ButtonsAlignmentProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.ButtonsAlignmentProperty, value);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x00015456 File Offset: 0x00013656
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x00015468 File Offset: 0x00013668
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue(1.0)]
		public double Interval
		{
			get
			{
				return (double)base.GetValue(NumericUpDown.IntervalProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.IntervalProperty, value);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0001547B File Offset: 0x0001367B
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x0001548D File Offset: 0x0001368D
		[Obsolete("This property will be deleted in the next release. You should use Controls:TextBoxHelper.SelectAllOnFocus instead.")]
		[Bindable(true)]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool SelectAllOnFocus
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.SelectAllOnFocusProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.SelectAllOnFocusProperty, value);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x000154A0 File Offset: 0x000136A0
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x000154B2 File Offset: 0x000136B2
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x000154C5 File Offset: 0x000136C5
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x000154D7 File Offset: 0x000136D7
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(1.7976931348623157E+308)]
		public double Maximum
		{
			get
			{
				return (double)base.GetValue(NumericUpDown.MaximumProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.MaximumProperty, value);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x000154EA File Offset: 0x000136EA
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x000154FC File Offset: 0x000136FC
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(-1.7976931348623157E+308)]
		public double Minimum
		{
			get
			{
				return (double)base.GetValue(NumericUpDown.MinimumProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.MinimumProperty, value);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0001550F File Offset: 0x0001370F
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x00015521 File Offset: 0x00013721
		[Category("Common")]
		[DefaultValue(true)]
		public bool Speedup
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.SpeedupProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.SpeedupProperty, value);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x00015534 File Offset: 0x00013734
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x00015546 File Offset: 0x00013746
		[Category("Common")]
		public string StringFormat
		{
			get
			{
				return (string)base.GetValue(NumericUpDown.StringFormatProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.StringFormatProperty, value);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x00015554 File Offset: 0x00013754
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x00015566 File Offset: 0x00013766
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(TextAlignment.Right)]
		public TextAlignment TextAlignment
		{
			get
			{
				return (TextAlignment)base.GetValue(NumericUpDown.TextAlignmentProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.TextAlignmentProperty, value);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x00015579 File Offset: 0x00013779
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x0001558B File Offset: 0x0001378B
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(null)]
		public double? Value
		{
			get
			{
				return (double?)base.GetValue(NumericUpDown.ValueProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.ValueProperty, value);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0001559E File Offset: 0x0001379E
		private CultureInfo SpecificCultureInfo
		{
			get
			{
				return this.Culture ?? base.Language.GetSpecificCulture();
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x000155B5 File Offset: 0x000137B5
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x000155C7 File Offset: 0x000137C7
		[Obsolete("This property will be deleted in the next release. Please use the new NumericInputMode property instead.")]
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(true)]
		public bool HasDecimals
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.HasDecimalsProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.HasDecimalsProperty, value);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x000155DA File Offset: 0x000137DA
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x000155EC File Offset: 0x000137EC
		[Category("Common")]
		[DefaultValue(NumericInput.All)]
		public NumericInput NumericInputMode
		{
			get
			{
				return (NumericInput)base.GetValue(NumericUpDown.NumericInputModeProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.NumericInputModeProperty, value);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x000155FF File Offset: 0x000137FF
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x00015611 File Offset: 0x00013811
		[Bindable(true)]
		[Category("Common")]
		[DefaultValue(false)]
		public bool SnapToMultipleOfInterval
		{
			get
			{
				return (bool)base.GetValue(NumericUpDown.SnapToMultipleOfIntervalProperty);
			}
			set
			{
				base.SetValue(NumericUpDown.SnapToMultipleOfIntervalProperty, value);
			}
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00015624 File Offset: 0x00013824
		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			if (!e.Handled)
			{
				NumericUpDown numericUpDown = (NumericUpDown)sender;
				if ((numericUpDown.InterceptManualEnter || numericUpDown.IsReadOnly) && numericUpDown.Focusable && e.OriginalSource == numericUpDown)
				{
					TraversalRequest request = new TraversalRequest(((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next);
					UIElement uielement = Keyboard.FocusedElement as UIElement;
					if (uielement != null)
					{
						uielement.MoveFocus(request);
					}
					else
					{
						numericUpDown.Focus();
					}
					e.Handled = true;
				}
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001569C File Offset: 0x0001389C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._repeatUp = (base.GetTemplateChild("PART_NumericUp") as RepeatButton);
			this._repeatDown = (base.GetTemplateChild("PART_NumericDown") as RepeatButton);
			this._valueTextBox = (base.GetTemplateChild("PART_TextBox") as TextBox);
			if (this._repeatUp == null || this._repeatDown == null || this._valueTextBox == null)
			{
				throw new InvalidOperationException(string.Format("You have missed to specify {0}, {1} or {2} in your template", "PART_NumericUp", "PART_NumericDown", "PART_TextBox"));
			}
			this.ToggleReadOnlyMode(this.IsReadOnly | !this.InterceptManualEnter);
			this._repeatUp.Click += delegate(object o, RoutedEventArgs e)
			{
				this.ChangeValueWithSpeedUp(true);
			};
			this._repeatDown.Click += delegate(object o, RoutedEventArgs e)
			{
				this.ChangeValueWithSpeedUp(false);
			};
			this._repeatUp.PreviewMouseUp += delegate(object o, MouseButtonEventArgs e)
			{
				this.ResetInternal();
			};
			this._repeatDown.PreviewMouseUp += delegate(object o, MouseButtonEventArgs e)
			{
				this.ResetInternal();
			};
			this.OnValueChanged(this.Value, this.Value);
			this._scrollViewer = this.TryFindScrollViewer();
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x000157B8 File Offset: 0x000139B8
		private void ToggleReadOnlyMode(bool isReadOnly)
		{
			if (this._repeatUp == null || this._repeatDown == null || this._valueTextBox == null)
			{
				return;
			}
			if (isReadOnly)
			{
				this._valueTextBox.LostFocus -= this.OnTextBoxLostFocus;
				this._valueTextBox.PreviewTextInput -= this.OnPreviewTextInput;
				this._valueTextBox.PreviewKeyDown -= this.OnTextBoxKeyDown;
				this._valueTextBox.TextChanged -= this.OnTextChanged;
				DataObject.RemovePastingHandler(this._valueTextBox, new DataObjectPastingEventHandler(this.OnValueTextBoxPaste));
				return;
			}
			this._valueTextBox.LostFocus += this.OnTextBoxLostFocus;
			this._valueTextBox.PreviewTextInput += this.OnPreviewTextInput;
			this._valueTextBox.PreviewKeyDown += this.OnTextBoxKeyDown;
			this._valueTextBox.TextChanged += this.OnTextChanged;
			DataObject.AddPastingHandler(this._valueTextBox, new DataObjectPastingEventHandler(this.OnValueTextBoxPaste));
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x000158C8 File Offset: 0x00013AC8
		public void SelectAll()
		{
			if (this._valueTextBox != null)
			{
				this._valueTextBox.SelectAll();
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000158DD File Offset: 0x00013ADD
		protected virtual void OnDelayChanged(int oldDelay, int newDelay)
		{
			if (oldDelay != newDelay)
			{
				if (this._repeatDown != null)
				{
					this._repeatDown.Delay = newDelay;
				}
				if (this._repeatUp != null)
				{
					this._repeatUp.Delay = newDelay;
				}
			}
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001590B File Offset: 0x00013B0B
		protected virtual void OnMaximumChanged(double oldMaximum, double newMaximum)
		{
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001590D File Offset: 0x00013B0D
		protected virtual void OnMinimumChanged(double oldMinimum, double newMinimum)
		{
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00015910 File Offset: 0x00013B10
		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			base.OnPreviewKeyDown(e);
			if (!this.InterceptArrowKeys)
			{
				return;
			}
			Key key = e.Key;
			if (key != Key.Up)
			{
				if (key == Key.Down)
				{
					this.ChangeValueWithSpeedUp(false);
					e.Handled = true;
				}
			}
			else
			{
				this.ChangeValueWithSpeedUp(true);
				e.Handled = true;
			}
			if (e.Handled)
			{
				this._manualChange = false;
				this.InternalSetText(this.Value);
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00015979 File Offset: 0x00013B79
		protected override void OnPreviewKeyUp(KeyEventArgs e)
		{
			base.OnPreviewKeyUp(e);
			if (e.Key == Key.Down || e.Key == Key.Up)
			{
				this.ResetInternal();
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001599C File Offset: 0x00013B9C
		protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
		{
			base.OnPreviewMouseWheel(e);
			if (this.InterceptMouseWheel && (base.IsFocused || this._valueTextBox.IsFocused || this.TrackMouseWheelWhenMouseOver))
			{
				bool addInterval = e.Delta > 0;
				this._manualChange = false;
				this.ChangeValueInternal(addInterval);
			}
			if (this._scrollViewer != null && this._handlesMouseWheelScrolling.Value != null)
			{
				if (this.TrackMouseWheelWhenMouseOver)
				{
					this._handlesMouseWheelScrolling.Value.SetValue(this._scrollViewer, true, null);
					return;
				}
				if (this.InterceptMouseWheel)
				{
					this._handlesMouseWheelScrolling.Value.SetValue(this._scrollViewer, this._valueTextBox.IsFocused, null);
					return;
				}
				this._handlesMouseWheelScrolling.Value.SetValue(this._scrollViewer, true, null);
			}
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00015A80 File Offset: 0x00013C80
		protected void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = true;
			if (string.IsNullOrWhiteSpace(e.Text) || e.Text.Length != 1)
			{
				return;
			}
			TextBox textBox = (TextBox)sender;
			CultureInfo equivalentCulture = this.SpecificCultureInfo;
			NumberFormatInfo numberFormatInfo = equivalentCulture.NumberFormat;
			string text = e.Text;
			if (char.IsDigit(text[0]))
			{
				if (textBox.Text.IndexOf(numberFormatInfo.NegativeSign, textBox.SelectionStart + textBox.SelectionLength, StringComparison.InvariantCultureIgnoreCase) < 0 && textBox.Text.IndexOf(numberFormatInfo.PositiveSign, textBox.SelectionStart + textBox.SelectionLength, StringComparison.InvariantCultureIgnoreCase) < 0)
				{
					e.Handled = false;
				}
			}
			else
			{
				bool flag = textBox.SelectedText == textBox.Text;
				if (numberFormatInfo.NumberDecimalSeparator == text)
				{
					if ((textBox.Text.All((char i) => i.ToString(equivalentCulture) != numberFormatInfo.NumberDecimalSeparator) || flag) && this.NumericInputMode.HasFlag(NumericInput.Decimal))
					{
						e.Handled = false;
					}
				}
				else if (numberFormatInfo.NegativeSign == text || text == numberFormatInfo.PositiveSign)
				{
					if (textBox.SelectionStart == 0)
					{
						if (textBox.Text.Length > 1)
						{
							if (flag || (!textBox.Text.StartsWith(numberFormatInfo.NegativeSign, StringComparison.InvariantCultureIgnoreCase) && !textBox.Text.StartsWith(numberFormatInfo.PositiveSign, StringComparison.InvariantCultureIgnoreCase)))
							{
								e.Handled = false;
							}
						}
						else
						{
							e.Handled = false;
						}
					}
					else if (textBox.SelectionStart > 0 && textBox.Text.ElementAt(textBox.SelectionStart - 1).ToString(equivalentCulture).Equals("E", StringComparison.InvariantCultureIgnoreCase) && this.NumericInputMode.HasFlag(NumericInput.Decimal))
					{
						e.Handled = false;
					}
				}
				else if (text.Equals("E", StringComparison.InvariantCultureIgnoreCase) && this.NumericInputMode.HasFlag(NumericInput.Decimal) && textBox.SelectionStart > 0 && !textBox.Text.Any((char i) => i.ToString(equivalentCulture).Equals("E", StringComparison.InvariantCultureIgnoreCase)))
				{
					e.Handled = false;
				}
			}
			this._manualChange = (this._manualChange || !e.Handled);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00015D10 File Offset: 0x00013F10
		protected virtual void OnSpeedupChanged(bool oldSpeedup, bool newSpeedup)
		{
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00015D14 File Offset: 0x00013F14
		protected virtual void OnValueChanged(double? oldValue, double? newValue)
		{
			if (!this._manualChange)
			{
				if (newValue == null)
				{
					if (this._valueTextBox != null)
					{
						this._valueTextBox.Text = null;
					}
					if (oldValue != newValue)
					{
						base.RaiseEvent(new RoutedPropertyChangedEventArgs<double?>(oldValue, newValue, NumericUpDown.ValueChangedEvent));
					}
					return;
				}
				if (this._repeatUp != null && !this._repeatUp.IsEnabled)
				{
					this._repeatUp.IsEnabled = true;
				}
				if (this._repeatDown != null && !this._repeatDown.IsEnabled)
				{
					this._repeatDown.IsEnabled = true;
				}
				if (newValue <= this.Minimum)
				{
					if (this._repeatDown != null)
					{
						this._repeatDown.IsEnabled = false;
					}
					this.ResetInternal();
					if (base.IsLoaded)
					{
						base.RaiseEvent(new RoutedEventArgs(NumericUpDown.MinimumReachedEvent));
					}
				}
				if (newValue >= this.Maximum)
				{
					if (this._repeatUp != null)
					{
						this._repeatUp.IsEnabled = false;
					}
					this.ResetInternal();
					if (base.IsLoaded)
					{
						base.RaiseEvent(new RoutedEventArgs(NumericUpDown.MaximumReachedEvent));
					}
				}
				if (this._valueTextBox != null)
				{
					this.InternalSetText(newValue);
				}
			}
			if (oldValue != newValue)
			{
				base.RaiseEvent(new RoutedPropertyChangedEventArgs<double?>(oldValue, newValue, NumericUpDown.ValueChangedEvent));
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00015EBC File Offset: 0x000140BC
		private static object CoerceMaximum(DependencyObject d, object value)
		{
			double minimum = ((NumericUpDown)d).Minimum;
			double num = (double)value;
			return (num < minimum) ? minimum : num;
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00015EE9 File Offset: 0x000140E9
		private static object CoerceStringFormat(DependencyObject d, object basevalue)
		{
			return basevalue ?? string.Empty;
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x00015EF8 File Offset: 0x000140F8
		private static object CoerceValue(DependencyObject d, object value)
		{
			if (value == null)
			{
				return null;
			}
			NumericUpDown numericUpDown = (NumericUpDown)d;
			double num = ((double?)value).Value;
			if (!numericUpDown.NumericInputMode.HasFlag(NumericInput.Decimal))
			{
				num = Math.Truncate(num);
			}
			if (num < numericUpDown.Minimum)
			{
				return numericUpDown.Minimum;
			}
			if (num > numericUpDown.Maximum)
			{
				return numericUpDown.Maximum;
			}
			return num;
		}

		// Token: 0x06000599 RID: 1433 RVA: 0x00015F6F File Offset: 0x0001416F
		private static void IntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((NumericUpDown)d).ResetInternal();
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00015F7C File Offset: 0x0001417C
		private static void OnDelayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			numericUpDown.RaiseChangeDelay();
			numericUpDown.OnDelayChanged((int)e.OldValue, (int)e.NewValue);
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00015FA7 File Offset: 0x000141A7
		private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			numericUpDown.CoerceValue(NumericUpDown.ValueProperty);
			numericUpDown.OnMaximumChanged((double)e.OldValue, (double)e.NewValue);
			numericUpDown.EnableDisableUpDown();
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00015FE0 File Offset: 0x000141E0
		private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			numericUpDown.CoerceValue(NumericUpDown.MaximumProperty);
			numericUpDown.CoerceValue(NumericUpDown.ValueProperty);
			numericUpDown.OnMinimumChanged((double)e.OldValue, (double)e.NewValue);
			numericUpDown.EnableDisableUpDown();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0001602C File Offset: 0x0001422C
		private static void OnSpeedupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((NumericUpDown)d).OnSpeedupChanged((bool)e.OldValue, (bool)e.NewValue);
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00016054 File Offset: 0x00014254
		private static void OnStringFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			if (numericUpDown._valueTextBox != null && numericUpDown.Value != null)
			{
				numericUpDown.InternalSetText(numericUpDown.Value);
			}
			string text = (string)e.NewValue;
			if (!numericUpDown.NumericInputMode.HasFlag(NumericInput.Decimal) && !string.IsNullOrEmpty(text) && NumericUpDown.RegexStringFormatHexadecimal.IsMatch(text))
			{
				numericUpDown.SetCurrentValue(NumericUpDown.NumericInputModeProperty, numericUpDown.NumericInputMode | NumericInput.Decimal);
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x000160DE File Offset: 0x000142DE
		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((NumericUpDown)d).OnValueChanged((double?)e.OldValue, (double?)e.NewValue);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00016104 File Offset: 0x00014304
		private static void OnHasDecimalsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			if (e.NewValue != e.OldValue && e.NewValue is bool && numericUpDown.Value != null)
			{
				bool flag = (bool)e.NewValue;
				NumericInput numericInput = numericUpDown.NumericInputMode;
				if (!flag)
				{
					numericUpDown.Value = new double?(Math.Truncate(numericUpDown.Value.GetValueOrDefault()));
					numericInput &= ~NumericInput.Decimal;
				}
				else
				{
					numericInput |= NumericInput.Decimal;
				}
				numericUpDown.SetCurrentValue(NumericUpDown.NumericInputModeProperty, numericInput);
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00016198 File Offset: 0x00014398
		private static void OnNumericInputModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			if (e.NewValue != e.OldValue && e.NewValue is NumericInput && numericUpDown.Value != null)
			{
				NumericInput numericInput = (NumericInput)e.NewValue;
				if (!numericInput.HasFlag(NumericInput.Decimal))
				{
					numericUpDown.Value = new double?(Math.Truncate(numericUpDown.Value.GetValueOrDefault()));
				}
			}
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x00016218 File Offset: 0x00014418
		private static void OnSnapToMultipleOfIntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)d;
			double valueOrDefault = numericUpDown.Value.GetValueOrDefault();
			if ((bool)e.NewValue && Math.Abs(numericUpDown.Interval) > 0.0)
			{
				numericUpDown.Value = new double?(Math.Round(valueOrDefault / numericUpDown.Interval) * numericUpDown.Interval);
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x0001627E File Offset: 0x0001447E
		private static bool ValidateDelay(object value)
		{
			return Convert.ToInt32(value) >= 0;
		}

		// Token: 0x060005A4 RID: 1444 RVA: 0x0001628C File Offset: 0x0001448C
		private void InternalSetText(double? newValue)
		{
			if (newValue == null)
			{
				this._valueTextBox.Text = null;
				return;
			}
			this._valueTextBox.Text = this.FormattedValue(newValue, this.StringFormat, this.SpecificCultureInfo);
			if ((bool)base.GetValue(TextBoxHelper.IsMonitoringProperty))
			{
				base.SetValue(TextBoxHelper.TextLengthProperty, this._valueTextBox.Text.Length);
			}
		}

		// Token: 0x060005A5 RID: 1445 RVA: 0x00016300 File Offset: 0x00014500
		private string FormattedValue(double? newValue, string format, CultureInfo culture)
		{
			format = format.Replace("{}", string.Empty);
			if (!string.IsNullOrWhiteSpace(format))
			{
				Match match = NumericUpDown.RegexStringFormatHexadecimal.Match(format);
				if (match.Success)
				{
					if (match.Groups["simpleHEX"].Success)
					{
						return ((int)newValue.Value).ToString(match.Groups["simpleHEX"].Value, culture);
					}
					if (match.Groups["complexHEX"].Success)
					{
						return string.Format(culture, match.Groups["complexHEX"].Value, (int)newValue.Value);
					}
				}
				else
				{
					if (!format.Contains("{"))
					{
						return newValue.Value.ToString(format, culture);
					}
					return string.Format(culture, format, newValue.Value);
				}
			}
			return newValue.Value.ToString(culture);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00016400 File Offset: 0x00014600
		private ScrollViewer TryFindScrollViewer()
		{
			this._valueTextBox.ApplyTemplate();
			ScrollViewer scrollViewer = this._valueTextBox.Template.FindName("PART_ContentHost", this._valueTextBox) as ScrollViewer;
			if (scrollViewer != null)
			{
				this._handlesMouseWheelScrolling = new Lazy<PropertyInfo>(() => this._scrollViewer.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).SingleOrDefault((PropertyInfo i) => i.Name == "HandlesMouseWheelScrolling"));
			}
			return scrollViewer;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00016454 File Offset: 0x00014654
		private void ChangeValueWithSpeedUp(bool toPositive)
		{
			if (this.IsReadOnly)
			{
				return;
			}
			double num = (double)(toPositive ? 1 : -1);
			if (this.Speedup)
			{
				double num2 = this.Interval * this._internalLargeChange;
				if ((this._intervalValueSinceReset += this.Interval * this._internalIntervalMultiplierForCalculation) > num2)
				{
					this._internalLargeChange *= 10.0;
					this._internalIntervalMultiplierForCalculation *= 10.0;
				}
				this.ChangeValueInternal(num * this._internalIntervalMultiplierForCalculation);
				return;
			}
			this.ChangeValueInternal(num * this.Interval);
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x000164F2 File Offset: 0x000146F2
		private void ChangeValueInternal(bool addInterval)
		{
			this.ChangeValueInternal(addInterval ? this.Interval : (-this.Interval));
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001650C File Offset: 0x0001470C
		private void ChangeValueInternal(double interval)
		{
			if (this.IsReadOnly)
			{
				return;
			}
			NumericUpDownChangedRoutedEventArgs numericUpDownChangedRoutedEventArgs = (interval > 0.0) ? new NumericUpDownChangedRoutedEventArgs(NumericUpDown.ValueIncrementedEvent, interval) : new NumericUpDownChangedRoutedEventArgs(NumericUpDown.ValueDecrementedEvent, interval);
			base.RaiseEvent(numericUpDownChangedRoutedEventArgs);
			if (!numericUpDownChangedRoutedEventArgs.Handled)
			{
				this.ChangeValueBy(numericUpDownChangedRoutedEventArgs.Interval);
				this._valueTextBox.CaretIndex = this._valueTextBox.Text.Length;
			}
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x00016580 File Offset: 0x00014780
		private void ChangeValueBy(double difference)
		{
			double num = this.Value.GetValueOrDefault() + difference;
			base.SetCurrentValue(NumericUpDown.ValueProperty, NumericUpDown.CoerceValue(this, num));
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x000165B8 File Offset: 0x000147B8
		private void EnableDisableDown()
		{
			if (this._repeatDown != null)
			{
				this._repeatDown.IsEnabled = (this.Value > this.Minimum);
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x000165FC File Offset: 0x000147FC
		private void EnableDisableUp()
		{
			if (this._repeatUp != null)
			{
				this._repeatUp.IsEnabled = (this.Value < this.Maximum);
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001663E File Offset: 0x0001483E
		private void EnableDisableUpDown()
		{
			this.EnableDisableUp();
			this.EnableDisableDown();
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001664C File Offset: 0x0001484C
		private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			this._manualChange = (this._manualChange || e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Decimal || e.Key == Key.OemComma || e.Key == Key.OemPeriod);
			if (this.NumericInputMode.HasFlag(NumericInput.Decimal) && (e.Key == Key.Decimal || e.Key == Key.OemPeriod))
			{
				TextBox textBox = sender as TextBox;
				if (!textBox.Text.Contains(this.SpecificCultureInfo.NumberFormat.NumberDecimalSeparator))
				{
					int caretIndex = textBox.CaretIndex;
					textBox.Text = textBox.Text.Insert(caretIndex, this.SpecificCultureInfo.NumberFormat.CurrencyDecimalSeparator);
					textBox.CaretIndex = caretIndex + 1;
				}
				e.Handled = true;
			}
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00016730 File Offset: 0x00014930
		private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
		{
			if (!this.InterceptManualEnter)
			{
				return;
			}
			if (this._manualChange)
			{
				TextBox textBox = (TextBox)sender;
				this._manualChange = false;
				double num;
				if (this.ValidateText(textBox.Text, out num))
				{
					if (this.SnapToMultipleOfInterval && Math.Abs(this.Interval) > 0.0)
					{
						num = Math.Round(num / this.Interval) * this.Interval;
					}
					if (num > this.Maximum)
					{
						num = this.Maximum;
					}
					else if (num < this.Minimum)
					{
						num = this.Minimum;
					}
					base.SetCurrentValue(NumericUpDown.ValueProperty, num);
				}
			}
			this.OnValueChanged(this.Value, this.Value);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x000167E8 File Offset: 0x000149E8
		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (string.IsNullOrEmpty(((TextBox)sender).Text))
			{
				this.Value = null;
				return;
			}
			double num;
			if (this._manualChange && this.ValidateText(((TextBox)sender).Text, out num))
			{
				base.SetCurrentValue(NumericUpDown.ValueProperty, num);
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00016848 File Offset: 0x00014A48
		private void OnValueTextBoxPaste(object sender, DataObjectPastingEventArgs e)
		{
			TextBox textBox = (TextBox)sender;
			string text = textBox.Text;
			if (!e.SourceDataObject.GetDataPresent(DataFormats.Text, true))
			{
				e.CancelCommand();
				return;
			}
			string str = e.SourceDataObject.GetData(DataFormats.Text) as string;
			string text2 = text.Substring(0, textBox.SelectionStart) + str + text.Substring(textBox.SelectionStart + textBox.SelectionLength);
			double num;
			if (!this.ValidateText(text2, out num))
			{
				e.CancelCommand();
				return;
			}
			this._manualChange = true;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x000168D3 File Offset: 0x00014AD3
		private void RaiseChangeDelay()
		{
			base.RaiseEvent(new RoutedEventArgs(NumericUpDown.DelayChangedEvent));
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x000168E5 File Offset: 0x00014AE5
		private void ResetInternal()
		{
			if (this.IsReadOnly)
			{
				return;
			}
			this._internalLargeChange = 100.0 * this.Interval;
			this._internalIntervalMultiplierForCalculation = this.Interval;
			this._intervalValueSinceReset = 0.0;
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00016921 File Offset: 0x00014B21
		private bool ValidateText(string text, out double convertedValue)
		{
			text = this.GetAnyNumberFromText(text);
			return double.TryParse(text, NumberStyles.Any, this.SpecificCultureInfo, out convertedValue);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00016940 File Offset: 0x00014B40
		private string GetAnyNumberFromText(string text)
		{
			MatchCollection matchCollection = NumericUpDown.RegexStringFormatNumber.Matches(text);
			if (matchCollection.Count > 0)
			{
				return matchCollection[0].Value;
			}
			return text;
		}

		// Token: 0x04000215 RID: 533
		public static readonly DependencyProperty DelayProperty;

		// Token: 0x04000216 RID: 534
		public static readonly DependencyProperty TextAlignmentProperty;

		// Token: 0x04000217 RID: 535
		public static readonly DependencyProperty SpeedupProperty;

		// Token: 0x04000218 RID: 536
		public static readonly DependencyProperty IsReadOnlyProperty;

		// Token: 0x04000219 RID: 537
		public static readonly DependencyProperty StringFormatProperty;

		// Token: 0x0400021A RID: 538
		public static readonly DependencyProperty InterceptArrowKeysProperty;

		// Token: 0x0400021B RID: 539
		public static readonly DependencyProperty ValueProperty;

		// Token: 0x0400021C RID: 540
		public static readonly DependencyProperty ButtonsAlignmentProperty;

		// Token: 0x0400021D RID: 541
		public static readonly DependencyProperty MinimumProperty;

		// Token: 0x0400021E RID: 542
		public static readonly DependencyProperty MaximumProperty;

		// Token: 0x0400021F RID: 543
		public static readonly DependencyProperty IntervalProperty;

		// Token: 0x04000220 RID: 544
		public static readonly DependencyProperty InterceptMouseWheelProperty;

		// Token: 0x04000221 RID: 545
		public static readonly DependencyProperty TrackMouseWheelWhenMouseOverProperty;

		// Token: 0x04000222 RID: 546
		public static readonly DependencyProperty HideUpDownButtonsProperty;

		// Token: 0x04000223 RID: 547
		public static readonly DependencyProperty UpDownButtonsWidthProperty;

		// Token: 0x04000224 RID: 548
		public static readonly DependencyProperty InterceptManualEnterProperty;

		// Token: 0x04000225 RID: 549
		public static readonly DependencyProperty CultureProperty;

		// Token: 0x04000226 RID: 550
		[Obsolete("This property will be deleted in the next release. You should use TextBoxHelper.SelectAllOnFocus instead.")]
		public static readonly DependencyProperty SelectAllOnFocusProperty;

		// Token: 0x04000227 RID: 551
		[Obsolete("This property will be deleted in the next release. Please use the new NumericInputMode property instead.")]
		public static readonly DependencyProperty HasDecimalsProperty;

		// Token: 0x04000228 RID: 552
		public static readonly DependencyProperty NumericInputModeProperty;

		// Token: 0x04000229 RID: 553
		public static readonly DependencyProperty SnapToMultipleOfIntervalProperty;

		// Token: 0x0400022A RID: 554
		private static readonly Regex RegexStringFormatHexadecimal;

		// Token: 0x0400022B RID: 555
		private static readonly Regex RegexStringFormatNumber;

		// Token: 0x0400022C RID: 556
		private const double DefaultInterval = 1.0;

		// Token: 0x0400022D RID: 557
		private const int DefaultDelay = 500;

		// Token: 0x0400022E RID: 558
		private const string ElementNumericDown = "PART_NumericDown";

		// Token: 0x0400022F RID: 559
		private const string ElementNumericUp = "PART_NumericUp";

		// Token: 0x04000230 RID: 560
		private const string ElementTextBox = "PART_TextBox";

		// Token: 0x04000231 RID: 561
		private const string ScientificNotationChar = "E";

		// Token: 0x04000232 RID: 562
		private const StringComparison StrComp = StringComparison.InvariantCultureIgnoreCase;

		// Token: 0x04000233 RID: 563
		private Lazy<PropertyInfo> _handlesMouseWheelScrolling = new Lazy<PropertyInfo>();

		// Token: 0x04000234 RID: 564
		private double _internalIntervalMultiplierForCalculation = 1.0;

		// Token: 0x04000235 RID: 565
		private double _internalLargeChange = 100.0;

		// Token: 0x04000236 RID: 566
		private double _intervalValueSinceReset;

		// Token: 0x04000237 RID: 567
		private bool _manualChange;

		// Token: 0x04000238 RID: 568
		private RepeatButton _repeatDown;

		// Token: 0x04000239 RID: 569
		private RepeatButton _repeatUp;

		// Token: 0x0400023A RID: 570
		private TextBox _valueTextBox;

		// Token: 0x0400023B RID: 571
		private ScrollViewer _scrollViewer;
	}
}
