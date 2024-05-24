using System;
using System.Windows.Controls.Primitives;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000069 RID: 105
	public class MetroThumbContentControlDragCompletedEventArgs : DragCompletedEventArgs
	{
		// Token: 0x0600049D RID: 1181 RVA: 0x00011B2D File Offset: 0x0000FD2D
		public MetroThumbContentControlDragCompletedEventArgs(double horizontalOffset, double verticalOffset, bool canceled) : base(horizontalOffset, verticalOffset, canceled)
		{
			base.RoutedEvent = MetroThumbContentControl.DragCompletedEvent;
		}
	}
}
