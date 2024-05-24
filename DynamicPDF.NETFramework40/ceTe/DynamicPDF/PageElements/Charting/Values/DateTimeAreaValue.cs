using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E0 RID: 2272
	public class DateTimeAreaValue : AreaValue
	{
		// Token: 0x06005D7C RID: 23932 RVA: 0x0034F760 File Offset: 0x0034E760
		public DateTimeAreaValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x06005D7D RID: 23933 RVA: 0x0034F774 File Offset: 0x0034E774
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D7E RID: 23934 RVA: 0x0034F78C File Offset: 0x0034E78C
		internal int a()
		{
			return base.c().a(this.a);
		}

		// Token: 0x04003062 RID: 12386
		private new DateTime a;
	}
}
