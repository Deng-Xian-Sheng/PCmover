using System;
using System.Security.Cryptography;
using System.Text;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000007 RID: 7
	public class CodeChallenge
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000020A4 File Offset: 0x000002A4
		// (set) Token: 0x06000029 RID: 41 RVA: 0x000020AC File Offset: 0x000002AC
		public string Challenge { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000020B5 File Offset: 0x000002B5
		// (set) Token: 0x0600002B RID: 43 RVA: 0x000020BD File Offset: 0x000002BD
		public string Verifier { get; private set; }

		// Token: 0x0600002C RID: 44 RVA: 0x000020C8 File Offset: 0x000002C8
		public CodeChallenge(string method)
		{
			if (method != "S256")
			{
				throw new Exception("Only S256 supported for CodeChallenge");
			}
			byte[] array = new byte[32];
			RandomNumberGenerator.Create().GetBytes(array);
			this.Verifier = CodeChallenge.Encode(array);
			this.Challenge = string.Empty;
			using (SHA256 sha = SHA256.Create())
			{
				this.Challenge = CodeChallenge.Encode(sha.ComputeHash(Encoding.UTF8.GetBytes(this.Verifier)));
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002160 File Offset: 0x00000360
		private CodeChallenge()
		{
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002168 File Offset: 0x00000368
		private static string Encode(byte[] bytes)
		{
			return Convert.ToBase64String(bytes).TrimEnd(new char[]
			{
				'='
			}).Replace('+', '-').Replace('/', '_');
		}
	}
}
