using System;
using System.Collections.Generic;
using System.Linq;
using CefSharp.Enums;
using CefSharp.Internals;

namespace CefSharp
{
	// Token: 0x02000019 RID: 25
	public sealed class CefCustomScheme
	{
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002462 File Offset: 0x00000662
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000246A File Offset: 0x0000066A
		public string SchemeName { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002473 File Offset: 0x00000673
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000247B File Offset: 0x0000067B
		public string DomainName { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002484 File Offset: 0x00000684
		// (set) Token: 0x06000059 RID: 89 RVA: 0x0000249C File Offset: 0x0000069C
		public bool IsStandard
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.Standard);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.Standard;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.Standard;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600005A RID: 90 RVA: 0x000024BF File Offset: 0x000006BF
		// (set) Token: 0x0600005B RID: 91 RVA: 0x000024D7 File Offset: 0x000006D7
		public bool IsLocal
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.Local);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.Local;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.Local;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600005C RID: 92 RVA: 0x000024FA File Offset: 0x000006FA
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002512 File Offset: 0x00000712
		public bool IsDisplayIsolated
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.DisplayIsolated);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.DisplayIsolated;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.DisplayIsolated;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002535 File Offset: 0x00000735
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000254D File Offset: 0x0000074D
		public bool IsSecure
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.Secure);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.Secure;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.Secure;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002570 File Offset: 0x00000770
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002589 File Offset: 0x00000789
		public bool IsCorsEnabled
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.CorsEnabled);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.CorsEnabled;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.CorsEnabled;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000025AD File Offset: 0x000007AD
		// (set) Token: 0x06000063 RID: 99 RVA: 0x000025C6 File Offset: 0x000007C6
		public bool IsCSPBypassing
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.CspBypassing);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.CspBypassing;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.CspBypassing;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000025EA File Offset: 0x000007EA
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002603 File Offset: 0x00000803
		public bool IsFetchEnabled
		{
			get
			{
				return this.schemeOptions.HasFlag(SchemeOptions.FetchEnabled);
			}
			set
			{
				if (value)
				{
					this.schemeOptions |= SchemeOptions.FetchEnabled;
					return;
				}
				this.schemeOptions &= ~SchemeOptions.FetchEnabled;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002627 File Offset: 0x00000827
		// (set) Token: 0x06000067 RID: 103 RVA: 0x0000262F File Offset: 0x0000082F
		public ISchemeHandlerFactory SchemeHandlerFactory { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002638 File Offset: 0x00000838
		public SchemeOptions Options
		{
			get
			{
				return this.schemeOptions;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002640 File Offset: 0x00000840
		public CefCustomScheme()
		{
			this.schemeOptions = (SchemeOptions.Standard | SchemeOptions.Secure | SchemeOptions.CorsEnabled);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002650 File Offset: 0x00000850
		public CefCustomScheme(string schemeName, SchemeOptions options)
		{
			this.SchemeName = schemeName;
			this.schemeOptions = options;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002668 File Offset: 0x00000868
		public static List<CefCustomScheme> ParseCommandLineArguments(IEnumerable<string> args)
		{
			string argumentValue = args.GetArgumentValue("--custom-scheme");
			List<CefCustomScheme> customSchemes = new List<CefCustomScheme>();
			if (!string.IsNullOrEmpty(argumentValue))
			{
				argumentValue.Split(new char[]
				{
					';'
				}).ToList<string>().ForEach(delegate(string x)
				{
					string[] array = x.Split(new char[]
					{
						'|'
					});
					string schemeName = array[0];
					SchemeOptions options = SchemeOptions.None;
					Enum.TryParse<SchemeOptions>(array[1], out options);
					CefCustomScheme item = new CefCustomScheme(schemeName, options);
					customSchemes.Add(item);
				});
			}
			return customSchemes;
		}

		// Token: 0x04000014 RID: 20
		private SchemeOptions schemeOptions;
	}
}
