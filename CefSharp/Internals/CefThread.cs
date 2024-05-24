using System;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000C3 RID: 195
	public static class CefThread
	{
		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x000094E1 File Offset: 0x000076E1
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x000094E8 File Offset: 0x000076E8
		public static TaskFactory UiThreadTaskFactory { get; private set; }

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060005D2 RID: 1490 RVA: 0x000094F0 File Offset: 0x000076F0
		// (remove) Token: 0x060005D3 RID: 1491 RVA: 0x00009524 File Offset: 0x00007724
		public static event EventHandler Initialized;

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00009557 File Offset: 0x00007757
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x0000955E File Offset: 0x0000775E
		public static Func<bool> CurrentOnUiThreadDelegate { get; private set; }

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00009566 File Offset: 0x00007766
		public static bool CanExecuteOnUiThread
		{
			get
			{
				return CefThread.UiThreadTaskFactory != null;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00009570 File Offset: 0x00007770
		public static bool CurrentlyOnUiThread
		{
			get
			{
				Func<bool> currentOnUiThreadDelegate = CefThread.CurrentOnUiThreadDelegate;
				return currentOnUiThreadDelegate != null && currentOnUiThreadDelegate();
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x0000958E File Offset: 0x0000778E
		// (set) Token: 0x060005D9 RID: 1497 RVA: 0x00009595 File Offset: 0x00007795
		public static bool HasShutdown { get; private set; }

		// Token: 0x060005DA RID: 1498 RVA: 0x000095A0 File Offset: 0x000077A0
		public static Task<TResult> ExecuteOnUiThread<TResult>(Func<TResult> function)
		{
			object lockObj = CefThread.LockObj;
			Task<TResult> result;
			lock (lockObj)
			{
				if (CefThread.HasShutdown)
				{
					throw new Exception("Cef.Shutdown has already been called, it's no longer possible to execute on the CEF UI Thread. Check CefThread.HasShutdown to guard against this execption");
				}
				TaskFactory uiThreadTaskFactory = CefThread.UiThreadTaskFactory;
				if (uiThreadTaskFactory == null)
				{
					result = CefThread.QueueForExcutionWhenUiThreadCreated<TResult>(function);
				}
				else
				{
					result = uiThreadTaskFactory.StartNew<TResult>(function);
				}
			}
			return result;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00009608 File Offset: 0x00007808
		private static Task<T> QueueForExcutionWhenUiThreadCreated<T>(Func<T> func)
		{
			TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
			EventHandler handler = null;
			handler = delegate(object s, EventArgs args)
			{
				CefThread.Initialized -= handler;
				T result = func();
				tcs.SetResult(result);
			};
			CefThread.Initialized += handler;
			return tcs.Task;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0000965C File Offset: 0x0000785C
		public static void Initialize(TaskFactory uiThreadTaskFactory, Func<bool> currentOnUiThreadDelegate)
		{
			object lockObj = CefThread.LockObj;
			lock (lockObj)
			{
				EventHandler initialized = CefThread.Initialized;
				if (initialized != null)
				{
					initialized(null, EventArgs.Empty);
				}
				CefThread.UiThreadTaskFactory = uiThreadTaskFactory;
				CefThread.CurrentOnUiThreadDelegate = currentOnUiThreadDelegate;
			}
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000096B8 File Offset: 0x000078B8
		public static void Shutdown()
		{
			object lockObj = CefThread.LockObj;
			lock (lockObj)
			{
				CefThread.CurrentOnUiThreadDelegate = null;
				CefThread.Initialized = null;
				CefThread.UiThreadTaskFactory = null;
				CefThread.HasShutdown = true;
			}
		}

		// Token: 0x04000336 RID: 822
		private static readonly object LockObj = new object();
	}
}
