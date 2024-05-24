using System;
using System.Collections.Generic;
using Laplink.Service.Infrastructure;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000022 RID: 34
	public class ServiceMachineHandleManager : HandleManager<ServiceMachine>
	{
		// Token: 0x060001E5 RID: 485 RVA: 0x0000F2C2 File Offset: 0x0000D4C2
		public ServiceMachineHandleManager(int startHandle) : base(startHandle, new ServiceMachineComparer())
		{
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
		public ServiceMachine FindMachine(Machine machine)
		{
			if (machine != null)
			{
				ulong id = machine.Id;
				Dictionary<int, ServiceMachine> dict = base.Dict;
				lock (dict)
				{
					foreach (ServiceMachine serviceMachine in base.Dict.Values)
					{
						if (serviceMachine.PcmMachine.Id == id)
						{
							return serviceMachine;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000F36C File Offset: 0x0000D56C
		public ServiceMachine AddMachine(Machine machine)
		{
			bool flag;
			return this.AddMachine(machine, out flag);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000F384 File Offset: 0x0000D584
		public ServiceMachine AddMachine(Machine machine, out bool added)
		{
			added = false;
			if (machine == null)
			{
				return null;
			}
			ServiceMachine serviceMachine = this.FindMachine(machine);
			if (serviceMachine != null)
			{
				return serviceMachine;
			}
			serviceMachine = new ServiceMachine(machine);
			serviceMachine.Handle = base.Add(serviceMachine);
			added = true;
			return serviceMachine;
		}
	}
}
