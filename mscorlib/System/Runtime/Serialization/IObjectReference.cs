using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000733 RID: 1843
	[ComVisible(true)]
	public interface IObjectReference
	{
		// Token: 0x060051BA RID: 20922
		[SecurityCritical]
		object GetRealObject(StreamingContext context);
	}
}
