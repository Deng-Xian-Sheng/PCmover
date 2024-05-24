using System;

namespace Laplink.Tools.Helpers.Wcf
{
	// Token: 0x02000008 RID: 8
	public static class SchemeHelper
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00002FA1 File Offset: 0x000011A1
		public static SchemeHelper.ConnectionType GetConnectionType(string scheme)
		{
			if (string.IsNullOrWhiteSpace(scheme))
			{
				return SchemeHelper.ConnectionType.None;
			}
			if (scheme == LlEndpoint.UriSchemeServiceBus)
			{
				return SchemeHelper.ConnectionType.ServiceBus;
			}
			if (scheme == LlEndpoint.UriSchemeWmi)
			{
				return SchemeHelper.ConnectionType.Wmi;
			}
			if (scheme == LlEndpoint.UriSchemeEma)
			{
				return SchemeHelper.ConnectionType.Ema;
			}
			return SchemeHelper.ConnectionType.Wcf;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00002FDB File Offset: 0x000011DB
		public static SchemeHelper.ConnectionType GetConnectionType(Uri uri)
		{
			return SchemeHelper.GetConnectionType((uri != null) ? uri.Scheme : null);
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002FEE File Offset: 0x000011EE
		public static bool IsScriptConnectionType(SchemeHelper.ConnectionType ct)
		{
			return ct - SchemeHelper.ConnectionType.Wmi <= 1;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002FF9 File Offset: 0x000011F9
		public static bool IsScriptConnectionType(string scheme)
		{
			return SchemeHelper.IsScriptConnectionType(SchemeHelper.GetConnectionType(scheme));
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003006 File Offset: 0x00001206
		public static bool IsScriptConnectionType(Uri uri)
		{
			return SchemeHelper.IsScriptConnectionType(SchemeHelper.GetConnectionType(uri));
		}

		// Token: 0x0200000D RID: 13
		public enum ConnectionType
		{
			// Token: 0x04000028 RID: 40
			None,
			// Token: 0x04000029 RID: 41
			Wcf,
			// Token: 0x0400002A RID: 42
			ServiceBus,
			// Token: 0x0400002B RID: 43
			Wmi,
			// Token: 0x0400002C RID: 44
			Ema
		}
	}
}
