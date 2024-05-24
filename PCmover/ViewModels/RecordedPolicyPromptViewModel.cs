using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Laplink.Tools.Popups;
using PCmover.Infrastructure;
using Prism.Commands;

namespace PCmover.ViewModels
{
	// Token: 0x0200000D RID: 13
	public class RecordedPolicyPromptViewModel : PopupViewModelBase
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00003498 File Offset: 0x00001698
		public RecordedPolicyPromptViewModel(RecordedPolicyPromptData data)
		{
			this._data = data;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = false;
			base.PopupData.IsOpen = true;
			this.OnYes = new DelegateCommand<PasswordBox>(new Action<PasswordBox>(this.OnYesCommand));
			this.OnNo = new DelegateCommand(new Action(this.OnNoCommand));
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003510 File Offset: 0x00001710
		public static bool PromptForRecorded
		{
			get
			{
				bool result;
				try
				{
					if (DefaultPolicy.IgnoreRecorded)
					{
						result = false;
					}
					else if (!File.Exists(DefaultPolicy.RecordedPolicyPath))
					{
						result = false;
					}
					else
					{
						DefaultPolicy defaultPolicy = DefaultPolicy.Load(DefaultPolicy.RecordedPolicyPath);
						if (defaultPolicy.SupressRunPolicyPrompt)
						{
							result = false;
						}
						else
						{
							result = (defaultPolicy.IsComplete != DefaultPolicy.Tristate.True);
						}
					}
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00003574 File Offset: 0x00001774
		// (set) Token: 0x0600008B RID: 139 RVA: 0x0000357C File Offset: 0x0000177C
		public DelegateCommand<PasswordBox> OnYes { get; private set; }

		// Token: 0x0600008C RID: 140 RVA: 0x00003585 File Offset: 0x00001785
		private void OnYesCommand(PasswordBox passwordBox)
		{
			base.PopupData.IsOpen = false;
			this._data.UseRecorded = true;
			this._data.ResetEvent.Set();
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000035B0 File Offset: 0x000017B0
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000035B8 File Offset: 0x000017B8
		public DelegateCommand OnNo { get; private set; }

		// Token: 0x0600008F RID: 143 RVA: 0x000035C1 File Offset: 0x000017C1
		private void OnNoCommand()
		{
			base.PopupData.IsOpen = false;
			this._data.UseRecorded = false;
			this._data.ResetEvent.Set();
		}

		// Token: 0x04000021 RID: 33
		private readonly RecordedPolicyPromptData _data;
	}
}
