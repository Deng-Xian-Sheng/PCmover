using System;

namespace System.Collections
{
	// Token: 0x020004A6 RID: 1190
	[__DynamicallyInvokable]
	public static class StructuralComparisons
	{
		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x060038F7 RID: 14583 RVA: 0x000DA40C File Offset: 0x000D860C
		[__DynamicallyInvokable]
		public static IComparer StructuralComparer
		{
			[__DynamicallyInvokable]
			get
			{
				IComparer comparer = StructuralComparisons.s_StructuralComparer;
				if (comparer == null)
				{
					comparer = new StructuralComparer();
					StructuralComparisons.s_StructuralComparer = comparer;
				}
				return comparer;
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x060038F8 RID: 14584 RVA: 0x000DA434 File Offset: 0x000D8634
		[__DynamicallyInvokable]
		public static IEqualityComparer StructuralEqualityComparer
		{
			[__DynamicallyInvokable]
			get
			{
				IEqualityComparer equalityComparer = StructuralComparisons.s_StructuralEqualityComparer;
				if (equalityComparer == null)
				{
					equalityComparer = new StructuralEqualityComparer();
					StructuralComparisons.s_StructuralEqualityComparer = equalityComparer;
				}
				return equalityComparer;
			}
		}

		// Token: 0x04001907 RID: 6407
		private static volatile IComparer s_StructuralComparer;

		// Token: 0x04001908 RID: 6408
		private static volatile IEqualityComparer s_StructuralEqualityComparer;
	}
}
