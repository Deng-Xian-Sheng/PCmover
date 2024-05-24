using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000735 RID: 1845
	[ComVisible(true)]
	public interface ISerializationSurrogate
	{
		// Token: 0x060051BC RID: 20924
		[SecurityCritical]
		void GetObjectData(object obj, SerializationInfo info, StreamingContext context);

		// Token: 0x060051BD RID: 20925
		[SecurityCritical]
		object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector);
	}
}
