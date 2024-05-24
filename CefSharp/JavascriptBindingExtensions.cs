using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.Event;

namespace CefSharp
{
	// Token: 0x02000083 RID: 131
	public static class JavascriptBindingExtensions
	{
		// Token: 0x06000398 RID: 920 RVA: 0x000037B4 File Offset: 0x000019B4
		public static Task<IList<string>> EnsureObjectBoundAsync(this IWebBrowser browser, params string[] names)
		{
			TaskCompletionSource<IList<string>> objBoundTasks = new TaskCompletionSource<IList<string>>();
			EventHandler<JavascriptBindingMultipleCompleteEventArgs> handler = null;
			handler = delegate(object sender, JavascriptBindingMultipleCompleteEventArgs args)
			{
				browser.JavascriptObjectRepository.ObjectsBoundInJavascript -= handler;
				bool flag = names.ToList<string>().SequenceEqual(args.ObjectNames);
				if (flag)
				{
					objBoundTasks.SetResult(args.ObjectNames);
					return;
				}
				objBoundTasks.SetException(new Exception("Not all objects were bound successfully, bound objects were " + string.Join(",", args.ObjectNames)));
			};
			browser.JavascriptObjectRepository.ObjectsBoundInJavascript += handler;
			string script = "(function() { CefSharp.BindObjectAsync({ NotifyIfAlreadyBound: true, IgnoreCache: false }, '" + string.Join("', '", names) + "'); })();";
			browser.ExecuteScriptAsync(script);
			return objBoundTasks.Task;
		}
	}
}
