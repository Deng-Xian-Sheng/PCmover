using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D6 RID: 2006
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	[ComVisible(true)]
	public sealed class SoapTypeAttribute : SoapAttribute
	{
		// Token: 0x060056E4 RID: 22244 RVA: 0x0013487E File Offset: 0x00132A7E
		internal bool IsInteropXmlElement()
		{
			return (this._explicitlySet & (SoapTypeAttribute.ExplicitlySet.XmlElementName | SoapTypeAttribute.ExplicitlySet.XmlNamespace)) > SoapTypeAttribute.ExplicitlySet.None;
		}

		// Token: 0x060056E5 RID: 22245 RVA: 0x0013488B File Offset: 0x00132A8B
		internal bool IsInteropXmlType()
		{
			return (this._explicitlySet & (SoapTypeAttribute.ExplicitlySet.XmlTypeName | SoapTypeAttribute.ExplicitlySet.XmlTypeNamespace)) > SoapTypeAttribute.ExplicitlySet.None;
		}

		// Token: 0x17000E4C RID: 3660
		// (get) Token: 0x060056E6 RID: 22246 RVA: 0x00134899 File Offset: 0x00132A99
		// (set) Token: 0x060056E7 RID: 22247 RVA: 0x001348A1 File Offset: 0x00132AA1
		public SoapOption SoapOptions
		{
			get
			{
				return this._SoapOptions;
			}
			set
			{
				this._SoapOptions = value;
			}
		}

		// Token: 0x17000E4D RID: 3661
		// (get) Token: 0x060056E8 RID: 22248 RVA: 0x001348AA File Offset: 0x00132AAA
		// (set) Token: 0x060056E9 RID: 22249 RVA: 0x001348D8 File Offset: 0x00132AD8
		public string XmlElementName
		{
			get
			{
				if (this._XmlElementName == null && this.ReflectInfo != null)
				{
					this._XmlElementName = SoapTypeAttribute.GetTypeName((Type)this.ReflectInfo);
				}
				return this._XmlElementName;
			}
			set
			{
				this._XmlElementName = value;
				this._explicitlySet |= SoapTypeAttribute.ExplicitlySet.XmlElementName;
			}
		}

		// Token: 0x17000E4E RID: 3662
		// (get) Token: 0x060056EA RID: 22250 RVA: 0x001348EF File Offset: 0x00132AEF
		// (set) Token: 0x060056EB RID: 22251 RVA: 0x00134913 File Offset: 0x00132B13
		public override string XmlNamespace
		{
			get
			{
				if (this.ProtXmlNamespace == null && this.ReflectInfo != null)
				{
					this.ProtXmlNamespace = this.XmlTypeNamespace;
				}
				return this.ProtXmlNamespace;
			}
			set
			{
				this.ProtXmlNamespace = value;
				this._explicitlySet |= SoapTypeAttribute.ExplicitlySet.XmlNamespace;
			}
		}

		// Token: 0x17000E4F RID: 3663
		// (get) Token: 0x060056EC RID: 22252 RVA: 0x0013492A File Offset: 0x00132B2A
		// (set) Token: 0x060056ED RID: 22253 RVA: 0x00134958 File Offset: 0x00132B58
		public string XmlTypeName
		{
			get
			{
				if (this._XmlTypeName == null && this.ReflectInfo != null)
				{
					this._XmlTypeName = SoapTypeAttribute.GetTypeName((Type)this.ReflectInfo);
				}
				return this._XmlTypeName;
			}
			set
			{
				this._XmlTypeName = value;
				this._explicitlySet |= SoapTypeAttribute.ExplicitlySet.XmlTypeName;
			}
		}

		// Token: 0x17000E50 RID: 3664
		// (get) Token: 0x060056EE RID: 22254 RVA: 0x0013496F File Offset: 0x00132B6F
		// (set) Token: 0x060056EF RID: 22255 RVA: 0x0013499E File Offset: 0x00132B9E
		public string XmlTypeNamespace
		{
			[SecuritySafeCritical]
			get
			{
				if (this._XmlTypeNamespace == null && this.ReflectInfo != null)
				{
					this._XmlTypeNamespace = XmlNamespaceEncoder.GetXmlNamespaceForTypeNamespace((RuntimeType)this.ReflectInfo, null);
				}
				return this._XmlTypeNamespace;
			}
			set
			{
				this._XmlTypeNamespace = value;
				this._explicitlySet |= SoapTypeAttribute.ExplicitlySet.XmlTypeNamespace;
			}
		}

		// Token: 0x17000E51 RID: 3665
		// (get) Token: 0x060056F0 RID: 22256 RVA: 0x001349B5 File Offset: 0x00132BB5
		// (set) Token: 0x060056F1 RID: 22257 RVA: 0x001349BD File Offset: 0x00132BBD
		public XmlFieldOrderOption XmlFieldOrder
		{
			get
			{
				return this._XmlFieldOrder;
			}
			set
			{
				this._XmlFieldOrder = value;
			}
		}

		// Token: 0x17000E52 RID: 3666
		// (get) Token: 0x060056F2 RID: 22258 RVA: 0x001349C6 File Offset: 0x00132BC6
		// (set) Token: 0x060056F3 RID: 22259 RVA: 0x001349C9 File Offset: 0x00132BC9
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

		// Token: 0x060056F4 RID: 22260 RVA: 0x001349DC File Offset: 0x00132BDC
		private static string GetTypeName(Type t)
		{
			if (!t.IsNested)
			{
				return t.Name;
			}
			string fullName = t.FullName;
			string @namespace = t.Namespace;
			if (@namespace == null || @namespace.Length == 0)
			{
				return fullName;
			}
			return fullName.Substring(@namespace.Length + 1);
		}

		// Token: 0x040027CE RID: 10190
		private SoapTypeAttribute.ExplicitlySet _explicitlySet;

		// Token: 0x040027CF RID: 10191
		private SoapOption _SoapOptions;

		// Token: 0x040027D0 RID: 10192
		private string _XmlElementName;

		// Token: 0x040027D1 RID: 10193
		private string _XmlTypeName;

		// Token: 0x040027D2 RID: 10194
		private string _XmlTypeNamespace;

		// Token: 0x040027D3 RID: 10195
		private XmlFieldOrderOption _XmlFieldOrder;

		// Token: 0x02000C6E RID: 3182
		[Flags]
		[Serializable]
		private enum ExplicitlySet
		{
			// Token: 0x040037E8 RID: 14312
			None = 0,
			// Token: 0x040037E9 RID: 14313
			XmlElementName = 1,
			// Token: 0x040037EA RID: 14314
			XmlNamespace = 2,
			// Token: 0x040037EB RID: 14315
			XmlTypeName = 4,
			// Token: 0x040037EC RID: 14316
			XmlTypeNamespace = 8
		}
	}
}
