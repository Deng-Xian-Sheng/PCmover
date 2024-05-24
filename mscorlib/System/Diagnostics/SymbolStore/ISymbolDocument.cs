using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FC RID: 1020
	[ComVisible(true)]
	public interface ISymbolDocument
	{
		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06003394 RID: 13204
		string URL { get; }

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06003395 RID: 13205
		Guid DocumentType { get; }

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06003396 RID: 13206
		Guid Language { get; }

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06003397 RID: 13207
		Guid LanguageVendor { get; }

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06003398 RID: 13208
		Guid CheckSumAlgorithmId { get; }

		// Token: 0x06003399 RID: 13209
		byte[] GetCheckSum();

		// Token: 0x0600339A RID: 13210
		int FindClosestLine(int line);

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x0600339B RID: 13211
		bool HasEmbeddedSource { get; }

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x0600339C RID: 13212
		int SourceLength { get; }

		// Token: 0x0600339D RID: 13213
		byte[] GetSourceRange(int startLine, int startColumn, int endLine, int endColumn);
	}
}
