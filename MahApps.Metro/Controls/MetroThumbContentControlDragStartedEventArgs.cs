using System;
using System.Windows.Controls.Primitives;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200006A RID: 106
	public class MetroThumbContentControlDragStartedEventArgs : DragStartedEventArgs
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x00011B43 File Offset: 0x0000FD43
		public MetroThumbContentControlDragStartedEventArgs(double horizontalOffset, double verticalOffset) : base(horizontalOffset, verticalOffset)
		{
			base.RoutedEvent = MetroThumbContentControl.DragStartedEvent;
		}
	}
}
