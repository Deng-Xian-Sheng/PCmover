using System;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using WizardModule.Properties;

namespace WizardModule.ViewModels.Popups
{
	// Token: 0x020000A9 RID: 169
	public class ProxyCredentialsViewModel : PopupViewModelBase
	{
		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x06000EBF RID: 3775 RVA: 0x0002776F File Offset: 0x0002596F
		// (set) Token: 0x06000EC0 RID: 3776 RVA: 0x00027777 File Offset: 0x00025977
		public string ProxyText
		{
			get
			{
				return this._ProxyText;
			}
			private set
			{
				this.SetProperty<string>(ref this._ProxyText, value, "ProxyText");
			}
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00026FEC File Offset: 0x000251EC
		[Obsolete("Design only")]
		public ProxyCredentialsViewModel()
		{
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x0002778C File Offset: 0x0002598C
		public ProxyCredentialsViewModel(IUnityContainer container, IEventAggregator eventAggregator, IPCmoverEngine engine, EngineEvents.ProxyCredentialsData configData)
		{
			this._container = container;
			this._eventAggregator = eventAggregator;
			this._engine = engine;
			this._configData = configData;
			base.PopupData.Animation = PopupAnimation.Fade;
			this.OnSetProxyCredentials = new DelegateCommand<object>(new Action<object>(this.OnSetProxyCredentialsCommand), new Func<object, bool>(this.CanOnSetProxyCredentialsCommand));
			this.OnCancelProxy = new DelegateCommand(new Action(this.OnCancelProxyCommand), new Func<bool>(this.CanOnCancelProxyCommand));
			this.ProxyText = string.Format(Resources.ProxyPrompt, configData.ProxyServer);
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06000EC3 RID: 3779 RVA: 0x00027825 File Offset: 0x00025A25
		// (set) Token: 0x06000EC4 RID: 3780 RVA: 0x0002782D File Offset: 0x00025A2D
		public DelegateCommand<object> OnSetProxyCredentials { get; private set; }

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSetProxyCredentialsCommand(object parameter)
		{
			return true;
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00027838 File Offset: 0x00025A38
		private bool? SetResult(bool result)
		{
			if (this._configData.Tcs != null)
			{
				return new bool?(this._configData.Tcs.TrySetResult(result));
			}
			IPCmoverEngine engine = this._engine;
			if (engine == null)
			{
				return null;
			}
			return new bool?(engine.CatchCommEx(delegate
			{
				this._engine.SendCallbackReply(this._configData.ReplyHandle, result ? 1 : 0);
			}, "SetResult"));
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x000278B4 File Offset: 0x00025AB4
		private void OnSetProxyCredentialsCommand(object parameter)
		{
			if (parameter != null)
			{
				try
				{
					object[] array = (object[])parameter;
					string userName = (string)array[0];
					PasswordBox passwordBox = array[1] as PasswordBox;
					if (!string.IsNullOrWhiteSpace(userName))
					{
						string password = passwordBox.Password;
						base.PopupData.IsOpen = false;
						IPCmoverEngine engine = this._engine;
						if (engine != null)
						{
							engine.CatchCommEx(delegate
							{
								this._engine.SetProxyAuth(this._configData.ProxyServer, userName, password);
								this.SetResult(true);
							}, "OnSetProxyCredentialsCommand");
						}
					}
				}
				catch (Exception)
				{
					base.PopupData.IsOpen = false;
					this.SetResult(false);
				}
			}
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x00027960 File Offset: 0x00025B60
		// (set) Token: 0x06000EC9 RID: 3785 RVA: 0x00027968 File Offset: 0x00025B68
		public DelegateCommand OnCancelProxy { get; private set; }

		// Token: 0x06000ECA RID: 3786 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCancelProxyCommand()
		{
			return true;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00027974 File Offset: 0x00025B74
		private void OnCancelProxyCommand()
		{
			ProxyCredentialsViewModel.<OnCancelProxyCommand>d__22 <OnCancelProxyCommand>d__;
			<OnCancelProxyCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCancelProxyCommand>d__.<>4__this = this;
			<OnCancelProxyCommand>d__.<>1__state = -1;
			<OnCancelProxyCommand>d__.<>t__builder.Start<ProxyCredentialsViewModel.<OnCancelProxyCommand>d__22>(ref <OnCancelProxyCommand>d__);
		}

		// Token: 0x040004FF RID: 1279
		private string _ProxyText;

		// Token: 0x04000500 RID: 1280
		private readonly IUnityContainer _container;

		// Token: 0x04000501 RID: 1281
		private readonly IEventAggregator _eventAggregator;

		// Token: 0x04000502 RID: 1282
		private readonly IPCmoverEngine _engine;

		// Token: 0x04000503 RID: 1283
		private readonly EngineEvents.ProxyCredentialsData _configData;
	}
}
