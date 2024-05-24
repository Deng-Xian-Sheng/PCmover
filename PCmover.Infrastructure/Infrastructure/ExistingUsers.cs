using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003E RID: 62
	public class ExistingUsers : INotifyPropertyChanged
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600032F RID: 815 RVA: 0x00008898 File Offset: 0x00006A98
		// (remove) Token: 0x06000330 RID: 816 RVA: 0x000088D0 File Offset: 0x00006AD0
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000331 RID: 817 RVA: 0x00008905 File Offset: 0x00006B05
		public ExistingUsers()
		{
			this.Users = new ObservableCollection<UserDetail>();
			this.SelectedUser = new UserDetail();
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00008923 File Offset: 0x00006B23
		// (set) Token: 0x06000333 RID: 819 RVA: 0x0000892B File Offset: 0x00006B2B
		private ObservableCollection<UserDetail> _Users { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00008934 File Offset: 0x00006B34
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0000893C File Offset: 0x00006B3C
		public ObservableCollection<UserDetail> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Users"));
			}
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00008960 File Offset: 0x00006B60
		// (set) Token: 0x06000337 RID: 823 RVA: 0x00008968 File Offset: 0x00006B68
		private UserDetail _SelectedUser { get; set; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000338 RID: 824 RVA: 0x00008971 File Offset: 0x00006B71
		// (set) Token: 0x06000339 RID: 825 RVA: 0x00008979 File Offset: 0x00006B79
		public UserDetail SelectedUser
		{
			get
			{
				return this._SelectedUser;
			}
			set
			{
				this._SelectedUser = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("SelectedUser"));
			}
		}
	}
}
