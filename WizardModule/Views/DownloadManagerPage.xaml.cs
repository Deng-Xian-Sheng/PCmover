using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels;

namespace WizardModule.Views
{
	// Token: 0x02000026 RID: 38
	public partial class DownloadManagerPage : UserControl
	{
		// Token: 0x06000412 RID: 1042 RVA: 0x00009017 File Offset: 0x00007217
		public DownloadManagerPage(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Init();
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00009058 File Offset: 0x00007258
		private void Init()
		{
			DownloadManagerPage.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<DownloadManagerPage.<Init>d__1>(ref <Init>d__);
		}
	}
}
