using System;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000083 RID: 131
	public class CommonFileDialogFilterCollection : Collection<CommonFileDialogFilter>
	{
		// Token: 0x0600048C RID: 1164 RVA: 0x000117F4 File Offset: 0x0000F9F4
		internal CommonFileDialogFilterCollection()
		{
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00011800 File Offset: 0x0000FA00
		internal ShellNativeMethods.FilterSpec[] GetAllFilterSpecs()
		{
			ShellNativeMethods.FilterSpec[] array = new ShellNativeMethods.FilterSpec[base.Count];
			for (int i = 0; i < base.Count; i++)
			{
				array[i] = base[i].GetFilterSpec();
			}
			return array;
		}
	}
}
