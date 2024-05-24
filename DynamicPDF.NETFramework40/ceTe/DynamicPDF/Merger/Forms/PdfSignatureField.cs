using System;
using ceTe.DynamicPDF.Forms;
using zz93;

namespace ceTe.DynamicPDF.Merger.Forms
{
	// Token: 0x02000703 RID: 1795
	public class PdfSignatureField : PdfFormField
	{
		// Token: 0x06004638 RID: 17976 RVA: 0x0023E520 File Offset: 0x0023D520
		internal PdfSignatureField(PdfForm A_0, int A_1, PdfFormField A_2, abj A_3) : base(A_0, A_1, A_2, A_3)
		{
			for (abk abk = A_3.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num == 22)
				{
					abd abd = abk.c().h6();
					if (abd != null)
					{
						A_0.a(true);
					}
				}
			}
		}

		// Token: 0x06004639 RID: 17977 RVA: 0x0023E58C File Offset: 0x0023D58C
		internal override FormField hm(int A_0)
		{
			return new aao(this, A_0);
		}
	}
}
