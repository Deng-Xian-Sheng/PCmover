using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F7 RID: 2039
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNmtokens : ISoapXsd
	{
		// Token: 0x17000E97 RID: 3735
		// (get) Token: 0x060057FD RID: 22525 RVA: 0x00136871 File Offset: 0x00134A71
		public static string XsdType
		{
			get
			{
				return "NMTOKENS";
			}
		}

		// Token: 0x060057FE RID: 22526 RVA: 0x00136878 File Offset: 0x00134A78
		public string GetXsdType()
		{
			return SoapNmtokens.XsdType;
		}

		// Token: 0x060057FF RID: 22527 RVA: 0x0013687F File Offset: 0x00134A7F
		public SoapNmtokens()
		{
		}

		// Token: 0x06005800 RID: 22528 RVA: 0x00136887 File Offset: 0x00134A87
		public SoapNmtokens(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E98 RID: 3736
		// (get) Token: 0x06005801 RID: 22529 RVA: 0x00136896 File Offset: 0x00134A96
		// (set) Token: 0x06005802 RID: 22530 RVA: 0x0013689E File Offset: 0x00134A9E
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

		// Token: 0x06005803 RID: 22531 RVA: 0x001368A7 File Offset: 0x00134AA7
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x06005804 RID: 22532 RVA: 0x001368B4 File Offset: 0x00134AB4
		public static SoapNmtokens Parse(string value)
		{
			return new SoapNmtokens(value);
		}

		// Token: 0x04002824 RID: 10276
		private string _value;
	}
}
