using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200001C RID: 28
	public class MigrationTypePolicyData
	{
		// Token: 0x0600009A RID: 154 RVA: 0x000029C5 File Offset: 0x00000BC5
		public MigrationTypePolicyData()
		{
			this.Image = new ImageMapData
			{
				Folders = new List<ImageFolderMapping>()
			};
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000029EA File Offset: 0x00000BEA
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000029F2 File Offset: 0x00000BF2
		public ImageMapData Image { get; set; }

		// Token: 0x040000B1 RID: 177
		public MigrationTypeOption DefaultOption = MigrationTypeOption.Nothing;
	}
}
