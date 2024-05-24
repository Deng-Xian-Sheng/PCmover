using System;
using System.Globalization;
using System.Runtime.Serialization;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public class ModuleInitializeException : ModularityException
	{
		// Token: 0x060002FF RID: 767 RVA: 0x000068FD File Offset: 0x00004AFD
		public ModuleInitializeException()
		{
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00006905 File Offset: 0x00004B05
		public ModuleInitializeException(string message) : base(message)
		{
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0000690E File Offset: 0x00004B0E
		public ModuleInitializeException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00007F0D File Offset: 0x0000610D
		public ModuleInitializeException(string moduleName, string moduleAssembly, string message) : this(moduleName, message, moduleAssembly, null)
		{
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00007F19 File Offset: 0x00006119
		public ModuleInitializeException(string moduleName, string moduleAssembly, string message, Exception innerException) : base(moduleName, string.Format(CultureInfo.CurrentCulture, Resources.FailedToLoadModule, new object[]
		{
			moduleName,
			moduleAssembly,
			message
		}), innerException)
		{
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00007F45 File Offset: 0x00006145
		public ModuleInitializeException(string moduleName, string message, Exception innerException) : base(moduleName, string.Format(CultureInfo.CurrentCulture, Resources.FailedToLoadModuleNoAssemblyInfo, new object[]
		{
			moduleName,
			message
		}), innerException)
		{
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00006923 File Offset: 0x00004B23
		protected ModuleInitializeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
