using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007FA RID: 2042
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapIdref : ISoapXsd
	{
		// Token: 0x17000E9D RID: 3741
		// (get) Token: 0x06005815 RID: 22549 RVA: 0x00136952 File Offset: 0x00134B52
		public static string XsdType
		{
			get
			{
				return "IDREF";
			}
		}

		// Token: 0x06005816 RID: 22550 RVA: 0x00136959 File Offset: 0x00134B59
		public string GetXsdType()
		{
			return SoapIdref.XsdType;
		}

		// Token: 0x06005817 RID: 22551 RVA: 0x00136960 File Offset: 0x00134B60
		public SoapIdref()
		{
		}

		// Token: 0x06005818 RID: 22552 RVA: 0x00136968 File Offset: 0x00134B68
		public SoapIdref(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E9E RID: 3742
		// (get) Token: 0x06005819 RID: 22553 RVA: 0x00136977 File Offset: 0x00134B77
		// (set) Token: 0x0600581A RID: 22554 RVA: 0x0013697F File Offset: 0x00134B7F
		public string Value
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

		// Token: 0x0600581B RID: 22555 RVA: 0x00136988 File Offset: 0x00134B88
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x0600581C RID: 22556 RVA: 0x00136995 File Offset: 0x00134B95
		public static SoapIdref Parse(string value)
		{
			return new SoapIdref(value);
		}

		// Token: 0x04002827 RID: 10279
		private string _value;
	}
}
