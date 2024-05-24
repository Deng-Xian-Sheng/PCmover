using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace PCmover.Infrastructure
{
	// Token: 0x0200002C RID: 44
	public class LinearGradientBrushBehavior : Behavior<RangeBase>
	{
		// Token: 0x0600028D RID: 653 RVA: 0x00006E08 File Offset: 0x00005008
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.Loaded += this.AssociatedObject_Loaded;
			base.AssociatedObject.ValueChanged += this.AssociatedObject_ValueChanged;
			LinearGradientBrush linearGradientBrush = base.AssociatedObject.Foreground as LinearGradientBrush;
			if (linearGradientBrush != null)
			{
				this.SourceBrush = linearGradientBrush;
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00006E64 File Offset: 0x00005064
		protected override void OnDetaching()
		{
			base.OnDetaching();
			base.AssociatedObject.Loaded -= this.AssociatedObject_Loaded;
			base.AssociatedObject.ValueChanged -= this.AssociatedObject_ValueChanged;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00006E9A File Offset: 0x0000509A
		private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
		{
			this.CalculateNewSolid(this.Progress);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00006E9A File Offset: 0x0000509A
		private void AssociatedObject_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.CalculateNewSolid(this.Progress);
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00006EA8 File Offset: 0x000050A8
		private double Progress
		{
			get
			{
				return base.AssociatedObject.Value / (base.AssociatedObject.Maximum - base.AssociatedObject.Minimum);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00006ECD File Offset: 0x000050CD
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00006EDF File Offset: 0x000050DF
		public LinearGradientBrush SourceBrush
		{
			get
			{
				return (LinearGradientBrush)base.GetValue(LinearGradientBrushBehavior.SourceBrushProperty);
			}
			set
			{
				base.SetValue(LinearGradientBrushBehavior.SourceBrushProperty, value);
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00006EF0 File Offset: 0x000050F0
		private Color GetColor(double ratio)
		{
			if (ratio < 0.0)
			{
				ratio = 0.0;
			}
			else if (ratio > 1.0)
			{
				ratio = 1.0;
			}
			GradientStop gradientStop = (from n in this.SourceBrush.GradientStops
			where n.Offset <= ratio
			orderby n.Offset
			select n).Last<GradientStop>();
			GradientStop gradientStop2 = (from n in this.SourceBrush.GradientStops
			where n.Offset >= ratio
			orderby n.Offset
			select n).First<GradientStop>();
			float num = 0f;
			if (gradientStop.Offset != gradientStop2.Offset)
			{
				num = (float)((ratio - gradientStop.Offset) / (gradientStop2.Offset - gradientStop.Offset));
			}
			Color result = default(Color);
			if (this.SourceBrush.ColorInterpolationMode == ColorInterpolationMode.ScRgbLinearInterpolation)
			{
				float a = (gradientStop2.Color.ScA - gradientStop.Color.ScA) * num + gradientStop.Color.ScA;
				float r = (gradientStop2.Color.ScR - gradientStop.Color.ScR) * num + gradientStop.Color.ScR;
				float g = (gradientStop2.Color.ScG - gradientStop.Color.ScG) * num + gradientStop.Color.ScG;
				float b = (gradientStop2.Color.ScB - gradientStop.Color.ScB) * num + gradientStop.Color.ScB;
				result = Color.FromScRgb(a, r, g, b);
			}
			else
			{
				byte a2 = (byte)((float)(gradientStop2.Color.A - gradientStop.Color.A) * num + (float)gradientStop.Color.A);
				byte r2 = (byte)((float)(gradientStop2.Color.R - gradientStop.Color.R) * num + (float)gradientStop.Color.R);
				byte g2 = (byte)((float)(gradientStop2.Color.G - gradientStop.Color.G) * num + (float)gradientStop.Color.G);
				byte b2 = (byte)((float)(gradientStop2.Color.B - gradientStop.Color.B) * num + (float)gradientStop.Color.B);
				result = Color.FromArgb(a2, r2, g2, b2);
			}
			return result;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x000071E4 File Offset: 0x000053E4
		private void CalculateNewSolid(double progress)
		{
			if (progress < 0.0)
			{
				progress = 0.0;
			}
			else if (progress > 1.0)
			{
				progress = 1.0;
			}
			progress = 1.0 - progress;
			GradientStop gradientStop = (from n in this.SourceBrush.GradientStops
			where n.Offset <= progress
			orderby n.Offset
			select n).Last<GradientStop>();
			GradientStop gradientStop2 = (from n in this.SourceBrush.GradientStops
			where n.Offset >= progress
			orderby n.Offset
			select n).First<GradientStop>();
			float num = 0f;
			if (gradientStop.Offset != gradientStop2.Offset)
			{
				num = (float)((progress - gradientStop.Offset) / (gradientStop2.Offset - gradientStop.Offset));
			}
			Color color = default(Color);
			if (this.SourceBrush.ColorInterpolationMode == ColorInterpolationMode.ScRgbLinearInterpolation)
			{
				float a = (gradientStop2.Color.ScA - gradientStop.Color.ScA) * num + gradientStop.Color.ScA;
				float r = (gradientStop2.Color.ScR - gradientStop.Color.ScR) * num + gradientStop.Color.ScR;
				float g = (gradientStop2.Color.ScG - gradientStop.Color.ScG) * num + gradientStop.Color.ScG;
				float b = (gradientStop2.Color.ScB - gradientStop.Color.ScB) * num + gradientStop.Color.ScB;
				color = Color.FromScRgb(a, r, g, b);
			}
			else
			{
				byte a2 = (byte)((float)(gradientStop2.Color.A - gradientStop.Color.A) * num + (float)gradientStop.Color.A);
				byte r2 = (byte)((float)(gradientStop2.Color.R - gradientStop.Color.R) * num + (float)gradientStop.Color.R);
				byte g2 = (byte)((float)(gradientStop2.Color.G - gradientStop.Color.G) * num + (float)gradientStop.Color.G);
				byte b2 = (byte)((float)(gradientStop2.Color.B - gradientStop.Color.B) * num + (float)gradientStop.Color.B);
				color = Color.FromArgb(a2, r2, g2, b2);
			}
			this.ApplyNewGradient(new SolidColorBrush
			{
				Color = color
			});
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00007502 File Offset: 0x00005702
		private void ApplyNewGradient(SolidColorBrush brush)
		{
			base.AssociatedObject.Foreground = brush;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00007510 File Offset: 0x00005710
		private void CalculateNewGradient(double progress)
		{
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
			linearGradientBrush.StartPoint = this.SourceBrush.StartPoint;
			linearGradientBrush.EndPoint = this.SourceBrush.EndPoint;
			foreach (GradientStop gradientStop in this.SourceBrush.GradientStops)
			{
				double num = (1.0 - gradientStop.Offset) / progress;
				GradientStop value = new GradientStop(gradientStop.Color, 1.0 - num);
				linearGradientBrush.GradientStops.Add(value);
			}
			this.ApplyNewGradient(linearGradientBrush);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00007502 File Offset: 0x00005702
		private void ApplyNewGradient(LinearGradientBrush brush)
		{
			base.AssociatedObject.Foreground = brush;
		}

		// Token: 0x040000B5 RID: 181
		public static readonly DependencyProperty SourceBrushProperty = DependencyProperty.Register("SourceBrush", typeof(LinearGradientBrush), typeof(LinearGradientBrushBehavior), new UIPropertyMetadata(null));
	}
}
