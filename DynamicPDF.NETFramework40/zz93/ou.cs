using System;
using System.Collections;

namespace zz93
{
	// Token: 0x02000238 RID: 568
	internal class ou : d3
	{
		// Token: 0x06001A61 RID: 6753 RVA: 0x00112D66 File Offset: 0x00111D66
		internal ou(kg A_0, p1 A_1, ij A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x00112D88 File Offset: 0x00111D88
		internal new Hashtable b()
		{
			return this.a;
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00112DA0 File Offset: 0x00111DA0
		internal new bool c()
		{
			return this.b;
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x00112DB8 File Offset: 0x00111DB8
		internal new void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x00112DC4 File Offset: 0x00111DC4
		protected internal override void cq()
		{
			while (!base.l().af())
			{
				base.l().ai();
				if (base.l().t())
				{
					if (base.l().v() == 352706657)
					{
						this.a();
					}
					if (base.l().v() == 46415)
					{
						this.b = true;
					}
					this.cs(base.l().v());
					base.e(base.l().v());
				}
				else
				{
					if (base.l().u())
					{
						int num = base.l().v();
						if (num <= 3418)
						{
							if (num != 1977)
							{
								if (num != 3418)
								{
									goto IL_105;
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
							if (num == 11228793)
							{
								break;
							}
							if (num != 86163053)
							{
								goto IL_105;
							}
							base.d(base.l().v());
							break;
						}
						continue;
						IL_105:
						base.d(base.l().v());
						continue;
						break;
					}
					if (base.l().aa())
					{
						if (!base.k().e(57))
						{
							break;
						}
						base.r();
						base.l().e(false);
					}
				}
			}
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x00112F48 File Offset: 0x00111F48
		private new void a()
		{
			string arg = string.Empty;
			int num = base.l().w();
			int num2 = base.l().x().Length;
			while (num < num2 && base.l().x()[num] != '=')
			{
				if (base.l().x()[num] == ' ')
				{
					num++;
				}
				else
				{
					arg += base.l().x()[num];
					num++;
				}
			}
			string text = string.Empty;
			num++;
			while (base.l().x()[num] != ' ')
			{
				char c = base.l().x()[num];
				if (c != '"' && c != '/' && c != '\\')
				{
					text += base.l().x()[num];
				}
				num++;
			}
			string value = this.a(num, num2);
			this.a[text.ToLower()] = value;
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x00113068 File Offset: 0x00112068
		private new string a(int A_0, int A_1)
		{
			string arg = string.Empty;
			int num = A_0;
			while (num < A_1 && base.l().x()[num] != '=')
			{
				if (base.l().x()[num] == ' ')
				{
					num++;
				}
				else
				{
					arg += base.l().x()[num];
					num++;
				}
			}
			string text = string.Empty;
			num += 2;
			while (base.l().x()[num] != '"')
			{
				if (base.l().x()[num] == ' ')
				{
					num++;
				}
				text += base.l().x()[num];
				num++;
			}
			return text;
		}

		// Token: 0x04000C01 RID: 3073
		internal new Hashtable a = new Hashtable();

		// Token: 0x04000C02 RID: 3074
		internal new bool b = false;
	}
}
