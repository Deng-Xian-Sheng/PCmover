using System;
using System.Security;
using System.Threading;

namespace System.Text
{
	// Token: 0x02000A5F RID: 2655
	internal sealed class InternalDecoderBestFitFallbackBuffer : DecoderFallbackBuffer
	{
		// Token: 0x1700119F RID: 4511
		// (get) Token: 0x0600677F RID: 26495 RVA: 0x0015DC60 File Offset: 0x0015BE60
		private static object InternalSyncObject
		{
			get
			{
				if (InternalDecoderBestFitFallbackBuffer.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref InternalDecoderBestFitFallbackBuffer.s_InternalSyncObject, value, null);
				}
				return InternalDecoderBestFitFallbackBuffer.s_InternalSyncObject;
			}
		}

		// Token: 0x06006780 RID: 26496 RVA: 0x0015DC8C File Offset: 0x0015BE8C
		public InternalDecoderBestFitFallbackBuffer(InternalDecoderBestFitFallback fallback)
		{
			this.oFallback = fallback;
			if (this.oFallback.arrayBestFit == null)
			{
				object internalSyncObject = InternalDecoderBestFitFallbackBuffer.InternalSyncObject;
				lock (internalSyncObject)
				{
					if (this.oFallback.arrayBestFit == null)
					{
						this.oFallback.arrayBestFit = fallback.encoding.GetBestFitBytesToUnicodeData();
					}
				}
			}
		}

		// Token: 0x06006781 RID: 26497 RVA: 0x0015DD0C File Offset: 0x0015BF0C
		public override bool Fallback(byte[] bytesUnknown, int index)
		{
			this.cBestFit = this.TryBestFit(bytesUnknown);
			if (this.cBestFit == '\0')
			{
				this.cBestFit = this.oFallback.cReplacement;
			}
			this.iCount = (this.iSize = 1);
			return true;
		}

		// Token: 0x06006782 RID: 26498 RVA: 0x0015DD50 File Offset: 0x0015BF50
		public override char GetNextChar()
		{
			this.iCount--;
			if (this.iCount < 0)
			{
				return '\0';
			}
			if (this.iCount == 2147483647)
			{
				this.iCount = -1;
				return '\0';
			}
			return this.cBestFit;
		}

		// Token: 0x06006783 RID: 26499 RVA: 0x0015DD87 File Offset: 0x0015BF87
		public override bool MovePrevious()
		{
			if (this.iCount >= 0)
			{
				this.iCount++;
			}
			return this.iCount >= 0 && this.iCount <= this.iSize;
		}

		// Token: 0x170011A0 RID: 4512
		// (get) Token: 0x06006784 RID: 26500 RVA: 0x0015DDBC File Offset: 0x0015BFBC
		public override int Remaining
		{
			get
			{
				if (this.iCount <= 0)
				{
					return 0;
				}
				return this.iCount;
			}
		}

		// Token: 0x06006785 RID: 26501 RVA: 0x0015DDCF File Offset: 0x0015BFCF
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.iCount = -1;
			this.byteStart = null;
		}

		// Token: 0x06006786 RID: 26502 RVA: 0x0015DDE0 File Offset: 0x0015BFE0
		[SecurityCritical]
		internal unsafe override int InternalFallback(byte[] bytes, byte* pBytes)
		{
			return 1;
		}

		// Token: 0x06006787 RID: 26503 RVA: 0x0015DDE4 File Offset: 0x0015BFE4
		private char TryBestFit(byte[] bytesCheck)
		{
			int num = 0;
			int num2 = this.oFallback.arrayBestFit.Length;
			if (num2 == 0)
			{
				return '\0';
			}
			if (bytesCheck.Length == 0 || bytesCheck.Length > 2)
			{
				return '\0';
			}
			char c;
			if (bytesCheck.Length == 1)
			{
				c = (char)bytesCheck[0];
			}
			else
			{
				c = (char)(((int)bytesCheck[0] << 8) + (int)bytesCheck[1]);
			}
			if (c < this.oFallback.arrayBestFit[0] || c > this.oFallback.arrayBestFit[num2 - 2])
			{
				return '\0';
			}
			int num3;
			while ((num3 = num2 - num) > 6)
			{
				int i = num3 / 2 + num & 65534;
				char c2 = this.oFallback.arrayBestFit[i];
				if (c2 == c)
				{
					return this.oFallback.arrayBestFit[i + 1];
				}
				if (c2 < c)
				{
					num = i;
				}
				else
				{
					num2 = i;
				}
			}
			for (int i = num; i < num2; i += 2)
			{
				if (this.oFallback.arrayBestFit[i] == c)
				{
					return this.oFallback.arrayBestFit[i + 1];
				}
			}
			return '\0';
		}

		// Token: 0x04002E3C RID: 11836
		internal char cBestFit;

		// Token: 0x04002E3D RID: 11837
		internal int iCount = -1;

		// Token: 0x04002E3E RID: 11838
		internal int iSize;

		// Token: 0x04002E3F RID: 11839
		private InternalDecoderBestFitFallback oFallback;

		// Token: 0x04002E40 RID: 11840
		private static object s_InternalSyncObject;
	}
}
