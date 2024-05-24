using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F0 RID: 2288
	internal static class AsyncTaskCache
	{
		// Token: 0x06005E27 RID: 24103 RVA: 0x0014AE70 File Offset: 0x00149070
		private static Task<int>[] CreateInt32Tasks()
		{
			Task<int>[] array = new Task<int>[10];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = AsyncTaskCache.CreateCacheableTask<int>(i + -1);
			}
			return array;
		}

		// Token: 0x06005E28 RID: 24104 RVA: 0x0014AEA0 File Offset: 0x001490A0
		internal static Task<TResult> CreateCacheableTask<TResult>(TResult result)
		{
			return new Task<TResult>(false, result, (TaskCreationOptions)16384, default(CancellationToken));
		}

		// Token: 0x04002A47 RID: 10823
		internal static readonly Task<bool> TrueTask = AsyncTaskCache.CreateCacheableTask<bool>(true);

		// Token: 0x04002A48 RID: 10824
		internal static readonly Task<bool> FalseTask = AsyncTaskCache.CreateCacheableTask<bool>(false);

		// Token: 0x04002A49 RID: 10825
		internal static readonly Task<int>[] Int32Tasks = AsyncTaskCache.CreateInt32Tasks();

		// Token: 0x04002A4A RID: 10826
		internal const int INCLUSIVE_INT32_MIN = -1;

		// Token: 0x04002A4B RID: 10827
		internal const int EXCLUSIVE_INT32_MAX = 9;
	}
}
