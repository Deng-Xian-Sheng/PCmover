using System;
using System.Runtime.Serialization;

namespace Prism.Regions.Behaviors
{
	// Token: 0x0200003F RID: 63
	[Serializable]
	public class RegionCreationException : Exception
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x00004844 File Offset: 0x00002A44
		public RegionCreationException()
		{
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000484C File Offset: 0x00002A4C
		public RegionCreationException(string message) : base(message)
		{
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00004855 File Offset: 0x00002A55
		public RegionCreationException(string message, Exception inner) : base(message, inner)
		{
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000485F File Offset: 0x00002A5F
		protected RegionCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
