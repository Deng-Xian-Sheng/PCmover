using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000002 RID: 2
	public static class AllClasses
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		public static IEnumerable<Type> FromAssemblies(params Assembly[] assemblies)
		{
			return AllClasses.FromAssemblies(true, assemblies);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020D9 File Offset: 0x000002D9
		public static IEnumerable<Type> FromAssemblies(bool skipOnError, params Assembly[] assemblies)
		{
			return AllClasses.FromAssemblies(assemblies, skipOnError);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020E2 File Offset: 0x000002E2
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Simplify API")]
		public static IEnumerable<Type> FromAssemblies(IEnumerable<Assembly> assemblies, bool skipOnError = true)
		{
			Guard.ArgumentNotNull(assemblies, "assemblies");
			return AllClasses.FromCheckedAssemblies(AllClasses.CheckAssemblies(assemblies), skipOnError);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002204 File Offset: 0x00000404
		private static IEnumerable<Type> FromCheckedAssemblies(IEnumerable<Assembly> assemblies, bool skipOnError)
		{
			return assemblies.SelectMany(delegate(Assembly a)
			{
				IEnumerable<TypeInfo> source;
				try
				{
					source = a.DefinedTypes;
				}
				catch (ReflectionTypeLoadException ex)
				{
					if (!skipOnError)
					{
						throw;
					}
					source = from t in ex.Types.TakeWhile((Type t) => t != null)
					select t.GetTypeInfo();
				}
				return from ti in source
				where (ti.IsClass & !ti.IsAbstract) && !ti.IsValueType && ti.IsVisible
				select ti.AsType();
			});
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002230 File Offset: 0x00000430
		private static IEnumerable<Assembly> CheckAssemblies(IEnumerable<Assembly> assemblies)
		{
			foreach (Assembly left in assemblies)
			{
				if (left == null)
				{
					throw new ArgumentException(Resources.ExceptionNullAssembly, "assemblies");
				}
			}
			return assemblies;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000228C File Offset: 0x0000048C
		private static bool IsSystemAssembly(Assembly a)
		{
			if (AllClasses.NetFrameworkProductName != null)
			{
				AssemblyProductAttribute customAttribute = a.GetCustomAttribute<AssemblyProductAttribute>();
				return customAttribute != null && string.Compare(AllClasses.NetFrameworkProductName, customAttribute.Product, StringComparison.Ordinal) == 0;
			}
			return false;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022C4 File Offset: 0x000004C4
		private static bool IsUnityAssembly(Assembly a)
		{
			if (AllClasses.UnityProductName != null)
			{
				AssemblyProductAttribute customAttribute = a.GetCustomAttribute<AssemblyProductAttribute>();
				return customAttribute != null && string.Compare(AllClasses.UnityProductName, customAttribute.Product, StringComparison.Ordinal) == 0;
			}
			return false;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000022FC File Offset: 0x000004FC
		private static string GetNetFrameworkProductName()
		{
			AssemblyProductAttribute customAttribute = typeof(object).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>();
			if (customAttribute == null)
			{
				return null;
			}
			return customAttribute.Product;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002330 File Offset: 0x00000530
		private static string GetUnityProductName()
		{
			AssemblyProductAttribute customAttribute = typeof(AllClasses).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyProductAttribute>();
			if (customAttribute == null)
			{
				return null;
			}
			return customAttribute.Product;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002362 File Offset: 0x00000562
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Simplify API")]
		public static IEnumerable<Type> FromLoadedAssemblies(bool includeSystemAssemblies = false, bool includeUnityAssemblies = false, bool includeDynamicAssemblies = false, bool skipOnError = true)
		{
			return AllClasses.FromCheckedAssemblies(AllClasses.GetLoadedAssemblies(includeSystemAssemblies, includeUnityAssemblies, includeDynamicAssemblies), skipOnError);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002372 File Offset: 0x00000572
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Simplify API")]
		public static IEnumerable<Type> FromAssembliesInBasePath(bool includeSystemAssemblies = false, bool includeUnityAssemblies = false, bool skipOnError = true)
		{
			return AllClasses.FromCheckedAssemblies(AllClasses.GetAssembliesInBasePath(includeSystemAssemblies, includeUnityAssemblies, skipOnError), skipOnError);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023D0 File Offset: 0x000005D0
		private static IEnumerable<Assembly> GetAssembliesInBasePath(bool includeSystemAssemblies, bool includeUnityAssemblies, bool skipOnError)
		{
			string baseDirectory;
			try
			{
				baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			}
			catch (SecurityException)
			{
				if (!skipOnError)
				{
					throw;
				}
				return new Assembly[0];
			}
			return from an in AllClasses.GetAssemblyNames(baseDirectory, skipOnError)
			select AllClasses.LoadAssembly(Path.GetFileNameWithoutExtension(an), skipOnError) into a
			where a != null && (includeSystemAssemblies || !AllClasses.IsSystemAssembly(a)) && (includeUnityAssemblies || !AllClasses.IsUnityAssembly(a))
			select a;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000245C File Offset: 0x0000065C
		private static IEnumerable<string> GetAssemblyNames(string path, bool skipOnError)
		{
			IEnumerable<string> result;
			try
			{
				result = Directory.EnumerateFiles(path, "*.dll").Concat(Directory.EnumerateFiles(path, "*.exe"));
			}
			catch (Exception ex)
			{
				if (!skipOnError || (!(ex is DirectoryNotFoundException) && !(ex is IOException) && !(ex is SecurityException) && !(ex is UnauthorizedAccessException)))
				{
					throw;
				}
				result = new string[0];
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000024C8 File Offset: 0x000006C8
		private static Assembly LoadAssembly(string assemblyName, bool skipOnError)
		{
			Assembly result;
			try
			{
				result = Assembly.Load(assemblyName);
			}
			catch (Exception ex)
			{
				if (!skipOnError || (!(ex is FileNotFoundException) && !(ex is FileLoadException) && !(ex is BadImageFormatException)))
				{
					throw;
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002554 File Offset: 0x00000754
		private static IEnumerable<Assembly> GetLoadedAssemblies(bool includeSystemAssemblies, bool includeUnityAssemblies, bool includeDynamicAssemblies)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			if (includeSystemAssemblies && includeDynamicAssemblies)
			{
				return assemblies;
			}
			return from a in assemblies
			where (includeDynamicAssemblies || !a.IsDynamic) && (includeSystemAssemblies || !AllClasses.IsSystemAssembly(a)) && (includeUnityAssemblies || !AllClasses.IsUnityAssembly(a))
			select a;
		}

		// Token: 0x04000001 RID: 1
		private static readonly string NetFrameworkProductName = AllClasses.GetNetFrameworkProductName();

		// Token: 0x04000002 RID: 2
		private static readonly string UnityProductName = AllClasses.GetUnityProductName();
	}
}
