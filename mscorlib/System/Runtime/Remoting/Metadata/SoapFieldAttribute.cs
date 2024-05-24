using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D8 RID: 2008
	[AttributeUsage(AttributeTargets.Field)]
	[ComVisible(true)]
	public sealed class SoapFieldAttribute : SoapAttribute
	{
		// Token: 0x06005705 RID: 22277 RVA: 0x00134B78 File Offset: 0x00132D78
		public bool IsInteropXmlElement()
		{
			return (this._explicitlySet & SoapFieldAttribute.ExplicitlySet.XmlElementName) > SoapFieldAttribute.ExplicitlySet.None;
		}

		// Token: 0x17000E5B RID: 3675
		// (get) Token: 0x06005706 RID: 22278 RVA: 0x00134B85 File Offset: 0x00132D85
		// (set) Token: 0x06005707 RID: 22279 RVA: 0x00134BB3 File Offset: 0x00132DB3
		public string XmlElementName
		{
			get
			{
				if (this._xmlElementName == null && this.ReflectInfo != null)
				{
					this._xmlElementName = ((FieldInfo)this.ReflectInfo).Name;
				}
				return this._xmlElementName;
			}
			set
			{
				this._xmlElementName = value;
				this._explicitlySet |= SoapFieldAttribute.ExplicitlySet.XmlElementName;
			}
		}

		// Token: 0x17000E5C RID: 3676
		// (get) Token: 0x06005708 RID: 22280 RVA: 0x00134BCA File Offset: 0x00132DCA
		// (set) Token: 0x06005709 RID: 22281 RVA: 0x00134BD2 File Offset: 0x00132DD2
		public int Order
		{
			get
			{
				return this._order;
			}
			set
			{
				this._order = value;
			}
		}

		// Token: 0x040027D9 RID: 10201
		private SoapFieldAttribute.ExplicitlySet _explicitlySet;

		// Token: 0x040027DA RID: 10202
		private string _xmlElementName;

		// Token: 0x040027DB RID: 10203
		private int _order;

		// Token: 0x02000C6F RID: 3183
		[Flags]
		[Serializable]
		private enum ExplicitlySet
		{
			// Token: 0x040037EE RID: 14318
			None = 0,
			// Token: 0x040037EF RID: 14319
			XmlElementName = 1
		}
	}
}
