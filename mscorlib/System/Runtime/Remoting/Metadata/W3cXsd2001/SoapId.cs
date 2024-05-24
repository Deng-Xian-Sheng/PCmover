using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F9 RID: 2041
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapId : ISoapXsd
	{
		// Token: 0x17000E9B RID: 3739
		// (get) Token: 0x0600580D RID: 22541 RVA: 0x00136907 File Offset: 0x00134B07
		public static string XsdType
		{
			get
			{
				return "ID";
			}
		}

		// Token: 0x0600580E RID: 22542 RVA: 0x0013690E File Offset: 0x00134B0E
		public string GetXsdType()
		{
			return SoapId.XsdType;
		}

		// Token: 0x0600580F RID: 22543 RVA: 0x00136915 File Offset: 0x00134B15
		public SoapId()
		{
		}

		// Token: 0x06005810 RID: 22544 RVA: 0x0013691D File Offset: 0x00134B1D
		public SoapId(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E9C RID: 3740
		// (get) Token: 0x06005811 RID: 22545 RVA: 0x0013692C File Offset: 0x00134B2C
		// (set) Token: 0x06005812 RID: 22546 RVA: 0x00136934 File Offset: 0x00134B34
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

		// Token: 0x06005813 RID: 22547 RVA: 0x0013693D File Offset: 0x00134B3D
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x06005814 RID: 22548 RVA: 0x0013694A File Offset: 0x00134B4A
		public static SoapId Parse(string value)
		{
			return new SoapId(value);
		}

		// Token: 0x04002826 RID: 10278
		private string _value;
	}
}
