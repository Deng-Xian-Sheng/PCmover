using System;
using System.Globalization;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000011 RID: 17
	public class ShellFile : ShellObject
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00004228 File Offset: 0x00002428
		internal ShellFile(string path)
		{
			string absolutePath = ShellHelper.GetAbsolutePath(path);
			if (!File.Exists(absolutePath))
			{
				throw new FileNotFoundException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.FilePathNotExist, new object[]
				{
					path
				}));
			}
			this.ParsingName = absolutePath;
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004279 File Offset: 0x00002479
		internal ShellFile(IShellItem2 shellItem)
		{
			this.nativeShellItem = shellItem;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x0000428C File Offset: 0x0000248C
		public static ShellFile FromFilePath(string path)
		{
			return new ShellFile(path);
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000042A4 File Offset: 0x000024A4
		public virtual string Path
		{
			get
			{
				return this.ParsingName;
			}
		}
	}
}
