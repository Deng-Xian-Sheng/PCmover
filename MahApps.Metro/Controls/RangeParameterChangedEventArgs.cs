using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000079 RID: 121
	public class RangeParameterChangedEventArgs : RoutedEventArgs
	{
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00017D32 File Offset: 0x00015F32
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x00017D3A File Offset: 0x00015F3A
		public RangeParameterChangeType ParameterType { get; private set; }

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00017D43 File Offset: 0x00015F43
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x00017D4B File Offset: 0x00015F4B
		public double OldValue { get; private set; }

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00017D54 File Offset: 0x00015F54
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x00017D5C File Offset: 0x00015F5C
		public double NewValue { get; private set; }

		// Token: 0x06000613 RID: 1555 RVA: 0x00017D65 File Offset: 0x00015F65
		internal RangeParameterChangedEventArgs(RangeParameterChangeType type, double _old, double _new)
		{
			this.ParameterType = type;
			this.OldValue = _old;
			this.NewValue = _new;
		}
	}
}
