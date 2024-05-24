using System;
using System.Security.Cryptography;
using System.Text;

namespace PCmover.Infrastructure
{
	// Token: 0x0200000D RID: 13
	public static class DataProtectionApiWrapper
	{
		// Token: 0x06000060 RID: 96 RVA: 0x000029F1 File Offset: 0x00000BF1
		public static string Encrypt(this string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(text), null, DataProtectionScope.LocalMachine));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002A18 File Offset: 0x00000C18
		public static string Decrypt(this string cipher)
		{
			if (cipher == null)
			{
				throw new ArgumentNullException("cipher");
			}
			byte[] bytes = ProtectedData.Unprotect(Convert.FromBase64String(cipher), null, DataProtectionScope.LocalMachine);
			return Encoding.Unicode.GetString(bytes);
		}

		// Token: 0x0400002F RID: 47
		private const DataProtectionScope Scope = DataProtectionScope.LocalMachine;
	}
}
