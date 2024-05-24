using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001B0 RID: 432
	[DataContract]
	public class AudioNode : DevToolsDomainEntityBase
	{
		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00011A08 File Offset: 0x0000FC08
		// (set) Token: 0x06000C76 RID: 3190 RVA: 0x00011A10 File Offset: 0x0000FC10
		[DataMember(Name = "nodeId", IsRequired = true)]
		public string NodeId { get; set; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x00011A19 File Offset: 0x0000FC19
		// (set) Token: 0x06000C78 RID: 3192 RVA: 0x00011A21 File Offset: 0x0000FC21
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; set; }

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00011A2A File Offset: 0x0000FC2A
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x00011A32 File Offset: 0x0000FC32
		[DataMember(Name = "nodeType", IsRequired = true)]
		public string NodeType { get; set; }

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x00011A3B File Offset: 0x0000FC3B
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x00011A43 File Offset: 0x0000FC43
		[DataMember(Name = "numberOfInputs", IsRequired = true)]
		public double NumberOfInputs { get; set; }

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00011A4C File Offset: 0x0000FC4C
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x00011A54 File Offset: 0x0000FC54
		[DataMember(Name = "numberOfOutputs", IsRequired = true)]
		public double NumberOfOutputs { get; set; }

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00011A5D File Offset: 0x0000FC5D
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00011A65 File Offset: 0x0000FC65
		[DataMember(Name = "channelCount", IsRequired = true)]
		public double ChannelCount { get; set; }

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x00011A6E File Offset: 0x0000FC6E
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x00011A8A File Offset: 0x0000FC8A
		public ChannelCountMode ChannelCountMode
		{
			get
			{
				return (ChannelCountMode)DevToolsDomainEntityBase.StringToEnum(typeof(ChannelCountMode), this.channelCountMode);
			}
			set
			{
				this.channelCountMode = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x00011A9D File Offset: 0x0000FC9D
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x00011AA5 File Offset: 0x0000FCA5
		[DataMember(Name = "channelCountMode", IsRequired = true)]
		internal string channelCountMode { get; set; }

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00011AAE File Offset: 0x0000FCAE
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x00011ACA File Offset: 0x0000FCCA
		public ChannelInterpretation ChannelInterpretation
		{
			get
			{
				return (ChannelInterpretation)DevToolsDomainEntityBase.StringToEnum(typeof(ChannelInterpretation), this.channelInterpretation);
			}
			set
			{
				this.channelInterpretation = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00011ADD File Offset: 0x0000FCDD
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x00011AE5 File Offset: 0x0000FCE5
		[DataMember(Name = "channelInterpretation", IsRequired = true)]
		internal string channelInterpretation { get; set; }
	}
}
