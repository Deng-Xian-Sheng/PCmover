using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x02000434 RID: 1076
	[DataContract]
	public class Animation : DevToolsDomainEntityBase
	{
		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x06001F37 RID: 7991 RVA: 0x0002353C File Offset: 0x0002173C
		// (set) Token: 0x06001F38 RID: 7992 RVA: 0x00023544 File Offset: 0x00021744
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x06001F39 RID: 7993 RVA: 0x0002354D File Offset: 0x0002174D
		// (set) Token: 0x06001F3A RID: 7994 RVA: 0x00023555 File Offset: 0x00021755
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x06001F3B RID: 7995 RVA: 0x0002355E File Offset: 0x0002175E
		// (set) Token: 0x06001F3C RID: 7996 RVA: 0x00023566 File Offset: 0x00021766
		[DataMember(Name = "pausedState", IsRequired = true)]
		public bool PausedState { get; set; }

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x06001F3D RID: 7997 RVA: 0x0002356F File Offset: 0x0002176F
		// (set) Token: 0x06001F3E RID: 7998 RVA: 0x00023577 File Offset: 0x00021777
		[DataMember(Name = "playState", IsRequired = true)]
		public string PlayState { get; set; }

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x06001F3F RID: 7999 RVA: 0x00023580 File Offset: 0x00021780
		// (set) Token: 0x06001F40 RID: 8000 RVA: 0x00023588 File Offset: 0x00021788
		[DataMember(Name = "playbackRate", IsRequired = true)]
		public double PlaybackRate { get; set; }

		// Token: 0x17000B70 RID: 2928
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x00023591 File Offset: 0x00021791
		// (set) Token: 0x06001F42 RID: 8002 RVA: 0x00023599 File Offset: 0x00021799
		[DataMember(Name = "startTime", IsRequired = true)]
		public double StartTime { get; set; }

		// Token: 0x17000B71 RID: 2929
		// (get) Token: 0x06001F43 RID: 8003 RVA: 0x000235A2 File Offset: 0x000217A2
		// (set) Token: 0x06001F44 RID: 8004 RVA: 0x000235AA File Offset: 0x000217AA
		[DataMember(Name = "currentTime", IsRequired = true)]
		public double CurrentTime { get; set; }

		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x06001F45 RID: 8005 RVA: 0x000235B3 File Offset: 0x000217B3
		// (set) Token: 0x06001F46 RID: 8006 RVA: 0x000235CF File Offset: 0x000217CF
		public AnimationType Type
		{
			get
			{
				return (AnimationType)DevToolsDomainEntityBase.StringToEnum(typeof(AnimationType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x06001F47 RID: 8007 RVA: 0x000235E2 File Offset: 0x000217E2
		// (set) Token: 0x06001F48 RID: 8008 RVA: 0x000235EA File Offset: 0x000217EA
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000B74 RID: 2932
		// (get) Token: 0x06001F49 RID: 8009 RVA: 0x000235F3 File Offset: 0x000217F3
		// (set) Token: 0x06001F4A RID: 8010 RVA: 0x000235FB File Offset: 0x000217FB
		[DataMember(Name = "source", IsRequired = false)]
		public AnimationEffect Source { get; set; }

		// Token: 0x17000B75 RID: 2933
		// (get) Token: 0x06001F4B RID: 8011 RVA: 0x00023604 File Offset: 0x00021804
		// (set) Token: 0x06001F4C RID: 8012 RVA: 0x0002360C File Offset: 0x0002180C
		[DataMember(Name = "cssId", IsRequired = false)]
		public string CssId { get; set; }
	}
}
