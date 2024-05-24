using System;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000027 RID: 39
	internal class CloseCommand : ICommand
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00005311 File Offset: 0x00003511
		public CloseCommand(Func<object, bool> canExecute, Action<object> executeAction)
		{
			this.canExecute = canExecute;
			this.executeAction = executeAction;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005327 File Offset: 0x00003527
		public bool CanExecute(object parameter)
		{
			return this.canExecute != null && this.canExecute(parameter);
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000533F File Offset: 0x0000353F
		public void Execute(object parameter)
		{
			Action<object> action = this.executeAction;
			if (action == null)
			{
				return;
			}
			action(parameter);
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000F0 RID: 240 RVA: 0x00005352 File Offset: 0x00003552
		// (remove) Token: 0x060000F1 RID: 241 RVA: 0x0000535A File Offset: 0x0000355A
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		// Token: 0x0400003B RID: 59
		private readonly Func<object, bool> canExecute;

		// Token: 0x0400003C RID: 60
		private readonly Action<object> executeAction;
	}
}
