using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x02000A18 RID: 2584
	[Guid("913337e9-11a1-4345-a3a2-4e7f956e222d")]
	[ComImport]
	internal interface IVector<T> : IIterable<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x060065C4 RID: 26052
		T GetAt(uint index);

		// Token: 0x1700117F RID: 4479
		// (get) Token: 0x060065C5 RID: 26053
		uint Size { get; }

		// Token: 0x060065C6 RID: 26054
		IReadOnlyList<T> GetView();

		// Token: 0x060065C7 RID: 26055
		bool IndexOf(T value, out uint index);

		// Token: 0x060065C8 RID: 26056
		void SetAt(uint index, T value);

		// Token: 0x060065C9 RID: 26057
		void InsertAt(uint index, T value);

		// Token: 0x060065CA RID: 26058
		void RemoveAt(uint index);

		// Token: 0x060065CB RID: 26059
		void Append(T value);

		// Token: 0x060065CC RID: 26060
		void RemoveAtEnd();

		// Token: 0x060065CD RID: 26061
		void Clear();

		// Token: 0x060065CE RID: 26062
		uint GetMany(uint startIndex, [Out] T[] items);

		// Token: 0x060065CF RID: 26063
		void ReplaceAll(T[] items);
	}
}
