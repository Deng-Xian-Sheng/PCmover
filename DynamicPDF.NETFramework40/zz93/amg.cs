using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020005B5 RID: 1461
	internal class amg
	{
		// Token: 0x060039E8 RID: 14824 RVA: 0x001F2123 File Offset: 0x001F1123
		internal amg(alp A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060039E9 RID: 14825 RVA: 0x001F2135 File Offset: 0x001F1135
		internal amg(amk A_0, alp A_1)
		{
			this.a = A_0;
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x060039EA RID: 14826 RVA: 0x001F2158 File Offset: 0x001F1158
		internal virtual x5 nh(PageWriter A_0, x5 A_1)
		{
			for (amk amk = this.a; amk != null; amk = amk.e())
			{
				amk.nl(A_0, A_1);
				A_1 = x5.f(A_1, x5.f(amk.d(), this.c.c()));
			}
			return A_1;
		}

		// Token: 0x060039EB RID: 14827 RVA: 0x001F21B0 File Offset: 0x001F11B0
		internal virtual x5 ni(PageWriter A_0, x5 A_1, x5 A_2)
		{
			for (amk amk = this.a; amk != null; amk = amk.e())
			{
				amk.nk(A_0, A_1, A_2);
				A_2 = x5.f(A_2, x5.f(amk.d(), this.c.c()));
			}
			return A_2;
		}

		// Token: 0x060039EC RID: 14828 RVA: 0x001F2208 File Offset: 0x001F1208
		internal void a(amk A_0)
		{
			if (this.a == null)
			{
				this.b = A_0;
				this.a = A_0;
			}
			else
			{
				this.b.a(A_0);
				this.b = A_0;
			}
		}

		// Token: 0x060039ED RID: 14829 RVA: 0x001F2254 File Offset: 0x001F1254
		internal amk e()
		{
			return this.a;
		}

		// Token: 0x060039EE RID: 14830 RVA: 0x001F226C File Offset: 0x001F126C
		internal void b(amk A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060039EF RID: 14831 RVA: 0x001F2278 File Offset: 0x001F1278
		internal virtual amg nj(bool A_0)
		{
			return this.f();
		}

		// Token: 0x060039F0 RID: 14832 RVA: 0x001F2290 File Offset: 0x001F1290
		internal virtual amg f()
		{
			amg amg = new amg(this.c);
			for (amk amk = this.a; amk != null; amk = amk.e())
			{
				amg.a(amk.f());
			}
			return amg;
		}

		// Token: 0x04001B7A RID: 7034
		private amk a;

		// Token: 0x04001B7B RID: 7035
		private amk b;

		// Token: 0x04001B7C RID: 7036
		private alp c;
	}
}
