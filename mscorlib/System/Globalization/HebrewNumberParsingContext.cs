using System;

namespace System.Globalization
{
	// Token: 0x020003DC RID: 988
	internal struct HebrewNumberParsingContext
	{
		// Token: 0x060032D9 RID: 13017 RVA: 0x000C42FB File Offset: 0x000C24FB
		public HebrewNumberParsingContext(int result)
		{
			this.state = HebrewNumber.HS.Start;
			this.result = result;
		}

		// Token: 0x04001684 RID: 5764
		internal HebrewNumber.HS state;

		// Token: 0x04001685 RID: 5765
		internal int result;
	}
}
