using System;

namespace System.Globalization
{
	// Token: 0x020003AF RID: 943
	internal class TokenHashValue
	{
		// Token: 0x06002F2A RID: 12074 RVA: 0x000B507A File Offset: 0x000B327A
		internal TokenHashValue(string tokenString, TokenType tokenType, int tokenValue)
		{
			this.tokenString = tokenString;
			this.tokenType = tokenType;
			this.tokenValue = tokenValue;
		}

		// Token: 0x040013C8 RID: 5064
		internal string tokenString;

		// Token: 0x040013C9 RID: 5065
		internal TokenType tokenType;

		// Token: 0x040013CA RID: 5066
		internal int tokenValue;
	}
}
