using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Media
{
	// Token: 0x02000194 RID: 404
	[DataContract]
	public class PlayerMessage : DevToolsDomainEntityBase
	{
		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x00011153 File Offset: 0x0000F353
		// (set) Token: 0x06000BD7 RID: 3031 RVA: 0x0001116F File Offset: 0x0000F36F
		public PlayerMessageLevel Level
		{
			get
			{
				return (PlayerMessageLevel)DevToolsDomainEntityBase.StringToEnum(typeof(PlayerMessageLevel), this.level);
			}
			set
			{
				this.level = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x00011182 File Offset: 0x0000F382
		// (set) Token: 0x06000BD9 RID: 3033 RVA: 0x0001118A File Offset: 0x0000F38A
		[DataMember(Name = "level", IsRequired = true)]
		internal string level { get; set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x00011193 File Offset: 0x0000F393
		// (set) Token: 0x06000BDB RID: 3035 RVA: 0x0001119B File Offset: 0x0000F39B
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; set; }
	}
}
