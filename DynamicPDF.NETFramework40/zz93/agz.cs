using System;

namespace zz93
{
	// Token: 0x020004EA RID: 1258
	internal class agz : agv
	{
		// Token: 0x06003387 RID: 13191 RVA: 0x001CA111 File Offset: 0x001C9111
		internal agz(agx A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x001CA124 File Offset: 0x001C9124
		internal override void le()
		{
			this.a.af().a(this.a.aa());
			this.a.ab();
			this.a.af().m().a(this);
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x001CA174 File Offset: 0x001C9174
		internal override bool lf()
		{
			return this.a.t();
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x001CA194 File Offset: 0x001C9194
		internal override long lg(bool A_0)
		{
			long result;
			if (!A_0)
			{
				result = this.a.ad();
			}
			else
			{
				result = -1L;
			}
			return result;
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x001CA1BB File Offset: 0x001C91BB
		internal override void lh()
		{
			this.a.ae();
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x001CA1CA File Offset: 0x001C91CA
		internal override void li()
		{
			this.a.e(4);
		}

		// Token: 0x0600338D RID: 13197 RVA: 0x001CA1DA File Offset: 0x001C91DA
		internal override void lj(long A_0)
		{
			this.a.b(A_0);
		}

		// Token: 0x0600338E RID: 13198 RVA: 0x001CA1EC File Offset: 0x001C91EC
		internal override bool lk()
		{
			return this.a.t();
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x001CA20C File Offset: 0x001C920C
		internal override aba lp()
		{
			return this.a;
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x001CA224 File Offset: 0x001C9224
		internal override afj lm(abi A_0)
		{
			return this.a.c(A_0);
		}

		// Token: 0x06003391 RID: 13201 RVA: 0x001CA244 File Offset: 0x001C9244
		internal override ab8 ll(abt A_0, abi A_1)
		{
			return this.a.a(A_0, A_1);
		}

		// Token: 0x06003392 RID: 13202 RVA: 0x001CA264 File Offset: 0x001C9264
		internal override int ln()
		{
			this.a.s();
			return this.a.z();
		}

		// Token: 0x06003393 RID: 13203 RVA: 0x001CA28D File Offset: 0x001C928D
		internal override void lo()
		{
			this.a.s();
		}

		// Token: 0x04001881 RID: 6273
		private agx a;
	}
}
