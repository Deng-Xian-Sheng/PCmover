using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CefSharp.Internals.Tasks;
using CefSharp.JavascriptBinding;

namespace CefSharp.Internals
{
	// Token: 0x020000E1 RID: 225
	public sealed class MethodRunnerQueue : IMethodRunnerQueue, IDisposable
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060006D3 RID: 1747 RVA: 0x0000B094 File Offset: 0x00009294
		// (remove) Token: 0x060006D4 RID: 1748 RVA: 0x0000B0CC File Offset: 0x000092CC
		public event EventHandler<MethodInvocationCompleteArgs> MethodInvocationComplete;

		// Token: 0x060006D5 RID: 1749 RVA: 0x0000B101 File Offset: 0x00009301
		public MethodRunnerQueue(IJavascriptObjectRepositoryInternal repository)
		{
			this.repository = repository;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x0000B127 File Offset: 0x00009327
		public void Dispose()
		{
			this.cancellationTokenSource.Cancel();
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0000B134 File Offset: 0x00009334
		public void Enqueue(MethodInvocation methodInvocation)
		{
			if (this.cancellationTokenSource.IsCancellationRequested)
			{
				return;
			}
			Task.Factory.StartNew(delegate()
			{
				if (this.cancellationTokenSource.IsCancellationRequested)
				{
					return;
				}
				MethodInvocationResult result = this.ExecuteMethodInvocation(methodInvocation);
				EventHandler<MethodInvocationCompleteArgs> methodInvocationComplete = this.MethodInvocationComplete;
				if (!this.cancellationTokenSource.Token.IsCancellationRequested && methodInvocationComplete != null)
				{
					methodInvocationComplete(this, new MethodInvocationCompleteArgs(result));
				}
			}, this.cancellationTokenSource.Token, TaskCreationOptions.HideScheduler, this.taskScheduler);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x0000B190 File Offset: 0x00009390
		private MethodInvocationResult ExecuteMethodInvocation(MethodInvocation methodInvocation)
		{
			object obj = null;
			bool flag = false;
			IJavascriptNameConverter nameConverter = this.repository.NameConverter;
			string message;
			try
			{
				TryCallMethodResult tryCallMethodResult = this.repository.TryCallMethod(methodInvocation.ObjectId, methodInvocation.MethodName, methodInvocation.Parameters.ToArray());
				flag = tryCallMethodResult.Success;
				obj = tryCallMethodResult.ReturnValue;
				message = tryCallMethodResult.Exception;
				if (flag && obj != null && typeof(Task).IsAssignableFrom(obj.GetType()))
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("Your method returned a Task which is not supported by default you must set CefSharpSettings.ConcurrentTaskExecution = true; before creating your first ChromiumWebBrowser instance.");
					stringBuilder.AppendLine("This will likely change to the default at some point in the near future, subscribe to the issue link below to be notified of any changes.");
					stringBuilder.AppendLine("See https://github.com/cefsharp/CefSharp/issues/2758 for more details, please report any issues you have there, make sure you have an example ready that reproduces your problem.");
					flag = false;
					message = stringBuilder.ToString();
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return new MethodInvocationResult
			{
				BrowserId = methodInvocation.BrowserId,
				CallbackId = methodInvocation.CallbackId,
				FrameId = methodInvocation.FrameId,
				Message = message,
				Result = obj,
				Success = flag,
				NameConverter = nameConverter
			};
		}

		// Token: 0x04000381 RID: 897
		private readonly LimitedConcurrencyLevelTaskScheduler taskScheduler = new LimitedConcurrencyLevelTaskScheduler(1);

		// Token: 0x04000382 RID: 898
		private readonly IJavascriptObjectRepositoryInternal repository;

		// Token: 0x04000383 RID: 899
		private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	}
}
