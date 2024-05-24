using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007EF RID: 2031
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNotation : ISoapXsd
	{
		// Token: 0x17000E87 RID: 3719
		// (get) Token: 0x060057BB RID: 22459 RVA: 0x001364CD File Offset: 0x001346CD
		public static string XsdType
		{
			get
			{
				return "NOTATION";
			}
		}

		// Token: 0x060057BC RID: 22460 RVA: 0x001364D4 File Offset: 0x001346D4
		public string GetXsdType()
		{
			return SoapNotation.XsdType;
		}

		// Token: 0x060057BD RID: 22461 RVA: 0x001364DB File Offset: 0x001346DB
		public SoapNotation()
		{
		}

		// Token: 0x060057BE RID: 22462 RVA: 0x001364E3 File Offset: 0x001346E3
		public SoapNotation(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E88 RID: 3720
		// (get) Token: 0x060057BF RID: 22463 RVA: 0x001364F2 File Offset: 0x001346F2
		// (set) Token: 0x060057C0 RID: 22464 RVA: 0x001364FA File Offset: 0x001346FA
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

		// Token: 0x060057C1 RID: 22465 RVA: 0x00136503 File Offset: 0x00134703
		public override string ToString()
		{
			return this._value;
		}

		// Token: 0x060057C2 RID: 22466 RVA: 0x0013650B File Offset: 0x0013470B
		public static SoapNotation Parse(string value)
		{
			return new SoapNotation(value);
		}

		// Token: 0x0400281C RID: 10268
		private string _value;
	}
}
