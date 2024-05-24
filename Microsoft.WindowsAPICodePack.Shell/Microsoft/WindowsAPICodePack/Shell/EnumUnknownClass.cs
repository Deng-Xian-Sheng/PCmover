using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000003 RID: 3
	internal class EnumUnknownClass : IEnumUnknown
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
		internal EnumUnknownClass(ICondition[] conditions)
		{
			this.conditionList.AddRange(conditions);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000207C File Offset: 0x0000027C
		public HResult Next(uint requestedNumber, ref IntPtr buffer, ref uint fetchedNumber)
		{
			this.current++;
			HResult result;
			if (this.current < this.conditionList.Count)
			{
				buffer = Marshal.GetIUnknownForObject(this.conditionList[this.current]);
				fetchedNumber = 1U;
				result = HResult.Ok;
			}
			else
			{
				result = HResult.False;
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020DC File Offset: 0x000002DC
		public HResult Skip(uint number)
		{
			int num = this.current + (int)number;
			HResult result;
			if (num > this.conditionList.Count - 1)
			{
				result = HResult.False;
			}
			else
			{
				this.current = num;
				result = HResult.Ok;
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000211C File Offset: 0x0000031C
		public HResult Reset()
		{
			this.current = -1;
			return HResult.Ok;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002138 File Offset: 0x00000338
		public HResult Clone(out IEnumUnknown result)
		{
			result = new EnumUnknownClass(this.conditionList.ToArray());
			return HResult.Ok;
		}

		// Token: 0x04000001 RID: 1
		private List<ICondition> conditionList = new List<ICondition>();

		// Token: 0x04000002 RID: 2
		private int current = -1;
	}
}
