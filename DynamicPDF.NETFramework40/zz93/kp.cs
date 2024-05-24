using System;

namespace zz93
{
	// Token: 0x020001A1 RID: 417
	internal class kp : d0
	{
		// Token: 0x06000EA0 RID: 3744 RVA: 0x000AFD18 File Offset: 0x000AED18
		internal kp(kg A_0, ij A_1)
		{
			while (!A_0.aj())
			{
				int num = A_0.al();
				if (num <= 2235034)
				{
					if (num <= 22432)
					{
						if (num != 3407)
						{
							if (num != 22432)
							{
								goto IL_3B7;
							}
							this.d = A_0.aq();
						}
						else if (base.k() == null)
						{
							base.c(A_0.an());
						}
					}
					else if (num != 109057)
					{
						if (num != 2163680)
						{
							if (num != 2235034)
							{
								goto IL_3B7;
							}
							if (this.a == null)
							{
								this.a = A_0.ao().ToLower();
								string text = this.a;
								switch (text)
								{
								case "text":
									this.j = ko.a;
									break;
								case "password":
									this.j = ko.b;
									break;
								case "button":
									this.j = ko.c;
									break;
								case "reset":
									this.j = ko.d;
									break;
								case "submit":
									this.j = ko.e;
									break;
								case "checkbox":
									this.j = ko.f;
									break;
								case "radio":
									this.j = ko.g;
									break;
								case "image":
									this.j = ko.h;
									break;
								case "file":
									this.j = ko.i;
									break;
								case "hidden":
									this.j = ko.j;
									break;
								}
							}
						}
						else if (this.b == -2147483648)
						{
							this.b = A_0.@as();
						}
					}
					else
					{
						this.f = A_0.ao();
					}
				}
				else if (num <= 165283231)
				{
					if (num != 143556695)
					{
						if (num != 144877216)
						{
							if (num != 165283231)
							{
								goto IL_3B7;
							}
							if (this.c == 2147483647)
							{
								this.c = A_0.@as();
							}
						}
						else if (base.m() == null)
						{
							string text2 = A_0.au();
							if (text2 != null)
							{
								base.a(new ig(A_1.a(text2.ToCharArray(), 0, text2.Length)));
							}
						}
					}
					else if (this.g == null)
					{
						this.g = A_0.ao();
						if (this.g != null)
						{
							this.i = A_0.w() - this.g.Length;
						}
					}
				}
				else if (num != 303337813)
				{
					if (num != 545266181)
					{
						if (num != 956344229)
						{
							goto IL_3B7;
						}
						this.e = true;
					}
					else if (base.l() == null)
					{
						base.a(A_0.am());
					}
				}
				else
				{
					this.h = true;
				}
				continue;
				IL_3B7:
				base.c(A_0);
			}
			if (this.a == null || this.j == ko.k)
			{
				this.j = ko.a;
			}
			A_0.ax();
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x000B0124 File Offset: 0x000AF124
		internal override int cn()
		{
			return 445520207;
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x000B013C File Offset: 0x000AF13C
		internal override string co()
		{
			return "input";
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x000B0154 File Offset: 0x000AF154
		internal ko a()
		{
			return this.j;
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x000B016C File Offset: 0x000AF16C
		internal int b()
		{
			int result;
			if (this.b == -2147483648)
			{
				result = 20;
			}
			else
			{
				result = this.b;
			}
			return result;
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x000B01A0 File Offset: 0x000AF1A0
		internal int c()
		{
			return this.c;
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x000B01B8 File Offset: 0x000AF1B8
		internal string d()
		{
			return this.g;
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x000B01D0 File Offset: 0x000AF1D0
		internal int e()
		{
			return this.i;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x000B01E8 File Offset: 0x000AF1E8
		internal string f()
		{
			return this.d;
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x000B0200 File Offset: 0x000AF200
		internal bool g()
		{
			return this.e;
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x000B0218 File Offset: 0x000AF218
		internal bool h()
		{
			return this.h;
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x000B0230 File Offset: 0x000AF230
		internal string i()
		{
			return this.f;
		}

		// Token: 0x04000733 RID: 1843
		private string a = null;

		// Token: 0x04000734 RID: 1844
		private int b = int.MinValue;

		// Token: 0x04000735 RID: 1845
		private new int c = int.MaxValue;

		// Token: 0x04000736 RID: 1846
		private string d = null;

		// Token: 0x04000737 RID: 1847
		private bool e = false;

		// Token: 0x04000738 RID: 1848
		private string f = null;

		// Token: 0x04000739 RID: 1849
		private string g = null;

		// Token: 0x0400073A RID: 1850
		private bool h = false;

		// Token: 0x0400073B RID: 1851
		private int i = 0;

		// Token: 0x0400073C RID: 1852
		private ko j = ko.k;
	}
}
