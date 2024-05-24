using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000023 RID: 35
	internal class NativeTaskDialog : IDisposable
	{
		// Token: 0x06000093 RID: 147 RVA: 0x00002C14 File Offset: 0x00000E14
		internal NativeTaskDialog(NativeTaskDialogSettings settings, TaskDialog outerDialog)
		{
			this.nativeDialogConfig = settings.NativeConfiguration;
			this.settings = settings;
			this.nativeDialogConfig.callback = new TaskDialogNativeMethods.TaskDialogCallback(this.DialogProc);
			this.ShowState = DialogShowState.PreShow;
			this.outerDialog = outerDialog;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00002C88 File Offset: 0x00000E88
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00002C9F File Offset: 0x00000E9F
		public DialogShowState ShowState { get; private set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00002CA8 File Offset: 0x00000EA8
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00002CBF File Offset: 0x00000EBF
		public int SelectedButtonId { get; private set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002CC8 File Offset: 0x00000EC8
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00002CDF File Offset: 0x00000EDF
		public int SelectedRadioButtonId { get; private set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00002CE8 File Offset: 0x00000EE8
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00002CFF File Offset: 0x00000EFF
		public bool CheckBoxChecked { get; private set; }

		// Token: 0x0600009C RID: 156 RVA: 0x00002D08 File Offset: 0x00000F08
		internal void NativeShow()
		{
			if (this.settings == null)
			{
				throw new InvalidOperationException(LocalizedMessages.NativeTaskDialogConfigurationError);
			}
			this.MarshalDialogControlStructs();
			try
			{
				this.ShowState = DialogShowState.Showing;
				int selectedButtonId;
				int selectedRadioButtonId;
				bool checkBoxChecked;
				HResult hresult = TaskDialogNativeMethods.TaskDialogIndirect(this.nativeDialogConfig, out selectedButtonId, out selectedRadioButtonId, out checkBoxChecked);
				if (CoreErrorHelper.Failed(hresult))
				{
					HResult hresult2 = hresult;
					string message;
					if (hresult2 != HResult.OutOfMemory)
					{
						if (hresult2 != HResult.InvalidArguments)
						{
							message = string.Format(CultureInfo.InvariantCulture, LocalizedMessages.NativeTaskDialogInternalErrorUnexpected, new object[]
							{
								hresult
							});
						}
						else
						{
							message = LocalizedMessages.NativeTaskDialogInternalErrorArgs;
						}
					}
					else
					{
						message = LocalizedMessages.NativeTaskDialogInternalErrorComplex;
					}
					Exception exceptionForHR = Marshal.GetExceptionForHR((int)hresult);
					throw new Win32Exception(message, exceptionForHR);
				}
				this.SelectedButtonId = selectedButtonId;
				this.SelectedRadioButtonId = selectedRadioButtonId;
				this.CheckBoxChecked = checkBoxChecked;
			}
			catch (EntryPointNotFoundException innerException)
			{
				throw new NotSupportedException(LocalizedMessages.NativeTaskDialogVersionError, innerException);
			}
			finally
			{
				this.ShowState = DialogShowState.Closed;
			}
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00002E20 File Offset: 0x00001020
		internal void NativeClose(TaskDialogResult result)
		{
			this.ShowState = DialogShowState.Closing;
			int wparam;
			if (result <= TaskDialogResult.Retry)
			{
				switch (result)
				{
				case TaskDialogResult.Ok:
					wparam = 1;
					goto IL_5B;
				case TaskDialogResult.Yes:
					wparam = 6;
					goto IL_5B;
				case (TaskDialogResult)3:
					break;
				case TaskDialogResult.No:
					wparam = 7;
					goto IL_5B;
				default:
					if (result == TaskDialogResult.Retry)
					{
						wparam = 4;
						goto IL_5B;
					}
					break;
				}
			}
			else
			{
				if (result == TaskDialogResult.Close)
				{
					wparam = 8;
					goto IL_5B;
				}
				if (result == TaskDialogResult.CustomButtonClicked)
				{
					wparam = 9;
					goto IL_5B;
				}
			}
			wparam = 2;
			IL_5B:
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.ClickButton, wparam, 0L);
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00002E98 File Offset: 0x00001098
		private int DialogProc(IntPtr windowHandle, uint message, IntPtr wparam, IntPtr lparam, IntPtr referenceData)
		{
			this.hWndDialog = windowHandle;
			switch (message)
			{
			case 0U:
			{
				int result = this.PerformDialogInitialization();
				this.outerDialog.RaiseOpenedEvent();
				return result;
			}
			case 2U:
				return this.HandleButtonClick((int)wparam);
			case 3U:
				return this.HandleHyperlinkClick(lparam);
			case 4U:
				return this.HandleTick((int)wparam);
			case 5U:
				return this.PerformDialogCleanup();
			case 6U:
				return this.HandleRadioButtonClick((int)wparam);
			case 9U:
				return this.HandleHelpInvocation();
			}
			return 0;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002F48 File Offset: 0x00001148
		private int PerformDialogInitialization()
		{
			if (this.IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.ShowProgressBar))
			{
				this.UpdateProgressBarRange();
				this.UpdateProgressBarState(this.settings.ProgressBarState);
				this.UpdateProgressBarValue(this.settings.ProgressBarValue);
				this.UpdateProgressBarValue(this.settings.ProgressBarValue);
			}
			else if (this.IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.ShowMarqueeProgressBar))
			{
				this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarMarquee, 1, 0L);
				this.UpdateProgressBarState(this.settings.ProgressBarState);
			}
			if (this.settings.ElevatedButtons != null && this.settings.ElevatedButtons.Count > 0)
			{
				foreach (int buttonId in this.settings.ElevatedButtons)
				{
					this.UpdateElevationIcon(buttonId, true);
				}
			}
			return 0;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003064 File Offset: 0x00001264
		private int HandleButtonClick(int id)
		{
			if (this.ShowState != DialogShowState.Closing)
			{
				this.outerDialog.RaiseButtonClickEvent(id);
			}
			int result;
			if (id < 9)
			{
				result = this.outerDialog.RaiseClosingEvent(id);
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000030B0 File Offset: 0x000012B0
		private int HandleRadioButtonClick(int id)
		{
			if (this.firstRadioButtonClicked && !this.IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions.NoDefaultRadioButton))
			{
				this.firstRadioButtonClicked = false;
			}
			else
			{
				this.outerDialog.RaiseButtonClickEvent(id);
			}
			return 0;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000030F8 File Offset: 0x000012F8
		private int HandleHyperlinkClick(IntPtr href)
		{
			string link = Marshal.PtrToStringUni(href);
			this.outerDialog.RaiseHyperlinkClickEvent(link);
			return 0;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003120 File Offset: 0x00001320
		private int HandleTick(int ticks)
		{
			this.outerDialog.RaiseTickEvent(ticks);
			return 0;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00003140 File Offset: 0x00001340
		private int HandleHelpInvocation()
		{
			this.outerDialog.RaiseHelpInvokedEvent();
			return 0;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003160 File Offset: 0x00001360
		private int PerformDialogCleanup()
		{
			this.firstRadioButtonClicked = true;
			return 0;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000317A File Offset: 0x0000137A
		internal void UpdateProgressBarValue(int i)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarPosition, i, 0L);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003194 File Offset: 0x00001394
		internal void UpdateProgressBarRange()
		{
			this.AssertCurrentlyShowing();
			long lparam = NativeTaskDialog.MakeLongLParam(this.settings.ProgressBarMaximum, this.settings.ProgressBarMinimum);
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarRange, 0, lparam);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000031D3 File Offset: 0x000013D3
		internal void UpdateProgressBarState(TaskDialogProgressBarState state)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetProgressBarState, (int)state, 0L);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000031EC File Offset: 0x000013EC
		internal void UpdateText(string text)
		{
			this.UpdateTextCore(text, TaskDialogNativeMethods.TaskDialogElements.Content);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000031F8 File Offset: 0x000013F8
		internal void UpdateInstruction(string instruction)
		{
			this.UpdateTextCore(instruction, TaskDialogNativeMethods.TaskDialogElements.MainInstruction);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003204 File Offset: 0x00001404
		internal void UpdateFooterText(string footerText)
		{
			this.UpdateTextCore(footerText, TaskDialogNativeMethods.TaskDialogElements.Footer);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003210 File Offset: 0x00001410
		internal void UpdateExpandedText(string expandedText)
		{
			this.UpdateTextCore(expandedText, TaskDialogNativeMethods.TaskDialogElements.ExpandedInformation);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000321C File Offset: 0x0000141C
		private void UpdateTextCore(string s, TaskDialogNativeMethods.TaskDialogElements element)
		{
			this.AssertCurrentlyShowing();
			this.FreeOldString(element);
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetElementText, (int)element, (long)this.MakeNewString(s, element));
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003248 File Offset: 0x00001448
		internal void UpdateMainIcon(TaskDialogStandardIcon mainIcon)
		{
			this.UpdateIconCore(mainIcon, TaskDialogNativeMethods.TaskDialogIconElement.Main);
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003254 File Offset: 0x00001454
		internal void UpdateFooterIcon(TaskDialogStandardIcon footerIcon)
		{
			this.UpdateIconCore(footerIcon, TaskDialogNativeMethods.TaskDialogIconElement.Footer);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003260 File Offset: 0x00001460
		private void UpdateIconCore(TaskDialogStandardIcon icon, TaskDialogNativeMethods.TaskDialogIconElement element)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.UpdateIcon, (int)element, (long)icon);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003279 File Offset: 0x00001479
		internal void UpdateCheckBoxChecked(bool cbc)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.ClickVerification, cbc ? 1 : 0, 1L);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003299 File Offset: 0x00001499
		internal void UpdateElevationIcon(int buttonId, bool showIcon)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.SetButtonElevationRequiredState, buttonId, (long)Convert.ToInt32(showIcon));
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000032B7 File Offset: 0x000014B7
		internal void UpdateButtonEnabled(int buttonID, bool enabled)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.EnableButton, buttonID, enabled ? 1L : 0L);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000032D7 File Offset: 0x000014D7
		internal void UpdateRadioButtonEnabled(int buttonID, bool enabled)
		{
			this.AssertCurrentlyShowing();
			this.SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages.EnableRadioButton, buttonID, enabled ? 1L : 0L);
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000032F7 File Offset: 0x000014F7
		internal void AssertCurrentlyShowing()
		{
			Debug.Assert(this.ShowState == DialogShowState.Showing, "Update*() methods should only be called while native dialog is showing");
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003310 File Offset: 0x00001510
		private int SendMessageHelper(TaskDialogNativeMethods.TaskDialogMessages message, int wparam, long lparam)
		{
			Debug.Assert(true, "HWND for dialog is null during SendMessage");
			return (int)CoreNativeMethods.SendMessage(this.hWndDialog, (uint)message, (IntPtr)wparam, new IntPtr(lparam));
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000334C File Offset: 0x0000154C
		private bool IsOptionSet(TaskDialogNativeMethods.TaskDialogOptions flag)
		{
			return (this.nativeDialogConfig.taskDialogFlags & flag) == flag;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003370 File Offset: 0x00001570
		private IntPtr MakeNewString(string text, TaskDialogNativeMethods.TaskDialogElements element)
		{
			IntPtr intPtr = Marshal.StringToHGlobalUni(text);
			this.updatedStrings[(int)element] = intPtr;
			return intPtr;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000339C File Offset: 0x0000159C
		private void FreeOldString(TaskDialogNativeMethods.TaskDialogElements element)
		{
			if (this.updatedStrings[(int)element] != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.updatedStrings[(int)element]);
				this.updatedStrings[(int)element] = IntPtr.Zero;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003400 File Offset: 0x00001600
		private static long MakeLongLParam(int a, int b)
		{
			return (long)((a << 16) + b);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000341C File Offset: 0x0000161C
		private void MarshalDialogControlStructs()
		{
			if (this.settings.Buttons != null && this.settings.Buttons.Length > 0)
			{
				this.buttonArray = NativeTaskDialog.AllocateAndMarshalButtons(this.settings.Buttons);
				this.settings.NativeConfiguration.buttons = this.buttonArray;
				this.settings.NativeConfiguration.buttonCount = (uint)this.settings.Buttons.Length;
			}
			if (this.settings.RadioButtons != null && this.settings.RadioButtons.Length > 0)
			{
				this.radioButtonArray = NativeTaskDialog.AllocateAndMarshalButtons(this.settings.RadioButtons);
				this.settings.NativeConfiguration.radioButtons = this.radioButtonArray;
				this.settings.NativeConfiguration.radioButtonCount = (uint)this.settings.RadioButtons.Length;
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003510 File Offset: 0x00001710
		private static IntPtr AllocateAndMarshalButtons(TaskDialogNativeMethods.TaskDialogButton[] structs)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(TaskDialogNativeMethods.TaskDialogButton)) * structs.Length);
			IntPtr ptr = intPtr;
			foreach (TaskDialogNativeMethods.TaskDialogButton taskDialogButton in structs)
			{
				Marshal.StructureToPtr(taskDialogButton, ptr, false);
				ptr = (IntPtr)(ptr.ToInt64() + (long)Marshal.SizeOf(taskDialogButton));
			}
			return intPtr;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003594 File Offset: 0x00001794
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000035A8 File Offset: 0x000017A8
		~NativeTaskDialog()
		{
			this.Dispose(false);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000035DC File Offset: 0x000017DC
		protected void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				this.disposed = true;
				if (this.ShowState == DialogShowState.Showing)
				{
					this.NativeClose(TaskDialogResult.Cancel);
				}
				if (this.updatedStrings != null)
				{
					for (int i = 0; i < this.updatedStrings.Length; i++)
					{
						if (this.updatedStrings[i] != IntPtr.Zero)
						{
							Marshal.FreeHGlobal(this.updatedStrings[i]);
							this.updatedStrings[i] = IntPtr.Zero;
						}
					}
				}
				if (this.buttonArray != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.buttonArray);
					this.buttonArray = IntPtr.Zero;
				}
				if (this.radioButtonArray != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.radioButtonArray);
					this.radioButtonArray = IntPtr.Zero;
				}
				if (disposing)
				{
				}
			}
		}

		// Token: 0x04000180 RID: 384
		private TaskDialogNativeMethods.TaskDialogConfiguration nativeDialogConfig;

		// Token: 0x04000181 RID: 385
		private NativeTaskDialogSettings settings;

		// Token: 0x04000182 RID: 386
		private IntPtr hWndDialog;

		// Token: 0x04000183 RID: 387
		private TaskDialog outerDialog;

		// Token: 0x04000184 RID: 388
		private IntPtr[] updatedStrings = new IntPtr[Enum.GetNames(typeof(TaskDialogNativeMethods.TaskDialogElements)).Length];

		// Token: 0x04000185 RID: 389
		private IntPtr buttonArray;

		// Token: 0x04000186 RID: 390
		private IntPtr radioButtonArray;

		// Token: 0x04000187 RID: 391
		private bool firstRadioButtonClicked = true;

		// Token: 0x04000188 RID: 392
		private bool disposed;
	}
}
