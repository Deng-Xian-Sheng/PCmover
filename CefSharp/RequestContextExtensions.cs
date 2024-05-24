using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CefSharp.Internals;
using CefSharp.Preferences;
using CefSharp.SchemeHandler;

namespace CefSharp
{
	// Token: 0x0200008E RID: 142
	public static class RequestContextExtensions
	{
		// Token: 0x060003FA RID: 1018 RVA: 0x00003E42 File Offset: 0x00002042
		public static void LoadExtensionFromDirectory(this IRequestContext requestContext, string rootDirectory, IExtensionHandler handler)
		{
			requestContext.LoadExtension(Path.GetFullPath(rootDirectory), null, handler);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00003E54 File Offset: 0x00002054
		public static void LoadExtensionsFromDirectory(this IRequestContext requestContext, string rootDirectory, IExtensionHandler handler)
		{
			string fullPath = Path.GetFullPath(rootDirectory);
			foreach (string text in Directory.GetDirectories(fullPath))
			{
				if (File.Exists(Path.Combine(text, "manifest.json")))
				{
					requestContext.LoadExtension(text, null, handler);
				}
			}
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00003E9C File Offset: 0x0000209C
		public static Task<ICookieManager> GetCookieManagerAsync(this IRequestContext requestContext)
		{
			RequestContextExtensions.<GetCookieManagerAsync>d__3 <GetCookieManagerAsync>d__;
			<GetCookieManagerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ICookieManager>.Create();
			<GetCookieManagerAsync>d__.requestContext = requestContext;
			<GetCookieManagerAsync>d__.<>1__state = -1;
			<GetCookieManagerAsync>d__.<>t__builder.Start<RequestContextExtensions.<GetCookieManagerAsync>d__3>(ref <GetCookieManagerAsync>d__);
			return <GetCookieManagerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00003EE0 File Offset: 0x000020E0
		public static Task<SetPreferenceResponse> SetPreferenceAsync(this IRequestContext requestContext, string name, object value)
		{
			if (CefThread.HasShutdown)
			{
				return Task.FromResult<SetPreferenceResponse>(new SetPreferenceResponse(false, "Cef.Shutdown has already been called, it is no longer possible to call SetPreferenceAsync."));
			}
			Func<SetPreferenceResponse> func = delegate()
			{
				string errorMessage;
				bool success = requestContext.SetPreference(name, value, out errorMessage);
				return new SetPreferenceResponse(success, errorMessage);
			};
			if (CefThread.CurrentlyOnUiThread)
			{
				return Task.FromResult<SetPreferenceResponse>(func());
			}
			return CefThread.ExecuteOnUiThread<SetPreferenceResponse>(func);
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00003F46 File Offset: 0x00002146
		public static Task<SetProxyResponse> SetProxyAsync(this IRequestContext requestContext, string host, int? port)
		{
			return requestContext.SetProxyAsync(null, host, port);
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x00003F54 File Offset: 0x00002154
		public static Task<SetProxyResponse> SetProxyAsync(this IRequestContext requestContext, string scheme, string host, int? port)
		{
			if (CefThread.HasShutdown)
			{
				return Task.FromResult<SetProxyResponse>(new SetProxyResponse(false, "Cef.Shutdown has already been called, it is no longer possible to call SetProxyAsync."));
			}
			Func<SetProxyResponse> func = delegate()
			{
				bool success = false;
				string errorMessage;
				if (requestContext.CanSetPreference("proxy"))
				{
					IDictionary<string, object> proxyDictionary = RequestContextExtensions.GetProxyDictionary(scheme, host, port);
					success = requestContext.SetPreference("proxy", proxyDictionary, out errorMessage);
				}
				else
				{
					errorMessage = "Unable to set the proxy preference, it is read-only. If you specified the proxy settings with command line args it is not possible to change the proxy settings via this method.";
				}
				return new SetProxyResponse(success, errorMessage);
			};
			if (CefThread.CurrentlyOnUiThread)
			{
				return Task.FromResult<SetProxyResponse>(func());
			}
			return CefThread.ExecuteOnUiThread<SetProxyResponse>(func);
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x00003FC4 File Offset: 0x000021C4
		public static bool SetProxy(this IRequestContext requestContext, string scheme, string host, int? port, out string errorMessage)
		{
			IDictionary<string, object> proxyDictionary = RequestContextExtensions.GetProxyDictionary(scheme, host, port);
			if (requestContext.CanSetPreference("proxy"))
			{
				return requestContext.SetPreference("proxy", proxyDictionary, out errorMessage);
			}
			throw new Exception("Unable to set the proxy preference, it is read-only. If you specified the proxy settings with command line args it is not possible to change the proxy settings via this method.");
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00004000 File Offset: 0x00002200
		public static bool SetProxy(this IRequestContext requestContext, string host, int? port, out string errorMessage)
		{
			return requestContext.SetProxy(null, host, port, out errorMessage);
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0000400C File Offset: 0x0000220C
		public static bool SetProxy(this IRequestContext requestContext, string host, out string errorMessage)
		{
			return requestContext.SetProxy(null, host, null, out errorMessage);
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000402C File Offset: 0x0000222C
		public static IDictionary<string, object> GetProxyDictionary(string scheme, string host, int? port)
		{
			if (string.IsNullOrWhiteSpace(scheme))
			{
				scheme = "http";
			}
			if (!RequestContextExtensions.ProxySchemes.Contains(scheme.ToLower()))
			{
				throw new ArgumentException("Invalid Scheme, see https://bitbucket.org/chromiumembedded/cef/wiki/GeneralUsage.md#markdown-header-proxy-resolution for a list of valid schemes.", "scheme");
			}
			if (string.IsNullOrWhiteSpace(host))
			{
				throw new ArgumentException("Cannot be null or empty", "host");
			}
			if (port != null)
			{
				int? num = port;
				int num2 = 0;
				if (!(num.GetValueOrDefault() < num2 & num != null))
				{
					num = port;
					num2 = 65535;
					if (!(num.GetValueOrDefault() > num2 & num != null))
					{
						goto IL_9C;
					}
				}
				throw new ArgumentOutOfRangeException("port", port, "Invalid TCP Port");
			}
			IL_9C:
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["mode"] = "fixed_servers";
			string key = "server";
			string str = scheme;
			string str2 = "://";
			string str3;
			if (port == null)
			{
				str3 = "";
			}
			else
			{
				string str4 = ":";
				int? num = port;
				str3 = str4 + num.ToString();
			}
			dictionary[key] = str + str2 + host + str3;
			return dictionary;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000412C File Offset: 0x0000232C
		public static Task<bool> ClearHttpAuthCredentialsAsync(this IRequestContext requestContext)
		{
			TaskCompletionCallback taskCompletionCallback = new TaskCompletionCallback();
			requestContext.ClearHttpAuthCredentials(taskCompletionCallback);
			return taskCompletionCallback.Task;
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x0000414C File Offset: 0x0000234C
		public static void RegisterOwinSchemeHandlerFactory(this IRequestContext requestContext, string schemeName, string domainName, Func<IDictionary<string, object>, Task> appFunc)
		{
			requestContext.RegisterSchemeHandlerFactory(schemeName, domainName, new OwinSchemeHandlerFactory(appFunc));
		}

		// Token: 0x040002A4 RID: 676
		private static string[] ProxySchemes = new string[]
		{
			"http",
			"socks",
			"socks4",
			"socks5"
		};
	}
}
