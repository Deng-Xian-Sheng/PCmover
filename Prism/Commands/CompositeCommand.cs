using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Prism.Properties;

namespace Prism.Commands
{
	// Token: 0x0200001E RID: 30
	public class CompositeCommand : ICommand
	{
		// Token: 0x06000077 RID: 119 RVA: 0x00003100 File Offset: 0x00001300
		public CompositeCommand()
		{
			this._onRegisteredCommandCanExecuteChangedHandler = new EventHandler(this.OnRegisteredCommandCanExecuteChanged);
			this._synchronizationContext = SynchronizationContext.Current;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003130 File Offset: 0x00001330
		public CompositeCommand(bool monitorCommandActivity) : this()
		{
			this._monitorCommandActivity = monitorCommandActivity;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003140 File Offset: 0x00001340
		public virtual void RegisterCommand(ICommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}
			if (command == this)
			{
				throw new ArgumentException(Resources.CannotRegisterCompositeCommandInItself);
			}
			List<ICommand> registeredCommands = this._registeredCommands;
			lock (registeredCommands)
			{
				if (this._registeredCommands.Contains(command))
				{
					throw new InvalidOperationException(Resources.CannotRegisterSameCommandTwice);
				}
				this._registeredCommands.Add(command);
			}
			command.CanExecuteChanged += this._onRegisteredCommandCanExecuteChangedHandler;
			this.OnCanExecuteChanged();
			if (this._monitorCommandActivity)
			{
				IActiveAware activeAware = command as IActiveAware;
				if (activeAware != null)
				{
					activeAware.IsActiveChanged += this.Command_IsActiveChanged;
				}
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000031F4 File Offset: 0x000013F4
		public virtual void UnregisterCommand(ICommand command)
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}
			List<ICommand> registeredCommands = this._registeredCommands;
			bool flag2;
			lock (registeredCommands)
			{
				flag2 = this._registeredCommands.Remove(command);
			}
			if (flag2)
			{
				command.CanExecuteChanged -= this._onRegisteredCommandCanExecuteChangedHandler;
				this.OnCanExecuteChanged();
				if (this._monitorCommandActivity)
				{
					IActiveAware activeAware = command as IActiveAware;
					if (activeAware != null)
					{
						activeAware.IsActiveChanged -= this.Command_IsActiveChanged;
					}
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00003284 File Offset: 0x00001484
		private void OnRegisteredCommandCanExecuteChanged(object sender, EventArgs e)
		{
			this.OnCanExecuteChanged();
		}

		// Token: 0x0600007C RID: 124 RVA: 0x0000328C File Offset: 0x0000148C
		public virtual bool CanExecute(object parameter)
		{
			bool result = false;
			List<ICommand> registeredCommands = this._registeredCommands;
			ICommand[] array;
			lock (registeredCommands)
			{
				array = this._registeredCommands.ToArray();
			}
			foreach (ICommand command in array)
			{
				if (this.ShouldExecute(command))
				{
					if (!command.CanExecute(parameter))
					{
						return false;
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600007D RID: 125 RVA: 0x0000330C File Offset: 0x0000150C
		// (remove) Token: 0x0600007E RID: 126 RVA: 0x00003344 File Offset: 0x00001544
		public virtual event EventHandler CanExecuteChanged;

		// Token: 0x0600007F RID: 127 RVA: 0x0000337C File Offset: 0x0000157C
		public virtual void Execute(object parameter)
		{
			List<ICommand> registeredCommands = this._registeredCommands;
			Queue<ICommand> queue;
			lock (registeredCommands)
			{
				queue = new Queue<ICommand>(this._registeredCommands.Where(new Func<ICommand, bool>(this.ShouldExecute)).ToList<ICommand>());
				goto IL_4C;
			}
			IL_40:
			queue.Dequeue().Execute(parameter);
			IL_4C:
			if (queue.Count <= 0)
			{
				return;
			}
			goto IL_40;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000033F0 File Offset: 0x000015F0
		protected virtual bool ShouldExecute(ICommand command)
		{
			IActiveAware activeAware = command as IActiveAware;
			return !this._monitorCommandActivity || activeAware == null || activeAware.IsActive;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003418 File Offset: 0x00001618
		public IList<ICommand> RegisteredCommands
		{
			get
			{
				List<ICommand> registeredCommands = this._registeredCommands;
				IList<ICommand> result;
				lock (registeredCommands)
				{
					result = this._registeredCommands.ToList<ICommand>();
				}
				return result;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003460 File Offset: 0x00001660
		protected virtual void OnCanExecuteChanged()
		{
			EventHandler handler = this.CanExecuteChanged;
			if (handler != null)
			{
				if (this._synchronizationContext != null && this._synchronizationContext != SynchronizationContext.Current)
				{
					this._synchronizationContext.Post(delegate(object o)
					{
						handler(this, EventArgs.Empty);
					}, null);
					return;
				}
				handler(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003284 File Offset: 0x00001484
		private void Command_IsActiveChanged(object sender, EventArgs e)
		{
			this.OnCanExecuteChanged();
		}

		// Token: 0x0400002C RID: 44
		private readonly List<ICommand> _registeredCommands = new List<ICommand>();

		// Token: 0x0400002D RID: 45
		private readonly bool _monitorCommandActivity;

		// Token: 0x0400002E RID: 46
		private readonly EventHandler _onRegisteredCommandCanExecuteChangedHandler;

		// Token: 0x0400002F RID: 47
		private SynchronizationContext _synchronizationContext;
	}
}
