using System;
using Laplink.Pcmover.Contracts;

namespace WizardModule.ViewModels
{
	// Token: 0x02000088 RID: 136
	public class FindPCTimerEventArgs : EventArgs
	{
		// Token: 0x0600096C RID: 2412 RVA: 0x00016811 File Offset: 0x00014A11
		public FindPCTimerEventArgs(ConnectableMachine machine)
		{
			this.Machine = machine;
		}

		// Token: 0x040002C6 RID: 710
		public readonly ConnectableMachine Machine;
	}
}
