using System;
using System.Security;
using System.Threading;

namespace System.Text
{
	// Token: 0x02000A6A RID: 2666
	internal sealed class InternalEncoderBestFitFallbackBuffer : EncoderFallbackBuffer
	{
		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x060067DB RID: 26587 RVA: 0x0015EEF8 File Offset: 0x0015D0F8
		private static object InternalSyncObject
		{
			get
			{
				if (InternalEncoderBestFitFallbackBuffer.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref InternalEncoderBestFitFallbackBuffer.s_InternalSyncObject, value, null);
				}
				return InternalEncoderBestFitFallbackBuffer.s_InternalSyncObject;
			}
		}

		// Token: 0x060067DC RID: 26588 RVA: 0x0015EF24 File Offset: 0x0015D124
		public InternalEncoderBestFitFallbackBuffer(InternalEncoderBestFitFallback fallback)
		{
			this.oFallback = fallback;
			if (this.oFallback.arrayBestFit == null)
			{
				object internalSyncObject = InternalEncoderBestFitFallbackBuffer.InternalSyncObject;
				lock (internalSyncObject)
				{
					if (this.oFallback.arrayBestFit == null)
					{
						this.oFallback.arrayBestFit = fallback.encoding.GetBestFitUnicodeToBytesData();
					}
				}
			}
		}

		// Token: 0x060067DD RID: 26589 RVA: 0x0015EFA4 File Offset: 0x0015D1A4
		public override bool Fallback(char charUnknown, int index)
		{
			this.iCount = (this.iSize = 1);
			this.cBestFit = this.TryBestFit(charUnknown);
			if (this.cBestFit == '\0')
			{
				this.cBestFit = '?';
			}
			return true;
		}

		// Token: 0x060067DE RID: 26590 RVA: 0x0015EFE0 File Offset: 0x0015D1E0
		public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
		{
			if (!char.IsHighSurrogate(charUnknownHigh))
			{
				throw new ArgumentOutOfRangeException("charUnknownHigh", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					55296,
					56319
				}));
			}
			if (!char.IsLowSurrogate(charUnknownLow))
			{
				throw new ArgumentOutOfRangeException("CharUnknownLow", Environment.GetResourceString("ArgumentOutOfRange_Range", new object[]
				{
					56320,
					57343
				}));
			}
			this.cBestFit = '?';
			this.iCount = (this.iSize = 2);
			return true;
		}

		// Token: 0x060067DF RID: 26591 RVA: 0x0015F080 File Offset: 0x0015D280
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

		// Token: 0x060067E0 RID: 26592 RVA: 0x0015F0B7 File Offset: 0x0015D2B7
		public override bool MovePrevious()
		{
			if (this.iCount >= 0)
			{
				this.iCount++;
			}
			return this.iCount >= 0 && this.iCount <= this.iSize;
		}

		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x060067E1 RID: 26593 RVA: 0x0015F0EC File Offset: 0x0015D2EC
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

		// Token: 0x060067E2 RID: 26594 RVA: 0x0015F0FF File Offset: 0x0015D2FF
		[SecuritySafeCritical]
		public override void Reset()
		{
			this.iCount = -1;
			this.charStart = null;
			this.bFallingBack = false;
		}

		// Token: 0x060067E3 RID: 26595 RVA: 0x0015F118 File Offset: 0x0015D318
		private char TryBestFit(char cUnknown)
		{
			int num = 0;
			int num2 = this.oFallback.arrayBestFit.Length;
			int num3;
			while ((num3 = num2 - num) > 6)
			{
				int i = num3 / 2 + num & 65534;
				char c = this.oFallback.arrayBestFit[i];
				if (c == cUnknown)
				{
					return this.oFallback.arrayBestFit[i + 1];
				}
				if (c < cUnknown)
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
				if (this.oFallback.arrayBestFit[i] == cUnknown)
				{
					return this.oFallback.arrayBestFit[i + 1];
				}
			}
			return '\0';
		}

		// Token: 0x04002E56 RID: 11862
		private char cBestFit;

		// Token: 0x04002E57 RID: 11863
		private InternalEncoderBestFitFallback oFallback;

		// Token: 0x04002E58 RID: 11864
		private int iCount = -1;

		// Token: 0x04002E59 RID: 11865
		private int iSize;

		// Token: 0x04002E5A RID: 11866
		private static object s_InternalSyncObject;
	}
}
