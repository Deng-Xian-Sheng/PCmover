using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PCmover.Tools
{
	// Token: 0x020000CB RID: 203
	internal class Encryptor
	{
		// Token: 0x06001068 RID: 4200 RVA: 0x0002AF08 File Offset: 0x00029108
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

		// Token: 0x06001069 RID: 4201 RVA: 0x0002AF4D File Offset: 0x0002914D
		internal static string Encrypt(string instring, byte[] key)
		{
			Encryptor._Key = key;
			return Encryptor.Encrypt(instring, true);
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0002AF5C File Offset: 0x0002915C
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

		// Token: 0x0600106B RID: 4203 RVA: 0x0002AFBC File Offset: 0x000291BC
		internal static string Decrypt(string hexencryptedstr, byte[] key)
		{
			Encryptor._Key = key;
			return Encryptor.Decrypt(hexencryptedstr, true);
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x0002AFCC File Offset: 0x000291CC
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

		// Token: 0x0600106D RID: 4205 RVA: 0x0002B014 File Offset: 0x00029214
		private static string bytes2hexstr(byte[] inbytes)
		{
			string text = "";
			foreach (byte value in inbytes)
			{
				text += string.Format("{0:x2}", Convert.ToUInt32(value));
			}
			return text;
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x0002B058 File Offset: 0x00029258
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

		// Token: 0x0600106F RID: 4207 RVA: 0x0002B164 File Offset: 0x00029364
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

		// Token: 0x04000585 RID: 1413
		private static byte[] _Key = Encoding.ASCII.GetBytes("FtHuIO8&7GHhKlLu");

		// Token: 0x04000586 RID: 1414
		private static readonly byte[] ZeroInitVector = new byte[16];
	}
}
