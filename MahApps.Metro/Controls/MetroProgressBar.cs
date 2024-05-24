using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000062 RID: 98
	public class MetroProgressBar : ProgressBar
	{
		// Token: 0x06000446 RID: 1094 RVA: 0x00010908 File Offset: 0x0000EB08
		static MetroProgressBar()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroProgressBar), new FrameworkPropertyMetadata(typeof(MetroProgressBar)));
			ProgressBar.IsIndeterminateProperty.OverrideMetadata(typeof(MetroProgressBar), new FrameworkPropertyMetadata(new PropertyChangedCallback(MetroProgressBar.OnIsIndeterminateChanged)));
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x000109C9 File Offset: 0x0000EBC9
		public MetroProgressBar()
		{
			base.IsVisibleChanged += this.VisibleChangedHandler;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x000109EE File Offset: 0x0000EBEE
		private void VisibleChangedHandler(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (base.IsIndeterminate)
			{
				MetroProgressBar.ToggleIndeterminate(this, (bool)e.OldValue, (bool)e.NewValue);
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00010A18 File Offset: 0x0000EC18
		private static void OnIsIndeterminateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			MetroProgressBar metroProgressBar = (MetroProgressBar)dependencyObject;
			if (metroProgressBar.IsLoaded && metroProgressBar.IsVisible)
			{
				MetroProgressBar.ToggleIndeterminate(metroProgressBar, (bool)e.OldValue, (bool)e.NewValue);
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00010A5C File Offset: 0x0000EC5C
		private static void ToggleIndeterminate(MetroProgressBar bar, bool oldValue, bool newValue)
		{
			if (newValue == oldValue)
			{
				return;
			}
			VisualState indeterminateState = bar.GetIndeterminate();
			FrameworkElement containingObject = bar.GetTemplateChild("ContainingGrid") as FrameworkElement;
			if (indeterminateState != null && containingObject != null)
			{
				Action invokeAction = delegate()
				{
					if (oldValue && indeterminateState.Storyboard != null)
					{
						indeterminateState.Storyboard.Stop(containingObject);
						indeterminateState.Storyboard.Remove(containingObject);
					}
					if (newValue)
					{
						bar.ResetStoryboard(bar.ActualSize(true), false);
					}
				};
				bar.Invoke(invokeAction);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x00010AE8 File Offset: 0x0000ECE8
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x00010AFA File Offset: 0x0000ECFA
		public double EllipseDiameter
		{
			get
			{
				return (double)base.GetValue(MetroProgressBar.EllipseDiameterProperty);
			}
			set
			{
				base.SetValue(MetroProgressBar.EllipseDiameterProperty, value);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x00010B0D File Offset: 0x0000ED0D
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x00010B1F File Offset: 0x0000ED1F
		public double EllipseOffset
		{
			get
			{
				return (double)base.GetValue(MetroProgressBar.EllipseOffsetProperty);
			}
			set
			{
				base.SetValue(MetroProgressBar.EllipseOffsetProperty, value);
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00010B34 File Offset: 0x0000ED34
		private void SizeChangedHandler(object sender, SizeChangedEventArgs e)
		{
			double width = this.ActualSize(false);
			if (base.Visibility == Visibility.Visible && base.IsIndeterminate)
			{
				this.ResetStoryboard(width, true);
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00010B64 File Offset: 0x0000ED64
		private double ActualSize(bool invalidateMeasureArrange)
		{
			if (invalidateMeasureArrange)
			{
				base.UpdateLayout();
				base.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
				base.InvalidateArrange();
			}
			if (base.Orientation != Orientation.Horizontal)
			{
				return base.ActualHeight;
			}
			return base.ActualWidth;
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00010BB4 File Offset: 0x0000EDB4
		private void ResetStoryboard(double width, bool removeOldStoryboard)
		{
			if (!base.IsIndeterminate)
			{
				return;
			}
			object obj = this.lockme;
			lock (obj)
			{
				double num = this.CalcContainerAnimStart(width);
				double num2 = this.CalcContainerAnimEnd(width);
				double value = this.CalcEllipseAnimWell(width);
				double value2 = this.CalcEllipseAnimEnd(width);
				try
				{
					VisualState indeterminate = this.GetIndeterminate();
					if (indeterminate != null && this.indeterminateStoryboard != null)
					{
						Storyboard storyboard = this.indeterminateStoryboard.Clone();
						Timeline timeline = storyboard.Children.First((Timeline t) => t.Name == "MainDoubleAnim");
						timeline.SetValue(DoubleAnimation.FromProperty, num);
						timeline.SetValue(DoubleAnimation.ToProperty, num2);
						string[] array = new string[]
						{
							"E1",
							"E2",
							"E3",
							"E4",
							"E5"
						};
						for (int i = 0; i < array.Length; i++)
						{
							string elemName = array[i];
							DoubleAnimationUsingKeyFrames doubleAnimationUsingKeyFrames = (DoubleAnimationUsingKeyFrames)storyboard.Children.First((Timeline t) => t.Name == elemName + "Anim");
							DoubleKeyFrame doubleKeyFrame;
							DoubleKeyFrame doubleKeyFrame2;
							DoubleKeyFrame doubleKeyFrame3;
							if (elemName == "E1")
							{
								doubleKeyFrame = doubleAnimationUsingKeyFrames.KeyFrames[1];
								doubleKeyFrame2 = doubleAnimationUsingKeyFrames.KeyFrames[2];
								doubleKeyFrame3 = doubleAnimationUsingKeyFrames.KeyFrames[3];
							}
							else
							{
								doubleKeyFrame = doubleAnimationUsingKeyFrames.KeyFrames[2];
								doubleKeyFrame2 = doubleAnimationUsingKeyFrames.KeyFrames[3];
								doubleKeyFrame3 = doubleAnimationUsingKeyFrames.KeyFrames[4];
							}
							doubleKeyFrame.Value = value;
							doubleKeyFrame2.Value = value;
							doubleKeyFrame3.Value = value2;
							doubleKeyFrame.InvalidateProperty(DoubleKeyFrame.ValueProperty);
							doubleKeyFrame2.InvalidateProperty(DoubleKeyFrame.ValueProperty);
							doubleKeyFrame3.InvalidateProperty(DoubleKeyFrame.ValueProperty);
							doubleAnimationUsingKeyFrames.InvalidateProperty(Storyboard.TargetPropertyProperty);
							doubleAnimationUsingKeyFrames.InvalidateProperty(Storyboard.TargetNameProperty);
						}
						FrameworkElement containingObject = (FrameworkElement)base.GetTemplateChild("ContainingGrid");
						if (removeOldStoryboard && indeterminate.Storyboard != null)
						{
							indeterminate.Storyboard.Stop(containingObject);
							indeterminate.Storyboard.Remove(containingObject);
						}
						indeterminate.Storyboard = storyboard;
						Storyboard storyboard2 = indeterminate.Storyboard;
						if (storyboard2 != null)
						{
							storyboard2.Begin(containingObject, true);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00010E50 File Offset: 0x0000F050
		private VisualState GetIndeterminate()
		{
			FrameworkElement frameworkElement = base.GetTemplateChild("ContainingGrid") as FrameworkElement;
			if (frameworkElement == null)
			{
				base.ApplyTemplate();
				frameworkElement = (base.GetTemplateChild("ContainingGrid") as FrameworkElement);
				if (frameworkElement == null)
				{
					return null;
				}
			}
			IList visualStateGroups = VisualStateManager.GetVisualStateGroups(frameworkElement);
			if (visualStateGroups == null)
			{
				return null;
			}
			return visualStateGroups.OfType<VisualStateGroup>().SelectMany((VisualStateGroup group) => group.States.OfType<VisualState>()).FirstOrDefault((VisualState state) => state.Name == "Indeterminate");
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00010EE8 File Offset: 0x0000F0E8
		private void SetEllipseDiameter(double width)
		{
			base.SetCurrentValue(MetroProgressBar.EllipseDiameterProperty, (width <= 180.0) ? 4.0 : ((width <= 280.0) ? 5.0 : 6.0));
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00010F3C File Offset: 0x0000F13C
		private void SetEllipseOffset(double width)
		{
			base.SetCurrentValue(MetroProgressBar.EllipseOffsetProperty, (width <= 180.0) ? 4.0 : ((width <= 280.0) ? 7.0 : 9.0));
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00010F90 File Offset: 0x0000F190
		private double CalcContainerAnimStart(double width)
		{
			if (width <= 180.0)
			{
				return -34.0;
			}
			if (width > 280.0)
			{
				return -63.0;
			}
			return -50.5;
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x00010FC8 File Offset: 0x0000F1C8
		private double CalcContainerAnimEnd(double width)
		{
			double num = 0.4352 * width;
			if (width <= 180.0)
			{
				return num - 25.731;
			}
			if (width > 280.0)
			{
				return num + 58.862;
			}
			return num + 27.84;
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0001101C File Offset: 0x0000F21C
		private double CalcEllipseAnimWell(double width)
		{
			return width * 1.0 / 3.0;
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00011033 File Offset: 0x0000F233
		private double CalcEllipseAnimEnd(double width)
		{
			return width * 2.0 / 3.0;
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001104C File Offset: 0x0000F24C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			object obj = this.lockme;
			lock (obj)
			{
				this.indeterminateStoryboard = (base.TryFindResource("IndeterminateStoryboard") as Storyboard);
			}
			base.Loaded -= this.LoadedHandler;
			base.Loaded += this.LoadedHandler;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x000110C8 File Offset: 0x0000F2C8
		private void LoadedHandler(object sender, RoutedEventArgs routedEventArgs)
		{
			base.Loaded -= this.LoadedHandler;
			this.SizeChangedHandler(null, null);
			base.SizeChanged += this.SizeChangedHandler;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x000110F6 File Offset: 0x0000F2F6
		protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
		{
			base.OnRenderSizeChanged(sizeInfo);
			this.UpdateEllipseProperties();
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00011108 File Offset: 0x0000F308
		private void UpdateEllipseProperties()
		{
			double num = this.ActualSize(true);
			if (num > 0.0)
			{
				if (this.EllipseDiameter.Equals(0.0))
				{
					this.SetEllipseDiameter(num);
				}
				if (this.EllipseOffset.Equals(0.0))
				{
					this.SetEllipseOffset(num);
				}
			}
		}

		// Token: 0x0400019E RID: 414
		public static readonly DependencyProperty EllipseDiameterProperty = DependencyProperty.Register("EllipseDiameter", typeof(double), typeof(MetroProgressBar), new PropertyMetadata(0.0));

		// Token: 0x0400019F RID: 415
		public static readonly DependencyProperty EllipseOffsetProperty = DependencyProperty.Register("EllipseOffset", typeof(double), typeof(MetroProgressBar), new PropertyMetadata(0.0));

		// Token: 0x040001A0 RID: 416
		private readonly object lockme = new object();

		// Token: 0x040001A1 RID: 417
		private Storyboard indeterminateStoryboard;
	}
}
