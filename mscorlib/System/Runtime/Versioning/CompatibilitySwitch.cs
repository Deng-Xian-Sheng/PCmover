using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.Versioning
{
	// Token: 0x02000726 RID: 1830
	public static class CompatibilitySwitch
	{
		// Token: 0x06005164 RID: 20836 RVA: 0x0011F03A File Offset: 0x0011D23A
		[SecurityCritical]
		public static bool IsEnabled(string compatibilitySwitchName)
		{
			return CompatibilitySwitch.IsEnabledInternalCall(compatibilitySwitchName, true);
		}

		// Token: 0x06005165 RID: 20837 RVA: 0x0011F043 File Offset: 0x0011D243
		[SecurityCritical]
		public static string GetValue(string compatibilitySwitchName)
		{
			return CompatibilitySwitch.GetValueInternalCall(compatibilitySwitchName, true);
		}

		// Token: 0x06005166 RID: 20838 RVA: 0x0011F04C File Offset: 0x0011D24C
		[SecurityCritical]
		internal static bool IsEnabledInternal(string compatibilitySwitchName)
		{
			return CompatibilitySwitch.IsEnabledInternalCall(compatibilitySwitchName, false);
		}

		// Token: 0x06005167 RID: 20839 RVA: 0x0011F055 File Offset: 0x0011D255
		[SecurityCritical]
		internal static string GetValueInternal(string compatibilitySwitchName)
		{
			return CompatibilitySwitch.GetValueInternalCall(compatibilitySwitchName, false);
		}

		// Token: 0x06005168 RID: 20840
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string GetAppContextOverridesInternalCall();

		// Token: 0x06005169 RID: 20841
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsEnabledInternalCall(string compatibilitySwitchName, bool onlyDB);

		// Token: 0x0600516A RID: 20842
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern string GetValueInternalCall(string compatibilitySwitchName, bool onlyDB);
	}
}
