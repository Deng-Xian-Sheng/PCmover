using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Principal
{
	// Token: 0x0200033C RID: 828
	internal static class Win32
	{
		// Token: 0x06002942 RID: 10562 RVA: 0x00098960 File Offset: 0x00096B60
		[SecuritySafeCritical]
		static Win32()
		{
			Win32Native.OSVERSIONINFO osversioninfo = new Win32Native.OSVERSIONINFO();
			if (!Environment.GetVersion(osversioninfo))
			{
				throw new SystemException(Environment.GetResourceString("InvalidOperation_GetVersion"));
			}
			if (osversioninfo.MajorVersion > 5 || osversioninfo.MinorVersion > 0)
			{
				Win32._LsaLookupNames2Supported = true;
				Win32._WellKnownSidApisSupported = true;
				return;
			}
			Win32._LsaLookupNames2Supported = false;
			Win32Native.OSVERSIONINFOEX osversioninfoex = new Win32Native.OSVERSIONINFOEX();
			if (!Environment.GetVersionEx(osversioninfoex))
			{
				throw new SystemException(Environment.GetResourceString("InvalidOperation_GetVersion"));
			}
			if (osversioninfoex.ServicePackMajor < 3)
			{
				Win32._WellKnownSidApisSupported = false;
				return;
			}
			Win32._WellKnownSidApisSupported = true;
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06002943 RID: 10563 RVA: 0x000989E8 File Offset: 0x00096BE8
		internal static bool LsaLookupNames2Supported
		{
			get
			{
				return Win32._LsaLookupNames2Supported;
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06002944 RID: 10564 RVA: 0x000989EF File Offset: 0x00096BEF
		internal static bool WellKnownSidApisSupported
		{
			get
			{
				return Win32._WellKnownSidApisSupported;
			}
		}

		// Token: 0x06002945 RID: 10565 RVA: 0x000989F8 File Offset: 0x00096BF8
		[SecurityCritical]
		internal static SafeLsaPolicyHandle LsaOpenPolicy(string systemName, PolicyRights rights)
		{
			Win32Native.LSA_OBJECT_ATTRIBUTES lsa_OBJECT_ATTRIBUTES;
			lsa_OBJECT_ATTRIBUTES.Length = Marshal.SizeOf(typeof(Win32Native.LSA_OBJECT_ATTRIBUTES));
			lsa_OBJECT_ATTRIBUTES.RootDirectory = IntPtr.Zero;
			lsa_OBJECT_ATTRIBUTES.ObjectName = IntPtr.Zero;
			lsa_OBJECT_ATTRIBUTES.Attributes = 0;
			lsa_OBJECT_ATTRIBUTES.SecurityDescriptor = IntPtr.Zero;
			lsa_OBJECT_ATTRIBUTES.SecurityQualityOfService = IntPtr.Zero;
			SafeLsaPolicyHandle result;
			uint num;
			if ((num = Win32Native.LsaOpenPolicy(systemName, ref lsa_OBJECT_ATTRIBUTES, (int)rights, out result)) == 0U)
			{
				return result;
			}
			if (num == 3221225506U)
			{
				throw new UnauthorizedAccessException();
			}
			if (num == 3221225626U || num == 3221225495U)
			{
				throw new OutOfMemoryException();
			}
			int errorCode = Win32Native.LsaNtStatusToWinError((int)num);
			throw new SystemException(Win32Native.GetMessage(errorCode));
		}

		// Token: 0x06002946 RID: 10566 RVA: 0x00098A9C File Offset: 0x00096C9C
		[SecurityCritical]
		internal static byte[] ConvertIntPtrSidToByteArraySid(IntPtr binaryForm)
		{
			byte b = Marshal.ReadByte(binaryForm, 0);
			if (b != SecurityIdentifier.Revision)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_InvalidSidRevision"), "binaryForm");
			}
			byte b2 = Marshal.ReadByte(binaryForm, 1);
			if (b2 < 0 || b2 > SecurityIdentifier.MaxSubAuthorities)
			{
				throw new ArgumentException(Environment.GetResourceString("IdentityReference_InvalidNumberOfSubauthorities", new object[]
				{
					SecurityIdentifier.MaxSubAuthorities
				}), "binaryForm");
			}
			int num = (int)(8 + b2 * 4);
			byte[] array = new byte[num];
			Marshal.Copy(binaryForm, array, 0, num);
			return array;
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x00098B24 File Offset: 0x00096D24
		[SecurityCritical]
		internal static int CreateSidFromString(string stringSid, out byte[] resultSid)
		{
			IntPtr zero = IntPtr.Zero;
			int lastWin32Error;
			try
			{
				if (1 != Win32Native.ConvertStringSidToSid(stringSid, out zero))
				{
					lastWin32Error = Marshal.GetLastWin32Error();
					goto IL_2D;
				}
				resultSid = Win32.ConvertIntPtrSidToByteArraySid(zero);
			}
			finally
			{
				Win32Native.LocalFree(zero);
			}
			return 0;
			IL_2D:
			resultSid = null;
			return lastWin32Error;
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x00098B74 File Offset: 0x00096D74
		[SecurityCritical]
		internal static int CreateWellKnownSid(WellKnownSidType sidType, SecurityIdentifier domainSid, out byte[] resultSid)
		{
			if (!Win32.WellKnownSidApisSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_RequiresW2kSP3"));
			}
			uint maxBinaryLength = (uint)SecurityIdentifier.MaxBinaryLength;
			resultSid = new byte[maxBinaryLength];
			if (Win32Native.CreateWellKnownSid((int)sidType, (domainSid == null) ? null : domainSid.BinaryForm, resultSid, ref maxBinaryLength) != 0)
			{
				return 0;
			}
			resultSid = null;
			return Marshal.GetLastWin32Error();
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x00098BD0 File Offset: 0x00096DD0
		[SecurityCritical]
		internal static bool IsEqualDomainSid(SecurityIdentifier sid1, SecurityIdentifier sid2)
		{
			if (!Win32.WellKnownSidApisSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_RequiresW2kSP3"));
			}
			if (sid1 == null || sid2 == null)
			{
				return false;
			}
			byte[] array = new byte[sid1.BinaryLength];
			sid1.GetBinaryForm(array, 0);
			byte[] array2 = new byte[sid2.BinaryLength];
			sid2.GetBinaryForm(array2, 0);
			bool flag;
			return Win32Native.IsEqualDomainSid(array, array2, out flag) != 0 && flag;
		}

		// Token: 0x0600294A RID: 10570 RVA: 0x00098C40 File Offset: 0x00096E40
		[SecurityCritical]
		internal unsafe static void InitializeReferencedDomainsPointer(SafeLsaMemoryHandle referencedDomains)
		{
			referencedDomains.Initialize((ulong)Marshal.SizeOf(typeof(Win32Native.LSA_REFERENCED_DOMAIN_LIST)));
			Win32Native.LSA_REFERENCED_DOMAIN_LIST lsa_REFERENCED_DOMAIN_LIST = referencedDomains.Read<Win32Native.LSA_REFERENCED_DOMAIN_LIST>(0UL);
			byte* ptr = null;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				referencedDomains.AcquirePointer(ref ptr);
				if (!lsa_REFERENCED_DOMAIN_LIST.Domains.IsNull())
				{
					Win32Native.LSA_TRUST_INFORMATION* ptr2 = (Win32Native.LSA_TRUST_INFORMATION*)((void*)lsa_REFERENCED_DOMAIN_LIST.Domains);
					ptr2 += lsa_REFERENCED_DOMAIN_LIST.Entries;
					long numBytes = (long)((byte*)ptr2 - (byte*)ptr);
					referencedDomains.Initialize((ulong)numBytes);
				}
			}
			finally
			{
				if (ptr != null)
				{
					referencedDomains.ReleasePointer();
				}
			}
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x00098CD4 File Offset: 0x00096ED4
		[SecurityCritical]
		internal static int GetWindowsAccountDomainSid(SecurityIdentifier sid, out SecurityIdentifier resultSid)
		{
			if (!Win32.WellKnownSidApisSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_RequiresW2kSP3"));
			}
			byte[] array = new byte[sid.BinaryLength];
			sid.GetBinaryForm(array, 0);
			uint maxBinaryLength = (uint)SecurityIdentifier.MaxBinaryLength;
			byte[] array2 = new byte[maxBinaryLength];
			if (Win32Native.GetWindowsAccountDomainSid(array, array2, ref maxBinaryLength) != 0)
			{
				resultSid = new SecurityIdentifier(array2, 0);
				return 0;
			}
			resultSid = null;
			return Marshal.GetLastWin32Error();
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x00098D38 File Offset: 0x00096F38
		[SecurityCritical]
		internal static bool IsWellKnownSid(SecurityIdentifier sid, WellKnownSidType type)
		{
			if (!Win32.WellKnownSidApisSupported)
			{
				throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_RequiresW2kSP3"));
			}
			byte[] array = new byte[sid.BinaryLength];
			sid.GetBinaryForm(array, 0);
			return Win32Native.IsWellKnownSid(array, (int)type) != 0;
		}

		// Token: 0x0600294D RID: 10573
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int ImpersonateLoggedOnUser(SafeAccessTokenHandle hToken);

		// Token: 0x0600294E RID: 10574
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int OpenThreadToken(TokenAccessLevels dwDesiredAccess, WinSecurityContext OpenAs, out SafeAccessTokenHandle phThreadToken);

		// Token: 0x0600294F RID: 10575
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int RevertToSelf();

		// Token: 0x06002950 RID: 10576
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		internal static extern int SetThreadToken(SafeAccessTokenHandle hToken);

		// Token: 0x040010FB RID: 4347
		internal const int FALSE = 0;

		// Token: 0x040010FC RID: 4348
		internal const int TRUE = 1;

		// Token: 0x040010FD RID: 4349
		private static bool _LsaLookupNames2Supported;

		// Token: 0x040010FE RID: 4350
		private static bool _WellKnownSidApisSupported;
	}
}
