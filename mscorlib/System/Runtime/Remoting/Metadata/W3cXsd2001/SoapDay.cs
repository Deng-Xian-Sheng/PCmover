using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E4 RID: 2020
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapDay : ISoapXsd
	{
		// Token: 0x17000E6F RID: 3695
		// (get) Token: 0x06005759 RID: 22361 RVA: 0x00135BC4 File Offset: 0x00133DC4
		public static string XsdType
		{
			get
			{
				return "gDay";
			}
		}

		// Token: 0x0600575A RID: 22362 RVA: 0x00135BCB File Offset: 0x00133DCB
		public string GetXsdType()
		{
			return SoapDay.XsdType;
		}

		// Token: 0x0600575B RID: 22363 RVA: 0x00135BD2 File Offset: 0x00133DD2
		public SoapDay()
		{
		}

		// Token: 0x0600575C RID: 22364 RVA: 0x00135BE5 File Offset: 0x00133DE5
		public SoapDay(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x17000E70 RID: 3696
		// (get) Token: 0x0600575D RID: 22365 RVA: 0x00135BFF File Offset: 0x00133DFF
		// (set) Token: 0x0600575E RID: 22366 RVA: 0x00135C07 File Offset: 0x00133E07
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

		// Token: 0x0600575F RID: 22367 RVA: 0x00135C10 File Offset: 0x00133E10
		public override string ToString()
		{
			return this._value.ToString("---dd", CultureInfo.InvariantCulture);
		}

		// Token: 0x06005760 RID: 22368 RVA: 0x00135C27 File Offset: 0x00133E27
		public static SoapDay Parse(string value)
		{
			return new SoapDay(DateTime.ParseExact(value, SoapDay.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x0400280C RID: 10252
		private DateTime _value = DateTime.MinValue;

		// Token: 0x0400280D RID: 10253
		private static string[] formats = new string[]
		{
			"---dd",
			"---ddzzz"
		};
	}
}
