using System;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200001B RID: 27
	public interface IThumbnailFromShellObject
	{
		// Token: 0x060000A8 RID: 168
		Bitmap ConstructBitmap(ShellObject shellObject, int sideSize);
	}
}
