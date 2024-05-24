using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000E8 RID: 232
	public static class SystemProperties
	{
		// Token: 0x060008DA RID: 2266 RVA: 0x00025F78 File Offset: 0x00024178
		public static ShellPropertyDescription GetPropertyDescription(PropertyKey propertyKey)
		{
			return ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propertyKey);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00025F98 File Offset: 0x00024198
		public static ShellPropertyDescription GetPropertyDescription(string canonicalName)
		{
			PropertyKey key;
			int num = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out key);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, Marshal.GetExceptionForHR(num));
			}
			return ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(key);
		}

		// Token: 0x020000E9 RID: 233
		public static class System
		{
			// Token: 0x17000477 RID: 1143
			// (get) Token: 0x060008DC RID: 2268 RVA: 0x00025FDC File Offset: 0x000241DC
			public static PropertyKey AcquisitionID
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{65A98875-3C80-40AB-ABBC-EFDAF77DBEE2}"), 100);
					return result;
				}
			}

			// Token: 0x17000478 RID: 1144
			// (get) Token: 0x060008DD RID: 2269 RVA: 0x00026004 File Offset: 0x00024204
			public static PropertyKey ApplicationName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 18);
					return result;
				}
			}

			// Token: 0x17000479 RID: 1145
			// (get) Token: 0x060008DE RID: 2270 RVA: 0x0002602C File Offset: 0x0002422C
			public static PropertyKey Author
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 4);
					return result;
				}
			}

			// Token: 0x1700047A RID: 1146
			// (get) Token: 0x060008DF RID: 2271 RVA: 0x00026054 File Offset: 0x00024254
			public static PropertyKey Capacity
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 3);
					return result;
				}
			}

			// Token: 0x1700047B RID: 1147
			// (get) Token: 0x060008E0 RID: 2272 RVA: 0x0002607C File Offset: 0x0002427C
			public static PropertyKey Category
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 2);
					return result;
				}
			}

			// Token: 0x1700047C RID: 1148
			// (get) Token: 0x060008E1 RID: 2273 RVA: 0x000260A4 File Offset: 0x000242A4
			public static PropertyKey Comment
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 6);
					return result;
				}
			}

			// Token: 0x1700047D RID: 1149
			// (get) Token: 0x060008E2 RID: 2274 RVA: 0x000260CC File Offset: 0x000242CC
			public static PropertyKey Company
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 15);
					return result;
				}
			}

			// Token: 0x1700047E RID: 1150
			// (get) Token: 0x060008E3 RID: 2275 RVA: 0x000260F4 File Offset: 0x000242F4
			public static PropertyKey ComputerName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 5);
					return result;
				}
			}

			// Token: 0x1700047F RID: 1151
			// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0002611C File Offset: 0x0002431C
			public static PropertyKey ContainedItems
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 29);
					return result;
				}
			}

			// Token: 0x17000480 RID: 1152
			// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00026144 File Offset: 0x00024344
			public static PropertyKey ContentStatus
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 27);
					return result;
				}
			}

			// Token: 0x17000481 RID: 1153
			// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002616C File Offset: 0x0002436C
			public static PropertyKey ContentType
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 26);
					return result;
				}
			}

			// Token: 0x17000482 RID: 1154
			// (get) Token: 0x060008E7 RID: 2279 RVA: 0x00026194 File Offset: 0x00024394
			public static PropertyKey Copyright
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 11);
					return result;
				}
			}

			// Token: 0x17000483 RID: 1155
			// (get) Token: 0x060008E8 RID: 2280 RVA: 0x000261BC File Offset: 0x000243BC
			public static PropertyKey DateAccessed
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 16);
					return result;
				}
			}

			// Token: 0x17000484 RID: 1156
			// (get) Token: 0x060008E9 RID: 2281 RVA: 0x000261E4 File Offset: 0x000243E4
			public static PropertyKey DateAcquired
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{2CBAA8F5-D81F-47CA-B17A-F8D822300131}"), 100);
					return result;
				}
			}

			// Token: 0x17000485 RID: 1157
			// (get) Token: 0x060008EA RID: 2282 RVA: 0x0002620C File Offset: 0x0002440C
			public static PropertyKey DateArchived
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{43F8D7B7-A444-4F87-9383-52271C9B915C}"), 100);
					return result;
				}
			}

			// Token: 0x17000486 RID: 1158
			// (get) Token: 0x060008EB RID: 2283 RVA: 0x00026234 File Offset: 0x00024434
			public static PropertyKey DateCompleted
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{72FAB781-ACDA-43E5-B155-B2434F85E678}"), 100);
					return result;
				}
			}

			// Token: 0x17000487 RID: 1159
			// (get) Token: 0x060008EC RID: 2284 RVA: 0x0002625C File Offset: 0x0002445C
			public static PropertyKey DateCreated
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 15);
					return result;
				}
			}

			// Token: 0x17000488 RID: 1160
			// (get) Token: 0x060008ED RID: 2285 RVA: 0x00026284 File Offset: 0x00024484
			public static PropertyKey DateImported
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18258);
					return result;
				}
			}

			// Token: 0x17000489 RID: 1161
			// (get) Token: 0x060008EE RID: 2286 RVA: 0x000262B0 File Offset: 0x000244B0
			public static PropertyKey DateModified
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 14);
					return result;
				}
			}

			// Token: 0x1700048A RID: 1162
			// (get) Token: 0x060008EF RID: 2287 RVA: 0x000262D8 File Offset: 0x000244D8
			public static PropertyKey DescriptionID
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 2);
					return result;
				}
			}

			// Token: 0x1700048B RID: 1163
			// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00026300 File Offset: 0x00024500
			public static PropertyKey DueDate
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE}"), 100);
					return result;
				}
			}

			// Token: 0x1700048C RID: 1164
			// (get) Token: 0x060008F1 RID: 2289 RVA: 0x00026328 File Offset: 0x00024528
			public static PropertyKey EndDate
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{C75FAA05-96FD-49E7-9CB4-9F601082D553}"), 100);
					return result;
				}
			}

			// Token: 0x1700048D RID: 1165
			// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00026350 File Offset: 0x00024550
			public static PropertyKey FileAllocationSize
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 18);
					return result;
				}
			}

			// Token: 0x1700048E RID: 1166
			// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00026378 File Offset: 0x00024578
			public static PropertyKey FileAttributes
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 13);
					return result;
				}
			}

			// Token: 0x1700048F RID: 1167
			// (get) Token: 0x060008F4 RID: 2292 RVA: 0x000263A0 File Offset: 0x000245A0
			public static PropertyKey FileCount
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 12);
					return result;
				}
			}

			// Token: 0x17000490 RID: 1168
			// (get) Token: 0x060008F5 RID: 2293 RVA: 0x000263C8 File Offset: 0x000245C8
			public static PropertyKey FileDescription
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 3);
					return result;
				}
			}

			// Token: 0x17000491 RID: 1169
			// (get) Token: 0x060008F6 RID: 2294 RVA: 0x000263F0 File Offset: 0x000245F0
			public static PropertyKey FileExtension
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E4F10A3C-49E6-405D-8288-A23BD4EEAA6C}"), 100);
					return result;
				}
			}

			// Token: 0x17000492 RID: 1170
			// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00026418 File Offset: 0x00024618
			public static PropertyKey FileFRN
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 21);
					return result;
				}
			}

			// Token: 0x17000493 RID: 1171
			// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00026440 File Offset: 0x00024640
			public static PropertyKey FileName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{41CF5AE0-F75A-4806-BD87-59C7D9248EB9}"), 100);
					return result;
				}
			}

			// Token: 0x17000494 RID: 1172
			// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00026468 File Offset: 0x00024668
			public static PropertyKey FileOwner
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{9B174B34-40FF-11D2-A27E-00C04FC30871}"), 4);
					return result;
				}
			}

			// Token: 0x17000495 RID: 1173
			// (get) Token: 0x060008FA RID: 2298 RVA: 0x00026490 File Offset: 0x00024690
			public static PropertyKey FileVersion
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 4);
					return result;
				}
			}

			// Token: 0x17000496 RID: 1174
			// (get) Token: 0x060008FB RID: 2299 RVA: 0x000264B8 File Offset: 0x000246B8
			public static PropertyKey FindData
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 0);
					return result;
				}
			}

			// Token: 0x17000497 RID: 1175
			// (get) Token: 0x060008FC RID: 2300 RVA: 0x000264E0 File Offset: 0x000246E0
			public static PropertyKey FlagColor
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{67DF94DE-0CA7-4D6F-B792-053A3E4F03CF}"), 100);
					return result;
				}
			}

			// Token: 0x17000498 RID: 1176
			// (get) Token: 0x060008FD RID: 2301 RVA: 0x00026508 File Offset: 0x00024708
			public static PropertyKey FlagColorText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{45EAE747-8E2A-40AE-8CBF-CA52ABA6152A}"), 100);
					return result;
				}
			}

			// Token: 0x17000499 RID: 1177
			// (get) Token: 0x060008FE RID: 2302 RVA: 0x00026530 File Offset: 0x00024730
			public static PropertyKey FlagStatus
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 12);
					return result;
				}
			}

			// Token: 0x1700049A RID: 1178
			// (get) Token: 0x060008FF RID: 2303 RVA: 0x00026558 File Offset: 0x00024758
			public static PropertyKey FlagStatusText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{DC54FD2E-189D-4871-AA01-08C2F57A4ABC}"), 100);
					return result;
				}
			}

			// Token: 0x1700049B RID: 1179
			// (get) Token: 0x06000900 RID: 2304 RVA: 0x00026580 File Offset: 0x00024780
			public static PropertyKey FreeSpace
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 2);
					return result;
				}
			}

			// Token: 0x1700049C RID: 1180
			// (get) Token: 0x06000901 RID: 2305 RVA: 0x000265A8 File Offset: 0x000247A8
			public static PropertyKey FullText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 6);
					return result;
				}
			}

			// Token: 0x1700049D RID: 1181
			// (get) Token: 0x06000902 RID: 2306 RVA: 0x000265D0 File Offset: 0x000247D0
			public static PropertyKey IdentityProperty
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A26F4AFC-7346-4299-BE47-EB1AE613139F}"), 100);
					return result;
				}
			}

			// Token: 0x1700049E RID: 1182
			// (get) Token: 0x06000903 RID: 2307 RVA: 0x000265F8 File Offset: 0x000247F8
			public static PropertyKey ImageParsingName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D7750EE0-C6A4-48EC-B53E-B87B52E6D073}"), 100);
					return result;
				}
			}

			// Token: 0x1700049F RID: 1183
			// (get) Token: 0x06000904 RID: 2308 RVA: 0x00026620 File Offset: 0x00024820
			public static PropertyKey Importance
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 11);
					return result;
				}
			}

			// Token: 0x170004A0 RID: 1184
			// (get) Token: 0x06000905 RID: 2309 RVA: 0x00026648 File Offset: 0x00024848
			public static PropertyKey ImportanceText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A3B29791-7713-4E1D-BB40-17DB85F01831}"), 100);
					return result;
				}
			}

			// Token: 0x170004A1 RID: 1185
			// (get) Token: 0x06000906 RID: 2310 RVA: 0x00026670 File Offset: 0x00024870
			public static PropertyKey InfoTipText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 17);
					return result;
				}
			}

			// Token: 0x170004A2 RID: 1186
			// (get) Token: 0x06000907 RID: 2311 RVA: 0x00026698 File Offset: 0x00024898
			public static PropertyKey InternalName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 5);
					return result;
				}
			}

			// Token: 0x170004A3 RID: 1187
			// (get) Token: 0x06000908 RID: 2312 RVA: 0x000266C0 File Offset: 0x000248C0
			public static PropertyKey IsAttachment
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F23F425C-71A1-4FA8-922F-678EA4A60408}"), 100);
					return result;
				}
			}

			// Token: 0x170004A4 RID: 1188
			// (get) Token: 0x06000909 RID: 2313 RVA: 0x000266E8 File Offset: 0x000248E8
			public static PropertyKey IsDefaultNonOwnerSaveLocation
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 5);
					return result;
				}
			}

			// Token: 0x170004A5 RID: 1189
			// (get) Token: 0x0600090A RID: 2314 RVA: 0x00026710 File Offset: 0x00024910
			public static PropertyKey IsDefaultSaveLocation
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 3);
					return result;
				}
			}

			// Token: 0x170004A6 RID: 1190
			// (get) Token: 0x0600090B RID: 2315 RVA: 0x00026738 File Offset: 0x00024938
			public static PropertyKey IsDeleted
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D}"), 100);
					return result;
				}
			}

			// Token: 0x170004A7 RID: 1191
			// (get) Token: 0x0600090C RID: 2316 RVA: 0x00026760 File Offset: 0x00024960
			public static PropertyKey IsEncrypted
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{90E5E14E-648B-4826-B2AA-ACAF790E3513}"), 10);
					return result;
				}
			}

			// Token: 0x170004A8 RID: 1192
			// (get) Token: 0x0600090D RID: 2317 RVA: 0x00026788 File Offset: 0x00024988
			public static PropertyKey IsFlagged
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5DA84765-E3FF-4278-86B0-A27967FBDD03}"), 100);
					return result;
				}
			}

			// Token: 0x170004A9 RID: 1193
			// (get) Token: 0x0600090E RID: 2318 RVA: 0x000267B0 File Offset: 0x000249B0
			public static PropertyKey IsFlaggedComplete
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A6F360D2-55F9-48DE-B909-620E090A647C}"), 100);
					return result;
				}
			}

			// Token: 0x170004AA RID: 1194
			// (get) Token: 0x0600090F RID: 2319 RVA: 0x000267D8 File Offset: 0x000249D8
			public static PropertyKey IsIncomplete
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{346C8BD1-2E6A-4C45-89A4-61B78E8E700F}"), 100);
					return result;
				}
			}

			// Token: 0x170004AB RID: 1195
			// (get) Token: 0x06000910 RID: 2320 RVA: 0x00026800 File Offset: 0x00024A00
			public static PropertyKey IsLocationSupported
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 8);
					return result;
				}
			}

			// Token: 0x170004AC RID: 1196
			// (get) Token: 0x06000911 RID: 2321 RVA: 0x00026828 File Offset: 0x00024A28
			public static PropertyKey IsPinnedToNamespaceTree
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 2);
					return result;
				}
			}

			// Token: 0x170004AD RID: 1197
			// (get) Token: 0x06000912 RID: 2322 RVA: 0x00026850 File Offset: 0x00024A50
			public static PropertyKey IsRead
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 10);
					return result;
				}
			}

			// Token: 0x170004AE RID: 1198
			// (get) Token: 0x06000913 RID: 2323 RVA: 0x00026878 File Offset: 0x00024A78
			public static PropertyKey IsSearchOnlyItem
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 4);
					return result;
				}
			}

			// Token: 0x170004AF RID: 1199
			// (get) Token: 0x06000914 RID: 2324 RVA: 0x000268A0 File Offset: 0x00024AA0
			public static PropertyKey IsSendToTarget
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 33);
					return result;
				}
			}

			// Token: 0x170004B0 RID: 1200
			// (get) Token: 0x06000915 RID: 2325 RVA: 0x000268C8 File Offset: 0x00024AC8
			public static PropertyKey IsShared
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 100);
					return result;
				}
			}

			// Token: 0x170004B1 RID: 1201
			// (get) Token: 0x06000916 RID: 2326 RVA: 0x000268F0 File Offset: 0x00024AF0
			public static PropertyKey ItemAuthors
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D0A04F0A-462A-48A4-BB2F-3706E88DBD7D}"), 100);
					return result;
				}
			}

			// Token: 0x170004B2 RID: 1202
			// (get) Token: 0x06000917 RID: 2327 RVA: 0x00026918 File Offset: 0x00024B18
			public static PropertyKey ItemClassType
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{048658AD-2DB8-41A4-BBB6-AC1EF1207EB1}"), 100);
					return result;
				}
			}

			// Token: 0x170004B3 RID: 1203
			// (get) Token: 0x06000918 RID: 2328 RVA: 0x00026940 File Offset: 0x00024B40
			public static PropertyKey ItemDate
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F7DB74B4-4287-4103-AFBA-F1B13DCD75CF}"), 100);
					return result;
				}
			}

			// Token: 0x170004B4 RID: 1204
			// (get) Token: 0x06000919 RID: 2329 RVA: 0x00026968 File Offset: 0x00024B68
			public static PropertyKey ItemFolderNameDisplay
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 2);
					return result;
				}
			}

			// Token: 0x170004B5 RID: 1205
			// (get) Token: 0x0600091A RID: 2330 RVA: 0x00026990 File Offset: 0x00024B90
			public static PropertyKey ItemFolderPathDisplay
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 6);
					return result;
				}
			}

			// Token: 0x170004B6 RID: 1206
			// (get) Token: 0x0600091B RID: 2331 RVA: 0x000269B8 File Offset: 0x00024BB8
			public static PropertyKey ItemFolderPathDisplayNarrow
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{DABD30ED-0043-4789-A7F8-D013A4736622}"), 100);
					return result;
				}
			}

			// Token: 0x170004B7 RID: 1207
			// (get) Token: 0x0600091C RID: 2332 RVA: 0x000269E0 File Offset: 0x00024BE0
			public static PropertyKey ItemName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F}"), 100);
					return result;
				}
			}

			// Token: 0x170004B8 RID: 1208
			// (get) Token: 0x0600091D RID: 2333 RVA: 0x00026A08 File Offset: 0x00024C08
			public static PropertyKey ItemNameDisplay
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 10);
					return result;
				}
			}

			// Token: 0x170004B9 RID: 1209
			// (get) Token: 0x0600091E RID: 2334 RVA: 0x00026A30 File Offset: 0x00024C30
			public static PropertyKey ItemNamePrefix
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D7313FF1-A77A-401C-8C99-3DBDD68ADD36}"), 100);
					return result;
				}
			}

			// Token: 0x170004BA RID: 1210
			// (get) Token: 0x0600091F RID: 2335 RVA: 0x00026A58 File Offset: 0x00024C58
			public static PropertyKey ItemParticipants
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D4D0AA16-9948-41A4-AA85-D97FF9646993}"), 100);
					return result;
				}
			}

			// Token: 0x170004BB RID: 1211
			// (get) Token: 0x06000920 RID: 2336 RVA: 0x00026A80 File Offset: 0x00024C80
			public static PropertyKey ItemPathDisplay
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 7);
					return result;
				}
			}

			// Token: 0x170004BC RID: 1212
			// (get) Token: 0x06000921 RID: 2337 RVA: 0x00026AA8 File Offset: 0x00024CA8
			public static PropertyKey ItemPathDisplayNarrow
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 8);
					return result;
				}
			}

			// Token: 0x170004BD RID: 1213
			// (get) Token: 0x06000922 RID: 2338 RVA: 0x00026AD0 File Offset: 0x00024CD0
			public static PropertyKey ItemType
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 11);
					return result;
				}
			}

			// Token: 0x170004BE RID: 1214
			// (get) Token: 0x06000923 RID: 2339 RVA: 0x00026AF8 File Offset: 0x00024CF8
			public static PropertyKey ItemTypeText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 4);
					return result;
				}
			}

			// Token: 0x170004BF RID: 1215
			// (get) Token: 0x06000924 RID: 2340 RVA: 0x00026B20 File Offset: 0x00024D20
			public static PropertyKey ItemUrl
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 9);
					return result;
				}
			}

			// Token: 0x170004C0 RID: 1216
			// (get) Token: 0x06000925 RID: 2341 RVA: 0x00026B48 File Offset: 0x00024D48
			public static PropertyKey Keywords
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 5);
					return result;
				}
			}

			// Token: 0x170004C1 RID: 1217
			// (get) Token: 0x06000926 RID: 2342 RVA: 0x00026B70 File Offset: 0x00024D70
			public static PropertyKey Kind
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{1E3EE840-BC2B-476C-8237-2ACD1A839B22}"), 3);
					return result;
				}
			}

			// Token: 0x170004C2 RID: 1218
			// (get) Token: 0x06000927 RID: 2343 RVA: 0x00026B98 File Offset: 0x00024D98
			public static PropertyKey KindText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F04BEF95-C585-4197-A2B7-DF46FDC9EE6D}"), 100);
					return result;
				}
			}

			// Token: 0x170004C3 RID: 1219
			// (get) Token: 0x06000928 RID: 2344 RVA: 0x00026BC0 File Offset: 0x00024DC0
			public static PropertyKey Language
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 28);
					return result;
				}
			}

			// Token: 0x170004C4 RID: 1220
			// (get) Token: 0x06000929 RID: 2345 RVA: 0x00026BE8 File Offset: 0x00024DE8
			public static PropertyKey MileageInformation
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{FDF84370-031A-4ADD-9E91-0D775F1C6605}"), 100);
					return result;
				}
			}

			// Token: 0x170004C5 RID: 1221
			// (get) Token: 0x0600092A RID: 2346 RVA: 0x00026C10 File Offset: 0x00024E10
			public static PropertyKey MIMEType
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 5);
					return result;
				}
			}

			// Token: 0x170004C6 RID: 1222
			// (get) Token: 0x0600092B RID: 2347 RVA: 0x00026C38 File Offset: 0x00024E38
			public static PropertyKey NamespaceClsid
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 6);
					return result;
				}
			}

			// Token: 0x170004C7 RID: 1223
			// (get) Token: 0x0600092C RID: 2348 RVA: 0x00026C60 File Offset: 0x00024E60
			public static PropertyKey Null
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{00000000-0000-0000-0000-000000000000}"), 0);
					return result;
				}
			}

			// Token: 0x170004C8 RID: 1224
			// (get) Token: 0x0600092D RID: 2349 RVA: 0x00026C88 File Offset: 0x00024E88
			public static PropertyKey OfflineAvailability
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A94688B6-7D9F-4570-A648-E3DFC0AB2B3F}"), 100);
					return result;
				}
			}

			// Token: 0x170004C9 RID: 1225
			// (get) Token: 0x0600092E RID: 2350 RVA: 0x00026CB0 File Offset: 0x00024EB0
			public static PropertyKey OfflineStatus
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{6D24888F-4718-4BDA-AFED-EA0FB4386CD8}"), 100);
					return result;
				}
			}

			// Token: 0x170004CA RID: 1226
			// (get) Token: 0x0600092F RID: 2351 RVA: 0x00026CD8 File Offset: 0x00024ED8
			public static PropertyKey OriginalFileName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 6);
					return result;
				}
			}

			// Token: 0x170004CB RID: 1227
			// (get) Token: 0x06000930 RID: 2352 RVA: 0x00026D00 File Offset: 0x00024F00
			public static PropertyKey OwnerSid
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{5D76B67F-9B3D-44BB-B6AE-25DA4F638A67}"), 6);
					return result;
				}
			}

			// Token: 0x170004CC RID: 1228
			// (get) Token: 0x06000931 RID: 2353 RVA: 0x00026D28 File Offset: 0x00024F28
			public static PropertyKey ParentalRating
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 21);
					return result;
				}
			}

			// Token: 0x170004CD RID: 1229
			// (get) Token: 0x06000932 RID: 2354 RVA: 0x00026D50 File Offset: 0x00024F50
			public static PropertyKey ParentalRatingReason
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{10984E0A-F9F2-4321-B7EF-BAF195AF4319}"), 100);
					return result;
				}
			}

			// Token: 0x170004CE RID: 1230
			// (get) Token: 0x06000933 RID: 2355 RVA: 0x00026D78 File Offset: 0x00024F78
			public static PropertyKey ParentalRatingsOrganization
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A7FE0840-1344-46F0-8D37-52ED712A4BF9}"), 100);
					return result;
				}
			}

			// Token: 0x170004CF RID: 1231
			// (get) Token: 0x06000934 RID: 2356 RVA: 0x00026DA0 File Offset: 0x00024FA0
			public static PropertyKey ParsingBindContext
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{DFB9A04D-362F-4CA3-B30B-0254B17B5B84}"), 100);
					return result;
				}
			}

			// Token: 0x170004D0 RID: 1232
			// (get) Token: 0x06000935 RID: 2357 RVA: 0x00026DC8 File Offset: 0x00024FC8
			public static PropertyKey ParsingName
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 24);
					return result;
				}
			}

			// Token: 0x170004D1 RID: 1233
			// (get) Token: 0x06000936 RID: 2358 RVA: 0x00026DF0 File Offset: 0x00024FF0
			public static PropertyKey ParsingPath
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 30);
					return result;
				}
			}

			// Token: 0x170004D2 RID: 1234
			// (get) Token: 0x06000937 RID: 2359 RVA: 0x00026E18 File Offset: 0x00025018
			public static PropertyKey PerceivedType
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 9);
					return result;
				}
			}

			// Token: 0x170004D3 RID: 1235
			// (get) Token: 0x06000938 RID: 2360 RVA: 0x00026E40 File Offset: 0x00025040
			public static PropertyKey PercentFull
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 5);
					return result;
				}
			}

			// Token: 0x170004D4 RID: 1236
			// (get) Token: 0x06000939 RID: 2361 RVA: 0x00026E68 File Offset: 0x00025068
			public static PropertyKey Priority
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 5);
					return result;
				}
			}

			// Token: 0x170004D5 RID: 1237
			// (get) Token: 0x0600093A RID: 2362 RVA: 0x00026E90 File Offset: 0x00025090
			public static PropertyKey PriorityText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D98BE98B-B86B-4095-BF52-9D23B2E0A752}"), 100);
					return result;
				}
			}

			// Token: 0x170004D6 RID: 1238
			// (get) Token: 0x0600093B RID: 2363 RVA: 0x00026EB8 File Offset: 0x000250B8
			public static PropertyKey Project
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{39A7F922-477C-48DE-8BC8-B28441E342E3}"), 100);
					return result;
				}
			}

			// Token: 0x170004D7 RID: 1239
			// (get) Token: 0x0600093C RID: 2364 RVA: 0x00026EE0 File Offset: 0x000250E0
			public static PropertyKey ProviderItemID
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F21D9941-81F0-471A-ADEE-4E74B49217ED}"), 100);
					return result;
				}
			}

			// Token: 0x170004D8 RID: 1240
			// (get) Token: 0x0600093D RID: 2365 RVA: 0x00026F08 File Offset: 0x00025108
			public static PropertyKey Rating
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 9);
					return result;
				}
			}

			// Token: 0x170004D9 RID: 1241
			// (get) Token: 0x0600093E RID: 2366 RVA: 0x00026F30 File Offset: 0x00025130
			public static PropertyKey RatingText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{90197CA7-FD8F-4E8C-9DA3-B57E1E609295}"), 100);
					return result;
				}
			}

			// Token: 0x170004DA RID: 1242
			// (get) Token: 0x0600093F RID: 2367 RVA: 0x00026F58 File Offset: 0x00025158
			public static PropertyKey Sensitivity
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F8D3F6AC-4874-42CB-BE59-AB454B30716A}"), 100);
					return result;
				}
			}

			// Token: 0x170004DB RID: 1243
			// (get) Token: 0x06000940 RID: 2368 RVA: 0x00026F80 File Offset: 0x00025180
			public static PropertyKey SensitivityText
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{D0C7F054-3F72-4725-8527-129A577CB269}"), 100);
					return result;
				}
			}

			// Token: 0x170004DC RID: 1244
			// (get) Token: 0x06000941 RID: 2369 RVA: 0x00026FA8 File Offset: 0x000251A8
			public static PropertyKey SFGAOFlags
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 25);
					return result;
				}
			}

			// Token: 0x170004DD RID: 1245
			// (get) Token: 0x06000942 RID: 2370 RVA: 0x00026FD0 File Offset: 0x000251D0
			public static PropertyKey SharedWith
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 200);
					return result;
				}
			}

			// Token: 0x170004DE RID: 1246
			// (get) Token: 0x06000943 RID: 2371 RVA: 0x00026FFC File Offset: 0x000251FC
			public static PropertyKey ShareUserRating
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 12);
					return result;
				}
			}

			// Token: 0x170004DF RID: 1247
			// (get) Token: 0x06000944 RID: 2372 RVA: 0x00027024 File Offset: 0x00025224
			public static PropertyKey SharingStatus
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902}"), 300);
					return result;
				}
			}

			// Token: 0x170004E0 RID: 1248
			// (get) Token: 0x06000945 RID: 2373 RVA: 0x00027050 File Offset: 0x00025250
			public static PropertyKey SimpleRating
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{A09F084E-AD41-489F-8076-AA5BE3082BCA}"), 100);
					return result;
				}
			}

			// Token: 0x170004E1 RID: 1249
			// (get) Token: 0x06000946 RID: 2374 RVA: 0x00027078 File Offset: 0x00025278
			public static PropertyKey Size
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 12);
					return result;
				}
			}

			// Token: 0x170004E2 RID: 1250
			// (get) Token: 0x06000947 RID: 2375 RVA: 0x000270A0 File Offset: 0x000252A0
			public static PropertyKey SoftwareUsed
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 305);
					return result;
				}
			}

			// Token: 0x170004E3 RID: 1251
			// (get) Token: 0x06000948 RID: 2376 RVA: 0x000270CC File Offset: 0x000252CC
			public static PropertyKey SourceItem
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{668CDFA5-7A1B-4323-AE4B-E527393A1D81}"), 100);
					return result;
				}
			}

			// Token: 0x170004E4 RID: 1252
			// (get) Token: 0x06000949 RID: 2377 RVA: 0x000270F4 File Offset: 0x000252F4
			public static PropertyKey StartDate
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE}"), 100);
					return result;
				}
			}

			// Token: 0x170004E5 RID: 1253
			// (get) Token: 0x0600094A RID: 2378 RVA: 0x0002711C File Offset: 0x0002531C
			public static PropertyKey Status
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{000214A1-0000-0000-C000-000000000046}"), 9);
					return result;
				}
			}

			// Token: 0x170004E6 RID: 1254
			// (get) Token: 0x0600094B RID: 2379 RVA: 0x00027144 File Offset: 0x00025344
			public static PropertyKey Subject
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 3);
					return result;
				}
			}

			// Token: 0x170004E7 RID: 1255
			// (get) Token: 0x0600094C RID: 2380 RVA: 0x0002716C File Offset: 0x0002536C
			public static PropertyKey Thumbnail
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 17);
					return result;
				}
			}

			// Token: 0x170004E8 RID: 1256
			// (get) Token: 0x0600094D RID: 2381 RVA: 0x00027194 File Offset: 0x00025394
			public static PropertyKey ThumbnailCacheId
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{446D16B1-8DAD-4870-A748-402EA43D788C}"), 100);
					return result;
				}
			}

			// Token: 0x170004E9 RID: 1257
			// (get) Token: 0x0600094E RID: 2382 RVA: 0x000271BC File Offset: 0x000253BC
			public static PropertyKey ThumbnailStream
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 27);
					return result;
				}
			}

			// Token: 0x170004EA RID: 1258
			// (get) Token: 0x0600094F RID: 2383 RVA: 0x000271E4 File Offset: 0x000253E4
			public static PropertyKey Title
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 2);
					return result;
				}
			}

			// Token: 0x170004EB RID: 1259
			// (get) Token: 0x06000950 RID: 2384 RVA: 0x0002720C File Offset: 0x0002540C
			public static PropertyKey TotalFileSize
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{28636AA6-953D-11D2-B5D6-00C04FD918D0}"), 14);
					return result;
				}
			}

			// Token: 0x170004EC RID: 1260
			// (get) Token: 0x06000951 RID: 2385 RVA: 0x00027234 File Offset: 0x00025434
			public static PropertyKey Trademarks
			{
				get
				{
					PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 9);
					return result;
				}
			}

			// Token: 0x020000EA RID: 234
			public static class AppUserModel
			{
				// Token: 0x170004ED RID: 1261
				// (get) Token: 0x06000952 RID: 2386 RVA: 0x0002725C File Offset: 0x0002545C
				public static PropertyKey ExcludeFromShowInNewInstall
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 8);
						return result;
					}
				}

				// Token: 0x170004EE RID: 1262
				// (get) Token: 0x06000953 RID: 2387 RVA: 0x00027284 File Offset: 0x00025484
				public static PropertyKey ID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 5);
						return result;
					}
				}

				// Token: 0x170004EF RID: 1263
				// (get) Token: 0x06000954 RID: 2388 RVA: 0x000272AC File Offset: 0x000254AC
				public static PropertyKey IsDestinationListSeparator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 6);
						return result;
					}
				}

				// Token: 0x170004F0 RID: 1264
				// (get) Token: 0x06000955 RID: 2389 RVA: 0x000272D4 File Offset: 0x000254D4
				public static PropertyKey PreventPinning
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 9);
						return result;
					}
				}

				// Token: 0x170004F1 RID: 1265
				// (get) Token: 0x06000956 RID: 2390 RVA: 0x000272FC File Offset: 0x000254FC
				public static PropertyKey RelaunchCommand
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 2);
						return result;
					}
				}

				// Token: 0x170004F2 RID: 1266
				// (get) Token: 0x06000957 RID: 2391 RVA: 0x00027324 File Offset: 0x00025524
				public static PropertyKey RelaunchDisplayNameResource
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 4);
						return result;
					}
				}

				// Token: 0x170004F3 RID: 1267
				// (get) Token: 0x06000958 RID: 2392 RVA: 0x0002734C File Offset: 0x0002554C
				public static PropertyKey RelaunchIconResource
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}"), 3);
						return result;
					}
				}
			}

			// Token: 0x020000EB RID: 235
			public static class Audio
			{
				// Token: 0x170004F4 RID: 1268
				// (get) Token: 0x06000959 RID: 2393 RVA: 0x00027374 File Offset: 0x00025574
				public static PropertyKey ChannelCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 7);
						return result;
					}
				}

				// Token: 0x170004F5 RID: 1269
				// (get) Token: 0x0600095A RID: 2394 RVA: 0x0002739C File Offset: 0x0002559C
				public static PropertyKey Compression
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 10);
						return result;
					}
				}

				// Token: 0x170004F6 RID: 1270
				// (get) Token: 0x0600095B RID: 2395 RVA: 0x000273C4 File Offset: 0x000255C4
				public static PropertyKey EncodingBitrate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 4);
						return result;
					}
				}

				// Token: 0x170004F7 RID: 1271
				// (get) Token: 0x0600095C RID: 2396 RVA: 0x000273EC File Offset: 0x000255EC
				public static PropertyKey Format
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 2);
						return result;
					}
				}

				// Token: 0x170004F8 RID: 1272
				// (get) Token: 0x0600095D RID: 2397 RVA: 0x00027414 File Offset: 0x00025614
				public static PropertyKey IsVariableBitrate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C}"), 100);
						return result;
					}
				}

				// Token: 0x170004F9 RID: 1273
				// (get) Token: 0x0600095E RID: 2398 RVA: 0x0002743C File Offset: 0x0002563C
				public static PropertyKey PeakValue
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E}"), 100);
						return result;
					}
				}

				// Token: 0x170004FA RID: 1274
				// (get) Token: 0x0600095F RID: 2399 RVA: 0x00027464 File Offset: 0x00025664
				public static PropertyKey SampleRate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 5);
						return result;
					}
				}

				// Token: 0x170004FB RID: 1275
				// (get) Token: 0x06000960 RID: 2400 RVA: 0x0002748C File Offset: 0x0002568C
				public static PropertyKey SampleSize
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 6);
						return result;
					}
				}

				// Token: 0x170004FC RID: 1276
				// (get) Token: 0x06000961 RID: 2401 RVA: 0x000274B4 File Offset: 0x000256B4
				public static PropertyKey StreamName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 9);
						return result;
					}
				}

				// Token: 0x170004FD RID: 1277
				// (get) Token: 0x06000962 RID: 2402 RVA: 0x000274DC File Offset: 0x000256DC
				public static PropertyKey StreamNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 8);
						return result;
					}
				}
			}

			// Token: 0x020000EC RID: 236
			public static class Calendar
			{
				// Token: 0x170004FE RID: 1278
				// (get) Token: 0x06000963 RID: 2403 RVA: 0x00027504 File Offset: 0x00025704
				public static PropertyKey Duration
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{293CA35A-09AA-4DD2-B180-1FE245728A52}"), 100);
						return result;
					}
				}

				// Token: 0x170004FF RID: 1279
				// (get) Token: 0x06000964 RID: 2404 RVA: 0x0002752C File Offset: 0x0002572C
				public static PropertyKey IsOnline
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BFEE9149-E3E2-49A7-A862-C05988145CEC}"), 100);
						return result;
					}
				}

				// Token: 0x17000500 RID: 1280
				// (get) Token: 0x06000965 RID: 2405 RVA: 0x00027554 File Offset: 0x00025754
				public static PropertyKey IsRecurring
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{315B9C8D-80A9-4EF9-AE16-8E746DA51D70}"), 100);
						return result;
					}
				}

				// Token: 0x17000501 RID: 1281
				// (get) Token: 0x06000966 RID: 2406 RVA: 0x0002757C File Offset: 0x0002577C
				public static PropertyKey Location
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F6272D18-CECC-40B1-B26A-3911717AA7BD}"), 100);
						return result;
					}
				}

				// Token: 0x17000502 RID: 1282
				// (get) Token: 0x06000967 RID: 2407 RVA: 0x000275A4 File Offset: 0x000257A4
				public static PropertyKey OptionalAttendeeAddresses
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D55BAE5A-3892-417A-A649-C6AC5AAAEAB3}"), 100);
						return result;
					}
				}

				// Token: 0x17000503 RID: 1283
				// (get) Token: 0x06000968 RID: 2408 RVA: 0x000275CC File Offset: 0x000257CC
				public static PropertyKey OptionalAttendeeNames
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{09429607-582D-437F-84C3-DE93A2B24C3C}"), 100);
						return result;
					}
				}

				// Token: 0x17000504 RID: 1284
				// (get) Token: 0x06000969 RID: 2409 RVA: 0x000275F4 File Offset: 0x000257F4
				public static PropertyKey OrganizerAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{744C8242-4DF5-456C-AB9E-014EFB9021E3}"), 100);
						return result;
					}
				}

				// Token: 0x17000505 RID: 1285
				// (get) Token: 0x0600096A RID: 2410 RVA: 0x0002761C File Offset: 0x0002581C
				public static PropertyKey OrganizerName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AAA660F9-9865-458E-B484-01BC7FE3973E}"), 100);
						return result;
					}
				}

				// Token: 0x17000506 RID: 1286
				// (get) Token: 0x0600096B RID: 2411 RVA: 0x00027644 File Offset: 0x00025844
				public static PropertyKey ReminderTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{72FC5BA4-24F9-4011-9F3F-ADD27AFAD818}"), 100);
						return result;
					}
				}

				// Token: 0x17000507 RID: 1287
				// (get) Token: 0x0600096C RID: 2412 RVA: 0x0002766C File Offset: 0x0002586C
				public static PropertyKey RequiredAttendeeAddresses
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0BA7D6C3-568D-4159-AB91-781A91FB71E5}"), 100);
						return result;
					}
				}

				// Token: 0x17000508 RID: 1288
				// (get) Token: 0x0600096D RID: 2413 RVA: 0x00027694 File Offset: 0x00025894
				public static PropertyKey RequiredAttendeeNames
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B33AF30B-F552-4584-936C-CB93E5CDA29F}"), 100);
						return result;
					}
				}

				// Token: 0x17000509 RID: 1289
				// (get) Token: 0x0600096E RID: 2414 RVA: 0x000276BC File Offset: 0x000258BC
				public static PropertyKey Resources
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{00F58A38-C54B-4C40-8696-97235980EAE1}"), 100);
						return result;
					}
				}

				// Token: 0x1700050A RID: 1290
				// (get) Token: 0x0600096F RID: 2415 RVA: 0x000276E4 File Offset: 0x000258E4
				public static PropertyKey ResponseStatus
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{188C1F91-3C40-4132-9EC5-D8B03B72A8A2}"), 100);
						return result;
					}
				}

				// Token: 0x1700050B RID: 1291
				// (get) Token: 0x06000970 RID: 2416 RVA: 0x0002770C File Offset: 0x0002590C
				public static PropertyKey ShowTimeAs
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E}"), 100);
						return result;
					}
				}

				// Token: 0x1700050C RID: 1292
				// (get) Token: 0x06000971 RID: 2417 RVA: 0x00027734 File Offset: 0x00025934
				public static PropertyKey ShowTimeAsText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{53DA57CF-62C0-45C4-81DE-7610BCEFD7F5}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000ED RID: 237
			public static class Communication
			{
				// Token: 0x1700050D RID: 1293
				// (get) Token: 0x06000972 RID: 2418 RVA: 0x0002775C File Offset: 0x0002595C
				public static PropertyKey AccountName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 9);
						return result;
					}
				}

				// Token: 0x1700050E RID: 1294
				// (get) Token: 0x06000973 RID: 2419 RVA: 0x00027784 File Offset: 0x00025984
				public static PropertyKey DateItemExpires
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{428040AC-A177-4C8A-9760-F6F761227F9A}"), 100);
						return result;
					}
				}

				// Token: 0x1700050F RID: 1295
				// (get) Token: 0x06000974 RID: 2420 RVA: 0x000277AC File Offset: 0x000259AC
				public static PropertyKey FollowUpIconIndex
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{83A6347E-6FE4-4F40-BA9C-C4865240D1F4}"), 100);
						return result;
					}
				}

				// Token: 0x17000510 RID: 1296
				// (get) Token: 0x06000975 RID: 2421 RVA: 0x000277D4 File Offset: 0x000259D4
				public static PropertyKey HeaderItem
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9C34F84-2241-4401-B607-BD20ED75AE7F}"), 100);
						return result;
					}
				}

				// Token: 0x17000511 RID: 1297
				// (get) Token: 0x06000976 RID: 2422 RVA: 0x000277FC File Offset: 0x000259FC
				public static PropertyKey PolicyTag
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}"), 100);
						return result;
					}
				}

				// Token: 0x17000512 RID: 1298
				// (get) Token: 0x06000977 RID: 2423 RVA: 0x00027824 File Offset: 0x00025A24
				public static PropertyKey SecurityFlags
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8619A4B6-9F4D-4429-8C0F-B996CA59E335}"), 100);
						return result;
					}
				}

				// Token: 0x17000513 RID: 1299
				// (get) Token: 0x06000978 RID: 2424 RVA: 0x0002784C File Offset: 0x00025A4C
				public static PropertyKey Suffix
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{807B653A-9E91-43EF-8F97-11CE04EE20C5}"), 100);
						return result;
					}
				}

				// Token: 0x17000514 RID: 1300
				// (get) Token: 0x06000979 RID: 2425 RVA: 0x00027874 File Offset: 0x00025A74
				public static PropertyKey TaskStatus
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999}"), 100);
						return result;
					}
				}

				// Token: 0x17000515 RID: 1301
				// (get) Token: 0x0600097A RID: 2426 RVA: 0x0002789C File Offset: 0x00025A9C
				public static PropertyKey TaskStatusText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A6744477-C237-475B-A075-54F34498292A}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000EE RID: 238
			public static class Computer
			{
				// Token: 0x17000516 RID: 1302
				// (get) Token: 0x0600097B RID: 2427 RVA: 0x000278C4 File Offset: 0x00025AC4
				public static PropertyKey DecoratedFreeSpace
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 7);
						return result;
					}
				}
			}

			// Token: 0x020000EF RID: 239
			public static class Contact
			{
				// Token: 0x17000517 RID: 1303
				// (get) Token: 0x0600097C RID: 2428 RVA: 0x000278EC File Offset: 0x00025AEC
				public static PropertyKey Anniversary
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9AD5BADB-CEA7-4470-A03D-B84E51B9949E}"), 100);
						return result;
					}
				}

				// Token: 0x17000518 RID: 1304
				// (get) Token: 0x0600097D RID: 2429 RVA: 0x00027914 File Offset: 0x00025B14
				public static PropertyKey AssistantName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CD102C9C-5540-4A88-A6F6-64E4981C8CD1}"), 100);
						return result;
					}
				}

				// Token: 0x17000519 RID: 1305
				// (get) Token: 0x0600097E RID: 2430 RVA: 0x0002793C File Offset: 0x00025B3C
				public static PropertyKey AssistantTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9A93244D-A7AD-4FF8-9B99-45EE4CC09AF6}"), 100);
						return result;
					}
				}

				// Token: 0x1700051A RID: 1306
				// (get) Token: 0x0600097F RID: 2431 RVA: 0x00027964 File Offset: 0x00025B64
				public static PropertyKey Birthday
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 47);
						return result;
					}
				}

				// Token: 0x1700051B RID: 1307
				// (get) Token: 0x06000980 RID: 2432 RVA: 0x0002798C File Offset: 0x00025B8C
				public static PropertyKey BusinessAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{730FB6DD-CF7C-426B-A03F-BD166CC9EE24}"), 100);
						return result;
					}
				}

				// Token: 0x1700051C RID: 1308
				// (get) Token: 0x06000981 RID: 2433 RVA: 0x000279B4 File Offset: 0x00025BB4
				public static PropertyKey BusinessAddressCity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{402B5934-EC5A-48C3-93E6-85E86A2D934E}"), 100);
						return result;
					}
				}

				// Token: 0x1700051D RID: 1309
				// (get) Token: 0x06000982 RID: 2434 RVA: 0x000279DC File Offset: 0x00025BDC
				public static PropertyKey BusinessAddressCountry
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B0B87314-FCF6-4FEB-8DFF-A50DA6AF561C}"), 100);
						return result;
					}
				}

				// Token: 0x1700051E RID: 1310
				// (get) Token: 0x06000983 RID: 2435 RVA: 0x00027A04 File Offset: 0x00025C04
				public static PropertyKey BusinessAddressPostalCode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E1D4A09E-D758-4CD1-B6EC-34A8B5A73F80}"), 100);
						return result;
					}
				}

				// Token: 0x1700051F RID: 1311
				// (get) Token: 0x06000984 RID: 2436 RVA: 0x00027A2C File Offset: 0x00025C2C
				public static PropertyKey BusinessAddressPostOfficeBox
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BC4E71CE-17F9-48D5-BEE9-021DF0EA5409}"), 100);
						return result;
					}
				}

				// Token: 0x17000520 RID: 1312
				// (get) Token: 0x06000985 RID: 2437 RVA: 0x00027A54 File Offset: 0x00025C54
				public static PropertyKey BusinessAddressState
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{446F787F-10C4-41CB-A6C4-4D0343551597}"), 100);
						return result;
					}
				}

				// Token: 0x17000521 RID: 1313
				// (get) Token: 0x06000986 RID: 2438 RVA: 0x00027A7C File Offset: 0x00025C7C
				public static PropertyKey BusinessAddressStreet
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DDD1460F-C0BF-4553-8CE4-10433C908FB0}"), 100);
						return result;
					}
				}

				// Token: 0x17000522 RID: 1314
				// (get) Token: 0x06000987 RID: 2439 RVA: 0x00027AA4 File Offset: 0x00025CA4
				public static PropertyKey BusinessFaxNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{91EFF6F3-2E27-42CA-933E-7C999FBE310B}"), 100);
						return result;
					}
				}

				// Token: 0x17000523 RID: 1315
				// (get) Token: 0x06000988 RID: 2440 RVA: 0x00027ACC File Offset: 0x00025CCC
				public static PropertyKey BusinessHomepage
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56310920-2491-4919-99CE-EADB06FAFDB2}"), 100);
						return result;
					}
				}

				// Token: 0x17000524 RID: 1316
				// (get) Token: 0x06000989 RID: 2441 RVA: 0x00027AF4 File Offset: 0x00025CF4
				public static PropertyKey BusinessTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6A15E5A0-0A1E-4CD7-BB8C-D2F1B0C929BC}"), 100);
						return result;
					}
				}

				// Token: 0x17000525 RID: 1317
				// (get) Token: 0x0600098A RID: 2442 RVA: 0x00027B1C File Offset: 0x00025D1C
				public static PropertyKey CallbackTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BF53D1C3-49E0-4F7F-8567-5A821D8AC542}"), 100);
						return result;
					}
				}

				// Token: 0x17000526 RID: 1318
				// (get) Token: 0x0600098B RID: 2443 RVA: 0x00027B44 File Offset: 0x00025D44
				public static PropertyKey CarTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8FDC6DEA-B929-412B-BA90-397A257465FE}"), 100);
						return result;
					}
				}

				// Token: 0x17000527 RID: 1319
				// (get) Token: 0x0600098C RID: 2444 RVA: 0x00027B6C File Offset: 0x00025D6C
				public static PropertyKey Children
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D4729704-8EF1-43EF-9024-2BD381187FD5}"), 100);
						return result;
					}
				}

				// Token: 0x17000528 RID: 1320
				// (get) Token: 0x0600098D RID: 2445 RVA: 0x00027B94 File Offset: 0x00025D94
				public static PropertyKey CompanyMainTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8589E481-6040-473D-B171-7FA89C2708ED}"), 100);
						return result;
					}
				}

				// Token: 0x17000529 RID: 1321
				// (get) Token: 0x0600098E RID: 2446 RVA: 0x00027BBC File Offset: 0x00025DBC
				public static PropertyKey Department
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FC9F7306-FF8F-4D49-9FB6-3FFE5C0951EC}"), 100);
						return result;
					}
				}

				// Token: 0x1700052A RID: 1322
				// (get) Token: 0x0600098F RID: 2447 RVA: 0x00027BE4 File Offset: 0x00025DE4
				public static PropertyKey EmailAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F8FA7FA3-D12B-4785-8A4E-691A94F7A3E7}"), 100);
						return result;
					}
				}

				// Token: 0x1700052B RID: 1323
				// (get) Token: 0x06000990 RID: 2448 RVA: 0x00027C0C File Offset: 0x00025E0C
				public static PropertyKey EmailAddress2
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{38965063-EDC8-4268-8491-B7723172CF29}"), 100);
						return result;
					}
				}

				// Token: 0x1700052C RID: 1324
				// (get) Token: 0x06000991 RID: 2449 RVA: 0x00027C34 File Offset: 0x00025E34
				public static PropertyKey EmailAddress3
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{644D37B4-E1B3-4BAD-B099-7E7C04966ACA}"), 100);
						return result;
					}
				}

				// Token: 0x1700052D RID: 1325
				// (get) Token: 0x06000992 RID: 2450 RVA: 0x00027C5C File Offset: 0x00025E5C
				public static PropertyKey EmailAddresses
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{84D8F337-981D-44B3-9615-C7596DBA17E3}"), 100);
						return result;
					}
				}

				// Token: 0x1700052E RID: 1326
				// (get) Token: 0x06000993 RID: 2451 RVA: 0x00027C84 File Offset: 0x00025E84
				public static PropertyKey EmailName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CC6F4F24-6083-4BD4-8754-674D0DE87AB8}"), 100);
						return result;
					}
				}

				// Token: 0x1700052F RID: 1327
				// (get) Token: 0x06000994 RID: 2452 RVA: 0x00027CAC File Offset: 0x00025EAC
				public static PropertyKey FileAsName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F1A24AA7-9CA7-40F6-89EC-97DEF9FFE8DB}"), 100);
						return result;
					}
				}

				// Token: 0x17000530 RID: 1328
				// (get) Token: 0x06000995 RID: 2453 RVA: 0x00027CD4 File Offset: 0x00025ED4
				public static PropertyKey FirstName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14977844-6B49-4AAD-A714-A4513BF60460}"), 100);
						return result;
					}
				}

				// Token: 0x17000531 RID: 1329
				// (get) Token: 0x06000996 RID: 2454 RVA: 0x00027CFC File Offset: 0x00025EFC
				public static PropertyKey FullName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{635E9051-50A5-4BA2-B9DB-4ED056C77296}"), 100);
						return result;
					}
				}

				// Token: 0x17000532 RID: 1330
				// (get) Token: 0x06000997 RID: 2455 RVA: 0x00027D24 File Offset: 0x00025F24
				public static PropertyKey Gender
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 100);
						return result;
					}
				}

				// Token: 0x17000533 RID: 1331
				// (get) Token: 0x06000998 RID: 2456 RVA: 0x00027D4C File Offset: 0x00025F4C
				public static PropertyKey GenderValue
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3C8CEE58-D4F0-4CF9-B756-4E5D24447BCD}"), 101);
						return result;
					}
				}

				// Token: 0x17000534 RID: 1332
				// (get) Token: 0x06000999 RID: 2457 RVA: 0x00027D74 File Offset: 0x00025F74
				public static PropertyKey Hobbies
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{5DC2253F-5E11-4ADF-9CFE-910DD01E3E70}"), 100);
						return result;
					}
				}

				// Token: 0x17000535 RID: 1333
				// (get) Token: 0x0600099A RID: 2458 RVA: 0x00027D9C File Offset: 0x00025F9C
				public static PropertyKey HomeAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{98F98354-617A-46B8-8560-5B1B64BF1F89}"), 100);
						return result;
					}
				}

				// Token: 0x17000536 RID: 1334
				// (get) Token: 0x0600099B RID: 2459 RVA: 0x00027DC4 File Offset: 0x00025FC4
				public static PropertyKey HomeAddressCity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 65);
						return result;
					}
				}

				// Token: 0x17000537 RID: 1335
				// (get) Token: 0x0600099C RID: 2460 RVA: 0x00027DEC File Offset: 0x00025FEC
				public static PropertyKey HomeAddressCountry
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{08A65AA1-F4C9-43DD-9DDF-A33D8E7EAD85}"), 100);
						return result;
					}
				}

				// Token: 0x17000538 RID: 1336
				// (get) Token: 0x0600099D RID: 2461 RVA: 0x00027E14 File Offset: 0x00026014
				public static PropertyKey HomeAddressPostalCode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8AFCC170-8A46-4B53-9EEE-90BAE7151E62}"), 100);
						return result;
					}
				}

				// Token: 0x17000539 RID: 1337
				// (get) Token: 0x0600099E RID: 2462 RVA: 0x00027E3C File Offset: 0x0002603C
				public static PropertyKey HomeAddressPostOfficeBox
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7B9F6399-0A3F-4B12-89BD-4ADC51C918AF}"), 100);
						return result;
					}
				}

				// Token: 0x1700053A RID: 1338
				// (get) Token: 0x0600099F RID: 2463 RVA: 0x00027E64 File Offset: 0x00026064
				public static PropertyKey HomeAddressState
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C89A23D0-7D6D-4EB8-87D4-776A82D493E5}"), 100);
						return result;
					}
				}

				// Token: 0x1700053B RID: 1339
				// (get) Token: 0x060009A0 RID: 2464 RVA: 0x00027E8C File Offset: 0x0002608C
				public static PropertyKey HomeAddressStreet
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0ADEF160-DB3F-4308-9A21-06237B16FA2A}"), 100);
						return result;
					}
				}

				// Token: 0x1700053C RID: 1340
				// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00027EB4 File Offset: 0x000260B4
				public static PropertyKey HomeFaxNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{660E04D6-81AB-4977-A09F-82313113AB26}"), 100);
						return result;
					}
				}

				// Token: 0x1700053D RID: 1341
				// (get) Token: 0x060009A2 RID: 2466 RVA: 0x00027EDC File Offset: 0x000260DC
				public static PropertyKey HomeTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 20);
						return result;
					}
				}

				// Token: 0x1700053E RID: 1342
				// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00027F04 File Offset: 0x00026104
				public static PropertyKey IMAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D68DBD8A-3374-4B81-9972-3EC30682DB3D}"), 100);
						return result;
					}
				}

				// Token: 0x1700053F RID: 1343
				// (get) Token: 0x060009A4 RID: 2468 RVA: 0x00027F2C File Offset: 0x0002612C
				public static PropertyKey Initials
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F3D8F40D-50CB-44A2-9718-40CB9119495D}"), 100);
						return result;
					}
				}

				// Token: 0x17000540 RID: 1344
				// (get) Token: 0x060009A5 RID: 2469 RVA: 0x00027F54 File Offset: 0x00026154
				public static PropertyKey JobTitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 6);
						return result;
					}
				}

				// Token: 0x17000541 RID: 1345
				// (get) Token: 0x060009A6 RID: 2470 RVA: 0x00027F7C File Offset: 0x0002617C
				public static PropertyKey Label
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{97B0AD89-DF49-49CC-834E-660974FD755B}"), 100);
						return result;
					}
				}

				// Token: 0x17000542 RID: 1346
				// (get) Token: 0x060009A7 RID: 2471 RVA: 0x00027FA4 File Offset: 0x000261A4
				public static PropertyKey LastName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8F367200-C270-457C-B1D4-E07C5BCD90C7}"), 100);
						return result;
					}
				}

				// Token: 0x17000543 RID: 1347
				// (get) Token: 0x060009A8 RID: 2472 RVA: 0x00027FCC File Offset: 0x000261CC
				public static PropertyKey MailingAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C0AC206A-827E-4650-95AE-77E2BB74FCC9}"), 100);
						return result;
					}
				}

				// Token: 0x17000544 RID: 1348
				// (get) Token: 0x060009A9 RID: 2473 RVA: 0x00027FF4 File Offset: 0x000261F4
				public static PropertyKey MiddleName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 71);
						return result;
					}
				}

				// Token: 0x17000545 RID: 1349
				// (get) Token: 0x060009AA RID: 2474 RVA: 0x0002801C File Offset: 0x0002621C
				public static PropertyKey MobileTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 35);
						return result;
					}
				}

				// Token: 0x17000546 RID: 1350
				// (get) Token: 0x060009AB RID: 2475 RVA: 0x00028044 File Offset: 0x00026244
				public static PropertyKey Nickname
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 74);
						return result;
					}
				}

				// Token: 0x17000547 RID: 1351
				// (get) Token: 0x060009AC RID: 2476 RVA: 0x0002806C File Offset: 0x0002626C
				public static PropertyKey OfficeLocation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 7);
						return result;
					}
				}

				// Token: 0x17000548 RID: 1352
				// (get) Token: 0x060009AD RID: 2477 RVA: 0x00028094 File Offset: 0x00026294
				public static PropertyKey OtherAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{508161FA-313B-43D5-83A1-C1ACCF68622C}"), 100);
						return result;
					}
				}

				// Token: 0x17000549 RID: 1353
				// (get) Token: 0x060009AE RID: 2478 RVA: 0x000280BC File Offset: 0x000262BC
				public static PropertyKey OtherAddressCity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6E682923-7F7B-4F0C-A337-CFCA296687BF}"), 100);
						return result;
					}
				}

				// Token: 0x1700054A RID: 1354
				// (get) Token: 0x060009AF RID: 2479 RVA: 0x000280E4 File Offset: 0x000262E4
				public static PropertyKey OtherAddressCountry
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8F167568-0AAE-4322-8ED9-6055B7B0E398}"), 100);
						return result;
					}
				}

				// Token: 0x1700054B RID: 1355
				// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0002810C File Offset: 0x0002630C
				public static PropertyKey OtherAddressPostalCode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{95C656C1-2ABF-4148-9ED3-9EC602E3B7CD}"), 100);
						return result;
					}
				}

				// Token: 0x1700054C RID: 1356
				// (get) Token: 0x060009B1 RID: 2481 RVA: 0x00028134 File Offset: 0x00026334
				public static PropertyKey OtherAddressPostOfficeBox
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8B26EA41-058F-43F6-AECC-4035681CE977}"), 100);
						return result;
					}
				}

				// Token: 0x1700054D RID: 1357
				// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0002815C File Offset: 0x0002635C
				public static PropertyKey OtherAddressState
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{71B377D6-E570-425F-A170-809FAE73E54E}"), 100);
						return result;
					}
				}

				// Token: 0x1700054E RID: 1358
				// (get) Token: 0x060009B3 RID: 2483 RVA: 0x00028184 File Offset: 0x00026384
				public static PropertyKey OtherAddressStreet
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FF962609-B7D6-4999-862D-95180D529AEA}"), 100);
						return result;
					}
				}

				// Token: 0x1700054F RID: 1359
				// (get) Token: 0x060009B4 RID: 2484 RVA: 0x000281AC File Offset: 0x000263AC
				public static PropertyKey PagerTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D6304E01-F8F5-4F45-8B15-D024A6296789}"), 100);
						return result;
					}
				}

				// Token: 0x17000550 RID: 1360
				// (get) Token: 0x060009B5 RID: 2485 RVA: 0x000281D4 File Offset: 0x000263D4
				public static PropertyKey PersonalTitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 69);
						return result;
					}
				}

				// Token: 0x17000551 RID: 1361
				// (get) Token: 0x060009B6 RID: 2486 RVA: 0x000281FC File Offset: 0x000263FC
				public static PropertyKey PrimaryAddressCity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C8EA94F0-A9E3-4969-A94B-9C62A95324E0}"), 100);
						return result;
					}
				}

				// Token: 0x17000552 RID: 1362
				// (get) Token: 0x060009B7 RID: 2487 RVA: 0x00028224 File Offset: 0x00026424
				public static PropertyKey PrimaryAddressCountry
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E53D799D-0F3F-466E-B2FF-74634A3CB7A4}"), 100);
						return result;
					}
				}

				// Token: 0x17000553 RID: 1363
				// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0002824C File Offset: 0x0002644C
				public static PropertyKey PrimaryAddressPostalCode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{18BBD425-ECFD-46EF-B612-7B4A6034EDA0}"), 100);
						return result;
					}
				}

				// Token: 0x17000554 RID: 1364
				// (get) Token: 0x060009B9 RID: 2489 RVA: 0x00028274 File Offset: 0x00026474
				public static PropertyKey PrimaryAddressPostOfficeBox
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DE5EF3C7-46E1-484E-9999-62C5308394C1}"), 100);
						return result;
					}
				}

				// Token: 0x17000555 RID: 1365
				// (get) Token: 0x060009BA RID: 2490 RVA: 0x0002829C File Offset: 0x0002649C
				public static PropertyKey PrimaryAddressState
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F1176DFE-7138-4640-8B4C-AE375DC70A6D}"), 100);
						return result;
					}
				}

				// Token: 0x17000556 RID: 1366
				// (get) Token: 0x060009BB RID: 2491 RVA: 0x000282C4 File Offset: 0x000264C4
				public static PropertyKey PrimaryAddressStreet
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{63C25B20-96BE-488F-8788-C09C407AD812}"), 100);
						return result;
					}
				}

				// Token: 0x17000557 RID: 1367
				// (get) Token: 0x060009BC RID: 2492 RVA: 0x000282EC File Offset: 0x000264EC
				public static PropertyKey PrimaryEmailAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 48);
						return result;
					}
				}

				// Token: 0x17000558 RID: 1368
				// (get) Token: 0x060009BD RID: 2493 RVA: 0x00028314 File Offset: 0x00026514
				public static PropertyKey PrimaryTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 25);
						return result;
					}
				}

				// Token: 0x17000559 RID: 1369
				// (get) Token: 0x060009BE RID: 2494 RVA: 0x0002833C File Offset: 0x0002653C
				public static PropertyKey Profession
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7268AF55-1CE4-4F6E-A41F-B6E4EF10E4A9}"), 100);
						return result;
					}
				}

				// Token: 0x1700055A RID: 1370
				// (get) Token: 0x060009BF RID: 2495 RVA: 0x00028364 File Offset: 0x00026564
				public static PropertyKey SpouseName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9D2408B6-3167-422B-82B0-F583B7A7CFE3}"), 100);
						return result;
					}
				}

				// Token: 0x1700055B RID: 1371
				// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0002838C File Offset: 0x0002658C
				public static PropertyKey Suffix
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{176DC63C-2688-4E89-8143-A347800F25E9}"), 73);
						return result;
					}
				}

				// Token: 0x1700055C RID: 1372
				// (get) Token: 0x060009C1 RID: 2497 RVA: 0x000283B4 File Offset: 0x000265B4
				public static PropertyKey TelexNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C554493C-C1F7-40C1-A76C-EF8C0614003E}"), 100);
						return result;
					}
				}

				// Token: 0x1700055D RID: 1373
				// (get) Token: 0x060009C2 RID: 2498 RVA: 0x000283DC File Offset: 0x000265DC
				public static PropertyKey TTYTDDTelephone
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AAF16BAC-2B55-45E6-9F6D-415EB94910DF}"), 100);
						return result;
					}
				}

				// Token: 0x1700055E RID: 1374
				// (get) Token: 0x060009C3 RID: 2499 RVA: 0x00028404 File Offset: 0x00026604
				public static PropertyKey Webpage
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 18);
						return result;
					}
				}

				// Token: 0x020000F0 RID: 240
				public static class JA
				{
					// Token: 0x1700055F RID: 1375
					// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0002842C File Offset: 0x0002662C
					public static PropertyKey CompanyNamePhonetic
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 2);
							return result;
						}
					}

					// Token: 0x17000560 RID: 1376
					// (get) Token: 0x060009C5 RID: 2501 RVA: 0x00028454 File Offset: 0x00026654
					public static PropertyKey FirstNamePhonetic
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 3);
							return result;
						}
					}

					// Token: 0x17000561 RID: 1377
					// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0002847C File Offset: 0x0002667C
					public static PropertyKey LastNamePhonetic
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 4);
							return result;
						}
					}
				}
			}

			// Token: 0x020000F1 RID: 241
			public static class JA
			{
				// Token: 0x17000562 RID: 1378
				// (get) Token: 0x060009C7 RID: 2503 RVA: 0x000284A4 File Offset: 0x000266A4
				public static PropertyKey CompanyNamePhonetic
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 2);
						return result;
					}
				}

				// Token: 0x17000563 RID: 1379
				// (get) Token: 0x060009C8 RID: 2504 RVA: 0x000284CC File Offset: 0x000266CC
				public static PropertyKey FirstNamePhonetic
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 3);
						return result;
					}
				}

				// Token: 0x17000564 RID: 1380
				// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000284F4 File Offset: 0x000266F4
				public static PropertyKey LastNamePhonetic
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{897B3694-FE9E-43E6-8066-260F590C0100}"), 4);
						return result;
					}
				}
			}

			// Token: 0x020000F2 RID: 242
			public static class Device
			{
				// Token: 0x17000565 RID: 1381
				// (get) Token: 0x060009CA RID: 2506 RVA: 0x0002851C File Offset: 0x0002671C
				public static PropertyKey PrinterUrl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B48F35A-BE6E-4F17-B108-3C4073D1669A}"), 15);
						return result;
					}
				}
			}

			// Token: 0x020000F3 RID: 243
			public static class DeviceInterface
			{
				// Token: 0x17000566 RID: 1382
				// (get) Token: 0x060009CB RID: 2507 RVA: 0x00028544 File Offset: 0x00026744
				public static PropertyKey PrinterDriverDirectory
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}"), 14);
						return result;
					}
				}

				// Token: 0x17000567 RID: 1383
				// (get) Token: 0x060009CC RID: 2508 RVA: 0x0002856C File Offset: 0x0002676C
				public static PropertyKey PrinterDriverName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AFC47170-14F5-498C-8F30-B0D19BE449C6}"), 11);
						return result;
					}
				}

				// Token: 0x17000568 RID: 1384
				// (get) Token: 0x060009CD RID: 2509 RVA: 0x00028594 File Offset: 0x00026794
				public static PropertyKey PrinterName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0A7B84EF-0C27-463F-84EF-06C5070001BE}"), 10);
						return result;
					}
				}

				// Token: 0x17000569 RID: 1385
				// (get) Token: 0x060009CE RID: 2510 RVA: 0x000285BC File Offset: 0x000267BC
				public static PropertyKey PrinterPortName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{EEC7B761-6F94-41B1-949F-C729720DD13C}"), 12);
						return result;
					}
				}
			}

			// Token: 0x020000F4 RID: 244
			public static class Devices
			{
				// Token: 0x1700056A RID: 1386
				// (get) Token: 0x060009CF RID: 2511 RVA: 0x000285E4 File Offset: 0x000267E4
				public static PropertyKey BatteryLife
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 10);
						return result;
					}
				}

				// Token: 0x1700056B RID: 1387
				// (get) Token: 0x060009D0 RID: 2512 RVA: 0x0002860C File Offset: 0x0002680C
				public static PropertyKey BatteryPlusCharging
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 22);
						return result;
					}
				}

				// Token: 0x1700056C RID: 1388
				// (get) Token: 0x060009D1 RID: 2513 RVA: 0x00028634 File Offset: 0x00026834
				public static PropertyKey BatteryPlusChargingText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 23);
						return result;
					}
				}

				// Token: 0x1700056D RID: 1389
				// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0002865C File Offset: 0x0002685C
				public static PropertyKey Category
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 91);
						return result;
					}
				}

				// Token: 0x1700056E RID: 1390
				// (get) Token: 0x060009D3 RID: 2515 RVA: 0x00028684 File Offset: 0x00026884
				public static PropertyKey CategoryGroup
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 94);
						return result;
					}
				}

				// Token: 0x1700056F RID: 1391
				// (get) Token: 0x060009D4 RID: 2516 RVA: 0x000286AC File Offset: 0x000268AC
				public static PropertyKey CategoryPlural
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 92);
						return result;
					}
				}

				// Token: 0x17000570 RID: 1392
				// (get) Token: 0x060009D5 RID: 2517 RVA: 0x000286D4 File Offset: 0x000268D4
				public static PropertyKey ChargingState
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 11);
						return result;
					}
				}

				// Token: 0x17000571 RID: 1393
				// (get) Token: 0x060009D6 RID: 2518 RVA: 0x000286FC File Offset: 0x000268FC
				public static PropertyKey Connected
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 55);
						return result;
					}
				}

				// Token: 0x17000572 RID: 1394
				// (get) Token: 0x060009D7 RID: 2519 RVA: 0x00028724 File Offset: 0x00026924
				public static PropertyKey ContainerId
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}"), 2);
						return result;
					}
				}

				// Token: 0x17000573 RID: 1395
				// (get) Token: 0x060009D8 RID: 2520 RVA: 0x0002874C File Offset: 0x0002694C
				public static PropertyKey DefaultTooltip
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 153);
						return result;
					}
				}

				// Token: 0x17000574 RID: 1396
				// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00028778 File Offset: 0x00026978
				public static PropertyKey DeviceDescription1
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 81);
						return result;
					}
				}

				// Token: 0x17000575 RID: 1397
				// (get) Token: 0x060009DA RID: 2522 RVA: 0x000287A0 File Offset: 0x000269A0
				public static PropertyKey DeviceDescription2
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 82);
						return result;
					}
				}

				// Token: 0x17000576 RID: 1398
				// (get) Token: 0x060009DB RID: 2523 RVA: 0x000287C8 File Offset: 0x000269C8
				public static PropertyKey DiscoveryMethod
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 52);
						return result;
					}
				}

				// Token: 0x17000577 RID: 1399
				// (get) Token: 0x060009DC RID: 2524 RVA: 0x000287F0 File Offset: 0x000269F0
				public static PropertyKey FriendlyName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 12288);
						return result;
					}
				}

				// Token: 0x17000578 RID: 1400
				// (get) Token: 0x060009DD RID: 2525 RVA: 0x0002881C File Offset: 0x00026A1C
				public static PropertyKey FunctionPaths
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 3);
						return result;
					}
				}

				// Token: 0x17000579 RID: 1401
				// (get) Token: 0x060009DE RID: 2526 RVA: 0x00028844 File Offset: 0x00026A44
				public static PropertyKey InterfacePaths
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 2);
						return result;
					}
				}

				// Token: 0x1700057A RID: 1402
				// (get) Token: 0x060009DF RID: 2527 RVA: 0x0002886C File Offset: 0x00026A6C
				public static PropertyKey IsDefault
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 86);
						return result;
					}
				}

				// Token: 0x1700057B RID: 1403
				// (get) Token: 0x060009E0 RID: 2528 RVA: 0x00028894 File Offset: 0x00026A94
				public static PropertyKey IsNetworkConnected
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 85);
						return result;
					}
				}

				// Token: 0x1700057C RID: 1404
				// (get) Token: 0x060009E1 RID: 2529 RVA: 0x000288BC File Offset: 0x00026ABC
				public static PropertyKey IsShared
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 84);
						return result;
					}
				}

				// Token: 0x1700057D RID: 1405
				// (get) Token: 0x060009E2 RID: 2530 RVA: 0x000288E4 File Offset: 0x00026AE4
				public static PropertyKey IsSoftwareInstalling
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{83DA6326-97A6-4088-9453-A1923F573B29}"), 9);
						return result;
					}
				}

				// Token: 0x1700057E RID: 1406
				// (get) Token: 0x060009E3 RID: 2531 RVA: 0x0002890C File Offset: 0x00026B0C
				public static PropertyKey LaunchDeviceStageFromExplorer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 77);
						return result;
					}
				}

				// Token: 0x1700057F RID: 1407
				// (get) Token: 0x060009E4 RID: 2532 RVA: 0x00028934 File Offset: 0x00026B34
				public static PropertyKey LocalMachine
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 70);
						return result;
					}
				}

				// Token: 0x17000580 RID: 1408
				// (get) Token: 0x060009E5 RID: 2533 RVA: 0x0002895C File Offset: 0x00026B5C
				public static PropertyKey Manufacturer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8192);
						return result;
					}
				}

				// Token: 0x17000581 RID: 1409
				// (get) Token: 0x060009E6 RID: 2534 RVA: 0x00028988 File Offset: 0x00026B88
				public static PropertyKey MissedCalls
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 5);
						return result;
					}
				}

				// Token: 0x17000582 RID: 1410
				// (get) Token: 0x060009E7 RID: 2535 RVA: 0x000289B0 File Offset: 0x00026BB0
				public static PropertyKey ModelName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8194);
						return result;
					}
				}

				// Token: 0x17000583 RID: 1411
				// (get) Token: 0x060009E8 RID: 2536 RVA: 0x000289DC File Offset: 0x00026BDC
				public static PropertyKey ModelNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}"), 8195);
						return result;
					}
				}

				// Token: 0x17000584 RID: 1412
				// (get) Token: 0x060009E9 RID: 2537 RVA: 0x00028A08 File Offset: 0x00026C08
				public static PropertyKey NetworkedTooltip
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 152);
						return result;
					}
				}

				// Token: 0x17000585 RID: 1413
				// (get) Token: 0x060009EA RID: 2538 RVA: 0x00028A34 File Offset: 0x00026C34
				public static PropertyKey NetworkName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 7);
						return result;
					}
				}

				// Token: 0x17000586 RID: 1414
				// (get) Token: 0x060009EB RID: 2539 RVA: 0x00028A5C File Offset: 0x00026C5C
				public static PropertyKey NetworkType
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 8);
						return result;
					}
				}

				// Token: 0x17000587 RID: 1415
				// (get) Token: 0x060009EC RID: 2540 RVA: 0x00028A84 File Offset: 0x00026C84
				public static PropertyKey NewPictures
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 4);
						return result;
					}
				}

				// Token: 0x17000588 RID: 1416
				// (get) Token: 0x060009ED RID: 2541 RVA: 0x00028AAC File Offset: 0x00026CAC
				public static PropertyKey Notification
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 3);
						return result;
					}
				}

				// Token: 0x17000589 RID: 1417
				// (get) Token: 0x060009EE RID: 2542 RVA: 0x00028AD4 File Offset: 0x00026CD4
				public static PropertyKey NotificationStore
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{06704B0C-E830-4C81-9178-91E4E95A80A0}"), 2);
						return result;
					}
				}

				// Token: 0x1700058A RID: 1418
				// (get) Token: 0x060009EF RID: 2543 RVA: 0x00028AFC File Offset: 0x00026CFC
				public static PropertyKey NotWorkingProperly
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 83);
						return result;
					}
				}

				// Token: 0x1700058B RID: 1419
				// (get) Token: 0x060009F0 RID: 2544 RVA: 0x00028B24 File Offset: 0x00026D24
				public static PropertyKey Paired
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78C34FC8-104A-4ACA-9EA4-524D52996E57}"), 56);
						return result;
					}
				}

				// Token: 0x1700058C RID: 1420
				// (get) Token: 0x060009F1 RID: 2545 RVA: 0x00028B4C File Offset: 0x00026D4C
				public static PropertyKey PrimaryCategory
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 10);
						return result;
					}
				}

				// Token: 0x1700058D RID: 1421
				// (get) Token: 0x060009F2 RID: 2546 RVA: 0x00028B74 File Offset: 0x00026D74
				public static PropertyKey Roaming
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 9);
						return result;
					}
				}

				// Token: 0x1700058E RID: 1422
				// (get) Token: 0x060009F3 RID: 2547 RVA: 0x00028B9C File Offset: 0x00026D9C
				public static PropertyKey SafeRemovalRequired
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AFD97640-86A3-4210-B67C-289C41AABE55}"), 2);
						return result;
					}
				}

				// Token: 0x1700058F RID: 1423
				// (get) Token: 0x060009F4 RID: 2548 RVA: 0x00028BC4 File Offset: 0x00026DC4
				public static PropertyKey SharedTooltip
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{880F70A2-6082-47AC-8AAB-A739D1A300C3}"), 151);
						return result;
					}
				}

				// Token: 0x17000590 RID: 1424
				// (get) Token: 0x060009F5 RID: 2549 RVA: 0x00028BF0 File Offset: 0x00026DF0
				public static PropertyKey SignalStrength
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 2);
						return result;
					}
				}

				// Token: 0x17000591 RID: 1425
				// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00028C18 File Offset: 0x00026E18
				public static PropertyKey Status1
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 257);
						return result;
					}
				}

				// Token: 0x17000592 RID: 1426
				// (get) Token: 0x060009F7 RID: 2551 RVA: 0x00028C44 File Offset: 0x00026E44
				public static PropertyKey Status2
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D08DD4C0-3A9E-462E-8290-7B636B2576B9}"), 258);
						return result;
					}
				}

				// Token: 0x17000593 RID: 1427
				// (get) Token: 0x060009F8 RID: 2552 RVA: 0x00028C70 File Offset: 0x00026E70
				public static PropertyKey StorageCapacity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 12);
						return result;
					}
				}

				// Token: 0x17000594 RID: 1428
				// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00028C98 File Offset: 0x00026E98
				public static PropertyKey StorageFreeSpace
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 13);
						return result;
					}
				}

				// Token: 0x17000595 RID: 1429
				// (get) Token: 0x060009FA RID: 2554 RVA: 0x00028CC0 File Offset: 0x00026EC0
				public static PropertyKey StorageFreeSpacePercent
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 14);
						return result;
					}
				}

				// Token: 0x17000596 RID: 1430
				// (get) Token: 0x060009FB RID: 2555 RVA: 0x00028CE8 File Offset: 0x00026EE8
				public static PropertyKey TextMessages
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 3);
						return result;
					}
				}

				// Token: 0x17000597 RID: 1431
				// (get) Token: 0x060009FC RID: 2556 RVA: 0x00028D10 File Offset: 0x00026F10
				public static PropertyKey Voicemail
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}"), 6);
						return result;
					}
				}

				// Token: 0x020000F5 RID: 245
				public static class Notifications
				{
					// Token: 0x17000598 RID: 1432
					// (get) Token: 0x060009FD RID: 2557 RVA: 0x00028D38 File Offset: 0x00026F38
					public static PropertyKey LowBattery
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}"), 2);
							return result;
						}
					}

					// Token: 0x17000599 RID: 1433
					// (get) Token: 0x060009FE RID: 2558 RVA: 0x00028D60 File Offset: 0x00026F60
					public static PropertyKey MissedCall
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}"), 2);
							return result;
						}
					}

					// Token: 0x1700059A RID: 1434
					// (get) Token: 0x060009FF RID: 2559 RVA: 0x00028D88 File Offset: 0x00026F88
					public static PropertyKey NewMessage
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{2BE9260A-2012-4742-A555-F41B638B7DCB}"), 2);
							return result;
						}
					}

					// Token: 0x1700059B RID: 1435
					// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00028DB0 File Offset: 0x00026FB0
					public static PropertyKey NewVoicemail
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{59569556-0A08-4212-95B9-FAE2AD6413DB}"), 2);
							return result;
						}
					}

					// Token: 0x1700059C RID: 1436
					// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00028DD8 File Offset: 0x00026FD8
					public static PropertyKey StorageFull
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 2);
							return result;
						}
					}

					// Token: 0x1700059D RID: 1437
					// (get) Token: 0x06000A02 RID: 2562 RVA: 0x00028E00 File Offset: 0x00027000
					public static PropertyKey StorageFullLinkText
					{
						get
						{
							PropertyKey result = new PropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 3);
							return result;
						}
					}
				}
			}

			// Token: 0x020000F6 RID: 246
			public static class Notifications
			{
				// Token: 0x1700059E RID: 1438
				// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00028E28 File Offset: 0x00027028
				public static PropertyKey LowBattery
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}"), 2);
						return result;
					}
				}

				// Token: 0x1700059F RID: 1439
				// (get) Token: 0x06000A04 RID: 2564 RVA: 0x00028E50 File Offset: 0x00027050
				public static PropertyKey MissedCall
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}"), 2);
						return result;
					}
				}

				// Token: 0x170005A0 RID: 1440
				// (get) Token: 0x06000A05 RID: 2565 RVA: 0x00028E78 File Offset: 0x00027078
				public static PropertyKey NewMessage
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2BE9260A-2012-4742-A555-F41B638B7DCB}"), 2);
						return result;
					}
				}

				// Token: 0x170005A1 RID: 1441
				// (get) Token: 0x06000A06 RID: 2566 RVA: 0x00028EA0 File Offset: 0x000270A0
				public static PropertyKey NewVoicemail
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{59569556-0A08-4212-95B9-FAE2AD6413DB}"), 2);
						return result;
					}
				}

				// Token: 0x170005A2 RID: 1442
				// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00028EC8 File Offset: 0x000270C8
				public static PropertyKey StorageFull
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 2);
						return result;
					}
				}

				// Token: 0x170005A3 RID: 1443
				// (get) Token: 0x06000A08 RID: 2568 RVA: 0x00028EF0 File Offset: 0x000270F0
				public static PropertyKey StorageFullLinkText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}"), 3);
						return result;
					}
				}
			}

			// Token: 0x020000F7 RID: 247
			public static class Document
			{
				// Token: 0x170005A4 RID: 1444
				// (get) Token: 0x06000A09 RID: 2569 RVA: 0x00028F18 File Offset: 0x00027118
				public static PropertyKey ByteCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 4);
						return result;
					}
				}

				// Token: 0x170005A5 RID: 1445
				// (get) Token: 0x06000A0A RID: 2570 RVA: 0x00028F40 File Offset: 0x00027140
				public static PropertyKey CharacterCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 16);
						return result;
					}
				}

				// Token: 0x170005A6 RID: 1446
				// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00028F68 File Offset: 0x00027168
				public static PropertyKey ClientID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{276D7BB0-5B34-4FB0-AA4B-158ED12A1809}"), 100);
						return result;
					}
				}

				// Token: 0x170005A7 RID: 1447
				// (get) Token: 0x06000A0C RID: 2572 RVA: 0x00028F90 File Offset: 0x00027190
				public static PropertyKey Contributor
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F334115E-DA1B-4509-9B3D-119504DC7ABB}"), 100);
						return result;
					}
				}

				// Token: 0x170005A8 RID: 1448
				// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00028FB8 File Offset: 0x000271B8
				public static PropertyKey DateCreated
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 12);
						return result;
					}
				}

				// Token: 0x170005A9 RID: 1449
				// (get) Token: 0x06000A0E RID: 2574 RVA: 0x00028FE0 File Offset: 0x000271E0
				public static PropertyKey DatePrinted
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 11);
						return result;
					}
				}

				// Token: 0x170005AA RID: 1450
				// (get) Token: 0x06000A0F RID: 2575 RVA: 0x00029008 File Offset: 0x00027208
				public static PropertyKey DateSaved
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 13);
						return result;
					}
				}

				// Token: 0x170005AB RID: 1451
				// (get) Token: 0x06000A10 RID: 2576 RVA: 0x00029030 File Offset: 0x00027230
				public static PropertyKey Division
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1E005EE6-BF27-428B-B01C-79676ACD2870}"), 100);
						return result;
					}
				}

				// Token: 0x170005AC RID: 1452
				// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00029058 File Offset: 0x00027258
				public static PropertyKey DocumentID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E08805C8-E395-40DF-80D2-54F0D6C43154}"), 100);
						return result;
					}
				}

				// Token: 0x170005AD RID: 1453
				// (get) Token: 0x06000A12 RID: 2578 RVA: 0x00029080 File Offset: 0x00027280
				public static PropertyKey HiddenSlideCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 9);
						return result;
					}
				}

				// Token: 0x170005AE RID: 1454
				// (get) Token: 0x06000A13 RID: 2579 RVA: 0x000290A8 File Offset: 0x000272A8
				public static PropertyKey LastAuthor
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 8);
						return result;
					}
				}

				// Token: 0x170005AF RID: 1455
				// (get) Token: 0x06000A14 RID: 2580 RVA: 0x000290D0 File Offset: 0x000272D0
				public static PropertyKey LineCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 5);
						return result;
					}
				}

				// Token: 0x170005B0 RID: 1456
				// (get) Token: 0x06000A15 RID: 2581 RVA: 0x000290F8 File Offset: 0x000272F8
				public static PropertyKey Manager
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 14);
						return result;
					}
				}

				// Token: 0x170005B1 RID: 1457
				// (get) Token: 0x06000A16 RID: 2582 RVA: 0x00029120 File Offset: 0x00027320
				public static PropertyKey MultimediaClipCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 10);
						return result;
					}
				}

				// Token: 0x170005B2 RID: 1458
				// (get) Token: 0x06000A17 RID: 2583 RVA: 0x00029148 File Offset: 0x00027348
				public static PropertyKey NoteCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 8);
						return result;
					}
				}

				// Token: 0x170005B3 RID: 1459
				// (get) Token: 0x06000A18 RID: 2584 RVA: 0x00029170 File Offset: 0x00027370
				public static PropertyKey PageCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 14);
						return result;
					}
				}

				// Token: 0x170005B4 RID: 1460
				// (get) Token: 0x06000A19 RID: 2585 RVA: 0x00029198 File Offset: 0x00027398
				public static PropertyKey ParagraphCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 6);
						return result;
					}
				}

				// Token: 0x170005B5 RID: 1461
				// (get) Token: 0x06000A1A RID: 2586 RVA: 0x000291C0 File Offset: 0x000273C0
				public static PropertyKey PresentationFormat
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 3);
						return result;
					}
				}

				// Token: 0x170005B6 RID: 1462
				// (get) Token: 0x06000A1B RID: 2587 RVA: 0x000291E8 File Offset: 0x000273E8
				public static PropertyKey RevisionNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 9);
						return result;
					}
				}

				// Token: 0x170005B7 RID: 1463
				// (get) Token: 0x06000A1C RID: 2588 RVA: 0x00029210 File Offset: 0x00027410
				public static PropertyKey Security
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 19);
						return result;
					}
				}

				// Token: 0x170005B8 RID: 1464
				// (get) Token: 0x06000A1D RID: 2589 RVA: 0x00029238 File Offset: 0x00027438
				public static PropertyKey SlideCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 7);
						return result;
					}
				}

				// Token: 0x170005B9 RID: 1465
				// (get) Token: 0x06000A1E RID: 2590 RVA: 0x00029260 File Offset: 0x00027460
				public static PropertyKey Template
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 7);
						return result;
					}
				}

				// Token: 0x170005BA RID: 1466
				// (get) Token: 0x06000A1F RID: 2591 RVA: 0x00029288 File Offset: 0x00027488
				public static PropertyKey TotalEditingTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 10);
						return result;
					}
				}

				// Token: 0x170005BB RID: 1467
				// (get) Token: 0x06000A20 RID: 2592 RVA: 0x000292B0 File Offset: 0x000274B0
				public static PropertyKey Version
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D5CDD502-2E9C-101B-9397-08002B2CF9AE}"), 29);
						return result;
					}
				}

				// Token: 0x170005BC RID: 1468
				// (get) Token: 0x06000A21 RID: 2593 RVA: 0x000292D8 File Offset: 0x000274D8
				public static PropertyKey WordCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), 15);
						return result;
					}
				}
			}

			// Token: 0x020000F8 RID: 248
			public static class DRM
			{
				// Token: 0x170005BD RID: 1469
				// (get) Token: 0x06000A22 RID: 2594 RVA: 0x00029300 File Offset: 0x00027500
				public static PropertyKey DatePlayExpires
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 6);
						return result;
					}
				}

				// Token: 0x170005BE RID: 1470
				// (get) Token: 0x06000A23 RID: 2595 RVA: 0x00029328 File Offset: 0x00027528
				public static PropertyKey DatePlayStarts
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 5);
						return result;
					}
				}

				// Token: 0x170005BF RID: 1471
				// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00029350 File Offset: 0x00027550
				public static PropertyKey Description
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 3);
						return result;
					}
				}

				// Token: 0x170005C0 RID: 1472
				// (get) Token: 0x06000A25 RID: 2597 RVA: 0x00029378 File Offset: 0x00027578
				public static PropertyKey IsProtected
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 2);
						return result;
					}
				}

				// Token: 0x170005C1 RID: 1473
				// (get) Token: 0x06000A26 RID: 2598 RVA: 0x000293A0 File Offset: 0x000275A0
				public static PropertyKey PlayCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED}"), 4);
						return result;
					}
				}
			}

			// Token: 0x020000F9 RID: 249
			public static class GPS
			{
				// Token: 0x170005C2 RID: 1474
				// (get) Token: 0x06000A27 RID: 2599 RVA: 0x000293C8 File Offset: 0x000275C8
				public static PropertyKey Altitude
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{827EDB4F-5B73-44A7-891D-FDFFABEA35CA}"), 100);
						return result;
					}
				}

				// Token: 0x170005C3 RID: 1475
				// (get) Token: 0x06000A28 RID: 2600 RVA: 0x000293F0 File Offset: 0x000275F0
				public static PropertyKey AltitudeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{78342DCB-E358-4145-AE9A-6BFE4E0F9F51}"), 100);
						return result;
					}
				}

				// Token: 0x170005C4 RID: 1476
				// (get) Token: 0x06000A29 RID: 2601 RVA: 0x00029418 File Offset: 0x00027618
				public static PropertyKey AltitudeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2DAD1EB7-816D-40D3-9EC3-C9773BE2AADE}"), 100);
						return result;
					}
				}

				// Token: 0x170005C5 RID: 1477
				// (get) Token: 0x06000A2A RID: 2602 RVA: 0x00029440 File Offset: 0x00027640
				public static PropertyKey AltitudeRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{46AC629D-75EA-4515-867F-6DC4321C5844}"), 100);
						return result;
					}
				}

				// Token: 0x170005C6 RID: 1478
				// (get) Token: 0x06000A2B RID: 2603 RVA: 0x00029468 File Offset: 0x00027668
				public static PropertyKey AreaInformation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{972E333E-AC7E-49F1-8ADF-A70D07A9BCAB}"), 100);
						return result;
					}
				}

				// Token: 0x170005C7 RID: 1479
				// (get) Token: 0x06000A2C RID: 2604 RVA: 0x00029490 File Offset: 0x00027690
				public static PropertyKey Date
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3602C812-0F3B-45F0-85AD-603468D69423}"), 100);
						return result;
					}
				}

				// Token: 0x170005C8 RID: 1480
				// (get) Token: 0x06000A2D RID: 2605 RVA: 0x000294B8 File Offset: 0x000276B8
				public static PropertyKey DestinationBearing
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C66D4B3C-E888-47CC-B99F-9DCA3EE34DEA}"), 100);
						return result;
					}
				}

				// Token: 0x170005C9 RID: 1481
				// (get) Token: 0x06000A2E RID: 2606 RVA: 0x000294E0 File Offset: 0x000276E0
				public static PropertyKey DestinationBearingDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7ABCF4F8-7C3F-4988-AC91-8D2C2E97ECA5}"), 100);
						return result;
					}
				}

				// Token: 0x170005CA RID: 1482
				// (get) Token: 0x06000A2F RID: 2607 RVA: 0x00029508 File Offset: 0x00027708
				public static PropertyKey DestinationBearingNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BA3B1DA9-86EE-4B5D-A2A4-A271A429F0CF}"), 100);
						return result;
					}
				}

				// Token: 0x170005CB RID: 1483
				// (get) Token: 0x06000A30 RID: 2608 RVA: 0x00029530 File Offset: 0x00027730
				public static PropertyKey DestinationBearingRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9AB84393-2A0F-4B75-BB22-7279786977CB}"), 100);
						return result;
					}
				}

				// Token: 0x170005CC RID: 1484
				// (get) Token: 0x06000A31 RID: 2609 RVA: 0x00029558 File Offset: 0x00027758
				public static PropertyKey DestinationDistance
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A93EAE04-6804-4F24-AC81-09B266452118}"), 100);
						return result;
					}
				}

				// Token: 0x170005CD RID: 1485
				// (get) Token: 0x06000A32 RID: 2610 RVA: 0x00029580 File Offset: 0x00027780
				public static PropertyKey DestinationDistanceDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9BC2C99B-AC71-4127-9D1C-2596D0D7DCB7}"), 100);
						return result;
					}
				}

				// Token: 0x170005CE RID: 1486
				// (get) Token: 0x06000A33 RID: 2611 RVA: 0x000295A8 File Offset: 0x000277A8
				public static PropertyKey DestinationDistanceNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2BDA47DA-08C6-4FE1-80BC-A72FC517C5D0}"), 100);
						return result;
					}
				}

				// Token: 0x170005CF RID: 1487
				// (get) Token: 0x06000A34 RID: 2612 RVA: 0x000295D0 File Offset: 0x000277D0
				public static PropertyKey DestinationDistanceRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{ED4DF2D3-8695-450B-856F-F5C1C53ACB66}"), 100);
						return result;
					}
				}

				// Token: 0x170005D0 RID: 1488
				// (get) Token: 0x06000A35 RID: 2613 RVA: 0x000295F8 File Offset: 0x000277F8
				public static PropertyKey DestinationLatitude
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9D1D7CC5-5C39-451C-86B3-928E2D18CC47}"), 100);
						return result;
					}
				}

				// Token: 0x170005D1 RID: 1489
				// (get) Token: 0x06000A36 RID: 2614 RVA: 0x00029620 File Offset: 0x00027820
				public static PropertyKey DestinationLatitudeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3A372292-7FCA-49A7-99D5-E47BB2D4E7AB}"), 100);
						return result;
					}
				}

				// Token: 0x170005D2 RID: 1490
				// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00029648 File Offset: 0x00027848
				public static PropertyKey DestinationLatitudeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{ECF4B6F6-D5A6-433C-BB92-4076650FC890}"), 100);
						return result;
					}
				}

				// Token: 0x170005D3 RID: 1491
				// (get) Token: 0x06000A38 RID: 2616 RVA: 0x00029670 File Offset: 0x00027870
				public static PropertyKey DestinationLatitudeRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CEA820B9-CE61-4885-A128-005D9087C192}"), 100);
						return result;
					}
				}

				// Token: 0x170005D4 RID: 1492
				// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00029698 File Offset: 0x00027898
				public static PropertyKey DestinationLongitude
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{47A96261-CB4C-4807-8AD3-40B9D9DBC6BC}"), 100);
						return result;
					}
				}

				// Token: 0x170005D5 RID: 1493
				// (get) Token: 0x06000A3A RID: 2618 RVA: 0x000296C0 File Offset: 0x000278C0
				public static PropertyKey DestinationLongitudeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{425D69E5-48AD-4900-8D80-6EB6B8D0AC86}"), 100);
						return result;
					}
				}

				// Token: 0x170005D6 RID: 1494
				// (get) Token: 0x06000A3B RID: 2619 RVA: 0x000296E8 File Offset: 0x000278E8
				public static PropertyKey DestinationLongitudeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A3250282-FB6D-48D5-9A89-DBCACE75CCCF}"), 100);
						return result;
					}
				}

				// Token: 0x170005D7 RID: 1495
				// (get) Token: 0x06000A3C RID: 2620 RVA: 0x00029710 File Offset: 0x00027910
				public static PropertyKey DestinationLongitudeRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{182C1EA6-7C1C-4083-AB4B-AC6C9F4ED128}"), 100);
						return result;
					}
				}

				// Token: 0x170005D8 RID: 1496
				// (get) Token: 0x06000A3D RID: 2621 RVA: 0x00029738 File Offset: 0x00027938
				public static PropertyKey Differential
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AAF4EE25-BD3B-4DD7-BFC4-47F77BB00F6D}"), 100);
						return result;
					}
				}

				// Token: 0x170005D9 RID: 1497
				// (get) Token: 0x06000A3E RID: 2622 RVA: 0x00029760 File Offset: 0x00027960
				public static PropertyKey DOP
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0CF8FB02-1837-42F1-A697-A7017AA289B9}"), 100);
						return result;
					}
				}

				// Token: 0x170005DA RID: 1498
				// (get) Token: 0x06000A3F RID: 2623 RVA: 0x00029788 File Offset: 0x00027988
				public static PropertyKey DOPDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A0BE94C5-50BA-487B-BD35-0654BE8881ED}"), 100);
						return result;
					}
				}

				// Token: 0x170005DB RID: 1499
				// (get) Token: 0x06000A40 RID: 2624 RVA: 0x000297B0 File Offset: 0x000279B0
				public static PropertyKey DOPNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{47166B16-364F-4AA0-9F31-E2AB3DF449C3}"), 100);
						return result;
					}
				}

				// Token: 0x170005DC RID: 1500
				// (get) Token: 0x06000A41 RID: 2625 RVA: 0x000297D8 File Offset: 0x000279D8
				public static PropertyKey ImageDirection
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{16473C91-D017-4ED9-BA4D-B6BAA55DBCF8}"), 100);
						return result;
					}
				}

				// Token: 0x170005DD RID: 1501
				// (get) Token: 0x06000A42 RID: 2626 RVA: 0x00029800 File Offset: 0x00027A00
				public static PropertyKey ImageDirectionDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{10B24595-41A2-4E20-93C2-5761C1395F32}"), 100);
						return result;
					}
				}

				// Token: 0x170005DE RID: 1502
				// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00029828 File Offset: 0x00027A28
				public static PropertyKey ImageDirectionNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DC5877C7-225F-45F7-BAC7-E81334B6130A}"), 100);
						return result;
					}
				}

				// Token: 0x170005DF RID: 1503
				// (get) Token: 0x06000A44 RID: 2628 RVA: 0x00029850 File Offset: 0x00027A50
				public static PropertyKey ImageDirectionRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A4AAA5B7-1AD0-445F-811A-0F8F6E67F6B5}"), 100);
						return result;
					}
				}

				// Token: 0x170005E0 RID: 1504
				// (get) Token: 0x06000A45 RID: 2629 RVA: 0x00029878 File Offset: 0x00027A78
				public static PropertyKey Latitude
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8727CFFF-4868-4EC6-AD5B-81B98521D1AB}"), 100);
						return result;
					}
				}

				// Token: 0x170005E1 RID: 1505
				// (get) Token: 0x06000A46 RID: 2630 RVA: 0x000298A0 File Offset: 0x00027AA0
				public static PropertyKey LatitudeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{16E634EE-2BFF-497B-BD8A-4341AD39EEB9}"), 100);
						return result;
					}
				}

				// Token: 0x170005E2 RID: 1506
				// (get) Token: 0x06000A47 RID: 2631 RVA: 0x000298C8 File Offset: 0x00027AC8
				public static PropertyKey LatitudeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7DDAAAD1-CCC8-41AE-B750-B2CB8031AEA2}"), 100);
						return result;
					}
				}

				// Token: 0x170005E3 RID: 1507
				// (get) Token: 0x06000A48 RID: 2632 RVA: 0x000298F0 File Offset: 0x00027AF0
				public static PropertyKey LatitudeRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{029C0252-5B86-46C7-ACA0-2769FFC8E3D4}"), 100);
						return result;
					}
				}

				// Token: 0x170005E4 RID: 1508
				// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00029918 File Offset: 0x00027B18
				public static PropertyKey Longitude
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C4C4DBB2-B593-466B-BBDA-D03D27D5E43A}"), 100);
						return result;
					}
				}

				// Token: 0x170005E5 RID: 1509
				// (get) Token: 0x06000A4A RID: 2634 RVA: 0x00029940 File Offset: 0x00027B40
				public static PropertyKey LongitudeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BE6E176C-4534-4D2C-ACE5-31DEDAC1606B}"), 100);
						return result;
					}
				}

				// Token: 0x170005E6 RID: 1510
				// (get) Token: 0x06000A4B RID: 2635 RVA: 0x00029968 File Offset: 0x00027B68
				public static PropertyKey LongitudeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{02B0F689-A914-4E45-821D-1DDA452ED2C4}"), 100);
						return result;
					}
				}

				// Token: 0x170005E7 RID: 1511
				// (get) Token: 0x06000A4C RID: 2636 RVA: 0x00029990 File Offset: 0x00027B90
				public static PropertyKey LongitudeRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{33DCF22B-28D5-464C-8035-1EE9EFD25278}"), 100);
						return result;
					}
				}

				// Token: 0x170005E8 RID: 1512
				// (get) Token: 0x06000A4D RID: 2637 RVA: 0x000299B8 File Offset: 0x00027BB8
				public static PropertyKey MapDatum
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2CA2DAE6-EDDC-407D-BEF1-773942ABFA95}"), 100);
						return result;
					}
				}

				// Token: 0x170005E9 RID: 1513
				// (get) Token: 0x06000A4E RID: 2638 RVA: 0x000299E0 File Offset: 0x00027BE0
				public static PropertyKey MeasureMode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A015ED5D-AAEA-4D58-8A86-3C586920EA0B}"), 100);
						return result;
					}
				}

				// Token: 0x170005EA RID: 1514
				// (get) Token: 0x06000A4F RID: 2639 RVA: 0x00029A08 File Offset: 0x00027C08
				public static PropertyKey ProcessingMethod
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{59D49E61-840F-4AA9-A939-E2099B7F6399}"), 100);
						return result;
					}
				}

				// Token: 0x170005EB RID: 1515
				// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00029A30 File Offset: 0x00027C30
				public static PropertyKey Satellites
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{467EE575-1F25-4557-AD4E-B8B58B0D9C15}"), 100);
						return result;
					}
				}

				// Token: 0x170005EC RID: 1516
				// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00029A58 File Offset: 0x00027C58
				public static PropertyKey Speed
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DA5D0862-6E76-4E1B-BABD-70021BD25494}"), 100);
						return result;
					}
				}

				// Token: 0x170005ED RID: 1517
				// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00029A80 File Offset: 0x00027C80
				public static PropertyKey SpeedDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7D122D5A-AE5E-4335-8841-D71E7CE72F53}"), 100);
						return result;
					}
				}

				// Token: 0x170005EE RID: 1518
				// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00029AA8 File Offset: 0x00027CA8
				public static PropertyKey SpeedNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{ACC9CE3D-C213-4942-8B48-6D0820F21C6D}"), 100);
						return result;
					}
				}

				// Token: 0x170005EF RID: 1519
				// (get) Token: 0x06000A54 RID: 2644 RVA: 0x00029AD0 File Offset: 0x00027CD0
				public static PropertyKey SpeedRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{ECF7F4C9-544F-4D6D-9D98-8AD79ADAF453}"), 100);
						return result;
					}
				}

				// Token: 0x170005F0 RID: 1520
				// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00029AF8 File Offset: 0x00027CF8
				public static PropertyKey Status
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{125491F4-818F-46B2-91B5-D537753617B2}"), 100);
						return result;
					}
				}

				// Token: 0x170005F1 RID: 1521
				// (get) Token: 0x06000A56 RID: 2646 RVA: 0x00029B20 File Offset: 0x00027D20
				public static PropertyKey Track
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{76C09943-7C33-49E3-9E7E-CDBA872CFADA}"), 100);
						return result;
					}
				}

				// Token: 0x170005F2 RID: 1522
				// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00029B48 File Offset: 0x00027D48
				public static PropertyKey TrackDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C8D1920C-01F6-40C0-AC86-2F3A4AD00770}"), 100);
						return result;
					}
				}

				// Token: 0x170005F3 RID: 1523
				// (get) Token: 0x06000A58 RID: 2648 RVA: 0x00029B70 File Offset: 0x00027D70
				public static PropertyKey TrackNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{702926F4-44A6-43E1-AE71-45627116893B}"), 100);
						return result;
					}
				}

				// Token: 0x170005F4 RID: 1524
				// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00029B98 File Offset: 0x00027D98
				public static PropertyKey TrackRef
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{35DBE6FE-44C3-4400-AAAE-D2C799C407E8}"), 100);
						return result;
					}
				}

				// Token: 0x170005F5 RID: 1525
				// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00029BC0 File Offset: 0x00027DC0
				public static PropertyKey VersionID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{22704DA4-C6B2-4A99-8E56-F16DF8C92599}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000FA RID: 250
			public static class Identity
			{
				// Token: 0x170005F6 RID: 1526
				// (get) Token: 0x06000A5B RID: 2651 RVA: 0x00029BE8 File Offset: 0x00027DE8
				public static PropertyKey Blob
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8C3B93A4-BAED-1A83-9A32-102EE313F6EB}"), 100);
						return result;
					}
				}

				// Token: 0x170005F7 RID: 1527
				// (get) Token: 0x06000A5C RID: 2652 RVA: 0x00029C10 File Offset: 0x00027E10
				public static PropertyKey DisplayName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7D683FC9-D155-45A8-BB1F-89D19BCB792F}"), 100);
						return result;
					}
				}

				// Token: 0x170005F8 RID: 1528
				// (get) Token: 0x06000A5D RID: 2653 RVA: 0x00029C38 File Offset: 0x00027E38
				public static PropertyKey IsMeIdentity
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A4108708-09DF-4377-9DFC-6D99986D5A67}"), 100);
						return result;
					}
				}

				// Token: 0x170005F9 RID: 1529
				// (get) Token: 0x06000A5E RID: 2654 RVA: 0x00029C60 File Offset: 0x00027E60
				public static PropertyKey PrimaryEmailAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FCC16823-BAED-4F24-9B32-A0982117F7FA}"), 100);
						return result;
					}
				}

				// Token: 0x170005FA RID: 1530
				// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00029C88 File Offset: 0x00027E88
				public static PropertyKey ProviderID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{74A7DE49-FA11-4D3D-A006-DB7E08675916}"), 100);
						return result;
					}
				}

				// Token: 0x170005FB RID: 1531
				// (get) Token: 0x06000A60 RID: 2656 RVA: 0x00029CB0 File Offset: 0x00027EB0
				public static PropertyKey UniqueID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E55FC3B0-2B60-4220-918E-B21E8BF16016}"), 100);
						return result;
					}
				}

				// Token: 0x170005FC RID: 1532
				// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00029CD8 File Offset: 0x00027ED8
				public static PropertyKey UserName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C4322503-78CA-49C6-9ACC-A68E2AFD7B6B}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000FB RID: 251
			public static class IdentityProvider
			{
				// Token: 0x170005FD RID: 1533
				// (get) Token: 0x06000A62 RID: 2658 RVA: 0x00029D00 File Offset: 0x00027F00
				public static PropertyKey Name
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B96EFF7B-35CA-4A35-8607-29E3A54C46EA}"), 100);
						return result;
					}
				}

				// Token: 0x170005FE RID: 1534
				// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00029D28 File Offset: 0x00027F28
				public static PropertyKey Picture
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2425166F-5642-4864-992F-98FD98F294C3}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000FC RID: 252
			public static class Image
			{
				// Token: 0x170005FF RID: 1535
				// (get) Token: 0x06000A64 RID: 2660 RVA: 0x00029D50 File Offset: 0x00027F50
				public static PropertyKey BitDepth
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 7);
						return result;
					}
				}

				// Token: 0x17000600 RID: 1536
				// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00029D78 File Offset: 0x00027F78
				public static PropertyKey ColorSpace
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 40961);
						return result;
					}
				}

				// Token: 0x17000601 RID: 1537
				// (get) Token: 0x06000A66 RID: 2662 RVA: 0x00029DA4 File Offset: 0x00027FA4
				public static PropertyKey CompressedBitsPerPixel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{364B6FA9-37AB-482A-BE2B-AE02F60D4318}"), 100);
						return result;
					}
				}

				// Token: 0x17000602 RID: 1538
				// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00029DCC File Offset: 0x00027FCC
				public static PropertyKey CompressedBitsPerPixelDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1F8844E1-24AD-4508-9DFD-5326A415CE02}"), 100);
						return result;
					}
				}

				// Token: 0x17000603 RID: 1539
				// (get) Token: 0x06000A68 RID: 2664 RVA: 0x00029DF4 File Offset: 0x00027FF4
				public static PropertyKey CompressedBitsPerPixelNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D21A7148-D32C-4624-8900-277210F79C0F}"), 100);
						return result;
					}
				}

				// Token: 0x17000604 RID: 1540
				// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00029E1C File Offset: 0x0002801C
				public static PropertyKey Compression
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 259);
						return result;
					}
				}

				// Token: 0x17000605 RID: 1541
				// (get) Token: 0x06000A6A RID: 2666 RVA: 0x00029E48 File Offset: 0x00028048
				public static PropertyKey CompressionText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3F08E66F-2F44-4BB9-A682-AC35D2562322}"), 100);
						return result;
					}
				}

				// Token: 0x17000606 RID: 1542
				// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00029E70 File Offset: 0x00028070
				public static PropertyKey Dimensions
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 13);
						return result;
					}
				}

				// Token: 0x17000607 RID: 1543
				// (get) Token: 0x06000A6C RID: 2668 RVA: 0x00029E98 File Offset: 0x00028098
				public static PropertyKey HorizontalResolution
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 5);
						return result;
					}
				}

				// Token: 0x17000608 RID: 1544
				// (get) Token: 0x06000A6D RID: 2669 RVA: 0x00029EC0 File Offset: 0x000280C0
				public static PropertyKey HorizontalSize
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 3);
						return result;
					}
				}

				// Token: 0x17000609 RID: 1545
				// (get) Token: 0x06000A6E RID: 2670 RVA: 0x00029EE8 File Offset: 0x000280E8
				public static PropertyKey ImageID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{10DABE05-32AA-4C29-BF1A-63E2D220587F}"), 100);
						return result;
					}
				}

				// Token: 0x1700060A RID: 1546
				// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00029F10 File Offset: 0x00028110
				public static PropertyKey ResolutionUnit
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{19B51FA6-1F92-4A5C-AB48-7DF0ABD67444}"), 100);
						return result;
					}
				}

				// Token: 0x1700060B RID: 1547
				// (get) Token: 0x06000A70 RID: 2672 RVA: 0x00029F38 File Offset: 0x00028138
				public static PropertyKey VerticalResolution
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 6);
						return result;
					}
				}

				// Token: 0x1700060C RID: 1548
				// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00029F60 File Offset: 0x00028160
				public static PropertyKey VerticalSize
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 4);
						return result;
					}
				}
			}

			// Token: 0x020000FD RID: 253
			public static class Journal
			{
				// Token: 0x1700060D RID: 1549
				// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00029F88 File Offset: 0x00028188
				public static PropertyKey Contacts
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1}"), 100);
						return result;
					}
				}

				// Token: 0x1700060E RID: 1550
				// (get) Token: 0x06000A73 RID: 2675 RVA: 0x00029FB0 File Offset: 0x000281B0
				public static PropertyKey EntryType
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{95BEB1FC-326D-4644-B396-CD3ED90E6DDF}"), 100);
						return result;
					}
				}
			}

			// Token: 0x020000FE RID: 254
			public static class LayoutPattern
			{
				// Token: 0x1700060F RID: 1551
				// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00029FD8 File Offset: 0x000281D8
				public static PropertyKey ContentViewModeForBrowse
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 500);
						return result;
					}
				}

				// Token: 0x17000610 RID: 1552
				// (get) Token: 0x06000A75 RID: 2677 RVA: 0x0002A004 File Offset: 0x00028204
				public static PropertyKey ContentViewModeForSearch
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 501);
						return result;
					}
				}
			}

			// Token: 0x020000FF RID: 255
			public static class Link
			{
				// Token: 0x17000611 RID: 1553
				// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0002A030 File Offset: 0x00028230
				public static PropertyKey Arguments
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{436F2667-14E2-4FEB-B30A-146C53B5B674}"), 100);
						return result;
					}
				}

				// Token: 0x17000612 RID: 1554
				// (get) Token: 0x06000A77 RID: 2679 RVA: 0x0002A058 File Offset: 0x00028258
				public static PropertyKey Comment
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 5);
						return result;
					}
				}

				// Token: 0x17000613 RID: 1555
				// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0002A080 File Offset: 0x00028280
				public static PropertyKey DateVisited
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 23);
						return result;
					}
				}

				// Token: 0x17000614 RID: 1556
				// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0002A0A8 File Offset: 0x000282A8
				public static PropertyKey Description
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 21);
						return result;
					}
				}

				// Token: 0x17000615 RID: 1557
				// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0002A0D0 File Offset: 0x000282D0
				public static PropertyKey Status
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 3);
						return result;
					}
				}

				// Token: 0x17000616 RID: 1558
				// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0002A0F8 File Offset: 0x000282F8
				public static PropertyKey TargetExtension
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7A7D76F4-B630-4BD7-95FF-37CC51A975C9}"), 2);
						return result;
					}
				}

				// Token: 0x17000617 RID: 1559
				// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0002A120 File Offset: 0x00028320
				public static PropertyKey TargetParsingPath
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 2);
						return result;
					}
				}

				// Token: 0x17000618 RID: 1560
				// (get) Token: 0x06000A7D RID: 2685 RVA: 0x0002A148 File Offset: 0x00028348
				public static PropertyKey TargetSFGAOFlags
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B9B4B3FC-2B51-4A42-B5D8-324146AFCF25}"), 8);
						return result;
					}
				}

				// Token: 0x17000619 RID: 1561
				// (get) Token: 0x06000A7E RID: 2686 RVA: 0x0002A170 File Offset: 0x00028370
				public static PropertyKey TargetSFGAOFlagsStrings
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 3);
						return result;
					}
				}

				// Token: 0x1700061A RID: 1562
				// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0002A198 File Offset: 0x00028398
				public static PropertyKey TargetUrl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{5CBF2787-48CF-4208-B90E-EE5E5D420294}"), 2);
						return result;
					}
				}
			}

			// Token: 0x02000100 RID: 256
			public static class Media
			{
				// Token: 0x1700061B RID: 1563
				// (get) Token: 0x06000A80 RID: 2688 RVA: 0x0002A1C0 File Offset: 0x000283C0
				public static PropertyKey AuthorUrl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 32);
						return result;
					}
				}

				// Token: 0x1700061C RID: 1564
				// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0002A1E8 File Offset: 0x000283E8
				public static PropertyKey AverageLevel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{09EDD5B6-B301-43C5-9990-D00302EFFD46}"), 100);
						return result;
					}
				}

				// Token: 0x1700061D RID: 1565
				// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0002A210 File Offset: 0x00028410
				public static PropertyKey ClassPrimaryID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 13);
						return result;
					}
				}

				// Token: 0x1700061E RID: 1566
				// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0002A238 File Offset: 0x00028438
				public static PropertyKey ClassSecondaryID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 14);
						return result;
					}
				}

				// Token: 0x1700061F RID: 1567
				// (get) Token: 0x06000A84 RID: 2692 RVA: 0x0002A260 File Offset: 0x00028460
				public static PropertyKey CollectionGroupID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 24);
						return result;
					}
				}

				// Token: 0x17000620 RID: 1568
				// (get) Token: 0x06000A85 RID: 2693 RVA: 0x0002A288 File Offset: 0x00028488
				public static PropertyKey CollectionID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 25);
						return result;
					}
				}

				// Token: 0x17000621 RID: 1569
				// (get) Token: 0x06000A86 RID: 2694 RVA: 0x0002A2B0 File Offset: 0x000284B0
				public static PropertyKey ContentDistributor
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 18);
						return result;
					}
				}

				// Token: 0x17000622 RID: 1570
				// (get) Token: 0x06000A87 RID: 2695 RVA: 0x0002A2D8 File Offset: 0x000284D8
				public static PropertyKey ContentID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 26);
						return result;
					}
				}

				// Token: 0x17000623 RID: 1571
				// (get) Token: 0x06000A88 RID: 2696 RVA: 0x0002A300 File Offset: 0x00028500
				public static PropertyKey CreatorApplication
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 27);
						return result;
					}
				}

				// Token: 0x17000624 RID: 1572
				// (get) Token: 0x06000A89 RID: 2697 RVA: 0x0002A328 File Offset: 0x00028528
				public static PropertyKey CreatorApplicationVersion
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 28);
						return result;
					}
				}

				// Token: 0x17000625 RID: 1573
				// (get) Token: 0x06000A8A RID: 2698 RVA: 0x0002A350 File Offset: 0x00028550
				public static PropertyKey DateEncoded
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2E4B640D-5019-46D8-8881-55414CC5CAA0}"), 100);
						return result;
					}
				}

				// Token: 0x17000626 RID: 1574
				// (get) Token: 0x06000A8B RID: 2699 RVA: 0x0002A378 File Offset: 0x00028578
				public static PropertyKey DateReleased
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DE41CC29-6971-4290-B472-F59F2E2F31E2}"), 100);
						return result;
					}
				}

				// Token: 0x17000627 RID: 1575
				// (get) Token: 0x06000A8C RID: 2700 RVA: 0x0002A3A0 File Offset: 0x000285A0
				public static PropertyKey Duration
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440490-4C8B-11D1-8B70-080036B11A03}"), 3);
						return result;
					}
				}

				// Token: 0x17000628 RID: 1576
				// (get) Token: 0x06000A8D RID: 2701 RVA: 0x0002A3C8 File Offset: 0x000285C8
				public static PropertyKey DVDID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 15);
						return result;
					}
				}

				// Token: 0x17000629 RID: 1577
				// (get) Token: 0x06000A8E RID: 2702 RVA: 0x0002A3F0 File Offset: 0x000285F0
				public static PropertyKey EncodedBy
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 36);
						return result;
					}
				}

				// Token: 0x1700062A RID: 1578
				// (get) Token: 0x06000A8F RID: 2703 RVA: 0x0002A418 File Offset: 0x00028618
				public static PropertyKey EncodingSettings
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 37);
						return result;
					}
				}

				// Token: 0x1700062B RID: 1579
				// (get) Token: 0x06000A90 RID: 2704 RVA: 0x0002A440 File Offset: 0x00028640
				public static PropertyKey FrameCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6444048F-4C8B-11D1-8B70-080036B11A03}"), 12);
						return result;
					}
				}

				// Token: 0x1700062C RID: 1580
				// (get) Token: 0x06000A91 RID: 2705 RVA: 0x0002A468 File Offset: 0x00028668
				public static PropertyKey MCDI
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 16);
						return result;
					}
				}

				// Token: 0x1700062D RID: 1581
				// (get) Token: 0x06000A92 RID: 2706 RVA: 0x0002A490 File Offset: 0x00028690
				public static PropertyKey MetadataContentProvider
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 17);
						return result;
					}
				}

				// Token: 0x1700062E RID: 1582
				// (get) Token: 0x06000A93 RID: 2707 RVA: 0x0002A4B8 File Offset: 0x000286B8
				public static PropertyKey Producer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 22);
						return result;
					}
				}

				// Token: 0x1700062F RID: 1583
				// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0002A4E0 File Offset: 0x000286E0
				public static PropertyKey PromotionUrl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 33);
						return result;
					}
				}

				// Token: 0x17000630 RID: 1584
				// (get) Token: 0x06000A95 RID: 2709 RVA: 0x0002A508 File Offset: 0x00028708
				public static PropertyKey ProtectionType
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 38);
						return result;
					}
				}

				// Token: 0x17000631 RID: 1585
				// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0002A530 File Offset: 0x00028730
				public static PropertyKey ProviderRating
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 39);
						return result;
					}
				}

				// Token: 0x17000632 RID: 1586
				// (get) Token: 0x06000A97 RID: 2711 RVA: 0x0002A558 File Offset: 0x00028758
				public static PropertyKey ProviderStyle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 40);
						return result;
					}
				}

				// Token: 0x17000633 RID: 1587
				// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0002A580 File Offset: 0x00028780
				public static PropertyKey Publisher
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 30);
						return result;
					}
				}

				// Token: 0x17000634 RID: 1588
				// (get) Token: 0x06000A99 RID: 2713 RVA: 0x0002A5A8 File Offset: 0x000287A8
				public static PropertyKey SubscriptionContentId
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9AEBAE7A-9644-487D-A92C-657585ED751A}"), 100);
						return result;
					}
				}

				// Token: 0x17000635 RID: 1589
				// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0002A5D0 File Offset: 0x000287D0
				public static PropertyKey Subtitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 38);
						return result;
					}
				}

				// Token: 0x17000636 RID: 1590
				// (get) Token: 0x06000A9B RID: 2715 RVA: 0x0002A5F8 File Offset: 0x000287F8
				public static PropertyKey UniqueFileIdentifier
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 35);
						return result;
					}
				}

				// Token: 0x17000637 RID: 1591
				// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0002A620 File Offset: 0x00028820
				public static PropertyKey UserNoAutoInfo
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 41);
						return result;
					}
				}

				// Token: 0x17000638 RID: 1592
				// (get) Token: 0x06000A9D RID: 2717 RVA: 0x0002A648 File Offset: 0x00028848
				public static PropertyKey UserWebUrl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 34);
						return result;
					}
				}

				// Token: 0x17000639 RID: 1593
				// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0002A670 File Offset: 0x00028870
				public static PropertyKey Writer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 23);
						return result;
					}
				}

				// Token: 0x1700063A RID: 1594
				// (get) Token: 0x06000A9F RID: 2719 RVA: 0x0002A698 File Offset: 0x00028898
				public static PropertyKey Year
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 5);
						return result;
					}
				}
			}

			// Token: 0x02000101 RID: 257
			public static class Message
			{
				// Token: 0x1700063B RID: 1595
				// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x0002A6C0 File Offset: 0x000288C0
				public static PropertyKey AttachmentContents
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{3143BF7C-80A8-4854-8880-E2E40189BDD0}"), 100);
						return result;
					}
				}

				// Token: 0x1700063C RID: 1596
				// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x0002A6E8 File Offset: 0x000288E8
				public static PropertyKey AttachmentNames
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 21);
						return result;
					}
				}

				// Token: 0x1700063D RID: 1597
				// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x0002A710 File Offset: 0x00028910
				public static PropertyKey BccAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 2);
						return result;
					}
				}

				// Token: 0x1700063E RID: 1598
				// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0002A738 File Offset: 0x00028938
				public static PropertyKey BccName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 3);
						return result;
					}
				}

				// Token: 0x1700063F RID: 1599
				// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x0002A760 File Offset: 0x00028960
				public static PropertyKey CcAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 4);
						return result;
					}
				}

				// Token: 0x17000640 RID: 1600
				// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x0002A788 File Offset: 0x00028988
				public static PropertyKey CcName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 5);
						return result;
					}
				}

				// Token: 0x17000641 RID: 1601
				// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x0002A7B0 File Offset: 0x000289B0
				public static PropertyKey ConversationID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 100);
						return result;
					}
				}

				// Token: 0x17000642 RID: 1602
				// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x0002A7D8 File Offset: 0x000289D8
				public static PropertyKey ConversationIndex
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DC8F80BD-AF1E-4289-85B6-3DFC1B493992}"), 101);
						return result;
					}
				}

				// Token: 0x17000643 RID: 1603
				// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x0002A800 File Offset: 0x00028A00
				public static PropertyKey DateReceived
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 20);
						return result;
					}
				}

				// Token: 0x17000644 RID: 1604
				// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x0002A828 File Offset: 0x00028A28
				public static PropertyKey DateSent
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 19);
						return result;
					}
				}

				// Token: 0x17000645 RID: 1605
				// (get) Token: 0x06000AAA RID: 2730 RVA: 0x0002A850 File Offset: 0x00028A50
				public static PropertyKey Flags
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A82D9EE7-CA67-4312-965E-226BCEA85023}"), 100);
						return result;
					}
				}

				// Token: 0x17000646 RID: 1606
				// (get) Token: 0x06000AAB RID: 2731 RVA: 0x0002A878 File Offset: 0x00028A78
				public static PropertyKey FromAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 13);
						return result;
					}
				}

				// Token: 0x17000647 RID: 1607
				// (get) Token: 0x06000AAC RID: 2732 RVA: 0x0002A8A0 File Offset: 0x00028AA0
				public static PropertyKey FromName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 14);
						return result;
					}
				}

				// Token: 0x17000648 RID: 1608
				// (get) Token: 0x06000AAD RID: 2733 RVA: 0x0002A8C8 File Offset: 0x00028AC8
				public static PropertyKey HasAttachments
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4}"), 8);
						return result;
					}
				}

				// Token: 0x17000649 RID: 1609
				// (get) Token: 0x06000AAE RID: 2734 RVA: 0x0002A8F0 File Offset: 0x00028AF0
				public static PropertyKey IsFwdOrReply
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9A9BC088-4F6D-469E-9919-E705412040F9}"), 100);
						return result;
					}
				}

				// Token: 0x1700064A RID: 1610
				// (get) Token: 0x06000AAF RID: 2735 RVA: 0x0002A918 File Offset: 0x00028B18
				public static PropertyKey MessageClass
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CD9ED458-08CE-418F-A70E-F912C7BB9C5C}"), 103);
						return result;
					}
				}

				// Token: 0x1700064B RID: 1611
				// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x0002A940 File Offset: 0x00028B40
				public static PropertyKey ProofInProgress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9098F33C-9A7D-48A8-8DE5-2E1227A64E91}"), 100);
						return result;
					}
				}

				// Token: 0x1700064C RID: 1612
				// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x0002A968 File Offset: 0x00028B68
				public static PropertyKey SenderAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0BE1C8E7-1981-4676-AE14-FDD78F05A6E7}"), 100);
						return result;
					}
				}

				// Token: 0x1700064D RID: 1613
				// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x0002A990 File Offset: 0x00028B90
				public static PropertyKey SenderName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0DA41CFA-D224-4A18-AE2F-596158DB4B3A}"), 100);
						return result;
					}
				}

				// Token: 0x1700064E RID: 1614
				// (get) Token: 0x06000AB3 RID: 2739 RVA: 0x0002A9B8 File Offset: 0x00028BB8
				public static PropertyKey Store
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 15);
						return result;
					}
				}

				// Token: 0x1700064F RID: 1615
				// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x0002A9E0 File Offset: 0x00028BE0
				public static PropertyKey ToAddress
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 16);
						return result;
					}
				}

				// Token: 0x17000650 RID: 1616
				// (get) Token: 0x06000AB5 RID: 2741 RVA: 0x0002AA08 File Offset: 0x00028C08
				public static PropertyKey ToDoFlags
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1F856A9F-6900-4ABA-9505-2D5F1B4D66CB}"), 100);
						return result;
					}
				}

				// Token: 0x17000651 RID: 1617
				// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x0002AA30 File Offset: 0x00028C30
				public static PropertyKey ToDoTitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7}"), 100);
						return result;
					}
				}

				// Token: 0x17000652 RID: 1618
				// (get) Token: 0x06000AB7 RID: 2743 RVA: 0x0002AA58 File Offset: 0x00028C58
				public static PropertyKey ToName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD}"), 17);
						return result;
					}
				}
			}

			// Token: 0x02000102 RID: 258
			public static class Music
			{
				// Token: 0x17000653 RID: 1619
				// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x0002AA80 File Offset: 0x00028C80
				public static PropertyKey AlbumArtist
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 13);
						return result;
					}
				}

				// Token: 0x17000654 RID: 1620
				// (get) Token: 0x06000AB9 RID: 2745 RVA: 0x0002AAA8 File Offset: 0x00028CA8
				public static PropertyKey AlbumID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 100);
						return result;
					}
				}

				// Token: 0x17000655 RID: 1621
				// (get) Token: 0x06000ABA RID: 2746 RVA: 0x0002AAD0 File Offset: 0x00028CD0
				public static PropertyKey AlbumTitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 4);
						return result;
					}
				}

				// Token: 0x17000656 RID: 1622
				// (get) Token: 0x06000ABB RID: 2747 RVA: 0x0002AAF8 File Offset: 0x00028CF8
				public static PropertyKey Artist
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 2);
						return result;
					}
				}

				// Token: 0x17000657 RID: 1623
				// (get) Token: 0x06000ABC RID: 2748 RVA: 0x0002AB20 File Offset: 0x00028D20
				public static PropertyKey BeatsPerMinute
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 35);
						return result;
					}
				}

				// Token: 0x17000658 RID: 1624
				// (get) Token: 0x06000ABD RID: 2749 RVA: 0x0002AB48 File Offset: 0x00028D48
				public static PropertyKey Composer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 19);
						return result;
					}
				}

				// Token: 0x17000659 RID: 1625
				// (get) Token: 0x06000ABE RID: 2750 RVA: 0x0002AB70 File Offset: 0x00028D70
				public static PropertyKey Conductor
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 36);
						return result;
					}
				}

				// Token: 0x1700065A RID: 1626
				// (get) Token: 0x06000ABF RID: 2751 RVA: 0x0002AB98 File Offset: 0x00028D98
				public static PropertyKey ContentGroupDescription
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 33);
						return result;
					}
				}

				// Token: 0x1700065B RID: 1627
				// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0002ABC0 File Offset: 0x00028DC0
				public static PropertyKey DisplayArtist
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FD122953-FA93-4EF7-92C3-04C946B2F7C8}"), 100);
						return result;
					}
				}

				// Token: 0x1700065C RID: 1628
				// (get) Token: 0x06000AC1 RID: 2753 RVA: 0x0002ABE8 File Offset: 0x00028DE8
				public static PropertyKey Genre
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 11);
						return result;
					}
				}

				// Token: 0x1700065D RID: 1629
				// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0002AC10 File Offset: 0x00028E10
				public static PropertyKey InitialKey
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 34);
						return result;
					}
				}

				// Token: 0x1700065E RID: 1630
				// (get) Token: 0x06000AC3 RID: 2755 RVA: 0x0002AC38 File Offset: 0x00028E38
				public static PropertyKey IsCompilation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C449D5CB-9EA4-4809-82E8-AF9D59DED6D1}"), 100);
						return result;
					}
				}

				// Token: 0x1700065F RID: 1631
				// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0002AC60 File Offset: 0x00028E60
				public static PropertyKey Lyrics
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 12);
						return result;
					}
				}

				// Token: 0x17000660 RID: 1632
				// (get) Token: 0x06000AC5 RID: 2757 RVA: 0x0002AC88 File Offset: 0x00028E88
				public static PropertyKey Mood
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 39);
						return result;
					}
				}

				// Token: 0x17000661 RID: 1633
				// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x0002ACB0 File Offset: 0x00028EB0
				public static PropertyKey PartOfSet
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 37);
						return result;
					}
				}

				// Token: 0x17000662 RID: 1634
				// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0002ACD8 File Offset: 0x00028ED8
				public static PropertyKey Period
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 31);
						return result;
					}
				}

				// Token: 0x17000663 RID: 1635
				// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0002AD00 File Offset: 0x00028F00
				public static PropertyKey SynchronizedLyrics
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6B223B6A-162E-4AA9-B39F-05D678FC6D77}"), 100);
						return result;
					}
				}

				// Token: 0x17000664 RID: 1636
				// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0002AD28 File Offset: 0x00028F28
				public static PropertyKey TrackNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{56A3372E-CE9C-11D2-9F0E-006097C686F6}"), 7);
						return result;
					}
				}
			}

			// Token: 0x02000103 RID: 259
			public static class Note
			{
				// Token: 0x17000665 RID: 1637
				// (get) Token: 0x06000ACA RID: 2762 RVA: 0x0002AD50 File Offset: 0x00028F50
				public static PropertyKey Color
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{4776CAFA-BCE4-4CB1-A23E-265E76D8EB11}"), 100);
						return result;
					}
				}

				// Token: 0x17000666 RID: 1638
				// (get) Token: 0x06000ACB RID: 2763 RVA: 0x0002AD78 File Offset: 0x00028F78
				public static PropertyKey ColorText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{46B4E8DE-CDB2-440D-885C-1658EB65B914}"), 100);
						return result;
					}
				}
			}

			// Token: 0x02000104 RID: 260
			public static class Photo
			{
				// Token: 0x17000667 RID: 1639
				// (get) Token: 0x06000ACC RID: 2764 RVA: 0x0002ADA0 File Offset: 0x00028FA0
				public static PropertyKey Aperture
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37378);
						return result;
					}
				}

				// Token: 0x17000668 RID: 1640
				// (get) Token: 0x06000ACD RID: 2765 RVA: 0x0002ADCC File Offset: 0x00028FCC
				public static PropertyKey ApertureDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E1A9A38B-6685-46BD-875E-570DC7AD7320}"), 100);
						return result;
					}
				}

				// Token: 0x17000669 RID: 1641
				// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0002ADF4 File Offset: 0x00028FF4
				public static PropertyKey ApertureNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0337ECEC-39FB-4581-A0BD-4C4CC51E9914}"), 100);
						return result;
					}
				}

				// Token: 0x1700066A RID: 1642
				// (get) Token: 0x06000ACF RID: 2767 RVA: 0x0002AE1C File Offset: 0x0002901C
				public static PropertyKey Brightness
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1A701BF6-478C-4361-83AB-3701BB053C58}"), 100);
						return result;
					}
				}

				// Token: 0x1700066B RID: 1643
				// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0002AE44 File Offset: 0x00029044
				public static PropertyKey BrightnessDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6EBE6946-2321-440A-90F0-C043EFD32476}"), 100);
						return result;
					}
				}

				// Token: 0x1700066C RID: 1644
				// (get) Token: 0x06000AD1 RID: 2769 RVA: 0x0002AE6C File Offset: 0x0002906C
				public static PropertyKey BrightnessNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9E7D118F-B314-45A0-8CFB-D654B917C9E9}"), 100);
						return result;
					}
				}

				// Token: 0x1700066D RID: 1645
				// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0002AE94 File Offset: 0x00029094
				public static PropertyKey CameraManufacturer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 271);
						return result;
					}
				}

				// Token: 0x1700066E RID: 1646
				// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x0002AEC0 File Offset: 0x000290C0
				public static PropertyKey CameraModel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 272);
						return result;
					}
				}

				// Token: 0x1700066F RID: 1647
				// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0002AEEC File Offset: 0x000290EC
				public static PropertyKey CameraSerialNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 273);
						return result;
					}
				}

				// Token: 0x17000670 RID: 1648
				// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x0002AF18 File Offset: 0x00029118
				public static PropertyKey Contrast
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2A785BA9-8D23-4DED-82E6-60A350C86A10}"), 100);
						return result;
					}
				}

				// Token: 0x17000671 RID: 1649
				// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0002AF40 File Offset: 0x00029140
				public static PropertyKey ContrastText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{59DDE9F2-5253-40EA-9A8B-479E96C6249A}"), 100);
						return result;
					}
				}

				// Token: 0x17000672 RID: 1650
				// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x0002AF68 File Offset: 0x00029168
				public static PropertyKey DateTaken
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 36867);
						return result;
					}
				}

				// Token: 0x17000673 RID: 1651
				// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0002AF94 File Offset: 0x00029194
				public static PropertyKey DigitalZoom
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F85BF840-A925-4BC2-B0C4-8E36B598679E}"), 100);
						return result;
					}
				}

				// Token: 0x17000674 RID: 1652
				// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x0002AFBC File Offset: 0x000291BC
				public static PropertyKey DigitalZoomDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{745BAF0E-E5C1-4CFB-8A1B-D031A0A52393}"), 100);
						return result;
					}
				}

				// Token: 0x17000675 RID: 1653
				// (get) Token: 0x06000ADA RID: 2778 RVA: 0x0002AFE4 File Offset: 0x000291E4
				public static PropertyKey DigitalZoomNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{16CBB924-6500-473B-A5BE-F1599BCBE413}"), 100);
						return result;
					}
				}

				// Token: 0x17000676 RID: 1654
				// (get) Token: 0x06000ADB RID: 2779 RVA: 0x0002B00C File Offset: 0x0002920C
				public static PropertyKey Event
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 18248);
						return result;
					}
				}

				// Token: 0x17000677 RID: 1655
				// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0002B038 File Offset: 0x00029238
				public static PropertyKey EXIFVersion
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D35F743A-EB2E-47F2-A286-844132CB1427}"), 100);
						return result;
					}
				}

				// Token: 0x17000678 RID: 1656
				// (get) Token: 0x06000ADD RID: 2781 RVA: 0x0002B060 File Offset: 0x00029260
				public static PropertyKey ExposureBias
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37380);
						return result;
					}
				}

				// Token: 0x17000679 RID: 1657
				// (get) Token: 0x06000ADE RID: 2782 RVA: 0x0002B08C File Offset: 0x0002928C
				public static PropertyKey ExposureBiasDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AB205E50-04B7-461C-A18C-2F233836E627}"), 100);
						return result;
					}
				}

				// Token: 0x1700067A RID: 1658
				// (get) Token: 0x06000ADF RID: 2783 RVA: 0x0002B0B4 File Offset: 0x000292B4
				public static PropertyKey ExposureBiasNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{738BF284-1D87-420B-92CF-5834BF6EF9ED}"), 100);
						return result;
					}
				}

				// Token: 0x1700067B RID: 1659
				// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0002B0DC File Offset: 0x000292DC
				public static PropertyKey ExposureIndex
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{967B5AF8-995A-46ED-9E11-35B3C5B9782D}"), 100);
						return result;
					}
				}

				// Token: 0x1700067C RID: 1660
				// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x0002B104 File Offset: 0x00029304
				public static PropertyKey ExposureIndexDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{93112F89-C28B-492F-8A9D-4BE2062CEE8A}"), 100);
						return result;
					}
				}

				// Token: 0x1700067D RID: 1661
				// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0002B12C File Offset: 0x0002932C
				public static PropertyKey ExposureIndexNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CDEDCF30-8919-44DF-8F4C-4EB2FFDB8D89}"), 100);
						return result;
					}
				}

				// Token: 0x1700067E RID: 1662
				// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x0002B154 File Offset: 0x00029354
				public static PropertyKey ExposureProgram
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34850);
						return result;
					}
				}

				// Token: 0x1700067F RID: 1663
				// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x0002B180 File Offset: 0x00029380
				public static PropertyKey ExposureProgramText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FEC690B7-5F30-4646-AE47-4CAAFBA884A3}"), 100);
						return result;
					}
				}

				// Token: 0x17000680 RID: 1664
				// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x0002B1A8 File Offset: 0x000293A8
				public static PropertyKey ExposureTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33434);
						return result;
					}
				}

				// Token: 0x17000681 RID: 1665
				// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x0002B1D4 File Offset: 0x000293D4
				public static PropertyKey ExposureTimeDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{55E98597-AD16-42E0-B624-21599A199838}"), 100);
						return result;
					}
				}

				// Token: 0x17000682 RID: 1666
				// (get) Token: 0x06000AE7 RID: 2791 RVA: 0x0002B1FC File Offset: 0x000293FC
				public static PropertyKey ExposureTimeNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{257E44E2-9031-4323-AC38-85C552871B2E}"), 100);
						return result;
					}
				}

				// Token: 0x17000683 RID: 1667
				// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x0002B224 File Offset: 0x00029424
				public static PropertyKey Flash
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37385);
						return result;
					}
				}

				// Token: 0x17000684 RID: 1668
				// (get) Token: 0x06000AE9 RID: 2793 RVA: 0x0002B250 File Offset: 0x00029450
				public static PropertyKey FlashEnergy
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 41483);
						return result;
					}
				}

				// Token: 0x17000685 RID: 1669
				// (get) Token: 0x06000AEA RID: 2794 RVA: 0x0002B27C File Offset: 0x0002947C
				public static PropertyKey FlashEnergyDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D7B61C70-6323-49CD-A5FC-C84277162C97}"), 100);
						return result;
					}
				}

				// Token: 0x17000686 RID: 1670
				// (get) Token: 0x06000AEB RID: 2795 RVA: 0x0002B2A4 File Offset: 0x000294A4
				public static PropertyKey FlashEnergyNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FCAD3D3D-0858-400F-AAA3-2F66CCE2A6BC}"), 100);
						return result;
					}
				}

				// Token: 0x17000687 RID: 1671
				// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0002B2CC File Offset: 0x000294CC
				public static PropertyKey FlashManufacturer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{AABAF6C9-E0C5-4719-8585-57B103E584FE}"), 100);
						return result;
					}
				}

				// Token: 0x17000688 RID: 1672
				// (get) Token: 0x06000AED RID: 2797 RVA: 0x0002B2F4 File Offset: 0x000294F4
				public static PropertyKey FlashModel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FE83BB35-4D1A-42E2-916B-06F3E1AF719E}"), 100);
						return result;
					}
				}

				// Token: 0x17000689 RID: 1673
				// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0002B31C File Offset: 0x0002951C
				public static PropertyKey FlashText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6B8B68F6-200B-47EA-8D25-D8050F57339F}"), 100);
						return result;
					}
				}

				// Token: 0x1700068A RID: 1674
				// (get) Token: 0x06000AEF RID: 2799 RVA: 0x0002B344 File Offset: 0x00029544
				public static PropertyKey FNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 33437);
						return result;
					}
				}

				// Token: 0x1700068B RID: 1675
				// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x0002B370 File Offset: 0x00029570
				public static PropertyKey FNumberDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E92A2496-223B-4463-A4E3-30EABBA79D80}"), 100);
						return result;
					}
				}

				// Token: 0x1700068C RID: 1676
				// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x0002B398 File Offset: 0x00029598
				public static PropertyKey FNumberNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1B97738A-FDFC-462F-9D93-1957E08BE90C}"), 100);
						return result;
					}
				}

				// Token: 0x1700068D RID: 1677
				// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x0002B3C0 File Offset: 0x000295C0
				public static PropertyKey FocalLength
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37386);
						return result;
					}
				}

				// Token: 0x1700068E RID: 1678
				// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x0002B3EC File Offset: 0x000295EC
				public static PropertyKey FocalLengthDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{305BC615-DCA1-44A5-9FD4-10C0BA79412E}"), 100);
						return result;
					}
				}

				// Token: 0x1700068F RID: 1679
				// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0002B414 File Offset: 0x00029614
				public static PropertyKey FocalLengthInFilm
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A0E74609-B84D-4F49-B860-462BD9971F98}"), 100);
						return result;
					}
				}

				// Token: 0x17000690 RID: 1680
				// (get) Token: 0x06000AF5 RID: 2805 RVA: 0x0002B43C File Offset: 0x0002963C
				public static PropertyKey FocalLengthNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{776B6B3B-1E3D-4B0C-9A0E-8FBAF2A8492A}"), 100);
						return result;
					}
				}

				// Token: 0x17000691 RID: 1681
				// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0002B464 File Offset: 0x00029664
				public static PropertyKey FocalPlaneXResolution
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CFC08D97-C6F7-4484-89DD-EBEF4356FE76}"), 100);
						return result;
					}
				}

				// Token: 0x17000692 RID: 1682
				// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x0002B48C File Offset: 0x0002968C
				public static PropertyKey FocalPlaneXResolutionDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0933F3F5-4786-4F46-A8E8-D64DD37FA521}"), 100);
						return result;
					}
				}

				// Token: 0x17000693 RID: 1683
				// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0002B4B4 File Offset: 0x000296B4
				public static PropertyKey FocalPlaneXResolutionNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DCCB10AF-B4E2-4B88-95F9-031B4D5AB490}"), 100);
						return result;
					}
				}

				// Token: 0x17000694 RID: 1684
				// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x0002B4DC File Offset: 0x000296DC
				public static PropertyKey FocalPlaneYResolution
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{4FFFE4D0-914F-4AC4-8D6F-C9C61DE169B1}"), 100);
						return result;
					}
				}

				// Token: 0x17000695 RID: 1685
				// (get) Token: 0x06000AFA RID: 2810 RVA: 0x0002B504 File Offset: 0x00029704
				public static PropertyKey FocalPlaneYResolutionDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1D6179A6-A876-4031-B013-3347B2B64DC8}"), 100);
						return result;
					}
				}

				// Token: 0x17000696 RID: 1686
				// (get) Token: 0x06000AFB RID: 2811 RVA: 0x0002B52C File Offset: 0x0002972C
				public static PropertyKey FocalPlaneYResolutionNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A2E541C5-4440-4BA8-867E-75CFC06828CD}"), 100);
						return result;
					}
				}

				// Token: 0x17000697 RID: 1687
				// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0002B554 File Offset: 0x00029754
				public static PropertyKey GainControl
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FA304789-00C7-4D80-904A-1E4DCC7265AA}"), 100);
						return result;
					}
				}

				// Token: 0x17000698 RID: 1688
				// (get) Token: 0x06000AFD RID: 2813 RVA: 0x0002B57C File Offset: 0x0002977C
				public static PropertyKey GainControlDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{42864DFD-9DA4-4F77-BDED-4AAD7B256735}"), 100);
						return result;
					}
				}

				// Token: 0x17000699 RID: 1689
				// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0002B5A4 File Offset: 0x000297A4
				public static PropertyKey GainControlNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8E8ECF7C-B7B8-4EB8-A63F-0EE715C96F9E}"), 100);
						return result;
					}
				}

				// Token: 0x1700069A RID: 1690
				// (get) Token: 0x06000AFF RID: 2815 RVA: 0x0002B5CC File Offset: 0x000297CC
				public static PropertyKey GainControlText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C06238B2-0BF9-4279-A723-25856715CB9D}"), 100);
						return result;
					}
				}

				// Token: 0x1700069B RID: 1691
				// (get) Token: 0x06000B00 RID: 2816 RVA: 0x0002B5F4 File Offset: 0x000297F4
				public static PropertyKey ISOSpeed
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 34855);
						return result;
					}
				}

				// Token: 0x1700069C RID: 1692
				// (get) Token: 0x06000B01 RID: 2817 RVA: 0x0002B620 File Offset: 0x00029820
				public static PropertyKey LensManufacturer
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E6DDCAF7-29C5-4F0A-9A68-D19412EC7090}"), 100);
						return result;
					}
				}

				// Token: 0x1700069D RID: 1693
				// (get) Token: 0x06000B02 RID: 2818 RVA: 0x0002B648 File Offset: 0x00029848
				public static PropertyKey LensModel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E1277516-2B5F-4869-89B1-2E585BD38B7A}"), 100);
						return result;
					}
				}

				// Token: 0x1700069E RID: 1694
				// (get) Token: 0x06000B03 RID: 2819 RVA: 0x0002B670 File Offset: 0x00029870
				public static PropertyKey LightSource
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37384);
						return result;
					}
				}

				// Token: 0x1700069F RID: 1695
				// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0002B69C File Offset: 0x0002989C
				public static PropertyKey MakerNote
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FA303353-B659-4052-85E9-BCAC79549B84}"), 100);
						return result;
					}
				}

				// Token: 0x170006A0 RID: 1696
				// (get) Token: 0x06000B05 RID: 2821 RVA: 0x0002B6C4 File Offset: 0x000298C4
				public static PropertyKey MakerNoteOffset
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{813F4124-34E6-4D17-AB3E-6B1F3C2247A1}"), 100);
						return result;
					}
				}

				// Token: 0x170006A1 RID: 1697
				// (get) Token: 0x06000B06 RID: 2822 RVA: 0x0002B6EC File Offset: 0x000298EC
				public static PropertyKey MaxAperture
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{08F6D7C2-E3F2-44FC-AF1E-5AA5C81A2D3E}"), 100);
						return result;
					}
				}

				// Token: 0x170006A2 RID: 1698
				// (get) Token: 0x06000B07 RID: 2823 RVA: 0x0002B714 File Offset: 0x00029914
				public static PropertyKey MaxApertureDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C77724D4-601F-46C5-9B89-C53F93BCEB77}"), 100);
						return result;
					}
				}

				// Token: 0x170006A3 RID: 1699
				// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0002B73C File Offset: 0x0002993C
				public static PropertyKey MaxApertureNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C107E191-A459-44C5-9AE6-B952AD4B906D}"), 100);
						return result;
					}
				}

				// Token: 0x170006A4 RID: 1700
				// (get) Token: 0x06000B09 RID: 2825 RVA: 0x0002B764 File Offset: 0x00029964
				public static PropertyKey MeteringMode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37383);
						return result;
					}
				}

				// Token: 0x170006A5 RID: 1701
				// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0002B790 File Offset: 0x00029990
				public static PropertyKey MeteringModeText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F628FD8C-7BA8-465A-A65B-C5AA79263A9E}"), 100);
						return result;
					}
				}

				// Token: 0x170006A6 RID: 1702
				// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0002B7B8 File Offset: 0x000299B8
				public static PropertyKey Orientation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 274);
						return result;
					}
				}

				// Token: 0x170006A7 RID: 1703
				// (get) Token: 0x06000B0C RID: 2828 RVA: 0x0002B7E4 File Offset: 0x000299E4
				public static PropertyKey OrientationText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A9EA193C-C511-498A-A06B-58E2776DCC28}"), 100);
						return result;
					}
				}

				// Token: 0x170006A8 RID: 1704
				// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0002B80C File Offset: 0x00029A0C
				public static PropertyKey PeopleNames
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E8309B6E-084C-49B4-B1FC-90A80331B638}"), 100);
						return result;
					}
				}

				// Token: 0x170006A9 RID: 1705
				// (get) Token: 0x06000B0E RID: 2830 RVA: 0x0002B834 File Offset: 0x00029A34
				public static PropertyKey PhotometricInterpretation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{341796F1-1DF9-4B1C-A564-91BDEFA43877}"), 100);
						return result;
					}
				}

				// Token: 0x170006AA RID: 1706
				// (get) Token: 0x06000B0F RID: 2831 RVA: 0x0002B85C File Offset: 0x00029A5C
				public static PropertyKey PhotometricInterpretationText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{821437D6-9EAB-4765-A589-3B1CBBD22A61}"), 100);
						return result;
					}
				}

				// Token: 0x170006AB RID: 1707
				// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0002B884 File Offset: 0x00029A84
				public static PropertyKey ProgramMode
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D217F6D-3F6A-4825-B470-5F03CA2FBE9B}"), 100);
						return result;
					}
				}

				// Token: 0x170006AC RID: 1708
				// (get) Token: 0x06000B11 RID: 2833 RVA: 0x0002B8AC File Offset: 0x00029AAC
				public static PropertyKey ProgramModeText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7FE3AA27-2648-42F3-89B0-454E5CB150C3}"), 100);
						return result;
					}
				}

				// Token: 0x170006AD RID: 1709
				// (get) Token: 0x06000B12 RID: 2834 RVA: 0x0002B8D4 File Offset: 0x00029AD4
				public static PropertyKey RelatedSoundFile
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{318A6B45-087F-4DC2-B8CC-05359551FC9E}"), 100);
						return result;
					}
				}

				// Token: 0x170006AE RID: 1710
				// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0002B8FC File Offset: 0x00029AFC
				public static PropertyKey Saturation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49237325-A95A-4F67-B211-816B2D45D2E0}"), 100);
						return result;
					}
				}

				// Token: 0x170006AF RID: 1711
				// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0002B924 File Offset: 0x00029B24
				public static PropertyKey SaturationText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{61478C08-B600-4A84-BBE4-E99C45F0A072}"), 100);
						return result;
					}
				}

				// Token: 0x170006B0 RID: 1712
				// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0002B94C File Offset: 0x00029B4C
				public static PropertyKey Sharpness
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{FC6976DB-8349-4970-AE97-B3C5316A08F0}"), 100);
						return result;
					}
				}

				// Token: 0x170006B1 RID: 1713
				// (get) Token: 0x06000B16 RID: 2838 RVA: 0x0002B974 File Offset: 0x00029B74
				public static PropertyKey SharpnessText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{51EC3F47-DD50-421D-8769-334F50424B1E}"), 100);
						return result;
					}
				}

				// Token: 0x170006B2 RID: 1714
				// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0002B99C File Offset: 0x00029B9C
				public static PropertyKey ShutterSpeed
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37377);
						return result;
					}
				}

				// Token: 0x170006B3 RID: 1715
				// (get) Token: 0x06000B18 RID: 2840 RVA: 0x0002B9C8 File Offset: 0x00029BC8
				public static PropertyKey ShutterSpeedDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E13D8975-81C7-4948-AE3F-37CAE11E8FF7}"), 100);
						return result;
					}
				}

				// Token: 0x170006B4 RID: 1716
				// (get) Token: 0x06000B19 RID: 2841 RVA: 0x0002B9F0 File Offset: 0x00029BF0
				public static PropertyKey ShutterSpeedNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{16EA4042-D6F4-4BCA-8349-7C78D30FB333}"), 100);
						return result;
					}
				}

				// Token: 0x170006B5 RID: 1717
				// (get) Token: 0x06000B1A RID: 2842 RVA: 0x0002BA18 File Offset: 0x00029C18
				public static PropertyKey SubjectDistance
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{14B81DA1-0135-4D31-96D9-6CBFC9671A99}"), 37382);
						return result;
					}
				}

				// Token: 0x170006B6 RID: 1718
				// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0002BA44 File Offset: 0x00029C44
				public static PropertyKey SubjectDistanceDenominator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0C840A88-B043-466D-9766-D4B26DA3FA77}"), 100);
						return result;
					}
				}

				// Token: 0x170006B7 RID: 1719
				// (get) Token: 0x06000B1C RID: 2844 RVA: 0x0002BA6C File Offset: 0x00029C6C
				public static PropertyKey SubjectDistanceNumerator
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8AF4961C-F526-43E5-AA81-DB768219178D}"), 100);
						return result;
					}
				}

				// Token: 0x170006B8 RID: 1720
				// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0002BA94 File Offset: 0x00029C94
				public static PropertyKey TagViewAggregate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B812F15D-C2D8-4BBF-BACD-79744346113F}"), 100);
						return result;
					}
				}

				// Token: 0x170006B9 RID: 1721
				// (get) Token: 0x06000B1E RID: 2846 RVA: 0x0002BABC File Offset: 0x00029CBC
				public static PropertyKey TranscodedForSync
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9A8EBB75-6458-4E82-BACB-35C0095B03BB}"), 100);
						return result;
					}
				}

				// Token: 0x170006BA RID: 1722
				// (get) Token: 0x06000B1F RID: 2847 RVA: 0x0002BAE4 File Offset: 0x00029CE4
				public static PropertyKey WhiteBalance
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{EE3D3D8A-5381-4CFA-B13B-AAF66B5F4EC9}"), 100);
						return result;
					}
				}

				// Token: 0x170006BB RID: 1723
				// (get) Token: 0x06000B20 RID: 2848 RVA: 0x0002BB0C File Offset: 0x00029D0C
				public static PropertyKey WhiteBalanceText
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6336B95E-C7A7-426D-86FD-7AE3D39C84B4}"), 100);
						return result;
					}
				}
			}

			// Token: 0x02000105 RID: 261
			public static class PropGroup
			{
				// Token: 0x170006BC RID: 1724
				// (get) Token: 0x06000B21 RID: 2849 RVA: 0x0002BB34 File Offset: 0x00029D34
				public static PropertyKey Advanced
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{900A403B-097B-4B95-8AE2-071FDAEEB118}"), 100);
						return result;
					}
				}

				// Token: 0x170006BD RID: 1725
				// (get) Token: 0x06000B22 RID: 2850 RVA: 0x0002BB5C File Offset: 0x00029D5C
				public static PropertyKey Audio
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2804D469-788F-48AA-8570-71B9C187E138}"), 100);
						return result;
					}
				}

				// Token: 0x170006BE RID: 1726
				// (get) Token: 0x06000B23 RID: 2851 RVA: 0x0002BB84 File Offset: 0x00029D84
				public static PropertyKey Calendar
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9973D2B5-BFD8-438A-BA94-5349B293181A}"), 100);
						return result;
					}
				}

				// Token: 0x170006BF RID: 1727
				// (get) Token: 0x06000B24 RID: 2852 RVA: 0x0002BBAC File Offset: 0x00029DAC
				public static PropertyKey Camera
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DE00DE32-547E-4981-AD4B-542F2E9007D8}"), 100);
						return result;
					}
				}

				// Token: 0x170006C0 RID: 1728
				// (get) Token: 0x06000B25 RID: 2853 RVA: 0x0002BBD4 File Offset: 0x00029DD4
				public static PropertyKey Contact
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DF975FD3-250A-4004-858F-34E29A3E37AA}"), 100);
						return result;
					}
				}

				// Token: 0x170006C1 RID: 1729
				// (get) Token: 0x06000B26 RID: 2854 RVA: 0x0002BBFC File Offset: 0x00029DFC
				public static PropertyKey Content
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D0DAB0BA-368A-4050-A882-6C010FD19A4F}"), 100);
						return result;
					}
				}

				// Token: 0x170006C2 RID: 1730
				// (get) Token: 0x06000B27 RID: 2855 RVA: 0x0002BC24 File Offset: 0x00029E24
				public static PropertyKey Description
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8969B275-9475-4E00-A887-FF93B8B41E44}"), 100);
						return result;
					}
				}

				// Token: 0x170006C3 RID: 1731
				// (get) Token: 0x06000B28 RID: 2856 RVA: 0x0002BC4C File Offset: 0x00029E4C
				public static PropertyKey FileSystem
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3A7D2C1-80FC-4B40-8F34-30EA111BDC2E}"), 100);
						return result;
					}
				}

				// Token: 0x170006C4 RID: 1732
				// (get) Token: 0x06000B29 RID: 2857 RVA: 0x0002BC74 File Offset: 0x00029E74
				public static PropertyKey General
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CC301630-B192-4C22-B372-9F4C6D338E07}"), 100);
						return result;
					}
				}

				// Token: 0x170006C5 RID: 1733
				// (get) Token: 0x06000B2A RID: 2858 RVA: 0x0002BC9C File Offset: 0x00029E9C
				public static PropertyKey GPS
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F3713ADA-90E3-4E11-AAE5-FDC17685B9BE}"), 100);
						return result;
					}
				}

				// Token: 0x170006C6 RID: 1734
				// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0002BCC4 File Offset: 0x00029EC4
				public static PropertyKey Image
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E3690A87-0FA8-4A2A-9A9F-FCE8827055AC}"), 100);
						return result;
					}
				}

				// Token: 0x170006C7 RID: 1735
				// (get) Token: 0x06000B2C RID: 2860 RVA: 0x0002BCEC File Offset: 0x00029EEC
				public static PropertyKey Media
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{61872CF7-6B5E-4B4B-AC2D-59DA84459248}"), 100);
						return result;
					}
				}

				// Token: 0x170006C8 RID: 1736
				// (get) Token: 0x06000B2D RID: 2861 RVA: 0x0002BD14 File Offset: 0x00029F14
				public static PropertyKey MediaAdvanced
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{8859A284-DE7E-4642-99BA-D431D044B1EC}"), 100);
						return result;
					}
				}

				// Token: 0x170006C9 RID: 1737
				// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0002BD3C File Offset: 0x00029F3C
				public static PropertyKey Message
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7FD7259D-16B4-4135-9F97-7C96ECD2FA9E}"), 100);
						return result;
					}
				}

				// Token: 0x170006CA RID: 1738
				// (get) Token: 0x06000B2F RID: 2863 RVA: 0x0002BD64 File Offset: 0x00029F64
				public static PropertyKey Music
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{68DD6094-7216-40F1-A029-43FE7127043F}"), 100);
						return result;
					}
				}

				// Token: 0x170006CB RID: 1739
				// (get) Token: 0x06000B30 RID: 2864 RVA: 0x0002BD8C File Offset: 0x00029F8C
				public static PropertyKey Origin
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2598D2FB-5569-4367-95DF-5CD3A177E1A5}"), 100);
						return result;
					}
				}

				// Token: 0x170006CC RID: 1740
				// (get) Token: 0x06000B31 RID: 2865 RVA: 0x0002BDB4 File Offset: 0x00029FB4
				public static PropertyKey PhotoAdvanced
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0CB2BF5A-9EE7-4A86-8222-F01E07FDADAF}"), 100);
						return result;
					}
				}

				// Token: 0x170006CD RID: 1741
				// (get) Token: 0x06000B32 RID: 2866 RVA: 0x0002BDDC File Offset: 0x00029FDC
				public static PropertyKey RecordedTV
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{E7B33238-6584-4170-A5C0-AC25EFD9DA56}"), 100);
						return result;
					}
				}

				// Token: 0x170006CE RID: 1742
				// (get) Token: 0x06000B33 RID: 2867 RVA: 0x0002BE04 File Offset: 0x0002A004
				public static PropertyKey Video
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BEBE0920-7671-4C54-A3EB-49FDDFC191EE}"), 100);
						return result;
					}
				}
			}

			// Token: 0x02000106 RID: 262
			public static class PropList
			{
				// Token: 0x170006CF RID: 1743
				// (get) Token: 0x06000B34 RID: 2868 RVA: 0x0002BE2C File Offset: 0x0002A02C
				public static PropertyKey ConflictPrompt
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 11);
						return result;
					}
				}

				// Token: 0x170006D0 RID: 1744
				// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0002BE54 File Offset: 0x0002A054
				public static PropertyKey ContentViewModeForBrowse
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 13);
						return result;
					}
				}

				// Token: 0x170006D1 RID: 1745
				// (get) Token: 0x06000B36 RID: 2870 RVA: 0x0002BE7C File Offset: 0x0002A07C
				public static PropertyKey ContentViewModeForSearch
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 14);
						return result;
					}
				}

				// Token: 0x170006D2 RID: 1746
				// (get) Token: 0x06000B37 RID: 2871 RVA: 0x0002BEA4 File Offset: 0x0002A0A4
				public static PropertyKey ExtendedTileInfo
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 9);
						return result;
					}
				}

				// Token: 0x170006D3 RID: 1747
				// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0002BECC File Offset: 0x0002A0CC
				public static PropertyKey FileOperationPrompt
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 10);
						return result;
					}
				}

				// Token: 0x170006D4 RID: 1748
				// (get) Token: 0x06000B39 RID: 2873 RVA: 0x0002BEF4 File Offset: 0x0002A0F4
				public static PropertyKey FullDetails
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 2);
						return result;
					}
				}

				// Token: 0x170006D5 RID: 1749
				// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0002BF1C File Offset: 0x0002A11C
				public static PropertyKey InfoTip
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 4);
						return result;
					}
				}

				// Token: 0x170006D6 RID: 1750
				// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0002BF44 File Offset: 0x0002A144
				public static PropertyKey NonPersonal
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49D1091F-082E-493F-B23F-D2308AA9668C}"), 100);
						return result;
					}
				}

				// Token: 0x170006D7 RID: 1751
				// (get) Token: 0x06000B3C RID: 2876 RVA: 0x0002BF6C File Offset: 0x0002A16C
				public static PropertyKey PreviewDetails
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 8);
						return result;
					}
				}

				// Token: 0x170006D8 RID: 1752
				// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0002BF94 File Offset: 0x0002A194
				public static PropertyKey PreviewTitle
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 6);
						return result;
					}
				}

				// Token: 0x170006D9 RID: 1753
				// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0002BFBC File Offset: 0x0002A1BC
				public static PropertyKey QuickTip
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 5);
						return result;
					}
				}

				// Token: 0x170006DA RID: 1754
				// (get) Token: 0x06000B3F RID: 2879 RVA: 0x0002BFE4 File Offset: 0x0002A1E4
				public static PropertyKey TileInfo
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{C9944A21-A406-48FE-8225-AEC7E24C211B}"), 3);
						return result;
					}
				}

				// Token: 0x170006DB RID: 1755
				// (get) Token: 0x06000B40 RID: 2880 RVA: 0x0002C00C File Offset: 0x0002A20C
				public static PropertyKey XPDetailsPanel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{F2275480-F782-4291-BD94-F13693513AEC}"), 0);
						return result;
					}
				}
			}

			// Token: 0x02000107 RID: 263
			public static class RecordedTV
			{
				// Token: 0x170006DC RID: 1756
				// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0002C034 File Offset: 0x0002A234
				public static PropertyKey ChannelNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 7);
						return result;
					}
				}

				// Token: 0x170006DD RID: 1757
				// (get) Token: 0x06000B42 RID: 2882 RVA: 0x0002C05C File Offset: 0x0002A25C
				public static PropertyKey Credits
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 4);
						return result;
					}
				}

				// Token: 0x170006DE RID: 1758
				// (get) Token: 0x06000B43 RID: 2883 RVA: 0x0002C084 File Offset: 0x0002A284
				public static PropertyKey DateContentExpires
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 15);
						return result;
					}
				}

				// Token: 0x170006DF RID: 1759
				// (get) Token: 0x06000B44 RID: 2884 RVA: 0x0002C0AC File Offset: 0x0002A2AC
				public static PropertyKey EpisodeName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 2);
						return result;
					}
				}

				// Token: 0x170006E0 RID: 1760
				// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0002C0D4 File Offset: 0x0002A2D4
				public static PropertyKey IsATSCContent
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 16);
						return result;
					}
				}

				// Token: 0x170006E1 RID: 1761
				// (get) Token: 0x06000B46 RID: 2886 RVA: 0x0002C0FC File Offset: 0x0002A2FC
				public static PropertyKey IsClosedCaptioningAvailable
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 12);
						return result;
					}
				}

				// Token: 0x170006E2 RID: 1762
				// (get) Token: 0x06000B47 RID: 2887 RVA: 0x0002C124 File Offset: 0x0002A324
				public static PropertyKey IsDTVContent
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 17);
						return result;
					}
				}

				// Token: 0x170006E3 RID: 1763
				// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0002C14C File Offset: 0x0002A34C
				public static PropertyKey IsHDContent
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 18);
						return result;
					}
				}

				// Token: 0x170006E4 RID: 1764
				// (get) Token: 0x06000B49 RID: 2889 RVA: 0x0002C174 File Offset: 0x0002A374
				public static PropertyKey IsRepeatBroadcast
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 13);
						return result;
					}
				}

				// Token: 0x170006E5 RID: 1765
				// (get) Token: 0x06000B4A RID: 2890 RVA: 0x0002C19C File Offset: 0x0002A39C
				public static PropertyKey IsSAP
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 14);
						return result;
					}
				}

				// Token: 0x170006E6 RID: 1766
				// (get) Token: 0x06000B4B RID: 2891 RVA: 0x0002C1C4 File Offset: 0x0002A3C4
				public static PropertyKey NetworkAffiliation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{2C53C813-FB63-4E22-A1AB-0B331CA1E273}"), 100);
						return result;
					}
				}

				// Token: 0x170006E7 RID: 1767
				// (get) Token: 0x06000B4C RID: 2892 RVA: 0x0002C1EC File Offset: 0x0002A3EC
				public static PropertyKey OriginalBroadcastDate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{4684FE97-8765-4842-9C13-F006447B178C}"), 100);
						return result;
					}
				}

				// Token: 0x170006E8 RID: 1768
				// (get) Token: 0x06000B4D RID: 2893 RVA: 0x0002C214 File Offset: 0x0002A414
				public static PropertyKey ProgramDescription
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 3);
						return result;
					}
				}

				// Token: 0x170006E9 RID: 1769
				// (get) Token: 0x06000B4E RID: 2894 RVA: 0x0002C23C File Offset: 0x0002A43C
				public static PropertyKey RecordingTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A5477F61-7A82-4ECA-9DDE-98B69B2479B3}"), 100);
						return result;
					}
				}

				// Token: 0x170006EA RID: 1770
				// (get) Token: 0x06000B4F RID: 2895 RVA: 0x0002C264 File Offset: 0x0002A464
				public static PropertyKey StationCallSign
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{6D748DE2-8D38-4CC3-AC60-F009B057C557}"), 5);
						return result;
					}
				}

				// Token: 0x170006EB RID: 1771
				// (get) Token: 0x06000B50 RID: 2896 RVA: 0x0002C28C File Offset: 0x0002A48C
				public static PropertyKey StationName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493}"), 100);
						return result;
					}
				}
			}

			// Token: 0x02000108 RID: 264
			public static class Search
			{
				// Token: 0x170006EC RID: 1772
				// (get) Token: 0x06000B51 RID: 2897 RVA: 0x0002C2B4 File Offset: 0x0002A4B4
				public static PropertyKey AutoSummary
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 2);
						return result;
					}
				}

				// Token: 0x170006ED RID: 1773
				// (get) Token: 0x06000B52 RID: 2898 RVA: 0x0002C2DC File Offset: 0x0002A4DC
				public static PropertyKey ContainerHash
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{BCEEE283-35DF-4D53-826A-F36A3EEFC6BE}"), 100);
						return result;
					}
				}

				// Token: 0x170006EE RID: 1774
				// (get) Token: 0x06000B53 RID: 2899 RVA: 0x0002C304 File Offset: 0x0002A504
				public static PropertyKey Contents
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{B725F130-47EF-101A-A5F1-02608C9EEBAC}"), 19);
						return result;
					}
				}

				// Token: 0x170006EF RID: 1775
				// (get) Token: 0x06000B54 RID: 2900 RVA: 0x0002C32C File Offset: 0x0002A52C
				public static PropertyKey EntryID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 5);
						return result;
					}
				}

				// Token: 0x170006F0 RID: 1776
				// (get) Token: 0x06000B55 RID: 2901 RVA: 0x0002C354 File Offset: 0x0002A554
				public static PropertyKey ExtendedProperties
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7B03B546-FA4F-4A52-A2FE-03D5311E5865}"), 100);
						return result;
					}
				}

				// Token: 0x170006F1 RID: 1777
				// (get) Token: 0x06000B56 RID: 2902 RVA: 0x0002C37C File Offset: 0x0002A57C
				public static PropertyKey GatherTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B63E350-9CCC-11D0-BCDB-00805FCCCE04}"), 8);
						return result;
					}
				}

				// Token: 0x170006F2 RID: 1778
				// (get) Token: 0x06000B57 RID: 2903 RVA: 0x0002C3A4 File Offset: 0x0002A5A4
				public static PropertyKey HitCount
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 4);
						return result;
					}
				}

				// Token: 0x170006F3 RID: 1779
				// (get) Token: 0x06000B58 RID: 2904 RVA: 0x0002C3CC File Offset: 0x0002A5CC
				public static PropertyKey IsClosedDirectory
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 23);
						return result;
					}
				}

				// Token: 0x170006F4 RID: 1780
				// (get) Token: 0x06000B59 RID: 2905 RVA: 0x0002C3F4 File Offset: 0x0002A5F4
				public static PropertyKey IsFullyContained
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 24);
						return result;
					}
				}

				// Token: 0x170006F5 RID: 1781
				// (get) Token: 0x06000B5A RID: 2906 RVA: 0x0002C41C File Offset: 0x0002A61C
				public static PropertyKey QueryFocusedSummary
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 3);
						return result;
					}
				}

				// Token: 0x170006F6 RID: 1782
				// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0002C444 File Offset: 0x0002A644
				public static PropertyKey QueryFocusedSummaryWithFallback
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{560C36C0-503A-11CF-BAA1-00004C752A9A}"), 4);
						return result;
					}
				}

				// Token: 0x170006F7 RID: 1783
				// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0002C46C File Offset: 0x0002A66C
				public static PropertyKey Rank
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{49691C90-7E17-101A-A91C-08002B2ECDA9}"), 3);
						return result;
					}
				}

				// Token: 0x170006F8 RID: 1784
				// (get) Token: 0x06000B5D RID: 2909 RVA: 0x0002C494 File Offset: 0x0002A694
				public static PropertyKey Store
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{A06992B3-8CAF-4ED7-A547-B259E32AC9FC}"), 100);
						return result;
					}
				}

				// Token: 0x170006F9 RID: 1785
				// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0002C4BC File Offset: 0x0002A6BC
				public static PropertyKey UrlToIndex
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 2);
						return result;
					}
				}

				// Token: 0x170006FA RID: 1786
				// (get) Token: 0x06000B5F RID: 2911 RVA: 0x0002C4E4 File Offset: 0x0002A6E4
				public static PropertyKey UrlToIndexWithModificationTime
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0B63E343-9CCC-11D0-BCDB-00805FCCCE04}"), 12);
						return result;
					}
				}
			}

			// Token: 0x02000109 RID: 265
			public static class Shell
			{
				// Token: 0x170006FB RID: 1787
				// (get) Token: 0x06000B60 RID: 2912 RVA: 0x0002C50C File Offset: 0x0002A70C
				public static PropertyKey OmitFromView
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{DE35258C-C695-4CBC-B982-38B0AD24CED0}"), 2);
						return result;
					}
				}

				// Token: 0x170006FC RID: 1788
				// (get) Token: 0x06000B61 RID: 2913 RVA: 0x0002C534 File Offset: 0x0002A734
				public static PropertyKey SFGAOFlagsStrings
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D6942081-D53B-443D-AD47-5E059D9CD27A}"), 2);
						return result;
					}
				}
			}

			// Token: 0x0200010A RID: 266
			public static class Software
			{
				// Token: 0x170006FD RID: 1789
				// (get) Token: 0x06000B62 RID: 2914 RVA: 0x0002C55C File Offset: 0x0002A75C
				public static PropertyKey DateLastUsed
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{841E4F90-FF59-4D16-8947-E81BBFFAB36D}"), 16);
						return result;
					}
				}

				// Token: 0x170006FE RID: 1790
				// (get) Token: 0x06000B63 RID: 2915 RVA: 0x0002C584 File Offset: 0x0002A784
				public static PropertyKey ProductName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{0CEF7D53-FA64-11D1-A203-0000F81FEDEE}"), 7);
						return result;
					}
				}
			}

			// Token: 0x0200010B RID: 267
			public static class Sync
			{
				// Token: 0x170006FF RID: 1791
				// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0002C5AC File Offset: 0x0002A7AC
				public static PropertyKey Comments
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 13);
						return result;
					}
				}

				// Token: 0x17000700 RID: 1792
				// (get) Token: 0x06000B65 RID: 2917 RVA: 0x0002C5D4 File Offset: 0x0002A7D4
				public static PropertyKey ConflictDescription
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 4);
						return result;
					}
				}

				// Token: 0x17000701 RID: 1793
				// (get) Token: 0x06000B66 RID: 2918 RVA: 0x0002C5FC File Offset: 0x0002A7FC
				public static PropertyKey ConflictFirstLocation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 6);
						return result;
					}
				}

				// Token: 0x17000702 RID: 1794
				// (get) Token: 0x06000B67 RID: 2919 RVA: 0x0002C624 File Offset: 0x0002A824
				public static PropertyKey ConflictSecondLocation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 7);
						return result;
					}
				}

				// Token: 0x17000703 RID: 1795
				// (get) Token: 0x06000B68 RID: 2920 RVA: 0x0002C64C File Offset: 0x0002A84C
				public static PropertyKey HandlerCollectionID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 2);
						return result;
					}
				}

				// Token: 0x17000704 RID: 1796
				// (get) Token: 0x06000B69 RID: 2921 RVA: 0x0002C674 File Offset: 0x0002A874
				public static PropertyKey HandlerID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 3);
						return result;
					}
				}

				// Token: 0x17000705 RID: 1797
				// (get) Token: 0x06000B6A RID: 2922 RVA: 0x0002C69C File Offset: 0x0002A89C
				public static PropertyKey HandlerName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 2);
						return result;
					}
				}

				// Token: 0x17000706 RID: 1798
				// (get) Token: 0x06000B6B RID: 2923 RVA: 0x0002C6C4 File Offset: 0x0002A8C4
				public static PropertyKey HandlerType
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 8);
						return result;
					}
				}

				// Token: 0x17000707 RID: 1799
				// (get) Token: 0x06000B6C RID: 2924 RVA: 0x0002C6EC File Offset: 0x0002A8EC
				public static PropertyKey HandlerTypeLabel
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 9);
						return result;
					}
				}

				// Token: 0x17000708 RID: 1800
				// (get) Token: 0x06000B6D RID: 2925 RVA: 0x0002C714 File Offset: 0x0002A914
				public static PropertyKey ItemID
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 6);
						return result;
					}
				}

				// Token: 0x17000709 RID: 1801
				// (get) Token: 0x06000B6E RID: 2926 RVA: 0x0002C73C File Offset: 0x0002A93C
				public static PropertyKey ItemName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{CE50C159-2FB8-41FD-BE68-D3E042E274BC}"), 3);
						return result;
					}
				}

				// Token: 0x1700070A RID: 1802
				// (get) Token: 0x06000B6F RID: 2927 RVA: 0x0002C764 File Offset: 0x0002A964
				public static PropertyKey ProgressPercentage
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 23);
						return result;
					}
				}

				// Token: 0x1700070B RID: 1803
				// (get) Token: 0x06000B70 RID: 2928 RVA: 0x0002C78C File Offset: 0x0002A98C
				public static PropertyKey State
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 24);
						return result;
					}
				}

				// Token: 0x1700070C RID: 1804
				// (get) Token: 0x06000B71 RID: 2929 RVA: 0x0002C7B4 File Offset: 0x0002A9B4
				public static PropertyKey Status
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{7BD5533E-AF15-44DB-B8C8-BD6624E1D032}"), 10);
						return result;
					}
				}
			}

			// Token: 0x0200010C RID: 268
			public static class Task
			{
				// Token: 0x1700070D RID: 1805
				// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0002C7DC File Offset: 0x0002A9DC
				public static PropertyKey BillingInformation
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{D37D52C6-261C-4303-82B3-08B926AC6F12}"), 100);
						return result;
					}
				}

				// Token: 0x1700070E RID: 1806
				// (get) Token: 0x06000B73 RID: 2931 RVA: 0x0002C804 File Offset: 0x0002AA04
				public static PropertyKey CompletionStatus
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{084D8A0A-E6D5-40DE-BF1F-C8820E7C877C}"), 100);
						return result;
					}
				}

				// Token: 0x1700070F RID: 1807
				// (get) Token: 0x06000B74 RID: 2932 RVA: 0x0002C82C File Offset: 0x0002AA2C
				public static PropertyKey Owner
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0}"), 100);
						return result;
					}
				}
			}

			// Token: 0x0200010D RID: 269
			public static class Video
			{
				// Token: 0x17000710 RID: 1808
				// (get) Token: 0x06000B75 RID: 2933 RVA: 0x0002C854 File Offset: 0x0002AA54
				public static PropertyKey Compression
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 10);
						return result;
					}
				}

				// Token: 0x17000711 RID: 1809
				// (get) Token: 0x06000B76 RID: 2934 RVA: 0x0002C87C File Offset: 0x0002AA7C
				public static PropertyKey Director
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440492-4C8B-11D1-8B70-080036B11A03}"), 20);
						return result;
					}
				}

				// Token: 0x17000712 RID: 1810
				// (get) Token: 0x06000B77 RID: 2935 RVA: 0x0002C8A4 File Offset: 0x0002AAA4
				public static PropertyKey EncodingBitrate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 8);
						return result;
					}
				}

				// Token: 0x17000713 RID: 1811
				// (get) Token: 0x06000B78 RID: 2936 RVA: 0x0002C8CC File Offset: 0x0002AACC
				public static PropertyKey FourCC
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 44);
						return result;
					}
				}

				// Token: 0x17000714 RID: 1812
				// (get) Token: 0x06000B79 RID: 2937 RVA: 0x0002C8F4 File Offset: 0x0002AAF4
				public static PropertyKey FrameHeight
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 4);
						return result;
					}
				}

				// Token: 0x17000715 RID: 1813
				// (get) Token: 0x06000B7A RID: 2938 RVA: 0x0002C91C File Offset: 0x0002AB1C
				public static PropertyKey FrameRate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 6);
						return result;
					}
				}

				// Token: 0x17000716 RID: 1814
				// (get) Token: 0x06000B7B RID: 2939 RVA: 0x0002C944 File Offset: 0x0002AB44
				public static PropertyKey FrameWidth
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 3);
						return result;
					}
				}

				// Token: 0x17000717 RID: 1815
				// (get) Token: 0x06000B7C RID: 2940 RVA: 0x0002C96C File Offset: 0x0002AB6C
				public static PropertyKey HorizontalAspectRatio
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 42);
						return result;
					}
				}

				// Token: 0x17000718 RID: 1816
				// (get) Token: 0x06000B7D RID: 2941 RVA: 0x0002C994 File Offset: 0x0002AB94
				public static PropertyKey SampleSize
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 9);
						return result;
					}
				}

				// Token: 0x17000719 RID: 1817
				// (get) Token: 0x06000B7E RID: 2942 RVA: 0x0002C9BC File Offset: 0x0002ABBC
				public static PropertyKey StreamName
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 2);
						return result;
					}
				}

				// Token: 0x1700071A RID: 1818
				// (get) Token: 0x06000B7F RID: 2943 RVA: 0x0002C9E4 File Offset: 0x0002ABE4
				public static PropertyKey StreamNumber
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 11);
						return result;
					}
				}

				// Token: 0x1700071B RID: 1819
				// (get) Token: 0x06000B80 RID: 2944 RVA: 0x0002CA0C File Offset: 0x0002AC0C
				public static PropertyKey TotalBitrate
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 43);
						return result;
					}
				}

				// Token: 0x1700071C RID: 1820
				// (get) Token: 0x06000B81 RID: 2945 RVA: 0x0002CA34 File Offset: 0x0002AC34
				public static PropertyKey TranscodedForSync
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 46);
						return result;
					}
				}

				// Token: 0x1700071D RID: 1821
				// (get) Token: 0x06000B82 RID: 2946 RVA: 0x0002CA5C File Offset: 0x0002AC5C
				public static PropertyKey VerticalAspectRatio
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{64440491-4C8B-11D1-8B70-080036B11A03}"), 45);
						return result;
					}
				}
			}

			// Token: 0x0200010E RID: 270
			public static class Volume
			{
				// Token: 0x1700071E RID: 1822
				// (get) Token: 0x06000B83 RID: 2947 RVA: 0x0002CA84 File Offset: 0x0002AC84
				public static PropertyKey FileSystem
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 4);
						return result;
					}
				}

				// Token: 0x1700071F RID: 1823
				// (get) Token: 0x06000B84 RID: 2948 RVA: 0x0002CAAC File Offset: 0x0002ACAC
				public static PropertyKey IsMappedDrive
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{149C0B69-2C2D-48FC-808F-D318D78C4636}"), 2);
						return result;
					}
				}

				// Token: 0x17000720 RID: 1824
				// (get) Token: 0x06000B85 RID: 2949 RVA: 0x0002CAD4 File Offset: 0x0002ACD4
				public static PropertyKey IsRoot
				{
					get
					{
						PropertyKey result = new PropertyKey(new Guid("{9B174B35-40FF-11D2-A27E-00C04FC30871}"), 10);
						return result;
					}
				}
			}
		}
	}
}
