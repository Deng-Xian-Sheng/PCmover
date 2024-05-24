using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E0 RID: 2016
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapDate : ISoapXsd
	{
		// Token: 0x17000E64 RID: 3684
		// (get) Token: 0x0600572C RID: 22316 RVA: 0x0013577A File Offset: 0x0013397A
		public static string XsdType
		{
			get
			{
				return "date";
			}
		}

		// Token: 0x0600572D RID: 22317 RVA: 0x00135781 File Offset: 0x00133981
		public string GetXsdType()
		{
			return SoapDate.XsdType;
		}

		// Token: 0x0600572E RID: 22318 RVA: 0x00135788 File Offset: 0x00133988
		public SoapDate()
		{
		}

		// Token: 0x0600572F RID: 22319 RVA: 0x001357B0 File Offset: 0x001339B0
		public SoapDate(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x06005730 RID: 22320 RVA: 0x001357E0 File Offset: 0x001339E0
		public SoapDate(DateTime value, int sign)
		{
			this._value = value;
			this._sign = sign;
		}

		// Token: 0x17000E65 RID: 3685
		// (get) Token: 0x06005731 RID: 22321 RVA: 0x00135814 File Offset: 0x00133A14
		// (set) Token: 0x06005732 RID: 22322 RVA: 0x0013581C File Offset: 0x00133A1C
		public DateTime Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value.Date;
			}
		}

		// Token: 0x17000E66 RID: 3686
		// (get) Token: 0x06005733 RID: 22323 RVA: 0x0013582B File Offset: 0x00133A2B
		// (set) Token: 0x06005734 RID: 22324 RVA: 0x00135833 File Offset: 0x00133A33
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

		// Token: 0x06005735 RID: 22325 RVA: 0x0013583C File Offset: 0x00133A3C
		public override string ToString()
		{
			if (this._sign < 0)
			{
				return this._value.ToString("'-'yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
			return this._value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
		}

		// Token: 0x06005736 RID: 22326 RVA: 0x00135874 File Offset: 0x00133A74
		public static SoapDate Parse(string value)
		{
			int sign = 0;
			if (value[0] == '-')
			{
				sign = -1;
			}
			return new SoapDate(DateTime.ParseExact(value, SoapDate.formats, CultureInfo.InvariantCulture, DateTimeStyles.None), sign);
		}

		// Token: 0x04002801 RID: 10241
		private DateTime _value = DateTime.MinValue.Date;

		// Token: 0x04002802 RID: 10242
		private int _sign;

		// Token: 0x04002803 RID: 10243
		private static string[] formats = new string[]
		{
			"yyyy-MM-dd",
			"'+'yyyy-MM-dd",
			"'-'yyyy-MM-dd",
			"yyyy-MM-ddzzz",
			"'+'yyyy-MM-ddzzz",
			"'-'yyyy-MM-ddzzz"
		};
	}
}
