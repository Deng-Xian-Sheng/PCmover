using System;

namespace zz93
{
	// Token: 0x02000204 RID: 516
	internal class ne : IComparable<ne>
	{
		// Token: 0x0600177F RID: 6015 RVA: 0x000FAB38 File Offset: 0x000F9B38
		internal ne()
		{
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x000FAB54 File Offset: 0x000F9B54
		internal ne(k0 A_0)
		{
			this.e = (nt)A_0;
			this.a = A_0.d1();
			this.b = this.e.h();
			this.c = ((n5)A_0.db()).z();
			this.d = A_0.ar();
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x000FABC4 File Offset: 0x000F9BC4
		internal int a()
		{
			return this.a;
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x000FABDC File Offset: 0x000F9BDC
		internal int b()
		{
			return this.b;
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x000FABF4 File Offset: 0x000F9BF4
		internal int c()
		{
			return this.c;
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x000FAC0C File Offset: 0x000F9C0C
		internal x5 d()
		{
			return this.d;
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x000FAC24 File Offset: 0x000F9C24
		internal void a(x5 A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x000FAC30 File Offset: 0x000F9C30
		internal nt e()
		{
			return this.e;
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x000FAC48 File Offset: 0x000F9C48
		public int CompareTo(ne cus)
		{
			return (this.a == cus.a) ? ((this.c > cus.c) ? 1 : ((this.c < cus.c) ? -1 : 0)) : ((this.a > cus.a) ? 1 : ((this.a < cus.a) ? -1 : 0));
		}

		// Token: 0x04000AB2 RID: 2738
		private int a;

		// Token: 0x04000AB3 RID: 2739
		private int b;

		// Token: 0x04000AB4 RID: 2740
		private int c = 1;

		// Token: 0x04000AB5 RID: 2741
		private x5 d;

		// Token: 0x04000AB6 RID: 2742
		private nt e = null;
	}
}
