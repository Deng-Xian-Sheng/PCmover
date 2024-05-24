using System;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000957 RID: 2391
	[SecurityCritical]
	internal sealed class SafeHeapHandle : SafeBuffer
	{
		// Token: 0x060061DF RID: 25055 RVA: 0x0014EC06 File Offset: 0x0014CE06
		public SafeHeapHandle(ulong byteLength) : base(true)
		{
			this.Resize(byteLength);
		}

		// Token: 0x17001107 RID: 4359
		// (get) Token: 0x060061E0 RID: 25056 RVA: 0x0014EC16 File Offset: 0x0014CE16
		public override bool IsInvalid
		{
			[SecurityCritical]
			get
			{
				return this.handle == IntPtr.Zero;
			}
		}

		// Token: 0x060061E1 RID: 25057 RVA: 0x0014EC28 File Offset: 0x0014CE28
		public void Resize(ulong byteLength)
		{
			if (base.IsClosed)
			{
				throw new ObjectDisposedException("SafeHeapHandle");
			}
			ulong num = 0UL;
			if (this.handle == IntPtr.Zero)
			{
				this.handle = Marshal.AllocHGlobal((IntPtr)((long)byteLength));
			}
			else
			{
				num = base.ByteLength;
				this.handle = Marshal.ReAllocHGlobal(this.handle, (IntPtr)((long)byteLength));
			}
			if (this.handle == IntPtr.Zero)
			{
				throw new OutOfMemoryException();
			}
			if (byteLength > num)
			{
				ulong num2 = byteLength - num;
				if (num2 > 9223372036854775807UL)
				{
					GC.AddMemoryPressure(long.MaxValue);
					GC.AddMemoryPressure((long)(num2 - 9223372036854775807UL));
				}
				else
				{
					GC.AddMemoryPressure((long)num2);
				}
			}
			else
			{
				this.RemoveMemoryPressure(num - byteLength);
			}
			base.Initialize(byteLength);
		}

		// Token: 0x060061E2 RID: 25058 RVA: 0x0014ECF2 File Offset: 0x0014CEF2
		private void RemoveMemoryPressure(ulong removedBytes)
		{
			if (removedBytes == 0UL)
			{
				return;
			}
			if (removedBytes > 9223372036854775807UL)
			{
				GC.RemoveMemoryPressure(long.MaxValue);
				GC.RemoveMemoryPressure((long)(removedBytes - 9223372036854775807UL));
				return;
			}
			GC.RemoveMemoryPressure((long)removedBytes);
		}

		// Token: 0x060061E3 RID: 25059 RVA: 0x0014ED2C File Offset: 0x0014CF2C
		[SecurityCritical]
		protected override bool ReleaseHandle()
		{
			IntPtr handle = this.handle;
			this.handle = IntPtr.Zero;
			if (handle != IntPtr.Zero)
			{
				this.RemoveMemoryPressure(base.ByteLength);
				Marshal.FreeHGlobal(handle);
			}
			return true;
		}
	}
}
