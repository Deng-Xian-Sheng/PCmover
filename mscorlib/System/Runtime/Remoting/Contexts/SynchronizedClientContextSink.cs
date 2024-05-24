using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x0200081B RID: 2075
	internal class SynchronizedClientContextSink : InternalSink, IMessageSink
	{
		// Token: 0x06005908 RID: 22792 RVA: 0x001399EE File Offset: 0x00137BEE
		[SecurityCritical]
		internal SynchronizedClientContextSink(SynchronizationAttribute prop, IMessageSink nextSink)
		{
			this._property = prop;
			this._nextSink = nextSink;
		}

		// Token: 0x06005909 RID: 22793 RVA: 0x00139A04 File Offset: 0x00137C04
		[SecuritySafeCritical]
		~SynchronizedClientContextSink()
		{
			this._property.Dispose();
		}

		// Token: 0x0600590A RID: 22794 RVA: 0x00139A38 File Offset: 0x00137C38
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			IMessage message;
			if (this._property.IsReEntrant)
			{
				this._property.HandleThreadExit();
				message = this._nextSink.SyncProcessMessage(reqMsg);
				this._property.HandleThreadReEntry();
			}
			else
			{
				LogicalCallContext logicalCallContext = (LogicalCallContext)reqMsg.Properties[Message.CallContextKey];
				string text = logicalCallContext.RemotingData.LogicalCallID;
				bool flag = false;
				if (text == null)
				{
					text = Identity.GetNewLogicalCallID();
					logicalCallContext.RemotingData.LogicalCallID = text;
					flag = true;
				}
				bool flag2 = false;
				if (this._property.SyncCallOutLCID == null)
				{
					this._property.SyncCallOutLCID = text;
					flag2 = true;
				}
				message = this._nextSink.SyncProcessMessage(reqMsg);
				if (flag2)
				{
					this._property.SyncCallOutLCID = null;
					if (flag)
					{
						LogicalCallContext logicalCallContext2 = (LogicalCallContext)message.Properties[Message.CallContextKey];
						logicalCallContext2.RemotingData.LogicalCallID = null;
					}
				}
			}
			return message;
		}

		// Token: 0x0600590B RID: 22795 RVA: 0x00139B1C File Offset: 0x00137D1C
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			if (!this._property.IsReEntrant)
			{
				LogicalCallContext logicalCallContext = (LogicalCallContext)reqMsg.Properties[Message.CallContextKey];
				string newLogicalCallID = Identity.GetNewLogicalCallID();
				logicalCallContext.RemotingData.LogicalCallID = newLogicalCallID;
				this._property.AsyncCallOutLCIDList.Add(newLogicalCallID);
			}
			SynchronizedClientContextSink.AsyncReplySink replySink2 = new SynchronizedClientContextSink.AsyncReplySink(replySink, this._property);
			return this._nextSink.AsyncProcessMessage(reqMsg, replySink2);
		}

		// Token: 0x17000EC3 RID: 3779
		// (get) Token: 0x0600590C RID: 22796 RVA: 0x00139B8E File Offset: 0x00137D8E
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._nextSink;
			}
		}

		// Token: 0x04002891 RID: 10385
		internal IMessageSink _nextSink;

		// Token: 0x04002892 RID: 10386
		[SecurityCritical]
		internal SynchronizationAttribute _property;

		// Token: 0x02000C70 RID: 3184
		internal class AsyncReplySink : IMessageSink
		{
			// Token: 0x060070A7 RID: 28839 RVA: 0x001847D1 File Offset: 0x001829D1
			[SecurityCritical]
			internal AsyncReplySink(IMessageSink nextSink, SynchronizationAttribute prop)
			{
				this._nextSink = nextSink;
				this._property = prop;
			}

			// Token: 0x060070A8 RID: 28840 RVA: 0x001847E8 File Offset: 0x001829E8
			[SecurityCritical]
			public virtual IMessage SyncProcessMessage(IMessage reqMsg)
			{
				WorkItem workItem = new WorkItem(reqMsg, this._nextSink, null);
				this._property.HandleWorkRequest(workItem);
				if (!this._property.IsReEntrant)
				{
					this._property.AsyncCallOutLCIDList.Remove(((LogicalCallContext)reqMsg.Properties[Message.CallContextKey]).RemotingData.LogicalCallID);
				}
				return workItem.ReplyMessage;
			}

			// Token: 0x060070A9 RID: 28841 RVA: 0x00184851 File Offset: 0x00182A51
			[SecurityCritical]
			public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
			{
				throw new NotSupportedException();
			}

			// Token: 0x17001352 RID: 4946
			// (get) Token: 0x060070AA RID: 28842 RVA: 0x00184858 File Offset: 0x00182A58
			public IMessageSink NextSink
			{
				[SecurityCritical]
				get
				{
					return this._nextSink;
				}
			}

			// Token: 0x040037F0 RID: 14320
			internal IMessageSink _nextSink;

			// Token: 0x040037F1 RID: 14321
			[SecurityCritical]
			internal SynchronizationAttribute _property;
		}
	}
}
