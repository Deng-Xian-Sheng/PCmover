using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B7 RID: 183
	public class PasswordBoxBindingBehavior : Behavior<PasswordBox>
	{
		// Token: 0x060009F5 RID: 2549 RVA: 0x00026A16 File Offset: 0x00024C16
		[Category("MahApps.Metro")]
		public static string GetPassword(DependencyObject dpo)
		{
			return (string)dpo.GetValue(PasswordBoxBindingBehavior.PasswordProperty);
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00026A28 File Offset: 0x00024C28
		public static void SetPassword(DependencyObject dpo, string value)
		{
			dpo.SetValue(PasswordBoxBindingBehavior.PasswordProperty, value);
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00026A38 File Offset: 0x00024C38
		private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			PasswordBox passwordBox = sender as PasswordBox;
			if (passwordBox != null)
			{
				passwordBox.PasswordChanged -= PasswordBoxBindingBehavior.PasswordBoxPasswordChanged;
				if (!PasswordBoxBindingBehavior.GetIsChanging(passwordBox))
				{
					passwordBox.Password = (string)e.NewValue;
				}
				passwordBox.PasswordChanged += PasswordBoxBindingBehavior.PasswordBoxPasswordChanged;
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00026A90 File Offset: 0x00024C90
		private static void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e)
		{
			PasswordBox passwordBox = (PasswordBox)sender;
			PasswordBoxBindingBehavior.SetIsChanging(passwordBox, true);
			PasswordBoxBindingBehavior.SetPassword(passwordBox, passwordBox.Password);
			PasswordBoxBindingBehavior.SetIsChanging(passwordBox, false);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00026AC0 File Offset: 0x00024CC0
		private static void SetRevealedPasswordCaretIndex(PasswordBox passwordBox)
		{
			TextBox revealedPasswordTextBox = PasswordBoxBindingBehavior.GetRevealedPasswordTextBox(passwordBox);
			if (revealedPasswordTextBox != null)
			{
				int passwordBoxCaretPosition = PasswordBoxBindingBehavior.GetPasswordBoxCaretPosition(passwordBox);
				revealedPasswordTextBox.CaretIndex = passwordBoxCaretPosition;
			}
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00026AE8 File Offset: 0x00024CE8
		private static int GetPasswordBoxCaretPosition(PasswordBox passwordBox)
		{
			TextSelection selection = PasswordBoxBindingBehavior.GetSelection(passwordBox);
			object obj;
			if (selection == null)
			{
				obj = null;
			}
			else
			{
				obj = selection.GetType().GetInterfaces().FirstOrDefault((Type i) => i.Name == "ITextRange");
			}
			object obj2 = obj;
			object obj3;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				PropertyInfo property = obj2.GetProperty("Start");
				if (property == null)
				{
					obj3 = null;
				}
				else
				{
					MethodInfo getMethod = property.GetGetMethod();
					obj3 = ((getMethod != null) ? getMethod.Invoke(selection, null) : null);
				}
			}
			object obj4 = obj3;
			object obj5;
			if (obj4 == null)
			{
				obj5 = null;
			}
			else
			{
				PropertyInfo property2 = obj4.GetType().GetProperty("Offset", BindingFlags.Instance | BindingFlags.NonPublic);
				obj5 = ((property2 != null) ? property2.GetValue(obj4, null) : null);
			}
			return (obj5 as int?).GetValueOrDefault(0);
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00026B98 File Offset: 0x00024D98
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.PasswordChanged += PasswordBoxBindingBehavior.PasswordBoxPasswordChanged;
			base.AssociatedObject.Loaded += this.PasswordBoxLoaded;
			TextSelection selection = PasswordBoxBindingBehavior.GetSelection(base.AssociatedObject);
			if (selection != null)
			{
				selection.Changed += this.PasswordBoxSelectionChanged;
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00026BFC File Offset: 0x00024DFC
		private void PasswordBoxLoaded(object sender, RoutedEventArgs e)
		{
			PasswordBoxBindingBehavior.SetPassword(base.AssociatedObject, base.AssociatedObject.Password);
			TextBox textBox = base.AssociatedObject.FindChild("RevealedPassword");
			if (textBox != null && PasswordBoxBindingBehavior.GetSelection(base.AssociatedObject) == null)
			{
				PropertyInfo property = base.AssociatedObject.GetType().GetProperty("Selection", BindingFlags.Instance | BindingFlags.NonPublic);
				TextSelection textSelection = ((property != null) ? property.GetValue(base.AssociatedObject, null) : null) as TextSelection;
				PasswordBoxBindingBehavior.SetSelection(base.AssociatedObject, textSelection);
				if (textSelection != null)
				{
					PasswordBoxBindingBehavior.SetRevealedPasswordTextBox(base.AssociatedObject, textBox);
					PasswordBoxBindingBehavior.SetRevealedPasswordCaretIndex(base.AssociatedObject);
					textSelection.Changed += this.PasswordBoxSelectionChanged;
				}
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00026CAA File Offset: 0x00024EAA
		private void PasswordBoxSelectionChanged(object sender, EventArgs e)
		{
			PasswordBoxBindingBehavior.SetRevealedPasswordCaretIndex(base.AssociatedObject);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00026CB8 File Offset: 0x00024EB8
		protected override void OnDetaching()
		{
			if (base.AssociatedObject != null)
			{
				TextSelection selection = PasswordBoxBindingBehavior.GetSelection(base.AssociatedObject);
				if (selection != null)
				{
					selection.Changed -= this.PasswordBoxSelectionChanged;
				}
				base.AssociatedObject.Loaded -= this.PasswordBoxLoaded;
				base.AssociatedObject.PasswordChanged -= PasswordBoxBindingBehavior.PasswordBoxPasswordChanged;
			}
			base.OnDetaching();
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00026D22 File Offset: 0x00024F22
		private static bool GetIsChanging(DependencyObject obj)
		{
			return (bool)obj.GetValue(PasswordBoxBindingBehavior.IsChangingProperty);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00026D34 File Offset: 0x00024F34
		private static void SetIsChanging(DependencyObject obj, bool value)
		{
			obj.SetValue(PasswordBoxBindingBehavior.IsChangingProperty, value);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x00026D47 File Offset: 0x00024F47
		private static TextSelection GetSelection(DependencyObject obj)
		{
			return (TextSelection)obj.GetValue(PasswordBoxBindingBehavior.SelectionProperty);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x00026D59 File Offset: 0x00024F59
		private static void SetSelection(DependencyObject obj, TextSelection value)
		{
			obj.SetValue(PasswordBoxBindingBehavior.SelectionProperty, value);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00026D67 File Offset: 0x00024F67
		private static TextBox GetRevealedPasswordTextBox(DependencyObject obj)
		{
			return (TextBox)obj.GetValue(PasswordBoxBindingBehavior.RevealedPasswordTextBoxProperty);
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00026D79 File Offset: 0x00024F79
		private static void SetRevealedPasswordTextBox(DependencyObject obj, TextBox value)
		{
			obj.SetValue(PasswordBoxBindingBehavior.RevealedPasswordTextBoxProperty, value);
		}

		// Token: 0x04000466 RID: 1126
		public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxBindingBehavior), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(PasswordBoxBindingBehavior.OnPasswordPropertyChanged)));

		// Token: 0x04000467 RID: 1127
		private static readonly DependencyProperty IsChangingProperty = DependencyProperty.RegisterAttached("IsChanging", typeof(bool), typeof(PasswordBoxBindingBehavior), new UIPropertyMetadata(false));

		// Token: 0x04000468 RID: 1128
		private static readonly DependencyProperty SelectionProperty = DependencyProperty.RegisterAttached("Selection", typeof(TextSelection), typeof(PasswordBoxBindingBehavior), new UIPropertyMetadata(null));

		// Token: 0x04000469 RID: 1129
		private static readonly DependencyProperty RevealedPasswordTextBoxProperty = DependencyProperty.RegisterAttached("RevealedPasswordTextBox", typeof(TextBox), typeof(PasswordBoxBindingBehavior), new UIPropertyMetadata(null));
	}
}
