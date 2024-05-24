using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A9 RID: 1705
	internal struct StoreOperationScavenge
	{
		// Token: 0x06004FD9 RID: 20441 RVA: 0x0011CBEC File Offset: 0x0011ADEC
		public StoreOperationScavenge(bool Light, ulong SizeLimit, ulong RunLimit, uint ComponentLimit)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreOperationScavenge));
			this.Flags = StoreOperationScavenge.OpFlags.Nothing;
			if (Light)
			{
				this.Flags |= StoreOperationScavenge.OpFlags.Light;
			}
			this.SizeReclaimationLimit = SizeLimit;
			if (SizeLimit != 0UL)
			{
				this.Flags |= StoreOperationScavenge.OpFlags.LimitSize;
			}
			this.RuntimeLimit = RunLimit;
			if (RunLimit != 0UL)
			{
				this.Flags |= StoreOperationScavenge.OpFlags.LimitTime;
			}
			this.ComponentCountLimit = ComponentLimit;
			if (ComponentLimit != 0U)
			{
				this.Flags |= StoreOperationScavenge.OpFlags.LimitCount;
			}
		}

		// Token: 0x06004FDA RID: 20442 RVA: 0x0011CC70 File Offset: 0x0011AE70
		public StoreOperationScavenge(bool Light)
		{
			this = new StoreOperationScavenge(Light, 0UL, 0UL, 0U);
		}

		// Token: 0x06004FDB RID: 20443 RVA: 0x0011CC7E File Offset: 0x0011AE7E
		public void Destroy()
		{
		}

		// Token: 0x0400224D RID: 8781
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x0400224E RID: 8782
		[MarshalAs(UnmanagedType.U4)]
		public StoreOperationScavenge.OpFlags Flags;

		// Token: 0x0400224F RID: 8783
		[MarshalAs(UnmanagedType.U8)]
		public ulong SizeReclaimationLimit;

		// Token: 0x04002250 RID: 8784
		[MarshalAs(UnmanagedType.U8)]
		public ulong RuntimeLimit;

		// Token: 0x04002251 RID: 8785
		[MarshalAs(UnmanagedType.U4)]
		public uint ComponentCountLimit;

		// Token: 0x02000C52 RID: 3154
		[Flags]
		public enum OpFlags
		{
			// Token: 0x04003787 RID: 14215
			Nothing = 0,
			// Token: 0x04003788 RID: 14216
			Light = 1,
			// Token: 0x04003789 RID: 14217
			LimitSize = 2,
			// Token: 0x0400378A RID: 14218
			LimitTime = 4,
			// Token: 0x0400378B RID: 14219
			LimitCount = 8
		}
	}
}
