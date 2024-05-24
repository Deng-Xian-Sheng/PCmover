using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x020001FC RID: 508
	[DataContract]
	public class UsageForType : DevToolsDomainEntityBase
	{
		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00013A08 File Offset: 0x00011C08
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x00013A24 File Offset: 0x00011C24
		public StorageType StorageType
		{
			get
			{
				return (StorageType)DevToolsDomainEntityBase.StringToEnum(typeof(StorageType), this.storageType);
			}
			set
			{
				this.storageType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x00013A37 File Offset: 0x00011C37
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x00013A3F File Offset: 0x00011C3F
		[DataMember(Name = "storageType", IsRequired = true)]
		internal string storageType { get; set; }

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x00013A48 File Offset: 0x00011C48
		// (set) Token: 0x06000E93 RID: 3731 RVA: 0x00013A50 File Offset: 0x00011C50
		[DataMember(Name = "usage", IsRequired = true)]
		public double Usage { get; set; }
	}
}
