using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200086E RID: 2158
	[Serializable]
	internal class TransitionCall : IMessage, IInternalMessage, IMessageSink, ISerializable
	{
		// Token: 0x06005BCB RID: 23499 RVA: 0x00142170 File Offset: 0x00140370
		[SecurityCritical]
		internal TransitionCall(IntPtr targetCtxID, CrossContextDelegate deleg)
		{
			this._sourceCtxID = Thread.CurrentContext.InternalContextID;
			this._targetCtxID = targetCtxID;
			this._delegate = deleg;
			this._targetDomainID = 0;
			this._eeData = IntPtr.Zero;
			this._srvID = new ServerIdentity(null, Thread.GetContextInternal(this._targetCtxID));
			this._ID = this._srvID;
			this._ID.RaceSetChannelSink(CrossContextChannel.MessageSink);
			this._srvID.RaceSetServerObjectChain(this);
		}

		// Token: 0x06005BCC RID: 23500 RVA: 0x001421F4 File Offset: 0x001403F4
		[SecurityCritical]
		internal TransitionCall(IntPtr targetCtxID, IntPtr eeData, int targetDomainID)
		{
			this._sourceCtxID = Thread.CurrentContext.InternalContextID;
			this._targetCtxID = targetCtxID;
			this._delegate = null;
			this._targetDomainID = targetDomainID;
			this._eeData = eeData;
			this._srvID = null;
			this._ID = new Identity("TransitionCallURI", null);
			CrossAppDomainData data = new CrossAppDomainData(this._targetCtxID, this._targetDomainID, Identity.ProcessGuid);
			string text;
			IMessageSink channelSink = CrossAppDomainChannel.AppDomainChannel.CreateMessageSink(null, data, out text);
			this._ID.RaceSetChannelSink(channelSink);
		}

		// Token: 0x06005BCD RID: 23501 RVA: 0x00142280 File Offset: 0x00140480
		internal TransitionCall(SerializationInfo info, StreamingContext context)
		{
			if (info == null || context.State != StreamingContextStates.CrossAppDomain)
			{
				throw new ArgumentNullException("info");
			}
			this._props = (IDictionary)info.GetValue("props", typeof(IDictionary));
			this._delegate = (CrossContextDelegate)info.GetValue("delegate", typeof(CrossContextDelegate));
			this._sourceCtxID = (IntPtr)info.GetValue("sourceCtxID", typeof(IntPtr));
			this._targetCtxID = (IntPtr)info.GetValue("targetCtxID", typeof(IntPtr));
			this._eeData = (IntPtr)info.GetValue("eeData", typeof(IntPtr));
			this._targetDomainID = info.GetInt32("targetDomainID");
		}

		// Token: 0x17000FA9 RID: 4009
		// (get) Token: 0x06005BCE RID: 23502 RVA: 0x00142360 File Offset: 0x00140560
		public IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._props == null)
				{
					lock (this)
					{
						if (this._props == null)
						{
							this._props = new Hashtable();
						}
					}
				}
				return this._props;
			}
		}

		// Token: 0x17000FAA RID: 4010
		// (get) Token: 0x06005BCF RID: 23503 RVA: 0x001423B8 File Offset: 0x001405B8
		// (set) Token: 0x06005BD0 RID: 23504 RVA: 0x0014243C File Offset: 0x0014063C
		ServerIdentity IInternalMessage.ServerIdentityObject
		{
			[SecurityCritical]
			get
			{
				if (this._targetDomainID != 0 && this._srvID == null)
				{
					lock (this)
					{
						if (Thread.GetContextInternal(this._targetCtxID) == null)
						{
							Context defaultContext = Context.DefaultContext;
						}
						this._srvID = new ServerIdentity(null, Thread.GetContextInternal(this._targetCtxID));
						this._srvID.RaceSetServerObjectChain(this);
					}
				}
				return this._srvID;
			}
			[SecurityCritical]
			set
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
			}
		}

		// Token: 0x17000FAB RID: 4011
		// (get) Token: 0x06005BD1 RID: 23505 RVA: 0x0014244D File Offset: 0x0014064D
		// (set) Token: 0x06005BD2 RID: 23506 RVA: 0x00142455 File Offset: 0x00140655
		Identity IInternalMessage.IdentityObject
		{
			[SecurityCritical]
			get
			{
				return this._ID;
			}
			[SecurityCritical]
			set
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
			}
		}

		// Token: 0x06005BD3 RID: 23507 RVA: 0x00142466 File Offset: 0x00140666
		[SecurityCritical]
		void IInternalMessage.SetURI(string uri)
		{
			throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
		}

		// Token: 0x06005BD4 RID: 23508 RVA: 0x00142477 File Offset: 0x00140677
		[SecurityCritical]
		void IInternalMessage.SetCallContext(LogicalCallContext callContext)
		{
			throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
		}

		// Token: 0x06005BD5 RID: 23509 RVA: 0x00142488 File Offset: 0x00140688
		[SecurityCritical]
		bool IInternalMessage.HasProperties()
		{
			throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
		}

		// Token: 0x06005BD6 RID: 23510 RVA: 0x0014249C File Offset: 0x0014069C
		[SecurityCritical]
		public IMessage SyncProcessMessage(IMessage msg)
		{
			try
			{
				LogicalCallContext oldcctx = Message.PropagateCallContextFromMessageToThread(msg);
				if (this._delegate != null)
				{
					this._delegate();
				}
				else
				{
					CallBackHelper @object = new CallBackHelper(this._eeData, true, this._targetDomainID);
					CrossContextDelegate crossContextDelegate = new CrossContextDelegate(@object.Func);
					crossContextDelegate();
				}
				Message.PropagateCallContextFromThreadToMessage(msg, oldcctx);
			}
			catch (Exception e)
			{
				ReturnMessage returnMessage = new ReturnMessage(e, new ErrorMessage());
				returnMessage.SetLogicalCallContext((LogicalCallContext)msg.Properties[Message.CallContextKey]);
				return returnMessage;
			}
			return this;
		}

		// Token: 0x06005BD7 RID: 23511 RVA: 0x0014253C File Offset: 0x0014073C
		[SecurityCritical]
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			IMessage msg2 = this.SyncProcessMessage(msg);
			replySink.SyncProcessMessage(msg2);
			return null;
		}

		// Token: 0x17000FAC RID: 4012
		// (get) Token: 0x06005BD8 RID: 23512 RVA: 0x0014255A File Offset: 0x0014075A
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x06005BD9 RID: 23513 RVA: 0x00142560 File Offset: 0x00140760
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null || context.State != StreamingContextStates.CrossAppDomain)
			{
				throw new ArgumentNullException("info");
			}
			info.AddValue("props", this._props, typeof(IDictionary));
			info.AddValue("delegate", this._delegate, typeof(CrossContextDelegate));
			info.AddValue("sourceCtxID", this._sourceCtxID);
			info.AddValue("targetCtxID", this._targetCtxID);
			info.AddValue("targetDomainID", this._targetDomainID);
			info.AddValue("eeData", this._eeData);
		}

		// Token: 0x0400297B RID: 10619
		private IDictionary _props;

		// Token: 0x0400297C RID: 10620
		private IntPtr _sourceCtxID;

		// Token: 0x0400297D RID: 10621
		private IntPtr _targetCtxID;

		// Token: 0x0400297E RID: 10622
		private int _targetDomainID;

		// Token: 0x0400297F RID: 10623
		private ServerIdentity _srvID;

		// Token: 0x04002980 RID: 10624
		private Identity _ID;

		// Token: 0x04002981 RID: 10625
		private CrossContextDelegate _delegate;

		// Token: 0x04002982 RID: 10626
		private IntPtr _eeData;
	}
}
