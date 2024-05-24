using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x02000824 RID: 2084
	[Serializable]
	internal class LeaseLifeTimeServiceProperty : IContextProperty, IContributeObjectSink
	{
		// Token: 0x17000ED5 RID: 3797
		// (get) Token: 0x06005962 RID: 22882 RVA: 0x0013AF55 File Offset: 0x00139155
		public string Name
		{
			[SecurityCritical]
			get
			{
				return "LeaseLifeTimeServiceProperty";
			}
		}

		// Token: 0x06005963 RID: 22883 RVA: 0x0013AF5C File Offset: 0x0013915C
		[SecurityCritical]
		public bool IsNewContextOK(Context newCtx)
		{
			return true;
		}

		// Token: 0x06005964 RID: 22884 RVA: 0x0013AF5F File Offset: 0x0013915F
		[SecurityCritical]
		public void Freeze(Context newContext)
		{
		}

		// Token: 0x06005965 RID: 22885 RVA: 0x0013AF64 File Offset: 0x00139164
		[SecurityCritical]
		public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
		{
			bool flag;
			ServerIdentity serverIdentity = (ServerIdentity)MarshalByRefObject.GetIdentity(obj, out flag);
			if (serverIdentity.IsSingleCall())
			{
				return nextSink;
			}
			object obj2 = obj.InitializeLifetimeService();
			if (obj2 == null)
			{
				return nextSink;
			}
			if (!(obj2 is ILease))
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_ILeaseReturn", new object[]
				{
					obj2
				}));
			}
			ILease lease = (ILease)obj2;
			if (lease.InitialLeaseTime.CompareTo(TimeSpan.Zero) <= 0)
			{
				if (lease is Lease)
				{
					((Lease)lease).Remove();
				}
				return nextSink;
			}
			Lease lease2 = null;
			ServerIdentity obj3 = serverIdentity;
			lock (obj3)
			{
				if (serverIdentity.Lease != null)
				{
					lease2 = serverIdentity.Lease;
					lease2.Renew(lease2.InitialLeaseTime);
				}
				else
				{
					if (!(lease is Lease))
					{
						lease2 = (Lease)LifetimeServices.GetLeaseInitial(obj);
						if (lease2.CurrentState == LeaseState.Initial)
						{
							lease2.InitialLeaseTime = lease.InitialLeaseTime;
							lease2.RenewOnCallTime = lease.RenewOnCallTime;
							lease2.SponsorshipTimeout = lease.SponsorshipTimeout;
						}
					}
					else
					{
						lease2 = (Lease)lease;
					}
					serverIdentity.Lease = lease2;
					if (serverIdentity.ObjectRef != null)
					{
						lease2.ActivateLease();
					}
				}
			}
			if (lease2.RenewOnCallTime > TimeSpan.Zero)
			{
				return new LeaseSink(lease2, nextSink);
			}
			return nextSink;
		}
	}
}
