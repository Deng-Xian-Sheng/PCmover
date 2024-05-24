using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000277 RID: 631
	[DataContract]
	public class GetInstallabilityErrorsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060011CD RID: 4557 RVA: 0x0001601E File Offset: 0x0001421E
		// (set) Token: 0x060011CE RID: 4558 RVA: 0x00016026 File Offset: 0x00014226
		[DataMember]
		internal IList<InstallabilityError> installabilityErrors { get; set; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x060011CF RID: 4559 RVA: 0x0001602F File Offset: 0x0001422F
		public IList<InstallabilityError> InstallabilityErrors
		{
			get
			{
				return this.installabilityErrors;
			}
		}
	}
}
