using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000932 RID: 2354
	public class FontList
	{
		// Token: 0x06005FB0 RID: 24496 RVA: 0x0035E620 File Offset: 0x0035D620
		static FontList()
		{
			FontList.a.Add("TimesRoman", Font.TimesRoman);
			FontList.a.Add("TimesBold", Font.TimesBold);
			FontList.a.Add("TimesItalic", Font.TimesItalic);
			FontList.a.Add("TimesBoldItalic", Font.TimesBoldItalic);
			FontList.a.Add("Helvetica", Font.Helvetica);
			FontList.a.Add("HelveticaBold", Font.HelveticaBold);
			FontList.a.Add("HelveticaOblique", Font.HelveticaOblique);
			FontList.a.Add("HelveticaBoldOblique", Font.HelveticaBoldOblique);
			FontList.a.Add("Courier", Font.Courier);
			FontList.a.Add("CourierBold", Font.CourierBold);
			FontList.a.Add("CourierOblique", Font.CourierOblique);
			FontList.a.Add("CourierBoldOblique", Font.CourierBoldOblique);
			FontList.a.Add("Symbol", Font.Symbol);
			FontList.a.Add("ZapfDingbats", Font.ZapfDingbats);
			FontList.a.Add("HeiseiKakuGothicW5", Font.HeiseiKakuGothicW5);
			FontList.a.Add("HeiseiMinchoW3", Font.HeiseiMinchoW3);
			FontList.a.Add("HanyangSystemsGothicMedium", Font.HanyangSystemsGothicMedium);
			FontList.a.Add("HanyangSystemsShinMyeongJoMedium", Font.HanyangSystemsShinMyeongJoMedium);
			FontList.a.Add("SinoTypeSongLight", Font.SinoTypeSongLight);
			FontList.a.Add("MonotypeHeiMedium", Font.MonotypeHeiMedium);
			FontList.a.Add("MonotypeSungLight", Font.MonotypeSungLight);
		}

		// Token: 0x06005FB1 RID: 24497 RVA: 0x0035E7F5 File Offset: 0x0035D7F5
		internal FontList()
		{
		}

		// Token: 0x06005FB2 RID: 24498 RVA: 0x0035E80C File Offset: 0x0035D80C
		internal void a(ald A_0)
		{
			string text = null;
			string text2 = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 12196709)
				{
					if (num != 12721448)
					{
						throw new DlexParseException("A openTypeFont element contains an invalid attribute.");
					}
					text2 = A_0.a5();
				}
				else
				{
					text = A_0.a7();
				}
			}
			if (text == null || text2 == null)
			{
				throw new DlexParseException("A openTypeFont element does not contain a required attribute.");
			}
			OpenTypeFont value = new OpenTypeFont(text2);
			this.b.Add(text, value);
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x06005FB3 RID: 24499 RVA: 0x0035E8B4 File Offset: 0x0035D8B4
		public void Add(Font font)
		{
			this.b.Add(font.Name, font);
		}

		// Token: 0x17000A2D RID: 2605
		public Font this[string name]
		{
			get
			{
				Font font = (Font)FontList.a[name];
				if (font == null)
				{
					font = (Font)this.b[name];
				}
				return font;
			}
		}

		// Token: 0x04003143 RID: 12611
		private static HybridDictionary a = new HybridDictionary(21, true);

		// Token: 0x04003144 RID: 12612
		private HybridDictionary b = new HybridDictionary(true);
	}
}
