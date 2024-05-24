using System;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003F6 RID: 1014
	public abstract class CheckBoxField : ButtonField
	{
		// Token: 0x06002A53 RID: 10835 RVA: 0x00189D1B File Offset: 0x00188D1B
		internal CheckBoxField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06002A54 RID: 10836 RVA: 0x00189D2C File Offset: 0x00188D2C
		public override bool HasValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002A55 RID: 10837
		internal abstract Symbol hf();

		// Token: 0x06002A56 RID: 10838 RVA: 0x00189D40 File Offset: 0x00188D40
		internal override bj cc()
		{
			return bj.b;
		}
	}
}
