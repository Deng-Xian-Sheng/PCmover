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
	// Token: 0x0200007C RID: 124
	public partial class DefaultNotificationWindow : Window
	{
		// Token: 0x06000397 RID: 919 RVA: 0x0000936B File Offset: 0x0000756B
		public DefaultNotificationWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00009379 File Offset: 0x00007579
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000928A File Offset: 0x0000748A
		public INotification Notification
		{
			get
			{
				return base.DataContext as INotification;
			}
			set
			{
				base.DataContext = value;
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00009386 File Offset: 0x00007586
		private void OKButton_Click(object sender, RoutedEventArgs e)
		{
			base.Close();
		}
	}
}
