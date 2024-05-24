using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PCmover.Tools
{
	// Token: 0x02000044 RID: 68
	internal class Encryptor
	{
		// Token: 0x0600036F RID: 879 RVA: 0x00008D68 File Offset: 0x00006F68
		internal static string Encrypt(string instring, bool bFIPS)
		{
			if (string.IsNullOrEmpty(instring))
			{
				return string.Empty;
			}
			byte[] array = Encryptor.encryptStringToBytes_AES(instring, bFIPS);
			string result;
			if (bFIPS)
			{
				result = Convert.ToBase64String(array);
			}
			else
			{
				result = Encryptor.bytes2hexstr(array);
			}
			Array.Clear(array, 0, array.Length);
			return result;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00008DAD File Offset: 0x00006FAD
		internal static string Encrypt(string instring, byte[] key)
		{
			Encryptor._Key = key;
			return Encryptor.Encrypt(instring, true);
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00008DBC File Offset: 0x00006FBC
		internal static string Decrypt(string hexencryptedstr, bool bFIPS)
		{
			string result;
			try
			{
				if (string.IsNullOrEmpty(hexencryptedstr))
				{
					result = string.Empty;
				}
				else
				{
					byte[] array;
					if (bFIPS)
					{
						array = Convert.FromBase64String(hexencryptedstr);
					}
					else
					{
						array = Encryptor.hexstr2bytes(hexencryptedstr);
					}
					string text = Encryptor.decryptStringFromBytes_AES(array, bFIPS);
					Array.Clear(array, 0, array.Length);
					result = text;
				}
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00008E1C File Offset: 0x0000701C
		internal static string Decrypt(string hexencryptedstr, byte[] key)
		{
			Encryptor._Key = key;
			return Encryptor.Decrypt(hexencryptedstr, true);
		}

		// Token: 0x06000373 RID: 883 RVA: 0x00008E2C File Offset: 0x0000702C
		private static byte[] hexstr2bytes(string HexString)
		{
			int length = HexString.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				HexString.Substring(i, 2);
				array[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
			}
			return array;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00008E74 File Offset: 0x00007074
		private static string bytes2hexstr(byte[] inbytes)
		{
			string text = "";
			foreach (byte value in inbytes)
			{
				text += string.Format("{0:x2}", Convert.ToUInt32(value));
			}
			return text;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00008EB8 File Offset: 0x000070B8
		private static byte[] encryptStringToBytes_AES(string plainText, bool bFIPS = true)
		{
			if (plainText == null || plainText.Length <= 0)
			{
				throw new ArgumentNullException("plainText");
			}
			MemoryStream memoryStream = null;
			CryptoStream cryptoStream = null;
			StreamWriter streamWriter = null;
			SymmetricAlgorithm symmetricAlgorithm = null;
			try
			{
				memoryStream = new MemoryStream();
				if (bFIPS)
				{
					symmetricAlgorithm = new AesCryptoServiceProvider();
					symmetricAlgorithm.Key = Encryptor._Key;
					symmetricAlgorithm.GenerateIV();
					memoryStream.Write(symmetricAlgorithm.IV, 0, symmetricAlgorithm.IV.Length);
					symmetricAlgorithm.Mode = CipherMode.CBC;
					symmetricAlgorithm.Padding = PaddingMode.PKCS7;
				}
				else
				{
					symmetricAlgorithm = new RijndaelManaged();
					symmetricAlgorithm.Key = Encryptor._Key;
					symmetricAlgorithm.IV = Encryptor.ZeroInitVector;
					symmetricAlgorithm.Mode = CipherMode.CFB;
					symmetricAlgorithm.Padding = PaddingMode.Zeros;
				}
				ICryptoTransform transform = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
				cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				streamWriter = new StreamWriter(cryptoStream);
				streamWriter.Write(plainText);
				streamWriter.Write('\0');
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
				if (cryptoStream != null)
				{
					cryptoStream.Close();
				}
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
				if (symmetricAlgorithm != null)
				{
					symmetricAlgorithm.Clear();
				}
			}
			return memoryStream.ToArray();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00008FC4 File Offset: 0x000071C4
		private static string decryptStringFromBytes_AES(byte[] cipherText, bool bFIPS = true)
		{
			if (cipherText == null || cipherText.Length == 0)
			{
				throw new ArgumentNullException("cipherText");
			}
			MemoryStream memoryStream = null;
			CryptoStream cryptoStream = null;
			StreamReader streamReader = null;
			SymmetricAlgorithm symmetricAlgorithm = null;
			string text = null;
			try
			{
				memoryStream = new MemoryStream(cipherText);
				if (bFIPS)
				{
					symmetricAlgorithm = new AesCryptoServiceProvider();
					symmetricAlgorithm.Mode = CipherMode.CBC;
					symmetricAlgorithm.Padding = PaddingMode.PKCS7;
					byte[] array = new byte[symmetricAlgorithm.BlockSize / 8];
					memoryStream.Read(array, 0, array.Length);
					symmetricAlgorithm.IV = array;
					symmetricAlgorithm.Key = Encryptor._Key;
				}
				else
				{
					symmetricAlgorithm = new RijndaelManaged();
					symmetricAlgorithm.Mode = CipherMode.CFB;
					symmetricAlgorithm.Padding = PaddingMode.Zeros;
					symmetricAlgorithm.IV = Encryptor.ZeroInitVector;
					symmetricAlgorithm.Key = Encryptor._Key;
				}
				ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
				cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
				streamReader = new StreamReader(cryptoStream);
				text = streamReader.ReadToEnd();
				int num = text.IndexOf('\0');
				if (num > 0)
				{
					text = text.Remove(num);
				}
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Close();
				}
				if (cryptoStream != null)
				{
					cryptoStream.Close();
				}
				if (memoryStream != null)
				{
					memoryStream.Close();
				}
				if (symmetricAlgorithm != null)
				{
					symmetricAlgorithm.Clear();
				}
			}
			return text;
		}

		// Token: 0x0400013C RID: 316
		private static byte[] _Key = Encoding.ASCII.GetBytes("FtHuIO8&7GHhKlLu");

		// Token: 0x0400013D RID: 317
		private static readonly byte[] ZeroInitVector = new byte[16];
	}
}
