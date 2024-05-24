using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000964 RID: 2404
	[ComVisible(true)]
	public interface ICustomFactory
	{
		// Token: 0x06006221 RID: 25121
		MarshalByRefObject CreateInstance(Type serverType);
	}
}
