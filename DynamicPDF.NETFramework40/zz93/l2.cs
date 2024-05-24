using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020001D2 RID: 466
	internal class l2
	{
		// Token: 0x060013C3 RID: 5059 RVA: 0x000DEA53 File Offset: 0x000DDA53
		internal l2(int A_0, Font A_1, string A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x000DEA84 File Offset: 0x000DDA84
		internal int d()
		{
			return this.a;
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x000DEA9C File Offset: 0x000DDA9C
		internal void a(int A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x000DEAA8 File Offset: 0x000DDAA8
		internal Font e()
		{
			return this.b;
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x000DEAC0 File Offset: 0x000DDAC0
		internal void a(Font A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x000DEACC File Offset: 0x000DDACC
		internal string f()
		{
			return this.c;
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x000DEAE4 File Offset: 0x000DDAE4
		internal void a(string A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x000DEAF0 File Offset: 0x000DDAF0
		internal int g()
		{
			return this.d;
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x000DEB08 File Offset: 0x000DDB08
		internal void b(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x000DEB14 File Offset: 0x000DDB14
		internal bool h()
		{
			return this.e;
		}

		// Token: 0x060013CD RID: 5069 RVA: 0x000DEB2C File Offset: 0x000DDB2C
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x000DEB38 File Offset: 0x000DDB38
		internal static l2 c()
		{
			return l2.f;
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x000DEB50 File Offset: 0x000DDB50
		internal static l2 b()
		{
			return l2.g;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x000DEB68 File Offset: 0x000DDB68
		internal static l2 a()
		{
			return l2.h;
		}

		// Token: 0x04000950 RID: 2384
		private int a;

		// Token: 0x04000951 RID: 2385
		private Font b;

		// Token: 0x04000952 RID: 2386
		private string c;

		// Token: 0x04000953 RID: 2387
		private int d = 1;

		// Token: 0x04000954 RID: 2388
		private bool e = false;

		// Token: 0x04000955 RID: 2389
		private static l2 f = new l2(l5.a("TimesRomanCore"), Font.TimesRoman, "TimesRomanCore");

		// Token: 0x04000956 RID: 2390
		private static l2 g = new l2(l5.a("Symbol"), Font.Symbol, "Symbol");

		// Token: 0x04000957 RID: 2391
		private static l2 h = new l2(l5.a("ZapfDingbats"), Font.ZapfDingbats, "ZapfDingbats");
	}
}
