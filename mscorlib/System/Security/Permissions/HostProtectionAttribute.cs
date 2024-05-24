using System;
using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
	// Token: 0x020002E4 RID: 740
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
	[ComVisible(true)]
	[Serializable]
	public sealed class HostProtectionAttribute : CodeAccessSecurityAttribute
	{
		// Token: 0x06002617 RID: 9751 RVA: 0x0008B78F File Offset: 0x0008998F
		public HostProtectionAttribute() : base(SecurityAction.LinkDemand)
		{
		}

		// Token: 0x06002618 RID: 9752 RVA: 0x0008B798 File Offset: 0x00089998
		public HostProtectionAttribute(SecurityAction action) : base(action)
		{
			if (action != SecurityAction.LinkDemand)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFlag"));
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06002619 RID: 9753 RVA: 0x0008B7B5 File Offset: 0x000899B5
		// (set) Token: 0x0600261A RID: 9754 RVA: 0x0008B7BD File Offset: 0x000899BD
		public HostProtectionResource Resources
		{
			get
			{
				return this.m_resources;
			}
			set
			{
				this.m_resources = value;
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x0600261B RID: 9755 RVA: 0x0008B7C6 File Offset: 0x000899C6
		// (set) Token: 0x0600261C RID: 9756 RVA: 0x0008B7D3 File Offset: 0x000899D3
		public bool Synchronization
		{
			get
			{
				return (this.m_resources & HostProtectionResource.Synchronization) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.Synchronization) : (this.m_resources & ~HostProtectionResource.Synchronization));
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x0600261D RID: 9757 RVA: 0x0008B7F1 File Offset: 0x000899F1
		// (set) Token: 0x0600261E RID: 9758 RVA: 0x0008B7FE File Offset: 0x000899FE
		public bool SharedState
		{
			get
			{
				return (this.m_resources & HostProtectionResource.SharedState) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.SharedState) : (this.m_resources & ~HostProtectionResource.SharedState));
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x0600261F RID: 9759 RVA: 0x0008B81C File Offset: 0x00089A1C
		// (set) Token: 0x06002620 RID: 9760 RVA: 0x0008B829 File Offset: 0x00089A29
		public bool ExternalProcessMgmt
		{
			get
			{
				return (this.m_resources & HostProtectionResource.ExternalProcessMgmt) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.ExternalProcessMgmt) : (this.m_resources & ~HostProtectionResource.ExternalProcessMgmt));
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06002621 RID: 9761 RVA: 0x0008B847 File Offset: 0x00089A47
		// (set) Token: 0x06002622 RID: 9762 RVA: 0x0008B854 File Offset: 0x00089A54
		public bool SelfAffectingProcessMgmt
		{
			get
			{
				return (this.m_resources & HostProtectionResource.SelfAffectingProcessMgmt) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.SelfAffectingProcessMgmt) : (this.m_resources & ~HostProtectionResource.SelfAffectingProcessMgmt));
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06002623 RID: 9763 RVA: 0x0008B872 File Offset: 0x00089A72
		// (set) Token: 0x06002624 RID: 9764 RVA: 0x0008B880 File Offset: 0x00089A80
		public bool ExternalThreading
		{
			get
			{
				return (this.m_resources & HostProtectionResource.ExternalThreading) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.ExternalThreading) : (this.m_resources & ~HostProtectionResource.ExternalThreading));
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06002625 RID: 9765 RVA: 0x0008B89F File Offset: 0x00089A9F
		// (set) Token: 0x06002626 RID: 9766 RVA: 0x0008B8AD File Offset: 0x00089AAD
		public bool SelfAffectingThreading
		{
			get
			{
				return (this.m_resources & HostProtectionResource.SelfAffectingThreading) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.SelfAffectingThreading) : (this.m_resources & ~HostProtectionResource.SelfAffectingThreading));
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06002627 RID: 9767 RVA: 0x0008B8CC File Offset: 0x00089ACC
		// (set) Token: 0x06002628 RID: 9768 RVA: 0x0008B8DA File Offset: 0x00089ADA
		[ComVisible(true)]
		public bool SecurityInfrastructure
		{
			get
			{
				return (this.m_resources & HostProtectionResource.SecurityInfrastructure) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.SecurityInfrastructure) : (this.m_resources & ~HostProtectionResource.SecurityInfrastructure));
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06002629 RID: 9769 RVA: 0x0008B8F9 File Offset: 0x00089AF9
		// (set) Token: 0x0600262A RID: 9770 RVA: 0x0008B90A File Offset: 0x00089B0A
		public bool UI
		{
			get
			{
				return (this.m_resources & HostProtectionResource.UI) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.UI) : (this.m_resources & ~HostProtectionResource.UI));
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x0600262B RID: 9771 RVA: 0x0008B92F File Offset: 0x00089B2F
		// (set) Token: 0x0600262C RID: 9772 RVA: 0x0008B940 File Offset: 0x00089B40
		public bool MayLeakOnAbort
		{
			get
			{
				return (this.m_resources & HostProtectionResource.MayLeakOnAbort) > HostProtectionResource.None;
			}
			set
			{
				this.m_resources = (value ? (this.m_resources | HostProtectionResource.MayLeakOnAbort) : (this.m_resources & ~HostProtectionResource.MayLeakOnAbort));
			}
		}

		// Token: 0x0600262D RID: 9773 RVA: 0x0008B965 File Offset: 0x00089B65
		public override IPermission CreatePermission()
		{
			if (this.m_unrestricted)
			{
				return new HostProtectionPermission(PermissionState.Unrestricted);
			}
			return new HostProtectionPermission(this.m_resources);
		}

		// Token: 0x04000E96 RID: 3734
		private HostProtectionResource m_resources;
	}
}
