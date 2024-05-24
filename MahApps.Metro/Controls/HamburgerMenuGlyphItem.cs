using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200003C RID: 60
	public class HamburgerMenuGlyphItem : HamburgerMenuItem
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0000BAEB File Offset: 0x00009CEB
		// (set) Token: 0x06000299 RID: 665 RVA: 0x0000BAFD File Offset: 0x00009CFD
		public string Glyph
		{
			get
			{
				return (string)base.GetValue(HamburgerMenuGlyphItem.GlyphProperty);
			}
			set
			{
				base.SetValue(HamburgerMenuGlyphItem.GlyphProperty, value);
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000BB0B File Offset: 0x00009D0B
		protected override Freezable CreateInstanceCore()
		{
			return new HamburgerMenuGlyphItem();
		}

		// Token: 0x040000FC RID: 252
		public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register("Glyph", typeof(string), typeof(HamburgerMenuGlyphItem), new PropertyMetadata(null));
	}
}
