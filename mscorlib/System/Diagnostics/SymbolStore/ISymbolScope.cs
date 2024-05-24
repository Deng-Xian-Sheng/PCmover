using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000401 RID: 1025
	[ComVisible(true)]
	public interface ISymbolScope
	{
		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x060033B7 RID: 13239
		ISymbolMethod Method { get; }

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x060033B8 RID: 13240
		ISymbolScope Parent { get; }

		// Token: 0x060033B9 RID: 13241
		ISymbolScope[] GetChildren();

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x060033BA RID: 13242
		int StartOffset { get; }

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x060033BB RID: 13243
		int EndOffset { get; }

		// Token: 0x060033BC RID: 13244
		ISymbolVariable[] GetLocals();

		// Token: 0x060033BD RID: 13245
		ISymbolNamespace[] GetNamespaces();
	}
}
