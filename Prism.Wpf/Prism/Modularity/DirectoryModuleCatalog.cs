using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Policy;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x0200004B RID: 75
	public class DirectoryModuleCatalog : ModuleCatalog
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000233 RID: 563 RVA: 0x0000692D File Offset: 0x00004B2D
		// (set) Token: 0x06000234 RID: 564 RVA: 0x00006935 File Offset: 0x00004B35
		public string ModulePath { get; set; }

		// Token: 0x06000235 RID: 565 RVA: 0x00006940 File Offset: 0x00004B40
		protected override void InnerLoad()
		{
			if (string.IsNullOrEmpty(this.ModulePath))
			{
				throw new InvalidOperationException(Resources.ModulePathCannotBeNullOrEmpty);
			}
			if (!Directory.Exists(this.ModulePath))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.DirectoryNotFound, new object[]
				{
					this.ModulePath
				}));
			}
			AppDomain appDomain = this.BuildChildDomain(AppDomain.CurrentDomain);
			try
			{
				List<string> list = new List<string>();
				IEnumerable<string> collection = from Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()
				where !(assembly is AssemblyBuilder) && assembly.GetType().FullName != "System.Reflection.Emit.InternalAssemblyBuilder" && !string.IsNullOrEmpty(assembly.Location)
				select assembly.Location;
				list.AddRange(collection);
				Type typeFromHandle = typeof(DirectoryModuleCatalog.InnerModuleInfoLoader);
				if (typeFromHandle.Assembly != null)
				{
					DirectoryModuleCatalog.InnerModuleInfoLoader innerModuleInfoLoader = (DirectoryModuleCatalog.InnerModuleInfoLoader)appDomain.CreateInstanceFrom(typeFromHandle.Assembly.Location, typeFromHandle.FullName).Unwrap();
					innerModuleInfoLoader.LoadAssemblies(list);
					base.Items.AddRange(innerModuleInfoLoader.GetModuleInfos(this.ModulePath));
				}
			}
			finally
			{
				AppDomain.Unload(appDomain);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00006A80 File Offset: 0x00004C80
		protected virtual AppDomain BuildChildDomain(AppDomain parentDomain)
		{
			if (parentDomain == null)
			{
				throw new ArgumentNullException("parentDomain");
			}
			Evidence securityInfo = new Evidence(parentDomain.Evidence);
			AppDomainSetup setupInformation = parentDomain.SetupInformation;
			return AppDomain.CreateDomain("DiscoveryRegion", securityInfo, setupInformation);
		}

		// Token: 0x0200009D RID: 157
		private class InnerModuleInfoLoader : MarshalByRefObject
		{
			// Token: 0x06000422 RID: 1058 RVA: 0x0000A208 File Offset: 0x00008408
			internal ModuleInfo[] GetModuleInfos(string path)
			{
				DirectoryInfo directory = new DirectoryInfo(path);
				ResolveEventHandler value = (object sender, ResolveEventArgs args) => DirectoryModuleCatalog.InnerModuleInfoLoader.OnReflectionOnlyResolve(args, directory);
				AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += value;
				Type type = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().First((Assembly asm) => asm.FullName == typeof(IModule).Assembly.FullName).GetType(typeof(IModule).FullName);
				ModuleInfo[] result = DirectoryModuleCatalog.InnerModuleInfoLoader.GetNotAllreadyLoadedModuleInfos(directory, type).ToArray<ModuleInfo>();
				AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= value;
				return result;
			}

			// Token: 0x06000423 RID: 1059 RVA: 0x0000A29C File Offset: 0x0000849C
			private static IEnumerable<ModuleInfo> GetNotAllreadyLoadedModuleInfos(DirectoryInfo directory, Type IModuleType)
			{
				List<FileInfo> list = new List<FileInfo>();
				Assembly[] alreadyLoadedAssemblies = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies();
				foreach (FileInfo fileInfo in from file in directory.GetFiles("*.dll")
				where alreadyLoadedAssemblies.FirstOrDefault((Assembly assembly) => string.Compare(Path.GetFileName(assembly.Location), file.Name, StringComparison.OrdinalIgnoreCase) == 0) == null
				select file)
				{
					try
					{
						Assembly.ReflectionOnlyLoadFrom(fileInfo.FullName);
						list.Add(fileInfo);
					}
					catch (BadImageFormatException)
					{
					}
				}
				Func<Type, bool> <>9__3;
				return list.SelectMany(delegate(FileInfo file)
				{
					IEnumerable<Type> source = Assembly.ReflectionOnlyLoadFrom(file.FullName).GetExportedTypes().Where(new Func<Type, bool>(IModuleType.IsAssignableFrom));
					Func<Type, bool> predicate;
					if ((predicate = <>9__3) == null)
					{
						predicate = (<>9__3 = ((Type t) => t != IModuleType));
					}
					return from t in source.Where(predicate)
					where !t.IsAbstract
					select t into type
					select DirectoryModuleCatalog.InnerModuleInfoLoader.CreateModuleInfo(type);
				});
			}

			// Token: 0x06000424 RID: 1060 RVA: 0x0000A354 File Offset: 0x00008554
			private static Assembly OnReflectionOnlyResolve(ResolveEventArgs args, DirectoryInfo directory)
			{
				Assembly assembly = AppDomain.CurrentDomain.ReflectionOnlyGetAssemblies().FirstOrDefault((Assembly asm) => string.Equals(asm.FullName, args.Name, StringComparison.OrdinalIgnoreCase));
				if (assembly != null)
				{
					return assembly;
				}
				AssemblyName assemblyName = new AssemblyName(args.Name);
				string text = Path.Combine(directory.FullName, assemblyName.Name + ".dll");
				if (File.Exists(text))
				{
					return Assembly.ReflectionOnlyLoadFrom(text);
				}
				return Assembly.ReflectionOnlyLoad(args.Name);
			}

			// Token: 0x06000425 RID: 1061 RVA: 0x0000A3E4 File Offset: 0x000085E4
			internal void LoadAssemblies(IEnumerable<string> assemblies)
			{
				foreach (string assemblyFile in assemblies)
				{
					try
					{
						Assembly.ReflectionOnlyLoadFrom(assemblyFile);
					}
					catch (FileNotFoundException)
					{
					}
				}
			}

			// Token: 0x06000426 RID: 1062 RVA: 0x0000A440 File Offset: 0x00008640
			private static ModuleInfo CreateModuleInfo(Type type)
			{
				string name = type.Name;
				List<string> list = new List<string>();
				bool flag = false;
				CustomAttributeData customAttributeData = CustomAttributeData.GetCustomAttributes(type).FirstOrDefault((CustomAttributeData cad) => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);
				if (customAttributeData != null)
				{
					foreach (CustomAttributeNamedArgument customAttributeNamedArgument in customAttributeData.NamedArguments)
					{
						string name2 = customAttributeNamedArgument.MemberInfo.Name;
						if (!(name2 == "ModuleName"))
						{
							if (!(name2 == "OnDemand"))
							{
								if (name2 == "StartupLoaded")
								{
									flag = !(bool)customAttributeNamedArgument.TypedValue.Value;
								}
							}
							else
							{
								flag = (bool)customAttributeNamedArgument.TypedValue.Value;
							}
						}
						else
						{
							name = (string)customAttributeNamedArgument.TypedValue.Value;
						}
					}
				}
				foreach (CustomAttributeData customAttributeData2 in from cad in CustomAttributeData.GetCustomAttributes(type)
				where cad.Constructor.DeclaringType.FullName == typeof(ModuleDependencyAttribute).FullName
				select cad)
				{
					list.Add((string)customAttributeData2.ConstructorArguments[0].Value);
				}
				ModuleInfo moduleInfo = new ModuleInfo(name, type.AssemblyQualifiedName);
				moduleInfo.InitializationMode = (flag ? InitializationMode.OnDemand : InitializationMode.WhenAvailable);
				moduleInfo.Ref = type.Assembly.EscapedCodeBase;
				moduleInfo.DependsOn.AddRange(list);
				return moduleInfo;
			}
		}
	}
}
