using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000067 RID: 103
	public class MetroThumbContentControl : ContentControlEx, IMetroThumb, IInputElement
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x0001164C File Offset: 0x0000F84C
		static MetroThumbContentControl()
		{
			MetroThumbContentControl.DragStartedEvent = EventManager.RegisterRoutedEvent("DragStarted", RoutingStrategy.Bubble, typeof(DragStartedEventHandler), typeof(MetroThumbContentControl));
			MetroThumbContentControl.DragDeltaEvent = EventManager.RegisterRoutedEvent("DragDelta", RoutingStrategy.Bubble, typeof(DragDeltaEventHandler), typeof(MetroThumbContentControl));
			MetroThumbContentControl.DragCompletedEvent = EventManager.RegisterRoutedEvent("DragCompleted", RoutingStrategy.Bubble, typeof(DragCompletedEventHandler), typeof(MetroThumbContentControl));
			MetroThumbContentControl.IsDraggingPropertyKey = DependencyProperty.RegisterReadOnly("IsDragging", typeof(bool), typeof(MetroThumbContentControl), new FrameworkPropertyMetadata(false));
			MetroThumbContentControl.IsDraggingProperty = MetroThumbContentControl.IsDraggingPropertyKey.DependencyProperty;
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroThumbContentControl), new FrameworkPropertyMetadata(typeof(MetroThumbContentControl)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(MetroThumbContentControl), new FrameworkPropertyMetadata(false));
			EventManager.RegisterClassHandler(typeof(MetroThumbContentControl), Mouse.LostMouseCaptureEvent, new MouseEventHandler(MetroThumbContentControl.OnLostMouseCapture));
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000484 RID: 1156 RVA: 0x00011764 File Offset: 0x0000F964
		// (remove) Token: 0x06000485 RID: 1157 RVA: 0x00011772 File Offset: 0x0000F972
		public event DragStartedEventHandler DragStarted
		{
			add
			{
				base.AddHandler(MetroThumbContentControl.DragStartedEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroThumbContentControl.DragStartedEvent, value);
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000486 RID: 1158 RVA: 0x00011780 File Offset: 0x0000F980
		// (remove) Token: 0x06000487 RID: 1159 RVA: 0x0001178E File Offset: 0x0000F98E
		public event DragDeltaEventHandler DragDelta
		{
			add
			{
				base.AddHandler(MetroThumbContentControl.DragDeltaEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroThumbContentControl.DragDeltaEvent, value);
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x06000488 RID: 1160 RVA: 0x0001179C File Offset: 0x0000F99C
		// (remove) Token: 0x06000489 RID: 1161 RVA: 0x000117AA File Offset: 0x0000F9AA
		public event DragCompletedEventHandler DragCompleted
		{
			add
			{
				base.AddHandler(MetroThumbContentControl.DragCompletedEvent, value);
			}
			remove
			{
				base.RemoveHandler(MetroThumbContentControl.DragCompletedEvent, value);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x000117B8 File Offset: 0x0000F9B8
		// (set) Token: 0x0600048B RID: 1163 RVA: 0x000117CA File Offset: 0x0000F9CA
		public bool IsDragging
		{
			get
			{
				return (bool)base.GetValue(MetroThumbContentControl.IsDraggingProperty);
			}
			protected set
			{
				base.SetValue(MetroThumbContentControl.IsDraggingPropertyKey, value);
			}
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000117E0 File Offset: 0x0000F9E0
		public void CancelDragAction()
		{
			if (!this.IsDragging)
			{
				return;
			}
			if (base.IsMouseCaptured)
			{
				base.ReleaseMouseCapture();
			}
			base.ClearValue(MetroThumbContentControl.IsDraggingPropertyKey);
			double horizontalOffset = this.oldDragScreenPoint.X - this.startDragScreenPoint.X;
			double verticalOffset = this.oldDragScreenPoint.Y - this.startDragScreenPoint.Y;
			base.RaiseEvent(new MetroThumbContentControlDragCompletedEventArgs(horizontalOffset, verticalOffset, true));
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00011850 File Offset: 0x0000FA50
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (!this.IsDragging)
			{
				e.Handled = true;
				try
				{
					base.Focus();
					base.CaptureMouse();
					base.SetValue(MetroThumbContentControl.IsDraggingPropertyKey, true);
					this.startDragPoint = e.GetPosition(this);
					this.oldDragScreenPoint = (this.startDragScreenPoint = base.PointToScreen(this.startDragPoint));
					base.RaiseEvent(new MetroThumbContentControlDragStartedEventArgs(this.startDragPoint.X, this.startDragPoint.Y));
				}
				catch (Exception)
				{
					this.CancelDragAction();
				}
			}
			base.OnMouseLeftButtonDown(e);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x000118F8 File Offset: 0x0000FAF8
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			if (base.IsMouseCaptured && this.IsDragging)
			{
				e.Handled = true;
				base.ClearValue(MetroThumbContentControl.IsDraggingPropertyKey);
				base.ReleaseMouseCapture();
				Point point = base.PointToScreen(e.MouseDevice.GetPosition(this));
				double horizontalOffset = point.X - this.startDragScreenPoint.X;
				double verticalOffset = point.Y - this.startDragScreenPoint.Y;
				base.RaiseEvent(new MetroThumbContentControlDragCompletedEventArgs(horizontalOffset, verticalOffset, false));
			}
			base.OnMouseLeftButtonUp(e);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00011980 File Offset: 0x0000FB80
		private static void OnLostMouseCapture(object sender, MouseEventArgs e)
		{
			MetroThumbContentControl metroThumbContentControl = (MetroThumbContentControl)sender;
			if (Mouse.Captured != metroThumbContentControl)
			{
				metroThumbContentControl.CancelDragAction();
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x000119A4 File Offset: 0x0000FBA4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (!this.IsDragging)
			{
				return;
			}
			if (e.MouseDevice.LeftButton == MouseButtonState.Pressed)
			{
				Point position = e.GetPosition(this);
				Point point = base.PointToScreen(position);
				if (point != this.oldDragScreenPoint)
				{
					this.oldDragScreenPoint = point;
					e.Handled = true;
					double horizontalChange = position.X - this.startDragPoint.X;
					double verticalChange = position.Y - this.startDragPoint.Y;
					base.RaiseEvent(new DragDeltaEventArgs(horizontalChange, verticalChange)
					{
						RoutedEvent = MetroThumbContentControl.DragDeltaEvent
					});
					return;
				}
			}
			else
			{
				if (e.MouseDevice.Captured == this)
				{
					base.ReleaseMouseCapture();
				}
				base.ClearValue(MetroThumbContentControl.IsDraggingPropertyKey);
				this.startDragPoint.X = 0.0;
				this.startDragPoint.Y = 0.0;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00011A86 File Offset: 0x0000FC86
		protected override void OnPreviewTouchDown(TouchEventArgs e)
		{
			this.ReleaseCurrentDevice();
			this.CaptureCurrentDevice(e);
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00011A95 File Offset: 0x0000FC95
		protected override void OnPreviewTouchUp(TouchEventArgs e)
		{
			this.ReleaseCurrentDevice();
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00011A9D File Offset: 0x0000FC9D
		protected override void OnLostTouchCapture(TouchEventArgs e)
		{
			if (this.currentDevice != null)
			{
				this.CaptureCurrentDevice(e);
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x00011AB0 File Offset: 0x0000FCB0
		private void ReleaseCurrentDevice()
		{
			if (this.currentDevice != null)
			{
				TouchDevice touchDevice = this.currentDevice;
				this.currentDevice = null;
				base.ReleaseTouchCapture(touchDevice);
			}
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x00011ADB File Offset: 0x0000FCDB
		private void CaptureCurrentDevice(TouchEventArgs e)
		{
			if (base.CaptureTouch(e.TouchDevice))
			{
				this.currentDevice = e.TouchDevice;
			}
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x00011AF7 File Offset: 0x0000FCF7
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new MetroThumbContentControlAutomationPeer(this);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00011B07 File Offset: 0x0000FD07
		void IMetroThumb.add_MouseDoubleClick(MouseButtonEventHandler value)
		{
			base.MouseDoubleClick += value;
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00011B10 File Offset: 0x0000FD10
		void IMetroThumb.remove_MouseDoubleClick(MouseButtonEventHandler value)
		{
			base.MouseDoubleClick -= value;
		}

		// Token: 0x040001AA RID: 426
		private TouchDevice currentDevice;

		// Token: 0x040001AB RID: 427
		private Point startDragPoint;

		// Token: 0x040001AC RID: 428
		private Point startDragScreenPoint;

		// Token: 0x040001AD RID: 429
		private Point oldDragScreenPoint;

		// Token: 0x040001B1 RID: 433
		public static readonly DependencyPropertyKey IsDraggingPropertyKey;

		// Token: 0x040001B2 RID: 434
		public static readonly DependencyProperty IsDraggingProperty;
	}
}
