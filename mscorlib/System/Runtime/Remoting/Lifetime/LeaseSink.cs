using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x02000820 RID: 2080
	internal class LeaseSink : IMessageSink
	{
		// Token: 0x06005940 RID: 22848 RVA: 0x0013A673 File Offset: 0x00138873
		public LeaseSink(Lease lease, IMessageSink nextSink)
		{
			this.lease = lease;
			this.nextSink = nextSink;
		}

		// Token: 0x06005941 RID: 22849 RVA: 0x0013A689 File Offset: 0x00138889
		[SecurityCritical]
		public IMessage SyncProcessMessage(IMessage msg)
		{
			this.lease.RenewOnCall();
			return this.nextSink.SyncProcessMessage(msg);
		}

		// Token: 0x06005942 RID: 22850 RVA: 0x0013A6A2 File Offset: 0x001388A2
		[SecurityCritical]
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			this.lease.RenewOnCall();
			return this.nextSink.AsyncProcessMessage(msg, replySink);
		}

		// Token: 0x17000ECF RID: 3791
		// (get) Token: 0x06005943 RID: 22851 RVA: 0x0013A6BC File Offset: 0x001388BC
		public IMessageSink NextSink
		{
			[SecurityCritical]
			get
			{
				return this.nextSink;
			}
		}

		// Token: 0x040028A0 RID: 10400
		private Lease lease;

		// Token: 0x040028A1 RID: 10401
		private IMessageSink nextSink;
	}
}
