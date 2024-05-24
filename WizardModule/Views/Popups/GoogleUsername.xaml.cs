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
	// Token: 0x02000045 RID: 69
	public partial class GoogleUsername : UserControl, IHasPopupData
	{
		// Token: 0x17000382 RID: 898
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000A17D File Offset: 0x0000837D
		public GoogleUsernameViewModel Vm { get; }

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000A185 File Offset: 0x00008385
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000A194 File Offset: 0x00008394
		public GoogleUsername(IUnityContainer container, GoogleUsernameData data)
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
