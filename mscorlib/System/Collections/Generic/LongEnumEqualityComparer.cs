using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004C7 RID: 1223
	[Serializable]
	internal sealed class LongEnumEqualityComparer<T> : EqualityComparer<T>, ISerializable where T : struct
	{
		// Token: 0x06003A9D RID: 15005 RVA: 0x000DF5E4 File Offset: 0x000DD7E4
		public override bool Equals(T x, T y)
		{
			long num = JitHelpers.UnsafeEnumCastLong<T>(x);
			long num2 = JitHelpers.UnsafeEnumCastLong<T>(y);
			return num == num2;
		}

		// Token: 0x06003A9E RID: 15006 RVA: 0x000DF604 File Offset: 0x000DD804
		public override int GetHashCode(T obj)
		{
			return JitHelpers.UnsafeEnumCastLong<T>(obj).GetHashCode();
		}

		// Token: 0x06003A9F RID: 15007 RVA: 0x000DF620 File Offset: 0x000DD820
		public override bool Equals(object obj)
		{
			LongEnumEqualityComparer<T> longEnumEqualityComparer = obj as LongEnumEqualityComparer<T>;
			return longEnumEqualityComparer != null;
		}

		// Token: 0x06003AA0 RID: 15008 RVA: 0x000DF638 File Offset: 0x000DD838
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}

		// Token: 0x06003AA1 RID: 15009 RVA: 0x000DF64A File Offset: 0x000DD84A
		public LongEnumEqualityComparer()
		{
		}

		// Token: 0x06003AA2 RID: 15010 RVA: 0x000DF652 File Offset: 0x000DD852
		public LongEnumEqualityComparer(SerializationInfo information, StreamingContext context)
		{
		}

		// Token: 0x06003AA3 RID: 15011 RVA: 0x000DF65A File Offset: 0x000DD85A
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.SetType(typeof(ObjectEqualityComparer<T>));
		}
	}
}
