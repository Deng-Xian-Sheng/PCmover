using System;
using System.Collections;
using System.Web;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000920 RID: 2336
	public class XmpLangAltList : XmpCollection
	{
		// Token: 0x06005F13 RID: 24339 RVA: 0x0035C233 File Offset: 0x0035B233
		internal XmpLangAltList()
		{
		}

		// Token: 0x06005F14 RID: 24340 RVA: 0x0035C24C File Offset: 0x0035B24C
		public void AddLang(string langCountry, string text)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
			}
			this.a.Add(new afb(langCountry, text));
		}

		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x06005F15 RID: 24341 RVA: 0x0035C28C File Offset: 0x0035B28C
		// (set) Token: 0x06005F16 RID: 24342 RVA: 0x0035C2A4 File Offset: 0x0035B2A4
		public string DefaultText
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06005F17 RID: 24343 RVA: 0x0035C2B0 File Offset: 0x0035B2B0
		public override int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06005F18 RID: 24344 RVA: 0x0035C2D0 File Offset: 0x0035B2D0
		internal override void j1(XmpWriter A_0)
		{
			A_0.Draw("\t\t\t<rdf:Alt>\n");
			if ((this.b == null || this.b == string.Empty) && A_0.Title != null)
			{
				this.b = A_0.Title;
			}
			A_0.Draw("\t\t\t\t<rdf:li xml:lang='x-default'>" + HttpUtility.HtmlEncode(this.b) + "</rdf:li>\n");
			if (this.a != null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					afb afb = (afb)this.a[i];
					A_0.Draw(string.Concat(new string[]
					{
						"\t\t\t\t<rdf:li xml:lang='",
						afb.a(),
						"'>",
						HttpUtility.HtmlEncode(afb.b()),
						"</rdf:li>\n"
					}));
				}
			}
			A_0.Draw("\t\t\t</rdf:Alt>\n");
		}

		// Token: 0x040030EC RID: 12524
		private ArrayList a;

		// Token: 0x040030ED RID: 12525
		private string b = string.Empty;
	}
}
