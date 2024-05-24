using System;
using System.Security.Policy;

namespace System.Security.Permissions
{
	// Token: 0x02000308 RID: 776
	[Serializable]
	internal sealed class StrongName2
	{
		// Token: 0x06002750 RID: 10064 RVA: 0x0008EA31 File Offset: 0x0008CC31
		public StrongName2(StrongNamePublicKeyBlob publicKeyBlob, string name, Version version)
		{
			this.m_publicKeyBlob = publicKeyBlob;
			this.m_name = name;
			this.m_version = version;
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x0008EA4E File Offset: 0x0008CC4E
		public StrongName2 Copy()
		{
			return new StrongName2(this.m_publicKeyBlob, this.m_name, this.m_version);
		}

		// Token: 0x06002752 RID: 10066 RVA: 0x0008EA68 File Offset: 0x0008CC68
		public bool IsSubsetOf(StrongName2 target)
		{
			return this.m_publicKeyBlob == null || (this.m_publicKeyBlob.Equals(target.m_publicKeyBlob) && (this.m_name == null || (target.m_name != null && StrongName.CompareNames(target.m_name, this.m_name))) && (this.m_version == null || (target.m_version != null && target.m_version.CompareTo(this.m_version) == 0)));
		}

		// Token: 0x06002753 RID: 10067 RVA: 0x0008EADF File Offset: 0x0008CCDF
		public StrongName2 Intersect(StrongName2 target)
		{
			if (target.IsSubsetOf(this))
			{
				return target.Copy();
			}
			if (this.IsSubsetOf(target))
			{
				return this.Copy();
			}
			return null;
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x0008EB02 File Offset: 0x0008CD02
		public bool Equals(StrongName2 target)
		{
			return target.IsSubsetOf(this) && this.IsSubsetOf(target);
		}

		// Token: 0x04000F3D RID: 3901
		public StrongNamePublicKeyBlob m_publicKeyBlob;

		// Token: 0x04000F3E RID: 3902
		public string m_name;

		// Token: 0x04000F3F RID: 3903
		public Version m_version;
	}
}
