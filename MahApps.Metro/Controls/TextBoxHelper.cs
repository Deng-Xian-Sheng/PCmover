using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MahApps.Metro.Behaviours;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000055 RID: 85
	public class TextBoxHelper
	{
		// Token: 0x0600037C RID: 892 RVA: 0x0000DE79 File Offset: 0x0000C079
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static bool GetIsSpellCheckContextMenuEnabled(UIElement element)
		{
			return (bool)element.GetValue(TextBoxHelper.IsSpellCheckContextMenuEnabledProperty);
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000DE8B File Offset: 0x0000C08B
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetIsSpellCheckContextMenuEnabled(UIElement element, bool value)
		{
			element.SetValue(TextBoxHelper.IsSpellCheckContextMenuEnabledProperty, value);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000DE9E File Offset: 0x0000C09E
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static bool GetAutoWatermark(DependencyObject element)
		{
			return (bool)element.GetValue(TextBoxHelper.AutoWatermarkProperty);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000DEB0 File Offset: 0x0000C0B0
		public static void SetAutoWatermark(DependencyObject element, bool value)
		{
			element.SetValue(TextBoxHelper.AutoWatermarkProperty, value);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000DEC4 File Offset: 0x0000C0C4
		private static void OnAutoWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FrameworkElement frameworkElement = d as FrameworkElement;
			bool? flag = e.NewValue as bool?;
			if (frameworkElement != null)
			{
				if (flag.GetValueOrDefault())
				{
					if (frameworkElement.IsLoaded)
					{
						TextBoxHelper.OnControlWithAutoWatermarkSupportLoaded(frameworkElement, new RoutedEventArgs());
						return;
					}
					frameworkElement.Loaded += TextBoxHelper.OnControlWithAutoWatermarkSupportLoaded;
					return;
				}
				else
				{
					frameworkElement.Loaded -= TextBoxHelper.OnControlWithAutoWatermarkSupportLoaded;
				}
			}
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000DF30 File Offset: 0x0000C130
		private static void OnControlWithAutoWatermarkSupportLoaded(object o, RoutedEventArgs routedEventArgs)
		{
			FrameworkElement frameworkElement = (FrameworkElement)o;
			frameworkElement.Loaded -= TextBoxHelper.OnControlWithAutoWatermarkSupportLoaded;
			DependencyProperty dp;
			if (!TextBoxHelper.AutoWatermarkPropertyMapping.TryGetValue(frameworkElement.GetType(), out dp))
			{
				throw new NotSupportedException(string.Format("{0} is not supported for {1}", "AutoWatermarkProperty", frameworkElement.GetType()));
			}
			PropertyInfo propertyInfo = TextBoxHelper.ResolvePropertyFromBindingExpression(frameworkElement.GetBindingExpression(dp));
			if (propertyInfo != null)
			{
				DisplayAttribute customAttribute = propertyInfo.GetCustomAttribute<DisplayAttribute>();
				if (customAttribute != null)
				{
					frameworkElement.SetCurrentValue(TextBoxHelper.WatermarkProperty, customAttribute.GetPrompt());
				}
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000DFB8 File Offset: 0x0000C1B8
		private static PropertyInfo ResolvePropertyFromBindingExpression(BindingExpression bindingExpression)
		{
			if (bindingExpression != null)
			{
				if (bindingExpression.Status == BindingStatus.PathError)
				{
					return null;
				}
				string resolvedSourcePropertyName = bindingExpression.ResolvedSourcePropertyName;
				if (!string.IsNullOrEmpty(resolvedSourcePropertyName))
				{
					object resolvedSource = bindingExpression.ResolvedSource;
					Type type = (resolvedSource != null) ? resolvedSource.GetType() : null;
					if (type != null)
					{
						return type.GetProperty(resolvedSourcePropertyName, BindingFlags.Instance | BindingFlags.Public);
					}
				}
			}
			return null;
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000E00C File Offset: 0x0000C20C
		private static void IsSpellCheckContextMenuEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TextBoxBase textBoxBase = d as TextBoxBase;
			if (textBoxBase == null)
			{
				throw new InvalidOperationException("The property 'IsSpellCheckContextMenuEnabled' may only be set on TextBoxBase elements.");
			}
			if (e.OldValue != e.NewValue)
			{
				textBoxBase.SetCurrentValue(SpellCheck.IsEnabledProperty, (bool)e.NewValue);
				if ((bool)e.NewValue)
				{
					textBoxBase.ContextMenuOpening += TextBoxHelper.TextBoxBaseContextMenuOpening;
					textBoxBase.LostFocus += TextBoxHelper.TextBoxBaseLostFocus;
					textBoxBase.ContextMenuClosing += TextBoxHelper.TextBoxBaseContextMenuClosing;
					return;
				}
				textBoxBase.ContextMenuOpening -= TextBoxHelper.TextBoxBaseContextMenuOpening;
				textBoxBase.LostFocus -= TextBoxHelper.TextBoxBaseLostFocus;
				textBoxBase.ContextMenuClosing -= TextBoxHelper.TextBoxBaseContextMenuClosing;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000E0D8 File Offset: 0x0000C2D8
		private static void TextBoxBaseLostFocus(object sender, RoutedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			TextBoxHelper.RemoveSpellCheckMenuItems((frameworkElement != null) ? frameworkElement.ContextMenu : null);
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000E0F1 File Offset: 0x0000C2F1
		private static void TextBoxBaseContextMenuClosing(object sender, ContextMenuEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			TextBoxHelper.RemoveSpellCheckMenuItems((frameworkElement != null) ? frameworkElement.ContextMenu : null);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000E10C File Offset: 0x0000C30C
		private static void TextBoxBaseContextMenuOpening(object sender, ContextMenuEventArgs e)
		{
			TextBoxBase textBoxBase = (TextBoxBase)sender;
			ContextMenu contextMenu = textBoxBase.ContextMenu;
			if (contextMenu == null)
			{
				return;
			}
			TextBoxHelper.RemoveSpellCheckMenuItems(contextMenu);
			if (!SpellCheck.GetIsEnabled(textBoxBase))
			{
				return;
			}
			int insertIndex = 0;
			TextBox textBox = textBoxBase as TextBox;
			RichTextBox richTextBox = textBoxBase as RichTextBox;
			SpellingError spellingError = (textBox != null) ? textBox.GetSpellingError(textBox.CaretIndex) : ((richTextBox != null) ? richTextBox.GetSpellingError(richTextBox.CaretPosition) : null);
			if (spellingError != null)
			{
				Style style = contextMenu.TryFindResource(Spelling.SuggestionMenuItemStyleKey) as Style;
				List<string> list = spellingError.Suggestions.ToList<string>();
				if (list.Any<string>())
				{
					using (List<string>.Enumerator enumerator = list.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string commandParameter = enumerator.Current;
							MenuItem insertItem = new MenuItem
							{
								Command = EditingCommands.CorrectSpellingError,
								CommandParameter = commandParameter,
								CommandTarget = textBoxBase,
								Style = style,
								Tag = typeof(Spelling)
							};
							contextMenu.Items.Insert(insertIndex++, insertItem);
						}
						goto IL_13D;
					}
				}
				contextMenu.Items.Insert(insertIndex++, new MenuItem
				{
					Style = (contextMenu.TryFindResource(Spelling.NoSuggestionsMenuItemStyleKey) as Style),
					Tag = typeof(Spelling)
				});
				IL_13D:
				contextMenu.Items.Insert(insertIndex++, new Separator
				{
					Style = (contextMenu.TryFindResource(Spelling.SeparatorStyleKey) as Style),
					Tag = typeof(Spelling)
				});
				MenuItem insertItem2 = new MenuItem
				{
					Command = EditingCommands.IgnoreSpellingError,
					CommandTarget = textBoxBase,
					Style = (contextMenu.TryFindResource(Spelling.IgnoreAllMenuItemStyleKey) as Style),
					Tag = typeof(Spelling)
				};
				contextMenu.Items.Insert(insertIndex++, insertItem2);
				contextMenu.Items.Insert(insertIndex, new Separator
				{
					Style = (contextMenu.TryFindResource(Spelling.SeparatorStyleKey) as Style),
					Tag = typeof(Spelling)
				});
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000E32C File Offset: 0x0000C52C
		private static void RemoveSpellCheckMenuItems(ContextMenu contextMenu)
		{
			if (contextMenu != null)
			{
				foreach (FrameworkElement removeItem in (from item in contextMenu.Items.OfType<FrameworkElement>()
				where item.Tag == typeof(Spelling)
				select item).ToList<FrameworkElement>())
				{
					contextMenu.Items.Remove(removeItem);
				}
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000E3B8 File Offset: 0x0000C5B8
		public static void SetIsWaitingForData(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.IsWaitingForDataProperty, value);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000E3CB File Offset: 0x0000C5CB
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		public static bool GetIsWaitingForData(DependencyObject obj)
		{
			return (bool)obj.GetValue(TextBoxHelper.IsWaitingForDataProperty);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000E3DD File Offset: 0x0000C5DD
		public static void SetSelectAllOnFocus(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.SelectAllOnFocusProperty, value);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000E3F0 File Offset: 0x0000C5F0
		public static bool GetSelectAllOnFocus(DependencyObject obj)
		{
			return (bool)obj.GetValue(TextBoxHelper.SelectAllOnFocusProperty);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000E402 File Offset: 0x0000C602
		public static void SetIsMonitoring(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.IsMonitoringProperty, value);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000E415 File Offset: 0x0000C615
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static string GetWatermark(DependencyObject obj)
		{
			return (string)obj.GetValue(TextBoxHelper.WatermarkProperty);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000E427 File Offset: 0x0000C627
		public static void SetWatermark(DependencyObject obj, string value)
		{
			obj.SetValue(TextBoxHelper.WatermarkProperty, value);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000E435 File Offset: 0x0000C635
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static TextAlignment GetWatermarkAlignment(DependencyObject obj)
		{
			return (TextAlignment)obj.GetValue(TextBoxHelper.WatermarkAlignmentProperty);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000E447 File Offset: 0x0000C647
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static void SetWatermarkAlignment(DependencyObject obj, TextAlignment value)
		{
			obj.SetValue(TextBoxHelper.WatermarkAlignmentProperty, value);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000E45A File Offset: 0x0000C65A
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static TextTrimming GetWatermarkTrimming(DependencyObject obj)
		{
			return (TextTrimming)obj.GetValue(TextBoxHelper.WatermarkTrimmingProperty);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000E46C File Offset: 0x0000C66C
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(TimePickerBase))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static void SetWatermarkTrimming(DependencyObject obj, TextTrimming value)
		{
			obj.SetValue(TextBoxHelper.WatermarkTrimmingProperty, value);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000E47F File Offset: 0x0000C67F
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static TextWrapping GetWatermarkWrapping(DependencyObject obj)
		{
			return (TextWrapping)obj.GetValue(TextBoxHelper.WatermarkWrappingProperty);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000E491 File Offset: 0x0000C691
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		public static void SetWatermarkWrapping(DependencyObject obj, TextWrapping value)
		{
			obj.SetValue(TextBoxHelper.WatermarkWrappingProperty, value);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000E4A4 File Offset: 0x0000C6A4
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		[AttachedPropertyBrowsableForType(typeof(HotKeyBox))]
		public static bool GetUseFloatingWatermark(DependencyObject obj)
		{
			return (bool)obj.GetValue(TextBoxHelper.UseFloatingWatermarkProperty);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000E4B6 File Offset: 0x0000C6B6
		public static void SetUseFloatingWatermark(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.UseFloatingWatermarkProperty, value);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000E4C9 File Offset: 0x0000C6C9
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(TextBoxBase))]
		[AttachedPropertyBrowsableForType(typeof(PasswordBox))]
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		[AttachedPropertyBrowsableForType(typeof(DatePicker))]
		[AttachedPropertyBrowsableForType(typeof(NumericUpDown))]
		public static bool GetHasText(DependencyObject obj)
		{
			return (bool)obj.GetValue(TextBoxHelper.HasTextProperty);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000E4DB File Offset: 0x0000C6DB
		public static void SetHasText(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.HasTextProperty, value);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000E4F0 File Offset: 0x0000C6F0
		private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is TextBox)
			{
				TextBox txtBox = (TextBox)d;
				if ((bool)e.NewValue)
				{
					txtBox.BeginInvoke(delegate
					{
						TextBoxHelper.TextChanged(txtBox, new TextChangedEventArgs(TextBoxBase.TextChangedEvent, UndoAction.None));
					}, DispatcherPriority.Background);
					txtBox.TextChanged += new TextChangedEventHandler(TextBoxHelper.TextChanged);
					txtBox.GotFocus += TextBoxHelper.TextBoxGotFocus;
					return;
				}
				txtBox.TextChanged -= new TextChangedEventHandler(TextBoxHelper.TextChanged);
				txtBox.GotFocus -= TextBoxHelper.TextBoxGotFocus;
				return;
			}
			else if (d is PasswordBox)
			{
				PasswordBox passBox = (PasswordBox)d;
				if ((bool)e.NewValue)
				{
					passBox.BeginInvoke(delegate
					{
						TextBoxHelper.PasswordChanged(passBox, new RoutedEventArgs(PasswordBox.PasswordChangedEvent, passBox));
					}, DispatcherPriority.Background);
					passBox.PasswordChanged += TextBoxHelper.PasswordChanged;
					passBox.GotFocus += TextBoxHelper.PasswordGotFocus;
					return;
				}
				passBox.PasswordChanged -= TextBoxHelper.PasswordChanged;
				passBox.GotFocus -= TextBoxHelper.PasswordGotFocus;
				return;
			}
			else if (d is NumericUpDown)
			{
				NumericUpDown numericUpDown = (NumericUpDown)d;
				if ((bool)e.NewValue)
				{
					numericUpDown.BeginInvoke(delegate
					{
						TextBoxHelper.OnNumericUpDownValueChaged(numericUpDown, new RoutedEventArgs(NumericUpDown.ValueChangedEvent, numericUpDown));
					}, DispatcherPriority.Background);
					numericUpDown.ValueChanged += new RoutedPropertyChangedEventHandler<double?>(TextBoxHelper.OnNumericUpDownValueChaged);
					return;
				}
				numericUpDown.ValueChanged -= new RoutedPropertyChangedEventHandler<double?>(TextBoxHelper.OnNumericUpDownValueChaged);
				return;
			}
			else
			{
				if (!(d is TimePickerBase))
				{
					if (d is DatePicker)
					{
						DatePicker datePicker = (DatePicker)d;
						if ((bool)e.NewValue)
						{
							datePicker.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(TextBoxHelper.OnDatePickerBaseSelectedDateChanged);
							return;
						}
						datePicker.SelectedDateChanged -= new EventHandler<SelectionChangedEventArgs>(TextBoxHelper.OnDatePickerBaseSelectedDateChanged);
					}
					return;
				}
				TimePickerBase timePickerBase = (TimePickerBase)d;
				if ((bool)e.NewValue)
				{
					timePickerBase.SelectedTimeChanged += new EventHandler<TimePickerBaseSelectionChangedEventArgs<TimeSpan?>>(TextBoxHelper.OnTimePickerBaseSelectedTimeChanged);
					return;
				}
				timePickerBase.SelectedTimeChanged -= new EventHandler<TimePickerBaseSelectionChangedEventArgs<TimeSpan?>>(TextBoxHelper.OnTimePickerBaseSelectedTimeChanged);
				return;
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000E738 File Offset: 0x0000C938
		private static void SetTextLength<TDependencyObject>(TDependencyObject sender, Func<TDependencyObject, int> funcTextLength) where TDependencyObject : DependencyObject
		{
			if (sender != null)
			{
				int num = funcTextLength(sender);
				sender.SetValue(TextBoxHelper.TextLengthProperty, num);
				sender.SetValue(TextBoxHelper.HasTextProperty, num >= 1);
			}
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000E787 File Offset: 0x0000C987
		private static void TextChanged(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.SetTextLength<TextBox>(sender as TextBox, (TextBox textBox) => textBox.Text.Length);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000E7B3 File Offset: 0x0000C9B3
		private static void OnNumericUpDownValueChaged(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.SetTextLength<NumericUpDown>(sender as NumericUpDown, delegate(NumericUpDown numericUpDown)
			{
				if (numericUpDown.Value == null)
				{
					return 0;
				}
				return 1;
			});
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000E7DF File Offset: 0x0000C9DF
		private static void PasswordChanged(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.SetTextLength<PasswordBox>(sender as PasswordBox, (PasswordBox passwordBox) => passwordBox.Password.Length);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000E80B File Offset: 0x0000CA0B
		private static void OnDatePickerBaseSelectedDateChanged(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.SetTextLength<DatePicker>(sender as DatePicker, delegate(DatePicker timePickerBase)
			{
				if (timePickerBase.SelectedDate == null)
				{
					return 0;
				}
				return 1;
			});
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000E837 File Offset: 0x0000CA37
		private static void OnTimePickerBaseSelectedTimeChanged(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.SetTextLength<TimePickerBase>(sender as TimePickerBase, delegate(TimePickerBase timePickerBase)
			{
				if (timePickerBase.SelectedTime == null)
				{
					return 0;
				}
				return 1;
			});
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000E863 File Offset: 0x0000CA63
		private static void TextBoxGotFocus(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.ControlGotFocus<TextBox>(sender as TextBox, delegate(TextBox textBox)
			{
				textBox.SelectAll();
			});
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000E88F File Offset: 0x0000CA8F
		private static void NumericUpDownGotFocus(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.ControlGotFocus<NumericUpDown>(sender as NumericUpDown, delegate(NumericUpDown numericUpDown)
			{
				numericUpDown.SelectAll();
			});
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000E8BB File Offset: 0x0000CABB
		private static void PasswordGotFocus(object sender, RoutedEventArgs e)
		{
			TextBoxHelper.ControlGotFocus<PasswordBox>(sender as PasswordBox, delegate(PasswordBox passwordBox)
			{
				passwordBox.SelectAll();
			});
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000E8E7 File Offset: 0x0000CAE7
		private static void ControlGotFocus<TDependencyObject>(TDependencyObject sender, Action<TDependencyObject> action) where TDependencyObject : DependencyObject
		{
			if (sender != null && TextBoxHelper.GetSelectAllOnFocus(sender))
			{
				sender.Dispatcher.BeginInvoke(action, new object[]
				{
					sender
				});
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000E91F File Offset: 0x0000CB1F
		[Category("MahApps.Metro")]
		public static bool GetClearTextButton(DependencyObject d)
		{
			return (bool)d.GetValue(TextBoxHelper.ClearTextButtonProperty);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000E931 File Offset: 0x0000CB31
		public static void SetClearTextButton(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.ClearTextButtonProperty, value);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000E944 File Offset: 0x0000CB44
		[Category("MahApps.Metro")]
		public static bool GetTextButton(DependencyObject d)
		{
			return (bool)d.GetValue(TextBoxHelper.TextButtonProperty);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000E956 File Offset: 0x0000CB56
		public static void SetTextButton(DependencyObject obj, bool value)
		{
			obj.SetValue(TextBoxHelper.TextButtonProperty, value);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000E969 File Offset: 0x0000CB69
		[Category("MahApps.Metro")]
		public static ButtonsAlignment GetButtonsAlignment(DependencyObject d)
		{
			return (ButtonsAlignment)d.GetValue(TextBoxHelper.ButtonsAlignmentProperty);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000E97B File Offset: 0x0000CB7B
		public static void SetButtonsAlignment(DependencyObject obj, ButtonsAlignment value)
		{
			obj.SetValue(TextBoxHelper.ButtonsAlignmentProperty, value);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000E98E File Offset: 0x0000CB8E
		[Category("MahApps.Metro")]
		[AttachedPropertyBrowsableForType(typeof(ButtonBase))]
		public static bool GetIsClearTextButtonBehaviorEnabled(Button d)
		{
			return (bool)d.GetValue(TextBoxHelper.IsClearTextButtonBehaviorEnabledProperty);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
		[AttachedPropertyBrowsableForType(typeof(ButtonBase))]
		public static void SetIsClearTextButtonBehaviorEnabled(Button obj, bool value)
		{
			obj.SetValue(TextBoxHelper.IsClearTextButtonBehaviorEnabledProperty, value);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000E9B3 File Offset: 0x0000CBB3
		[Category("MahApps.Metro")]
		public static double GetButtonWidth(DependencyObject obj)
		{
			return (double)obj.GetValue(TextBoxHelper.ButtonWidthProperty);
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000E9C5 File Offset: 0x0000CBC5
		public static void SetButtonWidth(DependencyObject obj, double value)
		{
			obj.SetValue(TextBoxHelper.ButtonWidthProperty, value);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000E9D8 File Offset: 0x0000CBD8
		[Category("MahApps.Metro")]
		public static ICommand GetButtonCommand(DependencyObject d)
		{
			return (ICommand)d.GetValue(TextBoxHelper.ButtonCommandProperty);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000E9EA File Offset: 0x0000CBEA
		public static void SetButtonCommand(DependencyObject obj, ICommand value)
		{
			obj.SetValue(TextBoxHelper.ButtonCommandProperty, value);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000E9F8 File Offset: 0x0000CBF8
		[Category("MahApps.Metro")]
		public static object GetButtonCommandParameter(DependencyObject d)
		{
			return d.GetValue(TextBoxHelper.ButtonCommandParameterProperty);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000EA05 File Offset: 0x0000CC05
		public static void SetButtonCommandParameter(DependencyObject obj, object value)
		{
			obj.SetValue(TextBoxHelper.ButtonCommandParameterProperty, value);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000EA13 File Offset: 0x0000CC13
		[Category("MahApps.Metro")]
		public static object GetButtonContent(DependencyObject d)
		{
			return d.GetValue(TextBoxHelper.ButtonContentProperty);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000EA20 File Offset: 0x0000CC20
		public static void SetButtonContent(DependencyObject obj, object value)
		{
			obj.SetValue(TextBoxHelper.ButtonContentProperty, value);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000EA2E File Offset: 0x0000CC2E
		[Category("MahApps.Metro")]
		public static DataTemplate GetButtonContentTemplate(DependencyObject d)
		{
			return (DataTemplate)d.GetValue(TextBoxHelper.ButtonContentTemplateProperty);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000EA40 File Offset: 0x0000CC40
		public static void SetButtonContentTemplate(DependencyObject obj, DataTemplate value)
		{
			obj.SetValue(TextBoxHelper.ButtonContentTemplateProperty, value);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000EA4E File Offset: 0x0000CC4E
		[Category("MahApps.Metro")]
		public static ControlTemplate GetButtonTemplate(DependencyObject d)
		{
			return (ControlTemplate)d.GetValue(TextBoxHelper.ButtonTemplateProperty);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000EA60 File Offset: 0x0000CC60
		public static void SetButtonTemplate(DependencyObject obj, ControlTemplate value)
		{
			obj.SetValue(TextBoxHelper.ButtonTemplateProperty, value);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000EA6E File Offset: 0x0000CC6E
		[Category("MahApps.Metro")]
		public static FontFamily GetButtonFontFamily(DependencyObject d)
		{
			return (FontFamily)d.GetValue(TextBoxHelper.ButtonFontFamilyProperty);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000EA80 File Offset: 0x0000CC80
		public static void SetButtonFontFamily(DependencyObject obj, FontFamily value)
		{
			obj.SetValue(TextBoxHelper.ButtonFontFamilyProperty, value);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000EA8E File Offset: 0x0000CC8E
		[Category("MahApps.Metro")]
		public static double GetButtonFontSize(DependencyObject d)
		{
			return (double)d.GetValue(TextBoxHelper.ButtonFontSizeProperty);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000EAA0 File Offset: 0x0000CCA0
		public static void SetButtonFontSize(DependencyObject obj, double value)
		{
			obj.SetValue(TextBoxHelper.ButtonFontSizeProperty, value);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000EAB4 File Offset: 0x0000CCB4
		private static void IsClearTextButtonBehaviorEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Button button = d as Button;
			if (e.OldValue != e.NewValue && button != null)
			{
				button.Click -= TextBoxHelper.ButtonClicked;
				if ((bool)e.NewValue)
				{
					button.Click += TextBoxHelper.ButtonClicked;
				}
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000EB10 File Offset: 0x0000CD10
		public static void ButtonClicked(object sender, RoutedEventArgs e)
		{
			DependencyObject dependencyObject = ((Button)sender).GetAncestors().FirstOrDefault((DependencyObject a) => a is TextBox || a is PasswordBox || a is ComboBox);
			ICommand buttonCommand = TextBoxHelper.GetButtonCommand(dependencyObject);
			object parameter = TextBoxHelper.GetButtonCommandParameter(dependencyObject) ?? dependencyObject;
			if (buttonCommand != null && buttonCommand.CanExecute(parameter))
			{
				buttonCommand.Execute(parameter);
			}
			if (TextBoxHelper.GetClearTextButton(dependencyObject))
			{
				if (dependencyObject is TextBox)
				{
					((TextBox)dependencyObject).Clear();
					BindingExpression bindingExpression = ((TextBox)dependencyObject).GetBindingExpression(TextBox.TextProperty);
					if (bindingExpression == null)
					{
						return;
					}
					bindingExpression.UpdateSource();
					return;
				}
				else if (dependencyObject is PasswordBox)
				{
					((PasswordBox)dependencyObject).Clear();
					BindingExpression bindingExpression2 = ((PasswordBox)dependencyObject).GetBindingExpression(PasswordBoxBindingBehavior.PasswordProperty);
					if (bindingExpression2 == null)
					{
						return;
					}
					bindingExpression2.UpdateSource();
					return;
				}
				else if (dependencyObject is ComboBox)
				{
					if (((ComboBox)dependencyObject).IsEditable)
					{
						((ComboBox)dependencyObject).Text = string.Empty;
						BindingExpression bindingExpression3 = ((ComboBox)dependencyObject).GetBindingExpression(ComboBox.TextProperty);
						if (bindingExpression3 != null)
						{
							bindingExpression3.UpdateSource();
						}
					}
					((ComboBox)dependencyObject).SelectedItem = null;
					BindingExpression bindingExpression4 = ((ComboBox)dependencyObject).GetBindingExpression(Selector.SelectedItemProperty);
					if (bindingExpression4 == null)
					{
						return;
					}
					bindingExpression4.UpdateSource();
				}
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000EC40 File Offset: 0x0000CE40
		private static void ButtonCommandOrClearTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TextBox textBox = d as TextBox;
			if (textBox != null)
			{
				textBox.Loaded -= TextBoxHelper.TextChanged;
				textBox.Loaded += TextBoxHelper.TextChanged;
				if (textBox.IsLoaded)
				{
					TextBoxHelper.TextChanged(textBox, new RoutedEventArgs());
				}
			}
			PasswordBox passwordBox = d as PasswordBox;
			if (passwordBox != null)
			{
				passwordBox.Loaded -= TextBoxHelper.PasswordChanged;
				passwordBox.Loaded += TextBoxHelper.PasswordChanged;
				if (passwordBox.IsLoaded)
				{
					TextBoxHelper.PasswordChanged(passwordBox, new RoutedEventArgs());
				}
			}
			ComboBox comboBox = d as ComboBox;
			if (comboBox != null)
			{
				comboBox.Loaded -= TextBoxHelper.ComboBoxLoaded;
				comboBox.Loaded += TextBoxHelper.ComboBoxLoaded;
				if (comboBox.IsLoaded)
				{
					TextBoxHelper.ComboBoxLoaded(comboBox, new RoutedEventArgs());
				}
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000ED10 File Offset: 0x0000CF10
		private static void ComboBoxLoaded(object sender, RoutedEventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			if (comboBox != null)
			{
				comboBox.SetValue(TextBoxHelper.HasTextProperty, !string.IsNullOrWhiteSpace(comboBox.Text) || comboBox.SelectedItem != null);
			}
		}

		// Token: 0x04000162 RID: 354
		public static readonly DependencyProperty IsMonitoringProperty = DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(TextBoxHelper), new UIPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.OnIsMonitoringChanged)));

		// Token: 0x04000163 RID: 355
		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper), new UIPropertyMetadata(string.Empty));

		// Token: 0x04000164 RID: 356
		public static readonly DependencyProperty WatermarkAlignmentProperty = DependencyProperty.RegisterAttached("WatermarkAlignment", typeof(TextAlignment), typeof(TextBoxHelper), new FrameworkPropertyMetadata(TextAlignment.Left, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x04000165 RID: 357
		public static readonly DependencyProperty WatermarkTrimmingProperty = DependencyProperty.RegisterAttached("WatermarkTrimming", typeof(TextTrimming), typeof(TextBoxHelper), new FrameworkPropertyMetadata(TextTrimming.None, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000166 RID: 358
		public static readonly DependencyProperty WatermarkWrappingProperty = DependencyProperty.RegisterAttached("WatermarkWrapping", typeof(TextWrapping), typeof(TextBoxHelper), new FrameworkPropertyMetadata(TextWrapping.NoWrap, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000167 RID: 359
		public static readonly DependencyProperty UseFloatingWatermarkProperty = DependencyProperty.RegisterAttached("UseFloatingWatermark", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.ButtonCommandOrClearTextChanged)));

		// Token: 0x04000168 RID: 360
		public static readonly DependencyProperty TextLengthProperty = DependencyProperty.RegisterAttached("TextLength", typeof(int), typeof(TextBoxHelper), new UIPropertyMetadata(0));

		// Token: 0x04000169 RID: 361
		public static readonly DependencyProperty ClearTextButtonProperty = DependencyProperty.RegisterAttached("ClearTextButton", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.ButtonCommandOrClearTextChanged)));

		// Token: 0x0400016A RID: 362
		public static readonly DependencyProperty TextButtonProperty = DependencyProperty.RegisterAttached("TextButton", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.ButtonCommandOrClearTextChanged)));

		// Token: 0x0400016B RID: 363
		public static readonly DependencyProperty ButtonsAlignmentProperty = DependencyProperty.RegisterAttached("ButtonsAlignment", typeof(ButtonsAlignment), typeof(TextBoxHelper), new FrameworkPropertyMetadata(ButtonsAlignment.Right, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

		// Token: 0x0400016C RID: 364
		public static readonly DependencyProperty IsClearTextButtonBehaviorEnabledProperty = DependencyProperty.RegisterAttached("IsClearTextButtonBehaviorEnabled", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.IsClearTextButtonBehaviorEnabledChanged)));

		// Token: 0x0400016D RID: 365
		public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.RegisterAttached("ButtonWidth", typeof(double), typeof(TextBoxHelper), new FrameworkPropertyMetadata(22.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits));

		// Token: 0x0400016E RID: 366
		public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.RegisterAttached("ButtonCommand", typeof(ICommand), typeof(TextBoxHelper), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(TextBoxHelper.ButtonCommandOrClearTextChanged)));

		// Token: 0x0400016F RID: 367
		public static readonly DependencyProperty ButtonCommandParameterProperty = DependencyProperty.RegisterAttached("ButtonCommandParameter", typeof(object), typeof(TextBoxHelper), new FrameworkPropertyMetadata(null));

		// Token: 0x04000170 RID: 368
		public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.RegisterAttached("ButtonContent", typeof(object), typeof(TextBoxHelper), new FrameworkPropertyMetadata("r"));

		// Token: 0x04000171 RID: 369
		public static readonly DependencyProperty ButtonContentTemplateProperty = DependencyProperty.RegisterAttached("ButtonContentTemplate", typeof(DataTemplate), typeof(TextBoxHelper), new FrameworkPropertyMetadata(null));

		// Token: 0x04000172 RID: 370
		public static readonly DependencyProperty ButtonTemplateProperty = DependencyProperty.RegisterAttached("ButtonTemplate", typeof(ControlTemplate), typeof(TextBoxHelper), new FrameworkPropertyMetadata(null));

		// Token: 0x04000173 RID: 371
		public static readonly DependencyProperty ButtonFontFamilyProperty = DependencyProperty.RegisterAttached("ButtonFontFamily", typeof(FontFamily), typeof(TextBoxHelper), new FrameworkPropertyMetadata(new FontFamilyConverter().ConvertFromString("Marlett")));

		// Token: 0x04000174 RID: 372
		public static readonly DependencyProperty ButtonFontSizeProperty = DependencyProperty.RegisterAttached("ButtonFontSize", typeof(double), typeof(TextBoxHelper), new FrameworkPropertyMetadata(SystemFonts.MessageFontSize));

		// Token: 0x04000175 RID: 373
		public static readonly DependencyProperty SelectAllOnFocusProperty = DependencyProperty.RegisterAttached("SelectAllOnFocus", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false));

		// Token: 0x04000176 RID: 374
		public static readonly DependencyProperty IsWaitingForDataProperty = DependencyProperty.RegisterAttached("IsWaitingForData", typeof(bool), typeof(TextBoxHelper), new UIPropertyMetadata(false));

		// Token: 0x04000177 RID: 375
		public static readonly DependencyProperty HasTextProperty = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000178 RID: 376
		public static readonly DependencyProperty IsSpellCheckContextMenuEnabledProperty = DependencyProperty.RegisterAttached("IsSpellCheckContextMenuEnabled", typeof(bool), typeof(TextBoxHelper), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.IsSpellCheckContextMenuEnabledChanged)));

		// Token: 0x04000179 RID: 377
		public static readonly DependencyProperty AutoWatermarkProperty = DependencyProperty.RegisterAttached("AutoWatermark", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, new PropertyChangedCallback(TextBoxHelper.OnAutoWatermarkChanged)));

		// Token: 0x0400017A RID: 378
		private static readonly Dictionary<Type, DependencyProperty> AutoWatermarkPropertyMapping = new Dictionary<Type, DependencyProperty>
		{
			{
				typeof(TextBox),
				TextBox.TextProperty
			},
			{
				typeof(ComboBox),
				Selector.SelectedItemProperty
			},
			{
				typeof(NumericUpDown),
				NumericUpDown.ValueProperty
			},
			{
				typeof(HotKeyBox),
				HotKeyBox.HotKeyProperty
			},
			{
				typeof(DatePicker),
				DatePicker.SelectedDateProperty
			},
			{
				typeof(TimePicker),
				TimePickerBase.SelectedTimeProperty
			},
			{
				typeof(DateTimePicker),
				DateTimePicker.SelectedDateProperty
			}
		};
	}
}
