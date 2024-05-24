using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200002C RID: 44
	public class DataGridNumericUpDownColumn : DataGridBoundColumn
	{
		// Token: 0x0600010B RID: 267 RVA: 0x000059D0 File Offset: 0x00003BD0
		static DataGridNumericUpDownColumn()
		{
			DataGridBoundColumn.ElementStyleProperty.OverrideMetadata(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(DataGridNumericUpDownColumn.DefaultElementStyle));
			DataGridBoundColumn.EditingElementStyleProperty.OverrideMetadata(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(DataGridNumericUpDownColumn.DefaultEditingElementStyle));
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00005CB8 File Offset: 0x00003EB8
		public static Style DefaultEditingElementStyle
		{
			get
			{
				if (DataGridNumericUpDownColumn._defaultEditingElementStyle == null)
				{
					Style style = new Style(typeof(NumericUpDown));
					style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0.0)));
					style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(0.0)));
					style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top));
					style.Setters.Add(new Setter(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled));
					style.Setters.Add(new Setter(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled));
					style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
					style.Setters.Add(new Setter(FrameworkElement.MinHeightProperty, 0.0));
					style.Seal();
					DataGridNumericUpDownColumn._defaultEditingElementStyle = style;
				}
				return DataGridNumericUpDownColumn._defaultEditingElementStyle;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00005DD0 File Offset: 0x00003FD0
		public static Style DefaultElementStyle
		{
			get
			{
				if (DataGridNumericUpDownColumn._defaultElementStyle == null)
				{
					Style style = new Style(typeof(NumericUpDown));
					style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0.0)));
					style.Setters.Add(new Setter(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Top));
					style.Setters.Add(new Setter(UIElement.IsHitTestVisibleProperty, false));
					style.Setters.Add(new Setter(UIElement.FocusableProperty, false));
					style.Setters.Add(new Setter(NumericUpDown.HideUpDownButtonsProperty, true));
					style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Transparent));
					style.Setters.Add(new Setter(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled));
					style.Setters.Add(new Setter(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled));
					style.Setters.Add(new Setter(Control.VerticalContentAlignmentProperty, VerticalAlignment.Center));
					style.Setters.Add(new Setter(FrameworkElement.MinHeightProperty, 0.0));
					style.Setters.Add(new Setter(ControlsHelper.DisabledVisualElementVisibilityProperty, Visibility.Collapsed));
					style.Seal();
					DataGridNumericUpDownColumn._defaultElementStyle = style;
				}
				return DataGridNumericUpDownColumn._defaultElementStyle;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00005F43 File Offset: 0x00004143
		private static void ApplyBinding(BindingBase binding, DependencyObject target, DependencyProperty property)
		{
			if (binding != null)
			{
				BindingOperations.SetBinding(target, property, binding);
				return;
			}
			BindingOperations.ClearBinding(target, property);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00005F5C File Offset: 0x0000415C
		private void ApplyStyle(bool isEditing, bool defaultToElementStyle, FrameworkElement element)
		{
			Style style = this.PickStyle(isEditing, defaultToElementStyle);
			if (style != null)
			{
				element.Style = style;
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005F7C File Offset: 0x0000417C
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			return this.GenerateNumericUpDown(true, cell);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00005F86 File Offset: 0x00004186
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			NumericUpDown numericUpDown = this.GenerateNumericUpDown(false, cell);
			numericUpDown.HideUpDownButtons = true;
			return numericUpDown;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00005F98 File Offset: 0x00004198
		private NumericUpDown GenerateNumericUpDown(bool isEditing, DataGridCell cell)
		{
			NumericUpDown numericUpDown = (cell != null) ? (cell.Content as NumericUpDown) : null;
			if (numericUpDown == null)
			{
				numericUpDown = new NumericUpDown();
			}
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontFamilyProperty, TextElement.FontFamilyProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontSizeProperty, TextElement.FontSizeProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontStyleProperty, TextElement.FontStyleProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontWeightProperty, TextElement.FontWeightProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.StringFormatProperty, NumericUpDown.StringFormatProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.MinimumProperty, NumericUpDown.MinimumProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.MaximumProperty, NumericUpDown.MaximumProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.IntervalProperty, NumericUpDown.IntervalProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.HideUpDownButtonsProperty, NumericUpDown.HideUpDownButtonsProperty);
			DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.UpDownButtonsWidthProperty, NumericUpDown.UpDownButtonsWidthProperty);
			if (isEditing)
			{
				DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.ForegroundProperty, TextElement.ForegroundProperty);
			}
			else if (!DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.ForegroundProperty, TextElement.ForegroundProperty))
			{
				DataGridNumericUpDownColumn.ApplyBinding(new Binding(Control.ForegroundProperty.Name)
				{
					Source = cell,
					Mode = BindingMode.OneWay
				}, numericUpDown, TextElement.ForegroundProperty);
			}
			this.ApplyStyle(isEditing, true, numericUpDown);
			DataGridNumericUpDownColumn.ApplyBinding(this.Binding, numericUpDown, NumericUpDown.ValueProperty);
			numericUpDown.InterceptArrowKeys = true;
			numericUpDown.InterceptMouseWheel = true;
			numericUpDown.Speedup = true;
			return numericUpDown;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000060F8 File Offset: 0x000042F8
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			NumericUpDown numericUpDown = editingElement as NumericUpDown;
			if (numericUpDown != null)
			{
				numericUpDown.Focus();
				numericUpDown.SelectAll();
				return numericUpDown.Value;
			}
			return null;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006129 File Offset: 0x00004329
		internal static bool SyncColumnProperty(DependencyObject column, DependencyObject content, DependencyProperty columnProperty, DependencyProperty contentProperty)
		{
			if (DataGridNumericUpDownColumn.IsDefaultValue(column, columnProperty))
			{
				content.ClearValue(contentProperty);
				return false;
			}
			content.SetValue(contentProperty, column.GetValue(columnProperty));
			return true;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000614C File Offset: 0x0000434C
		private static bool IsDefaultValue(DependencyObject d, DependencyProperty dp)
		{
			return DependencyPropertyHelper.GetValueSource(d, dp).BaseValueSource == BaseValueSource.Default;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000616C File Offset: 0x0000436C
		private Style PickStyle(bool isEditing, bool defaultToElementStyle)
		{
			Style style = isEditing ? base.EditingElementStyle : base.ElementStyle;
			if (isEditing && defaultToElementStyle && style == null)
			{
				style = base.ElementStyle;
			}
			return style;
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000117 RID: 279 RVA: 0x0000619B File Offset: 0x0000439B
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000061AD File Offset: 0x000043AD
		public string StringFormat
		{
			get
			{
				return (string)base.GetValue(DataGridNumericUpDownColumn.StringFormatProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.StringFormatProperty, value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000119 RID: 281 RVA: 0x000061BB File Offset: 0x000043BB
		// (set) Token: 0x0600011A RID: 282 RVA: 0x000061CD File Offset: 0x000043CD
		public double Minimum
		{
			get
			{
				return (double)base.GetValue(DataGridNumericUpDownColumn.MinimumProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.MinimumProperty, value);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600011B RID: 283 RVA: 0x000061E0 File Offset: 0x000043E0
		// (set) Token: 0x0600011C RID: 284 RVA: 0x000061F2 File Offset: 0x000043F2
		public double Maximum
		{
			get
			{
				return (double)base.GetValue(DataGridNumericUpDownColumn.MaximumProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.MaximumProperty, value);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00006205 File Offset: 0x00004405
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00006217 File Offset: 0x00004417
		public double Interval
		{
			get
			{
				return (double)base.GetValue(DataGridNumericUpDownColumn.IntervalProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.IntervalProperty, value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000622A File Offset: 0x0000442A
		// (set) Token: 0x06000120 RID: 288 RVA: 0x0000623C File Offset: 0x0000443C
		public bool HideUpDownButtons
		{
			get
			{
				return (bool)base.GetValue(DataGridNumericUpDownColumn.HideUpDownButtonsProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.HideUpDownButtonsProperty, value);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0000624F File Offset: 0x0000444F
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00006261 File Offset: 0x00004461
		public double UpDownButtonsWidth
		{
			get
			{
				return (double)base.GetValue(DataGridNumericUpDownColumn.UpDownButtonsWidthProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.UpDownButtonsWidthProperty, value);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00006274 File Offset: 0x00004474
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00006286 File Offset: 0x00004486
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(DataGridNumericUpDownColumn.FontFamilyProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.FontFamilyProperty, value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00006294 File Offset: 0x00004494
		// (set) Token: 0x06000126 RID: 294 RVA: 0x000062A6 File Offset: 0x000044A6
		[TypeConverter(typeof(FontSizeConverter))]
		[Localizability(LocalizationCategory.None)]
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(DataGridNumericUpDownColumn.FontSizeProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.FontSizeProperty, value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000127 RID: 295 RVA: 0x000062B9 File Offset: 0x000044B9
		// (set) Token: 0x06000128 RID: 296 RVA: 0x000062CB File Offset: 0x000044CB
		public FontStyle FontStyle
		{
			get
			{
				return (FontStyle)base.GetValue(DataGridNumericUpDownColumn.FontStyleProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.FontStyleProperty, value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000129 RID: 297 RVA: 0x000062DE File Offset: 0x000044DE
		// (set) Token: 0x0600012A RID: 298 RVA: 0x000062F0 File Offset: 0x000044F0
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(DataGridNumericUpDownColumn.FontWeightProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.FontWeightProperty, value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00006303 File Offset: 0x00004503
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00006315 File Offset: 0x00004515
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(DataGridNumericUpDownColumn.ForegroundProperty);
			}
			set
			{
				base.SetValue(DataGridNumericUpDownColumn.ForegroundProperty, value);
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006323 File Offset: 0x00004523
		private static void NotifyPropertyChangeForRefreshContent(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGridNumericUpDownColumn)d).NotifyPropertyChanged(e.Property.Name);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000633C File Offset: 0x0000453C
		protected override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			NumericUpDown numericUpDown = ((dataGridCell != null) ? dataGridCell.Content : null) as NumericUpDown;
			if (numericUpDown != null)
			{
				uint num = <PrivateImplementationDetails>.ComputeStringHash(propertyName);
				if (num <= 2724873441U)
				{
					if (num <= 491939769U)
					{
						if (num != 438536855U)
						{
							if (num == 491939769U)
							{
								if (propertyName == "HideUpDownButtons")
								{
									DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.HideUpDownButtonsProperty, NumericUpDown.HideUpDownButtonsProperty);
								}
							}
						}
						else if (propertyName == "Minimum")
						{
							DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.MinimumProperty, NumericUpDown.MinimumProperty);
						}
					}
					else if (num != 1528496667U)
					{
						if (num != 1813401013U)
						{
							if (num == 2724873441U)
							{
								if (propertyName == "FontSize")
								{
									DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontSizeProperty, TextElement.FontSizeProperty);
								}
							}
						}
						else if (propertyName == "FontStyle")
						{
							DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontStyleProperty, TextElement.FontStyleProperty);
						}
					}
					else if (propertyName == "StringFormat")
					{
						DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.StringFormatProperty, NumericUpDown.StringFormatProperty);
					}
				}
				else if (num <= 3684776344U)
				{
					if (num != 3496045264U)
					{
						if (num == 3684776344U)
						{
							if (propertyName == "Interval")
							{
								DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.IntervalProperty, NumericUpDown.IntervalProperty);
							}
						}
					}
					else if (propertyName == "FontWeight")
					{
						DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontWeightProperty, TextElement.FontWeightProperty);
					}
				}
				else if (num != 3801439777U)
				{
					if (num != 4072221131U)
					{
						if (num == 4130445440U)
						{
							if (propertyName == "FontFamily")
							{
								DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.FontFamilyProperty, TextElement.FontFamilyProperty);
							}
						}
					}
					else if (propertyName == "UpDownButtonsWidth")
					{
						DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.UpDownButtonsWidthProperty, NumericUpDown.UpDownButtonsWidthProperty);
					}
				}
				else if (propertyName == "Maximum")
				{
					DataGridNumericUpDownColumn.SyncColumnProperty(this, numericUpDown, DataGridNumericUpDownColumn.MaximumProperty, NumericUpDown.MaximumProperty);
				}
			}
			base.RefreshCellContent(element, propertyName);
		}

		// Token: 0x04000043 RID: 67
		private static Style _defaultEditingElementStyle;

		// Token: 0x04000044 RID: 68
		private static Style _defaultElementStyle;

		// Token: 0x04000045 RID: 69
		public static readonly DependencyProperty StringFormatProperty = NumericUpDown.StringFormatProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((string)NumericUpDown.StringFormatProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000046 RID: 70
		public static readonly DependencyProperty MinimumProperty = NumericUpDown.MinimumProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((double)NumericUpDown.MinimumProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000047 RID: 71
		public static readonly DependencyProperty MaximumProperty = NumericUpDown.MaximumProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((double)NumericUpDown.MaximumProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000048 RID: 72
		public static readonly DependencyProperty IntervalProperty = NumericUpDown.IntervalProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((double)NumericUpDown.IntervalProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000049 RID: 73
		public static readonly DependencyProperty HideUpDownButtonsProperty = NumericUpDown.HideUpDownButtonsProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((bool)NumericUpDown.HideUpDownButtonsProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004A RID: 74
		public static readonly DependencyProperty UpDownButtonsWidthProperty = NumericUpDown.UpDownButtonsWidthProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata((double)NumericUpDown.UpDownButtonsWidthProperty.DefaultMetadata.DefaultValue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004B RID: 75
		public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004C RID: 76
		public static readonly DependencyProperty FontSizeProperty = TextElement.FontSizeProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004D RID: 77
		public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontStyle, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004E RID: 78
		public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontWeight, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400004F RID: 79
		public static readonly DependencyProperty ForegroundProperty = TextElement.ForegroundProperty.AddOwner(typeof(DataGridNumericUpDownColumn), new FrameworkPropertyMetadata(SystemColors.ControlTextBrush, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridNumericUpDownColumn.NotifyPropertyChangeForRefreshContent)));
	}
}
