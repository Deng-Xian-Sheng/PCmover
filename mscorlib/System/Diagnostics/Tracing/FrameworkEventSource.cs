using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000433 RID: 1075
	[FriendAccessAllowed]
	[EventSource(Guid = "8E9F5090-2D75-4d03-8A81-E5AFBF85DAF1", Name = "System.Diagnostics.Eventing.FrameworkEventSource")]
	internal sealed class FrameworkEventSource : EventSource
	{
		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x0600358C RID: 13708 RVA: 0x000D10F6 File Offset: 0x000CF2F6
		public static bool IsInitialized
		{
			get
			{
				return FrameworkEventSource.Log != null;
			}
		}

		// Token: 0x0600358D RID: 13709 RVA: 0x000D1100 File Offset: 0x000CF300
		private FrameworkEventSource() : base(new Guid(2392805520U, 11637, 19715, 138, 129, 229, 175, 191, 133, 218, 241), "System.Diagnostics.Eventing.FrameworkEventSource")
		{
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x000D1154 File Offset: 0x000CF354
		[NonEvent]
		[SecuritySafeCritical]
		private unsafe void WriteEvent(int eventId, long arg1, int arg2, string arg3, bool arg4)
		{
			if (base.IsEnabled())
			{
				if (arg3 == null)
				{
					arg3 = "";
				}
				fixed (string text = arg3)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					EventSource.EventData* ptr2 = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)4) * (UIntPtr)sizeof(EventSource.EventData))];
					ptr2->DataPointer = (IntPtr)((void*)(&arg1));
					ptr2->Size = 8;
					ptr2[1].DataPointer = (IntPtr)((void*)(&arg2));
					ptr2[1].Size = 4;
					ptr2[2].DataPointer = (IntPtr)((void*)ptr);
					ptr2[2].Size = (arg3.Length + 1) * 2;
					ptr2[3].DataPointer = (IntPtr)((void*)(&arg4));
					ptr2[3].Size = 4;
					base.WriteEventCore(eventId, 4, ptr2);
				}
			}
		}

		// Token: 0x0600358F RID: 13711 RVA: 0x000D1234 File Offset: 0x000CF434
		[NonEvent]
		[SecuritySafeCritical]
		private unsafe void WriteEvent(int eventId, long arg1, int arg2, string arg3)
		{
			if (base.IsEnabled())
			{
				if (arg3 == null)
				{
					arg3 = "";
				}
				fixed (string text = arg3)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					EventSource.EventData* ptr2 = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(EventSource.EventData))];
					ptr2->DataPointer = (IntPtr)((void*)(&arg1));
					ptr2->Size = 8;
					ptr2[1].DataPointer = (IntPtr)((void*)(&arg2));
					ptr2[1].Size = 4;
					ptr2[2].DataPointer = (IntPtr)((void*)ptr);
					ptr2[2].Size = (arg3.Length + 1) * 2;
					base.WriteEventCore(eventId, 3, ptr2);
				}
			}
		}

		// Token: 0x06003590 RID: 13712 RVA: 0x000D12E8 File Offset: 0x000CF4E8
		[NonEvent]
		[SecuritySafeCritical]
		private unsafe void WriteEvent(int eventId, long arg1, string arg2, bool arg3, bool arg4)
		{
			if (base.IsEnabled())
			{
				if (arg2 == null)
				{
					arg2 = "";
				}
				fixed (string text = arg2)
				{
					char* ptr = text;
					if (ptr != null)
					{
						ptr += RuntimeHelpers.OffsetToStringData / 2;
					}
					EventSource.EventData* ptr2 = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)4) * (UIntPtr)sizeof(EventSource.EventData))];
					ptr2->DataPointer = (IntPtr)((void*)(&arg1));
					ptr2->Size = 8;
					ptr2[1].DataPointer = (IntPtr)((void*)ptr);
					ptr2[1].Size = (arg2.Length + 1) * 2;
					ptr2[2].DataPointer = (IntPtr)((void*)(&arg3));
					ptr2[2].Size = 4;
					ptr2[3].DataPointer = (IntPtr)((void*)(&arg4));
					ptr2[3].Size = 4;
					base.WriteEventCore(eventId, 4, ptr2);
				}
			}
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x000D13C4 File Offset: 0x000CF5C4
		[NonEvent]
		[SecuritySafeCritical]
		private unsafe void WriteEvent(int eventId, long arg1, bool arg2, bool arg3)
		{
			if (base.IsEnabled())
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)3) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->DataPointer = (IntPtr)((void*)(&arg1));
				ptr->Size = 8;
				ptr[1].DataPointer = (IntPtr)((void*)(&arg2));
				ptr[1].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&arg3));
				ptr[2].Size = 4;
				base.WriteEventCore(eventId, 3, ptr);
			}
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x000D1450 File Offset: 0x000CF650
		[NonEvent]
		[SecuritySafeCritical]
		private unsafe void WriteEvent(int eventId, long arg1, bool arg2, bool arg3, int arg4)
		{
			if (base.IsEnabled())
			{
				EventSource.EventData* ptr = stackalloc EventSource.EventData[checked(unchecked((UIntPtr)4) * (UIntPtr)sizeof(EventSource.EventData))];
				ptr->DataPointer = (IntPtr)((void*)(&arg1));
				ptr->Size = 8;
				ptr[1].DataPointer = (IntPtr)((void*)(&arg2));
				ptr[1].Size = 4;
				ptr[2].DataPointer = (IntPtr)((void*)(&arg3));
				ptr[2].Size = 4;
				ptr[3].DataPointer = (IntPtr)((void*)(&arg4));
				ptr[3].Size = 4;
				base.WriteEventCore(eventId, 4, ptr);
			}
		}

		// Token: 0x06003593 RID: 13715 RVA: 0x000D1507 File Offset: 0x000CF707
		[Event(1, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerLookupStarted(string baseName, string mainAssemblyName, string cultureName)
		{
			base.WriteEvent(1, baseName, mainAssemblyName, cultureName);
		}

		// Token: 0x06003594 RID: 13716 RVA: 0x000D1513 File Offset: 0x000CF713
		[Event(2, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerLookingForResourceSet(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(2, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x06003595 RID: 13717 RVA: 0x000D1527 File Offset: 0x000CF727
		[Event(3, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerFoundResourceSetInCache(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(3, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x06003596 RID: 13718 RVA: 0x000D153B File Offset: 0x000CF73B
		[Event(4, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerFoundResourceSetInCacheUnexpected(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(4, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x06003597 RID: 13719 RVA: 0x000D154F File Offset: 0x000CF74F
		[Event(5, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerStreamFound(string baseName, string mainAssemblyName, string cultureName, string loadedAssemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(5, new object[]
				{
					baseName,
					mainAssemblyName,
					cultureName,
					loadedAssemblyName,
					resourceFileName
				});
			}
		}

		// Token: 0x06003598 RID: 13720 RVA: 0x000D157C File Offset: 0x000CF77C
		[Event(6, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerStreamNotFound(string baseName, string mainAssemblyName, string cultureName, string loadedAssemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(6, new object[]
				{
					baseName,
					mainAssemblyName,
					cultureName,
					loadedAssemblyName,
					resourceFileName
				});
			}
		}

		// Token: 0x06003599 RID: 13721 RVA: 0x000D15A9 File Offset: 0x000CF7A9
		[Event(7, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerGetSatelliteAssemblySucceeded(string baseName, string mainAssemblyName, string cultureName, string assemblyName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(7, new object[]
				{
					baseName,
					mainAssemblyName,
					cultureName,
					assemblyName
				});
			}
		}

		// Token: 0x0600359A RID: 13722 RVA: 0x000D15D1 File Offset: 0x000CF7D1
		[Event(8, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerGetSatelliteAssemblyFailed(string baseName, string mainAssemblyName, string cultureName, string assemblyName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(8, new object[]
				{
					baseName,
					mainAssemblyName,
					cultureName,
					assemblyName
				});
			}
		}

		// Token: 0x0600359B RID: 13723 RVA: 0x000D15F9 File Offset: 0x000CF7F9
		[Event(9, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded(string baseName, string mainAssemblyName, string assemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(9, new object[]
				{
					baseName,
					mainAssemblyName,
					assemblyName,
					resourceFileName
				});
			}
		}

		// Token: 0x0600359C RID: 13724 RVA: 0x000D1622 File Offset: 0x000CF822
		[Event(10, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerCaseInsensitiveResourceStreamLookupFailed(string baseName, string mainAssemblyName, string assemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(10, new object[]
				{
					baseName,
					mainAssemblyName,
					assemblyName,
					resourceFileName
				});
			}
		}

		// Token: 0x0600359D RID: 13725 RVA: 0x000D164B File Offset: 0x000CF84B
		[Event(11, Level = EventLevel.Error, Keywords = (EventKeywords)1L)]
		public void ResourceManagerManifestResourceAccessDenied(string baseName, string mainAssemblyName, string assemblyName, string canonicalName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(11, new object[]
				{
					baseName,
					mainAssemblyName,
					assemblyName,
					canonicalName
				});
			}
		}

		// Token: 0x0600359E RID: 13726 RVA: 0x000D1674 File Offset: 0x000CF874
		[Event(12, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerNeutralResourcesSufficient(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(12, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x0600359F RID: 13727 RVA: 0x000D1689 File Offset: 0x000CF889
		[Event(13, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerNeutralResourceAttributeMissing(string mainAssemblyName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(13, mainAssemblyName);
			}
		}

		// Token: 0x060035A0 RID: 13728 RVA: 0x000D169C File Offset: 0x000CF89C
		[Event(14, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerCreatingResourceSet(string baseName, string mainAssemblyName, string cultureName, string fileName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(14, new object[]
				{
					baseName,
					mainAssemblyName,
					cultureName,
					fileName
				});
			}
		}

		// Token: 0x060035A1 RID: 13729 RVA: 0x000D16C5 File Offset: 0x000CF8C5
		[Event(15, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerNotCreatingResourceSet(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(15, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x060035A2 RID: 13730 RVA: 0x000D16DA File Offset: 0x000CF8DA
		[Event(16, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerLookupFailed(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(16, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x060035A3 RID: 13731 RVA: 0x000D16EF File Offset: 0x000CF8EF
		[Event(17, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerReleasingResources(string baseName, string mainAssemblyName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(17, baseName, mainAssemblyName);
			}
		}

		// Token: 0x060035A4 RID: 13732 RVA: 0x000D1703 File Offset: 0x000CF903
		[Event(18, Level = EventLevel.Warning, Keywords = (EventKeywords)1L)]
		public void ResourceManagerNeutralResourcesNotFound(string baseName, string mainAssemblyName, string resName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(18, baseName, mainAssemblyName, resName);
			}
		}

		// Token: 0x060035A5 RID: 13733 RVA: 0x000D1718 File Offset: 0x000CF918
		[Event(19, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerNeutralResourcesFound(string baseName, string mainAssemblyName, string resName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(19, baseName, mainAssemblyName, resName);
			}
		}

		// Token: 0x060035A6 RID: 13734 RVA: 0x000D172D File Offset: 0x000CF92D
		[Event(20, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerAddingCultureFromConfigFile(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(20, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x060035A7 RID: 13735 RVA: 0x000D1742 File Offset: 0x000CF942
		[Event(21, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerCultureNotFoundInConfigFile(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(21, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x060035A8 RID: 13736 RVA: 0x000D1757 File Offset: 0x000CF957
		[Event(22, Level = EventLevel.Informational, Keywords = (EventKeywords)1L)]
		public void ResourceManagerCultureFoundInConfigFile(string baseName, string mainAssemblyName, string cultureName)
		{
			if (base.IsEnabled())
			{
				base.WriteEvent(22, baseName, mainAssemblyName, cultureName);
			}
		}

		// Token: 0x060035A9 RID: 13737 RVA: 0x000D176C File Offset: 0x000CF96C
		[NonEvent]
		public void ResourceManagerLookupStarted(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerLookupStarted(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035AA RID: 13738 RVA: 0x000D1784 File Offset: 0x000CF984
		[NonEvent]
		public void ResourceManagerLookingForResourceSet(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerLookingForResourceSet(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x000D179C File Offset: 0x000CF99C
		[NonEvent]
		public void ResourceManagerFoundResourceSetInCache(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerFoundResourceSetInCache(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035AC RID: 13740 RVA: 0x000D17B4 File Offset: 0x000CF9B4
		[NonEvent]
		public void ResourceManagerFoundResourceSetInCacheUnexpected(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerFoundResourceSetInCacheUnexpected(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035AD RID: 13741 RVA: 0x000D17CC File Offset: 0x000CF9CC
		[NonEvent]
		public void ResourceManagerStreamFound(string baseName, Assembly mainAssembly, string cultureName, Assembly loadedAssembly, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerStreamFound(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName, FrameworkEventSource.GetName(loadedAssembly), resourceFileName);
			}
		}

		// Token: 0x060035AE RID: 13742 RVA: 0x000D17ED File Offset: 0x000CF9ED
		[NonEvent]
		public void ResourceManagerStreamNotFound(string baseName, Assembly mainAssembly, string cultureName, Assembly loadedAssembly, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerStreamNotFound(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName, FrameworkEventSource.GetName(loadedAssembly), resourceFileName);
			}
		}

		// Token: 0x060035AF RID: 13743 RVA: 0x000D180E File Offset: 0x000CFA0E
		[NonEvent]
		public void ResourceManagerGetSatelliteAssemblySucceeded(string baseName, Assembly mainAssembly, string cultureName, string assemblyName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerGetSatelliteAssemblySucceeded(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName, assemblyName);
			}
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x000D1828 File Offset: 0x000CFA28
		[NonEvent]
		public void ResourceManagerGetSatelliteAssemblyFailed(string baseName, Assembly mainAssembly, string cultureName, string assemblyName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerGetSatelliteAssemblyFailed(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName, assemblyName);
			}
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x000D1842 File Offset: 0x000CFA42
		[NonEvent]
		public void ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded(string baseName, Assembly mainAssembly, string assemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerCaseInsensitiveResourceStreamLookupSucceeded(baseName, FrameworkEventSource.GetName(mainAssembly), assemblyName, resourceFileName);
			}
		}

		// Token: 0x060035B2 RID: 13746 RVA: 0x000D185C File Offset: 0x000CFA5C
		[NonEvent]
		public void ResourceManagerCaseInsensitiveResourceStreamLookupFailed(string baseName, Assembly mainAssembly, string assemblyName, string resourceFileName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerCaseInsensitiveResourceStreamLookupFailed(baseName, FrameworkEventSource.GetName(mainAssembly), assemblyName, resourceFileName);
			}
		}

		// Token: 0x060035B3 RID: 13747 RVA: 0x000D1876 File Offset: 0x000CFA76
		[NonEvent]
		public void ResourceManagerManifestResourceAccessDenied(string baseName, Assembly mainAssembly, string assemblyName, string canonicalName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerManifestResourceAccessDenied(baseName, FrameworkEventSource.GetName(mainAssembly), assemblyName, canonicalName);
			}
		}

		// Token: 0x060035B4 RID: 13748 RVA: 0x000D1890 File Offset: 0x000CFA90
		[NonEvent]
		public void ResourceManagerNeutralResourcesSufficient(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerNeutralResourcesSufficient(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035B5 RID: 13749 RVA: 0x000D18A8 File Offset: 0x000CFAA8
		[NonEvent]
		public void ResourceManagerNeutralResourceAttributeMissing(Assembly mainAssembly)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerNeutralResourceAttributeMissing(FrameworkEventSource.GetName(mainAssembly));
			}
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x000D18BE File Offset: 0x000CFABE
		[NonEvent]
		public void ResourceManagerCreatingResourceSet(string baseName, Assembly mainAssembly, string cultureName, string fileName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerCreatingResourceSet(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName, fileName);
			}
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x000D18D8 File Offset: 0x000CFAD8
		[NonEvent]
		public void ResourceManagerNotCreatingResourceSet(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerNotCreatingResourceSet(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035B8 RID: 13752 RVA: 0x000D18F0 File Offset: 0x000CFAF0
		[NonEvent]
		public void ResourceManagerLookupFailed(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerLookupFailed(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035B9 RID: 13753 RVA: 0x000D1908 File Offset: 0x000CFB08
		[NonEvent]
		public void ResourceManagerReleasingResources(string baseName, Assembly mainAssembly)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerReleasingResources(baseName, FrameworkEventSource.GetName(mainAssembly));
			}
		}

		// Token: 0x060035BA RID: 13754 RVA: 0x000D191F File Offset: 0x000CFB1F
		[NonEvent]
		public void ResourceManagerNeutralResourcesNotFound(string baseName, Assembly mainAssembly, string resName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerNeutralResourcesNotFound(baseName, FrameworkEventSource.GetName(mainAssembly), resName);
			}
		}

		// Token: 0x060035BB RID: 13755 RVA: 0x000D1937 File Offset: 0x000CFB37
		[NonEvent]
		public void ResourceManagerNeutralResourcesFound(string baseName, Assembly mainAssembly, string resName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerNeutralResourcesFound(baseName, FrameworkEventSource.GetName(mainAssembly), resName);
			}
		}

		// Token: 0x060035BC RID: 13756 RVA: 0x000D194F File Offset: 0x000CFB4F
		[NonEvent]
		public void ResourceManagerAddingCultureFromConfigFile(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerAddingCultureFromConfigFile(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x000D1967 File Offset: 0x000CFB67
		[NonEvent]
		public void ResourceManagerCultureNotFoundInConfigFile(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerCultureNotFoundInConfigFile(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035BE RID: 13758 RVA: 0x000D197F File Offset: 0x000CFB7F
		[NonEvent]
		public void ResourceManagerCultureFoundInConfigFile(string baseName, Assembly mainAssembly, string cultureName)
		{
			if (base.IsEnabled())
			{
				this.ResourceManagerCultureFoundInConfigFile(baseName, FrameworkEventSource.GetName(mainAssembly), cultureName);
			}
		}

		// Token: 0x060035BF RID: 13759 RVA: 0x000D1997 File Offset: 0x000CFB97
		private static string GetName(Assembly assembly)
		{
			if (assembly == null)
			{
				return "<<NULL>>";
			}
			return assembly.FullName;
		}

		// Token: 0x060035C0 RID: 13760 RVA: 0x000D19AE File Offset: 0x000CFBAE
		[Event(30, Level = EventLevel.Verbose, Keywords = (EventKeywords)18L)]
		public void ThreadPoolEnqueueWork(long workID)
		{
			base.WriteEvent(30, workID);
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x000D19B9 File Offset: 0x000CFBB9
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void ThreadPoolEnqueueWorkObject(object workID)
		{
			this.ThreadPoolEnqueueWork((long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref workID)))));
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x000D19CF File Offset: 0x000CFBCF
		[Event(31, Level = EventLevel.Verbose, Keywords = (EventKeywords)18L)]
		public void ThreadPoolDequeueWork(long workID)
		{
			base.WriteEvent(31, workID);
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x000D19DA File Offset: 0x000CFBDA
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void ThreadPoolDequeueWorkObject(object workID)
		{
			this.ThreadPoolDequeueWork((long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref workID)))));
		}

		// Token: 0x060035C4 RID: 13764 RVA: 0x000D19F0 File Offset: 0x000CFBF0
		[Event(140, Level = EventLevel.Informational, Keywords = (EventKeywords)4L, ActivityOptions = EventActivityOptions.Disable, Task = (EventTask)1, Opcode = EventOpcode.Start, Version = 1)]
		private void GetResponseStart(long id, string uri, bool success, bool synchronous)
		{
			this.WriteEvent(140, id, uri, success, synchronous);
		}

		// Token: 0x060035C5 RID: 13765 RVA: 0x000D1A02 File Offset: 0x000CFC02
		[Event(141, Level = EventLevel.Informational, Keywords = (EventKeywords)4L, ActivityOptions = EventActivityOptions.Disable, Task = (EventTask)1, Opcode = EventOpcode.Stop, Version = 1)]
		private void GetResponseStop(long id, bool success, bool synchronous, int statusCode)
		{
			this.WriteEvent(141, id, success, synchronous, statusCode);
		}

		// Token: 0x060035C6 RID: 13766 RVA: 0x000D1A14 File Offset: 0x000CFC14
		[Event(142, Level = EventLevel.Informational, Keywords = (EventKeywords)4L, ActivityOptions = EventActivityOptions.Disable, Task = (EventTask)2, Opcode = EventOpcode.Start, Version = 1)]
		private void GetRequestStreamStart(long id, string uri, bool success, bool synchronous)
		{
			this.WriteEvent(142, id, uri, success, synchronous);
		}

		// Token: 0x060035C7 RID: 13767 RVA: 0x000D1A26 File Offset: 0x000CFC26
		[Event(143, Level = EventLevel.Informational, Keywords = (EventKeywords)4L, ActivityOptions = EventActivityOptions.Disable, Task = (EventTask)2, Opcode = EventOpcode.Stop, Version = 1)]
		private void GetRequestStreamStop(long id, bool success, bool synchronous)
		{
			this.WriteEvent(143, id, success, synchronous);
		}

		// Token: 0x060035C8 RID: 13768 RVA: 0x000D1A36 File Offset: 0x000CFC36
		[NonEvent]
		[SecuritySafeCritical]
		public void BeginGetResponse(object id, string uri, bool success, bool synchronous)
		{
			if (base.IsEnabled())
			{
				this.GetResponseStart(FrameworkEventSource.IdForObject(id), uri, success, synchronous);
			}
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x000D1A50 File Offset: 0x000CFC50
		[NonEvent]
		[SecuritySafeCritical]
		public void EndGetResponse(object id, bool success, bool synchronous, int statusCode)
		{
			if (base.IsEnabled())
			{
				this.GetResponseStop(FrameworkEventSource.IdForObject(id), success, synchronous, statusCode);
			}
		}

		// Token: 0x060035CA RID: 13770 RVA: 0x000D1A6A File Offset: 0x000CFC6A
		[NonEvent]
		[SecuritySafeCritical]
		public void BeginGetRequestStream(object id, string uri, bool success, bool synchronous)
		{
			if (base.IsEnabled())
			{
				this.GetRequestStreamStart(FrameworkEventSource.IdForObject(id), uri, success, synchronous);
			}
		}

		// Token: 0x060035CB RID: 13771 RVA: 0x000D1A84 File Offset: 0x000CFC84
		[NonEvent]
		[SecuritySafeCritical]
		public void EndGetRequestStream(object id, bool success, bool synchronous)
		{
			if (base.IsEnabled())
			{
				this.GetRequestStreamStop(FrameworkEventSource.IdForObject(id), success, synchronous);
			}
		}

		// Token: 0x060035CC RID: 13772 RVA: 0x000D1A9C File Offset: 0x000CFC9C
		[Event(150, Level = EventLevel.Informational, Keywords = (EventKeywords)16L, Task = (EventTask)3, Opcode = EventOpcode.Send)]
		public void ThreadTransferSend(long id, int kind, string info, bool multiDequeues)
		{
			if (base.IsEnabled())
			{
				this.WriteEvent(150, id, kind, info, multiDequeues);
			}
		}

		// Token: 0x060035CD RID: 13773 RVA: 0x000D1AB6 File Offset: 0x000CFCB6
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void ThreadTransferSendObj(object id, int kind, string info, bool multiDequeues)
		{
			this.ThreadTransferSend((long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref id)))), kind, info, multiDequeues);
		}

		// Token: 0x060035CE RID: 13774 RVA: 0x000D1AD0 File Offset: 0x000CFCD0
		[Event(151, Level = EventLevel.Informational, Keywords = (EventKeywords)16L, Task = (EventTask)3, Opcode = EventOpcode.Receive)]
		public void ThreadTransferReceive(long id, int kind, string info)
		{
			if (base.IsEnabled())
			{
				this.WriteEvent(151, id, kind, info);
			}
		}

		// Token: 0x060035CF RID: 13775 RVA: 0x000D1AE8 File Offset: 0x000CFCE8
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void ThreadTransferReceiveObj(object id, int kind, string info)
		{
			this.ThreadTransferReceive((long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref id)))), kind, info);
		}

		// Token: 0x060035D0 RID: 13776 RVA: 0x000D1B00 File Offset: 0x000CFD00
		[Event(152, Level = EventLevel.Informational, Keywords = (EventKeywords)16L, Task = (EventTask)3, Opcode = (EventOpcode)11)]
		public void ThreadTransferReceiveHandled(long id, int kind, string info)
		{
			if (base.IsEnabled())
			{
				this.WriteEvent(152, id, kind, info);
			}
		}

		// Token: 0x060035D1 RID: 13777 RVA: 0x000D1B18 File Offset: 0x000CFD18
		[NonEvent]
		[SecuritySafeCritical]
		public unsafe void ThreadTransferReceiveHandledObj(object id, int kind, string info)
		{
			this.ThreadTransferReceive((long)((ulong)(*(IntPtr*)((void*)JitHelpers.UnsafeCastToStackPointer<object>(ref id)))), kind, info);
		}

		// Token: 0x060035D2 RID: 13778 RVA: 0x000D1B30 File Offset: 0x000CFD30
		private static long IdForObject(object obj)
		{
			return (long)obj.GetHashCode() + 9223372032559808512L;
		}

		// Token: 0x040017DF RID: 6111
		public static readonly FrameworkEventSource Log = new FrameworkEventSource();

		// Token: 0x02000B95 RID: 2965
		public static class Keywords
		{
			// Token: 0x0400351D RID: 13597
			public const EventKeywords Loader = (EventKeywords)1L;

			// Token: 0x0400351E RID: 13598
			public const EventKeywords ThreadPool = (EventKeywords)2L;

			// Token: 0x0400351F RID: 13599
			public const EventKeywords NetClient = (EventKeywords)4L;

			// Token: 0x04003520 RID: 13600
			public const EventKeywords DynamicTypeUsage = (EventKeywords)8L;

			// Token: 0x04003521 RID: 13601
			public const EventKeywords ThreadTransfer = (EventKeywords)16L;
		}

		// Token: 0x02000B96 RID: 2966
		[FriendAccessAllowed]
		public static class Tasks
		{
			// Token: 0x04003522 RID: 13602
			public const EventTask GetResponse = (EventTask)1;

			// Token: 0x04003523 RID: 13603
			public const EventTask GetRequestStream = (EventTask)2;

			// Token: 0x04003524 RID: 13604
			public const EventTask ThreadTransfer = (EventTask)3;
		}

		// Token: 0x02000B97 RID: 2967
		[FriendAccessAllowed]
		public static class Opcodes
		{
			// Token: 0x04003525 RID: 13605
			public const EventOpcode ReceiveHandled = (EventOpcode)11;
		}
	}
}
