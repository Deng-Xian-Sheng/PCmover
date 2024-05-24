using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.ServiceWorker
{
	// Token: 0x0200020C RID: 524
	[DataContract]
	public class ServiceWorkerRegistration : DevToolsDomainEntityBase
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000F0B RID: 3851 RVA: 0x00014175 File Offset: 0x00012375
		// (set) Token: 0x06000F0C RID: 3852 RVA: 0x0001417D File Offset: 0x0001237D
		[DataMember(Name = "registrationId", IsRequired = true)]
		public string RegistrationId { get; set; }

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00014186 File Offset: 0x00012386
		// (set) Token: 0x06000F0E RID: 3854 RVA: 0x0001418E File Offset: 0x0001238E
		[DataMember(Name = "scopeURL", IsRequired = true)]
		public string ScopeURL { get; set; }

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000F0F RID: 3855 RVA: 0x00014197 File Offset: 0x00012397
		// (set) Token: 0x06000F10 RID: 3856 RVA: 0x0001419F File Offset: 0x0001239F
		[DataMember(Name = "isDeleted", IsRequired = true)]
		public bool IsDeleted { get; set; }
	}
}
