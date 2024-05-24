using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection.Emit
{
	// Token: 0x0200066A RID: 1642
	[ComVisible(true)]
	[Obsolete("An alternate API is available: Emit the MarshalAs custom attribute instead. http://go.microsoft.com/fwlink/?linkid=14202")]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[Serializable]
	public sealed class UnmanagedMarshal
	{
		// Token: 0x06004F04 RID: 20228 RVA: 0x0011BFE2 File Offset: 0x0011A1E2
		public static UnmanagedMarshal DefineUnmanagedMarshal(UnmanagedType unmanagedType)
		{
			if (unmanagedType == UnmanagedType.ByValTStr || unmanagedType == UnmanagedType.SafeArray || unmanagedType == UnmanagedType.CustomMarshaler || unmanagedType == UnmanagedType.ByValArray || unmanagedType == UnmanagedType.LPArray)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_NotASimpleNativeType"));
			}
			return new UnmanagedMarshal(unmanagedType, Guid.Empty, 0, (UnmanagedType)0);
		}

		// Token: 0x06004F05 RID: 20229 RVA: 0x0011C01A File Offset: 0x0011A21A
		public static UnmanagedMarshal DefineByValTStr(int elemCount)
		{
			return new UnmanagedMarshal(UnmanagedType.ByValTStr, Guid.Empty, elemCount, (UnmanagedType)0);
		}

		// Token: 0x06004F06 RID: 20230 RVA: 0x0011C02A File Offset: 0x0011A22A
		public static UnmanagedMarshal DefineSafeArray(UnmanagedType elemType)
		{
			return new UnmanagedMarshal(UnmanagedType.SafeArray, Guid.Empty, 0, elemType);
		}

		// Token: 0x06004F07 RID: 20231 RVA: 0x0011C03A File Offset: 0x0011A23A
		public static UnmanagedMarshal DefineByValArray(int elemCount)
		{
			return new UnmanagedMarshal(UnmanagedType.ByValArray, Guid.Empty, elemCount, (UnmanagedType)0);
		}

		// Token: 0x06004F08 RID: 20232 RVA: 0x0011C04A File Offset: 0x0011A24A
		public static UnmanagedMarshal DefineLPArray(UnmanagedType elemType)
		{
			return new UnmanagedMarshal(UnmanagedType.LPArray, Guid.Empty, 0, elemType);
		}

		// Token: 0x17000C92 RID: 3218
		// (get) Token: 0x06004F09 RID: 20233 RVA: 0x0011C05A File Offset: 0x0011A25A
		public UnmanagedType GetUnmanagedType
		{
			get
			{
				return this.m_unmanagedType;
			}
		}

		// Token: 0x17000C93 RID: 3219
		// (get) Token: 0x06004F0A RID: 20234 RVA: 0x0011C062 File Offset: 0x0011A262
		public Guid IIDGuid
		{
			get
			{
				if (this.m_unmanagedType == UnmanagedType.CustomMarshaler)
				{
					return this.m_guid;
				}
				throw new ArgumentException(Environment.GetResourceString("Argument_NotACustomMarshaler"));
			}
		}

		// Token: 0x17000C94 RID: 3220
		// (get) Token: 0x06004F0B RID: 20235 RVA: 0x0011C084 File Offset: 0x0011A284
		public int ElementCount
		{
			get
			{
				if (this.m_unmanagedType != UnmanagedType.ByValArray && this.m_unmanagedType != UnmanagedType.ByValTStr)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NoUnmanagedElementCount"));
				}
				return this.m_numElem;
			}
		}

		// Token: 0x17000C95 RID: 3221
		// (get) Token: 0x06004F0C RID: 20236 RVA: 0x0011C0B0 File Offset: 0x0011A2B0
		public UnmanagedType BaseType
		{
			get
			{
				if (this.m_unmanagedType != UnmanagedType.LPArray && this.m_unmanagedType != UnmanagedType.SafeArray)
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_NoNestedMarshal"));
				}
				return this.m_baseType;
			}
		}

		// Token: 0x06004F0D RID: 20237 RVA: 0x0011C0DC File Offset: 0x0011A2DC
		private UnmanagedMarshal(UnmanagedType unmanagedType, Guid guid, int numElem, UnmanagedType type)
		{
			this.m_unmanagedType = unmanagedType;
			this.m_guid = guid;
			this.m_numElem = numElem;
			this.m_baseType = type;
		}

		// Token: 0x06004F0E RID: 20238 RVA: 0x0011C104 File Offset: 0x0011A304
		internal byte[] InternalGetBytes()
		{
			if (this.m_unmanagedType == UnmanagedType.SafeArray || this.m_unmanagedType == UnmanagedType.LPArray)
			{
				int num = 2;
				byte[] array = new byte[num];
				array[0] = (byte)this.m_unmanagedType;
				array[1] = (byte)this.m_baseType;
				return array;
			}
			if (this.m_unmanagedType == UnmanagedType.ByValArray || this.m_unmanagedType == UnmanagedType.ByValTStr)
			{
				int num2 = 0;
				int num3;
				if (this.m_numElem <= 127)
				{
					num3 = 1;
				}
				else if (this.m_numElem <= 16383)
				{
					num3 = 2;
				}
				else
				{
					num3 = 4;
				}
				num3++;
				byte[] array = new byte[num3];
				array[num2++] = (byte)this.m_unmanagedType;
				if (this.m_numElem <= 127)
				{
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				else if (this.m_numElem <= 16383)
				{
					array[num2++] = (byte)(this.m_numElem >> 8 | 128);
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				else if (this.m_numElem <= 536870911)
				{
					array[num2++] = (byte)(this.m_numElem >> 24 | 192);
					array[num2++] = (byte)(this.m_numElem >> 16 & 255);
					array[num2++] = (byte)(this.m_numElem >> 8 & 255);
					array[num2++] = (byte)(this.m_numElem & 255);
				}
				return array;
			}
			return new byte[]
			{
				(byte)this.m_unmanagedType
			};
		}

		// Token: 0x040021D4 RID: 8660
		internal UnmanagedType m_unmanagedType;

		// Token: 0x040021D5 RID: 8661
		internal Guid m_guid;

		// Token: 0x040021D6 RID: 8662
		internal int m_numElem;

		// Token: 0x040021D7 RID: 8663
		internal UnmanagedType m_baseType;
	}
}
