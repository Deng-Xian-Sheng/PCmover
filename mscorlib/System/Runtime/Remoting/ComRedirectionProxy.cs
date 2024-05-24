using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007BD RID: 1981
	internal class ComRedirectionProxy : MarshalByRefObject, IMessageSink
	{
		// Token: 0x060055CA RID: 21962 RVA: 0x00130BEA File Offset: 0x0012EDEA
		internal ComRedirectionProxy(MarshalByRefObject comObject, Type serverType)
		{
			this._comObject = comObject;
			this._serverType = serverType;
		}

		// Token: 0x060055CB RID: 21963 RVA: 0x00130C00 File Offset: 0x0012EE00
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			IMethodCallMessage reqMsg = (IMethodCallMessage)msg;
			IMethodReturnMessage methodReturnMessage = RemotingServices.ExecuteMessage(this._comObject, reqMsg);
			if (methodReturnMessage != null)
			{
				COMException ex = methodReturnMessage.Exception as COMException;
				if (ex != null && (ex._HResult == -2147023174 || ex._HResult == -2147023169))
				{
					this._comObject = (MarshalByRefObject)Activator.CreateInstance(this._serverType, true);
					methodReturnMessage = RemotingServices.ExecuteMessage(this._comObject, reqMsg);
				}
			}
			return methodReturnMessage;
		}

		// Token: 0x060055CC RID: 21964 RVA: 0x00130C74 File Offset: 0x0012EE74
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			IMessage msg2 = this.SyncProcessMessage(msg);
			if (replySink != null)
			{
				replySink.SyncProcessMessage(msg2);
			}
			return null;
		}

		// Token: 0x17000E24 RID: 3620
		// (get) Token: 0x060055CD RID: 21965 RVA: 0x00130C97 File Offset: 0x0012EE97
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x04002773 RID: 10099
		private MarshalByRefObject _comObject;

		// Token: 0x04002774 RID: 10100
		private Type _serverType;
	}
}
