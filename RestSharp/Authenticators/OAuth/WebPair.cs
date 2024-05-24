using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators.OAuth
{
	// Token: 0x02000063 RID: 99
	[NullableContext(1)]
	[Nullable(0)]
	internal class WebPair
	{
		// Token: 0x0600057B RID: 1403 RVA: 0x0000DA05 File Offset: 0x0000BC05
		public WebPair(string name, string value, bool encode = false)
		{
			this.Name = name;
			this.Value = value;
			this.WebValue = (encode ? OAuthTools.UrlEncodeRelaxed(value ?? "") : value);
			this.Encode = encode;
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0000DA3D File Offset: 0x0000BC3D
		public string Name { get; }

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000DA45 File Offset: 0x0000BC45
		public string Value { get; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0000DA4D File Offset: 0x0000BC4D
		public string WebValue { get; }

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000DA55 File Offset: 0x0000BC55
		public bool Encode { get; }

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x0000DA5D File Offset: 0x0000BC5D
		internal static WebPair.WebPairComparer Comparer { get; } = new WebPair.WebPairComparer();

		// Token: 0x020000D2 RID: 210
		[NullableContext(0)]
		internal class WebPairComparer : IComparer<WebPair>
		{
			// Token: 0x060006EB RID: 1771 RVA: 0x0000FDD0 File Offset: 0x0000DFD0
			[NullableContext(1)]
			public int Compare(WebPair x, WebPair y)
			{
				int num = string.CompareOrdinal(x.Name, y.Name);
				if (num == 0)
				{
					return string.CompareOrdinal(x.Value, y.Value);
				}
				return num;
			}
		}
	}
}
