using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F2 RID: 2034
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapLanguage : ISoapXsd
	{
		// Token: 0x17000E8D RID: 3725
		// (get) Token: 0x060057D5 RID: 22485 RVA: 0x001366FA File Offset: 0x001348FA
		public static string XsdType
		{
			get
			{
				return "language";
			}
		}

		// Token: 0x060057D6 RID: 22486 RVA: 0x00136701 File Offset: 0x00134901
		public string GetXsdType()
		{
			return SoapLanguage.XsdType;
		}

		// Token: 0x060057D7 RID: 22487 RVA: 0x00136708 File Offset: 0x00134908
		public SoapLanguage()
		{
		}

		// Token: 0x060057D8 RID: 22488 RVA: 0x00136710 File Offset: 0x00134910
		public SoapLanguage(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E8E RID: 3726
		// (get) Token: 0x060057D9 RID: 22489 RVA: 0x0013671F File Offset: 0x0013491F
		// (set) Token: 0x060057DA RID: 22490 RVA: 0x00136727 File Offset: 0x00134927
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

		// Token: 0x060057DB RID: 22491 RVA: 0x00136730 File Offset: 0x00134930
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057DC RID: 22492 RVA: 0x0013673D File Offset: 0x0013493D
		public static SoapLanguage Parse(string value)
		{
			return new SoapLanguage(value);
		}

		// Token: 0x0400281F RID: 10271
		private string _value;
	}
}
