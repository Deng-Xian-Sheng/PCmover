using System;
using System.Threading;

namespace PCmover.ViewModels
{
	// Token: 0x0200000A RID: 10
	public class AuthenticationData
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002EAE File Offset: 0x000010AE
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002EB6 File Offset: 0x000010B6
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002EBF File Offset: 0x000010BF
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002EC7 File Offset: 0x000010C7
		public bool IsAuthenticated { get; set; }
	}
}
