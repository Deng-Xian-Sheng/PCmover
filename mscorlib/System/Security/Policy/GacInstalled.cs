using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x02000372 RID: 882
	[ComVisible(true)]
	[Serializable]
	public sealed class GacInstalled : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002BB9 RID: 11193 RVA: 0x000A2E73 File Offset: 0x000A1073
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new GacIdentityPermission();
		}

		// Token: 0x06002BBA RID: 11194 RVA: 0x000A2E7A File Offset: 0x000A107A
		public override bool Equals(object o)
		{
			return o is GacInstalled;
		}

		// Token: 0x06002BBB RID: 11195 RVA: 0x000A2E85 File Offset: 0x000A1085
		public override int GetHashCode()
		{
			return 0;
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x000A2E88 File Offset: 0x000A1088
		public override EvidenceBase Clone()
		{
			return new GacInstalled();
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x000A2E8F File Offset: 0x000A108F
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002BBE RID: 11198 RVA: 0x000A2E98 File Offset: 0x000A1098
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement(base.GetType().FullName);
			securityElement.AddAttribute("version", "1");
			return securityElement;
		}

		// Token: 0x06002BBF RID: 11199 RVA: 0x000A2EC7 File Offset: 0x000A10C7
		public override string ToString()
		{
			return this.ToXml().ToString();
		}
	}
}
