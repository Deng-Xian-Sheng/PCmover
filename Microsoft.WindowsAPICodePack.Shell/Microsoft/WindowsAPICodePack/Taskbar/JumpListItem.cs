using System;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000185 RID: 389
	public class JumpListItem : ShellFile, IJumpListItem
	{
		// Token: 0x06000F24 RID: 3876 RVA: 0x00035302 File Offset: 0x00033502
		public JumpListItem(string path) : base(path)
		{
		}

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x00035310 File Offset: 0x00033510
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00035328 File Offset: 0x00033528
		public new string Path
		{
			get
			{
				return base.Path;
			}
			set
			{
				base.ParsingName = value;
			}
		}
	}
}
