using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007CB RID: 1995
	internal class ServerIdentity : Identity
	{
		// Token: 0x06005689 RID: 22153 RVA: 0x0013315C File Offset: 0x0013135C
		internal Type GetLastCalledType(string newTypeName)
		{
			ServerIdentity.LastCalledType lastCalledType = this._lastCalledType;
			if (lastCalledType == null)
			{
				return null;
			}
			string typeName = lastCalledType.typeName;
			Type type = lastCalledType.type;
			if (typeName == null || type == null)
			{
				return null;
			}
			if (typeName.Equals(newTypeName))
			{
				return type;
			}
			return null;
		}

		// Token: 0x0600568A RID: 22154 RVA: 0x001331A0 File Offset: 0x001313A0
		internal void SetLastCalledType(string newTypeName, Type newType)
		{
			this._lastCalledType = new ServerIdentity.LastCalledType
			{
				typeName = newTypeName,
				type = newType
			};
		}

		// Token: 0x0600568B RID: 22155 RVA: 0x001331C8 File Offset: 0x001313C8
		[SecurityCritical]
		internal void SetHandle()
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(this, ref flag);
				if (!this._srvIdentityHandle.IsAllocated)
				{
					this._srvIdentityHandle = new GCHandle(this, GCHandleType.Normal);
				}
				else
				{
					this._srvIdentityHandle.Target = this;
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(this);
				}
			}
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x00133228 File Offset: 0x00131428
		[SecurityCritical]
		internal void ResetHandle()
		{
			bool flag = false;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				Monitor.Enter(this, ref flag);
				this._srvIdentityHandle.Target = null;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(this);
				}
			}
		}

		// Token: 0x0600568D RID: 22157 RVA: 0x0013326C File Offset: 0x0013146C
		internal GCHandle GetHandle()
		{
			return this._srvIdentityHandle;
		}

		// Token: 0x0600568E RID: 22158 RVA: 0x00133274 File Offset: 0x00131474
		[SecurityCritical]
		internal ServerIdentity(MarshalByRefObject obj, Context serverCtx) : base(obj is ContextBoundObject)
		{
			if (obj != null)
			{
				if (!RemotingServices.IsTransparentProxy(obj))
				{
					this._srvType = obj.GetType();
				}
				else
				{
					RealProxy realProxy = RemotingServices.GetRealProxy(obj);
					this._srvType = realProxy.GetProxiedType();
				}
			}
			this._srvCtx = serverCtx;
			this._serverObjectChain = null;
			this._stackBuilderSink = null;
		}

		// Token: 0x0600568F RID: 22159 RVA: 0x001332D1 File Offset: 0x001314D1
		[SecurityCritical]
		internal ServerIdentity(MarshalByRefObject obj, Context serverCtx, string uri) : this(obj, serverCtx)
		{
			base.SetOrCreateURI(uri, true);
		}

		// Token: 0x17000E37 RID: 3639
		// (get) Token: 0x06005690 RID: 22160 RVA: 0x001332E3 File Offset: 0x001314E3
		internal Context ServerContext
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this._srvCtx;
			}
		}

		// Token: 0x06005691 RID: 22161 RVA: 0x001332EB File Offset: 0x001314EB
		internal void SetSingleCallObjectMode()
		{
			this._flags |= 512;
		}

		// Token: 0x06005692 RID: 22162 RVA: 0x001332FF File Offset: 0x001314FF
		internal void SetSingletonObjectMode()
		{
			this._flags |= 1024;
		}

		// Token: 0x06005693 RID: 22163 RVA: 0x00133313 File Offset: 0x00131513
		internal bool IsSingleCall()
		{
			return (this._flags & 512) != 0;
		}

		// Token: 0x06005694 RID: 22164 RVA: 0x00133324 File Offset: 0x00131524
		internal bool IsSingleton()
		{
			return (this._flags & 1024) != 0;
		}

		// Token: 0x06005695 RID: 22165 RVA: 0x00133338 File Offset: 0x00131538
		[SecurityCritical]
		internal IMessageSink GetServerObjectChain(out MarshalByRefObject obj)
		{
			obj = null;
			if (!this.IsSingleCall())
			{
				if (this._serverObjectChain == null)
				{
					bool flag = false;
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
						Monitor.Enter(this, ref flag);
						if (this._serverObjectChain == null)
						{
							MarshalByRefObject tporObject = base.TPOrObject;
							this._serverObjectChain = this._srvCtx.CreateServerObjectChain(tporObject);
						}
					}
					finally
					{
						if (flag)
						{
							Monitor.Exit(this);
						}
					}
				}
				return this._serverObjectChain;
			}
			MarshalByRefObject marshalByRefObject;
			IMessageSink messageSink;
			if (this._tpOrObject != null && this._firstCallDispatched == 0 && Interlocked.CompareExchange(ref this._firstCallDispatched, 1, 0) == 0)
			{
				marshalByRefObject = (MarshalByRefObject)this._tpOrObject;
				messageSink = this._serverObjectChain;
				if (messageSink == null)
				{
					messageSink = this._srvCtx.CreateServerObjectChain(marshalByRefObject);
				}
			}
			else
			{
				marshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(this._srvType, true);
				string objectUri = RemotingServices.GetObjectUri(marshalByRefObject);
				if (objectUri != null)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_WellKnown_CtorCantMarshal"), base.URI));
				}
				if (!RemotingServices.IsTransparentProxy(marshalByRefObject))
				{
					marshalByRefObject.__RaceSetServerIdentity(this);
				}
				else
				{
					RealProxy realProxy = RemotingServices.GetRealProxy(marshalByRefObject);
					realProxy.IdentityObject = this;
				}
				messageSink = this._srvCtx.CreateServerObjectChain(marshalByRefObject);
			}
			obj = marshalByRefObject;
			return messageSink;
		}

		// Token: 0x17000E38 RID: 3640
		// (get) Token: 0x06005696 RID: 22166 RVA: 0x00133468 File Offset: 0x00131668
		// (set) Token: 0x06005697 RID: 22167 RVA: 0x00133470 File Offset: 0x00131670
		internal Type ServerType
		{
			get
			{
				return this._srvType;
			}
			set
			{
				this._srvType = value;
			}
		}

		// Token: 0x17000E39 RID: 3641
		// (get) Token: 0x06005698 RID: 22168 RVA: 0x00133479 File Offset: 0x00131679
		// (set) Token: 0x06005699 RID: 22169 RVA: 0x00133481 File Offset: 0x00131681
		internal bool MarshaledAsSpecificType
		{
			get
			{
				return this._bMarshaledAsSpecificType;
			}
			set
			{
				this._bMarshaledAsSpecificType = value;
			}
		}

		// Token: 0x0600569A RID: 22170 RVA: 0x0013348C File Offset: 0x0013168C
		[SecurityCritical]
		internal IMessageSink RaceSetServerObjectChain(IMessageSink serverObjectChain)
		{
			if (this._serverObjectChain == null)
			{
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(this, ref flag);
					if (this._serverObjectChain == null)
					{
						this._serverObjectChain = serverObjectChain;
					}
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(this);
					}
				}
			}
			return this._serverObjectChain;
		}

		// Token: 0x0600569B RID: 22171 RVA: 0x001334E4 File Offset: 0x001316E4
		[SecurityCritical]
		internal bool AddServerSideDynamicProperty(IDynamicProperty prop)
		{
			if (this._dphSrv == null)
			{
				DynamicPropertyHolder dphSrv = new DynamicPropertyHolder();
				bool flag = false;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					Monitor.Enter(this, ref flag);
					if (this._dphSrv == null)
					{
						this._dphSrv = dphSrv;
					}
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(this);
					}
				}
			}
			return this._dphSrv.AddDynamicProperty(prop);
		}

		// Token: 0x0600569C RID: 22172 RVA: 0x00133548 File Offset: 0x00131748
		[SecurityCritical]
		internal bool RemoveServerSideDynamicProperty(string name)
		{
			if (this._dphSrv == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_PropNotFound"));
			}
			return this._dphSrv.RemoveDynamicProperty(name);
		}

		// Token: 0x17000E3A RID: 3642
		// (get) Token: 0x0600569D RID: 22173 RVA: 0x0013356E File Offset: 0x0013176E
		internal ArrayWithSize ServerSideDynamicSinks
		{
			[SecurityCritical]
			get
			{
				if (this._dphSrv == null)
				{
					return null;
				}
				return this._dphSrv.DynamicSinks;
			}
		}

		// Token: 0x0600569E RID: 22174 RVA: 0x00133585 File Offset: 0x00131785
		[SecurityCritical]
		internal override void AssertValid()
		{
			if (base.TPOrObject != null)
			{
				RemotingServices.IsTransparentProxy(base.TPOrObject);
			}
		}

		// Token: 0x04002799 RID: 10137
		internal Context _srvCtx;

		// Token: 0x0400279A RID: 10138
		internal IMessageSink _serverObjectChain;

		// Token: 0x0400279B RID: 10139
		internal StackBuilderSink _stackBuilderSink;

		// Token: 0x0400279C RID: 10140
		internal DynamicPropertyHolder _dphSrv;

		// Token: 0x0400279D RID: 10141
		internal Type _srvType;

		// Token: 0x0400279E RID: 10142
		private ServerIdentity.LastCalledType _lastCalledType;

		// Token: 0x0400279F RID: 10143
		internal bool _bMarshaledAsSpecificType;

		// Token: 0x040027A0 RID: 10144
		internal int _firstCallDispatched;

		// Token: 0x040027A1 RID: 10145
		internal GCHandle _srvIdentityHandle;

		// Token: 0x02000C69 RID: 3177
		private class LastCalledType
		{
			// Token: 0x040037D7 RID: 14295
			public string typeName;

			// Token: 0x040037D8 RID: 14296
			public Type type;
		}
	}
}
