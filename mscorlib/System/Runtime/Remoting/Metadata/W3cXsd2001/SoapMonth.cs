using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E5 RID: 2021
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapMonth : ISoapXsd
	{
		// Token: 0x17000E71 RID: 3697
		// (get) Token: 0x06005762 RID: 22370 RVA: 0x00135C5C File Offset: 0x00133E5C
		public static string XsdType
		{
			get
			{
				return "gMonth";
			}
		}

		// Token: 0x06005763 RID: 22371 RVA: 0x00135C63 File Offset: 0x00133E63
		public string GetXsdType()
		{
			return SoapMonth.XsdType;
		}

		// Token: 0x06005764 RID: 22372 RVA: 0x00135C6A File Offset: 0x00133E6A
		public SoapMonth()
		{
		}

		// Token: 0x06005765 RID: 22373 RVA: 0x00135C7D File Offset: 0x00133E7D
		public SoapMonth(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x17000E72 RID: 3698
		// (get) Token: 0x06005766 RID: 22374 RVA: 0x00135C97 File Offset: 0x00133E97
		// (set) Token: 0x06005767 RID: 22375 RVA: 0x00135C9F File Offset: 0x00133E9F
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

		// Token: 0x06005768 RID: 22376 RVA: 0x00135CA8 File Offset: 0x00133EA8
		public override string ToString()
		{
			return this._value.ToString("--MM--", CultureInfo.InvariantCulture);
		}

		// Token: 0x06005769 RID: 22377 RVA: 0x00135CBF File Offset: 0x00133EBF
		public static SoapMonth Parse(string value)
		{
			return new SoapMonth(DateTime.ParseExact(value, SoapMonth.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x0400280E RID: 10254
		private DateTime _value = DateTime.MinValue;

		// Token: 0x0400280F RID: 10255
		private static string[] formats = new string[]
		{
			"--MM--",
			"--MM--zzz"
		};
	}
}
