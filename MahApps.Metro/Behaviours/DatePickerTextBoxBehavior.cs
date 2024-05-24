using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Behaviours
{
	// Token: 0x020000B5 RID: 181
	public class DatePickerTextBoxBehavior : Behavior<DatePickerTextBox>
	{
		// Token: 0x060009DB RID: 2523 RVA: 0x00026250 File Offset: 0x00024450
		protected override void OnAttached()
		{
			base.OnAttached();
			base.AssociatedObject.TextChanged += this.OnTextChanged;
			this.BeginInvoke(new Action(this.SetHasTextProperty), DispatcherPriority.Loaded);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x00026282 File Offset: 0x00024482
		protected override void OnDetaching()
		{
			base.AssociatedObject.TextChanged -= this.OnTextChanged;
			base.OnDetaching();
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x000262A1 File Offset: 0x000244A1
		private void OnTextChanged(object sender, TextChangedEventArgs e)
		{
			this.SetHasTextProperty();
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x000262A9 File Offset: 0x000244A9
		private void SetHasTextProperty()
		{
			DependencyObject templatedParent = base.AssociatedObject.TemplatedParent;
			if (templatedParent == null)
			{
				return;
			}
			templatedParent.SetValue(TextBoxHelper.HasTextProperty, base.AssociatedObject.Text.Length > 0);
		}
	}
}
