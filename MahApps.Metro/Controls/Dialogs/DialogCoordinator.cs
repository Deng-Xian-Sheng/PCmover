using System;
using System.Threading.Tasks;
using System.Windows;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A2 RID: 162
	public class DialogCoordinator : IDialogCoordinator
	{
		// Token: 0x060008D0 RID: 2256 RVA: 0x000233B8 File Offset: 0x000215B8
		public Task<string> ShowInputAsync(object context, string title, string message, MetroDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.ShowInputAsync(title, message, settings));
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00023404 File Offset: 0x00021604
		public string ShowModalInputExternal(object context, string title, string message, MetroDialogSettings metroDialogSettings = null)
		{
			return DialogCoordinator.GetMetroWindow(context).ShowModalInputExternal(title, message, metroDialogSettings);
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00023418 File Offset: 0x00021618
		public Task<LoginDialogData> ShowLoginAsync(object context, string title, string message, LoginDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.ShowLoginAsync(title, message, settings));
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00023464 File Offset: 0x00021664
		public LoginDialogData ShowModalLoginExternal(object context, string title, string message, LoginDialogSettings settings = null)
		{
			return DialogCoordinator.GetMetroWindow(context).ShowModalLoginExternal(title, message, settings);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00023478 File Offset: 0x00021678
		public Task<MessageDialogResult> ShowMessageAsync(object context, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.ShowMessageAsync(title, message, style, settings));
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x000234CC File Offset: 0x000216CC
		public MessageDialogResult ShowModalMessageExternal(object context, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
		{
			return DialogCoordinator.GetMetroWindow(context).ShowModalMessageExternal(title, message, style, settings);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x000234E0 File Offset: 0x000216E0
		public Task<ProgressDialogController> ShowProgressAsync(object context, string title, string message, bool isCancelable = false, MetroDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.ShowProgressAsync(title, message, isCancelable, settings));
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00023534 File Offset: 0x00021734
		public Task ShowMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.ShowMetroDialogAsync(dialog, settings));
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00023578 File Offset: 0x00021778
		public Task HideMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null)
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.HideMetroDialogAsync(dialog, settings));
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x000235BC File Offset: 0x000217BC
		public Task<TDialog> GetCurrentDialogAsync<TDialog>(object context) where TDialog : BaseMetroDialog
		{
			MetroWindow metroWindow = DialogCoordinator.GetMetroWindow(context);
			return metroWindow.Invoke(() => metroWindow.GetCurrentDialogAsync<TDialog>());
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000235F4 File Offset: 0x000217F4
		private static MetroWindow GetMetroWindow(object context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (!DialogParticipation.IsRegistered(context))
			{
				throw new InvalidOperationException("Context is not registered. Consider using DialogParticipation.Register in XAML to bind in the DataContext.");
			}
			DependencyObject association = DialogParticipation.GetAssociation(context);
			MetroWindow metroWindow = association.Invoke(() => Window.GetWindow(association) as MetroWindow);
			if (metroWindow == null)
			{
				throw new InvalidOperationException("Context is not inside a MetroWindow.");
			}
			return metroWindow;
		}

		// Token: 0x040003F1 RID: 1009
		public static readonly IDialogCoordinator Instance = new DialogCoordinator();
	}
}
