using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;

namespace System.Globalization
{
	// Token: 0x020003B7 RID: 951
	internal static class EncodingTable
	{
		// Token: 0x06002F4C RID: 12108 RVA: 0x000B5AA4 File Offset: 0x000B3CA4
		[SecuritySafeCritical]
		private unsafe static int internalGetCodePageFromName(string name)
		{
			int i = 0;
			int num = EncodingTable.lastEncodingItem;
			while (num - i > 3)
			{
				int num2 = (num - i) / 2 + i;
				int num3 = string.nativeCompareOrdinalIgnoreCaseWC(name, EncodingTable.encodingDataPtr[num2].webName);
				if (num3 == 0)
				{
					return (int)EncodingTable.encodingDataPtr[num2].codePage;
				}
				if (num3 < 0)
				{
					num = num2;
				}
				else
				{
					i = num2;
				}
			}
			while (i <= num)
			{
				if (string.nativeCompareOrdinalIgnoreCaseWC(name, EncodingTable.encodingDataPtr[i].webName) == 0)
				{
					return (int)EncodingTable.encodingDataPtr[i].codePage;
				}
				i++;
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_EncodingNotSupported"), name), "name");
		}

		// Token: 0x06002F4D RID: 12109 RVA: 0x000B5B60 File Offset: 0x000B3D60
		[SecuritySafeCritical]
		internal unsafe static EncodingInfo[] GetEncodings()
		{
			if (EncodingTable.lastCodePageItem == 0)
			{
				int num = 0;
				while (EncodingTable.codePageDataPtr[num].codePage != 0)
				{
					num++;
				}
				EncodingTable.lastCodePageItem = num;
			}
			EncodingInfo[] array = new EncodingInfo[EncodingTable.lastCodePageItem];
			for (int i = 0; i < EncodingTable.lastCodePageItem; i++)
			{
				array[i] = new EncodingInfo((int)EncodingTable.codePageDataPtr[i].codePage, CodePageDataItem.CreateString(EncodingTable.codePageDataPtr[i].Names, 0U), Environment.GetResourceString("Globalization.cp_" + EncodingTable.codePageDataPtr[i].codePage.ToString()));
			}
			return array;
		}

		// Token: 0x06002F4E RID: 12110 RVA: 0x000B5C1C File Offset: 0x000B3E1C
		internal static int GetCodePageFromName(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			object obj = EncodingTable.hashByName[name];
			if (obj != null)
			{
				return (int)obj;
			}
			int num = EncodingTable.internalGetCodePageFromName(name);
			EncodingTable.hashByName[name] = num;
			return num;
		}

		// Token: 0x06002F4F RID: 12111 RVA: 0x000B5C68 File Offset: 0x000B3E68
		[SecuritySafeCritical]
		internal unsafe static CodePageDataItem GetCodePageDataItem(int codepage)
		{
			CodePageDataItem codePageDataItem = (CodePageDataItem)EncodingTable.hashByCodePage[codepage];
			if (codePageDataItem != null)
			{
				return codePageDataItem;
			}
			int num = 0;
			int codePage;
			while ((codePage = (int)EncodingTable.codePageDataPtr[num].codePage) != 0)
			{
				if (codePage == codepage)
				{
					codePageDataItem = new CodePageDataItem(num);
					EncodingTable.hashByCodePage[codepage] = codePageDataItem;
					return codePageDataItem;
				}
				num++;
			}
			return null;
		}

		// Token: 0x06002F50 RID: 12112
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern InternalEncodingDataItem* GetEncodingData();

		// Token: 0x06002F51 RID: 12113
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetNumEncodingItems();

		// Token: 0x06002F52 RID: 12114
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern InternalCodePageDataItem* GetCodePageData();

		// Token: 0x06002F53 RID: 12115
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal unsafe static extern byte* nativeCreateOpenFileMapping(string inSectionName, int inBytesToAllocate, out IntPtr mappedFileHandle);

		// Token: 0x0400140E RID: 5134
		private static int lastEncodingItem = EncodingTable.GetNumEncodingItems() - 1;

		// Token: 0x0400140F RID: 5135
		private static volatile int lastCodePageItem;

		// Token: 0x04001410 RID: 5136
		[SecurityCritical]
		internal unsafe static InternalEncodingDataItem* encodingDataPtr = EncodingTable.GetEncodingData();

		// Token: 0x04001411 RID: 5137
		[SecurityCritical]
		internal unsafe static InternalCodePageDataItem* codePageDataPtr = EncodingTable.GetCodePageData();

		// Token: 0x04001412 RID: 5138
		private static Hashtable hashByName = Hashtable.Synchronized(new Hashtable(StringComparer.OrdinalIgnoreCase));

		// Token: 0x04001413 RID: 5139
		private static Hashtable hashByCodePage = Hashtable.Synchronized(new Hashtable());
	}
}
