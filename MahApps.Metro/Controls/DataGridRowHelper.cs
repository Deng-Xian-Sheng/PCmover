using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000047 RID: 71
	public static class DataGridRowHelper
	{
		// Token: 0x06000304 RID: 772 RVA: 0x0000CB52 File Offset: 0x0000AD52
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(DataGridRow))]
		public static DataGridSelectionUnit GetSelectionUnit(UIElement element)
		{
			return (DataGridSelectionUnit)element.GetValue(DataGridRowHelper.SelectionUnitProperty);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000CB64 File Offset: 0x0000AD64
		public static void SetSelectionUnit(UIElement element, DataGridSelectionUnit value)
		{
			element.SetValue(DataGridRowHelper.SelectionUnitProperty, value);
		}

		// Token: 0x0400011E RID: 286
		public static readonly DependencyProperty SelectionUnitProperty = DependencyProperty.RegisterAttached("SelectionUnit", typeof(DataGridSelectionUnit), typeof(DataGridRowHelper), new FrameworkPropertyMetadata(DataGridSelectionUnit.FullRow));
	}
}
