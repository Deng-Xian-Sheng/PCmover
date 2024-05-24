using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x02000323 RID: 803
	[DataContract]
	public class Layer : DevToolsDomainEntityBase
	{
		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0001B834 File Offset: 0x00019A34
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0001B83C File Offset: 0x00019A3C
		[DataMember(Name = "layerId", IsRequired = true)]
		public string LayerId { get; set; }

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0001B845 File Offset: 0x00019A45
		// (set) Token: 0x06001783 RID: 6019 RVA: 0x0001B84D File Offset: 0x00019A4D
		[DataMember(Name = "parentLayerId", IsRequired = false)]
		public string ParentLayerId { get; set; }

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0001B856 File Offset: 0x00019A56
		// (set) Token: 0x06001785 RID: 6021 RVA: 0x0001B85E File Offset: 0x00019A5E
		[DataMember(Name = "backendNodeId", IsRequired = false)]
		public int? BackendNodeId { get; set; }

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0001B867 File Offset: 0x00019A67
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x0001B86F File Offset: 0x00019A6F
		[DataMember(Name = "offsetX", IsRequired = true)]
		public double OffsetX { get; set; }

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0001B878 File Offset: 0x00019A78
		// (set) Token: 0x06001789 RID: 6025 RVA: 0x0001B880 File Offset: 0x00019A80
		[DataMember(Name = "offsetY", IsRequired = true)]
		public double OffsetY { get; set; }

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0001B889 File Offset: 0x00019A89
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x0001B891 File Offset: 0x00019A91
		[DataMember(Name = "width", IsRequired = true)]
		public double Width { get; set; }

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x0001B89A File Offset: 0x00019A9A
		// (set) Token: 0x0600178D RID: 6029 RVA: 0x0001B8A2 File Offset: 0x00019AA2
		[DataMember(Name = "height", IsRequired = true)]
		public double Height { get; set; }

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x0001B8AB File Offset: 0x00019AAB
		// (set) Token: 0x0600178F RID: 6031 RVA: 0x0001B8B3 File Offset: 0x00019AB3
		[DataMember(Name = "transform", IsRequired = false)]
		public double[] Transform { get; set; }

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x0001B8BC File Offset: 0x00019ABC
		// (set) Token: 0x06001791 RID: 6033 RVA: 0x0001B8C4 File Offset: 0x00019AC4
		[DataMember(Name = "anchorX", IsRequired = false)]
		public double? AnchorX { get; set; }

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x0001B8CD File Offset: 0x00019ACD
		// (set) Token: 0x06001793 RID: 6035 RVA: 0x0001B8D5 File Offset: 0x00019AD5
		[DataMember(Name = "anchorY", IsRequired = false)]
		public double? AnchorY { get; set; }

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x0001B8DE File Offset: 0x00019ADE
		// (set) Token: 0x06001795 RID: 6037 RVA: 0x0001B8E6 File Offset: 0x00019AE6
		[DataMember(Name = "anchorZ", IsRequired = false)]
		public double? AnchorZ { get; set; }

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0001B8EF File Offset: 0x00019AEF
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x0001B8F7 File Offset: 0x00019AF7
		[DataMember(Name = "paintCount", IsRequired = true)]
		public int PaintCount { get; set; }

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x0001B900 File Offset: 0x00019B00
		// (set) Token: 0x06001799 RID: 6041 RVA: 0x0001B908 File Offset: 0x00019B08
		[DataMember(Name = "drawsContent", IsRequired = true)]
		public bool DrawsContent { get; set; }

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x0600179A RID: 6042 RVA: 0x0001B911 File Offset: 0x00019B11
		// (set) Token: 0x0600179B RID: 6043 RVA: 0x0001B919 File Offset: 0x00019B19
		[DataMember(Name = "invisible", IsRequired = false)]
		public bool? Invisible { get; set; }

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0001B922 File Offset: 0x00019B22
		// (set) Token: 0x0600179D RID: 6045 RVA: 0x0001B92A File Offset: 0x00019B2A
		[DataMember(Name = "scrollRects", IsRequired = false)]
		public IList<ScrollRect> ScrollRects { get; set; }

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0001B933 File Offset: 0x00019B33
		// (set) Token: 0x0600179F RID: 6047 RVA: 0x0001B93B File Offset: 0x00019B3B
		[DataMember(Name = "stickyPositionConstraint", IsRequired = false)]
		public StickyPositionConstraint StickyPositionConstraint { get; set; }
	}
}
