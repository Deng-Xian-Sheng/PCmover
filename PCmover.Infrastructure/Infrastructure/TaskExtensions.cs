using System;
using System.Threading.Tasks;

namespace PCmover.Infrastructure
{
	// Token: 0x02000038 RID: 56
	public static class TaskExtensions
	{
		// Token: 0x060002D1 RID: 721 RVA: 0x000081D2 File Offset: 0x000063D2
		public static void Forget(this Task task)
		{
			task.ContinueWith(delegate(Task t)
			{
				throw t.Exception;
			}, TaskContinuationOptions.OnlyOnFaulted);
		}
	}
}
