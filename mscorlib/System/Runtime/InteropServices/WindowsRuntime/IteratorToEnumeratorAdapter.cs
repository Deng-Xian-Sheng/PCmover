using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009EF RID: 2543
	internal sealed class IteratorToEnumeratorAdapter<T> : IEnumerator<!0>, IDisposable, IEnumerator
	{
		// Token: 0x060064B2 RID: 25778 RVA: 0x0015707C File Offset: 0x0015527C
		internal IteratorToEnumeratorAdapter(IIterator<T> iterator)
		{
			this.m_iterator = iterator;
			this.m_hadCurrent = true;
			this.m_isInitialized = false;
		}

		// Token: 0x17001157 RID: 4439
		// (get) Token: 0x060064B3 RID: 25779 RVA: 0x00157099 File Offset: 0x00155299
		public T Current
		{
			get
			{
				if (!this.m_isInitialized)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumNotStarted);
				}
				if (!this.m_hadCurrent)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumEnded);
				}
				return this.m_current;
			}
		}

		// Token: 0x17001158 RID: 4440
		// (get) Token: 0x060064B4 RID: 25780 RVA: 0x001570BF File Offset: 0x001552BF
		object IEnumerator.Current
		{
			get
			{
				if (!this.m_isInitialized)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumNotStarted);
				}
				if (!this.m_hadCurrent)
				{
					ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumEnded);
				}
				return this.m_current;
			}
		}

		// Token: 0x060064B5 RID: 25781 RVA: 0x001570EC File Offset: 0x001552EC
		[SecuritySafeCritical]
		public bool MoveNext()
		{
			if (!this.m_hadCurrent)
			{
				return false;
			}
			try
			{
				if (!this.m_isInitialized)
				{
					this.m_hadCurrent = this.m_iterator.HasCurrent;
					this.m_isInitialized = true;
				}
				else
				{
					this.m_hadCurrent = this.m_iterator.MoveNext();
				}
				if (this.m_hadCurrent)
				{
					this.m_current = this.m_iterator.Current;
				}
			}
			catch (Exception e)
			{
				if (Marshal.GetHRForException(e) != -2147483636)
				{
					throw;
				}
				ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
			}
			return this.m_hadCurrent;
		}

		// Token: 0x060064B6 RID: 25782 RVA: 0x00157184 File Offset: 0x00155384
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x060064B7 RID: 25783 RVA: 0x0015718B File Offset: 0x0015538B
		public void Dispose()
		{
		}

		// Token: 0x04002CF1 RID: 11505
		private IIterator<T> m_iterator;

		// Token: 0x04002CF2 RID: 11506
		private bool m_hadCurrent;

		// Token: 0x04002CF3 RID: 11507
		private T m_current;

		// Token: 0x04002CF4 RID: 11508
		private bool m_isInitialized;
	}
}
