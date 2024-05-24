using System;
using System.Collections.Generic;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000130 RID: 304
	[DefaultMember("Item")]
	internal class hk
	{
		// Token: 0x06000B8E RID: 2958 RVA: 0x0008CB0E File Offset: 0x0008BB0E
		internal hk(int A_0, ig A_1)
		{
			this.a = A_0;
			this.d.Add(A_1);
		}

		// Token: 0x06000B8F RID: 2959 RVA: 0x0008CB50 File Offset: 0x0008BB50
		internal List<ig> a(int A_0)
		{
			List<ig> result;
			if (A_0 == this.a && !this.e)
			{
				result = this.d;
			}
			else if (A_0 > this.a || this.e)
			{
				if (this.b == null)
				{
					result = null;
				}
				else
				{
					result = this.b.a(A_0);
				}
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.a(A_0);
			}
			return result;
		}

		// Token: 0x06000B90 RID: 2960 RVA: 0x0008CBE0 File Offset: 0x0008BBE0
		internal List<ig> b(int A_0)
		{
			List<ig> result;
			if (A_0 == this.a)
			{
				result = this.d;
			}
			else if (A_0 > this.a)
			{
				if (this.b == null)
				{
					result = null;
				}
				else
				{
					result = this.b.b(A_0);
				}
			}
			else if (this.c == null)
			{
				result = null;
			}
			else
			{
				result = this.c.b(A_0);
			}
			return result;
		}

		// Token: 0x06000B91 RID: 2961 RVA: 0x0008CC60 File Offset: 0x0008BC60
		internal void a(int A_0, ig A_1)
		{
			if (A_0 > this.a)
			{
				if (this.b == null)
				{
					this.b = new hk(A_0, A_1);
				}
				else
				{
					this.b.a(A_0, A_1);
				}
			}
			else if (A_0 < this.a)
			{
				if (this.c == null)
				{
					this.c = new hk(A_0, A_1);
				}
				else
				{
					this.c.a(A_0, A_1);
				}
			}
		}

		// Token: 0x04000624 RID: 1572
		private int a;

		// Token: 0x04000625 RID: 1573
		private hk b = null;

		// Token: 0x04000626 RID: 1574
		private hk c = null;

		// Token: 0x04000627 RID: 1575
		private List<ig> d = new List<ig>();

		// Token: 0x04000628 RID: 1576
		private bool e = false;
	}
}
