using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Reflection.Emit
{
	// Token: 0x02000655 RID: 1621
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public struct OpCode
	{
		// Token: 0x06004CA0 RID: 19616 RVA: 0x00116A8C File Offset: 0x00114C8C
		internal OpCode(OpCodeValues value, int flags)
		{
			this.m_stringname = null;
			this.m_pop = (StackBehaviour)(flags >> 12 & 31);
			this.m_push = (StackBehaviour)(flags >> 17 & 31);
			this.m_operand = (OperandType)(flags & 31);
			this.m_type = (OpCodeType)(flags >> 9 & 7);
			this.m_size = (flags >> 22 & 3);
			this.m_s1 = (byte)(value >> 8);
			this.m_s2 = (byte)value;
			this.m_ctrl = (FlowControl)(flags >> 5 & 15);
			this.m_endsUncondJmpBlk = ((flags & 16777216) != 0);
			this.m_stackChange = flags >> 28;
		}

		// Token: 0x06004CA1 RID: 19617 RVA: 0x00116B14 File Offset: 0x00114D14
		internal bool EndsUncondJmpBlk()
		{
			return this.m_endsUncondJmpBlk;
		}

		// Token: 0x06004CA2 RID: 19618 RVA: 0x00116B1C File Offset: 0x00114D1C
		internal int StackChange()
		{
			return this.m_stackChange;
		}

		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x06004CA3 RID: 19619 RVA: 0x00116B24 File Offset: 0x00114D24
		[__DynamicallyInvokable]
		public OperandType OperandType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_operand;
			}
		}

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x06004CA4 RID: 19620 RVA: 0x00116B2C File Offset: 0x00114D2C
		[__DynamicallyInvokable]
		public FlowControl FlowControl
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_ctrl;
			}
		}

		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x06004CA5 RID: 19621 RVA: 0x00116B34 File Offset: 0x00114D34
		[__DynamicallyInvokable]
		public OpCodeType OpCodeType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x06004CA6 RID: 19622 RVA: 0x00116B3C File Offset: 0x00114D3C
		[__DynamicallyInvokable]
		public StackBehaviour StackBehaviourPop
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_pop;
			}
		}

		// Token: 0x17000BFE RID: 3070
		// (get) Token: 0x06004CA7 RID: 19623 RVA: 0x00116B44 File Offset: 0x00114D44
		[__DynamicallyInvokable]
		public StackBehaviour StackBehaviourPush
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_push;
			}
		}

		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x06004CA8 RID: 19624 RVA: 0x00116B4C File Offset: 0x00114D4C
		[__DynamicallyInvokable]
		public int Size
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_size;
			}
		}

		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x06004CA9 RID: 19625 RVA: 0x00116B54 File Offset: 0x00114D54
		[__DynamicallyInvokable]
		public short Value
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.m_size == 2)
				{
					return (short)((int)this.m_s1 << 8 | (int)this.m_s2);
				}
				return (short)this.m_s2;
			}
		}

		// Token: 0x17000C01 RID: 3073
		// (get) Token: 0x06004CAA RID: 19626 RVA: 0x00116B78 File Offset: 0x00114D78
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.Size == 0)
				{
					return null;
				}
				string[] array = OpCode.g_nameCache;
				if (array == null)
				{
					array = new string[287];
					OpCode.g_nameCache = array;
				}
				OpCodeValues opCodeValues = (OpCodeValues)((ushort)this.Value);
				int num = (int)opCodeValues;
				if (num > 255)
				{
					if (num < 65024 || num > 65054)
					{
						return null;
					}
					num = 256 + (num - 65024);
				}
				string text = Volatile.Read<string>(ref array[num]);
				if (text != null)
				{
					return text;
				}
				text = Enum.GetName(typeof(OpCodeValues), opCodeValues).ToLowerInvariant().Replace("_", ".");
				Volatile.Write<string>(ref array[num], text);
				return text;
			}
		}

		// Token: 0x06004CAB RID: 19627 RVA: 0x00116C2B File Offset: 0x00114E2B
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is OpCode && this.Equals((OpCode)obj);
		}

		// Token: 0x06004CAC RID: 19628 RVA: 0x00116C43 File Offset: 0x00114E43
		[__DynamicallyInvokable]
		public bool Equals(OpCode obj)
		{
			return obj.Value == this.Value;
		}

		// Token: 0x06004CAD RID: 19629 RVA: 0x00116C54 File Offset: 0x00114E54
		[__DynamicallyInvokable]
		public static bool operator ==(OpCode a, OpCode b)
		{
			return a.Equals(b);
		}

		// Token: 0x06004CAE RID: 19630 RVA: 0x00116C5E File Offset: 0x00114E5E
		[__DynamicallyInvokable]
		public static bool operator !=(OpCode a, OpCode b)
		{
			return !(a == b);
		}

		// Token: 0x06004CAF RID: 19631 RVA: 0x00116C6A File Offset: 0x00114E6A
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return (int)this.Value;
		}

		// Token: 0x06004CB0 RID: 19632 RVA: 0x00116C72 File Offset: 0x00114E72
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04002129 RID: 8489
		internal const int OperandTypeMask = 31;

		// Token: 0x0400212A RID: 8490
		internal const int FlowControlShift = 5;

		// Token: 0x0400212B RID: 8491
		internal const int FlowControlMask = 15;

		// Token: 0x0400212C RID: 8492
		internal const int OpCodeTypeShift = 9;

		// Token: 0x0400212D RID: 8493
		internal const int OpCodeTypeMask = 7;

		// Token: 0x0400212E RID: 8494
		internal const int StackBehaviourPopShift = 12;

		// Token: 0x0400212F RID: 8495
		internal const int StackBehaviourPushShift = 17;

		// Token: 0x04002130 RID: 8496
		internal const int StackBehaviourMask = 31;

		// Token: 0x04002131 RID: 8497
		internal const int SizeShift = 22;

		// Token: 0x04002132 RID: 8498
		internal const int SizeMask = 3;

		// Token: 0x04002133 RID: 8499
		internal const int EndsUncondJmpBlkFlag = 16777216;

		// Token: 0x04002134 RID: 8500
		internal const int StackChangeShift = 28;

		// Token: 0x04002135 RID: 8501
		private string m_stringname;

		// Token: 0x04002136 RID: 8502
		private StackBehaviour m_pop;

		// Token: 0x04002137 RID: 8503
		private StackBehaviour m_push;

		// Token: 0x04002138 RID: 8504
		private OperandType m_operand;

		// Token: 0x04002139 RID: 8505
		private OpCodeType m_type;

		// Token: 0x0400213A RID: 8506
		private int m_size;

		// Token: 0x0400213B RID: 8507
		private byte m_s1;

		// Token: 0x0400213C RID: 8508
		private byte m_s2;

		// Token: 0x0400213D RID: 8509
		private FlowControl m_ctrl;

		// Token: 0x0400213E RID: 8510
		private bool m_endsUncondJmpBlk;

		// Token: 0x0400213F RID: 8511
		private int m_stackChange;

		// Token: 0x04002140 RID: 8512
		private static volatile string[] g_nameCache;
	}
}
