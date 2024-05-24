using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000931 RID: 2353
	public class FontFamilyList
	{
		// Token: 0x06005FAA RID: 24490 RVA: 0x0035E368 File Offset: 0x0035D368
		static FontFamilyList()
		{
			FontFamilyList.b.Add("Times", FontFamily.Times);
			FontFamilyList.b.Add("Helvetica", FontFamily.Helvetica);
			FontFamilyList.b.Add("Courier", FontFamily.Courier);
			FontFamilyList.b.Add("Symbol", FontFamily.Symbol);
			FontFamilyList.b.Add("ZapfDingbats", FontFamily.ZapfDingbats);
		}

		// Token: 0x06005FAB RID: 24491 RVA: 0x0035E3EC File Offset: 0x0035D3EC
		internal FontFamilyList()
		{
		}

		// Token: 0x06005FAC RID: 24492 RVA: 0x0035E404 File Offset: 0x0035D404
		internal void a(ald A_0)
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
						text = A_0.a7();
					}
					else
					{
						text2 = A_0.a7();
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
						text5 = A_0.a7();
					}
					else
					{
						text4 = A_0.a7();
					}
				}
				else
				{
					text3 = A_0.a7();
				}
				continue;
				IL_7F:
				throw new DlexParseException("A fontFamily element contains an invalid attribute.");
			}
			if (text == null || text2 == null || text3 == null || text4 == null || text5 == null)
			{
				throw new DlexParseException("A fontFamily element does not contain a required attribute.");
			}
			FontFamily value = new FontFamily(text, A_0.t().b()[text5], A_0.t().b()[text2], A_0.t().b()[text4], A_0.t().b()[text3]);
			this.a.Add(text, value);
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x06005FAD RID: 24493 RVA: 0x0035E54C File Offset: 0x0035D54C
		public void Add(FontFamily FontFamily)
		{
			this.a.Add(FontFamily.Name, FontFamily);
		}

		// Token: 0x17000A2C RID: 2604
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

		// Token: 0x06005FAF RID: 24495 RVA: 0x0035E5A8 File Offset: 0x0035D5A8
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

		// Token: 0x04003141 RID: 12609
		private HybridDictionary a = new HybridDictionary(true);

		// Token: 0x04003142 RID: 12610
		private static HybridDictionary b = new HybridDictionary(5, true);
	}
}
