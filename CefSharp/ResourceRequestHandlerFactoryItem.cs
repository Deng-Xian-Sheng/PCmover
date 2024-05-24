using System;

namespace CefSharp
{
	// Token: 0x02000091 RID: 145
	public class ResourceRequestHandlerFactoryItem
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x00006B70 File Offset: 0x00004D70
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x00006B78 File Offset: 0x00004D78
		public byte[] Data { get; private set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00006B81 File Offset: 0x00004D81
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x00006B89 File Offset: 0x00004D89
		public string MimeType { get; private set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x00006B92 File Offset: 0x00004D92
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x00006B9A File Offset: 0x00004D9A
		public bool OneTimeUse { get; private set; }

		// Token: 0x0600043B RID: 1083 RVA: 0x00006BA3 File Offset: 0x00004DA3
		public ResourceRequestHandlerFactoryItem(byte[] data, string mimeType, bool oneTimeUse)
		{
			this.Data = data;
			this.MimeType = mimeType;
			this.OneTimeUse = oneTimeUse;
		}
	}
}
