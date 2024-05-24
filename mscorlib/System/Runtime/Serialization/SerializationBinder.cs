using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x0200073D RID: 1853
	[ComVisible(true)]
	[Serializable]
	public abstract class SerializationBinder
	{
		// Token: 0x060051CB RID: 20939 RVA: 0x0011FD4B File Offset: 0x0011DF4B
		public virtual void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			assemblyName = null;
			typeName = null;
		}

		// Token: 0x060051CC RID: 20940
		public abstract Type BindToType(string assemblyName, string typeName);
	}
}
