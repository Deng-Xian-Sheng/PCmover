using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BF RID: 703
	[DataContract]
	public class CachedResource : DevToolsDomainEntityBase
	{
		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x0600143A RID: 5178 RVA: 0x00018A9A File Offset: 0x00016C9A
		// (set) Token: 0x0600143B RID: 5179 RVA: 0x00018AA2 File Offset: 0x00016CA2
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x0600143C RID: 5180 RVA: 0x00018AAB File Offset: 0x00016CAB
		// (set) Token: 0x0600143D RID: 5181 RVA: 0x00018AC7 File Offset: 0x00016CC7
		public ResourceType Type
		{
			get
			{
				return (ResourceType)DevToolsDomainEntityBase.StringToEnum(typeof(ResourceType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x00018ADA File Offset: 0x00016CDA
		// (set) Token: 0x0600143F RID: 5183 RVA: 0x00018AE2 File Offset: 0x00016CE2
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001440 RID: 5184 RVA: 0x00018AEB File Offset: 0x00016CEB
		// (set) Token: 0x06001441 RID: 5185 RVA: 0x00018AF3 File Offset: 0x00016CF3
		[DataMember(Name = "response", IsRequired = false)]
		public Response Response { get; set; }

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001442 RID: 5186 RVA: 0x00018AFC File Offset: 0x00016CFC
		// (set) Token: 0x06001443 RID: 5187 RVA: 0x00018B04 File Offset: 0x00016D04
		[DataMember(Name = "bodySize", IsRequired = true)]
		public double BodySize { get; set; }
	}
}
