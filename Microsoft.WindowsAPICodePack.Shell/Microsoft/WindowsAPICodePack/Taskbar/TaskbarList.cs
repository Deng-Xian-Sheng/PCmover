using System;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000186 RID: 390
	internal static class TaskbarList
	{
		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00035334 File Offset: 0x00033534
		internal static ITaskbarList4 Instance
		{
			get
			{
				if (TaskbarList._taskbarList == null)
				{
					lock (TaskbarList._syncLock)
					{
						if (TaskbarList._taskbarList == null)
						{
							TaskbarList._taskbarList = (ITaskbarList4)new CTaskbarList();
							TaskbarList._taskbarList.HrInit();
						}
					}
				}
				return TaskbarList._taskbarList;
			}
		}

		// Token: 0x04000670 RID: 1648
		private static object _syncLock = new object();

		// Token: 0x04000671 RID: 1649
		private static ITaskbarList4 _taskbarList;
	}
}
