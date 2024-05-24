using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000181 RID: 385
	[DataContract]
	public class PausedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x00010248 File Offset: 0x0000E448
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x00010250 File Offset: 0x0000E450
		[DataMember(Name = "callFrames", IsRequired = true)]
		public IList<CallFrame> CallFrames { get; private set; }

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000B0F RID: 2831 RVA: 0x00010259 File Offset: 0x0000E459
		// (set) Token: 0x06000B10 RID: 2832 RVA: 0x00010275 File Offset: 0x0000E475
		public PausedReason Reason
		{
			get
			{
				return (PausedReason)DevToolsDomainEventArgsBase.StringToEnum(typeof(PausedReason), this.reason);
			}
			set
			{
				this.reason = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000B11 RID: 2833 RVA: 0x00010288 File Offset: 0x0000E488
		// (set) Token: 0x06000B12 RID: 2834 RVA: 0x00010290 File Offset: 0x0000E490
		[DataMember(Name = "reason", IsRequired = true)]
		internal string reason { get; private set; }

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x00010299 File Offset: 0x0000E499
		// (set) Token: 0x06000B14 RID: 2836 RVA: 0x000102A1 File Offset: 0x0000E4A1
		[DataMember(Name = "data", IsRequired = false)]
		public object Data { get; private set; }

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x000102AA File Offset: 0x0000E4AA
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x000102B2 File Offset: 0x0000E4B2
		[DataMember(Name = "hitBreakpoints", IsRequired = false)]
		public string[] HitBreakpoints { get; private set; }

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x000102BB File Offset: 0x0000E4BB
		// (set) Token: 0x06000B18 RID: 2840 RVA: 0x000102C3 File Offset: 0x0000E4C3
		[DataMember(Name = "asyncStackTrace", IsRequired = false)]
		public StackTrace AsyncStackTrace { get; private set; }

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x000102CC File Offset: 0x0000E4CC
		// (set) Token: 0x06000B1A RID: 2842 RVA: 0x000102D4 File Offset: 0x0000E4D4
		[DataMember(Name = "asyncStackTraceId", IsRequired = false)]
		public StackTraceId AsyncStackTraceId { get; private set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x000102DD File Offset: 0x0000E4DD
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x000102E5 File Offset: 0x0000E4E5
		[DataMember(Name = "asyncCallStackTraceId", IsRequired = false)]
		public StackTraceId AsyncCallStackTraceId { get; private set; }
	}
}
