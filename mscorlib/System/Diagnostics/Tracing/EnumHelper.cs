using System;
using System.Reflection;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200043F RID: 1087
	internal static class EnumHelper<UnderlyingType>
	{
		// Token: 0x060035F2 RID: 13810 RVA: 0x000D22CC File Offset: 0x000D04CC
		public static UnderlyingType Cast<ValueType>(ValueType value)
		{
			return EnumHelper<UnderlyingType>.Caster<ValueType>.Instance(value);
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x000D22D9 File Offset: 0x000D04D9
		internal static UnderlyingType Identity(UnderlyingType value)
		{
			return value;
		}

		// Token: 0x04001815 RID: 6165
		private static readonly MethodInfo IdentityInfo = Statics.GetDeclaredStaticMethod(typeof(EnumHelper<UnderlyingType>), "Identity");

		// Token: 0x02000B98 RID: 2968
		// (Invoke) Token: 0x06006C8F RID: 27791
		private delegate UnderlyingType Transformer<ValueType>(ValueType value);

		// Token: 0x02000B99 RID: 2969
		private static class Caster<ValueType>
		{
			// Token: 0x04003526 RID: 13606
			public static readonly EnumHelper<UnderlyingType>.Transformer<ValueType> Instance = (EnumHelper<UnderlyingType>.Transformer<ValueType>)Statics.CreateDelegate(typeof(EnumHelper<UnderlyingType>.Transformer<ValueType>), EnumHelper<UnderlyingType>.IdentityInfo);
		}
	}
}
