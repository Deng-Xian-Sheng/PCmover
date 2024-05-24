using System;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000004 RID: 4
	public enum MoveResult
	{
		// Token: 0x0400000D RID: 13
		Success,
		// Token: 0x0400000E RID: 14
		SourceDoesNotExist,
		// Token: 0x0400000F RID: 15
		DestinationExists,
		// Token: 0x04000010 RID: 16
		ErrorCopying,
		// Token: 0x04000011 RID: 17
		ErrorDeleting,
		// Token: 0x04000012 RID: 18
		UnexpectedException,
		// Token: 0x04000013 RID: 19
		GenericFailure
	}
}
