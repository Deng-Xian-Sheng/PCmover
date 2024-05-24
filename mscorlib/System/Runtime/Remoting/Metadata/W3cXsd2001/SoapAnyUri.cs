using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007ED RID: 2029
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapAnyUri : ISoapXsd
	{
		// Token: 0x17000E81 RID: 3713
		// (get) Token: 0x060057A5 RID: 22437 RVA: 0x00136381 File Offset: 0x00134581
		public static string XsdType
		{
			get
			{
				return "anyURI";
			}
		}

		// Token: 0x060057A6 RID: 22438 RVA: 0x00136388 File Offset: 0x00134588
		public string GetXsdType()
		{
			return SoapAnyUri.XsdType;
		}

		// Token: 0x060057A7 RID: 22439 RVA: 0x0013638F File Offset: 0x0013458F
		public SoapAnyUri()
		{
		}

		// Token: 0x060057A8 RID: 22440 RVA: 0x00136397 File Offset: 0x00134597
		public SoapAnyUri(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E82 RID: 3714
		// (get) Token: 0x060057A9 RID: 22441 RVA: 0x001363A6 File Offset: 0x001345A6
		// (set) Token: 0x060057AA RID: 22442 RVA: 0x001363AE File Offset: 0x001345AE
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

		// Token: 0x060057AB RID: 22443 RVA: 0x001363B7 File Offset: 0x001345B7
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060057AC RID: 22444 RVA: 0x001363BF File Offset: 0x001345BF
		public static SoapAnyUri Parse(string value)
		{
			return new SoapAnyUri(value);
		}

		// Token: 0x04002818 RID: 10264
		private string _value;
	}
}
