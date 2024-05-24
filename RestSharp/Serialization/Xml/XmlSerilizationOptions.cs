using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace RestSharp.Serialization.Xml
{
	// Token: 0x02000043 RID: 67
	[NullableContext(1)]
	[Nullable(0)]
	public class XmlSerilizationOptions
	{
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000B165 File Offset: 0x00009365
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x0000B16D File Offset: 0x0000936D
		public string RootElement { get; set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000B176 File Offset: 0x00009376
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x0000B17E File Offset: 0x0000937E
		public string Namespace { get; set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000B187 File Offset: 0x00009387
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x0000B18F File Offset: 0x0000938F
		public string DateFormat { get; set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000B198 File Offset: 0x00009398
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x0000B1A0 File Offset: 0x000093A0
		public CultureInfo Culture { get; set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000B1A9 File Offset: 0x000093A9
		public static XmlSerilizationOptions Default
		{
			get
			{
				return new XmlSerilizationOptions
				{
					Culture = CultureInfo.InvariantCulture
				};
			}
		}
	}
}
