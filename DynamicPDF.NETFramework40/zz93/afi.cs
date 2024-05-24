using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B5 RID: 1205
	internal class afi : abj
	{
		// Token: 0x06003190 RID: 12688 RVA: 0x001BBCE8 File Offset: 0x001BACE8
		internal afi(agp A_0, abi A_1, abk A_2) : base(A_1, A_2)
		{
			this.a = A_0;
		}

		// Token: 0x06003191 RID: 12689 RVA: 0x001BBCFC File Offset: 0x001BACFC
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				this.h9(a_, A_0);
			}
		}

		// Token: 0x06003192 RID: 12690 RVA: 0x001BBD30 File Offset: 0x001BAD30
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			if (base.p())
			{
				A_1.WriteDictionaryOpen();
				base.b(A_0, A_1);
				A_1.WriteDictionaryClose();
			}
		}

		// Token: 0x04001728 RID: 5928
		private new agp a;
	}
}
