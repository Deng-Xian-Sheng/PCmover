using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000038 RID: 56
	[TemplatePart(Name = "HamburgerButton", Type = typeof(Button))]
	[TemplatePart(Name = "ButtonsListView", Type = typeof(ListBox))]
	[TemplatePart(Name = "OptionsListView", Type = typeof(ListBox))]
	public class HamburgerMenu : ContentControl
	{
		// Token: 0x0600022E RID: 558 RVA: 0x0000A8C3 File Offset: 0x00008AC3
		public HamburgerMenu()
		{
			base.DefaultStyleKey = typeof(HamburgerMenu);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000A8DC File Offset: 0x00008ADC
		public override void OnApplyTemplate()
		{
			if (this._hamburgerButton != null)
			{
				this._hamburgerButton.Click -= this.HamburgerButton_Click;
			}
			if (this._buttonsListView != null)
			{
				this._buttonsListView.MouseUp -= this.ButtonsListView_ItemClick;
				this._buttonsListView.SelectionChanged -= this.ButtonsListView_SelectionChanged;
			}
			if (this._optionsListView != null)
			{
				this._optionsListView.MouseUp -= this.OptionsListView_ItemClick;
				this._optionsListView.SelectionChanged -= this.OptionsListView_SelectionChanged;
			}
			this._hamburgerButton = (Button)base.GetTemplateChild("HamburgerButton");
			this._buttonsListView = (ListBox)base.GetTemplateChild("ButtonsListView");
			this._optionsListView = (ListBox)base.GetTemplateChild("OptionsListView");
			if (this._hamburgerButton != null)
			{
				this._hamburgerButton.Click += this.HamburgerButton_Click;
			}
			if (this._buttonsListView != null)
			{
				this._buttonsListView.MouseUp += this.ButtonsListView_ItemClick;
				this._buttonsListView.SelectionChanged += this.ButtonsListView_SelectionChanged;
			}
			if (this._optionsListView != null)
			{
				this._optionsListView.MouseUp += this.OptionsListView_ItemClick;
				this._optionsListView.SelectionChanged += this.OptionsListView_SelectionChanged;
			}
			this.ChangeItemFocusVisualStyle();
			base.Loaded -= this.HamburgerMenu_Loaded;
			base.Loaded += this.HamburgerMenu_Loaded;
			base.OnApplyTemplate();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000AA74 File Offset: 0x00008C74
		private void HamburgerMenu_Loaded(object sender, RoutedEventArgs e)
		{
			if (base.GetValue(ContentControl.ContentProperty) != null)
			{
				return;
			}
			ListBox buttonsListView = this._buttonsListView;
			object obj;
			if ((obj = ((buttonsListView != null) ? buttonsListView.SelectedItem : null)) == null)
			{
				ListBox optionsListView = this._optionsListView;
				obj = ((optionsListView != null) ? optionsListView.SelectedItem : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				base.SetCurrentValue(ContentControl.ContentProperty, obj2);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000231 RID: 561 RVA: 0x0000AAC8 File Offset: 0x00008CC8
		// (remove) Token: 0x06000232 RID: 562 RVA: 0x0000AB00 File Offset: 0x00008D00
		public event ItemClickEventHandler ItemClick;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000233 RID: 563 RVA: 0x0000AB38 File Offset: 0x00008D38
		// (remove) Token: 0x06000234 RID: 564 RVA: 0x0000AB70 File Offset: 0x00008D70
		public event ItemClickEventHandler OptionsItemClick;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000235 RID: 565 RVA: 0x0000ABA8 File Offset: 0x00008DA8
		// (remove) Token: 0x06000236 RID: 566 RVA: 0x0000ABE0 File Offset: 0x00008DE0
		public event EventHandler<HamburgerMenuItemInvokedEventArgs> ItemInvoked;

		// Token: 0x06000237 RID: 567 RVA: 0x0000AC15 File Offset: 0x00008E15
		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{
			this.IsPaneOpen = !this.IsPaneOpen;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000AC28 File Offset: 0x00008E28
		private void OnItemClick()
		{
			if (this._optionsListView != null)
			{
				this._optionsListView.SelectedIndex = -1;
			}
			object selectedItem = this._buttonsListView.SelectedItem;
			HamburgerMenuItem hamburgerMenuItem = selectedItem as HamburgerMenuItem;
			if (hamburgerMenuItem != null)
			{
				hamburgerMenuItem.RaiseCommand();
			}
			this.RaiseItemCommand();
			ItemClickEventHandler itemClick = this.ItemClick;
			if (itemClick != null)
			{
				itemClick(this, new ItemClickEventArgs(selectedItem));
			}
			EventHandler<HamburgerMenuItemInvokedEventArgs> itemInvoked = this.ItemInvoked;
			if (itemInvoked == null)
			{
				return;
			}
			itemInvoked(this, new HamburgerMenuItemInvokedEventArgs
			{
				InvokedItem = selectedItem,
				IsItemOptions = false
			});
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000ACA8 File Offset: 0x00008EA8
		private void OnOptionsItemClick()
		{
			if (this._buttonsListView != null)
			{
				this._buttonsListView.SelectedIndex = -1;
			}
			object selectedItem = this._optionsListView.SelectedItem;
			HamburgerMenuItem hamburgerMenuItem = selectedItem as HamburgerMenuItem;
			if (hamburgerMenuItem != null)
			{
				hamburgerMenuItem.RaiseCommand();
			}
			this.RaiseOptionsItemCommand();
			ItemClickEventHandler optionsItemClick = this.OptionsItemClick;
			if (optionsItemClick != null)
			{
				optionsItemClick(this, new ItemClickEventArgs(selectedItem));
			}
			EventHandler<HamburgerMenuItemInvokedEventArgs> itemInvoked = this.ItemInvoked;
			if (itemInvoked == null)
			{
				return;
			}
			itemInvoked(this, new HamburgerMenuItemInvokedEventArgs
			{
				InvokedItem = selectedItem,
				IsItemOptions = true
			});
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000AD28 File Offset: 0x00008F28
		private ListBoxItem GetClickedListBoxItem(ItemsControl itemsControl, DependencyObject dependencyObject)
		{
			if (itemsControl == null || dependencyObject == null)
			{
				return null;
			}
			return ItemsControl.ContainerFromElement(itemsControl, dependencyObject) as ListBoxItem;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000AD3E File Offset: 0x00008F3E
		private void ButtonsListView_ItemClick(object sender, MouseButtonEventArgs e)
		{
			if (this.GetClickedListBoxItem(sender as ItemsControl, e.OriginalSource as DependencyObject) != null)
			{
				this.OnItemClick();
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000AD5F File Offset: 0x00008F5F
		private void OptionsListView_ItemClick(object sender, MouseButtonEventArgs e)
		{
			if (this.GetClickedListBoxItem(sender as ItemsControl, e.OriginalSource as DependencyObject) != null)
			{
				this.OnOptionsItemClick();
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000AD80 File Offset: 0x00008F80
		private void ButtonsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems != null && e.AddedItems.Count > 0 && (Keyboard.IsKeyToggled(Key.Space) || Keyboard.IsKeyToggled(Key.Up) || Keyboard.IsKeyToggled(Key.Prior) || Keyboard.IsKeyToggled(Key.Down) || Keyboard.IsKeyToggled(Key.Next)))
			{
				this.OnItemClick();
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000ADD8 File Offset: 0x00008FD8
		private void OptionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems != null && e.AddedItems.Count > 0 && (Keyboard.IsKeyToggled(Key.Space) || Keyboard.IsKeyToggled(Key.Up) || Keyboard.IsKeyToggled(Key.Prior) || Keyboard.IsKeyToggled(Key.Down) || Keyboard.IsKeyToggled(Key.Next)))
			{
				this.OnOptionsItemClick();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000AE2E File Offset: 0x0000902E
		// (set) Token: 0x06000240 RID: 576 RVA: 0x0000AE40 File Offset: 0x00009040
		public DataTemplate HamburgerMenuTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(HamburgerMenu.HamburgerMenuTemplateProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerMenuTemplateProperty, value);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000241 RID: 577 RVA: 0x0000AE4E File Offset: 0x0000904E
		// (set) Token: 0x06000242 RID: 578 RVA: 0x0000AE60 File Offset: 0x00009060
		public DataTemplate HamburgerMenuHeaderTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(HamburgerMenu.HamburgerMenuHeaderTemplateProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerMenuHeaderTemplateProperty, value);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000243 RID: 579 RVA: 0x0000AE6E File Offset: 0x0000906E
		// (set) Token: 0x06000244 RID: 580 RVA: 0x0000AE80 File Offset: 0x00009080
		public double HamburgerWidth
		{
			get
			{
				return (double)base.GetValue(HamburgerMenu.HamburgerWidthProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerWidthProperty, value);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000245 RID: 581 RVA: 0x0000AE93 File Offset: 0x00009093
		// (set) Token: 0x06000246 RID: 582 RVA: 0x0000AEA5 File Offset: 0x000090A5
		public double HamburgerHeight
		{
			get
			{
				return (double)base.GetValue(HamburgerMenu.HamburgerHeightProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerHeightProperty, value);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000247 RID: 583 RVA: 0x0000AEB8 File Offset: 0x000090B8
		// (set) Token: 0x06000248 RID: 584 RVA: 0x0000AECA File Offset: 0x000090CA
		public Thickness HamburgerMargin
		{
			get
			{
				return (Thickness)base.GetValue(HamburgerMenu.HamburgerMarginProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerMarginProperty, value);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000AEDD File Offset: 0x000090DD
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000AEEF File Offset: 0x000090EF
		public Visibility HamburgerVisibility
		{
			get
			{
				return (Visibility)base.GetValue(HamburgerMenu.HamburgerVisibilityProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.HamburgerVisibilityProperty, value);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000AF02 File Offset: 0x00009102
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0000AF0F File Offset: 0x0000910F
		public object OptionsItemsSource
		{
			get
			{
				return base.GetValue(HamburgerMenu.OptionsItemsSourceProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemsSourceProperty, value);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600024D RID: 589 RVA: 0x0000AF1D File Offset: 0x0000911D
		// (set) Token: 0x0600024E RID: 590 RVA: 0x0000AF2F File Offset: 0x0000912F
		public Style OptionsItemContainerStyle
		{
			get
			{
				return (Style)base.GetValue(HamburgerMenu.OptionsItemContainerStyleProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemContainerStyleProperty, value);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0000AF3D File Offset: 0x0000913D
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0000AF4F File Offset: 0x0000914F
		public DataTemplate OptionsItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(HamburgerMenu.OptionsItemTemplateProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemTemplateProperty, value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000AF5D File Offset: 0x0000915D
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0000AF6F File Offset: 0x0000916F
		public DataTemplateSelector OptionsItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(HamburgerMenu.OptionsItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemTemplateSelectorProperty, value);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000AF7D File Offset: 0x0000917D
		public ItemCollection OptionsItems
		{
			get
			{
				if (this._optionsListView == null)
				{
					throw new Exception("OptionsListView is not defined yet. Please use OptionsItemsSource instead.");
				}
				ListBox optionsListView = this._optionsListView;
				if (optionsListView == null)
				{
					return null;
				}
				return optionsListView.Items;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000254 RID: 596 RVA: 0x0000AFA3 File Offset: 0x000091A3
		// (set) Token: 0x06000255 RID: 597 RVA: 0x0000AFB5 File Offset: 0x000091B5
		public Visibility OptionsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(HamburgerMenu.OptionsVisibilityProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsVisibilityProperty, value);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0000AFC8 File Offset: 0x000091C8
		// (set) Token: 0x06000257 RID: 599 RVA: 0x0000AFD5 File Offset: 0x000091D5
		public object SelectedOptionsItem
		{
			get
			{
				return base.GetValue(HamburgerMenu.SelectedOptionsItemProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.SelectedOptionsItemProperty, value);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0000AFE3 File Offset: 0x000091E3
		// (set) Token: 0x06000259 RID: 601 RVA: 0x0000AFF5 File Offset: 0x000091F5
		public int SelectedOptionsIndex
		{
			get
			{
				return (int)base.GetValue(HamburgerMenu.SelectedOptionsIndexProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.SelectedOptionsIndexProperty, value);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600025A RID: 602 RVA: 0x0000B008 File Offset: 0x00009208
		// (set) Token: 0x0600025B RID: 603 RVA: 0x0000B01A File Offset: 0x0000921A
		public ICommand OptionsItemCommand
		{
			get
			{
				return (ICommand)base.GetValue(HamburgerMenu.OptionsItemCommandProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemCommandProperty, value);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600025C RID: 604 RVA: 0x0000B028 File Offset: 0x00009228
		// (set) Token: 0x0600025D RID: 605 RVA: 0x0000B035 File Offset: 0x00009235
		public object OptionsItemCommandParameter
		{
			get
			{
				return base.GetValue(HamburgerMenu.OptionsItemCommandParameterProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OptionsItemCommandParameterProperty, value);
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000B044 File Offset: 0x00009244
		public void RaiseOptionsItemCommand()
		{
			ICommand optionsItemCommand = this.OptionsItemCommand;
			object parameter = this.OptionsItemCommandParameter ?? this;
			if (optionsItemCommand != null && optionsItemCommand.CanExecute(parameter))
			{
				optionsItemCommand.Execute(parameter);
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000B077 File Offset: 0x00009277
		private static void OpenPaneLengthPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != args.OldValue)
			{
				HamburgerMenu hamburgerMenu = dependencyObject as HamburgerMenu;
				if (hamburgerMenu == null)
				{
					return;
				}
				hamburgerMenu.ChangeItemFocusVisualStyle();
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000B099 File Offset: 0x00009299
		private static void CompactPaneLengthPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != args.OldValue)
			{
				HamburgerMenu hamburgerMenu = dependencyObject as HamburgerMenu;
				if (hamburgerMenu == null)
				{
					return;
				}
				hamburgerMenu.ChangeItemFocusVisualStyle();
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000B0BB File Offset: 0x000092BB
		private static void IsPaneOpenPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (args.NewValue != args.OldValue)
			{
				HamburgerMenu hamburgerMenu = dependencyObject as HamburgerMenu;
				if (hamburgerMenu == null)
				{
					return;
				}
				hamburgerMenu.ChangeItemFocusVisualStyle();
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000262 RID: 610 RVA: 0x0000B0DD File Offset: 0x000092DD
		// (set) Token: 0x06000263 RID: 611 RVA: 0x0000B0EF File Offset: 0x000092EF
		public double OpenPaneLength
		{
			get
			{
				return (double)base.GetValue(HamburgerMenu.OpenPaneLengthProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.OpenPaneLengthProperty, value);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000264 RID: 612 RVA: 0x0000B102 File Offset: 0x00009302
		// (set) Token: 0x06000265 RID: 613 RVA: 0x0000B114 File Offset: 0x00009314
		public SplitViewPanePlacement PanePlacement
		{
			get
			{
				return (SplitViewPanePlacement)base.GetValue(HamburgerMenu.PanePlacementProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.PanePlacementProperty, value);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000B127 File Offset: 0x00009327
		// (set) Token: 0x06000267 RID: 615 RVA: 0x0000B139 File Offset: 0x00009339
		public SplitViewDisplayMode DisplayMode
		{
			get
			{
				return (SplitViewDisplayMode)base.GetValue(HamburgerMenu.DisplayModeProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.DisplayModeProperty, value);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0000B14C File Offset: 0x0000934C
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0000B15E File Offset: 0x0000935E
		public double CompactPaneLength
		{
			get
			{
				return (double)base.GetValue(HamburgerMenu.CompactPaneLengthProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.CompactPaneLengthProperty, value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000B171 File Offset: 0x00009371
		// (set) Token: 0x0600026B RID: 619 RVA: 0x0000B183 File Offset: 0x00009383
		public Brush PaneBackground
		{
			get
			{
				return (Brush)base.GetValue(HamburgerMenu.PaneBackgroundProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.PaneBackgroundProperty, value);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000B191 File Offset: 0x00009391
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000B1A3 File Offset: 0x000093A3
		public Brush PaneForeground
		{
			get
			{
				return (Brush)base.GetValue(HamburgerMenu.PaneForegroundProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.PaneForegroundProperty, value);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600026E RID: 622 RVA: 0x0000B1B1 File Offset: 0x000093B1
		// (set) Token: 0x0600026F RID: 623 RVA: 0x0000B1C3 File Offset: 0x000093C3
		public bool IsPaneOpen
		{
			get
			{
				return (bool)base.GetValue(HamburgerMenu.IsPaneOpenProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.IsPaneOpenProperty, value);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0000B1D6 File Offset: 0x000093D6
		// (set) Token: 0x06000271 RID: 625 RVA: 0x0000B1E3 File Offset: 0x000093E3
		public object ItemsSource
		{
			get
			{
				return base.GetValue(HamburgerMenu.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemsSourceProperty, value);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000272 RID: 626 RVA: 0x0000B1F1 File Offset: 0x000093F1
		// (set) Token: 0x06000273 RID: 627 RVA: 0x0000B203 File Offset: 0x00009403
		public Style ItemContainerStyle
		{
			get
			{
				return (Style)base.GetValue(HamburgerMenu.ItemContainerStyleProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemContainerStyleProperty, value);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0000B211 File Offset: 0x00009411
		// (set) Token: 0x06000275 RID: 629 RVA: 0x0000B223 File Offset: 0x00009423
		public DataTemplate ItemTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(HamburgerMenu.ItemTemplateProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemTemplateProperty, value);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0000B231 File Offset: 0x00009431
		// (set) Token: 0x06000277 RID: 631 RVA: 0x0000B243 File Offset: 0x00009443
		public DataTemplateSelector ItemTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(HamburgerMenu.ItemTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemTemplateSelectorProperty, value);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000B251 File Offset: 0x00009451
		public ItemCollection Items
		{
			get
			{
				if (this._buttonsListView == null)
				{
					throw new Exception("ButtonsListView is not defined yet. Please use ItemsSource instead.");
				}
				return this._buttonsListView.Items;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000B271 File Offset: 0x00009471
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0000B27E File Offset: 0x0000947E
		public object SelectedItem
		{
			get
			{
				return base.GetValue(HamburgerMenu.SelectedItemProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.SelectedItemProperty, value);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0000B28C File Offset: 0x0000948C
		// (set) Token: 0x0600027C RID: 636 RVA: 0x0000B29E File Offset: 0x0000949E
		public int SelectedIndex
		{
			get
			{
				return (int)base.GetValue(HamburgerMenu.SelectedIndexProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.SelectedIndexProperty, value);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600027D RID: 637 RVA: 0x0000B2B1 File Offset: 0x000094B1
		// (set) Token: 0x0600027E RID: 638 RVA: 0x0000B2C3 File Offset: 0x000094C3
		public TransitionType ContentTransition
		{
			get
			{
				return (TransitionType)base.GetValue(HamburgerMenu.ContentTransitionProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ContentTransitionProperty, value);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000B2D6 File Offset: 0x000094D6
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000B2E8 File Offset: 0x000094E8
		public ICommand ItemCommand
		{
			get
			{
				return (ICommand)base.GetValue(HamburgerMenu.ItemCommandProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemCommandProperty, value);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000B2F6 File Offset: 0x000094F6
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000B303 File Offset: 0x00009503
		public object ItemCommandParameter
		{
			get
			{
				return base.GetValue(HamburgerMenu.ItemCommandParameterProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ItemCommandParameterProperty, value);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000B311 File Offset: 0x00009511
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000B323 File Offset: 0x00009523
		public bool VerticalScrollBarOnLeftSide
		{
			get
			{
				return (bool)base.GetValue(HamburgerMenu.VerticalScrollBarOnLeftSideProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.VerticalScrollBarOnLeftSideProperty, value);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000B336 File Offset: 0x00009536
		// (set) Token: 0x06000286 RID: 646 RVA: 0x0000B348 File Offset: 0x00009548
		public bool ShowSelectionIndicator
		{
			get
			{
				return (bool)base.GetValue(HamburgerMenu.ShowSelectionIndicatorProperty);
			}
			set
			{
				base.SetValue(HamburgerMenu.ShowSelectionIndicatorProperty, value);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000287 RID: 647 RVA: 0x0000B35B File Offset: 0x0000955B
		// (set) Token: 0x06000288 RID: 648 RVA: 0x0000B36D File Offset: 0x0000956D
		public Style ItemFocusVisualStyle
		{
			get
			{
				return (Style)base.GetValue(HamburgerMenu.ItemFocusVisualStyleProperty);
			}
			private set
			{
				base.SetValue(HamburgerMenu.ItemFocusVisualStylePropertyKey, value);
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000B37C File Offset: 0x0000957C
		public void RaiseItemCommand()
		{
			ICommand itemCommand = this.ItemCommand;
			object parameter = this.ItemCommandParameter ?? this;
			if (itemCommand != null && itemCommand.CanExecute(parameter))
			{
				itemCommand.Execute(parameter);
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000B3B0 File Offset: 0x000095B0
		private void ChangeItemFocusVisualStyle()
		{
			this._defaultItemFocusVisualTemplate = (this._defaultItemFocusVisualTemplate ?? (base.TryFindResource("HamburgerMenuItemFocusVisualTemplate") as ControlTemplate));
			if (this._defaultItemFocusVisualTemplate != null)
			{
				Style style = new Style(typeof(Control));
				style.Setters.Add(new Setter(Control.TemplateProperty, this._defaultItemFocusVisualTemplate));
				style.Setters.Add(new Setter(FrameworkElement.WidthProperty, this.IsPaneOpen ? this.OpenPaneLength : this.CompactPaneLength));
				style.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left));
				style.Seal();
				base.SetValue(HamburgerMenu.ItemFocusVisualStylePropertyKey, style);
			}
		}

		// Token: 0x040000CF RID: 207
		private Button _hamburgerButton;

		// Token: 0x040000D0 RID: 208
		private ListBox _buttonsListView;

		// Token: 0x040000D1 RID: 209
		private ListBox _optionsListView;

		// Token: 0x040000D5 RID: 213
		public static readonly DependencyProperty HamburgerWidthProperty = DependencyProperty.Register("HamburgerWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata(48.0));

		// Token: 0x040000D6 RID: 214
		public static readonly DependencyProperty HamburgerHeightProperty = DependencyProperty.Register("HamburgerHeight", typeof(double), typeof(HamburgerMenu), new PropertyMetadata(48.0));

		// Token: 0x040000D7 RID: 215
		public static readonly DependencyProperty HamburgerMarginProperty = DependencyProperty.Register("HamburgerMargin", typeof(Thickness), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000D8 RID: 216
		public static readonly DependencyProperty HamburgerVisibilityProperty = DependencyProperty.Register("HamburgerVisibility", typeof(Visibility), typeof(HamburgerMenu), new PropertyMetadata(Visibility.Visible));

		// Token: 0x040000D9 RID: 217
		public static readonly DependencyProperty HamburgerMenuTemplateProperty = DependencyProperty.Register("HamburgerMenuTemplate", typeof(DataTemplate), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DA RID: 218
		public static readonly DependencyProperty HamburgerMenuHeaderTemplateProperty = DependencyProperty.Register("HamburgerMenuHeaderTemplate", typeof(DataTemplate), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DB RID: 219
		public static readonly DependencyProperty OptionsItemsSourceProperty = DependencyProperty.Register("OptionsItemsSource", typeof(object), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DC RID: 220
		public static readonly DependencyProperty OptionsItemContainerStyleProperty = DependencyProperty.Register("OptionsItemContainerStyle", typeof(Style), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DD RID: 221
		public static readonly DependencyProperty OptionsItemTemplateProperty = DependencyProperty.Register("OptionsItemTemplate", typeof(DataTemplate), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DE RID: 222
		public static readonly DependencyProperty OptionsItemTemplateSelectorProperty = DependencyProperty.Register("OptionsItemTemplateSelector", typeof(DataTemplateSelector), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000DF RID: 223
		public static readonly DependencyProperty OptionsVisibilityProperty = DependencyProperty.Register("OptionsVisibility", typeof(Visibility), typeof(HamburgerMenu), new PropertyMetadata(Visibility.Visible));

		// Token: 0x040000E0 RID: 224
		public static readonly DependencyProperty SelectedOptionsItemProperty = DependencyProperty.Register("SelectedOptionsItem", typeof(object), typeof(HamburgerMenu), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040000E1 RID: 225
		public static readonly DependencyProperty SelectedOptionsIndexProperty = DependencyProperty.Register("SelectedOptionsIndex", typeof(int), typeof(HamburgerMenu), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal));

		// Token: 0x040000E2 RID: 226
		public static readonly DependencyProperty OptionsItemCommandProperty = DependencyProperty.Register("OptionsItemCommand", typeof(ICommand), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000E3 RID: 227
		public static readonly DependencyProperty OptionsItemCommandParameterProperty = DependencyProperty.Register("OptionsItemCommandParameter", typeof(object), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000E4 RID: 228
		private ControlTemplate _defaultItemFocusVisualTemplate;

		// Token: 0x040000E5 RID: 229
		public static readonly DependencyProperty OpenPaneLengthProperty = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(HamburgerMenu), new PropertyMetadata(240.0, new PropertyChangedCallback(HamburgerMenu.OpenPaneLengthPropertyChangedCallback)));

		// Token: 0x040000E6 RID: 230
		public static readonly DependencyProperty PanePlacementProperty = DependencyProperty.Register("PanePlacement", typeof(SplitViewPanePlacement), typeof(HamburgerMenu), new PropertyMetadata(SplitViewPanePlacement.Left));

		// Token: 0x040000E7 RID: 231
		public static readonly DependencyProperty DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(SplitViewDisplayMode), typeof(HamburgerMenu), new PropertyMetadata(SplitViewDisplayMode.CompactInline));

		// Token: 0x040000E8 RID: 232
		public static readonly DependencyProperty CompactPaneLengthProperty = DependencyProperty.Register("CompactPaneLength", typeof(double), typeof(HamburgerMenu), new PropertyMetadata(48.0, new PropertyChangedCallback(HamburgerMenu.CompactPaneLengthPropertyChangedCallback)));

		// Token: 0x040000E9 RID: 233
		public static readonly DependencyProperty PaneBackgroundProperty = DependencyProperty.Register("PaneBackground", typeof(Brush), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000EA RID: 234
		public static readonly DependencyProperty PaneForegroundProperty = DependencyProperty.Register("PaneForeground", typeof(Brush), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000EB RID: 235
		public static readonly DependencyProperty IsPaneOpenProperty = DependencyProperty.Register("IsPaneOpen", typeof(bool), typeof(HamburgerMenu), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(HamburgerMenu.IsPaneOpenPropertyChangedCallback)));

		// Token: 0x040000EC RID: 236
		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(object), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000ED RID: 237
		public static readonly DependencyProperty ItemContainerStyleProperty = DependencyProperty.Register("ItemContainerStyle", typeof(Style), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000EE RID: 238
		public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000EF RID: 239
		public static readonly DependencyProperty ItemTemplateSelectorProperty = DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000F0 RID: 240
		public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(HamburgerMenu), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

		// Token: 0x040000F1 RID: 241
		public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex", typeof(int), typeof(HamburgerMenu), new FrameworkPropertyMetadata(-1, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal));

		// Token: 0x040000F2 RID: 242
		public static readonly DependencyProperty ContentTransitionProperty = DependencyProperty.Register("ContentTransition", typeof(TransitionType), typeof(HamburgerMenu), new FrameworkPropertyMetadata(TransitionType.Normal));

		// Token: 0x040000F3 RID: 243
		public static readonly DependencyProperty ItemCommandProperty = DependencyProperty.Register("ItemCommand", typeof(ICommand), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000F4 RID: 244
		public static readonly DependencyProperty ItemCommandParameterProperty = DependencyProperty.Register("ItemCommandParameter", typeof(object), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000F5 RID: 245
		public static readonly DependencyProperty VerticalScrollBarOnLeftSideProperty = DependencyProperty.Register("VerticalScrollBarOnLeftSide", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(false));

		// Token: 0x040000F6 RID: 246
		public static readonly DependencyProperty ShowSelectionIndicatorProperty = DependencyProperty.Register("ShowSelectionIndicator", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(false));

		// Token: 0x040000F7 RID: 247
		public static readonly DependencyPropertyKey ItemFocusVisualStylePropertyKey = DependencyProperty.RegisterReadOnly("ItemFocusVisualStyle", typeof(Style), typeof(HamburgerMenu), new PropertyMetadata(null));

		// Token: 0x040000F8 RID: 248
		public static readonly DependencyProperty ItemFocusVisualStyleProperty = HamburgerMenu.ItemFocusVisualStylePropertyKey.DependencyProperty;
	}
}
