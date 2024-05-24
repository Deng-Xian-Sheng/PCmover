using System;
using System.Collections.Generic;
using Laplink.Service.Infrastructure;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000025 RID: 37
	public class ServiceTaskHandleManager : HandleManager<ServiceTask>
	{
		// Token: 0x060001FD RID: 509 RVA: 0x0000F7DA File Offset: 0x0000D9DA
		public ServiceTaskHandleManager(int startHandle, PcmoverManager manager) : base(startHandle, new ServiceTaskComparer())
		{
			this._manager = manager;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000F7F0 File Offset: 0x0000D9F0
		public ServiceTask FindTask(IPcmTask pcmTask)
		{
			if (pcmTask != null)
			{
				ulong id = pcmTask.Id;
				Dictionary<int, ServiceTask> dict = base.Dict;
				lock (dict)
				{
					foreach (ServiceTask serviceTask in base.Dict.Values)
					{
						if (serviceTask.Task.Id == id)
						{
							return serviceTask;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000F88C File Offset: 0x0000DA8C
		public ServiceTask FindTask(Machine machine)
		{
			if (machine != null)
			{
				Dictionary<int, ServiceTask> dict = base.Dict;
				lock (dict)
				{
					foreach (ServiceTask serviceTask in base.Dict.Values)
					{
						if (serviceTask.ContainsMachine(machine))
						{
							return serviceTask;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000F91C File Offset: 0x0000DB1C
		public ServiceTask AddTask(IPcmTask pcmTask, ServiceMachine srcServiceMachine, ServiceMachine dstServiceMachine)
		{
			if (pcmTask == null)
			{
				return null;
			}
			ServiceTask serviceTask = this.FindTask(pcmTask);
			if (serviceTask != null)
			{
				return serviceTask;
			}
			serviceTask = new ServiceTask(this._manager, pcmTask, srcServiceMachine, dstServiceMachine);
			int handle = base.Add(serviceTask);
			serviceTask.Handle = handle;
			return serviceTask;
		}

		// Token: 0x04000091 RID: 145
		private readonly PcmoverManager _manager;
	}
}
