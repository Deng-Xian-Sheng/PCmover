using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.HeadlessExperimental
{
	// Token: 0x0200034B RID: 843
	[DataContract]
	public class ScreenshotParams : DevToolsDomainEntityBase
	{
		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06001876 RID: 6262 RVA: 0x0001CF30 File Offset: 0x0001B130
		// (set) Token: 0x06001877 RID: 6263 RVA: 0x0001CF4C File Offset: 0x0001B14C
		public ScreenshotParamsFormat? Format
		{
			get
			{
				return (ScreenshotParamsFormat?)DevToolsDomainEntityBase.StringToEnum(typeof(ScreenshotParamsFormat?), this.format);
			}
			set
			{
				this.format = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06001878 RID: 6264 RVA: 0x0001CF5F File Offset: 0x0001B15F
		// (set) Token: 0x06001879 RID: 6265 RVA: 0x0001CF67 File Offset: 0x0001B167
		[DataMember(Name = "format", IsRequired = false)]
		internal string format { get; set; }

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x0001CF70 File Offset: 0x0001B170
		// (set) Token: 0x0600187B RID: 6267 RVA: 0x0001CF78 File Offset: 0x0001B178
		[DataMember(Name = "quality", IsRequired = false)]
		public int? Quality { get; set; }
	}
}
