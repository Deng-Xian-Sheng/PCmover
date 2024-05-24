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
	// Token: 0x0200004E RID: 78
	public partial class UndoWarning : UserControl, IHasPopupData
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x0000A8A6 File Offset: 0x00008AA6
		public UndoWarningViewModel Vm { get; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000A8AE File Offset: 0x00008AAE
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0000A8BC File Offset: 0x00008ABC
		public UndoWarning(IUnityContainer container, UndoWarningData data)
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
