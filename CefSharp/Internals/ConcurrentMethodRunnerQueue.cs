using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CefSharp.Internals
{
	// Token: 0x020000C7 RID: 199
	public sealed class ConcurrentMethodRunnerQueue : IMethodRunnerQueue, IDisposable
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060005E4 RID: 1508 RVA: 0x000097E4 File Offset: 0x000079E4
		// (remove) Token: 0x060005E5 RID: 1509 RVA: 0x0000981C File Offset: 0x00007A1C
		public event EventHandler<MethodInvocationCompleteArgs> MethodInvocationComplete;

		// Token: 0x060005E6 RID: 1510 RVA: 0x00009851 File Offset: 0x00007A51
		public ConcurrentMethodRunnerQueue(IJavascriptObjectRepositoryInternal repository)
		{
			this.repository = repository;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0000986B File Offset: 0x00007A6B
		public void Dispose()
		{
			this.MethodInvocationComplete = null;
			this.cancellationTokenSource.Cancel();
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00009880 File Offset: 0x00007A80
		public void Enqueue(MethodInvocation methodInvocation)
		{
			ConcurrentMethodRunnerQueue.<>c__DisplayClass8_0 CS$<>8__locals1 = new ConcurrentMethodRunnerQueue.<>c__DisplayClass8_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.methodInvocation = methodInvocation;
			if (this.cancellationTokenSource.IsCancellationRequested)
			{
				return;
			}
			Task.Run(delegate()
			{
				ConcurrentMethodRunnerQueue.<>c__DisplayClass8_0.<<Enqueue>b__0>d <<Enqueue>b__0>d;
				<<Enqueue>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<Enqueue>b__0>d.<>4__this = CS$<>8__locals1;
				<<Enqueue>b__0>d.<>1__state = -1;
				<<Enqueue>b__0>d.<>t__builder.Start<ConcurrentMethodRunnerQueue.<>c__DisplayClass8_0.<<Enqueue>b__0>d>(ref <<Enqueue>b__0>d);
				return <<Enqueue>b__0>d.<>t__builder.Task;
			}, this.cancellationTokenSource.Token);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x000098CC File Offset: 0x00007ACC
		private Task<MethodInvocationResult> ExecuteMethodInvocation(MethodInvocation methodInvocation)
		{
			ConcurrentMethodRunnerQueue.<ExecuteMethodInvocation>d__9 <ExecuteMethodInvocation>d__;
			<ExecuteMethodInvocation>d__.<>t__builder = AsyncTaskMethodBuilder<MethodInvocationResult>.Create();
			<ExecuteMethodInvocation>d__.<>4__this = this;
			<ExecuteMethodInvocation>d__.methodInvocation = methodInvocation;
			<ExecuteMethodInvocation>d__.<>1__state = -1;
			<ExecuteMethodInvocation>d__.<>t__builder.Start<ConcurrentMethodRunnerQueue.<ExecuteMethodInvocation>d__9>(ref <ExecuteMethodInvocation>d__);
			return <ExecuteMethodInvocation>d__.<>t__builder.Task;
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00009917 File Offset: 0x00007B17
		private void OnMethodInvocationComplete(MethodInvocationResult e, CancellationToken token)
		{
			if (!token.IsCancellationRequested)
			{
				EventHandler<MethodInvocationCompleteArgs> methodInvocationComplete = this.MethodInvocationComplete;
				if (methodInvocationComplete == null)
				{
					return;
				}
				methodInvocationComplete(this, new MethodInvocationCompleteArgs(e));
			}
		}

		// Token: 0x0400033B RID: 827
		private static readonly Type VoidTaskResultType = Type.GetType("System.Threading.Tasks.VoidTaskResult");

		// Token: 0x0400033C RID: 828
		private readonly IJavascriptObjectRepositoryInternal repository;

		// Token: 0x0400033D RID: 829
		private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	}
}
