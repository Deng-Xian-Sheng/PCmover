using System;
using System.Windows;
using System.Windows.Controls;
using ControlzEx;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200009B RID: 155
	[TemplatePart(Name = "PART_ContentPresenter", Type = typeof(UIElement))]
	[TemplatePart(Name = "PART_Separator", Type = typeof(UIElement))]
	public class WindowCommandsItem : ContentControl
	{
		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x000227A1 File Offset: 0x000209A1
		// (set) Token: 0x06000886 RID: 2182 RVA: 0x000227A9 File Offset: 0x000209A9
		internal PropertyChangeNotifier VisibilityPropertyChangeNotifier { get; set; }

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x000227B2 File Offset: 0x000209B2
		// (set) Token: 0x06000888 RID: 2184 RVA: 0x000227C4 File Offset: 0x000209C4
		public bool IsSeparatorVisible
		{
			get
			{
				return (bool)base.GetValue(WindowCommandsItem.IsSeparatorVisibleProperty);
			}
			set
			{
				base.SetValue(WindowCommandsItem.IsSeparatorVisibleProperty, value);
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x000227D8 File Offset: 0x000209D8
		static WindowCommandsItem()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowCommandsItem), new FrameworkPropertyMetadata(typeof(WindowCommandsItem)));
		}

		// Token: 0x040003DC RID: 988
		private const string PART_ContentPresenter = "PART_ContentPresenter";

		// Token: 0x040003DD RID: 989
		private const string PART_Separator = "PART_Separator";

		// Token: 0x040003DF RID: 991
		public static readonly DependencyProperty IsSeparatorVisibleProperty = DependencyProperty.Register("IsSeparatorVisible", typeof(bool), typeof(WindowCommandsItem), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));
	}
}
