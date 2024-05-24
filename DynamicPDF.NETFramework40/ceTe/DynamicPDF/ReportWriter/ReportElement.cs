using System;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x0200080F RID: 2063
	public abstract class ReportElement
	{
		// Token: 0x06005386 RID: 21382 RVA: 0x00292221 File Offset: 0x00291221
		internal virtual void gi(xh A_0, LayoutWriter A_1)
		{
			this.fi(A_0, A_1);
		}

		// Token: 0x06005387 RID: 21383
		internal abstract void fi(xf A_0, LayoutWriter A_1);

		// Token: 0x06005388 RID: 21384 RVA: 0x00292230 File Offset: 0x00291230
		internal virtual short gk()
		{
			return short.MinValue;
		}

		// Token: 0x06005389 RID: 21385 RVA: 0x00292247 File Offset: 0x00291247
		internal virtual void gl(short A_0)
		{
		}

		// Token: 0x0600538A RID: 21386 RVA: 0x0029224C File Offset: 0x0029124C
		internal virtual bool gp()
		{
			return false;
		}

		// Token: 0x0600538B RID: 21387 RVA: 0x00292260 File Offset: 0x00291260
		internal virtual bool gj()
		{
			return false;
		}

		// Token: 0x0600538C RID: 21388 RVA: 0x00292274 File Offset: 0x00291274
		internal virtual x5 gm()
		{
			return x5.a();
		}

		// Token: 0x0600538D RID: 21389 RVA: 0x0029228C File Offset: 0x0029128C
		internal virtual x5 gn()
		{
			return x5.b();
		}

		// Token: 0x0600538E RID: 21390 RVA: 0x002922A4 File Offset: 0x002912A4
		internal virtual bool fj()
		{
			return true;
		}

		// Token: 0x0600538F RID: 21391 RVA: 0x002922B7 File Offset: 0x002912B7
		internal virtual void gq(short A_0)
		{
			throw new Exception("Method operation not implemented");
		}

		// Token: 0x06005390 RID: 21392 RVA: 0x002922C4 File Offset: 0x002912C4
		internal virtual void go(short A_0, wx A_1)
		{
			throw new Exception("Method operation not implemented");
		}

		// Token: 0x06005391 RID: 21393 RVA: 0x002922D4 File Offset: 0x002912D4
		internal virtual ushort fk()
		{
			return 0;
		}
	}
}
