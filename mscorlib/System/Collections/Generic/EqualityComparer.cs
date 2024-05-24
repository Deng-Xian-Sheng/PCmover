using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004BF RID: 1215
	[TypeDependency("System.Collections.Generic.ObjectEqualityComparer`1")]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class EqualityComparer<T> : IEqualityComparer, IEqualityComparer<T>
	{
		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x06003A6A RID: 14954 RVA: 0x000DED51 File Offset: 0x000DCF51
		[__DynamicallyInvokable]
		public static EqualityComparer<T> Default
		{
			[__DynamicallyInvokable]
			get
			{
				return EqualityComparer<T>.defaultComparer;
			}
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x000DED58 File Offset: 0x000DCF58
		[SecuritySafeCritical]
		private static EqualityComparer<T> CreateComparer()
		{
			RuntimeType runtimeType = (RuntimeType)typeof(T);
			if (runtimeType == typeof(byte))
			{
				return (EqualityComparer<T>)new ByteEqualityComparer();
			}
			if (typeof(IEquatable<T>).IsAssignableFrom(runtimeType))
			{
				return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(GenericEqualityComparer<int>), runtimeType);
			}
			if (runtimeType.IsGenericType && runtimeType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				RuntimeType runtimeType2 = (RuntimeType)runtimeType.GetGenericArguments()[0];
				if (typeof(IEquatable<>).MakeGenericType(new Type[]
				{
					runtimeType2
				}).IsAssignableFrom(runtimeType2))
				{
					return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(NullableEqualityComparer<int>), runtimeType2);
				}
			}
			if (runtimeType.IsEnum)
			{
				switch (Type.GetTypeCode(Enum.GetUnderlyingType(runtimeType)))
				{
				case TypeCode.SByte:
					return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(SByteEnumEqualityComparer<sbyte>), runtimeType);
				case TypeCode.Byte:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
					return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(EnumEqualityComparer<int>), runtimeType);
				case TypeCode.Int16:
					return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(ShortEnumEqualityComparer<short>), runtimeType);
				case TypeCode.Int64:
				case TypeCode.UInt64:
					return (EqualityComparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(LongEnumEqualityComparer<long>), runtimeType);
				}
			}
			return new ObjectEqualityComparer<T>();
		}

		// Token: 0x06003A6C RID: 14956
		[__DynamicallyInvokable]
		public abstract bool Equals(T x, T y);

		// Token: 0x06003A6D RID: 14957
		[__DynamicallyInvokable]
		public abstract int GetHashCode(T obj);

		// Token: 0x06003A6E RID: 14958 RVA: 0x000DEEDC File Offset: 0x000DD0DC
		internal virtual int IndexOf(T[] array, T value, int startIndex, int count)
		{
			int num = startIndex + count;
			for (int i = startIndex; i < num; i++)
			{
				if (this.Equals(array[i], value))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003A6F RID: 14959 RVA: 0x000DEF10 File Offset: 0x000DD110
		internal virtual int LastIndexOf(T[] array, T value, int startIndex, int count)
		{
			int num = startIndex - count + 1;
			for (int i = startIndex; i >= num; i--)
			{
				if (this.Equals(array[i], value))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06003A70 RID: 14960 RVA: 0x000DEF43 File Offset: 0x000DD143
		[__DynamicallyInvokable]
		int IEqualityComparer.GetHashCode(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			if (obj is T)
			{
				return this.GetHashCode((T)((object)obj));
			}
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
			return 0;
		}

		// Token: 0x06003A71 RID: 14961 RVA: 0x000DEF66 File Offset: 0x000DD166
		[__DynamicallyInvokable]
		bool IEqualityComparer.Equals(object x, object y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (x is T && y is T)
			{
				return this.Equals((T)((object)x), (T)((object)y));
			}
			ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
			return false;
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x000DEFA0 File Offset: 0x000DD1A0
		[__DynamicallyInvokable]
		protected EqualityComparer()
		{
		}

		// Token: 0x04001949 RID: 6473
		private static readonly EqualityComparer<T> defaultComparer = EqualityComparer<T>.CreateComparer();
	}
}
