using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000092 RID: 146
	[TemplatePart(Name = "PART_BackgroundTranslate", Type = typeof(TranslateTransform))]
	[TemplatePart(Name = "PART_DraggingThumb", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_SwitchTrack", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_ThumbIndicator", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_ThumbTranslate", Type = typeof(TranslateTransform))]
	public class ToggleSwitchButton : ToggleButton
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00020185 File Offset: 0x0001E385
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00020197 File Offset: 0x0001E397
		[Obsolete("This property will be deleted in the next release. You should use OnSwitchBrush and OffSwitchBrush to change the switch's brushes.")]
		public Brush SwitchForeground
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitchButton.SwitchForegroundProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.SwitchForegroundProperty, value);
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x000201A5 File Offset: 0x0001E3A5
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x000201B7 File Offset: 0x0001E3B7
		public Brush OnSwitchBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitchButton.OnSwitchBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.OnSwitchBrushProperty, value);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x000201C5 File Offset: 0x0001E3C5
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x000201D7 File Offset: 0x0001E3D7
		public Brush OffSwitchBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitchButton.OffSwitchBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.OffSwitchBrushProperty, value);
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x000201E5 File Offset: 0x0001E3E5
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x000201F7 File Offset: 0x0001E3F7
		public Brush ThumbIndicatorBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitchButton.ThumbIndicatorBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.ThumbIndicatorBrushProperty, value);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00020205 File Offset: 0x0001E405
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x00020217 File Offset: 0x0001E417
		public Brush ThumbIndicatorDisabledBrush
		{
			get
			{
				return (Brush)base.GetValue(ToggleSwitchButton.ThumbIndicatorDisabledBrushProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.ThumbIndicatorDisabledBrushProperty, value);
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x00020225 File Offset: 0x0001E425
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x00020237 File Offset: 0x0001E437
		public double ThumbIndicatorWidth
		{
			get
			{
				return (double)base.GetValue(ToggleSwitchButton.ThumbIndicatorWidthProperty);
			}
			set
			{
				base.SetValue(ToggleSwitchButton.ThumbIndicatorWidthProperty, value);
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0002024C File Offset: 0x0001E44C
		static ToggleSwitchButton()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleSwitchButton), new FrameworkPropertyMetadata(typeof(ToggleSwitchButton)));
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0002037B File Offset: 0x0001E57B
		public ToggleSwitchButton()
		{
			this.isCheckedPropertyChangeNotifier = new PropertyChangeNotifier(this, ToggleButton.IsCheckedProperty);
			this.isCheckedPropertyChangeNotifier.ValueChanged += this.IsCheckedPropertyChangeNotifierValueChanged;
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x000203AB File Offset: 0x0001E5AB
		private void IsCheckedPropertyChangeNotifierValueChanged(object sender, EventArgs e)
		{
			this.UpdateThumb();
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x000203B4 File Offset: 0x0001E5B4
		private void UpdateThumb()
		{
			if (this._ThumbTranslate != null && this._SwitchTrack != null && this._ThumbIndicator != null)
			{
				double destination = base.IsChecked.GetValueOrDefault() ? (base.ActualWidth - (this._SwitchTrack.Margin.Left + this._SwitchTrack.Margin.Right + this._ThumbIndicator.ActualWidth + this._ThumbIndicator.Margin.Left + this._ThumbIndicator.Margin.Right)) : 0.0;
				this._thumbAnimation = new DoubleAnimation();
				this._thumbAnimation.To = new double?(destination);
				this._thumbAnimation.Duration = TimeSpan.FromMilliseconds(500.0);
				this._thumbAnimation.EasingFunction = new ExponentialEase
				{
					Exponent = 9.0
				};
				this._thumbAnimation.FillBehavior = FillBehavior.Stop;
				AnimationTimeline currentAnimation = this._thumbAnimation;
				this._thumbAnimation.Completed += delegate(object sender, EventArgs e)
				{
					if (this._thumbAnimation != null && currentAnimation == this._thumbAnimation)
					{
						this._ThumbTranslate.X = destination;
						this._thumbAnimation = null;
					}
				};
				this._ThumbTranslate.BeginAnimation(TranslateTransform.XProperty, this._thumbAnimation);
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x00020518 File Offset: 0x0001E718
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._BackgroundTranslate = (base.GetTemplateChild("PART_BackgroundTranslate") as TranslateTransform);
			this._DraggingThumb = (base.GetTemplateChild("PART_DraggingThumb") as Thumb);
			this._SwitchTrack = (base.GetTemplateChild("PART_SwitchTrack") as Grid);
			this._ThumbIndicator = (base.GetTemplateChild("PART_ThumbIndicator") as FrameworkElement);
			this._ThumbTranslate = (base.GetTemplateChild("PART_ThumbTranslate") as TranslateTransform);
			if (this._ThumbIndicator != null && this._ThumbTranslate != null && this._BackgroundTranslate != null)
			{
				Binding binding = new Binding("X");
				binding.Source = this._ThumbTranslate;
				BindingOperations.SetBinding(this._BackgroundTranslate, TranslateTransform.XProperty, binding);
			}
			if (this._DraggingThumb != null && this._ThumbIndicator != null && this._ThumbTranslate != null)
			{
				this._DraggingThumb.DragStarted -= this._DraggingThumb_DragStarted;
				this._DraggingThumb.DragDelta -= this._DraggingThumb_DragDelta;
				this._DraggingThumb.DragCompleted -= this._DraggingThumb_DragCompleted;
				this._DraggingThumb.DragStarted += this._DraggingThumb_DragStarted;
				this._DraggingThumb.DragDelta += this._DraggingThumb_DragDelta;
				this._DraggingThumb.DragCompleted += this._DraggingThumb_DragCompleted;
				if (this._SwitchTrack != null)
				{
					this._SwitchTrack.SizeChanged -= this._SwitchTrack_SizeChanged;
					this._SwitchTrack.SizeChanged += this._SwitchTrack_SizeChanged;
				}
			}
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x000206BB File Offset: 0x0001E8BB
		private void SetIsPressed(bool pressed)
		{
			typeof(ToggleButton).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(this, new object[]
			{
				pressed
			});
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x000206EC File Offset: 0x0001E8EC
		private void _DraggingThumb_DragStarted(object sender, DragStartedEventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed && !base.IsPressed)
			{
				this.SetIsPressed(true);
			}
			if (this._ThumbTranslate != null)
			{
				this._ThumbTranslate.BeginAnimation(TranslateTransform.XProperty, null);
				double x = base.IsChecked.GetValueOrDefault() ? (base.ActualWidth - (this._SwitchTrack.Margin.Left + this._SwitchTrack.Margin.Right + this._ThumbIndicator.ActualWidth + this._ThumbIndicator.Margin.Left + this._ThumbIndicator.Margin.Right)) : 0.0;
				this._ThumbTranslate.X = x;
				this._thumbAnimation = null;
			}
			this._lastDragPosition = new double?(this._ThumbTranslate.X);
			this._isDragging = false;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x000207DC File Offset: 0x0001E9DC
		private void _DraggingThumb_DragDelta(object sender, DragDeltaEventArgs e)
		{
			if (this._lastDragPosition != null)
			{
				if (Math.Abs(e.HorizontalChange) > 3.0)
				{
					this._isDragging = true;
				}
				if (this._SwitchTrack != null && this._ThumbIndicator != null)
				{
					double value = this._lastDragPosition.Value;
					this._ThumbTranslate.X = Math.Min(base.ActualWidth - (this._SwitchTrack.Margin.Left + this._SwitchTrack.Margin.Right + this._ThumbIndicator.ActualWidth + this._ThumbIndicator.Margin.Left + this._ThumbIndicator.Margin.Right), Math.Max(0.0, value + e.HorizontalChange));
				}
			}
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x000208C0 File Offset: 0x0001EAC0
		private void _DraggingThumb_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			this.SetIsPressed(false);
			this._lastDragPosition = null;
			if (!this._isDragging)
			{
				this.OnClick();
				return;
			}
			if (this._ThumbTranslate != null && this._SwitchTrack != null)
			{
				if (!base.IsChecked.GetValueOrDefault() && this._ThumbTranslate.X + 6.5 >= this._SwitchTrack.ActualWidth / 2.0)
				{
					this.OnClick();
					return;
				}
				if (base.IsChecked.GetValueOrDefault() && this._ThumbTranslate.X + 6.5 <= this._SwitchTrack.ActualWidth / 2.0)
				{
					this.OnClick();
					return;
				}
				this.UpdateThumb();
			}
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00020994 File Offset: 0x0001EB94
		private void _SwitchTrack_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this._ThumbTranslate != null && this._SwitchTrack != null && this._ThumbIndicator != null)
			{
				double x = base.IsChecked.GetValueOrDefault() ? (base.ActualWidth - (this._SwitchTrack.Margin.Left + this._SwitchTrack.Margin.Right + this._ThumbIndicator.ActualWidth + this._ThumbIndicator.Margin.Left + this._ThumbIndicator.Margin.Right)) : 0.0;
				this._ThumbTranslate.X = x;
			}
		}

		// Token: 0x04000356 RID: 854
		private const string PART_BackgroundTranslate = "PART_BackgroundTranslate";

		// Token: 0x04000357 RID: 855
		private const string PART_DraggingThumb = "PART_DraggingThumb";

		// Token: 0x04000358 RID: 856
		private const string PART_SwitchTrack = "PART_SwitchTrack";

		// Token: 0x04000359 RID: 857
		private const string PART_ThumbIndicator = "PART_ThumbIndicator";

		// Token: 0x0400035A RID: 858
		private const string PART_ThumbTranslate = "PART_ThumbTranslate";

		// Token: 0x0400035B RID: 859
		private TranslateTransform _BackgroundTranslate;

		// Token: 0x0400035C RID: 860
		private Thumb _DraggingThumb;

		// Token: 0x0400035D RID: 861
		private Grid _SwitchTrack;

		// Token: 0x0400035E RID: 862
		private FrameworkElement _ThumbIndicator;

		// Token: 0x0400035F RID: 863
		private TranslateTransform _ThumbTranslate;

		// Token: 0x04000360 RID: 864
		private readonly PropertyChangeNotifier isCheckedPropertyChangeNotifier;

		// Token: 0x04000361 RID: 865
		[Obsolete("This property will be deleted in the next release. You should use OnSwitchBrush and OffSwitchBrush to change the switch's brushes.")]
		public static readonly DependencyProperty SwitchForegroundProperty = DependencyProperty.Register("SwitchForeground", typeof(Brush), typeof(ToggleSwitchButton), new PropertyMetadata(null, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			((ToggleSwitchButton)o).SetCurrentValue(ToggleSwitchButton.OnSwitchBrushProperty, e.NewValue as Brush);
		}));

		// Token: 0x04000362 RID: 866
		public static readonly DependencyProperty OnSwitchBrushProperty = DependencyProperty.Register("OnSwitchBrush", typeof(Brush), typeof(ToggleSwitchButton), null);

		// Token: 0x04000363 RID: 867
		public static readonly DependencyProperty OffSwitchBrushProperty = DependencyProperty.Register("OffSwitchBrush", typeof(Brush), typeof(ToggleSwitchButton), null);

		// Token: 0x04000364 RID: 868
		public static readonly DependencyProperty ThumbIndicatorBrushProperty = DependencyProperty.Register("ThumbIndicatorBrush", typeof(Brush), typeof(ToggleSwitchButton), null);

		// Token: 0x04000365 RID: 869
		public static readonly DependencyProperty ThumbIndicatorDisabledBrushProperty = DependencyProperty.Register("ThumbIndicatorDisabledBrush", typeof(Brush), typeof(ToggleSwitchButton), null);

		// Token: 0x04000366 RID: 870
		public static readonly DependencyProperty ThumbIndicatorWidthProperty = DependencyProperty.Register("ThumbIndicatorWidth", typeof(double), typeof(ToggleSwitchButton), new PropertyMetadata(13.0));

		// Token: 0x04000367 RID: 871
		private DoubleAnimation _thumbAnimation;

		// Token: 0x04000368 RID: 872
		private double? _lastDragPosition;

		// Token: 0x04000369 RID: 873
		private bool _isDragging;
	}
}
