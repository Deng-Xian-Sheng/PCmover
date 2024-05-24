using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200022F RID: 559
	[DataContract]
	public class AdFrameStatus : DevToolsDomainEntityBase
	{
		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06001014 RID: 4116 RVA: 0x00014F08 File Offset: 0x00013108
		// (set) Token: 0x06001015 RID: 4117 RVA: 0x00014F24 File Offset: 0x00013124
		public AdFrameType AdFrameType
		{
			get
			{
				return (AdFrameType)DevToolsDomainEntityBase.StringToEnum(typeof(AdFrameType), this.adFrameType);
			}
			set
			{
				this.adFrameType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06001016 RID: 4118 RVA: 0x00014F37 File Offset: 0x00013137
		// (set) Token: 0x06001017 RID: 4119 RVA: 0x00014F3F File Offset: 0x0001313F
		[DataMember(Name = "adFrameType", IsRequired = true)]
		internal string adFrameType { get; set; }

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06001018 RID: 4120 RVA: 0x00014F48 File Offset: 0x00013148
		// (set) Token: 0x06001019 RID: 4121 RVA: 0x00014F64 File Offset: 0x00013164
		public AdFrameExplanation[] Explanations
		{
			get
			{
				return (AdFrameExplanation[])DevToolsDomainEntityBase.StringToEnum(typeof(AdFrameExplanation[]), this.explanations);
			}
			set
			{
				this.explanations = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x0600101A RID: 4122 RVA: 0x00014F72 File Offset: 0x00013172
		// (set) Token: 0x0600101B RID: 4123 RVA: 0x00014F7A File Offset: 0x0001317A
		[DataMember(Name = "explanations", IsRequired = false)]
		internal string explanations { get; set; }
	}
}
