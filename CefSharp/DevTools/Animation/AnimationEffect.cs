using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000435 RID: 1077
	[DataContract]
	public class AnimationEffect : DevToolsDomainEntityBase
	{
		// Token: 0x17000B76 RID: 2934
		// (get) Token: 0x06001F4E RID: 8014 RVA: 0x0002361D File Offset: 0x0002181D
		// (set) Token: 0x06001F4F RID: 8015 RVA: 0x00023625 File Offset: 0x00021825
		[DataMember(Name = "delay", IsRequired = true)]
		public double Delay { get; set; }

		// Token: 0x17000B77 RID: 2935
		// (get) Token: 0x06001F50 RID: 8016 RVA: 0x0002362E File Offset: 0x0002182E
		// (set) Token: 0x06001F51 RID: 8017 RVA: 0x00023636 File Offset: 0x00021836
		[DataMember(Name = "endDelay", IsRequired = true)]
		public double EndDelay { get; set; }

		// Token: 0x17000B78 RID: 2936
		// (get) Token: 0x06001F52 RID: 8018 RVA: 0x0002363F File Offset: 0x0002183F
		// (set) Token: 0x06001F53 RID: 8019 RVA: 0x00023647 File Offset: 0x00021847
		[DataMember(Name = "iterationStart", IsRequired = true)]
		public double IterationStart { get; set; }

		// Token: 0x17000B79 RID: 2937
		// (get) Token: 0x06001F54 RID: 8020 RVA: 0x00023650 File Offset: 0x00021850
		// (set) Token: 0x06001F55 RID: 8021 RVA: 0x00023658 File Offset: 0x00021858
		[DataMember(Name = "iterations", IsRequired = true)]
		public double Iterations { get; set; }

		// Token: 0x17000B7A RID: 2938
		// (get) Token: 0x06001F56 RID: 8022 RVA: 0x00023661 File Offset: 0x00021861
		// (set) Token: 0x06001F57 RID: 8023 RVA: 0x00023669 File Offset: 0x00021869
		[DataMember(Name = "duration", IsRequired = true)]
		public double Duration { get; set; }

		// Token: 0x17000B7B RID: 2939
		// (get) Token: 0x06001F58 RID: 8024 RVA: 0x00023672 File Offset: 0x00021872
		// (set) Token: 0x06001F59 RID: 8025 RVA: 0x0002367A File Offset: 0x0002187A
		[DataMember(Name = "direction", IsRequired = true)]
		public string Direction { get; set; }

		// Token: 0x17000B7C RID: 2940
		// (get) Token: 0x06001F5A RID: 8026 RVA: 0x00023683 File Offset: 0x00021883
		// (set) Token: 0x06001F5B RID: 8027 RVA: 0x0002368B File Offset: 0x0002188B
		[DataMember(Name = "fill", IsRequired = true)]
		public string Fill { get; set; }

		// Token: 0x17000B7D RID: 2941
		// (get) Token: 0x06001F5C RID: 8028 RVA: 0x00023694 File Offset: 0x00021894
		// (set) Token: 0x06001F5D RID: 8029 RVA: 0x0002369C File Offset: 0x0002189C
		[DataMember(Name = "backendNodeId", IsRequired = false)]
		public int? BackendNodeId { get; set; }

		// Token: 0x17000B7E RID: 2942
		// (get) Token: 0x06001F5E RID: 8030 RVA: 0x000236A5 File Offset: 0x000218A5
		// (set) Token: 0x06001F5F RID: 8031 RVA: 0x000236AD File Offset: 0x000218AD
		[DataMember(Name = "keyframesRule", IsRequired = false)]
		public KeyframesRule KeyframesRule { get; set; }

		// Token: 0x17000B7F RID: 2943
		// (get) Token: 0x06001F60 RID: 8032 RVA: 0x000236B6 File Offset: 0x000218B6
		// (set) Token: 0x06001F61 RID: 8033 RVA: 0x000236BE File Offset: 0x000218BE
		[DataMember(Name = "easing", IsRequired = true)]
		public string Easing { get; set; }
	}
}
