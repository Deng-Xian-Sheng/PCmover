using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000035 RID: 53
	public class Glow : Control
	{
		// Token: 0x06000204 RID: 516 RVA: 0x00009B08 File Offset: 0x00007D08
		static Glow()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Glow), new FrameworkPropertyMetadata(typeof(Glow)));
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00009C1C File Offset: 0x00007E1C
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00009C2E File Offset: 0x00007E2E
		public Brush GlowBrush
		{
			get
			{
				return (Brush)base.GetValue(Glow.GlowBrushProperty);
			}
			set
			{
				base.SetValue(Glow.GlowBrushProperty, value);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00009C3C File Offset: 0x00007E3C
		// (set) Token: 0x06000208 RID: 520 RVA: 0x00009C4E File Offset: 0x00007E4E
		public Brush NonActiveGlowBrush
		{
			get
			{
				return (Brush)base.GetValue(Glow.NonActiveGlowBrushProperty);
			}
			set
			{
				base.SetValue(Glow.NonActiveGlowBrushProperty, value);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00009C5C File Offset: 0x00007E5C
		// (set) Token: 0x0600020A RID: 522 RVA: 0x00009C6E File Offset: 0x00007E6E
		public bool IsGlow
		{
			get
			{
				return (bool)base.GetValue(Glow.IsGlowProperty);
			}
			set
			{
				base.SetValue(Glow.IsGlowProperty, value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00009C81 File Offset: 0x00007E81
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00009C93 File Offset: 0x00007E93
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(Glow.OrientationProperty);
			}
			set
			{
				base.SetValue(Glow.OrientationProperty, value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00009CA6 File Offset: 0x00007EA6
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00009CB8 File Offset: 0x00007EB8
		public GlowDirection Direction
		{
			get
			{
				return (GlowDirection)base.GetValue(Glow.DirectionProperty);
			}
			set
			{
				base.SetValue(Glow.DirectionProperty, value);
			}
		}

		// Token: 0x040000B2 RID: 178
		public static readonly DependencyProperty GlowBrushProperty = DependencyProperty.Register("GlowBrush", typeof(Brush), typeof(Glow), new UIPropertyMetadata(Brushes.Transparent));

		// Token: 0x040000B3 RID: 179
		public static readonly DependencyProperty NonActiveGlowBrushProperty = DependencyProperty.Register("NonActiveGlowBrush", typeof(Brush), typeof(Glow), new UIPropertyMetadata(Brushes.Transparent));

		// Token: 0x040000B4 RID: 180
		public static readonly DependencyProperty IsGlowProperty = DependencyProperty.Register("IsGlow", typeof(bool), typeof(Glow), new UIPropertyMetadata(true));

		// Token: 0x040000B5 RID: 181
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(Glow), new UIPropertyMetadata(Orientation.Vertical));

		// Token: 0x040000B6 RID: 182
		public static readonly DependencyProperty DirectionProperty = DependencyProperty.Register("Direction", typeof(GlowDirection), typeof(Glow), new UIPropertyMetadata(GlowDirection.Top));
	}
}
