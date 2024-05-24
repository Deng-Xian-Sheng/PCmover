using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000269 RID: 617
	[DataContract]
	public class JavascriptDialogOpeningEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005EB RID: 1515
		// (get) Token: 0x06001171 RID: 4465 RVA: 0x00015CF7 File Offset: 0x00013EF7
		// (set) Token: 0x06001172 RID: 4466 RVA: 0x00015CFF File Offset: 0x00013EFF
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x06001173 RID: 4467 RVA: 0x00015D08 File Offset: 0x00013F08
		// (set) Token: 0x06001174 RID: 4468 RVA: 0x00015D10 File Offset: 0x00013F10
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; private set; }

		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x06001175 RID: 4469 RVA: 0x00015D19 File Offset: 0x00013F19
		// (set) Token: 0x06001176 RID: 4470 RVA: 0x00015D35 File Offset: 0x00013F35
		public DialogType Type
		{
			get
			{
				return (DialogType)DevToolsDomainEventArgsBase.StringToEnum(typeof(DialogType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001177 RID: 4471 RVA: 0x00015D48 File Offset: 0x00013F48
		// (set) Token: 0x06001178 RID: 4472 RVA: 0x00015D50 File Offset: 0x00013F50
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06001179 RID: 4473 RVA: 0x00015D59 File Offset: 0x00013F59
		// (set) Token: 0x0600117A RID: 4474 RVA: 0x00015D61 File Offset: 0x00013F61
		[DataMember(Name = "hasBrowserHandler", IsRequired = true)]
		public bool HasBrowserHandler { get; private set; }

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x0600117B RID: 4475 RVA: 0x00015D6A File Offset: 0x00013F6A
		// (set) Token: 0x0600117C RID: 4476 RVA: 0x00015D72 File Offset: 0x00013F72
		[DataMember(Name = "defaultPrompt", IsRequired = false)]
		public string DefaultPrompt { get; private set; }
	}
}
