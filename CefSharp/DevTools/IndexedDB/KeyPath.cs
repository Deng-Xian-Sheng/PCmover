using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000344 RID: 836
	[DataContract]
	public class KeyPath : DevToolsDomainEntityBase
	{
		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x0600184D RID: 6221 RVA: 0x0001CB9D File Offset: 0x0001AD9D
		// (set) Token: 0x0600184E RID: 6222 RVA: 0x0001CBB9 File Offset: 0x0001ADB9
		public KeyPathType Type
		{
			get
			{
				return (KeyPathType)DevToolsDomainEntityBase.StringToEnum(typeof(KeyPathType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x0600184F RID: 6223 RVA: 0x0001CBCC File Offset: 0x0001ADCC
		// (set) Token: 0x06001850 RID: 6224 RVA: 0x0001CBD4 File Offset: 0x0001ADD4
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x06001851 RID: 6225 RVA: 0x0001CBDD File Offset: 0x0001ADDD
		// (set) Token: 0x06001852 RID: 6226 RVA: 0x0001CBE5 File Offset: 0x0001ADE5
		[DataMember(Name = "string", IsRequired = false)]
		public string String { get; set; }

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x06001853 RID: 6227 RVA: 0x0001CBEE File Offset: 0x0001ADEE
		// (set) Token: 0x06001854 RID: 6228 RVA: 0x0001CBF6 File Offset: 0x0001ADF6
		[DataMember(Name = "array", IsRequired = false)]
		public string[] Array { get; set; }
	}
}
