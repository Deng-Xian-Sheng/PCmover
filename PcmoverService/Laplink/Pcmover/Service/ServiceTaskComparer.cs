using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000024 RID: 36
	public class ServiceTaskComparer : EqualityComparer<ServiceTask>
	{
		// Token: 0x060001FA RID: 506 RVA: 0x0000F798 File Offset: 0x0000D998
		public override int GetHashCode(ServiceTask serviceTask)
		{
			return serviceTask.Task.Id.GetHashCode();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000F7B8 File Offset: 0x0000D9B8
		public override bool Equals(ServiceTask task1, ServiceTask task2)
		{
			return task1.Task.Id == task2.Task.Id;
		}
	}
}
