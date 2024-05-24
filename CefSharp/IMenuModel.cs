using System;

namespace CefSharp
{
	// Token: 0x02000070 RID: 112
	public interface IMenuModel
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600029B RID: 667
		int Count { get; }

		// Token: 0x0600029C RID: 668
		bool Clear();

		// Token: 0x0600029D RID: 669
		string GetLabelAt(int index);

		// Token: 0x0600029E RID: 670
		CefMenuCommand GetCommandIdAt(int index);

		// Token: 0x0600029F RID: 671
		bool Remove(CefMenuCommand commandId);

		// Token: 0x060002A0 RID: 672
		bool AddItem(CefMenuCommand commandId, string label);

		// Token: 0x060002A1 RID: 673
		bool AddSeparator();

		// Token: 0x060002A2 RID: 674
		bool AddCheckItem(CefMenuCommand commandId, string label);

		// Token: 0x060002A3 RID: 675
		bool AddRadioItem(CefMenuCommand commandId, string label, int groupId);

		// Token: 0x060002A4 RID: 676
		IMenuModel AddSubMenu(CefMenuCommand commandId, string label);

		// Token: 0x060002A5 RID: 677
		bool InsertSeparatorAt(int index);

		// Token: 0x060002A6 RID: 678
		bool InsertItemAt(int index, CefMenuCommand commandId, string label);

		// Token: 0x060002A7 RID: 679
		bool InsertCheckItemAt(int index, CefMenuCommand commandId, string label);

		// Token: 0x060002A8 RID: 680
		bool InsertRadioItemAt(int index, CefMenuCommand commandId, string label, int groupId);

		// Token: 0x060002A9 RID: 681
		IMenuModel InsertSubMenuAt(int index, CefMenuCommand commandId, string label);

		// Token: 0x060002AA RID: 682
		bool RemoveAt(int index);

		// Token: 0x060002AB RID: 683
		int GetIndexOf(CefMenuCommand commandId);

		// Token: 0x060002AC RID: 684
		bool SetCommandIdAt(int index, CefMenuCommand commandId);

		// Token: 0x060002AD RID: 685
		string GetLabel(CefMenuCommand commandId);

		// Token: 0x060002AE RID: 686
		bool SetLabel(CefMenuCommand commandId, string label);

		// Token: 0x060002AF RID: 687
		bool SetLabelAt(int index, string label);

		// Token: 0x060002B0 RID: 688
		MenuItemType GetType(CefMenuCommand commandId);

		// Token: 0x060002B1 RID: 689
		MenuItemType GetTypeAt(int index);

		// Token: 0x060002B2 RID: 690
		int GetGroupId(CefMenuCommand commandId);

		// Token: 0x060002B3 RID: 691
		int GetGroupIdAt(int index);

		// Token: 0x060002B4 RID: 692
		bool SetGroupId(CefMenuCommand commandId, int groupId);

		// Token: 0x060002B5 RID: 693
		bool SetGroupIdAt(int index, int groupId);

		// Token: 0x060002B6 RID: 694
		IMenuModel GetSubMenu(CefMenuCommand commandId);

		// Token: 0x060002B7 RID: 695
		IMenuModel GetSubMenuAt(int index);

		// Token: 0x060002B8 RID: 696
		bool IsVisible(CefMenuCommand commandId);

		// Token: 0x060002B9 RID: 697
		bool IsVisibleAt(int index);

		// Token: 0x060002BA RID: 698
		bool SetVisible(CefMenuCommand commandId, bool visible);

		// Token: 0x060002BB RID: 699
		bool SetVisibleAt(int index, bool visible);

		// Token: 0x060002BC RID: 700
		bool IsEnabled(CefMenuCommand commandId);

		// Token: 0x060002BD RID: 701
		bool IsEnabledAt(int index);

		// Token: 0x060002BE RID: 702
		bool SetEnabled(CefMenuCommand commandId, bool enabled);

		// Token: 0x060002BF RID: 703
		bool SetEnabledAt(int index, bool enabled);

		// Token: 0x060002C0 RID: 704
		bool IsChecked(CefMenuCommand commandId);

		// Token: 0x060002C1 RID: 705
		bool IsCheckedAt(int index);

		// Token: 0x060002C2 RID: 706
		bool SetChecked(CefMenuCommand commandId, bool isChecked);

		// Token: 0x060002C3 RID: 707
		bool SetCheckedAt(int index, bool isChecked);

		// Token: 0x060002C4 RID: 708
		bool HasAccelerator(CefMenuCommand commandId);

		// Token: 0x060002C5 RID: 709
		bool HasAcceleratorAt(int index);

		// Token: 0x060002C6 RID: 710
		bool SetAccelerator(CefMenuCommand commandId, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed);

		// Token: 0x060002C7 RID: 711
		bool SetAcceleratorAt(int index, int keyCode, bool shiftPressed, bool ctrlPressed, bool altPressed);

		// Token: 0x060002C8 RID: 712
		bool RemoveAccelerator(CefMenuCommand commandId);

		// Token: 0x060002C9 RID: 713
		bool RemoveAcceleratorAt(int index);

		// Token: 0x060002CA RID: 714
		bool GetAccelerator(CefMenuCommand commandId, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed);

		// Token: 0x060002CB RID: 715
		bool GetAcceleratorAt(int index, out int keyCode, out bool shiftPressed, out bool ctrlPressed, out bool altPressed);
	}
}
