using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001AE RID: 430
	[DataContract]
	public class BaseAudioContext : DevToolsDomainEntityBase
	{
		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x00011901 File Offset: 0x0000FB01
		// (set) Token: 0x06000C5E RID: 3166 RVA: 0x00011909 File Offset: 0x0000FB09
		[DataMember(Name = "contextId", IsRequired = true)]
		public string ContextId { get; set; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x00011912 File Offset: 0x0000FB12
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x0001192E File Offset: 0x0000FB2E
		public ContextType ContextType
		{
			get
			{
				return (ContextType)DevToolsDomainEntityBase.StringToEnum(typeof(ContextType), this.contextType);
			}
			set
			{
				this.contextType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x00011941 File Offset: 0x0000FB41
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x00011949 File Offset: 0x0000FB49
		[DataMember(Name = "contextType", IsRequired = true)]
		internal string contextType { get; set; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x00011952 File Offset: 0x0000FB52
		// (set) Token: 0x06000C64 RID: 3172 RVA: 0x0001196E File Offset: 0x0000FB6E
		public ContextState ContextState
		{
			get
			{
				return (ContextState)DevToolsDomainEntityBase.StringToEnum(typeof(ContextState), this.contextState);
			}
			set
			{
				this.contextState = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x00011981 File Offset: 0x0000FB81
		// (set) Token: 0x06000C66 RID: 3174 RVA: 0x00011989 File Offset: 0x0000FB89
		[DataMember(Name = "contextState", IsRequired = true)]
		internal string contextState { get; set; }

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00011992 File Offset: 0x0000FB92
		// (set) Token: 0x06000C68 RID: 3176 RVA: 0x0001199A File Offset: 0x0000FB9A
		[DataMember(Name = "realtimeData", IsRequired = false)]
		public ContextRealtimeData RealtimeData { get; set; }

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x000119A3 File Offset: 0x0000FBA3
		// (set) Token: 0x06000C6A RID: 3178 RVA: 0x000119AB File Offset: 0x0000FBAB
		[DataMember(Name = "callbackBufferSize", IsRequired = true)]
		public double CallbackBufferSize { get; set; }

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x000119B4 File Offset: 0x0000FBB4
		// (set) Token: 0x06000C6C RID: 3180 RVA: 0x000119BC File Offset: 0x0000FBBC
		[DataMember(Name = "maxOutputChannelCount", IsRequired = true)]
		public double MaxOutputChannelCount { get; set; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x000119C5 File Offset: 0x0000FBC5
		// (set) Token: 0x06000C6E RID: 3182 RVA: 0x000119CD File Offset: 0x0000FBCD
		[DataMember(Name = "sampleRate", IsRequired = true)]
		public double SampleRate { get; set; }
	}
}
