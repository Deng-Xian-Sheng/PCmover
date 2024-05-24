using System;
using System.Drawing;
using System.IO;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200001A RID: 26
	public interface IThumbnailFromStream
	{
		// Token: 0x060000A7 RID: 167
		Bitmap ConstructBitmap(Stream stream, int sideSize);
	}
}
