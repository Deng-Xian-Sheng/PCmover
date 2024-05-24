using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Contexts
{
	// Token: 0x02000808 RID: 2056
	[ComVisible(true)]
	public class Context
	{
		// Token: 0x0600587E RID: 22654 RVA: 0x001381B3 File Offset: 0x001363B3
		[SecurityCritical]
		public Context() : this(0)
		{
		}

		// Token: 0x0600587F RID: 22655 RVA: 0x001381BC File Offset: 0x001363BC
		[SecurityCritical]
		private Context(int flags)
		{
			this._ctxFlags = flags;
			if ((this._ctxFlags & 1) != 0)
			{
				this._ctxID = 0;
			}
			else
			{
				this._ctxID = Interlocked.Increment(ref Context._ctxIDCounter);
			}
			DomainSpecificRemotingData remotingData = Thread.GetDomain().RemotingData;
			if (remotingData != null)
			{
				IContextProperty[] appDomainContextProperties = remotingData.AppDomainContextProperties;
				if (appDomainContextProperties != null)
				{
					for (int i = 0; i < appDomainContextProperties.Length; i++)
					{
						this.SetProperty(appDomainContextProperties[i]);
					}
				}
			}
			if ((this._ctxFlags & 1) != 0)
			{
				this.Freeze();
			}
			this.SetupInternalContext((this._ctxFlags & 1) == 1);
		}

		// Token: 0x06005880 RID: 22656
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void SetupInternalContext(bool bDefault);

		// Token: 0x06005881 RID: 22657 RVA: 0x0013824C File Offset: 0x0013644C
		[SecuritySafeCritical]
		~Context()
		{
			if (this._internalContext != IntPtr.Zero && (this._ctxFlags & 1) == 0)
			{
				this.CleanupInternalContext();
			}
		}

		// Token: 0x06005882 RID: 22658
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void CleanupInternalContext();

		// Token: 0x17000EA9 RID: 3753
		// (get) Token: 0x06005883 RID: 22659 RVA: 0x00138294 File Offset: 0x00136494
		public virtual int ContextID
		{
			[SecurityCritical]
			get
			{
				return this._ctxID;
			}
		}

		// Token: 0x17000EAA RID: 3754
		// (get) Token: 0x06005884 RID: 22660 RVA: 0x0013829C File Offset: 0x0013649C
		internal virtual IntPtr InternalContextID
		{
			get
			{
				return this._internalContext;
			}
		}

		// Token: 0x17000EAB RID: 3755
		// (get) Token: 0x06005885 RID: 22661 RVA: 0x001382A4 File Offset: 0x001364A4
		internal virtual AppDomain AppDomain
		{
			get
			{
				return this._appDomain;
			}
		}

		// Token: 0x17000EAC RID: 3756
		// (get) Token: 0x06005886 RID: 22662 RVA: 0x001382AC File Offset: 0x001364AC
		internal bool IsDefaultContext
		{
			get
			{
				return this._ctxID == 0;
			}
		}

		// Token: 0x17000EAD RID: 3757
		// (get) Token: 0x06005887 RID: 22663 RVA: 0x001382B7 File Offset: 0x001364B7
		public static Context DefaultContext
		{
			[SecurityCritical]
			get
			{
				return Thread.GetDomain().GetDefaultContext();
			}
		}

		// Token: 0x06005888 RID: 22664 RVA: 0x001382C3 File Offset: 0x001364C3
		[SecurityCritical]
		internal static Context CreateDefaultContext()
		{
			return new Context(1);
		}

		// Token: 0x06005889 RID: 22665 RVA: 0x001382CC File Offset: 0x001364CC
		[SecurityCritical]
		public virtual IContextProperty GetProperty(string name)
		{
			if (this._ctxProps == null || name == null)
			{
				return null;
			}
			IContextProperty result = null;
			for (int i = 0; i < this._numCtxProps; i++)
			{
				if (this._ctxProps[i].Name.Equals(name))
				{
					result = this._ctxProps[i];
					break;
				}
			}
			return result;
		}

		// Token: 0x0600588A RID: 22666 RVA: 0x0013831C File Offset: 0x0013651C
		[SecurityCritical]
		public virtual void SetProperty(IContextProperty prop)
		{
			if (prop == null || prop.Name == null)
			{
				throw new ArgumentNullException((prop == null) ? "prop" : "property name");
			}
			if ((this._ctxFlags & 2) != 0)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_AddContextFrozen"));
			}
			lock (this)
			{
				Context.CheckPropertyNameClash(prop.Name, this._ctxProps, this._numCtxProps);
				if (this._ctxProps == null || this._numCtxProps == this._ctxProps.Length)
				{
					this._ctxProps = Context.GrowPropertiesArray(this._ctxProps);
				}
				IContextProperty[] ctxProps = this._ctxProps;
				int numCtxProps = this._numCtxProps;
				this._numCtxProps = numCtxProps + 1;
				ctxProps[numCtxProps] = prop;
			}
		}

		// Token: 0x0600588B RID: 22667 RVA: 0x001383E4 File Offset: 0x001365E4
		[SecurityCritical]
		internal virtual void InternalFreeze()
		{
			this._ctxFlags |= 2;
			for (int i = 0; i < this._numCtxProps; i++)
			{
				this._ctxProps[i].Freeze(this);
			}
		}

		// Token: 0x0600588C RID: 22668 RVA: 0x00138420 File Offset: 0x00136620
		[SecurityCritical]
		public virtual void Freeze()
		{
			lock (this)
			{
				if ((this._ctxFlags & 2) != 0)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ContextAlreadyFrozen"));
				}
				this.InternalFreeze();
			}
		}

		// Token: 0x0600588D RID: 22669 RVA: 0x00138478 File Offset: 0x00136678
		internal virtual void SetThreadPoolAware()
		{
			this._ctxFlags |= 4;
		}

		// Token: 0x17000EAE RID: 3758
		// (get) Token: 0x0600588E RID: 22670 RVA: 0x00138488 File Offset: 0x00136688
		internal virtual bool IsThreadPoolAware
		{
			get
			{
				return (this._ctxFlags & 4) == 4;
			}
		}

		// Token: 0x17000EAF RID: 3759
		// (get) Token: 0x0600588F RID: 22671 RVA: 0x00138498 File Offset: 0x00136698
		public virtual IContextProperty[] ContextProperties
		{
			[SecurityCritical]
			get
			{
				if (this._ctxProps == null)
				{
					return null;
				}
				IContextProperty[] result;
				lock (this)
				{
					IContextProperty[] array = new IContextProperty[this._numCtxProps];
					Array.Copy(this._ctxProps, array, this._numCtxProps);
					result = array;
				}
				return result;
			}
		}

		// Token: 0x06005890 RID: 22672 RVA: 0x001384F8 File Offset: 0x001366F8
		[SecurityCritical]
		internal static void CheckPropertyNameClash(string name, IContextProperty[] props, int count)
		{
			for (int i = 0; i < count; i++)
			{
				if (props[i].Name.Equals(name))
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_DuplicatePropertyName"));
				}
			}
		}

		// Token: 0x06005891 RID: 22673 RVA: 0x00138534 File Offset: 0x00136734
		internal static IContextProperty[] GrowPropertiesArray(IContextProperty[] props)
		{
			int num = ((props != null) ? props.Length : 0) + 8;
			IContextProperty[] array = new IContextProperty[num];
			if (props != null)
			{
				Array.Copy(props, array, props.Length);
			}
			return array;
		}

		// Token: 0x06005892 RID: 22674 RVA: 0x00138564 File Offset: 0x00136764
		[SecurityCritical]
		internal virtual IMessageSink GetServerContextChain()
		{
			if (this._serverContextChain == null)
			{
				IMessageSink messageSink = ServerContextTerminatorSink.MessageSink;
				int numCtxProps = this._numCtxProps;
				while (numCtxProps-- > 0)
				{
					object obj = this._ctxProps[numCtxProps];
					IContributeServerContextSink contributeServerContextSink = obj as IContributeServerContextSink;
					if (contributeServerContextSink != null)
					{
						messageSink = contributeServerContextSink.GetServerContextSink(messageSink);
						if (messageSink == null)
						{
							throw new RemotingException(Environment.GetResourceString("Remoting_Contexts_BadProperty"));
						}
					}
				}
				lock (this)
				{
					if (this._serverContextChain == null)
					{
						this._serverContextChain = messageSink;
					}
				}
			}
			return this._serverContextChain;
		}

		// Token: 0x06005893 RID: 22675 RVA: 0x00138604 File Offset: 0x00136804
		[SecurityCritical]
		internal virtual IMessageSink GetClientContextChain()
		{
			if (this._clientContextChain == null)
			{
				IMessageSink messageSink = ClientContextTerminatorSink.MessageSink;
				for (int i = 0; i < this._numCtxProps; i++)
				{
					object obj = this._ctxProps[i];
					IContributeClientContextSink contributeClientContextSink = obj as IContributeClientContextSink;
					if (contributeClientContextSink != null)
					{
						messageSink = contributeClientContextSink.GetClientContextSink(messageSink);
						if (messageSink == null)
						{
							throw new RemotingException(Environment.GetResourceString("Remoting_Contexts_BadProperty"));
						}
					}
				}
				lock (this)
				{
					if (this._clientContextChain == null)
					{
						this._clientContextChain = messageSink;
					}
				}
			}
			return this._clientContextChain;
		}

		// Token: 0x06005894 RID: 22676 RVA: 0x001386A4 File Offset: 0x001368A4
		[SecurityCritical]
		internal virtual IMessageSink CreateServerObjectChain(MarshalByRefObject serverObj)
		{
			IMessageSink messageSink = new ServerObjectTerminatorSink(serverObj);
			int numCtxProps = this._numCtxProps;
			while (numCtxProps-- > 0)
			{
				object obj = this._ctxProps[numCtxProps];
				IContributeObjectSink contributeObjectSink = obj as IContributeObjectSink;
				if (contributeObjectSink != null)
				{
					messageSink = contributeObjectSink.GetObjectSink(serverObj, messageSink);
					if (messageSink == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Contexts_BadProperty"));
					}
				}
			}
			return messageSink;
		}

		// Token: 0x06005895 RID: 22677 RVA: 0x001386FC File Offset: 0x001368FC
		[SecurityCritical]
		internal virtual IMessageSink CreateEnvoyChain(MarshalByRefObject objectOrProxy)
		{
			IMessageSink messageSink = EnvoyTerminatorSink.MessageSink;
			for (int i = 0; i < this._numCtxProps; i++)
			{
				object obj = this._ctxProps[i];
				IContributeEnvoySink contributeEnvoySink = obj as IContributeEnvoySink;
				if (contributeEnvoySink != null)
				{
					messageSink = contributeEnvoySink.GetEnvoySink(objectOrProxy, messageSink);
					if (messageSink == null)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_Contexts_BadProperty"));
					}
				}
			}
			return messageSink;
		}

		// Token: 0x06005896 RID: 22678 RVA: 0x00138758 File Offset: 0x00136958
		[SecurityCritical]
		internal IMessage NotifyActivatorProperties(IMessage msg, bool bServerSide)
		{
			IMessage message = null;
			try
			{
				int numCtxProps = this._numCtxProps;
				while (numCtxProps-- != 0)
				{
					object obj = this._ctxProps[numCtxProps];
					IContextPropertyActivator contextPropertyActivator = obj as IContextPropertyActivator;
					if (contextPropertyActivator != null)
					{
						IConstructionCallMessage constructionCallMessage = msg as IConstructionCallMessage;
						if (constructionCallMessage != null)
						{
							if (!bServerSide)
							{
								contextPropertyActivator.CollectFromClientContext(constructionCallMessage);
							}
							else
							{
								contextPropertyActivator.DeliverClientContextToServerContext(constructionCallMessage);
							}
						}
						else if (bServerSide)
						{
							contextPropertyActivator.CollectFromServerContext((IConstructionReturnMessage)msg);
						}
						else
						{
							contextPropertyActivator.DeliverServerContextToClientContext((IConstructionReturnMessage)msg);
						}
					}
				}
			}
			catch (Exception e)
			{
				IMethodCallMessage mcm;
				if (msg is IConstructionCallMessage)
				{
					mcm = (IMethodCallMessage)msg;
				}
				else
				{
					mcm = new ErrorMessage();
				}
				message = new ReturnMessage(e, mcm);
				if (msg != null)
				{
					((ReturnMessage)message).SetLogicalCallContext((LogicalCallContext)msg.Properties[Message.CallContextKey]);
				}
			}
			return message;
		}

		// Token: 0x06005897 RID: 22679 RVA: 0x00138830 File Offset: 0x00136A30
		public override string ToString()
		{
			return "ContextID: " + this._ctxID.ToString();
		}

		// Token: 0x06005898 RID: 22680 RVA: 0x00138848 File Offset: 0x00136A48
		[SecurityCritical]
		public void DoCallBack(CrossContextDelegate deleg)
		{
			if (deleg == null)
			{
				throw new ArgumentNullException("deleg");
			}
			if ((this._ctxFlags & 2) == 0)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Contexts_ContextNotFrozenForCallBack"));
			}
			Context currentContext = Thread.CurrentContext;
			if (currentContext == this)
			{
				deleg();
				return;
			}
			currentContext.DoCallBackGeneric(this.InternalContextID, deleg);
			GC.KeepAlive(this);
		}

		// Token: 0x06005899 RID: 22681 RVA: 0x001388A4 File Offset: 0x00136AA4
		[SecurityCritical]
		internal static void DoCallBackFromEE(IntPtr targetCtxID, IntPtr privateData, int targetDomainID)
		{
			if (targetDomainID == 0)
			{
				CallBackHelper @object = new CallBackHelper(privateData, true, targetDomainID);
				CrossContextDelegate deleg = new CrossContextDelegate(@object.Func);
				Thread.CurrentContext.DoCallBackGeneric(targetCtxID, deleg);
				return;
			}
			TransitionCall msg = new TransitionCall(targetCtxID, privateData, targetDomainID);
			Message.PropagateCallContextFromThreadToMessage(msg);
			IMessage message = Thread.CurrentContext.GetClientContextChain().SyncProcessMessage(msg);
			Message.PropagateCallContextFromMessageToThread(message);
			IMethodReturnMessage methodReturnMessage = message as IMethodReturnMessage;
			if (methodReturnMessage != null && methodReturnMessage.Exception != null)
			{
				throw methodReturnMessage.Exception;
			}
		}

		// Token: 0x0600589A RID: 22682 RVA: 0x0013891C File Offset: 0x00136B1C
		[SecurityCritical]
		internal void DoCallBackGeneric(IntPtr targetCtxID, CrossContextDelegate deleg)
		{
			TransitionCall msg = new TransitionCall(targetCtxID, deleg);
			Message.PropagateCallContextFromThreadToMessage(msg);
			IMessage message = this.GetClientContextChain().SyncProcessMessage(msg);
			if (message != null)
			{
				Message.PropagateCallContextFromMessageToThread(message);
			}
			IMethodReturnMessage methodReturnMessage = message as IMethodReturnMessage;
			if (methodReturnMessage != null && methodReturnMessage.Exception != null)
			{
				throw methodReturnMessage.Exception;
			}
		}

		// Token: 0x0600589B RID: 22683
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void ExecuteCallBackInEE(IntPtr privateData);

		// Token: 0x17000EB0 RID: 3760
		// (get) Token: 0x0600589C RID: 22684 RVA: 0x00138968 File Offset: 0x00136B68
		private LocalDataStore MyLocalStore
		{
			get
			{
				if (this._localDataStore == null)
				{
					LocalDataStoreMgr localDataStoreMgr = Context._localDataStoreMgr;
					lock (localDataStoreMgr)
					{
						if (this._localDataStore == null)
						{
							this._localDataStore = Context._localDataStoreMgr.CreateLocalDataStore();
						}
					}
				}
				return this._localDataStore.Store;
			}
		}

		// Token: 0x0600589D RID: 22685 RVA: 0x001389D4 File Offset: 0x00136BD4
		[SecurityCritical]
		public static LocalDataStoreSlot AllocateDataSlot()
		{
			return Context._localDataStoreMgr.AllocateDataSlot();
		}

		// Token: 0x0600589E RID: 22686 RVA: 0x001389E0 File Offset: 0x00136BE0
		[SecurityCritical]
		public static LocalDataStoreSlot AllocateNamedDataSlot(string name)
		{
			return Context._localDataStoreMgr.AllocateNamedDataSlot(name);
		}

		// Token: 0x0600589F RID: 22687 RVA: 0x001389ED File Offset: 0x00136BED
		[SecurityCritical]
		public static LocalDataStoreSlot GetNamedDataSlot(string name)
		{
			return Context._localDataStoreMgr.GetNamedDataSlot(name);
		}

		// Token: 0x060058A0 RID: 22688 RVA: 0x001389FA File Offset: 0x00136BFA
		[SecurityCritical]
		public static void FreeNamedDataSlot(string name)
		{
			Context._localDataStoreMgr.FreeNamedDataSlot(name);
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x00138A07 File Offset: 0x00136C07
		[SecurityCritical]
		public static void SetData(LocalDataStoreSlot slot, object data)
		{
			Thread.CurrentContext.MyLocalStore.SetData(slot, data);
		}

		// Token: 0x060058A2 RID: 22690 RVA: 0x00138A1A File Offset: 0x00136C1A
		[SecurityCritical]
		public static object GetData(LocalDataStoreSlot slot)
		{
			return Thread.CurrentContext.MyLocalStore.GetData(slot);
		}

		// Token: 0x060058A3 RID: 22691 RVA: 0x00138A2C File Offset: 0x00136C2C
		private int ReserveSlot()
		{
			if (this._ctxStatics == null)
			{
				this._ctxStatics = new object[8];
				this._ctxStatics[0] = null;
				this._ctxStaticsFreeIndex = 1;
				this._ctxStaticsCurrentBucket = 0;
			}
			if (this._ctxStaticsFreeIndex == 8)
			{
				object[] array = new object[8];
				object[] array2 = this._ctxStatics;
				while (array2[0] != null)
				{
					array2 = (object[])array2[0];
				}
				array2[0] = array;
				this._ctxStaticsFreeIndex = 1;
				this._ctxStaticsCurrentBucket++;
			}
			int ctxStaticsFreeIndex = this._ctxStaticsFreeIndex;
			this._ctxStaticsFreeIndex = ctxStaticsFreeIndex + 1;
			return ctxStaticsFreeIndex | this._ctxStaticsCurrentBucket << 16;
		}

		// Token: 0x060058A4 RID: 22692 RVA: 0x00138AC0 File Offset: 0x00136CC0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
		public static bool RegisterDynamicProperty(IDynamicProperty prop, ContextBoundObject obj, Context ctx)
		{
			if (prop == null || prop.Name == null || !(prop is IContributeDynamicSink))
			{
				throw new ArgumentNullException("prop");
			}
			if (obj != null && ctx != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NonNullObjAndCtx"));
			}
			bool result;
			if (obj != null)
			{
				result = IdentityHolder.AddDynamicProperty(obj, prop);
			}
			else
			{
				result = Context.AddDynamicProperty(ctx, prop);
			}
			return result;
		}

		// Token: 0x060058A5 RID: 22693 RVA: 0x00138B1C File Offset: 0x00136D1C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
		public static bool UnregisterDynamicProperty(string name, ContextBoundObject obj, Context ctx)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (obj != null && ctx != null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NonNullObjAndCtx"));
			}
			bool result;
			if (obj != null)
			{
				result = IdentityHolder.RemoveDynamicProperty(obj, name);
			}
			else
			{
				result = Context.RemoveDynamicProperty(ctx, name);
			}
			return result;
		}

		// Token: 0x060058A6 RID: 22694 RVA: 0x00138B65 File Offset: 0x00136D65
		[SecurityCritical]
		internal static bool AddDynamicProperty(Context ctx, IDynamicProperty prop)
		{
			if (ctx != null)
			{
				return ctx.AddPerContextDynamicProperty(prop);
			}
			return Context.AddGlobalDynamicProperty(prop);
		}

		// Token: 0x060058A7 RID: 22695 RVA: 0x00138B78 File Offset: 0x00136D78
		[SecurityCritical]
		private bool AddPerContextDynamicProperty(IDynamicProperty prop)
		{
			if (this._dphCtx == null)
			{
				DynamicPropertyHolder dphCtx = new DynamicPropertyHolder();
				lock (this)
				{
					if (this._dphCtx == null)
					{
						this._dphCtx = dphCtx;
					}
				}
			}
			return this._dphCtx.AddDynamicProperty(prop);
		}

		// Token: 0x060058A8 RID: 22696 RVA: 0x00138BD8 File Offset: 0x00136DD8
		[SecurityCritical]
		private static bool AddGlobalDynamicProperty(IDynamicProperty prop)
		{
			return Context._dphGlobal.AddDynamicProperty(prop);
		}

		// Token: 0x060058A9 RID: 22697 RVA: 0x00138BE5 File Offset: 0x00136DE5
		[SecurityCritical]
		internal static bool RemoveDynamicProperty(Context ctx, string name)
		{
			if (ctx != null)
			{
				return ctx.RemovePerContextDynamicProperty(name);
			}
			return Context.RemoveGlobalDynamicProperty(name);
		}

		// Token: 0x060058AA RID: 22698 RVA: 0x00138BF8 File Offset: 0x00136DF8
		[SecurityCritical]
		private bool RemovePerContextDynamicProperty(string name)
		{
			if (this._dphCtx == null)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Contexts_NoProperty"), name));
			}
			return this._dphCtx.RemoveDynamicProperty(name);
		}

		// Token: 0x060058AB RID: 22699 RVA: 0x00138C29 File Offset: 0x00136E29
		[SecurityCritical]
		private static bool RemoveGlobalDynamicProperty(string name)
		{
			return Context._dphGlobal.RemoveDynamicProperty(name);
		}

		// Token: 0x17000EB1 RID: 3761
		// (get) Token: 0x060058AC RID: 22700 RVA: 0x00138C36 File Offset: 0x00136E36
		internal virtual IDynamicProperty[] PerContextDynamicProperties
		{
			get
			{
				if (this._dphCtx == null)
				{
					return null;
				}
				return this._dphCtx.DynamicProperties;
			}
		}

		// Token: 0x17000EB2 RID: 3762
		// (get) Token: 0x060058AD RID: 22701 RVA: 0x00138C4D File Offset: 0x00136E4D
		internal static ArrayWithSize GlobalDynamicSinks
		{
			[SecurityCritical]
			get
			{
				return Context._dphGlobal.DynamicSinks;
			}
		}

		// Token: 0x17000EB3 RID: 3763
		// (get) Token: 0x060058AE RID: 22702 RVA: 0x00138C59 File Offset: 0x00136E59
		internal virtual ArrayWithSize DynamicSinks
		{
			[SecurityCritical]
			get
			{
				if (this._dphCtx == null)
				{
					return null;
				}
				return this._dphCtx.DynamicSinks;
			}
		}

		// Token: 0x060058AF RID: 22703 RVA: 0x00138C70 File Offset: 0x00136E70
		[SecurityCritical]
		internal virtual bool NotifyDynamicSinks(IMessage msg, bool bCliSide, bool bStart, bool bAsync, bool bNotifyGlobals)
		{
			bool result = false;
			if (bNotifyGlobals && Context._dphGlobal.DynamicProperties != null)
			{
				ArrayWithSize globalDynamicSinks = Context.GlobalDynamicSinks;
				if (globalDynamicSinks != null)
				{
					DynamicPropertyHolder.NotifyDynamicSinks(msg, globalDynamicSinks, bCliSide, bStart, bAsync);
					result = true;
				}
			}
			ArrayWithSize dynamicSinks = this.DynamicSinks;
			if (dynamicSinks != null)
			{
				DynamicPropertyHolder.NotifyDynamicSinks(msg, dynamicSinks, bCliSide, bStart, bAsync);
				result = true;
			}
			return result;
		}

		// Token: 0x04002852 RID: 10322
		internal const int CTX_DEFAULT_CONTEXT = 1;

		// Token: 0x04002853 RID: 10323
		internal const int CTX_FROZEN = 2;

		// Token: 0x04002854 RID: 10324
		internal const int CTX_THREADPOOL_AWARE = 4;

		// Token: 0x04002855 RID: 10325
		private const int GROW_BY = 8;

		// Token: 0x04002856 RID: 10326
		private const int STATICS_BUCKET_SIZE = 8;

		// Token: 0x04002857 RID: 10327
		private IContextProperty[] _ctxProps;

		// Token: 0x04002858 RID: 10328
		private DynamicPropertyHolder _dphCtx;

		// Token: 0x04002859 RID: 10329
		private volatile LocalDataStoreHolder _localDataStore;

		// Token: 0x0400285A RID: 10330
		private IMessageSink _serverContextChain;

		// Token: 0x0400285B RID: 10331
		private IMessageSink _clientContextChain;

		// Token: 0x0400285C RID: 10332
		private AppDomain _appDomain;

		// Token: 0x0400285D RID: 10333
		private object[] _ctxStatics;

		// Token: 0x0400285E RID: 10334
		private IntPtr _internalContext;

		// Token: 0x0400285F RID: 10335
		private int _ctxID;

		// Token: 0x04002860 RID: 10336
		private int _ctxFlags;

		// Token: 0x04002861 RID: 10337
		private int _numCtxProps;

		// Token: 0x04002862 RID: 10338
		private int _ctxStaticsCurrentBucket;

		// Token: 0x04002863 RID: 10339
		private int _ctxStaticsFreeIndex;

		// Token: 0x04002864 RID: 10340
		private static DynamicPropertyHolder _dphGlobal = new DynamicPropertyHolder();

		// Token: 0x04002865 RID: 10341
		private static LocalDataStoreMgr _localDataStoreMgr = new LocalDataStoreMgr();

		// Token: 0x04002866 RID: 10342
		private static int _ctxIDCounter = 0;
	}
}
