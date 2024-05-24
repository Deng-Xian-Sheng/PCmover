using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CefSharp.JavascriptBinding;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000B6 RID: 182
	public class DefaultBinder : IBinder
	{
		// Token: 0x06000588 RID: 1416 RVA: 0x00008C62 File Offset: 0x00006E62
		public DefaultBinder(IJavascriptNameConverter javascriptNameConverter = null)
		{
			this.javascriptNameConverter = javascriptNameConverter;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00008C74 File Offset: 0x00006E74
		public virtual object Bind(object obj, Type targetType)
		{
			if (obj == null)
			{
				if (targetType.IsValueType)
				{
					return Activator.CreateInstance(targetType);
				}
				return null;
			}
			else
			{
				Type type = obj.GetType();
				if (targetType.IsAssignableFrom(type))
				{
					return obj;
				}
				if (targetType.IsEnum && targetType.IsEnumDefined(obj))
				{
					return Enum.ToObject(targetType, obj);
				}
				TypeConverter converter = TypeDescriptor.GetConverter(type);
				if (converter.CanConvertTo(targetType))
				{
					return converter.ConvertTo(obj, targetType);
				}
				if (targetType.IsCollection() || targetType.IsArray() || targetType.IsEnumerable())
				{
					return this.BindCollection(targetType, type, obj);
				}
				return this.BindObject(targetType, type, obj);
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00008D04 File Offset: 0x00006F04
		protected virtual object BindCollection(Type targetType, Type objType, object obj)
		{
			ICollection collection = obj as ICollection;
			if (collection == null)
			{
				return null;
			}
			Type type;
			if (targetType.GetTypeInfo().IsGenericType)
			{
				type = targetType.GetGenericArguments().FirstOrDefault<Type>();
			}
			else
			{
				Type type2 = (from i in targetType.GetInterfaces()
				where i.GetTypeInfo().IsGenericType
				select i).FirstOrDefault((Type i) => i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
				type = ((type2 == null) ? null : type2.GetGenericArguments().FirstOrDefault<Type>());
			}
			if (type == null)
			{
				type = typeof(object);
			}
			Type type3 = typeof(List<>).MakeGenericType(new Type[]
			{
				type
			});
			IList list = (IList)Activator.CreateInstance(type3);
			IList<object> source = (IList<object>)obj;
			for (int j = 0; j < collection.Count; j++)
			{
				object obj2 = source.ElementAtOrDefault(j);
				object value = this.Bind(obj2, type);
				list.Add(value);
			}
			if (targetType.IsArray())
			{
				MethodInfo methodInfo = DefaultBinder.ToArrayMethodInfo.MakeGenericMethod(new Type[]
				{
					type
				});
				MethodBase methodBase = methodInfo;
				object obj3 = null;
				object[] parameters = new IList[]
				{
					list
				};
				return methodBase.Invoke(obj3, parameters);
			}
			return list;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00008E50 File Offset: 0x00007050
		protected virtual object BindObject(Type targetType, Type objType, object obj)
		{
			object obj2 = Activator.CreateInstance(targetType, true);
			if (typeof(IDictionary<string, object>).IsAssignableFrom(objType))
			{
				IDictionary<string, object> dictionary = (IDictionary<string, object>)obj;
				List<BindingMemberInfo> list = BindingMemberInfo.Collect(targetType).ToList<BindingMemberInfo>();
				foreach (BindingMemberInfo bindingMemberInfo in list)
				{
					string propertyName = this.GetPropertyName(bindingMemberInfo);
					object obj3;
					if (dictionary.TryGetValue(propertyName, out obj3))
					{
						object newValue = this.Bind(obj3, bindingMemberInfo.Type);
						bindingMemberInfo.SetValue(obj2, newValue);
					}
				}
			}
			return obj2;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00008EF8 File Offset: 0x000070F8
		private string GetPropertyName(BindingMemberInfo modelProperty)
		{
			if (this.javascriptNameConverter == null)
			{
				return modelProperty.Name;
			}
			return this.javascriptNameConverter.ConvertReturnedObjectPropertyAndFieldToNameJavascript(modelProperty);
		}

		// Token: 0x0400031E RID: 798
		private static readonly MethodInfo ToArrayMethodInfo = typeof(Enumerable).GetMethod("ToArray", BindingFlags.Static | BindingFlags.Public);

		// Token: 0x0400031F RID: 799
		private readonly IJavascriptNameConverter javascriptNameConverter;
	}
}
