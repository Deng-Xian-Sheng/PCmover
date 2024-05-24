using System;
using System.Collections.Specialized;
using System.ComponentModel;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x0200000A RID: 10
	public class Request : IRequest, IDisposable
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00002BCB File Offset: 0x00000DCB
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00002BD8 File Offset: 0x00000DD8
		public UrlRequestFlags Flags
		{
			get
			{
				return this.request.Flags;
			}
			set
			{
				this.request.Flags = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00002BE6 File Offset: 0x00000DE6
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00002BF3 File Offset: 0x00000DF3
		public string Url
		{
			get
			{
				return this.request.Url;
			}
			set
			{
				this.request.Url = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00002C01 File Offset: 0x00000E01
		public ulong Identifier
		{
			get
			{
				return this.request.Identifier;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00002C0E File Offset: 0x00000E0E
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00002C1B File Offset: 0x00000E1B
		public string Method
		{
			get
			{
				return this.request.Method;
			}
			set
			{
				this.request.Method = value;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00002C29 File Offset: 0x00000E29
		public string ReferrerUrl
		{
			get
			{
				return this.request.ReferrerUrl;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00002C36 File Offset: 0x00000E36
		public ResourceType ResourceType
		{
			get
			{
				return this.request.ResourceType;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00002C43 File Offset: 0x00000E43
		public ReferrerPolicy ReferrerPolicy
		{
			get
			{
				return this.request.ReferrerPolicy;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00002C50 File Offset: 0x00000E50
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00002C5D File Offset: 0x00000E5D
		public NameValueCollection Headers
		{
			get
			{
				return this.request.Headers;
			}
			set
			{
				this.request.Headers = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00002C6B File Offset: 0x00000E6B
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00002C78 File Offset: 0x00000E78
		public IPostData PostData
		{
			get
			{
				return this.request.PostData;
			}
			set
			{
				this.request.PostData = value;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00002C86 File Offset: 0x00000E86
		public TransitionType TransitionType
		{
			get
			{
				return this.request.TransitionType;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00002C93 File Offset: 0x00000E93
		public bool IsDisposed
		{
			get
			{
				return this.request.IsDisposed;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00002CA0 File Offset: 0x00000EA0
		public bool IsReadOnly
		{
			get
			{
				return this.request.IsReadOnly;
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00002CAD File Offset: 0x00000EAD
		public void Dispose()
		{
			this.request.Dispose();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00002CBA File Offset: 0x00000EBA
		public string GetHeaderByName(string name)
		{
			return this.request.GetHeaderByName(name);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00002CC8 File Offset: 0x00000EC8
		public void InitializePostData()
		{
			this.request.InitializePostData();
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00002CD5 File Offset: 0x00000ED5
		public void SetHeaderByName(string name, string value, bool overwrite)
		{
			this.request.SetHeaderByName(name, value, overwrite);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00002CE5 File Offset: 0x00000EE5
		public void SetReferrer(string referrerUrl, ReferrerPolicy policy)
		{
			this.request.SetReferrer(referrerUrl, policy);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00002CF4 File Offset: 0x00000EF4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public IRequest UnWrap()
		{
			return this.request;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002CFC File Offset: 0x00000EFC
		public static IRequest Create()
		{
			return new Request();
		}

		// Token: 0x04000006 RID: 6
		internal Request request = new Request();
	}
}
