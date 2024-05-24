using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025F RID: 607
	[DataContract]
	public class FrameNavigatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x00015A3D File Offset: 0x00013C3D
		// (set) Token: 0x06001131 RID: 4401 RVA: 0x00015A45 File Offset: 0x00013C45
		[DataMember(Name = "frame", IsRequired = true)]
		public Frame Frame { get; private set; }

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06001132 RID: 4402 RVA: 0x00015A4E File Offset: 0x00013C4E
		// (set) Token: 0x06001133 RID: 4403 RVA: 0x00015A6A File Offset: 0x00013C6A
		public NavigationType Type
		{
			get
			{
				return (NavigationType)DevToolsDomainEventArgsBase.StringToEnum(typeof(NavigationType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06001134 RID: 4404 RVA: 0x00015A7D File Offset: 0x00013C7D
		// (set) Token: 0x06001135 RID: 4405 RVA: 0x00015A85 File Offset: 0x00013C85
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }
	}
}
