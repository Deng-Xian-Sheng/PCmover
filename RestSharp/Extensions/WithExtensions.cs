using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Extensions
{
	// Token: 0x02000050 RID: 80
	internal static class WithExtensions
	{
		// Token: 0x060004F8 RID: 1272 RVA: 0x0000C6CB File Offset: 0x0000A8CB
		[NullableContext(1)]
		internal static T With<[Nullable(2)] T>(this T self, Action<T> @do)
		{
			@do(self);
			return self;
		}
	}
}
