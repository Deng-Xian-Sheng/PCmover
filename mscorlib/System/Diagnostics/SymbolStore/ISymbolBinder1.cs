using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FB RID: 1019
	[ComVisible(true)]
	public interface ISymbolBinder1
	{
		// Token: 0x06003393 RID: 13203
		ISymbolReader GetReader(IntPtr importer, string filename, string searchPath);
	}
}
