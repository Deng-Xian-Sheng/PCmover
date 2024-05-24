using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200086B RID: 2155
	internal interface ISerializationRootObject
	{
		// Token: 0x06005BC1 RID: 23489
		[SecurityCritical]
		void RootSetObjectData(SerializationInfo info, StreamingContext ctx);
	}
}
