using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	// Token: 0x020004C5 RID: 1221
	[Serializable]
	internal sealed class SByteEnumEqualityComparer<T> : EnumEqualityComparer<T>, ISerializable where T : struct
	{
		// Token: 0x06003A97 RID: 14999 RVA: 0x000DF582 File Offset: 0x000DD782
		public SByteEnumEqualityComparer()
		{
		}

		// Token: 0x06003A98 RID: 15000 RVA: 0x000DF58A File Offset: 0x000DD78A
		public SByteEnumEqualityComparer(SerializationInfo information, StreamingContext context)
		{
		}

		// Token: 0x06003A99 RID: 15001 RVA: 0x000DF594 File Offset: 0x000DD794
		public override int GetHashCode(T obj)
		{
			int num = JitHelpers.UnsafeEnumCast<T>(obj);
			return ((sbyte)num).GetHashCode();
		}
	}
}
