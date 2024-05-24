using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E9 RID: 2025
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapPositiveInteger : ISoapXsd
	{
		// Token: 0x17000E79 RID: 3705
		// (get) Token: 0x06005785 RID: 22405 RVA: 0x00135FD5 File Offset: 0x001341D5
		public static string XsdType
		{
			get
			{
				return "positiveInteger";
			}
		}

		// Token: 0x06005786 RID: 22406 RVA: 0x00135FDC File Offset: 0x001341DC
		public string GetXsdType()
		{
			return SoapPositiveInteger.XsdType;
		}

		// Token: 0x06005787 RID: 22407 RVA: 0x00135FE3 File Offset: 0x001341E3
		public SoapPositiveInteger()
		{
		}

		// Token: 0x06005788 RID: 22408 RVA: 0x00135FEC File Offset: 0x001341EC
		public SoapPositiveInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
			if (this._value < 1m)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:positiveInteger", value));
			}
		}

		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x06005789 RID: 22409 RVA: 0x00136042 File Offset: 0x00134242
		// (set) Token: 0x0600578A RID: 22410 RVA: 0x0013604C File Offset: 0x0013424C
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
				if (this._value < 1m)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:positiveInteger", value));
				}
			}
		}

		// Token: 0x0600578B RID: 22411 RVA: 0x0013609C File Offset: 0x0013429C
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x0600578C RID: 22412 RVA: 0x001360AE File Offset: 0x001342AE
		public static SoapPositiveInteger Parse(string value)
		{
			return new SoapPositiveInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x04002814 RID: 10260
		private decimal _value;
	}
}
