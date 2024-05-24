using System;
using System.Collections;

namespace System.Security.Policy
{
	// Token: 0x02000366 RID: 870
	internal sealed class CodeGroupStack
	{
		// Token: 0x06002B0F RID: 11023 RVA: 0x000A0927 File Offset: 0x0009EB27
		internal CodeGroupStack()
		{
			this.m_array = new ArrayList();
		}

		// Token: 0x06002B10 RID: 11024 RVA: 0x000A093A File Offset: 0x0009EB3A
		internal void Push(CodeGroupStackFrame element)
		{
			this.m_array.Add(element);
		}

		// Token: 0x06002B11 RID: 11025 RVA: 0x000A094C File Offset: 0x0009EB4C
		internal CodeGroupStackFrame Pop()
		{
			if (this.IsEmpty())
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EmptyStack"));
			}
			int count = this.m_array.Count;
			CodeGroupStackFrame result = (CodeGroupStackFrame)this.m_array[count - 1];
			this.m_array.RemoveAt(count - 1);
			return result;
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x000A09A0 File Offset: 0x0009EBA0
		internal bool IsEmpty()
		{
			return this.m_array.Count == 0;
		}

		// Token: 0x04001188 RID: 4488
		private ArrayList m_array;
	}
}
