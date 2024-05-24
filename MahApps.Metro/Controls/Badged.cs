using System;
using System.Windows;
using System.Windows.Media.Animation;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000023 RID: 35
	[TemplatePart(Name = "PART_BadgeContainer", Type = typeof(UIElement))]
	public class Badged : BadgedEx
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003CCF File Offset: 0x00001ECF
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003CE1 File Offset: 0x00001EE1
		public Storyboard BadgeChangedStoryboard
		{
			get
			{
				return (Storyboard)base.GetValue(Badged.BadgeChangedStoryboardProperty);
			}
			set
			{
				base.SetValue(Badged.BadgeChangedStoryboardProperty, value);
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003CF0 File Offset: 0x00001EF0
		static Badged()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Badged), new FrameworkPropertyMetadata(typeof(Badged)));
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003D49 File Offset: 0x00001F49
		public override void OnApplyTemplate()
		{
			base.BadgeChanged -= this.OnBadgeChanged;
			base.OnApplyTemplate();
			base.BadgeChanged += this.OnBadgeChanged;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003D78 File Offset: 0x00001F78
		private void OnBadgeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			Storyboard badgeChangedStoryboard = this.BadgeChangedStoryboard;
			if (this._badgeContainer != null && badgeChangedStoryboard != null)
			{
				try
				{
					this._badgeContainer.BeginStoryboard(badgeChangedStoryboard);
				}
				catch (Exception innerException)
				{
					throw new MahAppsException("Uups, it seems like there is something wrong with the given Storyboard.", innerException);
				}
			}
		}

		// Token: 0x0400002D RID: 45
		public static readonly DependencyProperty BadgeChangedStoryboardProperty = DependencyProperty.Register("BadgeChangedStoryboard", typeof(Storyboard), typeof(Badged), new PropertyMetadata(null));
	}
}
