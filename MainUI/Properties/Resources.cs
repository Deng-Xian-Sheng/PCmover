using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MainUI.Properties
{
	// Token: 0x0200001C RID: 28
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x06000184 RID: 388 RVA: 0x000067D1 File Offset: 0x000049D1
		internal Resources()
		{
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000185 RID: 389 RVA: 0x000067D9 File Offset: 0x000049D9
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("MainUI.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006805 File Offset: 0x00004A05
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000680C File Offset: 0x00004A0C
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00006814 File Offset: 0x00004A14
		public static string About
		{
			get
			{
				return Resources.ResourceManager.GetString("About", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000189 RID: 393 RVA: 0x0000682A File Offset: 0x00004A2A
		public static string ApplicationsTransferred
		{
			get
			{
				return Resources.ResourceManager.GetString("ApplicationsTransferred", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600018A RID: 394 RVA: 0x00006840 File Offset: 0x00004A40
		public static string Apps
		{
			get
			{
				return Resources.ResourceManager.GetString("Apps", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600018B RID: 395 RVA: 0x00006856 File Offset: 0x00004A56
		public static string AppsToMove
		{
			get
			{
				return Resources.ResourceManager.GetString("AppsToMove", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600018C RID: 396 RVA: 0x0000686C File Offset: 0x00004A6C
		public static string Back
		{
			get
			{
				return Resources.ResourceManager.GetString("Back", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600018D RID: 397 RVA: 0x00006882 File Offset: 0x00004A82
		public static string Change
		{
			get
			{
				return Resources.ResourceManager.GetString("Change", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600018E RID: 398 RVA: 0x00006898 File Offset: 0x00004A98
		public static string CloseFolders
		{
			get
			{
				return Resources.ResourceManager.GetString("CloseFolders", Resources.resourceCulture);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600018F RID: 399 RVA: 0x000068AE File Offset: 0x00004AAE
		public static string Copyright
		{
			get
			{
				return Resources.ResourceManager.GetString("Copyright", Resources.resourceCulture);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000190 RID: 400 RVA: 0x000068C4 File Offset: 0x00004AC4
		public static string DestinationBase
		{
			get
			{
				return Resources.ResourceManager.GetString("DestinationBase", Resources.resourceCulture);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000191 RID: 401 RVA: 0x000068DA File Offset: 0x00004ADA
		public static string DestinationExists
		{
			get
			{
				return Resources.ResourceManager.GetString("DestinationExists", Resources.resourceCulture);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000192 RID: 402 RVA: 0x000068F0 File Offset: 0x00004AF0
		public static string Documents
		{
			get
			{
				return Resources.ResourceManager.GetString("Documents", Resources.resourceCulture);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00006906 File Offset: 0x00004B06
		public static string Done
		{
			get
			{
				return Resources.ResourceManager.GetString("Done", Resources.resourceCulture);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000194 RID: 404 RVA: 0x0000691C File Offset: 0x00004B1C
		public static string Downloads
		{
			get
			{
				return Resources.ResourceManager.GetString("Downloads", Resources.resourceCulture);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00006932 File Offset: 0x00004B32
		public static string DriveInformation
		{
			get
			{
				return Resources.ResourceManager.GetString("DriveInformation", Resources.resourceCulture);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00006948 File Offset: 0x00004B48
		public static string ErrorEmail
		{
			get
			{
				return Resources.ResourceManager.GetString("ErrorEmail", Resources.resourceCulture);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000197 RID: 407 RVA: 0x0000695E File Offset: 0x00004B5E
		public static string ErrorOnlyOneDrive
		{
			get
			{
				return Resources.ResourceManager.GetString("ErrorOnlyOneDrive", Resources.resourceCulture);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00006974 File Offset: 0x00004B74
		public static string Errors
		{
			get
			{
				return Resources.ResourceManager.GetString("Errors", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000199 RID: 409 RVA: 0x0000698A File Offset: 0x00004B8A
		public static string Explain
		{
			get
			{
				return Resources.ResourceManager.GetString("Explain", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600019A RID: 410 RVA: 0x000069A0 File Offset: 0x00004BA0
		public static string Explain2
		{
			get
			{
				return Resources.ResourceManager.GetString("Explain2", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600019B RID: 411 RVA: 0x000069B6 File Offset: 0x00004BB6
		public static string Explain3
		{
			get
			{
				return Resources.ResourceManager.GetString("Explain3", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600019C RID: 412 RVA: 0x000069CC File Offset: 0x00004BCC
		public static string Explain4
		{
			get
			{
				return Resources.ResourceManager.GetString("Explain4", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600019D RID: 413 RVA: 0x000069E2 File Offset: 0x00004BE2
		public static string ExplorerWarning
		{
			get
			{
				return Resources.ResourceManager.GetString("ExplorerWarning", Resources.resourceCulture);
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600019E RID: 414 RVA: 0x000069F8 File Offset: 0x00004BF8
		public static string ExplorerWarningMsg
		{
			get
			{
				return Resources.ResourceManager.GetString("ExplorerWarningMsg", Resources.resourceCulture);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600019F RID: 415 RVA: 0x00006A0E File Offset: 0x00004C0E
		public static string Finish
		{
			get
			{
				return Resources.ResourceManager.GetString("Finish", Resources.resourceCulture);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00006A24 File Offset: 0x00004C24
		public static string FolderExists
		{
			get
			{
				return Resources.ResourceManager.GetString("FolderExists", Resources.resourceCulture);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00006A3A File Offset: 0x00004C3A
		public static string FreeString
		{
			get
			{
				return Resources.ResourceManager.GetString("FreeString", Resources.resourceCulture);
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00006A50 File Offset: 0x00004C50
		public static string From
		{
			get
			{
				return Resources.ResourceManager.GetString("From", Resources.resourceCulture);
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00006A66 File Offset: 0x00004C66
		public static string FTAtext
		{
			get
			{
				return Resources.ResourceManager.GetString("FTAtext", Resources.resourceCulture);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00006A7C File Offset: 0x00004C7C
		public static string FTATopText
		{
			get
			{
				return Resources.ResourceManager.GetString("FTATopText", Resources.resourceCulture);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00006A92 File Offset: 0x00004C92
		public static string FTAURL
		{
			get
			{
				return Resources.ResourceManager.GetString("FTAURL", Resources.resourceCulture);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00006AA8 File Offset: 0x00004CA8
		public static string FTAURLtext
		{
			get
			{
				return Resources.ResourceManager.GetString("FTAURLtext", Resources.resourceCulture);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00006ABE File Offset: 0x00004CBE
		public static string Latest
		{
			get
			{
				return Resources.ResourceManager.GetString("Latest", Resources.resourceCulture);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00006AD4 File Offset: 0x00004CD4
		public static string LearnMore
		{
			get
			{
				return Resources.ResourceManager.GetString("LearnMore", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00006AEA File Offset: 0x00004CEA
		public static string LibraryFolders
		{
			get
			{
				return Resources.ResourceManager.GetString("LibraryFolders", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00006B00 File Offset: 0x00004D00
		public static string LibraryFoldersTransferred
		{
			get
			{
				return Resources.ResourceManager.GetString("LibraryFoldersTransferred", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001AB RID: 427 RVA: 0x00006B16 File Offset: 0x00004D16
		public static string Music
		{
			get
			{
				return Resources.ResourceManager.GetString("Music", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00006B2C File Offset: 0x00004D2C
		public static string NewPC
		{
			get
			{
				return Resources.ResourceManager.GetString("NewPC", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001AD RID: 429 RVA: 0x00006B42 File Offset: 0x00004D42
		public static string Next
		{
			get
			{
				return Resources.ResourceManager.GetString("Next", Resources.resourceCulture);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001AE RID: 430 RVA: 0x00006B58 File Offset: 0x00004D58
		public static string NoSecond
		{
			get
			{
				return Resources.ResourceManager.GetString("NoSecond", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001AF RID: 431 RVA: 0x00006B6E File Offset: 0x00004D6E
		public static string NoSource
		{
			get
			{
				return Resources.ResourceManager.GetString("NoSource", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00006B84 File Offset: 0x00004D84
		public static string OneDriveMapped
		{
			get
			{
				return Resources.ResourceManager.GetString("OneDriveMapped", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00006B9A File Offset: 0x00004D9A
		public static string Overwrite
		{
			get
			{
				return Resources.ResourceManager.GetString("Overwrite", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00006BB0 File Offset: 0x00004DB0
		public static string PickFolderDesc
		{
			get
			{
				return Resources.ResourceManager.GetString("PickFolderDesc", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00006BC6 File Offset: 0x00004DC6
		public static string PickFoldersTitle
		{
			get
			{
				return Resources.ResourceManager.GetString("PickFoldersTitle", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x00006BDC File Offset: 0x00004DDC
		public static string PickFoldersTo
		{
			get
			{
				return Resources.ResourceManager.GetString("PickFoldersTo", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00006BF2 File Offset: 0x00004DF2
		public static string PickFoldersToDesc
		{
			get
			{
				return Resources.ResourceManager.GetString("PickFoldersToDesc", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00006C08 File Offset: 0x00004E08
		public static string PickProgramsDesc
		{
			get
			{
				return Resources.ResourceManager.GetString("PickProgramsDesc", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00006C1E File Offset: 0x00004E1E
		public static string PickProgramsTitle
		{
			get
			{
				return Resources.ResourceManager.GetString("PickProgramsTitle", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00006C34 File Offset: 0x00004E34
		public static string Pictures
		{
			get
			{
				return Resources.ResourceManager.GetString("Pictures", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00006C4A File Offset: 0x00004E4A
		public static string ReconfigurationError
		{
			get
			{
				return Resources.ResourceManager.GetString("ReconfigurationError", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00006C60 File Offset: 0x00004E60
		public static string ReconfigurationErrorMsg
		{
			get
			{
				return Resources.ResourceManager.GetString("ReconfigurationErrorMsg", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001BB RID: 443 RVA: 0x00006C76 File Offset: 0x00004E76
		public static string ReconfigureError1
		{
			get
			{
				return Resources.ResourceManager.GetString("ReconfigureError1", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001BC RID: 444 RVA: 0x00006C8C File Offset: 0x00004E8C
		public static string ReconfigureError2
		{
			get
			{
				return Resources.ResourceManager.GetString("ReconfigureError2", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006CA2 File Offset: 0x00004EA2
		public static string ReconfigureError3
		{
			get
			{
				return Resources.ResourceManager.GetString("ReconfigureError3", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00006CB8 File Offset: 0x00004EB8
		public static string RegCountry
		{
			get
			{
				return Resources.ResourceManager.GetString("RegCountry", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00006CCE File Offset: 0x00004ECE
		public static string Register
		{
			get
			{
				return Resources.ResourceManager.GetString("Register", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00006CE4 File Offset: 0x00004EE4
		public static string RegisterExplain
		{
			get
			{
				return Resources.ResourceManager.GetString("RegisterExplain", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00006CFA File Offset: 0x00004EFA
		public static string RegLang
		{
			get
			{
				return Resources.ResourceManager.GetString("RegLang", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00006D10 File Offset: 0x00004F10
		public static string RegProdNum
		{
			get
			{
				return Resources.ResourceManager.GetString("RegProdNum", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00006D26 File Offset: 0x00004F26
		public static string RegUrl
		{
			get
			{
				return Resources.ResourceManager.GetString("RegUrl", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00006D3C File Offset: 0x00004F3C
		public static string RegVendorID
		{
			get
			{
				return Resources.ResourceManager.GetString("RegVendorID", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00006D52 File Offset: 0x00004F52
		public static string SelectAll
		{
			get
			{
				return Resources.ResourceManager.GetString("SelectAll", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00006D68 File Offset: 0x00004F68
		public static string Size
		{
			get
			{
				return Resources.ResourceManager.GetString("Size", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00006D7E File Offset: 0x00004F7E
		public static string SizeWarning
		{
			get
			{
				return Resources.ResourceManager.GetString("SizeWarning", Resources.resourceCulture);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00006D94 File Offset: 0x00004F94
		public static string SizeWarningDescription
		{
			get
			{
				return Resources.ResourceManager.GetString("SizeWarningDescription", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00006DAA File Offset: 0x00004FAA
		public static string SkipOrReplace
		{
			get
			{
				return Resources.ResourceManager.GetString("SkipOrReplace", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00006DC0 File Offset: 0x00004FC0
		public static string SourceDoesNotExist
		{
			get
			{
				return Resources.ResourceManager.GetString("SourceDoesNotExist", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00006DD6 File Offset: 0x00004FD6
		public static string Summary
		{
			get
			{
				return Resources.ResourceManager.GetString("Summary", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00006DEC File Offset: 0x00004FEC
		public static string SummaryDesc
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryDesc", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00006E02 File Offset: 0x00005002
		public static string SummaryDocuments
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryDocuments", Resources.resourceCulture);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00006E18 File Offset: 0x00005018
		public static string SummaryDownloads
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryDownloads", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00006E2E File Offset: 0x0000502E
		public static string SummaryMusic
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryMusic", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00006E44 File Offset: 0x00005044
		public static string SummaryPictures
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryPictures", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00006E5A File Offset: 0x0000505A
		public static string SummaryRestart
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryRestart", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00006E70 File Offset: 0x00005070
		public static string SummaryVideos
		{
			get
			{
				return Resources.ResourceManager.GetString("SummaryVideos", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00006E86 File Offset: 0x00005086
		public static string Title
		{
			get
			{
				return Resources.ResourceManager.GetString("Title", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00006E9C File Offset: 0x0000509C
		public static string To
		{
			get
			{
				return Resources.ResourceManager.GetString("To", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00006EB2 File Offset: 0x000050B2
		public static string Transfer
		{
			get
			{
				return Resources.ResourceManager.GetString("Transfer", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00006EC8 File Offset: 0x000050C8
		public static string Undo
		{
			get
			{
				return Resources.ResourceManager.GetString("Undo", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00006EDE File Offset: 0x000050DE
		public static string UndoText
		{
			get
			{
				return Resources.ResourceManager.GetString("UndoText", Resources.resourceCulture);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00006EF4 File Offset: 0x000050F4
		public static string Upsell
		{
			get
			{
				return Resources.ResourceManager.GetString("Upsell", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00006F0A File Offset: 0x0000510A
		public static string Upsell2
		{
			get
			{
				return Resources.ResourceManager.GetString("Upsell2", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00006F20 File Offset: 0x00005120
		public static string URL_Upsell
		{
			get
			{
				return Resources.ResourceManager.GetString("URL_Upsell", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00006F36 File Offset: 0x00005136
		public static string Version
		{
			get
			{
				return Resources.ResourceManager.GetString("Version", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00006F4C File Offset: 0x0000514C
		public static string Videos
		{
			get
			{
				return Resources.ResourceManager.GetString("Videos", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00006F62 File Offset: 0x00005162
		public static string Warning
		{
			get
			{
				return Resources.ResourceManager.GetString("Warning", Resources.resourceCulture);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00006F78 File Offset: 0x00005178
		public static string What
		{
			get
			{
				return Resources.ResourceManager.GetString("What", Resources.resourceCulture);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00006F8E File Offset: 0x0000518E
		public static string WhatDesc
		{
			get
			{
				return Resources.ResourceManager.GetString("WhatDesc", Resources.resourceCulture);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00006FA4 File Offset: 0x000051A4
		public static string YourEmail
		{
			get
			{
				return Resources.ResourceManager.GetString("YourEmail", Resources.resourceCulture);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00006FBA File Offset: 0x000051BA
		public static string YourFirstName
		{
			get
			{
				return Resources.ResourceManager.GetString("YourFirstName", Resources.resourceCulture);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00006FD0 File Offset: 0x000051D0
		public static string YourLastName
		{
			get
			{
				return Resources.ResourceManager.GetString("YourLastName", Resources.resourceCulture);
			}
		}

		// Token: 0x040000A8 RID: 168
		private static ResourceManager resourceMan;

		// Token: 0x040000A9 RID: 169
		private static CultureInfo resourceCulture;
	}
}
