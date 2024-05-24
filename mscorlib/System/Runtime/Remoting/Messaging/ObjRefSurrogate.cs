using System;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200087C RID: 2172
	internal class ObjRefSurrogate : ISerializationSurrogate
	{
		// Token: 0x06005C55 RID: 23637 RVA: 0x0014387A File Offset: 0x00141A7A
		[SecurityCritical]
		public virtual void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			((ObjRef)obj).GetObjectData(info, context);
			info.AddValue("fIsMarshalled", 0);
		}

		// Token: 0x06005C56 RID: 23638 RVA: 0x001438B1 File Offset: 0x00141AB1
		[SecurityCritical]
		public virtual object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_PopulateData"));
		}
	}
}
