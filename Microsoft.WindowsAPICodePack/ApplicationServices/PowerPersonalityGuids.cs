using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000041 RID: 65
	internal static class PowerPersonalityGuids
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00004C24 File Offset: 0x00002E24
		internal static PowerPersonality GuidToEnum(Guid guid)
		{
			PowerPersonality result;
			if (guid == PowerPersonalityGuids.HighPerformance)
			{
				result = PowerPersonality.HighPerformance;
			}
			else if (guid == PowerPersonalityGuids.PowerSaver)
			{
				result = PowerPersonality.PowerSaver;
			}
			else if (guid == PowerPersonalityGuids.Automatic)
			{
				result = PowerPersonality.Automatic;
			}
			else
			{
				result = PowerPersonality.Unknown;
			}
			return result;
		}

		// Token: 0x04000239 RID: 569
		internal static readonly Guid HighPerformance = new Guid(2355003354U, 59583, 19094, 154, 133, 166, 226, 58, 140, 99, 92);

		// Token: 0x0400023A RID: 570
		internal static readonly Guid PowerSaver = new Guid(2709787400U, 13633, 20395, 188, 129, 247, 21, 86, 242, 11, 74);

		// Token: 0x0400023B RID: 571
		internal static readonly Guid Automatic = new Guid(941310498U, 63124, 16880, 150, 133, byte.MaxValue, 91, 178, 96, 223, 46);

		// Token: 0x0400023C RID: 572
		internal static readonly Guid All = new Guid(1755441502, 5098, 16865, 128, 17, 12, 73, 108, 164, 144, 176);
	}
}
