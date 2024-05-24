using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F0 RID: 2032
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNormalizedString : ISoapXsd
	{
		// Token: 0x17000E89 RID: 3721
		// (get) Token: 0x060057C3 RID: 22467 RVA: 0x00136513 File Offset: 0x00134713
		public static string XsdType
		{
			get
			{
				return "normalizedString";
			}
		}

		// Token: 0x060057C4 RID: 22468 RVA: 0x0013651A File Offset: 0x0013471A
		public string GetXsdType()
		{
			return SoapNormalizedString.XsdType;
		}

		// Token: 0x060057C5 RID: 22469 RVA: 0x00136521 File Offset: 0x00134721
		public SoapNormalizedString()
		{
		}

		// Token: 0x060057C6 RID: 22470 RVA: 0x00136529 File Offset: 0x00134729
		public SoapNormalizedString(string value)
		{
			this._value = this.Validate(value);
		}

		// Token: 0x17000E8A RID: 3722
		// (get) Token: 0x060057C7 RID: 22471 RVA: 0x0013653E File Offset: 0x0013473E
		// (set) Token: 0x060057C8 RID: 22472 RVA: 0x00136546 File Offset: 0x00134746
		public string Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = this.Validate(value);
			}
		}

		// Token: 0x060057C9 RID: 22473 RVA: 0x00136555 File Offset: 0x00134755
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057CA RID: 22474 RVA: 0x00136562 File Offset: 0x00134762
		public static SoapNormalizedString Parse(string value)
		{
			return new SoapNormalizedString(value);
		}

		// Token: 0x060057CB RID: 22475 RVA: 0x0013656C File Offset: 0x0013476C
		private string Validate(string value)
		{
			if (value == null || value.Length == 0)
			{
				return value;
			}
			char[] anyOf = new char[]
			{
				'\r',
				'\n',
				'\t'
			};
			int num = value.LastIndexOfAny(anyOf);
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:normalizedString",
					value
				}));
			}
			return value;
		}

		// Token: 0x0400281D RID: 10269
		private string _value;
	}
}
