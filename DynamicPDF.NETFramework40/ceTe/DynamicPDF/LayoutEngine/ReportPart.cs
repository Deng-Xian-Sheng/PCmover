using System;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000928 RID: 2344
	public class ReportPart
	{
		// Token: 0x06005F6E RID: 24430 RVA: 0x0035D778 File Offset: 0x0035C778
		internal ReportPart(akv A_0, Report A_1)
		{
			this.a = A_0.mv();
			this.b = A_0.mx();
			if (A_0.mw() != null)
			{
				this.c = new LayoutElementList(A_1, A_0.mw());
			}
		}

		// Token: 0x06005F6F RID: 24431 RVA: 0x0035D7CC File Offset: 0x0035C7CC
		internal ReportPart(akv A_0, SubReport A_1)
		{
			this.a = A_0.mv();
			this.b = A_0.mx();
			if (A_0.mw() != null)
			{
				this.c = new LayoutElementList(A_1, A_0.mw());
			}
		}

		// Token: 0x17000A21 RID: 2593
		// (get) Token: 0x06005F70 RID: 24432 RVA: 0x0035D820 File Offset: 0x0035C820
		public bool HasElements
		{
			get
			{
				return this.c != null && this.c.Count > 0;
			}
		}

		// Token: 0x17000A22 RID: 2594
		// (get) Token: 0x06005F71 RID: 24433 RVA: 0x0035D84C File Offset: 0x0035C84C
		public LayoutElementList Elements
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17000A23 RID: 2595
		// (get) Token: 0x06005F72 RID: 24434 RVA: 0x0035D864 File Offset: 0x0035C864
		// (set) Token: 0x06005F73 RID: 24435 RVA: 0x0035D882 File Offset: 0x0035C882
		public float Height
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x17000A24 RID: 2596
		// (get) Token: 0x06005F74 RID: 24436 RVA: 0x0035D894 File Offset: 0x0035C894
		// (set) Token: 0x06005F75 RID: 24437 RVA: 0x0035D8AC File Offset: 0x0035C8AC
		public string Id
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x0400311B RID: 12571
		private string a;

		// Token: 0x0400311C RID: 12572
		private x5 b;

		// Token: 0x0400311D RID: 12573
		private LayoutElementList c = null;
	}
}
