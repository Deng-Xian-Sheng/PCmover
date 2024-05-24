using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007DF RID: 2015
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapTime : ISoapXsd
	{
		// Token: 0x17000E62 RID: 3682
		// (get) Token: 0x06005723 RID: 22307 RVA: 0x001355CC File Offset: 0x001337CC
		public static string XsdType
		{
			get
			{
				return "time";
			}
		}

		// Token: 0x06005724 RID: 22308 RVA: 0x001355D3 File Offset: 0x001337D3
		public string GetXsdType()
		{
			return SoapTime.XsdType;
		}

		// Token: 0x06005725 RID: 22309 RVA: 0x001355DA File Offset: 0x001337DA
		public SoapTime()
		{
		}

		// Token: 0x06005726 RID: 22310 RVA: 0x001355ED File Offset: 0x001337ED
		public SoapTime(DateTime value)
		{
			this._value = value;
		}

		// Token: 0x17000E63 RID: 3683
		// (get) Token: 0x06005727 RID: 22311 RVA: 0x00135607 File Offset: 0x00133807
		// (set) Token: 0x06005728 RID: 22312 RVA: 0x0013560F File Offset: 0x0013380F
		public DateTime Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = new DateTime(1, 1, 1, value.Hour, value.Minute, value.Second, value.Millisecond);
			}
		}

		// Token: 0x06005729 RID: 22313 RVA: 0x0013563B File Offset: 0x0013383B
		public override string ToString()
		{
			return this._value.ToString("HH:mm:ss.fffffffzzz", CultureInfo.InvariantCulture);
		}

		// Token: 0x0600572A RID: 22314 RVA: 0x00135654 File Offset: 0x00133854
		public static SoapTime Parse(string value)
		{
			string s = value;
			if (value.EndsWith("Z", StringComparison.Ordinal))
			{
				s = value.Substring(0, value.Length - 1) + "-00:00";
			}
			return new SoapTime(DateTime.ParseExact(s, SoapTime.formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
		}

		// Token: 0x040027FF RID: 10239
		private DateTime _value = DateTime.MinValue;

		// Token: 0x04002800 RID: 10240
		private static string[] formats = new string[]
		{
			"HH:mm:ss.fffffffzzz",
			"HH:mm:ss.ffff",
			"HH:mm:ss.ffffzzz",
			"HH:mm:ss.fff",
			"HH:mm:ss.fffzzz",
			"HH:mm:ss.ff",
			"HH:mm:ss.ffzzz",
			"HH:mm:ss.f",
			"HH:mm:ss.fzzz",
			"HH:mm:ss",
			"HH:mm:sszzz",
			"HH:mm:ss.fffff",
			"HH:mm:ss.fffffzzz",
			"HH:mm:ss.ffffff",
			"HH:mm:ss.ffffffzzz",
			"HH:mm:ss.fffffff",
			"HH:mm:ss.ffffffff",
			"HH:mm:ss.ffffffffzzz",
			"HH:mm:ss.fffffffff",
			"HH:mm:ss.fffffffffzzz",
			"HH:mm:ss.fffffffff",
			"HH:mm:ss.fffffffffzzz"
		};
	}
}
