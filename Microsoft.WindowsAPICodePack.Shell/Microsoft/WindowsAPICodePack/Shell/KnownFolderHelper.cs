using System;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000064 RID: 100
	public static class KnownFolderHelper
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0000CB5C File Offset: 0x0000AD5C
		internal static IKnownFolderNative FromPIDL(IntPtr pidl)
		{
			KnownFolderManagerClass knownFolderManagerClass = new KnownFolderManagerClass();
			IKnownFolderNative knownFolderNative;
			HResult hresult = knownFolderManagerClass.FindFolderFromIDList(pidl, out knownFolderNative);
			return (hresult == HResult.Ok) ? knownFolderNative : null;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000CB88 File Offset: 0x0000AD88
		public static IKnownFolder FromKnownFolderId(Guid knownFolderId)
		{
			KnownFolderManagerClass knownFolderManagerClass = new KnownFolderManagerClass();
			IKnownFolderNative knownFolderNative;
			HResult folder = knownFolderManagerClass.GetFolder(knownFolderId, out knownFolderNative);
			if (folder != HResult.Ok)
			{
				throw new ShellException(folder);
			}
			IKnownFolder knownFolder = KnownFolderHelper.GetKnownFolder(knownFolderNative);
			if (knownFolder == null)
			{
				throw new ArgumentException(LocalizedMessages.KnownFolderInvalidGuid, "knownFolderId");
			}
			return knownFolder;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000CBE4 File Offset: 0x0000ADE4
		internal static IKnownFolder FromKnownFolderIdInternal(Guid knownFolderId)
		{
			IKnownFolderManager knownFolderManager = new KnownFolderManagerClass();
			IKnownFolderNative knownFolderNative;
			HResult folder = knownFolderManager.GetFolder(knownFolderId, out knownFolderNative);
			return (folder == HResult.Ok) ? KnownFolderHelper.GetKnownFolder(knownFolderNative) : null;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000CC14 File Offset: 0x0000AE14
		private static IKnownFolder GetKnownFolder(IKnownFolderNative knownFolderNative)
		{
			Debug.Assert(knownFolderNative != null, "Native IKnownFolder should not be null.");
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			IShellItem2 shellItem2;
			HResult shellItem = knownFolderNative.GetShellItem(0, ref guid, out shellItem2);
			IKnownFolder result;
			if (!CoreErrorHelper.Succeeded(shellItem))
			{
				result = null;
			}
			else
			{
				bool flag = false;
				if (shellItem2 != null)
				{
					ShellNativeMethods.ShellFileGetAttributesOptions shellFileGetAttributesOptions;
					shellItem2.GetAttributes(ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem, out shellFileGetAttributesOptions);
					flag = ((shellFileGetAttributesOptions & ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem) != (ShellNativeMethods.ShellFileGetAttributesOptions)0);
				}
				if (flag)
				{
					FileSystemKnownFolder fileSystemKnownFolder = new FileSystemKnownFolder(knownFolderNative);
					result = fileSystemKnownFolder;
				}
				else
				{
					NonFileSystemKnownFolder nonFileSystemKnownFolder = new NonFileSystemKnownFolder(knownFolderNative);
					result = nonFileSystemKnownFolder;
				}
			}
			return result;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		public static IKnownFolder FromCanonicalName(string canonicalName)
		{
			IKnownFolderManager knownFolderManager = new KnownFolderManagerClass();
			IKnownFolderNative knownFolderNative;
			knownFolderManager.GetFolderByName(canonicalName, out knownFolderNative);
			IKnownFolder knownFolder = KnownFolderHelper.GetKnownFolder(knownFolderNative);
			if (knownFolder == null)
			{
				throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, "canonicalName");
			}
			return knownFolder;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000CD00 File Offset: 0x0000AF00
		public static IKnownFolder FromPath(string path)
		{
			return KnownFolderHelper.FromParsingName(path);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000CD18 File Offset: 0x0000AF18
		public static IKnownFolder FromParsingName(string parsingName)
		{
			if (parsingName == null)
			{
				throw new ArgumentNullException("parsingName");
			}
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			IKnownFolder result;
			try
			{
				intPtr = ShellHelper.PidlFromParsingName(parsingName);
				if (intPtr == IntPtr.Zero)
				{
					throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, "parsingName");
				}
				IKnownFolderNative knownFolderNative = KnownFolderHelper.FromPIDL(intPtr);
				if (knownFolderNative != null)
				{
					IKnownFolder knownFolder = KnownFolderHelper.GetKnownFolder(knownFolderNative);
					if (knownFolder == null)
					{
						throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, "parsingName");
					}
					result = knownFolder;
				}
				else
				{
					intPtr2 = ShellHelper.PidlFromParsingName(parsingName.PadRight(1, '\0'));
					if (intPtr2 == IntPtr.Zero)
					{
						throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, "parsingName");
					}
					IKnownFolder knownFolder2 = KnownFolderHelper.GetKnownFolder(KnownFolderHelper.FromPIDL(intPtr));
					if (knownFolder2 == null)
					{
						throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, "parsingName");
					}
					result = knownFolder2;
				}
			}
			finally
			{
				ShellNativeMethods.ILFree(intPtr);
				ShellNativeMethods.ILFree(intPtr2);
			}
			return result;
		}
	}
}
