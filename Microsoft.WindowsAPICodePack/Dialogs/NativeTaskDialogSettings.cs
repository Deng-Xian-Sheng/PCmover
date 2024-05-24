using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000024 RID: 36
	internal class NativeTaskDialogSettings
	{
		// Token: 0x060000C0 RID: 192 RVA: 0x00003700 File Offset: 0x00001900
		internal NativeTaskDialogSettings()
		{
			this.NativeConfiguration = new TaskDialogNativeMethods.TaskDialogConfiguration();
			this.NativeConfiguration.size = (uint)Marshal.SizeOf(this.NativeConfiguration);
			this.NativeConfiguration.parentHandle = IntPtr.Zero;
			this.NativeConfiguration.instance = IntPtr.Zero;
			this.NativeConfiguration.taskDialogFlags = TaskDialogNativeMethods.TaskDialogOptions.AllowCancel;
			this.NativeConfiguration.commonButtons = TaskDialogNativeMethods.TaskDialogCommonButtons.Ok;
			this.NativeConfiguration.mainIcon = new TaskDialogNativeMethods.IconUnion(0);
			this.NativeConfiguration.footerIcon = new TaskDialogNativeMethods.IconUnion(0);
			this.NativeConfiguration.width = 0U;
			this.NativeConfiguration.buttonCount = 0U;
			this.NativeConfiguration.radioButtonCount = 0U;
			this.NativeConfiguration.buttons = IntPtr.Zero;
			this.NativeConfiguration.radioButtons = IntPtr.Zero;
			this.NativeConfiguration.defaultButtonIndex = 0;
			this.NativeConfiguration.defaultRadioButtonIndex = 0;
			this.NativeConfiguration.windowTitle = TaskDialogDefaults.Caption;
			this.NativeConfiguration.mainInstruction = TaskDialogDefaults.MainInstruction;
			this.NativeConfiguration.content = TaskDialogDefaults.Content;
			this.NativeConfiguration.verificationText = null;
			this.NativeConfiguration.expandedInformation = null;
			this.NativeConfiguration.expandedControlText = null;
			this.NativeConfiguration.collapsedControlText = null;
			this.NativeConfiguration.footerText = null;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000385C File Offset: 0x00001A5C
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x00003873 File Offset: 0x00001A73
		public int ProgressBarMinimum { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000387C File Offset: 0x00001A7C
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00003893 File Offset: 0x00001A93
		public int ProgressBarMaximum { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000389C File Offset: 0x00001A9C
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x000038B3 File Offset: 0x00001AB3
		public int ProgressBarValue { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x000038BC File Offset: 0x00001ABC
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x000038D3 File Offset: 0x00001AD3
		public TaskDialogProgressBarState ProgressBarState { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x000038DC File Offset: 0x00001ADC
		// (set) Token: 0x060000CA RID: 202 RVA: 0x000038F3 File Offset: 0x00001AF3
		public bool InvokeHelp { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000CB RID: 203 RVA: 0x000038FC File Offset: 0x00001AFC
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00003913 File Offset: 0x00001B13
		public TaskDialogNativeMethods.TaskDialogConfiguration NativeConfiguration { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000391C File Offset: 0x00001B1C
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00003933 File Offset: 0x00001B33
		public TaskDialogNativeMethods.TaskDialogButton[] Buttons { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000393C File Offset: 0x00001B3C
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00003953 File Offset: 0x00001B53
		public TaskDialogNativeMethods.TaskDialogButton[] RadioButtons { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000395C File Offset: 0x00001B5C
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x00003973 File Offset: 0x00001B73
		public List<int> ElevatedButtons { get; set; }
	}
}
