using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200049B RID: 1179
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IDictionary : ICollection, IEnumerable
	{
		// Token: 0x17000870 RID: 2160
		[__DynamicallyInvokable]
		object this[object key]
		{
			[__DynamicallyInvokable]
			get;
			[__DynamicallyInvokable]
			set;
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x060038A9 RID: 14505
		[__DynamicallyInvokable]
		ICollection Keys { [__DynamicallyInvokable] get; }

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x060038AA RID: 14506
		[__DynamicallyInvokable]
		ICollection Values { [__DynamicallyInvokable] get; }

		// Token: 0x060038AB RID: 14507
		[__DynamicallyInvokable]
		bool Contains(object key);

		// Token: 0x060038AC RID: 14508
		[__DynamicallyInvokable]
		void Add(object key, object value);

		// Token: 0x060038AD RID: 14509
		[__DynamicallyInvokable]
		void Clear();

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x060038AE RID: 14510
		[__DynamicallyInvokable]
		bool IsReadOnly { [__DynamicallyInvokable] get; }

		// Token: 0x17000874 RID: 2164
		// (get) Token: 0x060038AF RID: 14511
		[__DynamicallyInvokable]
		bool IsFixedSize { [__DynamicallyInvokable] get; }

		// Token: 0x060038B0 RID: 14512
		[__DynamicallyInvokable]
		IDictionaryEnumerator GetEnumerator();

		// Token: 0x060038B1 RID: 14513
		[__DynamicallyInvokable]
		void Remove(object key);
	}
}
