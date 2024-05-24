using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000668 RID: 1640
	public class TimestampServer
	{
		// Token: 0x06003DE2 RID: 15842 RVA: 0x00216E1E File Offset: 0x00215E1E
		public TimestampServer(string tsUrl)
		{
			this.a = tsUrl;
			this.b = string.Empty;
			this.c = string.Empty;
			this.d = 0;
		}

		// Token: 0x06003DE3 RID: 15843 RVA: 0x00216E4D File Offset: 0x00215E4D
		public TimestampServer(string tsUrl, string userName, string password)
		{
			this.a = tsUrl;
			this.b = userName;
			this.c = password;
			this.d = 0;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06003DE4 RID: 15844 RVA: 0x00216E74 File Offset: 0x00215E74
		// (set) Token: 0x06003DE5 RID: 15845 RVA: 0x00216E8C File Offset: 0x00215E8C
		public string Url
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06003DE6 RID: 15846 RVA: 0x00216E98 File Offset: 0x00215E98
		// (set) Token: 0x06003DE7 RID: 15847 RVA: 0x00216EB0 File Offset: 0x00215EB0
		public string UserName
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06003DE8 RID: 15848 RVA: 0x00216EBC File Offset: 0x00215EBC
		// (set) Token: 0x06003DE9 RID: 15849 RVA: 0x00216ED4 File Offset: 0x00215ED4
		public string Password
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06003DEA RID: 15850 RVA: 0x00216EE0 File Offset: 0x00215EE0
		// (set) Token: 0x06003DEB RID: 15851 RVA: 0x00216EF8 File Offset: 0x00215EF8
		public int Timeout
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x0400216D RID: 8557
		private string a;

		// Token: 0x0400216E RID: 8558
		private string b;

		// Token: 0x0400216F RID: 8559
		private string c;

		// Token: 0x04002170 RID: 8560
		private int d;
	}
}
