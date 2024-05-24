using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000236 RID: 566
	[DataContract]
	public class PermissionsPolicyFeatureState : DevToolsDomainEntityBase
	{
		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06001024 RID: 4132 RVA: 0x00014FE4 File Offset: 0x000131E4
		// (set) Token: 0x06001025 RID: 4133 RVA: 0x00015000 File Offset: 0x00013200
		public PermissionsPolicyFeature Feature
		{
			get
			{
				return (PermissionsPolicyFeature)DevToolsDomainEntityBase.StringToEnum(typeof(PermissionsPolicyFeature), this.feature);
			}
			set
			{
				this.feature = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06001026 RID: 4134 RVA: 0x00015013 File Offset: 0x00013213
		// (set) Token: 0x06001027 RID: 4135 RVA: 0x0001501B File Offset: 0x0001321B
		[DataMember(Name = "feature", IsRequired = true)]
		internal string feature { get; set; }

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06001028 RID: 4136 RVA: 0x00015024 File Offset: 0x00013224
		// (set) Token: 0x06001029 RID: 4137 RVA: 0x0001502C File Offset: 0x0001322C
		[DataMember(Name = "allowed", IsRequired = true)]
		public bool Allowed { get; set; }

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x0600102A RID: 4138 RVA: 0x00015035 File Offset: 0x00013235
		// (set) Token: 0x0600102B RID: 4139 RVA: 0x0001503D File Offset: 0x0001323D
		[DataMember(Name = "locator", IsRequired = false)]
		public PermissionsPolicyBlockLocator Locator { get; set; }
	}
}
