using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	// Token: 0x020007E6 RID: 2022
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapHexBinary : ISoapXsd
	{
		// Token: 0x17000E73 RID: 3699
		// (get) Token: 0x0600576B RID: 22379 RVA: 0x00135CF4 File Offset: 0x00133EF4
		public static string XsdType
		{
			get
			{
				return "hexBinary";
			}
		}

		// Token: 0x0600576C RID: 22380 RVA: 0x00135CFB File Offset: 0x00133EFB
		public string GetXsdType()
		{
			return SoapHexBinary.XsdType;
		}

		// Token: 0x0600576D RID: 22381 RVA: 0x00135D02 File Offset: 0x00133F02
		public SoapHexBinary()
		{
		}

		// Token: 0x0600576E RID: 22382 RVA: 0x00135D17 File Offset: 0x00133F17
		public SoapHexBinary(byte[] value)
		{
			this._value = value;
		}

		// Token: 0x17000E74 RID: 3700
		// (get) Token: 0x0600576F RID: 22383 RVA: 0x00135D33 File Offset: 0x00133F33
		// (set) Token: 0x06005770 RID: 22384 RVA: 0x00135D3B File Offset: 0x00133F3B
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

		// Token: 0x06005771 RID: 22385 RVA: 0x00135D44 File Offset: 0x00133F44
		public override string ToString()
		{
			this.sb.Length = 0;
			for (int i = 0; i < this._value.Length; i++)
			{
				string text = this._value[i].ToString("X", CultureInfo.InvariantCulture);
				if (text.Length == 1)
				{
					this.sb.Append('0');
				}
				this.sb.Append(text);
			}
			return this.sb.ToString();
		}

		// Token: 0x06005772 RID: 22386 RVA: 0x00135DBB File Offset: 0x00133FBB
		public static SoapHexBinary Parse(string value)
		{
			return new SoapHexBinary(SoapHexBinary.ToByteArray(SoapType.FilterBin64(value)));
		}

		// Token: 0x06005773 RID: 22387 RVA: 0x00135DD0 File Offset: 0x00133FD0
		private static byte[] ToByteArray(string value)
		{
			char[] array = value.ToCharArray();
			if (array.Length % 2 != 0)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid"), "xsd:hexBinary", value));
			}
			byte[] array2 = new byte[array.Length / 2];
			for (int i = 0; i < array.Length / 2; i++)
			{
				array2[i] = SoapHexBinary.ToByte(array[i * 2], value) * 16 + SoapHexBinary.ToByte(array[i * 2 + 1], value);
			}
			return array2;
		}

		// Token: 0x06005774 RID: 22388 RVA: 0x00135E48 File Offset: 0x00134048
		private static byte ToByte(char c, string value)
		{
			byte result = 0;
			string s = c.ToString();
			try
			{
				s = c.ToString();
				result = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SOAPInteropxsdInvalid", new object[]
				{
					"xsd:hexBinary",
					value
				}));
			}
			return result;
		}

		// Token: 0x04002810 RID: 10256
		private byte[] _value;

		// Token: 0x04002811 RID: 10257
		private StringBuilder sb = new StringBuilder(100);
	}
}
