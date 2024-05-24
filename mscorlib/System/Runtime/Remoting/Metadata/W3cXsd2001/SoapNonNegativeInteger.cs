using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007EB RID: 2027
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNonNegativeInteger : ISoapXsd
	{
		// Token: 0x17000E7D RID: 3709
		// (get) Token: 0x06005795 RID: 22421 RVA: 0x001361AD File Offset: 0x001343AD
		public static string XsdType
		{
			get
			{
				return "nonNegativeInteger";
			}
		}

		// Token: 0x06005796 RID: 22422 RVA: 0x001361B4 File Offset: 0x001343B4
		public string GetXsdType()
		{
			return SoapNonNegativeInteger.XsdType;
		}

		// Token: 0x06005797 RID: 22423 RVA: 0x001361BB File Offset: 0x001343BB
		public SoapNonNegativeInteger()
		{
		}

		// Token: 0x06005798 RID: 22424 RVA: 0x001361C4 File Offset: 0x001343C4
		public SoapNonNegativeInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
			if (this._value < 0m)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:nonNegativeInteger", value));
			}
		}

		// Token: 0x17000E7E RID: 3710
		// (get) Token: 0x06005799 RID: 22425 RVA: 0x0013621A File Offset: 0x0013441A
		// (set) Token: 0x0600579A RID: 22426 RVA: 0x00136224 File Offset: 0x00134424
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
				if (this._value < 0m)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:nonNegativeInteger", value));
				}
			}
		}

		// Token: 0x0600579B RID: 22427 RVA: 0x00136274 File Offset: 0x00134474
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x0600579C RID: 22428 RVA: 0x00136286 File Offset: 0x00134486
		public static SoapNonNegativeInteger Parse(string value)
		{
			return new SoapNonNegativeInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x04002816 RID: 10262
		private decimal _value;
	}
}
