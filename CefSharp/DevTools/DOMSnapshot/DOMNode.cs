using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;
using CefSharp.DevTools.DOMDebugger;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x0200036A RID: 874
	[DataContract]
	public class DOMNode : DevToolsDomainEntityBase
	{
		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x06001930 RID: 6448 RVA: 0x0001DF7D File Offset: 0x0001C17D
		// (set) Token: 0x06001931 RID: 6449 RVA: 0x0001DF85 File Offset: 0x0001C185
		[DataMember(Name = "nodeType", IsRequired = true)]
		public int NodeType { get; set; }

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x06001932 RID: 6450 RVA: 0x0001DF8E File Offset: 0x0001C18E
		// (set) Token: 0x06001933 RID: 6451 RVA: 0x0001DF96 File Offset: 0x0001C196
		[DataMember(Name = "nodeName", IsRequired = true)]
		public string NodeName { get; set; }

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x06001934 RID: 6452 RVA: 0x0001DF9F File Offset: 0x0001C19F
		// (set) Token: 0x06001935 RID: 6453 RVA: 0x0001DFA7 File Offset: 0x0001C1A7
		[DataMember(Name = "nodeValue", IsRequired = true)]
		public string NodeValue { get; set; }

		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x06001936 RID: 6454 RVA: 0x0001DFB0 File Offset: 0x0001C1B0
		// (set) Token: 0x06001937 RID: 6455 RVA: 0x0001DFB8 File Offset: 0x0001C1B8
		[DataMember(Name = "textValue", IsRequired = false)]
		public string TextValue { get; set; }

		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x06001938 RID: 6456 RVA: 0x0001DFC1 File Offset: 0x0001C1C1
		// (set) Token: 0x06001939 RID: 6457 RVA: 0x0001DFC9 File Offset: 0x0001C1C9
		[DataMember(Name = "inputValue", IsRequired = false)]
		public string InputValue { get; set; }

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x0600193A RID: 6458 RVA: 0x0001DFD2 File Offset: 0x0001C1D2
		// (set) Token: 0x0600193B RID: 6459 RVA: 0x0001DFDA File Offset: 0x0001C1DA
		[DataMember(Name = "inputChecked", IsRequired = false)]
		public bool? InputChecked { get; set; }

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x0001DFE3 File Offset: 0x0001C1E3
		// (set) Token: 0x0600193D RID: 6461 RVA: 0x0001DFEB File Offset: 0x0001C1EB
		[DataMember(Name = "optionSelected", IsRequired = false)]
		public bool? OptionSelected { get; set; }

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x0600193E RID: 6462 RVA: 0x0001DFF4 File Offset: 0x0001C1F4
		// (set) Token: 0x0600193F RID: 6463 RVA: 0x0001DFFC File Offset: 0x0001C1FC
		[DataMember(Name = "backendNodeId", IsRequired = true)]
		public int BackendNodeId { get; set; }

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x06001940 RID: 6464 RVA: 0x0001E005 File Offset: 0x0001C205
		// (set) Token: 0x06001941 RID: 6465 RVA: 0x0001E00D File Offset: 0x0001C20D
		[DataMember(Name = "childNodeIndexes", IsRequired = false)]
		public int[] ChildNodeIndexes { get; set; }

		// Token: 0x170008F4 RID: 2292
		// (get) Token: 0x06001942 RID: 6466 RVA: 0x0001E016 File Offset: 0x0001C216
		// (set) Token: 0x06001943 RID: 6467 RVA: 0x0001E01E File Offset: 0x0001C21E
		[DataMember(Name = "attributes", IsRequired = false)]
		public IList<NameValue> Attributes { get; set; }

		// Token: 0x170008F5 RID: 2293
		// (get) Token: 0x06001944 RID: 6468 RVA: 0x0001E027 File Offset: 0x0001C227
		// (set) Token: 0x06001945 RID: 6469 RVA: 0x0001E02F File Offset: 0x0001C22F
		[DataMember(Name = "pseudoElementIndexes", IsRequired = false)]
		public int[] PseudoElementIndexes { get; set; }

		// Token: 0x170008F6 RID: 2294
		// (get) Token: 0x06001946 RID: 6470 RVA: 0x0001E038 File Offset: 0x0001C238
		// (set) Token: 0x06001947 RID: 6471 RVA: 0x0001E040 File Offset: 0x0001C240
		[DataMember(Name = "layoutNodeIndex", IsRequired = false)]
		public int? LayoutNodeIndex { get; set; }

		// Token: 0x170008F7 RID: 2295
		// (get) Token: 0x06001948 RID: 6472 RVA: 0x0001E049 File Offset: 0x0001C249
		// (set) Token: 0x06001949 RID: 6473 RVA: 0x0001E051 File Offset: 0x0001C251
		[DataMember(Name = "documentURL", IsRequired = false)]
		public string DocumentURL { get; set; }

		// Token: 0x170008F8 RID: 2296
		// (get) Token: 0x0600194A RID: 6474 RVA: 0x0001E05A File Offset: 0x0001C25A
		// (set) Token: 0x0600194B RID: 6475 RVA: 0x0001E062 File Offset: 0x0001C262
		[DataMember(Name = "baseURL", IsRequired = false)]
		public string BaseURL { get; set; }

		// Token: 0x170008F9 RID: 2297
		// (get) Token: 0x0600194C RID: 6476 RVA: 0x0001E06B File Offset: 0x0001C26B
		// (set) Token: 0x0600194D RID: 6477 RVA: 0x0001E073 File Offset: 0x0001C273
		[DataMember(Name = "contentLanguage", IsRequired = false)]
		public string ContentLanguage { get; set; }

		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x0600194E RID: 6478 RVA: 0x0001E07C File Offset: 0x0001C27C
		// (set) Token: 0x0600194F RID: 6479 RVA: 0x0001E084 File Offset: 0x0001C284
		[DataMember(Name = "documentEncoding", IsRequired = false)]
		public string DocumentEncoding { get; set; }

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06001950 RID: 6480 RVA: 0x0001E08D File Offset: 0x0001C28D
		// (set) Token: 0x06001951 RID: 6481 RVA: 0x0001E095 File Offset: 0x0001C295
		[DataMember(Name = "publicId", IsRequired = false)]
		public string PublicId { get; set; }

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06001952 RID: 6482 RVA: 0x0001E09E File Offset: 0x0001C29E
		// (set) Token: 0x06001953 RID: 6483 RVA: 0x0001E0A6 File Offset: 0x0001C2A6
		[DataMember(Name = "systemId", IsRequired = false)]
		public string SystemId { get; set; }

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x06001954 RID: 6484 RVA: 0x0001E0AF File Offset: 0x0001C2AF
		// (set) Token: 0x06001955 RID: 6485 RVA: 0x0001E0B7 File Offset: 0x0001C2B7
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; set; }

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x06001956 RID: 6486 RVA: 0x0001E0C0 File Offset: 0x0001C2C0
		// (set) Token: 0x06001957 RID: 6487 RVA: 0x0001E0C8 File Offset: 0x0001C2C8
		[DataMember(Name = "contentDocumentIndex", IsRequired = false)]
		public int? ContentDocumentIndex { get; set; }

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06001958 RID: 6488 RVA: 0x0001E0D1 File Offset: 0x0001C2D1
		// (set) Token: 0x06001959 RID: 6489 RVA: 0x0001E0ED File Offset: 0x0001C2ED
		public PseudoType? PseudoType
		{
			get
			{
				return (PseudoType?)DevToolsDomainEntityBase.StringToEnum(typeof(PseudoType?), this.pseudoType);
			}
			set
			{
				this.pseudoType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x0600195A RID: 6490 RVA: 0x0001E100 File Offset: 0x0001C300
		// (set) Token: 0x0600195B RID: 6491 RVA: 0x0001E108 File Offset: 0x0001C308
		[DataMember(Name = "pseudoType", IsRequired = false)]
		internal string pseudoType { get; set; }

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x0600195C RID: 6492 RVA: 0x0001E111 File Offset: 0x0001C311
		// (set) Token: 0x0600195D RID: 6493 RVA: 0x0001E12D File Offset: 0x0001C32D
		public ShadowRootType? ShadowRootType
		{
			get
			{
				return (ShadowRootType?)DevToolsDomainEntityBase.StringToEnum(typeof(ShadowRootType?), this.shadowRootType);
			}
			set
			{
				this.shadowRootType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x0600195E RID: 6494 RVA: 0x0001E140 File Offset: 0x0001C340
		// (set) Token: 0x0600195F RID: 6495 RVA: 0x0001E148 File Offset: 0x0001C348
		[DataMember(Name = "shadowRootType", IsRequired = false)]
		internal string shadowRootType { get; set; }

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x0001E151 File Offset: 0x0001C351
		// (set) Token: 0x06001961 RID: 6497 RVA: 0x0001E159 File Offset: 0x0001C359
		[DataMember(Name = "isClickable", IsRequired = false)]
		public bool? IsClickable { get; set; }

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06001962 RID: 6498 RVA: 0x0001E162 File Offset: 0x0001C362
		// (set) Token: 0x06001963 RID: 6499 RVA: 0x0001E16A File Offset: 0x0001C36A
		[DataMember(Name = "eventListeners", IsRequired = false)]
		public IList<EventListener> EventListeners { get; set; }

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06001964 RID: 6500 RVA: 0x0001E173 File Offset: 0x0001C373
		// (set) Token: 0x06001965 RID: 6501 RVA: 0x0001E17B File Offset: 0x0001C37B
		[DataMember(Name = "currentSourceURL", IsRequired = false)]
		public string CurrentSourceURL { get; set; }

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06001966 RID: 6502 RVA: 0x0001E184 File Offset: 0x0001C384
		// (set) Token: 0x06001967 RID: 6503 RVA: 0x0001E18C File Offset: 0x0001C38C
		[DataMember(Name = "originURL", IsRequired = false)]
		public string OriginURL { get; set; }

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x06001968 RID: 6504 RVA: 0x0001E195 File Offset: 0x0001C395
		// (set) Token: 0x06001969 RID: 6505 RVA: 0x0001E19D File Offset: 0x0001C39D
		[DataMember(Name = "scrollOffsetX", IsRequired = false)]
		public double? ScrollOffsetX { get; set; }

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x0600196A RID: 6506 RVA: 0x0001E1A6 File Offset: 0x0001C3A6
		// (set) Token: 0x0600196B RID: 6507 RVA: 0x0001E1AE File Offset: 0x0001C3AE
		[DataMember(Name = "scrollOffsetY", IsRequired = false)]
		public double? ScrollOffsetY { get; set; }
	}
}
