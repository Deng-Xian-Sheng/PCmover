using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008EF RID: 2287
	public class DateTimeStackedBarValue : StackedBarValue
	{
		// Token: 0x06005DFA RID: 24058 RVA: 0x00353ED2 File Offset: 0x00352ED2
		public DateTimeStackedBarValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06005DFB RID: 24059 RVA: 0x00353EE8 File Offset: 0x00352EE8
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005DFC RID: 24060 RVA: 0x00353F00 File Offset: 0x00352F00
		internal override int it()
		{
			return base.b().b(this.a);
		}

		// Token: 0x0400308B RID: 12427
		private new DateTime a;
	}
}
