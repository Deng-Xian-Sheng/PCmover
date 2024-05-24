using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Prism.Mvvm
{
	// Token: 0x02000007 RID: 7
	public static class ViewModelLocationProvider
	{
		// Token: 0x06000027 RID: 39 RVA: 0x00002469 File Offset: 0x00000669
		public static void SetDefaultViewModelFactory(Func<Type, object> viewModelFactory)
		{
			ViewModelLocationProvider._defaultViewModelFactory = viewModelFactory;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002471 File Offset: 0x00000671
		public static void SetDefaultViewModelFactory(Func<object, Type, object> viewModelFactory)
		{
			ViewModelLocationProvider._defaultViewModelFactoryWithViewParameter = viewModelFactory;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002479 File Offset: 0x00000679
		public static void SetDefaultViewTypeToViewModelTypeResolver(Func<Type, Type> viewTypeToViewModelTypeResolver)
		{
			ViewModelLocationProvider._defaultViewTypeToViewModelTypeResolver = viewTypeToViewModelTypeResolver;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002484 File Offset: 0x00000684
		public static void AutoWireViewModelChanged(object view, Action<object, object> setDataContextCallback)
		{
			object obj = ViewModelLocationProvider.GetViewModelForView(view);
			if (obj == null)
			{
				Type type = ViewModelLocationProvider.GetViewModelTypeForView(view.GetType());
				if (type == null)
				{
					type = ViewModelLocationProvider._defaultViewTypeToViewModelTypeResolver(view.GetType());
				}
				if (type == null)
				{
					return;
				}
				obj = ((ViewModelLocationProvider._defaultViewModelFactoryWithViewParameter != null) ? ViewModelLocationProvider._defaultViewModelFactoryWithViewParameter(view, type) : ViewModelLocationProvider._defaultViewModelFactory(type));
			}
			setDataContextCallback(view, obj);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024E8 File Offset: 0x000006E8
		private static object GetViewModelForView(object view)
		{
			string key = view.GetType().ToString();
			if (ViewModelLocationProvider._factories.ContainsKey(key))
			{
				return ViewModelLocationProvider._factories[key]();
			}
			return null;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002520 File Offset: 0x00000720
		private static Type GetViewModelTypeForView(Type view)
		{
			string key = view.ToString();
			if (ViewModelLocationProvider._typeFactories.ContainsKey(key))
			{
				return ViewModelLocationProvider._typeFactories[key];
			}
			return null;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000254E File Offset: 0x0000074E
		public static void Register<T>(Func<object> factory)
		{
			ViewModelLocationProvider.Register(typeof(T).ToString(), factory);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002565 File Offset: 0x00000765
		public static void Register(string viewTypeName, Func<object> factory)
		{
			ViewModelLocationProvider._factories[viewTypeName] = factory;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002574 File Offset: 0x00000774
		public static void Register<T, VM>()
		{
			object typeFromHandle = typeof(T);
			Type typeFromHandle2 = typeof(VM);
			ViewModelLocationProvider.Register(typeFromHandle.ToString(), typeFromHandle2);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000025A1 File Offset: 0x000007A1
		public static void Register(string viewTypeName, Type viewModelType)
		{
			ViewModelLocationProvider._typeFactories[viewTypeName] = viewModelType;
		}

		// Token: 0x04000007 RID: 7
		private static Dictionary<string, Func<object>> _factories = new Dictionary<string, Func<object>>();

		// Token: 0x04000008 RID: 8
		private static Dictionary<string, Type> _typeFactories = new Dictionary<string, Type>();

		// Token: 0x04000009 RID: 9
		private static Func<Type, object> _defaultViewModelFactory = (Type type) => Activator.CreateInstance(type);

		// Token: 0x0400000A RID: 10
		private static Func<object, Type, object> _defaultViewModelFactoryWithViewParameter;

		// Token: 0x0400000B RID: 11
		private static Func<Type, Type> _defaultViewTypeToViewModelTypeResolver = delegate(Type viewType)
		{
			string text = viewType.FullName;
			text = text.Replace(".Views.", ".ViewModels.");
			string fullName = viewType.GetTypeInfo().Assembly.FullName;
			string text2 = text.EndsWith("View") ? "Model" : "ViewModel";
			return Type.GetType(string.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", new object[]
			{
				text,
				text2,
				fullName
			}));
		};
	}
}
