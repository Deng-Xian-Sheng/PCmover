using System;
using System.Reflection;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000780 RID: 1920
	internal sealed class BinaryAssemblyInfo
	{
		// Token: 0x060053BD RID: 21437 RVA: 0x00126D47 File Offset: 0x00124F47
		internal BinaryAssemblyInfo(string assemblyString)
		{
			this.assemblyString = assemblyString;
		}

		// Token: 0x060053BE RID: 21438 RVA: 0x00126D56 File Offset: 0x00124F56
		internal BinaryAssemblyInfo(string assemblyString, Assembly assembly)
		{
			this.assemblyString = assemblyString;
			this.assembly = assembly;
		}

		// Token: 0x060053BF RID: 21439 RVA: 0x00126D6C File Offset: 0x00124F6C
		internal Assembly GetAssembly()
		{
			if (this.assembly == null)
			{
				this.assembly = FormatterServices.LoadAssemblyFromStringNoThrow(this.assemblyString);
				if (this.assembly == null)
				{
					throw new SerializationException(Environment.GetResourceString("Serialization_AssemblyNotFound", new object[]
					{
						this.assemblyString
					}));
				}
			}
			return this.assembly;
		}

		// Token: 0x040025B1 RID: 9649
		internal string assemblyString;

		// Token: 0x040025B2 RID: 9650
		private Assembly assembly;
	}
}
