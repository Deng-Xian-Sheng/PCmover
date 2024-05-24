using System;
using System.IO;
using System.Text;

namespace zz93
{
	// Token: 0x0200047D RID: 1149
	internal class ad0 : sa
	{
		// Token: 0x06002F6C RID: 12140 RVA: 0x001ADE4C File Offset: 0x001ACE4C
		internal ad0(Stream A_0, byte[] A_1, int A_2) : base(A_0, A_1, A_2)
		{
			int num = base.e(4);
			int num2 = 6;
			int num3 = base.e(2) * 12;
			for (int i = num2; i < num3; i += 12)
			{
				if (base.e(i + 6) == 6)
				{
					if (base.e(i) == 3 && base.e(i + 2) == 1)
					{
						this.b = ad0.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
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
						if (base.e(i) == 3 && base.e(i + 2) == 0)
						{
							this.b = ad0.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
							break;
						}
					}
				}
			}
			if (this.b.Length == 0)
			{
				for (int i = num2; i < num3; i += 12)
				{
					if (base.e(i + 6) == 4)
					{
						if (base.e(i) == 3 && base.e(i + 2) == 1)
						{
							this.b = ad0.a.GetString(base.p(), num + base.e(i + 10), base.e(i + 8)).Trim().Replace(" ", string.Empty);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06002F6D RID: 12141 RVA: 0x001AE082 File Offset: 0x001AD082
		internal void a(ad8 A_0)
		{
			A_0.b();
			A_0.a(9, base.p().Length);
			A_0.a(base.p());
		}

		// Token: 0x06002F6E RID: 12142 RVA: 0x001AE0AC File Offset: 0x001AD0AC
		internal string a()
		{
			return this.b;
		}

		// Token: 0x04001694 RID: 5780
		private new static Encoding a = Encoding.BigEndianUnicode;

		// Token: 0x04001695 RID: 5781
		private string b = string.Empty;
	}
}
