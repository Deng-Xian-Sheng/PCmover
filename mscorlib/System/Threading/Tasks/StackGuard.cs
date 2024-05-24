using System;
using System.Security;
using Microsoft.Win32;

namespace System.Threading.Tasks
{
	// Token: 0x02000565 RID: 1381
	internal class StackGuard
	{
		// Token: 0x06004154 RID: 16724 RVA: 0x000F3DF8 File Offset: 0x000F1FF8
		[SecuritySafeCritical]
		internal bool TryBeginInliningScope()
		{
			if (this.m_inliningDepth < 20 || this.CheckForSufficientStack())
			{
				this.m_inliningDepth++;
				return true;
			}
			return false;
		}

		// Token: 0x06004155 RID: 16725 RVA: 0x000F3E1D File Offset: 0x000F201D
		internal void EndInliningScope()
		{
			this.m_inliningDepth--;
			if (this.m_inliningDepth < 0)
			{
				this.m_inliningDepth = 0;
			}
		}

		// Token: 0x06004156 RID: 16726 RVA: 0x000F3E40 File Offset: 0x000F2040
		[SecurityCritical]
		private unsafe bool CheckForSufficientStack()
		{
			int num = StackGuard.s_pageSize;
			if (num == 0)
			{
				Win32Native.SYSTEM_INFO system_INFO = default(Win32Native.SYSTEM_INFO);
				Win32Native.GetSystemInfo(ref system_INFO);
				num = (StackGuard.s_pageSize = system_INFO.dwPageSize);
			}
			Win32Native.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION = default(Win32Native.MEMORY_BASIC_INFORMATION);
			UIntPtr uintPtr = new UIntPtr((void*)((byte*)(&memory_BASIC_INFORMATION) - (IntPtr)num * (IntPtr)sizeof(Win32Native.MEMORY_BASIC_INFORMATION)));
			ulong num2 = uintPtr.ToUInt64();
			if (this.m_lastKnownWatermark != 0UL && num2 > this.m_lastKnownWatermark)
			{
				return true;
			}
			Win32Native.VirtualQuery(uintPtr.ToPointer(), ref memory_BASIC_INFORMATION, (UIntPtr)((ulong)((long)sizeof(Win32Native.MEMORY_BASIC_INFORMATION))));
			if (num2 - ((UIntPtr)memory_BASIC_INFORMATION.AllocationBase).ToUInt64() > 65536UL)
			{
				this.m_lastKnownWatermark = num2;
				return true;
			}
			return false;
		}

		// Token: 0x04001B41 RID: 6977
		private int m_inliningDepth;

		// Token: 0x04001B42 RID: 6978
		private const int MAX_UNCHECKED_INLINING_DEPTH = 20;

		// Token: 0x04001B43 RID: 6979
		private ulong m_lastKnownWatermark;

		// Token: 0x04001B44 RID: 6980
		private static int s_pageSize;

		// Token: 0x04001B45 RID: 6981
		private const long STACK_RESERVED_SPACE = 65536L;
	}
}
