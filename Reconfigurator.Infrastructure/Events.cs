using System;
using Prism.Events;

namespace Reconfigurator.Infrastructure
{
	// Token: 0x02000003 RID: 3
	public class Events
	{
		// Token: 0x0200000C RID: 12
		public enum CustomSelection
		{
			// Token: 0x0400002D RID: 45
			Programs,
			// Token: 0x0400002E RID: 46
			Folders,
			// Token: 0x0400002F RID: 47
			ProgramsOff,
			// Token: 0x04000030 RID: 48
			FoldersOff
		}

		// Token: 0x0200000D RID: 13
		public class ChangedCustomSelection : PubSubEvent<Events.CustomSelection>
		{
		}

		// Token: 0x0200000E RID: 14
		public class SelectionHappened : PubSubEvent<string>
		{
		}

		// Token: 0x0200000F RID: 15
		public class AllowChangeEvent : PubSubEvent<bool>
		{
		}

		// Token: 0x02000010 RID: 16
		public class FromDriveChangeEvent : PubSubEvent<string>
		{
		}

		// Token: 0x02000011 RID: 17
		public class TransferErrorEvent : PubSubEvent<TransferError>
		{
		}

		// Token: 0x02000012 RID: 18
		public class TransferErrorCompleteEvent : PubSubEvent<TransferError>
		{
		}

		// Token: 0x02000013 RID: 19
		public class CopyFoldersEvent : PubSubEvent<CopyFolderData>
		{
		}

		// Token: 0x02000014 RID: 20
		public class MoveLibraryEvent : PubSubEvent<MoveLibraryData>
		{
		}
	}
}
