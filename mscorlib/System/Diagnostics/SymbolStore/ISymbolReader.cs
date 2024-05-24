using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000400 RID: 1024
	[ComVisible(true)]
	public interface ISymbolReader
	{
		// Token: 0x060033AD RID: 13229
		ISymbolDocument GetDocument(string url, Guid language, Guid languageVendor, Guid documentType);

		// Token: 0x060033AE RID: 13230
		ISymbolDocument[] GetDocuments();

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x060033AF RID: 13231
		SymbolToken UserEntryPoint { get; }

		// Token: 0x060033B0 RID: 13232
		ISymbolMethod GetMethod(SymbolToken method);

		// Token: 0x060033B1 RID: 13233
		ISymbolMethod GetMethod(SymbolToken method, int version);

		// Token: 0x060033B2 RID: 13234
		ISymbolVariable[] GetVariables(SymbolToken parent);

		// Token: 0x060033B3 RID: 13235
		ISymbolVariable[] GetGlobalVariables();

		// Token: 0x060033B4 RID: 13236
		ISymbolMethod GetMethodFromDocumentPosition(ISymbolDocument document, int line, int column);

		// Token: 0x060033B5 RID: 13237
		byte[] GetSymAttribute(SymbolToken parent, string name);

		// Token: 0x060033B6 RID: 13238
		ISymbolNamespace[] GetNamespaces();
	}
}
