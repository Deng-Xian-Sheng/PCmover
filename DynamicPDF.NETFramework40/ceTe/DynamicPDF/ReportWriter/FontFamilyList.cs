using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200081A RID: 2074
	public class FontFamilyList
	{
		// Token: 0x060053EE RID: 21486 RVA: 0x0029340C File Offset: 0x0029240C
		static FontFamilyList()
		{
			FontFamilyList.b.Add("Times", FontFamily.Times);
			FontFamilyList.b.Add("Helvetica", FontFamily.Helvetica);
			FontFamilyList.b.Add("Courier", FontFamily.Courier);
			FontFamilyList.b.Add("Symbol", FontFamily.Symbol);
			FontFamilyList.b.Add("ZapfDingbats", FontFamily.ZapfDingbats);
		}

		// Token: 0x060053EF RID: 21487 RVA: 0x00293490 File Offset: 0x00292490
		internal FontFamilyList()
		{
		}

		// Token: 0x060053F0 RID: 21488 RVA: 0x002934A8 File Offset: 0x002924A8
		internal void a(wd A_0)
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			string text4 = null;
			string text5 = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 12196709)
				{
					if (num != 9108260)
					{
						if (num != 12196709)
						{
							goto IL_7F;
						}
						text = A_0.a8();
					}
					else
					{
						text2 = A_0.a8();
					}
				}
				else if (num != 372769642)
				{
					if (num != 701635338)
					{
						if (num != 848721182)
						{
							goto IL_7F;
						}
						text5 = A_0.a8();
					}
					else
					{
						text4 = A_0.a8();
					}
				}
				else
				{
					text3 = A_0.a8();
				}
				continue;
				IL_7F:
				throw new DplxParseException("A fontFamily element contains an invalid attribute.");
			}
			if (text == null || text2 == null || text3 == null || text4 == null || text5 == null)
			{
				throw new DplxParseException("A fontFamily element does not contain a required attribute.");
			}
			FontFamily value = new FontFamily(text, A_0.t().b()[text5], A_0.t().b()[text2], A_0.t().b()[text4], A_0.t().b()[text3]);
			this.a.Add(text, value);
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060053F1 RID: 21489 RVA: 0x002935F0 File Offset: 0x002925F0
		public void Add(FontFamily FontFamily)
		{
			this.a.Add(FontFamily.Name, FontFamily);
		}

		// Token: 0x170007A9 RID: 1961
		public FontFamily this[string name]
		{
			get
			{
				FontFamily fontFamily = (FontFamily)FontFamilyList.b[name];
				if (fontFamily == null)
				{
					fontFamily = (FontFamily)this.a[name];
				}
				return fontFamily;
			}
		}

		// Token: 0x060053F3 RID: 21491 RVA: 0x0029364C File Offset: 0x0029264C
		internal FontFamilyList a()
		{
			object[] array = new object[this.a.Count];
			this.a.Keys.CopyTo(array, 0);
			FontFamilyList fontFamilyList = new FontFamilyList();
			for (int i = 0; i < this.a.Count; i++)
			{
				fontFamilyList.Add((FontFamily)this.a[array[i]]);
			}
			return fontFamilyList;
		}

		// Token: 0x04002CFC RID: 11516
		private HybridDictionary a = new HybridDictionary(true);

		// Token: 0x04002CFD RID: 11517
		private static HybridDictionary b = new HybridDictionary(5, true);
	}
}
