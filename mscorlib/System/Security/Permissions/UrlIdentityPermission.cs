using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x0200030E RID: 782
	[ComVisible(true)]
	[Serializable]
	public sealed class UrlIdentityPermission : CodeAccessPermission, IBuiltInPermission
	{
		// Token: 0x06002783 RID: 10115 RVA: 0x0008F9D8 File Offset: 0x0008DBD8
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			if (this.m_serializedPermission != null)
			{
				this.FromXml(SecurityElement.FromString(this.m_serializedPermission));
				this.m_serializedPermission = null;
				return;
			}
			if (this.m_url != null)
			{
				this.m_unrestricted = false;
				this.m_urls = new URLString[1];
				this.m_urls[0] = this.m_url;
				this.m_url = null;
			}
		}

		// Token: 0x06002784 RID: 10116 RVA: 0x0008FA38 File Offset: 0x0008DC38
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			if ((ctx.State & ~(StreamingContextStates.Clone | StreamingContextStates.CrossAppDomain)) != (StreamingContextStates)0)
			{
				this.m_serializedPermission = this.ToXml().ToString();
				if (this.m_urls != null && this.m_urls.Length == 1)
				{
					this.m_url = this.m_urls[0];
				}
			}
		}

		// Token: 0x06002785 RID: 10117 RVA: 0x0008FA86 File Offset: 0x0008DC86
		[OnSerialized]
		private void OnSerialized(StreamingContext ctx)
		{
			if ((ctx.State & ~(StreamingContextStates.Clone | StreamingContextStates.CrossAppDomain)) != (StreamingContextStates)0)
			{
				this.m_serializedPermission = null;
				this.m_url = null;
			}
		}

		// Token: 0x06002786 RID: 10118 RVA: 0x0008FAA5 File Offset: 0x0008DCA5
		public UrlIdentityPermission(PermissionState state)
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

		// Token: 0x06002787 RID: 10119 RVA: 0x0008FAD3 File Offset: 0x0008DCD3
		public UrlIdentityPermission(string site)
		{
			if (site == null)
			{
				throw new ArgumentNullException("site");
			}
			this.Url = site;
		}

		// Token: 0x06002788 RID: 10120 RVA: 0x0008FAF0 File Offset: 0x0008DCF0
		internal UrlIdentityPermission(URLString site)
		{
			this.m_unrestricted = false;
			this.m_urls = new URLString[1];
			this.m_urls[0] = site;
		}

		// Token: 0x06002789 RID: 10121 RVA: 0x0008FB14 File Offset: 0x0008DD14
		internal void AppendOrigin(ArrayList originList)
		{
			if (this.m_urls == null)
			{
				originList.Add("");
				return;
			}
			for (int i = 0; i < this.m_urls.Length; i++)
			{
				originList.Add(this.m_urls[i].ToString());
			}
		}

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x0600278B RID: 10123 RVA: 0x0008FB93 File Offset: 0x0008DD93
		// (set) Token: 0x0600278A RID: 10122 RVA: 0x0008FB5D File Offset: 0x0008DD5D
		public string Url
		{
			get
			{
				if (this.m_urls == null)
				{
					return "";
				}
				if (this.m_urls.Length == 1)
				{
					return this.m_urls[0].ToString();
				}
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_AmbiguousIdentity"));
			}
			set
			{
				this.m_unrestricted = false;
				if (value == null || value.Length == 0)
				{
					this.m_urls = null;
					return;
				}
				this.m_urls = new URLString[1];
				this.m_urls[0] = new URLString(value);
			}
		}

		// Token: 0x0600278C RID: 10124 RVA: 0x0008FBCC File Offset: 0x0008DDCC
		public override IPermission Copy()
		{
			UrlIdentityPermission urlIdentityPermission = new UrlIdentityPermission(PermissionState.None);
			urlIdentityPermission.m_unrestricted = this.m_unrestricted;
			if (this.m_urls != null)
			{
				urlIdentityPermission.m_urls = new URLString[this.m_urls.Length];
				for (int i = 0; i < this.m_urls.Length; i++)
				{
					urlIdentityPermission.m_urls[i] = (URLString)this.m_urls[i].Copy();
				}
			}
			return urlIdentityPermission;
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0008FC38 File Offset: 0x0008DE38
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return !this.m_unrestricted && (this.m_urls == null || this.m_urls.Length == 0);
			}
			UrlIdentityPermission urlIdentityPermission = target as UrlIdentityPermission;
			if (urlIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (urlIdentityPermission.m_unrestricted)
			{
				return true;
			}
			if (this.m_unrestricted)
			{
				return false;
			}
			if (this.m_urls != null)
			{
				foreach (URLString urlstring in this.m_urls)
				{
					bool flag = false;
					if (urlIdentityPermission.m_urls != null)
					{
						foreach (URLString operand in urlIdentityPermission.m_urls)
						{
							if (urlstring.IsSubsetOf(operand))
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

		// Token: 0x0600278E RID: 10126 RVA: 0x0008FD10 File Offset: 0x0008DF10
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			UrlIdentityPermission urlIdentityPermission = target as UrlIdentityPermission;
			if (urlIdentityPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (this.m_unrestricted && urlIdentityPermission.m_unrestricted)
			{
				return new UrlIdentityPermission(PermissionState.None)
				{
					m_unrestricted = true
				};
			}
			if (this.m_unrestricted)
			{
				return urlIdentityPermission.Copy();
			}
			if (urlIdentityPermission.m_unrestricted)
			{
				return this.Copy();
			}
			if (this.m_urls == null || urlIdentityPermission.m_urls == null || this.m_urls.Length == 0 || urlIdentityPermission.m_urls.Length == 0)
			{
				return null;
			}
			List<URLString> list = new List<URLString>();
			foreach (URLString urlstring in this.m_urls)
			{
				foreach (URLString operand in urlIdentityPermission.m_urls)
				{
					URLString urlstring2 = (URLString)urlstring.Intersect(operand);
					if (urlstring2 != null)
					{
						list.Add(urlstring2);
					}
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			return new UrlIdentityPermission(PermissionState.None)
			{
				m_urls = list.ToArray()
			};
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x0008FE38 File Offset: 0x0008E038
		public override IPermission Union(IPermission target)
		{
			if (target == null)
			{
				if ((this.m_urls == null || this.m_urls.Length == 0) && !this.m_unrestricted)
				{
					return null;
				}
				return this.Copy();
			}
			else
			{
				UrlIdentityPermission urlIdentityPermission = target as UrlIdentityPermission;
				if (urlIdentityPermission == null)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
					{
						base.GetType().FullName
					}));
				}
				if (this.m_unrestricted || urlIdentityPermission.m_unrestricted)
				{
					return new UrlIdentityPermission(PermissionState.None)
					{
						m_unrestricted = true
					};
				}
				if (this.m_urls == null || this.m_urls.Length == 0)
				{
					if (urlIdentityPermission.m_urls == null || urlIdentityPermission.m_urls.Length == 0)
					{
						return null;
					}
					return urlIdentityPermission.Copy();
				}
				else
				{
					if (urlIdentityPermission.m_urls == null || urlIdentityPermission.m_urls.Length == 0)
					{
						return this.Copy();
					}
					List<URLString> list = new List<URLString>();
					foreach (URLString item in this.m_urls)
					{
						list.Add(item);
					}
					foreach (URLString urlstring in urlIdentityPermission.m_urls)
					{
						bool flag = false;
						foreach (URLString url in list)
						{
							if (urlstring.Equals(url))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							list.Add(urlstring);
						}
					}
					return new UrlIdentityPermission(PermissionState.None)
					{
						m_urls = list.ToArray()
					};
				}
			}
		}

		// Token: 0x06002790 RID: 10128 RVA: 0x0008FFBC File Offset: 0x0008E1BC
		public override void FromXml(SecurityElement esd)
		{
			this.m_unrestricted = false;
			this.m_urls = null;
			CodeAccessPermission.ValidateElement(esd, this);
			string text = esd.Attribute("Unrestricted");
			if (text != null && string.Compare(text, "true", StringComparison.OrdinalIgnoreCase) == 0)
			{
				this.m_unrestricted = true;
				return;
			}
			string text2 = esd.Attribute("Url");
			List<URLString> list = new List<URLString>();
			if (text2 != null)
			{
				list.Add(new URLString(text2, true));
			}
			ArrayList children = esd.Children;
			if (children != null)
			{
				foreach (object obj in children)
				{
					SecurityElement securityElement = (SecurityElement)obj;
					text2 = securityElement.Attribute("Url");
					if (text2 != null)
					{
						list.Add(new URLString(text2, true));
					}
				}
			}
			if (list.Count != 0)
			{
				this.m_urls = list.ToArray();
			}
		}

		// Token: 0x06002791 RID: 10129 RVA: 0x000900A8 File Offset: 0x0008E2A8
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.UrlIdentityPermission");
			if (this.m_unrestricted)
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			else if (this.m_urls != null)
			{
				if (this.m_urls.Length == 1)
				{
					securityElement.AddAttribute("Url", this.m_urls[0].ToString());
				}
				else
				{
					for (int i = 0; i < this.m_urls.Length; i++)
					{
						SecurityElement securityElement2 = new SecurityElement("Url");
						securityElement2.AddAttribute("Url", this.m_urls[i].ToString());
						securityElement.AddChild(securityElement2);
					}
				}
			}
			return securityElement;
		}

		// Token: 0x06002792 RID: 10130 RVA: 0x00090146 File Offset: 0x0008E346
		int IBuiltInPermission.GetTokenIndex()
		{
			return UrlIdentityPermission.GetTokenIndex();
		}

		// Token: 0x06002793 RID: 10131 RVA: 0x0009014D File Offset: 0x0008E34D
		internal static int GetTokenIndex()
		{
			return 13;
		}

		// Token: 0x04000F4E RID: 3918
		[OptionalField(VersionAdded = 2)]
		private bool m_unrestricted;

		// Token: 0x04000F4F RID: 3919
		[OptionalField(VersionAdded = 2)]
		private URLString[] m_urls;

		// Token: 0x04000F50 RID: 3920
		[OptionalField(VersionAdded = 2)]
		private string m_serializedPermission;

		// Token: 0x04000F51 RID: 3921
		private URLString m_url;
	}
}
