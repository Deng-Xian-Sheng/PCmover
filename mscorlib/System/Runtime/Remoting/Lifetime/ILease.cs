using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x0200081D RID: 2077
	[ComVisible(true)]
	public interface ILease
	{
		// Token: 0x06005917 RID: 22807
		[SecurityCritical]
		void Register(ISponsor obj, TimeSpan renewalTime);

		// Token: 0x06005918 RID: 22808
		[SecurityCritical]
		void Register(ISponsor obj);

		// Token: 0x06005919 RID: 22809
		[SecurityCritical]
		void Unregister(ISponsor obj);

		// Token: 0x0600591A RID: 22810
		[SecurityCritical]
		TimeSpan Renew(TimeSpan renewalTime);

		// Token: 0x17000EC5 RID: 3781
		// (get) Token: 0x0600591B RID: 22811
		// (set) Token: 0x0600591C RID: 22812
		TimeSpan RenewOnCallTime { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17000EC6 RID: 3782
		// (get) Token: 0x0600591D RID: 22813
		// (set) Token: 0x0600591E RID: 22814
		TimeSpan SponsorshipTimeout { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17000EC7 RID: 3783
		// (get) Token: 0x0600591F RID: 22815
		// (set) Token: 0x06005920 RID: 22816
		TimeSpan InitialLeaseTime { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17000EC8 RID: 3784
		// (get) Token: 0x06005921 RID: 22817
		TimeSpan CurrentLeaseTime { [SecurityCritical] get; }

		// Token: 0x17000EC9 RID: 3785
		// (get) Token: 0x06005922 RID: 22818
		LeaseState CurrentState { [SecurityCritical] get; }
	}
}
