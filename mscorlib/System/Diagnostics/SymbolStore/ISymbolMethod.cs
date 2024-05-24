using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FE RID: 1022
	[ComVisible(true)]
	public interface ISymbolMethod
	{
		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x060033A0 RID: 13216
		SymbolToken Token { get; }

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x060033A1 RID: 13217
		int SequencePointCount { get; }

		// Token: 0x060033A2 RID: 13218
		void GetSequencePoints(int[] offsets, ISymbolDocument[] documents, int[] lines, int[] columns, int[] endLines, int[] endColumns);

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x060033A3 RID: 13219
		ISymbolScope RootScope { get; }

		// Token: 0x060033A4 RID: 13220
		ISymbolScope GetScope(int offset);

		// Token: 0x060033A5 RID: 13221
		int GetOffset(ISymbolDocument document, int line, int column);

		// Token: 0x060033A6 RID: 13222
		int[] GetRanges(ISymbolDocument document, int line, int column);

		// Token: 0x060033A7 RID: 13223
		ISymbolVariable[] GetParameters();

		// Token: 0x060033A8 RID: 13224
		ISymbolNamespace GetNamespace();

		// Token: 0x060033A9 RID: 13225
		bool GetSourceStartEnd(ISymbolDocument[] docs, int[] lines, int[] columns);
	}
}
