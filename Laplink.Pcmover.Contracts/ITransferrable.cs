using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000086 RID: 134
	public interface ITransferrable
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000384 RID: 900
		// (set) Token: 0x06000385 RID: 901
		Transferrable Transferrable { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000386 RID: 902
		// (set) Token: 0x06000387 RID: 903
		string Target { get; set; }
	}
}
