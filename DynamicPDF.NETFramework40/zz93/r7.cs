using System;

namespace zz93
{
	// Token: 0x020002BB RID: 699
	internal struct r7 : IComparable
	{
		// Token: 0x06002020 RID: 8224 RVA: 0x0013C4F3 File Offset: 0x0013B4F3
		internal r7(string A_0, string A_1, int A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x06002021 RID: 8225 RVA: 0x0013C50C File Offset: 0x0013B50C
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x0013C524 File Offset: 0x0013B524
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06002023 RID: 8227 RVA: 0x0013C53C File Offset: 0x0013B53C
		internal int c()
		{
			return this.c;
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x0013C554 File Offset: 0x0013B554
		public int CompareTo(object obj)
		{
			return this.a.CompareTo(((r7)obj).a());
		}

		// Token: 0x04000DEA RID: 3562
		private string a;

		// Token: 0x04000DEB RID: 3563
		private string b;

		// Token: 0x04000DEC RID: 3564
		private int c;
	}
}
