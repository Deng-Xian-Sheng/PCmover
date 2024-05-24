using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x0200004D RID: 77
	public partial class SelectAzureAccount : UserControl, IHasPopupData
	{
		// Token: 0x17000392 RID: 914
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000A7D1 File Offset: 0x000089D1
		public SelectAzureAccountViewModel Vm { get; }

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x0000A7D9 File Offset: 0x000089D9
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0000A7E8 File Offset: 0x000089E8
		public SelectAzureAccount(IUnityContainer container, SelectAzureAccountData data)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("data", data)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
