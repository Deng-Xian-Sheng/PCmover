using System;
using System.IO;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	// Token: 0x02000731 RID: 1841
	[ComVisible(true)]
	public interface IFormatter
	{
		// Token: 0x060051A1 RID: 20897
		object Deserialize(Stream serializationStream);

		// Token: 0x060051A2 RID: 20898
		void Serialize(Stream serializationStream, object graph);

		// Token: 0x17000D71 RID: 3441
		// (get) Token: 0x060051A3 RID: 20899
		// (set) Token: 0x060051A4 RID: 20900
		ISurrogateSelector SurrogateSelector { get; set; }

		// Token: 0x17000D72 RID: 3442
		// (get) Token: 0x060051A5 RID: 20901
		// (set) Token: 0x060051A6 RID: 20902
		SerializationBinder Binder { get; set; }

		// Token: 0x17000D73 RID: 3443
		// (get) Token: 0x060051A7 RID: 20903
		// (set) Token: 0x060051A8 RID: 20904
		StreamingContext Context { get; set; }
	}
}
