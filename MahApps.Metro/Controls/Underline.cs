using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000096 RID: 150
	[TemplatePart(Name = "PART_UnderlineBorder", Type = typeof(Border))]
	public class Underline : ContentControl
	{
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600082A RID: 2090 RVA: 0x00021430 File Offset: 0x0001F630
		// (set) Token: 0x0600082B RID: 2091 RVA: 0x00021442 File Offset: 0x0001F642
		public Dock Placement
		{
			get
			{
				return (Dock)base.GetValue(Underline.PlacementProperty);
			}
			set
			{
				base.SetValue(Underline.PlacementProperty, value);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600082C RID: 2092 RVA: 0x00021455 File Offset: 0x0001F655
		// (set) Token: 0x0600082D RID: 2093 RVA: 0x00021467 File Offset: 0x0001F667
		public double LineThickness
		{
			get
			{
				return (double)base.GetValue(Underline.LineThicknessProperty);
			}
			set
			{
				base.SetValue(Underline.LineThicknessProperty, value);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0002147A File Offset: 0x0001F67A
		// (set) Token: 0x0600082F RID: 2095 RVA: 0x0002148C File Offset: 0x0001F68C
		public double LineExtent
		{
			get
			{
				return (double)base.GetValue(Underline.LineExtentProperty);
			}
			set
			{
				base.SetValue(Underline.LineExtentProperty, value);
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x000214A0 File Offset: 0x0001F6A0
		static Underline()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Underline), new FrameworkPropertyMetadata(typeof(Underline)));
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0002159A File Offset: 0x0001F79A
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._underlineBorder = (base.GetTemplateChild("PART_UnderlineBorder") as Border);
			this.ApplyBorderProperties();
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x000215C0 File Offset: 0x0001F7C0
		private void ApplyBorderProperties()
		{
			if (this._underlineBorder == null)
			{
				return;
			}
			this._underlineBorder.Height = double.NaN;
			this._underlineBorder.Width = double.NaN;
			this._underlineBorder.BorderThickness = default(Thickness);
			switch (this.Placement)
			{
			case Dock.Left:
				this._underlineBorder.Width = this.LineExtent;
				this._underlineBorder.BorderThickness = new Thickness(this.LineThickness, 0.0, 0.0, 0.0);
				break;
			case Dock.Top:
				this._underlineBorder.Height = this.LineExtent;
				this._underlineBorder.BorderThickness = new Thickness(0.0, this.LineThickness, 0.0, 0.0);
				break;
			case Dock.Right:
				this._underlineBorder.Width = this.LineExtent;
				this._underlineBorder.BorderThickness = new Thickness(0.0, 0.0, this.LineThickness, 0.0);
				break;
			case Dock.Bottom:
				this._underlineBorder.Height = this.LineExtent;
				this._underlineBorder.BorderThickness = new Thickness(0.0, 0.0, 0.0, this.LineThickness);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			base.InvalidateVisual();
		}

		// Token: 0x04000383 RID: 899
		public const string UnderlineBorderPartName = "PART_UnderlineBorder";

		// Token: 0x04000384 RID: 900
		private Border _underlineBorder;

		// Token: 0x04000385 RID: 901
		public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register("Placement", typeof(Dock), typeof(Underline), new PropertyMetadata(Dock.Left, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			Underline underline = o as Underline;
			if (underline == null)
			{
				return;
			}
			underline.ApplyBorderProperties();
		}));

		// Token: 0x04000386 RID: 902
		public static readonly DependencyProperty LineThicknessProperty = DependencyProperty.Register("LineThickness", typeof(double), typeof(Underline), new PropertyMetadata(1.0, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			Underline underline = o as Underline;
			if (underline == null)
			{
				return;
			}
			underline.ApplyBorderProperties();
		}));

		// Token: 0x04000387 RID: 903
		public static readonly DependencyProperty LineExtentProperty = DependencyProperty.Register("LineExtent", typeof(double), typeof(Underline), new PropertyMetadata(double.NaN, delegate(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			Underline underline = o as Underline;
			if (underline == null)
			{
				return;
			}
			underline.ApplyBorderProperties();
		}));
	}
}
