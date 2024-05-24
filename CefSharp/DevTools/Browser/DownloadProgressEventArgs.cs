using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FA RID: 1018
	[DataContract]
	public class DownloadProgressEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x06001DB2 RID: 7602 RVA: 0x00021FF9 File Offset: 0x000201F9
		// (set) Token: 0x06001DB3 RID: 7603 RVA: 0x00022001 File Offset: 0x00020201
		[DataMember(Name = "guid", IsRequired = true)]
		public string Guid { get; private set; }

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x06001DB4 RID: 7604 RVA: 0x0002200A File Offset: 0x0002020A
		// (set) Token: 0x06001DB5 RID: 7605 RVA: 0x00022012 File Offset: 0x00020212
		[DataMember(Name = "totalBytes", IsRequired = true)]
		public double TotalBytes { get; private set; }

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x06001DB6 RID: 7606 RVA: 0x0002201B File Offset: 0x0002021B
		// (set) Token: 0x06001DB7 RID: 7607 RVA: 0x00022023 File Offset: 0x00020223
		[DataMember(Name = "receivedBytes", IsRequired = true)]
		public double ReceivedBytes { get; private set; }

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x06001DB8 RID: 7608 RVA: 0x0002202C File Offset: 0x0002022C
		// (set) Token: 0x06001DB9 RID: 7609 RVA: 0x00022048 File Offset: 0x00020248
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

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x06001DBA RID: 7610 RVA: 0x0002205B File Offset: 0x0002025B
		// (set) Token: 0x06001DBB RID: 7611 RVA: 0x00022063 File Offset: 0x00020263
		[DataMember(Name = "state", IsRequired = true)]
		internal string state { get; private set; }
	}
}
