using System;
using System.Collections;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000862 RID: 2146
	internal class MCMDictionary : MessageDictionary
	{
		// Token: 0x06005B00 RID: 23296 RVA: 0x0013F37B File Offset: 0x0013D57B
		public MCMDictionary(IMethodCallMessage msg, IDictionary idict) : base(MCMDictionary.MCMkeys, idict)
		{
			this._mcmsg = msg;
		}

		// Token: 0x06005B01 RID: 23297 RVA: 0x0013F390 File Offset: 0x0013D590
		[SecuritySafeCritical]
		internal override object GetMessageValue(int i)
		{
			switch (i)
			{
			case 0:
				return this._mcmsg.Uri;
			case 1:
				return this._mcmsg.MethodName;
			case 2:
				return this._mcmsg.MethodSignature;
			case 3:
				return this._mcmsg.TypeName;
			case 4:
				return this._mcmsg.Args;
			case 5:
				return this.FetchLogicalCallContext();
			default:
				throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
			}
		}

		// Token: 0x06005B02 RID: 23298 RVA: 0x0013F410 File Offset: 0x0013D610
		[SecurityCritical]
		private LogicalCallContext FetchLogicalCallContext()
		{
			Message message = this._mcmsg as Message;
			if (message != null)
			{
				return message.GetLogicalCallContext();
			}
			MethodCall methodCall = this._mcmsg as MethodCall;
			if (methodCall != null)
			{
				return methodCall.GetLogicalCallContext();
			}
			throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
		}

		// Token: 0x06005B03 RID: 23299 RVA: 0x0013F458 File Offset: 0x0013D658
		[SecurityCritical]
		internal override void SetSpecialKey(int keyNum, object value)
		{
			Message message = this._mcmsg as Message;
			MethodCall methodCall = this._mcmsg as MethodCall;
			if (keyNum != 0)
			{
				if (keyNum != 1)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
				}
				if (message != null)
				{
					message.SetLogicalCallContext((LogicalCallContext)value);
					return;
				}
				throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
			}
			else
			{
				if (message != null)
				{
					message.Uri = (string)value;
					return;
				}
				if (methodCall != null)
				{
					methodCall.Uri = (string)value;
					return;
				}
				throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
			}
		}

		// Token: 0x04002937 RID: 10551
		public static string[] MCMkeys = new string[]
		{
			"__Uri",
			"__MethodName",
			"__MethodSignature",
			"__TypeName",
			"__Args",
			"__CallContext"
		};

		// Token: 0x04002938 RID: 10552
		internal IMethodCallMessage _mcmsg;
	}
}
