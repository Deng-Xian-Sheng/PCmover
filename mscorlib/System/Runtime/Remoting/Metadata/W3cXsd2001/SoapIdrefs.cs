using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F4 RID: 2036
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapIdrefs : ISoapXsd
	{
		// Token: 0x17000E91 RID: 3729
		// (get) Token: 0x060057E5 RID: 22501 RVA: 0x00136790 File Offset: 0x00134990
		public static string XsdType
		{
			get
			{
				return "IDREFS";
			}
		}

		// Token: 0x060057E6 RID: 22502 RVA: 0x00136797 File Offset: 0x00134997
		public string GetXsdType()
		{
			return SoapIdrefs.XsdType;
		}

		// Token: 0x060057E7 RID: 22503 RVA: 0x0013679E File Offset: 0x0013499E
		public SoapIdrefs()
		{
		}

		// Token: 0x060057E8 RID: 22504 RVA: 0x001367A6 File Offset: 0x001349A6
		public SoapIdrefs(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E92 RID: 3730
		// (get) Token: 0x060057E9 RID: 22505 RVA: 0x001367B5 File Offset: 0x001349B5
		// (set) Token: 0x060057EA RID: 22506 RVA: 0x001367BD File Offset: 0x001349BD
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

		// Token: 0x060057EB RID: 22507 RVA: 0x001367C6 File Offset: 0x001349C6
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057EC RID: 22508 RVA: 0x001367D3 File Offset: 0x001349D3
		public static SoapIdrefs Parse(string value)
		{
			return new SoapIdrefs(value);
		}

		// Token: 0x04002821 RID: 10273
		private string _value;
	}
}
