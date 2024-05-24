using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000145 RID: 325
	[DefaultMember("Item")]
	internal class h5 : h3
	{
		// Token: 0x06000C33 RID: 3123 RVA: 0x00090C90 File Offset: 0x0008FC90
		internal override void c4(int A_0, object A_1)
		{
			if (this.a == null)
			{
				this.a = new h6(A_0, A_1);
			}
			else
			{
				this.a.a(A_0, A_1);
			}
		}

		// Token: 0x06000C34 RID: 3124 RVA: 0x00090CCC File Offset: 0x0008FCCC
		internal override bool c5(int A_0)
		{
			return this.a != null && this.a.a(A_0);
		}

		// Token: 0x06000C35 RID: 3125 RVA: 0x00090CF8 File Offset: 0x0008FCF8
		internal override h6 c6(int A_0)
		{
			h6 result;
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

		// Token: 0x0400064C RID: 1612
		private h6 a;
	}
}
