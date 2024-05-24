using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000273 RID: 627
	internal sealed class NativeHmac : IDisposable
	{
		// Token: 0x0600222E RID: 8750 RVA: 0x00078CA1 File Offset: 0x00076EA1
		internal NativeHmac(CapiNative.AlgorithmID algId)
		{
			this._algId = algId;
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x00078CB0 File Offset: 0x00076EB0
		[SecuritySafeCritical]
		public void Dispose()
		{
			this.Reset();
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x00078CB8 File Offset: 0x00076EB8
		[SecuritySafeCritical]
		internal void SetKey(byte[] key)
		{
			SafeCspHandle value = CapiNative.SafeNativeMethods.DefaultProvider.Value;
			this._key = NativeHmac.OpenKeyHandle(value, key);
			try
			{
				this._hash = NativeHmac.OpenHmacHandle(value, this._algId, this._key);
			}
			catch (CryptographicException)
			{
				this._key.Dispose();
				this._key = null;
				throw;
			}
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x00078D1C File Offset: 0x00076F1C
		[SecuritySafeCritical]
		internal unsafe void AppendData(byte[] data, int offset, int count)
		{
			fixed (byte[] array = data)
			{
				byte* ptr;
				if (data == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = &array[0];
				}
				if (!CapiNative.SafeNativeMethods.CryptHashData(this._hash, (IntPtr)((void*)(ptr + offset)), count, 0))
				{
					throw new CryptographicException(Marshal.GetLastWin32Error());
				}
			}
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x00078D68 File Offset: 0x00076F68
		[SecuritySafeCritical]
		internal void Finish(byte[] output)
		{
			int num = output.Length;
			Exception ex = null;
			if (!CapiNative.SafeNativeMethods.CryptGetHashParam(this._hash, CapiNative.HashProperty.HashValue, output, ref num, 0))
			{
				ex = new CryptographicException(Marshal.GetLastWin32Error());
			}
			this.Reset();
			if (ex != null)
			{
				throw ex;
			}
			if (num != output.Length)
			{
				throw new CryptographicException();
			}
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x00078DAF File Offset: 0x00076FAF
		[SecuritySafeCritical]
		internal void Reset()
		{
			SafeCspHashHandle hash = this._hash;
			if (hash != null)
			{
				hash.Dispose();
			}
			this._hash = null;
			SafeCspKeyHandle key = this._key;
			if (key != null)
			{
				key.Dispose();
			}
			this._key = null;
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x00078DE4 File Offset: 0x00076FE4
		[SecurityCritical]
		private unsafe static SafeCspKeyHandle OpenKeyHandle(SafeCspHandle hProv, byte[] key)
		{
			if (key.Length > 128)
			{
				throw new CryptographicException();
			}
			int num = sizeof(NativeHmac.BLOBHEADER) + 4;
			int num2 = num + 128;
			int dwDataLen = num + key.Length;
			byte* ptr = stackalloc byte[(UIntPtr)num2];
			NativeHmac.BLOBHEADER* ptr2 = (NativeHmac.BLOBHEADER*)ptr;
			ptr2->bType = 8;
			ptr2->bVersion = 2;
			ptr2->reserved = 0;
			ptr2->aiKeyAlg = CapiNative.AlgorithmID.Rc2;
			int* ptr3 = (int*)(ptr + sizeof(NativeHmac.BLOBHEADER));
			byte* ptr4 = ptr + sizeof(NativeHmac.BLOBHEADER) + 4;
			if (key.Length >= 2)
			{
				*ptr3 = key.Length;
			}
			else
			{
				*ptr3 = 2;
				*(short*)ptr4 = 0;
				dwDataLen = num + 2;
			}
			Marshal.Copy(key, 0, (IntPtr)((void*)ptr4), key.Length);
			SafeCspKeyHandle safeCspKeyHandle;
			bool flag = CapiNative.SafeNativeMethods.CryptImportKey(hProv, (IntPtr)((void*)ptr), dwDataLen, IntPtr.Zero, (CapiNative.KeyGenerationFlags)256, out safeCspKeyHandle);
			for (int i = 0; i < key.Length; i++)
			{
				ptr4[i] = 0;
			}
			if (!flag)
			{
				Exception ex = new CryptographicException(Marshal.GetLastWin32Error());
				safeCspKeyHandle.Dispose();
				throw ex;
			}
			return safeCspKeyHandle;
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x00078ED8 File Offset: 0x000770D8
		[SecurityCritical]
		private unsafe static SafeCspHashHandle OpenHmacHandle(SafeCspHandle hProv, CapiNative.AlgorithmID algId, SafeCspKeyHandle macKey)
		{
			SafeCspHashHandle safeCspHashHandle;
			if (!CapiNative.SafeNativeMethods.CryptCreateHash(hProv, CapiNative.AlgorithmID.Hmac, macKey.DangerousGetHandle(), 0, out safeCspHashHandle))
			{
				Exception ex = new CryptographicException(Marshal.GetLastWin32Error());
				safeCspHashHandle.Dispose();
				throw ex;
			}
			NativeHmac.HMAC_Info hmac_Info = default(NativeHmac.HMAC_Info);
			hmac_Info.HashAlgid = algId;
			IntPtr pbData = new IntPtr((void*)(&hmac_Info));
			if (!CapiNative.SafeNativeMethods.CryptSetHashParam(safeCspHashHandle, CapiNative.HashProperty.HmacInfo, pbData, 0))
			{
				Exception ex2 = new CryptographicException(Marshal.GetLastWin32Error());
				safeCspHashHandle.Dispose();
				throw ex2;
			}
			GC.KeepAlive(macKey);
			return safeCspHashHandle;
		}

		// Token: 0x04000C66 RID: 3174
		[SecurityCritical]
		private SafeCspHashHandle _hash;

		// Token: 0x04000C67 RID: 3175
		[SecurityCritical]
		private SafeCspKeyHandle _key;

		// Token: 0x04000C68 RID: 3176
		private CapiNative.AlgorithmID _algId;

		// Token: 0x02000B47 RID: 2887
		private struct BLOBHEADER
		{
			// Token: 0x040033BC RID: 13244
			internal byte bType;

			// Token: 0x040033BD RID: 13245
			internal byte bVersion;

			// Token: 0x040033BE RID: 13246
			internal short reserved;

			// Token: 0x040033BF RID: 13247
			internal CapiNative.AlgorithmID aiKeyAlg;
		}

		// Token: 0x02000B48 RID: 2888
		private struct HMAC_Info
		{
			// Token: 0x040033C0 RID: 13248
			internal CapiNative.AlgorithmID HashAlgid;

			// Token: 0x040033C1 RID: 13249
			internal IntPtr pbInnerString;

			// Token: 0x040033C2 RID: 13250
			internal uint cbInnerString;

			// Token: 0x040033C3 RID: 13251
			internal IntPtr pbOuterString;

			// Token: 0x040033C4 RID: 13252
			internal uint cbOuterString;
		}
	}
}
