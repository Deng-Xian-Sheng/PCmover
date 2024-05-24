using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200002E RID: 46
	[NullableContext(1)]
	[Nullable(0)]
	[GeneratedCode("reflection-utils", "1.0.0")]
	internal class ReflectionUtils
	{
		// Token: 0x06000407 RID: 1031 RVA: 0x00008F2B File Offset: 0x0000712B
		public static Type GetTypeInfo(Type type)
		{
			return type;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00008F2E File Offset: 0x0000712E
		public static Attribute GetAttribute(MemberInfo info, Type type)
		{
			if (info == null || type == null || !Attribute.IsDefined(info, type))
			{
				return null;
			}
			return Attribute.GetCustomAttribute(info, type);
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00008F54 File Offset: 0x00007154
		public static Type GetGenericListElementType(Type type)
		{
			foreach (Type type2 in ((IEnumerable<Type>)type.GetInterfaces()))
			{
				if (ReflectionUtils.IsTypeGeneric(type2) && type2.GetGenericTypeDefinition() == typeof(IList<>))
				{
					return ReflectionUtils.GetGenericTypeArguments(type2)[0];
				}
			}
			return ReflectionUtils.GetGenericTypeArguments(type)[0];
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00008FD0 File Offset: 0x000071D0
		public static Attribute GetAttribute(Type objectType, Type attributeType)
		{
			if (objectType == null || attributeType == null || !Attribute.IsDefined(objectType, attributeType))
			{
				return null;
			}
			return Attribute.GetCustomAttribute(objectType, attributeType);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00008FF6 File Offset: 0x000071F6
		public static Type[] GetGenericTypeArguments(Type type)
		{
			return type.GetGenericArguments();
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00008FFE File Offset: 0x000071FE
		public static bool IsTypeGeneric(Type type)
		{
			return ReflectionUtils.GetTypeInfo(type).IsGenericType;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0000900C File Offset: 0x0000720C
		public static bool IsTypeGenericeCollectionInterface(Type type)
		{
			if (!ReflectionUtils.IsTypeGeneric(type))
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			return genericTypeDefinition == typeof(IList<>) || genericTypeDefinition == typeof(ICollection<>) || genericTypeDefinition == typeof(IEnumerable<>) || genericTypeDefinition == typeof(IReadOnlyCollection<>) || genericTypeDefinition == typeof(IReadOnlyList<>);
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00009084 File Offset: 0x00007284
		public static bool IsAssignableFrom(Type type1, Type type2)
		{
			return ReflectionUtils.GetTypeInfo(type1).IsAssignableFrom(ReflectionUtils.GetTypeInfo(type2));
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00009097 File Offset: 0x00007297
		public static bool IsTypeDictionary(Type type)
		{
			return typeof(IDictionary).IsAssignableFrom(type) || (ReflectionUtils.GetTypeInfo(type).IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<, >));
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x000090D1 File Offset: 0x000072D1
		public static bool IsNullableType(Type type)
		{
			return ReflectionUtils.GetTypeInfo(type).IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000090F7 File Offset: 0x000072F7
		public static object ToNullableType(object obj, Type nullableType)
		{
			if (obj != null)
			{
				return Convert.ChangeType(obj, Nullable.GetUnderlyingType(nullableType), CultureInfo.InvariantCulture);
			}
			return null;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x0000910F File Offset: 0x0000730F
		public static bool IsValueType(Type type)
		{
			return ReflectionUtils.GetTypeInfo(type).IsValueType;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000911C File Offset: 0x0000731C
		public static IEnumerable<ConstructorInfo> GetConstructors(Type type)
		{
			return type.GetConstructors();
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00009124 File Offset: 0x00007324
		public static ConstructorInfo GetConstructorInfo(Type type, params Type[] argsType)
		{
			foreach (ConstructorInfo constructorInfo in ReflectionUtils.GetConstructors(type))
			{
				ParameterInfo[] parameters = constructorInfo.GetParameters();
				if (argsType.Length == parameters.Length)
				{
					int num = 0;
					bool flag = true;
					ParameterInfo[] parameters2 = constructorInfo.GetParameters();
					for (int i = 0; i < parameters2.Length; i++)
					{
						if (parameters2[i].ParameterType != argsType[num])
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return constructorInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x000091C0 File Offset: 0x000073C0
		public static IEnumerable<PropertyInfo> GetProperties(Type type)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000091CA File Offset: 0x000073CA
		public static IEnumerable<FieldInfo> GetFields(Type type)
		{
			return type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x000091D4 File Offset: 0x000073D4
		public static MethodInfo GetGetterMethodInfo(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetGetMethod(true);
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x000091DD File Offset: 0x000073DD
		public static MethodInfo GetSetterMethodInfo(PropertyInfo propertyInfo)
		{
			return propertyInfo.GetSetMethod(true);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000091E6 File Offset: 0x000073E6
		public static ReflectionUtils.ConstructorDelegate GetContructor(ConstructorInfo constructorInfo)
		{
			return ReflectionUtils.GetConstructorByExpression(constructorInfo);
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000091EE File Offset: 0x000073EE
		public static ReflectionUtils.ConstructorDelegate GetContructor(Type type, params Type[] argsType)
		{
			return ReflectionUtils.GetConstructorByExpression(type, argsType);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000091F7 File Offset: 0x000073F7
		public static ReflectionUtils.ConstructorDelegate GetConstructorByReflection(ConstructorInfo constructorInfo)
		{
			return (object[] args) => constructorInfo.Invoke(args);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00009210 File Offset: 0x00007410
		public static ReflectionUtils.ConstructorDelegate GetConstructorByReflection(Type type, params Type[] argsType)
		{
			ConstructorInfo constructorInfo = ReflectionUtils.GetConstructorInfo(type, argsType);
			if (!(constructorInfo == null))
			{
				return ReflectionUtils.GetConstructorByReflection(constructorInfo);
			}
			return null;
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00009238 File Offset: 0x00007438
		public static ReflectionUtils.ConstructorDelegate GetConstructorByExpression(ConstructorInfo constructorInfo)
		{
			ParameterInfo[] parameters = constructorInfo.GetParameters();
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object[]), "args");
			Expression[] array = new Expression[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				Expression index = Expression.Constant(i);
				Type parameterType = parameters[i].ParameterType;
				Expression expression = Expression.Convert(Expression.ArrayIndex(parameterExpression, index), parameterType);
				array[i] = expression;
			}
			Expression<Func<object[], object>> expression2 = Expression.Lambda<Func<object[], object>>(Expression.New(constructorInfo, array), new ParameterExpression[]
			{
				parameterExpression
			});
			Func<object[], object> compiledLambda = expression2.Compile();
			return (object[] args) => compiledLambda(args);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000092E4 File Offset: 0x000074E4
		public static ReflectionUtils.ConstructorDelegate GetConstructorByExpression(Type type, params Type[] argsType)
		{
			ConstructorInfo constructorInfo = ReflectionUtils.GetConstructorInfo(type, argsType);
			if (!(constructorInfo == null))
			{
				return ReflectionUtils.GetConstructorByExpression(constructorInfo);
			}
			return null;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000930A File Offset: 0x0000750A
		public static ReflectionUtils.GetDelegate GetGetMethod(PropertyInfo propertyInfo)
		{
			return ReflectionUtils.GetGetMethodByExpression(propertyInfo);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00009312 File Offset: 0x00007512
		public static ReflectionUtils.GetDelegate GetGetMethod(FieldInfo fieldInfo)
		{
			return ReflectionUtils.GetGetMethodByExpression(fieldInfo);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000931A File Offset: 0x0000751A
		public static ReflectionUtils.GetDelegate GetGetMethodByReflection(PropertyInfo propertyInfo)
		{
			MethodInfo methodInfo = ReflectionUtils.GetGetterMethodInfo(propertyInfo);
			return (object source) => methodInfo.Invoke(source, ReflectionUtils.EmptyObjects);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00009338 File Offset: 0x00007538
		public static ReflectionUtils.GetDelegate GetGetMethodByReflection(FieldInfo fieldInfo)
		{
			return (object source) => fieldInfo.GetValue(source);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00009354 File Offset: 0x00007554
		public static ReflectionUtils.GetDelegate GetGetMethodByExpression(PropertyInfo propertyInfo)
		{
			MethodInfo getterMethodInfo = ReflectionUtils.GetGetterMethodInfo(propertyInfo);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			UnaryExpression instance = (!ReflectionUtils.IsValueType(propertyInfo.DeclaringType)) ? Expression.TypeAs(parameterExpression, propertyInfo.DeclaringType) : Expression.Convert(parameterExpression, propertyInfo.DeclaringType);
			Func<object, object> compiled = Expression.Lambda<Func<object, object>>(Expression.TypeAs(Expression.Call(instance, getterMethodInfo), typeof(object)), new ParameterExpression[]
			{
				parameterExpression
			}).Compile();
			return (object source) => compiled(source);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000093E8 File Offset: 0x000075E8
		public static ReflectionUtils.GetDelegate GetGetMethodByExpression(FieldInfo fieldInfo)
		{
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			MemberExpression expression = Expression.Field(Expression.Convert(parameterExpression, fieldInfo.DeclaringType), fieldInfo);
			ReflectionUtils.GetDelegate compiled = Expression.Lambda<ReflectionUtils.GetDelegate>(Expression.Convert(expression, typeof(object)), new ParameterExpression[]
			{
				parameterExpression
			}).Compile();
			return (object source) => compiled(source);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00009459 File Offset: 0x00007659
		public static ReflectionUtils.SetDelegate GetSetMethod(PropertyInfo propertyInfo)
		{
			return ReflectionUtils.GetSetMethodByExpression(propertyInfo);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00009461 File Offset: 0x00007661
		public static ReflectionUtils.SetDelegate GetSetMethod(FieldInfo fieldInfo)
		{
			return ReflectionUtils.GetSetMethodByExpression(fieldInfo);
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x00009469 File Offset: 0x00007669
		public static ReflectionUtils.SetDelegate GetSetMethodByReflection(PropertyInfo propertyInfo)
		{
			MethodInfo methodInfo = ReflectionUtils.GetSetterMethodInfo(propertyInfo);
			return delegate(object source, object value)
			{
				methodInfo.Invoke(source, new object[]
				{
					value
				});
			};
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00009487 File Offset: 0x00007687
		public static ReflectionUtils.SetDelegate GetSetMethodByReflection(FieldInfo fieldInfo)
		{
			return delegate(object source, object value)
			{
				fieldInfo.SetValue(source, value);
			};
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000094A0 File Offset: 0x000076A0
		public static ReflectionUtils.SetDelegate GetSetMethodByExpression(PropertyInfo propertyInfo)
		{
			MethodInfo setterMethodInfo = ReflectionUtils.GetSetterMethodInfo(propertyInfo);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(object), "instance");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object), "value");
			Expression instance = (!ReflectionUtils.IsValueType(propertyInfo.DeclaringType)) ? Expression.TypeAs(parameterExpression, propertyInfo.DeclaringType) : Expression.Convert(parameterExpression, propertyInfo.DeclaringType);
			UnaryExpression unaryExpression = (!ReflectionUtils.IsValueType(propertyInfo.PropertyType)) ? Expression.TypeAs(parameterExpression2, propertyInfo.PropertyType) : Expression.Convert(parameterExpression2, propertyInfo.PropertyType);
			MethodCallExpression body = Expression.Call(instance, setterMethodInfo, new Expression[]
			{
				unaryExpression
			});
			ParameterExpression[] parameters = new ParameterExpression[]
			{
				parameterExpression,
				parameterExpression2
			};
			Action<object, object> compiled = Expression.Lambda<Action<object, object>>(body, parameters).Compile();
			return delegate(object source, object val)
			{
				compiled(source, val);
			};
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00009578 File Offset: 0x00007778
		public static ReflectionUtils.SetDelegate GetSetMethodByExpression(FieldInfo fieldInfo)
		{
			ParameterExpression parameterExpression;
			ParameterExpression parameterExpression2;
			Action<object, object> compiled = Expression.Lambda<Action<object, object>>(ReflectionUtils.Assign(Expression.Field(Expression.Convert(parameterExpression, fieldInfo.DeclaringType), fieldInfo), Expression.Convert(parameterExpression2, fieldInfo.FieldType)), new ParameterExpression[]
			{
				parameterExpression,
				parameterExpression2
			}).Compile();
			return delegate(object source, object val)
			{
				compiled(source, val);
			};
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00009604 File Offset: 0x00007804
		public static BinaryExpression Assign(Expression left, Expression right)
		{
			MethodInfo method = typeof(ReflectionUtils.Assigner<>).MakeGenericType(new Type[]
			{
				left.Type
			}).GetMethod("Assign");
			return Expression.Add(left, right, method);
		}

		// Token: 0x040000F6 RID: 246
		private static readonly object[] EmptyObjects = new object[0];

		// Token: 0x020000A9 RID: 169
		// (Invoke) Token: 0x06000662 RID: 1634
		[NullableContext(0)]
		public delegate object GetDelegate(object source);

		// Token: 0x020000AA RID: 170
		// (Invoke) Token: 0x06000666 RID: 1638
		[NullableContext(0)]
		public delegate void SetDelegate(object source, object value);

		// Token: 0x020000AB RID: 171
		// (Invoke) Token: 0x0600066A RID: 1642
		[NullableContext(0)]
		public delegate object ConstructorDelegate(params object[] args);

		// Token: 0x020000AC RID: 172
		// (Invoke) Token: 0x0600066E RID: 1646
		[NullableContext(0)]
		public delegate TValue ThreadSafeDictionaryValueFactory<[Nullable(2)] TKey, [Nullable(2)] TValue>(TKey key);

		// Token: 0x020000AD RID: 173
		[NullableContext(0)]
		private static class Assigner<[Nullable(2)] T>
		{
			// Token: 0x06000671 RID: 1649 RVA: 0x0000F28C File Offset: 0x0000D48C
			[NullableContext(1)]
			public static T Assign(ref T left, T right)
			{
				left = right;
				return right;
			}
		}

		// Token: 0x020000AE RID: 174
		[Nullable(0)]
		public sealed class ThreadSafeDictionary<[Nullable(2)] TKey, [Nullable(2)] TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
		{
			// Token: 0x06000672 RID: 1650 RVA: 0x0000F2A3 File Offset: 0x0000D4A3
			public ThreadSafeDictionary(ReflectionUtils.ThreadSafeDictionaryValueFactory<TKey, TValue> valueFactory)
			{
				this._valueFactory = valueFactory;
			}

			// Token: 0x06000673 RID: 1651 RVA: 0x0000F2C0 File Offset: 0x0000D4C0
			private TValue Get(TKey key)
			{
				if (this._dictionary == null)
				{
					return this.AddValue(key);
				}
				TValue result;
				if (!this._dictionary.TryGetValue(key, out result))
				{
					return this.AddValue(key);
				}
				return result;
			}

			// Token: 0x06000674 RID: 1652 RVA: 0x0000F2F8 File Offset: 0x0000D4F8
			private TValue AddValue(TKey key)
			{
				TValue tvalue = this._valueFactory(key);
				object @lock = this._lock;
				lock (@lock)
				{
					if (this._dictionary == null)
					{
						this._dictionary = new Dictionary<TKey, TValue>();
						this._dictionary[key] = tvalue;
					}
					else
					{
						TValue result;
						if (this._dictionary.TryGetValue(key, out result))
						{
							return result;
						}
						Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(this._dictionary);
						dictionary[key] = tvalue;
						this._dictionary = dictionary;
					}
				}
				return tvalue;
			}

			// Token: 0x06000675 RID: 1653 RVA: 0x0000F398 File Offset: 0x0000D598
			public void Add(TKey key, TValue value)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000676 RID: 1654 RVA: 0x0000F39F File Offset: 0x0000D59F
			public bool ContainsKey(TKey key)
			{
				return this._dictionary.ContainsKey(key);
			}

			// Token: 0x17000192 RID: 402
			// (get) Token: 0x06000677 RID: 1655 RVA: 0x0000F3AD File Offset: 0x0000D5AD
			public ICollection<TKey> Keys
			{
				get
				{
					return this._dictionary.Keys;
				}
			}

			// Token: 0x06000678 RID: 1656 RVA: 0x0000F3BA File Offset: 0x0000D5BA
			public bool Remove(TKey key)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000679 RID: 1657 RVA: 0x0000F3C1 File Offset: 0x0000D5C1
			public bool TryGetValue(TKey key, out TValue value)
			{
				value = this[key];
				return true;
			}

			// Token: 0x17000193 RID: 403
			// (get) Token: 0x0600067A RID: 1658 RVA: 0x0000F3D1 File Offset: 0x0000D5D1
			public ICollection<TValue> Values
			{
				get
				{
					return this._dictionary.Values;
				}
			}

			// Token: 0x17000194 RID: 404
			public TValue this[TKey key]
			{
				get
				{
					return this.Get(key);
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600067D RID: 1661 RVA: 0x0000F3EE File Offset: 0x0000D5EE
			public void Add([Nullable(new byte[]
			{
				0,
				1,
				1
			})] KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600067E RID: 1662 RVA: 0x0000F3F5 File Offset: 0x0000D5F5
			public void Clear()
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600067F RID: 1663 RVA: 0x0000F3FC File Offset: 0x0000D5FC
			public bool Contains([Nullable(new byte[]
			{
				0,
				1,
				1
			})] KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000680 RID: 1664 RVA: 0x0000F403 File Offset: 0x0000D603
			public void CopyTo([Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})] KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			// Token: 0x17000195 RID: 405
			// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000F40A File Offset: 0x0000D60A
			public int Count
			{
				get
				{
					return this._dictionary.Count;
				}
			}

			// Token: 0x17000196 RID: 406
			// (get) Token: 0x06000682 RID: 1666 RVA: 0x0000F417 File Offset: 0x0000D617
			public bool IsReadOnly
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x06000683 RID: 1667 RVA: 0x0000F41E File Offset: 0x0000D61E
			public bool Remove([Nullable(new byte[]
			{
				0,
				1,
				1
			})] KeyValuePair<TKey, TValue> item)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000684 RID: 1668 RVA: 0x0000F425 File Offset: 0x0000D625
			[return: Nullable(new byte[]
			{
				1,
				0,
				1,
				1
			})]
			public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return this._dictionary.GetEnumerator();
			}

			// Token: 0x06000685 RID: 1669 RVA: 0x0000F437 File Offset: 0x0000D637
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this._dictionary.GetEnumerator();
			}

			// Token: 0x04000238 RID: 568
			private readonly object _lock = new object();

			// Token: 0x04000239 RID: 569
			private readonly ReflectionUtils.ThreadSafeDictionaryValueFactory<TKey, TValue> _valueFactory;

			// Token: 0x0400023A RID: 570
			private Dictionary<TKey, TValue> _dictionary;
		}
	}
}
