using System;
using System.ComponentModel;

namespace IntelEMA
{
	// Token: 0x02000005 RID: 5
	public class ConnectableEndpoint : INotifyPropertyChanged
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (remove) Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000003 RID: 3 RVA: 0x000020BD File Offset: 0x000002BD
		public ConnectableEndpoint(EndpointData data)
		{
			this.EndpointData = data;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020CC File Offset: 0x000002CC
		// (set) Token: 0x06000005 RID: 5 RVA: 0x000020D4 File Offset: 0x000002D4
		public EndpointData EndpointData { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020DD File Offset: 0x000002DD
		// (set) Token: 0x06000007 RID: 7 RVA: 0x000020E5 File Offset: 0x000002E5
		public PCmoverStatus Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Status"));
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x0000210C File Offset: 0x0000030C
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000212C File Offset: 0x0000032C
		public PowerStateEnum State
		{
			get
			{
				return (PowerStateEnum)this.EndpointData.PowerState.Value;
			}
			set
			{
				this.EndpointData.PowerState = new int?((int)value);
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("State"));
			}
		}

		// Token: 0x0400001B RID: 27
		private PCmoverStatus _Status;
	}
}
