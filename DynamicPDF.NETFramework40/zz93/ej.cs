using System;

namespace zz93
{
	// Token: 0x020000C3 RID: 195
	internal class ej : d0
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x0007B2EF File Offset: 0x0007A2EF
		internal ej()
		{
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x0007B30F File Offset: 0x0007A30F
		internal ej(kg A_0, ij A_1)
		{
			this.a(A_0, A_1);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x0007B338 File Offset: 0x0007A338
		internal void a(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 144877216)
				{
					if (num != 3407)
					{
						if (num != 6898202)
						{
							if (num != 144877216)
							{
								goto IL_139;
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
						else if (this.b == null)
						{
							this.b = A_0.ao();
						}
					}
					else if (base.k() == null)
					{
						base.c(A_0.an());
					}
				}
				else if (num != 545266181)
				{
					if (num != 677666251)
					{
						if (num != 1617181893)
						{
							goto IL_139;
						}
						if (this.c == null)
						{
							this.c = A_0.aq();
						}
					}
					else if (this.a == null)
					{
						this.a = A_0.ao();
					}
				}
				else if (base.l() == null)
				{
					base.a(A_0.am());
				}
				continue;
				IL_139:
				base.c(A_0);
			}
			A_0.ax();
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x0007B4A0 File Offset: 0x0007A4A0
		internal string a()
		{
			return this.a;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x0007B4B8 File Offset: 0x0007A4B8
		internal string b()
		{
			return this.b;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0007B4D0 File Offset: 0x0007A4D0
		internal string c()
		{
			return this.c;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0007B4E8 File Offset: 0x0007A4E8
		internal gn d()
		{
			return this.d;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0007B500 File Offset: 0x0007A500
		internal void a(gn A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x0007B50C File Offset: 0x0007A50C
		internal override int cn()
		{
			return 11228793;
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x0007B524 File Offset: 0x0007A524
		internal override string co()
		{
			return "body";
		}

		// Token: 0x040004B5 RID: 1205
		private string a = null;

		// Token: 0x040004B6 RID: 1206
		private string b;

		// Token: 0x040004B7 RID: 1207
		private new string c = null;

		// Token: 0x040004B8 RID: 1208
		private gn d = gn.e;
	}
}
