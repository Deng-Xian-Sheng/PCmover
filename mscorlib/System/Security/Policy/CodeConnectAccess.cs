using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Security.Policy
{
	// Token: 0x0200035D RID: 861
	[ComVisible(true)]
	[Serializable]
	public class CodeConnectAccess
	{
		// Token: 0x06002A85 RID: 10885 RVA: 0x0009D1C5 File Offset: 0x0009B3C5
		public CodeConnectAccess(string allowScheme, int allowPort)
		{
			if (!CodeConnectAccess.IsValidScheme(allowScheme))
			{
				throw new ArgumentOutOfRangeException("allowScheme");
			}
			this.SetCodeConnectAccess(allowScheme.ToLower(CultureInfo.InvariantCulture), allowPort);
		}

		// Token: 0x06002A86 RID: 10886 RVA: 0x0009D1F4 File Offset: 0x0009B3F4
		public static CodeConnectAccess CreateOriginSchemeAccess(int allowPort)
		{
			CodeConnectAccess codeConnectAccess = new CodeConnectAccess();
			codeConnectAccess.SetCodeConnectAccess(CodeConnectAccess.OriginScheme, allowPort);
			return codeConnectAccess;
		}

		// Token: 0x06002A87 RID: 10887 RVA: 0x0009D214 File Offset: 0x0009B414
		public static CodeConnectAccess CreateAnySchemeAccess(int allowPort)
		{
			CodeConnectAccess codeConnectAccess = new CodeConnectAccess();
			codeConnectAccess.SetCodeConnectAccess(CodeConnectAccess.AnyScheme, allowPort);
			return codeConnectAccess;
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x0009D234 File Offset: 0x0009B434
		private CodeConnectAccess()
		{
		}

		// Token: 0x06002A89 RID: 10889 RVA: 0x0009D23C File Offset: 0x0009B43C
		private void SetCodeConnectAccess(string lowerCaseScheme, int allowPort)
		{
			this._LowerCaseScheme = lowerCaseScheme;
			if (allowPort == CodeConnectAccess.DefaultPort)
			{
				this._LowerCasePort = "$default";
			}
			else if (allowPort == CodeConnectAccess.OriginPort)
			{
				this._LowerCasePort = "$origin";
			}
			else
			{
				if (allowPort < 0 || allowPort > 65535)
				{
					throw new ArgumentOutOfRangeException("allowPort");
				}
				this._LowerCasePort = allowPort.ToString(CultureInfo.InvariantCulture);
			}
			this._IntPort = allowPort;
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06002A8A RID: 10890 RVA: 0x0009D2AA File Offset: 0x0009B4AA
		public string Scheme
		{
			get
			{
				return this._LowerCaseScheme;
			}
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06002A8B RID: 10891 RVA: 0x0009D2B2 File Offset: 0x0009B4B2
		public int Port
		{
			get
			{
				return this._IntPort;
			}
		}

		// Token: 0x06002A8C RID: 10892 RVA: 0x0009D2BC File Offset: 0x0009B4BC
		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			CodeConnectAccess codeConnectAccess = o as CodeConnectAccess;
			return codeConnectAccess != null && this.Scheme == codeConnectAccess.Scheme && this.Port == codeConnectAccess.Port;
		}

		// Token: 0x06002A8D RID: 10893 RVA: 0x0009D300 File Offset: 0x0009B500
		public override int GetHashCode()
		{
			return this.Scheme.GetHashCode() + this.Port.GetHashCode();
		}

		// Token: 0x06002A8E RID: 10894 RVA: 0x0009D328 File Offset: 0x0009B528
		internal CodeConnectAccess(string allowScheme, string allowPort)
		{
			if (allowScheme == null || allowScheme.Length == 0)
			{
				throw new ArgumentNullException("allowScheme");
			}
			if (allowPort == null || allowPort.Length == 0)
			{
				throw new ArgumentNullException("allowPort");
			}
			this._LowerCaseScheme = allowScheme.ToLower(CultureInfo.InvariantCulture);
			if (this._LowerCaseScheme == CodeConnectAccess.OriginScheme)
			{
				this._LowerCaseScheme = CodeConnectAccess.OriginScheme;
			}
			else if (this._LowerCaseScheme == CodeConnectAccess.AnyScheme)
			{
				this._LowerCaseScheme = CodeConnectAccess.AnyScheme;
			}
			else if (!CodeConnectAccess.IsValidScheme(this._LowerCaseScheme))
			{
				throw new ArgumentOutOfRangeException("allowScheme");
			}
			this._LowerCasePort = allowPort.ToLower(CultureInfo.InvariantCulture);
			if (this._LowerCasePort == "$default")
			{
				this._IntPort = CodeConnectAccess.DefaultPort;
				return;
			}
			if (this._LowerCasePort == "$origin")
			{
				this._IntPort = CodeConnectAccess.OriginPort;
				return;
			}
			this._IntPort = int.Parse(allowPort, CultureInfo.InvariantCulture);
			if (this._IntPort < 0 || this._IntPort > 65535)
			{
				throw new ArgumentOutOfRangeException("allowPort");
			}
			this._LowerCasePort = this._IntPort.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06002A8F RID: 10895 RVA: 0x0009D463 File Offset: 0x0009B663
		internal bool IsOriginScheme
		{
			get
			{
				return this._LowerCaseScheme == CodeConnectAccess.OriginScheme;
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06002A90 RID: 10896 RVA: 0x0009D472 File Offset: 0x0009B672
		internal bool IsAnyScheme
		{
			get
			{
				return this._LowerCaseScheme == CodeConnectAccess.AnyScheme;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06002A91 RID: 10897 RVA: 0x0009D481 File Offset: 0x0009B681
		internal bool IsDefaultPort
		{
			get
			{
				return this.Port == CodeConnectAccess.DefaultPort;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06002A92 RID: 10898 RVA: 0x0009D490 File Offset: 0x0009B690
		internal bool IsOriginPort
		{
			get
			{
				return this.Port == CodeConnectAccess.OriginPort;
			}
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06002A93 RID: 10899 RVA: 0x0009D49F File Offset: 0x0009B69F
		internal string StrPort
		{
			get
			{
				return this._LowerCasePort;
			}
		}

		// Token: 0x06002A94 RID: 10900 RVA: 0x0009D4A8 File Offset: 0x0009B6A8
		internal static bool IsValidScheme(string scheme)
		{
			if (scheme == null || scheme.Length == 0 || !CodeConnectAccess.IsAsciiLetter(scheme[0]))
			{
				return false;
			}
			for (int i = scheme.Length - 1; i > 0; i--)
			{
				if (!CodeConnectAccess.IsAsciiLetterOrDigit(scheme[i]) && scheme[i] != '+' && scheme[i] != '-' && scheme[i] != '.')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002A95 RID: 10901 RVA: 0x0009D515 File Offset: 0x0009B715
		private static bool IsAsciiLetterOrDigit(char character)
		{
			return CodeConnectAccess.IsAsciiLetter(character) || (character >= '0' && character <= '9');
		}

		// Token: 0x06002A96 RID: 10902 RVA: 0x0009D530 File Offset: 0x0009B730
		private static bool IsAsciiLetter(char character)
		{
			return (character >= 'a' && character <= 'z') || (character >= 'A' && character <= 'Z');
		}

		// Token: 0x04001146 RID: 4422
		private string _LowerCaseScheme;

		// Token: 0x04001147 RID: 4423
		private string _LowerCasePort;

		// Token: 0x04001148 RID: 4424
		private int _IntPort;

		// Token: 0x04001149 RID: 4425
		private const string DefaultStr = "$default";

		// Token: 0x0400114A RID: 4426
		private const string OriginStr = "$origin";

		// Token: 0x0400114B RID: 4427
		internal const int NoPort = -1;

		// Token: 0x0400114C RID: 4428
		internal const int AnyPort = -2;

		// Token: 0x0400114D RID: 4429
		public static readonly int DefaultPort = -3;

		// Token: 0x0400114E RID: 4430
		public static readonly int OriginPort = -4;

		// Token: 0x0400114F RID: 4431
		public static readonly string OriginScheme = "$origin";

		// Token: 0x04001150 RID: 4432
		public static readonly string AnyScheme = "*";
	}
}
