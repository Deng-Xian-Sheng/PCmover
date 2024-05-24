using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200006A RID: 106
	public class FillTaskData
	{
		// Token: 0x060002DB RID: 731 RVA: 0x00002050 File Offset: 0x00000250
		public FillTaskData()
		{
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00003C2C File Offset: 0x00001E2C
		public FillTaskData(FillTaskResult result, string message)
		{
			this.Result = result;
			this.Message = message;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00003C42 File Offset: 0x00001E42
		public FillTaskData(int handle)
		{
			this.Handle = handle;
			this.Result = FillTaskResult.Success;
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060002DE RID: 734 RVA: 0x00003C58 File Offset: 0x00001E58
		// (set) Token: 0x060002DF RID: 735 RVA: 0x00003C60 File Offset: 0x00001E60
		public FillTaskResult Result { get; set; }

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00003C69 File Offset: 0x00001E69
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x00003C71 File Offset: 0x00001E71
		public string Message { get; set; }

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x00003C7A File Offset: 0x00001E7A
		// (set) Token: 0x060002E3 RID: 739 RVA: 0x00003C82 File Offset: 0x00001E82
		public int Handle { get; set; }
	}
}
