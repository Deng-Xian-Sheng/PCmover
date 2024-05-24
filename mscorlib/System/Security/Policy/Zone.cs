using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x02000370 RID: 880
	[ComVisible(true)]
	[Serializable]
	public sealed class Zone : EvidenceBase, IIdentityPermissionFactory
	{
		// Token: 0x06002B98 RID: 11160 RVA: 0x000A2945 File Offset: 0x000A0B45
		public Zone(SecurityZone zone)
		{
			if (zone < SecurityZone.NoZone || zone > SecurityZone.Untrusted)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_IllegalZone"));
			}
			this.m_zone = zone;
		}

		// Token: 0x06002B99 RID: 11161 RVA: 0x000A296C File Offset: 0x000A0B6C
		private Zone(Zone zone)
		{
			this.m_url = zone.m_url;
			this.m_zone = zone.m_zone;
		}

		// Token: 0x06002B9A RID: 11162 RVA: 0x000A298C File Offset: 0x000A0B8C
		private Zone(string url)
		{
			this.m_url = url;
			this.m_zone = SecurityZone.NoZone;
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x000A29A2 File Offset: 0x000A0BA2
		public static Zone CreateFromUrl(string url)
		{
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			return new Zone(url);
		}

		// Token: 0x06002B9C RID: 11164
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern SecurityZone _CreateFromUrl(string url);

		// Token: 0x06002B9D RID: 11165 RVA: 0x000A29B8 File Offset: 0x000A0BB8
		public IPermission CreateIdentityPermission(Evidence evidence)
		{
			return new ZoneIdentityPermission(this.SecurityZone);
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06002B9E RID: 11166 RVA: 0x000A29C5 File Offset: 0x000A0BC5
		public SecurityZone SecurityZone
		{
			[SecuritySafeCritical]
			get
			{
				if (this.m_url != null)
				{
					this.m_zone = Zone._CreateFromUrl(this.m_url);
				}
				return this.m_zone;
			}
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x000A29E8 File Offset: 0x000A0BE8
		public override bool Equals(object o)
		{
			Zone zone = o as Zone;
			return zone != null && this.SecurityZone == zone.SecurityZone;
		}

		// Token: 0x06002BA0 RID: 11168 RVA: 0x000A2A0F File Offset: 0x000A0C0F
		public override int GetHashCode()
		{
			return (int)this.SecurityZone;
		}

		// Token: 0x06002BA1 RID: 11169 RVA: 0x000A2A17 File Offset: 0x000A0C17
		public override EvidenceBase Clone()
		{
			return new Zone(this);
		}

		// Token: 0x06002BA2 RID: 11170 RVA: 0x000A2A1F File Offset: 0x000A0C1F
		public object Copy()
		{
			return this.Clone();
		}

		// Token: 0x06002BA3 RID: 11171 RVA: 0x000A2A28 File Offset: 0x000A0C28
		internal SecurityElement ToXml()
		{
			SecurityElement securityElement = new SecurityElement("System.Security.Policy.Zone");
			securityElement.AddAttribute("version", "1");
			if (this.SecurityZone != SecurityZone.NoZone)
			{
				securityElement.AddChild(new SecurityElement("Zone", Zone.s_names[(int)this.SecurityZone]));
			}
			else
			{
				securityElement.AddChild(new SecurityElement("Zone", Zone.s_names[Zone.s_names.Length - 1]));
			}
			return securityElement;
		}

		// Token: 0x06002BA4 RID: 11172 RVA: 0x000A2A97 File Offset: 0x000A0C97
		public override string ToString()
		{
			return this.ToXml().ToString();
		}

		// Token: 0x06002BA5 RID: 11173 RVA: 0x000A2AA4 File Offset: 0x000A0CA4
		internal object Normalize()
		{
			return Zone.s_names[(int)this.SecurityZone];
		}

		// Token: 0x040011A3 RID: 4515
		[OptionalField(VersionAdded = 2)]
		private string m_url;

		// Token: 0x040011A4 RID: 4516
		private SecurityZone m_zone;

		// Token: 0x040011A5 RID: 4517
		private static readonly string[] s_names = new string[]
		{
			"MyComputer",
			"Intranet",
			"Trusted",
			"Internet",
			"Untrusted",
			"NoZone"
		};
	}
}
