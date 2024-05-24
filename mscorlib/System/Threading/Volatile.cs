using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000531 RID: 1329
	[__DynamicallyInvokable]
	public static class Volatile
	{
		// Token: 0x06003E5E RID: 15966 RVA: 0x000E8928 File Offset: 0x000E6B28
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static bool Read(ref bool location)
		{
			bool result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E5F RID: 15967 RVA: 0x000E8940 File Offset: 0x000E6B40
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static sbyte Read(ref sbyte location)
		{
			sbyte result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E60 RID: 15968 RVA: 0x000E8958 File Offset: 0x000E6B58
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static byte Read(ref byte location)
		{
			byte result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E61 RID: 15969 RVA: 0x000E8970 File Offset: 0x000E6B70
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static short Read(ref short location)
		{
			short result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E62 RID: 15970 RVA: 0x000E8988 File Offset: 0x000E6B88
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static ushort Read(ref ushort location)
		{
			ushort result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E63 RID: 15971 RVA: 0x000E89A0 File Offset: 0x000E6BA0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static int Read(ref int location)
		{
			int result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E64 RID: 15972 RVA: 0x000E89B8 File Offset: 0x000E6BB8
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static uint Read(ref uint location)
		{
			uint result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E65 RID: 15973 RVA: 0x000E89CE File Offset: 0x000E6BCE
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static long Read(ref long location)
		{
			return Interlocked.CompareExchange(ref location, 0L, 0L);
		}

		// Token: 0x06003E66 RID: 15974 RVA: 0x000E89DC File Offset: 0x000E6BDC
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe static ulong Read(ref ulong location)
		{
			fixed (ulong* ptr = &location)
			{
				ulong* location2 = ptr;
				return (ulong)Interlocked.CompareExchange(ref *(long*)location2, 0L, 0L);
			}
		}

		// Token: 0x06003E67 RID: 15975 RVA: 0x000E89F8 File Offset: 0x000E6BF8
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr Read(ref IntPtr location)
		{
			IntPtr result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E68 RID: 15976 RVA: 0x000E8A10 File Offset: 0x000E6C10
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		public static UIntPtr Read(ref UIntPtr location)
		{
			UIntPtr result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E69 RID: 15977 RVA: 0x000E8A28 File Offset: 0x000E6C28
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static float Read(ref float location)
		{
			float result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E6A RID: 15978 RVA: 0x000E8A3E File Offset: 0x000E6C3E
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static double Read(ref double location)
		{
			return Interlocked.CompareExchange(ref location, 0.0, 0.0);
		}

		// Token: 0x06003E6B RID: 15979 RVA: 0x000E8A58 File Offset: 0x000E6C58
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static T Read<T>(ref T location) where T : class
		{
			T result = location;
			Thread.MemoryBarrier();
			return result;
		}

		// Token: 0x06003E6C RID: 15980 RVA: 0x000E8A72 File Offset: 0x000E6C72
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref bool location, bool value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E6D RID: 15981 RVA: 0x000E8A7C File Offset: 0x000E6C7C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static void Write(ref sbyte location, sbyte value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E6E RID: 15982 RVA: 0x000E8A86 File Offset: 0x000E6C86
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref byte location, byte value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E6F RID: 15983 RVA: 0x000E8A90 File Offset: 0x000E6C90
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref short location, short value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E70 RID: 15984 RVA: 0x000E8A9A File Offset: 0x000E6C9A
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static void Write(ref ushort location, ushort value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E71 RID: 15985 RVA: 0x000E8AA4 File Offset: 0x000E6CA4
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref int location, int value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E72 RID: 15986 RVA: 0x000E8AAE File Offset: 0x000E6CAE
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public static void Write(ref uint location, uint value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E73 RID: 15987 RVA: 0x000E8AB8 File Offset: 0x000E6CB8
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref long location, long value)
		{
			Interlocked.Exchange(ref location, value);
		}

		// Token: 0x06003E74 RID: 15988 RVA: 0x000E8AC4 File Offset: 0x000E6CC4
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public unsafe static void Write(ref ulong location, ulong value)
		{
			fixed (ulong* ptr = &location)
			{
				ulong* location2 = ptr;
				Interlocked.Exchange(ref *(long*)location2, (long)value);
			}
		}

		// Token: 0x06003E75 RID: 15989 RVA: 0x000E8AE1 File Offset: 0x000E6CE1
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void Write(ref IntPtr location, IntPtr value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E76 RID: 15990 RVA: 0x000E8AEB File Offset: 0x000E6CEB
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[CLSCompliant(false)]
		public static void Write(ref UIntPtr location, UIntPtr value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E77 RID: 15991 RVA: 0x000E8AF5 File Offset: 0x000E6CF5
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref float location, float value)
		{
			Thread.MemoryBarrier();
			location = value;
		}

		// Token: 0x06003E78 RID: 15992 RVA: 0x000E8AFF File Offset: 0x000E6CFF
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static void Write(ref double location, double value)
		{
			Interlocked.Exchange(ref location, value);
		}

		// Token: 0x06003E79 RID: 15993 RVA: 0x000E8B09 File Offset: 0x000E6D09
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static void Write<T>(ref T location, T value) where T : class
		{
			Thread.MemoryBarrier();
			location = value;
		}
	}
}
