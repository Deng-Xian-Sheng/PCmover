using System;
using System.Security;
using System.Threading;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000958 RID: 2392
	internal sealed class SafeHeapHandleCache : IDisposable
	{
		// Token: 0x060061E4 RID: 25060 RVA: 0x0014ED6B File Offset: 0x0014CF6B
		[SecuritySafeCritical]
		public SafeHeapHandleCache(ulong minSize = 64UL, ulong maxSize = 2048UL, int maxHandles = 0)
		{
			this._minSize = minSize;
			this._maxSize = maxSize;
			this._handleCache = new SafeHeapHandle[(maxHandles > 0) ? maxHandles : (Environment.ProcessorCount * 4)];
		}

		// Token: 0x060061E5 RID: 25061 RVA: 0x0014ED9C File Offset: 0x0014CF9C
		[SecurityCritical]
		public SafeHeapHandle Acquire(ulong minSize = 0UL)
		{
			if (minSize < this._minSize)
			{
				minSize = this._minSize;
			}
			SafeHeapHandle safeHeapHandle = null;
			for (int i = 0; i < this._handleCache.Length; i++)
			{
				safeHeapHandle = Interlocked.Exchange<SafeHeapHandle>(ref this._handleCache[i], null);
				if (safeHeapHandle != null)
				{
					break;
				}
			}
			if (safeHeapHandle != null)
			{
				if (safeHeapHandle.ByteLength < minSize)
				{
					safeHeapHandle.Resize(minSize);
				}
			}
			else
			{
				safeHeapHandle = new SafeHeapHandle(minSize);
			}
			return safeHeapHandle;
		}

		// Token: 0x060061E6 RID: 25062 RVA: 0x0014EE04 File Offset: 0x0014D004
		[SecurityCritical]
		public void Release(SafeHeapHandle handle)
		{
			if (handle.ByteLength <= this._maxSize)
			{
				for (int i = 0; i < this._handleCache.Length; i++)
				{
					handle = Interlocked.Exchange<SafeHeapHandle>(ref this._handleCache[i], handle);
					if (handle == null)
					{
						return;
					}
				}
			}
			handle.Dispose();
		}

		// Token: 0x060061E7 RID: 25063 RVA: 0x0014EE50 File Offset: 0x0014D050
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060061E8 RID: 25064 RVA: 0x0014EE60 File Offset: 0x0014D060
		[SecuritySafeCritical]
		private void Dispose(bool disposing)
		{
			if (this._handleCache != null)
			{
				for (int i = 0; i < this._handleCache.Length; i++)
				{
					SafeHeapHandle safeHeapHandle = this._handleCache[i];
					this._handleCache[i] = null;
					if (safeHeapHandle != null && disposing)
					{
						safeHeapHandle.Dispose();
					}
				}
			}
		}

		// Token: 0x060061E9 RID: 25065 RVA: 0x0014EEA8 File Offset: 0x0014D0A8
		~SafeHeapHandleCache()
		{
			this.Dispose(false);
		}

		// Token: 0x04002B7C RID: 11132
		private readonly ulong _minSize;

		// Token: 0x04002B7D RID: 11133
		private readonly ulong _maxSize;

		// Token: 0x04002B7E RID: 11134
		[SecurityCritical]
		internal readonly SafeHeapHandle[] _handleCache;
	}
}
