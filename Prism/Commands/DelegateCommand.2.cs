using System;
using System.Linq.Expressions;
using System.Reflection;
using Prism.Properties;

namespace Prism.Commands
{
	// Token: 0x02000021 RID: 33
	public class DelegateCommand<T> : DelegateCommandBase
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00003811 File Offset: 0x00001A11
		public DelegateCommand(Action<T> executeMethod) : this(executeMethod, (T o) => true)
		{
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000383C File Offset: 0x00001A3C
		public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
		{
			if (executeMethod == null || canExecuteMethod == null)
			{
				throw new ArgumentNullException("executeMethod", Resources.DelegateCommandDelegatesCannotBeNull);
			}
			TypeInfo typeInfo = typeof(T).GetTypeInfo();
			if (typeInfo.IsValueType && (!typeInfo.IsGenericType || !typeof(Nullable<>).GetTypeInfo().IsAssignableFrom(typeInfo.GetGenericTypeDefinition().GetTypeInfo())))
			{
				throw new InvalidCastException(Resources.DelegateCommandInvalidGenericPayloadType);
			}
			this._executeMethod = executeMethod;
			this._canExecuteMethod = canExecuteMethod;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000038BF File Offset: 0x00001ABF
		public void Execute(T parameter)
		{
			this._executeMethod(parameter);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000038CD File Offset: 0x00001ACD
		public bool CanExecute(T parameter)
		{
			return this._canExecuteMethod(parameter);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000038DB File Offset: 0x00001ADB
		protected override void Execute(object parameter)
		{
			this.Execute((T)((object)parameter));
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000038E9 File Offset: 0x00001AE9
		protected override bool CanExecute(object parameter)
		{
			return this.CanExecute((T)((object)parameter));
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000038F7 File Offset: 0x00001AF7
		public DelegateCommand<T> ObservesProperty<TType>(Expression<Func<TType>> propertyExpression)
		{
			base.ObservesPropertyInternal<TType>(propertyExpression);
			return this;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003904 File Offset: 0x00001B04
		public DelegateCommand<T> ObservesCanExecute(Expression<Func<bool>> canExecuteExpression)
		{
			Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(canExecuteExpression.Body, new ParameterExpression[]
			{
				Expression.Parameter(typeof(T), "o")
			});
			this._canExecuteMethod = expression.Compile();
			base.ObservesPropertyInternal<bool>(canExecuteExpression);
			return this;
		}

		// Token: 0x04000039 RID: 57
		private readonly Action<T> _executeMethod;

		// Token: 0x0400003A RID: 58
		private Func<T, bool> _canExecuteMethod;
	}
}
