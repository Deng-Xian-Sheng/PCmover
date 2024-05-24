using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000E6 RID: 230
	internal static class ShellPropertyFactory
	{
		// Token: 0x060008C3 RID: 2243 RVA: 0x00025620 File Offset: 0x00023820
		public static IShellProperty CreateShellProperty(PropertyKey propKey, ShellObject shellObject)
		{
			return ShellPropertyFactory.GenericCreateShellProperty<ShellObject>(propKey, shellObject);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0002563C File Offset: 0x0002383C
		public static IShellProperty CreateShellProperty(PropertyKey propKey, IPropertyStore store)
		{
			return ShellPropertyFactory.GenericCreateShellProperty<IPropertyStore>(propKey, store);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00025658 File Offset: 0x00023858
		private static IShellProperty GenericCreateShellProperty<T>(PropertyKey propKey, T thirdArg)
		{
			Type type = (thirdArg is ShellObject) ? typeof(ShellObject) : typeof(T);
			ShellPropertyDescription propertyDescription = ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propKey);
			Type type2 = typeof(ShellProperty<>).MakeGenericType(new Type[]
			{
				ShellPropertyFactory.VarEnumToSystemType(propertyDescription.VarEnumType)
			});
			int typeHash = ShellPropertyFactory.GetTypeHash(new Type[]
			{
				type2,
				type
			});
			Func<PropertyKey, ShellPropertyDescription, object, IShellProperty> func;
			if (!ShellPropertyFactory._storeCache.TryGetValue(typeHash, out func))
			{
				Type[] argTypes = new Type[]
				{
					typeof(PropertyKey),
					typeof(ShellPropertyDescription),
					type
				};
				func = ShellPropertyFactory.ExpressConstructor(type2, argTypes);
				ShellPropertyFactory._storeCache.Add(typeHash, func);
			}
			return func(propKey, propertyDescription, thirdArg);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0002574C File Offset: 0x0002394C
		public static Type VarEnumToSystemType(VarEnum VarEnumType)
		{
			if (VarEnumType <= (VarEnum)4101)
			{
				if (VarEnumType <= VarEnum.VT_LPWSTR)
				{
					switch (VarEnumType)
					{
					case VarEnum.VT_EMPTY:
					case VarEnum.VT_NULL:
						return typeof(object);
					case VarEnum.VT_I2:
						return typeof(short?);
					case VarEnum.VT_I4:
						return typeof(int?);
					case VarEnum.VT_R4:
					case VarEnum.VT_CY:
					case VarEnum.VT_DATE:
					case VarEnum.VT_BSTR:
					case VarEnum.VT_DISPATCH:
					case VarEnum.VT_ERROR:
					case VarEnum.VT_VARIANT:
					case VarEnum.VT_DECIMAL:
					case (VarEnum)15:
					case VarEnum.VT_I1:
						break;
					case VarEnum.VT_R8:
						return typeof(double?);
					case VarEnum.VT_BOOL:
						return typeof(bool?);
					case VarEnum.VT_UNKNOWN:
						return typeof(IntPtr?);
					case VarEnum.VT_UI1:
						return typeof(byte?);
					case VarEnum.VT_UI2:
						return typeof(ushort?);
					case VarEnum.VT_UI4:
						return typeof(uint?);
					case VarEnum.VT_I8:
						return typeof(long?);
					case VarEnum.VT_UI8:
						return typeof(ulong?);
					default:
						if (VarEnumType == VarEnum.VT_LPWSTR)
						{
							return typeof(string);
						}
						break;
					}
				}
				else
				{
					switch (VarEnumType)
					{
					case VarEnum.VT_FILETIME:
						return typeof(DateTime?);
					case VarEnum.VT_BLOB:
						return typeof(byte[]);
					case VarEnum.VT_STREAM:
						return typeof(IStream);
					case VarEnum.VT_STORAGE:
					case VarEnum.VT_STREAMED_OBJECT:
					case VarEnum.VT_STORED_OBJECT:
					case VarEnum.VT_BLOB_OBJECT:
						break;
					case VarEnum.VT_CF:
						return typeof(IntPtr?);
					case VarEnum.VT_CLSID:
						return typeof(IntPtr?);
					default:
						switch (VarEnumType)
						{
						case (VarEnum)4098:
							return typeof(short[]);
						case (VarEnum)4099:
							return typeof(int[]);
						case (VarEnum)4101:
							return typeof(double[]);
						}
						break;
					}
				}
			}
			else if (VarEnumType <= (VarEnum)4127)
			{
				switch (VarEnumType)
				{
				case (VarEnum)4107:
					return typeof(bool[]);
				case (VarEnum)4108:
				case (VarEnum)4109:
				case (VarEnum)4110:
				case (VarEnum)4111:
				case (VarEnum)4112:
					break;
				case (VarEnum)4113:
					return typeof(byte[]);
				case (VarEnum)4114:
					return typeof(ushort[]);
				case (VarEnum)4115:
					return typeof(uint[]);
				case (VarEnum)4116:
					return typeof(long[]);
				case (VarEnum)4117:
					return typeof(ulong[]);
				default:
					if (VarEnumType == (VarEnum)4127)
					{
						return typeof(string[]);
					}
					break;
				}
			}
			else
			{
				if (VarEnumType == (VarEnum)4160)
				{
					return typeof(DateTime[]);
				}
				switch (VarEnumType)
				{
				case (VarEnum)4167:
					return typeof(IntPtr[]);
				case (VarEnum)4168:
					return typeof(IntPtr[]);
				}
			}
			return typeof(object);
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00025AD4 File Offset: 0x00023CD4
		private static Func<PropertyKey, ShellPropertyDescription, object, IShellProperty> ExpressConstructor(Type type, Type[] argTypes)
		{
			int typeHash = ShellPropertyFactory.GetTypeHash(argTypes);
			ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((ConstructorInfo x) => typeHash == ShellPropertyFactory.GetTypeHash(from a in x.GetParameters()
			select a.ParameterType));
			if (constructorInfo == null)
			{
				throw new ArgumentException(LocalizedMessages.ShellPropertyFactoryConstructorNotFound, "type");
			}
			ParameterExpression parameterExpression = Expression.Parameter(argTypes[0], "propKey");
			ParameterExpression parameterExpression2 = Expression.Parameter(argTypes[1], "desc");
			ParameterExpression parameterExpression3 = Expression.Parameter(typeof(object), "third");
			NewExpression body = Expression.New(constructorInfo, new Expression[]
			{
				parameterExpression,
				parameterExpression2,
				Expression.Convert(parameterExpression3, argTypes[2])
			});
			return Expression.Lambda<Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>>(body, new ParameterExpression[]
			{
				parameterExpression,
				parameterExpression2,
				parameterExpression3
			}).Compile();
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00025BB4 File Offset: 0x00023DB4
		private static int GetTypeHash(params Type[] types)
		{
			return ShellPropertyFactory.GetTypeHash((IEnumerable<Type>)types);
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00025BD4 File Offset: 0x00023DD4
		private static int GetTypeHash(IEnumerable<Type> types)
		{
			int num = 0;
			foreach (Type type in types)
			{
				num = num * 31 + type.GetHashCode();
			}
			return num;
		}

		// Token: 0x04000439 RID: 1081
		private static Dictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>> _storeCache = new Dictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>>();
	}
}
