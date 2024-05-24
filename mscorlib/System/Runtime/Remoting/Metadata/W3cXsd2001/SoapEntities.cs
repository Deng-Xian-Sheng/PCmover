using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F5 RID: 2037
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapEntities : ISoapXsd
	{
		// Token: 0x17000E93 RID: 3731
		// (get) Token: 0x060057ED RID: 22509 RVA: 0x001367DB File Offset: 0x001349DB
		public static string XsdType
		{
			get
			{
				return "ENTITIES";
			}
		}

		// Token: 0x060057EE RID: 22510 RVA: 0x001367E2 File Offset: 0x001349E2
		public string GetXsdType()
		{
			return SoapEntities.XsdType;
		}

		// Token: 0x060057EF RID: 22511 RVA: 0x001367E9 File Offset: 0x001349E9
		public SoapEntities()
		{
		}

		// Token: 0x060057F0 RID: 22512 RVA: 0x001367F1 File Offset: 0x001349F1
		public SoapEntities(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E94 RID: 3732
		// (get) Token: 0x060057F1 RID: 22513 RVA: 0x00136800 File Offset: 0x00134A00
		// (set) Token: 0x060057F2 RID: 22514 RVA: 0x00136808 File Offset: 0x00134A08
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

		// Token: 0x060057F3 RID: 22515 RVA: 0x00136811 File Offset: 0x00134A11
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057F4 RID: 22516 RVA: 0x0013681E File Offset: 0x00134A1E
		public static SoapEntities Parse(string value)
		{
			return new SoapEntities(value);
		}

		// Token: 0x04002822 RID: 10274
		private string _value;
	}
}
