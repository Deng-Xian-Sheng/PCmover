using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FF RID: 1023
	[ComVisible(true)]
	public interface ISymbolNamespace
	{
		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x060033AA RID: 13226
		string Name { get; }

		// Token: 0x060033AB RID: 13227
		ISymbolNamespace[] GetNamespaces();

		// Token: 0x060033AC RID: 13228
		ISymbolVariable[] GetVariables();
	}
}
