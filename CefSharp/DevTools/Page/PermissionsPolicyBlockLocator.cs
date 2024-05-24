using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000235 RID: 565
	[DataContract]
	public class PermissionsPolicyBlockLocator : DevToolsDomainEntityBase
	{
		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x0600101D RID: 4125 RVA: 0x00014F8B File Offset: 0x0001318B
		// (set) Token: 0x0600101E RID: 4126 RVA: 0x00014F93 File Offset: 0x00013193
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; set; }

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x00014F9C File Offset: 0x0001319C
		// (set) Token: 0x06001020 RID: 4128 RVA: 0x00014FB8 File Offset: 0x000131B8
		public PermissionsPolicyBlockReason BlockReason
		{
			get
			{
				return (PermissionsPolicyBlockReason)DevToolsDomainEntityBase.StringToEnum(typeof(PermissionsPolicyBlockReason), this.blockReason);
			}
			set
			{
				this.blockReason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x00014FCB File Offset: 0x000131CB
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x00014FD3 File Offset: 0x000131D3
		[DataMember(Name = "blockReason", IsRequired = true)]
		internal string blockReason { get; set; }
	}
}
