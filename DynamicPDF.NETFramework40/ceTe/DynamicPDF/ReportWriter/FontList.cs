using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200081B RID: 2075
	public class FontList
	{
		// Token: 0x060053F4 RID: 21492 RVA: 0x002936C4 File Offset: 0x002926C4
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

		// Token: 0x060053F5 RID: 21493 RVA: 0x00293899 File Offset: 0x00292899
		internal FontList()
		{
		}

		// Token: 0x060053F6 RID: 21494 RVA: 0x002938B0 File Offset: 0x002928B0
		internal void a(wd A_0)
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
						throw new DplxParseException("A openTypeFont element contains an invalid attribute.");
					}
					text2 = A_0.a6();
				}
				else
				{
					text = A_0.a8();
				}
			}
			if (text == null || text2 == null)
			{
				throw new DplxParseException("A openTypeFont element does not contain a required attribute.");
			}
			OpenTypeFont value = new OpenTypeFont(text2);
			this.b.Add(text, value);
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060053F7 RID: 21495 RVA: 0x00293958 File Offset: 0x00292958
		public void Add(Font font)
		{
			this.b.Add(font.Name, font);
		}

		// Token: 0x170007AA RID: 1962
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

		// Token: 0x04002CFE RID: 11518
		private static HybridDictionary a = new HybridDictionary(21, true);

		// Token: 0x04002CFF RID: 11519
		private HybridDictionary b = new HybridDictionary(true);
	}
}
