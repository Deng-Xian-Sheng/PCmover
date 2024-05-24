using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B1 RID: 433
	[DataContract]
	public class AudioParam : DevToolsDomainEntityBase
	{
		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x06000C8A RID: 3210 RVA: 0x00011AF6 File Offset: 0x0000FCF6
		// (set) Token: 0x06000C8B RID: 3211 RVA: 0x00011AFE File Offset: 0x0000FCFE
		[DataMember(Name = "paramId", IsRequired = true)]
		public string ParamId { get; set; }

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x00011B07 File Offset: 0x0000FD07
		// (set) Token: 0x06000C8D RID: 3213 RVA: 0x00011B0F File Offset: 0x0000FD0F
		[DataMember(Name = "nodeId", IsRequired = true)]
		public string NodeId { get; set; }

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000C8E RID: 3214 RVA: 0x00011B18 File Offset: 0x0000FD18
		// (set) Token: 0x06000C8F RID: 3215 RVA: 0x00011B20 File Offset: 0x0000FD20
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; set; }

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x00011B29 File Offset: 0x0000FD29
		// (set) Token: 0x06000C91 RID: 3217 RVA: 0x00011B31 File Offset: 0x0000FD31
		[DataMember(Name = "paramType", IsRequired = true)]
		public string ParamType { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000C92 RID: 3218 RVA: 0x00011B3A File Offset: 0x0000FD3A
		// (set) Token: 0x06000C93 RID: 3219 RVA: 0x00011B56 File Offset: 0x0000FD56
		public AutomationRate Rate
		{
			get
			{
				return (AutomationRate)DevToolsDomainEntityBase.StringToEnum(typeof(AutomationRate), this.rate);
			}
			set
			{
				this.rate = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000C94 RID: 3220 RVA: 0x00011B69 File Offset: 0x0000FD69
		// (set) Token: 0x06000C95 RID: 3221 RVA: 0x00011B71 File Offset: 0x0000FD71
		[DataMember(Name = "rate", IsRequired = true)]
		internal string rate { get; set; }

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000C96 RID: 3222 RVA: 0x00011B7A File Offset: 0x0000FD7A
		// (set) Token: 0x06000C97 RID: 3223 RVA: 0x00011B82 File Offset: 0x0000FD82
		[DataMember(Name = "defaultValue", IsRequired = true)]
		public double DefaultValue { get; set; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000C98 RID: 3224 RVA: 0x00011B8B File Offset: 0x0000FD8B
		// (set) Token: 0x06000C99 RID: 3225 RVA: 0x00011B93 File Offset: 0x0000FD93
		[DataMember(Name = "minValue", IsRequired = true)]
		public double MinValue { get; set; }

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x00011B9C File Offset: 0x0000FD9C
		// (set) Token: 0x06000C9B RID: 3227 RVA: 0x00011BA4 File Offset: 0x0000FDA4
		[DataMember(Name = "maxValue", IsRequired = true)]
		public double MaxValue { get; set; }
	}
}
