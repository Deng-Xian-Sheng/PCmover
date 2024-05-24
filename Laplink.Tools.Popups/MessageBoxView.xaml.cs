using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;

namespace Laplink.Tools.Popups
{
	// Token: 0x02000006 RID: 6
	public partial class MessageBoxView : UserControl, IHasPopupData
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002297 File Offset: 0x00000497
		public MessageBoxViewModel Vm { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000229F File Offset: 0x0000049F
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022AC File Offset: 0x000004AC
		public MessageBoxView(IUnityContainer container, PopupEvents.MessageBoxEventArgs args)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("args", args)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
