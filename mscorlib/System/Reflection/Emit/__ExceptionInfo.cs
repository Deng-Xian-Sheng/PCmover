using System;

namespace System.Reflection.Emit
{
	// Token: 0x0200063E RID: 1598
	internal sealed class __ExceptionInfo
	{
		// Token: 0x06004AD9 RID: 19161 RVA: 0x0010F36C File Offset: 0x0010D56C
		private __ExceptionInfo()
		{
			this.m_startAddr = 0;
			this.m_filterAddr = null;
			this.m_catchAddr = null;
			this.m_catchEndAddr = null;
			this.m_endAddr = 0;
			this.m_currentCatch = 0;
			this.m_type = null;
			this.m_endFinally = -1;
			this.m_currentState = 0;
		}

		// Token: 0x06004ADA RID: 19162 RVA: 0x0010F3C0 File Offset: 0x0010D5C0
		internal __ExceptionInfo(int startAddr, Label endLabel)
		{
			this.m_startAddr = startAddr;
			this.m_endAddr = -1;
			this.m_filterAddr = new int[4];
			this.m_catchAddr = new int[4];
			this.m_catchEndAddr = new int[4];
			this.m_catchClass = new Type[4];
			this.m_currentCatch = 0;
			this.m_endLabel = endLabel;
			this.m_type = new int[4];
			this.m_endFinally = -1;
			this.m_currentState = 0;
		}

		// Token: 0x06004ADB RID: 19163 RVA: 0x0010F43C File Offset: 0x0010D63C
		private static Type[] EnlargeArray(Type[] incoming)
		{
			Type[] array = new Type[incoming.Length * 2];
			Array.Copy(incoming, array, incoming.Length);
			return array;
		}

		// Token: 0x06004ADC RID: 19164 RVA: 0x0010F460 File Offset: 0x0010D660
		private void MarkHelper(int catchorfilterAddr, int catchEndAddr, Type catchClass, int type)
		{
			if (this.m_currentCatch >= this.m_catchAddr.Length)
			{
				this.m_filterAddr = ILGenerator.EnlargeArray(this.m_filterAddr);
				this.m_catchAddr = ILGenerator.EnlargeArray(this.m_catchAddr);
				this.m_catchEndAddr = ILGenerator.EnlargeArray(this.m_catchEndAddr);
				this.m_catchClass = __ExceptionInfo.EnlargeArray(this.m_catchClass);
				this.m_type = ILGenerator.EnlargeArray(this.m_type);
			}
			if (type == 1)
			{
				this.m_type[this.m_currentCatch] = type;
				this.m_filterAddr[this.m_currentCatch] = catchorfilterAddr;
				this.m_catchAddr[this.m_currentCatch] = -1;
				if (this.m_currentCatch > 0)
				{
					this.m_catchEndAddr[this.m_currentCatch - 1] = catchorfilterAddr;
				}
			}
			else
			{
				this.m_catchClass[this.m_currentCatch] = catchClass;
				if (this.m_type[this.m_currentCatch] != 1)
				{
					this.m_type[this.m_currentCatch] = type;
				}
				this.m_catchAddr[this.m_currentCatch] = catchorfilterAddr;
				if (this.m_currentCatch > 0 && this.m_type[this.m_currentCatch] != 1)
				{
					this.m_catchEndAddr[this.m_currentCatch - 1] = catchEndAddr;
				}
				this.m_catchEndAddr[this.m_currentCatch] = -1;
				this.m_currentCatch++;
			}
			if (this.m_endAddr == -1)
			{
				this.m_endAddr = catchorfilterAddr;
			}
		}

		// Token: 0x06004ADD RID: 19165 RVA: 0x0010F5B3 File Offset: 0x0010D7B3
		internal void MarkFilterAddr(int filterAddr)
		{
			this.m_currentState = 1;
			this.MarkHelper(filterAddr, filterAddr, null, 1);
		}

		// Token: 0x06004ADE RID: 19166 RVA: 0x0010F5C6 File Offset: 0x0010D7C6
		internal void MarkFaultAddr(int faultAddr)
		{
			this.m_currentState = 4;
			this.MarkHelper(faultAddr, faultAddr, null, 4);
		}

		// Token: 0x06004ADF RID: 19167 RVA: 0x0010F5D9 File Offset: 0x0010D7D9
		internal void MarkCatchAddr(int catchAddr, Type catchException)
		{
			this.m_currentState = 2;
			this.MarkHelper(catchAddr, catchAddr, catchException, 0);
		}

		// Token: 0x06004AE0 RID: 19168 RVA: 0x0010F5EC File Offset: 0x0010D7EC
		internal void MarkFinallyAddr(int finallyAddr, int endCatchAddr)
		{
			if (this.m_endFinally != -1)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_TooManyFinallyClause"));
			}
			this.m_currentState = 3;
			this.m_endFinally = finallyAddr;
			this.MarkHelper(finallyAddr, endCatchAddr, null, 2);
		}

		// Token: 0x06004AE1 RID: 19169 RVA: 0x0010F61F File Offset: 0x0010D81F
		internal void Done(int endAddr)
		{
			this.m_catchEndAddr[this.m_currentCatch - 1] = endAddr;
			this.m_currentState = 5;
		}

		// Token: 0x06004AE2 RID: 19170 RVA: 0x0010F638 File Offset: 0x0010D838
		internal int GetStartAddress()
		{
			return this.m_startAddr;
		}

		// Token: 0x06004AE3 RID: 19171 RVA: 0x0010F640 File Offset: 0x0010D840
		internal int GetEndAddress()
		{
			return this.m_endAddr;
		}

		// Token: 0x06004AE4 RID: 19172 RVA: 0x0010F648 File Offset: 0x0010D848
		internal int GetFinallyEndAddress()
		{
			return this.m_endFinally;
		}

		// Token: 0x06004AE5 RID: 19173 RVA: 0x0010F650 File Offset: 0x0010D850
		internal Label GetEndLabel()
		{
			return this.m_endLabel;
		}

		// Token: 0x06004AE6 RID: 19174 RVA: 0x0010F658 File Offset: 0x0010D858
		internal int[] GetFilterAddresses()
		{
			return this.m_filterAddr;
		}

		// Token: 0x06004AE7 RID: 19175 RVA: 0x0010F660 File Offset: 0x0010D860
		internal int[] GetCatchAddresses()
		{
			return this.m_catchAddr;
		}

		// Token: 0x06004AE8 RID: 19176 RVA: 0x0010F668 File Offset: 0x0010D868
		internal int[] GetCatchEndAddresses()
		{
			return this.m_catchEndAddr;
		}

		// Token: 0x06004AE9 RID: 19177 RVA: 0x0010F670 File Offset: 0x0010D870
		internal Type[] GetCatchClass()
		{
			return this.m_catchClass;
		}

		// Token: 0x06004AEA RID: 19178 RVA: 0x0010F678 File Offset: 0x0010D878
		internal int GetNumberOfCatches()
		{
			return this.m_currentCatch;
		}

		// Token: 0x06004AEB RID: 19179 RVA: 0x0010F680 File Offset: 0x0010D880
		internal int[] GetExceptionTypes()
		{
			return this.m_type;
		}

		// Token: 0x06004AEC RID: 19180 RVA: 0x0010F688 File Offset: 0x0010D888
		internal void SetFinallyEndLabel(Label lbl)
		{
			this.m_finallyEndLabel = lbl;
		}

		// Token: 0x06004AED RID: 19181 RVA: 0x0010F691 File Offset: 0x0010D891
		internal Label GetFinallyEndLabel()
		{
			return this.m_finallyEndLabel;
		}

		// Token: 0x06004AEE RID: 19182 RVA: 0x0010F69C File Offset: 0x0010D89C
		internal bool IsInner(__ExceptionInfo exc)
		{
			int num = exc.m_currentCatch - 1;
			int num2 = this.m_currentCatch - 1;
			return exc.m_catchEndAddr[num] < this.m_catchEndAddr[num2] || (exc.m_catchEndAddr[num] == this.m_catchEndAddr[num2] && exc.GetEndAddress() > this.GetEndAddress());
		}

		// Token: 0x06004AEF RID: 19183 RVA: 0x0010F6F2 File Offset: 0x0010D8F2
		internal int GetCurrentState()
		{
			return this.m_currentState;
		}

		// Token: 0x04001ED2 RID: 7890
		internal const int None = 0;

		// Token: 0x04001ED3 RID: 7891
		internal const int Filter = 1;

		// Token: 0x04001ED4 RID: 7892
		internal const int Finally = 2;

		// Token: 0x04001ED5 RID: 7893
		internal const int Fault = 4;

		// Token: 0x04001ED6 RID: 7894
		internal const int PreserveStack = 4;

		// Token: 0x04001ED7 RID: 7895
		internal const int State_Try = 0;

		// Token: 0x04001ED8 RID: 7896
		internal const int State_Filter = 1;

		// Token: 0x04001ED9 RID: 7897
		internal const int State_Catch = 2;

		// Token: 0x04001EDA RID: 7898
		internal const int State_Finally = 3;

		// Token: 0x04001EDB RID: 7899
		internal const int State_Fault = 4;

		// Token: 0x04001EDC RID: 7900
		internal const int State_Done = 5;

		// Token: 0x04001EDD RID: 7901
		internal int m_startAddr;

		// Token: 0x04001EDE RID: 7902
		internal int[] m_filterAddr;

		// Token: 0x04001EDF RID: 7903
		internal int[] m_catchAddr;

		// Token: 0x04001EE0 RID: 7904
		internal int[] m_catchEndAddr;

		// Token: 0x04001EE1 RID: 7905
		internal int[] m_type;

		// Token: 0x04001EE2 RID: 7906
		internal Type[] m_catchClass;

		// Token: 0x04001EE3 RID: 7907
		internal Label m_endLabel;

		// Token: 0x04001EE4 RID: 7908
		internal Label m_finallyEndLabel;

		// Token: 0x04001EE5 RID: 7909
		internal int m_endAddr;

		// Token: 0x04001EE6 RID: 7910
		internal int m_endFinally;

		// Token: 0x04001EE7 RID: 7911
		internal int m_currentCatch;

		// Token: 0x04001EE8 RID: 7912
		private int m_currentState;
	}
}
