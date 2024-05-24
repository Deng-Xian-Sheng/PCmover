using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Reflection
{
	// Token: 0x02000609 RID: 1545
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class Missing : ISerializable
	{
		// Token: 0x06004782 RID: 18306 RVA: 0x001049AB File Offset: 0x00102BAB
		private Missing()
		{
		}

		// Token: 0x06004783 RID: 18307 RVA: 0x001049B3 File Offset: 0x00102BB3
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			UnitySerializationHolder.GetUnitySerializationInfo(info, this);
		}

		// Token: 0x04001DA6 RID: 7590
		[__DynamicallyInvokable]
		public static readonly Missing Value = new Missing();
	}
}
