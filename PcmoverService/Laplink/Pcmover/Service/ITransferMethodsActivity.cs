using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000011 RID: 17
	public interface ITransferMethodsActivity
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000057 RID: 87
		IEnumerable<ServiceTransferMethod> ActivityServiceTransferMethods { get; }
	}
}
