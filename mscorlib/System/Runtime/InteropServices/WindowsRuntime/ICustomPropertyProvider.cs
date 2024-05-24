using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A0A RID: 2570
	[Guid("7C925755-3E48-42B4-8677-76372267033F")]
	[ComImport]
	internal interface ICustomPropertyProvider
	{
		// Token: 0x0600657A RID: 25978
		ICustomProperty GetCustomProperty(string name);

		// Token: 0x0600657B RID: 25979
		ICustomProperty GetIndexedProperty(string name, Type indexParameterType);

		// Token: 0x0600657C RID: 25980
		string GetStringRepresentation();

		// Token: 0x1700116F RID: 4463
		// (get) Token: 0x0600657D RID: 25981
		Type Type { get; }
	}
}
