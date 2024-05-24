using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace System.Security.Util
{
	// Token: 0x02000379 RID: 889
	internal static class Config
	{
		// Token: 0x06002C16 RID: 11286 RVA: 0x000A4374 File Offset: 0x000A2574
		[SecurityCritical]
		private static void GetFileLocales()
		{
			if (Config.m_machineConfig == null)
			{
				string machineConfig = null;
				Config.GetMachineDirectory(JitHelpers.GetStringHandleOnStack(ref machineConfig));
				Config.m_machineConfig = machineConfig;
			}
			if (Config.m_userConfig == null)
			{
				string userConfig = null;
				Config.GetUserDirectory(JitHelpers.GetStringHandleOnStack(ref userConfig));
				Config.m_userConfig = userConfig;
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06002C17 RID: 11287 RVA: 0x000A43BF File Offset: 0x000A25BF
		internal static string MachineDirectory
		{
			[SecurityCritical]
			get
			{
				Config.GetFileLocales();
				return Config.m_machineConfig;
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06002C18 RID: 11288 RVA: 0x000A43CD File Offset: 0x000A25CD
		internal static string UserDirectory
		{
			[SecurityCritical]
			get
			{
				Config.GetFileLocales();
				return Config.m_userConfig;
			}
		}

		// Token: 0x06002C19 RID: 11289
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int SaveDataByte(string path, [In] byte[] data, int length);

		// Token: 0x06002C1A RID: 11290
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern bool RecoverData(ConfigId id);

		// Token: 0x06002C1B RID: 11291
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void SetQuickCache(ConfigId id, QuickCacheEntryType quickCacheFlags);

		// Token: 0x06002C1C RID: 11292
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern bool GetCacheEntry(ConfigId id, int numKey, [In] byte[] key, int keyLength, ObjectHandleOnStack retData);

		// Token: 0x06002C1D RID: 11293 RVA: 0x000A43DC File Offset: 0x000A25DC
		[SecurityCritical]
		internal static bool GetCacheEntry(ConfigId id, int numKey, byte[] key, out byte[] data)
		{
			byte[] array = null;
			bool cacheEntry = Config.GetCacheEntry(id, numKey, key, key.Length, JitHelpers.GetObjectHandleOnStack<byte[]>(ref array));
			data = array;
			return cacheEntry;
		}

		// Token: 0x06002C1E RID: 11294
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void AddCacheEntry(ConfigId id, int numKey, [In] byte[] key, int keyLength, byte[] data, int dataLength);

		// Token: 0x06002C1F RID: 11295 RVA: 0x000A4402 File Offset: 0x000A2602
		[SecurityCritical]
		internal static void AddCacheEntry(ConfigId id, int numKey, byte[] key, byte[] data)
		{
			Config.AddCacheEntry(id, numKey, key, key.Length, data, data.Length);
		}

		// Token: 0x06002C20 RID: 11296
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern void ResetCacheData(ConfigId id);

		// Token: 0x06002C21 RID: 11297
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetMachineDirectory(StringHandleOnStack retDirectory);

		// Token: 0x06002C22 RID: 11298
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetUserDirectory(StringHandleOnStack retDirectory);

		// Token: 0x06002C23 RID: 11299
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern bool WriteToEventLog(string message);

		// Token: 0x040011BC RID: 4540
		private static volatile string m_machineConfig;

		// Token: 0x040011BD RID: 4541
		private static volatile string m_userConfig;
	}
}
