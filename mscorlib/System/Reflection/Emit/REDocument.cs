using System;
using System.Diagnostics.SymbolStore;

namespace System.Reflection.Emit
{
	// Token: 0x02000642 RID: 1602
	internal sealed class REDocument
	{
		// Token: 0x06004AFC RID: 19196 RVA: 0x0010FAE4 File Offset: 0x0010DCE4
		internal REDocument(ISymbolDocumentWriter document)
		{
			this.m_iLineNumberCount = 0;
			this.m_document = document;
		}

		// Token: 0x06004AFD RID: 19197 RVA: 0x0010FAFC File Offset: 0x0010DCFC
		internal void AddLineNumberInfo(ISymbolDocumentWriter document, int iOffset, int iStartLine, int iStartColumn, int iEndLine, int iEndColumn)
		{
			this.EnsureCapacity();
			this.m_iOffsets[this.m_iLineNumberCount] = iOffset;
			this.m_iLines[this.m_iLineNumberCount] = iStartLine;
			this.m_iColumns[this.m_iLineNumberCount] = iStartColumn;
			this.m_iEndLines[this.m_iLineNumberCount] = iEndLine;
			this.m_iEndColumns[this.m_iLineNumberCount] = iEndColumn;
			checked
			{
				this.m_iLineNumberCount++;
			}
		}

		// Token: 0x06004AFE RID: 19198 RVA: 0x0010FB68 File Offset: 0x0010DD68
		private void EnsureCapacity()
		{
			if (this.m_iLineNumberCount == 0)
			{
				this.m_iOffsets = new int[16];
				this.m_iLines = new int[16];
				this.m_iColumns = new int[16];
				this.m_iEndLines = new int[16];
				this.m_iEndColumns = new int[16];
				return;
			}
			if (this.m_iLineNumberCount == this.m_iOffsets.Length)
			{
				int num = checked(this.m_iLineNumberCount * 2);
				int[] array = new int[num];
				Array.Copy(this.m_iOffsets, array, this.m_iLineNumberCount);
				this.m_iOffsets = array;
				array = new int[num];
				Array.Copy(this.m_iLines, array, this.m_iLineNumberCount);
				this.m_iLines = array;
				array = new int[num];
				Array.Copy(this.m_iColumns, array, this.m_iLineNumberCount);
				this.m_iColumns = array;
				array = new int[num];
				Array.Copy(this.m_iEndLines, array, this.m_iLineNumberCount);
				this.m_iEndLines = array;
				array = new int[num];
				Array.Copy(this.m_iEndColumns, array, this.m_iLineNumberCount);
				this.m_iEndColumns = array;
			}
		}

		// Token: 0x06004AFF RID: 19199 RVA: 0x0010FC7C File Offset: 0x0010DE7C
		internal void EmitLineNumberInfo(ISymbolWriter symWriter)
		{
			if (this.m_iLineNumberCount == 0)
			{
				return;
			}
			int[] array = new int[this.m_iLineNumberCount];
			Array.Copy(this.m_iOffsets, array, this.m_iLineNumberCount);
			int[] array2 = new int[this.m_iLineNumberCount];
			Array.Copy(this.m_iLines, array2, this.m_iLineNumberCount);
			int[] array3 = new int[this.m_iLineNumberCount];
			Array.Copy(this.m_iColumns, array3, this.m_iLineNumberCount);
			int[] array4 = new int[this.m_iLineNumberCount];
			Array.Copy(this.m_iEndLines, array4, this.m_iLineNumberCount);
			int[] array5 = new int[this.m_iLineNumberCount];
			Array.Copy(this.m_iEndColumns, array5, this.m_iLineNumberCount);
			symWriter.DefineSequencePoints(this.m_document, array, array2, array3, array4, array5);
		}

		// Token: 0x04001EF6 RID: 7926
		private int[] m_iOffsets;

		// Token: 0x04001EF7 RID: 7927
		private int[] m_iLines;

		// Token: 0x04001EF8 RID: 7928
		private int[] m_iColumns;

		// Token: 0x04001EF9 RID: 7929
		private int[] m_iEndLines;

		// Token: 0x04001EFA RID: 7930
		private int[] m_iEndColumns;

		// Token: 0x04001EFB RID: 7931
		internal ISymbolDocumentWriter m_document;

		// Token: 0x04001EFC RID: 7932
		private int m_iLineNumberCount;

		// Token: 0x04001EFD RID: 7933
		private const int InitialSize = 16;
	}
}
