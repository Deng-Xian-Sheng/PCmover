using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A1B RID: 2587
	[Guid("393de7de-6fd0-4c0d-bb71-47244a113e93")]
	[ComImport]
	internal interface IBindableVector : IBindableIterable
	{
		// Token: 0x060065E0 RID: 26080
		object GetAt(uint index);

		// Token: 0x17001182 RID: 4482
		// (get) Token: 0x060065E1 RID: 26081
		uint Size { get; }

		// Token: 0x060065E2 RID: 26082
		IBindableVectorView GetView();

		// Token: 0x060065E3 RID: 26083
		bool IndexOf(object value, out uint index);

		// Token: 0x060065E4 RID: 26084
		void SetAt(uint index, object value);

		// Token: 0x060065E5 RID: 26085
		void InsertAt(uint index, object value);

		// Token: 0x060065E6 RID: 26086
		void RemoveAt(uint index);

		// Token: 0x060065E7 RID: 26087
		void Append(object value);

		// Token: 0x060065E8 RID: 26088
		void RemoveAtEnd();

		// Token: 0x060065E9 RID: 26089
		void Clear();
	}
}
