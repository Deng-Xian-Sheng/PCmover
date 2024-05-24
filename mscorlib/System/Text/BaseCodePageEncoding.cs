using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.Text
{
	// Token: 0x02000A5A RID: 2650
	[Serializable]
	internal abstract class BaseCodePageEncoding : EncodingNLS, ISerializable
	{
		// Token: 0x0600674A RID: 26442 RVA: 0x0015CE71 File Offset: 0x0015B071
		[SecurityCritical]
		internal BaseCodePageEncoding(int codepage) : this(codepage, codepage)
		{
		}

		// Token: 0x0600674B RID: 26443 RVA: 0x0015CE7B File Offset: 0x0015B07B
		[SecurityCritical]
		internal BaseCodePageEncoding(int codepage, int dataCodePage)
		{
			this.bFlagDataTable = true;
			this.pCodePage = null;
			base..ctor((codepage == 0) ? Win32Native.GetACP() : codepage);
			this.dataTableCodePage = dataCodePage;
			this.LoadCodePageTables();
		}

		// Token: 0x0600674C RID: 26444 RVA: 0x0015CEAA File Offset: 0x0015B0AA
		[SecurityCritical]
		internal BaseCodePageEncoding(SerializationInfo info, StreamingContext context)
		{
			this.bFlagDataTable = true;
			this.pCodePage = null;
			base..ctor(0);
			throw new ArgumentNullException("this");
		}

		// Token: 0x0600674D RID: 26445 RVA: 0x0015CECC File Offset: 0x0015B0CC
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.SerializeEncoding(info, context);
			info.AddValue(this.m_bUseMlangTypeForSerialization ? "m_maxByteSize" : "maxCharSize", this.IsSingleByte ? 1 : 2);
			info.SetType(this.m_bUseMlangTypeForSerialization ? typeof(MLangCodePageEncoding) : typeof(CodePageEncoding));
		}

		// Token: 0x0600674E RID: 26446 RVA: 0x0015CF2C File Offset: 0x0015B12C
		[SecurityCritical]
		private unsafe void LoadCodePageTables()
		{
			BaseCodePageEncoding.CodePageHeader* ptr = BaseCodePageEncoding.FindCodePage(this.dataTableCodePage);
			if (ptr == null)
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_NoCodepageData", new object[]
				{
					this.CodePage
				}));
			}
			this.pCodePage = ptr;
			this.LoadManagedCodePage();
		}

		// Token: 0x0600674F RID: 26447 RVA: 0x0015CF7C File Offset: 0x0015B17C
		[SecurityCritical]
		private unsafe static BaseCodePageEncoding.CodePageHeader* FindCodePage(int codePage)
		{
			for (int i = 0; i < (int)BaseCodePageEncoding.m_pCodePageFileHeader->CodePageCount; i++)
			{
				BaseCodePageEncoding.CodePageIndex* ptr = &BaseCodePageEncoding.m_pCodePageFileHeader->CodePages + i;
				if ((int)ptr->CodePage == codePage)
				{
					return (BaseCodePageEncoding.CodePageHeader*)(BaseCodePageEncoding.m_pCodePageFileHeader + ptr->Offset / sizeof(BaseCodePageEncoding.CodePageDataFileHeader));
				}
			}
			return null;
		}

		// Token: 0x06006750 RID: 26448 RVA: 0x0015CFD0 File Offset: 0x0015B1D0
		[SecurityCritical]
		internal unsafe static int GetCodePageByteSize(int codePage)
		{
			BaseCodePageEncoding.CodePageHeader* ptr = BaseCodePageEncoding.FindCodePage(codePage);
			if (ptr == null)
			{
				return 0;
			}
			return (int)ptr->ByteCount;
		}

		// Token: 0x06006751 RID: 26449
		[SecurityCritical]
		protected abstract void LoadManagedCodePage();

		// Token: 0x06006752 RID: 26450 RVA: 0x0015CFF4 File Offset: 0x0015B1F4
		[SecurityCritical]
		protected unsafe byte* GetSharedMemory(int iSize)
		{
			string memorySectionName = this.GetMemorySectionName();
			IntPtr intPtr;
			byte* ptr = EncodingTable.nativeCreateOpenFileMapping(memorySectionName, iSize, out intPtr);
			if (ptr == null)
			{
				throw new OutOfMemoryException(Environment.GetResourceString("Arg_OutOfMemoryException"));
			}
			if (intPtr != IntPtr.Zero)
			{
				this.safeMemorySectionHandle = new SafeViewOfFileHandle((IntPtr)((void*)ptr), true);
				this.safeFileMappingHandle = new SafeFileMappingHandle(intPtr, true);
			}
			return ptr;
		}

		// Token: 0x06006753 RID: 26451 RVA: 0x0015D054 File Offset: 0x0015B254
		[SecurityCritical]
		protected unsafe virtual string GetMemorySectionName()
		{
			int num = this.bFlagDataTable ? this.dataTableCodePage : this.CodePage;
			return string.Format(CultureInfo.InvariantCulture, "NLS_CodePage_{0}_{1}_{2}_{3}_{4}", new object[]
			{
				num,
				this.pCodePage->VersionMajor,
				this.pCodePage->VersionMinor,
				this.pCodePage->VersionRevision,
				this.pCodePage->VersionBuild
			});
		}

		// Token: 0x06006754 RID: 26452
		[SecurityCritical]
		protected abstract void ReadBestFitTable();

		// Token: 0x06006755 RID: 26453 RVA: 0x0015D0E4 File Offset: 0x0015B2E4
		[SecuritySafeCritical]
		internal override char[] GetBestFitUnicodeToBytesData()
		{
			if (this.arrayUnicodeBestFit == null)
			{
				this.ReadBestFitTable();
			}
			return this.arrayUnicodeBestFit;
		}

		// Token: 0x06006756 RID: 26454 RVA: 0x0015D0FA File Offset: 0x0015B2FA
		[SecuritySafeCritical]
		internal override char[] GetBestFitBytesToUnicodeData()
		{
			if (this.arrayBytesBestFit == null)
			{
				this.ReadBestFitTable();
			}
			return this.arrayBytesBestFit;
		}

		// Token: 0x06006757 RID: 26455 RVA: 0x0015D110 File Offset: 0x0015B310
		[SecurityCritical]
		internal void CheckMemorySection()
		{
			if (this.safeMemorySectionHandle != null && this.safeMemorySectionHandle.DangerousGetHandle() == IntPtr.Zero)
			{
				this.LoadManagedCodePage();
			}
		}

		// Token: 0x04002E22 RID: 11810
		internal const string CODE_PAGE_DATA_FILE_NAME = "codepages.nlp";

		// Token: 0x04002E23 RID: 11811
		[NonSerialized]
		protected int dataTableCodePage;

		// Token: 0x04002E24 RID: 11812
		[NonSerialized]
		protected bool bFlagDataTable;

		// Token: 0x04002E25 RID: 11813
		[NonSerialized]
		protected int iExtraBytes;

		// Token: 0x04002E26 RID: 11814
		[NonSerialized]
		protected char[] arrayUnicodeBestFit;

		// Token: 0x04002E27 RID: 11815
		[NonSerialized]
		protected char[] arrayBytesBestFit;

		// Token: 0x04002E28 RID: 11816
		[NonSerialized]
		protected bool m_bUseMlangTypeForSerialization;

		// Token: 0x04002E29 RID: 11817
		[SecurityCritical]
		private unsafe static BaseCodePageEncoding.CodePageDataFileHeader* m_pCodePageFileHeader = (BaseCodePageEncoding.CodePageDataFileHeader*)GlobalizationAssembly.GetGlobalizationResourceBytePtr(typeof(CharUnicodeInfo).Assembly, "codepages.nlp");

		// Token: 0x04002E2A RID: 11818
		[SecurityCritical]
		[NonSerialized]
		protected unsafe BaseCodePageEncoding.CodePageHeader* pCodePage;

		// Token: 0x04002E2B RID: 11819
		[SecurityCritical]
		[NonSerialized]
		protected SafeViewOfFileHandle safeMemorySectionHandle;

		// Token: 0x04002E2C RID: 11820
		[SecurityCritical]
		[NonSerialized]
		protected SafeFileMappingHandle safeFileMappingHandle;

		// Token: 0x02000CAA RID: 3242
		[StructLayout(LayoutKind.Explicit)]
		internal struct CodePageDataFileHeader
		{
			// Token: 0x04003889 RID: 14473
			[FieldOffset(0)]
			internal char TableName;

			// Token: 0x0400388A RID: 14474
			[FieldOffset(32)]
			internal ushort Version;

			// Token: 0x0400388B RID: 14475
			[FieldOffset(40)]
			internal short CodePageCount;

			// Token: 0x0400388C RID: 14476
			[FieldOffset(42)]
			internal short unused1;

			// Token: 0x0400388D RID: 14477
			[FieldOffset(44)]
			internal BaseCodePageEncoding.CodePageIndex CodePages;
		}

		// Token: 0x02000CAB RID: 3243
		[StructLayout(LayoutKind.Explicit, Pack = 2)]
		internal struct CodePageIndex
		{
			// Token: 0x0400388E RID: 14478
			[FieldOffset(0)]
			internal char CodePageName;

			// Token: 0x0400388F RID: 14479
			[FieldOffset(32)]
			internal short CodePage;

			// Token: 0x04003890 RID: 14480
			[FieldOffset(34)]
			internal short ByteCount;

			// Token: 0x04003891 RID: 14481
			[FieldOffset(36)]
			internal int Offset;
		}

		// Token: 0x02000CAC RID: 3244
		[StructLayout(LayoutKind.Explicit)]
		internal struct CodePageHeader
		{
			// Token: 0x04003892 RID: 14482
			[FieldOffset(0)]
			internal char CodePageName;

			// Token: 0x04003893 RID: 14483
			[FieldOffset(32)]
			internal ushort VersionMajor;

			// Token: 0x04003894 RID: 14484
			[FieldOffset(34)]
			internal ushort VersionMinor;

			// Token: 0x04003895 RID: 14485
			[FieldOffset(36)]
			internal ushort VersionRevision;

			// Token: 0x04003896 RID: 14486
			[FieldOffset(38)]
			internal ushort VersionBuild;

			// Token: 0x04003897 RID: 14487
			[FieldOffset(40)]
			internal short CodePage;

			// Token: 0x04003898 RID: 14488
			[FieldOffset(42)]
			internal short ByteCount;

			// Token: 0x04003899 RID: 14489
			[FieldOffset(44)]
			internal char UnicodeReplace;

			// Token: 0x0400389A RID: 14490
			[FieldOffset(46)]
			internal ushort ByteReplace;

			// Token: 0x0400389B RID: 14491
			[FieldOffset(48)]
			internal short FirstDataWord;
		}
	}
}
