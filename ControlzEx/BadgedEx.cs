using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlzEx
{
	// Token: 0x02000003 RID: 3
	[TemplatePart(Name = "PART_BadgeContainer", Type = typeof(UIElement))]
	public class BadgedEx : ContentControl
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x0000205D File Offset: 0x0000025D
		public object Badge
		{
			get
			{
				return base.GetValue(BadgedEx.BadgeProperty);
			}
			set
			{
				base.SetValue(BadgedEx.BadgeProperty, value);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000206B File Offset: 0x0000026B
		// (set) Token: 0x06000004 RID: 4 RVA: 0x0000207D File Offset: 0x0000027D
		public Brush BadgeBackground
		{
			get
			{
				return (Brush)base.GetValue(BadgedEx.BadgeBackgroundProperty);
			}
			set
			{
				base.SetValue(BadgedEx.BadgeBackgroundProperty, value);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000208B File Offset: 0x0000028B
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000209D File Offset: 0x0000029D
		public Brush BadgeForeground
		{
			get
			{
				return (Brush)base.GetValue(BadgedEx.BadgeForegroundProperty);
			}
			set
			{
				base.SetValue(BadgedEx.BadgeForegroundProperty, value);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020AB File Offset: 0x000002AB
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020BD File Offset: 0x000002BD
		public BadgePlacementMode BadgePlacementMode
		{
			get
			{
				return (BadgePlacementMode)base.GetValue(BadgedEx.BadgePlacementModeProperty);
			}
			set
			{
				base.SetValue(BadgedEx.BadgePlacementModeProperty, value);
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000009 RID: 9 RVA: 0x000020D0 File Offset: 0x000002D0
		// (remove) Token: 0x0600000A RID: 10 RVA: 0x000020DE File Offset: 0x000002DE
		public event RoutedPropertyChangedEventHandler<object> BadgeChanged
		{
			add
			{
				base.AddHandler(BadgedEx.BadgeChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(BadgedEx.BadgeChangedEvent, value);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020EC File Offset: 0x000002EC
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020FE File Offset: 0x000002FE
		public bool IsBadgeSet
		{
			get
			{
				return (bool)base.GetValue(BadgedEx.IsBadgeSetProperty);
			}
			private set
			{
				base.SetValue(BadgedEx.IsBadgeSetPropertyKey, value);
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002114 File Offset: 0x00000314
		private static void OnBadgeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			BadgedEx badgedEx = (BadgedEx)d;
			badgedEx.IsBadgeSet = (!string.IsNullOrWhiteSpace(e.NewValue as string) || (e.NewValue != null && !(e.NewValue is string)));
			RoutedPropertyChangedEventArgs<object> e2 = new RoutedPropertyChangedEventArgs<object>(e.OldValue, e.NewValue)
			{
				RoutedEvent = BadgedEx.BadgeChangedEvent
			};
			badgedEx.RaiseEvent(e2);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002186 File Offset: 0x00000386
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this._badgeContainer = (base.GetTemplateChild("PART_BadgeContainer") as FrameworkElement);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021A4 File Offset: 0x000003A4
		protected override Size ArrangeOverride(Size arrangeBounds)
		{
			Size result = base.ArrangeOverride(arrangeBounds);
			if (this._badgeContainer == null)
			{
				return result;
			}
			Size desiredSize = this._badgeContainer.DesiredSize;
			if ((desiredSize.Width <= 0.0 || desiredSize.Height <= 0.0) && !double.IsNaN(this._badgeContainer.ActualWidth) && !double.IsInfinity(this._badgeContainer.ActualWidth) && !double.IsNaN(this._badgeContainer.ActualHeight) && !double.IsInfinity(this._badgeContainer.ActualHeight))
			{
				desiredSize = new Size(this._badgeContainer.ActualWidth, this._badgeContainer.ActualHeight);
			}
			double num = 0.0 - desiredSize.Width / 2.0;
			double num2 = 0.0 - desiredSize.Height / 2.0;
			this._badgeContainer.Margin = new Thickness(0.0);
			this._badgeContainer.Margin = new Thickness(num, num2, num, num2);
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022C8 File Offset: 0x000004C8
		// Note: this type is marked as 'beforefieldinit'.
		static BadgedEx()
		{
			BadgedEx.BadgeChangedEvent = EventManager.RegisterRoutedEvent("BadgeChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(BadgedEx));
			BadgedEx.IsBadgeSetPropertyKey = DependencyProperty.RegisterReadOnly("IsBadgeSet", typeof(bool), typeof(BadgedEx), new PropertyMetadata(false));
			BadgedEx.IsBadgeSetProperty = BadgedEx.IsBadgeSetPropertyKey.DependencyProperty;
		}

		// Token: 0x0400000A RID: 10
		public const string BadgeContainerPartName = "PART_BadgeContainer";

		// Token: 0x0400000B RID: 11
		protected FrameworkElement _badgeContainer;

		// Token: 0x0400000C RID: 12
		public static readonly DependencyProperty BadgeProperty = DependencyProperty.Register("Badge", typeof(object), typeof(BadgedEx), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange, new PropertyChangedCallback(BadgedEx.OnBadgeChanged)));

		// Token: 0x0400000D RID: 13
		public static readonly DependencyProperty BadgeBackgroundProperty = DependencyProperty.Register("BadgeBackground", typeof(Brush), typeof(BadgedEx), new PropertyMetadata(null));

		// Token: 0x0400000E RID: 14
		public static readonly DependencyProperty BadgeForegroundProperty = DependencyProperty.Register("BadgeForeground", typeof(Brush), typeof(BadgedEx), new PropertyMetadata(null));

		// Token: 0x0400000F RID: 15
		public static readonly DependencyProperty BadgePlacementModeProperty = DependencyProperty.Register("BadgePlacementMode", typeof(BadgePlacementMode), typeof(BadgedEx), new PropertyMetadata(BadgePlacementMode.TopLeft));

		// Token: 0x04000011 RID: 17
		private static readonly DependencyPropertyKey IsBadgeSetPropertyKey;

		// Token: 0x04000012 RID: 18
		public static readonly DependencyProperty IsBadgeSetProperty;
	}
}
