using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.Contracts;

namespace WizardModule.Migration
{
	// Token: 0x020000BB RID: 187
	public static class MachineHelpers
	{
		// Token: 0x06001000 RID: 4096 RVA: 0x00028ECA File Offset: 0x000270CA
		public static bool SameMachine(this ConnectableMachine left, ConnectableMachine right)
		{
			return left.NetName == right.NetName && left.Method == right.Method;
		}

		// Token: 0x06001001 RID: 4097 RVA: 0x00028EF0 File Offset: 0x000270F0
		public static int FindIndex<T>(this ObservableCollection<T> ts, Predicate<T> match)
		{
			for (int i = 0; i < ts.Count; i++)
			{
				if (match(ts[i]))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06001002 RID: 4098 RVA: 0x00028F20 File Offset: 0x00027120
		public static bool RemoveMachine(this ObservableCollection<ConnectableMachine> list, ConnectableMachine machine)
		{
			int num = list.FindIndex((ConnectableMachine x) => x.SameMachine(machine));
			if (num < 0)
			{
				return false;
			}
			if (list[num].Status == DiscoveredMachineStatus.MachineFound)
			{
				list.RemoveAt(num);
			}
			return true;
		}

		// Token: 0x06001003 RID: 4099 RVA: 0x00028F6C File Offset: 0x0002716C
		public static bool AddOrUpdateMachine(this ObservableCollection<ConnectableMachine> list, ConnectableMachine machine)
		{
			int num = list.FindIndex((ConnectableMachine x) => x.SameMachine(machine));
			if (num < 0)
			{
				if (machine.Status == DiscoveredMachineStatus.MachineFound)
				{
					list.Add(machine);
				}
				else
				{
					list.Insert(0, machine);
				}
				return true;
			}
			if (list[num].Status == DiscoveredMachineStatus.MachineFound || list[num].Status == machine.Status)
			{
				if (list[0].Status != DiscoveredMachineStatus.MachineFound || machine.Status == DiscoveredMachineStatus.MachineFound)
				{
					list[num] = machine;
				}
				else
				{
					if (num != 0)
					{
						list[num] = list[0];
					}
					list[0] = machine;
				}
			}
			return false;
		}
	}
}
