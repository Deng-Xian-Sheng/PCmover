using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006AB RID: 1707
	internal struct StoreTransactionOperation
	{
		// Token: 0x0400225D RID: 8797
		[MarshalAs(UnmanagedType.U4)]
		public StoreTransactionOperationType Operation;

		// Token: 0x0400225E RID: 8798
		public StoreTransactionData Data;
	}
}
