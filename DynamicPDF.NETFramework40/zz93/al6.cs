using System;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005AB RID: 1451
	internal class al6 : ahp
	{
		// Token: 0x060039C0 RID: 14784 RVA: 0x001F1906 File Offset: 0x001F0906
		internal al6(ahq A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060039C1 RID: 14785 RVA: 0x001F1920 File Offset: 0x001F0920
		internal ahq a()
		{
			return this.a;
		}

		// Token: 0x060039C2 RID: 14786 RVA: 0x001F1938 File Offset: 0x001F0938
		internal override bool nd()
		{
			return true;
		}

		// Token: 0x060039C3 RID: 14787 RVA: 0x001F194B File Offset: 0x001F094B
		internal override void lu(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			this.a.lu(A_0, A_1, A_2);
		}

		// Token: 0x060039C4 RID: 14788 RVA: 0x001F195D File Offset: 0x001F095D
		internal override void lv(LayoutWriter A_0, akk A_1, alq A_2, char[] A_3)
		{
			this.a.lv(A_0, A_1, A_2, A_3);
		}

		// Token: 0x04001B79 RID: 7033
		private ahq a = null;
	}
}
