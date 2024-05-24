using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000080 RID: 128
	internal class cu : IComparable<cu>
	{
		// Token: 0x060005E8 RID: 1512 RVA: 0x000558A5 File Offset: 0x000548A5
		internal cu(int A_0, int A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000558D4 File Offset: 0x000548D4
		internal int b()
		{
			return this.a;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x000558EC File Offset: 0x000548EC
		internal int c()
		{
			return this.b;
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00055904 File Offset: 0x00054904
		internal virtual bool bb()
		{
			return true;
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x00055918 File Offset: 0x00054918
		internal virtual bool ba()
		{
			return false;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0005592C File Offset: 0x0005492C
		internal virtual int a5()
		{
			return -1;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0005593F File Offset: 0x0005493F
		internal virtual void a6(int A_0)
		{
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00055944 File Offset: 0x00054944
		internal virtual bool a7()
		{
			return false;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00055957 File Offset: 0x00054957
		internal virtual void a8(bool A_0)
		{
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0005595C File Offset: 0x0005495C
		internal virtual bool bn()
		{
			return false;
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0005596F File Offset: 0x0005496F
		internal virtual void bo(bool A_0)
		{
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00055974 File Offset: 0x00054974
		internal virtual ab6 bl()
		{
			return null;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00055988 File Offset: 0x00054988
		internal int d()
		{
			return this.c;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000559A0 File Offset: 0x000549A0
		internal void b(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000559AA File Offset: 0x000549AA
		internal virtual void a9(DocumentWriter A_0, int A_1)
		{
			throw new GeneratorException("Method not implemented");
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000559B8 File Offset: 0x000549B8
		public int CompareTo(cu other)
		{
			return (this.a > other.a) ? 1 : ((this.a < other.a) ? -1 : 0);
		}

		// Token: 0x0400032A RID: 810
		private int a = 0;

		// Token: 0x0400032B RID: 811
		private int b = 0;

		// Token: 0x0400032C RID: 812
		private int c = -1;
	}
}
