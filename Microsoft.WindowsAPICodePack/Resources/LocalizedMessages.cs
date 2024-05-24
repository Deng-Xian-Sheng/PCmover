using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.WindowsAPICodePack.Resources
{
	// Token: 0x02000049 RID: 73
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class LocalizedMessages
	{
		// Token: 0x0600019D RID: 413 RVA: 0x00006535 File Offset: 0x00004735
		internal LocalizedMessages()
		{
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600019E RID: 414 RVA: 0x00006540 File Offset: 0x00004740
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(LocalizedMessages.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Microsoft.WindowsAPICodePack.Resources.LocalizedMessages", typeof(LocalizedMessages).Assembly);
					LocalizedMessages.resourceMan = resourceManager;
				}
				return LocalizedMessages.resourceMan;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0000658C File Offset: 0x0000478C
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x000065A3 File Offset: 0x000047A3
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return LocalizedMessages.resourceCulture;
			}
			set
			{
				LocalizedMessages.resourceCulture = value;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x000065AC File Offset: 0x000047AC
		internal static string ApplicationRecoverFailedToRegisterForRestartBadParameters
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoverFailedToRegisterForRestartBadParameters", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x000065D4 File Offset: 0x000047D4
		internal static string ApplicationRecoveryBadParameters
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryBadParameters", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x000065FC File Offset: 0x000047FC
		internal static string ApplicationRecoveryFailedToRegister
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryFailedToRegister", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00006624 File Offset: 0x00004824
		internal static string ApplicationRecoveryFailedToRegisterForRestart
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryFailedToRegisterForRestart", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x0000664C File Offset: 0x0000484C
		internal static string ApplicationRecoveryFailedToUnregister
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryFailedToUnregister", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00006674 File Offset: 0x00004874
		internal static string ApplicationRecoveryFailedToUnregisterForRestart
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryFailedToUnregisterForRestart", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000669C File Offset: 0x0000489C
		internal static string ApplicationRecoveryMustBeCalledFromCallback
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ApplicationRecoveryMustBeCalledFromCallback", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x000066C4 File Offset: 0x000048C4
		internal static string BatteryStateStringRepresentation
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("BatteryStateStringRepresentation", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x000066EC File Offset: 0x000048EC
		internal static string CancelableCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CancelableCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00006714 File Offset: 0x00004914
		internal static string CaptionCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CaptionCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001AB RID: 427 RVA: 0x0000673C File Offset: 0x0000493C
		internal static string CheckBoxCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CheckBoxCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00006764 File Offset: 0x00004964
		internal static string CollapsedTextCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CollapsedTextCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001AD RID: 429 RVA: 0x0000678C File Offset: 0x0000498C
		internal static string CoreHelpersRunningOn7
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CoreHelpersRunningOn7", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000067B4 File Offset: 0x000049B4
		internal static string CoreHelpersRunningOnVista
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CoreHelpersRunningOnVista", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000067DC File Offset: 0x000049DC
		internal static string CoreHelpersRunningOnXp
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("CoreHelpersRunningOnXp", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x00006804 File Offset: 0x00004A04
		internal static string DialogCollectionCannotHaveDuplicateNames
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogCollectionCannotHaveDuplicateNames", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x0000682C File Offset: 0x00004A2C
		internal static string DialogCollectionControlAlreadyHosted
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogCollectionControlAlreadyHosted", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x00006854 File Offset: 0x00004A54
		internal static string DialogCollectionControlNameNull
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogCollectionControlNameNull", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x0000687C File Offset: 0x00004A7C
		internal static string DialogCollectionModifyShowingDialog
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogCollectionModifyShowingDialog", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x000068A4 File Offset: 0x00004AA4
		internal static string DialogControlNameCannotBeEmpty
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlNameCannotBeEmpty", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x000068CC File Offset: 0x00004ACC
		internal static string DialogControlsCannotBeRenamed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogControlsCannotBeRenamed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000068F4 File Offset: 0x00004AF4
		internal static string DialogDefaultCaption
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogDefaultCaption", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x0000691C File Offset: 0x00004B1C
		internal static string DialogDefaultContent
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogDefaultContent", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00006944 File Offset: 0x00004B44
		internal static string DialogDefaultMainInstruction
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("DialogDefaultMainInstruction", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x0000696C File Offset: 0x00004B6C
		internal static string ExpandedDetailsCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExpandedDetailsCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001BA RID: 442 RVA: 0x00006994 File Offset: 0x00004B94
		internal static string ExpandedLabelCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExpandedLabelCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000069BC File Offset: 0x00004BBC
		internal static string ExpandingStateCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ExpandingStateCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001BC RID: 444 RVA: 0x000069E4 File Offset: 0x00004BE4
		internal static string HyperlinksCannotBetSet
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("HyperlinksCannotBetSet", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006A0C File Offset: 0x00004C0C
		internal static string InvalidReferencePath
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("InvalidReferencePath", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00006A34 File Offset: 0x00004C34
		internal static string MessageManagerHandlerNotRegistered
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("MessageManagerHandlerNotRegistered", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00006A5C File Offset: 0x00004C5C
		internal static string NativeTaskDialogConfigurationError
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NativeTaskDialogConfigurationError", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x00006A84 File Offset: 0x00004C84
		internal static string NativeTaskDialogInternalErrorArgs
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NativeTaskDialogInternalErrorArgs", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00006AAC File Offset: 0x00004CAC
		internal static string NativeTaskDialogInternalErrorComplex
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NativeTaskDialogInternalErrorComplex", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00006AD4 File Offset: 0x00004CD4
		internal static string NativeTaskDialogInternalErrorUnexpected
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NativeTaskDialogInternalErrorUnexpected", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00006AFC File Offset: 0x00004CFC
		internal static string NativeTaskDialogVersionError
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("NativeTaskDialogVersionError", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00006B24 File Offset: 0x00004D24
		internal static string OwnerCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("OwnerCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00006B4C File Offset: 0x00004D4C
		internal static string PowerExecutionStateFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PowerExecutionStateFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00006B74 File Offset: 0x00004D74
		internal static string PowerInsufficientAccessBatteryState
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PowerInsufficientAccessBatteryState", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00006B9C File Offset: 0x00004D9C
		internal static string PowerInsufficientAccessCapabilities
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PowerInsufficientAccessCapabilities", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00006BC4 File Offset: 0x00004DC4
		internal static string PowerManagerActiveSchemeFailed
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PowerManagerActiveSchemeFailed", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00006BEC File Offset: 0x00004DEC
		internal static string PowerManagerBatteryNotPresent
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PowerManagerBatteryNotPresent", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00006C14 File Offset: 0x00004E14
		internal static string ProgressBarCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ProgressBarCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001CB RID: 459 RVA: 0x00006C3C File Offset: 0x00004E3C
		internal static string ProgressBarCannotBeHostedInMultipleDialogs
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("ProgressBarCannotBeHostedInMultipleDialogs", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00006C64 File Offset: 0x00004E64
		internal static string PropertyKeyFormatString
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropertyKeyFormatString", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00006C8C File Offset: 0x00004E8C
		internal static string PropVariantInitializationError
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropVariantInitializationError", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001CE RID: 462 RVA: 0x00006CB4 File Offset: 0x00004EB4
		internal static string PropVariantMultiDimArray
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropVariantMultiDimArray", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001CF RID: 463 RVA: 0x00006CDC File Offset: 0x00004EDC
		internal static string PropVariantNullString
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropVariantNullString", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00006D04 File Offset: 0x00004F04
		internal static string PropVariantTypeNotSupported
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropVariantTypeNotSupported", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00006D2C File Offset: 0x00004F2C
		internal static string PropVariantUnsupportedType
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("PropVariantUnsupportedType", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00006D54 File Offset: 0x00004F54
		internal static string RecoverySettingsFormatString
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("RecoverySettingsFormatString", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x00006D7C File Offset: 0x00004F7C
		internal static string RestartSettingsFormatString
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("RestartSettingsFormatString", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00006DA4 File Offset: 0x00004FA4
		internal static string StandardButtonsCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StandardButtonsCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00006DCC File Offset: 0x00004FCC
		internal static string StartupLocationCannotBeChanged
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("StartupLocationCannotBeChanged", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00006DF4 File Offset: 0x00004FF4
		internal static string TaskDialogBadButtonId
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogBadButtonId", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00006E1C File Offset: 0x0000501C
		internal static string TaskDialogButtonTextEmpty
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogButtonTextEmpty", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00006E44 File Offset: 0x00005044
		internal static string TaskDialogCheckBoxTextRequiredToEnableCheckBox
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogCheckBoxTextRequiredToEnableCheckBox", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00006E6C File Offset: 0x0000506C
		internal static string TaskDialogCloseNonShowing
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogCloseNonShowing", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00006E94 File Offset: 0x00005094
		internal static string TaskDialogDefaultCaption
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogDefaultCaption", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001DB RID: 475 RVA: 0x00006EBC File Offset: 0x000050BC
		internal static string TaskDialogDefaultContent
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogDefaultContent", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00006EE4 File Offset: 0x000050E4
		internal static string TaskDialogDefaultMainInstruction
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogDefaultMainInstruction", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001DD RID: 477 RVA: 0x00006F0C File Offset: 0x0000510C
		internal static string TaskDialogOnlyOneDefaultControl
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogOnlyOneDefaultControl", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00006F34 File Offset: 0x00005134
		internal static string TaskDialogProgressBarMaxValueGreaterThanMin
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogProgressBarMaxValueGreaterThanMin", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00006F5C File Offset: 0x0000515C
		internal static string TaskDialogProgressBarMinValueGreaterThanZero
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogProgressBarMinValueGreaterThanZero", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00006F84 File Offset: 0x00005184
		internal static string TaskDialogProgressBarMinValueLessThanMax
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogProgressBarMinValueLessThanMax", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x00006FAC File Offset: 0x000051AC
		internal static string TaskDialogProgressBarValueInRange
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogProgressBarValueInRange", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x00006FD4 File Offset: 0x000051D4
		internal static string TaskDialogSupportedButtonsAndButtons
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogSupportedButtonsAndButtons", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00006FFC File Offset: 0x000051FC
		internal static string TaskDialogSupportedButtonsAndLinks
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogSupportedButtonsAndLinks", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00007024 File Offset: 0x00005224
		internal static string TaskDialogUnkownControl
		{
			get
			{
				return LocalizedMessages.ResourceManager.GetString("TaskDialogUnkownControl", LocalizedMessages.resourceCulture);
			}
		}

		// Token: 0x0400026A RID: 618
		private static ResourceManager resourceMan;

		// Token: 0x0400026B RID: 619
		private static CultureInfo resourceCulture;
	}
}
