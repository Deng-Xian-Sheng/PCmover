using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007AD RID: 1965
	internal class DomainSpecificRemotingData
	{
		// Token: 0x06005509 RID: 21769 RVA: 0x0012E23C File Offset: 0x0012C43C
		internal DomainSpecificRemotingData()
		{
			this._flags = 0;
			this._ConfigLock = new object();
			this._ChannelServicesData = new ChannelServicesData();
			this._IDTableLock = new ReaderWriterLock();
			this._appDomainProperties = new IContextProperty[1];
			this._appDomainProperties[0] = new LeaseLifeTimeServiceProperty();
		}

		// Token: 0x17000DF6 RID: 3574
		// (get) Token: 0x0600550A RID: 21770 RVA: 0x0012E290 File Offset: 0x0012C490
		// (set) Token: 0x0600550B RID: 21771 RVA: 0x0012E298 File Offset: 0x0012C498
		internal LeaseManager LeaseManager
		{
			get
			{
				return this._LeaseManager;
			}
			set
			{
				this._LeaseManager = value;
			}
		}

		// Token: 0x17000DF7 RID: 3575
		// (get) Token: 0x0600550C RID: 21772 RVA: 0x0012E2A1 File Offset: 0x0012C4A1
		internal object ConfigLock
		{
			get
			{
				return this._ConfigLock;
			}
		}

		// Token: 0x17000DF8 RID: 3576
		// (get) Token: 0x0600550D RID: 21773 RVA: 0x0012E2A9 File Offset: 0x0012C4A9
		internal ReaderWriterLock IDTableLock
		{
			get
			{
				return this._IDTableLock;
			}
		}

		// Token: 0x17000DF9 RID: 3577
		// (get) Token: 0x0600550E RID: 21774 RVA: 0x0012E2B1 File Offset: 0x0012C4B1
		// (set) Token: 0x0600550F RID: 21775 RVA: 0x0012E2B9 File Offset: 0x0012C4B9
		internal LocalActivator LocalActivator
		{
			[SecurityCritical]
			get
			{
				return this._LocalActivator;
			}
			[SecurityCritical]
			set
			{
				this._LocalActivator = value;
			}
		}

		// Token: 0x17000DFA RID: 3578
		// (get) Token: 0x06005510 RID: 21776 RVA: 0x0012E2C2 File Offset: 0x0012C4C2
		// (set) Token: 0x06005511 RID: 21777 RVA: 0x0012E2CA File Offset: 0x0012C4CA
		internal ActivationListener ActivationListener
		{
			get
			{
				return this._ActivationListener;
			}
			set
			{
				this._ActivationListener = value;
			}
		}

		// Token: 0x17000DFB RID: 3579
		// (get) Token: 0x06005512 RID: 21778 RVA: 0x0012E2D3 File Offset: 0x0012C4D3
		// (set) Token: 0x06005513 RID: 21779 RVA: 0x0012E2E0 File Offset: 0x0012C4E0
		internal bool InitializingActivation
		{
			get
			{
				return (this._flags & 1) == 1;
			}
			set
			{
				if (value)
				{
					this._flags |= 1;
					return;
				}
				this._flags &= -2;
			}
		}

		// Token: 0x17000DFC RID: 3580
		// (get) Token: 0x06005514 RID: 21780 RVA: 0x0012E303 File Offset: 0x0012C503
		// (set) Token: 0x06005515 RID: 21781 RVA: 0x0012E310 File Offset: 0x0012C510
		internal bool ActivationInitialized
		{
			get
			{
				return (this._flags & 2) == 2;
			}
			set
			{
				if (value)
				{
					this._flags |= 2;
					return;
				}
				this._flags &= -3;
			}
		}

		// Token: 0x17000DFD RID: 3581
		// (get) Token: 0x06005516 RID: 21782 RVA: 0x0012E333 File Offset: 0x0012C533
		// (set) Token: 0x06005517 RID: 21783 RVA: 0x0012E340 File Offset: 0x0012C540
		internal bool ActivatorListening
		{
			get
			{
				return (this._flags & 4) == 4;
			}
			set
			{
				if (value)
				{
					this._flags |= 4;
					return;
				}
				this._flags &= -5;
			}
		}

		// Token: 0x17000DFE RID: 3582
		// (get) Token: 0x06005518 RID: 21784 RVA: 0x0012E363 File Offset: 0x0012C563
		internal IContextProperty[] AppDomainContextProperties
		{
			get
			{
				return this._appDomainProperties;
			}
		}

		// Token: 0x17000DFF RID: 3583
		// (get) Token: 0x06005519 RID: 21785 RVA: 0x0012E36B File Offset: 0x0012C56B
		internal ChannelServicesData ChannelServicesData
		{
			get
			{
				return this._ChannelServicesData;
			}
		}

		// Token: 0x04002724 RID: 10020
		private const int ACTIVATION_INITIALIZING = 1;

		// Token: 0x04002725 RID: 10021
		private const int ACTIVATION_INITIALIZED = 2;

		// Token: 0x04002726 RID: 10022
		private const int ACTIVATOR_LISTENING = 4;

		// Token: 0x04002727 RID: 10023
		[SecurityCritical]
		private LocalActivator _LocalActivator;

		// Token: 0x04002728 RID: 10024
		private ActivationListener _ActivationListener;

		// Token: 0x04002729 RID: 10025
		private IContextProperty[] _appDomainProperties;

		// Token: 0x0400272A RID: 10026
		private int _flags;

		// Token: 0x0400272B RID: 10027
		private object _ConfigLock;

		// Token: 0x0400272C RID: 10028
		private ChannelServicesData _ChannelServicesData;

		// Token: 0x0400272D RID: 10029
		private LeaseManager _LeaseManager;

		// Token: 0x0400272E RID: 10030
		private ReaderWriterLock _IDTableLock;
	}
}
