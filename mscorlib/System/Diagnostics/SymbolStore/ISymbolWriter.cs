using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000403 RID: 1027
	[ComVisible(true)]
	public interface ISymbolWriter
	{
		// Token: 0x060033C7 RID: 13255
		void Initialize(IntPtr emitter, string filename, bool fFullBuild);

		// Token: 0x060033C8 RID: 13256
		ISymbolDocumentWriter DefineDocument(string url, Guid language, Guid languageVendor, Guid documentType);

		// Token: 0x060033C9 RID: 13257
		void SetUserEntryPoint(SymbolToken entryMethod);

		// Token: 0x060033CA RID: 13258
		void OpenMethod(SymbolToken method);

		// Token: 0x060033CB RID: 13259
		void CloseMethod();

		// Token: 0x060033CC RID: 13260
		void DefineSequencePoints(ISymbolDocumentWriter document, int[] offsets, int[] lines, int[] columns, int[] endLines, int[] endColumns);

		// Token: 0x060033CD RID: 13261
		int OpenScope(int startOffset);

		// Token: 0x060033CE RID: 13262
		void CloseScope(int endOffset);

		// Token: 0x060033CF RID: 13263
		void SetScopeRange(int scopeID, int startOffset, int endOffset);

		// Token: 0x060033D0 RID: 13264
		void DefineLocalVariable(string name, FieldAttributes attributes, byte[] signature, SymAddressKind addrKind, int addr1, int addr2, int addr3, int startOffset, int endOffset);

		// Token: 0x060033D1 RID: 13265
		void DefineParameter(string name, ParameterAttributes attributes, int sequence, SymAddressKind addrKind, int addr1, int addr2, int addr3);

		// Token: 0x060033D2 RID: 13266
		void DefineField(SymbolToken parent, string name, FieldAttributes attributes, byte[] signature, SymAddressKind addrKind, int addr1, int addr2, int addr3);

		// Token: 0x060033D3 RID: 13267
		void DefineGlobalVariable(string name, FieldAttributes attributes, byte[] signature, SymAddressKind addrKind, int addr1, int addr2, int addr3);

		// Token: 0x060033D4 RID: 13268
		void Close();

		// Token: 0x060033D5 RID: 13269
		void SetSymAttribute(SymbolToken parent, string name, byte[] data);

		// Token: 0x060033D6 RID: 13270
		void OpenNamespace(string name);

		// Token: 0x060033D7 RID: 13271
		void CloseNamespace();

		// Token: 0x060033D8 RID: 13272
		void UsingNamespace(string fullName);

		// Token: 0x060033D9 RID: 13273
		void SetMethodSourceRange(ISymbolDocumentWriter startDoc, int startLine, int startColumn, ISymbolDocumentWriter endDoc, int endLine, int endColumn);

		// Token: 0x060033DA RID: 13274
		void SetUnderlyingWriter(IntPtr underlyingWriter);
	}
}
