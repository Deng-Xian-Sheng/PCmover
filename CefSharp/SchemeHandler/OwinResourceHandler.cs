using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CefSharp.SchemeHandler
{
	// Token: 0x020000AD RID: 173
	public class OwinResourceHandler : ResourceHandler
	{
		// Token: 0x0600055A RID: 1370 RVA: 0x000085E8 File Offset: 0x000067E8
		public OwinResourceHandler(Func<IDictionary<string, object>, Task> appFunc) : base("text/html", null, false, null)
		{
			this.appFunc = appFunc;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00008600 File Offset: 0x00006800
		public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
		{
			OwinResourceHandler.<>c__DisplayClass3_0 CS$<>8__locals1 = new OwinResourceHandler.<>c__DisplayClass3_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.callback = callback;
			CS$<>8__locals1.responseStream = new MemoryStream();
			Stream value = Stream.Null;
			if (request.Method == "POST")
			{
				using (IPostData postData = request.PostData)
				{
					if (postData != null)
					{
						IList<IPostDataElement> elements = postData.Elements;
						IPostDataElement postDataElement = elements.First<IPostDataElement>();
						byte[] bytes = postDataElement.Bytes;
						value = new MemoryStream(bytes, 0, bytes.Length);
					}
				}
			}
			Uri uri = new Uri(request.Url);
			IDictionary<string, string[]> dictionary = OwinResourceHandler.ToDictionary(request.Headers);
			dictionary.Add("Host", new string[]
			{
				uri.Host + ((uri.Port > 0) ? (":" + uri.Port.ToString()) : "")
			});
			CS$<>8__locals1.owinEnvironment = new Dictionary<string, object>(StringComparer.Ordinal)
			{
				{
					"owin.RequestBody",
					value
				},
				{
					"owin.RequestHeaders",
					dictionary
				},
				{
					"owin.RequestMethod",
					request.Method
				},
				{
					"owin.RequestPath",
					uri.AbsolutePath
				},
				{
					"owin.RequestPathBase",
					"/"
				},
				{
					"owin.RequestProtocol",
					"HTTP/1.1"
				},
				{
					"owin.RequestQueryString",
					string.IsNullOrEmpty(uri.Query) ? string.Empty : uri.Query.Substring(1)
				},
				{
					"owin.RequestScheme",
					uri.Scheme
				},
				{
					"owin.ResponseHeaders",
					new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
				},
				{
					"owin.ResponseBody",
					CS$<>8__locals1.responseStream
				},
				{
					"owin.Version",
					"1.0.0"
				}
			};
			Task.Run(delegate()
			{
				OwinResourceHandler.<>c__DisplayClass3_0.<<ProcessRequestAsync>b__0>d <<ProcessRequestAsync>b__0>d;
				<<ProcessRequestAsync>b__0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
				<<ProcessRequestAsync>b__0>d.<>4__this = CS$<>8__locals1;
				<<ProcessRequestAsync>b__0>d.<>1__state = -1;
				<<ProcessRequestAsync>b__0>d.<>t__builder.Start<OwinResourceHandler.<>c__DisplayClass3_0.<<ProcessRequestAsync>b__0>d>(ref <<ProcessRequestAsync>b__0>d);
				return <<ProcessRequestAsync>b__0>d.<>t__builder.Task;
			});
			return CefReturnValue.ContinueAsync;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x000087E8 File Offset: 0x000069E8
		private static IDictionary<string, string[]> ToDictionary(NameValueCollection nameValueCollection)
		{
			Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);
			foreach (string text in nameValueCollection.AllKeys)
			{
				if (!dictionary.ContainsKey(text))
				{
					dictionary.Add(text, new string[0]);
				}
				string[] values = nameValueCollection.GetValues(text);
				if (values != null)
				{
					foreach (string item in values)
					{
						List<string> list = dictionary[text].ToList<string>();
						list.Add(item);
						dictionary[text] = list.ToArray();
					}
				}
			}
			return dictionary;
		}

		// Token: 0x0400030D RID: 781
		private static readonly Dictionary<int, string> StatusCodeToStatusTextMapping = new Dictionary<int, string>
		{
			{
				200,
				"OK"
			},
			{
				301,
				"Moved Permanently"
			},
			{
				304,
				"Not Modified"
			},
			{
				404,
				"Not Found"
			}
		};

		// Token: 0x0400030E RID: 782
		private readonly Func<IDictionary<string, object>, Task> appFunc;
	}
}
