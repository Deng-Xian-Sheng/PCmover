using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D5 RID: 469
	[DataContract]
	public class TracingCompleteEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00012977 File Offset: 0x00010B77
		// (set) Token: 0x06000D89 RID: 3465 RVA: 0x0001297F File Offset: 0x00010B7F
		[DataMember(Name = "dataLossOccurred", IsRequired = true)]
		public bool DataLossOccurred { get; private set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x00012988 File Offset: 0x00010B88
		// (set) Token: 0x06000D8B RID: 3467 RVA: 0x00012990 File Offset: 0x00010B90
		[DataMember(Name = "stream", IsRequired = false)]
		public string Stream { get; private set; }

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00012999 File Offset: 0x00010B99
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x000129B5 File Offset: 0x00010BB5
		public StreamFormat? TraceFormat
		{
			get
			{
				return (StreamFormat?)DevToolsDomainEventArgsBase.StringToEnum(typeof(StreamFormat?), this.traceFormat);
			}
			set
			{
				this.traceFormat = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x000129C8 File Offset: 0x00010BC8
		// (set) Token: 0x06000D8F RID: 3471 RVA: 0x000129D0 File Offset: 0x00010BD0
		[DataMember(Name = "traceFormat", IsRequired = false)]
		internal string traceFormat { get; private set; }

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000D90 RID: 3472 RVA: 0x000129D9 File Offset: 0x00010BD9
		// (set) Token: 0x06000D91 RID: 3473 RVA: 0x000129F5 File Offset: 0x00010BF5
		public StreamCompression? StreamCompression
		{
			get
			{
				return (StreamCompression?)DevToolsDomainEventArgsBase.StringToEnum(typeof(StreamCompression?), this.streamCompression);
			}
			set
			{
				this.streamCompression = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000D92 RID: 3474 RVA: 0x00012A08 File Offset: 0x00010C08
		// (set) Token: 0x06000D93 RID: 3475 RVA: 0x00012A10 File Offset: 0x00010C10
		[DataMember(Name = "streamCompression", IsRequired = false)]
		internal string streamCompression { get; private set; }
	}
}
