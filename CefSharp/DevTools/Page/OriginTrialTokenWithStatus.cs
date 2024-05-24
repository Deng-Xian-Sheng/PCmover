using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023B RID: 571
	[DataContract]
	public class OriginTrialTokenWithStatus : DevToolsDomainEntityBase
	{
		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x0600103C RID: 4156 RVA: 0x000150EB File Offset: 0x000132EB
		// (set) Token: 0x0600103D RID: 4157 RVA: 0x000150F3 File Offset: 0x000132F3
		[DataMember(Name = "rawTokenText", IsRequired = true)]
		public string RawTokenText { get; set; }

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x0600103E RID: 4158 RVA: 0x000150FC File Offset: 0x000132FC
		// (set) Token: 0x0600103F RID: 4159 RVA: 0x00015104 File Offset: 0x00013304
		[DataMember(Name = "parsedToken", IsRequired = false)]
		public OriginTrialToken ParsedToken { get; set; }

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06001040 RID: 4160 RVA: 0x0001510D File Offset: 0x0001330D
		// (set) Token: 0x06001041 RID: 4161 RVA: 0x00015129 File Offset: 0x00013329
		public OriginTrialTokenStatus Status
		{
			get
			{
				return (OriginTrialTokenStatus)DevToolsDomainEntityBase.StringToEnum(typeof(OriginTrialTokenStatus), this.status);
			}
			set
			{
				this.status = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06001042 RID: 4162 RVA: 0x0001513C File Offset: 0x0001333C
		// (set) Token: 0x06001043 RID: 4163 RVA: 0x00015144 File Offset: 0x00013344
		[DataMember(Name = "status", IsRequired = true)]
		internal string status { get; set; }
	}
}
