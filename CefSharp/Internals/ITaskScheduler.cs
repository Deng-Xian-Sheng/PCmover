using System;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000D6 RID: 214
	public interface ITaskScheduler
	{
		// Token: 0x06000637 RID: 1591
		void ExecuteTask(Task task);
	}
}
