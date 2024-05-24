using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000873 RID: 2163
	[SecurityCritical]
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.Infrastructure)]
	public class MethodReturnMessageWrapper : InternalMessageWrapper, IMethodReturnMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005C0C RID: 23564 RVA: 0x00142CB8 File Offset: 0x00140EB8
		public MethodReturnMessageWrapper(IMethodReturnMessage msg) : base(msg)
		{
			this._msg = msg;
			this._args = this._msg.Args;
			this._returnValue = this._msg.ReturnValue;
			this._exception = this._msg.Exception;
		}

		// Token: 0x17000FCA RID: 4042
		// (get) Token: 0x06005C0D RID: 23565 RVA: 0x00142D06 File Offset: 0x00140F06
		// (set) Token: 0x06005C0E RID: 23566 RVA: 0x00142D13 File Offset: 0x00140F13
		public string Uri
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

		// Token: 0x17000FCB RID: 4043
		// (get) Token: 0x06005C0F RID: 23567 RVA: 0x00142D2B File Offset: 0x00140F2B
		public virtual string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodName;
			}
		}

		// Token: 0x17000FCC RID: 4044
		// (get) Token: 0x06005C10 RID: 23568 RVA: 0x00142D38 File Offset: 0x00140F38
		public virtual string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._msg.TypeName;
			}
		}

		// Token: 0x17000FCD RID: 4045
		// (get) Token: 0x06005C11 RID: 23569 RVA: 0x00142D45 File Offset: 0x00140F45
		public virtual object MethodSignature
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodSignature;
			}
		}

		// Token: 0x17000FCE RID: 4046
		// (get) Token: 0x06005C12 RID: 23570 RVA: 0x00142D52 File Offset: 0x00140F52
		public virtual LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._msg.LogicalCallContext;
			}
		}

		// Token: 0x17000FCF RID: 4047
		// (get) Token: 0x06005C13 RID: 23571 RVA: 0x00142D5F File Offset: 0x00140F5F
		public virtual MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._msg.MethodBase;
			}
		}

		// Token: 0x17000FD0 RID: 4048
		// (get) Token: 0x06005C14 RID: 23572 RVA: 0x00142D6C File Offset: 0x00140F6C
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

		// Token: 0x06005C15 RID: 23573 RVA: 0x00142D80 File Offset: 0x00140F80
		[SecurityCritical]
		public virtual string GetArgName(int index)
		{
			return this._msg.GetArgName(index);
		}

		// Token: 0x06005C16 RID: 23574 RVA: 0x00142D8E File Offset: 0x00140F8E
		[SecurityCritical]
		public virtual object GetArg(int argNum)
		{
			return this._args[argNum];
		}

		// Token: 0x17000FD1 RID: 4049
		// (get) Token: 0x06005C17 RID: 23575 RVA: 0x00142D98 File Offset: 0x00140F98
		// (set) Token: 0x06005C18 RID: 23576 RVA: 0x00142DA0 File Offset: 0x00140FA0
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

		// Token: 0x17000FD2 RID: 4050
		// (get) Token: 0x06005C19 RID: 23577 RVA: 0x00142DA9 File Offset: 0x00140FA9
		public virtual bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._msg.HasVarArgs;
			}
		}

		// Token: 0x17000FD3 RID: 4051
		// (get) Token: 0x06005C1A RID: 23578 RVA: 0x00142DB6 File Offset: 0x00140FB6
		public virtual int OutArgCount
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

		// Token: 0x06005C1B RID: 23579 RVA: 0x00142DD8 File Offset: 0x00140FD8
		[SecurityCritical]
		public virtual object GetOutArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArg(argNum);
		}

		// Token: 0x06005C1C RID: 23580 RVA: 0x00142DFB File Offset: 0x00140FFB
		[SecurityCritical]
		public virtual string GetOutArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArgName(index);
		}

		// Token: 0x17000FD4 RID: 4052
		// (get) Token: 0x06005C1D RID: 23581 RVA: 0x00142E1E File Offset: 0x0014101E
		public virtual object[] OutArgs
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

		// Token: 0x17000FD5 RID: 4053
		// (get) Token: 0x06005C1E RID: 23582 RVA: 0x00142E40 File Offset: 0x00141040
		// (set) Token: 0x06005C1F RID: 23583 RVA: 0x00142E48 File Offset: 0x00141048
		public virtual Exception Exception
		{
			[SecurityCritical]
			get
			{
				return this._exception;
			}
			set
			{
				this._exception = value;
			}
		}

		// Token: 0x17000FD6 RID: 4054
		// (get) Token: 0x06005C20 RID: 23584 RVA: 0x00142E51 File Offset: 0x00141051
		// (set) Token: 0x06005C21 RID: 23585 RVA: 0x00142E59 File Offset: 0x00141059
		public virtual object ReturnValue
		{
			[SecurityCritical]
			get
			{
				return this._returnValue;
			}
			set
			{
				this._returnValue = value;
			}
		}

		// Token: 0x17000FD7 RID: 4055
		// (get) Token: 0x06005C22 RID: 23586 RVA: 0x00142E62 File Offset: 0x00141062
		public virtual IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					this._properties = new MethodReturnMessageWrapper.MRMWrapperDictionary(this, this._msg.Properties);
				}
				return this._properties;
			}
		}

		// Token: 0x04002991 RID: 10641
		private IMethodReturnMessage _msg;

		// Token: 0x04002992 RID: 10642
		private IDictionary _properties;

		// Token: 0x04002993 RID: 10643
		private ArgMapper _argMapper;

		// Token: 0x04002994 RID: 10644
		private object[] _args;

		// Token: 0x04002995 RID: 10645
		private object _returnValue;

		// Token: 0x04002996 RID: 10646
		private Exception _exception;

		// Token: 0x02000C78 RID: 3192
		private class MRMWrapperDictionary : Hashtable
		{
			// Token: 0x060070B6 RID: 28854 RVA: 0x001849C8 File Offset: 0x00182BC8
			public MRMWrapperDictionary(IMethodReturnMessage msg, IDictionary idict)
			{
				this._mrmsg = msg;
				this._idict = idict;
			}

			// Token: 0x17001354 RID: 4948
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
							return this._mrmsg.Uri;
						}
						if (text == "__MethodName")
						{
							return this._mrmsg.MethodName;
						}
						if (text == "__MethodSignature")
						{
							return this._mrmsg.MethodSignature;
						}
						if (text == "__TypeName")
						{
							return this._mrmsg.TypeName;
						}
						if (text == "__Return")
						{
							return this._mrmsg.ReturnValue;
						}
						if (text == "__OutArgs")
						{
							return this._mrmsg.OutArgs;
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
						if (text == "__MethodName" || text == "__MethodSignature" || text == "__TypeName" || text == "__Return" || text == "__OutArgs")
						{
							throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
						}
						this._idict[key] = value;
					}
				}
			}

			// Token: 0x04003803 RID: 14339
			private IMethodReturnMessage _mrmsg;

			// Token: 0x04003804 RID: 14340
			private IDictionary _idict;
		}
	}
}
