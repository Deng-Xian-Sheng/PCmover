using System;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000074 RID: 116
	public class PivotItem : ContentControl
	{
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00016E92 File Offset: 0x00015092
		// (set) Token: 0x060005D5 RID: 1493 RVA: 0x00016EA4 File Offset: 0x000150A4
		public string Header
		{
			get
			{
				return (string)base.GetValue(PivotItem.HeaderProperty);
			}
			set
			{
				base.SetValue(PivotItem.HeaderProperty, value);
			}
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00016EB4 File Offset: 0x000150B4
		static PivotItem()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PivotItem), new FrameworkPropertyMetadata(typeof(PivotItem)));
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00016F0D File Offset: 0x0001510D
		public PivotItem()
		{
			base.RequestBringIntoView += delegate(object s, RequestBringIntoViewEventArgs e)
			{
				e.Handled = true;
			};
		}

		// Token: 0x04000246 RID: 582
		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(PivotItem), new PropertyMetadata(null));
	}
}
