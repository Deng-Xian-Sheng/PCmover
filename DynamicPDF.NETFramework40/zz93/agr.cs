using System;

namespace zz93
{
	// Token: 0x020004E2 RID: 1250
	internal class agr : aa9
	{
		// Token: 0x060032E7 RID: 13031 RVA: 0x001C5355 File Offset: 0x001C4355
		internal agr(byte[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060032E8 RID: 13032 RVA: 0x001C5368 File Offset: 0x001C4368
		internal override aba k8()
		{
			if (this.b == null)
			{
				this.b = new agu(base.f(), this.a);
			}
			return this.b;
		}

		// Token: 0x04001864 RID: 6244
		private new byte[] a;

		// Token: 0x04001865 RID: 6245
		private aba b;
	}
}
