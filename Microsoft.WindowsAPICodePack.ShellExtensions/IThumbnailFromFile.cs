using System;
using System.Drawing;
using System.IO;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200001C RID: 28
	public interface IThumbnailFromFile
	{
		// Token: 0x060000A9 RID: 169
		Bitmap ConstructBitmap(FileInfo info, int sideSize);
	}
}
