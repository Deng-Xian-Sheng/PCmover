using System;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200011D RID: 285
	[Flags]
	public enum ShellObjectChangeTypes
	{
		// Token: 0x0400046A RID: 1130
		None = 0,
		// Token: 0x0400046B RID: 1131
		ItemRename = 1,
		// Token: 0x0400046C RID: 1132
		ItemCreate = 2,
		// Token: 0x0400046D RID: 1133
		ItemDelete = 4,
		// Token: 0x0400046E RID: 1134
		DirectoryCreate = 8,
		// Token: 0x0400046F RID: 1135
		DirectoryDelete = 16,
		// Token: 0x04000470 RID: 1136
		MediaInsert = 32,
		// Token: 0x04000471 RID: 1137
		MediaRemove = 64,
		// Token: 0x04000472 RID: 1138
		DriveRemove = 128,
		// Token: 0x04000473 RID: 1139
		DriveAdd = 256,
		// Token: 0x04000474 RID: 1140
		NetShare = 512,
		// Token: 0x04000475 RID: 1141
		NetUnshare = 1024,
		// Token: 0x04000476 RID: 1142
		AttributesChange = 2048,
		// Token: 0x04000477 RID: 1143
		DirectoryContentsUpdate = 4096,
		// Token: 0x04000478 RID: 1144
		Update = 8192,
		// Token: 0x04000479 RID: 1145
		ServerDisconnect = 16384,
		// Token: 0x0400047A RID: 1146
		SystemImageUpdate = 32768,
		// Token: 0x0400047B RID: 1147
		DirectoryRename = 131072,
		// Token: 0x0400047C RID: 1148
		FreeSpace = 262144,
		// Token: 0x0400047D RID: 1149
		AssociationChange = 134217728,
		// Token: 0x0400047E RID: 1150
		DiskEventsMask = 145439,
		// Token: 0x0400047F RID: 1151
		GlobalEventsMask = 201687520,
		// Token: 0x04000480 RID: 1152
		AllEventsMask = 2147483647,
		// Token: 0x04000481 RID: 1153
		FromInterrupt = -2147483648
	}
}
