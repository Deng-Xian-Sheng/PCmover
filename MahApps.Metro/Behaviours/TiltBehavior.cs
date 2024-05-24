using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000BC RID: 188
	public class TiltBehavior : Behavior<FrameworkElement>
	{
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00027455 File Offset: 0x00025655
		// (set) Token: 0x06000A25 RID: 2597 RVA: 0x00027467 File Offset: 0x00025667
		public bool KeepDragging
		{
			get
			{
				return (bool)base.GetValue(TiltBehavior.KeepDraggingProperty);
			}
			set
			{
				base.SetValue(TiltBehavior.KeepDraggingProperty, value);
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000A26 RID: 2598 RVA: 0x0002747A File Offset: 0x0002567A
		// (set) Token: 0x06000A27 RID: 2599 RVA: 0x0002748C File Offset: 0x0002568C
		public int TiltFactor
		{
			get
			{
				return (int)base.GetValue(TiltBehavior.TiltFactorProperty);
			}
			set
			{
				base.SetValue(TiltBehavior.TiltFactorProperty, value);
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000A28 RID: 2600 RVA: 0x0002749F File Offset: 0x0002569F
		// (set) Token: 0x06000A29 RID: 2601 RVA: 0x000274A7 File Offset: 0x000256A7
		public Planerator RotatorParent { get; set; }

		// Token: 0x06000A2A RID: 2602 RVA: 0x000274B0 File Offset: 0x000256B0
		protected override void OnAttached()
		{
			this.attachedElement = base.AssociatedObject;
			if (this.attachedElement is ListBox)
			{
				return;
			}
			Panel attachedElementPanel = this.attachedElement as Panel;
			if (attachedElementPanel != null)
			{
				Action<UIElement> <>9__1;
				attachedElementPanel.Loaded += delegate(object sl, RoutedEventArgs el)
				{
					List<UIElement> list = attachedElementPanel.Children.Cast<UIElement>().ToList<UIElement>();
					Action<UIElement> action;
					if ((action = <>9__1) == null)
					{
						action = (<>9__1 = delegate(UIElement element)
						{
							Interaction.GetBehaviors(element).Add(new TiltBehavior
							{
								KeepDragging = this.KeepDragging,
								TiltFactor = this.TiltFactor
							});
						});
					}
					list.ForEach(action);
				};
				return;
			}
			this.originalPanel = ((this.attachedElement.Parent as Panel) ?? TiltBehavior.GetParentPanel(this.attachedElement));
			this.originalMargin = this.attachedElement.Margin;
			this.originalSize = new Size(this.attachedElement.Width, this.attachedElement.Height);
			double left = Canvas.GetLeft(this.attachedElement);
			double right = Canvas.GetRight(this.attachedElement);
			double top = Canvas.GetTop(this.attachedElement);
			double bottom = Canvas.GetBottom(this.attachedElement);
			int zindex = Panel.GetZIndex(this.attachedElement);
			VerticalAlignment verticalAlignment = this.attachedElement.VerticalAlignment;
			HorizontalAlignment horizontalAlignment = this.attachedElement.HorizontalAlignment;
			this.RotatorParent = new Planerator
			{
				Margin = this.originalMargin,
				Width = this.originalSize.Width,
				Height = this.originalSize.Height,
				VerticalAlignment = verticalAlignment,
				HorizontalAlignment = horizontalAlignment
			};
			this.RotatorParent.SetValue(Canvas.LeftProperty, left);
			this.RotatorParent.SetValue(Canvas.RightProperty, right);
			this.RotatorParent.SetValue(Canvas.TopProperty, top);
			this.RotatorParent.SetValue(Canvas.BottomProperty, bottom);
			this.RotatorParent.SetValue(Panel.ZIndexProperty, zindex);
			this.originalPanel.Children.Remove(this.attachedElement);
			this.attachedElement.Margin = default(Thickness);
			this.attachedElement.Width = double.NaN;
			this.attachedElement.Height = double.NaN;
			this.originalPanel.Children.Add(this.RotatorParent);
			this.RotatorParent.Child = this.attachedElement;
			CompositionTarget.Rendering += this.CompositionTargetRendering;
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00027709 File Offset: 0x00025909
		protected override void OnDetaching()
		{
			base.OnDetaching();
			CompositionTarget.Rendering -= this.CompositionTargetRendering;
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00027724 File Offset: 0x00025924
		private void CompositionTargetRendering(object sender, EventArgs e)
		{
			if (this.KeepDragging)
			{
				this.current = Mouse.GetPosition(this.RotatorParent.Child);
				if (Mouse.LeftButton != MouseButtonState.Pressed)
				{
					this.RotatorParent.RotationY = ((this.RotatorParent.RotationY - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationY - 5.0));
					this.RotatorParent.RotationX = ((this.RotatorParent.RotationX - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationX - 5.0));
					return;
				}
				if (this.current.X > 0.0 && this.current.X < this.attachedElement.ActualWidth && this.current.Y > 0.0 && this.current.Y < this.attachedElement.ActualHeight)
				{
					this.RotatorParent.RotationY = (double)(-1 * this.TiltFactor) + this.current.X * 2.0 * (double)this.TiltFactor / this.attachedElement.ActualWidth;
					this.RotatorParent.RotationX = (double)(-1 * this.TiltFactor) + this.current.Y * 2.0 * (double)this.TiltFactor / this.attachedElement.ActualHeight;
					return;
				}
			}
			else if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				if (!this.isPressed)
				{
					this.current = Mouse.GetPosition(this.RotatorParent.Child);
					if (this.current.X > 0.0 && this.current.X < this.attachedElement.ActualWidth && this.current.Y > 0.0 && this.current.Y < this.attachedElement.ActualHeight)
					{
						this.RotatorParent.RotationY = (double)(-1 * this.TiltFactor) + this.current.X * 2.0 * (double)this.TiltFactor / this.attachedElement.ActualWidth;
						this.RotatorParent.RotationX = (double)(-1 * this.TiltFactor) + this.current.Y * 2.0 * (double)this.TiltFactor / this.attachedElement.ActualHeight;
					}
					this.isPressed = true;
				}
				if (this.isPressed && this.times == 7)
				{
					this.RotatorParent.RotationY = ((this.RotatorParent.RotationY - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationY - 5.0));
					this.RotatorParent.RotationX = ((this.RotatorParent.RotationX - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationX - 5.0));
					return;
				}
				if (this.isPressed && this.times < 7)
				{
					this.times++;
					return;
				}
			}
			else
			{
				this.isPressed = false;
				this.times = -1;
				this.RotatorParent.RotationY = ((this.RotatorParent.RotationY - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationY - 5.0));
				this.RotatorParent.RotationX = ((this.RotatorParent.RotationX - 5.0 < 0.0) ? 0.0 : (this.RotatorParent.RotationX - 5.0));
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00027B65 File Offset: 0x00025D65
		private static Panel GetParentPanel(DependencyObject element)
		{
			return element.TryFindParent<Panel>();
		}

		// Token: 0x0400046F RID: 1135
		public static readonly DependencyProperty KeepDraggingProperty = DependencyProperty.Register("KeepDragging", typeof(bool), typeof(TiltBehavior), new PropertyMetadata(true));

		// Token: 0x04000470 RID: 1136
		public static readonly DependencyProperty TiltFactorProperty = DependencyProperty.Register("TiltFactor", typeof(int), typeof(TiltBehavior), new PropertyMetadata(20));

		// Token: 0x04000471 RID: 1137
		private bool isPressed;

		// Token: 0x04000472 RID: 1138
		private Thickness originalMargin;

		// Token: 0x04000473 RID: 1139
		private Panel originalPanel;

		// Token: 0x04000474 RID: 1140
		private Size originalSize;

		// Token: 0x04000475 RID: 1141
		private FrameworkElement attachedElement;

		// Token: 0x04000476 RID: 1142
		private Point current = new Point(-99.0, -99.0);

		// Token: 0x04000477 RID: 1143
		private int times = -1;
	}
}
