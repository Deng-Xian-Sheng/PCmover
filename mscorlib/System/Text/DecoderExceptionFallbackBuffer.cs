using System;
using System.Globalization;

namespace System.Text
{
	// Token: 0x02000A61 RID: 2657
	public sealed class DecoderExceptionFallbackBuffer : DecoderFallbackBuffer
	{
		// Token: 0x0600678D RID: 26509 RVA: 0x0015DEF5 File Offset: 0x0015C0F5
		public override bool Fallback(byte[] bytesUnknown, int index)
		{
			this.Throw(bytesUnknown, index);
			return true;
		}

		// Token: 0x0600678E RID: 26510 RVA: 0x0015DF00 File Offset: 0x0015C100
		public override char GetNextChar()
		{
			return '\0';
		}

		// Token: 0x0600678F RID: 26511 RVA: 0x0015DF03 File Offset: 0x0015C103
		public override bool MovePrevious()
		{
			return false;
		}

		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x06006790 RID: 26512 RVA: 0x0015DF06 File Offset: 0x0015C106
		public override int Remaining
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06006791 RID: 26513 RVA: 0x0015DF0C File Offset: 0x0015C10C
		private void Throw(byte[] bytesUnknown, int index)
		{
			StringBuilder stringBuilder = new StringBuilder(bytesUnknown.Length * 3);
			int num = 0;
			while (num < bytesUnknown.Length && num < 20)
			{
				stringBuilder.Append("[");
				stringBuilder.Append(bytesUnknown[num].ToString("X2", CultureInfo.InvariantCulture));
				stringBuilder.Append("]");
				num++;
			}
			if (num == 20)
			{
				stringBuilder.Append(" ...");
			}
			throw new DecoderFallbackException(Environment.GetResourceString("Argument_InvalidCodePageBytesIndex", new object[]
			{
				stringBuilder,
				index
			}), bytesUnknown, index);
		}
	}
}
