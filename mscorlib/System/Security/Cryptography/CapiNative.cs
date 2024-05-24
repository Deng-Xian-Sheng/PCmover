using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x0200023C RID: 572
	internal static class CapiNative
	{
		// Token: 0x06002093 RID: 8339 RVA: 0x000725A0 File Offset: 0x000707A0
		[SecurityCritical]
		internal static SafeCspHandle AcquireCsp(string keyContainer, string providerName, CapiNative.ProviderType providerType, CapiNative.CryptAcquireContextFlags flags)
		{
			if ((flags & CapiNative.CryptAcquireContextFlags.VerifyContext) == CapiNative.CryptAcquireContextFlags.VerifyContext && (flags & CapiNative.CryptAcquireContextFlags.MachineKeyset) == CapiNative.CryptAcquireContextFlags.MachineKeyset)
			{
				flags &= ~CapiNative.CryptAcquireContextFlags.MachineKeyset;
			}
			SafeCspHandle result = null;
			if (!CapiNative.UnsafeNativeMethods.CryptAcquireContext(out result, keyContainer, providerName, providerType, flags))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
			return result;
		}

		// Token: 0x06002094 RID: 8340 RVA: 0x000725E4 File Offset: 0x000707E4
		[SecurityCritical]
		internal static SafeCspHashHandle CreateHashAlgorithm(SafeCspHandle cspHandle, CapiNative.AlgorithmID algorithm)
		{
			SafeCspHashHandle result = null;
			if (!CapiNative.UnsafeNativeMethods.CryptCreateHash(cspHandle, algorithm, IntPtr.Zero, 0, out result))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
			return result;
		}

		// Token: 0x06002095 RID: 8341 RVA: 0x00072610 File Offset: 0x00070810
		[SecurityCritical]
		internal static void GenerateRandomBytes(SafeCspHandle cspHandle, byte[] buffer)
		{
			if (!CapiNative.UnsafeNativeMethods.CryptGenRandom(cspHandle, buffer.Length, buffer))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
		}

		// Token: 0x06002096 RID: 8342 RVA: 0x0007262C File Offset: 0x0007082C
		[SecurityCritical]
		internal unsafe static void GenerateRandomBytes(SafeCspHandle cspHandle, byte[] buffer, int offset, int count)
		{
			fixed (byte* ptr = &buffer[offset])
			{
				byte* pbBuffer = ptr;
				if (!CapiNative.UnsafeNativeMethods.CryptGenRandom(cspHandle, count, pbBuffer))
				{
					throw new CryptographicException(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x0007265C File Offset: 0x0007085C
		[SecurityCritical]
		internal static int GetHashPropertyInt32(SafeCspHashHandle hashHandle, CapiNative.HashProperty property)
		{
			byte[] hashProperty = CapiNative.GetHashProperty(hashHandle, property);
			if (hashProperty.Length != 4)
			{
				return 0;
			}
			return BitConverter.ToInt32(hashProperty, 0);
		}

		// Token: 0x06002098 RID: 8344 RVA: 0x00072680 File Offset: 0x00070880
		[SecurityCritical]
		internal static byte[] GetHashProperty(SafeCspHashHandle hashHandle, CapiNative.HashProperty property)
		{
			int num = 0;
			byte[] array = null;
			if (!CapiNative.UnsafeNativeMethods.CryptGetHashParam(hashHandle, property, array, ref num, 0))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error != 234)
				{
					throw new CryptographicException(lastWin32Error);
				}
			}
			array = new byte[num];
			if (!CapiNative.UnsafeNativeMethods.CryptGetHashParam(hashHandle, property, array, ref num, 0))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
			return array;
		}

		// Token: 0x06002099 RID: 8345 RVA: 0x000726D4 File Offset: 0x000708D4
		[SecurityCritical]
		internal static int GetKeyPropertyInt32(SafeCspKeyHandle keyHandle, CapiNative.KeyProperty property)
		{
			byte[] keyProperty = CapiNative.GetKeyProperty(keyHandle, property);
			if (keyProperty.Length != 4)
			{
				return 0;
			}
			return BitConverter.ToInt32(keyProperty, 0);
		}

		// Token: 0x0600209A RID: 8346 RVA: 0x000726F8 File Offset: 0x000708F8
		[SecurityCritical]
		internal static byte[] GetKeyProperty(SafeCspKeyHandle keyHandle, CapiNative.KeyProperty property)
		{
			int num = 0;
			byte[] array = null;
			if (!CapiNative.UnsafeNativeMethods.CryptGetKeyParam(keyHandle, property, array, ref num, 0))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error != 234)
				{
					throw new CryptographicException(lastWin32Error);
				}
			}
			array = new byte[num];
			if (!CapiNative.UnsafeNativeMethods.CryptGetKeyParam(keyHandle, property, array, ref num, 0))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
			return array;
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x0007274B File Offset: 0x0007094B
		[SecurityCritical]
		internal static void SetHashProperty(SafeCspHashHandle hashHandle, CapiNative.HashProperty property, byte[] value)
		{
			if (!CapiNative.UnsafeNativeMethods.CryptSetHashParam(hashHandle, property, value, 0))
			{
				throw new CryptographicException(Marshal.GetLastWin32Error());
			}
		}

		// Token: 0x0600209C RID: 8348 RVA: 0x00072764 File Offset: 0x00070964
		[SecurityCritical]
		internal static bool VerifySignature(SafeCspHandle cspHandle, SafeCspKeyHandle keyHandle, CapiNative.AlgorithmID signatureAlgorithm, CapiNative.AlgorithmID hashAlgorithm, byte[] hashValue, byte[] signature)
		{
			byte[] array = new byte[signature.Length];
			Array.Copy(signature, array, array.Length);
			Array.Reverse(array);
			bool result;
			using (SafeCspHashHandle safeCspHashHandle = CapiNative.CreateHashAlgorithm(cspHandle, hashAlgorithm))
			{
				if (hashValue.Length != CapiNative.GetHashPropertyInt32(safeCspHashHandle, CapiNative.HashProperty.HashSize))
				{
					throw new CryptographicException(-2146893822);
				}
				CapiNative.SetHashProperty(safeCspHashHandle, CapiNative.HashProperty.HashValue, hashValue);
				if (CapiNative.UnsafeNativeMethods.CryptVerifySignature(safeCspHashHandle, array, array.Length, keyHandle, null, 0))
				{
					result = true;
				}
				else
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error != -2146893818)
					{
						throw new CryptographicException(lastWin32Error);
					}
					result = false;
				}
			}
			return result;
		}

		// Token: 0x02000B33 RID: 2867
		internal enum AlgorithmClass
		{
			// Token: 0x04003355 RID: 13141
			Any,
			// Token: 0x04003356 RID: 13142
			Signature = 8192,
			// Token: 0x04003357 RID: 13143
			DataEncrypt = 24576,
			// Token: 0x04003358 RID: 13144
			Hash = 32768,
			// Token: 0x04003359 RID: 13145
			KeyExchange = 40960
		}

		// Token: 0x02000B34 RID: 2868
		internal enum AlgorithmType
		{
			// Token: 0x0400335B RID: 13147
			Any,
			// Token: 0x0400335C RID: 13148
			Rsa = 1024,
			// Token: 0x0400335D RID: 13149
			Block = 1536
		}

		// Token: 0x02000B35 RID: 2869
		internal enum AlgorithmSubId
		{
			// Token: 0x0400335F RID: 13151
			Any,
			// Token: 0x04003360 RID: 13152
			RsaAny = 0,
			// Token: 0x04003361 RID: 13153
			Rc2 = 2,
			// Token: 0x04003362 RID: 13154
			Md5,
			// Token: 0x04003363 RID: 13155
			Sha1,
			// Token: 0x04003364 RID: 13156
			Sha256 = 12,
			// Token: 0x04003365 RID: 13157
			Sha384,
			// Token: 0x04003366 RID: 13158
			Sha512,
			// Token: 0x04003367 RID: 13159
			Hmac = 9
		}

		// Token: 0x02000B36 RID: 2870
		internal enum AlgorithmID
		{
			// Token: 0x04003369 RID: 13161
			None,
			// Token: 0x0400336A RID: 13162
			RsaSign = 9216,
			// Token: 0x0400336B RID: 13163
			RsaKeyExchange = 41984,
			// Token: 0x0400336C RID: 13164
			Rc2 = 26114,
			// Token: 0x0400336D RID: 13165
			Md5 = 32771,
			// Token: 0x0400336E RID: 13166
			Sha1,
			// Token: 0x0400336F RID: 13167
			Sha256 = 32780,
			// Token: 0x04003370 RID: 13168
			Sha384,
			// Token: 0x04003371 RID: 13169
			Sha512,
			// Token: 0x04003372 RID: 13170
			Hmac = 32777
		}

		// Token: 0x02000B37 RID: 2871
		[Flags]
		internal enum CryptAcquireContextFlags
		{
			// Token: 0x04003374 RID: 13172
			None = 0,
			// Token: 0x04003375 RID: 13173
			NewKeyset = 8,
			// Token: 0x04003376 RID: 13174
			DeleteKeyset = 16,
			// Token: 0x04003377 RID: 13175
			MachineKeyset = 32,
			// Token: 0x04003378 RID: 13176
			Silent = 64,
			// Token: 0x04003379 RID: 13177
			VerifyContext = -268435456
		}

		// Token: 0x02000B38 RID: 2872
		internal enum ErrorCode
		{
			// Token: 0x0400337B RID: 13179
			Ok,
			// Token: 0x0400337C RID: 13180
			MoreData = 234,
			// Token: 0x0400337D RID: 13181
			BadHash = -2146893822,
			// Token: 0x0400337E RID: 13182
			BadData = -2146893819,
			// Token: 0x0400337F RID: 13183
			BadSignature,
			// Token: 0x04003380 RID: 13184
			NoKey = -2146893811
		}

		// Token: 0x02000B39 RID: 2873
		internal enum HashProperty
		{
			// Token: 0x04003382 RID: 13186
			None,
			// Token: 0x04003383 RID: 13187
			HashValue = 2,
			// Token: 0x04003384 RID: 13188
			HashSize = 4,
			// Token: 0x04003385 RID: 13189
			HmacInfo
		}

		// Token: 0x02000B3A RID: 2874
		[Flags]
		internal enum KeyGenerationFlags
		{
			// Token: 0x04003387 RID: 13191
			None = 0,
			// Token: 0x04003388 RID: 13192
			Exportable = 1,
			// Token: 0x04003389 RID: 13193
			UserProtected = 2,
			// Token: 0x0400338A RID: 13194
			Archivable = 16384
		}

		// Token: 0x02000B3B RID: 2875
		internal enum KeyProperty
		{
			// Token: 0x0400338C RID: 13196
			None,
			// Token: 0x0400338D RID: 13197
			AlgorithmID = 7,
			// Token: 0x0400338E RID: 13198
			KeyLength = 9
		}

		// Token: 0x02000B3C RID: 2876
		internal enum KeySpec
		{
			// Token: 0x04003390 RID: 13200
			KeyExchange = 1,
			// Token: 0x04003391 RID: 13201
			Signature
		}

		// Token: 0x02000B3D RID: 2877
		internal static class ProviderNames
		{
			// Token: 0x04003392 RID: 13202
			internal const string MicrosoftEnhanced = "Microsoft Enhanced Cryptographic Provider v1.0";
		}

		// Token: 0x02000B3E RID: 2878
		internal enum ProviderType
		{
			// Token: 0x04003394 RID: 13204
			RsaFull = 1,
			// Token: 0x04003395 RID: 13205
			RsaAes = 24
		}

		// Token: 0x02000B3F RID: 2879
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		internal static class SafeNativeMethods
		{
			// Token: 0x06006B72 RID: 27506
			[DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptAcquireContext(out SafeCspHandle phProv, IntPtr pszContainer, IntPtr pszProvider, CapiNative.ProviderType dwProvType, CapiNative.CryptAcquireContextFlags dwFlags);

			// Token: 0x06006B73 RID: 27507
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptCreateHash(SafeCspHandle hProv, CapiNative.AlgorithmID Algid, IntPtr hKey, int dwFlags, out SafeCspHashHandle phHash);

			// Token: 0x06006B74 RID: 27508
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptGetHashParam(SafeCspHashHandle hHash, CapiNative.HashProperty dwParam, [MarshalAs(UnmanagedType.LPArray)] [In] [Out] byte[] pbData, [In] [Out] ref int pdwDataLen, int dwFlags);

			// Token: 0x06006B75 RID: 27509
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptHashData(SafeCspHashHandle hHash, IntPtr pbData, int dwDataLen, int dwFlags);

			// Token: 0x06006B76 RID: 27510
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptImportKey(SafeCspHandle hProv, IntPtr pbData, int dwDataLen, IntPtr hPubKey, CapiNative.KeyGenerationFlags dwFlags, out SafeCspKeyHandle phKey);

			// Token: 0x06006B77 RID: 27511
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptSetHashParam(SafeCspHashHandle hHash, CapiNative.HashProperty dwParam, IntPtr pbData, int dwFlags);

			// Token: 0x04003396 RID: 13206
			internal static readonly Lazy<SafeCspHandle> DefaultProvider = new Lazy<SafeCspHandle>(delegate()
			{
				SafeCspHandle safeCspHandle;
				if (!CapiNative.SafeNativeMethods.CryptAcquireContext(out safeCspHandle, IntPtr.Zero, IntPtr.Zero, CapiNative.ProviderType.RsaAes, CapiNative.CryptAcquireContextFlags.VerifyContext))
				{
					Exception ex = new CryptographicException(Marshal.GetLastWin32Error());
					safeCspHandle.Dispose();
					throw ex;
				}
				return safeCspHandle;
			});
		}

		// Token: 0x02000B40 RID: 2880
		[SecurityCritical]
		internal static class UnsafeNativeMethods
		{
			// Token: 0x06006B79 RID: 27513
			[DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptAcquireContext(out SafeCspHandle phProv, string pszContainer, string pszProvider, CapiNative.ProviderType dwProvType, CapiNative.CryptAcquireContextFlags dwFlags);

			// Token: 0x06006B7A RID: 27514
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptCreateHash(SafeCspHandle hProv, CapiNative.AlgorithmID Algid, IntPtr hKey, int dwFlags, out SafeCspHashHandle phHash);

			// Token: 0x06006B7B RID: 27515
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptGenKey(SafeCspHandle hProv, int Algid, uint dwFlags, out SafeCspKeyHandle phKey);

			// Token: 0x06006B7C RID: 27516
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptGenRandom(SafeCspHandle hProv, int dwLen, [MarshalAs(UnmanagedType.LPArray)] [In] [Out] byte[] pbBuffer);

			// Token: 0x06006B7D RID: 27517
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal unsafe static extern bool CryptGenRandom(SafeCspHandle hProv, int dwLen, byte* pbBuffer);

			// Token: 0x06006B7E RID: 27518
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptGetHashParam(SafeCspHashHandle hHash, CapiNative.HashProperty dwParam, [MarshalAs(UnmanagedType.LPArray)] [In] [Out] byte[] pbData, [In] [Out] ref int pdwDataLen, int dwFlags);

			// Token: 0x06006B7F RID: 27519
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptGetKeyParam(SafeCspKeyHandle hKey, CapiNative.KeyProperty dwParam, [MarshalAs(UnmanagedType.LPArray)] [In] [Out] byte[] pbData, [In] [Out] ref int pdwDataLen, int dwFlags);

			// Token: 0x06006B80 RID: 27520
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptImportKey(SafeCspHandle hProv, [MarshalAs(UnmanagedType.LPArray)] [In] byte[] pbData, int pdwDataLen, IntPtr hPubKey, CapiNative.KeyGenerationFlags dwFlags, out SafeCspKeyHandle phKey);

			// Token: 0x06006B81 RID: 27521
			[DllImport("advapi32", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptSetHashParam(SafeCspHashHandle hHash, CapiNative.HashProperty dwParam, [MarshalAs(UnmanagedType.LPArray)] [In] byte[] pbData, int dwFlags);

			// Token: 0x06006B82 RID: 27522
			[DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CryptVerifySignature(SafeCspHashHandle hHash, [MarshalAs(UnmanagedType.LPArray)] [In] byte[] pbSignature, int dwSigLen, SafeCspKeyHandle hPubKey, string sDescription, int dwFlags);
		}
	}
}
