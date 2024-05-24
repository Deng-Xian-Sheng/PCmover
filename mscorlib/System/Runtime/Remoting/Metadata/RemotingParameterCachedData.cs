using System;
using System.Reflection;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D1 RID: 2001
	internal class RemotingParameterCachedData : RemotingCachedData
	{
		// Token: 0x060056CA RID: 22218 RVA: 0x0013437B File Offset: 0x0013257B
		internal RemotingParameterCachedData(RuntimeParameterInfo ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056CB RID: 22219 RVA: 0x0013438C File Offset: 0x0013258C
		internal override SoapAttribute GetSoapAttributeNoLock()
		{
			object[] customAttributes = this.RI.GetCustomAttributes(typeof(SoapParameterAttribute), true);
			SoapAttribute soapAttribute;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				soapAttribute = (SoapParameterAttribute)customAttributes[0];
			}
			else
			{
				soapAttribute = new SoapParameterAttribute();
			}
			soapAttribute.SetReflectInfo(this.RI);
			return soapAttribute;
		}

		// Token: 0x040027B0 RID: 10160
		private RuntimeParameterInfo RI;
	}
}
