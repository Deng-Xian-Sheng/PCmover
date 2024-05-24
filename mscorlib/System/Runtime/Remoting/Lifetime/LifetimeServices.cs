using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x02000823 RID: 2083
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class LifetimeServices
	{
		// Token: 0x06005951 RID: 22865 RVA: 0x0013AC1C File Offset: 0x00138E1C
		private static TimeSpan GetTimeSpan(ref long ticks)
		{
			return TimeSpan.FromTicks(Volatile.Read(ref ticks));
		}

		// Token: 0x06005952 RID: 22866 RVA: 0x0013AC29 File Offset: 0x00138E29
		private static void SetTimeSpan(ref long ticks, TimeSpan value)
		{
			Volatile.Write(ref ticks, value.Ticks);
		}

		// Token: 0x17000ED0 RID: 3792
		// (get) Token: 0x06005953 RID: 22867 RVA: 0x0013AC38 File Offset: 0x00138E38
		private static object LifetimeSyncObject
		{
			get
			{
				if (LifetimeServices.s_LifetimeSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange(ref LifetimeServices.s_LifetimeSyncObject, value, null);
				}
				return LifetimeServices.s_LifetimeSyncObject;
			}
		}

		// Token: 0x06005954 RID: 22868 RVA: 0x0013AC64 File Offset: 0x00138E64
		[Obsolete("Do not create instances of the LifetimeServices class.  Call the static methods directly on this type instead", true)]
		public LifetimeServices()
		{
		}

		// Token: 0x17000ED1 RID: 3793
		// (get) Token: 0x06005955 RID: 22869 RVA: 0x0013AC6C File Offset: 0x00138E6C
		// (set) Token: 0x06005956 RID: 22870 RVA: 0x0013AC78 File Offset: 0x00138E78
		public static TimeSpan LeaseTime
		{
			get
			{
				return LifetimeServices.GetTimeSpan(ref LifetimeServices.s_leaseTimeTicks);
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				object lifetimeSyncObject = LifetimeServices.LifetimeSyncObject;
				lock (lifetimeSyncObject)
				{
					if (LifetimeServices.s_isLeaseTime)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_SetOnce", new object[]
						{
							"LeaseTime"
						}));
					}
					LifetimeServices.SetTimeSpan(ref LifetimeServices.s_leaseTimeTicks, value);
					LifetimeServices.s_isLeaseTime = true;
				}
			}
		}

		// Token: 0x17000ED2 RID: 3794
		// (get) Token: 0x06005957 RID: 22871 RVA: 0x0013ACE8 File Offset: 0x00138EE8
		// (set) Token: 0x06005958 RID: 22872 RVA: 0x0013ACF4 File Offset: 0x00138EF4
		public static TimeSpan RenewOnCallTime
		{
			get
			{
				return LifetimeServices.GetTimeSpan(ref LifetimeServices.s_renewOnCallTimeTicks);
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				object lifetimeSyncObject = LifetimeServices.LifetimeSyncObject;
				lock (lifetimeSyncObject)
				{
					if (LifetimeServices.s_isRenewOnCallTime)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_SetOnce", new object[]
						{
							"RenewOnCallTime"
						}));
					}
					LifetimeServices.SetTimeSpan(ref LifetimeServices.s_renewOnCallTimeTicks, value);
					LifetimeServices.s_isRenewOnCallTime = true;
				}
			}
		}

		// Token: 0x17000ED3 RID: 3795
		// (get) Token: 0x06005959 RID: 22873 RVA: 0x0013AD64 File Offset: 0x00138F64
		// (set) Token: 0x0600595A RID: 22874 RVA: 0x0013AD70 File Offset: 0x00138F70
		public static TimeSpan SponsorshipTimeout
		{
			get
			{
				return LifetimeServices.GetTimeSpan(ref LifetimeServices.s_sponsorshipTimeoutTicks);
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				object lifetimeSyncObject = LifetimeServices.LifetimeSyncObject;
				lock (lifetimeSyncObject)
				{
					if (LifetimeServices.s_isSponsorshipTimeout)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Lifetime_SetOnce", new object[]
						{
							"SponsorshipTimeout"
						}));
					}
					LifetimeServices.SetTimeSpan(ref LifetimeServices.s_sponsorshipTimeoutTicks, value);
					LifetimeServices.s_isSponsorshipTimeout = true;
				}
			}
		}

		// Token: 0x17000ED4 RID: 3796
		// (get) Token: 0x0600595B RID: 22875 RVA: 0x0013ADE0 File Offset: 0x00138FE0
		// (set) Token: 0x0600595C RID: 22876 RVA: 0x0013ADEC File Offset: 0x00138FEC
		public static TimeSpan LeaseManagerPollTime
		{
			get
			{
				return LifetimeServices.GetTimeSpan(ref LifetimeServices.s_pollTimeTicks);
			}
			[SecurityCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				object lifetimeSyncObject = LifetimeServices.LifetimeSyncObject;
				lock (lifetimeSyncObject)
				{
					LifetimeServices.SetTimeSpan(ref LifetimeServices.s_pollTimeTicks, value);
					if (LeaseManager.IsInitialized())
					{
						LeaseManager.GetLeaseManager().ChangePollTime(value);
					}
				}
			}
		}

		// Token: 0x0600595D RID: 22877 RVA: 0x0013AE44 File Offset: 0x00139044
		[SecurityCritical]
		internal static ILease GetLeaseInitial(MarshalByRefObject obj)
		{
			LeaseManager leaseManager = LeaseManager.GetLeaseManager(LifetimeServices.LeaseManagerPollTime);
			ILease lease = leaseManager.GetLease(obj);
			if (lease == null)
			{
				lease = LifetimeServices.CreateLease(obj);
			}
			return lease;
		}

		// Token: 0x0600595E RID: 22878 RVA: 0x0013AE74 File Offset: 0x00139074
		[SecurityCritical]
		internal static ILease GetLease(MarshalByRefObject obj)
		{
			LeaseManager leaseManager = LeaseManager.GetLeaseManager(LifetimeServices.LeaseManagerPollTime);
			return leaseManager.GetLease(obj);
		}

		// Token: 0x0600595F RID: 22879 RVA: 0x0013AE97 File Offset: 0x00139097
		[SecurityCritical]
		internal static ILease CreateLease(MarshalByRefObject obj)
		{
			return LifetimeServices.CreateLease(LifetimeServices.LeaseTime, LifetimeServices.RenewOnCallTime, LifetimeServices.SponsorshipTimeout, obj);
		}

		// Token: 0x06005960 RID: 22880 RVA: 0x0013AEAE File Offset: 0x001390AE
		[SecurityCritical]
		internal static ILease CreateLease(TimeSpan leaseTime, TimeSpan renewOnCallTime, TimeSpan sponsorshipTimeout, MarshalByRefObject obj)
		{
			LeaseManager.GetLeaseManager(LifetimeServices.LeaseManagerPollTime);
			return new Lease(leaseTime, renewOnCallTime, sponsorshipTimeout, obj);
		}

		// Token: 0x040028AF RID: 10415
		private static bool s_isLeaseTime = false;

		// Token: 0x040028B0 RID: 10416
		private static bool s_isRenewOnCallTime = false;

		// Token: 0x040028B1 RID: 10417
		private static bool s_isSponsorshipTimeout = false;

		// Token: 0x040028B2 RID: 10418
		private static long s_leaseTimeTicks = TimeSpan.FromMinutes(5.0).Ticks;

		// Token: 0x040028B3 RID: 10419
		private static long s_renewOnCallTimeTicks = TimeSpan.FromMinutes(2.0).Ticks;

		// Token: 0x040028B4 RID: 10420
		private static long s_sponsorshipTimeoutTicks = TimeSpan.FromMinutes(2.0).Ticks;

		// Token: 0x040028B5 RID: 10421
		private static long s_pollTimeTicks = TimeSpan.FromMilliseconds(10000.0).Ticks;

		// Token: 0x040028B6 RID: 10422
		private static object s_LifetimeSyncObject = null;
	}
}
