using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C3 RID: 963
	[DataContract]
	public class CSSStyleSheetHeader : DevToolsDomainEntityBase
	{
		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06001C09 RID: 7177 RVA: 0x00020BC7 File Offset: 0x0001EDC7
		// (set) Token: 0x06001C0A RID: 7178 RVA: 0x00020BCF File Offset: 0x0001EDCF
		[DataMember(Name = "styleSheetId", IsRequired = true)]
		public string StyleSheetId { get; set; }

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06001C0B RID: 7179 RVA: 0x00020BD8 File Offset: 0x0001EDD8
		// (set) Token: 0x06001C0C RID: 7180 RVA: 0x00020BE0 File Offset: 0x0001EDE0
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; set; }

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06001C0D RID: 7181 RVA: 0x00020BE9 File Offset: 0x0001EDE9
		// (set) Token: 0x06001C0E RID: 7182 RVA: 0x00020BF1 File Offset: 0x0001EDF1
		[DataMember(Name = "sourceURL", IsRequired = true)]
		public string SourceURL { get; set; }

		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06001C0F RID: 7183 RVA: 0x00020BFA File Offset: 0x0001EDFA
		// (set) Token: 0x06001C10 RID: 7184 RVA: 0x00020C02 File Offset: 0x0001EE02
		[DataMember(Name = "sourceMapURL", IsRequired = false)]
		public string SourceMapURL { get; set; }

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06001C11 RID: 7185 RVA: 0x00020C0B File Offset: 0x0001EE0B
		// (set) Token: 0x06001C12 RID: 7186 RVA: 0x00020C27 File Offset: 0x0001EE27
		public StyleSheetOrigin Origin
		{
			get
			{
				return (StyleSheetOrigin)DevToolsDomainEntityBase.StringToEnum(typeof(StyleSheetOrigin), this.origin);
			}
			set
			{
				this.origin = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06001C13 RID: 7187 RVA: 0x00020C3A File Offset: 0x0001EE3A
		// (set) Token: 0x06001C14 RID: 7188 RVA: 0x00020C42 File Offset: 0x0001EE42
		[DataMember(Name = "origin", IsRequired = true)]
		internal string origin { get; set; }

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06001C15 RID: 7189 RVA: 0x00020C4B File Offset: 0x0001EE4B
		// (set) Token: 0x06001C16 RID: 7190 RVA: 0x00020C53 File Offset: 0x0001EE53
		[DataMember(Name = "title", IsRequired = true)]
		public string Title { get; set; }

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x00020C5C File Offset: 0x0001EE5C
		// (set) Token: 0x06001C18 RID: 7192 RVA: 0x00020C64 File Offset: 0x0001EE64
		[DataMember(Name = "ownerNode", IsRequired = false)]
		public int? OwnerNode { get; set; }

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x06001C19 RID: 7193 RVA: 0x00020C6D File Offset: 0x0001EE6D
		// (set) Token: 0x06001C1A RID: 7194 RVA: 0x00020C75 File Offset: 0x0001EE75
		[DataMember(Name = "disabled", IsRequired = true)]
		public bool Disabled { get; set; }

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06001C1B RID: 7195 RVA: 0x00020C7E File Offset: 0x0001EE7E
		// (set) Token: 0x06001C1C RID: 7196 RVA: 0x00020C86 File Offset: 0x0001EE86
		[DataMember(Name = "hasSourceURL", IsRequired = false)]
		public bool? HasSourceURL { get; set; }

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06001C1D RID: 7197 RVA: 0x00020C8F File Offset: 0x0001EE8F
		// (set) Token: 0x06001C1E RID: 7198 RVA: 0x00020C97 File Offset: 0x0001EE97
		[DataMember(Name = "isInline", IsRequired = true)]
		public bool IsInline { get; set; }

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06001C1F RID: 7199 RVA: 0x00020CA0 File Offset: 0x0001EEA0
		// (set) Token: 0x06001C20 RID: 7200 RVA: 0x00020CA8 File Offset: 0x0001EEA8
		[DataMember(Name = "isMutable", IsRequired = true)]
		public bool IsMutable { get; set; }

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06001C21 RID: 7201 RVA: 0x00020CB1 File Offset: 0x0001EEB1
		// (set) Token: 0x06001C22 RID: 7202 RVA: 0x00020CB9 File Offset: 0x0001EEB9
		[DataMember(Name = "isConstructed", IsRequired = true)]
		public bool IsConstructed { get; set; }

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06001C23 RID: 7203 RVA: 0x00020CC2 File Offset: 0x0001EEC2
		// (set) Token: 0x06001C24 RID: 7204 RVA: 0x00020CCA File Offset: 0x0001EECA
		[DataMember(Name = "startLine", IsRequired = true)]
		public double StartLine { get; set; }

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06001C25 RID: 7205 RVA: 0x00020CD3 File Offset: 0x0001EED3
		// (set) Token: 0x06001C26 RID: 7206 RVA: 0x00020CDB File Offset: 0x0001EEDB
		[DataMember(Name = "startColumn", IsRequired = true)]
		public double StartColumn { get; set; }

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06001C27 RID: 7207 RVA: 0x00020CE4 File Offset: 0x0001EEE4
		// (set) Token: 0x06001C28 RID: 7208 RVA: 0x00020CEC File Offset: 0x0001EEEC
		[DataMember(Name = "length", IsRequired = true)]
		public double Length { get; set; }

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06001C29 RID: 7209 RVA: 0x00020CF5 File Offset: 0x0001EEF5
		// (set) Token: 0x06001C2A RID: 7210 RVA: 0x00020CFD File Offset: 0x0001EEFD
		[DataMember(Name = "endLine", IsRequired = true)]
		public double EndLine { get; set; }

		// Token: 0x17000A1F RID: 2591
		// (get) Token: 0x06001C2B RID: 7211 RVA: 0x00020D06 File Offset: 0x0001EF06
		// (set) Token: 0x06001C2C RID: 7212 RVA: 0x00020D0E File Offset: 0x0001EF0E
		[DataMember(Name = "endColumn", IsRequired = true)]
		public double EndColumn { get; set; }
	}
}
