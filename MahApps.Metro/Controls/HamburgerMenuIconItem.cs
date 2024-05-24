using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200003D RID: 61
	public class HamburgerMenuIconItem : HamburgerMenuItem
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600029D RID: 669 RVA: 0x0000BB45 File Offset: 0x00009D45
		// (set) Token: 0x0600029E RID: 670 RVA: 0x0000BB52 File Offset: 0x00009D52
		public object Icon
		{
			get
			{
				return base.GetValue(HamburgerMenuIconItem.IconProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuIconItem.IconProperty, value);
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000BB60 File Offset: 0x00009D60
		protected override Freezable CreateInstanceCore()
		{
			return new HamburgerMenuIconItem();
		}

		// Token: 0x040000FD RID: 253
		public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(HamburgerMenuIconItem), new PropertyMetadata(null));
	}
}
