using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000198 RID: 408
	[DataContract]
	public class PlayerError : DevToolsDomainEntityBase
	{
		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x00011200 File Offset: 0x0000F400
		// (set) Token: 0x06000BE8 RID: 3048 RVA: 0x0001121C File Offset: 0x0000F41C
		public PlayerErrorType Type
		{
			get
			{
				return (PlayerErrorType)DevToolsDomainEntityBase.StringToEnum(typeof(PlayerErrorType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0001122F File Offset: 0x0000F42F
		// (set) Token: 0x06000BEA RID: 3050 RVA: 0x00011237 File Offset: 0x0000F437
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x00011240 File Offset: 0x0000F440
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x00011248 File Offset: 0x0000F448
		[DataMember(Name = "errorCode", IsRequired = true)]
		public string ErrorCode { get; set; }
	}
}
