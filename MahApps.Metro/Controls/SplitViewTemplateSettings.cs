using System;
using System.Windows;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000088 RID: 136
	public sealed class SplitViewTemplateSettings : DependencyObject
	{
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x0001D521 File Offset: 0x0001B721
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x0001D533 File Offset: 0x0001B733
		public GridLength CompactPaneGridLength
		{
			get
			{
				return (GridLength)base.GetValue(SplitViewTemplateSettings.CompactPaneGridLengthProperty);
			}
			private set
			{
				base.SetValue(SplitViewTemplateSettings.CompactPaneGridLengthProperty, value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x0001D546 File Offset: 0x0001B746
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x0001D558 File Offset: 0x0001B758
		public double NegativeOpenPaneLength
		{
			get
			{
				return (double)base.GetValue(SplitViewTemplateSettings.NegativeOpenPaneLengthProperty);
			}
			private set
			{
				base.SetValue(SplitViewTemplateSettings.NegativeOpenPaneLengthProperty, value);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x0001D56B File Offset: 0x0001B76B
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x0001D57D File Offset: 0x0001B77D
		public double NegativeOpenPaneLengthMinusCompactLength
		{
			get
			{
				return (double)base.GetValue(SplitViewTemplateSettings.NegativeOpenPaneLengthMinusCompactLengthProperty);
			}
			set
			{
				base.SetValue(SplitViewTemplateSettings.NegativeOpenPaneLengthMinusCompactLengthProperty, value);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x0001D590 File Offset: 0x0001B790
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x0001D5A2 File Offset: 0x0001B7A2
		public GridLength OpenPaneGridLength
		{
			get
			{
				return (GridLength)base.GetValue(SplitViewTemplateSettings.OpenPaneGridLengthProperty);
			}
			private set
			{
				base.SetValue(SplitViewTemplateSettings.OpenPaneGridLengthProperty, value);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x0001D5B5 File Offset: 0x0001B7B5
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x0001D5C7 File Offset: 0x0001B7C7
		public double OpenPaneLength
		{
			get
			{
				return (double)base.GetValue(SplitViewTemplateSettings.OpenPaneLengthProperty);
			}
			private set
			{
				base.SetValue(SplitViewTemplateSettings.OpenPaneLengthProperty, value);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x0001D5DA File Offset: 0x0001B7DA
		// (set) Token: 0x0600072D RID: 1837 RVA: 0x0001D5EC File Offset: 0x0001B7EC
		public double OpenPaneLengthMinusCompactLength
		{
			get
			{
				return (double)base.GetValue(SplitViewTemplateSettings.OpenPaneLengthMinusCompactLengthProperty);
			}
			private set
			{
				base.SetValue(SplitViewTemplateSettings.OpenPaneLengthMinusCompactLengthProperty, value);
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x0001D5FF File Offset: 0x0001B7FF
		internal SplitViewTemplateSettings(SplitView owner)
		{
			this.Owner = owner;
			this.Update();
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001D614 File Offset: 0x0001B814
		internal SplitView Owner { get; }

		// Token: 0x06000730 RID: 1840 RVA: 0x0001D61C File Offset: 0x0001B81C
		internal void Update()
		{
			this.CompactPaneGridLength = new GridLength(this.Owner.CompactPaneLength, GridUnitType.Pixel);
			this.OpenPaneGridLength = new GridLength(this.Owner.OpenPaneLength, GridUnitType.Pixel);
			this.OpenPaneLength = this.Owner.OpenPaneLength;
			this.OpenPaneLengthMinusCompactLength = this.Owner.OpenPaneLength - this.Owner.CompactPaneLength;
			this.NegativeOpenPaneLength = -this.OpenPaneLength;
			this.NegativeOpenPaneLengthMinusCompactLength = -this.OpenPaneLengthMinusCompactLength;
		}

		// Token: 0x040002E6 RID: 742
		internal static readonly DependencyProperty CompactPaneGridLengthProperty = DependencyProperty.Register("CompactPaneGridLength", typeof(GridLength), typeof(SplitViewTemplateSettings), new PropertyMetadata(null));

		// Token: 0x040002E7 RID: 743
		internal static readonly DependencyProperty NegativeOpenPaneLengthProperty = DependencyProperty.Register("NegativeOpenPaneLength", typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0.0));

		// Token: 0x040002E8 RID: 744
		internal static readonly DependencyProperty NegativeOpenPaneLengthMinusCompactLengthProperty = DependencyProperty.Register("NegativeOpenPaneLengthMinusCompactLength", typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0.0));

		// Token: 0x040002E9 RID: 745
		internal static readonly DependencyProperty OpenPaneGridLengthProperty = DependencyProperty.Register("OpenPaneGridLength", typeof(GridLength), typeof(SplitViewTemplateSettings), new PropertyMetadata(null));

		// Token: 0x040002EA RID: 746
		internal static readonly DependencyProperty OpenPaneLengthProperty = DependencyProperty.Register("OpenPaneLength", typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0.0));

		// Token: 0x040002EB RID: 747
		internal static readonly DependencyProperty OpenPaneLengthMinusCompactLengthProperty = DependencyProperty.Register("OpenPaneLengthMinusCompactLength", typeof(double), typeof(SplitViewTemplateSettings), new PropertyMetadata(0.0));
	}
}
