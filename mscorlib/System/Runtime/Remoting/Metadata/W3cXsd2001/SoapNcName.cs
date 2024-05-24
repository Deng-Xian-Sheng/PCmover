using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007F8 RID: 2040
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapNcName : ISoapXsd
	{
		// Token: 0x17000E99 RID: 3737
		// (get) Token: 0x06005805 RID: 22533 RVA: 0x001368BC File Offset: 0x00134ABC
		public static string XsdType
		{
			get
			{
				return "NCName";
			}
		}

		// Token: 0x06005806 RID: 22534 RVA: 0x001368C3 File Offset: 0x00134AC3
		public string GetXsdType()
		{
			return SoapNcName.XsdType;
		}

		// Token: 0x06005807 RID: 22535 RVA: 0x001368CA File Offset: 0x00134ACA
		public SoapNcName()
		{
		}

		// Token: 0x06005808 RID: 22536 RVA: 0x001368D2 File Offset: 0x00134AD2
		public SoapNcName(string value)
		{
			this._value = value;
		}

		// Token: 0x17000E9A RID: 3738
		// (get) Token: 0x06005809 RID: 22537 RVA: 0x001368E1 File Offset: 0x00134AE1
		// (set) Token: 0x0600580A RID: 22538 RVA: 0x001368E9 File Offset: 0x00134AE9
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

		// Token: 0x0600580B RID: 22539 RVA: 0x001368F2 File Offset: 0x00134AF2
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x0600580C RID: 22540 RVA: 0x001368FF File Offset: 0x00134AFF
		public static SoapNcName Parse(string value)
		{
			return new SoapNcName(value);
		}

		// Token: 0x04002825 RID: 10277
		private string _value;
	}
}
