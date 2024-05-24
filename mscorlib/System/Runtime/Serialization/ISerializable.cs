using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000734 RID: 1844
	[ComVisible(true)]
	public interface ISerializable
	{
		// Token: 0x060051BB RID: 20923
		[SecurityCritical]
		void GetObjectData(SerializationInfo info, StreamingContext context);
	}
}
