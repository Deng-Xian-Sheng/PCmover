using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CefSharp.Event;
using CefSharp.JavascriptBinding;

namespace CefSharp.Internals
{
	// Token: 0x020000DB RID: 219
	public class JavascriptObjectRepository : FreezableBase, IJavascriptObjectRepositoryInternal, IJavascriptObjectRepository, IDisposable
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000678 RID: 1656 RVA: 0x00009E0C File Offset: 0x0000800C
		// (remove) Token: 0x06000679 RID: 1657 RVA: 0x00009E44 File Offset: 0x00008044
		public event EventHandler<JavascriptBindingEventArgs> ResolveObject;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600067A RID: 1658 RVA: 0x00009E7C File Offset: 0x0000807C
		// (remove) Token: 0x0600067B RID: 1659 RVA: 0x00009EB4 File Offset: 0x000080B4
		public event EventHandler<JavascriptBindingCompleteEventArgs> ObjectBoundInJavascript;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x0600067C RID: 1660 RVA: 0x00009EEC File Offset: 0x000080EC
		// (remove) Token: 0x0600067D RID: 1661 RVA: 0x00009F24 File Offset: 0x00008124
		public event EventHandler<JavascriptBindingMultipleCompleteEventArgs> ObjectsBoundInJavascript;

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x00009F59 File Offset: 0x00008159
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x00009F61 File Offset: 0x00008161
		public bool IsBrowserInitialized { get; set; }

		// Token: 0x06000680 RID: 1664 RVA: 0x00009F6A File Offset: 0x0000816A
		public void Dispose()
		{
			this.ResolveObject = null;
			this.ObjectBoundInJavascript = null;
			this.ObjectsBoundInJavascript = null;
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00009F81 File Offset: 0x00008181
		public bool HasBoundObjects
		{
			get
			{
				return this.objects.Count > 0;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00009F91 File Offset: 0x00008191
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x00009F99 File Offset: 0x00008199
		public JavascriptBindingSettings Settings { get; private set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00009FA2 File Offset: 0x000081A2
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x00009FAA File Offset: 0x000081AA
		public IJavascriptNameConverter NameConverter
		{
			get
			{
				return this.nameConverter;
			}
			set
			{
				base.ThrowIfFrozen("NameConverter");
				this.nameConverter = value;
			}
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00009FBE File Offset: 0x000081BE
		public JavascriptObjectRepository()
		{
			this.Settings = new JavascriptBindingSettings();
			this.nameConverter = new LegacyCamelCaseJavascriptNameConverter();
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00009FE8 File Offset: 0x000081E8
		public bool IsBound(string name)
		{
			return this.objects.Values.Any((JavascriptObject x) => x.Name == name);
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0000A020 File Offset: 0x00008220
		List<JavascriptObject> IJavascriptObjectRepositoryInternal.GetLegacyBoundObjects()
		{
			this.RaiseResolveObjectEvent("Legacy");
			return (from x in this.objects.Values
			where x.RootObject
			select x).ToList<JavascriptObject>();
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0000A06C File Offset: 0x0000826C
		List<JavascriptObject> IJavascriptObjectRepositoryInternal.GetObjects(List<string> names)
		{
			bool flag = names == null || names.Count == 0;
			if (flag)
			{
				this.RaiseResolveObjectEvent("All");
				return (from x in this.objects.Values
				where x.RootObject
				select x).ToList<JavascriptObject>();
			}
			foreach (string name in names)
			{
				if (!this.IsBound(name))
				{
					this.RaiseResolveObjectEvent(name);
				}
			}
			return (from x in this.objects.Values
			where names.Contains(x.JavascriptName) && x.RootObject
			select x).ToList<JavascriptObject>();
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0000A158 File Offset: 0x00008358
		void IJavascriptObjectRepositoryInternal.ObjectsBound(List<Tuple<string, bool, bool>> objs)
		{
			EventHandler<JavascriptBindingCompleteEventArgs> boundObjectHandler = this.ObjectBoundInJavascript;
			EventHandler<JavascriptBindingMultipleCompleteEventArgs> boundObjectsHandler = this.ObjectsBoundInJavascript;
			if (boundObjectHandler != null || boundObjectsHandler != null)
			{
				Task.Run(delegate()
				{
					foreach (Tuple<string, bool, bool> tuple in objs)
					{
						EventHandler<JavascriptBindingCompleteEventArgs> boundObjectHandler = boundObjectHandler;
						if (boundObjectHandler != null)
						{
							boundObjectHandler(this, new JavascriptBindingCompleteEventArgs(this, tuple.Item1, tuple.Item2, tuple.Item3));
						}
					}
					EventHandler<JavascriptBindingMultipleCompleteEventArgs> boundObjectsHandler = boundObjectsHandler;
					if (boundObjectsHandler == null)
					{
						return;
					}
					boundObjectsHandler(this, new JavascriptBindingMultipleCompleteEventArgs(this, (from x in objs
					select x.Item1).ToList<string>()));
				});
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0000A1B4 File Offset: 0x000083B4
		private JavascriptObject CreateJavascriptObject(bool rootObject)
		{
			long num = Interlocked.Increment(ref JavascriptObjectRepository.lastId);
			JavascriptObject javascriptObject = new JavascriptObject
			{
				Id = num,
				RootObject = rootObject
			};
			this.objects[num] = javascriptObject;
			return javascriptObject;
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0000A1F0 File Offset: 0x000083F0
		public void Register(string name, object value, bool isAsync, BindingOptions options)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			base.Freeze();
			if (!this.IsBrowserInitialized && !isAsync)
			{
				CefSharpSettings.WcfEnabled = true;
			}
			if (!CefSharpSettings.WcfEnabled && !isAsync)
			{
				throw new InvalidOperationException("To enable synchronous JS bindings set WcfEnabled true in CefSharpSettings before you create\n                                                    your ChromiumWebBrowser instances.");
			}
			if (this.objects.Values.Count((JavascriptObject x) => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase)) > 0)
			{
				throw new ArgumentException("Object already bound with name:" + name, name);
			}
			Type type = value.GetType();
			if (type.IsPrimitive || type.BaseType.Namespace.StartsWith("System."))
			{
				throw new ArgumentException("Registering of .Net framework built in types is not supported, create your own Object and proxy the calls if you need to access a Window/Form/Control.", "value");
			}
			JavascriptObject javascriptObject = this.CreateJavascriptObject(true);
			javascriptObject.Value = value;
			javascriptObject.Name = name;
			javascriptObject.JavascriptName = name;
			javascriptObject.IsAsync = isAsync;
			javascriptObject.Binder = ((options != null) ? options.Binder : null);
			javascriptObject.MethodInterceptor = ((options != null) ? options.MethodInterceptor : null);
			javascriptObject.PropertyInterceptor = ((options != null) ? options.PropertyInterceptor : null);
			this.AnalyseObjectForBinding(javascriptObject, true, !isAsync, false);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0000A33F File Offset: 0x0000853F
		public void UnRegisterAll()
		{
			this.objects.Clear();
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0000A34C File Offset: 0x0000854C
		public bool UnRegister(string name)
		{
			foreach (KeyValuePair<long, JavascriptObject> keyValuePair in this.objects)
			{
				if (string.Equals(keyValuePair.Value.Name, name, StringComparison.OrdinalIgnoreCase))
				{
					JavascriptObject javascriptObject;
					this.objects.TryRemove(keyValuePair.Key, out javascriptObject);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0000A3C4 File Offset: 0x000085C4
		TryCallMethodResult IJavascriptObjectRepositoryInternal.TryCallMethod(long objectId, string name, object[] parameters)
		{
			return this.TryCallMethod(objectId, name, parameters);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0000A3D0 File Offset: 0x000085D0
		protected virtual TryCallMethodResult TryCallMethod(long objectId, string name, object[] parameters)
		{
			string exception = "";
			object obj2 = null;
			JavascriptObject obj;
			if (!this.objects.TryGetValue(objectId, out obj))
			{
				return new TryCallMethodResult(false, obj2, "Object Not Found Matching Id:" + objectId.ToString());
			}
			JavascriptMethod method = obj.Methods.FirstOrDefault((JavascriptMethod p) => p.JavascriptName == name);
			if (method == null)
			{
				throw new InvalidOperationException(string.Format("Method {0} not found on Object of Type {1}", name, obj.Value.GetType()));
			}
			try
			{
				if (method.HasParamArray)
				{
					List<object> list = new List<object>(method.Parameters.Count);
					for (int i = 0; i < method.Parameters.Count; i++)
					{
						if (method.Parameters[i].IsParamArray)
						{
							List<object> list2 = new List<object>();
							for (int j = i; j < parameters.Length; j++)
							{
								list2.Add(parameters[j]);
							}
							list.Add(list2.ToArray());
						}
						else
						{
							object item = parameters.ElementAtOrDefault(i);
							list.Add(item);
						}
					}
					parameters = list.ToArray();
				}
				int num = 0;
				try
				{
					if (obj.Binder != null)
					{
						for (int k = 0; k < parameters.Length; k++)
						{
							Type type = method.Parameters[k].Type;
							parameters[k] = obj.Binder.Bind(parameters[k], type);
						}
					}
					num = method.ParameterCount - parameters.Length;
					if (num > 0)
					{
						List<object> list3 = new List<object>(parameters);
						for (int l = 0; l < num; l++)
						{
							list3.Add(Type.Missing);
						}
						parameters = list3.ToArray();
					}
					if (obj.MethodInterceptor == null)
					{
						obj2 = method.Function(obj.Value, parameters);
					}
					else
					{
						obj2 = obj.MethodInterceptor.Intercept((object[] p) => method.Function(obj.Value, p), parameters, method.ManagedName);
					}
				}
				catch (Exception innerException)
				{
					throw new InvalidOperationException(string.Concat(new string[]
					{
						"Could not execute method: ",
						name,
						"(",
						string.Join(", ", parameters),
						") ",
						(num > 0) ? ("- Missing Parameters: " + num.ToString()) : ""
					}), innerException);
				}
				if (!obj.IsAsync && obj2 != null && JavascriptObjectRepository.IsComplexType(obj2.GetType()))
				{
					JavascriptObject javascriptObject = this.CreateJavascriptObject(false);
					javascriptObject.Value = obj2;
					javascriptObject.Name = "FunctionResult(" + name + ")";
					javascriptObject.JavascriptName = javascriptObject.Name;
					this.AnalyseObjectForBinding(javascriptObject, false, true, true);
					obj2 = javascriptObject;
				}
				return new TryCallMethodResult(true, obj2, exception);
			}
			catch (TargetInvocationException ex)
			{
				Exception baseException = ex.GetBaseException();
				exception = baseException.ToString();
			}
			catch (Exception ex2)
			{
				exception = ex2.ToString();
			}
			return new TryCallMethodResult(false, obj2, exception);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0000A75C File Offset: 0x0000895C
		Task<TryCallMethodResult> IJavascriptObjectRepositoryInternal.TryCallMethodAsync(long objectId, string name, object[] parameters)
		{
			return this.TryCallMethodAsync(objectId, name, parameters);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0000A768 File Offset: 0x00008968
		protected virtual Task<TryCallMethodResult> TryCallMethodAsync(long objectId, string name, object[] parameters)
		{
			JavascriptObjectRepository.<TryCallMethodAsync>d__40 <TryCallMethodAsync>d__;
			<TryCallMethodAsync>d__.<>t__builder = AsyncTaskMethodBuilder<TryCallMethodResult>.Create();
			<TryCallMethodAsync>d__.<>4__this = this;
			<TryCallMethodAsync>d__.objectId = objectId;
			<TryCallMethodAsync>d__.name = name;
			<TryCallMethodAsync>d__.parameters = parameters;
			<TryCallMethodAsync>d__.<>1__state = -1;
			<TryCallMethodAsync>d__.<>t__builder.Start<JavascriptObjectRepository.<TryCallMethodAsync>d__40>(ref <TryCallMethodAsync>d__);
			return <TryCallMethodAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0000A7C3 File Offset: 0x000089C3
		bool IJavascriptObjectRepositoryInternal.TryGetProperty(long objectId, string name, out object result, out string exception)
		{
			return this.TryGetProperty(objectId, name, out result, out exception);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0000A7D0 File Offset: 0x000089D0
		protected virtual bool TryGetProperty(long objectId, string name, out object result, out string exception)
		{
			exception = "";
			result = null;
			JavascriptObject obj;
			if (!this.objects.TryGetValue(objectId, out obj))
			{
				return false;
			}
			JavascriptProperty property = obj.Properties.FirstOrDefault((JavascriptProperty p) => p.JavascriptName == name);
			if (property == null)
			{
				throw new InvalidOperationException(string.Format("Property {0} not found on Object of Type {1}", name, obj.Value.GetType()));
			}
			try
			{
				if (obj.PropertyInterceptor == null)
				{
					result = property.GetValue(obj.Value);
				}
				else
				{
					result = obj.PropertyInterceptor.InterceptGet(() => property.GetValue(obj.Value), property.ManagedName);
				}
				return true;
			}
			catch (Exception ex)
			{
				exception = ex.ToString();
			}
			return false;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0000A8D4 File Offset: 0x00008AD4
		bool IJavascriptObjectRepositoryInternal.TrySetProperty(long objectId, string name, object value, out string exception)
		{
			return this.TrySetProperty(objectId, name, value, out exception);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0000A8E4 File Offset: 0x00008AE4
		protected virtual bool TrySetProperty(long objectId, string name, object value, out string exception)
		{
			exception = "";
			JavascriptObject obj;
			if (!this.objects.TryGetValue(objectId, out obj))
			{
				return false;
			}
			JavascriptProperty property = obj.Properties.FirstOrDefault((JavascriptProperty p) => p.JavascriptName == name);
			if (property == null)
			{
				throw new InvalidOperationException(string.Format("Property {0} not found on Object of Type {1}", name, obj.Value.GetType()));
			}
			try
			{
				if (obj.PropertyInterceptor == null)
				{
					property.SetValue(obj.Value, value);
				}
				else
				{
					obj.PropertyInterceptor.InterceptSet(delegate(object p)
					{
						property.SetValue(obj.Value, p);
					}, value, property.ManagedName);
				}
				return true;
			}
			catch (Exception ex)
			{
				exception = ex.ToString();
			}
			return false;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0000A9E4 File Offset: 0x00008BE4
		private void AnalyseObjectForBinding(JavascriptObject obj, bool analyseMethods, bool analyseProperties, bool readPropertyValue)
		{
			if (obj.Value == null)
			{
				return;
			}
			Type type = obj.Value.GetType();
			if (type.IsPrimitive || type == typeof(string))
			{
				return;
			}
			if (analyseMethods)
			{
				foreach (MethodInfo methodInfo in from p in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
				where !p.IsSpecialName
				select p)
				{
					if (!(methodInfo.ReturnType == typeof(Type)) && !Attribute.IsDefined(methodInfo, typeof(JavascriptIgnoreAttribute)))
					{
						JavascriptMethod item = JavascriptObjectRepository.CreateJavaScriptMethod(methodInfo, this.nameConverter);
						obj.Methods.Add(item);
					}
				}
			}
			if (analyseProperties)
			{
				foreach (PropertyInfo propertyInfo in from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where !p.IsSpecialName
				select p)
				{
					bool flag = propertyInfo.GetIndexParameters().Length != 0;
					bool flag2 = Attribute.IsDefined(propertyInfo, typeof(JavascriptIgnoreAttribute));
					if (!(propertyInfo.PropertyType == typeof(Type)) && !flag && !flag2)
					{
						JavascriptProperty javascriptProperty = this.CreateJavaScriptProperty(propertyInfo);
						if (javascriptProperty.IsComplexType)
						{
							JavascriptObject javascriptObject = this.CreateJavascriptObject(false);
							javascriptObject.Name = propertyInfo.Name;
							javascriptObject.JavascriptName = ((this.nameConverter == null) ? propertyInfo.Name : this.nameConverter.ConvertToJavascript(propertyInfo));
							javascriptObject.Value = javascriptProperty.GetValue(obj.Value);
							javascriptProperty.JsObject = javascriptObject;
							this.AnalyseObjectForBinding(javascriptProperty.JsObject, analyseMethods, true, readPropertyValue);
						}
						else if (readPropertyValue)
						{
							javascriptProperty.PropertyValue = javascriptProperty.GetValue(obj.Value);
						}
						obj.Properties.Add(javascriptProperty);
					}
				}
			}
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0000AC3C File Offset: 0x00008E3C
		private void RaiseResolveObjectEvent(string name)
		{
			EventHandler<JavascriptBindingEventArgs> resolveObject = this.ResolveObject;
			if (resolveObject == null)
			{
				return;
			}
			resolveObject(this, new JavascriptBindingEventArgs(this, name));
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0000AC58 File Offset: 0x00008E58
		private static JavascriptMethod CreateJavaScriptMethod(MethodInfo methodInfo, IJavascriptNameConverter nameConverter)
		{
			JavascriptMethod javascriptMethod = new JavascriptMethod();
			javascriptMethod.ManagedName = methodInfo.Name;
			javascriptMethod.JavascriptName = ((nameConverter == null) ? methodInfo.Name : nameConverter.ConvertToJavascript(methodInfo));
			javascriptMethod.Function = new Func<object, object[], object>(methodInfo.Invoke);
			javascriptMethod.ReturnType = methodInfo.ReturnType;
			javascriptMethod.ParameterCount = methodInfo.GetParameters().Length;
			javascriptMethod.Parameters = (from t in methodInfo.GetParameters()
			select new MethodParameter
			{
				IsParamArray = (t.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length != 0),
				Type = t.ParameterType
			}).ToList<MethodParameter>();
			javascriptMethod.HasParamArray = (javascriptMethod.Parameters.LastOrDefault((MethodParameter t) => t.IsParamArray) != null);
			return javascriptMethod;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0000AD28 File Offset: 0x00008F28
		private JavascriptProperty CreateJavaScriptProperty(PropertyInfo propertyInfo)
		{
			return new JavascriptProperty
			{
				ManagedName = propertyInfo.Name,
				JavascriptName = ((this.nameConverter == null) ? propertyInfo.Name : this.nameConverter.ConvertToJavascript(propertyInfo)),
				SetValue = delegate(object o, object v)
				{
					propertyInfo.SetValue(o, v, null);
				},
				GetValue = ((object o) => propertyInfo.GetValue(o, null)),
				IsComplexType = JavascriptObjectRepository.IsComplexType(propertyInfo.PropertyType),
				IsReadOnly = !propertyInfo.CanWrite
			};
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0000ADD4 File Offset: 0x00008FD4
		private static bool IsComplexType(Type type)
		{
			if (type == typeof(void))
			{
				return false;
			}
			Type type2 = type;
			bool flag = type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
			if (flag)
			{
				type2 = Nullable.GetUnderlyingType(type);
			}
			if (!(type2 == null) && !type2.IsArray)
			{
				string @namespace = type2.Namespace;
				if (@namespace == null || !@namespace.StartsWith("System"))
				{
					return (!type2.IsValueType || type2.IsPrimitive || type2.IsEnum) && !type2.IsPrimitive && type2 != typeof(string);
				}
			}
			return false;
		}

		// Token: 0x0400035E RID: 862
		public const string AllObjects = "All";

		// Token: 0x0400035F RID: 863
		public const string LegacyObjects = "Legacy";

		// Token: 0x04000360 RID: 864
		private static long lastId;

		// Token: 0x04000364 RID: 868
		protected readonly ConcurrentDictionary<long, JavascriptObject> objects = new ConcurrentDictionary<long, JavascriptObject>();

		// Token: 0x04000365 RID: 869
		private IJavascriptNameConverter nameConverter;
	}
}
