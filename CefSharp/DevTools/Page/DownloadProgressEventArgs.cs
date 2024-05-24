using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000267 RID: 615
	[DataContract]
	public class DownloadProgressEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06001161 RID: 4449 RVA: 0x00015C52 File Offset: 0x00013E52
		// (set) Token: 0x06001162 RID: 4450 RVA: 0x00015C5A File Offset: 0x00013E5A
		[DataMember(Name = "guid", IsRequired = true)]
		public string Guid { get; private set; }

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001163 RID: 4451 RVA: 0x00015C63 File Offset: 0x00013E63
		// (set) Token: 0x06001164 RID: 4452 RVA: 0x00015C6B File Offset: 0x00013E6B
		[DataMember(Name = "totalBytes", IsRequired = true)]
		public double TotalBytes { get; private set; }

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001165 RID: 4453 RVA: 0x00015C74 File Offset: 0x00013E74
		// (set) Token: 0x06001166 RID: 4454 RVA: 0x00015C7C File Offset: 0x00013E7C
		[DataMember(Name = "receivedBytes", IsRequired = true)]
		public double ReceivedBytes { get; private set; }

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001167 RID: 4455 RVA: 0x00015C85 File Offset: 0x00013E85
		// (set) Token: 0x06001168 RID: 4456 RVA: 0x00015CA1 File Offset: 0x00013EA1
		public DownloadProgressState State
		{
			get
			{
				return (DownloadProgressState)DevToolsDomainEventArgsBase.StringToEnum(typeof(DownloadProgressState), this.state);
			}
			set
			{
				this.state = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001169 RID: 4457 RVA: 0x00015CB4 File Offset: 0x00013EB4
		// (set) Token: 0x0600116A RID: 4458 RVA: 0x00015CBC File Offset: 0x00013EBC
		[DataMember(Name = "state", IsRequired = true)]
		internal string state { get; private set; }
	}
}
