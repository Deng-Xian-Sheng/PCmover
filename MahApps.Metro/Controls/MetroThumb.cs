using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000066 RID: 102
	public class MetroThumb : Thumb, IMetroThumb, IInputElement
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00011589 File Offset: 0x0000F789
		protected override void OnPreviewTouchDown(TouchEventArgs e)
		{
			this.ReleaseCurrentDevice();
			this.CaptureCurrentDevice(e);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00011598 File Offset: 0x0000F798
		protected override void OnPreviewTouchUp(TouchEventArgs e)
		{
			this.ReleaseCurrentDevice();
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x000115A0 File Offset: 0x0000F7A0
		protected override void OnLostTouchCapture(TouchEventArgs e)
		{
			if (this.currentDevice != null)
			{
				this.CaptureCurrentDevice(e);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000115B4 File Offset: 0x0000F7B4
		private void ReleaseCurrentDevice()
		{
			if (this.currentDevice != null)
			{
				TouchDevice touchDevice = this.currentDevice;
				this.currentDevice = null;
				base.ReleaseTouchCapture(touchDevice);
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000115DF File Offset: 0x0000F7DF
		private void CaptureCurrentDevice(TouchEventArgs e)
		{
			if (base.CaptureTouch(e.TouchDevice))
			{
				this.currentDevice = e.TouchDevice;
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00011603 File Offset: 0x0000F803
		void IMetroThumb.add_DragStarted(DragStartedEventHandler value)
		{
			base.DragStarted += value;
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001160C File Offset: 0x0000F80C
		void IMetroThumb.remove_DragStarted(DragStartedEventHandler value)
		{
			base.DragStarted -= value;
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00011615 File Offset: 0x0000F815
		void IMetroThumb.add_DragDelta(DragDeltaEventHandler value)
		{
			base.DragDelta += value;
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0001161E File Offset: 0x0000F81E
		void IMetroThumb.remove_DragDelta(DragDeltaEventHandler value)
		{
			base.DragDelta -= value;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00011627 File Offset: 0x0000F827
		void IMetroThumb.add_DragCompleted(DragCompletedEventHandler value)
		{
			base.DragCompleted += value;
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00011630 File Offset: 0x0000F830
		void IMetroThumb.remove_DragCompleted(DragCompletedEventHandler value)
		{
			base.DragCompleted -= value;
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00011639 File Offset: 0x0000F839
		void IMetroThumb.add_MouseDoubleClick(MouseButtonEventHandler value)
		{
			base.MouseDoubleClick += value;
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00011642 File Offset: 0x0000F842
		void IMetroThumb.remove_MouseDoubleClick(MouseButtonEventHandler value)
		{
			base.MouseDoubleClick -= value;
		}

		// Token: 0x040001A9 RID: 425
		private TouchDevice currentDevice;
	}
}
