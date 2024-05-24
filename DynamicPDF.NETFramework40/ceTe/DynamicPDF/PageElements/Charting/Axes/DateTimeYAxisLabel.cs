using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C0 RID: 1984
	public class DateTimeYAxisLabel : YAxisLabel
	{
		// Token: 0x06005114 RID: 20756 RVA: 0x00286C08 File Offset: 0x00285C08
		public DateTimeYAxisLabel(string text, DateTime value1) : base(text)
		{
			this.a = value1;
		}

		// Token: 0x06005115 RID: 20757 RVA: 0x00286C1B File Offset: 0x00285C1B
		public DateTimeYAxisLabel(string text, DateTime value1, Font font, float fontSize, Color textColor) : base(text, font, fontSize, textColor)
		{
			this.a = value1;
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x06005116 RID: 20758 RVA: 0x00286C34 File Offset: 0x00285C34
		// (set) Token: 0x06005117 RID: 20759 RVA: 0x00286C4C File Offset: 0x00285C4C
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

		// Token: 0x06005118 RID: 20760 RVA: 0x00286C58 File Offset: 0x00285C58
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06005119 RID: 20761 RVA: 0x00286C70 File Offset: 0x00285C70
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x04002B76 RID: 11126
		private new DateTime a;

		// Token: 0x04002B77 RID: 11127
		private new int b;
	}
}
