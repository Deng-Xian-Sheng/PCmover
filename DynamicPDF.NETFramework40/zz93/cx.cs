using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000083 RID: 131
	internal class cx : cu
	{
		// Token: 0x0600060C RID: 1548 RVA: 0x00055DE6 File Offset: 0x00054DE6
		internal cx(int A_0, int A_1, int A_2, int A_3) : base(A_2, A_3)
		{
			this.e = A_0;
			this.f = A_1;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00055E10 File Offset: 0x00054E10
		internal int a()
		{
			return this.e;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00055E28 File Offset: 0x00054E28
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00055E34 File Offset: 0x00054E34
		internal override int a5()
		{
			return this.f;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00055E4C File Offset: 0x00054E4C
		internal override void a6(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00055E58 File Offset: 0x00054E58
		internal override bool a7()
		{
			return true;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00055E6C File Offset: 0x00054E6C
		internal override void a9(DocumentWriter A_0, int A_1)
		{
			bool flag = this.f != A_1;
			if (flag)
			{
				A_0.WriteDictionaryOpen();
				A_0.WriteName(cx.a);
				A_0.WriteName(cx.b);
				A_0.WriteName(cx.c);
				A_0.WriteReferenceShallow(A_0.Document.j().i().a(this.f).a());
				A_0.WriteName(cx.d);
				A_0.WriteNumber(this.e);
				A_0.WriteDictionaryClose();
			}
			else
			{
				A_0.WriteNumber(this.e);
			}
		}

		// Token: 0x04000336 RID: 822
		private static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04000337 RID: 823
		private static byte[] b = new byte[]
		{
			77,
			67,
			82
		};

		// Token: 0x04000338 RID: 824
		private static byte[] c = new byte[]
		{
			80,
			103
		};

		// Token: 0x04000339 RID: 825
		private static byte[] d = new byte[]
		{
			77,
			67,
			73,
			68
		};

		// Token: 0x0400033A RID: 826
		private int e = 0;

		// Token: 0x0400033B RID: 827
		private int f = -1;
	}
}
