using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000029 RID: 41
	internal static class CommandHelpers
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x0000537C File Offset: 0x0000357C
		internal static bool CanExecuteCommandSource(ICommandSource commandSource)
		{
			ICommand command = commandSource.Command;
			if (command == null)
			{
				return false;
			}
			object parameter = commandSource.CommandParameter ?? commandSource;
			RoutedCommand routedCommand = command as RoutedCommand;
			if (routedCommand != null)
			{
				IInputElement target = commandSource.CommandTarget ?? (commandSource as IInputElement);
				return routedCommand.CanExecute(parameter, target);
			}
			return command.CanExecute(parameter);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000053CC File Offset: 0x000035CC
		[SecurityCritical]
		[SecuritySafeCritical]
		internal static void ExecuteCommandSource(ICommandSource commandSource)
		{
			CommandHelpers.CriticalExecuteCommandSource(commandSource);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000053D4 File Offset: 0x000035D4
		[SecurityCritical]
		internal static void CriticalExecuteCommandSource(ICommandSource commandSource)
		{
			ICommand command = commandSource.Command;
			if (command == null)
			{
				return;
			}
			object parameter = commandSource.CommandParameter ?? commandSource;
			RoutedCommand routedCommand = command as RoutedCommand;
			if (routedCommand != null)
			{
				IInputElement target = commandSource.CommandTarget ?? (commandSource as IInputElement);
				if (routedCommand.CanExecute(parameter, target))
				{
					routedCommand.Execute(parameter, target);
					return;
				}
			}
			else if (command.CanExecute(parameter))
			{
				command.Execute(parameter);
			}
		}
	}
}
