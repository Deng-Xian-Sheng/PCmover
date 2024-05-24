using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Resources
{
	// Token: 0x02000390 RID: 912
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class MissingManifestResourceException : SystemException
	{
		// Token: 0x06002CFE RID: 11518 RVA: 0x000AA0E3 File Offset: 0x000A82E3
		[__DynamicallyInvokable]
		public MissingManifestResourceException() : base(Environment.GetResourceString("Arg_MissingManifestResourceException"))
		{
			base.SetErrorCode(-2146233038);
		}

		// Token: 0x06002CFF RID: 11519 RVA: 0x000AA100 File Offset: 0x000A8300
		[__DynamicallyInvokable]
		public MissingManifestResourceException(string message) : base(message)
		{
			base.SetErrorCode(-2146233038);
		}

		// Token: 0x06002D00 RID: 11520 RVA: 0x000AA114 File Offset: 0x000A8314
		[__DynamicallyInvokable]
		public MissingManifestResourceException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233038);
		}

		// Token: 0x06002D01 RID: 11521 RVA: 0x000AA129 File Offset: 0x000A8329
		protected MissingManifestResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
