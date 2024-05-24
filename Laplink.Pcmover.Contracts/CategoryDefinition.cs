using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200002C RID: 44
	public class CategoryDefinition : ContainerInfo
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002C93 File Offset: 0x00000E93
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00002C9B File Offset: 0x00000E9B
		public string Name { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00002CA4 File Offset: 0x00000EA4
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00002CAC File Offset: 0x00000EAC
		public string Group { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002CB5 File Offset: 0x00000EB5
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00002CBD File Offset: 0x00000EBD
		public string UserAccountName { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00002CC6 File Offset: 0x00000EC6
		public bool IsCloud
		{
			get
			{
				return this.Group == CategoryGroups.Cloud || this.Group == CategoryGroups.OneDrive;
			}
		}
	}
}
