using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Collections.Generic
{
	// Token: 0x020004B9 RID: 1209
	[TypeDependency("System.Collections.Generic.ObjectComparer`1")]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class Comparer<T> : IComparer, IComparer<T>
	{
		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x06003A1F RID: 14879 RVA: 0x000DDBE2 File Offset: 0x000DBDE2
		[__DynamicallyInvokable]
		public static Comparer<T> Default
		{
			[__DynamicallyInvokable]
			get
			{
				return Comparer<T>.defaultComparer;
			}
		}

		// Token: 0x06003A20 RID: 14880 RVA: 0x000DDBE9 File Offset: 0x000DBDE9
		[__DynamicallyInvokable]
		public static Comparer<T> Create(Comparison<T> comparison)
		{
			if (comparison == null)
			{
				throw new ArgumentNullException("comparison");
			}
			return new ComparisonComparer<T>(comparison);
		}

		// Token: 0x06003A21 RID: 14881 RVA: 0x000DDC00 File Offset: 0x000DBE00
		[SecuritySafeCritical]
		private static Comparer<T> CreateComparer()
		{
			RuntimeType runtimeType = (RuntimeType)typeof(T);
			if (typeof(IComparable<T>).IsAssignableFrom(runtimeType))
			{
				return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(GenericComparer<int>), runtimeType);
			}
			if (runtimeType.IsGenericType && runtimeType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				RuntimeType runtimeType2 = (RuntimeType)runtimeType.GetGenericArguments()[0];
				if (typeof(IComparable<>).MakeGenericType(new Type[]
				{
					runtimeType2
				}).IsAssignableFrom(runtimeType2))
				{
					return (Comparer<T>)RuntimeTypeHandle.CreateInstanceForAnotherGenericParameter((RuntimeType)typeof(NullableComparer<int>), runtimeType2);
				}
			}
			return new ObjectComparer<T>();
		}

		// Token: 0x06003A22 RID: 14882
		[__DynamicallyInvokable]
		public abstract int Compare(T x, T y);

		// Token: 0x06003A23 RID: 14883 RVA: 0x000DDCB8 File Offset: 0x000DBEB8
		[__DynamicallyInvokable]
		int IComparer.Compare(object x, object y)
		{
			if (x == null)
			{
				if (y != null)
				{
					return -1;
				}
				return 0;
			}
			else
			{
				if (y == null)
				{
					return 1;
				}
				if (x is T && y is T)
				{
					return this.Compare((T)((object)x), (T)((object)y));
				}
				ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArgumentForComparison);
				return 0;
			}
		}

		// Token: 0x06003A24 RID: 14884 RVA: 0x000DDCF3 File Offset: 0x000DBEF3
		[__DynamicallyInvokable]
		protected Comparer()
		{
		}

		// Token: 0x04001939 RID: 6457
		private static readonly Comparer<T> defaultComparer = Comparer<T>.CreateComparer();
	}
}
