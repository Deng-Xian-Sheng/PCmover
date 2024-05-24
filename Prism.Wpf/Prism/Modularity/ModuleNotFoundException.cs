using System;
using System.Runtime.Serialization;

namespace Prism.Modularity
{
	// Token: 0x02000068 RID: 104
	[Serializable]
	public class ModuleNotFoundException : ModularityException
	{
		// Token: 0x06000325 RID: 805 RVA: 0x000068FD File Offset: 0x00004AFD
		public ModuleNotFoundException()
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x00006905 File Offset: 0x00004B05
		public ModuleNotFoundException(string message) : base(message)
		{
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000690E File Offset: 0x00004B0E
		public ModuleNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00006AC2 File Offset: 0x00004CC2
		public ModuleNotFoundException(string moduleName, string message) : base(moduleName, message)
		{
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00006918 File Offset: 0x00004B18
		public ModuleNotFoundException(string moduleName, string message, Exception innerException) : base(moduleName, message, innerException)
		{
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00006923 File Offset: 0x00004B23
		protected ModuleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
