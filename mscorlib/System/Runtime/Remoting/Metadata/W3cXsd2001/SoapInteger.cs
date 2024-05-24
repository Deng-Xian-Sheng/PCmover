using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E8 RID: 2024
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapInteger : ISoapXsd
	{
		// Token: 0x17000E77 RID: 3703
		// (get) Token: 0x0600577D RID: 22397 RVA: 0x00135F70 File Offset: 0x00134170
		public static string XsdType
		{
			get
			{
				return "integer";
			}
		}

		// Token: 0x0600577E RID: 22398 RVA: 0x00135F77 File Offset: 0x00134177
		public string GetXsdType()
		{
			return SoapInteger.XsdType;
		}

		// Token: 0x0600577F RID: 22399 RVA: 0x00135F7E File Offset: 0x0013417E
		public SoapInteger()
		{
		}

		// Token: 0x06005780 RID: 22400 RVA: 0x00135F86 File Offset: 0x00134186
		public SoapInteger(decimal value)
		{
			this._value = decimal.Truncate(value);
		}

		// Token: 0x17000E78 RID: 3704
		// (get) Token: 0x06005781 RID: 22401 RVA: 0x00135F9A File Offset: 0x0013419A
		// (set) Token: 0x06005782 RID: 22402 RVA: 0x00135FA2 File Offset: 0x001341A2
		public decimal Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = decimal.Truncate(value);
			}
		}

		// Token: 0x06005783 RID: 22403 RVA: 0x00135FB0 File Offset: 0x001341B0
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06005784 RID: 22404 RVA: 0x00135FC2 File Offset: 0x001341C2
		public static SoapInteger Parse(string value)
		{
			return new SoapInteger(decimal.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture));
		}

		// Token: 0x04002813 RID: 10259
		private decimal _value;
	}
}
