using System;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using Prism.Commands;
using Prism.Events;
using Reconfigurator.Infrastructure;

namespace Reconfigurator.ViewModels
{
	// Token: 0x02000009 RID: 9
	public class SkipReplaceUserControlViewModel : PopupViewModelBase
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002370 File Offset: 0x00000570
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002378 File Offset: 0x00000578
		public string ErrorText
		{
			get
			{
				return this._ErrorText;
			}
			private set
			{
				this.SetProperty<string>(ref this._ErrorText, value, "ErrorText");
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000238D File Offset: 0x0000058D
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002395 File Offset: 0x00000595
		public string Title
		{
			get
			{
				return this._Title;
			}
			private set
			{
				this.SetProperty<string>(ref this._Title, value, "Title");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000023AA File Offset: 0x000005AA
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000023B2 File Offset: 0x000005B2
		public bool ShowSkip
		{
			get
			{
				return this._ShowSkip;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowSkip, value, "ShowSkip");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000023C7 File Offset: 0x000005C7
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000023CF File Offset: 0x000005CF
		public bool ShowReplace
		{
			get
			{
				return this._ShowReplace;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowReplace, value, "ShowReplace");
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000023E4 File Offset: 0x000005E4
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000023EC File Offset: 0x000005EC
		public bool ShowContinue
		{
			get
			{
				return this._ShowContinue;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowContinue, value, "ShowContinue");
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002401 File Offset: 0x00000601
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002409 File Offset: 0x00000609
		public bool ShowCancel
		{
			get
			{
				return this._ShowCancel;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowCancel, value, "ShowCancel");
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002D RID: 45 RVA: 0x0000241E File Offset: 0x0000061E
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002426 File Offset: 0x00000626
		public Brush BorderBrush
		{
			get
			{
				return this._BorderBrush;
			}
			private set
			{
				this.SetProperty<Brush>(ref this._BorderBrush, value, "BorderBrush");
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x0000243C File Offset: 0x0000063C
		public SkipReplaceUserControlViewModel(IEventAggregator eventAggregator, TransferError transferError, LlTraceSource ts)
		{
			this.eventAggregator = eventAggregator;
			this.transferError = transferError;
			transferError.ErrorResult = ErrorResult.Cancel;
			base.PopupData.Animation = PopupAnimation.Scroll;
			base.PopupData.IsBlackout = true;
			base.PopupData.UseOverlay = true;
			base.PopupData.IsOpen = true;
			this.OnReplace = new DelegateCommand(new Action(this.OnReplaceCommand));
			this.OnSkip = new DelegateCommand(new Action(this.OnSkipCommand));
			this.OnCancel = new DelegateCommand(new Action(this.OnCancelCommand));
			this.OnContinue = new DelegateCommand(new Action(this.OnContinueCommand));
			this.ShowReplace = transferError.ShowReplace;
			this.ShowSkip = transferError.ShowSkip;
			this.ShowCancel = transferError.ShowCancel;
			this.ShowContinue = transferError.ShowContinue;
			this.ErrorText = transferError.ErrorText;
			this.Title = transferError.Title;
			this.BorderBrush = Brushes.Silver;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002543 File Offset: 0x00000743
		// (set) Token: 0x06000031 RID: 49 RVA: 0x0000254B File Offset: 0x0000074B
		public DelegateCommand OnReplace { get; private set; }

		// Token: 0x06000032 RID: 50 RVA: 0x00002554 File Offset: 0x00000754
		private void OnReplaceCommand()
		{
			this.transferError.ErrorResult = ErrorResult.Replace;
			base.PopupData.IsOpen = false;
			this.eventAggregator.GetEvent<Events.TransferErrorCompleteEvent>().Publish(this.transferError);
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002584 File Offset: 0x00000784
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000258C File Offset: 0x0000078C
		public DelegateCommand OnSkip { get; private set; }

		// Token: 0x06000035 RID: 53 RVA: 0x00002595 File Offset: 0x00000795
		private void OnSkipCommand()
		{
			this.transferError.ErrorResult = ErrorResult.Skip;
			base.PopupData.IsOpen = false;
			this.eventAggregator.GetEvent<Events.TransferErrorCompleteEvent>().Publish(this.transferError);
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000025C5 File Offset: 0x000007C5
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000025CD File Offset: 0x000007CD
		public DelegateCommand OnCancel { get; private set; }

		// Token: 0x06000038 RID: 56 RVA: 0x000025D6 File Offset: 0x000007D6
		private void OnCancelCommand()
		{
			this.transferError.ErrorResult = ErrorResult.Cancel;
			base.PopupData.IsOpen = false;
			this.eventAggregator.GetEvent<Events.TransferErrorCompleteEvent>().Publish(this.transferError);
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002606 File Offset: 0x00000806
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000260E File Offset: 0x0000080E
		public DelegateCommand OnContinue { get; private set; }

		// Token: 0x0600003B RID: 59 RVA: 0x00002617 File Offset: 0x00000817
		private void OnContinueCommand()
		{
			this.transferError.ErrorResult = ErrorResult.Continue;
			base.PopupData.IsOpen = false;
			this.eventAggregator.GetEvent<Events.TransferErrorCompleteEvent>().Publish(this.transferError);
		}

		// Token: 0x0400000A RID: 10
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400000B RID: 11
		private readonly TransferError transferError;

		// Token: 0x0400000C RID: 12
		private string _ErrorText;

		// Token: 0x0400000D RID: 13
		private string _Title;

		// Token: 0x0400000E RID: 14
		private bool _ShowSkip;

		// Token: 0x0400000F RID: 15
		private bool _ShowReplace;

		// Token: 0x04000010 RID: 16
		private bool _ShowContinue;

		// Token: 0x04000011 RID: 17
		private bool _ShowCancel;

		// Token: 0x04000012 RID: 18
		private Brush _BorderBrush;
	}
}
