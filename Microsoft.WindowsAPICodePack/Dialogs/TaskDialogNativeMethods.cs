using System;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000025 RID: 37
	internal static class TaskDialogNativeMethods
	{
		// Token: 0x060000D3 RID: 211
		[DllImport("Comctl32.dll", SetLastError = true)]
		internal static extern HResult TaskDialogIndirect([In] TaskDialogNativeMethods.TaskDialogConfiguration taskConfig, out int button, out int radioButton, [MarshalAs(UnmanagedType.Bool)] out bool verificationFlagChecked);

		// Token: 0x04000196 RID: 406
		internal const int TaskDialogIdealWidth = 0;

		// Token: 0x04000197 RID: 407
		internal const int TaskDialogButtonShieldIcon = 1;

		// Token: 0x04000198 RID: 408
		internal const int NoDefaultButtonSpecified = 0;

		// Token: 0x02000026 RID: 38
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		internal class TaskDialogConfiguration
		{
			// Token: 0x04000199 RID: 409
			internal uint size;

			// Token: 0x0400019A RID: 410
			internal IntPtr parentHandle;

			// Token: 0x0400019B RID: 411
			internal IntPtr instance;

			// Token: 0x0400019C RID: 412
			internal TaskDialogNativeMethods.TaskDialogOptions taskDialogFlags;

			// Token: 0x0400019D RID: 413
			internal TaskDialogNativeMethods.TaskDialogCommonButtons commonButtons;

			// Token: 0x0400019E RID: 414
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string windowTitle;

			// Token: 0x0400019F RID: 415
			internal TaskDialogNativeMethods.IconUnion mainIcon;

			// Token: 0x040001A0 RID: 416
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string mainInstruction;

			// Token: 0x040001A1 RID: 417
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string content;

			// Token: 0x040001A2 RID: 418
			internal uint buttonCount;

			// Token: 0x040001A3 RID: 419
			internal IntPtr buttons;

			// Token: 0x040001A4 RID: 420
			internal int defaultButtonIndex;

			// Token: 0x040001A5 RID: 421
			internal uint radioButtonCount;

			// Token: 0x040001A6 RID: 422
			internal IntPtr radioButtons;

			// Token: 0x040001A7 RID: 423
			internal int defaultRadioButtonIndex;

			// Token: 0x040001A8 RID: 424
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string verificationText;

			// Token: 0x040001A9 RID: 425
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string expandedInformation;

			// Token: 0x040001AA RID: 426
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string expandedControlText;

			// Token: 0x040001AB RID: 427
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string collapsedControlText;

			// Token: 0x040001AC RID: 428
			internal TaskDialogNativeMethods.IconUnion footerIcon;

			// Token: 0x040001AD RID: 429
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string footerText;

			// Token: 0x040001AE RID: 430
			internal TaskDialogNativeMethods.TaskDialogCallback callback;

			// Token: 0x040001AF RID: 431
			internal IntPtr callbackData;

			// Token: 0x040001B0 RID: 432
			internal uint width;
		}

		// Token: 0x02000027 RID: 39
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
		internal struct IconUnion
		{
			// Token: 0x060000D5 RID: 213 RVA: 0x00003984 File Offset: 0x00001B84
			internal IconUnion(int i)
			{
				this.spacer = IntPtr.Zero;
				this.mainIcon = i;
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000399C File Offset: 0x00001B9C
			public int MainIcon
			{
				get
				{
					return this.mainIcon;
				}
			}

			// Token: 0x040001B1 RID: 433
			[FieldOffset(0)]
			private int mainIcon;

			// Token: 0x040001B2 RID: 434
			[FieldOffset(0)]
			private IntPtr spacer;
		}

		// Token: 0x02000028 RID: 40
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		internal struct TaskDialogButton
		{
			// Token: 0x060000D7 RID: 215 RVA: 0x000039B4 File Offset: 0x00001BB4
			public TaskDialogButton(int buttonId, string text)
			{
				this.buttonId = buttonId;
				this.buttonText = text;
			}

			// Token: 0x040001B3 RID: 435
			internal int buttonId;

			// Token: 0x040001B4 RID: 436
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string buttonText;
		}

		// Token: 0x02000029 RID: 41
		[Flags]
		internal enum TaskDialogCommonButtons
		{
			// Token: 0x040001B6 RID: 438
			Ok = 1,
			// Token: 0x040001B7 RID: 439
			Yes = 2,
			// Token: 0x040001B8 RID: 440
			No = 4,
			// Token: 0x040001B9 RID: 441
			Cancel = 8,
			// Token: 0x040001BA RID: 442
			Retry = 16,
			// Token: 0x040001BB RID: 443
			Close = 32
		}

		// Token: 0x0200002A RID: 42
		internal enum TaskDialogCommonButtonReturnIds
		{
			// Token: 0x040001BD RID: 445
			Ok = 1,
			// Token: 0x040001BE RID: 446
			Cancel,
			// Token: 0x040001BF RID: 447
			Abort,
			// Token: 0x040001C0 RID: 448
			Retry,
			// Token: 0x040001C1 RID: 449
			Ignore,
			// Token: 0x040001C2 RID: 450
			Yes,
			// Token: 0x040001C3 RID: 451
			No,
			// Token: 0x040001C4 RID: 452
			Close
		}

		// Token: 0x0200002B RID: 43
		internal enum TaskDialogElements
		{
			// Token: 0x040001C6 RID: 454
			Content,
			// Token: 0x040001C7 RID: 455
			ExpandedInformation,
			// Token: 0x040001C8 RID: 456
			Footer,
			// Token: 0x040001C9 RID: 457
			MainInstruction
		}

		// Token: 0x0200002C RID: 44
		internal enum TaskDialogIconElement
		{
			// Token: 0x040001CB RID: 459
			Main,
			// Token: 0x040001CC RID: 460
			Footer
		}

		// Token: 0x0200002D RID: 45
		[Flags]
		internal enum TaskDialogOptions
		{
			// Token: 0x040001CE RID: 462
			None = 0,
			// Token: 0x040001CF RID: 463
			EnableHyperlinks = 1,
			// Token: 0x040001D0 RID: 464
			UseMainIcon = 2,
			// Token: 0x040001D1 RID: 465
			UseFooterIcon = 4,
			// Token: 0x040001D2 RID: 466
			AllowCancel = 8,
			// Token: 0x040001D3 RID: 467
			UseCommandLinks = 16,
			// Token: 0x040001D4 RID: 468
			UseNoIconCommandLinks = 32,
			// Token: 0x040001D5 RID: 469
			ExpandFooterArea = 64,
			// Token: 0x040001D6 RID: 470
			ExpandedByDefault = 128,
			// Token: 0x040001D7 RID: 471
			CheckVerificationFlag = 256,
			// Token: 0x040001D8 RID: 472
			ShowProgressBar = 512,
			// Token: 0x040001D9 RID: 473
			ShowMarqueeProgressBar = 1024,
			// Token: 0x040001DA RID: 474
			UseCallbackTimer = 2048,
			// Token: 0x040001DB RID: 475
			PositionRelativeToWindow = 4096,
			// Token: 0x040001DC RID: 476
			RightToLeftLayout = 8192,
			// Token: 0x040001DD RID: 477
			NoDefaultRadioButton = 16384
		}

		// Token: 0x0200002E RID: 46
		internal enum TaskDialogMessages
		{
			// Token: 0x040001DF RID: 479
			NavigatePage = 1125,
			// Token: 0x040001E0 RID: 480
			ClickButton,
			// Token: 0x040001E1 RID: 481
			SetMarqueeProgressBar,
			// Token: 0x040001E2 RID: 482
			SetProgressBarState,
			// Token: 0x040001E3 RID: 483
			SetProgressBarRange,
			// Token: 0x040001E4 RID: 484
			SetProgressBarPosition,
			// Token: 0x040001E5 RID: 485
			SetProgressBarMarquee,
			// Token: 0x040001E6 RID: 486
			SetElementText,
			// Token: 0x040001E7 RID: 487
			ClickRadioButton = 1134,
			// Token: 0x040001E8 RID: 488
			EnableButton,
			// Token: 0x040001E9 RID: 489
			EnableRadioButton,
			// Token: 0x040001EA RID: 490
			ClickVerification,
			// Token: 0x040001EB RID: 491
			UpdateElementText,
			// Token: 0x040001EC RID: 492
			SetButtonElevationRequiredState,
			// Token: 0x040001ED RID: 493
			UpdateIcon
		}

		// Token: 0x0200002F RID: 47
		internal enum TaskDialogNotifications
		{
			// Token: 0x040001EF RID: 495
			Created,
			// Token: 0x040001F0 RID: 496
			Navigated,
			// Token: 0x040001F1 RID: 497
			ButtonClicked,
			// Token: 0x040001F2 RID: 498
			HyperlinkClicked,
			// Token: 0x040001F3 RID: 499
			Timer,
			// Token: 0x040001F4 RID: 500
			Destroyed,
			// Token: 0x040001F5 RID: 501
			RadioButtonClicked,
			// Token: 0x040001F6 RID: 502
			Constructed,
			// Token: 0x040001F7 RID: 503
			VerificationClicked,
			// Token: 0x040001F8 RID: 504
			Help,
			// Token: 0x040001F9 RID: 505
			ExpandButtonClicked
		}

		// Token: 0x02000030 RID: 48
		// (Invoke) Token: 0x060000D9 RID: 217
		internal delegate int TaskDialogCallback(IntPtr hwnd, uint message, IntPtr wparam, IntPtr lparam, IntPtr referenceData);

		// Token: 0x02000031 RID: 49
		internal enum ProgressBarState
		{
			// Token: 0x040001FB RID: 507
			Normal = 1,
			// Token: 0x040001FC RID: 508
			Error,
			// Token: 0x040001FD RID: 509
			Paused
		}

		// Token: 0x02000032 RID: 50
		internal enum TaskDialogIcons
		{
			// Token: 0x040001FF RID: 511
			Warning = 65535,
			// Token: 0x04000200 RID: 512
			Error = 65534,
			// Token: 0x04000201 RID: 513
			Information = 65533,
			// Token: 0x04000202 RID: 514
			Shield = 65532
		}
	}
}
