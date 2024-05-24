using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002AC RID: 684
	internal static class X509Utils
	{
		// Token: 0x06002407 RID: 9223 RVA: 0x00082391 File Offset: 0x00080591
		private static bool OidGroupWillNotUseActiveDirectory(OidGroup group)
		{
			return group == OidGroup.HashAlgorithm || group == OidGroup.EncryptionAlgorithm || group == OidGroup.PublicKeyAlgorithm || group == OidGroup.SignatureAlgorithm || group == OidGroup.Attribute || group == OidGroup.ExtensionOrAttribute || group == OidGroup.KeyDerivationFunction;
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x000823B4 File Offset: 0x000805B4
		[SecurityCritical]
		private static CRYPT_OID_INFO FindOidInfo(OidKeyType keyType, string key, OidGroup group)
		{
			IntPtr intPtr = IntPtr.Zero;
			RuntimeHelpers.PrepareConstrainedRegions();
			CRYPT_OID_INFO result;
			try
			{
				if (keyType == OidKeyType.Oid)
				{
					intPtr = Marshal.StringToCoTaskMemAnsi(key);
				}
				else
				{
					intPtr = Marshal.StringToCoTaskMemUni(key);
				}
				if (!X509Utils.OidGroupWillNotUseActiveDirectory(group))
				{
					OidGroup dwGroupId = group | OidGroup.DisableSearchDS;
					IntPtr intPtr2 = X509Utils.CryptFindOIDInfo(keyType, intPtr, dwGroupId);
					if (intPtr2 != IntPtr.Zero)
					{
						return (CRYPT_OID_INFO)Marshal.PtrToStructure(intPtr2, typeof(CRYPT_OID_INFO));
					}
				}
				IntPtr intPtr3 = X509Utils.CryptFindOIDInfo(keyType, intPtr, group);
				if (intPtr3 != IntPtr.Zero)
				{
					result = (CRYPT_OID_INFO)Marshal.PtrToStructure(intPtr3, typeof(CRYPT_OID_INFO));
				}
				else
				{
					if (group != OidGroup.AllGroups)
					{
						IntPtr intPtr4 = X509Utils.CryptFindOIDInfo(keyType, intPtr, OidGroup.AllGroups);
						if (intPtr4 != IntPtr.Zero)
						{
							return (CRYPT_OID_INFO)Marshal.PtrToStructure(intPtr4, typeof(CRYPT_OID_INFO));
						}
					}
					result = default(CRYPT_OID_INFO);
				}
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(intPtr);
				}
			}
			return result;
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x000824BC File Offset: 0x000806BC
		[SecuritySafeCritical]
		internal static int GetAlgIdFromOid(string oid, OidGroup oidGroup)
		{
			if (string.Equals(oid, "2.16.840.1.101.3.4.2.1", StringComparison.Ordinal))
			{
				return 32780;
			}
			if (string.Equals(oid, "2.16.840.1.101.3.4.2.2", StringComparison.Ordinal))
			{
				return 32781;
			}
			if (string.Equals(oid, "2.16.840.1.101.3.4.2.3", StringComparison.Ordinal))
			{
				return 32782;
			}
			return X509Utils.FindOidInfo(OidKeyType.Oid, oid, oidGroup).AlgId;
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x00082514 File Offset: 0x00080714
		[SecuritySafeCritical]
		internal static string GetFriendlyNameFromOid(string oid, OidGroup oidGroup)
		{
			CRYPT_OID_INFO crypt_OID_INFO = X509Utils.FindOidInfo(OidKeyType.Oid, oid, oidGroup);
			return crypt_OID_INFO.pwszName;
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x00082530 File Offset: 0x00080730
		[SecuritySafeCritical]
		internal static string GetOidFromFriendlyName(string friendlyName, OidGroup oidGroup)
		{
			CRYPT_OID_INFO crypt_OID_INFO = X509Utils.FindOidInfo(OidKeyType.Name, friendlyName, oidGroup);
			return crypt_OID_INFO.pszOID;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x0008254C File Offset: 0x0008074C
		internal static int NameOrOidToAlgId(string oid, OidGroup oidGroup)
		{
			if (oid == null)
			{
				return 32772;
			}
			string text = CryptoConfig.MapNameToOID(oid, oidGroup);
			if (text == null)
			{
				text = oid;
			}
			int algIdFromOid = X509Utils.GetAlgIdFromOid(text, oidGroup);
			if (algIdFromOid == 0 || algIdFromOid == -1)
			{
				throw new CryptographicException(Environment.GetResourceString("Cryptography_InvalidOID"));
			}
			return algIdFromOid;
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x00082590 File Offset: 0x00080790
		internal static X509ContentType MapContentType(uint contentType)
		{
			switch (contentType)
			{
			case 1U:
				return X509ContentType.Cert;
			case 4U:
				return X509ContentType.SerializedStore;
			case 5U:
				return X509ContentType.SerializedCert;
			case 8U:
			case 9U:
				return X509ContentType.Pkcs7;
			case 10U:
				return X509ContentType.Authenticode;
			case 12U:
				return X509ContentType.Pfx;
			}
			return X509ContentType.Unknown;
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x000825E4 File Offset: 0x000807E4
		internal static uint MapKeyStorageFlags(X509KeyStorageFlags keyStorageFlags)
		{
			if ((keyStorageFlags & (X509KeyStorageFlags.UserKeySet | X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable | X509KeyStorageFlags.UserProtected | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet)) != keyStorageFlags)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidFlag"), "keyStorageFlags");
			}
			X509KeyStorageFlags x509KeyStorageFlags = keyStorageFlags & (X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet);
			if (x509KeyStorageFlags == (X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.EphemeralKeySet))
			{
				throw new ArgumentException(Environment.GetResourceString("Cryptography_X509_InvalidFlagCombination", new object[]
				{
					x509KeyStorageFlags
				}), "keyStorageFlags");
			}
			uint num = 0U;
			if ((keyStorageFlags & X509KeyStorageFlags.UserKeySet) == X509KeyStorageFlags.UserKeySet)
			{
				num |= 4096U;
			}
			else if ((keyStorageFlags & X509KeyStorageFlags.MachineKeySet) == X509KeyStorageFlags.MachineKeySet)
			{
				num |= 32U;
			}
			if ((keyStorageFlags & X509KeyStorageFlags.Exportable) == X509KeyStorageFlags.Exportable)
			{
				num |= 1U;
			}
			if ((keyStorageFlags & X509KeyStorageFlags.UserProtected) == X509KeyStorageFlags.UserProtected)
			{
				num |= 2U;
			}
			if ((keyStorageFlags & X509KeyStorageFlags.EphemeralKeySet) == X509KeyStorageFlags.EphemeralKeySet)
			{
				num |= 33280U;
			}
			return num;
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x00082680 File Offset: 0x00080880
		[SecurityCritical]
		internal static SafeCertStoreHandle ExportCertToMemoryStore(X509Certificate certificate)
		{
			SafeCertStoreHandle invalidHandle = SafeCertStoreHandle.InvalidHandle;
			X509Utils.OpenX509Store(2U, 8704U, null, invalidHandle);
			X509Utils._AddCertificateToStore(invalidHandle, certificate.CertContext);
			return invalidHandle;
		}

		// Token: 0x06002410 RID: 9232 RVA: 0x000826B0 File Offset: 0x000808B0
		[SecurityCritical]
		internal static IntPtr PasswordToHGlobalUni(object password)
		{
			if (password != null)
			{
				string text = password as string;
				if (text != null)
				{
					return Marshal.StringToHGlobalUni(text);
				}
				SecureString secureString = password as SecureString;
				if (secureString != null)
				{
					return Marshal.SecureStringToGlobalAllocUnicode(secureString);
				}
			}
			return IntPtr.Zero;
		}

		// Token: 0x06002411 RID: 9233
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("crypt32")]
		private static extern IntPtr CryptFindOIDInfo(OidKeyType dwKeyType, IntPtr pvKey, OidGroup dwGroupId);

		// Token: 0x06002412 RID: 9234
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void _AddCertificateToStore(SafeCertStoreHandle safeCertStoreHandle, SafeCertContextHandle safeCertContext);

		// Token: 0x06002413 RID: 9235
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _DuplicateCertContext(IntPtr handle, ref SafeCertContextHandle safeCertContext);

		// Token: 0x06002414 RID: 9236
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _ExportCertificatesToBlob(SafeCertStoreHandle safeCertStoreHandle, X509ContentType contentType, IntPtr password);

		// Token: 0x06002415 RID: 9237
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _GetCertRawData(SafeCertContextHandle safeCertContext);

		// Token: 0x06002416 RID: 9238
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void _GetDateNotAfter(SafeCertContextHandle safeCertContext, ref Win32Native.FILE_TIME fileTime);

		// Token: 0x06002417 RID: 9239
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void _GetDateNotBefore(SafeCertContextHandle safeCertContext, ref Win32Native.FILE_TIME fileTime);

		// Token: 0x06002418 RID: 9240
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string _GetIssuerName(SafeCertContextHandle safeCertContext, bool legacyV1Mode);

		// Token: 0x06002419 RID: 9241
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string _GetPublicKeyOid(SafeCertContextHandle safeCertContext);

		// Token: 0x0600241A RID: 9242
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _GetPublicKeyParameters(SafeCertContextHandle safeCertContext);

		// Token: 0x0600241B RID: 9243
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _GetPublicKeyValue(SafeCertContextHandle safeCertContext);

		// Token: 0x0600241C RID: 9244
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string _GetSubjectInfo(SafeCertContextHandle safeCertContext, uint displayType, bool legacyV1Mode);

		// Token: 0x0600241D RID: 9245
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _GetSerialNumber(SafeCertContextHandle safeCertContext);

		// Token: 0x0600241E RID: 9246
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] _GetThumbprint(SafeCertContextHandle safeCertContext);

		// Token: 0x0600241F RID: 9247
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _LoadCertFromBlob(byte[] rawData, IntPtr password, uint dwFlags, bool persistKeySet, ref SafeCertContextHandle pCertCtx);

		// Token: 0x06002420 RID: 9248
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _LoadCertFromFile(string fileName, IntPtr password, uint dwFlags, bool persistKeySet, ref SafeCertContextHandle pCertCtx);

		// Token: 0x06002421 RID: 9249
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _OpenX509Store(uint storeType, uint flags, string storeName, ref SafeCertStoreHandle safeCertStoreHandle);

		// Token: 0x06002422 RID: 9250
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint _QueryCertBlobType(byte[] rawData);

		// Token: 0x06002423 RID: 9251
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern uint _QueryCertFileType(string fileName);

		// Token: 0x06002424 RID: 9252 RVA: 0x000826E7 File Offset: 0x000808E7
		[SecurityCritical]
		internal static void DuplicateCertContext(IntPtr handle, SafeCertContextHandle safeCertContext)
		{
			X509Utils._DuplicateCertContext(handle, ref safeCertContext);
			if (!safeCertContext.IsInvalid)
			{
				GC.ReRegisterForFinalize(safeCertContext);
			}
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x000826FF File Offset: 0x000808FF
		[SecurityCritical]
		internal static void LoadCertFromBlob(byte[] rawData, IntPtr password, uint dwFlags, bool persistKeySet, SafeCertContextHandle pCertCtx)
		{
			X509Utils._LoadCertFromBlob(rawData, password, dwFlags, persistKeySet, ref pCertCtx);
			if (!pCertCtx.IsInvalid)
			{
				GC.ReRegisterForFinalize(pCertCtx);
			}
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x0008271C File Offset: 0x0008091C
		[SecurityCritical]
		internal static void LoadCertFromFile(string fileName, IntPtr password, uint dwFlags, bool persistKeySet, SafeCertContextHandle pCertCtx)
		{
			X509Utils._LoadCertFromFile(fileName, password, dwFlags, persistKeySet, ref pCertCtx);
			if (!pCertCtx.IsInvalid)
			{
				GC.ReRegisterForFinalize(pCertCtx);
			}
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x00082739 File Offset: 0x00080939
		[SecurityCritical]
		private static void OpenX509Store(uint storeType, uint flags, string storeName, SafeCertStoreHandle safeCertStoreHandle)
		{
			X509Utils._OpenX509Store(storeType, flags, storeName, ref safeCertStoreHandle);
			if (!safeCertStoreHandle.IsInvalid)
			{
				GC.ReRegisterForFinalize(safeCertStoreHandle);
			}
		}
	}
}
