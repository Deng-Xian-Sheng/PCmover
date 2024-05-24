using System;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000003 RID: 3
	public class ContractInfo
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000021AA File Offset: 0x000003AA
		public Type Type { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000021B2 File Offset: 0x000003B2
		public string UriName { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000021BA File Offset: 0x000003BA
		public string Version { get; }

		// Token: 0x0600001A RID: 26 RVA: 0x000021C2 File Offset: 0x000003C2
		public ContractInfo(Type type, string uriName, string version)
		{
			this.Type = type;
			this.UriName = uriName;
			this.Version = version;
		}
	}
}
