using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007EA RID: 2026
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNonPositiveInteger : ISoapXsd
	{
		// Token: 0x17000E7B RID: 3707
		// (get) Token: 0x0600578D RID: 22413 RVA: 0x001360C1 File Offset: 0x001342C1
		public static string XsdType
		{
			get
			{
				return "nonPositiveInteger";
			}
		}

		// Token: 0x0600578E RID: 22414 RVA: 0x001360C8 File Offset: 0x001342C8
		public string GetXsdType()
		{
			return SoapNonPositiveInteger.XsdType;
		}

		// Token: 0x0600578F RID: 22415 RVA: 0x001360CF File Offset: 0x001342CF
		public SoapNonPositiveInteger()
		{
		}

		// Token: 0x06005790 RID: 22416 RVA: 0x001360D8 File Offset: 0x001342D8
		public SoapNonPositiveInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
			if (this._value > 0m)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:nonPositiveInteger", value));
			}
		}

		// Token: 0x17000E7C RID: 3708
		// (get) Token: 0x06005791 RID: 22417 RVA: 0x0013612E File Offset: 0x0013432E
		// (set) Token: 0x06005792 RID: 22418 RVA: 0x00136138 File Offset: 0x00134338
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
				if (this._value > 0m)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:nonPositiveInteger", value));
				}
			}
		}

		// Token: 0x06005793 RID: 22419 RVA: 0x00136188 File Offset: 0x00134388
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06005794 RID: 22420 RVA: 0x0013619A File Offset: 0x0013439A
		public static SoapNonPositiveInteger Parse(string value)
		{
			return new SoapNonPositiveInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x04002815 RID: 10261
		private decimal _value;
	}
}
