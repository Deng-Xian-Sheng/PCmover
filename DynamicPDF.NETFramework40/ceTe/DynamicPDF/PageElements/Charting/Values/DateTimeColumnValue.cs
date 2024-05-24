using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008E4 RID: 2276
	public class DateTimeColumnValue : ColumnValue
	{
		// Token: 0x06005D8A RID: 23946 RVA: 0x0034F8FE File Offset: 0x0034E8FE
		public DateTimeColumnValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06005D8B RID: 23947 RVA: 0x0034F914 File Offset: 0x0034E914
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005D8C RID: 23948 RVA: 0x0034F92C File Offset: 0x0034E92C
		internal override int @is()
		{
			return base.d().a(this.a);
		}

		// Token: 0x04003064 RID: 12388
		private new DateTime a;
	}
}
