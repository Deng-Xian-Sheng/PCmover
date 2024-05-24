using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.WindowsAPICodePack.Shell.Resources
{
	// Token: 0x02000110 RID: 272
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	[DebuggerNonUserCode]
	internal class LocalizedMessages
	{
		// Token: 0x06000B88 RID: 2952 RVA: 0x0002CB1D File Offset: 0x0002AD1D
		internal LocalizedMessages()
		{
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06000B89 RID: 2953 RVA: 0x0002CB28 File Offset: 0x0002AD28
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(LocalizedMessages.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages", typeof(LocalizedMessages).Assembly);
					LocalizedMessages.resourceMan = resourceManager;
				}
				return LocalizedMessages.resourceMan;
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0002CB74 File Offset: 0x0002AD74
		// (set) Token: 0x06000B8B RID: 2955 RVA: 0x0002CB8B File Offset: 0x0002AD8B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return LocalizedMessages.resourceCulture;
			}
			set
			{
				LocalizedMessages.resourceCulture = value;
			}
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x0002CB94 File Offset: 0x0002AD94
		internal static string AddToMostRecentlyUsedListCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("AddToMostRecentlyUsedListCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x0002CBBC File Offset: 0x0002ADBC
		internal static string AlwaysAppendDefaultExtensionCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("AlwaysAppendDefaultExtensionCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x0002CBE4 File Offset: 0x0002ADE4
		internal static string ComboBoxIndexOutsideBounds
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ComboBoxIndexOutsideBounds", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x0002CC0C File Offset: 0x0002AE0C
		internal static string CommonFileDialogCanceled
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogCanceled", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x0002CC34 File Offset: 0x0002AE34
		internal static string CommonFileDialogCannotCreateShellItem
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogCannotCreateShellItem", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0002CC5C File Offset: 0x0002AE5C
		internal static string CommonFileDialogInvalidHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogInvalidHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0002CC84 File Offset: 0x0002AE84
		internal static string CommonFileDialogMultipleFiles
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogMultipleFiles", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x0002CCAC File Offset: 0x0002AEAC
		internal static string CommonFileDialogMultipleItems
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogMultipleItems", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x0002CCD4 File Offset: 0x0002AED4
		internal static string CommonFileDialogNotClosed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogNotClosed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x0002CCFC File Offset: 0x0002AEFC
		internal static string CommonFileDialogRequiresVista
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFileDialogRequiresVista", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x0002CD24 File Offset: 0x0002AF24
		internal static string CommonFiltersOffice
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFiltersOffice", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0002CD4C File Offset: 0x0002AF4C
		internal static string CommonFiltersPicture
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFiltersPicture", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0002CD74 File Offset: 0x0002AF74
		internal static string CommonFiltersText
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CommonFiltersText", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06000B99 RID: 2969 RVA: 0x0002CD9C File Offset: 0x0002AF9C
		internal static string CreatePromptCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CreatePromptCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x0002CDC4 File Offset: 0x0002AFC4
		internal static string DialogControlCollectionCannotRemoveControls
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionCannotRemoveControls", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0002CDEC File Offset: 0x0002AFEC
		internal static string DialogControlCollectionEmptyName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionEmptyName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x0002CE14 File Offset: 0x0002B014
		internal static string DialogControlCollectionMenuItemControlsCannotBeAdded
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionMenuItemControlsCannotBeAdded", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06000B9D RID: 2973 RVA: 0x0002CE3C File Offset: 0x0002B03C
		internal static string DialogControlCollectionModifyingControls
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionModifyingControls", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x0002CE64 File Offset: 0x0002B064
		internal static string DialogControlCollectionMoreThanOneControl
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionMoreThanOneControl", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06000B9F RID: 2975 RVA: 0x0002CE8C File Offset: 0x0002B08C
		internal static string DialogControlCollectionRemoveControlFirst
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlCollectionRemoveControlFirst", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x0002CEB4 File Offset: 0x0002B0B4
		internal static string EnsureFileExistsCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("EnsureFileExistsCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x0002CEDC File Offset: 0x0002B0DC
		internal static string EnsurePathExistsCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("EnsurePathExistsCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0002CF04 File Offset: 0x0002B104
		internal static string EnsureReadonlyCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("EnsureReadonlyCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0002CF2C File Offset: 0x0002B12C
		internal static string EnsureValidNamesCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("EnsureValidNamesCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x0002CF54 File Offset: 0x0002B154
		internal static string ExplorerBrowserBrowseToObjectFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserBrowseToObjectFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x0002CF7C File Offset: 0x0002B17C
		internal static string ExplorerBrowserFailedToGetView
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserFailedToGetView", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x0002CFA4 File Offset: 0x0002B1A4
		internal static string ExplorerBrowserIconSize
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserIconSize", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x0002CFCC File Offset: 0x0002B1CC
		internal static string ExplorerBrowserItemCount
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserItemCount", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x0002CFF4 File Offset: 0x0002B1F4
		internal static string ExplorerBrowserSelectedItemCount
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserSelectedItemCount", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x0002D01C File Offset: 0x0002B21C
		internal static string ExplorerBrowserUnexpectedError
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserUnexpectedError", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x0002D044 File Offset: 0x0002B244
		internal static string ExplorerBrowserViewItems
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExplorerBrowserViewItems", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06000BAB RID: 2987 RVA: 0x0002D06C File Offset: 0x0002B26C
		internal static string FilePathNotExist
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FilePathNotExist", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x06000BAC RID: 2988 RVA: 0x0002D094 File Offset: 0x0002B294
		internal static string FolderIdsUnknownGuid
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderIdsUnknownGuid", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		internal static string FolderTypeCategory
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeCategory", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06000BAE RID: 2990 RVA: 0x0002D0E4 File Offset: 0x0002B2E4
		internal static string FolderTypeClassic
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeClassic", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x0002D10C File Offset: 0x0002B30C
		internal static string FolderTypeCommunications
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeCommunications", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x06000BB0 RID: 2992 RVA: 0x0002D134 File Offset: 0x0002B334
		internal static string FolderTypeCompressedFolder
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeCompressedFolder", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x06000BB1 RID: 2993 RVA: 0x0002D15C File Offset: 0x0002B35C
		internal static string FolderTypeContacts
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeContacts", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x0002D184 File Offset: 0x0002B384
		internal static string FolderTypeDocuments
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeDocuments", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06000BB3 RID: 2995 RVA: 0x0002D1AC File Offset: 0x0002B3AC
		internal static string FolderTypeGames
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeGames", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x0002D1D4 File Offset: 0x0002B3D4
		internal static string FolderTypeGenericLibrary
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeGenericLibrary", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06000BB5 RID: 2997 RVA: 0x0002D1FC File Offset: 0x0002B3FC
		internal static string FolderTypeInvalid
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeInvalid", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x0002D224 File Offset: 0x0002B424
		internal static string FolderTypeLibrary
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeLibrary", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x06000BB7 RID: 2999 RVA: 0x0002D24C File Offset: 0x0002B44C
		internal static string FolderTypeMusic
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeMusic", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x0002D274 File Offset: 0x0002B474
		internal static string FolderTypeMusicIcons
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeMusicIcons", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x0002D29C File Offset: 0x0002B49C
		internal static string FolderTypeNetworkExplorer
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeNetworkExplorer", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06000BBA RID: 3002 RVA: 0x0002D2C4 File Offset: 0x0002B4C4
		internal static string FolderTypeNotSpecified
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeNotSpecified", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x0002D2EC File Offset: 0x0002B4EC
		internal static string FolderTypeOpenSearch
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeOpenSearch", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06000BBC RID: 3004 RVA: 0x0002D314 File Offset: 0x0002B514
		internal static string FolderTypeOtherUsers
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeOtherUsers", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06000BBD RID: 3005 RVA: 0x0002D33C File Offset: 0x0002B53C
		internal static string FolderTypePictures
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypePictures", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x0002D364 File Offset: 0x0002B564
		internal static string FolderTypePrinters
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypePrinters", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06000BBF RID: 3007 RVA: 0x0002D38C File Offset: 0x0002B58C
		internal static string FolderTypeRecordedTV
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeRecordedTV", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x0002D3B4 File Offset: 0x0002B5B4
		internal static string FolderTypeRecycleBin
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeRecycleBin", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x0002D3DC File Offset: 0x0002B5DC
		internal static string FolderTypeSavedGames
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeSavedGames", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0002D404 File Offset: 0x0002B604
		internal static string FolderTypeSearchConnector
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeSearchConnector", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x0002D42C File Offset: 0x0002B62C
		internal static string FolderTypeSearches
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeSearches", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0002D454 File Offset: 0x0002B654
		internal static string FolderTypeSearchResults
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeSearchResults", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x0002D47C File Offset: 0x0002B67C
		internal static string FolderTypeSoftwareExplorer
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeSoftwareExplorer", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x06000BC6 RID: 3014 RVA: 0x0002D4A4 File Offset: 0x0002B6A4
		internal static string FolderTypeUserFiles
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeUserFiles", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x06000BC7 RID: 3015 RVA: 0x0002D4CC File Offset: 0x0002B6CC
		internal static string FolderTypeUserLibraries
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeUserLibraries", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x0002D4F4 File Offset: 0x0002B6F4
		internal static string FolderTypeVideos
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("FolderTypeVideos", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06000BC9 RID: 3017 RVA: 0x0002D51C File Offset: 0x0002B71C
		internal static string IsExpandedModeCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("IsExpandedModeCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x0002D544 File Offset: 0x0002B744
		internal static string JumpListCustomCategoriesDisabled
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("JumpListCustomCategoriesDisabled", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06000BCB RID: 3019 RVA: 0x0002D56C File Offset: 0x0002B76C
		internal static string JumpListFileTypeNotRegistered
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("JumpListFileTypeNotRegistered", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x0002D594 File Offset: 0x0002B794
		internal static string JumpListLinkPathRequired
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("JumpListLinkPathRequired", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x06000BCD RID: 3021 RVA: 0x0002D5BC File Offset: 0x0002B7BC
		internal static string JumpListLinkTitleRequired
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("JumpListLinkTitleRequired", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x06000BCE RID: 3022 RVA: 0x0002D5E4 File Offset: 0x0002B7E4
		internal static string JumpListNegativeOrdinalPosition
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("JumpListNegativeOrdinalPosition", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0002D60C File Offset: 0x0002B80C
		internal static string KnownFolderInvalidGuid
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("KnownFolderInvalidGuid", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x0002D634 File Offset: 0x0002B834
		internal static string KnownFolderParsingName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("KnownFolderParsingName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06000BD1 RID: 3025 RVA: 0x0002D65C File Offset: 0x0002B85C
		internal static string MessageListenerCannotCreateWindow
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageListenerCannotCreateWindow", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0002D684 File Offset: 0x0002B884
		internal static string MessageListenerClassNotRegistered
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageListenerClassNotRegistered", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06000BD3 RID: 3027 RVA: 0x0002D6AC File Offset: 0x0002B8AC
		internal static string MessageListenerFilterUnableToRegister
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageListenerFilterUnableToRegister", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x0002D6D4 File Offset: 0x0002B8D4
		internal static string MessageListenerFilterUnknownListenerHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageListenerFilterUnknownListenerHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06000BD5 RID: 3029 RVA: 0x0002D6FC File Offset: 0x0002B8FC
		internal static string MessageListenerNoWindowHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageListenerNoWindowHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x06000BD6 RID: 3030 RVA: 0x0002D724 File Offset: 0x0002B924
		internal static string NavigateToShortcutCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NavigateToShortcutCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x0002D74C File Offset: 0x0002B94C
		internal static string NavigationLogNullParent
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NavigationLogNullParent", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06000BD8 RID: 3032 RVA: 0x0002D774 File Offset: 0x0002B974
		internal static string NotImplementedException
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NotImplementedException", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x0002D79C File Offset: 0x0002B99C
		internal static string OverwritePromptCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("OverwritePromptCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0002D7C4 File Offset: 0x0002B9C4
		internal static string PropertyCollectionCanonicalInvalidIndex
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropertyCollectionCanonicalInvalidIndex", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x0002D7EC File Offset: 0x0002B9EC
		internal static string PropertyCollectionInvalidIndex
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropertyCollectionInvalidIndex", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0002D814 File Offset: 0x0002BA14
		internal static string PropertyCollectionNullCanonicalName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropertyCollectionNullCanonicalName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x0002D83C File Offset: 0x0002BA3C
		internal static string RadioButtonListIndexOutOfBounds
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("RadioButtonListIndexOutOfBounds", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x0002D864 File Offset: 0x0002BA64
		internal static string RestoreDirectoryCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("RestoreDirectoryCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x0002D88C File Offset: 0x0002BA8C
		internal static string SaveFileNullItem
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("SaveFileNullItem", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06000BE0 RID: 3040 RVA: 0x0002D8B4 File Offset: 0x0002BAB4
		internal static string SearchConditionFactoryInvalidProperty
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("SearchConditionFactoryInvalidProperty", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x0002D8DC File Offset: 0x0002BADC
		internal static string ShellExceptionDefaultText
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellExceptionDefaultText", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x0002D904 File Offset: 0x0002BB04
		internal static string ShellHelperGetParsingNameFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellHelperGetParsingNameFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x0002D92C File Offset: 0x0002BB2C
		internal static string ShellInvalidCanonicalName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellInvalidCanonicalName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x0002D954 File Offset: 0x0002BB54
		internal static string ShellLibraryDefaultSaveFolderNotFound
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellLibraryDefaultSaveFolderNotFound", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06000BE5 RID: 3045 RVA: 0x0002D97C File Offset: 0x0002BB7C
		internal static string ShellLibraryEmptyName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellLibraryEmptyName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0002D9A4 File Offset: 0x0002BBA4
		internal static string ShellLibraryFolderNotFound
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellLibraryFolderNotFound", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x06000BE7 RID: 3047 RVA: 0x0002D9CC File Offset: 0x0002BBCC
		internal static string ShellLibraryInvalidFolderType
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellLibraryInvalidFolderType", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x0002D9F4 File Offset: 0x0002BBF4
		internal static string ShellLibraryInvalidLibrary
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellLibraryInvalidLibrary", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x0002DA1C File Offset: 0x0002BC1C
		internal static string ShellObjectCannotGetDisplayName
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCannotGetDisplayName", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x0002DA44 File Offset: 0x0002BC44
		internal static string ShellObjectCollectionArrayTooSmall
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCollectionArrayTooSmall", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x0002DA6C File Offset: 0x0002BC6C
		internal static string ShellObjectCollectionEmptyCollection
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCollectionEmptyCollection", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x0002DA94 File Offset: 0x0002BC94
		internal static string ShellObjectCollectionInsertReadOnly
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCollectionInsertReadOnly", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x0002DABC File Offset: 0x0002BCBC
		internal static string ShellObjectCollectionRemoveReadOnly
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCollectionRemoveReadOnly", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x0002DAE4 File Offset: 0x0002BCE4
		internal static string ShellObjectCreationFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectCreationFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06000BEF RID: 3055 RVA: 0x0002DB0C File Offset: 0x0002BD0C
		internal static string ShellObjectFactoryPlatformNotSupported
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectFactoryPlatformNotSupported", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0002DB34 File Offset: 0x0002BD34
		internal static string ShellObjectFactoryUnableToCreateItem
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectFactoryUnableToCreateItem", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x0002DB5C File Offset: 0x0002BD5C
		internal static string ShellObjectWatcherRegisterFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectWatcherRegisterFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0002DB84 File Offset: 0x0002BD84
		internal static string ShellObjectWatcherUnableToChangeEvents
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellObjectWatcherUnableToChangeEvents", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x0002DBAC File Offset: 0x0002BDAC
		internal static string ShellPropertyCannotSetProperty
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyCannotSetProperty", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0002DBD4 File Offset: 0x0002BDD4
		internal static string ShellPropertyFactoryConstructorNotFound
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyFactoryConstructorNotFound", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x0002DBFC File Offset: 0x0002BDFC
		internal static string ShellPropertySetValue
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertySetValue", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0002DC24 File Offset: 0x0002BE24
		internal static string ShellPropertyUnableToGetWritableProperty
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyUnableToGetWritableProperty", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x0002DC4C File Offset: 0x0002BE4C
		internal static string ShellPropertyValueTruncated
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyValueTruncated", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0002DC74 File Offset: 0x0002BE74
		internal static string ShellPropertyWindows7
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyWindows7", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x0002DC9C File Offset: 0x0002BE9C
		internal static string ShellPropertyWrongType
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellPropertyWrongType", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x0002DCC4 File Offset: 0x0002BEC4
		internal static string ShellSearchFolderUnableToSetSortColumns
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellSearchFolderUnableToSetSortColumns", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x0002DCEC File Offset: 0x0002BEEC
		internal static string ShellSearchFolderUnableToSetVisibleColumns
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellSearchFolderUnableToSetVisibleColumns", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x0002DD14 File Offset: 0x0002BF14
		internal static string ShellThumbnailCurrentSizeRange
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellThumbnailCurrentSizeRange", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x0002DD3C File Offset: 0x0002BF3C
		internal static string ShellThumbnailDoesNotHaveThumbnail
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellThumbnailDoesNotHaveThumbnail", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x0002DD64 File Offset: 0x0002BF64
		internal static string ShellThumbnailNoHandler
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellThumbnailNoHandler", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0002DD8C File Offset: 0x0002BF8C
		internal static string ShellThumbnailSizeCannotBe0
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShellThumbnailSizeCannotBe0", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x0002DDB4 File Offset: 0x0002BFB4
		internal static string ShowHiddenItemsCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShowHiddenItemsCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0002DDDC File Offset: 0x0002BFDC
		internal static string ShowPlacesListCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ShowPlacesListCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x0002DE04 File Offset: 0x0002C004
		internal static string StockIconInvalidGuid
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StockIconInvalidGuid", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x0002DE2C File Offset: 0x0002C02C
		internal static string TabbedThumbnailZeroChildHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TabbedThumbnailZeroChildHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x0002DE54 File Offset: 0x0002C054
		internal static string TabbedThumbnailZeroParentHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TabbedThumbnailZeroParentHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x0002DE7C File Offset: 0x0002C07C
		internal static string TasbarWindowProxyWindowSet
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TasbarWindowProxyWindowSet", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x0002DEA4 File Offset: 0x0002C0A4
		internal static string TaskbarManagerValidWindowRequired
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskbarManagerValidWindowRequired", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x0002DECC File Offset: 0x0002C0CC
		internal static string TaskbarWindowEmptyButtonArray
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskbarWindowEmptyButtonArray", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0002DEF4 File Offset: 0x0002C0F4
		internal static string TaskbarWindowManagerButtonsAlreadyAdded
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskbarWindowManagerButtonsAlreadyAdded", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x0002DF1C File Offset: 0x0002C11C
		internal static string TaskbarWindowValueSet
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskbarWindowValueSet", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x0002DF44 File Offset: 0x0002C144
		internal static string ThumbnailManagerControlNotAdded
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailManagerControlNotAdded", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0002DF6C File Offset: 0x0002C16C
		internal static string ThumbnailManagerInvalidHandle
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailManagerInvalidHandle", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06000C0C RID: 3084 RVA: 0x0002DF94 File Offset: 0x0002C194
		internal static string ThumbnailManagerPreviewAdded
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailManagerPreviewAdded", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x0002DFBC File Offset: 0x0002C1BC
		internal static string ThumbnailManagerPreviewNotAdded
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailManagerPreviewNotAdded", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0002DFE4 File Offset: 0x0002C1E4
		internal static string ThumbnailToolbarManagerMaxButtons
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailToolbarManagerMaxButtons", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x0002E00C File Offset: 0x0002C20C
		internal static string ThumbnailToolbarManagerNullEmptyArray
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ThumbnailToolbarManagerNullEmptyArray", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x0400043C RID: 1084
		private static ResourceManager resourceMan;

		// Token: 0x0400043D RID: 1085
		private static CultureInfo resourceCulture;
	}
}
