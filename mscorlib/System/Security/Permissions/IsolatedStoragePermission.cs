using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002EA RID: 746
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, ControlEvidence = true, ControlPolicy = true)]
	[Serializable]
	public abstract class IsolatedStoragePermission : CodeAccessPermission, IUnrestrictedPermission
	{
		// Token: 0x0600263C RID: 9788 RVA: 0x0008BC20 File Offset: 0x00089E20
		protected IsolatedStoragePermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.m_userQuota = long.MaxValue;
				this.m_machineQuota = long.MaxValue;
				this.m_expirationDays = long.MaxValue;
				this.m_permanentData = true;
				this.m_allowed = IsolatedStorageContainment.UnrestrictedIsolatedStorage;
				return;
			}
			if (state == PermissionState.None)
			{
				this.m_userQuota = 0L;
				this.m_machineQuota = 0L;
				this.m_expirationDays = 0L;
				this.m_permanentData = false;
				this.m_allowed = IsolatedStorageContainment.None;
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x0008BCB0 File Offset: 0x00089EB0
		internal IsolatedStoragePermission(IsolatedStorageContainment UsageAllowed, long ExpirationDays, bool PermanentData)
		{
			this.m_userQuota = 0L;
			this.m_machineQuota = 0L;
			this.m_expirationDays = ExpirationDays;
			this.m_permanentData = PermanentData;
			this.m_allowed = UsageAllowed;
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x0008BCDD File Offset: 0x00089EDD
		internal IsolatedStoragePermission(IsolatedStorageContainment UsageAllowed, long ExpirationDays, bool PermanentData, long UserQuota)
		{
			this.m_machineQuota = 0L;
			this.m_userQuota = UserQuota;
			this.m_expirationDays = ExpirationDays;
			this.m_permanentData = PermanentData;
			this.m_allowed = UsageAllowed;
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06002640 RID: 9792 RVA: 0x0008BD13 File Offset: 0x00089F13
		// (set) Token: 0x0600263F RID: 9791 RVA: 0x0008BD0A File Offset: 0x00089F0A
		public long UserQuota
		{
			get
			{
				return this.m_userQuota;
			}
			set
			{
				this.m_userQuota = value;
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06002642 RID: 9794 RVA: 0x0008BD24 File Offset: 0x00089F24
		// (set) Token: 0x06002641 RID: 9793 RVA: 0x0008BD1B File Offset: 0x00089F1B
		public IsolatedStorageContainment UsageAllowed
		{
			get
			{
				return this.m_allowed;
			}
			set
			{
				this.m_allowed = value;
			}
		}

		// Token: 0x06002643 RID: 9795 RVA: 0x0008BD2C File Offset: 0x00089F2C
		public bool IsUnrestricted()
		{
			return this.m_allowed == IsolatedStorageContainment.UnrestrictedIsolatedStorage;
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x0008BD3B File Offset: 0x00089F3B
		internal static long min(long x, long y)
		{
			if (x <= y)
			{
				return x;
			}
			return y;
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x0008BD44 File Offset: 0x00089F44
		internal static long max(long x, long y)
		{
			if (x >= y)
			{
				return x;
			}
			return y;
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x0008BD4D File Offset: 0x00089F4D
		public override SecurityElement ToXml()
		{
			return this.ToXml(base.GetType().FullName);
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x0008BD60 File Offset: 0x00089F60
		internal SecurityElement ToXml(string permName)
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, permName);
			if (!this.IsUnrestricted())
			{
				securityElement.AddAttribute("Allowed", Enum.GetName(typeof(IsolatedStorageContainment), this.m_allowed));
				if (this.m_userQuota > 0L)
				{
					securityElement.AddAttribute("UserQuota", this.m_userQuota.ToString(CultureInfo.InvariantCulture));
				}
				if (this.m_machineQuota > 0L)
				{
					securityElement.AddAttribute("MachineQuota", this.m_machineQuota.ToString(CultureInfo.InvariantCulture));
				}
				if (this.m_expirationDays > 0L)
				{
					securityElement.AddAttribute("Expiry", this.m_expirationDays.ToString(CultureInfo.InvariantCulture));
				}
				if (this.m_permanentData)
				{
					securityElement.AddAttribute("Permanent", this.m_permanentData.ToString());
				}
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		// Token: 0x06002648 RID: 9800 RVA: 0x0008BE48 File Offset: 0x0008A048
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			this.m_allowed = IsolatedStorageContainment.None;
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.m_allowed = IsolatedStorageContainment.UnrestrictedIsolatedStorage;
			}
			else
			{
				string text = esd.Attribute("Allowed");
				if (text != null)
				{
					this.m_allowed = (IsolatedStorageContainment)Enum.Parse(typeof(IsolatedStorageContainment), text);
				}
			}
			if (this.m_allowed == IsolatedStorageContainment.UnrestrictedIsolatedStorage)
			{
				this.m_userQuota = long.MaxValue;
				this.m_machineQuota = long.MaxValue;
				this.m_expirationDays = long.MaxValue;
				this.m_permanentData = true;
				return;
			}
			string text2 = esd.Attribute("UserQuota");
			this.m_userQuota = ((text2 != null) ? long.Parse(text2, CultureInfo.InvariantCulture) : 0L);
			text2 = esd.Attribute("MachineQuota");
			this.m_machineQuota = ((text2 != null) ? long.Parse(text2, CultureInfo.InvariantCulture) : 0L);
			text2 = esd.Attribute("Expiry");
			this.m_expirationDays = ((text2 != null) ? long.Parse(text2, CultureInfo.InvariantCulture) : 0L);
			text2 = esd.Attribute("Permanent");
			this.m_permanentData = (text2 != null && bool.Parse(text2));
		}

		// Token: 0x04000EC9 RID: 3785
		internal long m_userQuota;

		// Token: 0x04000ECA RID: 3786
		internal long m_machineQuota;

		// Token: 0x04000ECB RID: 3787
		internal long m_expirationDays;

		// Token: 0x04000ECC RID: 3788
		internal bool m_permanentData;

		// Token: 0x04000ECD RID: 3789
		internal IsolatedStorageContainment m_allowed;

		// Token: 0x04000ECE RID: 3790
		private const string _strUserQuota = "UserQuota";

		// Token: 0x04000ECF RID: 3791
		private const string _strMachineQuota = "MachineQuota";

		// Token: 0x04000ED0 RID: 3792
		private const string _strExpiry = "Expiry";

		// Token: 0x04000ED1 RID: 3793
		private const string _strPermDat = "Permanent";
	}
}
