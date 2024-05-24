using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D4 RID: 2004
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum SoapOption
	{
		// Token: 0x040027C4 RID: 10180
		None = 0,
		// Token: 0x040027C5 RID: 10181
		AlwaysIncludeTypes = 1,
		// Token: 0x040027C6 RID: 10182
		XsdString = 2,
		// Token: 0x040027C7 RID: 10183
		EmbedAll = 4,
		// Token: 0x040027C8 RID: 10184
		Option1 = 8,
		// Token: 0x040027C9 RID: 10185
		Option2 = 16
	}
}
