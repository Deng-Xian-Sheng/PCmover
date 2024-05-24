using System;
using System.Text;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000923 RID: 2339
	public class XmpWriter
	{
		// Token: 0x06005F27 RID: 24359 RVA: 0x0035C88E File Offset: 0x0035B88E
		public XmpWriter(DocumentWriter writer)
		{
			this.a = writer;
		}

		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x06005F28 RID: 24360 RVA: 0x0035C8C4 File Offset: 0x0035B8C4
		public string Producer
		{
			get
			{
				return this.a.Document.Producer;
			}
		}

		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06005F29 RID: 24361 RVA: 0x0035C8E8 File Offset: 0x0035B8E8
		public string Author
		{
			get
			{
				return this.a.Document.Author;
			}
		}

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06005F2A RID: 24362 RVA: 0x0035C90C File Offset: 0x0035B90C
		public string Title
		{
			get
			{
				return this.a.Document.Title;
			}
		}

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06005F2B RID: 24363 RVA: 0x0035C930 File Offset: 0x0035B930
		public int TotalPages
		{
			get
			{
				return this.a.Document.Pages.Count;
			}
		}

		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06005F2C RID: 24364 RVA: 0x0035C958 File Offset: 0x0035B958
		public string Keywords
		{
			get
			{
				return this.a.Document.Keywords;
			}
		}

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06005F2D RID: 24365 RVA: 0x0035C97C File Offset: 0x0035B97C
		public DateTime Date
		{
			get
			{
				return this.a.CreationDate.ToUniversalTime();
			}
		}

		// Token: 0x06005F2E RID: 24366 RVA: 0x0035C9A4 File Offset: 0x0035B9A4
		internal string d()
		{
			return this.a.Document.Creator;
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06005F2F RID: 24367 RVA: 0x0035C9C8 File Offset: 0x0035B9C8
		public float PdfVersion
		{
			get
			{
				float result;
				switch (this.a.Document.PdfVersion)
				{
				case ceTe.DynamicPDF.PdfVersion.v1_3:
					result = 1.3f;
					break;
				case ceTe.DynamicPDF.PdfVersion.v1_4:
					result = 1.4f;
					break;
				case ceTe.DynamicPDF.PdfVersion.v1_5:
					result = 1.5f;
					break;
				case ceTe.DynamicPDF.PdfVersion.v1_6:
					result = 1.6f;
					break;
				case ceTe.DynamicPDF.PdfVersion.v1_7:
					result = 1.7f;
					break;
				default:
					result = 1.4f;
					break;
				}
				return result;
			}
		}

		// Token: 0x06005F30 RID: 24368 RVA: 0x0035CA38 File Offset: 0x0035BA38
		internal afa e()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			PageList pages = this.a.Document.Pages;
			foreach (object obj in pages)
			{
				Page page = (Page)obj;
				PageDimensions dimensions = page.Dimensions;
				if (num3 < dimensions.Width * dimensions.Height)
				{
					num = dimensions.Width;
					num2 = dimensions.Height;
					num3 = num * num2;
				}
			}
			return new afa(num, num2, "points");
		}

		// Token: 0x06005F31 RID: 24369 RVA: 0x0035CB10 File Offset: 0x0035BB10
		internal void f()
		{
			this.Draw("<?xpacket begin='﻿' id='W5M0MpCehiHzreSzNTczkc9d'?>\n");
			this.Draw("<x:xmpmeta xmlns:x='adobe:ns:meta/'>\n");
			this.Draw(" <rdf:RDF xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#'>\n");
		}

		// Token: 0x06005F32 RID: 24370 RVA: 0x0035CB37 File Offset: 0x0035BB37
		internal void g()
		{
			this.Draw(" </rdf:RDF>\n");
			this.Draw("</x:xmpmeta>\n");
			this.c();
			this.Draw("\n<?xpacket end='w'?>");
		}

		// Token: 0x06005F33 RID: 24371 RVA: 0x0035CB68 File Offset: 0x0035BB68
		internal DocumentWriter h()
		{
			return this.a;
		}

		// Token: 0x06005F34 RID: 24372 RVA: 0x0035CB80 File Offset: 0x0035BB80
		public void BeginDescription(string urlnamespace, string alias, string about)
		{
			this.Draw(string.Concat(new string[]
			{
				"\t<rdf:Description rdf:about='",
				about,
				"' xmlns:",
				alias,
				"='",
				urlnamespace,
				"'>\n"
			}));
		}

		// Token: 0x06005F35 RID: 24373 RVA: 0x0035CBD0 File Offset: 0x0035BBD0
		public void BeginDescription(string urlnamespace, string alias)
		{
			this.Draw(string.Concat(new string[]
			{
				"\t\t\t<rdf:Description xmlns:",
				alias,
				"='",
				urlnamespace,
				"'>\n"
			}));
		}

		// Token: 0x06005F36 RID: 24374 RVA: 0x0035CC12 File Offset: 0x0035BC12
		public void BeginDescription()
		{
			this.Draw("\t\t\t<rdf:Description>\n");
		}

		// Token: 0x06005F37 RID: 24375 RVA: 0x0035CC21 File Offset: 0x0035BC21
		public void EndDescription()
		{
			this.Draw("\t</rdf:Description>\n");
			this.a();
		}

		// Token: 0x06005F38 RID: 24376 RVA: 0x0035CC38 File Offset: 0x0035BC38
		public byte[] ToUtf8(string text)
		{
			return Encoding.UTF8.GetBytes(text);
		}

		// Token: 0x06005F39 RID: 24377 RVA: 0x0035CC58 File Offset: 0x0035BC58
		public void Draw(string text)
		{
			byte[] array = this.ToUtf8(text);
			int num = array.Length;
			this.a(num);
			Array.Copy(array, 0, this.c, this.b, num);
			this.b += num;
		}

		// Token: 0x06005F3A RID: 24378 RVA: 0x0035CCA0 File Offset: 0x0035BCA0
		public void Draw(bool val)
		{
			if (val)
			{
				this.Draw("True");
			}
			else
			{
				this.Draw("False");
			}
		}

		// Token: 0x06005F3B RID: 24379 RVA: 0x0035CCD0 File Offset: 0x0035BCD0
		public void Draw(DateTime date)
		{
			this.Draw(x6.a(date));
		}

		// Token: 0x06005F3C RID: 24380 RVA: 0x0035CCE0 File Offset: 0x0035BCE0
		public void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(XmpWriter.e);
			writer.WriteName(XmpWriter.f);
			writer.WriteName(XmpWriter.g);
			writer.WriteName(XmpWriter.h);
			if (writer.Document.Security != null && !writer.Document.Security.c())
			{
				writer.WriteName(XmpWriter.k);
				writer.WriteArrayOpen();
				writer.WriteName(XmpWriter.j);
				writer.WriteArrayClose();
			}
			if (writer.Document.Security == null || writer.Document.Security.c())
			{
				writer.WriteName(XmpWriter.i);
				writer.ai(this.b);
				writer.WriteDictionaryClose();
				writer.WriteStream(this.c, this.b);
			}
			else
			{
				writer.WriteName(XmpWriter.i);
				writer.WriteNumber(this.b);
				writer.WriteDictionaryClose();
				writer.af(this.c, this.b);
			}
			writer.WriteEndObject();
		}

		// Token: 0x06005F3D RID: 24381 RVA: 0x0035CE14 File Offset: 0x0035BE14
		private void c()
		{
			int num = 2048;
			this.a(num);
			for (int i = 1; i < num; i++)
			{
				if (i % 101 == 0)
				{
					this.a();
				}
				else
				{
					this.c[this.b++] = 32;
				}
			}
		}

		// Token: 0x06005F3E RID: 24382 RVA: 0x0035CE78 File Offset: 0x0035BE78
		private void a(int A_0)
		{
			while (this.d - this.b < A_0)
			{
				this.b();
			}
		}

		// Token: 0x06005F3F RID: 24383 RVA: 0x0035CEA8 File Offset: 0x0035BEA8
		private void b()
		{
			this.d *= 2;
			byte[] destinationArray = new byte[this.d];
			Array.Copy(this.c, 0, destinationArray, 0, this.c.Length);
			this.c = destinationArray;
		}

		// Token: 0x06005F40 RID: 24384 RVA: 0x0035CEF0 File Offset: 0x0035BEF0
		private void a()
		{
			this.a(1);
			this.c[this.b++] = 10;
		}

		// Token: 0x040030FA RID: 12538
		private DocumentWriter a;

		// Token: 0x040030FB RID: 12539
		private int b = 0;

		// Token: 0x040030FC RID: 12540
		private byte[] c = new byte[1024];

		// Token: 0x040030FD RID: 12541
		private int d = 1024;

		// Token: 0x040030FE RID: 12542
		private static byte[] e = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x040030FF RID: 12543
		private static byte[] f = new byte[]
		{
			77,
			101,
			116,
			97,
			100,
			97,
			116,
			97
		};

		// Token: 0x04003100 RID: 12544
		private static byte[] g = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x04003101 RID: 12545
		private static byte[] h = new byte[]
		{
			88,
			77,
			76
		};

		// Token: 0x04003102 RID: 12546
		private static byte[] i = new byte[]
		{
			76,
			101,
			110,
			103,
			116,
			104
		};

		// Token: 0x04003103 RID: 12547
		private static byte[] j = new byte[]
		{
			67,
			114,
			121,
			112,
			116
		};

		// Token: 0x04003104 RID: 12548
		private static byte[] k = new byte[]
		{
			70,
			105,
			108,
			116,
			101,
			114
		};
	}
}
