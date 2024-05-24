using System;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004F8 RID: 1272
	[__DynamicallyInvokable]
	public static class Interlocked
	{
		// Token: 0x06003C1A RID: 15386 RVA: 0x000E3E03 File Offset: 0x000E2003
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static int Increment(ref int location)
		{
			return Interlocked.Add(ref location, 1);
		}

		// Token: 0x06003C1B RID: 15387 RVA: 0x000E3E0C File Offset: 0x000E200C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static long Increment(ref long location)
		{
			return Interlocked.Add(ref location, 1L);
		}

		// Token: 0x06003C1C RID: 15388 RVA: 0x000E3E16 File Offset: 0x000E2016
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static int Decrement(ref int location)
		{
			return Interlocked.Add(ref location, -1);
		}

		// Token: 0x06003C1D RID: 15389 RVA: 0x000E3E1F File Offset: 0x000E201F
		[__DynamicallyInvokable]
		public static long Decrement(ref long location)
		{
			return Interlocked.Add(ref location, -1L);
		}

		// Token: 0x06003C1E RID: 15390
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int Exchange(ref int location1, int value);

		// Token: 0x06003C1F RID: 15391
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long Exchange(ref long location1, long value);

		// Token: 0x06003C20 RID: 15392
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float Exchange(ref float location1, float value);

		// Token: 0x06003C21 RID: 15393
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double Exchange(ref double location1, double value);

		// Token: 0x06003C22 RID: 15394
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object Exchange(ref object location1, object value);

		// Token: 0x06003C23 RID: 15395
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr Exchange(ref IntPtr location1, IntPtr value);

		// Token: 0x06003C24 RID: 15396 RVA: 0x000E3E29 File Offset: 0x000E2029
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[ComVisible(false)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static T Exchange<T>(ref T location1, T value) where T : class
		{
			Interlocked._Exchange(__makeref(location1), __makeref(value));
			return value;
		}

		// Token: 0x06003C25 RID: 15397
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _Exchange(TypedReference location1, TypedReference value);

		// Token: 0x06003C26 RID: 15398
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern int CompareExchange(ref int location1, int value, int comparand);

		// Token: 0x06003C27 RID: 15399
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern long CompareExchange(ref long location1, long value, long comparand);

		// Token: 0x06003C28 RID: 15400
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float CompareExchange(ref float location1, float value, float comparand);

		// Token: 0x06003C29 RID: 15401
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern double CompareExchange(ref double location1, double value, double comparand);

		// Token: 0x06003C2A RID: 15402
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern object CompareExchange(ref object location1, object value, object comparand);

		// Token: 0x06003C2B RID: 15403
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr CompareExchange(ref IntPtr location1, IntPtr value, IntPtr comparand);

		// Token: 0x06003C2C RID: 15404 RVA: 0x000E3E3E File Offset: 0x000E203E
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[ComVisible(false)]
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public static T CompareExchange<T>(ref T location1, T value, T comparand) where T : class
		{
			Interlocked._CompareExchange(__makeref(location1), __makeref(value), comparand);
			return value;
		}

		// Token: 0x06003C2D RID: 15405
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void _CompareExchange(TypedReference location1, TypedReference value, object comparand);

		// Token: 0x06003C2E RID: 15406
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int CompareExchange(ref int location1, int value, int comparand, ref bool succeeded);

		// Token: 0x06003C2F RID: 15407
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int ExchangeAdd(ref int location1, int value);

		// Token: 0x06003C30 RID: 15408
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern long ExchangeAdd(ref long location1, long value);

		// Token: 0x06003C31 RID: 15409 RVA: 0x000E3E59 File Offset: 0x000E2059
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static int Add(ref int location1, int value)
		{
			return Interlocked.ExchangeAdd(ref location1, value) + value;
		}

		// Token: 0x06003C32 RID: 15410 RVA: 0x000E3E64 File Offset: 0x000E2064
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[__DynamicallyInvokable]
		public static long Add(ref long location1, long value)
		{
			return Interlocked.ExchangeAdd(ref location1, value) + value;
		}

		// Token: 0x06003C33 RID: 15411 RVA: 0x000E3E6F File Offset: 0x000E206F
		[__DynamicallyInvokable]
		public static long Read(ref long location)
		{
			return Interlocked.CompareExchange(ref location, 0L, 0L);
		}

		// Token: 0x06003C34 RID: 15412 RVA: 0x000E3E7B File Offset: 0x000E207B
		[__DynamicallyInvokable]
		public static void MemoryBarrier()
		{
			Thread.MemoryBarrier();
		}

		// Token: 0x06003C35 RID: 15413
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SpeculationBarrier();
	}
}
