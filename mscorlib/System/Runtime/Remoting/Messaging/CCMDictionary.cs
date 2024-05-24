using System;
using System.Collections;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000860 RID: 2144
	internal class CCMDictionary : MessageDictionary
	{
		// Token: 0x06005AF6 RID: 23286 RVA: 0x0013EF46 File Offset: 0x0013D146
		public CCMDictionary(IConstructionCallMessage msg, IDictionary idict) : base(CCMDictionary.CCMkeys, idict)
		{
			this._ccmsg = msg;
		}

		// Token: 0x06005AF7 RID: 23287 RVA: 0x0013EF5C File Offset: 0x0013D15C
		[SecuritySafeCritical]
		internal override object GetMessageValue(int i)
		{
			switch (i)
			{
			case 0:
				return this._ccmsg.Uri;
			case 1:
				return this._ccmsg.MethodName;
			case 2:
				return this._ccmsg.MethodSignature;
			case 3:
				return this._ccmsg.TypeName;
			case 4:
				return this._ccmsg.Args;
			case 5:
				return this.FetchLogicalCallContext();
			case 6:
				return this._ccmsg.CallSiteActivationAttributes;
			case 7:
				return null;
			case 8:
				return this._ccmsg.ContextProperties;
			case 9:
				return this._ccmsg.Activator;
			case 10:
				return this._ccmsg.ActivationTypeName;
			default:
				throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
			}
		}

		// Token: 0x06005AF8 RID: 23288 RVA: 0x0013F024 File Offset: 0x0013D224
		[SecurityCritical]
		private LogicalCallContext FetchLogicalCallContext()
		{
			ConstructorCallMessage constructorCallMessage = this._ccmsg as ConstructorCallMessage;
			if (constructorCallMessage != null)
			{
				return constructorCallMessage.GetLogicalCallContext();
			}
			if (this._ccmsg is ConstructionCall)
			{
				return ((MethodCall)this._ccmsg).GetLogicalCallContext();
			}
			throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x0013F074 File Offset: 0x0013D274
		[SecurityCritical]
		internal override void SetSpecialKey(int keyNum, object value)
		{
			if (keyNum == 0)
			{
				((ConstructorCallMessage)this._ccmsg).Uri = (string)value;
				return;
			}
			if (keyNum != 1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
			}
			((ConstructorCallMessage)this._ccmsg).SetLogicalCallContext((LogicalCallContext)value);
		}

		// Token: 0x04002931 RID: 10545
		public static string[] CCMkeys = new string[]
		{
			"__Uri",
			"__MethodName",
			"__MethodSignature",
			"__TypeName",
			"__Args",
			"__CallContext",
			"__CallSiteActivationAttributes",
			"__ActivationType",
			"__ContextProperties",
			"__Activator",
			"__ActivationTypeName"
		};

		// Token: 0x04002932 RID: 10546
		internal IConstructionCallMessage _ccmsg;
	}
}
