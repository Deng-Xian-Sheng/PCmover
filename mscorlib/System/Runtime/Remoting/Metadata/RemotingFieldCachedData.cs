using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting.Metadata
{
	// Token: 0x020007D0 RID: 2000
	internal class RemotingFieldCachedData : RemotingCachedData
	{
		// Token: 0x060056C7 RID: 22215 RVA: 0x00134310 File Offset: 0x00132510
		internal RemotingFieldCachedData(RuntimeFieldInfo ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056C8 RID: 22216 RVA: 0x0013431F File Offset: 0x0013251F
		internal RemotingFieldCachedData(SerializationFieldInfo ri)
		{
			this.RI = ri;
		}

		// Token: 0x060056C9 RID: 22217 RVA: 0x00134330 File Offset: 0x00132530
		internal override SoapAttribute GetSoapAttributeNoLock()
		{
			object[] customAttributes = this.RI.GetCustomAttributes(typeof(SoapFieldAttribute), false);
			SoapAttribute soapAttribute;
			if (customAttributes != null && customAttributes.Length != 0)
			{
				soapAttribute = (SoapAttribute)customAttributes[0];
			}
			else
			{
				soapAttribute = new SoapFieldAttribute();
			}
			soapAttribute.SetReflectInfo(this.RI);
			return soapAttribute;
		}

		// Token: 0x040027AF RID: 10159
		private FieldInfo RI;
	}
}
