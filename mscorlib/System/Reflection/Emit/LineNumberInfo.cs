using System;
using System.Diagnostics.SymbolStore;

namespace System.Reflection.Emit
{
	// Token: 0x02000641 RID: 1601
	internal sealed class LineNumberInfo
	{
		// Token: 0x06004AF7 RID: 19191 RVA: 0x0010F977 File Offset: 0x0010DB77
		internal LineNumberInfo()
		{
			this.m_DocumentCount = 0;
			this.m_iLastFound = 0;
		}

		// Token: 0x06004AF8 RID: 19192 RVA: 0x0010F990 File Offset: 0x0010DB90
		internal void AddLineNumberInfo(ISymbolDocumentWriter document, int iOffset, int iStartLine, int iStartColumn, int iEndLine, int iEndColumn)
		{
			int num = this.FindDocument(document);
			this.m_Documents[num].AddLineNumberInfo(document, iOffset, iStartLine, iStartColumn, iEndLine, iEndColumn);
		}

		// Token: 0x06004AF9 RID: 19193 RVA: 0x0010F9BC File Offset: 0x0010DBBC
		private int FindDocument(ISymbolDocumentWriter document)
		{
			if (this.m_iLastFound < this.m_DocumentCount && this.m_Documents[this.m_iLastFound].m_document == document)
			{
				return this.m_iLastFound;
			}
			for (int i = 0; i < this.m_DocumentCount; i++)
			{
				if (this.m_Documents[i].m_document == document)
				{
					this.m_iLastFound = i;
					return this.m_iLastFound;
				}
			}
			this.EnsureCapacity();
			this.m_iLastFound = this.m_DocumentCount;
			this.m_Documents[this.m_iLastFound] = new REDocument(document);
			checked
			{
				this.m_DocumentCount++;
				return this.m_iLastFound;
			}
		}

		// Token: 0x06004AFA RID: 19194 RVA: 0x0010FA5C File Offset: 0x0010DC5C
		private void EnsureCapacity()
		{
			if (this.m_DocumentCount == 0)
			{
				this.m_Documents = new REDocument[16];
				return;
			}
			if (this.m_DocumentCount == this.m_Documents.Length)
			{
				REDocument[] array = new REDocument[this.m_DocumentCount * 2];
				Array.Copy(this.m_Documents, array, this.m_DocumentCount);
				this.m_Documents = array;
			}
		}

		// Token: 0x06004AFB RID: 19195 RVA: 0x0010FAB8 File Offset: 0x0010DCB8
		internal void EmitLineNumberInfo(ISymbolWriter symWriter)
		{
			for (int i = 0; i < this.m_DocumentCount; i++)
			{
				this.m_Documents[i].EmitLineNumberInfo(symWriter);
			}
		}

		// Token: 0x04001EF2 RID: 7922
		private int m_DocumentCount;

		// Token: 0x04001EF3 RID: 7923
		private REDocument[] m_Documents;

		// Token: 0x04001EF4 RID: 7924
		private const int InitialSize = 16;

		// Token: 0x04001EF5 RID: 7925
		private int m_iLastFound;
	}
}
