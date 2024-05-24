using System;

namespace zz93
{
	// Token: 0x020004C2 RID: 1218
	internal class afv : fs
	{
		// Token: 0x060031FF RID: 12799 RVA: 0x001BF19B File Offset: 0x001BE19B
		internal afv(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x001BF1B0 File Offset: 0x001BE1B0
		internal string a()
		{
			return this.a;
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x001BF1C8 File Offset: 0x001BE1C8
		internal void a(string A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06003202 RID: 12802 RVA: 0x001BF1D4 File Offset: 0x001BE1D4
		internal bool b()
		{
			return this.b;
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x001BF1EC File Offset: 0x001BE1EC
		internal void a(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003204 RID: 12804 RVA: 0x001BF1F8 File Offset: 0x001BE1F8
		internal override afv km()
		{
			return this;
		}

		// Token: 0x0400176F RID: 5999
		private string a;

		// Token: 0x04001770 RID: 6000
		private bool b;
	}
}
