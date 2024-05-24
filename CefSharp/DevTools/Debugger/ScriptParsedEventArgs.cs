using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000183 RID: 387
	[DataContract]
	public class ScriptParsedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0001044E File Offset: 0x0000E64E
		// (set) Token: 0x06000B44 RID: 2884 RVA: 0x00010456 File Offset: 0x0000E656
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; private set; }

		// Token: 0x1700037A RID: 890
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0001045F File Offset: 0x0000E65F
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x00010467 File Offset: 0x0000E667
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x06000B47 RID: 2887 RVA: 0x00010470 File Offset: 0x0000E670
		// (set) Token: 0x06000B48 RID: 2888 RVA: 0x00010478 File Offset: 0x0000E678
		[DataMember(Name = "startLine", IsRequired = true)]
		public int StartLine { get; private set; }

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x06000B49 RID: 2889 RVA: 0x00010481 File Offset: 0x0000E681
		// (set) Token: 0x06000B4A RID: 2890 RVA: 0x00010489 File Offset: 0x0000E689
		[DataMember(Name = "startColumn", IsRequired = true)]
		public int StartColumn { get; private set; }

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000B4B RID: 2891 RVA: 0x00010492 File Offset: 0x0000E692
		// (set) Token: 0x06000B4C RID: 2892 RVA: 0x0001049A File Offset: 0x0000E69A
		[DataMember(Name = "endLine", IsRequired = true)]
		public int EndLine { get; private set; }

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000B4D RID: 2893 RVA: 0x000104A3 File Offset: 0x0000E6A3
		// (set) Token: 0x06000B4E RID: 2894 RVA: 0x000104AB File Offset: 0x0000E6AB
		[DataMember(Name = "endColumn", IsRequired = true)]
		public int EndColumn { get; private set; }

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000B4F RID: 2895 RVA: 0x000104B4 File Offset: 0x0000E6B4
		// (set) Token: 0x06000B50 RID: 2896 RVA: 0x000104BC File Offset: 0x0000E6BC
		[DataMember(Name = "executionContextId", IsRequired = true)]
		public int ExecutionContextId { get; private set; }

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000B51 RID: 2897 RVA: 0x000104C5 File Offset: 0x0000E6C5
		// (set) Token: 0x06000B52 RID: 2898 RVA: 0x000104CD File Offset: 0x0000E6CD
		[DataMember(Name = "hash", IsRequired = true)]
		public string Hash { get; private set; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000B53 RID: 2899 RVA: 0x000104D6 File Offset: 0x0000E6D6
		// (set) Token: 0x06000B54 RID: 2900 RVA: 0x000104DE File Offset: 0x0000E6DE
		[DataMember(Name = "executionContextAuxData", IsRequired = false)]
		public object ExecutionContextAuxData { get; private set; }

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000B55 RID: 2901 RVA: 0x000104E7 File Offset: 0x0000E6E7
		// (set) Token: 0x06000B56 RID: 2902 RVA: 0x000104EF File Offset: 0x0000E6EF
		[DataMember(Name = "isLiveEdit", IsRequired = false)]
		public bool? IsLiveEdit { get; private set; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000B57 RID: 2903 RVA: 0x000104F8 File Offset: 0x0000E6F8
		// (set) Token: 0x06000B58 RID: 2904 RVA: 0x00010500 File Offset: 0x0000E700
		[DataMember(Name = "sourceMapURL", IsRequired = false)]
		public string SourceMapURL { get; private set; }

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x06000B59 RID: 2905 RVA: 0x00010509 File Offset: 0x0000E709
		// (set) Token: 0x06000B5A RID: 2906 RVA: 0x00010511 File Offset: 0x0000E711
		[DataMember(Name = "hasSourceURL", IsRequired = false)]
		public bool? HasSourceURL { get; private set; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0001051A File Offset: 0x0000E71A
		// (set) Token: 0x06000B5C RID: 2908 RVA: 0x00010522 File Offset: 0x0000E722
		[DataMember(Name = "isModule", IsRequired = false)]
		public bool? IsModule { get; private set; }

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0001052B File Offset: 0x0000E72B
		// (set) Token: 0x06000B5E RID: 2910 RVA: 0x00010533 File Offset: 0x0000E733
		[DataMember(Name = "length", IsRequired = false)]
		public int? Length { get; private set; }

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0001053C File Offset: 0x0000E73C
		// (set) Token: 0x06000B60 RID: 2912 RVA: 0x00010544 File Offset: 0x0000E744
		[DataMember(Name = "stackTrace", IsRequired = false)]
		public StackTrace StackTrace { get; private set; }

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0001054D File Offset: 0x0000E74D
		// (set) Token: 0x06000B62 RID: 2914 RVA: 0x00010555 File Offset: 0x0000E755
		[DataMember(Name = "codeOffset", IsRequired = false)]
		public int? CodeOffset { get; private set; }

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0001055E File Offset: 0x0000E75E
		// (set) Token: 0x06000B64 RID: 2916 RVA: 0x0001057A File Offset: 0x0000E77A
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

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0001058D File Offset: 0x0000E78D
		// (set) Token: 0x06000B66 RID: 2918 RVA: 0x00010595 File Offset: 0x0000E795
		[DataMember(Name = "scriptLanguage", IsRequired = false)]
		internal string scriptLanguage { get; private set; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0001059E File Offset: 0x0000E79E
		// (set) Token: 0x06000B68 RID: 2920 RVA: 0x000105A6 File Offset: 0x0000E7A6
		[DataMember(Name = "debugSymbols", IsRequired = false)]
		public DebugSymbols DebugSymbols { get; private set; }

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x000105AF File Offset: 0x0000E7AF
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x000105B7 File Offset: 0x0000E7B7
		[DataMember(Name = "embedderName", IsRequired = false)]
		public string EmbedderName { get; private set; }
	}
}
