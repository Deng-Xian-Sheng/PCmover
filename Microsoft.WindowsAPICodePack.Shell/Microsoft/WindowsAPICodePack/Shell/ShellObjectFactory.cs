using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000016 RID: 22
	internal static class ShellObjectFactory
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x00004654 File Offset: 0x00002854
		internal static ShellObject Create(IShellItem nativeShellItem)
		{
			Debug.Assert(nativeShellItem != null, "nativeShellItem should not be null");
			if (!CoreHelpers.RunningOnVista)
			{
				throw new PlatformNotSupportedException(LocalizedMessages.ShellObjectFactoryPlatformNotSupported);
			}
			IShellItem2 shellItem = nativeShellItem as IShellItem2;
			string text = ShellHelper.GetItemType(shellItem);
			if (!string.IsNullOrEmpty(text))
			{
				text = text.ToUpperInvariant();
			}
			ShellNativeMethods.ShellFileGetAttributesOptions shellFileGetAttributesOptions;
			shellItem.GetAttributes(ShellNativeMethods.ShellFileGetAttributesOptions.Folder | ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem, out shellFileGetAttributesOptions);
			bool flag = (shellFileGetAttributesOptions & ShellNativeMethods.ShellFileGetAttributesOptions.FileSystem) != (ShellNativeMethods.ShellFileGetAttributesOptions)0;
			bool flag2 = (shellFileGetAttributesOptions & ShellNativeMethods.ShellFileGetAttributesOptions.Folder) != (ShellNativeMethods.ShellFileGetAttributesOptions)0;
			ShellLibrary shellLibrary = null;
			ShellObject result;
			if (text == ".lnk")
			{
				result = new ShellLink(shellItem);
			}
			else if (flag2)
			{
				if (text == ".library-ms" && (shellLibrary = ShellLibrary.FromShellItem(shellItem, true)) != null)
				{
					result = shellLibrary;
				}
				else if (text == ".searchconnector-ms")
				{
					result = new ShellSearchConnector(shellItem);
				}
				else if (text == ".search-ms")
				{
					result = new ShellSavedSearchCollection(shellItem);
				}
				else if (flag)
				{
					if (!ShellObjectFactory.IsVirtualKnownFolder(shellItem))
					{
						FileSystemKnownFolder fileSystemKnownFolder = new FileSystemKnownFolder(shellItem);
						result = fileSystemKnownFolder;
					}
					else
					{
						result = new ShellFileSystemFolder(shellItem);
					}
				}
				else if (ShellObjectFactory.IsVirtualKnownFolder(shellItem))
				{
					NonFileSystemKnownFolder nonFileSystemKnownFolder = new NonFileSystemKnownFolder(shellItem);
					result = nonFileSystemKnownFolder;
				}
				else
				{
					result = new ShellNonFileSystemFolder(shellItem);
				}
			}
			else if (flag)
			{
				result = new ShellFile(shellItem);
			}
			else
			{
				result = new ShellNonFileSystemItem(shellItem);
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000048CC File Offset: 0x00002ACC
		private static bool IsVirtualKnownFolder(IShellItem2 nativeShellItem2)
		{
			IntPtr pidl = IntPtr.Zero;
			bool result;
			try
			{
				IKnownFolderNative nativeFolder = null;
				KnownFoldersSafeNativeMethods.NativeFolderDefinition definition = default(KnownFoldersSafeNativeMethods.NativeFolderDefinition);
				object padlock = new object();
				lock (padlock)
				{
					IntPtr unknown = Marshal.GetIUnknownForObject(nativeShellItem2);
					ThreadPool.QueueUserWorkItem(delegate(object obj)
					{
						lock (padlock)
						{
							pidl = ShellHelper.PidlFromUnknown(unknown);
							new KnownFolderManagerClass().FindFolderFromIDList(pidl, out nativeFolder);
							if (nativeFolder != null)
							{
								nativeFolder.GetFolderDefinition(out definition);
							}
							Monitor.Pulse(padlock);
						}
					});
					Monitor.Wait(padlock);
				}
				result = (nativeFolder != null && definition.category == FolderCategory.Virtual);
			}
			finally
			{
				ShellNativeMethods.ILFree(pidl);
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000049B8 File Offset: 0x00002BB8
		internal static ShellObject Create(string parsingName)
		{
			if (string.IsNullOrEmpty(parsingName))
			{
				throw new ArgumentNullException("parsingName");
			}
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			IShellItem2 nativeShellItem;
			int num = ShellNativeMethods.SHCreateItemFromParsingName(parsingName, IntPtr.Zero, ref guid, out nativeShellItem);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new ShellException(LocalizedMessages.ShellObjectFactoryUnableToCreateItem, Marshal.GetExceptionForHR(num));
			}
			return ShellObjectFactory.Create(nativeShellItem);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004A2C File Offset: 0x00002C2C
		internal static ShellObject Create(IntPtr idListPtr)
		{
			CoreHelpers.ThrowIfNotVista();
			Guid guid = new Guid("7E9FB0D3-919F-4307-AB2E-9B1860310C93");
			IShellItem2 nativeShellItem;
			int result = ShellNativeMethods.SHCreateItemFromIDList(idListPtr, ref guid, out nativeShellItem);
			ShellObject result2;
			if (!CoreErrorHelper.Succeeded(result))
			{
				result2 = null;
			}
			else
			{
				result2 = ShellObjectFactory.Create(nativeShellItem);
			}
			return result2;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004A78 File Offset: 0x00002C78
		internal static ShellObject Create(IntPtr idListPtr, ShellContainer parent)
		{
			IShellItem nativeShellItem;
			int result = ShellNativeMethods.SHCreateShellItem(IntPtr.Zero, parent.NativeShellFolder, idListPtr, out nativeShellItem);
			ShellObject result2;
			if (!CoreErrorHelper.Succeeded(result))
			{
				result2 = null;
			}
			else
			{
				result2 = ShellObjectFactory.Create(nativeShellItem);
			}
			return result2;
		}
	}
}
