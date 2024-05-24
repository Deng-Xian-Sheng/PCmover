using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MahApps.Metro.Controls
{
	// Token: 0x02000097 RID: 151
	internal static class VisualStates
	{
		// Token: 0x06000834 RID: 2100 RVA: 0x00021760 File Offset: 0x0001F960
		public static void GoToState(Control control, bool useTransitions, params string[] stateNames)
		{
			foreach (string stateName in stateNames)
			{
				if (VisualStateManager.GoToState(control, stateName, useTransitions))
				{
					break;
				}
			}
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0002178B File Offset: 0x0001F98B
		public static FrameworkElement GetImplementationRoot(DependencyObject dependencyObject)
		{
			if (VisualTreeHelper.GetChildrenCount(dependencyObject) != 1)
			{
				return null;
			}
			return VisualTreeHelper.GetChild(dependencyObject, 0) as FrameworkElement;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x000217A4 File Offset: 0x0001F9A4
		public static VisualStateGroup TryGetVisualStateGroup(DependencyObject dependencyObject, string groupName)
		{
			FrameworkElement implementationRoot = VisualStates.GetImplementationRoot(dependencyObject);
			if (implementationRoot == null)
			{
				return null;
			}
			return VisualStateManager.GetVisualStateGroups(implementationRoot).OfType<VisualStateGroup>().FirstOrDefault((VisualStateGroup group) => string.CompareOrdinal(groupName, group.Name) == 0);
		}

		// Token: 0x04000388 RID: 904
		public const string GroupCommon = "CommonStates";

		// Token: 0x04000389 RID: 905
		public const string StateNormal = "Normal";

		// Token: 0x0400038A RID: 906
		public const string StateReadOnly = "ReadOnly";

		// Token: 0x0400038B RID: 907
		public const string StateMouseOver = "MouseOver";

		// Token: 0x0400038C RID: 908
		public const string StatePressed = "Pressed";

		// Token: 0x0400038D RID: 909
		public const string StateDisabled = "Disabled";

		// Token: 0x0400038E RID: 910
		public const string GroupFocus = "FocusStates";

		// Token: 0x0400038F RID: 911
		public const string StateUnfocused = "Unfocused";

		// Token: 0x04000390 RID: 912
		public const string StateFocused = "Focused";

		// Token: 0x04000391 RID: 913
		public const string GroupSelection = "SelectionStates";

		// Token: 0x04000392 RID: 914
		public const string StateSelected = "Selected";

		// Token: 0x04000393 RID: 915
		public const string StateUnselected = "Unselected";

		// Token: 0x04000394 RID: 916
		public const string StateSelectedInactive = "SelectedInactive";

		// Token: 0x04000395 RID: 917
		public const string GroupExpansion = "ExpansionStates";

		// Token: 0x04000396 RID: 918
		public const string StateExpanded = "Expanded";

		// Token: 0x04000397 RID: 919
		public const string StateCollapsed = "Collapsed";

		// Token: 0x04000398 RID: 920
		public const string GroupPopup = "PopupStates";

		// Token: 0x04000399 RID: 921
		public const string StatePopupOpened = "PopupOpened";

		// Token: 0x0400039A RID: 922
		public const string StatePopupClosed = "PopupClosed";

		// Token: 0x0400039B RID: 923
		public const string GroupValidation = "ValidationStates";

		// Token: 0x0400039C RID: 924
		public const string StateValid = "Valid";

		// Token: 0x0400039D RID: 925
		public const string StateInvalidFocused = "InvalidFocused";

		// Token: 0x0400039E RID: 926
		public const string StateInvalidUnfocused = "InvalidUnfocused";

		// Token: 0x0400039F RID: 927
		public const string GroupExpandDirection = "ExpandDirectionStates";

		// Token: 0x040003A0 RID: 928
		public const string StateExpandDown = "ExpandDown";

		// Token: 0x040003A1 RID: 929
		public const string StateExpandUp = "ExpandUp";

		// Token: 0x040003A2 RID: 930
		public const string StateExpandLeft = "ExpandLeft";

		// Token: 0x040003A3 RID: 931
		public const string StateExpandRight = "ExpandRight";

		// Token: 0x040003A4 RID: 932
		public const string GroupHasItems = "HasItemsStates";

		// Token: 0x040003A5 RID: 933
		public const string StateHasItems = "HasItems";

		// Token: 0x040003A6 RID: 934
		public const string StateNoItems = "NoItems";

		// Token: 0x040003A7 RID: 935
		public const string GroupIncrease = "IncreaseStates";

		// Token: 0x040003A8 RID: 936
		public const string StateIncreaseEnabled = "IncreaseEnabled";

		// Token: 0x040003A9 RID: 937
		public const string StateIncreaseDisabled = "IncreaseDisabled";

		// Token: 0x040003AA RID: 938
		public const string GroupDecrease = "DecreaseStates";

		// Token: 0x040003AB RID: 939
		public const string StateDecreaseEnabled = "DecreaseEnabled";

		// Token: 0x040003AC RID: 940
		public const string StateDecreaseDisabled = "DecreaseDisabled";

		// Token: 0x040003AD RID: 941
		public const string GroupInteractionMode = "InteractionModeStates";

		// Token: 0x040003AE RID: 942
		public const string StateEdit = "Edit";

		// Token: 0x040003AF RID: 943
		public const string StateDisplay = "Display";

		// Token: 0x040003B0 RID: 944
		public const string GroupLocked = "LockedStates";

		// Token: 0x040003B1 RID: 945
		public const string StateLocked = "Locked";

		// Token: 0x040003B2 RID: 946
		public const string StateUnlocked = "Unlocked";

		// Token: 0x040003B3 RID: 947
		public const string StateActive = "Active";

		// Token: 0x040003B4 RID: 948
		public const string StateInactive = "Inactive";

		// Token: 0x040003B5 RID: 949
		public const string GroupActive = "ActiveStates";

		// Token: 0x040003B6 RID: 950
		public const string StateUnwatermarked = "Unwatermarked";

		// Token: 0x040003B7 RID: 951
		public const string StateWatermarked = "Watermarked";

		// Token: 0x040003B8 RID: 952
		public const string GroupWatermark = "WatermarkStates";

		// Token: 0x040003B9 RID: 953
		public const string StateCalendarButtonUnfocused = "CalendarButtonUnfocused";

		// Token: 0x040003BA RID: 954
		public const string StateCalendarButtonFocused = "CalendarButtonFocused";

		// Token: 0x040003BB RID: 955
		public const string GroupCalendarButtonFocus = "CalendarButtonFocusStates";

		// Token: 0x040003BC RID: 956
		public const string StateBusy = "Busy";

		// Token: 0x040003BD RID: 957
		public const string StateIdle = "Idle";

		// Token: 0x040003BE RID: 958
		public const string GroupBusyStatus = "BusyStatusStates";

		// Token: 0x040003BF RID: 959
		public const string StateVisible = "Visible";

		// Token: 0x040003C0 RID: 960
		public const string StateHidden = "Hidden";

		// Token: 0x040003C1 RID: 961
		public const string GroupVisibility = "VisibilityStates";
	}
}
