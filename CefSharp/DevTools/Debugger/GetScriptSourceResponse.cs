using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000187 RID: 391
	[DataContract]
	public class GetScriptSourceResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06000B7B RID: 2939 RVA: 0x00010644 File Offset: 0x0000E844
		// (set) Token: 0x06000B7C RID: 2940 RVA: 0x0001064C File Offset: 0x0000E84C
		[DataMember]
		internal string scriptSource { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06000B7D RID: 2941 RVA: 0x00010655 File Offset: 0x0000E855
		public string ScriptSource
		{
			get
			{
				return this.scriptSource;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x06000B7E RID: 2942 RVA: 0x0001065D File Offset: 0x0000E85D
		// (set) Token: 0x06000B7F RID: 2943 RVA: 0x00010665 File Offset: 0x0000E865
		[DataMember]
		internal string bytecode { get; set; }

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x06000B80 RID: 2944 RVA: 0x0001066E File Offset: 0x0000E86E
		public byte[] Bytecode
		{
			get
			{
				return base.Convert(this.bytecode);
			}
		}
	}
}
