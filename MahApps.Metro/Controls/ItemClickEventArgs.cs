using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000039 RID: 57
	public class ItemClickEventArgs : RoutedEventArgs
	{
		// Token: 0x0600028C RID: 652 RVA: 0x0000BAA1 File Offset: 0x00009CA1
		public ItemClickEventArgs(object clickedObject)
		{
			this.ClickedItem = clickedObject;
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000BAB0 File Offset: 0x00009CB0
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000BAB8 File Offset: 0x00009CB8
		public object ClickedItem { get; internal set; }
	}
}
