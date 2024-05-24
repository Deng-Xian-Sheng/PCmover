using System;
using System.Globalization;
using System.Runtime.Serialization;
using Prism.Properties;

namespace Prism.Modularity
{
	// Token: 0x0200006C RID: 108
	[Serializable]
	public class ModuleTypeLoadingException : ModularityException
	{
		// Token: 0x06000333 RID: 819 RVA: 0x000068FD File Offset: 0x00004AFD
		public ModuleTypeLoadingException()
		{
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00006905 File Offset: 0x00004B05
		public ModuleTypeLoadingException(string message) : base(message)
		{
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000690E File Offset: 0x00004B0E
		public ModuleTypeLoadingException(string message, Exception exception) : base(message, exception)
		{
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00008767 File Offset: 0x00006967
		public ModuleTypeLoadingException(string moduleName, string message) : this(moduleName, message, null)
		{
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00008772 File Offset: 0x00006972
		public ModuleTypeLoadingException(string moduleName, string message, Exception innerException) : base(moduleName, string.Format(CultureInfo.CurrentCulture, Resources.FailedToRetrieveModule, new object[]
		{
			moduleName,
			message
		}), innerException)
		{
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00006923 File Offset: 0x00004B23
		protected ModuleTypeLoadingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
