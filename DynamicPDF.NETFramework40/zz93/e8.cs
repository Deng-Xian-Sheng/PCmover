using System;

namespace zz93
{
	// Token: 0x020000DC RID: 220
	internal class e8 : d0
	{
		// Token: 0x060009D6 RID: 2518 RVA: 0x0007FF88 File Offset: 0x0007EF88
		internal void a(kg A_0)
		{
			if (this.a == gn.e)
			{
				string text = A_0.ao();
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "left")
						{
							this.a = gn.a;
							goto IL_92;
						}
						if (text2 == "right")
						{
							this.a = gn.b;
							goto IL_92;
						}
						if (text2 == "center")
						{
							this.a = gn.c;
							goto IL_92;
						}
						if (text2 == "justify")
						{
							this.a = gn.d;
							goto IL_92;
						}
					}
					this.a = gn.a;
					IL_92:;
				}
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0008002C File Offset: 0x0007F02C
		internal void b(kg A_0)
		{
			if (this.b == gs.a)
			{
				string text = A_0.ao();
				if (text != null)
				{
					string text2 = text.ToLower();
					if (text2 != null)
					{
						if (text2 == "top")
						{
							this.b = gs.e;
							goto IL_92;
						}
						if (text2 == "middle")
						{
							this.b = gs.g;
							goto IL_92;
						}
						if (text2 == "bottom")
						{
							this.b = gs.h;
							goto IL_92;
						}
						if (text2 == "baseline")
						{
							this.b = gs.b;
							goto IL_92;
						}
					}
					this.b = gs.g;
					IL_92:;
				}
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x000800D0 File Offset: 0x0007F0D0
		internal gn i()
		{
			return this.a;
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x000800E8 File Offset: 0x0007F0E8
		internal gs j()
		{
			return this.b;
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x00080100 File Offset: 0x0007F100
		internal override int cn()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x00080108 File Offset: 0x0007F108
		internal override string co()
		{
			throw new NotImplementedException();
		}

		// Token: 0x040004F0 RID: 1264
		private gn a = gn.e;

		// Token: 0x040004F1 RID: 1265
		private gs b = gs.a;
	}
}
