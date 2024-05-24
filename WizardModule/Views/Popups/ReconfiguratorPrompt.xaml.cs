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
	// Token: 0x0200004C RID: 76
	public partial class ReconfiguratorPrompt : UserControl, IHasPopupData
	{
		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000A70D File Offset: 0x0000890D
		public ReconfiguratorPromptViewModel Vm { get; }

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000A715 File Offset: 0x00008915
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000A724 File Offset: 0x00008924
		public ReconfiguratorPrompt(IUnityContainer container, ReconfiguratorPromptData data)
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
