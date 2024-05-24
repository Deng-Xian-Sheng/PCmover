using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F3 RID: 2035
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapName : ISoapXsd
	{
		// Token: 0x17000E8F RID: 3727
		// (get) Token: 0x060057DD RID: 22493 RVA: 0x00136745 File Offset: 0x00134945
		public static string XsdType
		{
			get
			{
				return "Name";
			}
		}

		// Token: 0x060057DE RID: 22494 RVA: 0x0013674C File Offset: 0x0013494C
		public string GetXsdType()
		{
			return SoapName.XsdType;
		}

		// Token: 0x060057DF RID: 22495 RVA: 0x00136753 File Offset: 0x00134953
		public SoapName()
		{
		}

		// Token: 0x060057E0 RID: 22496 RVA: 0x0013675B File Offset: 0x0013495B
		public SoapName(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E90 RID: 3728
		// (get) Token: 0x060057E1 RID: 22497 RVA: 0x0013676A File Offset: 0x0013496A
		// (set) Token: 0x060057E2 RID: 22498 RVA: 0x00136772 File Offset: 0x00134972
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

		// Token: 0x060057E3 RID: 22499 RVA: 0x0013677B File Offset: 0x0013497B
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x060057E4 RID: 22500 RVA: 0x00136788 File Offset: 0x00134988
		public static SoapName Parse(string value)
		{
			return new SoapName(value);
		}

		// Token: 0x04002820 RID: 10272
		private string _value;
	}
}
