using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x0200004E RID: 78
	public sealed class TaskDialog : IDialogControlHost, IDisposable
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060001ED RID: 493 RVA: 0x00007130 File Offset: 0x00005330
		// (remove) Token: 0x060001EE RID: 494 RVA: 0x0000716C File Offset: 0x0000536C
		public event EventHandler<TaskDialogTickEventArgs> Tick;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060001EF RID: 495 RVA: 0x000071A8 File Offset: 0x000053A8
		// (remove) Token: 0x060001F0 RID: 496 RVA: 0x000071E4 File Offset: 0x000053E4
		public event EventHandler<TaskDialogHyperlinkClickedEventArgs> HyperlinkClick;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060001F1 RID: 497 RVA: 0x00007220 File Offset: 0x00005420
		// (remove) Token: 0x060001F2 RID: 498 RVA: 0x0000725C File Offset: 0x0000545C
		public event EventHandler<TaskDialogClosingEventArgs> Closing;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060001F3 RID: 499 RVA: 0x00007298 File Offset: 0x00005498
		// (remove) Token: 0x060001F4 RID: 500 RVA: 0x000072D4 File Offset: 0x000054D4
		public event EventHandler HelpInvoked;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060001F5 RID: 501 RVA: 0x00007310 File Offset: 0x00005510
		// (remove) Token: 0x060001F6 RID: 502 RVA: 0x0000734C File Offset: 0x0000554C
		public event EventHandler Opened;

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00007388 File Offset: 0x00005588
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x000073A0 File Offset: 0x000055A0
		public IntPtr OwnerWindowHandle
		{
			get
			{
				return this.ownerWindow;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.OwnerCannotBeChanged);
				this.ownerWindow = value;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x000073B8 File Offset: 0x000055B8
		// (set) Token: 0x060001FA RID: 506 RVA: 0x000073D0 File Offset: 0x000055D0
		public string Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateText(this.text);
				}
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00007408 File Offset: 0x00005608
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00007420 File Offset: 0x00005620
		public string InstructionText
		{
			get
			{
				return this.instructionText;
			}
			set
			{
				this.instructionText = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateInstruction(this.instructionText);
				}
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001FD RID: 509 RVA: 0x00007458 File Offset: 0x00005658
		// (set) Token: 0x060001FE RID: 510 RVA: 0x00007470 File Offset: 0x00005670
		public string Caption
		{
			get
			{
				return this.caption;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.CaptionCannotBeChanged);
				this.caption = value;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001FF RID: 511 RVA: 0x00007488 File Offset: 0x00005688
		// (set) Token: 0x06000200 RID: 512 RVA: 0x000074A0 File Offset: 0x000056A0
		public string FooterText
		{
			get
			{
				return this.footerText;
			}
			set
			{
				this.footerText = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateFooterText(this.footerText);
				}
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000201 RID: 513 RVA: 0x000074D8 File Offset: 0x000056D8
		// (set) Token: 0x06000202 RID: 514 RVA: 0x000074F0 File Offset: 0x000056F0
		public string FooterCheckBoxText
		{
			get
			{
				return this.checkBoxText;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.CheckBoxCannotBeChanged);
				this.checkBoxText = value;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000203 RID: 515 RVA: 0x00007508 File Offset: 0x00005708
		// (set) Token: 0x06000204 RID: 516 RVA: 0x00007520 File Offset: 0x00005720
		public string DetailsExpandedText
		{
			get
			{
				return this.detailsExpandedText;
			}
			set
			{
				this.detailsExpandedText = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateExpandedText(this.detailsExpandedText);
				}
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000205 RID: 517 RVA: 0x00007558 File Offset: 0x00005758
		// (set) Token: 0x06000206 RID: 518 RVA: 0x00007570 File Offset: 0x00005770
		public bool DetailsExpanded
		{
			get
			{
				return this.detailsExpanded;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ExpandingStateCannotBeChanged);
				this.detailsExpanded = value;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00007588 File Offset: 0x00005788
		// (set) Token: 0x06000208 RID: 520 RVA: 0x000075A0 File Offset: 0x000057A0
		public string DetailsExpandedLabel
		{
			get
			{
				return this.detailsExpandedLabel;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ExpandedLabelCannotBeChanged);
				this.detailsExpandedLabel = value;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000209 RID: 521 RVA: 0x000075B8 File Offset: 0x000057B8
		// (set) Token: 0x0600020A RID: 522 RVA: 0x000075D0 File Offset: 0x000057D0
		public string DetailsCollapsedLabel
		{
			get
			{
				return this.detailsCollapsedLabel;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.CollapsedTextCannotBeChanged);
				this.detailsCollapsedLabel = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600020B RID: 523 RVA: 0x000075E8 File Offset: 0x000057E8
		// (set) Token: 0x0600020C RID: 524 RVA: 0x00007600 File Offset: 0x00005800
		public bool Cancelable
		{
			get
			{
				return this.cancelable;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.CancelableCannotBeChanged);
				this.cancelable = value;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00007618 File Offset: 0x00005818
		// (set) Token: 0x0600020E RID: 526 RVA: 0x00007630 File Offset: 0x00005830
		public TaskDialogStandardIcon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateMainIcon(this.icon);
				}
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00007668 File Offset: 0x00005868
		// (set) Token: 0x06000210 RID: 528 RVA: 0x00007680 File Offset: 0x00005880
		public TaskDialogStandardIcon FooterIcon
		{
			get
			{
				return this.footerIcon;
			}
			set
			{
				this.footerIcon = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateFooterIcon(this.footerIcon);
				}
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000211 RID: 529 RVA: 0x000076B8 File Offset: 0x000058B8
		// (set) Token: 0x06000212 RID: 530 RVA: 0x000076D0 File Offset: 0x000058D0
		public TaskDialogStandardButtons StandardButtons
		{
			get
			{
				return this.standardButtons;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.StandardButtonsCannotBeChanged);
				this.standardButtons = value;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000213 RID: 531 RVA: 0x000076E8 File Offset: 0x000058E8
		public DialogControlCollection<TaskDialogControl> Controls
		{
			get
			{
				return this.controls;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00007700 File Offset: 0x00005900
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00007718 File Offset: 0x00005918
		public bool HyperlinksEnabled
		{
			get
			{
				return this.hyperlinksEnabled;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.HyperlinksCannotBetSet);
				this.hyperlinksEnabled = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00007730 File Offset: 0x00005930
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00007754 File Offset: 0x00005954
		public bool? FooterCheckBoxChecked
		{
			get
			{
				return new bool?(this.footerCheckBoxChecked.GetValueOrDefault(false));
			}
			set
			{
				this.footerCheckBoxChecked = value;
				if (this.NativeDialogShowing)
				{
					this.nativeDialog.UpdateCheckBoxChecked(this.footerCheckBoxChecked.Value);
				}
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000218 RID: 536 RVA: 0x00007790 File Offset: 0x00005990
		// (set) Token: 0x06000219 RID: 537 RVA: 0x000077A8 File Offset: 0x000059A8
		public TaskDialogExpandedDetailsLocation ExpansionMode
		{
			get
			{
				return this.expansionMode;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ExpandedDetailsCannotBeChanged);
				this.expansionMode = value;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600021A RID: 538 RVA: 0x000077C0 File Offset: 0x000059C0
		// (set) Token: 0x0600021B RID: 539 RVA: 0x000077D8 File Offset: 0x000059D8
		public TaskDialogStartupLocation StartupLocation
		{
			get
			{
				return this.startupLocation;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.StartupLocationCannotBeChanged);
				this.startupLocation = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600021C RID: 540 RVA: 0x000077F0 File Offset: 0x000059F0
		// (set) Token: 0x0600021D RID: 541 RVA: 0x00007808 File Offset: 0x00005A08
		public TaskDialogProgressBar ProgressBar
		{
			get
			{
				return this.progressBar;
			}
			set
			{
				this.ThrowIfDialogShowing(LocalizedMessages.ProgressBarCannotBeChanged);
				if (value != null)
				{
					if (value.HostingDialog != null)
					{
						throw new InvalidOperationException(LocalizedMessages.ProgressBarCannotBeHostedInMultipleDialogs);
					}
					value.HostingDialog = this;
				}
				this.progressBar = value;
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00007854 File Offset: 0x00005A54
		public TaskDialog()
		{
			CoreHelpers.ThrowIfNotVista();
			this.controls = new DialogControlCollection<TaskDialogControl>(this);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000078B0 File Offset: 0x00005AB0
		public static TaskDialogResult Show(string text)
		{
			return TaskDialog.ShowCoreStatic(text, TaskDialogDefaults.MainInstruction, TaskDialogDefaults.Caption);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000078D4 File Offset: 0x00005AD4
		public static TaskDialogResult Show(string text, string instructionText)
		{
			return TaskDialog.ShowCoreStatic(text, instructionText, TaskDialogDefaults.Caption);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000078F4 File Offset: 0x00005AF4
		public static TaskDialogResult Show(string text, string instructionText, string caption)
		{
			return TaskDialog.ShowCoreStatic(text, instructionText, caption);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00007910 File Offset: 0x00005B10
		public TaskDialogResult Show()
		{
			return this.ShowCore();
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00007928 File Offset: 0x00005B28
		private static TaskDialogResult ShowCoreStatic(string text, string instructionText, string caption)
		{
			CoreHelpers.ThrowIfNotVista();
			if (TaskDialog.staticDialog == null)
			{
				TaskDialog.staticDialog = new TaskDialog();
			}
			TaskDialog.staticDialog.text = text;
			TaskDialog.staticDialog.instructionText = instructionText;
			TaskDialog.staticDialog.caption = caption;
			return TaskDialog.staticDialog.Show();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00007988 File Offset: 0x00005B88
		private TaskDialogResult ShowCore()
		{
			TaskDialogResult result;
			try
			{
				this.SortDialogControls();
				this.ValidateCurrentDialogSettings();
				NativeTaskDialogSettings settings = new NativeTaskDialogSettings();
				this.ApplyCoreSettings(settings);
				this.ApplySupplementalSettings(settings);
				this.nativeDialog = new NativeTaskDialog(settings, this);
				this.nativeDialog.NativeShow();
				result = TaskDialog.ConstructDialogResult(this.nativeDialog);
				this.footerCheckBoxChecked = new bool?(this.nativeDialog.CheckBoxChecked);
			}
			finally
			{
				this.CleanUp();
				this.nativeDialog = null;
			}
			return result;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00007A20 File Offset: 0x00005C20
		private void ValidateCurrentDialogSettings()
		{
			if (this.footerCheckBoxChecked != null && this.footerCheckBoxChecked.Value && string.IsNullOrEmpty(this.checkBoxText))
			{
				throw new InvalidOperationException(LocalizedMessages.TaskDialogCheckBoxTextRequiredToEnableCheckBox);
			}
			if (this.progressBar != null && !this.progressBar.HasValidValues)
			{
				throw new InvalidOperationException(LocalizedMessages.TaskDialogProgressBarValueInRange);
			}
			if (this.buttons.Count > 0 && this.commandLinks.Count > 0)
			{
				throw new NotSupportedException(LocalizedMessages.TaskDialogSupportedButtonsAndLinks);
			}
			if (this.buttons.Count > 0 && this.standardButtons != TaskDialogStandardButtons.None)
			{
				throw new NotSupportedException(LocalizedMessages.TaskDialogSupportedButtonsAndButtons);
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00007AF0 File Offset: 0x00005CF0
		private static TaskDialogResult ConstructDialogResult(NativeTaskDialog native)
		{
			Debug.Assert(native.ShowState == DialogShowState.Closed, "dialog result being constructed for unshown dialog.");
			TaskDialogStandardButtons taskDialogStandardButtons = TaskDialog.MapButtonIdToStandardButton(native.SelectedButtonId);
			TaskDialogResult result;
			if (taskDialogStandardButtons == TaskDialogStandardButtons.None)
			{
				result = TaskDialogResult.CustomButtonClicked;
			}
			else
			{
				result = (TaskDialogResult)taskDialogStandardButtons;
			}
			return result;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00007B40 File Offset: 0x00005D40
		public void Close()
		{
			if (!this.NativeDialogShowing)
			{
				throw new InvalidOperationException(LocalizedMessages.TaskDialogCloseNonShowing);
			}
			this.nativeDialog.NativeClose(TaskDialogResult.Cancel);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00007B74 File Offset: 0x00005D74
		public void Close(TaskDialogResult closingResult)
		{
			if (!this.NativeDialogShowing)
			{
				throw new InvalidOperationException(LocalizedMessages.TaskDialogCloseNonShowing);
			}
			this.nativeDialog.NativeClose(closingResult);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00007BA5 File Offset: 0x00005DA5
		private void ApplyCoreSettings(NativeTaskDialogSettings settings)
		{
			this.ApplyGeneralNativeConfiguration(settings.NativeConfiguration);
			this.ApplyTextConfiguration(settings.NativeConfiguration);
			this.ApplyOptionConfiguration(settings.NativeConfiguration);
			this.ApplyControlConfiguration(settings);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00007BD8 File Offset: 0x00005DD8
		private void ApplyGeneralNativeConfiguration(TaskDialogNativeMethods.TaskDialogConfiguration dialogConfig)
		{
			if (this.ownerWindow != IntPtr.Zero)
			{
				dialogConfig.parentHandle = this.ownerWindow;
			}
			dialogConfig.mainIcon = new TaskDialogNativeMethods.IconUnion((int)this.icon);
			dialogConfig.footerIcon = new TaskDialogNativeMethods.IconUnion((int)this.footerIcon);
			dialogConfig.commonButtons = (TaskDialogNativeMethods.TaskDialogCommonButtons)this.standardButtons;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00007C3C File Offset: 0x00005E3C
		private void ApplyTextConfiguration(TaskDialogNativeMethods.TaskDialogConfiguration dialogConfig)
		{
			dialogConfig.content = this.text;
			dialogConfig.windowTitle = this.caption;
			dialogConfig.mainInstruction = this.instructionText;
			dialogConfig.expandedInformation = this.detailsExpandedText;
			dialogConfig.expandedControlText = this.detailsExpandedLabel;
			dialogConfig.collapsedControlText = this.detailsCollapsedLabel;
			dialogConfig.footerText = this.footerText;
			dialogConfig.verificationText = this.checkBoxText;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00007CAC File Offset: 0x00005EAC
		private void ApplyOptionConfiguration(TaskDialogNativeMethods.TaskDialogConfiguration dialogConfig)
		{
			TaskDialogNativeMethods.TaskDialogOptions taskDialogOptions = TaskDialogNativeMethods.TaskDialogOptions.None;
			if (this.cancelable)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.AllowCancel;
			}
			if (this.footerCheckBoxChecked != null && this.footerCheckBoxChecked.Value)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.CheckVerificationFlag;
			}
			if (this.hyperlinksEnabled)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.EnableHyperlinks;
			}
			if (this.detailsExpanded)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.ExpandedByDefault;
			}
			if (this.Tick != null)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.UseCallbackTimer;
			}
			if (this.startupLocation == TaskDialogStartupLocation.CenterOwner)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.PositionRelativeToWindow;
			}
			if (this.expansionMode == TaskDialogExpandedDetailsLocation.ExpandFooter)
			{
				taskDialogOptions |= TaskDialogNativeMethods.TaskDialogOptions.ExpandFooterArea;
			}
			dialogConfig.taskDialogFlags = taskDialogOptions;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00007D78 File Offset: 0x00005F78
		private void ApplyControlConfiguration(NativeTaskDialogSettings settings)
		{
			if (this.progressBar != null)
			{
				if (this.progressBar.State == TaskDialogProgressBarState.Marquee)
				{
					settings.NativeConfiguration.taskDialogFlags |= TaskDialogNativeMethods.TaskDialogOptions.ShowMarqueeProgressBar;
				}
				else
				{
					settings.NativeConfiguration.taskDialogFlags |= TaskDialogNativeMethods.TaskDialogOptions.ShowProgressBar;
				}
			}
			if (this.buttons.Count > 0 || this.commandLinks.Count > 0)
			{
				List<TaskDialogButtonBase> list = (this.buttons.Count > 0) ? this.buttons : this.commandLinks;
				settings.Buttons = TaskDialog.BuildButtonStructArray(list);
				if (this.commandLinks.Count > 0)
				{
					settings.NativeConfiguration.taskDialogFlags |= TaskDialogNativeMethods.TaskDialogOptions.UseCommandLinks;
				}
				settings.NativeConfiguration.defaultButtonIndex = TaskDialog.FindDefaultButtonId(list);
				TaskDialog.ApplyElevatedIcons(settings, list);
			}
			if (this.radioButtons.Count > 0)
			{
				settings.RadioButtons = TaskDialog.BuildButtonStructArray(this.radioButtons);
				int num = TaskDialog.FindDefaultButtonId(this.radioButtons);
				settings.NativeConfiguration.defaultRadioButtonIndex = num;
				if (num == 0)
				{
					settings.NativeConfiguration.taskDialogFlags |= TaskDialogNativeMethods.TaskDialogOptions.NoDefaultRadioButton;
				}
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00007EDC File Offset: 0x000060DC
		private static TaskDialogNativeMethods.TaskDialogButton[] BuildButtonStructArray(List<TaskDialogButtonBase> controls)
		{
			int count = controls.Count;
			TaskDialogNativeMethods.TaskDialogButton[] array = new TaskDialogNativeMethods.TaskDialogButton[count];
			for (int i = 0; i < count; i++)
			{
				TaskDialogButtonBase taskDialogButtonBase = controls[i];
				array[i] = new TaskDialogNativeMethods.TaskDialogButton(taskDialogButtonBase.Id, taskDialogButtonBase.ToString());
			}
			return array;
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00007F50 File Offset: 0x00006150
		private static int FindDefaultButtonId(List<TaskDialogButtonBase> controls)
		{
			List<TaskDialogButtonBase> list = controls.FindAll((TaskDialogButtonBase control) => control.Default);
			int result;
			if (list.Count == 1)
			{
				result = list[0].Id;
			}
			else
			{
				if (list.Count > 1)
				{
					throw new InvalidOperationException(LocalizedMessages.TaskDialogOnlyOneDefaultControl);
				}
				result = 0;
			}
			return result;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00007FC8 File Offset: 0x000061C8
		private static void ApplyElevatedIcons(NativeTaskDialogSettings settings, List<TaskDialogButtonBase> controls)
		{
			foreach (TaskDialogButtonBase taskDialogButtonBase in controls)
			{
				TaskDialogButton taskDialogButton = (TaskDialogButton)taskDialogButtonBase;
				if (taskDialogButton.UseElevationIcon)
				{
					if (settings.ElevatedButtons == null)
					{
						settings.ElevatedButtons = new List<int>();
					}
					settings.ElevatedButtons.Add(taskDialogButton.Id);
				}
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000805C File Offset: 0x0000625C
		private void ApplySupplementalSettings(NativeTaskDialogSettings settings)
		{
			if (this.progressBar != null)
			{
				if (this.progressBar.State != TaskDialogProgressBarState.Marquee)
				{
					settings.ProgressBarMinimum = this.progressBar.Minimum;
					settings.ProgressBarMaximum = this.progressBar.Maximum;
					settings.ProgressBarValue = this.progressBar.Value;
					settings.ProgressBarState = this.progressBar.State;
				}
			}
			if (this.HelpInvoked != null)
			{
				settings.InvokeHelp = true;
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000080EC File Offset: 0x000062EC
		private void SortDialogControls()
		{
			foreach (TaskDialogControl taskDialogControl in this.controls)
			{
				TaskDialogButtonBase taskDialogButtonBase = taskDialogControl as TaskDialogButtonBase;
				TaskDialogCommandLink taskDialogCommandLink = taskDialogControl as TaskDialogCommandLink;
				if (taskDialogButtonBase != null && string.IsNullOrEmpty(taskDialogButtonBase.Text) && taskDialogCommandLink != null && string.IsNullOrEmpty(taskDialogCommandLink.Instruction))
				{
					throw new InvalidOperationException(LocalizedMessages.TaskDialogButtonTextEmpty);
				}
				TaskDialogRadioButton item;
				if (taskDialogCommandLink != null)
				{
					this.commandLinks.Add(taskDialogCommandLink);
				}
				else if ((item = (taskDialogControl as TaskDialogRadioButton)) != null)
				{
					if (this.radioButtons == null)
					{
						this.radioButtons = new List<TaskDialogButtonBase>();
					}
					this.radioButtons.Add(item);
				}
				else if (taskDialogButtonBase != null)
				{
					if (this.buttons == null)
					{
						this.buttons = new List<TaskDialogButtonBase>();
					}
					this.buttons.Add(taskDialogButtonBase);
				}
				else
				{
					TaskDialogProgressBar taskDialogProgressBar;
					if ((taskDialogProgressBar = (taskDialogControl as TaskDialogProgressBar)) == null)
					{
						throw new InvalidOperationException(LocalizedMessages.TaskDialogUnkownControl);
					}
					this.progressBar = taskDialogProgressBar;
				}
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00008264 File Offset: 0x00006464
		private static TaskDialogStandardButtons MapButtonIdToStandardButton(int id)
		{
			TaskDialogStandardButtons result;
			switch (id)
			{
			case 1:
				result = TaskDialogStandardButtons.Ok;
				break;
			case 2:
				result = TaskDialogStandardButtons.Cancel;
				break;
			case 3:
				result = TaskDialogStandardButtons.None;
				break;
			case 4:
				result = TaskDialogStandardButtons.Retry;
				break;
			case 5:
				result = TaskDialogStandardButtons.None;
				break;
			case 6:
				result = TaskDialogStandardButtons.Yes;
				break;
			case 7:
				result = TaskDialogStandardButtons.No;
				break;
			case 8:
				result = TaskDialogStandardButtons.Close;
				break;
			default:
				result = TaskDialogStandardButtons.None;
				break;
			}
			return result;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000082C8 File Offset: 0x000064C8
		private void ThrowIfDialogShowing(string message)
		{
			if (this.NativeDialogShowing)
			{
				throw new NotSupportedException(message);
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000235 RID: 565 RVA: 0x000082EC File Offset: 0x000064EC
		private bool NativeDialogShowing
		{
			get
			{
				return this.nativeDialog != null && (this.nativeDialog.ShowState == DialogShowState.Showing || this.nativeDialog.ShowState == DialogShowState.Closing);
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000832C File Offset: 0x0000652C
		private TaskDialogButtonBase GetButtonForId(int id)
		{
			return (TaskDialogButtonBase)this.controls.GetControlbyId(id);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00008350 File Offset: 0x00006550
		bool IDialogControlHost.IsCollectionChangeAllowed()
		{
			return !this.NativeDialogShowing;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000836B File Offset: 0x0000656B
		void IDialogControlHost.ApplyCollectionChanged()
		{
			Debug.Assert(!this.NativeDialogShowing, "Collection changed notification received despite show state of dialog");
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00008384 File Offset: 0x00006584
		bool IDialogControlHost.IsControlPropertyChangeAllowed(string propertyName, DialogControl control)
		{
			Debug.Assert(control is TaskDialogControl, "Property changing for a control that is not a TaskDialogControl-derived type");
			Debug.Assert(propertyName != "Name", "Name changes at any time are not supported - public API should have blocked this");
			bool result = false;
			if (!this.NativeDialogShowing)
			{
				if (propertyName != null)
				{
					if (propertyName == "Enabled")
					{
						result = false;
						goto IL_54;
					}
				}
				result = true;
				IL_54:;
			}
			else
			{
				if (propertyName != null)
				{
					if (propertyName == "Text" || propertyName == "Default")
					{
						result = false;
						goto IL_A9;
					}
					if (propertyName == "ShowElevationIcon" || propertyName == "Enabled")
					{
						result = true;
						goto IL_A9;
					}
				}
				Debug.Assert(true, "Unknown property name coming through property changing handler");
				IL_A9:;
			}
			return result;
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00008440 File Offset: 0x00006640
		void IDialogControlHost.ApplyControlPropertyChange(string propertyName, DialogControl control)
		{
			if (this.NativeDialogShowing)
			{
				TaskDialogButton taskDialogButton;
				TaskDialogRadioButton taskDialogRadioButton;
				if (control is TaskDialogProgressBar)
				{
					if (!this.progressBar.HasValidValues)
					{
						throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarValueInRange);
					}
					if (propertyName != null)
					{
						if (propertyName == "State")
						{
							this.nativeDialog.UpdateProgressBarState(this.progressBar.State);
							goto IL_CA;
						}
						if (propertyName == "Value")
						{
							this.nativeDialog.UpdateProgressBarValue(this.progressBar.Value);
							goto IL_CA;
						}
						if (propertyName == "Minimum" || propertyName == "Maximum")
						{
							this.nativeDialog.UpdateProgressBarRange();
							goto IL_CA;
						}
					}
					Debug.Assert(true, "Unknown property being set");
					IL_CA:;
				}
				else if ((taskDialogButton = (control as TaskDialogButton)) != null)
				{
					if (propertyName != null)
					{
						if (propertyName == "ShowElevationIcon")
						{
							this.nativeDialog.UpdateElevationIcon(taskDialogButton.Id, taskDialogButton.UseElevationIcon);
							goto IL_143;
						}
						if (propertyName == "Enabled")
						{
							this.nativeDialog.UpdateButtonEnabled(taskDialogButton.Id, taskDialogButton.Enabled);
							goto IL_143;
						}
					}
					Debug.Assert(true, "Unknown property being set");
					IL_143:;
				}
				else if ((taskDialogRadioButton = (control as TaskDialogRadioButton)) != null)
				{
					if (propertyName != null)
					{
						if (propertyName == "Enabled")
						{
							this.nativeDialog.UpdateRadioButtonEnabled(taskDialogRadioButton.Id, taskDialogRadioButton.Enabled);
							goto IL_192;
						}
					}
					Debug.Assert(true, "Unknown property being set");
					IL_192:;
				}
				else
				{
					Debug.Assert(true, "Control property changed notification not handled properly - being ignored");
				}
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000085F4 File Offset: 0x000067F4
		internal void RaiseButtonClickEvent(int id)
		{
			TaskDialogButtonBase buttonForId = this.GetButtonForId(id);
			if (buttonForId != null)
			{
				buttonForId.RaiseClickEvent();
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000861C File Offset: 0x0000681C
		internal void RaiseHyperlinkClickEvent(string link)
		{
			EventHandler<TaskDialogHyperlinkClickedEventArgs> hyperlinkClick = this.HyperlinkClick;
			if (hyperlinkClick != null)
			{
				hyperlinkClick(this, new TaskDialogHyperlinkClickedEventArgs(link));
			}
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000864C File Offset: 0x0000684C
		internal int RaiseClosingEvent(int id)
		{
			EventHandler<TaskDialogClosingEventArgs> closing = this.Closing;
			if (closing != null)
			{
				TaskDialogClosingEventArgs taskDialogClosingEventArgs = new TaskDialogClosingEventArgs();
				TaskDialogStandardButtons taskDialogStandardButtons = TaskDialog.MapButtonIdToStandardButton(id);
				if (taskDialogStandardButtons == TaskDialogStandardButtons.None)
				{
					TaskDialogButtonBase buttonForId = this.GetButtonForId(id);
					if (buttonForId == null)
					{
						throw new InvalidOperationException(LocalizedMessages.TaskDialogBadButtonId);
					}
					taskDialogClosingEventArgs.CustomButton = buttonForId.Name;
					taskDialogClosingEventArgs.TaskDialogResult = TaskDialogResult.CustomButtonClicked;
				}
				else
				{
					taskDialogClosingEventArgs.TaskDialogResult = (TaskDialogResult)taskDialogStandardButtons;
				}
				closing(this, taskDialogClosingEventArgs);
				if (taskDialogClosingEventArgs.Cancel)
				{
					return 1;
				}
			}
			return 0;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000086FC File Offset: 0x000068FC
		internal void RaiseHelpInvokedEvent()
		{
			if (this.HelpInvoked != null)
			{
				this.HelpInvoked(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000872C File Offset: 0x0000692C
		internal void RaiseOpenedEvent()
		{
			if (this.Opened != null)
			{
				this.Opened(this, EventArgs.Empty);
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000875C File Offset: 0x0000695C
		internal void RaiseTickEvent(int ticks)
		{
			if (this.Tick != null)
			{
				this.Tick(this, new TaskDialogTickEventArgs(ticks));
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000878C File Offset: 0x0000698C
		private void CleanUp()
		{
			if (this.progressBar != null)
			{
				this.progressBar.Reset();
			}
			if (this.buttons != null)
			{
				this.buttons.Clear();
			}
			if (this.commandLinks != null)
			{
				this.commandLinks.Clear();
			}
			if (this.radioButtons != null)
			{
				this.radioButtons.Clear();
			}
			this.progressBar = null;
			if (this.nativeDialog != null)
			{
				this.nativeDialog.Dispose();
			}
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00008828 File Offset: 0x00006A28
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000883C File Offset: 0x00006A3C
		~TaskDialog()
		{
			this.Dispose(false);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00008870 File Offset: 0x00006A70
		public void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.disposed = true;
				if (disposing)
				{
					if (this.nativeDialog != null && this.nativeDialog.ShowState == DialogShowState.Showing)
					{
						this.nativeDialog.NativeClose(TaskDialogResult.Cancel);
					}
					this.buttons = null;
					this.radioButtons = null;
					this.commandLinks = null;
				}
				if (this.nativeDialog != null)
				{
					this.nativeDialog.Dispose();
					this.nativeDialog = null;
				}
				if (TaskDialog.staticDialog != null)
				{
					TaskDialog.staticDialog.Dispose();
					TaskDialog.staticDialog = null;
				}
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000245 RID: 581 RVA: 0x00008924 File Offset: 0x00006B24
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnVista;
			}
		}

		// Token: 0x0400026C RID: 620
		private static TaskDialog staticDialog;

		// Token: 0x0400026D RID: 621
		private NativeTaskDialog nativeDialog;

		// Token: 0x0400026E RID: 622
		private List<TaskDialogButtonBase> buttons = new List<TaskDialogButtonBase>();

		// Token: 0x0400026F RID: 623
		private List<TaskDialogButtonBase> radioButtons = new List<TaskDialogButtonBase>();

		// Token: 0x04000270 RID: 624
		private List<TaskDialogButtonBase> commandLinks = new List<TaskDialogButtonBase>();

		// Token: 0x04000271 RID: 625
		private IntPtr ownerWindow;

		// Token: 0x04000277 RID: 631
		private string text;

		// Token: 0x04000278 RID: 632
		private string instructionText;

		// Token: 0x04000279 RID: 633
		private string caption;

		// Token: 0x0400027A RID: 634
		private string footerText;

		// Token: 0x0400027B RID: 635
		private string checkBoxText;

		// Token: 0x0400027C RID: 636
		private string detailsExpandedText;

		// Token: 0x0400027D RID: 637
		private bool detailsExpanded;

		// Token: 0x0400027E RID: 638
		private string detailsExpandedLabel;

		// Token: 0x0400027F RID: 639
		private string detailsCollapsedLabel;

		// Token: 0x04000280 RID: 640
		private bool cancelable;

		// Token: 0x04000281 RID: 641
		private TaskDialogStandardIcon icon;

		// Token: 0x04000282 RID: 642
		private TaskDialogStandardIcon footerIcon;

		// Token: 0x04000283 RID: 643
		private TaskDialogStandardButtons standardButtons = TaskDialogStandardButtons.None;

		// Token: 0x04000284 RID: 644
		private DialogControlCollection<TaskDialogControl> controls;

		// Token: 0x04000285 RID: 645
		private bool hyperlinksEnabled;

		// Token: 0x04000286 RID: 646
		private bool? footerCheckBoxChecked = null;

		// Token: 0x04000287 RID: 647
		private TaskDialogExpandedDetailsLocation expansionMode;

		// Token: 0x04000288 RID: 648
		private TaskDialogStartupLocation startupLocation;

		// Token: 0x04000289 RID: 649
		private TaskDialogProgressBar progressBar;

		// Token: 0x0400028A RID: 650
		private bool disposed;
	}
}
