using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000050 RID: 80
	public class SliderHelper
	{
		// Token: 0x06000340 RID: 832 RVA: 0x0000D483 File Offset: 0x0000B683
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetThumbFillBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.ThumbFillBrushProperty);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000D495 File Offset: 0x0000B695
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetThumbFillBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.ThumbFillBrushProperty, value);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000D4A3 File Offset: 0x0000B6A3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetThumbFillHoverBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.ThumbFillHoverBrushProperty);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000D4B5 File Offset: 0x0000B6B5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetThumbFillHoverBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.ThumbFillHoverBrushProperty, value);
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000D4C3 File Offset: 0x0000B6C3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetThumbFillPressedBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.ThumbFillPressedBrushProperty);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000D4D5 File Offset: 0x0000B6D5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetThumbFillPressedBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.ThumbFillPressedBrushProperty, value);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000D4E3 File Offset: 0x0000B6E3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetThumbFillDisabledBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.ThumbFillDisabledBrushProperty);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000D4F5 File Offset: 0x0000B6F5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetThumbFillDisabledBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.ThumbFillDisabledBrushProperty, value);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000D503 File Offset: 0x0000B703
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackFillBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackFillBrushProperty);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000D515 File Offset: 0x0000B715
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackFillBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackFillBrushProperty, value);
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000D523 File Offset: 0x0000B723
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackFillHoverBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackFillHoverBrushProperty);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000D535 File Offset: 0x0000B735
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackFillHoverBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackFillHoverBrushProperty, value);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000D543 File Offset: 0x0000B743
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackFillPressedBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackFillPressedBrushProperty);
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000D555 File Offset: 0x0000B755
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackFillPressedBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackFillPressedBrushProperty, value);
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000D563 File Offset: 0x0000B763
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackFillDisabledBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackFillDisabledBrushProperty);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000D575 File Offset: 0x0000B775
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackFillDisabledBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackFillDisabledBrushProperty, value);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000D583 File Offset: 0x0000B783
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackValueFillBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackValueFillBrushProperty);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000D595 File Offset: 0x0000B795
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackValueFillBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackValueFillBrushProperty, value);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000D5A3 File Offset: 0x0000B7A3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackValueFillHoverBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackValueFillHoverBrushProperty);
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000D5B5 File Offset: 0x0000B7B5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackValueFillHoverBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackValueFillHoverBrushProperty, value);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000D5C3 File Offset: 0x0000B7C3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackValueFillPressedBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackValueFillPressedBrushProperty);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000D5D5 File Offset: 0x0000B7D5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackValueFillPressedBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackValueFillPressedBrushProperty, value);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000D5E3 File Offset: 0x0000B7E3
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static Brush GetTrackValueFillDisabledBrush(UIElement element)
		{
			return (Brush)element.GetValue(SliderHelper.TrackValueFillDisabledBrushProperty);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000D5F5 File Offset: 0x0000B7F5
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetTrackValueFillDisabledBrush(UIElement element, Brush value)
		{
			element.SetValue(SliderHelper.TrackValueFillDisabledBrushProperty, value);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000D603 File Offset: 0x0000B803
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static MouseWheelChange GetChangeValueBy(UIElement element)
		{
			return (MouseWheelChange)element.GetValue(SliderHelper.ChangeValueByProperty);
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000D615 File Offset: 0x0000B815
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetChangeValueBy(UIElement element, MouseWheelChange value)
		{
			element.SetValue(SliderHelper.ChangeValueByProperty, value);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000D628 File Offset: 0x0000B828
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static MouseWheelState GetEnableMouseWheel(UIElement element)
		{
			return (MouseWheelState)element.GetValue(SliderHelper.EnableMouseWheelProperty);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000D63A File Offset: 0x0000B83A
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(Slider))]
		[AttachedPropertyBrowsableForType(typeof(RangeSlider))]
		public static void SetEnableMouseWheel(UIElement element, MouseWheelState value)
		{
			element.SetValue(SliderHelper.EnableMouseWheelProperty, value);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000D650 File Offset: 0x0000B850
		private static void OnEnableMouseWheelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue != e.OldValue)
			{
				if (d is Slider)
				{
					Slider slider = (Slider)d;
					slider.PreviewMouseWheel -= SliderHelper.OnSliderPreviewMouseWheel;
					if ((MouseWheelState)e.NewValue != MouseWheelState.None)
					{
						slider.PreviewMouseWheel += SliderHelper.OnSliderPreviewMouseWheel;
						return;
					}
				}
				else if (d is RangeSlider)
				{
					RangeSlider rangeSlider = (RangeSlider)d;
					rangeSlider.PreviewMouseWheel -= SliderHelper.OnRangeSliderPreviewMouseWheel;
					if ((MouseWheelState)e.NewValue != MouseWheelState.None)
					{
						rangeSlider.PreviewMouseWheel += SliderHelper.OnRangeSliderPreviewMouseWheel;
					}
				}
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000D6F4 File Offset: 0x0000B8F4
		private static void OnSliderPreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			Slider slider = sender as Slider;
			if (slider != null && (slider.IsFocused || MouseWheelState.MouseHover.Equals(slider.GetValue(SliderHelper.EnableMouseWheelProperty))))
			{
				double num = ((MouseWheelChange)slider.GetValue(SliderHelper.ChangeValueByProperty) == MouseWheelChange.LargeChange) ? slider.LargeChange : slider.SmallChange;
				if (e.Delta > 0)
				{
					slider.Value += num;
				}
				else
				{
					slider.Value -= num;
				}
				e.Handled = true;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000D780 File Offset: 0x0000B980
		private static void OnRangeSliderPreviewMouseWheel(object sender, MouseWheelEventArgs e)
		{
			RangeSlider rangeSlider = sender as RangeSlider;
			if (rangeSlider != null && (rangeSlider.IsFocused || MouseWheelState.MouseHover.Equals(rangeSlider.GetValue(SliderHelper.EnableMouseWheelProperty))))
			{
				double num = ((MouseWheelChange)rangeSlider.GetValue(SliderHelper.ChangeValueByProperty) == MouseWheelChange.LargeChange) ? rangeSlider.LargeChange : rangeSlider.SmallChange;
				if (e.Delta > 0)
				{
					rangeSlider.LowerValue += num;
					rangeSlider.UpperValue += num;
				}
				else
				{
					rangeSlider.LowerValue -= num;
					rangeSlider.UpperValue -= num;
				}
				e.Handled = true;
			}
		}

		// Token: 0x0400013C RID: 316
		public static readonly DependencyProperty ThumbFillBrushProperty = DependencyProperty.RegisterAttached("ThumbFillBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400013D RID: 317
		public static readonly DependencyProperty ThumbFillHoverBrushProperty = DependencyProperty.RegisterAttached("ThumbFillHoverBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400013E RID: 318
		public static readonly DependencyProperty ThumbFillPressedBrushProperty = DependencyProperty.RegisterAttached("ThumbFillPressedBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400013F RID: 319
		public static readonly DependencyProperty ThumbFillDisabledBrushProperty = DependencyProperty.RegisterAttached("ThumbFillDisabledBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000140 RID: 320
		public static readonly DependencyProperty TrackFillBrushProperty = DependencyProperty.RegisterAttached("TrackFillBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000141 RID: 321
		public static readonly DependencyProperty TrackFillHoverBrushProperty = DependencyProperty.RegisterAttached("TrackFillHoverBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000142 RID: 322
		public static readonly DependencyProperty TrackFillPressedBrushProperty = DependencyProperty.RegisterAttached("TrackFillPressedBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000143 RID: 323
		public static readonly DependencyProperty TrackFillDisabledBrushProperty = DependencyProperty.RegisterAttached("TrackFillDisabledBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000144 RID: 324
		public static readonly DependencyProperty TrackValueFillBrushProperty = DependencyProperty.RegisterAttached("TrackValueFillBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000145 RID: 325
		public static readonly DependencyProperty TrackValueFillHoverBrushProperty = DependencyProperty.RegisterAttached("TrackValueFillHoverBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000146 RID: 326
		public static readonly DependencyProperty TrackValueFillPressedBrushProperty = DependencyProperty.RegisterAttached("TrackValueFillPressedBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000147 RID: 327
		public static readonly DependencyProperty TrackValueFillDisabledBrushProperty = DependencyProperty.RegisterAttached("TrackValueFillDisabledBrush", typeof(Brush), typeof(SliderHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000148 RID: 328
		public static readonly DependencyProperty ChangeValueByProperty = DependencyProperty.RegisterAttached("ChangeValueBy", typeof(MouseWheelChange), typeof(SliderHelper), new PropertyMetadata(MouseWheelChange.SmallChange));

		// Token: 0x04000149 RID: 329
		public static readonly DependencyProperty EnableMouseWheelProperty = DependencyProperty.RegisterAttached("EnableMouseWheel", typeof(MouseWheelState), typeof(SliderHelper), new PropertyMetadata(MouseWheelState.None, new PropertyChangedCallback(SliderHelper.OnEnableMouseWheelChanged)));
	}
}
