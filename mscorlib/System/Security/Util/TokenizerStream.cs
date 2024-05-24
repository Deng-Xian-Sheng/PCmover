using System;

namespace System.Security.Util
{
	// Token: 0x02000387 RID: 903
	internal sealed class TokenizerStream
	{
		// Token: 0x06002CCA RID: 11466 RVA: 0x000A8E41 File Offset: 0x000A7041
		internal TokenizerStream()
		{
			this.m_countTokens = 0;
			this.m_headTokens = new TokenizerShortBlock();
			this.m_headStrings = new TokenizerStringBlock();
			this.Reset();
		}

		// Token: 0x06002CCB RID: 11467 RVA: 0x000A8E6C File Offset: 0x000A706C
		internal void AddToken(short token)
		{
			if (this.m_currentTokens.m_block.Length <= this.m_indexTokens)
			{
				this.m_currentTokens.m_next = new TokenizerShortBlock();
				this.m_currentTokens = this.m_currentTokens.m_next;
				this.m_indexTokens = 0;
			}
			this.m_countTokens++;
			short[] block = this.m_currentTokens.m_block;
			int indexTokens = this.m_indexTokens;
			this.m_indexTokens = indexTokens + 1;
			block[indexTokens] = token;
		}

		// Token: 0x06002CCC RID: 11468 RVA: 0x000A8EE4 File Offset: 0x000A70E4
		internal void AddString(string str)
		{
			if (this.m_currentStrings.m_block.Length <= this.m_indexStrings)
			{
				this.m_currentStrings.m_next = new TokenizerStringBlock();
				this.m_currentStrings = this.m_currentStrings.m_next;
				this.m_indexStrings = 0;
			}
			string[] block = this.m_currentStrings.m_block;
			int indexStrings = this.m_indexStrings;
			this.m_indexStrings = indexStrings + 1;
			block[indexStrings] = str;
		}

		// Token: 0x06002CCD RID: 11469 RVA: 0x000A8F4C File Offset: 0x000A714C
		internal void Reset()
		{
			this.m_lastTokens = null;
			this.m_currentTokens = this.m_headTokens;
			this.m_currentStrings = this.m_headStrings;
			this.m_indexTokens = 0;
			this.m_indexStrings = 0;
		}

		// Token: 0x06002CCE RID: 11470 RVA: 0x000A8F7C File Offset: 0x000A717C
		internal short GetNextFullToken()
		{
			if (this.m_currentTokens.m_block.Length <= this.m_indexTokens)
			{
				this.m_lastTokens = this.m_currentTokens;
				this.m_currentTokens = this.m_currentTokens.m_next;
				this.m_indexTokens = 0;
			}
			short[] block = this.m_currentTokens.m_block;
			int indexTokens = this.m_indexTokens;
			this.m_indexTokens = indexTokens + 1;
			return block[indexTokens];
		}

		// Token: 0x06002CCF RID: 11471 RVA: 0x000A8FE0 File Offset: 0x000A71E0
		internal short GetNextToken()
		{
			return this.GetNextFullToken() & 255;
		}

		// Token: 0x06002CD0 RID: 11472 RVA: 0x000A8FFC File Offset: 0x000A71FC
		internal string GetNextString()
		{
			if (this.m_currentStrings.m_block.Length <= this.m_indexStrings)
			{
				this.m_currentStrings = this.m_currentStrings.m_next;
				this.m_indexStrings = 0;
			}
			string[] block = this.m_currentStrings.m_block;
			int indexStrings = this.m_indexStrings;
			this.m_indexStrings = indexStrings + 1;
			return block[indexStrings];
		}

		// Token: 0x06002CD1 RID: 11473 RVA: 0x000A9053 File Offset: 0x000A7253
		internal void ThrowAwayNextString()
		{
			this.GetNextString();
		}

		// Token: 0x06002CD2 RID: 11474 RVA: 0x000A905C File Offset: 0x000A725C
		internal void TagLastToken(short tag)
		{
			if (this.m_indexTokens == 0)
			{
				this.m_lastTokens.m_block[this.m_lastTokens.m_block.Length - 1] = (short)((ushort)this.m_lastTokens.m_block[this.m_lastTokens.m_block.Length - 1] | (ushort)tag);
				return;
			}
			this.m_currentTokens.m_block[this.m_indexTokens - 1] = (short)((ushort)this.m_currentTokens.m_block[this.m_indexTokens - 1] | (ushort)tag);
		}

		// Token: 0x06002CD3 RID: 11475 RVA: 0x000A90DA File Offset: 0x000A72DA
		internal int GetTokenCount()
		{
			return this.m_countTokens;
		}

		// Token: 0x06002CD4 RID: 11476 RVA: 0x000A90E4 File Offset: 0x000A72E4
		internal void GoToPosition(int position)
		{
			this.Reset();
			for (int i = 0; i < position; i++)
			{
				if (this.GetNextToken() == 3)
				{
					this.ThrowAwayNextString();
				}
			}
		}

		// Token: 0x0400121A RID: 4634
		private int m_countTokens;

		// Token: 0x0400121B RID: 4635
		private TokenizerShortBlock m_headTokens;

		// Token: 0x0400121C RID: 4636
		private TokenizerShortBlock m_lastTokens;

		// Token: 0x0400121D RID: 4637
		private TokenizerShortBlock m_currentTokens;

		// Token: 0x0400121E RID: 4638
		private int m_indexTokens;

		// Token: 0x0400121F RID: 4639
		private TokenizerStringBlock m_headStrings;

		// Token: 0x04001220 RID: 4640
		private TokenizerStringBlock m_currentStrings;

		// Token: 0x04001221 RID: 4641
		private int m_indexStrings;
	}
}
