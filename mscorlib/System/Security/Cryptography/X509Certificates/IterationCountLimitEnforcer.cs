using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using Microsoft.Win32;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B0 RID: 688
	internal static class IterationCountLimitEnforcer
	{
		// Token: 0x0600246D RID: 9325 RVA: 0x0008336C File Offset: 0x0008156C
		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EnforceIterationCountLimit(byte[] pkcs12, bool readingFromFile, bool passwordProvided)
		{
			IterationCountLimitEnforcer.Impl.EnforceIterationCountLimit(pkcs12, readingFromFile, passwordProvided);
		}

		// Token: 0x02000B49 RID: 2889
		private static class Impl
		{
			// Token: 0x06006B97 RID: 27543 RVA: 0x001746F4 File Offset: 0x001728F4
			[SecuritySafeCritical]
			[EnvironmentPermission(SecurityAction.Assert, Unrestricted = true)]
			private static long ReadSecuritySwitch()
			{
				long result = 0L;
				string environmentVariable = Environment.GetEnvironmentVariable("COMPlus_Pkcs12UnspecifiedPasswordIterationLimit");
				if (environmentVariable != null && long.TryParse(environmentVariable, out result))
				{
					return result;
				}
				if (IterationCountLimitEnforcer.Impl.ReadSettingsFromRegistry(Registry.CurrentUser, ref result))
				{
					return result;
				}
				if (IterationCountLimitEnforcer.Impl.ReadSettingsFromRegistry(Registry.LocalMachine, ref result))
				{
					return result;
				}
				return 600000L;
			}

			// Token: 0x06006B98 RID: 27544 RVA: 0x00174744 File Offset: 0x00172944
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
			[RegistryPermission(SecurityAction.Assert, Unrestricted = true)]
			private static bool ReadSettingsFromRegistry(RegistryKey regKey, ref long value)
			{
				try
				{
					using (RegistryKey registryKey = regKey.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework", false))
					{
						if (registryKey != null)
						{
							object value2 = registryKey.GetValue("Pkcs12UnspecifiedPasswordIterationLimit");
							if (value2 != null)
							{
								value = Convert.ToInt64(value2, CultureInfo.InvariantCulture);
								return true;
							}
						}
					}
				}
				catch
				{
				}
				return false;
			}

			// Token: 0x06006B99 RID: 27545 RVA: 0x001747B4 File Offset: 0x001729B4
			internal static void EnforceIterationCountLimit(byte[] pkcs12, bool readingFromFile, bool passwordProvided)
			{
				if (readingFromFile || passwordProvided)
				{
					return;
				}
				long num = IterationCountLimitEnforcer.Impl.s_pkcs12UnspecifiedPasswordIterationLimit;
				if (num == -1L)
				{
					return;
				}
				if (num < 0L)
				{
					num = 600000L;
				}
				checked
				{
					try
					{
						try
						{
							KdfWorkLimiter.SetIterationLimit((ulong)num);
							ulong iterationCount = IterationCountLimitEnforcer.Impl.GetIterationCount(pkcs12);
							if (iterationCount > (ulong)num || KdfWorkLimiter.WasWorkLimitExceeded())
							{
								throw new CryptographicException();
							}
						}
						finally
						{
							KdfWorkLimiter.ResetIterationLimit();
						}
					}
					catch (Exception inner)
					{
						throw new CryptographicException(Environment.GetResourceString("Cryptography_X509_PfxWithoutPassword"), inner);
					}
				}
			}

			// Token: 0x06006B9A RID: 27546 RVA: 0x00174838 File Offset: 0x00172A38
			private static ulong GetIterationCount(byte[] pkcs12)
			{
				ReadOnlyMemory<byte> rebind = new ReadOnlyMemory<byte>(pkcs12);
				AsnValueReader asnValueReader = new AsnValueReader(pkcs12, AsnEncodingRules.BER);
				PfxAsn pfxAsn;
				PfxAsn.Decode(ref asnValueReader, rebind, out pfxAsn);
				return pfxAsn.CountTotalIterations();
			}

			// Token: 0x040033C5 RID: 13253
			private const long DefaultPkcs12UnspecifiedPasswordIterationLimit = 600000L;

			// Token: 0x040033C6 RID: 13254
			private static long s_pkcs12UnspecifiedPasswordIterationLimit = IterationCountLimitEnforcer.Impl.ReadSecuritySwitch();
		}
	}
}
