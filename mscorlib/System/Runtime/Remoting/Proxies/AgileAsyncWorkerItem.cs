using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Proxies
{
	// Token: 0x02000802 RID: 2050
	internal class AgileAsyncWorkerItem
	{
		// Token: 0x06005865 RID: 22629 RVA: 0x00137D77 File Offset: 0x00135F77
		[SecurityCritical]
		public AgileAsyncWorkerItem(IMethodCallMessage message, AsyncResult ar, object target)
		{
			this._message = new MethodCall(message);
			this._ar = ar;
			this._target = target;
		}

		// Token: 0x06005866 RID: 22630 RVA: 0x00137D99 File Offset: 0x00135F99
		[SecurityCritical]
		public static void ThreadPoolCallBack(object o)
		{
			((AgileAsyncWorkerItem)o).DoAsyncCall();
		}

		// Token: 0x06005867 RID: 22631 RVA: 0x00137DA6 File Offset: 0x00135FA6
		[SecurityCritical]
		public void DoAsyncCall()
		{
			new StackBuilderSink(this._target).AsyncProcessMessage(this._message, this._ar);
		}

		// Token: 0x04002847 RID: 10311
		private IMethodCallMessage _message;

		// Token: 0x04002848 RID: 10312
		private AsyncResult _ar;

		// Token: 0x04002849 RID: 10313
		private object _target;
	}
}
