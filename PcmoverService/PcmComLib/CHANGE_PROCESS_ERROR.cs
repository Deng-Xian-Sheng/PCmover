using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000042 RID: 66
	[CompilerGenerated]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.CHANGE_PROCESS_ERROR")]
	public enum CHANGE_PROCESS_ERROR
	{
		// Token: 0x040000E6 RID: 230
		CPE_NONE,
		// Token: 0x040000E7 RID: 231
		CPE_USERSTOP,
		// Token: 0x040000E8 RID: 232
		CPE_EOF_INTENTIONAL,
		// Token: 0x040000E9 RID: 233
		CPE_BEGIN_UNEXPECTED = 8,
		// Token: 0x040000EA RID: 234
		CPE_EOF_UNEXPECTED = 8,
		// Token: 0x040000EB RID: 235
		CPE_DISKFULL,
		// Token: 0x040000EC RID: 236
		CPE_CONNECTION,
		// Token: 0x040000ED RID: 237
		CPE_INTERNAL,
		// Token: 0x040000EE RID: 238
		CPE_OTHER
	}
}
