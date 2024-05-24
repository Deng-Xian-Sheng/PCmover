using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using RestSharp.Extensions;

namespace RestSharp.Serializers
{
	// Token: 0x02000033 RID: 51
	[NullableContext(1)]
	[Nullable(0)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false)]
	public sealed class SerializeAsAttribute : Attribute
	{
		// Token: 0x06000439 RID: 1081 RVA: 0x000096FC File Offset: 0x000078FC
		public SerializeAsAttribute()
		{
			this.NameStyle = NameStyle.AsIs;
			this.Index = int.MaxValue;
			this.Culture = CultureInfo.InvariantCulture;
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00009721 File Offset: 0x00007921
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00009729 File Offset: 0x00007929
		public string Name { get; set; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00009732 File Offset: 0x00007932
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x0000973A File Offset: 0x0000793A
		public bool Attribute { get; set; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x00009743 File Offset: 0x00007943
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x0000974B File Offset: 0x0000794B
		public bool Content { get; set; }

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x00009754 File Offset: 0x00007954
		// (set) Token: 0x06000441 RID: 1089 RVA: 0x0000975C File Offset: 0x0000795C
		public CultureInfo Culture { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x00009765 File Offset: 0x00007965
		// (set) Token: 0x06000443 RID: 1091 RVA: 0x0000976D File Offset: 0x0000796D
		public NameStyle NameStyle { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x00009776 File Offset: 0x00007976
		// (set) Token: 0x06000445 RID: 1093 RVA: 0x0000977E File Offset: 0x0000797E
		public int Index { get; set; }

		// Token: 0x06000446 RID: 1094 RVA: 0x00009788 File Offset: 0x00007988
		public string TransformName(string input)
		{
			string text = this.Name ?? input;
			string result;
			switch (this.NameStyle)
			{
			case NameStyle.CamelCase:
				result = text.ToCamelCase(this.Culture);
				break;
			case NameStyle.LowerCase:
				result = text.ToLower(this.Culture);
				break;
			case NameStyle.PascalCase:
				result = text.ToPascalCase(this.Culture);
				break;
			default:
				result = input;
				break;
			}
			return result;
		}
	}
}
