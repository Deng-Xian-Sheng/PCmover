using System;
using System.Runtime.InteropServices;

namespace System.Security.Principal
{
	// Token: 0x02000328 RID: 808
	[ComVisible(true)]
	[Serializable]
	public enum WindowsAccountType
	{
		// Token: 0x04001020 RID: 4128
		Normal,
		// Token: 0x04001021 RID: 4129
		Guest,
		// Token: 0x04001022 RID: 4130
		System,
		// Token: 0x04001023 RID: 4131
		Anonymous
	}
}
