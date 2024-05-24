using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000046 RID: 70
	public static class DataGridHelper
	{
		// Token: 0x060002FD RID: 765 RVA: 0x0000C890 File Offset: 0x0000AA90
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(DataGrid))]
		public static bool GetEnableCellEditAssist(DependencyObject element)
		{
			return (bool)element.GetValue(DataGridHelper.EnableCellEditAssistProperty);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0000C8A2 File Offset: 0x0000AAA2
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(DataGrid))]
		public static void SetEnableCellEditAssist(DependencyObject element, bool value)
		{
			element.SetValue(DataGridHelper.EnableCellEditAssistProperty, value);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000C8B8 File Offset: 0x0000AAB8
		private static void EnableCellEditAssistPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = d as DataGrid;
			if (dataGrid == null)
			{
				return;
			}
			dataGrid.PreviewMouseLeftButtonDown -= DataGridHelper.DataGridOnPreviewMouseLeftButtonDown;
			if ((bool)e.NewValue)
			{
				dataGrid.PreviewMouseLeftButtonDown += DataGridHelper.DataGridOnPreviewMouseLeftButtonDown;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0000C904 File Offset: 0x0000AB04
		private static void DataGridOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;
			DependencyObject dependencyObject = dataGrid.InputHitTest(e.GetPosition((DataGrid)sender)) as DependencyObject;
			while (dependencyObject != null)
			{
				DataGridCell dataGridCell = dependencyObject as DataGridCell;
				if (dataGridCell != null && dataGrid.Equals(dataGridCell.TryFindParent<DataGrid>()))
				{
					if (dataGridCell.IsReadOnly)
					{
						return;
					}
					ToggleButton toggleButton;
					if (DataGridHelper.IsDirectHitOnEditComponent<ToggleButton>(dataGridCell, e, out toggleButton))
					{
						dataGrid.CurrentCell = new DataGridCellInfo(dataGridCell);
						dataGrid.BeginEdit();
						toggleButton.SetCurrentValue(ToggleButton.IsCheckedProperty, !toggleButton.IsChecked);
						dataGrid.CommitEdit();
						e.Handled = true;
						return;
					}
					ComboBox comboBox;
					if (DataGridHelper.IsDirectHitOnEditComponent<ComboBox>(dataGridCell, e, out comboBox))
					{
						if (DataGridHelper._suppressComboAutoDropDown != null)
						{
							return;
						}
						dataGrid.CurrentCell = new DataGridCellInfo(dataGridCell);
						dataGrid.BeginEdit();
						if (DataGridHelper.IsDirectHitOnEditComponent<ComboBox>(dataGridCell, e, out comboBox))
						{
							DataGridHelper._suppressComboAutoDropDown = dataGrid;
							comboBox.DropDownClosed += DataGridHelper.ComboBoxOnDropDownClosed;
							comboBox.IsDropDownOpen = true;
						}
						e.Handled = true;
					}
					return;
				}
				else
				{
					dependencyObject = ((dependencyObject is Visual || dependencyObject is Visual3D) ? VisualTreeHelper.GetParent(dependencyObject) : null);
				}
			}
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000CA3F File Offset: 0x0000AC3F
		private static void ComboBoxOnDropDownClosed(object sender, EventArgs eventArgs)
		{
			DataGridHelper._suppressComboAutoDropDown.CommitEdit();
			DataGridHelper._suppressComboAutoDropDown = null;
			((ComboBox)sender).DropDownClosed -= DataGridHelper.ComboBoxOnDropDownClosed;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0000CA6C File Offset: 0x0000AC6C
		private static bool IsDirectHitOnEditComponent<TControl>(ContentControl contentControl, MouseEventArgs e, out TControl control) where TControl : Control
		{
			control = (contentControl.Content as TControl);
			if (control == null)
			{
				return false;
			}
			FrameworkElement frameworkElement = VisualTreeHelper.GetChild(contentControl, 0) as FrameworkElement;
			if (frameworkElement == null)
			{
				return false;
			}
			MatrixTransform matrixTransform = (MatrixTransform)control.TransformToAncestor(frameworkElement);
			Rect rect = new Rect(new Point(matrixTransform.Value.OffsetX, matrixTransform.Value.OffsetY), new Size(control.ActualWidth, control.ActualHeight));
			return rect.Contains(e.GetPosition(frameworkElement));
		}

		// Token: 0x0400011C RID: 284
		private static DataGrid _suppressComboAutoDropDown;

		// Token: 0x0400011D RID: 285
		public static readonly DependencyProperty EnableCellEditAssistProperty = DependencyProperty.RegisterAttached("EnableCellEditAssist", typeof(bool), typeof(DataGridHelper), new PropertyMetadata(false, new PropertyChangedCallback(DataGridHelper.EnableCellEditAssistPropertyChangedCallback)));
	}
}
