using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D7 RID: 2007
	[AttributeUsage(AttributeTargets.Method)]
	[ComVisible(true)]
	public sealed class SoapMethodAttribute : SoapAttribute
	{
		// Token: 0x17000E53 RID: 3667
		// (get) Token: 0x060056F6 RID: 22262 RVA: 0x00134A2B File Offset: 0x00132C2B
		internal bool SoapActionExplicitySet
		{
			get
			{
				return this._bSoapActionExplicitySet;
			}
		}

		// Token: 0x17000E54 RID: 3668
		// (get) Token: 0x060056F7 RID: 22263 RVA: 0x00134A33 File Offset: 0x00132C33
		// (set) Token: 0x060056F8 RID: 22264 RVA: 0x00134A69 File Offset: 0x00132C69
		public string SoapAction
		{
			[SecuritySafeCritical]
			get
			{
				if (this._SoapAction == null)
				{
					this._SoapAction = this.XmlTypeNamespaceOfDeclaringType + "#" + ((MemberInfo)this.ReflectInfo).Name;
				}
				return this._SoapAction;
			}
			set
			{
				this._SoapAction = value;
				this._bSoapActionExplicitySet = true;
			}
		}

		// Token: 0x17000E55 RID: 3669
		// (get) Token: 0x060056F9 RID: 22265 RVA: 0x00134A79 File Offset: 0x00132C79
		// (set) Token: 0x060056FA RID: 22266 RVA: 0x00134A7C File Offset: 0x00132C7C
		public override bool UseAttribute
		{
			get
			{
				return false;
			}
			set
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Attribute_UseAttributeNotsettable"));
			}
		}

		// Token: 0x17000E56 RID: 3670
		// (get) Token: 0x060056FB RID: 22267 RVA: 0x00134A8D File Offset: 0x00132C8D
		// (set) Token: 0x060056FC RID: 22268 RVA: 0x00134AA9 File Offset: 0x00132CA9
		public override string XmlNamespace
		{
			[SecuritySafeCritical]
			get
			{
				if (this.ProtXmlNamespace == null)
				{
					this.ProtXmlNamespace = this.XmlTypeNamespaceOfDeclaringType;
				}
				return this.ProtXmlNamespace;
			}
			set
			{
				this.ProtXmlNamespace = value;
			}
		}

		// Token: 0x17000E57 RID: 3671
		// (get) Token: 0x060056FD RID: 22269 RVA: 0x00134AB2 File Offset: 0x00132CB2
		// (set) Token: 0x060056FE RID: 22270 RVA: 0x00134AEA File Offset: 0x00132CEA
		public string ResponseXmlElementName
		{
			get
			{
				if (this._responseXmlElementName == null && this.ReflectInfo != null)
				{
					this._responseXmlElementName = ((MemberInfo)this.ReflectInfo).Name + "Response";
				}
				return this._responseXmlElementName;
			}
			set
			{
				this._responseXmlElementName = value;
			}
		}

		// Token: 0x17000E58 RID: 3672
		// (get) Token: 0x060056FF RID: 22271 RVA: 0x00134AF3 File Offset: 0x00132CF3
		// (set) Token: 0x06005700 RID: 22272 RVA: 0x00134B0F File Offset: 0x00132D0F
		public string ResponseXmlNamespace
		{
			get
			{
				if (this._responseXmlNamespace == null)
				{
					this._responseXmlNamespace = this.XmlNamespace;
				}
				return this._responseXmlNamespace;
			}
			set
			{
				this._responseXmlNamespace = value;
			}
		}

		// Token: 0x17000E59 RID: 3673
		// (get) Token: 0x06005701 RID: 22273 RVA: 0x00134B18 File Offset: 0x00132D18
		// (set) Token: 0x06005702 RID: 22274 RVA: 0x00134B33 File Offset: 0x00132D33
		public string ReturnXmlElementName
		{
			get
			{
				if (this._returnXmlElementName == null)
				{
					this._returnXmlElementName = "return";
				}
				return this._returnXmlElementName;
			}
			set
			{
				this._returnXmlElementName = value;
			}
		}

		// Token: 0x17000E5A RID: 3674
		// (get) Token: 0x06005703 RID: 22275 RVA: 0x00134B3C File Offset: 0x00132D3C
		private string XmlTypeNamespaceOfDeclaringType
		{
			[SecurityCritical]
			get
			{
				if (this.ReflectInfo != null)
				{
					Type declaringType = ((MemberInfo)this.ReflectInfo).DeclaringType;
					return XmlNamespaceEncoder.GetXmlNamespaceForType((RuntimeType)declaringType, null);
				}
				return null;
			}
		}

		// Token: 0x040027D4 RID: 10196
		private string _SoapAction;

		// Token: 0x040027D5 RID: 10197
		private string _responseXmlElementName;

		// Token: 0x040027D6 RID: 10198
		private string _responseXmlNamespace;

		// Token: 0x040027D7 RID: 10199
		private string _returnXmlElementName;

		// Token: 0x040027D8 RID: 10200
		private bool _bSoapActionExplicitySet;
	}
}
