using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace Laplink.Tools.Popups
{
	// Token: 0x02000008 RID: 8
	public class PopupContainerViewModelBase : BindableBase, IPopupRoot
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002781 File Offset: 0x00000981
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002790 File Offset: 0x00000990
		public bool IsBlackout
		{
			get
			{
				return this.PopupData.IsBlackout;
			}
			set
			{
				if (value)
				{
					this.PopupData.IsBlackout = true;
					return;
				}
				if (this.PopupData.IsBlackout && (!this.PopupData.IsOpen || !this.PopupData.BlackoutWhenOpen))
				{
					this.PopupData.IsBlackout = false;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000027E0 File Offset: 0x000009E0
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000027E8 File Offset: 0x000009E8
		public PopupData PopupData
		{
			get
			{
				return this._popupData;
			}
			set
			{
				if (value != this._popupData)
				{
					if (this._popupData != null && this._popupData.IsOpen)
					{
						this._popupDataQueue.Enqueue(value);
						return;
					}
					if (this._popupData != null)
					{
						this._popupData.PropertyChanged -= this.PopupData_PropertyChanged;
					}
					if (value != null)
					{
						value.PropertyChanged += this.PopupData_PropertyChanged;
					}
					this.SetProperty<PopupData>(ref this._popupData, value, "PopupData");
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002867 File Offset: 0x00000A67
		private void PopupData_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsOpen" && !this.PopupData.IsOpen && this._popupDataQueue.Any<PopupData>())
			{
				this.PopupData = this._popupDataQueue.Dequeue();
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000028A6 File Offset: 0x00000AA6
		protected PopupContainerViewModelBase()
		{
			this.PopupData = new PopupData();
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000028C4 File Offset: 0x00000AC4
		protected PopupContainerViewModelBase(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.container = container;
			this.eventAggregator = eventAggregator;
			this.PopupData = new PopupData();
			eventAggregator.GetEvent<PopupEvents.ShowPopup>().Subscribe(new Action<PopupEvents.ResolveInfo>(this.OnShowPopup), ThreadOption.UIThread);
			eventAggregator.GetEvent<PopupEvents.MessageBoxEvent>().Subscribe(new Action<PopupEvents.MessageBoxEventArgs>(this.ShowMessageBox), ThreadOption.UIThread, false);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00002930 File Offset: 0x00000B30
		protected void OnShowPopup(PopupEvents.ResolveInfo resolveInfo)
		{
			if (resolveInfo == null)
			{
				return;
			}
			IHasPopupData hasPopupData = resolveInfo.Resolve(this.container) as IHasPopupData;
			if (hasPopupData == null)
			{
				return;
			}
			this.PopupData = hasPopupData.PopupData;
			hasPopupData.PopupData.IsOpen = true;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000296F File Offset: 0x00000B6F
		private void ShowMessageBox(PopupEvents.MessageBoxEventArgs args)
		{
			this.OnShowPopup(new PopupEvents.ResolveInfo(typeof(MessageBoxView), new ParameterOverride("args", args)));
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00002991 File Offset: 0x00000B91
		public void DisablePopupRoot()
		{
			this.IsBlackout = true;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000299A File Offset: 0x00000B9A
		public void EnablePopupRoot()
		{
			this.IsBlackout = false;
		}

		// Token: 0x0400000E RID: 14
		protected readonly IUnityContainer container;

		// Token: 0x0400000F RID: 15
		protected readonly IEventAggregator eventAggregator;

		// Token: 0x04000010 RID: 16
		private Queue<PopupData> _popupDataQueue = new Queue<PopupData>();

		// Token: 0x04000011 RID: 17
		private PopupData _popupData;
	}
}
