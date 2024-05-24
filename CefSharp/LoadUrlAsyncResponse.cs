using System;

namespace CefSharp
{
	// Token: 0x02000088 RID: 136
	public class LoadUrlAsyncResponse
	{
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000038FF File Offset: 0x00001AFF
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x00003907 File Offset: 0x00001B07
		public CefErrorCode ErrorCode { get; private set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x00003910 File Offset: 0x00001B10
		// (set) Token: 0x060003B2 RID: 946 RVA: 0x00003918 File Offset: 0x00001B18
		public int HttpStatusCode { get; private set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x00003921 File Offset: 0x00001B21
		public bool Success
		{
			get
			{
				return this.ErrorCode == CefErrorCode.None && this.HttpStatusCode == 200;
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000393A File Offset: 0x00001B3A
		public LoadUrlAsyncResponse(CefErrorCode errorCode, int httpStatusCode)
		{
			this.ErrorCode = errorCode;
			this.HttpStatusCode = httpStatusCode;
		}
	}
}
