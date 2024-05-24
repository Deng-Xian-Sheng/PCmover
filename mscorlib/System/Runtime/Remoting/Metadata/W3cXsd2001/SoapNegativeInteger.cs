using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007EC RID: 2028
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNegativeInteger : ISoapXsd
	{
		// Token: 0x17000E7F RID: 3711
		// (get) Token: 0x0600579D RID: 22429 RVA: 0x00136299 File Offset: 0x00134499
		public static string XsdType
		{
			get
			{
				return "negativeInteger";
			}
		}

		// Token: 0x0600579E RID: 22430 RVA: 0x001362A0 File Offset: 0x001344A0
		public string GetXsdType()
		{
			return SoapNegativeInteger.XsdType;
		}

		// Token: 0x0600579F RID: 22431 RVA: 0x001362A7 File Offset: 0x001344A7
		public SoapNegativeInteger()
		{
		}

		// Token: 0x060057A0 RID: 22432 RVA: 0x001362B0 File Offset: 0x001344B0
		public SoapNegativeInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
			if (value > -1m)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:negativeInteger", value));
			}
		}

		// Token: 0x17000E80 RID: 3712
		// (get) Token: 0x060057A1 RID: 22433 RVA: 0x00136301 File Offset: 0x00134501
		// (set) Token: 0x060057A2 RID: 22434 RVA: 0x0013630C File Offset: 0x0013450C
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
				if (this._value > -1m)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:negativeInteger", value));
				}
			}
		}

		// Token: 0x060057A3 RID: 22435 RVA: 0x0013635C File Offset: 0x0013455C
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x060057A4 RID: 22436 RVA: 0x0013636E File Offset: 0x0013456E
		public static SoapNegativeInteger Parse(string value)
		{
			return new SoapNegativeInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x04002817 RID: 10263
		private decimal _value;
	}
}
