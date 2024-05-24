using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E3 RID: 2019
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapMonthDay : ISoapXsd
	{
		// Token: 0x17000E6D RID: 3693
		// (get) Token: 0x06005750 RID: 22352 RVA: 0x00135B2C File Offset: 0x00133D2C
		public static string XsdType
		{
			get
			{
				return "gMonthDay";
			}
		}

		// Token: 0x06005751 RID: 22353 RVA: 0x00135B33 File Offset: 0x00133D33
		public string GetXsdType()
		{
			return SoapMonthDay.XsdType;
		}

		// Token: 0x06005752 RID: 22354 RVA: 0x00135B3A File Offset: 0x00133D3A
		public SoapMonthDay()
		{
		}

		// Token: 0x06005753 RID: 22355 RVA: 0x00135B4D File Offset: 0x00133D4D
		public SoapMonthDay(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x17000E6E RID: 3694
		// (get) Token: 0x06005754 RID: 22356 RVA: 0x00135B67 File Offset: 0x00133D67
		// (set) Token: 0x06005755 RID: 22357 RVA: 0x00135B6F File Offset: 0x00133D6F
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

		// Token: 0x06005756 RID: 22358 RVA: 0x00135B78 File Offset: 0x00133D78
		public override string ToString()
		{
			return this._value.ToString("'--'MM'-'dd", CultureInfo.InvariantCulture);
		}

		// Token: 0x06005757 RID: 22359 RVA: 0x00135B8F File Offset: 0x00133D8F
		public static SoapMonthDay Parse(string value)
		{
			return new SoapMonthDay(DateTime.ParseExact(value, SoapMonthDay.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x0400280A RID: 10250
		private DateTime _value = DateTime.MinValue;

		// Token: 0x0400280B RID: 10251
		private static string[] formats = new string[]
		{
			"--MM-dd",
			"--MM-ddzzz"
		};
	}
}
