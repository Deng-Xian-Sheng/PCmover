using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000082 RID: 130
	internal class cw : cu
	{
		// Token: 0x06000600 RID: 1536 RVA: 0x00055BBE File Offset: 0x00054BBE
		internal cw(int A_0, int A_1) : base(A_0, A_1)
		{
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00055BE0 File Offset: 0x00054BE0
		internal cw(int A_0, int A_1, Resource A_2, int A_3) : base(A_0, A_1)
		{
			this.e = A_2;
			this.f = A_3;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00055C14 File Offset: 0x00054C14
		internal Resource a()
		{
			return this.e;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00055C2C File Offset: 0x00054C2C
		internal void a(Resource A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00055C38 File Offset: 0x00054C38
		internal override int a5()
		{
			return this.f;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00055C50 File Offset: 0x00054C50
		internal override void a6(int A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00055C5C File Offset: 0x00054C5C
		internal override bool a7()
		{
			return this.g;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00055C74 File Offset: 0x00054C74
		internal override void a8(bool A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00055C80 File Offset: 0x00054C80
		internal override void a9(DocumentWriter A_0, int A_1)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(cw.a);
			A_0.WriteName(cw.b);
			A_0.WriteName(cw.c);
			if (A_0.Document.j().i().a(this.e.b()) != null)
			{
				A_0.WriteReferenceShallow(A_0.Document.j().i().a(this.e.b()).a());
			}
			if (this.f != A_1)
			{
				A_0.WriteName(cw.d);
				A_0.WriteReferenceShallow(A_0.Document.j().i().a(this.f).a());
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00055D58 File Offset: 0x00054D58
		internal override bool ba()
		{
			return true;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00055D6C File Offset: 0x00054D6C
		internal virtual bool bm(int A_0)
		{
			return false;
		}

		// Token: 0x0400032F RID: 815
		private static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04000330 RID: 816
		private static byte[] b = new byte[]
		{
			79,
			66,
			74,
			82
		};

		// Token: 0x04000331 RID: 817
		internal static byte[] c = new byte[]
		{
			79,
			98,
			106
		};

		// Token: 0x04000332 RID: 818
		private static byte[] d = new byte[]
		{
			80,
			103
		};

		// Token: 0x04000333 RID: 819
		private Resource e = null;

		// Token: 0x04000334 RID: 820
		private int f = -1;

		// Token: 0x04000335 RID: 821
		private bool g = false;
	}
}
