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
	// Token: 0x02000044 RID: 68
	public partial class CopyInstaller : UserControl, IHasPopupData
	{
		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000A0BA File Offset: 0x000082BA
		public CopyInstallerViewModel Vm { get; }

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000471 RID: 1137 RVA: 0x0000A0C2 File Offset: 0x000082C2
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000A0D0 File Offset: 0x000082D0
		public CopyInstaller(IUnityContainer container, CopyInstallerData data)
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
