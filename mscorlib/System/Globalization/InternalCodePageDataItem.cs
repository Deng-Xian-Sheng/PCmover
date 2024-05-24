using System;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003B9 RID: 953
	internal struct InternalCodePageDataItem
	{
		// Token: 0x04001416 RID: 5142
		internal ushort codePage;

		// Token: 0x04001417 RID: 5143
		internal ushort uiFamilyCodePage;

		// Token: 0x04001418 RID: 5144
		internal uint flags;

		// Token: 0x04001419 RID: 5145
		[SecurityCritical]
		internal unsafe sbyte* Names;
	}
}
