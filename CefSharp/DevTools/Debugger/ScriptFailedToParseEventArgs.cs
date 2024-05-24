using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000182 RID: 386
	[DataContract]
	public class ScriptFailedToParseEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000B1E RID: 2846 RVA: 0x000102F6 File Offset: 0x0000E4F6
		// (set) Token: 0x06000B1F RID: 2847 RVA: 0x000102FE File Offset: 0x0000E4FE
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; private set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000B20 RID: 2848 RVA: 0x00010307 File Offset: 0x0000E507
		// (set) Token: 0x06000B21 RID: 2849 RVA: 0x0001030F File Offset: 0x0000E50F
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000B22 RID: 2850 RVA: 0x00010318 File Offset: 0x0000E518
		// (set) Token: 0x06000B23 RID: 2851 RVA: 0x00010320 File Offset: 0x0000E520
		[DataMember(Name = "startLine", IsRequired = true)]
		public int StartLine { get; private set; }

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000B24 RID: 2852 RVA: 0x00010329 File Offset: 0x0000E529
		// (set) Token: 0x06000B25 RID: 2853 RVA: 0x00010331 File Offset: 0x0000E531
		[DataMember(Name = "startColumn", IsRequired = true)]
		public int StartColumn { get; private set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x0001033A File Offset: 0x0000E53A
		// (set) Token: 0x06000B27 RID: 2855 RVA: 0x00010342 File Offset: 0x0000E542
		[DataMember(Name = "endLine", IsRequired = true)]
		public int EndLine { get; private set; }

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0001034B File Offset: 0x0000E54B
		// (set) Token: 0x06000B29 RID: 2857 RVA: 0x00010353 File Offset: 0x0000E553
		[DataMember(Name = "endColumn", IsRequired = true)]
		public int EndColumn { get; private set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000B2A RID: 2858 RVA: 0x0001035C File Offset: 0x0000E55C
		// (set) Token: 0x06000B2B RID: 2859 RVA: 0x00010364 File Offset: 0x0000E564
		[DataMember(Name = "executionContextId", IsRequired = true)]
		public int ExecutionContextId { get; private set; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000B2C RID: 2860 RVA: 0x0001036D File Offset: 0x0000E56D
		// (set) Token: 0x06000B2D RID: 2861 RVA: 0x00010375 File Offset: 0x0000E575
		[DataMember(Name = "hash", IsRequired = true)]
		public string Hash { get; private set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0001037E File Offset: 0x0000E57E
		// (set) Token: 0x06000B2F RID: 2863 RVA: 0x00010386 File Offset: 0x0000E586
		[DataMember(Name = "executionContextAuxData", IsRequired = false)]
		public object ExecutionContextAuxData { get; private set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000B30 RID: 2864 RVA: 0x0001038F File Offset: 0x0000E58F
		// (set) Token: 0x06000B31 RID: 2865 RVA: 0x00010397 File Offset: 0x0000E597
		[DataMember(Name = "sourceMapURL", IsRequired = false)]
		public string SourceMapURL { get; private set; }

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000B32 RID: 2866 RVA: 0x000103A0 File Offset: 0x0000E5A0
		// (set) Token: 0x06000B33 RID: 2867 RVA: 0x000103A8 File Offset: 0x0000E5A8
		[DataMember(Name = "hasSourceURL", IsRequired = false)]
		public bool? HasSourceURL { get; private set; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000B34 RID: 2868 RVA: 0x000103B1 File Offset: 0x0000E5B1
		// (set) Token: 0x06000B35 RID: 2869 RVA: 0x000103B9 File Offset: 0x0000E5B9
		[DataMember(Name = "isModule", IsRequired = false)]
		public bool? IsModule { get; private set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000B36 RID: 2870 RVA: 0x000103C2 File Offset: 0x0000E5C2
		// (set) Token: 0x06000B37 RID: 2871 RVA: 0x000103CA File Offset: 0x0000E5CA
		[DataMember(Name = "length", IsRequired = false)]
		public int? Length { get; private set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000B38 RID: 2872 RVA: 0x000103D3 File Offset: 0x0000E5D3
		// (set) Token: 0x06000B39 RID: 2873 RVA: 0x000103DB File Offset: 0x0000E5DB
		[DataMember(Name = "stackTrace", IsRequired = false)]
		public StackTrace StackTrace { get; private set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000B3A RID: 2874 RVA: 0x000103E4 File Offset: 0x0000E5E4
		// (set) Token: 0x06000B3B RID: 2875 RVA: 0x000103EC File Offset: 0x0000E5EC
		[DataMember(Name = "codeOffset", IsRequired = false)]
		public int? CodeOffset { get; private set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000B3C RID: 2876 RVA: 0x000103F5 File Offset: 0x0000E5F5
		// (set) Token: 0x06000B3D RID: 2877 RVA: 0x00010411 File Offset: 0x0000E611
		public ScriptLanguage? ScriptLanguage
		{
			get
			{
				return (ScriptLanguage?)DevToolsDomainEventArgsBase.StringToEnum(typeof(ScriptLanguage?), this.scriptLanguage);
			}
			set
			{
				this.scriptLanguage = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000B3E RID: 2878 RVA: 0x00010424 File Offset: 0x0000E624
		// (set) Token: 0x06000B3F RID: 2879 RVA: 0x0001042C File Offset: 0x0000E62C
		[DataMember(Name = "scriptLanguage", IsRequired = false)]
		internal string scriptLanguage { get; private set; }

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000B40 RID: 2880 RVA: 0x00010435 File Offset: 0x0000E635
		// (set) Token: 0x06000B41 RID: 2881 RVA: 0x0001043D File Offset: 0x0000E63D
		[DataMember(Name = "embedderName", IsRequired = false)]
		public string EmbedderName { get; private set; }
	}
}
