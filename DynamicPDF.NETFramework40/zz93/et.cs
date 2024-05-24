using System;

namespace zz93
{
	// Token: 0x020000CD RID: 205
	internal class et : d3
	{
		// Token: 0x0600097B RID: 2427 RVA: 0x0007DC6C File Offset: 0x0007CC6C
		internal et(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0007DC7C File Offset: 0x0007CC7C
		private new bool a(int A_0, int A_1)
		{
			if (A_0 <= 165445)
			{
				if (A_0 <= 3034)
				{
					if (A_0 != 1946 && A_0 != 3034)
					{
						goto IL_74;
					}
				}
				else if (A_0 != 3418 && A_0 != 165445)
				{
					goto IL_74;
				}
			}
			else if (A_0 <= 506116087)
			{
				if (A_0 != 442866842 && A_0 != 506116087)
				{
					goto IL_74;
				}
			}
			else if (A_0 != 718642778 && A_0 != 889490394)
			{
				goto IL_74;
			}
			base.l().f(A_1);
			return true;
			IL_74:
			return false;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0007DD04 File Offset: 0x0007CD04
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				int num = base.l().w();
				base.l().ai();
				if (base.l().t())
				{
					if (this.a(base.l().v(), num))
					{
						break;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else
				{
					if (base.l().u())
					{
						int num2 = base.l().v();
						if (num2 <= 3418)
						{
							if (num2 != 1977)
							{
								if (num2 != 3418)
								{
									goto IL_F2;
								}
								break;
							}
							else
							{
								this.cs(base.l().v());
							}
						}
						else
						{
							if (num2 == 11228793)
							{
								break;
							}
							if (num2 == 144937050)
							{
								base.l().f(num);
								break;
							}
							if (num2 != 258605815)
							{
								goto IL_F2;
							}
							break;
						}
						continue;
						IL_F2:
						base.d(base.l().v());
						continue;
						break;
					}
					if (base.l().aa())
					{
						base.r();
					}
				}
			}
		}
	}
}
