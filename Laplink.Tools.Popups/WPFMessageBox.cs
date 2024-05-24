using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace Laplink.Tools.Popups
{
	// Token: 0x0200000E RID: 14
	public class WPFMessageBox
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002C35 File Offset: 0x00000E35
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002C3D File Offset: 0x00000E3D
		public bool Suppress { get; set; }

		// Token: 0x06000074 RID: 116 RVA: 0x00002C48 File Offset: 0x00000E48
		public WPFMessageBox(IUnityContainer container, IEventAggregator eventAggregator, string Msg1, string Caption, uint nType, uint nIDHelp, int nDefault, Action<int> Callback = null, bool wait = true, string Msg2 = null, string Msg3 = null, string Msg4 = null, string Msg5 = null, string Msg6 = null, string Msg7 = null, string Msg8 = null, string Msg9 = null, string Msg10 = null)
		{
			WPFMessageBox <>4__this = this;
			this.container = container;
			this.eventAggregator = eventAggregator;
			this.wait = wait;
			this.Msg1 = Msg1;
			this.Msg2 = Msg2;
			this.Msg3 = Msg3;
			this.Msg4 = Msg4;
			this.Msg5 = Msg5;
			this.Msg6 = Msg6;
			this.Msg7 = Msg7;
			this.Msg8 = Msg8;
			this.Msg9 = Msg9;
			this.Msg10 = Msg10;
			this.Caption = Caption;
			this.nType = nType;
			this.nIDHelp = nIDHelp;
			this.nDefault = nDefault;
			this.Callback = Callback;
			CodeHelper.trycatch(delegate()
			{
				IMessageBoxPolicy messageBoxPolicy = container.Resolve(Array.Empty<ResolverOverride>());
				<>4__this.Suppress = messageBoxPolicy.SuppressMessageBoxes;
			});
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002D20 File Offset: 0x00000F20
		private int DoModal()
		{
			PopupEvents.MessageBoxEventArgs messageBoxEventArgs = new PopupEvents.MessageBoxEventArgs();
			messageBoxEventArgs.Caption = this.Caption;
			messageBoxEventArgs.Message1 = this.Msg1;
			messageBoxEventArgs.Message2 = this.Msg2;
			messageBoxEventArgs.Message3 = this.Msg3;
			messageBoxEventArgs.Message4 = this.Msg4;
			messageBoxEventArgs.Message5 = this.Msg5;
			messageBoxEventArgs.Message6 = this.Msg6;
			messageBoxEventArgs.Message7 = this.Msg7;
			messageBoxEventArgs.Message8 = this.Msg8;
			messageBoxEventArgs.Message9 = this.Msg9;
			messageBoxEventArgs.Message10 = this.Msg10;
			messageBoxEventArgs.WouldBlock = false;
			messageBoxEventArgs.Type = (PopupEvents.MBType)(this.nType & 15U);
			uint num = this.nType & 240U;
			if (num <= 16U)
			{
				if (num == 0U)
				{
					messageBoxEventArgs.Icon = PopupEvents.MBICON.MB_NONE;
					goto IL_101;
				}
				if (num == 16U)
				{
					messageBoxEventArgs.Icon = PopupEvents.MBICON.MB_STOP;
					goto IL_101;
				}
			}
			else
			{
				if (num == 32U)
				{
					messageBoxEventArgs.Icon = PopupEvents.MBICON.MB_QUESTION;
					goto IL_101;
				}
				if (num == 48U)
				{
					messageBoxEventArgs.Icon = PopupEvents.MBICON.MB_WARNING;
					goto IL_101;
				}
				if (num == 64U)
				{
					messageBoxEventArgs.Icon = PopupEvents.MBICON.MB_INFORMATION;
					goto IL_101;
				}
			}
			messageBoxEventArgs.Type = PopupEvents.MBType.MB_OK;
			IL_101:
			if (this.Suppress)
			{
				return this.nDefault;
			}
			bool flag = false;
			if (this.wait)
			{
				messageBoxEventArgs.Callback = new Action<int>(this.ResponseCallback);
				this.StoredCallback = this.Callback;
				flag = (Thread.CurrentThread != Application.Current.Dispatcher.Thread);
				if (!flag)
				{
					messageBoxEventArgs.WouldBlock = true;
				}
			}
			else
			{
				messageBoxEventArgs.Callback = this.Callback;
			}
			this.eventAggregator.GetEvent<PopupEvents.MessageBoxEvent>().Publish(messageBoxEventArgs);
			if (flag)
			{
				this.stopWaitHandle.WaitOne();
			}
			return this.nDefault;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002EBD File Offset: 0x000010BD
		public Task<int> DoModalAsync()
		{
			return Task.Run<int>(new Func<int>(this.DoModal));
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002ED0 File Offset: 0x000010D0
		private void ResponseCallback(int responseCode)
		{
			this.nDefault = responseCode;
			this.stopWaitHandle.Set();
			Action<int> storedCallback = this.StoredCallback;
			if (storedCallback == null)
			{
				return;
			}
			storedCallback(responseCode);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002EF8 File Offset: 0x000010F8
		public static Task<MessageBoxResult> ShowDialogAsync(IUnityContainer container, IEventAggregator e, string Message, string Caption = "", PopupEvents.MBType Buttons = PopupEvents.MBType.MB_OK, MessageBoxImage Icon = MessageBoxImage.None, MessageBoxResult Default = MessageBoxResult.None)
		{
			WPFMessageBox.<ShowDialogAsync>d__28 <ShowDialogAsync>d__;
			<ShowDialogAsync>d__.<>t__builder = AsyncTaskMethodBuilder<MessageBoxResult>.Create();
			<ShowDialogAsync>d__.container = container;
			<ShowDialogAsync>d__.e = e;
			<ShowDialogAsync>d__.Message = Message;
			<ShowDialogAsync>d__.Caption = Caption;
			<ShowDialogAsync>d__.Buttons = Buttons;
			<ShowDialogAsync>d__.Icon = Icon;
			<ShowDialogAsync>d__.Default = Default;
			<ShowDialogAsync>d__.<>1__state = -1;
			<ShowDialogAsync>d__.<>t__builder.Start<WPFMessageBox.<ShowDialogAsync>d__28>(ref <ShowDialogAsync>d__);
			return <ShowDialogAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002F70 File Offset: 0x00001170
		public static Task<MessageBoxResult> ShowDialogAsyncNoSuppress(IUnityContainer container, IEventAggregator e, string Message, string Caption = "", PopupEvents.MBType Buttons = PopupEvents.MBType.MB_OK, MessageBoxImage Icon = MessageBoxImage.None, MessageBoxResult Default = MessageBoxResult.None)
		{
			WPFMessageBox.<ShowDialogAsyncNoSuppress>d__29 <ShowDialogAsyncNoSuppress>d__;
			<ShowDialogAsyncNoSuppress>d__.<>t__builder = AsyncTaskMethodBuilder<MessageBoxResult>.Create();
			<ShowDialogAsyncNoSuppress>d__.container = container;
			<ShowDialogAsyncNoSuppress>d__.e = e;
			<ShowDialogAsyncNoSuppress>d__.Message = Message;
			<ShowDialogAsyncNoSuppress>d__.Caption = Caption;
			<ShowDialogAsyncNoSuppress>d__.Buttons = Buttons;
			<ShowDialogAsyncNoSuppress>d__.Icon = Icon;
			<ShowDialogAsyncNoSuppress>d__.Default = Default;
			<ShowDialogAsyncNoSuppress>d__.<>1__state = -1;
			<ShowDialogAsyncNoSuppress>d__.<>t__builder.Start<WPFMessageBox.<ShowDialogAsyncNoSuppress>d__29>(ref <ShowDialogAsyncNoSuppress>d__);
			return <ShowDialogAsyncNoSuppress>d__.<>t__builder.Task;
		}

		// Token: 0x04000020 RID: 32
		private AutoResetEvent stopWaitHandle = new AutoResetEvent(false);

		// Token: 0x04000021 RID: 33
		private Action<int> StoredCallback;

		// Token: 0x04000022 RID: 34
		private IEventAggregator eventAggregator;

		// Token: 0x04000023 RID: 35
		private IUnityContainer container;

		// Token: 0x04000024 RID: 36
		private bool wait;

		// Token: 0x04000025 RID: 37
		private string Msg1;

		// Token: 0x04000026 RID: 38
		private string Msg2;

		// Token: 0x04000027 RID: 39
		private string Msg3;

		// Token: 0x04000028 RID: 40
		private string Msg4;

		// Token: 0x04000029 RID: 41
		private string Msg5;

		// Token: 0x0400002A RID: 42
		private string Msg6;

		// Token: 0x0400002B RID: 43
		private string Msg7;

		// Token: 0x0400002C RID: 44
		private string Msg8;

		// Token: 0x0400002D RID: 45
		private string Msg9;

		// Token: 0x0400002E RID: 46
		private string Msg10;

		// Token: 0x0400002F RID: 47
		private string Caption;

		// Token: 0x04000030 RID: 48
		private uint nType;

		// Token: 0x04000031 RID: 49
		private uint nIDHelp;

		// Token: 0x04000032 RID: 50
		private int nDefault;

		// Token: 0x04000033 RID: 51
		private Action<int> Callback;
	}
}
