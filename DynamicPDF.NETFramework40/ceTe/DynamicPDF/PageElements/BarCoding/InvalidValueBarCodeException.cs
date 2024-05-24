using System;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000764 RID: 1892
	public class InvalidValueBarCodeException : BarCodeException
	{
		// Token: 0x06004CE3 RID: 19683 RVA: 0x0026E20D File Offset: 0x0026D20D
		public InvalidValueBarCodeException(string message) : base(message)
		{
		}

		// Token: 0x06004CE4 RID: 19684 RVA: 0x0026E219 File Offset: 0x0026D219
		public InvalidValueBarCodeException() : base("Invalid barcode value.")
		{
		}
	}
}
