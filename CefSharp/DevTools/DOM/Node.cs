using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000381 RID: 897
	[DataContract]
	public class Node : DevToolsDomainEntityBase
	{
		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x06001A2E RID: 6702 RVA: 0x0001EB37 File Offset: 0x0001CD37
		// (set) Token: 0x06001A2F RID: 6703 RVA: 0x0001EB3F File Offset: 0x0001CD3F
		[DataMember(Name = "nodeId", IsRequired = true)]
		public int NodeId { get; set; }

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x06001A30 RID: 6704 RVA: 0x0001EB48 File Offset: 0x0001CD48
		// (set) Token: 0x06001A31 RID: 6705 RVA: 0x0001EB50 File Offset: 0x0001CD50
		[DataMember(Name = "parentId", IsRequired = false)]
		public int? ParentId { get; set; }

		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x06001A32 RID: 6706 RVA: 0x0001EB59 File Offset: 0x0001CD59
		// (set) Token: 0x06001A33 RID: 6707 RVA: 0x0001EB61 File Offset: 0x0001CD61
		[DataMember(Name = "backendNodeId", IsRequired = true)]
		public int BackendNodeId { get; set; }

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x06001A34 RID: 6708 RVA: 0x0001EB6A File Offset: 0x0001CD6A
		// (set) Token: 0x06001A35 RID: 6709 RVA: 0x0001EB72 File Offset: 0x0001CD72
		[DataMember(Name = "nodeType", IsRequired = true)]
		public int NodeType { get; set; }

		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x06001A36 RID: 6710 RVA: 0x0001EB7B File Offset: 0x0001CD7B
		// (set) Token: 0x06001A37 RID: 6711 RVA: 0x0001EB83 File Offset: 0x0001CD83
		[DataMember(Name = "nodeName", IsRequired = true)]
		public string NodeName { get; set; }

		// Token: 0x17000961 RID: 2401
		// (get) Token: 0x06001A38 RID: 6712 RVA: 0x0001EB8C File Offset: 0x0001CD8C
		// (set) Token: 0x06001A39 RID: 6713 RVA: 0x0001EB94 File Offset: 0x0001CD94
		[DataMember(Name = "localName", IsRequired = true)]
		public string LocalName { get; set; }

		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06001A3A RID: 6714 RVA: 0x0001EB9D File Offset: 0x0001CD9D
		// (set) Token: 0x06001A3B RID: 6715 RVA: 0x0001EBA5 File Offset: 0x0001CDA5
		[DataMember(Name = "nodeValue", IsRequired = true)]
		public string NodeValue { get; set; }

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x06001A3C RID: 6716 RVA: 0x0001EBAE File Offset: 0x0001CDAE
		// (set) Token: 0x06001A3D RID: 6717 RVA: 0x0001EBB6 File Offset: 0x0001CDB6
		[DataMember(Name = "childNodeCount", IsRequired = false)]
		public int? ChildNodeCount { get; set; }

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x06001A3E RID: 6718 RVA: 0x0001EBBF File Offset: 0x0001CDBF
		// (set) Token: 0x06001A3F RID: 6719 RVA: 0x0001EBC7 File Offset: 0x0001CDC7
		[DataMember(Name = "children", IsRequired = false)]
		public IList<Node> Children { get; set; }

		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x06001A40 RID: 6720 RVA: 0x0001EBD0 File Offset: 0x0001CDD0
		// (set) Token: 0x06001A41 RID: 6721 RVA: 0x0001EBD8 File Offset: 0x0001CDD8
		[DataMember(Name = "attributes", IsRequired = false)]
		public string[] Attributes { get; set; }

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x06001A42 RID: 6722 RVA: 0x0001EBE1 File Offset: 0x0001CDE1
		// (set) Token: 0x06001A43 RID: 6723 RVA: 0x0001EBE9 File Offset: 0x0001CDE9
		[DataMember(Name = "documentURL", IsRequired = false)]
		public string DocumentURL { get; set; }

		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06001A44 RID: 6724 RVA: 0x0001EBF2 File Offset: 0x0001CDF2
		// (set) Token: 0x06001A45 RID: 6725 RVA: 0x0001EBFA File Offset: 0x0001CDFA
		[DataMember(Name = "baseURL", IsRequired = false)]
		public string BaseURL { get; set; }

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06001A46 RID: 6726 RVA: 0x0001EC03 File Offset: 0x0001CE03
		// (set) Token: 0x06001A47 RID: 6727 RVA: 0x0001EC0B File Offset: 0x0001CE0B
		[DataMember(Name = "publicId", IsRequired = false)]
		public string PublicId { get; set; }

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06001A48 RID: 6728 RVA: 0x0001EC14 File Offset: 0x0001CE14
		// (set) Token: 0x06001A49 RID: 6729 RVA: 0x0001EC1C File Offset: 0x0001CE1C
		[DataMember(Name = "systemId", IsRequired = false)]
		public string SystemId { get; set; }

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06001A4A RID: 6730 RVA: 0x0001EC25 File Offset: 0x0001CE25
		// (set) Token: 0x06001A4B RID: 6731 RVA: 0x0001EC2D File Offset: 0x0001CE2D
		[DataMember(Name = "internalSubset", IsRequired = false)]
		public string InternalSubset { get; set; }

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x06001A4C RID: 6732 RVA: 0x0001EC36 File Offset: 0x0001CE36
		// (set) Token: 0x06001A4D RID: 6733 RVA: 0x0001EC3E File Offset: 0x0001CE3E
		[DataMember(Name = "xmlVersion", IsRequired = false)]
		public string XmlVersion { get; set; }

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x06001A4E RID: 6734 RVA: 0x0001EC47 File Offset: 0x0001CE47
		// (set) Token: 0x06001A4F RID: 6735 RVA: 0x0001EC4F File Offset: 0x0001CE4F
		[DataMember(Name = "name", IsRequired = false)]
		public string Name { get; set; }

		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06001A50 RID: 6736 RVA: 0x0001EC58 File Offset: 0x0001CE58
		// (set) Token: 0x06001A51 RID: 6737 RVA: 0x0001EC60 File Offset: 0x0001CE60
		[DataMember(Name = "value", IsRequired = false)]
		public string Value { get; set; }

		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06001A52 RID: 6738 RVA: 0x0001EC69 File Offset: 0x0001CE69
		// (set) Token: 0x06001A53 RID: 6739 RVA: 0x0001EC85 File Offset: 0x0001CE85
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

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06001A54 RID: 6740 RVA: 0x0001EC98 File Offset: 0x0001CE98
		// (set) Token: 0x06001A55 RID: 6741 RVA: 0x0001ECA0 File Offset: 0x0001CEA0
		[DataMember(Name = "pseudoType", IsRequired = false)]
		internal string pseudoType { get; set; }

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06001A56 RID: 6742 RVA: 0x0001ECA9 File Offset: 0x0001CEA9
		// (set) Token: 0x06001A57 RID: 6743 RVA: 0x0001ECC5 File Offset: 0x0001CEC5
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

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06001A58 RID: 6744 RVA: 0x0001ECD8 File Offset: 0x0001CED8
		// (set) Token: 0x06001A59 RID: 6745 RVA: 0x0001ECE0 File Offset: 0x0001CEE0
		[DataMember(Name = "shadowRootType", IsRequired = false)]
		internal string shadowRootType { get; set; }

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06001A5A RID: 6746 RVA: 0x0001ECE9 File Offset: 0x0001CEE9
		// (set) Token: 0x06001A5B RID: 6747 RVA: 0x0001ECF1 File Offset: 0x0001CEF1
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; set; }

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06001A5C RID: 6748 RVA: 0x0001ECFA File Offset: 0x0001CEFA
		// (set) Token: 0x06001A5D RID: 6749 RVA: 0x0001ED02 File Offset: 0x0001CF02
		[DataMember(Name = "contentDocument", IsRequired = false)]
		public Node ContentDocument { get; set; }

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06001A5E RID: 6750 RVA: 0x0001ED0B File Offset: 0x0001CF0B
		// (set) Token: 0x06001A5F RID: 6751 RVA: 0x0001ED13 File Offset: 0x0001CF13
		[DataMember(Name = "shadowRoots", IsRequired = false)]
		public IList<Node> ShadowRoots { get; set; }

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06001A60 RID: 6752 RVA: 0x0001ED1C File Offset: 0x0001CF1C
		// (set) Token: 0x06001A61 RID: 6753 RVA: 0x0001ED24 File Offset: 0x0001CF24
		[DataMember(Name = "templateContent", IsRequired = false)]
		public Node TemplateContent { get; set; }

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x06001A62 RID: 6754 RVA: 0x0001ED2D File Offset: 0x0001CF2D
		// (set) Token: 0x06001A63 RID: 6755 RVA: 0x0001ED35 File Offset: 0x0001CF35
		[DataMember(Name = "pseudoElements", IsRequired = false)]
		public IList<Node> PseudoElements { get; set; }

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x06001A64 RID: 6756 RVA: 0x0001ED3E File Offset: 0x0001CF3E
		// (set) Token: 0x06001A65 RID: 6757 RVA: 0x0001ED46 File Offset: 0x0001CF46
		[DataMember(Name = "importedDocument", IsRequired = false)]
		public Node ImportedDocument { get; set; }

		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06001A66 RID: 6758 RVA: 0x0001ED4F File Offset: 0x0001CF4F
		// (set) Token: 0x06001A67 RID: 6759 RVA: 0x0001ED57 File Offset: 0x0001CF57
		[DataMember(Name = "distributedNodes", IsRequired = false)]
		public IList<BackendNode> DistributedNodes { get; set; }

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x06001A68 RID: 6760 RVA: 0x0001ED60 File Offset: 0x0001CF60
		// (set) Token: 0x06001A69 RID: 6761 RVA: 0x0001ED68 File Offset: 0x0001CF68
		[DataMember(Name = "isSVG", IsRequired = false)]
		public bool? IsSVG { get; set; }

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x06001A6A RID: 6762 RVA: 0x0001ED71 File Offset: 0x0001CF71
		// (set) Token: 0x06001A6B RID: 6763 RVA: 0x0001ED8D File Offset: 0x0001CF8D
		public CompatibilityMode? CompatibilityMode
		{
			get
			{
				return (CompatibilityMode?)DevToolsDomainEntityBase.StringToEnum(typeof(CompatibilityMode?), this.compatibilityMode);
			}
			set
			{
				this.compatibilityMode = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06001A6C RID: 6764 RVA: 0x0001EDA0 File Offset: 0x0001CFA0
		// (set) Token: 0x06001A6D RID: 6765 RVA: 0x0001EDA8 File Offset: 0x0001CFA8
		[DataMember(Name = "compatibilityMode", IsRequired = false)]
		internal string compatibilityMode { get; set; }
	}
}
