using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200008A RID: 138
	public class Tile : Button
	{
		// Token: 0x06000732 RID: 1842 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		static Tile()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Tile), new FrameworkPropertyMetadata(typeof(Tile)));
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0001D97E File Offset: 0x0001BB7E
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x0001D990 File Offset: 0x0001BB90
		public string Title
		{
			get
			{
				return (string)base.GetValue(Tile.TitleProperty);
			}
			set
			{
				base.SetValue(Tile.TitleProperty, value);
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x0001D99E File Offset: 0x0001BB9E
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x0001D9B0 File Offset: 0x0001BBB0
		[Bindable(true)]
		[Category("Layout")]
		public HorizontalAlignment HorizontalTitleAlignment
		{
			get
			{
				return (HorizontalAlignment)base.GetValue(Tile.HorizontalTitleAlignmentProperty);
			}
			set
			{
				base.SetValue(Tile.HorizontalTitleAlignmentProperty, value);
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x0001D9C3 File Offset: 0x0001BBC3
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x0001D9D5 File Offset: 0x0001BBD5
		[Bindable(true)]
		[Category("Layout")]
		public VerticalAlignment VerticalTitleAlignment
		{
			get
			{
				return (VerticalAlignment)base.GetValue(Tile.VerticalTitleAlignmentProperty);
			}
			set
			{
				base.SetValue(Tile.VerticalTitleAlignmentProperty, value);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x0001D9E8 File Offset: 0x0001BBE8
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x0001D9FA File Offset: 0x0001BBFA
		public string Count
		{
			get
			{
				return (string)base.GetValue(Tile.CountProperty);
			}
			set
			{
				base.SetValue(Tile.CountProperty, value);
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x0001DA08 File Offset: 0x0001BC08
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x0001DA1A File Offset: 0x0001BC1A
		public bool KeepDragging
		{
			get
			{
				return (bool)base.GetValue(Tile.KeepDraggingProperty);
			}
			set
			{
				base.SetValue(Tile.KeepDraggingProperty, value);
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600073D RID: 1853 RVA: 0x0001DA2D File Offset: 0x0001BC2D
		// (set) Token: 0x0600073E RID: 1854 RVA: 0x0001DA3F File Offset: 0x0001BC3F
		public int TiltFactor
		{
			get
			{
				return (int)base.GetValue(Tile.TiltFactorProperty);
			}
			set
			{
				base.SetValue(Tile.TiltFactorProperty, value);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0001DA52 File Offset: 0x0001BC52
		// (set) Token: 0x06000740 RID: 1856 RVA: 0x0001DA64 File Offset: 0x0001BC64
		public double TitleFontSize
		{
			get
			{
				return (double)base.GetValue(Tile.TitleFontSizeProperty);
			}
			set
			{
				base.SetValue(Tile.TitleFontSizeProperty, value);
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x0001DA77 File Offset: 0x0001BC77
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x0001DA89 File Offset: 0x0001BC89
		public double CountFontSize
		{
			get
			{
				return (double)base.GetValue(Tile.CountFontSizeProperty);
			}
			set
			{
				base.SetValue(Tile.CountFontSizeProperty, value);
			}
		}

		// Token: 0x040002F0 RID: 752
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Tile), new PropertyMetadata(null));

		// Token: 0x040002F1 RID: 753
		public static readonly DependencyProperty HorizontalTitleAlignmentProperty = DependencyProperty.Register("HorizontalTitleAlignment", typeof(HorizontalAlignment), typeof(Tile), new FrameworkPropertyMetadata(HorizontalAlignment.Left));

		// Token: 0x040002F2 RID: 754
		public static readonly DependencyProperty VerticalTitleAlignmentProperty = DependencyProperty.Register("VerticalTitleAlignment", typeof(VerticalAlignment), typeof(Tile), new FrameworkPropertyMetadata(VerticalAlignment.Bottom));

		// Token: 0x040002F3 RID: 755
		public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(string), typeof(Tile), new PropertyMetadata(null));

		// Token: 0x040002F4 RID: 756
		public static readonly DependencyProperty KeepDraggingProperty = DependencyProperty.Register("KeepDragging", typeof(bool), typeof(Tile), new PropertyMetadata(true));

		// Token: 0x040002F5 RID: 757
		public static readonly DependencyProperty TiltFactorProperty = DependencyProperty.Register("TiltFactor", typeof(int), typeof(Tile), new PropertyMetadata(5));

		// Token: 0x040002F6 RID: 758
		public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register("TitleFontSize", typeof(double), typeof(Tile), new PropertyMetadata(16.0));

		// Token: 0x040002F7 RID: 759
		public static readonly DependencyProperty CountFontSizeProperty = DependencyProperty.Register("CountFontSize", typeof(double), typeof(Tile), new PropertyMetadata(28.0));
	}
}
