using System;
using System.Collections;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200085E RID: 2142
	[SecurityCritical]
	internal class ConstructorReturnMessage : ReturnMessage, IConstructionReturnMessage, IMethodReturnMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005ACF RID: 23247 RVA: 0x0013EADF File Offset: 0x0013CCDF
		public ConstructorReturnMessage(MarshalByRefObject o, object[] outArgs, int outArgsCount, LogicalCallContext callCtx, IConstructionCallMessage ccm) : base(o, outArgs, outArgsCount, callCtx, ccm)
		{
			this._o = o;
			this._iFlags = 1;
		}

		// Token: 0x06005AD0 RID: 23248 RVA: 0x0013EAFC File Offset: 0x0013CCFC
		public ConstructorReturnMessage(Exception e, IConstructionCallMessage ccm) : base(e, ccm)
		{
		}

		// Token: 0x17000F43 RID: 3907
		// (get) Token: 0x06005AD1 RID: 23249 RVA: 0x0013EB06 File Offset: 0x0013CD06
		public override object ReturnValue
		{
			[SecurityCritical]
			get
			{
				if (this._iFlags == 1)
				{
					return RemotingServices.MarshalInternal(this._o, null, null);
				}
				return base.ReturnValue;
			}
		}

		// Token: 0x17000F44 RID: 3908
		// (get) Token: 0x06005AD2 RID: 23250 RVA: 0x0013EB28 File Offset: 0x0013CD28
		public override IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				if (this._properties == null)
				{
					object value = new CRMDictionary(this, new Hashtable());
					Interlocked.CompareExchange(ref this._properties, value, null);
				}
				return (IDictionary)this._properties;
			}
		}

		// Token: 0x06005AD3 RID: 23251 RVA: 0x0013EB62 File Offset: 0x0013CD62
		internal object GetObject()
		{
			return this._o;
		}

		// Token: 0x04002922 RID: 10530
		private const int Intercept = 1;

		// Token: 0x04002923 RID: 10531
		private MarshalByRefObject _o;

		// Token: 0x04002924 RID: 10532
		private int _iFlags;
	}
}
