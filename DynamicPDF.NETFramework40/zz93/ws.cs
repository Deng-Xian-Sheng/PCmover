using System;

namespace zz93
{
	// Token: 0x02000364 RID: 868
	internal class ws
	{
		// Token: 0x0600252C RID: 9516 RVA: 0x0015CB6D File Offset: 0x0015BB6D
		internal ws()
		{
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x0015CB78 File Offset: 0x0015BB78
		internal void a(ru A_0)
		{
			if (this.a == null)
			{
				this.a = (this.b = new ws.a(A_0));
			}
			else
			{
				ws.a a;
				this.b.a(a = new ws.a(A_0));
				this.b = a;
			}
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x0015CBCC File Offset: 0x0015BBCC
		internal bool a()
		{
			return this.a != null;
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x0015CBEC File Offset: 0x0015BBEC
		internal void a(acm A_0)
		{
			for (ws.a a = this.a; a != null; a = a.b())
			{
				a.a().a(A_0);
			}
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x0015CC24 File Offset: 0x0015BC24
		internal static void a(xd A_0)
		{
			for (xh xh = (xh)A_0.e(); xh != null; xh = (xh)xh.e())
			{
				for (ws.a a = xh.a().a; a != null; a = a.b())
				{
					if (a.a() is xs)
					{
						xs xs = (xs)a.a();
						if (xs.gg())
						{
							xd xd = xs.e();
							if (xd != null)
							{
								ws.a(xd);
							}
						}
						xs.b();
					}
				}
			}
		}

		// Token: 0x04001049 RID: 4169
		private ws.a a;

		// Token: 0x0400104A RID: 4170
		private ws.a b;

		// Token: 0x02000365 RID: 869
		private class a
		{
			// Token: 0x06002531 RID: 9521 RVA: 0x0015CCDA File Offset: 0x0015BCDA
			internal a(ru A_0)
			{
				this.a = A_0;
			}

			// Token: 0x06002532 RID: 9522 RVA: 0x0015CCEC File Offset: 0x0015BCEC
			internal ru a()
			{
				return this.a;
			}

			// Token: 0x06002533 RID: 9523 RVA: 0x0015CD04 File Offset: 0x0015BD04
			internal ws.a b()
			{
				return this.b;
			}

			// Token: 0x06002534 RID: 9524 RVA: 0x0015CD1C File Offset: 0x0015BD1C
			internal void a(ws.a A_0)
			{
				this.b = A_0;
			}

			// Token: 0x0400104B RID: 4171
			private ru a;

			// Token: 0x0400104C RID: 4172
			private ws.a b;
		}
	}
}
