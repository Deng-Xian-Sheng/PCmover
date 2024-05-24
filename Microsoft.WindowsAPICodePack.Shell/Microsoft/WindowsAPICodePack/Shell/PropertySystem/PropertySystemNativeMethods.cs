using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000A2 RID: 162
	internal static class PropertySystemNativeMethods
	{
		// Token: 0x0600054C RID: 1356
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int PSGetNameFromPropertyKey(ref PropertyKey propkey, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCanonicalName);

		// Token: 0x0600054D RID: 1357
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern HResult PSGetPropertyDescription(ref PropertyKey propkey, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IPropertyDescription ppv);

		// Token: 0x0600054E RID: 1358
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int PSGetPropertyKeyFromName([MarshalAs(UnmanagedType.LPWStr)] [In] string pszCanonicalName, out PropertyKey propkey);

		// Token: 0x0600054F RID: 1359
		[DllImport("propsys.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int PSGetPropertyDescriptionListFromString([MarshalAs(UnmanagedType.LPWStr)] [In] string pszPropList, [In] ref Guid riid, out IPropertyDescriptionList ppv);

		// Token: 0x020000A3 RID: 163
		internal enum RelativeDescriptionType
		{
			// Token: 0x0400031E RID: 798
			General,
			// Token: 0x0400031F RID: 799
			Date,
			// Token: 0x04000320 RID: 800
			Size,
			// Token: 0x04000321 RID: 801
			Count,
			// Token: 0x04000322 RID: 802
			Revision,
			// Token: 0x04000323 RID: 803
			Length,
			// Token: 0x04000324 RID: 804
			Duration,
			// Token: 0x04000325 RID: 805
			Speed,
			// Token: 0x04000326 RID: 806
			Rate,
			// Token: 0x04000327 RID: 807
			Rating,
			// Token: 0x04000328 RID: 808
			Priority
		}
	}
}
