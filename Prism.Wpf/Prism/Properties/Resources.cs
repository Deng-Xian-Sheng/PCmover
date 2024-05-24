using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Prism.Properties
{
	// Token: 0x02000044 RID: 68
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060001DA RID: 474 RVA: 0x0000238D File Offset: 0x0000058D
		internal Resources()
		{
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00005FAD File Offset: 0x000041AD
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("Prism.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00005FD9 File Offset: 0x000041D9
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00005FE0 File Offset: 0x000041E0
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

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00005FE8 File Offset: 0x000041E8
		internal static string AdapterInvalidTypeException
		{
			get
			{
				return Resources.ResourceManager.GetString("AdapterInvalidTypeException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00005FFE File Offset: 0x000041FE
		internal static string CannotChangeRegionNameException
		{
			get
			{
				return Resources.ResourceManager.GetString("CannotChangeRegionNameException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00006014 File Offset: 0x00004214
		internal static string CannotCreateNavigationTarget
		{
			get
			{
				return Resources.ResourceManager.GetString("CannotCreateNavigationTarget", Resources.resourceCulture);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000602A File Offset: 0x0000422A
		internal static string CanOnlyAddTypesThatInheritIFromRegionBehavior
		{
			get
			{
				return Resources.ResourceManager.GetString("CanOnlyAddTypesThatInheritIFromRegionBehavior", Resources.resourceCulture);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00006040 File Offset: 0x00004240
		internal static string ConfigurationStoreCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("ConfigurationStoreCannotBeNull", Resources.resourceCulture);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00006056 File Offset: 0x00004256
		internal static string ContentControlHasContentException
		{
			get
			{
				return Resources.ResourceManager.GetString("ContentControlHasContentException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000606C File Offset: 0x0000426C
		internal static string CyclicDependencyFound
		{
			get
			{
				return Resources.ResourceManager.GetString("CyclicDependencyFound", Resources.resourceCulture);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x00006082 File Offset: 0x00004282
		internal static string DeactiveNotPossibleException
		{
			get
			{
				return Resources.ResourceManager.GetString("DeactiveNotPossibleException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00006098 File Offset: 0x00004298
		internal static string DefaultTextLoggerPattern
		{
			get
			{
				return Resources.ResourceManager.GetString("DefaultTextLoggerPattern", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001E7 RID: 487 RVA: 0x000060AE File Offset: 0x000042AE
		internal static string DelegateCommandDelegatesCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("DelegateCommandDelegatesCannotBeNull", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x000060C4 File Offset: 0x000042C4
		internal static string DelegateCommandInvalidGenericPayloadType
		{
			get
			{
				return Resources.ResourceManager.GetString("DelegateCommandInvalidGenericPayloadType", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x000060DA File Offset: 0x000042DA
		internal static string DependencyForUnknownModule
		{
			get
			{
				return Resources.ResourceManager.GetString("DependencyForUnknownModule", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000060F0 File Offset: 0x000042F0
		internal static string DependencyOnMissingModule
		{
			get
			{
				return Resources.ResourceManager.GetString("DependencyOnMissingModule", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001EB RID: 491 RVA: 0x00006106 File Offset: 0x00004306
		internal static string DirectoryNotFound
		{
			get
			{
				return Resources.ResourceManager.GetString("DirectoryNotFound", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000611C File Offset: 0x0000431C
		internal static string DuplicatedModule
		{
			get
			{
				return Resources.ResourceManager.GetString("DuplicatedModule", Resources.resourceCulture);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001ED RID: 493 RVA: 0x00006132 File Offset: 0x00004332
		internal static string DuplicatedModuleGroup
		{
			get
			{
				return Resources.ResourceManager.GetString("DuplicatedModuleGroup", Resources.resourceCulture);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00006148 File Offset: 0x00004348
		internal static string FailedToGetType
		{
			get
			{
				return Resources.ResourceManager.GetString("FailedToGetType", Resources.resourceCulture);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000615E File Offset: 0x0000435E
		internal static string FailedToLoadModule
		{
			get
			{
				return Resources.ResourceManager.GetString("FailedToLoadModule", Resources.resourceCulture);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00006174 File Offset: 0x00004374
		internal static string FailedToLoadModuleNoAssemblyInfo
		{
			get
			{
				return Resources.ResourceManager.GetString("FailedToLoadModuleNoAssemblyInfo", Resources.resourceCulture);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000618A File Offset: 0x0000438A
		internal static string FailedToRetrieveModule
		{
			get
			{
				return Resources.ResourceManager.GetString("FailedToRetrieveModule", Resources.resourceCulture);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000061A0 File Offset: 0x000043A0
		internal static string HostControlCannotBeNull
		{
			get
			{
				return Resources.ResourceManager.GetString("HostControlCannotBeNull", Resources.resourceCulture);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x000061B6 File Offset: 0x000043B6
		internal static string HostControlCannotBeSetAfterAttach
		{
			get
			{
				return Resources.ResourceManager.GetString("HostControlCannotBeSetAfterAttach", Resources.resourceCulture);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000061CC File Offset: 0x000043CC
		internal static string HostControlMustBeATabControl
		{
			get
			{
				return Resources.ResourceManager.GetString("HostControlMustBeATabControl", Resources.resourceCulture);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x000061E2 File Offset: 0x000043E2
		internal static string IEnumeratorObsolete
		{
			get
			{
				return Resources.ResourceManager.GetString("IEnumeratorObsolete", Resources.resourceCulture);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000061F8 File Offset: 0x000043F8
		internal static string InvalidArgumentAssemblyUri
		{
			get
			{
				return Resources.ResourceManager.GetString("InvalidArgumentAssemblyUri", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0000620E File Offset: 0x0000440E
		internal static string InvalidDelegateRerefenceTypeException
		{
			get
			{
				return Resources.ResourceManager.GetString("InvalidDelegateRerefenceTypeException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00006224 File Offset: 0x00004424
		internal static string ItemsControlHasItemsSourceException
		{
			get
			{
				return Resources.ResourceManager.GetString("ItemsControlHasItemsSourceException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x0000623A File Offset: 0x0000443A
		internal static string MappingExistsException
		{
			get
			{
				return Resources.ResourceManager.GetString("MappingExistsException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00006250 File Offset: 0x00004450
		internal static string ModuleDependenciesNotMetInGroup
		{
			get
			{
				return Resources.ResourceManager.GetString("ModuleDependenciesNotMetInGroup", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00006266 File Offset: 0x00004466
		internal static string ModuleNotFound
		{
			get
			{
				return Resources.ResourceManager.GetString("ModuleNotFound", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000627C File Offset: 0x0000447C
		internal static string ModulePathCannotBeNullOrEmpty
		{
			get
			{
				return Resources.ResourceManager.GetString("ModulePathCannotBeNullOrEmpty", Resources.resourceCulture);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00006292 File Offset: 0x00004492
		internal static string ModuleTypeNotFound
		{
			get
			{
				return Resources.ResourceManager.GetString("ModuleTypeNotFound", Resources.resourceCulture);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001FE RID: 510 RVA: 0x000062A8 File Offset: 0x000044A8
		internal static string NavigationInProgress
		{
			get
			{
				return Resources.ResourceManager.GetString("NavigationInProgress", Resources.resourceCulture);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000062BE File Offset: 0x000044BE
		internal static string NavigationServiceHasNoRegion
		{
			get
			{
				return Resources.ResourceManager.GetString("NavigationServiceHasNoRegion", Resources.resourceCulture);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000200 RID: 512 RVA: 0x000062D4 File Offset: 0x000044D4
		internal static string NoRegionAdapterException
		{
			get
			{
				return Resources.ResourceManager.GetString("NoRegionAdapterException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000062EA File Offset: 0x000044EA
		internal static string NoRetrieverCanRetrieveModule
		{
			get
			{
				return Resources.ResourceManager.GetString("NoRetrieverCanRetrieveModule", Resources.resourceCulture);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000202 RID: 514 RVA: 0x00006300 File Offset: 0x00004500
		internal static string OnViewRegisteredException
		{
			get
			{
				return Resources.ResourceManager.GetString("OnViewRegisteredException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00006316 File Offset: 0x00004516
		internal static string PropertySupport_ExpressionNotProperty_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_ExpressionNotProperty_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000632C File Offset: 0x0000452C
		internal static string PropertySupport_NotMemberAccessExpression_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_NotMemberAccessExpression_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00006342 File Offset: 0x00004542
		internal static string PropertySupport_StaticExpression_Exception
		{
			get
			{
				return Resources.ResourceManager.GetString("PropertySupport_StaticExpression_Exception", Resources.resourceCulture);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00006358 File Offset: 0x00004558
		internal static string RegionBehaviorAttachCannotBeCallWithNullRegion
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionBehaviorAttachCannotBeCallWithNullRegion", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000636E File Offset: 0x0000456E
		internal static string RegionBehaviorRegionCannotBeSetAfterAttach
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionBehaviorRegionCannotBeSetAfterAttach", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00006384 File Offset: 0x00004584
		internal static string RegionCreationException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionCreationException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000639A File Offset: 0x0000459A
		internal static string RegionManagerWithDifferentNameException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionManagerWithDifferentNameException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000063B0 File Offset: 0x000045B0
		internal static string RegionNameCannotBeEmptyException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionNameCannotBeEmptyException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600020B RID: 523 RVA: 0x000063C6 File Offset: 0x000045C6
		internal static string RegionNameExistsException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionNameExistsException", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600020C RID: 524 RVA: 0x000063DC File Offset: 0x000045DC
		internal static string RegionNotFound
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionNotFound", Resources.resourceCulture);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600020D RID: 525 RVA: 0x000063F2 File Offset: 0x000045F2
		internal static string RegionNotInRegionManagerException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionNotInRegionManagerException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600020E RID: 526 RVA: 0x00006408 File Offset: 0x00004608
		internal static string RegionViewExistsException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionViewExistsException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000641E File Offset: 0x0000461E
		internal static string RegionViewNameExistsException
		{
			get
			{
				return Resources.ResourceManager.GetString("RegionViewNameExistsException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000210 RID: 528 RVA: 0x00006434 File Offset: 0x00004634
		internal static string StartupModuleDependsOnAnOnDemandModule
		{
			get
			{
				return Resources.ResourceManager.GetString("StartupModuleDependsOnAnOnDemandModule", Resources.resourceCulture);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000644A File Offset: 0x0000464A
		internal static string StringCannotBeNullOrEmpty
		{
			get
			{
				return Resources.ResourceManager.GetString("StringCannotBeNullOrEmpty", Resources.resourceCulture);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000212 RID: 530 RVA: 0x00006460 File Offset: 0x00004660
		internal static string StringCannotBeNullOrEmpty1
		{
			get
			{
				return Resources.ResourceManager.GetString("StringCannotBeNullOrEmpty1", Resources.resourceCulture);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000213 RID: 531 RVA: 0x00006476 File Offset: 0x00004676
		internal static string TypeWithKeyNotRegistered
		{
			get
			{
				return Resources.ResourceManager.GetString("TypeWithKeyNotRegistered", Resources.resourceCulture);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000214 RID: 532 RVA: 0x0000648C File Offset: 0x0000468C
		internal static string UpdateRegionException
		{
			get
			{
				return Resources.ResourceManager.GetString("UpdateRegionException", Resources.resourceCulture);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000064A2 File Offset: 0x000046A2
		internal static string ValueMustBeOfTypeModuleInfo
		{
			get
			{
				return Resources.ResourceManager.GetString("ValueMustBeOfTypeModuleInfo", Resources.resourceCulture);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000216 RID: 534 RVA: 0x000064B8 File Offset: 0x000046B8
		internal static string ValueNotFound
		{
			get
			{
				return Resources.ResourceManager.GetString("ValueNotFound", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000064CE File Offset: 0x000046CE
		internal static string ViewNotInRegionException
		{
			get
			{
				return Resources.ResourceManager.GetString("ViewNotInRegionException", Resources.resourceCulture);
			}
		}

		// Token: 0x04000060 RID: 96
		private static ResourceManager resourceMan;

		// Token: 0x04000061 RID: 97
		private static CultureInfo resourceCulture;
	}
}
