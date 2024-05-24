using System;

namespace CefSharp
{
	// Token: 0x02000089 RID: 137
	public sealed class NavigationEntry
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00003950 File Offset: 0x00001B50
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x00003958 File Offset: 0x00001B58
		public DateTime CompletionTime { get; private set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x00003961 File Offset: 0x00001B61
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x00003969 File Offset: 0x00001B69
		public string DisplayUrl { get; private set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x00003972 File Offset: 0x00001B72
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0000397A File Offset: 0x00001B7A
		public int HttpStatusCode { get; private set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00003983 File Offset: 0x00001B83
		// (set) Token: 0x060003BC RID: 956 RVA: 0x0000398B File Offset: 0x00001B8B
		public string OriginalUrl { get; private set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060003BD RID: 957 RVA: 0x00003994 File Offset: 0x00001B94
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0000399C File Offset: 0x00001B9C
		public string Title { get; private set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060003BF RID: 959 RVA: 0x000039A5 File Offset: 0x00001BA5
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x000039AD File Offset: 0x00001BAD
		public TransitionType TransitionType { get; private set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x000039B6 File Offset: 0x00001BB6
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x000039BE File Offset: 0x00001BBE
		public string Url { get; private set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x000039C7 File Offset: 0x00001BC7
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x000039CF File Offset: 0x00001BCF
		public bool HasPostData { get; private set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x000039D8 File Offset: 0x00001BD8
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x000039E0 File Offset: 0x00001BE0
		public bool IsValid { get; private set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060003C7 RID: 967 RVA: 0x000039E9 File Offset: 0x00001BE9
		// (set) Token: 0x060003C8 RID: 968 RVA: 0x000039F1 File Offset: 0x00001BF1
		public bool IsCurrent { get; private set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x000039FA File Offset: 0x00001BFA
		// (set) Token: 0x060003CA RID: 970 RVA: 0x00003A02 File Offset: 0x00001C02
		public SslStatus SslStatus { get; private set; }

		// Token: 0x060003CB RID: 971 RVA: 0x00003A0C File Offset: 0x00001C0C
		public NavigationEntry(bool isCurrent, DateTime completionTime, string displayUrl, int httpStatusCode, string originalUrl, string title, TransitionType transitionType, string url, bool hasPostData, bool isValid, SslStatus sslStatus)
		{
			this.IsCurrent = isCurrent;
			this.CompletionTime = completionTime;
			this.DisplayUrl = displayUrl;
			this.HttpStatusCode = httpStatusCode;
			this.OriginalUrl = originalUrl;
			this.Title = title;
			this.TransitionType = transitionType;
			this.Url = url;
			this.HasPostData = hasPostData;
			this.IsValid = isValid;
			this.SslStatus = sslStatus;
		}
	}
}
