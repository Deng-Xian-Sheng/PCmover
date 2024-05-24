using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Prism.Unity.Properties
{
	// Token: 0x02000008 RID: 8
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002754 File Offset: 0x00000954
		internal Resources()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000275C File Offset: 0x0000095C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Prism.Unity.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002788 File Offset: 0x00000988
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000278F File Offset: 0x0000098F
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002797 File Offset: 0x00000997
		internal static string AddingUnityBootstrapperExtensionToContainer
		{
			get
			{
				return Resources.ResourceManager.GetString("AddingUnityBootstrapperExtensionToContainer", Resources.resourceCulture);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000027AD File Offset: 0x000009AD
		internal static string BootstrapperSequenceCompleted
		{
			get
			{
				return Resources.ResourceManager.GetString("BootstrapperSequenceCompleted", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000027C3 File Offset: 0x000009C3
		internal static string ConfiguringDefaultRegionBehaviors
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringDefaultRegionBehaviors", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000027D9 File Offset: 0x000009D9
		internal static string ConfiguringModuleCatalog
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringModuleCatalog", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000027EF File Offset: 0x000009EF
		internal static string ConfiguringRegionAdapters
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringRegionAdapters", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002805 File Offset: 0x00000A05
		internal static string ConfiguringServiceLocatorSingleton
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringServiceLocatorSingleton", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000281B File Offset: 0x00000A1B
		internal static string ConfiguringUnityContainer
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringUnityContainer", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002831 File Offset: 0x00000A31
		internal static string ConfiguringViewModelLocator
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfiguringViewModelLocator", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002847 File Offset: 0x00000A47
		internal static string CreatingModuleCatalog
		{
			get
			{
				return Resources.ResourceManager.GetString("CreatingModuleCatalog", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000285D File Offset: 0x00000A5D
		internal static string CreatingShell
		{
			get
			{
				return Resources.ResourceManager.GetString("CreatingShell", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002873 File Offset: 0x00000A73
		internal static string CreatingUnityContainer
		{
			get
			{
				return Resources.ResourceManager.GetString("CreatingUnityContainer", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002889 File Offset: 0x00000A89
		internal static string InitializingModules
		{
			get
			{
				return Resources.ResourceManager.GetString("InitializingModules", Resources.resourceCulture);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000028 RID: 40 RVA: 0x0000289F File Offset: 0x00000A9F
		internal static string InitializingShell
		{
			get
			{
				return Resources.ResourceManager.GetString("InitializingShell", Resources.resourceCulture);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000028B5 File Offset: 0x00000AB5
		internal static string LoggerCreatedSuccessfully
		{
			get
			{
				return Resources.ResourceManager.GetString("LoggerCreatedSuccessfully", Resources.resourceCulture);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000028CB File Offset: 0x00000ACB
		internal static string NotOverwrittenGetModuleEnumeratorException
		{
			get
			{
				return Resources.ResourceManager.GetString("NotOverwrittenGetModuleEnumeratorException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000028E1 File Offset: 0x00000AE1
		internal static string NullLoggerFacadeException
		{
			get
			{
				return Resources.ResourceManager.GetString("NullLoggerFacadeException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000028F7 File Offset: 0x00000AF7
		internal static string NullModuleCatalogException
		{
			get
			{
				return Resources.ResourceManager.GetString("NullModuleCatalogException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000290D File Offset: 0x00000B0D
		internal static string NullUnityContainerException
		{
			get
			{
				return Resources.ResourceManager.GetString("NullUnityContainerException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002923 File Offset: 0x00000B23
		internal static string RegisteringFrameworkExceptionTypes
		{
			get
			{
				return Resources.ResourceManager.GetString("RegisteringFrameworkExceptionTypes", Resources.resourceCulture);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002939 File Offset: 0x00000B39
		internal static string SettingTheRegionManager
		{
			get
			{
				return Resources.ResourceManager.GetString("SettingTheRegionManager", Resources.resourceCulture);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000294F File Offset: 0x00000B4F
		internal static string TypeMappingAlreadyRegistered
		{
			get
			{
				return Resources.ResourceManager.GetString("TypeMappingAlreadyRegistered", Resources.resourceCulture);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002965 File Offset: 0x00000B65
		internal static string UpdatingRegions
		{
			get
			{
				return Resources.ResourceManager.GetString("UpdatingRegions", Resources.resourceCulture);
			}
		}

		// Token: 0x04000005 RID: 5
		private static ResourceManager resourceMan;

		// Token: 0x04000006 RID: 6
		private static CultureInfo resourceCulture;
	}
}
