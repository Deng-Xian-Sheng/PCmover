﻿using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FA RID: 1018
	[ComVisible(true)]
	public interface ISymbolBinder
	{
		// Token: 0x06003392 RID: 13202
		[Obsolete("The recommended alternative is ISymbolBinder1.GetReader. ISymbolBinder1.GetReader takes the importer interface pointer as an IntPtr instead of an Int32, and thus works on both 32-bit and 64-bit architectures. http://go.microsoft.com/fwlink/?linkid=14202=14202")]
		ISymbolReader GetReader(int importer, string filename, string searchPath);
	}
}
