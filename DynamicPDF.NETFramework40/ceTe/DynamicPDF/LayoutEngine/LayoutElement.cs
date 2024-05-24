using System;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000935 RID: 2357
	public abstract class LayoutElement
	{
		// Token: 0x06005FDC RID: 24540 RVA: 0x0035F2EA File Offset: 0x0035E2EA
		internal virtual void nu(aml A_0, LayoutWriter A_1)
		{
			this.nt(A_0, A_1);
		}

		// Token: 0x06005FDD RID: 24541
		internal abstract void nt(amj A_0, LayoutWriter A_1);

		// Token: 0x06005FDE RID: 24542 RVA: 0x0035F2F8 File Offset: 0x0035E2F8
		internal virtual short nw()
		{
			return short.MinValue;
		}

		// Token: 0x06005FDF RID: 24543 RVA: 0x0035F30F File Offset: 0x0035E30F
		internal virtual void nx(short A_0)
		{
		}

		// Token: 0x06005FE0 RID: 24544 RVA: 0x0035F314 File Offset: 0x0035E314
		internal virtual bool n3()
		{
			return false;
		}

		// Token: 0x06005FE1 RID: 24545 RVA: 0x0035F328 File Offset: 0x0035E328
		internal virtual bool nv()
		{
			return false;
		}

		// Token: 0x06005FE2 RID: 24546 RVA: 0x0035F33C File Offset: 0x0035E33C
		internal virtual x5 ny()
		{
			return x5.a();
		}

		// Token: 0x06005FE3 RID: 24547 RVA: 0x0035F354 File Offset: 0x0035E354
		internal virtual x5 nz()
		{
			return x5.b();
		}

		// Token: 0x06005FE4 RID: 24548 RVA: 0x0035F36C File Offset: 0x0035E36C
		internal virtual bool n2()
		{
			return true;
		}

		// Token: 0x06005FE5 RID: 24549 RVA: 0x0035F37F File Offset: 0x0035E37F
		internal virtual void n4(short A_0)
		{
			throw new Exception("Method operation not implemented");
		}

		// Token: 0x06005FE6 RID: 24550 RVA: 0x0035F38C File Offset: 0x0035E38C
		internal virtual void n1(short A_0, alv A_1)
		{
			throw new Exception("Method operation not implemented");
		}

		// Token: 0x06005FE7 RID: 24551 RVA: 0x0035F39C File Offset: 0x0035E39C
		internal virtual ushort n0()
		{
			return 0;
		}
	}
}
