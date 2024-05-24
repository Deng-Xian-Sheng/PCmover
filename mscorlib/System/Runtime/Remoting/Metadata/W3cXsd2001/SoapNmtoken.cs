using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F6 RID: 2038
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNmtoken : ISoapXsd
	{
		// Token: 0x17000E95 RID: 3733
		// (get) Token: 0x060057F5 RID: 22517 RVA: 0x00136826 File Offset: 0x00134A26
		public static string XsdType
		{
			get
			{
				return "NMTOKEN";
			}
		}

		// Token: 0x060057F6 RID: 22518 RVA: 0x0013682D File Offset: 0x00134A2D
		public string GetXsdType()
		{
			return SoapNmtoken.XsdType;
		}

		// Token: 0x060057F7 RID: 22519 RVA: 0x00136834 File Offset: 0x00134A34
		public SoapNmtoken()
		{
		}

		// Token: 0x060057F8 RID: 22520 RVA: 0x0013683C File Offset: 0x00134A3C
		public SoapNmtoken(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E96 RID: 3734
		// (get) Token: 0x060057F9 RID: 22521 RVA: 0x0013684B File Offset: 0x00134A4B
		// (set) Token: 0x060057FA RID: 22522 RVA: 0x00136853 File Offset: 0x00134A53
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

		// Token: 0x060057FB RID: 22523 RVA: 0x0013685C File Offset: 0x00134A5C
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057FC RID: 22524 RVA: 0x00136869 File Offset: 0x00134A69
		public static SoapNmtoken Parse(string value)
		{
			return new SoapNmtoken(value);
		}

		// Token: 0x04002823 RID: 10275
		private string _value;
	}
}
