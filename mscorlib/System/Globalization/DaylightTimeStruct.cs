using System;

namespace System.Globalization
{
	// Token: 0x020003B4 RID: 948
	internal struct DaylightTimeStruct
	{
		// Token: 0x06002F40 RID: 12096 RVA: 0x000B58D1 File Offset: 0x000B3AD1
		public DaylightTimeStruct(DateTime start, DateTime end, TimeSpan delta)
		{
			this.Start = start;
			this.End = end;
			this.Delta = delta;
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06002F41 RID: 12097 RVA: 0x000B58E8 File Offset: 0x000B3AE8
		public DateTime Start { get; }

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06002F42 RID: 12098 RVA: 0x000B58F0 File Offset: 0x000B3AF0
		public DateTime End { get; }

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06002F43 RID: 12099 RVA: 0x000B58F8 File Offset: 0x000B3AF8
		public TimeSpan Delta { get; }
	}
}
