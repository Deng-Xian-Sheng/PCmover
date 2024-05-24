using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017B RID: 379
	[DataContract]
	public class BreakLocation : DevToolsDomainEntityBase
	{
		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0001014A File Offset: 0x0000E34A
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x00010152 File Offset: 0x0000E352
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0001015B File Offset: 0x0000E35B
		// (set) Token: 0x06000AF9 RID: 2809 RVA: 0x00010163 File Offset: 0x0000E363
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x0001016C File Offset: 0x0000E36C
		// (set) Token: 0x06000AFB RID: 2811 RVA: 0x00010174 File Offset: 0x0000E374
		[DataMember(Name = "columnNumber", IsRequired = false)]
		public int? ColumnNumber { get; set; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0001017D File Offset: 0x0000E37D
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x00010199 File Offset: 0x0000E399
		public BreakLocationType? Type
		{
			get
			{
				return (BreakLocationType?)DevToolsDomainEntityBase.StringToEnum(typeof(BreakLocationType?), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x000101AC File Offset: 0x0000E3AC
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x000101B4 File Offset: 0x0000E3B4
		[DataMember(Name = "type", IsRequired = false)]
		internal string type { get; set; }
	}
}
