using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D2 RID: 2002
	internal class RemotingTypeCachedData : RemotingCachedData
	{
		// Token: 0x060056CC RID: 22220 RVA: 0x001343D7 File Offset: 0x001325D7
		internal RemotingTypeCachedData(RuntimeType ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056CD RID: 22221 RVA: 0x001343E8 File Offset: 0x001325E8
		internal override SoapAttribute GetSoapAttributeNoLock()
		{
			object[] customAttributes = this.RI.GetCustomAttributes(typeof(SoapTypeAttribute), true);
			SoapAttribute soapAttribute;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				soapAttribute = (SoapAttribute)customAttributes[0];
			}
			else
			{
				soapAttribute = new SoapTypeAttribute();
			}
			soapAttribute.SetReflectInfo(this.RI);
			return soapAttribute;
		}

		// Token: 0x060056CE RID: 22222 RVA: 0x00134434 File Offset: 0x00132634
		internal MethodBase GetLastCalledMethod(string newMeth)
		{
			RemotingTypeCachedData.LastCalledMethodClass lastMethodCalled = this._lastMethodCalled;
			if (lastMethodCalled == null)
			{
				return null;
			}
			string methodName = lastMethodCalled.methodName;
			MethodBase mb = lastMethodCalled.MB;
			if (mb == null || methodName == null)
			{
				return null;
			}
			if (methodName.Equals(newMeth))
			{
				return mb;
			}
			return null;
		}

		// Token: 0x060056CF RID: 22223 RVA: 0x00134478 File Offset: 0x00132678
		internal void SetLastCalledMethod(string newMethName, MethodBase newMB)
		{
			this._lastMethodCalled = new RemotingTypeCachedData.LastCalledMethodClass
			{
				methodName = newMethName,
				MB = newMB
			};
		}

		// Token: 0x17000E3F RID: 3647
		// (get) Token: 0x060056D0 RID: 22224 RVA: 0x001344A0 File Offset: 0x001326A0
		internal TypeInfo TypeInfo
		{
			[SecurityCritical]
			get
			{
				if (this._typeInfo == null)
				{
					this._typeInfo = new TypeInfo(this.RI);
				}
				return this._typeInfo;
			}
		}

		// Token: 0x17000E40 RID: 3648
		// (get) Token: 0x060056D1 RID: 22225 RVA: 0x001344C1 File Offset: 0x001326C1
		internal string QualifiedTypeName
		{
			[SecurityCritical]
			get
			{
				if (this._qualifiedTypeName == null)
				{
					this._qualifiedTypeName = RemotingServices.DetermineDefaultQualifiedTypeName(this.RI);
				}
				return this._qualifiedTypeName;
			}
		}

		// Token: 0x17000E41 RID: 3649
		// (get) Token: 0x060056D2 RID: 22226 RVA: 0x001344E2 File Offset: 0x001326E2
		internal string AssemblyName
		{
			get
			{
				if (this._assemblyName == null)
				{
					this._assemblyName = this.RI.Module.Assembly.FullName;
				}
				return this._assemblyName;
			}
		}

		// Token: 0x17000E42 RID: 3650
		// (get) Token: 0x060056D3 RID: 22227 RVA: 0x0013450D File Offset: 0x0013270D
		internal string SimpleAssemblyName
		{
			[SecurityCritical]
			get
			{
				if (this._simpleAssemblyName == null)
				{
					this._simpleAssemblyName = this.RI.GetRuntimeAssembly().GetSimpleName();
				}
				return this._simpleAssemblyName;
			}
		}

		// Token: 0x040027B1 RID: 10161
		private RuntimeType RI;

		// Token: 0x040027B2 RID: 10162
		private RemotingTypeCachedData.LastCalledMethodClass _lastMethodCalled;

		// Token: 0x040027B3 RID: 10163
		private TypeInfo _typeInfo;

		// Token: 0x040027B4 RID: 10164
		private string _qualifiedTypeName;

		// Token: 0x040027B5 RID: 10165
		private string _assemblyName;

		// Token: 0x040027B6 RID: 10166
		private string _simpleAssemblyName;

		// Token: 0x02000C6C RID: 3180
		private class LastCalledMethodClass
		{
			// Token: 0x040037DD RID: 14301
			public string methodName;

			// Token: 0x040037DE RID: 14302
			public MethodBase MB;
		}
	}
}
