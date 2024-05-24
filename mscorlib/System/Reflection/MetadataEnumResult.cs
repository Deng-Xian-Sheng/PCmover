using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005FC RID: 1532
	internal struct MetadataEnumResult
	{
		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x0600468E RID: 18062 RVA: 0x00102A73 File Offset: 0x00100C73
		public int Length
		{
			get
			{
				return this.length;
			}
		}

		// Token: 0x17000AB2 RID: 2738
		public unsafe int this[int index]
		{
			[SecurityCritical]
			get
			{
				if (this.largeResult != null)
				{
					return this.largeResult[index];
				}
				fixed (int* ptr = &this.smallResult.FixedElementField)
				{
					int* ptr2 = ptr;
					return ptr2[index];
				}
			}
		}

		// Token: 0x04001D49 RID: 7497
		private int[] largeResult;

		// Token: 0x04001D4A RID: 7498
		private int length;

		// Token: 0x04001D4B RID: 7499
		[FixedBuffer(typeof(int), 16)]
		private MetadataEnumResult.<smallResult>e__FixedBuffer smallResult;

		// Token: 0x02000C38 RID: 3128
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <smallResult>e__FixedBuffer
		{
			// Token: 0x04003733 RID: 14131
			public int FixedElementField;
		}
	}
}
