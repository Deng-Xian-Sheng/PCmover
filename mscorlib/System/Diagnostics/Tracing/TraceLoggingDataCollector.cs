using System;
using System.Security;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000480 RID: 1152
	[SecuritySafeCritical]
	internal class TraceLoggingDataCollector
	{
		// Token: 0x0600370E RID: 14094 RVA: 0x000D4680 File Offset: 0x000D2880
		private TraceLoggingDataCollector()
		{
		}

		// Token: 0x0600370F RID: 14095 RVA: 0x000D4688 File Offset: 0x000D2888
		public int BeginBufferedArray()
		{
			return DataCollector.ThreadInstance.BeginBufferedArray();
		}

		// Token: 0x06003710 RID: 14096 RVA: 0x000D4694 File Offset: 0x000D2894
		public void EndBufferedArray(int bookmark, int count)
		{
			DataCollector.ThreadInstance.EndBufferedArray(bookmark, count);
		}

		// Token: 0x06003711 RID: 14097 RVA: 0x000D46A2 File Offset: 0x000D28A2
		public TraceLoggingDataCollector AddGroup()
		{
			return this;
		}

		// Token: 0x06003712 RID: 14098 RVA: 0x000D46A5 File Offset: 0x000D28A5
		public unsafe void AddScalar(bool value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 1);
		}

		// Token: 0x06003713 RID: 14099 RVA: 0x000D46B5 File Offset: 0x000D28B5
		public unsafe void AddScalar(sbyte value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 1);
		}

		// Token: 0x06003714 RID: 14100 RVA: 0x000D46C5 File Offset: 0x000D28C5
		public unsafe void AddScalar(byte value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 1);
		}

		// Token: 0x06003715 RID: 14101 RVA: 0x000D46D5 File Offset: 0x000D28D5
		public unsafe void AddScalar(short value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 2);
		}

		// Token: 0x06003716 RID: 14102 RVA: 0x000D46E5 File Offset: 0x000D28E5
		public unsafe void AddScalar(ushort value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 2);
		}

		// Token: 0x06003717 RID: 14103 RVA: 0x000D46F5 File Offset: 0x000D28F5
		public unsafe void AddScalar(int value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 4);
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x000D4705 File Offset: 0x000D2905
		public unsafe void AddScalar(uint value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 4);
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x000D4715 File Offset: 0x000D2915
		public unsafe void AddScalar(long value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 8);
		}

		// Token: 0x0600371A RID: 14106 RVA: 0x000D4725 File Offset: 0x000D2925
		public unsafe void AddScalar(ulong value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 8);
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x000D4735 File Offset: 0x000D2935
		public unsafe void AddScalar(IntPtr value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), IntPtr.Size);
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x000D4749 File Offset: 0x000D2949
		public unsafe void AddScalar(UIntPtr value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), UIntPtr.Size);
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x000D475D File Offset: 0x000D295D
		public unsafe void AddScalar(float value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 4);
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x000D476D File Offset: 0x000D296D
		public unsafe void AddScalar(double value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 8);
		}

		// Token: 0x0600371F RID: 14111 RVA: 0x000D477D File Offset: 0x000D297D
		public unsafe void AddScalar(char value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 2);
		}

		// Token: 0x06003720 RID: 14112 RVA: 0x000D478D File Offset: 0x000D298D
		public unsafe void AddScalar(Guid value)
		{
			DataCollector.ThreadInstance.AddScalar((void*)(&value), 16);
		}

		// Token: 0x06003721 RID: 14113 RVA: 0x000D479E File Offset: 0x000D299E
		public void AddBinary(string value)
		{
			DataCollector.ThreadInstance.AddBinary(value, (value == null) ? 0 : (value.Length * 2));
		}

		// Token: 0x06003722 RID: 14114 RVA: 0x000D47B9 File Offset: 0x000D29B9
		public void AddBinary(byte[] value)
		{
			DataCollector.ThreadInstance.AddBinary(value, (value == null) ? 0 : value.Length);
		}

		// Token: 0x06003723 RID: 14115 RVA: 0x000D47CF File Offset: 0x000D29CF
		public void AddArray(bool[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 1);
		}

		// Token: 0x06003724 RID: 14116 RVA: 0x000D47E6 File Offset: 0x000D29E6
		public void AddArray(sbyte[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 1);
		}

		// Token: 0x06003725 RID: 14117 RVA: 0x000D47FD File Offset: 0x000D29FD
		public void AddArray(short[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 2);
		}

		// Token: 0x06003726 RID: 14118 RVA: 0x000D4814 File Offset: 0x000D2A14
		public void AddArray(ushort[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 2);
		}

		// Token: 0x06003727 RID: 14119 RVA: 0x000D482B File Offset: 0x000D2A2B
		public void AddArray(int[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 4);
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x000D4842 File Offset: 0x000D2A42
		public void AddArray(uint[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 4);
		}

		// Token: 0x06003729 RID: 14121 RVA: 0x000D4859 File Offset: 0x000D2A59
		public void AddArray(long[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 8);
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x000D4870 File Offset: 0x000D2A70
		public void AddArray(ulong[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 8);
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x000D4887 File Offset: 0x000D2A87
		public void AddArray(IntPtr[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, IntPtr.Size);
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x000D48A2 File Offset: 0x000D2AA2
		public void AddArray(UIntPtr[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, UIntPtr.Size);
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x000D48BD File Offset: 0x000D2ABD
		public void AddArray(float[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 4);
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x000D48D4 File Offset: 0x000D2AD4
		public void AddArray(double[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 8);
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x000D48EB File Offset: 0x000D2AEB
		public void AddArray(char[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 2);
		}

		// Token: 0x06003730 RID: 14128 RVA: 0x000D4902 File Offset: 0x000D2B02
		public void AddArray(Guid[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 16);
		}

		// Token: 0x06003731 RID: 14129 RVA: 0x000D491A File Offset: 0x000D2B1A
		public void AddCustom(byte[] value)
		{
			DataCollector.ThreadInstance.AddArray(value, (value == null) ? 0 : value.Length, 1);
		}

		// Token: 0x04001866 RID: 6246
		internal static readonly TraceLoggingDataCollector Instance = new TraceLoggingDataCollector();
	}
}
