using System;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x0200091F RID: 2335
	public class XmpJob : XmpCollection
	{
		// Token: 0x06005F0D RID: 24333 RVA: 0x0035BFF3 File Offset: 0x0035AFF3
		internal XmpJob()
		{
		}

		// Token: 0x06005F0E RID: 24334 RVA: 0x0035C008 File Offset: 0x0035B008
		public void Add(string name, string id, Uri uri)
		{
			if (this.a == null)
			{
				this.a = new string[3];
			}
			this.a(3);
			this.a[this.b++] = name;
			this.a[this.b++] = id;
			if (uri != null)
			{
				this.a[this.b++] = uri.ToString();
			}
			else
			{
				this.a[this.b++] = "";
			}
		}

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x06005F0F RID: 24335 RVA: 0x0035C0BC File Offset: 0x0035B0BC
		public override int Count
		{
			get
			{
				return this.b / 3;
			}
		}

		// Token: 0x06005F10 RID: 24336 RVA: 0x0035C0D8 File Offset: 0x0035B0D8
		internal override void j1(XmpWriter A_0)
		{
			if (this.a != null)
			{
				A_0.Draw("\t\t\t<rdf:Bag>\n");
				this.a(A_0);
				A_0.Draw("\t\t\t</rdf:Bag>\n");
			}
		}

		// Token: 0x06005F11 RID: 24337 RVA: 0x0035C118 File Offset: 0x0035B118
		private void a(XmpWriter A_0)
		{
			int i = 0;
			int num = 0;
			while (i < this.Count)
			{
				A_0.Draw("\t\t\t\t<rdf:li>\n\t\t\t\t\t<rdf:Description xmlns:stJob='http://ns.adobe.com/xap/1.0/sType/Job#'>\n");
				A_0.Draw("\t\t\t\t\t\t<stJob:name>" + x7.a(this.a[num++]) + "</stJob:name>\n");
				A_0.Draw("\t\t\t\t\t\t<stJob:id>" + x7.a(this.a[num++]) + "</stJob:id>\n");
				A_0.Draw("\t\t\t\t\t\t<stJob:url>" + this.a[num++] + "</stJob:url>\n");
				A_0.Draw("\t\t\t\t\t</rdf:Description>\n");
				A_0.Draw("\t\t\t\t</rdf:li>\n");
				i++;
			}
		}

		// Token: 0x06005F12 RID: 24338 RVA: 0x0035C1DC File Offset: 0x0035B1DC
		private void a(int A_0)
		{
			if (this.a.Length - this.b < A_0)
			{
				string[] destinationArray = new string[this.a.Length * 2];
				Array.Copy(this.a, 0, destinationArray, 0, this.a.Length);
				this.a = destinationArray;
			}
		}

		// Token: 0x040030EA RID: 12522
		private string[] a;

		// Token: 0x040030EB RID: 12523
		private int b = 0;
	}
}
