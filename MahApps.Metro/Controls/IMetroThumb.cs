using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200005A RID: 90
	public interface IMetroThumb : IInputElement
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060003ED RID: 1005
		// (remove) Token: 0x060003EE RID: 1006
		event DragStartedEventHandler DragStarted;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060003EF RID: 1007
		// (remove) Token: 0x060003F0 RID: 1008
		event DragDeltaEventHandler DragDelta;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060003F1 RID: 1009
		// (remove) Token: 0x060003F2 RID: 1010
		event DragCompletedEventHandler DragCompleted;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060003F3 RID: 1011
		// (remove) Token: 0x060003F4 RID: 1012
		event MouseButtonEventHandler MouseDoubleClick;
	}
}
