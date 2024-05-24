using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.Versioning
{
	// Token: 0x0200071B RID: 1819
	[FriendAccessAllowed]
	internal static class BinaryCompatibility
	{
		// Token: 0x17000D5C RID: 3420
		// (get) Token: 0x0600513E RID: 20798 RVA: 0x0011E84F File Offset: 0x0011CA4F
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Phone_V7_1
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Phone_V7_1;
			}
		}

		// Token: 0x17000D5D RID: 3421
		// (get) Token: 0x0600513F RID: 20799 RVA: 0x0011E85B File Offset: 0x0011CA5B
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Phone_V8_0
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Phone_V8_0;
			}
		}

		// Token: 0x17000D5E RID: 3422
		// (get) Token: 0x06005140 RID: 20800 RVA: 0x0011E867 File Offset: 0x0011CA67
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V4_5
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V4_5;
			}
		}

		// Token: 0x17000D5F RID: 3423
		// (get) Token: 0x06005141 RID: 20801 RVA: 0x0011E873 File Offset: 0x0011CA73
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V4_5_1
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V4_5_1;
			}
		}

		// Token: 0x17000D60 RID: 3424
		// (get) Token: 0x06005142 RID: 20802 RVA: 0x0011E87F File Offset: 0x0011CA7F
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V4_5_2
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V4_5_2;
			}
		}

		// Token: 0x17000D61 RID: 3425
		// (get) Token: 0x06005143 RID: 20803 RVA: 0x0011E88B File Offset: 0x0011CA8B
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V4_5_3
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V4_5_3;
			}
		}

		// Token: 0x17000D62 RID: 3426
		// (get) Token: 0x06005144 RID: 20804 RVA: 0x0011E897 File Offset: 0x0011CA97
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V4_5_4
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V4_5_4;
			}
		}

		// Token: 0x17000D63 RID: 3427
		// (get) Token: 0x06005145 RID: 20805 RVA: 0x0011E8A3 File Offset: 0x0011CAA3
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Desktop_V5_0
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Desktop_V5_0;
			}
		}

		// Token: 0x17000D64 RID: 3428
		// (get) Token: 0x06005146 RID: 20806 RVA: 0x0011E8AF File Offset: 0x0011CAAF
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Silverlight_V4
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Silverlight_V4;
			}
		}

		// Token: 0x17000D65 RID: 3429
		// (get) Token: 0x06005147 RID: 20807 RVA: 0x0011E8BB File Offset: 0x0011CABB
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Silverlight_V5
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Silverlight_V5;
			}
		}

		// Token: 0x17000D66 RID: 3430
		// (get) Token: 0x06005148 RID: 20808 RVA: 0x0011E8C7 File Offset: 0x0011CAC7
		[FriendAccessAllowed]
		internal static bool TargetsAtLeast_Silverlight_V6
		{
			[FriendAccessAllowed]
			get
			{
				return BinaryCompatibility.s_map.TargetsAtLeast_Silverlight_V6;
			}
		}

		// Token: 0x17000D67 RID: 3431
		// (get) Token: 0x06005149 RID: 20809 RVA: 0x0011E8D3 File Offset: 0x0011CAD3
		[FriendAccessAllowed]
		internal static TargetFrameworkId AppWasBuiltForFramework
		{
			[FriendAccessAllowed]
			get
			{
				if (BinaryCompatibility.s_AppWasBuiltForFramework == TargetFrameworkId.NotYetChecked)
				{
					BinaryCompatibility.ReadTargetFrameworkId();
				}
				return BinaryCompatibility.s_AppWasBuiltForFramework;
			}
		}

		// Token: 0x17000D68 RID: 3432
		// (get) Token: 0x0600514A RID: 20810 RVA: 0x0011E8E6 File Offset: 0x0011CAE6
		[FriendAccessAllowed]
		internal static int AppWasBuiltForVersion
		{
			[FriendAccessAllowed]
			get
			{
				if (BinaryCompatibility.s_AppWasBuiltForFramework == TargetFrameworkId.NotYetChecked)
				{
					BinaryCompatibility.ReadTargetFrameworkId();
				}
				return BinaryCompatibility.s_AppWasBuiltForVersion;
			}
		}

		// Token: 0x0600514B RID: 20811 RVA: 0x0011E8FC File Offset: 0x0011CAFC
		private static bool ParseTargetFrameworkMonikerIntoEnum(string targetFrameworkMoniker, out TargetFrameworkId targetFramework, out int targetFrameworkVersion)
		{
			targetFramework = TargetFrameworkId.NotYetChecked;
			targetFrameworkVersion = 0;
			string a = null;
			string text = null;
			BinaryCompatibility.ParseFrameworkName(targetFrameworkMoniker, out a, out targetFrameworkVersion, out text);
			if (!(a == ".NETFramework"))
			{
				if (!(a == ".NETPortable"))
				{
					if (!(a == ".NETCore"))
					{
						if (!(a == "WindowsPhone"))
						{
							if (!(a == "WindowsPhoneApp"))
							{
								if (!(a == "Silverlight"))
								{
									targetFramework = TargetFrameworkId.Unrecognized;
								}
								else
								{
									targetFramework = TargetFrameworkId.Silverlight;
									if (!string.IsNullOrEmpty(text))
									{
										if (text == "WindowsPhone")
										{
											targetFramework = TargetFrameworkId.Phone;
											targetFrameworkVersion = 70000;
										}
										else if (text == "WindowsPhone71")
										{
											targetFramework = TargetFrameworkId.Phone;
											targetFrameworkVersion = 70100;
										}
										else if (text == "WindowsPhone8")
										{
											targetFramework = TargetFrameworkId.Phone;
											targetFrameworkVersion = 80000;
										}
										else if (text.StartsWith("WindowsPhone", StringComparison.Ordinal))
										{
											targetFramework = TargetFrameworkId.Unrecognized;
											targetFrameworkVersion = 70100;
										}
										else
										{
											targetFramework = TargetFrameworkId.Unrecognized;
										}
									}
								}
							}
							else
							{
								targetFramework = TargetFrameworkId.Phone;
							}
						}
						else if (targetFrameworkVersion >= 80100)
						{
							targetFramework = TargetFrameworkId.Phone;
						}
						else
						{
							targetFramework = TargetFrameworkId.Unspecified;
						}
					}
					else
					{
						targetFramework = TargetFrameworkId.NetCore;
					}
				}
				else
				{
					targetFramework = TargetFrameworkId.Portable;
				}
			}
			else
			{
				targetFramework = TargetFrameworkId.NetFramework;
			}
			return true;
		}

		// Token: 0x0600514C RID: 20812 RVA: 0x0011EA20 File Offset: 0x0011CC20
		private static void ParseFrameworkName(string frameworkName, out string identifier, out int version, out string profile)
		{
			if (frameworkName == null)
			{
				throw new ArgumentNullException("frameworkName");
			}
			if (frameworkName.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_StringZeroLength"), "frameworkName");
			}
			string[] array = frameworkName.Split(new char[]
			{
				','
			});
			version = 0;
			if (array.Length < 2 || array.Length > 3)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_FrameworkNameTooShort"), "frameworkName");
			}
			identifier = array[0].Trim();
			if (identifier.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_FrameworkNameInvalid"), "frameworkName");
			}
			bool flag = false;
			profile = null;
			for (int i = 1; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'='
				});
				if (array2.Length != 2)
				{
					throw new ArgumentException(Environment.GetResourceString("SR.Argument_FrameworkNameInvalid"), "frameworkName");
				}
				string text = array2[0].Trim();
				string text2 = array2[1].Trim();
				if (text.Equals("Version", StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					if (text2.Length > 0 && (text2[0] == 'v' || text2[0] == 'V'))
					{
						text2 = text2.Substring(1);
					}
					Version version2 = new Version(text2);
					version = version2.Major * 10000;
					if (version2.Minor > 0)
					{
						version += version2.Minor * 100;
					}
					if (version2.Build > 0)
					{
						version += version2.Build;
					}
				}
				else
				{
					if (!text.Equals("Profile", StringComparison.OrdinalIgnoreCase))
					{
						throw new ArgumentException(Environment.GetResourceString("Argument_FrameworkNameInvalid"), "frameworkName");
					}
					if (!string.IsNullOrEmpty(text2))
					{
						profile = text2;
					}
				}
			}
			if (!flag)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_FrameworkNameMissingVersion"), "frameworkName");
			}
		}

		// Token: 0x0600514D RID: 20813 RVA: 0x0011EBE4 File Offset: 0x0011CDE4
		[SecuritySafeCritical]
		private static void ReadTargetFrameworkId()
		{
			string text = AppDomain.CurrentDomain.GetTargetFrameworkName();
			string valueInternal = CompatibilitySwitch.GetValueInternal("TargetFrameworkMoniker");
			if (!string.IsNullOrEmpty(valueInternal))
			{
				text = valueInternal;
			}
			int num = 0;
			TargetFrameworkId targetFrameworkId;
			if (text == null)
			{
				targetFrameworkId = TargetFrameworkId.Unspecified;
			}
			else if (!BinaryCompatibility.ParseTargetFrameworkMonikerIntoEnum(text, out targetFrameworkId, out num))
			{
				targetFrameworkId = TargetFrameworkId.Unrecognized;
			}
			BinaryCompatibility.s_AppWasBuiltForFramework = targetFrameworkId;
			BinaryCompatibility.s_AppWasBuiltForVersion = num;
		}

		// Token: 0x040023FA RID: 9210
		private static TargetFrameworkId s_AppWasBuiltForFramework;

		// Token: 0x040023FB RID: 9211
		private static int s_AppWasBuiltForVersion;

		// Token: 0x040023FC RID: 9212
		private static readonly BinaryCompatibility.BinaryCompatibilityMap s_map = new BinaryCompatibility.BinaryCompatibilityMap();

		// Token: 0x040023FD RID: 9213
		private const char c_componentSeparator = ',';

		// Token: 0x040023FE RID: 9214
		private const char c_keyValueSeparator = '=';

		// Token: 0x040023FF RID: 9215
		private const char c_versionValuePrefix = 'v';

		// Token: 0x04002400 RID: 9216
		private const string c_versionKey = "Version";

		// Token: 0x04002401 RID: 9217
		private const string c_profileKey = "Profile";

		// Token: 0x02000C62 RID: 3170
		private sealed class BinaryCompatibilityMap
		{
			// Token: 0x06007075 RID: 28789 RVA: 0x00183430 File Offset: 0x00181630
			internal BinaryCompatibilityMap()
			{
				this.AddQuirksForFramework(BinaryCompatibility.AppWasBuiltForFramework, BinaryCompatibility.AppWasBuiltForVersion);
			}

			// Token: 0x06007076 RID: 28790 RVA: 0x00183448 File Offset: 0x00181648
			private void AddQuirksForFramework(TargetFrameworkId builtAgainstFramework, int buildAgainstVersion)
			{
				switch (builtAgainstFramework)
				{
				case TargetFrameworkId.NotYetChecked:
				case TargetFrameworkId.Unrecognized:
				case TargetFrameworkId.Unspecified:
				case TargetFrameworkId.Portable:
					break;
				case TargetFrameworkId.NetFramework:
				case TargetFrameworkId.NetCore:
					if (buildAgainstVersion >= 50000)
					{
						this.TargetsAtLeast_Desktop_V5_0 = true;
					}
					if (buildAgainstVersion >= 40504)
					{
						this.TargetsAtLeast_Desktop_V4_5_4 = true;
					}
					if (buildAgainstVersion >= 40503)
					{
						this.TargetsAtLeast_Desktop_V4_5_3 = true;
					}
					if (buildAgainstVersion >= 40502)
					{
						this.TargetsAtLeast_Desktop_V4_5_2 = true;
					}
					if (buildAgainstVersion >= 40501)
					{
						this.TargetsAtLeast_Desktop_V4_5_1 = true;
					}
					if (buildAgainstVersion >= 40500)
					{
						this.TargetsAtLeast_Desktop_V4_5 = true;
						this.AddQuirksForFramework(TargetFrameworkId.Phone, 70100);
						this.AddQuirksForFramework(TargetFrameworkId.Silverlight, 50000);
						return;
					}
					break;
				case TargetFrameworkId.Silverlight:
					if (buildAgainstVersion >= 40000)
					{
						this.TargetsAtLeast_Silverlight_V4 = true;
					}
					if (buildAgainstVersion >= 50000)
					{
						this.TargetsAtLeast_Silverlight_V5 = true;
					}
					if (buildAgainstVersion >= 60000)
					{
						this.TargetsAtLeast_Silverlight_V6 = true;
					}
					break;
				case TargetFrameworkId.Phone:
					if (buildAgainstVersion >= 80000)
					{
						this.TargetsAtLeast_Phone_V8_0 = true;
					}
					if (buildAgainstVersion >= 80100)
					{
						this.TargetsAtLeast_Desktop_V4_5 = true;
						this.TargetsAtLeast_Desktop_V4_5_1 = true;
					}
					if (buildAgainstVersion >= 710)
					{
						this.TargetsAtLeast_Phone_V7_1 = true;
						return;
					}
					break;
				default:
					return;
				}
			}

			// Token: 0x040037BA RID: 14266
			internal bool TargetsAtLeast_Phone_V7_1;

			// Token: 0x040037BB RID: 14267
			internal bool TargetsAtLeast_Phone_V8_0;

			// Token: 0x040037BC RID: 14268
			internal bool TargetsAtLeast_Phone_V8_1;

			// Token: 0x040037BD RID: 14269
			internal bool TargetsAtLeast_Desktop_V4_5;

			// Token: 0x040037BE RID: 14270
			internal bool TargetsAtLeast_Desktop_V4_5_1;

			// Token: 0x040037BF RID: 14271
			internal bool TargetsAtLeast_Desktop_V4_5_2;

			// Token: 0x040037C0 RID: 14272
			internal bool TargetsAtLeast_Desktop_V4_5_3;

			// Token: 0x040037C1 RID: 14273
			internal bool TargetsAtLeast_Desktop_V4_5_4;

			// Token: 0x040037C2 RID: 14274
			internal bool TargetsAtLeast_Desktop_V5_0;

			// Token: 0x040037C3 RID: 14275
			internal bool TargetsAtLeast_Silverlight_V4;

			// Token: 0x040037C4 RID: 14276
			internal bool TargetsAtLeast_Silverlight_V5;

			// Token: 0x040037C5 RID: 14277
			internal bool TargetsAtLeast_Silverlight_V6;
		}
	}
}
