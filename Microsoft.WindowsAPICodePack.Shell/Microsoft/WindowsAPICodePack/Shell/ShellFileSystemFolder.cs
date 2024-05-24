using System;
using System.Globalization;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200000B RID: 11
	public class ShellFileSystemFolder : ShellFolder
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00002DB4 File Offset: 0x00000FB4
		internal ShellFileSystemFolder()
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002DBF File Offset: 0x00000FBF
		internal ShellFileSystemFolder(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002DD4 File Offset: 0x00000FD4
		public static ShellFileSystemFolder FromFolderPath(string path)
		{
			string absolutePath = ShellHelper.GetAbsolutePath(path);
			if (!Directory.Exists(absolutePath))
			{
				throw new DirectoryNotFoundException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.FilePathNotExist, new object[]
				{
					path
				}));
			}
			ShellFileSystemFolder shellFileSystemFolder = new ShellFileSystemFolder();
			ShellFileSystemFolder result;
			try
			{
				shellFileSystemFolder.ParsingName = absolutePath;
				result = shellFileSystemFolder;
			}
			catch
			{
				shellFileSystemFolder.Dispose();
				throw;
			}
			return result;
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002E48 File Offset: 0x00001048
		public virtual string Path
		{
			get
			{
				return this.ParsingName;
			}
		}
	}
}
