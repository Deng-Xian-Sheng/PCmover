using System;
using System.Collections;
using System.Diagnostics;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x02000821 RID: 2081
	internal class LeaseManager
	{
		// Token: 0x06005944 RID: 22852 RVA: 0x0013A6C4 File Offset: 0x001388C4
		internal static bool IsInitialized()
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			LeaseManager leaseManager = remotingData.LeaseManager;
			return leaseManager != null;
		}

		// Token: 0x06005945 RID: 22853 RVA: 0x0013A6E8 File Offset: 0x001388E8
		[SecurityCritical]
		internal static LeaseManager GetLeaseManager(TimeSpan pollTime)
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			LeaseManager leaseManager = remotingData.LeaseManager;
			if (leaseManager == null)
			{
				DomainSpecificRemotingData obj = remotingData;
				lock (obj)
				{
					if (remotingData.LeaseManager == null)
					{
						remotingData.LeaseManager = new LeaseManager(pollTime);
					}
					leaseManager = remotingData.LeaseManager;
				}
			}
			return leaseManager;
		}

		// Token: 0x06005946 RID: 22854 RVA: 0x0013A750 File Offset: 0x00138950
		internal static LeaseManager GetLeaseManager()
		{
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			return remotingData.LeaseManager;
		}

		// Token: 0x06005947 RID: 22855 RVA: 0x0013A770 File Offset: 0x00138970
		[SecurityCritical]
		private LeaseManager(TimeSpan pollTime)
		{
			this.pollTime = pollTime;
			this.leaseTimeAnalyzerDelegate = new TimerCallback(this.LeaseTimeAnalyzer);
			this.waitHandle = new AutoResetEvent(false);
			this.leaseTimer = new Timer(this.leaseTimeAnalyzerDelegate, null, -1, -1);
			this.leaseTimer.Change((int)pollTime.TotalMilliseconds, -1);
		}

		// Token: 0x06005948 RID: 22856 RVA: 0x0013A7F8 File Offset: 0x001389F8
		internal void ChangePollTime(TimeSpan pollTime)
		{
			this.pollTime = pollTime;
		}

		// Token: 0x06005949 RID: 22857 RVA: 0x0013A804 File Offset: 0x00138A04
		internal void ActivateLease(Lease lease)
		{
			Hashtable obj = this.leaseToTimeTable;
			lock (obj)
			{
				this.leaseToTimeTable[lease] = lease.leaseTime;
			}
		}

		// Token: 0x0600594A RID: 22858 RVA: 0x0013A858 File Offset: 0x00138A58
		internal void DeleteLease(Lease lease)
		{
			Hashtable obj = this.leaseToTimeTable;
			lock (obj)
			{
				this.leaseToTimeTable.Remove(lease);
			}
		}

		// Token: 0x0600594B RID: 22859 RVA: 0x0013A8A0 File Offset: 0x00138AA0
		[Conditional("_LOGGING")]
		internal void DumpLeases(Lease[] leases)
		{
			for (int i = 0; i < leases.Length; i++)
			{
			}
		}

		// Token: 0x0600594C RID: 22860 RVA: 0x0013A8BC File Offset: 0x00138ABC
		internal ILease GetLease(MarshalByRefObject obj)
		{
			bool flag = true;
			Identity identity = MarshalByRefObject.GetIdentity(obj, out flag);
			if (identity == null)
			{
				return null;
			}
			return identity.Lease;
		}

		// Token: 0x0600594D RID: 22861 RVA: 0x0013A8E0 File Offset: 0x00138AE0
		internal void ChangedLeaseTime(Lease lease, DateTime newTime)
		{
			Hashtable obj = this.leaseToTimeTable;
			lock (obj)
			{
				this.leaseToTimeTable[lease] = newTime;
			}
		}

		// Token: 0x0600594E RID: 22862 RVA: 0x0013A92C File Offset: 0x00138B2C
		internal void RegisterSponsorCall(Lease lease, object sponsorId, TimeSpan sponsorshipTimeOut)
		{
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				DateTime sponsorWaitTime = DateTime.UtcNow.Add(sponsorshipTimeOut);
				this.sponsorTable[sponsorId] = new LeaseManager.SponsorInfo(lease, sponsorId, sponsorWaitTime);
			}
		}

		// Token: 0x0600594F RID: 22863 RVA: 0x0013A98C File Offset: 0x00138B8C
		internal void DeleteSponsor(object sponsorId)
		{
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				this.sponsorTable.Remove(sponsorId);
			}
		}

		// Token: 0x06005950 RID: 22864 RVA: 0x0013A9D4 File Offset: 0x00138BD4
		[SecurityCritical]
		private void LeaseTimeAnalyzer(object state)
		{
			DateTime utcNow = DateTime.UtcNow;
			Hashtable obj = this.leaseToTimeTable;
			lock (obj)
			{
				IDictionaryEnumerator enumerator = this.leaseToTimeTable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DateTime dateTime = (DateTime)enumerator.Value;
					Lease value = (Lease)enumerator.Key;
					if (dateTime.CompareTo(utcNow) < 0)
					{
						this.tempObjects.Add(value);
					}
				}
				for (int i = 0; i < this.tempObjects.Count; i++)
				{
					Lease key = (Lease)this.tempObjects[i];
					this.leaseToTimeTable.Remove(key);
				}
			}
			for (int j = 0; j < this.tempObjects.Count; j++)
			{
				Lease lease = (Lease)this.tempObjects[j];
				if (lease != null)
				{
					lease.LeaseExpired(utcNow);
				}
			}
			this.tempObjects.Clear();
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				IDictionaryEnumerator enumerator2 = this.sponsorTable.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					object key2 = enumerator2.Key;
					LeaseManager.SponsorInfo sponsorInfo = (LeaseManager.SponsorInfo)enumerator2.Value;
					if (sponsorInfo.sponsorWaitTime.CompareTo(utcNow) < 0)
					{
						this.tempObjects.Add(sponsorInfo);
					}
				}
				for (int k = 0; k < this.tempObjects.Count; k++)
				{
					LeaseManager.SponsorInfo sponsorInfo2 = (LeaseManager.SponsorInfo)this.tempObjects[k];
					this.sponsorTable.Remove(sponsorInfo2.sponsorId);
				}
			}
			for (int l = 0; l < this.tempObjects.Count; l++)
			{
				LeaseManager.SponsorInfo sponsorInfo3 = (LeaseManager.SponsorInfo)this.tempObjects[l];
				if (sponsorInfo3 != null && sponsorInfo3.lease != null)
				{
					sponsorInfo3.lease.SponsorTimeout(sponsorInfo3.sponsorId);
					this.tempObjects[l] = null;
				}
			}
			this.tempObjects.Clear();
			this.leaseTimer.Change((int)this.pollTime.TotalMilliseconds, -1);
		}

		// Token: 0x040028A2 RID: 10402
		private Hashtable leaseToTimeTable = new Hashtable();

		// Token: 0x040028A3 RID: 10403
		private Hashtable sponsorTable = new Hashtable();

		// Token: 0x040028A4 RID: 10404
		private TimeSpan pollTime;

		// Token: 0x040028A5 RID: 10405
		private AutoResetEvent waitHandle;

		// Token: 0x040028A6 RID: 10406
		private TimerCallback leaseTimeAnalyzerDelegate;

		// Token: 0x040028A7 RID: 10407
		private volatile Timer leaseTimer;

		// Token: 0x040028A8 RID: 10408
		private ArrayList tempObjects = new ArrayList(10);

		// Token: 0x02000C74 RID: 3188
		internal class SponsorInfo
		{
			// Token: 0x060070B0 RID: 28848 RVA: 0x00184876 File Offset: 0x00182A76
			internal SponsorInfo(Lease lease, object sponsorId, DateTime sponsorWaitTime)
			{
				this.lease = lease;
				this.sponsorId = sponsorId;
				this.sponsorWaitTime = sponsorWaitTime;
			}

			// Token: 0x040037F8 RID: 14328
			internal Lease lease;

			// Token: 0x040037F9 RID: 14329
			internal object sponsorId;

			// Token: 0x040037FA RID: 14330
			internal DateTime sponsorWaitTime;
		}
	}
}
