using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E7 RID: 2023
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapBase64Binary : ISoapXsd
	{
		// Token: 0x17000E75 RID: 3701
		// (get) Token: 0x06005775 RID: 22389 RVA: 0x00135EB0 File Offset: 0x001340B0
		public static string XsdType
		{
			get
			{
				return "base64Binary";
			}
		}

		// Token: 0x06005776 RID: 22390 RVA: 0x00135EB7 File Offset: 0x001340B7
		public string GetXsdType()
		{
			return SoapBase64Binary.XsdType;
		}

		// Token: 0x06005777 RID: 22391 RVA: 0x00135EBE File Offset: 0x001340BE
		public SoapBase64Binary()
		{
		}

		// Token: 0x06005778 RID: 22392 RVA: 0x00135EC6 File Offset: 0x001340C6
		public SoapBase64Binary(byte[] value)
		{
			this._value = value;
		}

		// Token: 0x17000E76 RID: 3702
		// (get) Token: 0x06005779 RID: 22393 RVA: 0x00135ED5 File Offset: 0x001340D5
		// (set) Token: 0x0600577A RID: 22394 RVA: 0x00135EDD File Offset: 0x001340DD
		public byte[] Value
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

		// Token: 0x0600577B RID: 22395 RVA: 0x00135EE6 File Offset: 0x001340E6
		public override string ToString()
		{
			if (this._value == null)
			{
				return null;
			}
			return SoapType.LineFeedsBin64(Convert.ToBase64String(this._value));
		}

		// Token: 0x0600577C RID: 22396 RVA: 0x00135F04 File Offset: 0x00134104
		public static SoapBase64Binary Parse(string value)
		{
			if (value == null || value.Length == 0)
			{
				return new SoapBase64Binary(new byte[0]);
			}
			byte[] value2;
			try
			{
				value2 = Convert.FromBase64String(SoapType.FilterBin64(value));
			}
			catch (Exception)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "base64Binary", value));
			}
			return new SoapBase64Binary(value2);
		}

		// Token: 0x04002812 RID: 10258
		private byte[] _value;
	}
}
