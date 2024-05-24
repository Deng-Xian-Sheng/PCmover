using System;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x02000009 RID: 9
	public class ServiceInterfaces<C, Q> where C : Q
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002826 File Offset: 0x00000A26
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002841 File Offset: 0x00000A41
		public C ControlInterface
		{
			get
			{
				C controlInterfaceValue = this.ControlInterfaceValue;
				if (controlInterfaceValue == null)
				{
					throw new NoInterfaceCommunicationException("Control");
				}
				return controlInterfaceValue;
			}
			set
			{
				this.ControlInterfaceValue = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004E RID: 78 RVA: 0x0000284A File Offset: 0x00000A4A
		public bool HasControlInterface
		{
			get
			{
				return this.ControlInterfaceValue != null;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600004F RID: 79 RVA: 0x0000285A File Offset: 0x00000A5A
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002862 File Offset: 0x00000A62
		public C ControlInterfaceValue { get; private set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000286B File Offset: 0x00000A6B
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002886 File Offset: 0x00000A86
		public Q QueryInterface
		{
			get
			{
				Q queryInterfaceValue = this.QueryInterfaceValue;
				if (queryInterfaceValue == null)
				{
					throw new NoInterfaceCommunicationException("Query");
				}
				return queryInterfaceValue;
			}
			set
			{
				this.QueryInterfaceValue = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000288F File Offset: 0x00000A8F
		// (set) Token: 0x06000054 RID: 84 RVA: 0x000028B5 File Offset: 0x00000AB5
		public Q QueryInterfaceValue
		{
			get
			{
				if (this._queryInterfaceValue != null)
				{
					return this._queryInterfaceValue;
				}
				return (Q)((object)this.ControlInterfaceValue);
			}
			set
			{
				this._queryInterfaceValue = value;
			}
		}

		// Token: 0x0400001B RID: 27
		private Q _queryInterfaceValue;
	}
}
