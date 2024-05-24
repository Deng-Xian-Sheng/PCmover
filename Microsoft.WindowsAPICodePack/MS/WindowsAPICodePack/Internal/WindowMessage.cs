using System;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000009 RID: 9
	internal enum WindowMessage
	{
		// Token: 0x0400000E RID: 14
		Null,
		// Token: 0x0400000F RID: 15
		Create,
		// Token: 0x04000010 RID: 16
		Destroy,
		// Token: 0x04000011 RID: 17
		Move,
		// Token: 0x04000012 RID: 18
		Size = 5,
		// Token: 0x04000013 RID: 19
		Activate,
		// Token: 0x04000014 RID: 20
		SetFocus,
		// Token: 0x04000015 RID: 21
		KillFocus,
		// Token: 0x04000016 RID: 22
		Enable = 10,
		// Token: 0x04000017 RID: 23
		SetRedraw,
		// Token: 0x04000018 RID: 24
		SetText,
		// Token: 0x04000019 RID: 25
		GetText,
		// Token: 0x0400001A RID: 26
		GetTextLength,
		// Token: 0x0400001B RID: 27
		Paint,
		// Token: 0x0400001C RID: 28
		Close,
		// Token: 0x0400001D RID: 29
		QueryEndSession,
		// Token: 0x0400001E RID: 30
		Quit,
		// Token: 0x0400001F RID: 31
		QueryOpen,
		// Token: 0x04000020 RID: 32
		EraseBackground,
		// Token: 0x04000021 RID: 33
		SystemColorChange,
		// Token: 0x04000022 RID: 34
		EndSession,
		// Token: 0x04000023 RID: 35
		SystemError,
		// Token: 0x04000024 RID: 36
		ShowWindow,
		// Token: 0x04000025 RID: 37
		ControlColor,
		// Token: 0x04000026 RID: 38
		WinIniChange,
		// Token: 0x04000027 RID: 39
		SettingChange = 26,
		// Token: 0x04000028 RID: 40
		DevModeChange,
		// Token: 0x04000029 RID: 41
		ActivateApplication,
		// Token: 0x0400002A RID: 42
		FontChange,
		// Token: 0x0400002B RID: 43
		TimeChange,
		// Token: 0x0400002C RID: 44
		CancelMode,
		// Token: 0x0400002D RID: 45
		SetCursor,
		// Token: 0x0400002E RID: 46
		MouseActivate,
		// Token: 0x0400002F RID: 47
		ChildActivate,
		// Token: 0x04000030 RID: 48
		QueueSync,
		// Token: 0x04000031 RID: 49
		GetMinMaxInfo,
		// Token: 0x04000032 RID: 50
		PaintIcon = 38,
		// Token: 0x04000033 RID: 51
		IconEraseBackground,
		// Token: 0x04000034 RID: 52
		NextDialogControl,
		// Token: 0x04000035 RID: 53
		SpoolerStatus = 42,
		// Token: 0x04000036 RID: 54
		DrawItem,
		// Token: 0x04000037 RID: 55
		MeasureItem,
		// Token: 0x04000038 RID: 56
		DeleteItem,
		// Token: 0x04000039 RID: 57
		VKeyToItem,
		// Token: 0x0400003A RID: 58
		CharToItem,
		// Token: 0x0400003B RID: 59
		SetFont,
		// Token: 0x0400003C RID: 60
		GetFont,
		// Token: 0x0400003D RID: 61
		SetHotkey,
		// Token: 0x0400003E RID: 62
		GetHotkey,
		// Token: 0x0400003F RID: 63
		QueryDragIcon = 55,
		// Token: 0x04000040 RID: 64
		CompareItem = 57,
		// Token: 0x04000041 RID: 65
		Compacting = 65,
		// Token: 0x04000042 RID: 66
		WindowPositionChanging = 70,
		// Token: 0x04000043 RID: 67
		WindowPositionChanged,
		// Token: 0x04000044 RID: 68
		Power,
		// Token: 0x04000045 RID: 69
		CopyData = 74,
		// Token: 0x04000046 RID: 70
		CancelJournal,
		// Token: 0x04000047 RID: 71
		Notify = 78,
		// Token: 0x04000048 RID: 72
		InputLanguageChangeRequest = 80,
		// Token: 0x04000049 RID: 73
		InputLanguageChange,
		// Token: 0x0400004A RID: 74
		TCard,
		// Token: 0x0400004B RID: 75
		Help,
		// Token: 0x0400004C RID: 76
		UserChanged,
		// Token: 0x0400004D RID: 77
		NotifyFormat,
		// Token: 0x0400004E RID: 78
		ContextMenu = 123,
		// Token: 0x0400004F RID: 79
		StyleChanging,
		// Token: 0x04000050 RID: 80
		StyleChanged,
		// Token: 0x04000051 RID: 81
		DisplayChange,
		// Token: 0x04000052 RID: 82
		GetIcon,
		// Token: 0x04000053 RID: 83
		SetIcon,
		// Token: 0x04000054 RID: 84
		NCCreate,
		// Token: 0x04000055 RID: 85
		NCDestroy,
		// Token: 0x04000056 RID: 86
		NCCalculateSize,
		// Token: 0x04000057 RID: 87
		NCHitTest,
		// Token: 0x04000058 RID: 88
		NCPaint,
		// Token: 0x04000059 RID: 89
		NCActivate,
		// Token: 0x0400005A RID: 90
		GetDialogCode,
		// Token: 0x0400005B RID: 91
		NCMouseMove = 160,
		// Token: 0x0400005C RID: 92
		NCLeftButtonDown,
		// Token: 0x0400005D RID: 93
		NCLeftButtonUp,
		// Token: 0x0400005E RID: 94
		NCLeftButtonDoubleClick,
		// Token: 0x0400005F RID: 95
		NCRightButtonDown,
		// Token: 0x04000060 RID: 96
		NCRightButtonUp,
		// Token: 0x04000061 RID: 97
		NCRightButtonDoubleClick,
		// Token: 0x04000062 RID: 98
		NCMiddleButtonDown,
		// Token: 0x04000063 RID: 99
		NCMiddleButtonUp,
		// Token: 0x04000064 RID: 100
		NCMiddleButtonDoubleClick,
		// Token: 0x04000065 RID: 101
		KeyFirst = 256,
		// Token: 0x04000066 RID: 102
		KeyDown = 256,
		// Token: 0x04000067 RID: 103
		KeyUp,
		// Token: 0x04000068 RID: 104
		Char,
		// Token: 0x04000069 RID: 105
		DeadChar,
		// Token: 0x0400006A RID: 106
		SystemKeyDown,
		// Token: 0x0400006B RID: 107
		SystemKeyUp,
		// Token: 0x0400006C RID: 108
		SystemChar,
		// Token: 0x0400006D RID: 109
		SystemDeadChar,
		// Token: 0x0400006E RID: 110
		KeyLast,
		// Token: 0x0400006F RID: 111
		IMEStartComposition = 269,
		// Token: 0x04000070 RID: 112
		IMEEndComposition,
		// Token: 0x04000071 RID: 113
		IMEComposition,
		// Token: 0x04000072 RID: 114
		IMEKeyLast = 271,
		// Token: 0x04000073 RID: 115
		InitializeDialog,
		// Token: 0x04000074 RID: 116
		Command,
		// Token: 0x04000075 RID: 117
		SystemCommand,
		// Token: 0x04000076 RID: 118
		Timer,
		// Token: 0x04000077 RID: 119
		HorizontalScroll,
		// Token: 0x04000078 RID: 120
		VerticalScroll,
		// Token: 0x04000079 RID: 121
		InitializeMenu,
		// Token: 0x0400007A RID: 122
		InitializeMenuPopup,
		// Token: 0x0400007B RID: 123
		MenuSelect = 287,
		// Token: 0x0400007C RID: 124
		MenuChar,
		// Token: 0x0400007D RID: 125
		EnterIdle,
		// Token: 0x0400007E RID: 126
		CTLColorMessageBox = 306,
		// Token: 0x0400007F RID: 127
		CTLColorEdit,
		// Token: 0x04000080 RID: 128
		CTLColorListbox,
		// Token: 0x04000081 RID: 129
		CTLColorButton,
		// Token: 0x04000082 RID: 130
		CTLColorDialog,
		// Token: 0x04000083 RID: 131
		CTLColorScrollBar,
		// Token: 0x04000084 RID: 132
		CTLColorStatic,
		// Token: 0x04000085 RID: 133
		MouseFirst = 512,
		// Token: 0x04000086 RID: 134
		MouseMove = 512,
		// Token: 0x04000087 RID: 135
		LeftButtonDown,
		// Token: 0x04000088 RID: 136
		LeftButtonUp,
		// Token: 0x04000089 RID: 137
		LeftButtonDoubleClick,
		// Token: 0x0400008A RID: 138
		RightButtonDown,
		// Token: 0x0400008B RID: 139
		RightButtonUp,
		// Token: 0x0400008C RID: 140
		RightButtonDoubleClick,
		// Token: 0x0400008D RID: 141
		MiddleButtonDown,
		// Token: 0x0400008E RID: 142
		MiddleButtonUp,
		// Token: 0x0400008F RID: 143
		MiddleButtonDoubleClick,
		// Token: 0x04000090 RID: 144
		MouseWheel,
		// Token: 0x04000091 RID: 145
		MouseHorizontalWheel = 526,
		// Token: 0x04000092 RID: 146
		ParentNotify = 528,
		// Token: 0x04000093 RID: 147
		EnterMenuLoop,
		// Token: 0x04000094 RID: 148
		ExitMenuLoop,
		// Token: 0x04000095 RID: 149
		NextMenu,
		// Token: 0x04000096 RID: 150
		Sizing,
		// Token: 0x04000097 RID: 151
		CaptureChanged,
		// Token: 0x04000098 RID: 152
		Moving,
		// Token: 0x04000099 RID: 153
		PowerBroadcast = 536,
		// Token: 0x0400009A RID: 154
		DeviceChange,
		// Token: 0x0400009B RID: 155
		MDICreate = 544,
		// Token: 0x0400009C RID: 156
		MDIDestroy,
		// Token: 0x0400009D RID: 157
		MDIActivate,
		// Token: 0x0400009E RID: 158
		MDIRestore,
		// Token: 0x0400009F RID: 159
		MDINext,
		// Token: 0x040000A0 RID: 160
		MDIMaximize,
		// Token: 0x040000A1 RID: 161
		MDITile,
		// Token: 0x040000A2 RID: 162
		MDICascade,
		// Token: 0x040000A3 RID: 163
		MDIIconArrange,
		// Token: 0x040000A4 RID: 164
		MDIGetActive,
		// Token: 0x040000A5 RID: 165
		MDISetMenu = 560,
		// Token: 0x040000A6 RID: 166
		EnterSizeMove,
		// Token: 0x040000A7 RID: 167
		ExitSizeMove,
		// Token: 0x040000A8 RID: 168
		DropFiles,
		// Token: 0x040000A9 RID: 169
		MDIRefreshMenu,
		// Token: 0x040000AA RID: 170
		IMESetContext = 641,
		// Token: 0x040000AB RID: 171
		IMENotify,
		// Token: 0x040000AC RID: 172
		IMEControl,
		// Token: 0x040000AD RID: 173
		IMECompositionFull,
		// Token: 0x040000AE RID: 174
		IMESelect,
		// Token: 0x040000AF RID: 175
		IMEChar,
		// Token: 0x040000B0 RID: 176
		IMEKeyDown = 656,
		// Token: 0x040000B1 RID: 177
		IMEKeyUp,
		// Token: 0x040000B2 RID: 178
		MouseHover = 673,
		// Token: 0x040000B3 RID: 179
		NCMouseLeave,
		// Token: 0x040000B4 RID: 180
		MouseLeave,
		// Token: 0x040000B5 RID: 181
		Cut = 768,
		// Token: 0x040000B6 RID: 182
		Copy,
		// Token: 0x040000B7 RID: 183
		Paste,
		// Token: 0x040000B8 RID: 184
		Clear,
		// Token: 0x040000B9 RID: 185
		Undo,
		// Token: 0x040000BA RID: 186
		RenderFormat,
		// Token: 0x040000BB RID: 187
		RenderAllFormats,
		// Token: 0x040000BC RID: 188
		DestroyClipboard,
		// Token: 0x040000BD RID: 189
		DrawClipbard,
		// Token: 0x040000BE RID: 190
		PaintClipbard,
		// Token: 0x040000BF RID: 191
		VerticalScrollClipBoard,
		// Token: 0x040000C0 RID: 192
		SizeClipbard,
		// Token: 0x040000C1 RID: 193
		AskClipboardFormatname,
		// Token: 0x040000C2 RID: 194
		ChangeClipboardChain,
		// Token: 0x040000C3 RID: 195
		HorizontalScrollClipboard,
		// Token: 0x040000C4 RID: 196
		QueryNewPalette,
		// Token: 0x040000C5 RID: 197
		PaletteIsChanging,
		// Token: 0x040000C6 RID: 198
		PaletteChanged,
		// Token: 0x040000C7 RID: 199
		Hotkey,
		// Token: 0x040000C8 RID: 200
		Print = 791,
		// Token: 0x040000C9 RID: 201
		PrintClient,
		// Token: 0x040000CA RID: 202
		HandHeldFirst = 856,
		// Token: 0x040000CB RID: 203
		HandHeldlast = 863,
		// Token: 0x040000CC RID: 204
		PenWinFirst = 896,
		// Token: 0x040000CD RID: 205
		PenWinLast = 911,
		// Token: 0x040000CE RID: 206
		CoalesceFirst,
		// Token: 0x040000CF RID: 207
		CoalesceLast = 927,
		// Token: 0x040000D0 RID: 208
		DDE_First = 992,
		// Token: 0x040000D1 RID: 209
		DDE_Initiate = 992,
		// Token: 0x040000D2 RID: 210
		DDE_Terminate,
		// Token: 0x040000D3 RID: 211
		DDE_Advise,
		// Token: 0x040000D4 RID: 212
		DDE_Unadvise,
		// Token: 0x040000D5 RID: 213
		DDE_Ack,
		// Token: 0x040000D6 RID: 214
		DDE_Data,
		// Token: 0x040000D7 RID: 215
		DDE_Request,
		// Token: 0x040000D8 RID: 216
		DDE_Poke,
		// Token: 0x040000D9 RID: 217
		DDE_Execute,
		// Token: 0x040000DA RID: 218
		DDE_Last = 1000,
		// Token: 0x040000DB RID: 219
		User = 1024,
		// Token: 0x040000DC RID: 220
		App = 32768
	}
}
