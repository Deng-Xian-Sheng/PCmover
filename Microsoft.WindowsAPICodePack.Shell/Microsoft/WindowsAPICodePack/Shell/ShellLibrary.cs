using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000075 RID: 117
	public sealed class ShellLibrary : ShellContainer, IList<ShellFileSystemFolder>, ICollection<ShellFileSystemFolder>, IEnumerable<ShellFileSystemFolder>, IEnumerable
	{
		// Token: 0x06000391 RID: 913 RVA: 0x0000E08F File Offset: 0x0000C28F
		private ShellLibrary()
		{
			CoreHelpers.ThrowIfNotWin7();
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000E0A0 File Offset: 0x0000C2A0
		private ShellLibrary(INativeShellLibrary nativeShellLibrary) : this()
		{
			this.nativeShellLibrary = nativeShellLibrary;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000E0B4 File Offset: 0x0000C2B4
		private ShellLibrary(IKnownFolder sourceKnownFolder, bool isReadOnly) : this()
		{
			Debug.Assert(sourceKnownFolder != null);
			this.knownFolder = sourceKnownFolder;
			this.nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			AccessModes grfMode = isReadOnly ? AccessModes.Direct : AccessModes.ReadWrite;
			this.nativeShellItem = ((ShellObject)sourceKnownFolder).NativeShellItem2;
			Guid folderId = sourceKnownFolder.FolderId;
			try
			{
				this.nativeShellLibrary.LoadLibraryFromKnownFolder(ref folderId, grfMode);
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(LocalizedMessages.ShellLibraryInvalidLibrary, "sourceKnownFolder");
			}
			catch (NotImplementedException)
			{
				throw new ArgumentException(LocalizedMessages.ShellLibraryInvalidLibrary, "sourceKnownFolder");
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000E164 File Offset: 0x0000C364
		public ShellLibrary(string libraryName, bool overwrite) : this()
		{
			if (string.IsNullOrEmpty(libraryName))
			{
				throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, "libraryName");
			}
			this.Name = libraryName;
			Guid guid = new Guid("1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE");
			ShellNativeMethods.LibrarySaveOptions lsf = overwrite ? ShellNativeMethods.LibrarySaveOptions.OverrideExisting : ShellNativeMethods.LibrarySaveOptions.FailIfThere;
			this.nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			this.nativeShellLibrary.SaveInKnownFolder(ref guid, libraryName, lsf, out this.nativeShellItem);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000E1E0 File Offset: 0x0000C3E0
		public ShellLibrary(string libraryName, IKnownFolder sourceKnownFolder, bool overwrite) : this()
		{
			if (string.IsNullOrEmpty(libraryName))
			{
				throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, "libraryName");
			}
			this.knownFolder = sourceKnownFolder;
			this.Name = libraryName;
			Guid folderId = this.knownFolder.FolderId;
			ShellNativeMethods.LibrarySaveOptions lsf = overwrite ? ShellNativeMethods.LibrarySaveOptions.OverrideExisting : ShellNativeMethods.LibrarySaveOptions.FailIfThere;
			this.nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			this.nativeShellLibrary.SaveInKnownFolder(ref folderId, libraryName, lsf, out this.nativeShellItem);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000E260 File Offset: 0x0000C460
		public ShellLibrary(string libraryName, string folderPath, bool overwrite) : this()
		{
			if (string.IsNullOrEmpty(libraryName))
			{
				throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, "libraryName");
			}
			if (!Directory.Exists(folderPath))
			{
				throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryFolderNotFound);
			}
			this.Name = libraryName;
			ShellNativeMethods.LibrarySaveOptions lsf = overwrite ? ShellNativeMethods.LibrarySaveOptions.OverrideExisting : ShellNativeMethods.LibrarySaveOptions.FailIfThere;
			Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
			IShellItem folderToSaveIn;
			ShellNativeMethods.SHCreateItemFromParsingName(folderPath, IntPtr.Zero, ref guid, out folderToSaveIn);
			this.nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			this.nativeShellLibrary.Save(folderToSaveIn, libraryName, lsf, out this.nativeShellItem);
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000E304 File Offset: 0x0000C504
		public override string Name
		{
			get
			{
				if (base.Name == null && this.NativeShellItem != null)
				{
					base.Name = Path.GetFileNameWithoutExtension(ShellHelper.GetParsingName(this.NativeShellItem));
				}
				return base.Name;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0000E350 File Offset: 0x0000C550
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000E376 File Offset: 0x0000C576
		public IconReference IconResourceId
		{
			get
			{
				string refPath;
				this.nativeShellLibrary.GetIcon(out refPath);
				return new IconReference(refPath);
			}
			set
			{
				this.nativeShellLibrary.SetIcon(value.ReferencePath);
				this.nativeShellLibrary.Commit();
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0000E398 File Offset: 0x0000C598
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0000E3C0 File Offset: 0x0000C5C0
		public LibraryFolderType LibraryType
		{
			get
			{
				Guid folderTypeGuid;
				this.nativeShellLibrary.GetFolderType(out folderTypeGuid);
				return ShellLibrary.GetFolderTypefromGuid(folderTypeGuid);
			}
			set
			{
				Guid guid = ShellLibrary.FolderTypesGuids[(int)value];
				this.nativeShellLibrary.SetFolderType(ref guid);
				this.nativeShellLibrary.Commit();
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0000E3FC File Offset: 0x0000C5FC
		public Guid LibraryTypeId
		{
			get
			{
				Guid result;
				this.nativeShellLibrary.GetFolderType(out result);
				return result;
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000E420 File Offset: 0x0000C620
		private static LibraryFolderType GetFolderTypefromGuid(Guid folderTypeGuid)
		{
			for (int i = 0; i < ShellLibrary.FolderTypesGuids.Length; i++)
			{
				if (folderTypeGuid.Equals(ShellLibrary.FolderTypesGuids[i]))
				{
					return (LibraryFolderType)i;
				}
			}
			throw new ArgumentOutOfRangeException("folderTypeGuid", LocalizedMessages.ShellLibraryInvalidFolderType);
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600039E RID: 926 RVA: 0x0000E47C File Offset: 0x0000C67C
		// (set) Token: 0x0600039F RID: 927 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		public string DefaultSaveFolder
		{
			get
			{
				Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
				IShellItem shellItem;
				this.nativeShellLibrary.GetDefaultSaveFolder(ShellNativeMethods.DefaultSaveFolderType.Detect, ref guid, out shellItem);
				return ShellHelper.GetParsingName(shellItem);
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value");
				}
				if (!Directory.Exists(value))
				{
					throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryDefaultSaveFolderNotFound);
				}
				string fullName = new DirectoryInfo(value).FullName;
				Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
				IShellItem si;
				ShellNativeMethods.SHCreateItemFromParsingName(fullName, IntPtr.Zero, ref guid, out si);
				this.nativeShellLibrary.SetDefaultSaveFolder(ShellNativeMethods.DefaultSaveFolderType.Detect, si);
				this.nativeShellLibrary.Commit();
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000E53C File Offset: 0x0000C73C
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0000E564 File Offset: 0x0000C764
		public bool IsPinnedToNavigationPane
		{
			get
			{
				ShellNativeMethods.LibraryOptions libraryOptions = ShellNativeMethods.LibraryOptions.PinnedToNavigationPane;
				this.nativeShellLibrary.GetOptions(out libraryOptions);
				return (libraryOptions & ShellNativeMethods.LibraryOptions.PinnedToNavigationPane) == ShellNativeMethods.LibraryOptions.PinnedToNavigationPane;
			}
			set
			{
				ShellNativeMethods.LibraryOptions libraryOptions = ShellNativeMethods.LibraryOptions.Default;
				if (value)
				{
					libraryOptions |= ShellNativeMethods.LibraryOptions.PinnedToNavigationPane;
				}
				else
				{
					libraryOptions &= ~ShellNativeMethods.LibraryOptions.PinnedToNavigationPane;
				}
				this.nativeShellLibrary.SetOptions(ShellNativeMethods.LibraryOptions.PinnedToNavigationPane, libraryOptions);
				this.nativeShellLibrary.Commit();
			}
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000E5A5 File Offset: 0x0000C7A5
		public void Close()
		{
			base.Dispose();
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000E5B0 File Offset: 0x0000C7B0
		internal override IShellItem NativeShellItem
		{
			get
			{
				return this.NativeShellItem2;
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000E5C8 File Offset: 0x0000C7C8
		internal override IShellItem2 NativeShellItem2
		{
			get
			{
				return this.nativeShellItem;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		public static IKnownFolder LibrariesKnownFolder
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolderHelper.FromKnownFolderId(new Guid("1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE"));
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000E608 File Offset: 0x0000C808
		public static ShellLibrary Load(string libraryName, bool isReadOnly)
		{
			CoreHelpers.ThrowIfNotWin7();
			IKnownFolder libraries = KnownFolders.Libraries;
			string path = (libraries != null) ? libraries.Path : string.Empty;
			Guid guid = new Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE");
			string path2 = Path.Combine(path, libraryName + ".library-ms");
			IShellItem shellItem;
			int num = ShellNativeMethods.SHCreateItemFromParsingName(path2, IntPtr.Zero, ref guid, out shellItem);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new ShellException(num);
			}
			INativeShellLibrary nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			AccessModes grfMode = isReadOnly ? AccessModes.Direct : AccessModes.ReadWrite;
			nativeShellLibrary.LoadLibraryFromItem(shellItem, grfMode);
			ShellLibrary shellLibrary = new ShellLibrary(nativeShellLibrary);
			ShellLibrary result;
			try
			{
				shellLibrary.nativeShellItem = (IShellItem2)shellItem;
				shellLibrary.Name = libraryName;
				result = shellLibrary;
			}
			catch
			{
				shellLibrary.Dispose();
				throw;
			}
			return result;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000E6E8 File Offset: 0x0000C8E8
		public static ShellLibrary Load(string libraryName, string folderPath, bool isReadOnly)
		{
			CoreHelpers.ThrowIfNotWin7();
			string path = Path.Combine(folderPath, libraryName + ".library-ms");
			ShellFile shellFile = ShellFile.FromFilePath(path);
			IShellItem nativeShellItem = shellFile.NativeShellItem;
			INativeShellLibrary nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			AccessModes grfMode = isReadOnly ? AccessModes.Direct : AccessModes.ReadWrite;
			nativeShellLibrary.LoadLibraryFromItem(nativeShellItem, grfMode);
			ShellLibrary shellLibrary = new ShellLibrary(nativeShellLibrary);
			ShellLibrary result;
			try
			{
				shellLibrary.nativeShellItem = (IShellItem2)nativeShellItem;
				shellLibrary.Name = libraryName;
				result = shellLibrary;
			}
			catch
			{
				shellLibrary.Dispose();
				throw;
			}
			return result;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000E780 File Offset: 0x0000C980
		internal static ShellLibrary FromShellItem(IShellItem nativeShellItem, bool isReadOnly)
		{
			CoreHelpers.ThrowIfNotWin7();
			INativeShellLibrary nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
			AccessModes grfMode = isReadOnly ? AccessModes.Direct : AccessModes.ReadWrite;
			nativeShellLibrary.LoadLibraryFromItem(nativeShellItem, grfMode);
			return new ShellLibrary(nativeShellLibrary)
			{
				nativeShellItem = (IShellItem2)nativeShellItem
			};
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000E7CC File Offset: 0x0000C9CC
		public static ShellLibrary Load(IKnownFolder sourceKnownFolder, bool isReadOnly)
		{
			CoreHelpers.ThrowIfNotWin7();
			return new ShellLibrary(sourceKnownFolder, isReadOnly);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000E82C File Offset: 0x0000CA2C
		private static void ShowManageLibraryUI(ShellLibrary shellLibrary, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
		{
			int hr = 0;
			Thread thread = new Thread(delegate()
			{
				hr = ShellNativeMethods.SHShowManageLibraryUI(shellLibrary.NativeShellItem, windowHandle, title, instruction, allowAllLocations ? ShellNativeMethods.LibraryManageDialogOptions.NonIndexableLocationWarning : ShellNativeMethods.LibraryManageDialogOptions.Default);
			});
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			if (!CoreErrorHelper.Succeeded(hr))
			{
				throw new ShellException(hr);
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000E8B0 File Offset: 0x0000CAB0
		public static void ShowManageLibraryUI(string libraryName, string folderPath, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
		{
			using (ShellLibrary shellLibrary = ShellLibrary.Load(libraryName, folderPath, true))
			{
				ShellLibrary.ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		public static void ShowManageLibraryUI(string libraryName, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
		{
			using (ShellLibrary shellLibrary = ShellLibrary.Load(libraryName, true))
			{
				ShellLibrary.ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000E944 File Offset: 0x0000CB44
		public static void ShowManageLibraryUI(IKnownFolder sourceKnownFolder, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
		{
			using (ShellLibrary shellLibrary = ShellLibrary.Load(sourceKnownFolder, true))
			{
				ShellLibrary.ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000E98C File Offset: 0x0000CB8C
		public void Add(ShellFileSystemFolder item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			this.nativeShellLibrary.AddFolder(item.NativeShellItem);
			this.nativeShellLibrary.Commit();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
		public void Add(string folderPath)
		{
			if (!Directory.Exists(folderPath))
			{
				throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryFolderNotFound);
			}
			this.Add(ShellFileSystemFolder.FromFolderPath(folderPath));
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000EA08 File Offset: 0x0000CC08
		public void Clear()
		{
			List<ShellFileSystemFolder> itemsList = this.ItemsList;
			foreach (ShellFileSystemFolder shellFileSystemFolder in itemsList)
			{
				this.nativeShellLibrary.RemoveFolder(shellFileSystemFolder.NativeShellItem);
			}
			this.nativeShellLibrary.Commit();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000EA7C File Offset: 0x0000CC7C
		public bool Remove(ShellFileSystemFolder item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			try
			{
				this.nativeShellLibrary.RemoveFolder(item.NativeShellItem);
				this.nativeShellLibrary.Commit();
			}
			catch (COMException)
			{
				return false;
			}
			return true;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000EAE4 File Offset: 0x0000CCE4
		public bool Remove(string folderPath)
		{
			ShellFileSystemFolder item = ShellFileSystemFolder.FromFolderPath(folderPath);
			return this.Remove(item);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000EB04 File Offset: 0x0000CD04
		protected override void Dispose(bool disposing)
		{
			if (this.nativeShellLibrary != null)
			{
				Marshal.ReleaseComObject(this.nativeShellLibrary);
				this.nativeShellLibrary = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000EB3C File Offset: 0x0000CD3C
		~ShellLibrary()
		{
			this.Dispose(false);
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0000EB70 File Offset: 0x0000CD70
		private List<ShellFileSystemFolder> ItemsList
		{
			get
			{
				return this.GetFolders();
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000EB88 File Offset: 0x0000CD88
		private List<ShellFileSystemFolder> GetFolders()
		{
			List<ShellFileSystemFolder> list = new List<ShellFileSystemFolder>();
			Guid guid = new Guid("B63EA76D-1F85-456F-A19C-48159EFA858B");
			IShellItemArray shellItemArray;
			HResult folders = this.nativeShellLibrary.GetFolders(ShellNativeMethods.LibraryFolderFilter.AllItems, ref guid, out shellItemArray);
			List<ShellFileSystemFolder> result;
			if (!CoreErrorHelper.Succeeded(folders))
			{
				result = list;
			}
			else
			{
				uint num;
				shellItemArray.GetCount(out num);
				for (uint num2 = 0U; num2 < num; num2 += 1U)
				{
					IShellItem shellItem;
					shellItemArray.GetItemAt(num2, out shellItem);
					list.Add(new ShellFileSystemFolder(shellItem as IShellItem2));
				}
				if (shellItemArray != null)
				{
					Marshal.ReleaseComObject(shellItemArray);
					shellItemArray = null;
				}
				result = list;
			}
			return result;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000EC2C File Offset: 0x0000CE2C
		public new IEnumerator<ShellFileSystemFolder> GetEnumerator()
		{
			return this.ItemsList.GetEnumerator();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000EC50 File Offset: 0x0000CE50
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.ItemsList.GetEnumerator();
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000ECA0 File Offset: 0x0000CEA0
		public bool Contains(string fullPath)
		{
			if (string.IsNullOrEmpty(fullPath))
			{
				throw new ArgumentNullException("fullPath");
			}
			return this.ItemsList.Any((ShellFileSystemFolder folder) => string.Equals(fullPath, folder.Path, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000ED24 File Offset: 0x0000CF24
		public bool Contains(ShellFileSystemFolder item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			return this.ItemsList.Any((ShellFileSystemFolder folder) => string.Equals(item.Path, folder.Path, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000ED7C File Offset: 0x0000CF7C
		public int IndexOf(ShellFileSystemFolder item)
		{
			return this.ItemsList.IndexOf(item);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000ED9A File Offset: 0x0000CF9A
		void IList<ShellFileSystemFolder>.Insert(int index, ShellFileSystemFolder item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000EDA2 File Offset: 0x0000CFA2
		void IList<ShellFileSystemFolder>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000139 RID: 313
		public ShellFileSystemFolder this[int index]
		{
			get
			{
				return this.ItemsList[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000EDD2 File Offset: 0x0000CFD2
		void ICollection<ShellFileSystemFolder>.CopyTo(ShellFileSystemFolder[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000EDDC File Offset: 0x0000CFDC
		public int Count
		{
			get
			{
				return this.ItemsList.Count;
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0000EDFC File Offset: 0x0000CFFC
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000EE10 File Offset: 0x0000D010
		public new static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnWin7;
			}
		}

		// Token: 0x040002A6 RID: 678
		internal const string FileExtension = ".library-ms";

		// Token: 0x040002A7 RID: 679
		private INativeShellLibrary nativeShellLibrary;

		// Token: 0x040002A8 RID: 680
		private IKnownFolder knownFolder;

		// Token: 0x040002A9 RID: 681
		private static Guid[] FolderTypesGuids = new Guid[]
		{
			new Guid("5c4f28b5-f869-4e84-8e60-f11db97c5cc7"),
			new Guid("7d49d726-3c21-4f05-99aa-fdc2c9474656"),
			new Guid("94d6ddcc-4a68-4175-a374-bd584a510b78"),
			new Guid("b3690e58-e961-423b-b687-386ebfd83239"),
			new Guid("5fa96407-7e77-483c-ac93-691d05850de8")
		};
	}
}
