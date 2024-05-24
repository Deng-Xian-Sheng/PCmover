using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000444 RID: 1092
	[DataContract]
	public class AXProperty : DevToolsDomainEntityBase
	{
		// Token: 0x17000B9B RID: 2971
		// (get) Token: 0x06001FB1 RID: 8113 RVA: 0x00023B94 File Offset: 0x00021D94
		// (set) Token: 0x06001FB2 RID: 8114 RVA: 0x00023BB0 File Offset: 0x00021DB0
		public AXPropertyName Name
		{
			get
			{
				return (AXPropertyName)DevToolsDomainEntityBase.StringToEnum(typeof(AXPropertyName), this.name);
			}
			set
			{
				this.name = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B9C RID: 2972
		// (get) Token: 0x06001FB3 RID: 8115 RVA: 0x00023BC3 File Offset: 0x00021DC3
		// (set) Token: 0x06001FB4 RID: 8116 RVA: 0x00023BCB File Offset: 0x00021DCB
		[DataMember(Name = "name", IsRequired = true)]
		internal string name { get; set; }

		// Token: 0x17000B9D RID: 2973
		// (get) Token: 0x06001FB5 RID: 8117 RVA: 0x00023BD4 File Offset: 0x00021DD4
		// (set) Token: 0x06001FB6 RID: 8118 RVA: 0x00023BDC File Offset: 0x00021DDC
		[DataMember(Name = "value", IsRequired = true)]
		public AXValue Value { get; set; }
	}
}
