using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000030 RID: 48
	[TemplatePart(Name = "PART_Presenter", Type = typeof(TransitioningContentControl))]
	[TemplatePart(Name = "PART_BackButton", Type = typeof(Button))]
	[TemplatePart(Name = "PART_ForwardButton", Type = typeof(Button))]
	[TemplatePart(Name = "PART_UpButton", Type = typeof(Button))]
	[TemplatePart(Name = "PART_DownButton", Type = typeof(Button))]
	[TemplatePart(Name = "PART_BannerGrid", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_BannerLabel", Type = typeof(Label))]
	public class FlipView : Selector
	{
		// Token: 0x06000165 RID: 357 RVA: 0x00007020 File Offset: 0x00005220
		static FlipView()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipView), new FrameworkPropertyMetadata(typeof(FlipView)));
			PropertyMetadata previousSelectedIndexPropertyMetadata = Selector.SelectedIndexProperty.GetMetadata(typeof(FlipView));
			Selector.SelectedIndexProperty.OverrideMetadata(typeof(FlipView), new FrameworkPropertyMetadata
			{
				CoerceValueCallback = delegate(DependencyObject d, object value)
				{
					if (previousSelectedIndexPropertyMetadata.CoerceValueCallback != null)
					{
						Delegate[] invocationList = previousSelectedIndexPropertyMetadata.CoerceValueCallback.GetInvocationList();
						for (int i = 0; i < invocationList.Length; i++)
						{
							value = ((CoerceValueCallback)invocationList[i])(d, value);
						}
					}
					return FlipView.CoerceSelectedIndexProperty(d, value);
				}
			});
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000735C File Offset: 0x0000555C
		public FlipView()
		{
			base.Loaded += this.FlipViewLoaded;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00007380 File Offset: 0x00005580
		private static object CoerceSelectedIndexProperty(DependencyObject d, object value)
		{
			FlipView flipView = d as FlipView;
			if (flipView != null && flipView.allowSelectedIndexChangedCallback)
			{
				flipView.ComputeTransition(flipView.SelectedIndex, (value as int?) ?? flipView.SelectedIndex);
			}
			return value;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000073D0 File Offset: 0x000055D0
		private void ComputeTransition(int fromIndex, int toIndex)
		{
			if (this.presenter != null)
			{
				if (fromIndex < toIndex)
				{
					this.presenter.Transition = ((this.Orientation == Orientation.Horizontal) ? this.LeftTransition : this.DownTransition);
					return;
				}
				if (fromIndex > toIndex)
				{
					this.presenter.Transition = ((this.Orientation == Orientation.Horizontal) ? this.RightTransition : this.UpTransition);
					return;
				}
				this.presenter.Transition = TransitionType.Default;
			}
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000743D File Offset: 0x0000563D
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is FlipViewItem;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x00007448 File Offset: 0x00005648
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new FlipViewItem
			{
				HorizontalAlignment = HorizontalAlignment.Stretch
			};
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00007456 File Offset: 0x00005656
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			if (element != item)
			{
				element.SetValue(FrameworkElement.DataContextProperty, item);
			}
			base.PrepareContainerForItemOverride(element, item);
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00007470 File Offset: 0x00005670
		private void GetNavigationButtons(out Button prevButton, out Button nextButton, out IEnumerable<Button> inactiveButtons)
		{
			if (this.Orientation == Orientation.Horizontal)
			{
				prevButton = this.backButton;
				nextButton = this.forwardButton;
				inactiveButtons = new Button[]
				{
					this.upButton,
					this.downButton
				};
				return;
			}
			prevButton = this.upButton;
			nextButton = this.downButton;
			inactiveButtons = new Button[]
			{
				this.backButton,
				this.forwardButton
			};
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000074DC File Offset: 0x000056DC
		private void ApplyToNavigationButtons(Action<Button> prevButtonApply, Action<Button> nextButtonApply, Action<Button> inactiveButtonsApply)
		{
			if (prevButtonApply == null)
			{
				throw new ArgumentNullException("prevButtonApply");
			}
			if (nextButtonApply == null)
			{
				throw new ArgumentNullException("nextButtonApply");
			}
			if (inactiveButtonsApply == null)
			{
				throw new ArgumentNullException("inactiveButtonsApply");
			}
			Button button = null;
			Button button2 = null;
			IEnumerable<Button> enumerable = null;
			this.GetNavigationButtons(out button, out button2, out enumerable);
			foreach (Button button3 in enumerable)
			{
				if (button3 != null)
				{
					inactiveButtonsApply(button3);
				}
			}
			if (button != null)
			{
				prevButtonApply(button);
			}
			if (button2 != null)
			{
				nextButtonApply(button2);
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000757C File Offset: 0x0000577C
		private void DetectControlButtonsStatus(Visibility activeButtonsVisibility = Visibility.Visible)
		{
			if (!this.IsNavigationEnabled)
			{
				activeButtonsVisibility = Visibility.Hidden;
			}
			this.ApplyToNavigationButtons(delegate(Button prev)
			{
				prev.Visibility = ((this.CircularNavigation || (this.Items.Count > 0 && this.SelectedIndex > 0)) ? activeButtonsVisibility : Visibility.Hidden);
			}, delegate(Button next)
			{
				next.Visibility = ((this.CircularNavigation || (this.Items.Count > 0 && this.SelectedIndex < this.Items.Count - 1)) ? activeButtonsVisibility : Visibility.Hidden);
			}, delegate(Button inactive)
			{
				inactive.Visibility = Visibility.Hidden;
			});
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000075EC File Offset: 0x000057EC
		private void FlipViewLoaded(object sender, RoutedEventArgs e)
		{
			if (this.backButton == null || this.forwardButton == null || this.upButton == null || this.downButton == null)
			{
				base.ApplyTemplate();
			}
			if (this.loaded)
			{
				return;
			}
			base.Unloaded += this.FlipViewUnloaded;
			if (base.SelectedIndex < 0)
			{
				base.SelectedIndex = 0;
			}
			this.DetectControlButtonsStatus(Visibility.Visible);
			this.ShowBanner();
			this.loaded = true;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000765F File Offset: 0x0000585F
		private void FlipViewUnloaded(object sender, RoutedEventArgs e)
		{
			base.Unloaded -= this.FlipViewUnloaded;
			if (this.hideControlStoryboard != null && this.hideControlStoryboardCompletedHandler != null)
			{
				this.hideControlStoryboard.Completed -= this.hideControlStoryboardCompletedHandler;
			}
			this.loaded = false;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000769B File Offset: 0x0000589B
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);
			this.DetectControlButtonsStatus(Visibility.Visible);
		}

		// Token: 0x06000172 RID: 370 RVA: 0x000076AC File Offset: 0x000058AC
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			bool flag = this.Orientation == Orientation.Horizontal;
			bool flag2 = this.Orientation == Orientation.Vertical;
			bool flag3 = (e.Key == Key.Left && flag && this.backButton != null && this.backButton.Visibility == Visibility.Visible && this.backButton.IsEnabled) || (e.Key == Key.Up && flag2 && this.upButton != null && this.upButton.Visibility == Visibility.Visible && this.upButton.IsEnabled);
			bool flag4 = (e.Key == Key.Right && flag && this.forwardButton != null && this.forwardButton.Visibility == Visibility.Visible && this.forwardButton.IsEnabled) || (e.Key == Key.Down && flag2 && this.downButton != null && this.downButton.Visibility == Visibility.Visible && this.downButton.IsEnabled);
			if (flag3)
			{
				this.GoBack();
				e.Handled = true;
				base.Focus();
				return;
			}
			if (flag4)
			{
				this.GoForward();
				e.Handled = true;
				base.Focus();
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x000077CB File Offset: 0x000059CB
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			base.OnMouseDown(e);
			base.Focus();
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000077DC File Offset: 0x000059DC
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.showBannerStoryboard = ((Storyboard)base.Template.Resources["ShowBannerStoryboard"]).Clone();
			this.hideBannerStoryboard = ((Storyboard)base.Template.Resources["HideBannerStoryboard"]).Clone();
			this.showControlStoryboard = ((Storyboard)base.Template.Resources["ShowControlStoryboard"]).Clone();
			this.hideControlStoryboard = ((Storyboard)base.Template.Resources["HideControlStoryboard"]).Clone();
			this.presenter = (base.GetTemplateChild("PART_Presenter") as TransitioningContentControl);
			if (this.forwardButton != null)
			{
				this.forwardButton.Click -= this.NextButtonClick;
			}
			if (this.backButton != null)
			{
				this.backButton.Click -= this.PrevButtonClick;
			}
			if (this.upButton != null)
			{
				this.upButton.Click -= this.PrevButtonClick;
			}
			if (this.downButton != null)
			{
				this.downButton.Click -= this.NextButtonClick;
			}
			this.forwardButton = (base.GetTemplateChild("PART_ForwardButton") as Button);
			this.backButton = (base.GetTemplateChild("PART_BackButton") as Button);
			this.upButton = (base.GetTemplateChild("PART_UpButton") as Button);
			this.downButton = (base.GetTemplateChild("PART_DownButton") as Button);
			this.bannerGrid = (base.GetTemplateChild("PART_BannerGrid") as Grid);
			this.bannerLabel = (base.GetTemplateChild("PART_BannerLabel") as Label);
			if (this.forwardButton != null)
			{
				this.forwardButton.Click += this.NextButtonClick;
			}
			if (this.backButton != null)
			{
				this.backButton.Click += this.PrevButtonClick;
			}
			if (this.upButton != null)
			{
				this.upButton.Click += this.PrevButtonClick;
			}
			if (this.downButton != null)
			{
				this.downButton.Click += this.NextButtonClick;
			}
			if (this.bannerLabel != null)
			{
				this.bannerLabel.Opacity = (this.IsBannerEnabled ? 1.0 : 0.0);
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00007A44 File Offset: 0x00005C44
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			this.DetectControlButtonsStatus(Visibility.Visible);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00007A54 File Offset: 0x00005C54
		private void NextButtonClick(object sender, RoutedEventArgs e)
		{
			this.GoForward();
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00007A5C File Offset: 0x00005C5C
		private void PrevButtonClick(object sender, RoutedEventArgs e)
		{
			this.GoBack();
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00007A64 File Offset: 0x00005C64
		public void GoBack()
		{
			this.allowSelectedIndexChangedCallback = false;
			this.presenter.Transition = ((this.Orientation == Orientation.Horizontal) ? this.RightTransition : this.UpTransition);
			if (base.SelectedIndex > 0)
			{
				int selectedIndex = base.SelectedIndex;
				base.SelectedIndex = selectedIndex - 1;
			}
			else if (this.CircularNavigation)
			{
				base.SelectedIndex = base.Items.Count - 1;
			}
			this.allowSelectedIndexChangedCallback = true;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00007AD8 File Offset: 0x00005CD8
		public void GoForward()
		{
			this.allowSelectedIndexChangedCallback = false;
			this.presenter.Transition = ((this.Orientation == Orientation.Horizontal) ? this.LeftTransition : this.DownTransition);
			if (base.SelectedIndex < base.Items.Count - 1)
			{
				int selectedIndex = base.SelectedIndex;
				base.SelectedIndex = selectedIndex + 1;
			}
			else if (this.CircularNavigation)
			{
				base.SelectedIndex = 0;
			}
			this.allowSelectedIndexChangedCallback = true;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x00007B4A File Offset: 0x00005D4A
		public void ShowControlButtons()
		{
			FlipView.ExecuteWhenLoaded(this, delegate
			{
				this.DetectControlButtonsStatus(Visibility.Visible);
			});
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00007B5E File Offset: 0x00005D5E
		public void HideControlButtons()
		{
			FlipView.ExecuteWhenLoaded(this, delegate
			{
				this.DetectControlButtonsStatus(Visibility.Hidden);
			});
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00007B72 File Offset: 0x00005D72
		private void ShowBanner()
		{
			if (this.IsBannerEnabled)
			{
				Grid grid = this.bannerGrid;
				if (grid == null)
				{
					return;
				}
				grid.BeginStoryboard(this.showBannerStoryboard);
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00007B92 File Offset: 0x00005D92
		private void HideBanner()
		{
			if (base.ActualHeight > 0.0)
			{
				Label label = this.bannerLabel;
				if (label != null)
				{
					label.BeginStoryboard(this.hideControlStoryboard);
				}
				Grid grid = this.bannerGrid;
				if (grid == null)
				{
					return;
				}
				grid.BeginStoryboard(this.hideBannerStoryboard);
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00007BD4 File Offset: 0x00005DD4
		private static void ExecuteWhenLoaded(FlipView flipview, Action body)
		{
			FlipView.<>c__DisplayClass46_0 CS$<>8__locals1 = new FlipView.<>c__DisplayClass46_0();
			CS$<>8__locals1.flipview = flipview;
			CS$<>8__locals1.body = body;
			if (CS$<>8__locals1.flipview.IsLoaded)
			{
				Dispatcher.CurrentDispatcher.Invoke(CS$<>8__locals1.body);
				return;
			}
			RoutedEventHandler handler = null;
			handler = delegate(object o, RoutedEventArgs a)
			{
				CS$<>8__locals1.flipview.Loaded -= handler;
				Dispatcher.CurrentDispatcher.Invoke(CS$<>8__locals1.body);
			};
			CS$<>8__locals1.flipview.Loaded += handler;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00007C4F File Offset: 0x00005E4F
		// (set) Token: 0x06000180 RID: 384 RVA: 0x00007C61 File Offset: 0x00005E61
		public TransitionType UpTransition
		{
			get
			{
				return (TransitionType)base.GetValue(FlipView.UpTransitionProperty);
			}
			set
			{
				base.SetValue(FlipView.UpTransitionProperty, value);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00007C74 File Offset: 0x00005E74
		// (set) Token: 0x06000182 RID: 386 RVA: 0x00007C86 File Offset: 0x00005E86
		public TransitionType DownTransition
		{
			get
			{
				return (TransitionType)base.GetValue(FlipView.DownTransitionProperty);
			}
			set
			{
				base.SetValue(FlipView.DownTransitionProperty, value);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000183 RID: 387 RVA: 0x00007C99 File Offset: 0x00005E99
		// (set) Token: 0x06000184 RID: 388 RVA: 0x00007CAB File Offset: 0x00005EAB
		public TransitionType LeftTransition
		{
			get
			{
				return (TransitionType)base.GetValue(FlipView.LeftTransitionProperty);
			}
			set
			{
				base.SetValue(FlipView.LeftTransitionProperty, value);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000185 RID: 389 RVA: 0x00007CBE File Offset: 0x00005EBE
		// (set) Token: 0x06000186 RID: 390 RVA: 0x00007CD0 File Offset: 0x00005ED0
		public TransitionType RightTransition
		{
			get
			{
				return (TransitionType)base.GetValue(FlipView.RightTransitionProperty);
			}
			set
			{
				base.SetValue(FlipView.RightTransitionProperty, value);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00007CE3 File Offset: 0x00005EE3
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00007CF5 File Offset: 0x00005EF5
		[Obsolete("This property will be deleted in the next release. You should use now MouseHoverBorderEnabled instead.")]
		public bool MouseOverGlowEnabled
		{
			get
			{
				return (bool)base.GetValue(FlipView.MouseOverGlowEnabledProperty);
			}
			set
			{
				base.SetValue(FlipView.MouseOverGlowEnabledProperty, value);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00007D08 File Offset: 0x00005F08
		// (set) Token: 0x0600018A RID: 394 RVA: 0x00007D1A File Offset: 0x00005F1A
		public bool MouseHoverBorderEnabled
		{
			get
			{
				return (bool)base.GetValue(FlipView.MouseHoverBorderEnabledProperty);
			}
			set
			{
				base.SetValue(FlipView.MouseHoverBorderEnabledProperty, value);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00007D2D File Offset: 0x00005F2D
		// (set) Token: 0x0600018C RID: 396 RVA: 0x00007D3F File Offset: 0x00005F3F
		public Brush MouseHoverBorderBrush
		{
			get
			{
				return (Brush)base.GetValue(FlipView.MouseHoverBorderBrushProperty);
			}
			set
			{
				base.SetValue(FlipView.MouseHoverBorderBrushProperty, value);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00007D4D File Offset: 0x00005F4D
		// (set) Token: 0x0600018E RID: 398 RVA: 0x00007D5F File Offset: 0x00005F5F
		public Thickness MouseHoverBorderThickness
		{
			get
			{
				return (Thickness)base.GetValue(FlipView.MouseHoverBorderThicknessProperty);
			}
			set
			{
				base.SetValue(FlipView.MouseHoverBorderThicknessProperty, value);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00007D72 File Offset: 0x00005F72
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00007D84 File Offset: 0x00005F84
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(FlipView.OrientationProperty);
			}
			set
			{
				base.SetValue(FlipView.OrientationProperty, value);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000191 RID: 401 RVA: 0x00007D97 File Offset: 0x00005F97
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00007DA9 File Offset: 0x00005FA9
		public string BannerText
		{
			get
			{
				return (string)base.GetValue(FlipView.BannerTextProperty);
			}
			set
			{
				base.SetValue(FlipView.BannerTextProperty, value);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00007DB7 File Offset: 0x00005FB7
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00007DC9 File Offset: 0x00005FC9
		public bool IsBannerEnabled
		{
			get
			{
				return (bool)base.GetValue(FlipView.IsBannerEnabledProperty);
			}
			set
			{
				base.SetValue(FlipView.IsBannerEnabledProperty, value);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00007DDC File Offset: 0x00005FDC
		// (set) Token: 0x06000196 RID: 406 RVA: 0x00007DEE File Offset: 0x00005FEE
		public bool CircularNavigation
		{
			get
			{
				return (bool)base.GetValue(FlipView.CircularNavigationProperty);
			}
			set
			{
				base.SetValue(FlipView.CircularNavigationProperty, value);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00007E01 File Offset: 0x00006001
		// (set) Token: 0x06000198 RID: 408 RVA: 0x00007E13 File Offset: 0x00006013
		public bool IsNavigationEnabled
		{
			get
			{
				return (bool)base.GetValue(FlipView.IsNavigationEnabledProperty);
			}
			set
			{
				base.SetValue(FlipView.IsNavigationEnabledProperty, value);
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007E28 File Offset: 0x00006028
		private void ChangeBannerText(string value = null)
		{
			FlipView.<>c__DisplayClass99_0 CS$<>8__locals1 = new FlipView.<>c__DisplayClass99_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.value = value;
			if (!this.IsBannerEnabled)
			{
				FlipView.ExecuteWhenLoaded(this, delegate
				{
					CS$<>8__locals1.<>4__this.bannerLabel.Content = (CS$<>8__locals1.value ?? CS$<>8__locals1.<>4__this.BannerText);
				});
				return;
			}
			string newValue = CS$<>8__locals1.value ?? this.BannerText;
			if (newValue == null || this.hideControlStoryboard == null)
			{
				return;
			}
			if (this.hideControlStoryboardCompletedHandler != null)
			{
				this.hideControlStoryboard.Completed -= this.hideControlStoryboardCompletedHandler;
			}
			this.hideControlStoryboardCompletedHandler = delegate(object sender, EventArgs e)
			{
				try
				{
					CS$<>8__locals1.<>4__this.hideControlStoryboard.Completed -= CS$<>8__locals1.<>4__this.hideControlStoryboardCompletedHandler;
					CS$<>8__locals1.<>4__this.bannerLabel.Content = newValue;
					CS$<>8__locals1.<>4__this.bannerLabel.BeginStoryboard(CS$<>8__locals1.<>4__this.showControlStoryboard, HandoffBehavior.SnapshotAndReplace);
				}
				catch (Exception)
				{
				}
			};
			this.hideControlStoryboard.Completed += this.hideControlStoryboardCompletedHandler;
			this.bannerLabel.BeginStoryboard(this.hideControlStoryboard, HandoffBehavior.SnapshotAndReplace);
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00007EF0 File Offset: 0x000060F0
		private static void OnIsBannerEnabledPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FlipView flipview = (FlipView)d;
			if (!flipview.IsLoaded)
			{
				FlipView.ExecuteWhenLoaded(flipview, delegate
				{
					flipview.ApplyTemplate();
					if ((bool)e.NewValue)
					{
						flipview.ChangeBannerText(flipview.BannerText);
						flipview.ShowBanner();
						return;
					}
					flipview.HideBanner();
				});
				return;
			}
			if ((bool)e.NewValue)
			{
				flipview.ChangeBannerText(flipview.BannerText);
				flipview.ShowBanner();
				return;
			}
			flipview.HideBanner();
		}

		// Token: 0x04000065 RID: 101
		private const string PART_Presenter = "PART_Presenter";

		// Token: 0x04000066 RID: 102
		private const string PART_BackButton = "PART_BackButton";

		// Token: 0x04000067 RID: 103
		private const string PART_ForwardButton = "PART_ForwardButton";

		// Token: 0x04000068 RID: 104
		private const string PART_UpButton = "PART_UpButton";

		// Token: 0x04000069 RID: 105
		private const string PART_DownButton = "PART_DownButton";

		// Token: 0x0400006A RID: 106
		private const string PART_BannerGrid = "PART_BannerGrid";

		// Token: 0x0400006B RID: 107
		private const string PART_BannerLabel = "PART_BannerLabel";

		// Token: 0x0400006C RID: 108
		private TransitioningContentControl presenter;

		// Token: 0x0400006D RID: 109
		private Button backButton;

		// Token: 0x0400006E RID: 110
		private Button forwardButton;

		// Token: 0x0400006F RID: 111
		private Button upButton;

		// Token: 0x04000070 RID: 112
		private Button downButton;

		// Token: 0x04000071 RID: 113
		private Grid bannerGrid;

		// Token: 0x04000072 RID: 114
		private Label bannerLabel;

		// Token: 0x04000073 RID: 115
		private Storyboard showBannerStoryboard;

		// Token: 0x04000074 RID: 116
		private Storyboard hideBannerStoryboard;

		// Token: 0x04000075 RID: 117
		private Storyboard hideControlStoryboard;

		// Token: 0x04000076 RID: 118
		private Storyboard showControlStoryboard;

		// Token: 0x04000077 RID: 119
		private EventHandler hideControlStoryboardCompletedHandler;

		// Token: 0x04000078 RID: 120
		private bool loaded;

		// Token: 0x04000079 RID: 121
		private bool allowSelectedIndexChangedCallback = true;

		// Token: 0x0400007A RID: 122
		public static readonly DependencyProperty UpTransitionProperty = DependencyProperty.Register("UpTransition", typeof(TransitionType), typeof(FlipView), new PropertyMetadata(TransitionType.Up));

		// Token: 0x0400007B RID: 123
		public static readonly DependencyProperty DownTransitionProperty = DependencyProperty.Register("DownTransition", typeof(TransitionType), typeof(FlipView), new PropertyMetadata(TransitionType.Down));

		// Token: 0x0400007C RID: 124
		public static readonly DependencyProperty LeftTransitionProperty = DependencyProperty.Register("LeftTransition", typeof(TransitionType), typeof(FlipView), new PropertyMetadata(TransitionType.LeftReplace));

		// Token: 0x0400007D RID: 125
		public static readonly DependencyProperty RightTransitionProperty = DependencyProperty.Register("RightTransition", typeof(TransitionType), typeof(FlipView), new PropertyMetadata(TransitionType.RightReplace));

		// Token: 0x0400007E RID: 126
		[Obsolete("This property will be deleted in the next release. You should use now MouseHoverBorderEnabled instead.")]
		public static readonly DependencyProperty MouseOverGlowEnabledProperty = DependencyProperty.Register("MouseOverGlowEnabled", typeof(bool), typeof(FlipView), new PropertyMetadata(true, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((FlipView)o).SetCurrentValue(FlipView.MouseHoverBorderEnabledProperty, (bool)e.NewValue);
		}));

		// Token: 0x0400007F RID: 127
		public static readonly DependencyProperty MouseHoverBorderEnabledProperty = DependencyProperty.Register("MouseHoverBorderEnabled", typeof(bool), typeof(FlipView), new PropertyMetadata(true));

		// Token: 0x04000080 RID: 128
		public static readonly DependencyProperty MouseHoverBorderBrushProperty = DependencyProperty.Register("MouseHoverBorderBrush", typeof(Brush), typeof(FlipView), new PropertyMetadata(Brushes.LightGray));

		// Token: 0x04000081 RID: 129
		public static readonly DependencyProperty MouseHoverBorderThicknessProperty = DependencyProperty.Register("MouseHoverBorderThickness", typeof(Thickness), typeof(FlipView), new PropertyMetadata(new Thickness(4.0)));

		// Token: 0x04000082 RID: 130
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(FlipView), new PropertyMetadata(Orientation.Horizontal, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((FlipView)d).DetectControlButtonsStatus(Visibility.Visible);
		}));

		// Token: 0x04000083 RID: 131
		public static readonly DependencyProperty IsBannerEnabledProperty = DependencyProperty.Register("IsBannerEnabled", typeof(bool), typeof(FlipView), new UIPropertyMetadata(true, new PropertyChangedCallback(FlipView.OnIsBannerEnabledPropertyChangedCallback)));

		// Token: 0x04000084 RID: 132
		public static readonly DependencyProperty BannerTextProperty = DependencyProperty.Register("BannerText", typeof(string), typeof(FlipView), new FrameworkPropertyMetadata("Banner", FrameworkPropertyMetadataOptions.AffectsRender, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FlipView.ExecuteWhenLoaded((FlipView)d, delegate
			{
				((FlipView)d).ChangeBannerText((string)e.NewValue);
			});
		}));

		// Token: 0x04000085 RID: 133
		public static readonly DependencyProperty CircularNavigationProperty = DependencyProperty.Register("CircularNavigation", typeof(bool), typeof(FlipView), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((FlipView)d).DetectControlButtonsStatus(Visibility.Visible);
		}));

		// Token: 0x04000086 RID: 134
		public static readonly DependencyProperty IsNavigationEnabledProperty = DependencyProperty.Register("IsNavigationEnabled", typeof(bool), typeof(FlipView), new PropertyMetadata(true, delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((FlipView)d).DetectControlButtonsStatus(Visibility.Visible);
		}));
	}
}
