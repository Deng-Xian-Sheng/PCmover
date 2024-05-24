using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200002D RID: 45
	[ContentProperty("ItemsSource")]
	[TemplatePart(Name = "PART_Button", Type = typeof(Button))]
	[TemplatePart(Name = "PART_Image", Type = typeof(Image))]
	[TemplatePart(Name = "PART_ButtonContent", Type = typeof(ContentControl))]
	[TemplatePart(Name = "PART_Menu", Type = typeof(ContextMenu))]
	public class DropDownButton : ItemsControl
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000130 RID: 304 RVA: 0x000065AB File Offset: 0x000047AB
		// (remove) Token: 0x06000131 RID: 305 RVA: 0x000065B9 File Offset: 0x000047B9
		public event RoutedEventHandler Click
		{
			add
			{
				base.AddHandler(DropDownButton.ClickEvent, value);
			}
			remove
			{
				base.RemoveHandler(DropDownButton.ClickEvent, value);
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000065C7 File Offset: 0x000047C7
		private static void IsExpandedPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			DropDownButton dropDownButton = (DropDownButton)dependencyObject;
			dropDownButton.SetContextMenuPlacementTarget(dropDownButton.menu);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000065DA File Offset: 0x000047DA
		protected virtual void SetContextMenuPlacementTarget(ContextMenu contextMenu)
		{
			if (this.clickButton != null)
			{
				contextMenu.PlacementTarget = this.clickButton;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000134 RID: 308 RVA: 0x000065F0 File Offset: 0x000047F0
		// (set) Token: 0x06000135 RID: 309 RVA: 0x000065FD File Offset: 0x000047FD
		public object Content
		{
			get
			{
				return base.GetValue(DropDownButton.ContentProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ContentProperty, value);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000136 RID: 310 RVA: 0x0000660B File Offset: 0x0000480B
		// (set) Token: 0x06000137 RID: 311 RVA: 0x0000661D File Offset: 0x0000481D
		[Bindable(true)]
		public DataTemplate ContentTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DropDownButton.ContentTemplateProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ContentTemplateProperty, value);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000138 RID: 312 RVA: 0x0000662B File Offset: 0x0000482B
		// (set) Token: 0x06000139 RID: 313 RVA: 0x0000663D File Offset: 0x0000483D
		[Bindable(true)]
		public DataTemplateSelector ContentTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DropDownButton.ContentTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ContentTemplateSelectorProperty, value);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600013A RID: 314 RVA: 0x0000664B File Offset: 0x0000484B
		// (set) Token: 0x0600013B RID: 315 RVA: 0x0000665D File Offset: 0x0000485D
		[Bindable(true)]
		public string ContentStringFormat
		{
			get
			{
				return (string)base.GetValue(DropDownButton.ContentStringFormatProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ContentStringFormatProperty, value);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600013C RID: 316 RVA: 0x0000666B File Offset: 0x0000486B
		// (set) Token: 0x0600013D RID: 317 RVA: 0x00006678 File Offset: 0x00004878
		public object CommandParameter
		{
			get
			{
				return base.GetValue(DropDownButton.CommandParameterProperty);
			}
			set
			{
				base.SetValue(DropDownButton.CommandParameterProperty, value);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00006686 File Offset: 0x00004886
		// (set) Token: 0x0600013F RID: 319 RVA: 0x00006698 File Offset: 0x00004898
		public IInputElement CommandTarget
		{
			get
			{
				return (IInputElement)base.GetValue(DropDownButton.CommandTargetProperty);
			}
			set
			{
				base.SetValue(DropDownButton.CommandTargetProperty, value);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000140 RID: 320 RVA: 0x000066A6 File Offset: 0x000048A6
		// (set) Token: 0x06000141 RID: 321 RVA: 0x000066B8 File Offset: 0x000048B8
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(DropDownButton.CommandProperty);
			}
			set
			{
				base.SetValue(DropDownButton.CommandProperty, value);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000142 RID: 322 RVA: 0x000066C6 File Offset: 0x000048C6
		// (set) Token: 0x06000143 RID: 323 RVA: 0x000066D8 File Offset: 0x000048D8
		public bool IsExpanded
		{
			get
			{
				return (bool)base.GetValue(DropDownButton.IsExpandedProperty);
			}
			set
			{
				base.SetValue(DropDownButton.IsExpandedProperty, value);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000144 RID: 324 RVA: 0x000066EB File Offset: 0x000048EB
		// (set) Token: 0x06000145 RID: 325 RVA: 0x000066F8 File Offset: 0x000048F8
		public object ExtraTag
		{
			get
			{
				return base.GetValue(DropDownButton.ExtraTagProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ExtraTagProperty, value);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00006706 File Offset: 0x00004906
		// (set) Token: 0x06000147 RID: 327 RVA: 0x00006718 File Offset: 0x00004918
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(DropDownButton.OrientationProperty);
			}
			set
			{
				base.SetValue(DropDownButton.OrientationProperty, value);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000672B File Offset: 0x0000492B
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00006738 File Offset: 0x00004938
		[Bindable(true)]
		public object Icon
		{
			get
			{
				return base.GetValue(DropDownButton.IconProperty);
			}
			set
			{
				base.SetValue(DropDownButton.IconProperty, value);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00006746 File Offset: 0x00004946
		// (set) Token: 0x0600014B RID: 331 RVA: 0x00006758 File Offset: 0x00004958
		[Bindable(true)]
		public DataTemplate IconTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DropDownButton.IconTemplateProperty);
			}
			set
			{
				base.SetValue(DropDownButton.IconTemplateProperty, value);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600014C RID: 332 RVA: 0x00006766 File Offset: 0x00004966
		// (set) Token: 0x0600014D RID: 333 RVA: 0x00006778 File Offset: 0x00004978
		public Style ButtonStyle
		{
			get
			{
				return (Style)base.GetValue(DropDownButton.ButtonStyleProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ButtonStyleProperty, value);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00006786 File Offset: 0x00004986
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00006798 File Offset: 0x00004998
		public Style MenuStyle
		{
			get
			{
				return (Style)base.GetValue(DropDownButton.MenuStyleProperty);
			}
			set
			{
				base.SetValue(DropDownButton.MenuStyleProperty, value);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000067A6 File Offset: 0x000049A6
		// (set) Token: 0x06000151 RID: 337 RVA: 0x000067B8 File Offset: 0x000049B8
		public Brush ArrowBrush
		{
			get
			{
				return (Brush)base.GetValue(DropDownButton.ArrowBrushProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ArrowBrushProperty, value);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000067C6 File Offset: 0x000049C6
		// (set) Token: 0x06000153 RID: 339 RVA: 0x000067D8 File Offset: 0x000049D8
		public Brush ArrowMouseOverBrush
		{
			get
			{
				return (Brush)base.GetValue(DropDownButton.ArrowMouseOverBrushProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ArrowMouseOverBrushProperty, value);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000067E6 File Offset: 0x000049E6
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000067F8 File Offset: 0x000049F8
		public Brush ArrowPressedBrush
		{
			get
			{
				return (Brush)base.GetValue(DropDownButton.ArrowPressedBrushProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ArrowPressedBrushProperty, value);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000156 RID: 342 RVA: 0x00006806 File Offset: 0x00004A06
		// (set) Token: 0x06000157 RID: 343 RVA: 0x00006818 File Offset: 0x00004A18
		public Visibility ArrowVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DropDownButton.ArrowVisibilityProperty);
			}
			set
			{
				base.SetValue(DropDownButton.ArrowVisibilityProperty, value);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000682C File Offset: 0x00004A2C
		static DropDownButton()
		{
			DropDownButton.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DropDownButton));
			DropDownButton.IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(DropDownButton), new FrameworkPropertyMetadata(new PropertyChangedCallback(DropDownButton.IsExpandedPropertyChangedCallback)));
			DropDownButton.ExtraTagProperty = DependencyProperty.Register("ExtraTag", typeof(object), typeof(DropDownButton));
			DropDownButton.OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(DropDownButton), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));
			DropDownButton.IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(DropDownButton));
			DropDownButton.IconTemplateProperty = DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(DropDownButton));
			DropDownButton.CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(DropDownButton));
			DropDownButton.CommandTargetProperty = DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(DropDownButton));
			DropDownButton.CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(DropDownButton));
			DropDownButton.ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(DropDownButton));
			DropDownButton.ContentTemplateProperty = DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(DropDownButton), new FrameworkPropertyMetadata(null));
			DropDownButton.ContentTemplateSelectorProperty = DependencyProperty.Register("ContentTemplateSelector", typeof(DataTemplateSelector), typeof(DropDownButton), new FrameworkPropertyMetadata(null));
			DropDownButton.ContentStringFormatProperty = DependencyProperty.Register("ContentStringFormat", typeof(string), typeof(DropDownButton), new FrameworkPropertyMetadata(null));
			DropDownButton.ButtonStyleProperty = DependencyProperty.Register("ButtonStyle", typeof(Style), typeof(DropDownButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
			DropDownButton.MenuStyleProperty = DependencyProperty.Register("MenuStyle", typeof(Style), typeof(DropDownButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
			DropDownButton.ArrowBrushProperty = DependencyProperty.Register("ArrowBrush", typeof(Brush), typeof(DropDownButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			DropDownButton.ArrowMouseOverBrushProperty = DependencyProperty.Register("ArrowMouseOverBrush", typeof(Brush), typeof(DropDownButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			DropDownButton.ArrowPressedBrushProperty = DependencyProperty.Register("ArrowPressedBrush", typeof(Brush), typeof(DropDownButton), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
			DropDownButton.ArrowVisibilityProperty = DependencyProperty.Register("ArrowVisibility", typeof(Visibility), typeof(DropDownButton), new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownButton), new FrameworkPropertyMetadata(typeof(DropDownButton)));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00006B59 File Offset: 0x00004D59
		private void ButtonClick(object sender, RoutedEventArgs e)
		{
			base.SetCurrentValue(DropDownButton.IsExpandedProperty, true);
			e.RoutedEvent = DropDownButton.ClickEvent;
			base.RaiseEvent(e);
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00006B80 File Offset: 0x00004D80
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.clickButton = this.EnforceInstance<Button>("PART_Button");
			this.menu = this.EnforceInstance<ContextMenu>("PART_Menu");
			this.InitializeVisualElementsContainer();
			if (this.menu != null && base.Items != null && base.ItemsSource == null)
			{
				foreach (object newItem in ((IEnumerable)base.Items))
				{
					this.TryRemoveVisualFromOldTree(newItem);
					this.menu.Items.Add(newItem);
				}
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00006C2C File Offset: 0x00004E2C
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

		// Token: 0x0600015C RID: 348 RVA: 0x00006C78 File Offset: 0x00004E78
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			if (this.menu == null || base.ItemsSource != null || this.menu.ItemsSource != null)
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
						this.menu.Items.Add(newItem);
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
					this.menu.Items.Remove(removeItem);
				}
				return;
			}
			IL_F3:
			if (e.OldItems != null)
			{
				foreach (object removeItem2 in e.OldItems)
				{
					this.menu.Items.Remove(removeItem2);
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
					this.menu.Items.Add(newItem2);
				}
				return;
			}
			IL_195:
			if (base.Items == null)
			{
				return;
			}
			this.menu.Items.Clear();
			using (IEnumerator enumerator = ((IEnumerable)base.Items).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					object newItem3 = enumerator.Current;
					this.TryRemoveVisualFromOldTree(newItem3);
					this.menu.Items.Add(newItem3);
				}
				return;
			}
			IL_1F9:
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00006EC4 File Offset: 0x000050C4
		private T EnforceInstance<T>(string partName) where T : FrameworkElement, new()
		{
			T result;
			if ((result = (base.GetTemplateChild(partName) as T)) == null)
			{
				result = Activator.CreateInstance<T>();
			}
			return result;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00006EE8 File Offset: 0x000050E8
		private void InitializeVisualElementsContainer()
		{
			base.MouseRightButtonUp -= this.DropDownButtonMouseRightButtonUp;
			this.clickButton.Click -= this.ButtonClick;
			base.MouseRightButtonUp += this.DropDownButtonMouseRightButtonUp;
			this.clickButton.Click += this.ButtonClick;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00006F47 File Offset: 0x00005147
		private void DropDownButtonMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
		}

		// Token: 0x04000051 RID: 81
		public static readonly DependencyProperty IsExpandedProperty;

		// Token: 0x04000052 RID: 82
		public static readonly DependencyProperty ExtraTagProperty;

		// Token: 0x04000053 RID: 83
		public static readonly DependencyProperty OrientationProperty;

		// Token: 0x04000054 RID: 84
		public static readonly DependencyProperty IconProperty;

		// Token: 0x04000055 RID: 85
		public static readonly DependencyProperty IconTemplateProperty;

		// Token: 0x04000056 RID: 86
		public static readonly DependencyProperty CommandProperty;

		// Token: 0x04000057 RID: 87
		public static readonly DependencyProperty CommandTargetProperty;

		// Token: 0x04000058 RID: 88
		public static readonly DependencyProperty CommandParameterProperty;

		// Token: 0x04000059 RID: 89
		public static readonly DependencyProperty ContentProperty;

		// Token: 0x0400005A RID: 90
		public static readonly DependencyProperty ContentTemplateProperty;

		// Token: 0x0400005B RID: 91
		public static readonly DependencyProperty ContentTemplateSelectorProperty;

		// Token: 0x0400005C RID: 92
		public static readonly DependencyProperty ContentStringFormatProperty;

		// Token: 0x0400005D RID: 93
		public static readonly DependencyProperty ButtonStyleProperty;

		// Token: 0x0400005E RID: 94
		public static readonly DependencyProperty MenuStyleProperty;

		// Token: 0x0400005F RID: 95
		public static readonly DependencyProperty ArrowBrushProperty;

		// Token: 0x04000060 RID: 96
		public static readonly DependencyProperty ArrowMouseOverBrushProperty;

		// Token: 0x04000061 RID: 97
		public static readonly DependencyProperty ArrowPressedBrushProperty;

		// Token: 0x04000062 RID: 98
		public static readonly DependencyProperty ArrowVisibilityProperty;

		// Token: 0x04000063 RID: 99
		private Button clickButton;

		// Token: 0x04000064 RID: 100
		private ContextMenu menu;
	}
}
