using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C1 RID: 705
	[DataContract]
	public class Initiator : DevToolsDomainEntityBase
	{
		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001445 RID: 5189 RVA: 0x00018B15 File Offset: 0x00016D15
		// (set) Token: 0x06001446 RID: 5190 RVA: 0x00018B31 File Offset: 0x00016D31
		public InitiatorType Type
		{
			get
			{
				return (InitiatorType)DevToolsDomainEntityBase.StringToEnum(typeof(InitiatorType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x00018B44 File Offset: 0x00016D44
		// (set) Token: 0x06001448 RID: 5192 RVA: 0x00018B4C File Offset: 0x00016D4C
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x06001449 RID: 5193 RVA: 0x00018B55 File Offset: 0x00016D55
		// (set) Token: 0x0600144A RID: 5194 RVA: 0x00018B5D File Offset: 0x00016D5D
		[DataMember(Name = "stack", IsRequired = false)]
		public StackTrace Stack { get; set; }

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x00018B66 File Offset: 0x00016D66
		// (set) Token: 0x0600144C RID: 5196 RVA: 0x00018B6E File Offset: 0x00016D6E
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x0600144D RID: 5197 RVA: 0x00018B77 File Offset: 0x00016D77
		// (set) Token: 0x0600144E RID: 5198 RVA: 0x00018B7F File Offset: 0x00016D7F
		[DataMember(Name = "lineNumber", IsRequired = false)]
		public double? LineNumber { get; set; }

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x0600144F RID: 5199 RVA: 0x00018B88 File Offset: 0x00016D88
		// (set) Token: 0x06001450 RID: 5200 RVA: 0x00018B90 File Offset: 0x00016D90
		[DataMember(Name = "columnNumber", IsRequired = false)]
		public double? ColumnNumber { get; set; }

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06001451 RID: 5201 RVA: 0x00018B99 File Offset: 0x00016D99
		// (set) Token: 0x06001452 RID: 5202 RVA: 0x00018BA1 File Offset: 0x00016DA1
		[DataMember(Name = "requestId", IsRequired = false)]
		public string RequestId { get; set; }
	}
}
