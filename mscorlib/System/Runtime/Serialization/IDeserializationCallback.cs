using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000730 RID: 1840
	[ComVisible(true)]
	public interface IDeserializationCallback
	{
		// Token: 0x060051A0 RID: 20896
		void OnDeserialization(object sender);
	}
}
