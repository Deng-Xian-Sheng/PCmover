using System;
using System.Windows.Media;
using Prism.Commands;

namespace Laplink.Tools.Popups
{
	// Token: 0x02000007 RID: 7
	public class MessageBoxViewModel : PopupViewModelBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002359 File Offset: 0x00000559
		public PopupEvents.MessageBoxEventArgs Args { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002361 File Offset: 0x00000561
		public Brush MBBorderBrush
		{
			get
			{
				if (!this.Args.WouldBlock)
				{
					return Brushes.Silver;
				}
				return Brushes.Red;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000237B File Offset: 0x0000057B
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002383 File Offset: 0x00000583
		public string MBIcon
		{
			get
			{
				return this._mbIcon;
			}
			private set
			{
				this.SetProperty<string>(ref this._mbIcon, value, "MBIcon");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002398 File Offset: 0x00000598
		public bool IsIconVisible
		{
			get
			{
				return this.Args.Icon > PopupEvents.MBICON.MB_NONE;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000023A8 File Offset: 0x000005A8
		public bool IsMBYesVisible
		{
			get
			{
				return this.Args.Type == PopupEvents.MBType.MB_YESNO || this.Args.Type == PopupEvents.MBType.MB_YESNOCANCEL;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000023C8 File Offset: 0x000005C8
		public bool IsMBNoVisible
		{
			get
			{
				return this.IsMBYesVisible;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000023D0 File Offset: 0x000005D0
		public bool IsMBOKVisible
		{
			get
			{
				switch (this.Args.Type)
				{
				case PopupEvents.MBType.MB_OK:
				case PopupEvents.MBType.MB_OKCANCEL:
					return true;
				case PopupEvents.MBType.MB_YESNOCANCEL:
				case PopupEvents.MBType.MB_YESNO:
				case PopupEvents.MBType.MB_CANCELCONTINUE:
					return false;
				}
				return true;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002414 File Offset: 0x00000614
		public bool IsMBCancelVisible
		{
			get
			{
				PopupEvents.MBType type = this.Args.Type;
				return type == PopupEvents.MBType.MB_OKCANCEL || type == PopupEvents.MBType.MB_YESNOCANCEL || type == PopupEvents.MBType.MB_CANCELCONTINUE;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000243C File Offset: 0x0000063C
		public bool IsMBContinueVisible
		{
			get
			{
				return this.Args.Type == PopupEvents.MBType.MB_CANCELCONTINUE;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000244C File Offset: 0x0000064C
		public string MBCaption
		{
			get
			{
				return this.Args.Caption;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002459 File Offset: 0x00000659
		public string MBMessage1
		{
			get
			{
				return this.Args.Message1;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002466 File Offset: 0x00000666
		public string MBMessage2
		{
			get
			{
				return this.Args.Message2;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002473 File Offset: 0x00000673
		public string MBMessage3
		{
			get
			{
				return this.Args.Message3;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002480 File Offset: 0x00000680
		public string MBMessage4
		{
			get
			{
				return this.Args.Message4;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000248D File Offset: 0x0000068D
		public string MBMessage5
		{
			get
			{
				return this.Args.Message5;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000249A File Offset: 0x0000069A
		public string MBMessage6
		{
			get
			{
				return this.Args.Message6;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000026 RID: 38 RVA: 0x000024A7 File Offset: 0x000006A7
		public string MBMessage7
		{
			get
			{
				return this.Args.Message7;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000024B4 File Offset: 0x000006B4
		public string MBMessage8
		{
			get
			{
				return this.Args.Message8;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000024C1 File Offset: 0x000006C1
		public string MBMessage9
		{
			get
			{
				return this.Args.Message9;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000024CE File Offset: 0x000006CE
		public string MBMessage10
		{
			get
			{
				return this.Args.Message10;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002A RID: 42 RVA: 0x000024DB File Offset: 0x000006DB
		public Action<int> MBCallback
		{
			get
			{
				return this.Args.Callback;
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000024E8 File Offset: 0x000006E8
		[Obsolete("For design only", true)]
		public MessageBoxViewModel()
		{
			this.Args = new PopupEvents.MessageBoxEventArgs
			{
				Message1 = "Message",
				Caption = "Caption",
				Type = PopupEvents.MBType.MB_YESNO
			};
			this.SetIcon();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002534 File Offset: 0x00000734
		public MessageBoxViewModel(PopupEvents.MessageBoxEventArgs args)
		{
			this.Args = args;
			this.SetIcon();
			this.OnMBYes = new DelegateCommand(new Action(this.OnMBYesCommand), new Func<bool>(this.CanOnMBYesCommand));
			this.OnMBNo = new DelegateCommand(new Action(this.OnMBNoCommand), new Func<bool>(this.CanOnMBNoCommand));
			this.OnMBOK = new DelegateCommand(new Action(this.OnMBOKCommand), new Func<bool>(this.CanOnMBOKCommand));
			this.OnMBCancel = new DelegateCommand(new Action(this.OnMBCancelCommand), new Func<bool>(this.CanOnMBCancelCommand));
			this.OnMBContinue = new DelegateCommand(new Action(this.OnMBContinueCommand), new Func<bool>(this.CanOnMBContinueCommand));
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002610 File Offset: 0x00000810
		private void SetIcon()
		{
			string text;
			switch (this.Args.Icon)
			{
			case PopupEvents.MBICON.MB_NONE:
				text = "NoneIcon.png";
				break;
			case PopupEvents.MBICON.MB_EXCLAMATION:
			case PopupEvents.MBICON.MB_WARNING:
				text = "ExclamationIcon.png";
				break;
			case PopupEvents.MBICON.MB_INFORMATION:
				text = "InfoIcon.png";
				break;
			case PopupEvents.MBICON.MB_QUESTION:
				text = "QuestionIcon.png";
				break;
			case PopupEvents.MBICON.MB_STOP:
				text = "ErrorIcon.png";
				break;
			default:
				text = "InfoIcon.png";
				break;
			}
			if (text != null)
			{
				this.MBIcon = "/Laplink.Tools.Popups;component/Assets/" + text;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002E RID: 46 RVA: 0x0000268D File Offset: 0x0000088D
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002695 File Offset: 0x00000895
		public DelegateCommand OnMBYes { get; private set; }

		// Token: 0x06000030 RID: 48 RVA: 0x0000269E File Offset: 0x0000089E
		private bool CanOnMBYesCommand()
		{
			return true;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000026A1 File Offset: 0x000008A1
		private void OnMBYesCommand()
		{
			Action<int> mbcallback = this.MBCallback;
			if (mbcallback != null)
			{
				mbcallback(6);
			}
			this.CloseMessageBox();
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000026BB File Offset: 0x000008BB
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000026C3 File Offset: 0x000008C3
		public DelegateCommand OnMBNo { get; private set; }

		// Token: 0x06000034 RID: 52 RVA: 0x000026CC File Offset: 0x000008CC
		private bool CanOnMBNoCommand()
		{
			return true;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000026CF File Offset: 0x000008CF
		private void OnMBNoCommand()
		{
			Action<int> mbcallback = this.MBCallback;
			if (mbcallback != null)
			{
				mbcallback(7);
			}
			this.CloseMessageBox();
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000036 RID: 54 RVA: 0x000026E9 File Offset: 0x000008E9
		// (set) Token: 0x06000037 RID: 55 RVA: 0x000026F1 File Offset: 0x000008F1
		public DelegateCommand OnMBOK { get; private set; }

		// Token: 0x06000038 RID: 56 RVA: 0x000026FA File Offset: 0x000008FA
		private bool CanOnMBOKCommand()
		{
			return true;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000026FD File Offset: 0x000008FD
		private void OnMBOKCommand()
		{
			Action<int> mbcallback = this.MBCallback;
			if (mbcallback != null)
			{
				mbcallback(1);
			}
			this.CloseMessageBox();
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002717 File Offset: 0x00000917
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000271F File Offset: 0x0000091F
		public DelegateCommand OnMBCancel { get; private set; }

		// Token: 0x0600003C RID: 60 RVA: 0x00002728 File Offset: 0x00000928
		private bool CanOnMBCancelCommand()
		{
			return true;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000272B File Offset: 0x0000092B
		private void OnMBCancelCommand()
		{
			Action<int> mbcallback = this.MBCallback;
			if (mbcallback != null)
			{
				mbcallback(2);
			}
			this.CloseMessageBox();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002745 File Offset: 0x00000945
		// (set) Token: 0x0600003F RID: 63 RVA: 0x0000274D File Offset: 0x0000094D
		public DelegateCommand OnMBContinue { get; private set; }

		// Token: 0x06000040 RID: 64 RVA: 0x00002756 File Offset: 0x00000956
		private bool CanOnMBContinueCommand()
		{
			return true;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002759 File Offset: 0x00000959
		private void OnMBContinueCommand()
		{
			Action<int> mbcallback = this.MBCallback;
			if (mbcallback != null)
			{
				mbcallback(1);
			}
			this.CloseMessageBox();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00002773 File Offset: 0x00000973
		private void CloseMessageBox()
		{
			base.PopupData.IsOpen = false;
		}

		// Token: 0x04000008 RID: 8
		private string _mbIcon = "/Laplink.Tools.Popups;component/Assets/NoneIcon.png";
	}
}
