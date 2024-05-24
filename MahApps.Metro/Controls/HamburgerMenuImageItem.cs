using System;
using System.Windows;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200003E RID: 62
	public class HamburgerMenuImageItem : HamburgerMenuItem
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000BB9A File Offset: 0x00009D9A
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x0000BBAC File Offset: 0x00009DAC
		public ImageSource Thumbnail
		{
			get
			{
				return (ImageSource)base.GetValue(HamburgerMenuImageItem.ThumbnailProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuImageItem.ThumbnailProperty, value);
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000BBBA File Offset: 0x00009DBA
		protected override Freezable CreateInstanceCore()
		{
			return new HamburgerMenuImageItem();
		}

		// Token: 0x040000FE RID: 254
		public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(ImageSource), typeof(HamburgerMenuImageItem), new PropertyMetadata(null));
	}
}
