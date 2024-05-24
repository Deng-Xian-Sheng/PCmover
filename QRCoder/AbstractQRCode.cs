using System;

namespace QRCoder
{
	// Token: 0x02000003 RID: 3
	public abstract class AbstractQRCode
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000216A File Offset: 0x0000036A
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002172 File Offset: 0x00000372
		protected QRCodeData QrCodeData { get; set; }

		// Token: 0x06000009 RID: 9 RVA: 0x0000217B File Offset: 0x0000037B
		protected AbstractQRCode()
		{
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002183 File Offset: 0x00000383
		protected AbstractQRCode(QRCodeData data)
		{
			this.QrCodeData = data;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002192 File Offset: 0x00000392
		public virtual void SetQRCodeData(QRCodeData data)
		{
			this.QrCodeData = data;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000219B File Offset: 0x0000039B
		public void Dispose()
		{
			QRCodeData qrCodeData = this.QrCodeData;
			if (qrCodeData != null)
			{
				qrCodeData.Dispose();
			}
			this.QrCodeData = null;
		}
	}
}
