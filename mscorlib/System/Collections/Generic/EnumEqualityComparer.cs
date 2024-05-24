using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004C4 RID: 1220
	[Serializable]
	internal class EnumEqualityComparer<T> : EqualityComparer<T>, ISerializable where T : struct
	{
		// Token: 0x06003A90 RID: 14992 RVA: 0x000DF4E0 File Offset: 0x000DD6E0
		public override bool Equals(T x, T y)
		{
			int num = JitHelpers.UnsafeEnumCast<T>(x);
			int num2 = JitHelpers.UnsafeEnumCast<T>(y);
			return num == num2;
		}

		// Token: 0x06003A91 RID: 14993 RVA: 0x000DF500 File Offset: 0x000DD700
		public override int GetHashCode(T obj)
		{
			return JitHelpers.UnsafeEnumCast<T>(obj).GetHashCode();
		}

		// Token: 0x06003A92 RID: 14994 RVA: 0x000DF51B File Offset: 0x000DD71B
		public EnumEqualityComparer()
		{
		}

		// Token: 0x06003A93 RID: 14995 RVA: 0x000DF523 File Offset: 0x000DD723
		protected EnumEqualityComparer(SerializationInfo information, StreamingContext context)
		{
		}

		// Token: 0x06003A94 RID: 14996 RVA: 0x000DF52B File Offset: 0x000DD72B
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (Type.GetTypeCode(Enum.GetUnderlyingType(typeof(T))) != TypeCode.Int32)
			{
				info.SetType(typeof(ObjectEqualityComparer<T>));
			}
		}

		// Token: 0x06003A95 RID: 14997 RVA: 0x000DF558 File Offset: 0x000DD758
		public override bool Equals(object obj)
		{
			EnumEqualityComparer<T> enumEqualityComparer = obj as EnumEqualityComparer<T>;
			return enumEqualityComparer != null;
		}

		// Token: 0x06003A96 RID: 14998 RVA: 0x000DF570 File Offset: 0x000DD770
		public override int GetHashCode()
		{
			return base.GetType().Name.GetHashCode();
		}
	}
}
