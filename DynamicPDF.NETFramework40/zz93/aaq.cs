using System;

namespace zz93
{
	// Token: 0x02000402 RID: 1026
	internal class aaq
	{
		// Token: 0x06002B03 RID: 11011 RVA: 0x0018E3D4 File Offset: 0x0018D3D4
		internal aaq(abu A_0) : this(A_0, null)
		{
		}

		// Token: 0x06002B04 RID: 11012 RVA: 0x0018E3E1 File Offset: 0x0018D3E1
		internal aaq(abu A_0, ab7 A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x06002B05 RID: 11013 RVA: 0x0018E3FC File Offset: 0x0018D3FC
		internal abu a()
		{
			return this.a;
		}

		// Token: 0x06002B06 RID: 11014 RVA: 0x0018E414 File Offset: 0x0018D414
		internal string b()
		{
			string result;
			if (this.b == null)
			{
				result = this.a.j9();
			}
			else
			{
				result = this.b.kf();
			}
			return result;
		}

		// Token: 0x040013C5 RID: 5061
		private abu a;

		// Token: 0x040013C6 RID: 5062
		private ab7 b;
	}
}
