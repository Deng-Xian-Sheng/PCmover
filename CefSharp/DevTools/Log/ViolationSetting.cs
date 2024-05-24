using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Log
{
	// Token: 0x0200031C RID: 796
	[DataContract]
	public class ViolationSetting : DevToolsDomainEntityBase
	{
		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x06001757 RID: 5975 RVA: 0x0001B5D8 File Offset: 0x000197D8
		// (set) Token: 0x06001758 RID: 5976 RVA: 0x0001B5F4 File Offset: 0x000197F4
		public ViolationSettingName Name
		{
			get
			{
				return (ViolationSettingName)DevToolsDomainEntityBase.StringToEnum(typeof(ViolationSettingName), this.name);
			}
			set
			{
				this.name = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06001759 RID: 5977 RVA: 0x0001B607 File Offset: 0x00019807
		// (set) Token: 0x0600175A RID: 5978 RVA: 0x0001B60F File Offset: 0x0001980F
		[DataMember(Name = "name", IsRequired = true)]
		internal string name { get; set; }

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x0600175B RID: 5979 RVA: 0x0001B618 File Offset: 0x00019818
		// (set) Token: 0x0600175C RID: 5980 RVA: 0x0001B620 File Offset: 0x00019820
		[DataMember(Name = "threshold", IsRequired = true)]
		public double Threshold { get; set; }
	}
}
