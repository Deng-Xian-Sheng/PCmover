using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F1 RID: 2033
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapToken : ISoapXsd
	{
		// Token: 0x17000E8B RID: 3723
		// (get) Token: 0x060057CC RID: 22476 RVA: 0x001365C7 File Offset: 0x001347C7
		public static string XsdType
		{
			get
			{
				return "token";
			}
		}

		// Token: 0x060057CD RID: 22477 RVA: 0x001365CE File Offset: 0x001347CE
		public string GetXsdType()
		{
			return SoapToken.XsdType;
		}

		// Token: 0x060057CE RID: 22478 RVA: 0x001365D5 File Offset: 0x001347D5
		public SoapToken()
		{
		}

		// Token: 0x060057CF RID: 22479 RVA: 0x001365DD File Offset: 0x001347DD
		public SoapToken(string value)
		{
			this._value = this.Validate(value);
		}

		// Token: 0x17000E8C RID: 3724
		// (get) Token: 0x060057D0 RID: 22480 RVA: 0x001365F2 File Offset: 0x001347F2
		// (set) Token: 0x060057D1 RID: 22481 RVA: 0x001365FA File Offset: 0x001347FA
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

		// Token: 0x060057D2 RID: 22482 RVA: 0x00136609 File Offset: 0x00134809
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057D3 RID: 22483 RVA: 0x00136616 File Offset: 0x00134816
		public static SoapToken Parse(string value)
		{
			return new SoapToken(value);
		}

		// Token: 0x060057D4 RID: 22484 RVA: 0x00136620 File Offset: 0x00134820
		private string Validate(string value)
		{
			if (value == null || value.Length == 0)
			{
				return value;
			}
			char[] anyOf = new char[]
			{
				'\r',
				'\t'
			};
			int num = value.LastIndexOfAny(anyOf);
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			if (value.Length > 0 && (char.IsWhiteSpace(value[0]) || char.IsWhiteSpace(value[value.Length - 1])))
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			num = value.IndexOf("  ");
			if (num > -1)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:token",
					value
				}));
			}
			return value;
		}

		// Token: 0x0400281E RID: 10270
		private string _value;
	}
}
