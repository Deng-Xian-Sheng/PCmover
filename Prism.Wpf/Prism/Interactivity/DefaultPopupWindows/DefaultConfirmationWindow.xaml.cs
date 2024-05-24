using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Prism.Interactivity.InteractionRequest;

namespace Prism.Interactivity.DefaultPopupWindows
{
	// Token: 0x0200007B RID: 123
	public partial class DefaultConfirmationWindow : Window
	{
		// Token: 0x06000390 RID: 912 RVA: 0x0000926F File Offset: 0x0000746F
		public DefaultConfirmationWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000927D File Offset: 0x0000747D
		// (set) Token: 0x06000392 RID: 914 RVA: 0x0000928A File Offset: 0x0000748A
		public IConfirmation Confirmation
		{
			get
			{
				return base.DataContext as IConfirmation;
			}
			set
			{
				base.DataContext = value;
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00009293 File Offset: 0x00007493
		private void OkButton_Click(object sender, RoutedEventArgs e)
		{
			this.Confirmation.Confirmed = true;
			base.Close();
		}

		// Token: 0x06000394 RID: 916 RVA: 0x000092A7 File Offset: 0x000074A7
		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Confirmation.Confirmed = false;
			base.Close();
		}
	}
}
