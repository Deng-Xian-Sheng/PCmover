using System;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x02000361 RID: 865
	[ComVisible(true)]
	[Obsolete("Assembly level declarative security is obsolete and is no longer enforced by the CLR by default. See http://go.microsoft.com/fwlink/?LinkID=155570 for more information.")]
	[Serializable]
	public sealed class PermissionRequestEvidence : EvidenceBase
	{
		// Token: 0x06002AC5 RID: 10949 RVA: 0x0009E6B4 File Offset: 0x0009C8B4
		public PermissionRequestEvidence(PermissionSet request, PermissionSet optional, PermissionSet denied)
		{
			if (request == null)
			{
				this.m_request = null;
			}
			else
			{
				this.m_request = request.Copy();
			}
			if (optional == null)
			{
				this.m_optional = null;
			}
			else
			{
				this.m_optional = optional.Copy();
			}
			if (denied == null)
			{
				this.m_denied = null;
				return;
			}
			this.m_denied = denied.Copy();
		}

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06002AC6 RID: 10950 RVA: 0x0009E70E File Offset: 0x0009C90E
		public PermissionSet RequestedPermissions
		{
			get
			{
				return this.m_request;
			}
		}

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06002AC7 RID: 10951 RVA: 0x0009E716 File Offset: 0x0009C916
		public PermissionSet OptionalPermissions
		{
			get
			{
				return this.m_optional;
			}
		}

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06002AC8 RID: 10952 RVA: 0x0009E71E File Offset: 0x0009C91E
		public PermissionSet DeniedPermissions
		{
			get
			{
				return this.m_denied;
			}
		}

		// Token: 0x06002AC9 RID: 10953 RVA: 0x0009E726 File Offset: 0x0009C926
		public override EvidenceBase Clone()
		{
			return this.Copy();
		}

		// Token: 0x06002ACA RID: 10954 RVA: 0x0009E72E File Offset: 0x0009C92E
		public PermissionRequestEvidence Copy()
		{
			return new PermissionRequestEvidence(this.m_request, this.m_optional, this.m_denied);
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0009E748 File Offset: 0x0009C948
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.PermissionRequestEvidence");
			securityElement.AddAttribute("version", "1");
			if (this.m_request != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Request");
				securityElement2.AddChild(this.m_request.ToXml());
				securityElement.AddChild(securityElement2);
			}
			if (this.m_optional != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Optional");
				securityElement2.AddChild(this.m_optional.ToXml());
				securityElement.AddChild(securityElement2);
			}
			if (this.m_denied != null)
			{
				SecurityElement securityElement2 = new SecurityElement("Denied");
				securityElement2.AddChild(this.m_denied.ToXml());
				securityElement.AddChild(securityElement2);
			}
			return securityElement;
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x0009E7F2 File Offset: 0x0009C9F2
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x04001168 RID: 4456
		private PermissionSet m_request;

		// Token: 0x04001169 RID: 4457
		private PermissionSet m_optional;

		// Token: 0x0400116A RID: 4458
		private PermissionSet m_denied;

		// Token: 0x0400116B RID: 4459
		private string m_strRequest;

		// Token: 0x0400116C RID: 4460
		private string m_strOptional;

		// Token: 0x0400116D RID: 4461
		private string m_strDenied;
	}
}
