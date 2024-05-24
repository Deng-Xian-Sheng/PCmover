using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Lifetime
{
	// Token: 0x0200081C RID: 2076
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ClientSponsor : MarshalByRefObject, ISponsor
	{
		// Token: 0x0600590D RID: 22797 RVA: 0x00139B96 File Offset: 0x00137D96
		public ClientSponsor()
		{
		}

		// Token: 0x0600590E RID: 22798 RVA: 0x00139BBF File Offset: 0x00137DBF
		public ClientSponsor(TimeSpan renewalTime)
		{
			this.m_renewalTime = renewalTime;
		}

		// Token: 0x17000EC4 RID: 3780
		// (get) Token: 0x0600590F RID: 22799 RVA: 0x00139BEF File Offset: 0x00137DEF
		// (set) Token: 0x06005910 RID: 22800 RVA: 0x00139BF7 File Offset: 0x00137DF7
		public TimeSpan RenewalTime
		{
			get
			{
				return this.m_renewalTime;
			}
			set
			{
				this.m_renewalTime = value;
			}
		}

		// Token: 0x06005911 RID: 22801 RVA: 0x00139C00 File Offset: 0x00137E00
		[SecurityCritical]
		public bool Register(MarshalByRefObject obj)
		{
			ILease lease = (ILease)obj.GetLifetimeService();
			if (lease == null)
			{
				return false;
			}
			lease.Register(this);
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				this.sponsorTable[obj] = lease;
			}
			return true;
		}

		// Token: 0x06005912 RID: 22802 RVA: 0x00139C60 File Offset: 0x00137E60
		[SecurityCritical]
		public void Unregister(MarshalByRefObject obj)
		{
			ILease lease = null;
			Hashtable obj2 = this.sponsorTable;
			lock (obj2)
			{
				lease = (ILease)this.sponsorTable[obj];
			}
			if (lease != null)
			{
				lease.Unregister(this);
			}
		}

		// Token: 0x06005913 RID: 22803 RVA: 0x00139CB8 File Offset: 0x00137EB8
		[SecurityCritical]
		public TimeSpan Renewal(ILease lease)
		{
			return this.m_renewalTime;
		}

		// Token: 0x06005914 RID: 22804 RVA: 0x00139CC0 File Offset: 0x00137EC0
		[SecurityCritical]
		public void Close()
		{
			Hashtable obj = this.sponsorTable;
			lock (obj)
			{
				IDictionaryEnumerator enumerator = this.sponsorTable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((ILease)enumerator.Value).Unregister(this);
				}
				this.sponsorTable.Clear();
			}
		}

		// Token: 0x06005915 RID: 22805 RVA: 0x00139D2C File Offset: 0x00137F2C
		[SecurityCritical]
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x06005916 RID: 22806 RVA: 0x00139D30 File Offset: 0x00137F30
		[SecuritySafeCritical]
		~ClientSponsor()
		{
		}

		// Token: 0x04002893 RID: 10387
		private Hashtable sponsorTable = new Hashtable(10);

		// Token: 0x04002894 RID: 10388
		private TimeSpan m_renewalTime = TimeSpan.FromMinutes(2.0);
	}
}
