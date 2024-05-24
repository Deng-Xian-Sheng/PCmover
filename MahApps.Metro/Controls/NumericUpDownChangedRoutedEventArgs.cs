using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000071 RID: 113
	public class NumericUpDownChangedRoutedEventArgs : RoutedEventArgs
	{
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x000169FB File Offset: 0x00014BFB
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00016A03 File Offset: 0x00014C03
		public double Interval { get; set; }

		// Token: 0x060005BE RID: 1470 RVA: 0x00016A0C File Offset: 0x00014C0C
		public NumericUpDownChangedRoutedEventArgs(RoutedEvent routedEvent, double interval) : base(routedEvent)
		{
			this.Interval = interval;
		}
	}
}
