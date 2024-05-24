using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000242 RID: 578
	[DataContract]
	public class NavigationEntry : DevToolsDomainEntityBase
	{
		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x0600108E RID: 4238 RVA: 0x00015450 File Offset: 0x00013650
		// (set) Token: 0x0600108F RID: 4239 RVA: 0x00015458 File Offset: 0x00013658
		[DataMember(Name = "id", IsRequired = true)]
		public int Id { get; set; }

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001090 RID: 4240 RVA: 0x00015461 File Offset: 0x00013661
		// (set) Token: 0x06001091 RID: 4241 RVA: 0x00015469 File Offset: 0x00013669
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06001092 RID: 4242 RVA: 0x00015472 File Offset: 0x00013672
		// (set) Token: 0x06001093 RID: 4243 RVA: 0x0001547A File Offset: 0x0001367A
		[DataMember(Name = "userTypedURL", IsRequired = true)]
		public string UserTypedURL { get; set; }

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06001094 RID: 4244 RVA: 0x00015483 File Offset: 0x00013683
		// (set) Token: 0x06001095 RID: 4245 RVA: 0x0001548B File Offset: 0x0001368B
		[DataMember(Name = "title", IsRequired = true)]
		public string Title { get; set; }

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001096 RID: 4246 RVA: 0x00015494 File Offset: 0x00013694
		// (set) Token: 0x06001097 RID: 4247 RVA: 0x000154B0 File Offset: 0x000136B0
		public TransitionType TransitionType
		{
			get
			{
				return (TransitionType)DevToolsDomainEntityBase.StringToEnum(typeof(TransitionType), this.transitionType);
			}
			set
			{
				this.transitionType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001098 RID: 4248 RVA: 0x000154C3 File Offset: 0x000136C3
		// (set) Token: 0x06001099 RID: 4249 RVA: 0x000154CB File Offset: 0x000136CB
		[DataMember(Name = "transitionType", IsRequired = true)]
		internal string transitionType { get; set; }
	}
}
