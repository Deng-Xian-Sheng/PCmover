using System;

namespace CefSharp
{
	// Token: 0x02000098 RID: 152
	public class UrlParts
	{
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00006DB5 File Offset: 0x00004FB5
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x00006DBD File Offset: 0x00004FBD
		public string Spec { get; set; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x00006DC6 File Offset: 0x00004FC6
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x00006DCE File Offset: 0x00004FCE
		public string Scheme { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600046F RID: 1135 RVA: 0x00006DD7 File Offset: 0x00004FD7
		// (set) Token: 0x06000470 RID: 1136 RVA: 0x00006DDF File Offset: 0x00004FDF
		public string Username { get; set; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x00006DE8 File Offset: 0x00004FE8
		// (set) Token: 0x06000472 RID: 1138 RVA: 0x00006DF0 File Offset: 0x00004FF0
		public string Password { get; set; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00006DF9 File Offset: 0x00004FF9
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x00006E01 File Offset: 0x00005001
		public string Host { get; set; }

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00006E0A File Offset: 0x0000500A
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x00006E12 File Offset: 0x00005012
		public int? Port { get; set; }

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00006E1B File Offset: 0x0000501B
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x00006E23 File Offset: 0x00005023
		public string Origin { get; set; }

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00006E2C File Offset: 0x0000502C
		// (set) Token: 0x0600047A RID: 1146 RVA: 0x00006E34 File Offset: 0x00005034
		public string Path { get; set; }

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00006E3D File Offset: 0x0000503D
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x00006E45 File Offset: 0x00005045
		public string Query { get; set; }

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00006E4E File Offset: 0x0000504E
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x00006E56 File Offset: 0x00005056
		public string Fragment { get; set; }
	}
}
