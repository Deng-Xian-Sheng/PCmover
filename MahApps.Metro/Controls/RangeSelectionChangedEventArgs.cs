using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200007B RID: 123
	public class RangeSelectionChangedEventArgs : RoutedEventArgs
	{
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x00017D82 File Offset: 0x00015F82
		// (set) Token: 0x06000615 RID: 1557 RVA: 0x00017D8A File Offset: 0x00015F8A
		public double NewLowerValue { get; set; }

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x00017D93 File Offset: 0x00015F93
		// (set) Token: 0x06000617 RID: 1559 RVA: 0x00017D9B File Offset: 0x00015F9B
		public double NewUpperValue { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000618 RID: 1560 RVA: 0x00017DA4 File Offset: 0x00015FA4
		// (set) Token: 0x06000619 RID: 1561 RVA: 0x00017DAC File Offset: 0x00015FAC
		public double OldLowerValue { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x0600061A RID: 1562 RVA: 0x00017DB5 File Offset: 0x00015FB5
		// (set) Token: 0x0600061B RID: 1563 RVA: 0x00017DBD File Offset: 0x00015FBD
		public double OldUpperValue { get; set; }

		// Token: 0x0600061C RID: 1564 RVA: 0x00017DC6 File Offset: 0x00015FC6
		internal RangeSelectionChangedEventArgs(double newLowerValue, double newUpperValue, double oldLowerValue, double oldUpperValue)
		{
			this.NewLowerValue = newLowerValue;
			this.NewUpperValue = newUpperValue;
			this.OldLowerValue = oldLowerValue;
			this.OldUpperValue = oldUpperValue;
		}
	}
}
