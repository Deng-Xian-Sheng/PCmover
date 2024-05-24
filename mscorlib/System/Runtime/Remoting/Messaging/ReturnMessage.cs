using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000867 RID: 2151
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class ReturnMessage : IMethodReturnMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005B44 RID: 23364 RVA: 0x0013FE78 File Offset: 0x0013E078
		[SecurityCritical]
		public ReturnMessage(object ret, object[] outArgs, int outArgsCount, LogicalCallContext callCtx, IMethodCallMessage mcm)
		{
			this._ret = ret;
			this._outArgs = outArgs;
			this._outArgsCount = outArgsCount;
			if (callCtx != null)
			{
				this._callContext = callCtx;
			}
			else
			{
				this._callContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			}
			if (mcm != null)
			{
				this._URI = mcm.Uri;
				this._methodName = mcm.MethodName;
				this._methodSignature = null;
				this._typeName = mcm.TypeName;
				this._hasVarArgs = mcm.HasVarArgs;
				this._methodBase = mcm.MethodBase;
			}
		}

		// Token: 0x06005B45 RID: 23365 RVA: 0x0013FF10 File Offset: 0x0013E110
		[SecurityCritical]
		public ReturnMessage(Exception e, IMethodCallMessage mcm)
		{
			this._e = (ReturnMessage.IsCustomErrorEnabled() ? new RemotingException(Environment.GetResourceString("Remoting_InternalError")) : e);
			this._callContext = Thread.CurrentThread.GetMutableExecutionContext().LogicalCallContext;
			if (mcm != null)
			{
				this._URI = mcm.Uri;
				this._methodName = mcm.MethodName;
				this._methodSignature = null;
				this._typeName = mcm.TypeName;
				this._hasVarArgs = mcm.HasVarArgs;
				this._methodBase = mcm.MethodBase;
			}
		}

		// Token: 0x17000F74 RID: 3956
		// (get) Token: 0x06005B46 RID: 23366 RVA: 0x0013FF9D File Offset: 0x0013E19D
		// (set) Token: 0x06005B47 RID: 23367 RVA: 0x0013FFA5 File Offset: 0x0013E1A5
		public string Uri
		{
			[SecurityCritical]
			get
			{
				return this._URI;
			}
			set
			{
				this._URI = value;
			}
		}

		// Token: 0x17000F75 RID: 3957
		// (get) Token: 0x06005B48 RID: 23368 RVA: 0x0013FFAE File Offset: 0x0013E1AE
		public string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._methodName;
			}
		}

		// Token: 0x17000F76 RID: 3958
		// (get) Token: 0x06005B49 RID: 23369 RVA: 0x0013FFB6 File Offset: 0x0013E1B6
		public string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._typeName;
			}
		}

		// Token: 0x17000F77 RID: 3959
		// (get) Token: 0x06005B4A RID: 23370 RVA: 0x0013FFBE File Offset: 0x0013E1BE
		public object MethodSignature
		{
			[SecurityCritical]
			get
			{
				if (this._methodSignature == null && this._methodBase != null)
				{
					this._methodSignature = Message.GenerateMethodSignature(this._methodBase);
				}
				return this._methodSignature;
			}
		}

		// Token: 0x17000F78 RID: 3960
		// (get) Token: 0x06005B4B RID: 23371 RVA: 0x0013FFED File Offset: 0x0013E1ED
		public MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._methodBase;
			}
		}

		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x06005B4C RID: 23372 RVA: 0x0013FFF5 File Offset: 0x0013E1F5
		public bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._hasVarArgs;
			}
		}

		// Token: 0x17000F7A RID: 3962
		// (get) Token: 0x06005B4D RID: 23373 RVA: 0x0013FFFD File Offset: 0x0013E1FD
		public int ArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._outArgs == null)
				{
					return this._outArgsCount;
				}
				return this._outArgs.Length;
			}
		}

		// Token: 0x06005B4E RID: 23374 RVA: 0x00140018 File Offset: 0x0013E218
		[SecurityCritical]
		public object GetArg(int argNum)
		{
			if (this._outArgs == null)
			{
				if (argNum < 0 || argNum >= this._outArgsCount)
				{
					throw new ArgumentOutOfRangeException("argNum");
				}
				return null;
			}
			else
			{
				if (argNum < 0 || argNum >= this._outArgs.Length)
				{
					throw new ArgumentOutOfRangeException("argNum");
				}
				return this._outArgs[argNum];
			}
		}

		// Token: 0x06005B4F RID: 23375 RVA: 0x0014006C File Offset: 0x0013E26C
		[SecurityCritical]
		public string GetArgName(int index)
		{
			if (this._outArgs == null)
			{
				if (index < 0 || index >= this._outArgsCount)
				{
					throw new ArgumentOutOfRangeException("index");
				}
			}
			else if (index < 0 || index >= this._outArgs.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (this._methodBase != null)
			{
				RemotingMethodCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(this._methodBase);
				return reflectionCachedData.Parameters[index].Name;
			}
			return "__param" + index.ToString();
		}

		// Token: 0x17000F7B RID: 3963
		// (get) Token: 0x06005B50 RID: 23376 RVA: 0x001400EC File Offset: 0x0013E2EC
		public object[] Args
		{
			[SecurityCritical]
			get
			{
				if (this._outArgs == null)
				{
					return new object[this._outArgsCount];
				}
				return this._outArgs;
			}
		}

		// Token: 0x17000F7C RID: 3964
		// (get) Token: 0x06005B51 RID: 23377 RVA: 0x00140108 File Offset: 0x0013E308
		public int OutArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.ArgCount;
			}
		}

		// Token: 0x06005B52 RID: 23378 RVA: 0x0014012A File Offset: 0x0013E32A
		[SecurityCritical]
		public object GetOutArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArg(argNum);
		}

		// Token: 0x06005B53 RID: 23379 RVA: 0x0014014D File Offset: 0x0013E34D
		[SecurityCritical]
		public string GetOutArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArgName(index);
		}

		// Token: 0x17000F7D RID: 3965
		// (get) Token: 0x06005B54 RID: 23380 RVA: 0x00140170 File Offset: 0x0013E370
		public object[] OutArgs
		{
			[SecurityCritical]
			get
			{
				if (this._argMapper == null)
				{
					this._argMapper = new ArgMapper(this, true);
				}
				return this._argMapper.Args;
			}
		}

		// Token: 0x17000F7E RID: 3966
		// (get) Token: 0x06005B55 RID: 23381 RVA: 0x00140192 File Offset: 0x0013E392
		public Exception Exception
		{
			[SecurityCritical]
			get
			{
				return this._e;
			}
		}

		// Token: 0x17000F7F RID: 3967
		// (get) Token: 0x06005B56 RID: 23382 RVA: 0x0014019A File Offset: 0x0013E39A
		public virtual object ReturnValue
		{
			[SecurityCritical]
			get
			{
				return this._ret;
			}
		}

		// Token: 0x17000F80 RID: 3968
		// (get) Token: 0x06005B57 RID: 23383 RVA: 0x001401A2 File Offset: 0x0013E3A2
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					this._properties = new MRMDictionary(this, null);
				}
				return (MRMDictionary)this._properties;
			}
		}

		// Token: 0x17000F81 RID: 3969
		// (get) Token: 0x06005B58 RID: 23384 RVA: 0x001401C4 File Offset: 0x0013E3C4
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this.GetLogicalCallContext();
			}
		}

		// Token: 0x06005B59 RID: 23385 RVA: 0x001401CC File Offset: 0x0013E3CC
		[SecurityCritical]
		internal LogicalCallContext GetLogicalCallContext()
		{
			if (this._callContext == null)
			{
				this._callContext = new LogicalCallContext();
			}
			return this._callContext;
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x001401E8 File Offset: 0x0013E3E8
		internal LogicalCallContext SetLogicalCallContext(LogicalCallContext ctx)
		{
			LogicalCallContext callContext = this._callContext;
			this._callContext = ctx;
			return callContext;
		}

		// Token: 0x06005B5B RID: 23387 RVA: 0x00140204 File Offset: 0x0013E404
		internal bool HasProperties()
		{
			return this._properties != null;
		}

		// Token: 0x06005B5C RID: 23388 RVA: 0x00140210 File Offset: 0x0013E410
		[SecurityCritical]
		internal static bool IsCustomErrorEnabled()
		{
			object data = CallContext.GetData("__CustomErrorsEnabled");
			return data != null && (bool)data;
		}

		// Token: 0x04002946 RID: 10566
		internal object _ret;

		// Token: 0x04002947 RID: 10567
		internal object _properties;

		// Token: 0x04002948 RID: 10568
		internal string _URI;

		// Token: 0x04002949 RID: 10569
		internal Exception _e;

		// Token: 0x0400294A RID: 10570
		internal object[] _outArgs;

		// Token: 0x0400294B RID: 10571
		internal int _outArgsCount;

		// Token: 0x0400294C RID: 10572
		internal string _methodName;

		// Token: 0x0400294D RID: 10573
		internal string _typeName;

		// Token: 0x0400294E RID: 10574
		internal Type[] _methodSignature;

		// Token: 0x0400294F RID: 10575
		internal bool _hasVarArgs;

		// Token: 0x04002950 RID: 10576
		internal LogicalCallContext _callContext;

		// Token: 0x04002951 RID: 10577
		internal ArgMapper _argMapper;

		// Token: 0x04002952 RID: 10578
		internal MethodBase _methodBase;
	}
}
