using System;
using System.Threading;

namespace PCmover.ViewModels
{
	// Token: 0x0200000C RID: 12
	public class RecordedPolicyPromptData
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003474 File Offset: 0x00001674
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000347C File Offset: 0x0000167C
		public AutoResetEvent ResetEvent { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003485 File Offset: 0x00001685
		// (set) Token: 0x06000086 RID: 134 RVA: 0x0000348D File Offset: 0x0000168D
		public bool UseRecorded { get; set; }
	}
}
