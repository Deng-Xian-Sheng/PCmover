using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x020003FD RID: 1021
	[ComVisible(true)]
	public interface ISymbolDocumentWriter
	{
		// Token: 0x0600339E RID: 13214
		void SetSource(byte[] source);

		// Token: 0x0600339F RID: 13215
		void SetCheckSum(Guid algorithmId, byte[] checkSum);
	}
}
