using System;
using System.Text;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000065 RID: 101
	internal abstract class b6
	{
		// Token: 0x0600043B RID: 1083 RVA: 0x00047DC4 File Offset: 0x00046DC4
		internal b6()
		{
		}

		// Token: 0x0600043C RID: 1084
		internal abstract byte[] ar(long A_0, int A_1);

		// Token: 0x0600043D RID: 1085 RVA: 0x00047DD8 File Offset: 0x00046DD8
		internal static b6 a(abj A_0, string A_1, ab7 A_2, bool A_3)
		{
			abw abw = null;
			bool flag = false;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 22)
				{
					if (num == 111594775)
					{
						if (((abu)abk.c()).j8() != 332400384)
						{
							throw new PdfParsingException("Document can not be decrypted. Unrecognized encryption filter.");
						}
						if (abw != null)
						{
							return b6.a(abw, A_1, A_2, A_0, A_3);
						}
						flag = true;
					}
				}
				else
				{
					abw = (abw)abk.c();
					if (flag)
					{
						return b6.a(abw, A_1, A_2, A_0, A_3);
					}
				}
			}
			throw new PdfParsingException("Document can not be decrypted. Invalid encryption dictionary.");
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00047EA4 File Offset: 0x00046EA4
		internal cd b()
		{
			return this.g;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00047EBC File Offset: 0x00046EBC
		internal void a(cd A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06000440 RID: 1088
		internal abstract SecurityInfo aq();

		// Token: 0x06000441 RID: 1089 RVA: 0x00047EC8 File Offset: 0x00046EC8
		internal static b6 a(abw A_0, string A_1, ab7 A_2, abj A_3, bool A_4)
		{
			switch (A_0.kd())
			{
			case 1:
				return new ach(A_3, A_1, A_2, A_4);
			case 2:
				return new aar(A_3, A_1, A_2, A_4);
			case 4:
				b6.a(A_3);
				if (b6.d == b6.e && b6.e == "StdCF")
				{
					string text = b6.a(A_3, "StdCF");
					if (text != null)
					{
						if (text == "V2")
						{
							return new aar(A_3, A_1, A_2, A_4);
						}
						if (text == "AESV2")
						{
							return new b7(A_3, A_1, A_2, A_4);
						}
					}
					throw new PdfParsingException("Document can not be decrypted. Unrecognized algorithm.");
				}
				if (b6.d == b6.e && b6.d == "Identity" && b6.f == "StdCF")
				{
					string text = b6.a(A_3, b6.f);
					if (text != null)
					{
						if (text == "AESV2")
						{
							b7 b = new b7(A_3, A_1, A_2, A_4);
							b.au(true);
							return b;
						}
					}
					throw new PdfParsingException("Document can not be decrypted. Unrecognized algorithm.");
				}
				break;
			case 5:
				b6.a(A_3);
				if (b6.d == b6.e && b6.e == "StdCF")
				{
					string text = b6.a(A_3, "StdCF");
					if (text != null)
					{
						if (text == "AESV3")
						{
							return new b8(A_3, A_1, A_4);
						}
					}
					throw new PdfParsingException("Document can not be decrypted. Unrecognized algorithm.");
				}
				if (b6.d == b6.e && b6.d == "Identity" && b6.f == "StdCF")
				{
					string text = b6.a(A_3, b6.f);
					if (text != null)
					{
						if (text == "AESV3")
						{
							b8 b2 = new b8(A_3, A_1, A_4);
							b2.au(true);
							return b2;
						}
					}
					throw new PdfParsingException("Document can not be decrypted. Unrecognized algorithm.");
				}
				break;
			}
			throw new PdfParsingException("Document can not be decrypted. Unrecognized algorithm.");
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00048138 File Offset: 0x00047138
		private static void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 20870)
				{
					if (num != 5196614)
					{
						if (num == 5196934)
						{
							b6.d = ((abu)abk.c()).j9();
						}
					}
					else
					{
						b6.e = ((abu)abk.c()).j9();
					}
				}
				else
				{
					b6.f = ((abu)abk.c()).j9();
				}
			}
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000481D0 File Offset: 0x000471D0
		internal byte[] b(string A_0)
		{
			byte[] array = new byte[32];
			byte[] bytes = b6.b.GetBytes(A_0);
			Array.Copy(bytes, array, bytes.Length);
			Array.Copy(b6.c, 0, array, bytes.Length, 32 - bytes.Length);
			return array;
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00048218 File Offset: 0x00047218
		internal static byte[] a()
		{
			return b6.c;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00048230 File Offset: 0x00047230
		internal bool d(byte[] A_0, byte[] A_1)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if (A_0[i] != A_1[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00048268 File Offset: 0x00047268
		private static string a(abj A_0, string A_1)
		{
			abj abj = null;
			abk abk;
			for (abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j9() == "CF")
				{
					abj = (abj)abk.c();
					break;
				}
			}
			abk = abj.l();
			while (abk != null)
			{
				if (abk.a().j9() == A_1)
				{
					for (abk = ((abj)abk.c()).l(); abk != null; abk = abk.d())
					{
						int num = abk.a().j8();
						if (num == 12685)
						{
							return ((abu)abk.c()).j9();
						}
					}
				}
				else
				{
					abk = abk.d();
				}
			}
			throw new PdfParsingException("Document is encrypted with an unsupported algorithm.");
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x0004835C File Offset: 0x0004735C
		internal virtual bool @as()
		{
			return true;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00048370 File Offset: 0x00047370
		internal virtual bool at()
		{
			return false;
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00048383 File Offset: 0x00047383
		internal virtual void au(bool A_0)
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00048388 File Offset: 0x00047388
		internal virtual int av(ref byte[] A_0, int A_1, int A_2, byte[] A_3)
		{
			return 0;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0004839C File Offset: 0x0004739C
		internal string c()
		{
			return "StdCF";
		}

		// Token: 0x04000280 RID: 640
		private const string a = "StdCF";

		// Token: 0x04000281 RID: 641
		private static Encoding b = Encoding.ASCII;

		// Token: 0x04000282 RID: 642
		private static byte[] c = new byte[]
		{
			40,
			191,
			78,
			94,
			78,
			117,
			138,
			65,
			100,
			0,
			78,
			86,
			byte.MaxValue,
			250,
			1,
			8,
			46,
			46,
			0,
			182,
			208,
			104,
			62,
			128,
			47,
			12,
			169,
			254,
			100,
			83,
			105,
			122
		};

		// Token: 0x04000283 RID: 643
		private static string d;

		// Token: 0x04000284 RID: 644
		private static string e;

		// Token: 0x04000285 RID: 645
		private static string f;

		// Token: 0x04000286 RID: 646
		private cd g = cd.d;
	}
}
