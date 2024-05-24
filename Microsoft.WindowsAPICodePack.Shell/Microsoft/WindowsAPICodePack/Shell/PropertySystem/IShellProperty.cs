using System;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200013D RID: 317
	public interface IShellProperty
	{
		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x06000DAC RID: 3500
		PropertyKey PropertyKey { get; }

		// Token: 0x06000DAD RID: 3501
		string FormatForDisplay(PropertyDescriptionFormatOptions format);

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06000DAE RID: 3502
		ShellPropertyDescription Description { get; }

		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06000DAF RID: 3503
		string CanonicalName { get; }

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06000DB0 RID: 3504
		object ValueAsObject { get; }

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06000DB1 RID: 3505
		Type ValueType { get; }

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x06000DB2 RID: 3506
		IconReference IconReference { get; }
	}
}
