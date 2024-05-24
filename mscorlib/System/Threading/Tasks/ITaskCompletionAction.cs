using System;

namespace System.Threading.Tasks
{
	// Token: 0x02000567 RID: 1383
	internal interface ITaskCompletionAction
	{
		// Token: 0x06004158 RID: 16728
		void Invoke(Task completingTask);
	}
}
