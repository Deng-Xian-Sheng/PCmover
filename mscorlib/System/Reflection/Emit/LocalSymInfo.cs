using System;
using System.Diagnostics.SymbolStore;

namespace System.Reflection.Emit
{
	// Token: 0x02000646 RID: 1606
	internal class LocalSymInfo
	{
		// Token: 0x06004B67 RID: 19303 RVA: 0x0011139A File Offset: 0x0010F59A
		internal LocalSymInfo()
		{
			this.m_iLocalSymCount = 0;
			this.m_iNameSpaceCount = 0;
		}

		// Token: 0x06004B68 RID: 19304 RVA: 0x001113B0 File Offset: 0x0010F5B0
		private void EnsureCapacityNamespace()
		{
			if (this.m_iNameSpaceCount == 0)
			{
				this.m_namespace = new string[16];
				return;
			}
			if (this.m_iNameSpaceCount == this.m_namespace.Length)
			{
				string[] array = new string[checked(this.m_iNameSpaceCount * 2)];
				Array.Copy(this.m_namespace, array, this.m_iNameSpaceCount);
				this.m_namespace = array;
			}
		}

		// Token: 0x06004B69 RID: 19305 RVA: 0x0011140C File Offset: 0x0010F60C
		private void EnsureCapacity()
		{
			if (this.m_iLocalSymCount == 0)
			{
				this.m_strName = new string[16];
				this.m_ubSignature = new byte[16][];
				this.m_iLocalSlot = new int[16];
				this.m_iStartOffset = new int[16];
				this.m_iEndOffset = new int[16];
				return;
			}
			if (this.m_iLocalSymCount == this.m_strName.Length)
			{
				int num = checked(this.m_iLocalSymCount * 2);
				int[] array = new int[num];
				Array.Copy(this.m_iLocalSlot, array, this.m_iLocalSymCount);
				this.m_iLocalSlot = array;
				array = new int[num];
				Array.Copy(this.m_iStartOffset, array, this.m_iLocalSymCount);
				this.m_iStartOffset = array;
				array = new int[num];
				Array.Copy(this.m_iEndOffset, array, this.m_iLocalSymCount);
				this.m_iEndOffset = array;
				string[] array2 = new string[num];
				Array.Copy(this.m_strName, array2, this.m_iLocalSymCount);
				this.m_strName = array2;
				byte[][] array3 = new byte[num][];
				Array.Copy(this.m_ubSignature, array3, this.m_iLocalSymCount);
				this.m_ubSignature = array3;
			}
		}

		// Token: 0x06004B6A RID: 19306 RVA: 0x00111520 File Offset: 0x0010F720
		internal void AddLocalSymInfo(string strName, byte[] signature, int slot, int startOffset, int endOffset)
		{
			this.EnsureCapacity();
			this.m_iStartOffset[this.m_iLocalSymCount] = startOffset;
			this.m_iEndOffset[this.m_iLocalSymCount] = endOffset;
			this.m_iLocalSlot[this.m_iLocalSymCount] = slot;
			this.m_strName[this.m_iLocalSymCount] = strName;
			this.m_ubSignature[this.m_iLocalSymCount] = signature;
			checked
			{
				this.m_iLocalSymCount++;
			}
		}

		// Token: 0x06004B6B RID: 19307 RVA: 0x00111589 File Offset: 0x0010F789
		internal void AddUsingNamespace(string strNamespace)
		{
			this.EnsureCapacityNamespace();
			this.m_namespace[this.m_iNameSpaceCount] = strNamespace;
			checked
			{
				this.m_iNameSpaceCount++;
			}
		}

		// Token: 0x06004B6C RID: 19308 RVA: 0x001115B0 File Offset: 0x0010F7B0
		internal virtual void EmitLocalSymInfo(ISymbolWriter symWriter)
		{
			for (int i = 0; i < this.m_iLocalSymCount; i++)
			{
				symWriter.DefineLocalVariable(this.m_strName[i], FieldAttributes.PrivateScope, this.m_ubSignature[i], SymAddressKind.ILOffset, this.m_iLocalSlot[i], 0, 0, this.m_iStartOffset[i], this.m_iEndOffset[i]);
			}
			for (int i = 0; i < this.m_iNameSpaceCount; i++)
			{
				symWriter.UsingNamespace(this.m_namespace[i]);
			}
		}

		// Token: 0x04001F22 RID: 7970
		internal string[] m_strName;

		// Token: 0x04001F23 RID: 7971
		internal byte[][] m_ubSignature;

		// Token: 0x04001F24 RID: 7972
		internal int[] m_iLocalSlot;

		// Token: 0x04001F25 RID: 7973
		internal int[] m_iStartOffset;

		// Token: 0x04001F26 RID: 7974
		internal int[] m_iEndOffset;

		// Token: 0x04001F27 RID: 7975
		internal int m_iLocalSymCount;

		// Token: 0x04001F28 RID: 7976
		internal string[] m_namespace;

		// Token: 0x04001F29 RID: 7977
		internal int m_iNameSpaceCount;

		// Token: 0x04001F2A RID: 7978
		internal const int InitialSize = 16;
	}
}
