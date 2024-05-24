using System;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003B8 RID: 952
	internal struct InternalEncodingDataItem
	{
		// Token: 0x04001414 RID: 5140
		[SecurityCritical]
		internal unsafe sbyte* webName;

		// Token: 0x04001415 RID: 5141
		internal ushort codePage;
	}
}
