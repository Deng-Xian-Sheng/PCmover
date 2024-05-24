using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200018E RID: 398
	[DataContract]
	public class SetScriptSourceResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x0001077C File Offset: 0x0000E97C
		// (set) Token: 0x06000BA1 RID: 2977 RVA: 0x00010784 File Offset: 0x0000E984
		[DataMember]
		internal IList<CallFrame> callFrames { get; set; }

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0001078D File Offset: 0x0000E98D
		public IList<CallFrame> CallFrames
		{
			get
			{
				return this.callFrames;
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x00010795 File Offset: 0x0000E995
		// (set) Token: 0x06000BA4 RID: 2980 RVA: 0x0001079D File Offset: 0x0000E99D
		[DataMember]
		internal bool? stackChanged { get; set; }

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x000107A6 File Offset: 0x0000E9A6
		public bool? StackChanged
		{
			get
			{
				return this.stackChanged;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x000107AE File Offset: 0x0000E9AE
		// (set) Token: 0x06000BA7 RID: 2983 RVA: 0x000107B6 File Offset: 0x0000E9B6
		[DataMember]
		internal StackTrace asyncStackTrace { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x000107BF File Offset: 0x0000E9BF
		public StackTrace AsyncStackTrace
		{
			get
			{
				return this.asyncStackTrace;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x000107C7 File Offset: 0x0000E9C7
		// (set) Token: 0x06000BAA RID: 2986 RVA: 0x000107CF File Offset: 0x0000E9CF
		[DataMember]
		internal StackTraceId asyncStackTraceId { get; set; }

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x000107D8 File Offset: 0x0000E9D8
		public StackTraceId AsyncStackTraceId
		{
			get
			{
				return this.asyncStackTraceId;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x000107E0 File Offset: 0x0000E9E0
		// (set) Token: 0x06000BAD RID: 2989 RVA: 0x000107E8 File Offset: 0x0000E9E8
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x000107F1 File Offset: 0x0000E9F1
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
