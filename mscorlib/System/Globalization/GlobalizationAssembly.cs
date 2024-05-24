﻿using System;
using System.IO;
using System.Reflection;
using System.Security;

namespace System.Globalization
{
	// Token: 0x020003BA RID: 954
	internal sealed class GlobalizationAssembly
	{
		// Token: 0x06002F54 RID: 12116 RVA: 0x000B5CD0 File Offset: 0x000B3ED0
		[SecurityCritical]
		internal unsafe static byte* GetGlobalizationResourceBytePtr(Assembly assembly, string tableName)
		{
			Stream manifestResourceStream = assembly.GetManifestResourceStream(tableName);
			UnmanagedMemoryStream unmanagedMemoryStream = manifestResourceStream as UnmanagedMemoryStream;
			if (unmanagedMemoryStream != null)
			{
				byte* positionPointer = unmanagedMemoryStream.PositionPointer;
				if (positionPointer != null)
				{
					return positionPointer;
				}
			}
			throw new InvalidOperationException();
		}
	}
}
