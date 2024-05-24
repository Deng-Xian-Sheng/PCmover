using System;

namespace zz93
{
	// Token: 0x020004BE RID: 1214
	internal class afr
	{
		// Token: 0x060031D8 RID: 12760 RVA: 0x001BE578 File Offset: 0x001BD578
		internal afr(agd A_0, l2 A_1)
		{
			this.a[this.c] = A_0;
			this.b[this.c] = A_1;
			this.e[this.c] = 0;
			this.f[this.c] = A_0.a();
			this.c++;
		}

		// Token: 0x060031D9 RID: 12761 RVA: 0x001BE634 File Offset: 0x001BD634
		internal void a(agd A_0, l2 A_1)
		{
			if (this.c == this.a.Length && this.c == this.b.Length)
			{
				this.a();
			}
			this.a[this.c] = A_0;
			this.b[this.c] = A_1;
			this.e[this.c] = 0;
			this.f[this.c] = A_0.a();
			this.c++;
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x001BE6C1 File Offset: 0x001BD6C1
		internal void a(int A_0)
		{
			this.a[A_0] = null;
			this.b[A_0] = null;
			this.e[A_0] = 0;
			this.f[A_0] = 0;
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x001BE6E8 File Offset: 0x001BD6E8
		internal void a(float A_0, int A_1)
		{
			this.d[A_1] = A_0;
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x001BE6F4 File Offset: 0x001BD6F4
		private void a()
		{
			agd[] destinationArray = new agd[this.a.Length * 2];
			Array.Copy(this.a, 0, destinationArray, 0, this.a.Length);
			this.a = destinationArray;
			l2[] destinationArray2 = new l2[this.b.Length * 2];
			Array.Copy(this.b, 0, destinationArray2, 0, this.b.Length);
			this.b = destinationArray2;
			float[] destinationArray3 = new float[this.d.Length * 2];
			Array.Copy(this.d, 0, destinationArray3, 0, this.d.Length);
			this.d = destinationArray3;
			int[] destinationArray4 = new int[this.e.Length * 2];
			Array.Copy(this.e, 0, destinationArray4, 0, this.e.Length);
			this.e = destinationArray4;
			int[] destinationArray5 = new int[this.f.Length * 2];
			Array.Copy(this.f, 0, destinationArray5, 0, this.f.Length);
			this.f = destinationArray5;
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x001BE7EC File Offset: 0x001BD7EC
		internal agd[] b()
		{
			return this.a;
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x001BE804 File Offset: 0x001BD804
		internal void a(agd[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060031DF RID: 12767 RVA: 0x001BE810 File Offset: 0x001BD810
		internal l2[] c()
		{
			return this.b;
		}

		// Token: 0x060031E0 RID: 12768 RVA: 0x001BE828 File Offset: 0x001BD828
		internal void a(l2[] A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060031E1 RID: 12769 RVA: 0x001BE834 File Offset: 0x001BD834
		internal float[] d()
		{
			return this.d;
		}

		// Token: 0x060031E2 RID: 12770 RVA: 0x001BE84C File Offset: 0x001BD84C
		internal void a(float[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060031E3 RID: 12771 RVA: 0x001BE858 File Offset: 0x001BD858
		internal int[] e()
		{
			return this.e;
		}

		// Token: 0x060031E4 RID: 12772 RVA: 0x001BE870 File Offset: 0x001BD870
		internal void a(int[] A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060031E5 RID: 12773 RVA: 0x001BE87C File Offset: 0x001BD87C
		internal int[] f()
		{
			return this.f;
		}

		// Token: 0x060031E6 RID: 12774 RVA: 0x001BE894 File Offset: 0x001BD894
		internal void b(int[] A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060031E7 RID: 12775 RVA: 0x001BE8A0 File Offset: 0x001BD8A0
		internal float[] g()
		{
			return this.g;
		}

		// Token: 0x060031E8 RID: 12776 RVA: 0x001BE8B8 File Offset: 0x001BD8B8
		internal void b(float[] A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060031E9 RID: 12777 RVA: 0x001BE8C4 File Offset: 0x001BD8C4
		internal int[] h()
		{
			return this.h();
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x001BE8DC File Offset: 0x001BD8DC
		internal void c(int[] A_0)
		{
			this.h = A_0;
		}

		// Token: 0x04001756 RID: 5974
		private agd[] a = new agd[1];

		// Token: 0x04001757 RID: 5975
		private l2[] b = new l2[1];

		// Token: 0x04001758 RID: 5976
		private int c = 0;

		// Token: 0x04001759 RID: 5977
		private float[] d = new float[1];

		// Token: 0x0400175A RID: 5978
		private int[] e = new int[1];

		// Token: 0x0400175B RID: 5979
		private int[] f = new int[1];

		// Token: 0x0400175C RID: 5980
		private float[] g = new float[1];

		// Token: 0x0400175D RID: 5981
		private int[] h = new int[1];
	}
}
