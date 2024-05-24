using System;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000009 RID: 9
	public enum ErrorType
	{
		// Token: 0x04000017 RID: 23
		SourceLibraryDoesNotExist,
		// Token: 0x04000018 RID: 24
		DestinationLibraryExists,
		// Token: 0x04000019 RID: 25
		SourceFolderDoesNotExist,
		// Token: 0x0400001A RID: 26
		DestinationFolderExists,
		// Token: 0x0400001B RID: 27
		FileExists
	}
}
