using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E2 RID: 2018
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapYear : ISoapXsd
	{
		// Token: 0x17000E6A RID: 3690
		// (get) Token: 0x06005744 RID: 22340 RVA: 0x00135A08 File Offset: 0x00133C08
		public static string XsdType
		{
			get
			{
				return "gYear";
			}
		}

		// Token: 0x06005745 RID: 22341 RVA: 0x00135A0F File Offset: 0x00133C0F
		public string GetXsdType()
		{
			return SoapYear.XsdType;
		}

		// Token: 0x06005746 RID: 22342 RVA: 0x00135A16 File Offset: 0x00133C16
		public SoapYear()
		{
		}

		// Token: 0x06005747 RID: 22343 RVA: 0x00135A29 File Offset: 0x00133C29
		public SoapYear(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x06005748 RID: 22344 RVA: 0x00135A43 File Offset: 0x00133C43
		public SoapYear(DateTime value, int sign)
		{
			this._value = value;
			this._sign = sign;
		}

		// Token: 0x17000E6B RID: 3691
		// (get) Token: 0x06005749 RID: 22345 RVA: 0x00135A64 File Offset: 0x00133C64
		// (set) Token: 0x0600574A RID: 22346 RVA: 0x00135A6C File Offset: 0x00133C6C
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

		// Token: 0x17000E6C RID: 3692
		// (get) Token: 0x0600574B RID: 22347 RVA: 0x00135A75 File Offset: 0x00133C75
		// (set) Token: 0x0600574C RID: 22348 RVA: 0x00135A7D File Offset: 0x00133C7D
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

		// Token: 0x0600574D RID: 22349 RVA: 0x00135A86 File Offset: 0x00133C86
		public override string ToString()
		{
			if (this._sign < 0)
			{
				return this._value.ToString("'-'yyyy", CultureInfo.InvariantCulture);
			}
			return this._value.ToString("yyyy", CultureInfo.InvariantCulture);
		}

		// Token: 0x0600574E RID: 22350 RVA: 0x00135ABC File Offset: 0x00133CBC
		public static SoapYear Parse(string value)
		{
			int sign = 0;
			if (value[0] == '-')
			{
				sign = -1;
			}
			return new SoapYear(DateTime.ParseExact(value, SoapYear.formats, CultureInfo.InvariantCulture, DateTimeStyles.None), sign);
		}

		// Token: 0x04002807 RID: 10247
		private DateTime _value = DateTime.MinValue;

		// Token: 0x04002808 RID: 10248
		private int _sign;

		// Token: 0x04002809 RID: 10249
		private static string[] formats = new string[]
		{
			"yyyy",
			"'+'yyyy",
			"'-'yyyy",
			"yyyyzzz",
			"'+'yyyyzzz",
			"'-'yyyyzzz"
		};
	}
}
