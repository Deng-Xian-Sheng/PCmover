using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000045 RID: 69
	public class DataGridCellHelper
	{
		// Token: 0x060002EF RID: 751 RVA: 0x0000C614 File Offset: 0x0000A814
		private static void CellPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			DataGridCell dataGridCell = dependencyObject as DataGridCell;
			if (dataGridCell != null && e.NewValue != e.OldValue && e.NewValue is bool)
			{
				dataGridCell.Loaded -= DataGridCellHelper.DataGridCellLoaded;
				dataGridCell.Unloaded -= DataGridCellHelper.DataGridCellUnloaded;
				DataGrid value = null;
				if ((bool)e.NewValue)
				{
					value = dataGridCell.TryFindParent<DataGrid>();
					dataGridCell.Loaded += DataGridCellHelper.DataGridCellLoaded;
					dataGridCell.Unloaded += DataGridCellHelper.DataGridCellUnloaded;
				}
				DataGridCellHelper.SetDataGrid(dataGridCell, value);
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000C6B4 File Offset: 0x0000A8B4
		private static void DataGridCellLoaded(object sender, RoutedEventArgs e)
		{
			DataGridCell dataGridCell = (DataGridCell)sender;
			if (DataGridCellHelper.GetDataGrid(dataGridCell) == null)
			{
				DataGrid value = dataGridCell.TryFindParent<DataGrid>();
				DataGridCellHelper.SetDataGrid(dataGridCell, value);
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000C6DE File Offset: 0x0000A8DE
		private static void DataGridCellUnloaded(object sender, RoutedEventArgs e)
		{
			DataGridCellHelper.SetDataGrid((DataGridCell)sender, null);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000C6EC File Offset: 0x0000A8EC
		[AttachedPropertyBrowsableForType(typeof(DataGridCell))]
		[Obsolete("This property will be deleted in the next release.")]
		public static bool GetSaveDataGrid(UIElement element)
		{
			return (bool)element.GetValue(DataGridCellHelper.SaveDataGridProperty);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000C6FE File Offset: 0x0000A8FE
		[Obsolete("This property will be deleted in the next release.")]
		public static void SetSaveDataGrid(UIElement element, bool value)
		{
			element.SetValue(DataGridCellHelper.SaveDataGridProperty, value);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000C711 File Offset: 0x0000A911
		[AttachedPropertyBrowsableForType(typeof(DataGridCell))]
		[Obsolete("This property will be deleted in the next release.")]
		public static DataGrid GetDataGrid(UIElement element)
		{
			return (DataGrid)element.GetValue(DataGridCellHelper.DataGridProperty);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x0000C723 File Offset: 0x0000A923
		[Obsolete("This property will be deleted in the next release.")]
		public static void SetDataGrid(UIElement element, DataGrid value)
		{
			element.SetValue(DataGridCellHelper.DataGridProperty, value);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000C731 File Offset: 0x0000A931
		private static void SelectionUnitOnPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (args.OldValue != args.NewValue)
			{
				DataGridCellHelper.SetIsCellOrRowHeader((DataGridCell)dependencyObject, !object.Equals(args.NewValue, DataGridSelectionUnit.FullRow));
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000C763 File Offset: 0x0000A963
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(DataGridCell))]
		public static DataGridSelectionUnit GetSelectionUnit(UIElement element)
		{
			return (DataGridSelectionUnit)element.GetValue(DataGridCellHelper.SelectionUnitProperty);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0000C775 File Offset: 0x0000A975
		public static void SetSelectionUnit(UIElement element, DataGridSelectionUnit value)
		{
			element.SetValue(DataGridCellHelper.SelectionUnitProperty, value);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x0000C788 File Offset: 0x0000A988
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(DataGridCell))]
		public static bool GetIsCellOrRowHeader(UIElement element)
		{
			return (bool)element.GetValue(DataGridCellHelper.IsCellOrRowHeaderProperty);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x0000C79A File Offset: 0x0000A99A
		internal static void SetIsCellOrRowHeader(UIElement element, bool value)
		{
			element.SetValue(DataGridCellHelper.IsCellOrRowHeaderProperty, value);
		}

		// Token: 0x04000118 RID: 280
		[Obsolete("This property will be deleted in the next release.")]
		public static readonly DependencyProperty SaveDataGridProperty = DependencyProperty.RegisterAttached("SaveDataGrid", typeof(bool), typeof(DataGridCellHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridCellHelper.CellPropertyChangedCallback)));

		// Token: 0x04000119 RID: 281
		[Obsolete("This property will be deleted in the next release.")]
		public static readonly DependencyProperty DataGridProperty = DependencyProperty.RegisterAttached("DataGrid", typeof(DataGrid), typeof(DataGridCellHelper), new FrameworkPropertyMetadata(null));

		// Token: 0x0400011A RID: 282
		public static readonly DependencyProperty SelectionUnitProperty = DependencyProperty.RegisterAttached("SelectionUnit", typeof(DataGridSelectionUnit), typeof(DataGridCellHelper), new FrameworkPropertyMetadata(DataGridSelectionUnit.Cell, new PropertyChangedCallback(DataGridCellHelper.SelectionUnitOnPropertyChangedCallback)));

		// Token: 0x0400011B RID: 283
		public static readonly DependencyProperty IsCellOrRowHeaderProperty = DependencyProperty.RegisterAttached("IsCellOrRowHeader", typeof(bool), typeof(DataGridCellHelper), new FrameworkPropertyMetadata(true));
	}
}
