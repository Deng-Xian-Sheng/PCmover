using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007BC RID: 1980
	internal class RedirectionProxy : MarshalByRefObject, IMessageSink
	{
		// Token: 0x060055C5 RID: 21957 RVA: 0x00130B00 File Offset: 0x0012ED00
		[SecurityCritical]
		internal RedirectionProxy(MarshalByRefObject proxy, Type serverType)
		{
			this._proxy = proxy;
			this._realProxy = RemotingServices.GetRealProxy(this._proxy);
			this._serverType = serverType;
			this._objectMode = WellKnownObjectMode.Singleton;
		}

		// Token: 0x17000E22 RID: 3618
		// (set) Token: 0x060055C6 RID: 21958 RVA: 0x00130B2E File Offset: 0x0012ED2E
		public WellKnownObjectMode ObjectMode
		{
			set
			{
				this._objectMode = value;
			}
		}

		// Token: 0x060055C7 RID: 21959 RVA: 0x00130B38 File Offset: 0x0012ED38
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage msg)
		{
			IMessage result = null;
			try
			{
				msg.Properties["__Uri"] = this._realProxy.IdentityObject.URI;
				if (this._objectMode == WellKnownObjectMode.Singleton)
				{
					result = this._realProxy.Invoke(msg);
				}
				else
				{
					MarshalByRefObject proxy = (MarshalByRefObject)Activator.CreateInstance(this._serverType, true);
					RealProxy realProxy = RemotingServices.GetRealProxy(proxy);
					result = realProxy.Invoke(msg);
				}
			}
			catch (Exception e)
			{
				result = new ReturnMessage(e, msg as IMethodCallMessage);
			}
			return result;
		}

		// Token: 0x060055C8 RID: 21960 RVA: 0x00130BC4 File Offset: 0x0012EDC4
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

		// Token: 0x17000E23 RID: 3619
		// (get) Token: 0x060055C9 RID: 21961 RVA: 0x00130BE7 File Offset: 0x0012EDE7
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x0400276F RID: 10095
		private MarshalByRefObject _proxy;

		// Token: 0x04002770 RID: 10096
		[SecurityCritical]
		private RealProxy _realProxy;

		// Token: 0x04002771 RID: 10097
		private Type _serverType;

		// Token: 0x04002772 RID: 10098
		private WellKnownObjectMode _objectMode;
	}
}
