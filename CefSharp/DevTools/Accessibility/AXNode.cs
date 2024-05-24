using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000447 RID: 1095
	[DataContract]
	public class AXNode : DevToolsDomainEntityBase
	{
		// Token: 0x17000BA3 RID: 2979
		// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x00023C68 File Offset: 0x00021E68
		// (set) Token: 0x06001FC4 RID: 8132 RVA: 0x00023C70 File Offset: 0x00021E70
		[DataMember(Name = "nodeId", IsRequired = true)]
		public string NodeId { get; set; }

		// Token: 0x17000BA4 RID: 2980
		// (get) Token: 0x06001FC5 RID: 8133 RVA: 0x00023C79 File Offset: 0x00021E79
		// (set) Token: 0x06001FC6 RID: 8134 RVA: 0x00023C81 File Offset: 0x00021E81
		[DataMember(Name = "ignored", IsRequired = true)]
		public bool Ignored { get; set; }

		// Token: 0x17000BA5 RID: 2981
		// (get) Token: 0x06001FC7 RID: 8135 RVA: 0x00023C8A File Offset: 0x00021E8A
		// (set) Token: 0x06001FC8 RID: 8136 RVA: 0x00023C92 File Offset: 0x00021E92
		[DataMember(Name = "ignoredReasons", IsRequired = false)]
		public IList<AXProperty> IgnoredReasons { get; set; }

		// Token: 0x17000BA6 RID: 2982
		// (get) Token: 0x06001FC9 RID: 8137 RVA: 0x00023C9B File Offset: 0x00021E9B
		// (set) Token: 0x06001FCA RID: 8138 RVA: 0x00023CA3 File Offset: 0x00021EA3
		[DataMember(Name = "role", IsRequired = false)]
		public AXValue Role { get; set; }

		// Token: 0x17000BA7 RID: 2983
		// (get) Token: 0x06001FCB RID: 8139 RVA: 0x00023CAC File Offset: 0x00021EAC
		// (set) Token: 0x06001FCC RID: 8140 RVA: 0x00023CB4 File Offset: 0x00021EB4
		[DataMember(Name = "name", IsRequired = false)]
		public AXValue Name { get; set; }

		// Token: 0x17000BA8 RID: 2984
		// (get) Token: 0x06001FCD RID: 8141 RVA: 0x00023CBD File Offset: 0x00021EBD
		// (set) Token: 0x06001FCE RID: 8142 RVA: 0x00023CC5 File Offset: 0x00021EC5
		[DataMember(Name = "description", IsRequired = false)]
		public AXValue Description { get; set; }

		// Token: 0x17000BA9 RID: 2985
		// (get) Token: 0x06001FCF RID: 8143 RVA: 0x00023CCE File Offset: 0x00021ECE
		// (set) Token: 0x06001FD0 RID: 8144 RVA: 0x00023CD6 File Offset: 0x00021ED6
		[DataMember(Name = "value", IsRequired = false)]
		public AXValue Value { get; set; }

		// Token: 0x17000BAA RID: 2986
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x00023CDF File Offset: 0x00021EDF
		// (set) Token: 0x06001FD2 RID: 8146 RVA: 0x00023CE7 File Offset: 0x00021EE7
		[DataMember(Name = "properties", IsRequired = false)]
		public IList<AXProperty> Properties { get; set; }

		// Token: 0x17000BAB RID: 2987
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00023CF0 File Offset: 0x00021EF0
		// (set) Token: 0x06001FD4 RID: 8148 RVA: 0x00023CF8 File Offset: 0x00021EF8
		[DataMember(Name = "parentId", IsRequired = false)]
		public string ParentId { get; set; }

		// Token: 0x17000BAC RID: 2988
		// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x00023D01 File Offset: 0x00021F01
		// (set) Token: 0x06001FD6 RID: 8150 RVA: 0x00023D09 File Offset: 0x00021F09
		[DataMember(Name = "childIds", IsRequired = false)]
		public string[] ChildIds { get; set; }

		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x06001FD7 RID: 8151 RVA: 0x00023D12 File Offset: 0x00021F12
		// (set) Token: 0x06001FD8 RID: 8152 RVA: 0x00023D1A File Offset: 0x00021F1A
		[DataMember(Name = "backendDOMNodeId", IsRequired = false)]
		public int? BackendDOMNodeId { get; set; }

		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x06001FD9 RID: 8153 RVA: 0x00023D23 File Offset: 0x00021F23
		// (set) Token: 0x06001FDA RID: 8154 RVA: 0x00023D2B File Offset: 0x00021F2B
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; set; }
	}
}
