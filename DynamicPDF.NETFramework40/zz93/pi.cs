using System;

namespace zz93
{
	// Token: 0x02000250 RID: 592
	internal class pi : d0
	{
		// Token: 0x06001B0F RID: 6927 RVA: 0x0011917C File Offset: 0x0011817C
		internal pi(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num != 3407)
					{
						if (num != 2163680)
						{
							if (num != 144877216)
							{
								goto IL_133;
							}
							if (base.m() == null)
							{
								string text = A_0.au();
								if (text != null)
								{
									base.a(new ig(A_1.a(text.ToCharArray(), 0, text.Length)));
								}
							}
						}
						else if (this.b == -2147483648)
						{
							this.b = A_0.@as();
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 258710679)
				{
					if (num != 545266181)
					{
						if (num != 956344229)
						{
							goto IL_133;
						}
						this.a = true;
					}
					else if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else
				{
					this.c = true;
				}
				continue;
				IL_133:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x001192E0 File Offset: 0x001182E0
		internal override int cn()
		{
			return 86147604;
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x001192F8 File Offset: 0x001182F8
		internal override string co()
		{
			return "select";
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x00119310 File Offset: 0x00118310
		internal int a()
		{
			int result;
			if (this.b == -2147483648)
			{
				if (this.c)
				{
					result = 4;
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x00119354 File Offset: 0x00118354
		internal bool b()
		{
			return this.b != int.MinValue;
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x00119380 File Offset: 0x00118380
		internal bool c()
		{
			return this.a;
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x00119398 File Offset: 0x00118398
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x04000C3F RID: 3135
		private bool a = false;

		// Token: 0x04000C40 RID: 3136
		private int b = int.MinValue;

		// Token: 0x04000C41 RID: 3137
		private new bool c = false;
	}
}
