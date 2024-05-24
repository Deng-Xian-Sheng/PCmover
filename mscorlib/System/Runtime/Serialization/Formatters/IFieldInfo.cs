using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	// Token: 0x02000760 RID: 1888
	[ComVisible(true)]
	public interface IFieldInfo
	{
		// Token: 0x17000DBE RID: 3518
		// (get) Token: 0x060052FF RID: 21247
		// (set) Token: 0x06005300 RID: 21248
		string[] FieldNames { [SecurityCritical] get; [SecurityCritical] set; }

		// Token: 0x17000DBF RID: 3519
		// (get) Token: 0x06005301 RID: 21249
		// (set) Token: 0x06005302 RID: 21250
		Type[] FieldTypes { [SecurityCritical] get; [SecurityCritical] set; }
	}
}
