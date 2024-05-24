using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000872 RID: 2162
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class MethodCallMessageWrapper : InternalMessageWrapper, IMethodCallMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005BF9 RID: 23545 RVA: 0x00142B36 File Offset: 0x00140D36
		public MethodCallMessageWrapper(IMethodCallMessage msg) : base(msg)
		{
			this._msg = msg;
			this._args = this._msg.Args;
		}

		// Token: 0x17000FBE RID: 4030
		// (get) Token: 0x06005BFA RID: 23546 RVA: 0x00142B57 File Offset: 0x00140D57
		// (set) Token: 0x06005BFB RID: 23547 RVA: 0x00142B64 File Offset: 0x00140D64
		public virtual string Uri
		{
			[SecurityCritical]
			get
			{
				return this._msg.Uri;
			}
			set
			{
				this._msg.Properties[Message.UriKey] = value;
			}
		}

		// Token: 0x17000FBF RID: 4031
		// (get) Token: 0x06005BFC RID: 23548 RVA: 0x00142B7C File Offset: 0x00140D7C
		public virtual string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodName;
			}
		}

		// Token: 0x17000FC0 RID: 4032
		// (get) Token: 0x06005BFD RID: 23549 RVA: 0x00142B89 File Offset: 0x00140D89
		public virtual string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._msg.TypeName;
			}
		}

		// Token: 0x17000FC1 RID: 4033
		// (get) Token: 0x06005BFE RID: 23550 RVA: 0x00142B96 File Offset: 0x00140D96
		public virtual object MethodSignature
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodSignature;
			}
		}

		// Token: 0x17000FC2 RID: 4034
		// (get) Token: 0x06005BFF RID: 23551 RVA: 0x00142BA3 File Offset: 0x00140DA3
		public virtual LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._msg.LogicalCallContext;
			}
		}

		// Token: 0x17000FC3 RID: 4035
		// (get) Token: 0x06005C00 RID: 23552 RVA: 0x00142BB0 File Offset: 0x00140DB0
		public virtual MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodBase;
			}
		}

		// Token: 0x17000FC4 RID: 4036
		// (get) Token: 0x06005C01 RID: 23553 RVA: 0x00142BBD File Offset: 0x00140DBD
		public virtual int ArgCount
		{
			[SecurityCritical]
			get
			{
				if (this._args != null)
				{
					return this._args.Length;
				}
				return 0;
			}
		}

		// Token: 0x06005C02 RID: 23554 RVA: 0x00142BD1 File Offset: 0x00140DD1
		[SecurityCritical]
		public virtual string GetArgName(int index)
		{
			return this._msg.GetArgName(index);
		}

		// Token: 0x06005C03 RID: 23555 RVA: 0x00142BDF File Offset: 0x00140DDF
		[SecurityCritical]
		public virtual object GetArg(int argNum)
		{
			return this._args[argNum];
		}

		// Token: 0x17000FC5 RID: 4037
		// (get) Token: 0x06005C04 RID: 23556 RVA: 0x00142BE9 File Offset: 0x00140DE9
		// (set) Token: 0x06005C05 RID: 23557 RVA: 0x00142BF1 File Offset: 0x00140DF1
		public virtual object[] Args
		{
			[SecurityCritical]
			get
			{
				return this._args;
			}
			set
			{
				this._args = value;
			}
		}

		// Token: 0x17000FC6 RID: 4038
		// (get) Token: 0x06005C06 RID: 23558 RVA: 0x00142BFA File Offset: 0x00140DFA
		public virtual bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._msg.HasVarArgs;
			}
		}

		// Token: 0x17000FC7 RID: 4039
		// (get) Token: 0x06005C07 RID: 23559 RVA: 0x00142C07 File Offset: 0x00140E07
		public virtual int InArgCount
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

		// Token: 0x06005C08 RID: 23560 RVA: 0x00142C29 File Offset: 0x00140E29
		[SecurityCritical]
		public virtual object GetInArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, false);
			}
			return this._argMapper.GetArg(argNum);
		}

		// Token: 0x06005C09 RID: 23561 RVA: 0x00142C4C File Offset: 0x00140E4C
		[SecurityCritical]
		public virtual string GetInArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, false);
			}
			return this._argMapper.GetArgName(index);
		}

		// Token: 0x17000FC8 RID: 4040
		// (get) Token: 0x06005C0A RID: 23562 RVA: 0x00142C6F File Offset: 0x00140E6F
		public virtual object[] InArgs
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

		// Token: 0x17000FC9 RID: 4041
		// (get) Token: 0x06005C0B RID: 23563 RVA: 0x00142C91 File Offset: 0x00140E91
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					this._properties = new MethodCallMessageWrapper.MCMWrapperDictionary(this, this._msg.Properties);
				}
				return this._properties;
			}
		}

		// Token: 0x0400298D RID: 10637
		private IMethodCallMessage _msg;

		// Token: 0x0400298E RID: 10638
		private IDictionary _properties;

		// Token: 0x0400298F RID: 10639
		private ArgMapper _argMapper;

		// Token: 0x04002990 RID: 10640
		private object[] _args;

		// Token: 0x02000C77 RID: 3191
		private class MCMWrapperDictionary : Hashtable
		{
			// Token: 0x060070B3 RID: 28851 RVA: 0x001848A3 File Offset: 0x00182AA3
			public MCMWrapperDictionary(IMethodCallMessage msg, IDictionary idict)
			{
				this._mcmsg = msg;
				this._idict = idict;
			}

			// Token: 0x17001353 RID: 4947
			public override object this[object key]
			{
				[SecuritySafeCritical]
				get
				{
					string text = key as string;
					if (text != null)
					{
						if (text == "__Uri")
						{
							return this._mcmsg.Uri;
						}
						if (text == "__MethodName")
						{
							return this._mcmsg.MethodName;
						}
						if (text == "__MethodSignature")
						{
							return this._mcmsg.MethodSignature;
						}
						if (text == "__TypeName")
						{
							return this._mcmsg.TypeName;
						}
						if (text == "__Args")
						{
							return this._mcmsg.Args;
						}
					}
					return this._idict[key];
				}
				[SecuritySafeCritical]
				set
				{
					string text = key as string;
					if (text != null)
					{
						if (text == "__MethodName" || text == "__MethodSignature" || text == "__TypeName" || text == "__Args")
						{
							throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
						}
						this._idict[key] = value;
					}
				}
			}

			// Token: 0x04003801 RID: 14337
			private IMethodCallMessage _mcmsg;

			// Token: 0x04003802 RID: 14338
			private IDictionary _idict;
		}
	}
}
