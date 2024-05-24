using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005C7 RID: 1479
	[ComVisible(true)]
	public class AssemblyNameProxy : MarshalByRefObject
	{
		// Token: 0x060044AD RID: 17581 RVA: 0x000FCD26 File Offset: 0x000FAF26
		public AssemblyName GetAssemblyName(string assemblyFile)
		{
			return AssemblyName.GetAssemblyName(assemblyFile);
		}
	}
}
