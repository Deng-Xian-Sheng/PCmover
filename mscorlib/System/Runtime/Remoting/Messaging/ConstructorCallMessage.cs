using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200085F RID: 2143
	internal class ConstructorCallMessage : IConstructionCallMessage, IMethodCallMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005AD4 RID: 23252 RVA: 0x0013EB6A File Offset: 0x0013CD6A
		private ConstructorCallMessage()
		{
		}

		// Token: 0x06005AD5 RID: 23253 RVA: 0x0013EB72 File Offset: 0x0013CD72
		[SecurityCritical]
		internal ConstructorCallMessage(object[] callSiteActivationAttributes, object[] womAttr, object[] typeAttr, RuntimeType serverType)
		{
			this._activationType = serverType;
			this._activationTypeName = RemotingServices.GetDefaultQualifiedTypeName(this._activationType);
			this._callSiteActivationAttributes = callSiteActivationAttributes;
			this._womGlobalAttributes = womAttr;
			this._typeAttributes = typeAttr;
		}

		// Token: 0x06005AD6 RID: 23254 RVA: 0x0013EBA8 File Offset: 0x0013CDA8
		[SecurityCritical]
		public object GetThisPtr()
		{
			if (this._message != null)
			{
				return this._message.GetThisPtr();
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
		}

		// Token: 0x17000F45 RID: 3909
		// (get) Token: 0x06005AD7 RID: 23255 RVA: 0x0013EBCD File Offset: 0x0013CDCD
		public object[] CallSiteActivationAttributes
		{
			[SecurityCritical]
			get
			{
				return this._callSiteActivationAttributes;
			}
		}

		// Token: 0x06005AD8 RID: 23256 RVA: 0x0013EBD5 File Offset: 0x0013CDD5
		internal object[] GetWOMAttributes()
		{
			return this._womGlobalAttributes;
		}

		// Token: 0x06005AD9 RID: 23257 RVA: 0x0013EBDD File Offset: 0x0013CDDD
		internal object[] GetTypeAttributes()
		{
			return this._typeAttributes;
		}

		// Token: 0x17000F46 RID: 3910
		// (get) Token: 0x06005ADA RID: 23258 RVA: 0x0013EBE5 File Offset: 0x0013CDE5
		public Type ActivationType
		{
			[SecurityCritical]
			get
			{
				if (this._activationType == null && this._activationTypeName != null)
				{
					this._activationType = RemotingServices.InternalGetTypeFromQualifiedTypeName(this._activationTypeName, false);
				}
				return this._activationType;
			}
		}

		// Token: 0x17000F47 RID: 3911
		// (get) Token: 0x06005ADB RID: 23259 RVA: 0x0013EC15 File Offset: 0x0013CE15
		public string ActivationTypeName
		{
			[SecurityCritical]
			get
			{
				return this._activationTypeName;
			}
		}

		// Token: 0x17000F48 RID: 3912
		// (get) Token: 0x06005ADC RID: 23260 RVA: 0x0013EC1D File Offset: 0x0013CE1D
		public IList ContextProperties
		{
			[SecurityCritical]
			get
			{
				if (this._contextProperties == null)
				{
					this._contextProperties = new ArrayList();
				}
				return this._contextProperties;
			}
		}

		// Token: 0x17000F49 RID: 3913
		// (get) Token: 0x06005ADD RID: 23261 RVA: 0x0013EC38 File Offset: 0x0013CE38
		// (set) Token: 0x06005ADE RID: 23262 RVA: 0x0013EC5D File Offset: 0x0013CE5D
		public string Uri
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.Uri;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
			set
			{
				if (this._message != null)
				{
					this._message.Uri = value;
					return;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F4A RID: 3914
		// (get) Token: 0x06005ADF RID: 23263 RVA: 0x0013EC83 File Offset: 0x0013CE83
		public string MethodName
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.MethodName;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F4B RID: 3915
		// (get) Token: 0x06005AE0 RID: 23264 RVA: 0x0013ECA8 File Offset: 0x0013CEA8
		public string TypeName
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.TypeName;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F4C RID: 3916
		// (get) Token: 0x06005AE1 RID: 23265 RVA: 0x0013ECCD File Offset: 0x0013CECD
		public object MethodSignature
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.MethodSignature;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F4D RID: 3917
		// (get) Token: 0x06005AE2 RID: 23266 RVA: 0x0013ECF2 File Offset: 0x0013CEF2
		public MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.MethodBase;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F4E RID: 3918
		// (get) Token: 0x06005AE3 RID: 23267 RVA: 0x0013ED17 File Offset: 0x0013CF17
		public int InArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, false);
				}
				return this._argMapper.ArgCount;
			}
		}

		// Token: 0x06005AE4 RID: 23268 RVA: 0x0013ED39 File Offset: 0x0013CF39
		[SecurityCritical]
		public object GetInArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, false);
			}
			return this._argMapper.GetArg(argNum);
		}

		// Token: 0x06005AE5 RID: 23269 RVA: 0x0013ED5C File Offset: 0x0013CF5C
		[SecurityCritical]
		public string GetInArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, false);
			}
			return this._argMapper.GetArgName(index);
		}

		// Token: 0x17000F4F RID: 3919
		// (get) Token: 0x06005AE6 RID: 23270 RVA: 0x0013ED7F File Offset: 0x0013CF7F
		public object[] InArgs
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, false);
				}
				return this._argMapper.Args;
			}
		}

		// Token: 0x17000F50 RID: 3920
		// (get) Token: 0x06005AE7 RID: 23271 RVA: 0x0013EDA1 File Offset: 0x0013CFA1
		public int ArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.ArgCount;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x06005AE8 RID: 23272 RVA: 0x0013EDC6 File Offset: 0x0013CFC6
		[SecurityCritical]
		public object GetArg(int argNum)
		{
			if (this._message != null)
			{
				return this._message.GetArg(argNum);
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
		}

		// Token: 0x06005AE9 RID: 23273 RVA: 0x0013EDEC File Offset: 0x0013CFEC
		[SecurityCritical]
		public string GetArgName(int index)
		{
			if (this._message != null)
			{
				return this._message.GetArgName(index);
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
		}

		// Token: 0x17000F51 RID: 3921
		// (get) Token: 0x06005AEA RID: 23274 RVA: 0x0013EE12 File Offset: 0x0013D012
		public bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.HasVarArgs;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F52 RID: 3922
		// (get) Token: 0x06005AEB RID: 23275 RVA: 0x0013EE37 File Offset: 0x0013D037
		public object[] Args
		{
			[SecurityCritical]
			get
			{
				if (this._message != null)
				{
					return this._message.Args;
				}
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
			}
		}

		// Token: 0x17000F53 RID: 3923
		// (get) Token: 0x06005AEC RID: 23276 RVA: 0x0013EE5C File Offset: 0x0013D05C
		public IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					object value = new CCMDictionary(this, new Hashtable());
					Interlocked.CompareExchange(ref this._properties, value, null);
				}
				return (IDictionary)this._properties;
			}
		}

		// Token: 0x17000F54 RID: 3924
		// (get) Token: 0x06005AED RID: 23277 RVA: 0x0013EE96 File Offset: 0x0013D096
		// (set) Token: 0x06005AEE RID: 23278 RVA: 0x0013EE9E File Offset: 0x0013D09E
		public IActivator Activator
		{
			[SecurityCritical]
			get
			{
				return this._activator;
			}
			[SecurityCritical]
			set
			{
				this._activator = value;
			}
		}

		// Token: 0x17000F55 RID: 3925
		// (get) Token: 0x06005AEF RID: 23279 RVA: 0x0013EEA7 File Offset: 0x0013D0A7
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this.GetLogicalCallContext();
			}
		}

		// Token: 0x17000F56 RID: 3926
		// (get) Token: 0x06005AF0 RID: 23280 RVA: 0x0013EEAF File Offset: 0x0013D0AF
		// (set) Token: 0x06005AF1 RID: 23281 RVA: 0x0013EEBC File Offset: 0x0013D0BC
		internal bool ActivateInContext
		{
			get
			{
				return (this._iFlags & 1) != 0;
			}
			set
			{
				this._iFlags = (value ? (this._iFlags | 1) : (this._iFlags & -2));
			}
		}

		// Token: 0x06005AF2 RID: 23282 RVA: 0x0013EEDA File Offset: 0x0013D0DA
		[SecurityCritical]
		internal void SetFrame(MessageData msgData)
		{
			this._message = new Message();
			this._message.InitFields(msgData);
		}

		// Token: 0x06005AF3 RID: 23283 RVA: 0x0013EEF3 File Offset: 0x0013D0F3
		[SecurityCritical]
		internal LogicalCallContext GetLogicalCallContext()
		{
			if (this._message != null)
			{
				return this._message.GetLogicalCallContext();
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
		}

		// Token: 0x06005AF4 RID: 23284 RVA: 0x0013EF18 File Offset: 0x0013D118
		[SecurityCritical]
		internal LogicalCallContext SetLogicalCallContext(LogicalCallContext ctx)
		{
			if (this._message != null)
			{
				return this._message.SetLogicalCallContext(ctx);
			}
			throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
		}

		// Token: 0x06005AF5 RID: 23285 RVA: 0x0013EF3E File Offset: 0x0013D13E
		internal Message GetMessage()
		{
			return this._message;
		}

		// Token: 0x04002925 RID: 10533
		private object[] _callSiteActivationAttributes;

		// Token: 0x04002926 RID: 10534
		private object[] _womGlobalAttributes;

		// Token: 0x04002927 RID: 10535
		private object[] _typeAttributes;

		// Token: 0x04002928 RID: 10536
		[NonSerialized]
		private RuntimeType _activationType;

		// Token: 0x04002929 RID: 10537
		private string _activationTypeName;

		// Token: 0x0400292A RID: 10538
		private IList _contextProperties;

		// Token: 0x0400292B RID: 10539
		private int _iFlags;

		// Token: 0x0400292C RID: 10540
		private Message _message;

		// Token: 0x0400292D RID: 10541
		private object _properties;

		// Token: 0x0400292E RID: 10542
		private ArgMapper _argMapper;

		// Token: 0x0400292F RID: 10543
		private IActivator _activator;

		// Token: 0x04002930 RID: 10544
		private const int CCM_ACTIVATEINCONTEXT = 1;
	}
}
