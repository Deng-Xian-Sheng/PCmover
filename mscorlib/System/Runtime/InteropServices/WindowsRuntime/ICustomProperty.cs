using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A0F RID: 2575
	[Guid("30DA92C0-23E8-42A0-AE7C-734A0E5D2782")]
	[ComImport]
	internal interface ICustomProperty
	{
		// Token: 0x17001173 RID: 4467
		// (get) Token: 0x060065A0 RID: 26016
		Type Type { get; }

		// Token: 0x17001174 RID: 4468
		// (get) Token: 0x060065A1 RID: 26017
		string Name { get; }

		// Token: 0x060065A2 RID: 26018
		object GetValue(object target);

		// Token: 0x060065A3 RID: 26019
		void SetValue(object target, object value);

		// Token: 0x060065A4 RID: 26020
		object GetValue(object target, object indexValue);

		// Token: 0x060065A5 RID: 26021
		void SetValue(object target, object value, object indexValue);

		// Token: 0x17001175 RID: 4469
		// (get) Token: 0x060065A6 RID: 26022
		bool CanWrite { get; }

		// Token: 0x17001176 RID: 4470
		// (get) Token: 0x060065A7 RID: 26023
		bool CanRead { get; }
	}
}
