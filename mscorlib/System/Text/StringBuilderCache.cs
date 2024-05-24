using System;

namespace System.Text
{
	// Token: 0x02000A58 RID: 2648
	internal static class StringBuilderCache
	{
		// Token: 0x06006730 RID: 26416 RVA: 0x0015C0EC File Offset: 0x0015A2EC
		public static StringBuilder Acquire(int capacity = 16)
		{
			if (capacity <= 360)
			{
				StringBuilder cachedInstance = StringBuilderCache.CachedInstance;
				if (cachedInstance != null && capacity <= cachedInstance.Capacity)
				{
					StringBuilderCache.CachedInstance = null;
					cachedInstance.Clear();
					return cachedInstance;
				}
			}
			return new StringBuilder(capacity);
		}

		// Token: 0x06006731 RID: 26417 RVA: 0x0015C128 File Offset: 0x0015A328
		public static void Release(StringBuilder sb)
		{
			if (sb.Capacity <= 360)
			{
				StringBuilderCache.CachedInstance = sb;
			}
		}

		// Token: 0x06006732 RID: 26418 RVA: 0x0015C140 File Offset: 0x0015A340
		public static string GetStringAndRelease(StringBuilder sb)
		{
			string result = sb.ToString();
			StringBuilderCache.Release(sb);
			return result;
		}

		// Token: 0x04002E20 RID: 11808
		internal const int MAX_BUILDER_SIZE = 360;

		// Token: 0x04002E21 RID: 11809
		[ThreadStatic]
		private static StringBuilder CachedInstance;
	}
}
