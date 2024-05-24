using System;
using System.Collections;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x0200085B RID: 2139
	public class FontFamilyList : IEnumerable
	{
		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x060056BF RID: 22207 RVA: 0x0029BD30 File Offset: 0x0029AD30
		public int Count
		{
			get
			{
				return this.b.Count;
			}
		}

		// Token: 0x17000879 RID: 2169
		public FontFamily this[int index]
		{
			get
			{
				return (FontFamily)this.b[index];
			}
			set
			{
				this.b[index] = value;
			}
		}

		// Token: 0x1700087A RID: 2170
		public FontFamily this[string name]
		{
			get
			{
				return (FontFamily)this.a[name.ToLower()];
			}
			set
			{
				this.a[name.ToLower()] = value;
			}
		}

		// Token: 0x060056C4 RID: 22212 RVA: 0x0029BDC2 File Offset: 0x0029ADC2
		public void Add(FontFamily fontFamily)
		{
			this.b.Add(fontFamily);
			this.a.Add(fontFamily.Name.ToLower(), fontFamily);
		}

		// Token: 0x060056C5 RID: 22213 RVA: 0x0029BDEC File Offset: 0x0029ADEC
		public IEnumerator GetEnumerator()
		{
			return this.b.GetEnumerator();
		}

		// Token: 0x04002E35 RID: 11829
		private Hashtable a = new Hashtable();

		// Token: 0x04002E36 RID: 11830
		private ArrayList b = new ArrayList();
	}
}
