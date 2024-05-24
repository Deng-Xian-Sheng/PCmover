using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000065 RID: 101
	public class MetroTabItem : TabItem
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x00011429 File Offset: 0x0000F629
		public MetroTabItem()
		{
			base.DefaultStyleKey = typeof(MetroTabItem);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00011441 File Offset: 0x0000F641
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00011453 File Offset: 0x0000F653
		public bool CloseButtonEnabled
		{
			get
			{
				return (bool)base.GetValue(MetroTabItem.CloseButtonEnabledProperty);
			}
			set
			{
				base.SetValue(MetroTabItem.CloseButtonEnabledProperty, value);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x00011466 File Offset: 0x0000F666
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00011478 File Offset: 0x0000F678
		public ICommand CloseTabCommand
		{
			get
			{
				return (ICommand)base.GetValue(MetroTabItem.CloseTabCommandProperty);
			}
			set
			{
				base.SetValue(MetroTabItem.CloseTabCommandProperty, value);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00011486 File Offset: 0x0000F686
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x00011493 File Offset: 0x0000F693
		public object CloseTabCommandParameter
		{
			get
			{
				return base.GetValue(MetroTabItem.CloseTabCommandParameterProperty);
			}
			set
			{
				base.SetValue(MetroTabItem.CloseTabCommandParameterProperty, value);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x000114A1 File Offset: 0x0000F6A1
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x000114B3 File Offset: 0x0000F6B3
		public Thickness CloseButtonMargin
		{
			get
			{
				return (Thickness)base.GetValue(MetroTabItem.CloseButtonMarginProperty);
			}
			set
			{
				base.SetValue(MetroTabItem.CloseButtonMarginProperty, value);
			}
		}

		// Token: 0x040001A5 RID: 421
		public static readonly DependencyProperty CloseButtonEnabledProperty = DependencyProperty.Register("CloseButtonEnabled", typeof(bool), typeof(MetroTabItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x040001A6 RID: 422
		public static readonly DependencyProperty CloseTabCommandProperty = DependencyProperty.Register("CloseTabCommand", typeof(ICommand), typeof(MetroTabItem));

		// Token: 0x040001A7 RID: 423
		public static readonly DependencyProperty CloseTabCommandParameterProperty = DependencyProperty.Register("CloseTabCommandParameter", typeof(object), typeof(MetroTabItem), new PropertyMetadata(null));

		// Token: 0x040001A8 RID: 424
		public static readonly DependencyProperty CloseButtonMarginProperty = DependencyProperty.Register("CloseButtonMargin", typeof(Thickness), typeof(MetroTabItem), new FrameworkPropertyMetadata(default(Thickness), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));
	}
}
