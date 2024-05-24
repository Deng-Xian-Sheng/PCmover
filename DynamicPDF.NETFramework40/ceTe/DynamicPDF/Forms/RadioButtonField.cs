using System;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003FE RID: 1022
	public class RadioButtonField : ButtonField
	{
		// Token: 0x06002ADB RID: 10971 RVA: 0x0018D2BA File Offset: 0x0018C2BA
		internal RadioButtonField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, A_1, A_2)
		{
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06002ADC RID: 10972 RVA: 0x0018D2C8 File Offset: 0x0018C2C8
		public override bool HasValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06002ADD RID: 10973 RVA: 0x0018D2DC File Offset: 0x0018C2DC
		internal virtual Symbol i7()
		{
			return Symbol.Circle;
		}

		// Token: 0x06002ADE RID: 10974 RVA: 0x0018D2F0 File Offset: 0x0018C2F0
		internal override bj cc()
		{
			return bj.f;
		}
	}
}
