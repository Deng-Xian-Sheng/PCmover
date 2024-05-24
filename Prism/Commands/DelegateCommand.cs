using System;
using System.Linq.Expressions;
using Prism.Properties;

namespace Prism.Commands
{
	// Token: 0x0200001F RID: 31
	public class DelegateCommand : DelegateCommandBase
	{
		// Token: 0x06000084 RID: 132 RVA: 0x000034CD File Offset: 0x000016CD
		public DelegateCommand(Action executeMethod) : this(executeMethod, () => true)
		{
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000034F5 File Offset: 0x000016F5
		public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
		{
			if (executeMethod == null || canExecuteMethod == null)
			{
				throw new ArgumentNullException("executeMethod", Resources.DelegateCommandDelegatesCannotBeNull);
			}
			this._executeMethod = executeMethod;
			this._canExecuteMethod = canExecuteMethod;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003521 File Offset: 0x00001721
		public void Execute()
		{
			this._executeMethod();
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000352E File Offset: 0x0000172E
		public bool CanExecute()
		{
			return this._canExecuteMethod();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0000353B File Offset: 0x0000173B
		protected override void Execute(object parameter)
		{
			this.Execute();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00003543 File Offset: 0x00001743
		protected override bool CanExecute(object parameter)
		{
			return this.CanExecute();
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000354B File Offset: 0x0000174B
		public DelegateCommand ObservesProperty<T>(Expression<Func<T>> propertyExpression)
		{
			base.ObservesPropertyInternal<T>(propertyExpression);
			return this;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00003555 File Offset: 0x00001755
		public DelegateCommand ObservesCanExecute(Expression<Func<bool>> canExecuteExpression)
		{
			this._canExecuteMethod = canExecuteExpression.Compile();
			base.ObservesPropertyInternal<bool>(canExecuteExpression);
			return this;
		}

		// Token: 0x04000031 RID: 49
		private Action _executeMethod;

		// Token: 0x04000032 RID: 50
		private Func<bool> _canExecuteMethod;
	}
}
