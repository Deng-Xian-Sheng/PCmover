using System;

namespace zz93
{
	// Token: 0x0200026E RID: 622
	internal class qc : d0
	{
		// Token: 0x06001BFE RID: 7166 RVA: 0x00120D94 File Offset: 0x0011FD94
		internal qc(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 8554053)
				{
					if (num != 3407)
					{
						if (num != 8545886)
						{
							if (num != 8554053)
							{
								goto IL_11E;
							}
							this.a = A_0.@as();
						}
						else
						{
							this.b = A_0.@as();
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 144877216)
				{
					if (num != 545266181)
					{
						if (num != 956344229)
						{
							goto IL_11E;
						}
						this.c = true;
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
				continue;
				IL_11E:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x06001BFF RID: 7167 RVA: 0x00120EE4 File Offset: 0x0011FEE4
		internal override int cn()
		{
			return 23684646;
		}

		// Token: 0x06001C00 RID: 7168 RVA: 0x00120EFC File Offset: 0x0011FEFC
		internal override string co()
		{
			return "textArea";
		}

		// Token: 0x06001C01 RID: 7169 RVA: 0x00120F14 File Offset: 0x0011FF14
		internal bool a()
		{
			return this.c;
		}

		// Token: 0x06001C02 RID: 7170 RVA: 0x00120F2C File Offset: 0x0011FF2C
		internal int b()
		{
			return this.a;
		}

		// Token: 0x06001C03 RID: 7171 RVA: 0x00120F44 File Offset: 0x0011FF44
		internal int c()
		{
			return this.b;
		}

		// Token: 0x04000CA0 RID: 3232
		private int a = 20;

		// Token: 0x04000CA1 RID: 3233
		private int b = 2;

		// Token: 0x04000CA2 RID: 3234
		private new bool c = false;
	}
}
