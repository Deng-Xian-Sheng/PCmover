using System;
using System.Collections.Generic;
using System.Reflection;

namespace zz93
{
	// Token: 0x0200012F RID: 303
	[DefaultMember("Item")]
	internal class hj : hi
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x0008CA57 File Offset: 0x0008BA57
		internal hj()
		{
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x0008CA6C File Offset: 0x0008BA6C
		internal override void c1(int A_0, ig A_1)
		{
			if (this.a == null)
			{
				this.a = new hk(A_0, A_1);
			}
			else
			{
				this.a.a(A_0, A_1);
			}
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x0008CAA8 File Offset: 0x0008BAA8
		internal override List<ig> c2(int A_0)
		{
			List<ig> result;
			if (this.a == null)
			{
				result = null;
			}
			else
			{
				result = this.a.b(A_0);
			}
			return result;
		}

		// Token: 0x06000B8D RID: 2957 RVA: 0x0008CADC File Offset: 0x0008BADC
		internal override List<ig> c3(int A_0)
		{
			List<ig> result;
			if (this.a == null)
			{
				result = null;
			}
			else
			{
				result = this.a.a(A_0);
			}
			return result;
		}

		// Token: 0x04000623 RID: 1571
		private hk a = null;
	}
}
