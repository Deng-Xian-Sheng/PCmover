using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using Reconfigurator.Infrastructure;
using Reconfigurator.ViewModels;

namespace Reconfigurator.Views
{
	// Token: 0x02000007 RID: 7
	public partial class SkipReplaceUserControl : UserControl, IHasPopupData
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000226D File Offset: 0x0000046D
		public SkipReplaceUserControlViewModel Vm { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002275 File Offset: 0x00000475
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002284 File Offset: 0x00000484
		public SkipReplaceUserControl(IUnityContainer container, TransferError transferError)
		{
			this.InitializeComponent();
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("transferError", transferError)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
