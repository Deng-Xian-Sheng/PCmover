using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x02000210 RID: 528
	[DataContract]
	public class ServiceWorkerErrorMessage : DevToolsDomainEntityBase
	{
		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x000142AF File Offset: 0x000124AF
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x000142B7 File Offset: 0x000124B7
		[DataMember(Name = "errorMessage", IsRequired = true)]
		public string ErrorMessage { get; set; }

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000F2B RID: 3883 RVA: 0x000142C0 File Offset: 0x000124C0
		// (set) Token: 0x06000F2C RID: 3884 RVA: 0x000142C8 File Offset: 0x000124C8
		[DataMember(Name = "registrationId", IsRequired = true)]
		public string RegistrationId { get; set; }

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000F2D RID: 3885 RVA: 0x000142D1 File Offset: 0x000124D1
		// (set) Token: 0x06000F2E RID: 3886 RVA: 0x000142D9 File Offset: 0x000124D9
		[DataMember(Name = "versionId", IsRequired = true)]
		public string VersionId { get; set; }

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000F2F RID: 3887 RVA: 0x000142E2 File Offset: 0x000124E2
		// (set) Token: 0x06000F30 RID: 3888 RVA: 0x000142EA File Offset: 0x000124EA
		[DataMember(Name = "sourceURL", IsRequired = true)]
		public string SourceURL { get; set; }

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000F31 RID: 3889 RVA: 0x000142F3 File Offset: 0x000124F3
		// (set) Token: 0x06000F32 RID: 3890 RVA: 0x000142FB File Offset: 0x000124FB
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x00014304 File Offset: 0x00012504
		// (set) Token: 0x06000F34 RID: 3892 RVA: 0x0001430C File Offset: 0x0001250C
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }
	}
}
