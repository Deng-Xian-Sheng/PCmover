using System;
using System.Windows;
using System.Windows.Interactivity;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B9 RID: 185
	public class StylizedBehaviorCollection : FreezableCollection<Behavior>
	{
		// Token: 0x06000A13 RID: 2579 RVA: 0x00027056 File Offset: 0x00025256
		protected override Freezable CreateInstanceCore()
		{
			return new StylizedBehaviorCollection();
		}
	}
}
