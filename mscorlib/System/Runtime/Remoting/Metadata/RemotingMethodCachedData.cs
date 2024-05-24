using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D3 RID: 2003
	internal class RemotingMethodCachedData : RemotingCachedData
	{
		// Token: 0x060056D4 RID: 22228 RVA: 0x00134533 File Offset: 0x00132733
		internal RemotingMethodCachedData(RuntimeMethodInfo ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056D5 RID: 22229 RVA: 0x00134542 File Offset: 0x00132742
		internal RemotingMethodCachedData(RuntimeConstructorInfo ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056D6 RID: 22230 RVA: 0x00134554 File Offset: 0x00132754
		internal override SoapAttribute GetSoapAttributeNoLock()
		{
			object[] customAttributes = this.RI.GetCustomAttributes(typeof(SoapMethodAttribute), true);
			SoapAttribute soapAttribute;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				soapAttribute = (SoapAttribute)customAttributes[0];
			}
			else
			{
				soapAttribute = new SoapMethodAttribute();
			}
			soapAttribute.SetReflectInfo(this.RI);
			return soapAttribute;
		}

		// Token: 0x17000E43 RID: 3651
		// (get) Token: 0x060056D7 RID: 22231 RVA: 0x0013459F File Offset: 0x0013279F
		internal string TypeAndAssemblyName
		{
			[SecurityCritical]
			get
			{
				if (this._typeAndAssemblyName == null)
				{
					this.UpdateNames();
				}
				return this._typeAndAssemblyName;
			}
		}

		// Token: 0x17000E44 RID: 3652
		// (get) Token: 0x060056D8 RID: 22232 RVA: 0x001345B5 File Offset: 0x001327B5
		internal string MethodName
		{
			[SecurityCritical]
			get
			{
				if (this._methodName == null)
				{
					this.UpdateNames();
				}
				return this._methodName;
			}
		}

		// Token: 0x060056D9 RID: 22233 RVA: 0x001345CC File Offset: 0x001327CC
		[SecurityCritical]
		private void UpdateNames()
		{
			MethodBase ri = this.RI;
			this._methodName = ri.Name;
			if (ri.DeclaringType != null)
			{
				this._typeAndAssemblyName = RemotingServices.GetDefaultQualifiedTypeName((RuntimeType)ri.DeclaringType);
			}
		}

		// Token: 0x17000E45 RID: 3653
		// (get) Token: 0x060056DA RID: 22234 RVA: 0x00134610 File Offset: 0x00132810
		internal ParameterInfo[] Parameters
		{
			get
			{
				if (this._parameters == null)
				{
					this._parameters = this.RI.GetParameters();
				}
				return this._parameters;
			}
		}

		// Token: 0x17000E46 RID: 3654
		// (get) Token: 0x060056DB RID: 22235 RVA: 0x00134631 File Offset: 0x00132831
		internal int[] OutRefArgMap
		{
			get
			{
				if (this._outRefArgMap == null)
				{
					this.GetArgMaps();
				}
				return this._outRefArgMap;
			}
		}

		// Token: 0x17000E47 RID: 3655
		// (get) Token: 0x060056DC RID: 22236 RVA: 0x00134647 File Offset: 0x00132847
		internal int[] OutOnlyArgMap
		{
			get
			{
				if (this._outOnlyArgMap == null)
				{
					this.GetArgMaps();
				}
				return this._outOnlyArgMap;
			}
		}

		// Token: 0x17000E48 RID: 3656
		// (get) Token: 0x060056DD RID: 22237 RVA: 0x0013465D File Offset: 0x0013285D
		internal int[] NonRefOutArgMap
		{
			get
			{
				if (this._nonRefOutArgMap == null)
				{
					this.GetArgMaps();
				}
				return this._nonRefOutArgMap;
			}
		}

		// Token: 0x17000E49 RID: 3657
		// (get) Token: 0x060056DE RID: 22238 RVA: 0x00134673 File Offset: 0x00132873
		internal int[] MarshalRequestArgMap
		{
			get
			{
				if (this._marshalRequestMap == null)
				{
					this.GetArgMaps();
				}
				return this._marshalRequestMap;
			}
		}

		// Token: 0x17000E4A RID: 3658
		// (get) Token: 0x060056DF RID: 22239 RVA: 0x00134689 File Offset: 0x00132889
		internal int[] MarshalResponseArgMap
		{
			get
			{
				if (this._marshalResponseMap == null)
				{
					this.GetArgMaps();
				}
				return this._marshalResponseMap;
			}
		}

		// Token: 0x060056E0 RID: 22240 RVA: 0x001346A0 File Offset: 0x001328A0
		private void GetArgMaps()
		{
			lock (this)
			{
				if (this._inRefArgMap == null)
				{
					int[] inRefArgMap = null;
					int[] outRefArgMap = null;
					int[] outOnlyArgMap = null;
					int[] nonRefOutArgMap = null;
					int[] marshalRequestMap = null;
					int[] marshalResponseMap = null;
					ArgMapper.GetParameterMaps(this.Parameters, out inRefArgMap, out outRefArgMap, out outOnlyArgMap, out nonRefOutArgMap, out marshalRequestMap, out marshalResponseMap);
					this._inRefArgMap = inRefArgMap;
					this._outRefArgMap = outRefArgMap;
					this._outOnlyArgMap = outOnlyArgMap;
					this._nonRefOutArgMap = nonRefOutArgMap;
					this._marshalRequestMap = marshalRequestMap;
					this._marshalResponseMap = marshalResponseMap;
				}
			}
		}

		// Token: 0x060056E1 RID: 22241 RVA: 0x00134734 File Offset: 0x00132934
		internal bool IsOneWayMethod()
		{
			if ((this.flags & RemotingMethodCachedData.MethodCacheFlags.CheckedOneWay) == RemotingMethodCachedData.MethodCacheFlags.None)
			{
				RemotingMethodCachedData.MethodCacheFlags methodCacheFlags = RemotingMethodCachedData.MethodCacheFlags.CheckedOneWay;
				object[] customAttributes = this.RI.GetCustomAttributes(typeof(OneWayAttribute), true);
				if (customAttributes != null && customAttributes.Length != 0)
				{
					methodCacheFlags |= RemotingMethodCachedData.MethodCacheFlags.IsOneWay;
				}
				this.flags |= methodCacheFlags;
				return (methodCacheFlags & RemotingMethodCachedData.MethodCacheFlags.IsOneWay) > RemotingMethodCachedData.MethodCacheFlags.None;
			}
			return (this.flags & RemotingMethodCachedData.MethodCacheFlags.IsOneWay) > RemotingMethodCachedData.MethodCacheFlags.None;
		}

		// Token: 0x060056E2 RID: 22242 RVA: 0x00134790 File Offset: 0x00132990
		internal bool IsOverloaded()
		{
			if ((this.flags & RemotingMethodCachedData.MethodCacheFlags.CheckedOverloaded) == RemotingMethodCachedData.MethodCacheFlags.None)
			{
				RemotingMethodCachedData.MethodCacheFlags methodCacheFlags = RemotingMethodCachedData.MethodCacheFlags.CheckedOverloaded;
				MethodBase ri = this.RI;
				RuntimeMethodInfo runtimeMethodInfo;
				if ((runtimeMethodInfo = (ri as RuntimeMethodInfo)) != null)
				{
					if (runtimeMethodInfo.IsOverloaded)
					{
						methodCacheFlags |= RemotingMethodCachedData.MethodCacheFlags.IsOverloaded;
					}
				}
				else
				{
					RuntimeConstructorInfo runtimeConstructorInfo;
					if (!((runtimeConstructorInfo = (ri as RuntimeConstructorInfo)) != null))
					{
						throw new NotSupportedException(Environment.GetResourceString("InvalidOperation_Method"));
					}
					if (runtimeConstructorInfo.IsOverloaded)
					{
						methodCacheFlags |= RemotingMethodCachedData.MethodCacheFlags.IsOverloaded;
					}
				}
				this.flags |= methodCacheFlags;
			}
			return (this.flags & RemotingMethodCachedData.MethodCacheFlags.IsOverloaded) > RemotingMethodCachedData.MethodCacheFlags.None;
		}

		// Token: 0x17000E4B RID: 3659
		// (get) Token: 0x060056E3 RID: 22243 RVA: 0x0013481C File Offset: 0x00132A1C
		internal Type ReturnType
		{
			get
			{
				if ((this.flags & RemotingMethodCachedData.MethodCacheFlags.CheckedForReturnType) == RemotingMethodCachedData.MethodCacheFlags.None)
				{
					MethodInfo methodInfo = this.RI as MethodInfo;
					if (methodInfo != null)
					{
						Type returnType = methodInfo.ReturnType;
						if (returnType != typeof(void))
						{
							this._returnType = returnType;
						}
					}
					this.flags |= RemotingMethodCachedData.MethodCacheFlags.CheckedForReturnType;
				}
				return this._returnType;
			}
		}

		// Token: 0x040027B7 RID: 10167
		private MethodBase RI;

		// Token: 0x040027B8 RID: 10168
		private ParameterInfo[] _parameters;

		// Token: 0x040027B9 RID: 10169
		private RemotingMethodCachedData.MethodCacheFlags flags;

		// Token: 0x040027BA RID: 10170
		private string _typeAndAssemblyName;

		// Token: 0x040027BB RID: 10171
		private string _methodName;

		// Token: 0x040027BC RID: 10172
		private Type _returnType;

		// Token: 0x040027BD RID: 10173
		private int[] _inRefArgMap;

		// Token: 0x040027BE RID: 10174
		private int[] _outRefArgMap;

		// Token: 0x040027BF RID: 10175
		private int[] _outOnlyArgMap;

		// Token: 0x040027C0 RID: 10176
		private int[] _nonRefOutArgMap;

		// Token: 0x040027C1 RID: 10177
		private int[] _marshalRequestMap;

		// Token: 0x040027C2 RID: 10178
		private int[] _marshalResponseMap;

		// Token: 0x02000C6D RID: 3181
		[Flags]
		[Serializable]
		private enum MethodCacheFlags
		{
			// Token: 0x040037E0 RID: 14304
			None = 0,
			// Token: 0x040037E1 RID: 14305
			CheckedOneWay = 1,
			// Token: 0x040037E2 RID: 14306
			IsOneWay = 2,
			// Token: 0x040037E3 RID: 14307
			CheckedOverloaded = 4,
			// Token: 0x040037E4 RID: 14308
			IsOverloaded = 8,
			// Token: 0x040037E5 RID: 14309
			CheckedForAsync = 16,
			// Token: 0x040037E6 RID: 14310
			CheckedForReturnType = 32
		}
	}
}
