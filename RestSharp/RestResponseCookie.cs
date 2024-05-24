using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x02000028 RID: 40
	[NullableContext(1)]
	[Nullable(0)]
	[Obsolete("We will use HttpCookie in the response as well in the next major version")]
	public class RestResponseCookie
	{
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00007157 File Offset: 0x00005357
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0000715F File Offset: 0x0000535F
		public string Comment { get; set; }

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00007168 File Offset: 0x00005368
		// (set) Token: 0x0600039D RID: 925 RVA: 0x00007170 File Offset: 0x00005370
		public Uri CommentUri { get; set; }

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00007179 File Offset: 0x00005379
		// (set) Token: 0x0600039F RID: 927 RVA: 0x00007181 File Offset: 0x00005381
		public bool Discard { get; set; }

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000718A File Offset: 0x0000538A
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x00007192 File Offset: 0x00005392
		public string Domain { get; set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000719B File Offset: 0x0000539B
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x000071A3 File Offset: 0x000053A3
		public bool Expired { get; set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x000071AC File Offset: 0x000053AC
		// (set) Token: 0x060003A5 RID: 933 RVA: 0x000071B4 File Offset: 0x000053B4
		public DateTime Expires { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x000071BD File Offset: 0x000053BD
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x000071C5 File Offset: 0x000053C5
		public bool HttpOnly { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x000071CE File Offset: 0x000053CE
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x000071D6 File Offset: 0x000053D6
		public string Name { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060003AA RID: 938 RVA: 0x000071DF File Offset: 0x000053DF
		// (set) Token: 0x060003AB RID: 939 RVA: 0x000071E7 File Offset: 0x000053E7
		public string Path { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060003AC RID: 940 RVA: 0x000071F0 File Offset: 0x000053F0
		// (set) Token: 0x060003AD RID: 941 RVA: 0x000071F8 File Offset: 0x000053F8
		public string Port { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060003AE RID: 942 RVA: 0x00007201 File Offset: 0x00005401
		// (set) Token: 0x060003AF RID: 943 RVA: 0x00007209 File Offset: 0x00005409
		public bool Secure { get; set; }

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00007212 File Offset: 0x00005412
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x0000721A File Offset: 0x0000541A
		public DateTime TimeStamp { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00007223 File Offset: 0x00005423
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x0000722B File Offset: 0x0000542B
		public string Value { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x00007234 File Offset: 0x00005434
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x0000723C File Offset: 0x0000543C
		public int Version { get; set; }

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x00007245 File Offset: 0x00005445
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x0000724D File Offset: 0x0000544D
		public HttpCookie HttpCookie { get; private set; }

		// Token: 0x060003B8 RID: 952 RVA: 0x00007258 File Offset: 0x00005458
		internal static RestResponseCookie FromHttpCookie(HttpCookie cookie)
		{
			return new RestResponseCookie
			{
				Comment = cookie.Comment,
				CommentUri = cookie.CommentUri,
				Discard = cookie.Discard,
				Domain = cookie.Domain,
				Expired = cookie.Expired,
				Expires = cookie.Expires,
				HttpOnly = cookie.HttpOnly,
				Name = cookie.Name,
				Path = cookie.Path,
				Port = cookie.Port,
				Secure = cookie.Secure,
				TimeStamp = cookie.TimeStamp,
				Value = cookie.Value,
				Version = cookie.Version,
				HttpCookie = cookie
			};
		}
	}
}
