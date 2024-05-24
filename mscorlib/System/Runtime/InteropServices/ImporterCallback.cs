using System;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000950 RID: 2384
	internal class ImporterCallback : ITypeLibImporterNotifySink
	{
		// Token: 0x060061A4 RID: 24996 RVA: 0x0014E3E9 File Offset: 0x0014C5E9
		public void ReportEvent(ImporterEventKind EventKind, int EventCode, string EventMsg)
		{
		}

		// Token: 0x060061A5 RID: 24997 RVA: 0x0014E3EC File Offset: 0x0014C5EC
		[SecuritySafeCritical]
		public Assembly ResolveRef(object TypeLib)
		{
			Assembly result;
			try
			{
				ITypeLibConverter typeLibConverter = new TypeLibConverter();
				result = typeLibConverter.ConvertTypeLibToAssembly(TypeLib, Marshal.GetTypeLibName((ITypeLib)TypeLib) + ".dll", TypeLibImporterFlags.None, new ImporterCallback(), null, null, null, null);
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}
	}
}
