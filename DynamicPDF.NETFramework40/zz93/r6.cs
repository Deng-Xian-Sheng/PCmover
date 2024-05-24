using System;

namespace zz93
{
	// Token: 0x020002BA RID: 698
	internal struct r6 : IComparable
	{
		// Token: 0x0600201A RID: 8218 RVA: 0x0013C423 File Offset: 0x0013B423
		internal r6(string A_0, string A_1, r9 A_2, string A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x0013C444 File Offset: 0x0013B444
		internal string a()
		{
			return this.a;
		}

		// Token: 0x0600201C RID: 8220 RVA: 0x0013C45C File Offset: 0x0013B45C
		internal string b()
		{
			return this.b;
		}

		// Token: 0x0600201D RID: 8221 RVA: 0x0013C474 File Offset: 0x0013B474
		internal r9 c()
		{
			return this.c;
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x0013C48C File Offset: 0x0013B48C
		internal string d()
		{
			return this.d;
		}

		// Token: 0x0600201F RID: 8223 RVA: 0x0013C4A4 File Offset: 0x0013B4A4
		public int CompareTo(object obj)
		{
			int num = this.a.CompareTo(((r6)obj).a());
			if (num != 0)
			{
				num = this.b.CompareTo(((r6)obj).b());
			}
			return num;
		}

		// Token: 0x04000DE6 RID: 3558
		private string a;

		// Token: 0x04000DE7 RID: 3559
		private string b;

		// Token: 0x04000DE8 RID: 3560
		private r9 c;

		// Token: 0x04000DE9 RID: 3561
		private string d;
	}
}
