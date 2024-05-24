using System;
using System.Collections.Generic;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009D2 RID: 2514
	internal sealed class EnumeratorToIteratorAdapter<T> : IIterator<T>, IBindableIterator
	{
		// Token: 0x060063FD RID: 25597 RVA: 0x00154FD0 File Offset: 0x001531D0
		internal EnumeratorToIteratorAdapter(IEnumerator<T> enumerator)
		{
			this.m_enumerator = enumerator;
		}

		// Token: 0x1700114D RID: 4429
		// (get) Token: 0x060063FE RID: 25598 RVA: 0x00154FE6 File Offset: 0x001531E6
		public T Current
		{
			get
			{
				if (this.m_firstItem)
				{
					this.m_firstItem = false;
					this.MoveNext();
				}
				if (!this.m_hasCurrent)
				{
					throw WindowsRuntimeMarshal.GetExceptionForHR(-2147483637, null);
				}
				return this.m_enumerator.Current;
			}
		}

		// Token: 0x1700114E RID: 4430
		// (get) Token: 0x060063FF RID: 25599 RVA: 0x0015501D File Offset: 0x0015321D
		object IBindableIterator.Current
		{
			get
			{
				return ((IIterator<T>)this).Current;
			}
		}

		// Token: 0x1700114F RID: 4431
		// (get) Token: 0x06006400 RID: 25600 RVA: 0x0015502A File Offset: 0x0015322A
		public bool HasCurrent
		{
			get
			{
				if (this.m_firstItem)
				{
					this.m_firstItem = false;
					this.MoveNext();
				}
				return this.m_hasCurrent;
			}
		}

		// Token: 0x06006401 RID: 25601 RVA: 0x00155048 File Offset: 0x00153248
		public bool MoveNext()
		{
			try
			{
				this.m_hasCurrent = this.m_enumerator.MoveNext();
			}
			catch (InvalidOperationException innerException)
			{
				throw WindowsRuntimeMarshal.GetExceptionForHR(-2147483636, innerException);
			}
			return this.m_hasCurrent;
		}

		// Token: 0x06006402 RID: 25602 RVA: 0x0015508C File Offset: 0x0015328C
		public int GetMany(T[] items)
		{
			if (items == null)
			{
				return 0;
			}
			int num = 0;
			while (num < items.Length && this.HasCurrent)
			{
				items[num] = this.Current;
				this.MoveNext();
				num++;
			}
			if (typeof(T) == typeof(string))
			{
				string[] array = items as string[];
				for (int i = num; i < items.Length; i++)
				{
					array[i] = string.Empty;
				}
			}
			return num;
		}

		// Token: 0x04002CE4 RID: 11492
		private IEnumerator<T> m_enumerator;

		// Token: 0x04002CE5 RID: 11493
		private bool m_firstItem = true;

		// Token: 0x04002CE6 RID: 11494
		private bool m_hasCurrent;
	}
}
