using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000219 RID: 537
	[DataContract]
	public class SafetyTipInfo : DevToolsDomainEntityBase
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000F78 RID: 3960 RVA: 0x000147CA File Offset: 0x000129CA
		// (set) Token: 0x06000F79 RID: 3961 RVA: 0x000147E6 File Offset: 0x000129E6
		public SafetyTipStatus SafetyTipStatus
		{
			get
			{
				return (SafetyTipStatus)DevToolsDomainEntityBase.StringToEnum(typeof(SafetyTipStatus), this.safetyTipStatus);
			}
			set
			{
				this.safetyTipStatus = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x000147F9 File Offset: 0x000129F9
		// (set) Token: 0x06000F7B RID: 3963 RVA: 0x00014801 File Offset: 0x00012A01
		[DataMember(Name = "safetyTipStatus", IsRequired = true)]
		internal string safetyTipStatus { get; set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0001480A File Offset: 0x00012A0A
		// (set) Token: 0x06000F7D RID: 3965 RVA: 0x00014812 File Offset: 0x00012A12
		[DataMember(Name = "safeUrl", IsRequired = false)]
		public string SafeUrl { get; set; }
	}
}
