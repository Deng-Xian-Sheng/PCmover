using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000082 RID: 130
	[ContentProperty("ItemsSource")]
	[DefaultEvent("SelectionChanged")]
	[TemplatePart(Name = "PART_Container", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_Button", Type = typeof(Button))]
	[TemplatePart(Name = "PART_ButtonContent", Type = typeof(ContentControl))]
	[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
	[TemplatePart(Name = "PART_Expander", Type = typeof(Button))]
	[TemplatePart(Name = "PART_ListBox", Type = typeof(ListBox))]
	public class SplitButton : Selector
	{
		// Token: 0x1400002E RID: 46
		// (add) Token: 0x060006C5 RID: 1733 RVA: 0x0001C1D8 File Offset: 0x0001A3D8
		// (remove) Token: 0x060006C6 RID: 1734 RVA: 0x0001C1E6 File Offset: 0x0001A3E6
		public event RoutedEventHandler Click
		{
			add
			{
				base.AddHandler(SplitButton.ClickEvent, value);
			}
			remove
			{
				base.RemoveHandler(SplitButton.ClickEvent, value);
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0001C1F4 File Offset: 0x0001A3F4
		// (set) Token: 0x060006C8 RID: 1736 RVA: 0x0001C201 File Offset: 0x0001A401
		public object CommandParameter
		{
			get
			{
				return base.GetValue(SplitButton.CommandParameterProperty);
			}
			set
			{
				base.SetValue(SplitButton.CommandParameterProperty, value);
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0001C20F File Offset: 0x0001A40F
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x0001C221 File Offset: 0x0001A421
		public IInputElement CommandTarget
		{
			get
			{
				return (IInputElement)base.GetValue(SplitButton.CommandTargetProperty);
			}
			set
			{
				base.SetValue(SplitButton.CommandTargetProperty, value);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0001C22F File Offset: 0x0001A42F
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0001C241 File Offset: 0x0001A441
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(SplitButton.CommandProperty);
			}
			set
			{
				base.SetValue(SplitButton.CommandProperty, value);
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x0001C24F File Offset: 0x0001A44F
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x0001C261 File Offset: 0x0001A461
		public bool IsExpanded
		{
			get
			{
				return (bool)base.GetValue(SplitButton.IsExpandedProperty);
			}
			set
			{
				base.SetValue(SplitButton.IsExpandedProperty, value);
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x0001C274 File Offset: 0x0001A474
		// (set) Token: 0x060006D0 RID: 1744 RVA: 0x0001C281 File Offset: 0x0001A481
		public object ExtraTag
		{
			get
			{
				return base.GetValue(SplitButton.ExtraTagProperty);
			}
			set
			{
				base.SetValue(SplitButton.ExtraTagProperty, value);
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0001C28F File Offset: 0x0001A48F
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x0001C2A1 File Offset: 0x0001A4A1
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(SplitButton.OrientationProperty);
			}
			set
			{
				base.SetValue(SplitButton.OrientationProperty, value);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001C2B4 File Offset: 0x0001A4B4
		// (set) Token: 0x060006D4 RID: 1748 RVA: 0x0001C2C1 File Offset: 0x0001A4C1
		[Bindable(true)]
		public object Icon
		{
			get
			{
				return base.GetValue(SplitButton.IconProperty);
			}
			set
			{
				base.SetValue(SplitButton.IconProperty, value);
			}
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0001C2CF File Offset: 0x0001A4CF
		// (set) Token: 0x060006D6 RID: 1750 RVA: 0x0001C2E1 File Offset: 0x0001A4E1
		[Bindable(true)]
		public DataTemplate IconTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(SplitButton.IconTemplateProperty);
			}
			set
			{
				base.SetValue(SplitButton.IconTemplateProperty, value);
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001C2EF File Offset: 0x0001A4EF
		// (set) Token: 0x060006D8 RID: 1752 RVA: 0x0001C301 File Offset: 0x0001A501
		public Style ButtonStyle
		{
			get
			{
				return (Style)base.GetValue(SplitButton.ButtonStyleProperty);
			}
			set
			{
				base.SetValue(SplitButton.ButtonStyleProperty, value);
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0001C30F File Offset: 0x0001A50F
		// (set) Token: 0x060006DA RID: 1754 RVA: 0x0001C321 File Offset: 0x0001A521
		public Style ButtonArrowStyle
		{
			get
			{
				return (Style)base.GetValue(SplitButton.ButtonArrowStyleProperty);
			}
			set
			{
				base.SetValue(SplitButton.ButtonArrowStyleProperty, value);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x0001C32F File Offset: 0x0001A52F
		// (set) Token: 0x060006DC RID: 1756 RVA: 0x0001C341 File Offset: 0x0001A541
		public Style ListBoxStyle
		{
			get
			{
				return (Style)base.GetValue(SplitButton.ListBoxStyleProperty);
			}
			set
			{
				base.SetValue(SplitButton.ListBoxStyleProperty, value);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0001C34F File Offset: 0x0001A54F
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x0001C361 File Offset: 0x0001A561
		public Brush ArrowBrush
		{
			get
			{
				return (Brush)base.GetValue(SplitButton.ArrowBrushProperty);
			}
			set
			{
				base.SetValue(SplitButton.ArrowBrushProperty, value);
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0001C36F File Offset: 0x0001A56F
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0001C381 File Offset: 0x0001A581
		public Brush ArrowMouseOverBrush
		{
			get
			{
				return (Brush)base.GetValue(SplitButton.ArrowMouseOverBrushProperty);
			}
			set
			{
				base.SetValue(SplitButton.ArrowMouseOverBrushProperty, value);
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0001C38F File Offset: 0x0001A58F
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0001C3A1 File Offset: 0x0001A5A1
		public Brush ArrowPressedBrush
		{
			get
			{
				return (Brush)base.GetValue(SplitButton.ArrowPressedBrushProperty);
			}
			set
			{
				base.SetValue(SplitButton.ArrowPressedBrushProperty, value);
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0001C3B0 File Offset: 0x0001A5B0
		static SplitButton()
		{
			SplitButton.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplitButton));
			SplitButton.IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(SplitButton));
			SplitButton.ExtraTagProperty = DependencyProperty.Register("ExtraTag", typeof(object), typeof(SplitButton));
			SplitButton.OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SplitButton), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));
			SplitButton.IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(SplitButton));
			SplitButton.IconTemplateProperty = DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(SplitButton));
			SplitButton.CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButton));
			SplitButton.CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(SplitButton));
			SplitButton.CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButton));
			SplitButton.ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
			SplitButton.ButtonArrowStyleProperty = DependencyProperty.Register("ButtonArrowStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
			SplitButton.ListBoxStyleProperty = DependencyProperty.Register("ListBoxStyle", typeof(Style), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
			SplitButton.ArrowBrushProperty = DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			SplitButton.ArrowMouseOverBrushProperty = DependencyProperty.Register("ArrowMouseOverBrush", typeof(Brush), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			SplitButton.ArrowPressedBrushProperty = DependencyProperty.Register("ArrowPressedBrush", typeof(Brush), typeof(SplitButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButton), new FrameworkPropertyMetadata(typeof(SplitButton)));
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x0001C62A File Offset: 0x0001A82A
		public SplitButton()
		{
			Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this, new MouseButtonEventHandler(this.OutsideCapturedElementHandler));
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x0001C644 File Offset: 0x0001A844
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			e.RoutedEvent = SplitButton.ClickEvent;
			base.RaiseEvent(e);
			base.SetCurrentValue(SplitButton.IsExpandedProperty, false);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0001C669 File Offset: 0x0001A869
		private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			base.SetCurrentValue(SplitButton.IsExpandedProperty, false);
			e.Handled = true;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0001C683 File Offset: 0x0001A883
		private void ExpanderClick(object sender, RoutedEventArgs e)
		{
			base.SetCurrentValue(SplitButton.IsExpandedProperty, !this.IsExpanded);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0001C6A0 File Offset: 0x0001A8A0
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._clickButton = this.EnforceInstance<Button>("PART_Button");
			this._expander = this.EnforceInstance<Button>("PART_Expander");
			this._listBox = this.EnforceInstance<ListBox>("PART_ListBox");
			this._popup = this.EnforceInstance<Popup>("PART_Popup");
			this.InitializeVisualElementsContainer();
			if (this._listBox != null && base.Items != null && base.ItemsSource == null)
			{
				foreach (object newItem in ((IEnumerable)base.Items))
				{
					this.TryRemoveVisualFromOldTree(newItem);
					this._listBox.Items.Add(newItem);
				}
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0001C770 File Offset: 0x0001A970
		private void TryRemoveVisualFromOldTree(object newItem)
		{
			Visual visual = newItem as Visual;
			if (visual != null)
			{
				FrameworkElement objB = (LogicalTreeHelper.GetParent(visual) as FrameworkElement) ?? (VisualTreeHelper.GetParent(visual) as FrameworkElement);
				if (object.Equals(this, objB))
				{
					base.RemoveLogicalChild(visual);
					base.RemoveVisualChild(visual);
				}
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001C7BC File Offset: 0x0001A9BC
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			if (this._listBox == null || base.ItemsSource != null || this._listBox.ItemsSource != null)
			{
				return;
			}
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				if (e.NewItems == null)
				{
					return;
				}
				using (IEnumerator enumerator = e.NewItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object newItem = enumerator.Current;
						this.TryRemoveVisualFromOldTree(newItem);
						this._listBox.Items.Add(newItem);
					}
					return;
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				break;
			case NotifyCollectionChangedAction.Replace:
			case NotifyCollectionChangedAction.Move:
				goto IL_F3;
			case NotifyCollectionChangedAction.Reset:
				goto IL_195;
			default:
				goto IL_1F9;
			}
			if (e.OldItems == null)
			{
				return;
			}
			using (IEnumerator enumerator = e.OldItems.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object removeItem = enumerator.Current;
					this._listBox.Items.Remove(removeItem);
				}
				return;
			}
			IL_F3:
			if (e.OldItems != null)
			{
				foreach (object removeItem2 in e.OldItems)
				{
					this._listBox.Items.Remove(removeItem2);
				}
			}
			if (e.NewItems == null)
			{
				return;
			}
			using (IEnumerator enumerator = e.NewItems.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object newItem2 = enumerator.Current;
					this.TryRemoveVisualFromOldTree(newItem2);
					this._listBox.Items.Add(newItem2);
				}
				return;
			}
			IL_195:
			if (base.Items == null)
			{
				return;
			}
			this._listBox.Items.Clear();
			using (IEnumerator enumerator = ((IEnumerable)base.Items).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object newItem3 = enumerator.Current;
					this.TryRemoveVisualFromOldTree(newItem3);
					this._listBox.Items.Add(newItem3);
				}
				return;
			}
			IL_1F9:
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0001CA08 File Offset: 0x0001AC08
		private T EnforceInstance<T>(string partName) where T : FrameworkElement, new()
		{
			T result;
			if ((result = (base.GetTemplateChild(partName) as T)) == null)
			{
				result = Activator.CreateInstance<T>();
			}
			return result;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0001CA2C File Offset: 0x0001AC2C
		private void InitializeVisualElementsContainer()
		{
			this._expander.Click -= this.ExpanderClick;
			this._clickButton.Click -= this.ButtonClick;
			this._listBox.SelectionChanged -= this.ListBoxSelectionChanged;
			this._listBox.PreviewMouseLeftButtonDown -= this.ListBoxPreviewMouseLeftButtonDown;
			this._popup.Opened -= this.PopupOpened;
			this._popup.Closed -= this.PopupClosed;
			this._expander.Click += this.ExpanderClick;
			this._clickButton.Click += this.ButtonClick;
			this._listBox.SelectionChanged += this.ListBoxSelectionChanged;
			this._listBox.PreviewMouseLeftButtonDown += this.ListBoxPreviewMouseLeftButtonDown;
			this._popup.Opened += this.PopupOpened;
			this._popup.Closed += this.PopupClosed;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x0001CB50 File Offset: 0x0001AD50
		private void ListBoxPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DependencyObject dependencyObject = e.OriginalSource as DependencyObject;
			if (dependencyObject != null && ItemsControl.ContainerFromElement(this._listBox, dependencyObject) is ListBoxItem)
			{
				base.SetCurrentValue(SplitButton.IsExpandedProperty, false);
			}
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0001CB90 File Offset: 0x0001AD90
		private void PopupClosed(object sender, EventArgs e)
		{
			base.SetCurrentValue(SplitButton.IsExpandedProperty, false);
			base.ReleaseMouseCapture();
			Mouse.RemoveLostMouseCaptureHandler(this._popup, new MouseEventHandler(this.LostMouseCaptureHandler));
			if (base.IsKeyboardFocusWithin)
			{
				Button expander = this._expander;
				if (expander == null)
				{
					return;
				}
				expander.Focus();
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0001CBE4 File Offset: 0x0001ADE4
		private void PopupOpened(object sender, EventArgs e)
		{
			Mouse.Capture(this, CaptureMode.SubTree);
			Mouse.AddLostMouseCaptureHandler(this._popup, new MouseEventHandler(this.LostMouseCaptureHandler));
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001CC05 File Offset: 0x0001AE05
		private void LostMouseCaptureHandler(object sender, MouseEventArgs e)
		{
			if (this.IsExpanded)
			{
				Mouse.Capture(this, CaptureMode.SubTree);
			}
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x0001CC17 File Offset: 0x0001AE17
		private void OutsideCapturedElementHandler(object sender, MouseButtonEventArgs e)
		{
			this.PopupClosed(sender, e);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0001CC21 File Offset: 0x0001AE21
		protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnIsKeyboardFocusWithinChanged(e);
			if (!(bool)e.NewValue)
			{
				base.SetCurrentValue(SplitButton.IsExpandedProperty, false);
			}
		}

		// Token: 0x040002BB RID: 699
		public static readonly DependencyProperty IsExpandedProperty;

		// Token: 0x040002BC RID: 700
		public static readonly DependencyProperty ExtraTagProperty;

		// Token: 0x040002BD RID: 701
		public static readonly DependencyProperty OrientationProperty;

		// Token: 0x040002BE RID: 702
		public static readonly DependencyProperty IconProperty;

		// Token: 0x040002BF RID: 703
		public static readonly DependencyProperty IconTemplateProperty;

		// Token: 0x040002C0 RID: 704
		public static readonly DependencyProperty CommandProperty;

		// Token: 0x040002C1 RID: 705
		public static readonly DependencyProperty CommandTargetProperty;

		// Token: 0x040002C2 RID: 706
		public static readonly DependencyProperty CommandParameterProperty;

		// Token: 0x040002C3 RID: 707
		public static readonly DependencyProperty ButtonStyleProperty;

		// Token: 0x040002C4 RID: 708
		public static readonly DependencyProperty ButtonArrowStyleProperty;

		// Token: 0x040002C5 RID: 709
		public static readonly DependencyProperty ListBoxStyleProperty;

		// Token: 0x040002C6 RID: 710
		public static readonly DependencyProperty ArrowBrushProperty;

		// Token: 0x040002C7 RID: 711
		public static readonly DependencyProperty ArrowMouseOverBrushProperty;

		// Token: 0x040002C8 RID: 712
		public static readonly DependencyProperty ArrowPressedBrushProperty;

		// Token: 0x040002C9 RID: 713
		private Button _clickButton;

		// Token: 0x040002CA RID: 714
		private Button _expander;

		// Token: 0x040002CB RID: 715
		private ListBox _listBox;

		// Token: 0x040002CC RID: 716
		private Popup _popup;
	}
}
