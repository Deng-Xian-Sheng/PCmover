using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002CF RID: 719
	internal struct Triple<T1, T2, T3>
	{
		// Token: 0x06002560 RID: 9568 RVA: 0x0008878C File Offset: 0x0008698C
		internal Triple(T1 first, T2 second, T3 third)
		{
			this._first = first;
			this._second = second;
			this._third = third;
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06002561 RID: 9569 RVA: 0x000887A3 File Offset: 0x000869A3
		public T1 Item1
		{
			get
			{
				return this._first;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06002562 RID: 9570 RVA: 0x000887AB File Offset: 0x000869AB
		public T2 Item2
		{
			get
			{
				return this._second;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06002563 RID: 9571 RVA: 0x000887B3 File Offset: 0x000869B3
		public T3 Item3
		{
			get
			{
				return this._third;
			}
		}

		// Token: 0x04000E14 RID: 3604
		private readonly T1 _first;

		// Token: 0x04000E15 RID: 3605
		private readonly T2 _second;

		// Token: 0x04000E16 RID: 3606
		private readonly T3 _third;
	}
}
