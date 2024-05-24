using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x0200081F RID: 2079
	internal class Lease : MarshalByRefObject, ILease
	{
		// Token: 0x06005924 RID: 22820 RVA: 0x00139D58 File Offset: 0x00137F58
		internal Lease(TimeSpan initialLeaseTime, TimeSpan renewOnCallTime, TimeSpan sponsorshipTimeout, MarshalByRefObject managedObject)
		{
			this.id = Lease.nextId++;
			this.renewOnCallTime = renewOnCallTime;
			this.sponsorshipTimeout = sponsorshipTimeout;
			this.initialLeaseTime = initialLeaseTime;
			this.managedObject = managedObject;
			this.leaseManager = LeaseManager.GetLeaseManager();
			this.sponsorTable = new Hashtable(10);
			this.state = LeaseState.Initial;
		}

		// Token: 0x06005925 RID: 22821 RVA: 0x00139DC0 File Offset: 0x00137FC0
		internal void ActivateLease()
		{
			this.leaseTime = DateTime.UtcNow.Add(this.initialLeaseTime);
			this.state = LeaseState.Active;
			this.leaseManager.ActivateLease(this);
		}

		// Token: 0x06005926 RID: 22822 RVA: 0x00139DF9 File Offset: 0x00137FF9
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x17000ECA RID: 3786
		// (get) Token: 0x06005927 RID: 22823 RVA: 0x00139DFC File Offset: 0x00137FFC
		// (set) Token: 0x06005928 RID: 22824 RVA: 0x00139E04 File Offset: 0x00138004
		public TimeSpan RenewOnCallTime
		{
			[SecurityCritical]
			get
			{
				return this.renewOnCallTime;
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				if (this.state == LeaseState.Initial)
				{
					this.renewOnCallTime = value;
					return;
				}
				throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_InitialStateRenewOnCall", new object[]
				{
					this.state.ToString()
				}));
			}
		}

		// Token: 0x17000ECB RID: 3787
		// (get) Token: 0x06005929 RID: 22825 RVA: 0x00139E3F File Offset: 0x0013803F
		// (set) Token: 0x0600592A RID: 22826 RVA: 0x00139E47 File Offset: 0x00138047
		public TimeSpan SponsorshipTimeout
		{
			[SecurityCritical]
			get
			{
				return this.sponsorshipTimeout;
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				if (this.state == LeaseState.Initial)
				{
					this.sponsorshipTimeout = value;
					return;
				}
				throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_InitialStateSponsorshipTimeout", new object[]
				{
					this.state.ToString()
				}));
			}
		}

		// Token: 0x17000ECC RID: 3788
		// (get) Token: 0x0600592B RID: 22827 RVA: 0x00139E82 File Offset: 0x00138082
		// (set) Token: 0x0600592C RID: 22828 RVA: 0x00139E8C File Offset: 0x0013808C
		public TimeSpan InitialLeaseTime
		{
			[SecurityCritical]
			get
			{
				return this.initialLeaseTime;
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				if (this.state != LeaseState.Initial)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_InitialStateInitialLeaseTime", new object[]
					{
						this.state.ToString()
					}));
				}
				this.initialLeaseTime = value;
				if (TimeSpan.Zero.CompareTo(value) >= 0)
				{
					this.state = LeaseState.Null;
					return;
				}
			}
		}

		// Token: 0x17000ECD RID: 3789
		// (get) Token: 0x0600592D RID: 22829 RVA: 0x00139EEB File Offset: 0x001380EB
		public TimeSpan CurrentLeaseTime
		{
			[SecurityCritical]
			get
			{
				return this.leaseTime.Subtract(DateTime.UtcNow);
			}
		}

		// Token: 0x17000ECE RID: 3790
		// (get) Token: 0x0600592E RID: 22830 RVA: 0x00139EFD File Offset: 0x001380FD
		public LeaseState CurrentState
		{
			[SecurityCritical]
			get
			{
				return this.state;
			}
		}

		// Token: 0x0600592F RID: 22831 RVA: 0x00139F05 File Offset: 0x00138105
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public void Register(ISponsor obj)
		{
			this.Register(obj, TimeSpan.Zero);
		}

		// Token: 0x06005930 RID: 22832 RVA: 0x00139F14 File Offset: 0x00138114
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public void Register(ISponsor obj, TimeSpan renewalTime)
		{
			lock (this)
			{
				if (this.state != LeaseState.Expired && !(this.sponsorshipTimeout == TimeSpan.Zero))
				{
					object sponsorId = this.GetSponsorId(obj);
					Hashtable obj2 = this.sponsorTable;
					lock (obj2)
					{
						if (renewalTime > TimeSpan.Zero)
						{
							this.AddTime(renewalTime);
						}
						if (!this.sponsorTable.ContainsKey(sponsorId))
						{
							this.sponsorTable[sponsorId] = new Lease.SponsorStateInfo(renewalTime, Lease.SponsorState.Initial);
						}
					}
				}
			}
		}

		// Token: 0x06005931 RID: 22833 RVA: 0x00139FCC File Offset: 0x001381CC
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public void Unregister(ISponsor sponsor)
		{
			lock (this)
			{
				if (this.state != LeaseState.Expired)
				{
					object sponsorId = this.GetSponsorId(sponsor);
					Hashtable obj = this.sponsorTable;
					lock (obj)
					{
						if (sponsorId != null)
						{
							this.leaseManager.DeleteSponsor(sponsorId);
							Lease.SponsorStateInfo sponsorStateInfo = (Lease.SponsorStateInfo)this.sponsorTable[sponsorId];
							this.sponsorTable.Remove(sponsorId);
						}
					}
				}
			}
		}

		// Token: 0x06005932 RID: 22834 RVA: 0x0013A06C File Offset: 0x0013826C
		[SecurityCritical]
		private object GetSponsorId(ISponsor obj)
		{
			object result = null;
			if (obj != null)
			{
				if (RemotingServices.IsTransparentProxy(obj))
				{
					result = RemotingServices.GetRealProxy(obj);
				}
				else
				{
					result = obj;
				}
			}
			return result;
		}

		// Token: 0x06005933 RID: 22835 RVA: 0x0013A094 File Offset: 0x00138294
		[SecurityCritical]
		private ISponsor GetSponsorFromId(object sponsorId)
		{
			RealProxy realProxy = sponsorId as RealProxy;
			object obj;
			if (realProxy != null)
			{
				obj = realProxy.GetTransparentProxy();
			}
			else
			{
				obj = sponsorId;
			}
			return (ISponsor)obj;
		}

		// Token: 0x06005934 RID: 22836 RVA: 0x0013A0BE File Offset: 0x001382BE
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public TimeSpan Renew(TimeSpan renewalTime)
		{
			return this.RenewInternal(renewalTime);
		}

		// Token: 0x06005935 RID: 22837 RVA: 0x0013A0C8 File Offset: 0x001382C8
		internal TimeSpan RenewInternal(TimeSpan renewalTime)
		{
			TimeSpan result;
			lock (this)
			{
				if (this.state == LeaseState.Expired)
				{
					result = TimeSpan.Zero;
				}
				else
				{
					this.AddTime(renewalTime);
					result = this.leaseTime.Subtract(DateTime.UtcNow);
				}
			}
			return result;
		}

		// Token: 0x06005936 RID: 22838 RVA: 0x0013A128 File Offset: 0x00138328
		internal void Remove()
		{
			if (this.state == LeaseState.Expired)
			{
				return;
			}
			this.state = LeaseState.Expired;
			this.leaseManager.DeleteLease(this);
		}

		// Token: 0x06005937 RID: 22839 RVA: 0x0013A148 File Offset: 0x00138348
		[SecurityCritical]
		internal void Cancel()
		{
			lock (this)
			{
				if (this.state != LeaseState.Expired)
				{
					this.Remove();
					RemotingServices.Disconnect(this.managedObject, false);
					RemotingServices.Disconnect(this);
				}
			}
		}

		// Token: 0x06005938 RID: 22840 RVA: 0x0013A1A4 File Offset: 0x001383A4
		internal void RenewOnCall()
		{
			lock (this)
			{
				if (this.state != LeaseState.Initial && this.state != LeaseState.Expired)
				{
					this.AddTime(this.renewOnCallTime);
				}
			}
		}

		// Token: 0x06005939 RID: 22841 RVA: 0x0013A1FC File Offset: 0x001383FC
		[SecurityCritical]
		internal void LeaseExpired(DateTime now)
		{
			lock (this)
			{
				if (this.state != LeaseState.Expired)
				{
					if (this.leaseTime.CompareTo(now) < 0)
					{
						this.ProcessNextSponsor();
					}
				}
			}
		}

		// Token: 0x0600593A RID: 22842 RVA: 0x0013A254 File Offset: 0x00138454
		[SecurityCritical]
		internal void SponsorCall(ISponsor sponsor)
		{
			bool flag = false;
			if (this.state == LeaseState.Expired)
			{
				return;
			}
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				try
				{
					object sponsorId = this.GetSponsorId(sponsor);
					this.sponsorCallThread = Thread.CurrentThread.GetHashCode();
					Lease.AsyncRenewal asyncRenewal = new Lease.AsyncRenewal(sponsor.Renewal);
					Lease.SponsorStateInfo sponsorStateInfo = (Lease.SponsorStateInfo)this.sponsorTable[sponsorId];
					sponsorStateInfo.sponsorState = Lease.SponsorState.Waiting;
					IAsyncResult asyncResult = asyncRenewal.BeginInvoke(this, new AsyncCallback(this.SponsorCallback), null);
					if (sponsorStateInfo.sponsorState == Lease.SponsorState.Waiting && this.state != LeaseState.Expired)
					{
						this.leaseManager.RegisterSponsorCall(this, sponsorId, this.sponsorshipTimeout);
					}
					this.sponsorCallThread = 0;
				}
				catch (Exception)
				{
					flag = true;
					this.sponsorCallThread = 0;
				}
			}
			if (flag)
			{
				this.Unregister(sponsor);
				this.ProcessNextSponsor();
			}
		}

		// Token: 0x0600593B RID: 22843 RVA: 0x0013A348 File Offset: 0x00138548
		[SecurityCritical]
		internal void SponsorTimeout(object sponsorId)
		{
			lock (this)
			{
				if (this.sponsorTable.ContainsKey(sponsorId))
				{
					Hashtable obj = this.sponsorTable;
					lock (obj)
					{
						Lease.SponsorStateInfo sponsorStateInfo = (Lease.SponsorStateInfo)this.sponsorTable[sponsorId];
						if (sponsorStateInfo.sponsorState == Lease.SponsorState.Waiting)
						{
							this.Unregister(this.GetSponsorFromId(sponsorId));
							this.ProcessNextSponsor();
						}
					}
				}
			}
		}

		// Token: 0x0600593C RID: 22844 RVA: 0x0013A3E4 File Offset: 0x001385E4
		[SecurityCritical]
		private void ProcessNextSponsor()
		{
			object obj = null;
			TimeSpan timeSpan = TimeSpan.Zero;
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				IDictionaryEnumerator enumerator = this.sponsorTable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					object key = enumerator.Key;
					Lease.SponsorStateInfo sponsorStateInfo = (Lease.SponsorStateInfo)enumerator.Value;
					if (sponsorStateInfo.sponsorState == Lease.SponsorState.Initial && timeSpan == TimeSpan.Zero)
					{
						timeSpan = sponsorStateInfo.renewalTime;
						obj = key;
					}
					else if (sponsorStateInfo.renewalTime > timeSpan)
					{
						timeSpan = sponsorStateInfo.renewalTime;
						obj = key;
					}
				}
			}
			if (obj != null)
			{
				this.SponsorCall(this.GetSponsorFromId(obj));
				return;
			}
			this.Cancel();
		}

		// Token: 0x0600593D RID: 22845 RVA: 0x0013A4AC File Offset: 0x001386AC
		[SecurityCritical]
		internal void SponsorCallback(object obj)
		{
			this.SponsorCallback((IAsyncResult)obj);
		}

		// Token: 0x0600593E RID: 22846 RVA: 0x0013A4BC File Offset: 0x001386BC
		[SecurityCritical]
		internal void SponsorCallback(IAsyncResult iar)
		{
			if (this.state == LeaseState.Expired)
			{
				return;
			}
			int hashCode = Thread.CurrentThread.GetHashCode();
			if (hashCode == this.sponsorCallThread)
			{
				WaitCallback callBack = new WaitCallback(this.SponsorCallback);
				ThreadPool.QueueUserWorkItem(callBack, iar);
				return;
			}
			AsyncResult asyncResult = (AsyncResult)iar;
			Lease.AsyncRenewal asyncRenewal = (Lease.AsyncRenewal)asyncResult.AsyncDelegate;
			ISponsor sponsor = (ISponsor)asyncRenewal.Target;
			Lease.SponsorStateInfo sponsorStateInfo = null;
			if (!iar.IsCompleted)
			{
				this.Unregister(sponsor);
				this.ProcessNextSponsor();
				return;
			}
			bool flag = false;
			TimeSpan renewalTime = TimeSpan.Zero;
			try
			{
				renewalTime = asyncRenewal.EndInvoke(iar);
			}
			catch (Exception)
			{
				flag = true;
			}
			if (flag)
			{
				this.Unregister(sponsor);
				this.ProcessNextSponsor();
				return;
			}
			object sponsorId = this.GetSponsorId(sponsor);
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				if (this.sponsorTable.ContainsKey(sponsorId))
				{
					sponsorStateInfo = (Lease.SponsorStateInfo)this.sponsorTable[sponsorId];
					sponsorStateInfo.sponsorState = Lease.SponsorState.Completed;
					sponsorStateInfo.renewalTime = renewalTime;
				}
			}
			if (sponsorStateInfo == null)
			{
				this.ProcessNextSponsor();
				return;
			}
			if (sponsorStateInfo.renewalTime == TimeSpan.Zero)
			{
				this.Unregister(sponsor);
				this.ProcessNextSponsor();
				return;
			}
			this.RenewInternal(sponsorStateInfo.renewalTime);
		}

		// Token: 0x0600593F RID: 22847 RVA: 0x0013A61C File Offset: 0x0013881C
		private void AddTime(TimeSpan renewalSpan)
		{
			if (this.state == LeaseState.Expired)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = this.leaseTime;
			DateTime dateTime2 = utcNow.Add(renewalSpan);
			if (this.leaseTime.CompareTo(dateTime2) < 0)
			{
				this.leaseManager.ChangedLeaseTime(this, dateTime2);
				this.leaseTime = dateTime2;
				this.state = LeaseState.Active;
			}
		}

		// Token: 0x04002895 RID: 10389
		internal int id;

		// Token: 0x04002896 RID: 10390
		internal DateTime leaseTime;

		// Token: 0x04002897 RID: 10391
		internal TimeSpan initialLeaseTime;

		// Token: 0x04002898 RID: 10392
		internal TimeSpan renewOnCallTime;

		// Token: 0x04002899 RID: 10393
		internal TimeSpan sponsorshipTimeout;

		// Token: 0x0400289A RID: 10394
		internal Hashtable sponsorTable;

		// Token: 0x0400289B RID: 10395
		internal int sponsorCallThread;

		// Token: 0x0400289C RID: 10396
		internal LeaseManager leaseManager;

		// Token: 0x0400289D RID: 10397
		internal MarshalByRefObject managedObject;

		// Token: 0x0400289E RID: 10398
		internal LeaseState state;

		// Token: 0x0400289F RID: 10399
		internal static volatile int nextId;

		// Token: 0x02000C71 RID: 3185
		// (Invoke) Token: 0x060070AC RID: 28844
		internal delegate TimeSpan AsyncRenewal(ILease lease);

		// Token: 0x02000C72 RID: 3186
		[Serializable]
		internal enum SponsorState
		{
			// Token: 0x040037F3 RID: 14323
			Initial,
			// Token: 0x040037F4 RID: 14324
			Waiting,
			// Token: 0x040037F5 RID: 14325
			Completed
		}

		// Token: 0x02000C73 RID: 3187
		internal sealed class SponsorStateInfo
		{
			// Token: 0x060070AF RID: 28847 RVA: 0x00184860 File Offset: 0x00182A60
			internal SponsorStateInfo(TimeSpan renewalTime, Lease.SponsorState sponsorState)
			{
				this.renewalTime = renewalTime;
				this.sponsorState = sponsorState;
			}

			// Token: 0x040037F6 RID: 14326
			internal TimeSpan renewalTime;

			// Token: 0x040037F7 RID: 14327
			internal Lease.SponsorState sponsorState;
		}
	}
}
