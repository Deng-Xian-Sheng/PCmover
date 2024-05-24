using System;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000007 RID: 7
	public class LlUriProperties
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002D59 File Offset: 0x00000F59
		public string Scheme { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002D61 File Offset: 0x00000F61
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002D69 File Offset: 0x00000F69
		public string Host { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002D72 File Offset: 0x00000F72
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002D7A File Offset: 0x00000F7A
		public int Port { get; set; } = -1;

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002D83 File Offset: 0x00000F83
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002D8B File Offset: 0x00000F8B
		public string BaseName { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002D94 File Offset: 0x00000F94
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002D9C File Offset: 0x00000F9C
		public string Parameters { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002DA5 File Offset: 0x00000FA5
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002DAD File Offset: 0x00000FAD
		public string Version { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002DB6 File Offset: 0x00000FB6
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002DBE File Offset: 0x00000FBE
		public string ContractName { get; set; }

		// Token: 0x0600005D RID: 93 RVA: 0x00002DC7 File Offset: 0x00000FC7
		public LlUriProperties(string scheme)
		{
			this.Scheme = scheme;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002DE0 File Offset: 0x00000FE0
		public void CopyFrom(LlUriProperties other)
		{
			if (other != null)
			{
				this.Host = other.Host;
				this.Port = other.Port;
				this.BaseName = other.BaseName;
				this.Parameters = other.Parameters;
				this.Version = other.Version;
				this.ContractName = other.ContractName;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002E38 File Offset: 0x00001038
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00002EDC File Offset: 0x000010DC
		public virtual Uri Uri
		{
			get
			{
				string text = string.Empty;
				if (!string.IsNullOrWhiteSpace(this.Parameters))
				{
					text = LlEndpoint.UriSegmentDelimiter + this.Parameters;
				}
				string pathValue = string.Concat(new string[]
				{
					this.BaseName,
					text,
					"/",
					this.Version,
					"/",
					this.ContractName
				});
				Uri result;
				try
				{
					result = new UriBuilder(this.Scheme, this.Host, this.Port, pathValue).Uri;
				}
				catch (UriFormatException)
				{
					result = null;
				}
				return result;
			}
			set
			{
				this.Host = value.Host;
				this.Port = value.Port;
				string[] segments = value.Segments;
				int num = segments.Length;
				if (num < 4)
				{
					this.BaseName = null;
					this.Parameters = null;
					this.Version = null;
					this.ContractName = null;
					return;
				}
				this.BaseName = this.TrimSlash(segments[1]);
				string text = string.Empty;
				if (num >= 5)
				{
					for (int i = 2; i < num - 2; i++)
					{
						text += segments[i];
					}
				}
				this.Parameters = this.TrimSlash(text);
				this.Version = this.TrimSlash(segments[num - 2]);
				this.ContractName = this.TrimSlash(segments[num - 1]);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002F94 File Offset: 0x00001194
		protected string TrimSlash(string segment)
		{
			return segment.TrimIfEndsWith(LlEndpoint.UriSegmentDelimiter);
		}
	}
}
