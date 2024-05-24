using System;

namespace QRCoder.Exceptions
{
	// Token: 0x0200001D RID: 29
	public class DataTooLongException : Exception
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x00006CAE File Offset: 0x00004EAE
		public DataTooLongException(string eccLevel, string encodingMode, int maxSizeByte) : base(string.Format("The given payload exceeds the maximum size of the QR code standard. The maximum size allowed for the choosen paramters (ECC level={0}, EncodingMode={1}) is {2} byte.", eccLevel, encodingMode, maxSizeByte))
		{
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00006CC8 File Offset: 0x00004EC8
		public DataTooLongException(string eccLevel, string encodingMode, int version, int maxSizeByte) : base(string.Format("The given payload exceeds the maximum size of the QR code standard. The maximum size allowed for the choosen paramters (ECC level={0}, EncodingMode={1}, FixedVersion={2}) is {3} byte.", new object[]
		{
			eccLevel,
			encodingMode,
			version,
			maxSizeByte
		}))
		{
		}
	}
}
