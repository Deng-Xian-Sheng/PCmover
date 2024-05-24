using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200090D RID: 2317
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public struct ArrayWithOffset
	{
		// Token: 0x06005FDF RID: 24543 RVA: 0x0014B470 File Offset: 0x00149670
		[SecuritySafeCritical]
		[__DynamicallyInvokable]
		public ArrayWithOffset(object array, int offset)
		{
			this.m_array = array;
			this.m_offset = offset;
			this.m_count = 0;
			this.m_count = this.CalculateCount();
		}

		// Token: 0x06005FE0 RID: 24544 RVA: 0x0014B493 File Offset: 0x00149693
		[__DynamicallyInvokable]
		public object GetArray()
		{
			return this.m_array;
		}

		// Token: 0x06005FE1 RID: 24545 RVA: 0x0014B49B File Offset: 0x0014969B
		[__DynamicallyInvokable]
		public int GetOffset()
		{
			return this.m_offset;
		}

		// Token: 0x06005FE2 RID: 24546 RVA: 0x0014B4A3 File Offset: 0x001496A3
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_count + this.m_offset;
		}

		// Token: 0x06005FE3 RID: 24547 RVA: 0x0014B4B2 File Offset: 0x001496B2
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is ArrayWithOffset && this.Equals((ArrayWithOffset)obj);
		}

		// Token: 0x06005FE4 RID: 24548 RVA: 0x0014B4CA File Offset: 0x001496CA
		[__DynamicallyInvokable]
		public bool Equals(ArrayWithOffset obj)
		{
			return obj.m_array == this.m_array && obj.m_offset == this.m_offset && obj.m_count == this.m_count;
		}

		// Token: 0x06005FE5 RID: 24549 RVA: 0x0014B4F8 File Offset: 0x001496F8
		[__DynamicallyInvokable]
		public static bool operator ==(ArrayWithOffset a, ArrayWithOffset b)
		{
			return a.Equals(b);
		}

		// Token: 0x06005FE6 RID: 24550 RVA: 0x0014B502 File Offset: 0x00149702
		[__DynamicallyInvokable]
		public static bool operator !=(ArrayWithOffset a, ArrayWithOffset b)
		{
			return !(a == b);
		}

		// Token: 0x06005FE7 RID: 24551
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int CalculateCount();

		// Token: 0x04002A53 RID: 10835
		private object m_array;

		// Token: 0x04002A54 RID: 10836
		private int m_offset;

		// Token: 0x04002A55 RID: 10837
		private int m_count;
	}
}
