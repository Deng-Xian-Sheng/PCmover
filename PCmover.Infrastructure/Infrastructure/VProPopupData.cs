using System;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;

namespace PCmover.Infrastructure
{
	// Token: 0x02000041 RID: 65
	public class VProPopupData
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00008A1F File Offset: 0x00006C1F
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00008A27 File Offset: 0x00006C27
		public DefaultPolicy policy { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000345 RID: 837 RVA: 0x00008A30 File Offset: 0x00006C30
		// (set) Token: 0x06000346 RID: 838 RVA: 0x00008A38 File Offset: 0x00006C38
		public LlTraceSource TS { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000347 RID: 839 RVA: 0x00008A41 File Offset: 0x00006C41
		public TaskCompletionSource<ConnectableMachine> SelectedMachineTcs { get; } = new TaskCompletionSource<ConnectableMachine>();
	}
}
