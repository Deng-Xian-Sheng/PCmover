using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace System.Security
{
	// Token: 0x020001DA RID: 474
	[ComVisible(true)]
	[Serializable]
	public sealed class NamedPermissionSet : PermissionSet
	{
		// Token: 0x06001CA6 RID: 7334 RVA: 0x00062221 File Offset: 0x00060421
		internal NamedPermissionSet()
		{
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00062229 File Offset: 0x00060429
		public NamedPermissionSet(string name)
		{
			NamedPermissionSet.CheckName(name);
			this.m_name = name;
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x0006223E File Offset: 0x0006043E
		public NamedPermissionSet(string name, PermissionState state) : base(state)
		{
			NamedPermissionSet.CheckName(name);
			this.m_name = name;
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x00062254 File Offset: 0x00060454
		public NamedPermissionSet(string name, PermissionSet permSet) : base(permSet)
		{
			NamedPermissionSet.CheckName(name);
			this.m_name = name;
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x0006226A File Offset: 0x0006046A
		public NamedPermissionSet(NamedPermissionSet permSet) : base(permSet)
		{
			this.m_name = permSet.m_name;
			this.m_description = permSet.Description;
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x0006228B File Offset: 0x0006048B
		internal NamedPermissionSet(SecurityElement permissionSetXml) : base(PermissionState.None)
		{
			this.FromXml(permissionSetXml);
		}

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06001CAC RID: 7340 RVA: 0x0006229B File Offset: 0x0006049B
		// (set) Token: 0x06001CAD RID: 7341 RVA: 0x000622A3 File Offset: 0x000604A3
		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				NamedPermissionSet.CheckName(value);
				this.m_name = value;
			}
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x000622B2 File Offset: 0x000604B2
		private static void CheckName(string name)
		{
			if (name == null || name.Equals(""))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NPMSInvalidName"));
			}
		}

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06001CAF RID: 7343 RVA: 0x000622D4 File Offset: 0x000604D4
		// (set) Token: 0x06001CB0 RID: 7344 RVA: 0x000622FC File Offset: 0x000604FC
		public string Description
		{
			get
			{
				if (this.m_descrResource != null)
				{
					this.m_description = Environment.GetResourceString(this.m_descrResource);
					this.m_descrResource = null;
				}
				return this.m_description;
			}
			set
			{
				this.m_description = value;
				this.m_descrResource = null;
			}
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x0006230C File Offset: 0x0006050C
		public override PermissionSet Copy()
		{
			return new NamedPermissionSet(this);
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x00062314 File Offset: 0x00060514
		public NamedPermissionSet Copy(string name)
		{
			return new NamedPermissionSet(this)
			{
				Name = name
			};
		}

		// Token: 0x06001CB3 RID: 7347 RVA: 0x00062330 File Offset: 0x00060530
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = base.ToXml("System.Security.NamedPermissionSet");
			if (this.m_name != null && !this.m_name.Equals(""))
			{
				securityElement.AddAttribute("Name", SecurityElement.Escape(this.m_name));
			}
			if (this.Description != null && !this.Description.Equals(""))
			{
				securityElement.AddAttribute("Description", SecurityElement.Escape(this.Description));
			}
			return securityElement;
		}

		// Token: 0x06001CB4 RID: 7348 RVA: 0x000623AA File Offset: 0x000605AA
		public override void FromXml(SecurityElement et)
		{
			this.FromXml(et, false, false);
		}

		// Token: 0x06001CB5 RID: 7349 RVA: 0x000623B8 File Offset: 0x000605B8
		internal override void FromXml(SecurityElement et, bool allowInternalOnly, bool ignoreTypeLoadFailures)
		{
			if (et == null)
			{
				throw new ArgumentNullException("et");
			}
			string text = et.Attribute("Name");
			this.m_name = ((text == null) ? null : text);
			text = et.Attribute("Description");
			this.m_description = ((text == null) ? "" : text);
			this.m_descrResource = null;
			base.FromXml(et, allowInternalOnly, ignoreTypeLoadFailures);
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x0006241C File Offset: 0x0006061C
		internal void FromXmlNameOnly(SecurityElement et)
		{
			string text = et.Attribute("Name");
			this.m_name = ((text == null) ? null : text);
		}

		// Token: 0x06001CB7 RID: 7351 RVA: 0x00062442 File Offset: 0x00060642
		[ComVisible(false)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x06001CB8 RID: 7352 RVA: 0x0006244B File Offset: 0x0006064B
		[ComVisible(false)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06001CB9 RID: 7353 RVA: 0x00062454 File Offset: 0x00060654
		private static object InternalSyncObject
		{
			get
			{
				if (NamedPermissionSet.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange(ref NamedPermissionSet.s_InternalSyncObject, value, null);
				}
				return NamedPermissionSet.s_InternalSyncObject;
			}
		}

		// Token: 0x04000A04 RID: 2564
		private string m_name;

		// Token: 0x04000A05 RID: 2565
		private string m_description;

		// Token: 0x04000A06 RID: 2566
		[OptionalField(VersionAdded = 2)]
		internal string m_descrResource;

		// Token: 0x04000A07 RID: 2567
		private static object s_InternalSyncObject;
	}
}
