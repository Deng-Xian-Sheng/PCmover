using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.Xmp;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000657 RID: 1623
	public class CustomPropertyList
	{
		// Token: 0x06003D71 RID: 15729 RVA: 0x00215497 File Offset: 0x00214497
		internal CustomPropertyList()
		{
		}

		// Token: 0x06003D72 RID: 15730 RVA: 0x002154A4 File Offset: 0x002144A4
		public void Add(string name, string value)
		{
			if (this.a == null)
			{
				this.a = new Dictionary<string, string>();
			}
			this.a.Add(name, value);
		}

		// Token: 0x06003D73 RID: 15731 RVA: 0x002154DC File Offset: 0x002144DC
		internal Dictionary<string, string> a()
		{
			return this.a;
		}

		// Token: 0x06003D74 RID: 15732 RVA: 0x002154F4 File Offset: 0x002144F4
		internal void a(XmpWriter A_0)
		{
			A_0.BeginDescription("http://ns.adobe.com/pdfx/1.3/", "pdfx", " ");
			foreach (KeyValuePair<string, string> keyValuePair in this.a)
			{
				A_0.Draw(string.Concat(new string[]
				{
					"\t\t<pdfx:",
					keyValuePair.Key,
					">",
					keyValuePair.Value,
					"</pdfx:",
					keyValuePair.Key,
					">\n"
				}));
			}
			A_0.EndDescription();
		}

		// Token: 0x04002119 RID: 8473
		private Dictionary<string, string> a;
	}
}
