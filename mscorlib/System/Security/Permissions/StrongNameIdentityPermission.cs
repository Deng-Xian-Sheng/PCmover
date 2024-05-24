using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x02000309 RID: 777
	[ComVisible(true)]
	[Serializable]
	public sealed class StrongNameIdentityPermission : CodeAccessPermission, IBuiltInPermission
	{
		// Token: 0x06002755 RID: 10069 RVA: 0x0008EB1B File Offset: 0x0008CD1B
		public StrongNameIdentityPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.m_unrestricted = true;
				return;
			}
			if (state == PermissionState.None)
			{
				this.m_unrestricted = false;
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x06002756 RID: 10070 RVA: 0x0008EB4C File Offset: 0x0008CD4C
		public StrongNameIdentityPermission(StrongNamePublicKeyBlob blob, string name, Version version)
		{
			if (blob == null)
			{
				throw new ArgumentNullException("blob");
			}
			if (name != null && name.Equals(""))
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyStrongName"));
			}
			this.m_unrestricted = false;
			this.m_strongNames = new StrongName2[1];
			this.m_strongNames[0] = new StrongName2(blob, name, version);
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002758 RID: 10072 RVA: 0x0008EC18 File Offset: 0x0008CE18
		// (set) Token: 0x06002757 RID: 10071 RVA: 0x0008EBB0 File Offset: 0x0008CDB0
		public StrongNamePublicKeyBlob PublicKey
		{
			get
			{
				if (this.m_strongNames == null || this.m_strongNames.Length == 0)
				{
					return null;
				}
				if (this.m_strongNames.Length > 1)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_AmbiguousIdentity"));
				}
				return this.m_strongNames[0].m_publicKeyBlob;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PublicKey");
				}
				this.m_unrestricted = false;
				if (this.m_strongNames != null && this.m_strongNames.Length == 1)
				{
					this.m_strongNames[0].m_publicKeyBlob = value;
					return;
				}
				this.m_strongNames = new StrongName2[1];
				this.m_strongNames[0] = new StrongName2(value, "", new Version());
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600275A RID: 10074 RVA: 0x0008ECCC File Offset: 0x0008CECC
		// (set) Token: 0x06002759 RID: 10073 RVA: 0x0008EC58 File Offset: 0x0008CE58
		public string Name
		{
			get
			{
				if (this.m_strongNames == null || this.m_strongNames.Length == 0)
				{
					return "";
				}
				if (this.m_strongNames.Length > 1)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_AmbiguousIdentity"));
				}
				return this.m_strongNames[0].m_name;
			}
			set
			{
				if (value != null && value.Length == 0)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"));
				}
				this.m_unrestricted = false;
				if (this.m_strongNames != null && this.m_strongNames.Length == 1)
				{
					this.m_strongNames[0].m_name = value;
					return;
				}
				this.m_strongNames = new StrongName2[1];
				this.m_strongNames[0] = new StrongName2(null, value, new Version());
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600275C RID: 10076 RVA: 0x0008ED70 File Offset: 0x0008CF70
		// (set) Token: 0x0600275B RID: 10075 RVA: 0x0008ED18 File Offset: 0x0008CF18
		public Version Version
		{
			get
			{
				if (this.m_strongNames == null || this.m_strongNames.Length == 0)
				{
					return new Version();
				}
				if (this.m_strongNames.Length > 1)
				{
					throw new NotSupportedException(Environment.GetResourceString("NotSupported_AmbiguousIdentity"));
				}
				return this.m_strongNames[0].m_version;
			}
			set
			{
				this.m_unrestricted = false;
				if (this.m_strongNames != null && this.m_strongNames.Length == 1)
				{
					this.m_strongNames[0].m_version = value;
					return;
				}
				this.m_strongNames = new StrongName2[1];
				this.m_strongNames[0] = new StrongName2(null, "", value);
			}
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x0008EDBC File Offset: 0x0008CFBC
		public override IPermission Copy()
		{
			StrongNameIdentityPermission strongNameIdentityPermission = new StrongNameIdentityPermission(PermissionState.None);
			strongNameIdentityPermission.m_unrestricted = this.m_unrestricted;
			if (this.m_strongNames != null)
			{
				strongNameIdentityPermission.m_strongNames = new StrongName2[this.m_strongNames.Length];
				for (int i = 0; i < this.m_strongNames.Length; i++)
				{
					strongNameIdentityPermission.m_strongNames[i] = this.m_strongNames[i].Copy();
				}
			}
			return strongNameIdentityPermission;
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x0008EE20 File Offset: 0x0008D020
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return !this.m_unrestricted && (this.m_strongNames == null || this.m_strongNames.Length == 0);
			}
			StrongNameIdentityPermission strongNameIdentityPermission = target as StrongNameIdentityPermission;
			if (strongNameIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (strongNameIdentityPermission.m_unrestricted)
			{
				return true;
			}
			if (this.m_unrestricted)
			{
				return false;
			}
			if (this.m_strongNames != null)
			{
				foreach (StrongName2 strongName in this.m_strongNames)
				{
					bool flag = false;
					if (strongNameIdentityPermission.m_strongNames != null)
					{
						foreach (StrongName2 target2 in strongNameIdentityPermission.m_strongNames)
						{
							if (strongName.IsSubsetOf(target2))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x0008EEF8 File Offset: 0x0008D0F8
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			StrongNameIdentityPermission strongNameIdentityPermission = target as StrongNameIdentityPermission;
			if (strongNameIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (this.m_unrestricted && strongNameIdentityPermission.m_unrestricted)
			{
				return new StrongNameIdentityPermission(PermissionState.None)
				{
					m_unrestricted = true
				};
			}
			if (this.m_unrestricted)
			{
				return strongNameIdentityPermission.Copy();
			}
			if (strongNameIdentityPermission.m_unrestricted)
			{
				return this.Copy();
			}
			if (this.m_strongNames == null || strongNameIdentityPermission.m_strongNames == null || this.m_strongNames.Length == 0 || strongNameIdentityPermission.m_strongNames.Length == 0)
			{
				return null;
			}
			List<StrongName2> list = new List<StrongName2>();
			foreach (StrongName2 strongName in this.m_strongNames)
			{
				foreach (StrongName2 target2 in strongNameIdentityPermission.m_strongNames)
				{
					StrongName2 strongName2 = strongName.Intersect(target2);
					if (strongName2 != null)
					{
						list.Add(strongName2);
					}
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return new StrongNameIdentityPermission(PermissionState.None)
			{
				m_strongNames = list.ToArray()
			};
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x0008F01C File Offset: 0x0008D21C
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				if ((this.m_strongNames == null || this.m_strongNames.Length == 0) && !this.m_unrestricted)
				{
					return null;
				}
				return this.Copy();
			}
			else
			{
				StrongNameIdentityPermission strongNameIdentityPermission = target as StrongNameIdentityPermission;
				if (strongNameIdentityPermission == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
					{
						base.GetType().FullName
					}));
				}
				if (this.m_unrestricted || strongNameIdentityPermission.m_unrestricted)
				{
					return new StrongNameIdentityPermission(PermissionState.None)
					{
						m_unrestricted = true
					};
				}
				if (this.m_strongNames == null || this.m_strongNames.Length == 0)
				{
					if (strongNameIdentityPermission.m_strongNames == null || strongNameIdentityPermission.m_strongNames.Length == 0)
					{
						return null;
					}
					return strongNameIdentityPermission.Copy();
				}
				else
				{
					if (strongNameIdentityPermission.m_strongNames == null || strongNameIdentityPermission.m_strongNames.Length == 0)
					{
						return this.Copy();
					}
					List<StrongName2> list = new List<StrongName2>();
					foreach (StrongName2 item in this.m_strongNames)
					{
						list.Add(item);
					}
					foreach (StrongName2 strongName in strongNameIdentityPermission.m_strongNames)
					{
						bool flag = false;
						foreach (StrongName2 target2 in list)
						{
							if (strongName.Equals(target2))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(strongName);
						}
					}
					return new StrongNameIdentityPermission(PermissionState.None)
					{
						m_strongNames = list.ToArray()
					};
				}
			}
		}

		// Token: 0x06002761 RID: 10081 RVA: 0x0008F1A0 File Offset: 0x0008D3A0
		public override void FromXml(SecurityElement e)
		{
			this.m_unrestricted = false;
			this.m_strongNames = null;
			CodeAccessPermission.ValidateElement(e, this);
			string text = e.Attribute("Unrestricted");
			if (text != null && string.Compare(text, "true", StringComparison.OrdinalIgnoreCase) == 0)
			{
				this.m_unrestricted = true;
				return;
			}
			string text2 = e.Attribute("PublicKeyBlob");
			string text3 = e.Attribute("Name");
			string text4 = e.Attribute("AssemblyVersion");
			List<StrongName2> list = new List<StrongName2>();
			if (text2 != null || text3 != null || text4 != null)
			{
				StrongName2 item = new StrongName2((text2 == null) ? null : new StrongNamePublicKeyBlob(text2), text3, (text4 == null) ? null : new Version(text4));
				list.Add(item);
			}
			ArrayList children = e.Children;
			if (children != null)
			{
				foreach (object obj in children)
				{
					SecurityElement securityElement = (SecurityElement)obj;
					text2 = securityElement.Attribute("PublicKeyBlob");
					text3 = securityElement.Attribute("Name");
					text4 = securityElement.Attribute("AssemblyVersion");
					if (text2 != null || text3 != null || text4 != null)
					{
						StrongName2 item = new StrongName2((text2 == null) ? null : new StrongNamePublicKeyBlob(text2), text3, (text4 == null) ? null : new Version(text4));
						list.Add(item);
					}
				}
			}
			if (list.Count != 0)
			{
				this.m_strongNames = list.ToArray();
			}
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x0008F30C File Offset: 0x0008D50C
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.StrongNameIdentityPermission");
			if (this.m_unrestricted)
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			else if (this.m_strongNames != null)
			{
				if (this.m_strongNames.Length == 1)
				{
					if (this.m_strongNames[0].m_publicKeyBlob != null)
					{
						securityElement.AddAttribute("PublicKeyBlob", Hex.EncodeHexString(this.m_strongNames[0].m_publicKeyBlob.PublicKey));
					}
					if (this.m_strongNames[0].m_name != null)
					{
						securityElement.AddAttribute("Name", this.m_strongNames[0].m_name);
					}
					if (this.m_strongNames[0].m_version != null)
					{
						securityElement.AddAttribute("AssemblyVersion", this.m_strongNames[0].m_version.ToString());
					}
				}
				else
				{
					for (int i = 0; i < this.m_strongNames.Length; i++)
					{
						SecurityElement securityElement2 = new SecurityElement("StrongName");
						if (this.m_strongNames[i].m_publicKeyBlob != null)
						{
							securityElement2.AddAttribute("PublicKeyBlob", Hex.EncodeHexString(this.m_strongNames[i].m_publicKeyBlob.PublicKey));
						}
						if (this.m_strongNames[i].m_name != null)
						{
							securityElement2.AddAttribute("Name", this.m_strongNames[i].m_name);
						}
						if (this.m_strongNames[i].m_version != null)
						{
							securityElement2.AddAttribute("AssemblyVersion", this.m_strongNames[i].m_version.ToString());
						}
						securityElement.AddChild(securityElement2);
					}
				}
			}
			return securityElement;
		}

		// Token: 0x06002763 RID: 10083 RVA: 0x0008F497 File Offset: 0x0008D697
		int IBuiltInPermission.GetTokenIndex()
		{
			return StrongNameIdentityPermission.GetTokenIndex();
		}

		// Token: 0x06002764 RID: 10084 RVA: 0x0008F49E File Offset: 0x0008D69E
		internal static int GetTokenIndex()
		{
			return 12;
		}

		// Token: 0x04000F40 RID: 3904
		private bool m_unrestricted;

		// Token: 0x04000F41 RID: 3905
		private StrongName2[] m_strongNames;
	}
}
