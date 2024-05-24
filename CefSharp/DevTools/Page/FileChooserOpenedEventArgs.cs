using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200025A RID: 602
	[DataContract]
	public class FileChooserOpenedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06001116 RID: 4374 RVA: 0x00015926 File Offset: 0x00013B26
		// (set) Token: 0x06001117 RID: 4375 RVA: 0x0001592E File Offset: 0x00013B2E
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06001118 RID: 4376 RVA: 0x00015937 File Offset: 0x00013B37
		// (set) Token: 0x06001119 RID: 4377 RVA: 0x0001593F File Offset: 0x00013B3F
		[DataMember(Name = "backendNodeId", IsRequired = true)]
		public int BackendNodeId { get; private set; }

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x0600111A RID: 4378 RVA: 0x00015948 File Offset: 0x00013B48
		// (set) Token: 0x0600111B RID: 4379 RVA: 0x00015964 File Offset: 0x00013B64
		public FileChooserOpenedMode Mode
		{
			get
			{
				return (FileChooserOpenedMode)DevToolsDomainEventArgsBase.StringToEnum(typeof(FileChooserOpenedMode), this.mode);
			}
			set
			{
				this.mode = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x0600111C RID: 4380 RVA: 0x00015977 File Offset: 0x00013B77
		// (set) Token: 0x0600111D RID: 4381 RVA: 0x0001597F File Offset: 0x00013B7F
		[DataMember(Name = "mode", IsRequired = true)]
		internal string mode { get; private set; }
	}
}
