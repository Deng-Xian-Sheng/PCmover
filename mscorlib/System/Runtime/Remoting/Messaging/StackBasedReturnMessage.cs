using System;
using System.Collections;
using System.Reflection;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000866 RID: 2150
	internal class StackBasedReturnMessage : IMethodReturnMessage, IMethodMessage, IMessage, IInternalMessage
	{
		// Token: 0x06005B27 RID: 23335 RVA: 0x0013FC58 File Offset: 0x0013DE58
		internal StackBasedReturnMessage()
		{
		}

		// Token: 0x06005B28 RID: 23336 RVA: 0x0013FC60 File Offset: 0x0013DE60
		internal void InitFields(Message m)
		{
			this._m = m;
			if (this._h != null)
			{
				this._h.Clear();
			}
			if (this._d != null)
			{
				this._d.Clear();
			}
		}

		// Token: 0x17000F64 RID: 3940
		// (get) Token: 0x06005B29 RID: 23337 RVA: 0x0013FC8F File Offset: 0x0013DE8F
		public string Uri
		{
			[SecurityCritical]
			get
			{
				return this._m.Uri;
			}
		}

		// Token: 0x17000F65 RID: 3941
		// (get) Token: 0x06005B2A RID: 23338 RVA: 0x0013FC9C File Offset: 0x0013DE9C
		public string MethodName
		{
			[SecurityCritical]
			get
			{
				return this._m.MethodName;
			}
		}

		// Token: 0x17000F66 RID: 3942
		// (get) Token: 0x06005B2B RID: 23339 RVA: 0x0013FCA9 File Offset: 0x0013DEA9
		public string TypeName
		{
			[SecurityCritical]
			get
			{
				return this._m.TypeName;
			}
		}

		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x06005B2C RID: 23340 RVA: 0x0013FCB6 File Offset: 0x0013DEB6
		public object MethodSignature
		{
			[SecurityCritical]
			get
			{
				return this._m.MethodSignature;
			}
		}

		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x06005B2D RID: 23341 RVA: 0x0013FCC3 File Offset: 0x0013DEC3
		public MethodBase MethodBase
		{
			[SecurityCritical]
			get
			{
				return this._m.MethodBase;
			}
		}

		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x06005B2E RID: 23342 RVA: 0x0013FCD0 File Offset: 0x0013DED0
		public bool HasVarArgs
		{
			[SecurityCritical]
			get
			{
				return this._m.HasVarArgs;
			}
		}

		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x06005B2F RID: 23343 RVA: 0x0013FCDD File Offset: 0x0013DEDD
		public int ArgCount
		{
			[SecurityCritical]
			get
			{
				return this._m.ArgCount;
			}
		}

		// Token: 0x06005B30 RID: 23344 RVA: 0x0013FCEA File Offset: 0x0013DEEA
		[SecurityCritical]
		public object GetArg(int argNum)
		{
			return this._m.GetArg(argNum);
		}

		// Token: 0x06005B31 RID: 23345 RVA: 0x0013FCF8 File Offset: 0x0013DEF8
		[SecurityCritical]
		public string GetArgName(int index)
		{
			return this._m.GetArgName(index);
		}

		// Token: 0x17000F6B RID: 3947
		// (get) Token: 0x06005B32 RID: 23346 RVA: 0x0013FD06 File Offset: 0x0013DF06
		public object[] Args
		{
			[SecurityCritical]
			get
			{
				return this._m.Args;
			}
		}

		// Token: 0x17000F6C RID: 3948
		// (get) Token: 0x06005B33 RID: 23347 RVA: 0x0013FD13 File Offset: 0x0013DF13
		public LogicalCallContext LogicalCallContext
		{
			[SecurityCritical]
			get
			{
				return this._m.GetLogicalCallContext();
			}
		}

		// Token: 0x06005B34 RID: 23348 RVA: 0x0013FD20 File Offset: 0x0013DF20
		[SecurityCritical]
		internal LogicalCallContext GetLogicalCallContext()
		{
			return this._m.GetLogicalCallContext();
		}

		// Token: 0x06005B35 RID: 23349 RVA: 0x0013FD2D File Offset: 0x0013DF2D
		[SecurityCritical]
		internal LogicalCallContext SetLogicalCallContext(LogicalCallContext callCtx)
		{
			return this._m.SetLogicalCallContext(callCtx);
		}

		// Token: 0x17000F6D RID: 3949
		// (get) Token: 0x06005B36 RID: 23350 RVA: 0x0013FD3B File Offset: 0x0013DF3B
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

		// Token: 0x06005B37 RID: 23351 RVA: 0x0013FD5D File Offset: 0x0013DF5D
		[SecurityCritical]
		public object GetOutArg(int argNum)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArg(argNum);
		}

		// Token: 0x06005B38 RID: 23352 RVA: 0x0013FD80 File Offset: 0x0013DF80
		[SecurityCritical]
		public string GetOutArgName(int index)
		{
			if (this._argMapper == null)
			{
				this._argMapper = new ArgMapper(this, true);
			}
			return this._argMapper.GetArgName(index);
		}

		// Token: 0x17000F6E RID: 3950
		// (get) Token: 0x06005B39 RID: 23353 RVA: 0x0013FDA3 File Offset: 0x0013DFA3
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

		// Token: 0x17000F6F RID: 3951
		// (get) Token: 0x06005B3A RID: 23354 RVA: 0x0013FDC5 File Offset: 0x0013DFC5
		public Exception Exception
		{
			[SecurityCritical]
			get
			{
				return null;
			}
		}

		// Token: 0x17000F70 RID: 3952
		// (get) Token: 0x06005B3B RID: 23355 RVA: 0x0013FDC8 File Offset: 0x0013DFC8
		public object ReturnValue
		{
			[SecurityCritical]
			get
			{
				return this._m.GetReturnValue();
			}
		}

		// Token: 0x17000F71 RID: 3953
		// (get) Token: 0x06005B3C RID: 23356 RVA: 0x0013FDD8 File Offset: 0x0013DFD8
		public IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				IDictionary d;
				lock (this)
				{
					if (this._h == null)
					{
						this._h = new Hashtable();
					}
					if (this._d == null)
					{
						this._d = new MRMDictionary(this, this._h);
					}
					d = this._d;
				}
				return d;
			}
		}

		// Token: 0x17000F72 RID: 3954
		// (get) Token: 0x06005B3D RID: 23357 RVA: 0x0013FE44 File Offset: 0x0013E044
		// (set) Token: 0x06005B3E RID: 23358 RVA: 0x0013FE47 File Offset: 0x0013E047
		ServerIdentity IInternalMessage.ServerIdentityObject
		{
			[SecurityCritical]
			get
			{
				return null;
			}
			[SecurityCritical]
			set
			{
			}
		}

		// Token: 0x17000F73 RID: 3955
		// (get) Token: 0x06005B3F RID: 23359 RVA: 0x0013FE49 File Offset: 0x0013E049
		// (set) Token: 0x06005B40 RID: 23360 RVA: 0x0013FE4C File Offset: 0x0013E04C
		Identity IInternalMessage.IdentityObject
		{
			[SecurityCritical]
			get
			{
				return null;
			}
			[SecurityCritical]
			set
			{
			}
		}

		// Token: 0x06005B41 RID: 23361 RVA: 0x0013FE4E File Offset: 0x0013E04E
		[SecurityCritical]
		void IInternalMessage.SetURI(string val)
		{
			this._m.Uri = val;
		}

		// Token: 0x06005B42 RID: 23362 RVA: 0x0013FE5C File Offset: 0x0013E05C
		[SecurityCritical]
		void IInternalMessage.SetCallContext(LogicalCallContext newCallContext)
		{
			this._m.SetLogicalCallContext(newCallContext);
		}

		// Token: 0x06005B43 RID: 23363 RVA: 0x0013FE6B File Offset: 0x0013E06B
		[SecurityCritical]
		bool IInternalMessage.HasProperties()
		{
			return this._h != null;
		}

		// Token: 0x04002942 RID: 10562
		private Message _m;

		// Token: 0x04002943 RID: 10563
		private Hashtable _h;

		// Token: 0x04002944 RID: 10564
		private MRMDictionary _d;

		// Token: 0x04002945 RID: 10565
		private ArgMapper _argMapper;
	}
}
