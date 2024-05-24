using System;
using System.Runtime.Serialization;

namespace Prism.Modularity
{
	// Token: 0x0200004A RID: 74
	[Serializable]
	public class CyclicDependencyFoundException : ModularityException
	{
		// Token: 0x0600022E RID: 558 RVA: 0x000068FD File Offset: 0x00004AFD
		public CyclicDependencyFoundException()
		{
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00006905 File Offset: 0x00004B05
		public CyclicDependencyFoundException(string message) : base(message)
		{
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000690E File Offset: 0x00004B0E
		public CyclicDependencyFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00006918 File Offset: 0x00004B18
		public CyclicDependencyFoundException(string moduleName, string message, Exception innerException) : base(moduleName, message, innerException)
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00006923 File Offset: 0x00004B23
		protected CyclicDependencyFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
