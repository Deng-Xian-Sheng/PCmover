using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Prism.Mvvm
{
	// Token: 0x02000004 RID: 4
	public abstract class BindableBase : INotifyPropertyChanged
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000014 RID: 20 RVA: 0x0000218C File Offset: 0x0000038C
		// (remove) Token: 0x06000015 RID: 21 RVA: 0x000021C4 File Offset: 0x000003C4
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000016 RID: 22 RVA: 0x000021F9 File Offset: 0x000003F9
		protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			this.RaisePropertyChanged(propertyName);
			return true;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002224 File Offset: 0x00000424
		protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value))
			{
				return false;
			}
			storage = value;
			if (onChanged != null)
			{
				onChanged();
			}
			this.RaisePropertyChanged(propertyName);
			return true;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002259 File Offset: 0x00000459
		protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.OnPropertyChanged(propertyName);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002262 File Offset: 0x00000462
		[Obsolete("Please use the new RaisePropertyChanged method. This method will be removed to comply wth .NET coding standards. If you are overriding this method, you should overide the OnPropertyChanged(PropertyChangedEventArgs args) signature instead.")]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002270 File Offset: 0x00000470
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, args);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002284 File Offset: 0x00000484
		[Obsolete("Please use RaisePropertyChanged(nameof(PropertyName)) instead. Expressions are slower, and the new nameof feature eliminates the magic strings.")]
		protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			string propertyName = PropertySupport.ExtractPropertyName<T>(propertyExpression);
			this.OnPropertyChanged(propertyName);
		}
	}
}
