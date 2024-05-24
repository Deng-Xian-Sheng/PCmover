using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace System.Security.Policy
{
	// Token: 0x0200034D RID: 845
	[ComVisible(true)]
	[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
	[Serializable]
	public abstract class EvidenceBase
	{
		// Token: 0x06002A37 RID: 10807 RVA: 0x0009CA18 File Offset: 0x0009AC18
		protected EvidenceBase()
		{
			if (!base.GetType().IsSerializable)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Policy_EvidenceMustBeSerializable"));
			}
		}

		// Token: 0x06002A38 RID: 10808 RVA: 0x0009CA40 File Offset: 0x0009AC40
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, SerializationFormatter = true)]
		[PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
		public virtual EvidenceBase Clone()
		{
			EvidenceBase result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, this);
				memoryStream.Position = 0L;
				result = (binaryFormatter.Deserialize(memoryStream) as EvidenceBase);
			}
			return result;
		}
	}
}
