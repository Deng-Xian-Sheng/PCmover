using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000675 RID: 1653
	public class EmbeddedFileResource : Resource
	{
		// Token: 0x06003FF8 RID: 16376 RVA: 0x0021FEF3 File Offset: 0x0021EEF3
		internal EmbeddedFileResource(EmbeddedFile A_0)
		{
			this.q = A_0;
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06003FF9 RID: 16377 RVA: 0x0021FF08 File Offset: 0x0021EF08
		public override int RequiredPdfObjects
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x06003FFA RID: 16378 RVA: 0x0021FF1B File Offset: 0x0021EF1B
		public override void Draw(DocumentWriter writer)
		{
			this.b(writer);
		}

		// Token: 0x06003FFB RID: 16379 RVA: 0x0021FF28 File Offset: 0x0021EF28
		private new void b(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(EmbeddedFileResource.r);
			A_0.WriteText(this.q.FileName);
			A_0.WriteName(EmbeddedFileResource.c);
			A_0.WriteText(this.q.c());
			A_0.WriteName(EmbeddedFileResource.d);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(EmbeddedFileResource.c);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteDictionaryClose();
			if (A_0.s())
			{
				A_0.WriteName(EmbeddedFileResource.a);
				A_0.WriteName(this.q.Relation.ToString());
			}
			A_0.WriteName(EmbeddedFileResource.g);
			A_0.WriteText(this.q.Description);
			A_0.WriteName(Resource.a);
			A_0.WriteName(EmbeddedFileResource.f);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			A_0.WriteBeginObject();
			this.a(A_0);
			A_0.WriteEndObject();
		}

		// Token: 0x06003FFC RID: 16380 RVA: 0x00220048 File Offset: 0x0021F048
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.e);
			if (A_0.Document.Security != null && A_0.Document.Security.a() == b5.b && A_0.Document.Security.d())
			{
				A_0.WriteNumber(this.q.e().Length + 16 + (16 - this.q.e().Length % 16));
			}
			else
			{
				A_0.ai(this.q.e().Length);
			}
			if (A_0.Document.Security != null && A_0.Document.Security.a() == b5.b && A_0.Document.Security.d())
			{
				A_0.WriteName(Resource.c);
				A_0.WriteArrayOpen();
				A_0.WriteName(EmbeddedFileResource.k);
				A_0.WriteName(Resource.d);
				A_0.WriteArrayClose();
				A_0.WriteName(EmbeddedFileResource.l);
				A_0.WriteArrayOpen();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(EmbeddedFileResource.m);
				A_0.WriteName(EmbeddedFileResource.n);
				A_0.WriteDictionaryClose();
				A_0.WriteNull();
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(Resource.c);
				A_0.WriteName(Resource.d);
			}
			if (this.q.MimeType != null)
			{
				string text = this.q.MimeType;
				text = text.Replace("/", "#2F");
				A_0.WriteName(EmbeddedFileResource.p);
				A_0.WriteName(text);
			}
			A_0.WriteName(EmbeddedFileResource.j);
			A_0.WriteDictionaryOpen();
			if (this.q.d() != DateTime.MinValue && this.q.d() != DateTime.MaxValue)
			{
				A_0.WriteName(EmbeddedFileResource.i);
				A_0.WriteText("D:" + this.q.d().ToUniversalTime().ToString("yyyyMMddHHmmssZ"));
			}
			A_0.WriteName(EmbeddedFileResource.o);
			if (A_0.Document.Security != null && A_0.Document.Security.a() == b5.b && A_0.Document.Security.d())
			{
				A_0.WriteNumber(this.q.e().Length + 16 + (16 - this.q.e().Length % 16));
			}
			else
			{
				A_0.ai(this.q.e().Length);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteDictionaryClose();
			if (A_0.Document.Security != null && A_0.Document.Security.a() == b5.b && A_0.Document.Security.d())
			{
				A_0.ad(this.q.e(), this.q.e().Length);
			}
			else
			{
				A_0.WriteStream(this.q.e(), this.q.e().Length);
			}
		}

		// Token: 0x04002298 RID: 8856
		private new static byte[] a = new byte[]
		{
			65,
			70,
			82,
			101,
			108,
			97,
			116,
			105,
			111,
			110,
			115,
			104,
			105,
			112
		};

		// Token: 0x04002299 RID: 8857
		private new static byte[] b = new byte[]
		{
			69,
			109,
			98,
			101,
			100,
			100,
			101,
			100,
			70,
			105,
			108,
			101,
			115
		};

		// Token: 0x0400229A RID: 8858
		private new static byte c = 70;

		// Token: 0x0400229B RID: 8859
		private new static byte[] d = new byte[]
		{
			69,
			70
		};

		// Token: 0x0400229C RID: 8860
		private new static byte[] e = new byte[]
		{
			70,
			83
		};

		// Token: 0x0400229D RID: 8861
		private new static byte[] f = new byte[]
		{
			70,
			105,
			108,
			101,
			115,
			112,
			101,
			99
		};

		// Token: 0x0400229E RID: 8862
		private new static byte[] g = new byte[]
		{
			68,
			101,
			115,
			99
		};

		// Token: 0x0400229F RID: 8863
		private new static byte[] h = new byte[]
		{
			67,
			114,
			101,
			97,
			116,
			105,
			111,
			110,
			68,
			97,
			116,
			101
		};

		// Token: 0x040022A0 RID: 8864
		private new static byte[] i = new byte[]
		{
			77,
			111,
			100,
			68,
			97,
			116,
			101
		};

		// Token: 0x040022A1 RID: 8865
		private static byte[] j = new byte[]
		{
			80,
			97,
			114,
			97,
			109,
			115
		};

		// Token: 0x040022A2 RID: 8866
		private static byte[] k = new byte[]
		{
			67,
			114,
			121,
			112,
			116
		};

		// Token: 0x040022A3 RID: 8867
		private static byte[] l = new byte[]
		{
			68,
			101,
			99,
			111,
			100,
			101,
			80,
			97,
			114,
			109,
			115
		};

		// Token: 0x040022A4 RID: 8868
		private static byte[] m = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x040022A5 RID: 8869
		private static byte[] n = new byte[]
		{
			83,
			116,
			100,
			67,
			70
		};

		// Token: 0x040022A6 RID: 8870
		private static byte[] o = new byte[]
		{
			83,
			105,
			122,
			101
		};

		// Token: 0x040022A7 RID: 8871
		private static byte[] p = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x040022A8 RID: 8872
		private EmbeddedFile q;

		// Token: 0x040022A9 RID: 8873
		private static byte[] r = new byte[]
		{
			85,
			70
		};
	}
}
