using System;
using System.Collections.Generic;
using System.Reflection;

namespace zz93
{
	// Token: 0x020004D4 RID: 1236
	[DefaultMember("Item")]
	internal class agd
	{
		// Token: 0x0600328C RID: 12940 RVA: 0x001C2950 File Offset: 0x001C1950
		internal agd(int A_0, char[] A_1)
		{
			this.a = new agc[A_0];
			this.b = A_1;
		}

		// Token: 0x0600328D RID: 12941 RVA: 0x001C2978 File Offset: 0x001C1978
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x0600328E RID: 12942 RVA: 0x001C2994 File Offset: 0x001C1994
		internal List<agf> b()
		{
			return this.c;
		}

		// Token: 0x0600328F RID: 12943 RVA: 0x001C29AC File Offset: 0x001C19AC
		internal void a(List<agf> A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003290 RID: 12944 RVA: 0x001C29B8 File Offset: 0x001C19B8
		internal agc a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06003291 RID: 12945 RVA: 0x001C29D2 File Offset: 0x001C19D2
		internal void a(int A_0, agc A_1)
		{
			this.a[A_0] = A_1;
		}

		// Token: 0x06003292 RID: 12946 RVA: 0x001C29E0 File Offset: 0x001C19E0
		internal char b(int A_0)
		{
			char result;
			if (A_0 > 0)
			{
				result = this.b[A_0];
			}
			else if (A_0 == -1)
			{
				result = '\n';
			}
			else
			{
				result = '\0';
			}
			return result;
		}

		// Token: 0x06003293 RID: 12947 RVA: 0x001C2A1B File Offset: 0x001C1A1B
		internal void a(int A_0, int A_1)
		{
			Array.Reverse(this.a, A_0, A_1);
		}

		// Token: 0x040017AE RID: 6062
		private agc[] a;

		// Token: 0x040017AF RID: 6063
		private char[] b;

		// Token: 0x040017B0 RID: 6064
		private List<agf> c = null;
	}
}
