using System;
using System.Runtime.Serialization;

namespace Prism.Modularity
{
	// Token: 0x0200006B RID: 107
	[Serializable]
	public class ModuleTypeLoaderNotFoundException : ModularityException
	{
		// Token: 0x0600032E RID: 814 RVA: 0x000068FD File Offset: 0x00004AFD
		public ModuleTypeLoaderNotFoundException()
		{
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00006905 File Offset: 0x00004B05
		public ModuleTypeLoaderNotFoundException(string message) : base(message)
		{
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000690E File Offset: 0x00004B0E
		public ModuleTypeLoaderNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00006918 File Offset: 0x00004B18
		public ModuleTypeLoaderNotFoundException(string moduleName, string message, Exception innerException) : base(moduleName, message, innerException)
		{
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00006923 File Offset: 0x00004B23
		protected ModuleTypeLoaderNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
