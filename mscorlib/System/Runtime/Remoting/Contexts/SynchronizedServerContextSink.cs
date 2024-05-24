using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000819 RID: 2073
	internal class SynchronizedServerContextSink : InternalSink, IMessageSink
	{
		// Token: 0x060058F6 RID: 22774 RVA: 0x001397E0 File Offset: 0x001379E0
		[SecurityCritical]
		internal SynchronizedServerContextSink(SynchronizationAttribute prop, IMessageSink nextSink)
		{
			this._property = prop;
			this._nextSink = nextSink;
		}

		// Token: 0x060058F7 RID: 22775 RVA: 0x001397F8 File Offset: 0x001379F8
		[SecuritySafeCritical]
		~SynchronizedServerContextSink()
		{
			this._property.Dispose();
		}

		// Token: 0x060058F8 RID: 22776 RVA: 0x0013982C File Offset: 0x00137A2C
		[SecurityCritical]
		public virtual IMessage SyncProcessMessage(IMessage reqMsg)
		{
			WorkItem workItem = new WorkItem(reqMsg, this._nextSink, null);
			this._property.HandleWorkRequest(workItem);
			return workItem.ReplyMessage;
		}

		// Token: 0x060058F9 RID: 22777 RVA: 0x0013985C File Offset: 0x00137A5C
		[SecurityCritical]
		public virtual IMessageCtrl AsyncProcessMessage(IMessage reqMsg, IMessageSink replySink)
		{
			WorkItem workItem = new WorkItem(reqMsg, this._nextSink, replySink);
			workItem.SetAsync();
			this._property.HandleWorkRequest(workItem);
			return null;
		}

		// Token: 0x17000EC1 RID: 3777
		// (get) Token: 0x060058FA RID: 22778 RVA: 0x0013988A File Offset: 0x00137A8A
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this._nextSink;
			}
		}

		// Token: 0x04002883 RID: 10371
		internal IMessageSink _nextSink;

		// Token: 0x04002884 RID: 10372
		[SecurityCritical]
		internal SynchronizationAttribute _property;
	}
}
