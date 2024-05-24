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
using PCmover.Infrastructure;
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x0200004A RID: 74
	public partial class ProxyCredentials : UserControl, IHasPopupData
	{
		// Token: 0x1700038C RID: 908
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x0000A562 File Offset: 0x00008762
		public ProxyCredentialsViewModel Vm { get; }

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000A56A File Offset: 0x0000876A
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000A578 File Offset: 0x00008778
		public ProxyCredentials(IUnityContainer container, EngineEvents.ProxyCredentialsData configData)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("configData", configData)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
