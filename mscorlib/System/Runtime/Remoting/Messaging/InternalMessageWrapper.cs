using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000871 RID: 2161
	[SecurityCritical]
	[ComVisible(true)]
	public class InternalMessageWrapper
	{
		// Token: 0x06005BF6 RID: 23542 RVA: 0x00142AB0 File Offset: 0x00140CB0
		public InternalMessageWrapper(IMessage msg)
		{
			this.WrappedMessage = msg;
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x00142AC0 File Offset: 0x00140CC0
		[SecurityCritical]
		internal object GetIdentityObject()
		{
			IInternalMessage internalMessage = this.WrappedMessage as IInternalMessage;
			if (internalMessage != null)
			{
				return internalMessage.IdentityObject;
			}
			InternalMessageWrapper internalMessageWrapper = this.WrappedMessage as InternalMessageWrapper;
			if (internalMessageWrapper != null)
			{
				return internalMessageWrapper.GetIdentityObject();
			}
			return null;
		}

		// Token: 0x06005BF8 RID: 23544 RVA: 0x00142AFC File Offset: 0x00140CFC
		[SecurityCritical]
		internal object GetServerIdentityObject()
		{
			IInternalMessage internalMessage = this.WrappedMessage as IInternalMessage;
			if (internalMessage != null)
			{
				return internalMessage.ServerIdentityObject;
			}
			InternalMessageWrapper internalMessageWrapper = this.WrappedMessage as InternalMessageWrapper;
			if (internalMessageWrapper != null)
			{
				return internalMessageWrapper.GetServerIdentityObject();
			}
			return null;
		}

		// Token: 0x0400298C RID: 10636
		protected IMessage WrappedMessage;
	}
}
