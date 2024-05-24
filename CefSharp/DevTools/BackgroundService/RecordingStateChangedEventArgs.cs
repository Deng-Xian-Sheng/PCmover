using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000406 RID: 1030
	[DataContract]
	public class RecordingStateChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06001E10 RID: 7696 RVA: 0x0002274F File Offset: 0x0002094F
		// (set) Token: 0x06001E11 RID: 7697 RVA: 0x00022757 File Offset: 0x00020957
		[DataMember(Name = "isRecording", IsRequired = true)]
		public bool IsRecording { get; private set; }

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06001E12 RID: 7698 RVA: 0x00022760 File Offset: 0x00020960
		// (set) Token: 0x06001E13 RID: 7699 RVA: 0x0002277C File Offset: 0x0002097C
		public ServiceName Service
		{
			get
			{
				return (ServiceName)DevToolsDomainEventArgsBase.StringToEnum(typeof(ServiceName), this.service);
			}
			set
			{
				this.service = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06001E14 RID: 7700 RVA: 0x0002278F File Offset: 0x0002098F
		// (set) Token: 0x06001E15 RID: 7701 RVA: 0x00022797 File Offset: 0x00020997
		[DataMember(Name = "service", IsRequired = true)]
		internal string service { get; private set; }
	}
}
