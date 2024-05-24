using System;
using System.Collections;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000880 RID: 2176
	[Serializable]
	internal class InternalSink
	{
		// Token: 0x06005C72 RID: 23666 RVA: 0x001445B8 File Offset: 0x001427B8
		[SecurityCritical]
		internal static IMessage ValidateMessage(IMessage reqMsg)
		{
			IMessage result = null;
			if (reqMsg == null)
			{
				result = new ReturnMessage(new ArgumentNullException("reqMsg"), null);
			}
			return result;
		}

		// Token: 0x06005C73 RID: 23667 RVA: 0x001445DC File Offset: 0x001427DC
		[SecurityCritical]
		internal static IMessage DisallowAsyncActivation(IMessage reqMsg)
		{
			if (reqMsg is IConstructionCallMessage)
			{
				return new ReturnMessage(new RemotingException(Environment.GetResourceString("Remoting_Activation_AsyncUnsupported")), null);
			}
			return null;
		}

		// Token: 0x06005C74 RID: 23668 RVA: 0x00144600 File Offset: 0x00142800
		[SecurityCritical]
		internal static Identity GetIdentity(IMessage reqMsg)
		{
			Identity identity = null;
			if (reqMsg is IInternalMessage)
			{
				identity = ((IInternalMessage)reqMsg).IdentityObject;
			}
			else if (reqMsg is InternalMessageWrapper)
			{
				identity = (Identity)((InternalMessageWrapper)reqMsg).GetIdentityObject();
			}
			if (identity == null)
			{
				string uri = InternalSink.GetURI(reqMsg);
				identity = IdentityHolder.ResolveIdentity(uri);
				if (identity == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Remoting_ServerObjectNotFound", new object[]
					{
						uri
					}));
				}
			}
			return identity;
		}

		// Token: 0x06005C75 RID: 23669 RVA: 0x00144670 File Offset: 0x00142870
		[SecurityCritical]
		internal static ServerIdentity GetServerIdentity(IMessage reqMsg)
		{
			ServerIdentity serverIdentity = null;
			bool flag = false;
			IInternalMessage internalMessage = reqMsg as IInternalMessage;
			if (internalMessage != null)
			{
				serverIdentity = ((IInternalMessage)reqMsg).ServerIdentityObject;
				flag = true;
			}
			else if (reqMsg is InternalMessageWrapper)
			{
				serverIdentity = (ServerIdentity)((InternalMessageWrapper)reqMsg).GetServerIdentityObject();
			}
			if (serverIdentity == null)
			{
				string uri = InternalSink.GetURI(reqMsg);
				Identity identity = IdentityHolder.ResolveIdentity(uri);
				if (identity is ServerIdentity)
				{
					serverIdentity = (ServerIdentity)identity;
					if (flag)
					{
						internalMessage.ServerIdentityObject = serverIdentity;
					}
				}
			}
			return serverIdentity;
		}

		// Token: 0x06005C76 RID: 23670 RVA: 0x001446E4 File Offset: 0x001428E4
		[SecurityCritical]
		internal static string GetURI(IMessage msg)
		{
			string result = null;
			IMethodMessage methodMessage = msg as IMethodMessage;
			if (methodMessage != null)
			{
				result = methodMessage.Uri;
			}
			else
			{
				IDictionary properties = msg.Properties;
				if (properties != null)
				{
					result = (string)properties["__Uri"];
				}
			}
			return result;
		}
	}
}
