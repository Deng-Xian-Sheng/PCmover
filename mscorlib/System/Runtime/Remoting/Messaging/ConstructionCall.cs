using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x02000869 RID: 2153
	[SecurityCritical]
	[CLSCompliant(false)]
	[ComVisible(true)]
	[Serializable]
	public class ConstructionCall : MethodCall, IConstructionCallMessage, IMethodCallMessage, IMethodMessage, IMessage
	{
		// Token: 0x06005B8E RID: 23438 RVA: 0x00141273 File Offset: 0x0013F473
		public ConstructionCall(Header[] headers) : base(headers)
		{
		}

		// Token: 0x06005B8F RID: 23439 RVA: 0x0014127C File Offset: 0x0013F47C
		public ConstructionCall(IMessage m) : base(m)
		{
		}

		// Token: 0x06005B90 RID: 23440 RVA: 0x00141285 File Offset: 0x0013F485
		internal ConstructionCall(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06005B91 RID: 23441 RVA: 0x00141290 File Offset: 0x0013F490
		[SecurityCritical]
		internal override bool FillSpecialHeader(string key, object value)
		{
			if (key != null)
			{
				if (key.Equals("__ActivationType"))
				{
					this._activationType = null;
				}
				else if (key.Equals("__ContextProperties"))
				{
					this._contextProperties = (IList)value;
				}
				else if (key.Equals("__CallSiteActivationAttributes"))
				{
					this._callSiteActivationAttributes = (object[])value;
				}
				else if (key.Equals("__Activator"))
				{
					this._activator = (IActivator)value;
				}
				else
				{
					if (!key.Equals("__ActivationTypeName"))
					{
						return base.FillSpecialHeader(key, value);
					}
					this._activationTypeName = (string)value;
				}
			}
			return true;
		}

		// Token: 0x17000F90 RID: 3984
		// (get) Token: 0x06005B92 RID: 23442 RVA: 0x0014132F File Offset: 0x0013F52F
		public object[] CallSiteActivationAttributes
		{
			[SecurityCritical]
			get
			{
				return this._callSiteActivationAttributes;
			}
		}

		// Token: 0x17000F91 RID: 3985
		// (get) Token: 0x06005B93 RID: 23443 RVA: 0x00141337 File Offset: 0x0013F537
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

		// Token: 0x17000F92 RID: 3986
		// (get) Token: 0x06005B94 RID: 23444 RVA: 0x00141367 File Offset: 0x0013F567
		public string ActivationTypeName
		{
			[SecurityCritical]
			get
			{
				return this._activationTypeName;
			}
		}

		// Token: 0x17000F93 RID: 3987
		// (get) Token: 0x06005B95 RID: 23445 RVA: 0x0014136F File Offset: 0x0013F56F
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

		// Token: 0x17000F94 RID: 3988
		// (get) Token: 0x06005B96 RID: 23446 RVA: 0x0014138C File Offset: 0x0013F58C
		public override IDictionary Properties
		{
			[SecurityCritical]
			get
			{
				IDictionary externalProperties;
				lock (this)
				{
					if (this.InternalProperties == null)
					{
						this.InternalProperties = new Hashtable();
					}
					if (this.ExternalProperties == null)
					{
						this.ExternalProperties = new CCMDictionary(this, this.InternalProperties);
					}
					externalProperties = this.ExternalProperties;
				}
				return externalProperties;
			}
		}

		// Token: 0x17000F95 RID: 3989
		// (get) Token: 0x06005B97 RID: 23447 RVA: 0x001413F8 File Offset: 0x0013F5F8
		// (set) Token: 0x06005B98 RID: 23448 RVA: 0x00141400 File Offset: 0x0013F600
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

		// Token: 0x04002964 RID: 10596
		internal Type _activationType;

		// Token: 0x04002965 RID: 10597
		internal string _activationTypeName;

		// Token: 0x04002966 RID: 10598
		internal IList _contextProperties;

		// Token: 0x04002967 RID: 10599
		internal object[] _callSiteActivationAttributes;

		// Token: 0x04002968 RID: 10600
		internal IActivator _activator;
	}
}
