using System;
using System.IO;
using System.Text;

namespace zz93
{
	// Token: 0x020002BF RID: 703
	internal class sb : sa
	{
		// Token: 0x06002043 RID: 8259 RVA: 0x0013E3B8 File Offset: 0x0013D3B8
		internal sb(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
			int num = base.e(4);
			int num2 = 6;
			int num3 = base.e(2) * 12;
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 6)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1 && base.e(i + 4) == 1033)
					{
						this.b = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
						this.b = this.b.Replace("-", string.Empty);
						break;
					}
				}
			}
			if (this.b.Length == 0)
			{
				for (int i = num2; i < num3; i += 12)
				{
					if (base.e(i + 6) == 6)
					{
						if (base.e(i) == 3 && base.e(i + 2) == 0 && base.e(i + 4) == 1033)
						{
							this.b = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
							this.b = this.b.Replace("-", string.Empty);
							break;
						}
					}
				}
			}
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 4)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1 && base.e(i + 4) == 1033)
					{
						this.c = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
						this.c = this.c.Replace("-", string.Empty);
						break;
					}
				}
			}
			if (this.c.Length == 0)
			{
				for (int i = num2; i < num3; i += 12)
				{
					if (base.e(i + 6) == 4)
					{
						if (base.e(i) == 3 && base.e(i + 2) == 0 && base.e(i + 4) == 1033)
						{
							this.c = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
							this.c = this.c.Replace("-", string.Empty);
							break;
						}
					}
				}
			}
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 16)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1 && base.e(i + 4) == 1033)
					{
						this.d = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
						break;
					}
				}
			}
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 1)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1 && base.e(i + 4) == 1033)
					{
						this.e = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
						break;
					}
				}
			}
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 17)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1)
					{
						this.f = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
						break;
					}
				}
			}
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 2 && base.e(i + 4) == 1033)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1)
					{
						this.g = sb.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
					}
				}
			}
			base.o();
		}

		// Token: 0x06002044 RID: 8260 RVA: 0x0013EA0C File Offset: 0x0013DA0C
		internal string a()
		{
			return this.b;
		}

		// Token: 0x06002045 RID: 8261 RVA: 0x0013EA24 File Offset: 0x0013DA24
		internal string b()
		{
			return this.c;
		}

		// Token: 0x06002046 RID: 8262 RVA: 0x0013EA3C File Offset: 0x0013DA3C
		internal string c()
		{
			return this.d;
		}

		// Token: 0x06002047 RID: 8263 RVA: 0x0013EA54 File Offset: 0x0013DA54
		internal string d()
		{
			return this.e;
		}

		// Token: 0x04000DFA RID: 3578
		private new static Encoding a = Encoding.BigEndianUnicode;

		// Token: 0x04000DFB RID: 3579
		private string b = string.Empty;

		// Token: 0x04000DFC RID: 3580
		private string c = string.Empty;

		// Token: 0x04000DFD RID: 3581
		private new string d = string.Empty;

		// Token: 0x04000DFE RID: 3582
		private new string e = string.Empty;

		// Token: 0x04000DFF RID: 3583
		private new string f = string.Empty;

		// Token: 0x04000E00 RID: 3584
		private new string g = string.Empty;
	}
}
