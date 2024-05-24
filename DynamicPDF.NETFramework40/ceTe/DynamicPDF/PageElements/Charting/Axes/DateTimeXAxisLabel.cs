using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BA RID: 1978
	public class DateTimeXAxisLabel : XAxisLabel
	{
		// Token: 0x060050BF RID: 20671 RVA: 0x00283C0D File Offset: 0x00282C0D
		public DateTimeXAxisLabel(string text, DateTime value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x060050C0 RID: 20672 RVA: 0x00283C20 File Offset: 0x00282C20
		public DateTimeXAxisLabel(string text, DateTime value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060050C1 RID: 20673 RVA: 0x00283C38 File Offset: 0x00282C38
		// (set) Token: 0x060050C2 RID: 20674 RVA: 0x00283C50 File Offset: 0x00282C50
		public DateTime Value
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

		// Token: 0x060050C3 RID: 20675 RVA: 0x00283C5C File Offset: 0x00282C5C
		internal int a()
		{
			return this.b;
		}

		// Token: 0x060050C4 RID: 20676 RVA: 0x00283C74 File Offset: 0x00282C74
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04002B5F RID: 11103
		private new DateTime a;

		// Token: 0x04002B60 RID: 11104
		private new int b;
	}
}
