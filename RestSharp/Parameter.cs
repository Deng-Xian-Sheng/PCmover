using System;
using System.Runtime.CompilerServices;
using RestSharp.Validation;

namespace RestSharp
{
	// Token: 0x0200001D RID: 29
	[NullableContext(2)]
	[Nullable(0)]
	[Obsolete("Use Add[XXX]Parameter methods of IRestRequest instead of instantiating the Parameter class.")]
	public class Parameter : IEquatable<Parameter>
	{
		// Token: 0x060002F7 RID: 759 RVA: 0x00005EB4 File Offset: 0x000040B4
		[NullableContext(1)]
		public Parameter(string name, object value, ParameterType type)
		{
			if (type != ParameterType.RequestBody)
			{
				Ensure.NotEmpty(name, "name");
			}
			this.Name = name;
			this.Value = ((type != ParameterType.UrlSegment) ? value : ((value != null) ? value.ToString().Replace("%2F", "/").Replace("%2f", "/") : null));
			this.Type = type;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00005F22 File Offset: 0x00004122
		[NullableContext(1)]
		public Parameter(string name, object value, string contentType, ParameterType type) : this(name, value, type)
		{
			this.ContentType = contentType;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x00005F35 File Offset: 0x00004135
		// (set) Token: 0x060002FA RID: 762 RVA: 0x00005F3D File Offset: 0x0000413D
		public string Name { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060002FB RID: 763 RVA: 0x00005F46 File Offset: 0x00004146
		// (set) Token: 0x060002FC RID: 764 RVA: 0x00005F4E File Offset: 0x0000414E
		public object Value { get; set; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00005F57 File Offset: 0x00004157
		// (set) Token: 0x060002FE RID: 766 RVA: 0x00005F5F File Offset: 0x0000415F
		public ParameterType Type { get; set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00005F68 File Offset: 0x00004168
		// (set) Token: 0x06000300 RID: 768 RVA: 0x00005F70 File Offset: 0x00004170
		public DataFormat DataFormat { get; set; } = DataFormat.None;

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000301 RID: 769 RVA: 0x00005F79 File Offset: 0x00004179
		// (set) Token: 0x06000302 RID: 770 RVA: 0x00005F81 File Offset: 0x00004181
		public string ContentType { get; set; }

		// Token: 0x06000303 RID: 771 RVA: 0x00005F8A File Offset: 0x0000418A
		[NullableContext(1)]
		public override string ToString()
		{
			return string.Format("{0}={1}", this.Name, this.Value);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00005FA4 File Offset: 0x000041A4
		[NullableContext(1)]
		public bool Equals(Parameter other)
		{
			return other != null && (this == other || (this.Name == other.Name && object.Equals(this.Value, other.Value) && this.Type == other.Type && this.DataFormat == other.DataFormat && this.ContentType == other.ContentType));
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00006011 File Offset: 0x00004211
		[NullableContext(1)]
		public override bool Equals(object obj)
		{
			return obj != null && (this == obj || (obj.GetType() == base.GetType() && this.Equals((Parameter)obj)));
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00006040 File Offset: 0x00004240
		public override int GetHashCode()
		{
			return (((((this.Name != null) ? this.Name.GetHashCode() : 0) * 397 ^ ((this.Value != null) ? this.Value.GetHashCode() : 0)) * 397 ^ (int)this.Type) * 397 ^ (int)this.DataFormat) * 397 ^ ((this.ContentType != null) ? this.ContentType.GetHashCode() : 0);
		}
	}
}
