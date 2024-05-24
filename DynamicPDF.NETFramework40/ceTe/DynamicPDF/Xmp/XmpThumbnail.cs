using System;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000922 RID: 2338
	public class XmpThumbnail : XmpDataType
	{
		// Token: 0x06005F23 RID: 24355 RVA: 0x0035C5B7 File Offset: 0x0035B5B7
		internal XmpThumbnail()
		{
		}

		// Token: 0x06005F24 RID: 24356 RVA: 0x0035C5CC File Offset: 0x0035B5CC
		public void Add(int width, int height, string format, byte[] image)
		{
			if (this.d == null)
			{
				this.a = new int[1];
				this.b = new int[1];
				this.c = new string[1];
				this.d = new string[1];
			}
			if (width > 0 && height > 0 && format != null && image != null)
			{
				this.a(1);
				this.a[this.e] = width;
				this.b[this.e] = height;
				this.c[this.e] = format;
				this.d[this.e] = Convert.ToBase64String(image, 0, image.Length);
				this.e++;
			}
		}

		// Token: 0x06005F25 RID: 24357 RVA: 0x0035C690 File Offset: 0x0035B690
		internal override void j1(XmpWriter A_0)
		{
			if (this.d != null && this.c != null)
			{
				A_0.Draw("\t\t\t<rdf:Alt>\n");
				for (int i = 0; i < this.e; i++)
				{
					A_0.Draw("\t\t\t\t<rdf:li>\n");
					A_0.BeginDescription("http://ns.adobe.com/xap/1.0/g/img/", "xapGImg");
					A_0.Draw("\t\t\t\t\t<xapGImg:height>" + this.b[i] + "</xapGImg:height>\n");
					A_0.Draw("\t\t\t\t\t<xapGImg:width>" + this.a[i] + "</xapGImg:width>\n");
					A_0.Draw("\t\t\t\t\t<xapGImg:format>" + this.c[i] + "</xapGImg:format>\n");
					A_0.Draw("\t\t\t\t\t<xapGImg:image>" + this.d[i] + "</xapGImg:image>\n");
					A_0.Draw("\t\t\t</rdf:Description>\n");
					A_0.Draw("\t\t\t\t</rdf:li>\n");
				}
				A_0.Draw("\t\t\t</rdf:Alt>\n");
			}
		}

		// Token: 0x06005F26 RID: 24358 RVA: 0x0035C7A8 File Offset: 0x0035B7A8
		private void a(int A_0)
		{
			if (this.d.Length - this.e < A_0)
			{
				int[] destinationArray = new int[this.a.Length * 2];
				int[] destinationArray2 = new int[this.b.Length * 2];
				string[] destinationArray3 = new string[this.c.Length * 2];
				string[] destinationArray4 = new string[this.d.Length * 2];
				Array.Copy(this.a, 0, destinationArray, 0, this.a.Length);
				Array.Copy(this.b, 0, destinationArray2, 0, this.b.Length);
				Array.Copy(this.c, 0, destinationArray3, 0, this.c.Length);
				Array.Copy(this.d, 0, destinationArray4, 0, this.d.Length);
				this.a = destinationArray;
				this.b = destinationArray2;
				this.c = destinationArray3;
				this.d = destinationArray4;
			}
		}

		// Token: 0x040030F5 RID: 12533
		private int[] a;

		// Token: 0x040030F6 RID: 12534
		private int[] b;

		// Token: 0x040030F7 RID: 12535
		private string[] c;

		// Token: 0x040030F8 RID: 12536
		private string[] d;

		// Token: 0x040030F9 RID: 12537
		private int e = 0;
	}
}
