using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F8 RID: 504
	[DataContract]
	public class GetInfoResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x0001392C File Offset: 0x00011B2C
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x00013934 File Offset: 0x00011B34
		[DataMember]
		internal GPUInfo gpu { get; set; }

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x0001393D File Offset: 0x00011B3D
		public GPUInfo Gpu
		{
			get
			{
				return this.gpu;
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x00013945 File Offset: 0x00011B45
		// (set) Token: 0x06000E7E RID: 3710 RVA: 0x0001394D File Offset: 0x00011B4D
		[DataMember]
		internal string modelName { get; set; }

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00013956 File Offset: 0x00011B56
		public string ModelName
		{
			get
			{
				return this.modelName;
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0001395E File Offset: 0x00011B5E
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x00013966 File Offset: 0x00011B66
		[DataMember]
		internal string modelVersion { get; set; }

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0001396F File Offset: 0x00011B6F
		public string ModelVersion
		{
			get
			{
				return this.modelVersion;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x00013977 File Offset: 0x00011B77
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x0001397F File Offset: 0x00011B7F
		[DataMember]
		internal string commandLine { get; set; }

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x00013988 File Offset: 0x00011B88
		public string CommandLine
		{
			get
			{
				return this.commandLine;
			}
		}
	}
}
