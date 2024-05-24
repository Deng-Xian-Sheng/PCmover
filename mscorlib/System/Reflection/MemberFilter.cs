using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005FF RID: 1535
	// (Invoke) Token: 0x060046CE RID: 18126
	[ComVisible(true)]
	[Serializable]
	public delegate bool MemberFilter(MemberInfo m, object filterCriteria);
}
