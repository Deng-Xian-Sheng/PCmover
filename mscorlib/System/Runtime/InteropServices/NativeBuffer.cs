using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200095A RID: 2394
	internal class NativeBuffer : IDisposable
	{
		// Token: 0x06006201 RID: 25089 RVA: 0x0014F41B File Offset: 0x0014D61B
		[SecuritySafeCritical]
		static NativeBuffer()
		{
			NativeBuffer.s_handleCache = new SafeHeapHandleCache(64UL, 2048UL, 0);
		}

		// Token: 0x06006202 RID: 25090 RVA: 0x0014F43B File Offset: 0x0014D63B
		public NativeBuffer(ulong initialMinCapacity = 0UL)
		{
			this.EnsureByteCapacity(initialMinCapacity);
		}

		// Token: 0x1700110C RID: 4364
		// (get) Token: 0x06006203 RID: 25091 RVA: 0x0014F44C File Offset: 0x0014D64C
		protected unsafe void* VoidPointer
		{
			[SecurityCritical]
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (this._handle != null)
				{
					return this._handle.DangerousGetHandle().ToPointer();
				}
				return null;
			}
		}

		// Token: 0x1700110D RID: 4365
		// (get) Token: 0x06006204 RID: 25092 RVA: 0x0014F477 File Offset: 0x0014D677
		protected unsafe byte* BytePointer
		{
			[SecurityCritical]
			get
			{
				return (byte*)this.VoidPointer;
			}
		}

		// Token: 0x06006205 RID: 25093 RVA: 0x0014F47F File Offset: 0x0014D67F
		[SecuritySafeCritical]
		public SafeHandle GetHandle()
		{
			return this._handle ?? NativeBuffer.s_emptyHandle;
		}

		// Token: 0x1700110E RID: 4366
		// (get) Token: 0x06006206 RID: 25094 RVA: 0x0014F490 File Offset: 0x0014D690
		public ulong ByteCapacity
		{
			get
			{
				return this._capacity;
			}
		}

		// Token: 0x06006207 RID: 25095 RVA: 0x0014F498 File Offset: 0x0014D698
		[SecuritySafeCritical]
		public void EnsureByteCapacity(ulong minCapacity)
		{
			if (this._capacity < minCapacity)
			{
				this.Resize(minCapacity);
				this._capacity = minCapacity;
			}
		}

		// Token: 0x1700110F RID: 4367
		public unsafe byte this[ulong index]
		{
			[SecuritySafeCritical]
			get
			{
				if (index >= this._capacity)
				{
					throw new ArgumentOutOfRangeException();
				}
				return this.BytePointer[index];
			}
			[SecuritySafeCritical]
			set
			{
				if (index >= this._capacity)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.BytePointer[index] = value;
			}
		}

		// Token: 0x0600620A RID: 25098 RVA: 0x0014F4E8 File Offset: 0x0014D6E8
		[SecuritySafeCritical]
		private void Resize(ulong byteLength)
		{
			if (byteLength == 0UL)
			{
				this.ReleaseHandle();
				return;
			}
			if (this._handle == null)
			{
				this._handle = NativeBuffer.s_handleCache.Acquire(byteLength);
				return;
			}
			this._handle.Resize(byteLength);
		}

		// Token: 0x0600620B RID: 25099 RVA: 0x0014F51A File Offset: 0x0014D71A
		[SecuritySafeCritical]
		private void ReleaseHandle()
		{
			if (this._handle != null)
			{
				NativeBuffer.s_handleCache.Release(this._handle);
				this._capacity = 0UL;
				this._handle = null;
			}
		}

		// Token: 0x0600620C RID: 25100 RVA: 0x0014F543 File Offset: 0x0014D743
		[SecuritySafeCritical]
		public virtual void Free()
		{
			this.ReleaseHandle();
		}

		// Token: 0x0600620D RID: 25101 RVA: 0x0014F54B File Offset: 0x0014D74B
		[SecuritySafeCritical]
		public void Dispose()
		{
			this.Free();
		}

		// Token: 0x04002B80 RID: 11136
		private static readonly SafeHeapHandleCache s_handleCache;

		// Token: 0x04002B81 RID: 11137
		[SecurityCritical]
		private static readonly SafeHandle s_emptyHandle = new NativeBuffer.EmptySafeHandle();

		// Token: 0x04002B82 RID: 11138
		[SecurityCritical]
		private SafeHeapHandle _handle;

		// Token: 0x04002B83 RID: 11139
		private ulong _capacity;

		// Token: 0x02000C96 RID: 3222
		[SecurityCritical]
		private sealed class EmptySafeHandle : SafeHandle
		{
			// Token: 0x06007110 RID: 28944 RVA: 0x001852A6 File Offset: 0x001834A6
			public EmptySafeHandle() : base(IntPtr.Zero, true)
			{
			}

			// Token: 0x17001365 RID: 4965
			// (get) Token: 0x06007111 RID: 28945 RVA: 0x001852B4 File Offset: 0x001834B4
			public override bool IsInvalid
			{
				[SecurityCritical]
				get
				{
					return true;
				}
			}

			// Token: 0x06007112 RID: 28946 RVA: 0x001852B7 File Offset: 0x001834B7
			[SecurityCritical]
			protected override bool ReleaseHandle()
			{
				return true;
			}
		}
	}
}
