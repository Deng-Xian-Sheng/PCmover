using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics.SymbolStore
{
	// Token: 0x02000402 RID: 1026
	[ComVisible(true)]
	public interface ISymbolVariable
	{
		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x060033BE RID: 13246
		string Name { get; }

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x060033BF RID: 13247
		object Attributes { get; }

		// Token: 0x060033C0 RID: 13248
		byte[] GetSignature();

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x060033C1 RID: 13249
		SymAddressKind AddressKind { get; }

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x060033C2 RID: 13250
		int AddressField1 { get; }

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x060033C3 RID: 13251
		int AddressField2 { get; }

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x060033C4 RID: 13252
		int AddressField3 { get; }

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060033C5 RID: 13253
		int StartOffset { get; }

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x060033C6 RID: 13254
		int EndOffset { get; }
	}
}
