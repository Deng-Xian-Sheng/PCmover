using System;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x0200091E RID: 2334
	public class XmpArray : XmpCollection
	{
		// Token: 0x06005F06 RID: 24326 RVA: 0x0035BDCE File Offset: 0x0035ADCE
		internal XmpArray(ae9 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06005F07 RID: 24327 RVA: 0x0035BDE8 File Offset: 0x0035ADE8
		public void Add(string data)
		{
			if (this.a == null)
			{
				this.a = new string[1];
			}
			this.a(1);
			this.a[this.b++] = data;
		}

		// Token: 0x06005F08 RID: 24328 RVA: 0x0035BE38 File Offset: 0x0035AE38
		public void Add(DateTime date)
		{
			if (this.a == null)
			{
				this.a = new string[1];
			}
			this.a(1);
			this.a[this.b++] = x6.a(date);
		}

		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06005F09 RID: 24329 RVA: 0x0035BE8C File Offset: 0x0035AE8C
		public override int Count
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06005F0A RID: 24330 RVA: 0x0035BEA4 File Offset: 0x0035AEA4
		internal override void j1(XmpWriter A_0)
		{
			if (this.a != null)
			{
				switch (this.c)
				{
				case ae9.a:
					A_0.Draw("\t\t\t<rdf:Seq>\n");
					this.a(A_0);
					A_0.Draw("\t\t\t</rdf:Seq>\n");
					break;
				case ae9.b:
					A_0.Draw("\t\t\t<rdf:Bag>\n");
					this.a(A_0);
					A_0.Draw("\t\t\t</rdf:Bag>\n");
					break;
				case ae9.c:
					A_0.Draw("\t\t\t<rdf:Alt>\n");
					this.a(A_0);
					A_0.Draw("\t\t\t</rdf:Alt>\n");
					break;
				}
			}
		}

		// Token: 0x06005F0B RID: 24331 RVA: 0x0035BF48 File Offset: 0x0035AF48
		private void a(XmpWriter A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				A_0.Draw("\t\t\t\t<rdf:li>");
				A_0.Draw(x7.a(this.a[i]));
				A_0.Draw("</rdf:li>\n");
			}
		}

		// Token: 0x06005F0C RID: 24332 RVA: 0x0035BF9C File Offset: 0x0035AF9C
		private void a(int A_0)
		{
			if (this.a.Length - this.b < A_0)
			{
				string[] destinationArray = new string[this.a.Length * 2];
				Array.Copy(this.a, 0, destinationArray, 0, this.a.Length);
				this.a = destinationArray;
			}
		}

		// Token: 0x040030E7 RID: 12519
		private string[] a;

		// Token: 0x040030E8 RID: 12520
		private int b = 0;

		// Token: 0x040030E9 RID: 12521
		private ae9 c;
	}
}
