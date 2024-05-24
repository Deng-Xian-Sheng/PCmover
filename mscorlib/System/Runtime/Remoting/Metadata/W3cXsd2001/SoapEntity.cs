using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007FB RID: 2043
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapEntity : ISoapXsd
	{
		// Token: 0x17000E9F RID: 3743
		// (get) Token: 0x0600581D RID: 22557 RVA: 0x0013699D File Offset: 0x00134B9D
		public static string XsdType
		{
			get
			{
				return "ENTITY";
			}
		}

		// Token: 0x0600581E RID: 22558 RVA: 0x001369A4 File Offset: 0x00134BA4
		public string GetXsdType()
		{
			return SoapEntity.XsdType;
		}

		// Token: 0x0600581F RID: 22559 RVA: 0x001369AB File Offset: 0x00134BAB
		public SoapEntity()
		{
		}

		// Token: 0x06005820 RID: 22560 RVA: 0x001369B3 File Offset: 0x00134BB3
		public SoapEntity(string value)
		{
			this._value = value;
		}

		// Token: 0x17000EA0 RID: 3744
		// (get) Token: 0x06005821 RID: 22561 RVA: 0x001369C2 File Offset: 0x00134BC2
		// (set) Token: 0x06005822 RID: 22562 RVA: 0x001369CA File Offset: 0x00134BCA
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

		// Token: 0x06005823 RID: 22563 RVA: 0x001369D3 File Offset: 0x00134BD3
		public override string ToString()
		{
			return SoapType.Escape(this._value);
		}

		// Token: 0x06005824 RID: 22564 RVA: 0x001369E0 File Offset: 0x00134BE0
		public static SoapEntity Parse(string value)
		{
			return new SoapEntity(value);
		}

		// Token: 0x04002828 RID: 10280
		private string _value;
	}
}
