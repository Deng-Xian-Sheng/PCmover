using System;

namespace zz93
{
	// Token: 0x020005A1 RID: 1441
	internal class alw
	{
		// Token: 0x06003940 RID: 14656 RVA: 0x001EAA04 File Offset: 0x001E9A04
		internal alw(short A_0)
		{
			this.a = A_0;
			this.e = null;
		}

		// Token: 0x06003941 RID: 14657 RVA: 0x001EAA2F File Offset: 0x001E9A2F
		internal alw(short A_0, alv A_1)
		{
			this.a = A_0;
			this.d = A_1;
			this.e = null;
		}

		// Token: 0x06003942 RID: 14658 RVA: 0x001EAA64 File Offset: 0x001E9A64
		internal x5 a()
		{
			x5 result;
			if (this.b != null && this.b.a() != null)
			{
				result = this.b.a().b7();
			}
			else
			{
				result = x5.b();
			}
			return result;
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x001EAAB0 File Offset: 0x001E9AB0
		internal x5 b()
		{
			x5 result;
			if (this.b != null && this.b.a() != null)
			{
				result = this.b.a().b8();
			}
			else
			{
				result = x5.b();
			}
			return result;
		}

		// Token: 0x04001B45 RID: 6981
		internal short a;

		// Token: 0x04001B46 RID: 6982
		internal am6 b;

		// Token: 0x04001B47 RID: 6983
		internal x5 c = x5.c();

		// Token: 0x04001B48 RID: 6984
		internal alv d = alv.b;

		// Token: 0x04001B49 RID: 6985
		internal alw e;
	}
}
