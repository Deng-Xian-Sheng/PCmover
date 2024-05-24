using System;
using System.IO;
using System.Reflection;

namespace Laplink.Tools.Helpers
{
	// Token: 0x02000002 RID: 2
	public class AssemblyLoader<TInterface>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static TInterface LoadAssembly(string folder, string name)
		{
			foreach (Type type in Assembly.LoadFrom(Path.Combine(folder, name) + ".dll").GetExportedTypes())
			{
				if (type.IsClass && typeof(TInterface).IsAssignableFrom(type))
				{
					return (TInterface)((object)Activator.CreateInstance(type));
				}
			}
			throw new Exception(string.Format("{0} not found in {1}", typeof(TInterface).FullName, name));
		}
	}
}
