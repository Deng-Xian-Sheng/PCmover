using System;

namespace CefSharp
{
	// Token: 0x02000049 RID: 73
	public class LoadErrorEventArgs : EventArgs
	{
		// Token: 0x06000108 RID: 264 RVA: 0x0000348B File Offset: 0x0000168B
		public LoadErrorEventArgs(IBrowser browser, IFrame frame, CefErrorCode errorCode, string errorText, string failedUrl)
		{
			this.Browser = browser;
			this.Frame = frame;
			this.ErrorCode = errorCode;
			this.ErrorText = errorText;
			this.FailedUrl = failedUrl;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000109 RID: 265 RVA: 0x000034B8 File Offset: 0x000016B8
		// (set) Token: 0x0600010A RID: 266 RVA: 0x000034C0 File Offset: 0x000016C0
		public IBrowser Browser { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000034C9 File Offset: 0x000016C9
		// (set) Token: 0x0600010C RID: 268 RVA: 0x000034D1 File Offset: 0x000016D1
		public IFrame Frame { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000034DA File Offset: 0x000016DA
		// (set) Token: 0x0600010E RID: 270 RVA: 0x000034E2 File Offset: 0x000016E2
		public string FailedUrl { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600010F RID: 271 RVA: 0x000034EB File Offset: 0x000016EB
		// (set) Token: 0x06000110 RID: 272 RVA: 0x000034F3 File Offset: 0x000016F3
		public CefErrorCode ErrorCode { get; private set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000111 RID: 273 RVA: 0x000034FC File Offset: 0x000016FC
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00003504 File Offset: 0x00001704
		public string ErrorText { get; private set; }
	}
}
