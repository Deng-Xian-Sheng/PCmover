using System;
using System.Threading.Tasks;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A6 RID: 166
	public interface IDialogCoordinator
	{
		// Token: 0x060008FE RID: 2302
		Task<string> ShowInputAsync(object context, string title, string message, MetroDialogSettings settings = null);

		// Token: 0x060008FF RID: 2303
		string ShowModalInputExternal(object context, string title, string message, MetroDialogSettings settings = null);

		// Token: 0x06000900 RID: 2304
		Task<LoginDialogData> ShowLoginAsync(object context, string title, string message, LoginDialogSettings settings = null);

		// Token: 0x06000901 RID: 2305
		LoginDialogData ShowModalLoginExternal(object context, string title, string message, LoginDialogSettings settings = null);

		// Token: 0x06000902 RID: 2306
		Task<MessageDialogResult> ShowMessageAsync(object context, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);

		// Token: 0x06000903 RID: 2307
		MessageDialogResult ShowModalMessageExternal(object context, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null);

		// Token: 0x06000904 RID: 2308
		Task<ProgressDialogController> ShowProgressAsync(object context, string title, string message, bool isCancelable = false, MetroDialogSettings settings = null);

		// Token: 0x06000905 RID: 2309
		Task ShowMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null);

		// Token: 0x06000906 RID: 2310
		Task HideMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null);

		// Token: 0x06000907 RID: 2311
		Task<TDialog> GetCurrentDialogAsync<TDialog>(object context) where TDialog : BaseMetroDialog;
	}
}
