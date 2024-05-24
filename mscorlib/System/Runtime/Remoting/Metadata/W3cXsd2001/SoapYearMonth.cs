using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E1 RID: 2017
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapYearMonth : ISoapXsd
	{
		// Token: 0x17000E67 RID: 3687
		// (get) Token: 0x06005738 RID: 22328 RVA: 0x001358E4 File Offset: 0x00133AE4
		public static string XsdType
		{
			get
			{
				return "gYearMonth";
			}
		}

		// Token: 0x06005739 RID: 22329 RVA: 0x001358EB File Offset: 0x00133AEB
		public string GetXsdType()
		{
			return SoapYearMonth.XsdType;
		}

		// Token: 0x0600573A RID: 22330 RVA: 0x001358F2 File Offset: 0x00133AF2
		public SoapYearMonth()
		{
		}

		// Token: 0x0600573B RID: 22331 RVA: 0x00135905 File Offset: 0x00133B05
		public SoapYearMonth(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x0600573C RID: 22332 RVA: 0x0013591F File Offset: 0x00133B1F
		public SoapYearMonth(DateTime value, int sign)
		{
			this._value = value;
			this._sign = sign;
		}

		// Token: 0x17000E68 RID: 3688
		// (get) Token: 0x0600573D RID: 22333 RVA: 0x00135940 File Offset: 0x00133B40
		// (set) Token: 0x0600573E RID: 22334 RVA: 0x00135948 File Offset: 0x00133B48
		public DateTime Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x17000E69 RID: 3689
		// (get) Token: 0x0600573F RID: 22335 RVA: 0x00135951 File Offset: 0x00133B51
		// (set) Token: 0x06005740 RID: 22336 RVA: 0x00135959 File Offset: 0x00133B59
		public int Sign
		{
			get
			{
				return this._sign;
			}
			set
			{
				this._sign = value;
			}
		}

		// Token: 0x06005741 RID: 22337 RVA: 0x00135962 File Offset: 0x00133B62
		public override string ToString()
		{
			if (this._sign < 0)
			{
				return this._value.ToString("'-'yyyy-MM", CultureInfo.InvariantCulture);
			}
			return this._value.ToString("yyyy-MM", CultureInfo.InvariantCulture);
		}

		// Token: 0x06005742 RID: 22338 RVA: 0x00135998 File Offset: 0x00133B98
		public static SoapYearMonth Parse(string value)
		{
			int sign = 0;
			if (value[0] == '-')
			{
				sign = -1;
			}
			return new SoapYearMonth(DateTime.ParseExact(value, SoapYearMonth.formats, CultureInfo.InvariantCulture, DateTimeStyles.None), sign);
		}

		// Token: 0x04002804 RID: 10244
		private DateTime _value = DateTime.MinValue;

		// Token: 0x04002805 RID: 10245
		private int _sign;

		// Token: 0x04002806 RID: 10246
		private static string[] formats = new string[]
		{
			"yyyy-MM",
			"'+'yyyy-MM",
			"'-'yyyy-MM",
			"yyyy-MMzzz",
			"'+'yyyy-MMzzz",
			"'-'yyyy-MMzzz"
		};
	}
}
