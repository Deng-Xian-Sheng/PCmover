using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Input;
using Prism.Mvvm;

namespace Prism.Commands
{
	// Token: 0x02000020 RID: 32
	public abstract class DelegateCommandBase : ICommand, IActiveAware
	{
		// Token: 0x0600008C RID: 140 RVA: 0x0000356B File Offset: 0x0000176B
		protected DelegateCommandBase()
		{
			this._synchronizationContext = SynchronizationContext.Current;
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600008D RID: 141 RVA: 0x0000358C File Offset: 0x0000178C
		// (remove) Token: 0x0600008E RID: 142 RVA: 0x000035C4 File Offset: 0x000017C4
		public virtual event EventHandler CanExecuteChanged;

		// Token: 0x0600008F RID: 143 RVA: 0x000035FC File Offset: 0x000017FC
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

		// Token: 0x06000090 RID: 144 RVA: 0x00003669 File Offset: 0x00001869
		public void RaiseCanExecuteChanged()
		{
			this.OnCanExecuteChanged();
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00003671 File Offset: 0x00001871
		void ICommand.Execute(object parameter)
		{
			this.Execute(parameter);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000367A File Offset: 0x0000187A
		bool ICommand.CanExecute(object parameter)
		{
			return this.CanExecute(parameter);
		}

		// Token: 0x06000093 RID: 147
		protected abstract void Execute(object parameter);

		// Token: 0x06000094 RID: 148
		protected abstract bool CanExecute(object parameter);

		// Token: 0x06000095 RID: 149 RVA: 0x00003683 File Offset: 0x00001883
		protected internal void ObservesPropertyInternal<T>(Expression<Func<T>> propertyExpression)
		{
			this.AddPropertyToObserve(PropertySupport.ExtractPropertyName<T>(propertyExpression));
			this.HookInpc(propertyExpression.Body as MemberExpression);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000036A4 File Offset: 0x000018A4
		protected void HookInpc(MemberExpression expression)
		{
			if (expression == null)
			{
				return;
			}
			if (this._inpc == null)
			{
				ConstantExpression constantExpression = expression.Expression as ConstantExpression;
				if (constantExpression != null)
				{
					this._inpc = (constantExpression.Value as INotifyPropertyChanged);
					if (this._inpc != null)
					{
						this._inpc.PropertyChanged += this.Inpc_PropertyChanged;
					}
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000036FC File Offset: 0x000018FC
		protected void AddPropertyToObserve(string property)
		{
			if (this._propertiesToObserve.Contains(property))
			{
				throw new ArgumentException(string.Format("{0} is already being observed.", new object[]
				{
					property
				}));
			}
			this._propertiesToObserve.Add(property);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003733 File Offset: 0x00001933
		private void Inpc_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (this._propertiesToObserve.Contains(e.PropertyName) || (string.IsNullOrEmpty(e.PropertyName) && this._propertiesToObserve.Count > 0))
			{
				this.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00003769 File Offset: 0x00001969
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00003771 File Offset: 0x00001971
		public bool IsActive
		{
			get
			{
				return this._isActive;
			}
			set
			{
				if (this._isActive != value)
				{
					this._isActive = value;
					this.OnIsActiveChanged();
				}
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600009B RID: 155 RVA: 0x0000378C File Offset: 0x0000198C
		// (remove) Token: 0x0600009C RID: 156 RVA: 0x000037C4 File Offset: 0x000019C4
		public virtual event EventHandler IsActiveChanged;

		// Token: 0x0600009D RID: 157 RVA: 0x000037F9 File Offset: 0x000019F9
		protected virtual void OnIsActiveChanged()
		{
			EventHandler isActiveChanged = this.IsActiveChanged;
			if (isActiveChanged == null)
			{
				return;
			}
			isActiveChanged(this, EventArgs.Empty);
		}

		// Token: 0x04000033 RID: 51
		private bool _isActive;

		// Token: 0x04000034 RID: 52
		private SynchronizationContext _synchronizationContext;

		// Token: 0x04000035 RID: 53
		private readonly HashSet<string> _propertiesToObserve = new HashSet<string>();

		// Token: 0x04000036 RID: 54
		private INotifyPropertyChanged _inpc;
	}
}
