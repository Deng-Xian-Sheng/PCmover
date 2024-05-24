using System;
using CefSharp.ModelBinding;

namespace CefSharp
{
	// Token: 0x02000048 RID: 72
	public class JavascriptMessageReceivedEventArgs : EventArgs
	{
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000FF RID: 255 RVA: 0x000033ED File Offset: 0x000015ED
		// (set) Token: 0x06000100 RID: 256 RVA: 0x000033F5 File Offset: 0x000015F5
		public IFrame Frame { get; private set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000101 RID: 257 RVA: 0x000033FE File Offset: 0x000015FE
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00003406 File Offset: 0x00001606
		public IBrowser Browser { get; private set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000103 RID: 259 RVA: 0x0000340F File Offset: 0x0000160F
		// (set) Token: 0x06000104 RID: 260 RVA: 0x00003417 File Offset: 0x00001617
		public object Message { get; private set; }

		// Token: 0x06000105 RID: 261 RVA: 0x00003420 File Offset: 0x00001620
		public JavascriptMessageReceivedEventArgs(IBrowser browser, IFrame frame, object message)
		{
			this.Browser = browser;
			this.Frame = frame;
			this.Message = message;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00003440 File Offset: 0x00001640
		public T ConvertMessageTo<T>()
		{
			if (this.Message == null)
			{
				return default(T);
			}
			return (T)((object)JavascriptMessageReceivedEventArgs.Binder.Bind(this.Message, typeof(T)));
		}

		// Token: 0x04000256 RID: 598
		private static readonly IBinder Binder = new DefaultBinder(null);
	}
}
