using System;
using System.Runtime.Serialization;

namespace Prism.Modularity
{
	// Token: 0x0200004C RID: 76
	[Serializable]
	public class DuplicateModuleException : ModularityException
	{
		// Token: 0x06000238 RID: 568 RVA: 0x000068FD File Offset: 0x00004AFD
		public DuplicateModuleException()
		{
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00006905 File Offset: 0x00004B05
		public DuplicateModuleException(string message) : base(message)
		{
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000690E File Offset: 0x00004B0E
		public DuplicateModuleException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006AC2 File Offset: 0x00004CC2
		public DuplicateModuleException(string moduleName, string message) : base(moduleName, message)
		{
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00006918 File Offset: 0x00004B18
		public DuplicateModuleException(string moduleName, string message, Exception innerException) : base(moduleName, message, innerException)
		{
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00006923 File Offset: 0x00004B23
		protected DuplicateModuleException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
