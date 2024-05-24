using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017E RID: 382
	[DataContract]
	public class DebugSymbols : DevToolsDomainEntityBase
	{
		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x000101C5 File Offset: 0x0000E3C5
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x000101E1 File Offset: 0x0000E3E1
		public DebugSymbolsType Type
		{
			get
			{
				return (DebugSymbolsType)DevToolsDomainEntityBase.StringToEnum(typeof(DebugSymbolsType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x000101F4 File Offset: 0x0000E3F4
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x000101FC File Offset: 0x0000E3FC
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00010205 File Offset: 0x0000E405
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x0001020D File Offset: 0x0000E40D
		[DataMember(Name = "externalURL", IsRequired = false)]
		public string ExternalURL { get; set; }
	}
}
