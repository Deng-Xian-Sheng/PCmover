using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000250 RID: 592
	[DataContract]
	public class InstallabilityError : DevToolsDomainEntityBase
	{
		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x060010F9 RID: 4345 RVA: 0x000157F6 File Offset: 0x000139F6
		// (set) Token: 0x060010FA RID: 4346 RVA: 0x000157FE File Offset: 0x000139FE
		[DataMember(Name = "errorId", IsRequired = true)]
		public string ErrorId { get; set; }

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x060010FB RID: 4347 RVA: 0x00015807 File Offset: 0x00013A07
		// (set) Token: 0x060010FC RID: 4348 RVA: 0x0001580F File Offset: 0x00013A0F
		[DataMember(Name = "errorArguments", IsRequired = true)]
		public IList<InstallabilityErrorArgument> ErrorArguments { get; set; }
	}
}
