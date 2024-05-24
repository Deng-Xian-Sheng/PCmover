using System;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x02000426 RID: 1062
	internal class abo : abn
	{
		// Token: 0x06002C39 RID: 11321 RVA: 0x001961AC File Offset: 0x001951AC
		internal abo(abj A_0) : base(A_0, ResourceType.Font)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 3808101)
				{
					abk.a(false);
					break;
				}
			}
		}
	}
}
