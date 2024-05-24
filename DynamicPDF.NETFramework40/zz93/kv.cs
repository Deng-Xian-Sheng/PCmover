using System;

namespace zz93
{
	// Token: 0x020001A7 RID: 423
	internal class kv : d0
	{
		// Token: 0x06000ED0 RID: 3792 RVA: 0x000B0DB8 File Offset: 0x000AFDB8
		internal kv(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num != 3407)
				{
					if (num != 144877216)
					{
						if (num != 545266181)
						{
							base.c(A_0);
						}
						else if (base.l() == null)
						{
							base.a(A_0.am());
						}
					}
					else if (base.m() == null)
					{
						string text = A_0.au();
						if (text != null)
						{
							base.a(new ig(A_1.a(text.ToCharArray(), 0, text.Length)));
						}
					}
				}
				else if (base.k() == null)
				{
					base.c(A_0.an());
				}
			}
			A_0.ax();
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x000B0E9C File Offset: 0x000AFE9C
		internal override int cn()
		{
			return 220754;
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x000B0EB4 File Offset: 0x000AFEB4
		internal override string co()
		{
			return "kbd";
		}
	}
}
