using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	// Token: 0x020004C6 RID: 1222
	[Serializable]
	internal sealed class ShortEnumEqualityComparer<T> : EnumEqualityComparer<T>, ISerializable where T : struct
	{
		// Token: 0x06003A9A RID: 15002 RVA: 0x000DF5B2 File Offset: 0x000DD7B2
		public ShortEnumEqualityComparer()
		{
		}

		// Token: 0x06003A9B RID: 15003 RVA: 0x000DF5BA File Offset: 0x000DD7BA
		public ShortEnumEqualityComparer(SerializationInfo information, StreamingContext context)
		{
		}

		// Token: 0x06003A9C RID: 15004 RVA: 0x000DF5C4 File Offset: 0x000DD7C4
		public override int GetHashCode(T obj)
		{
			int num = JitHelpers.UnsafeEnumCast<T>(obj);
			return ((short)num).GetHashCode();
		}
	}
}
