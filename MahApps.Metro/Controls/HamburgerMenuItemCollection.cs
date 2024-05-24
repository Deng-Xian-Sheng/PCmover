using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000040 RID: 64
	public class HamburgerMenuItemCollection : FreezableCollection<HamburgerMenuItem>
	{
		// Token: 0x060002C4 RID: 708 RVA: 0x0000BF53 File Offset: 0x0000A153
		protected override Freezable CreateInstanceCore()
		{
			return new HamburgerMenuItemCollection();
		}
	}
}
