using System;

namespace ceTe.DynamicPDF.PageElements.Charting.Values
{
	// Token: 0x020008EB RID: 2283
	public class DateTimeStackedAreaValue : StackedAreaValue
	{
		// Token: 0x06005DCB RID: 24011 RVA: 0x003524CE File Offset: 0x003514CE
		public DateTimeStackedAreaValue(float value1, DateTime position) : base(value1)
		{
			this.a = position;
		}

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06005DCC RID: 24012 RVA: 0x003524E4 File Offset: 0x003514E4
		public DateTime Position
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x06005DCD RID: 24013 RVA: 0x003524FC File Offset: 0x003514FC
		internal int a()
		{
			return base.g().a(this.a);
		}

		// Token: 0x0400307B RID: 12411
		private new DateTime a;
	}
}
