using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000076 RID: 118
	internal class cl : Resource
	{
		// Token: 0x060004E7 RID: 1255 RVA: 0x0004FB37 File Offset: 0x0004EB37
		public cl(bg A_0, string A_1, string A_2, int A_3)
		{
			this.a = A_0;
			this.b = A_3;
			this.c = A_1;
			this.d = A_2;
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0004FB60 File Offset: 0x0004EB60
		public override int get_RequiredPdfObjects()
		{
			return 1;
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0004FB74 File Offset: 0x0004EB74
		public override ResourceType get_ResourceType()
		{
			return ResourceType.Default;
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0004FB88 File Offset: 0x0004EB88
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			Certificate certificate = this.a.a();
			writer.ad()[this.b].a(writer.GetObjectNumber());
			writer.ad()[this.b].a(certificate.c());
			writer.ad()[this.b].a(this.a.b());
			writer.ad()[this.b].a(certificate.SignSilently);
			writer.WriteName(cl.g);
			writer.ad()[this.b].b(writer.am());
			writer.Write(new byte[writer.ad()[this.b].g()]);
			writer.WriteName(cl.h);
			writer.ad()[this.b].c(writer.am());
			if (cl.e == null)
			{
				cl.e = new byte[]
				{
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32,
					32
				};
			}
			writer.Write(cl.e);
			if (writer.Document.b() != (CertifyingPermission)0)
			{
				writer.WriteName(cl.m);
				writer.WriteArrayOpen();
				writer.WriteDictionaryOpen();
				writer.WriteName(cl.n);
				writer.WriteDictionaryOpen();
				writer.WriteName(cl.o);
				writer.WriteNumber((int)writer.Document.b());
				writer.WriteName(cl.p);
				writer.WriteName(cl.q);
				writer.WriteName(Resource.a);
				writer.WriteName(cl.n);
				writer.WriteDictionaryClose();
				writer.WriteName(cl.r);
				writer.WriteName(cl.s);
				writer.WriteName(Resource.a);
				writer.WriteName(cl.t);
				writer.WriteDictionaryClose();
				writer.WriteArrayClose();
			}
			writer.WriteName(Resource.a);
			writer.WriteName(cl.i);
			writer.WriteName(cl.j);
			writer.WriteName(cl.k);
			writer.WriteName(Resource.c);
			writer.WriteName(cl.l);
			writer.WriteName(cl.x);
			writer.WriteText("D:" + DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmssZ"));
			writer.WriteName(cl.u);
			writer.WriteText(certificate.SubjectName);
			if (this.c != null && this.c.Length > 0)
			{
				writer.WriteName(cl.v);
				writer.WriteText(this.c);
			}
			if (this.d != null && this.d.Length > 0)
			{
				writer.WriteName(cl.w);
				writer.WriteText(this.d);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0004FEC4 File Offset: 0x0004EEC4
		internal new static byte[] a(byte[] A_0)
		{
			byte[] array = new byte[A_0.Length * 2];
			int num = 0;
			for (int i = 0; i < A_0.Length; i++)
			{
				array[num++] = cl.f[A_0[i] >> 4];
				array[num++] = cl.f[(int)(A_0[i] & 15)];
			}
			return array;
		}

		// Token: 0x040002CF RID: 719
		private new bg a;

		// Token: 0x040002D0 RID: 720
		private new int b;

		// Token: 0x040002D1 RID: 721
		private new string c;

		// Token: 0x040002D2 RID: 722
		private new string d;

		// Token: 0x040002D3 RID: 723
		private new static byte[] e = null;

		// Token: 0x040002D4 RID: 724
		private new static byte[] f = new byte[]
		{
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			97,
			98,
			99,
			100,
			101,
			102
		};

		// Token: 0x040002D5 RID: 725
		private new static byte[] g = new byte[]
		{
			67,
			111,
			110,
			116,
			101,
			110,
			116,
			115
		};

		// Token: 0x040002D6 RID: 726
		private new static byte[] h = new byte[]
		{
			66,
			121,
			116,
			101,
			82,
			97,
			110,
			103,
			101
		};

		// Token: 0x040002D7 RID: 727
		private new static byte[] i = new byte[]
		{
			83,
			105,
			103
		};

		// Token: 0x040002D8 RID: 728
		private static byte[] j = new byte[]
		{
			83,
			117,
			98,
			70,
			105,
			108,
			116,
			101,
			114
		};

		// Token: 0x040002D9 RID: 729
		private static byte[] k = new byte[]
		{
			97,
			100,
			98,
			101,
			46,
			112,
			107,
			99,
			115,
			55,
			46,
			100,
			101,
			116,
			97,
			99,
			104,
			101,
			100
		};

		// Token: 0x040002DA RID: 730
		private static byte[] l = new byte[]
		{
			65,
			100,
			111,
			98,
			101,
			46,
			80,
			80,
			75,
			76,
			105,
			116,
			101
		};

		// Token: 0x040002DB RID: 731
		private static byte[] m = new byte[]
		{
			82,
			101,
			102,
			101,
			114,
			101,
			110,
			99,
			101
		};

		// Token: 0x040002DC RID: 732
		private static byte[] n = new byte[]
		{
			84,
			114,
			97,
			110,
			115,
			102,
			111,
			114,
			109,
			80,
			97,
			114,
			97,
			109,
			115
		};

		// Token: 0x040002DD RID: 733
		private static byte o = 80;

		// Token: 0x040002DE RID: 734
		private static byte p = 86;

		// Token: 0x040002DF RID: 735
		private static byte[] q = new byte[]
		{
			49,
			46,
			50
		};

		// Token: 0x040002E0 RID: 736
		private static byte[] r = new byte[]
		{
			84,
			114,
			97,
			110,
			115,
			102,
			111,
			114,
			109,
			77,
			101,
			116,
			104,
			111,
			100
		};

		// Token: 0x040002E1 RID: 737
		private static byte[] s = new byte[]
		{
			68,
			111,
			99,
			77,
			68,
			80
		};

		// Token: 0x040002E2 RID: 738
		private static byte[] t = new byte[]
		{
			83,
			105,
			103,
			82,
			101,
			102
		};

		// Token: 0x040002E3 RID: 739
		private static byte[] u = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x040002E4 RID: 740
		private static byte[] v = new byte[]
		{
			82,
			101,
			97,
			115,
			111,
			110
		};

		// Token: 0x040002E5 RID: 741
		private static byte[] w = new byte[]
		{
			76,
			111,
			99,
			97,
			116,
			105,
			111,
			110
		};

		// Token: 0x040002E6 RID: 742
		private static byte x = 77;
	}
}
