using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000021 RID: 33
	public class ServiceMachineComparer : EqualityComparer<ServiceMachine>
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x0000F280 File Offset: 0x0000D480
		public override int GetHashCode(ServiceMachine serviceMachine)
		{
			return serviceMachine.PcmMachine.Id.GetHashCode();
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000F2A0 File Offset: 0x0000D4A0
		public override bool Equals(ServiceMachine machine1, ServiceMachine machine2)
		{
			return machine1.PcmMachine.Id == machine2.PcmMachine.Id;
		}
	}
}
