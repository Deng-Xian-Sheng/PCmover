using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000484 RID: 1156
	internal class TraceLoggingMetadataCollector
	{
		// Token: 0x06003740 RID: 14144 RVA: 0x000D4C47 File Offset: 0x000D2E47
		internal TraceLoggingMetadataCollector()
		{
			this.impl = new TraceLoggingMetadataCollector.Impl();
		}

		// Token: 0x06003741 RID: 14145 RVA: 0x000D4C65 File Offset: 0x000D2E65
		private TraceLoggingMetadataCollector(TraceLoggingMetadataCollector other, FieldMetadata group)
		{
			this.impl = other.impl;
			this.currentGroup = group;
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06003742 RID: 14146 RVA: 0x000D4C8B File Offset: 0x000D2E8B
		// (set) Token: 0x06003743 RID: 14147 RVA: 0x000D4C93 File Offset: 0x000D2E93
		internal EventFieldTags Tags { get; set; }

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06003744 RID: 14148 RVA: 0x000D4C9C File Offset: 0x000D2E9C
		internal int ScratchSize
		{
			get
			{
				return (int)this.impl.scratchSize;
			}
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06003745 RID: 14149 RVA: 0x000D4CA9 File Offset: 0x000D2EA9
		internal int DataCount
		{
			get
			{
				return (int)this.impl.dataCount;
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06003746 RID: 14150 RVA: 0x000D4CB6 File Offset: 0x000D2EB6
		internal int PinCount
		{
			get
			{
				return (int)this.impl.pinCount;
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06003747 RID: 14151 RVA: 0x000D4CC3 File Offset: 0x000D2EC3
		private bool BeginningBufferedArray
		{
			get
			{
				return this.bufferedArrayFieldCount == 0;
			}
		}

		// Token: 0x06003748 RID: 14152 RVA: 0x000D4CD0 File Offset: 0x000D2ED0
		public TraceLoggingMetadataCollector AddGroup(string name)
		{
			TraceLoggingMetadataCollector result = this;
			if (name != null || this.BeginningBufferedArray)
			{
				FieldMetadata fieldMetadata = new FieldMetadata(name, TraceLoggingDataType.Struct, this.Tags, this.BeginningBufferedArray);
				this.AddField(fieldMetadata);
				result = new TraceLoggingMetadataCollector(this, fieldMetadata);
			}
			return result;
		}

		// Token: 0x06003749 RID: 14153 RVA: 0x000D4D10 File Offset: 0x000D2F10
		public void AddScalar(string name, TraceLoggingDataType type)
		{
			TraceLoggingDataType traceLoggingDataType = type & (TraceLoggingDataType)31;
			int size;
			switch (traceLoggingDataType)
			{
			case TraceLoggingDataType.Int8:
			case TraceLoggingDataType.UInt8:
				break;
			case TraceLoggingDataType.Int16:
			case TraceLoggingDataType.UInt16:
				goto IL_6F;
			case TraceLoggingDataType.Int32:
			case TraceLoggingDataType.UInt32:
			case TraceLoggingDataType.Float:
			case TraceLoggingDataType.Boolean32:
			case TraceLoggingDataType.HexInt32:
				size = 4;
				goto IL_8B;
			case TraceLoggingDataType.Int64:
			case TraceLoggingDataType.UInt64:
			case TraceLoggingDataType.Double:
			case TraceLoggingDataType.FileTime:
			case TraceLoggingDataType.HexInt64:
				size = 8;
				goto IL_8B;
			case TraceLoggingDataType.Binary:
			case (TraceLoggingDataType)16:
			case (TraceLoggingDataType)19:
				goto IL_80;
			case TraceLoggingDataType.Guid:
			case TraceLoggingDataType.SystemTime:
				size = 16;
				goto IL_8B;
			default:
				if (traceLoggingDataType != TraceLoggingDataType.Char8)
				{
					if (traceLoggingDataType != TraceLoggingDataType.Char16)
					{
						goto IL_80;
					}
					goto IL_6F;
				}
				break;
			}
			size = 1;
			goto IL_8B;
			IL_6F:
			size = 2;
			goto IL_8B;
			IL_80:
			throw new ArgumentOutOfRangeException("type");
			IL_8B:
			this.impl.AddScalar(size);
			this.AddField(new FieldMetadata(name, type, this.Tags, this.BeginningBufferedArray));
		}

		// Token: 0x0600374A RID: 14154 RVA: 0x000D4DD0 File Offset: 0x000D2FD0
		public void AddBinary(string name, TraceLoggingDataType type)
		{
			TraceLoggingDataType traceLoggingDataType = type & (TraceLoggingDataType)31;
			if (traceLoggingDataType != TraceLoggingDataType.Binary && traceLoggingDataType - TraceLoggingDataType.CountedUtf16String > 1)
			{
				throw new ArgumentOutOfRangeException("type");
			}
			this.impl.AddScalar(2);
			this.impl.AddNonscalar();
			this.AddField(new FieldMetadata(name, type, this.Tags, this.BeginningBufferedArray));
		}

		// Token: 0x0600374B RID: 14155 RVA: 0x000D4E2C File Offset: 0x000D302C
		public void AddArray(string name, TraceLoggingDataType type)
		{
			TraceLoggingDataType traceLoggingDataType = type & (TraceLoggingDataType)31;
			switch (traceLoggingDataType)
			{
			case TraceLoggingDataType.Utf16String:
			case TraceLoggingDataType.MbcsString:
			case TraceLoggingDataType.Int8:
			case TraceLoggingDataType.UInt8:
			case TraceLoggingDataType.Int16:
			case TraceLoggingDataType.UInt16:
			case TraceLoggingDataType.Int32:
			case TraceLoggingDataType.UInt32:
			case TraceLoggingDataType.Int64:
			case TraceLoggingDataType.UInt64:
			case TraceLoggingDataType.Float:
			case TraceLoggingDataType.Double:
			case TraceLoggingDataType.Boolean32:
			case TraceLoggingDataType.Guid:
			case TraceLoggingDataType.FileTime:
			case TraceLoggingDataType.HexInt32:
			case TraceLoggingDataType.HexInt64:
				goto IL_7C;
			case TraceLoggingDataType.Binary:
			case (TraceLoggingDataType)16:
			case TraceLoggingDataType.SystemTime:
			case (TraceLoggingDataType)19:
				break;
			default:
				if (traceLoggingDataType == TraceLoggingDataType.Char8 || traceLoggingDataType == TraceLoggingDataType.Char16)
				{
					goto IL_7C;
				}
				break;
			}
			throw new ArgumentOutOfRangeException("type");
			IL_7C:
			if (this.BeginningBufferedArray)
			{
				throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedNestedArraysEnums"));
			}
			this.impl.AddScalar(2);
			this.impl.AddNonscalar();
			this.AddField(new FieldMetadata(name, type, this.Tags, true));
		}

		// Token: 0x0600374C RID: 14156 RVA: 0x000D4EF8 File Offset: 0x000D30F8
		public void BeginBufferedArray()
		{
			if (this.bufferedArrayFieldCount >= 0)
			{
				throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedNestedArraysEnums"));
			}
			this.bufferedArrayFieldCount = 0;
			this.impl.BeginBuffered();
		}

		// Token: 0x0600374D RID: 14157 RVA: 0x000D4F25 File Offset: 0x000D3125
		public void EndBufferedArray()
		{
			if (this.bufferedArrayFieldCount != 1)
			{
				throw new InvalidOperationException(Environment.GetResourceString("EventSource_IncorrentlyAuthoredTypeInfo"));
			}
			this.bufferedArrayFieldCount = int.MinValue;
			this.impl.EndBuffered();
		}

		// Token: 0x0600374E RID: 14158 RVA: 0x000D4F58 File Offset: 0x000D3158
		public void AddCustom(string name, TraceLoggingDataType type, byte[] metadata)
		{
			if (this.BeginningBufferedArray)
			{
				throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedCustomSerializedData"));
			}
			this.impl.AddScalar(2);
			this.impl.AddNonscalar();
			this.AddField(new FieldMetadata(name, type, this.Tags, metadata));
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x000D4FA8 File Offset: 0x000D31A8
		internal byte[] GetMetadata()
		{
			int num = this.impl.Encode(null);
			byte[] array = new byte[num];
			this.impl.Encode(array);
			return array;
		}

		// Token: 0x06003750 RID: 14160 RVA: 0x000D4FD7 File Offset: 0x000D31D7
		private void AddField(FieldMetadata fieldMetadata)
		{
			this.Tags = EventFieldTags.None;
			this.bufferedArrayFieldCount++;
			this.impl.fields.Add(fieldMetadata);
			if (this.currentGroup != null)
			{
				this.currentGroup.IncrementStructFieldCount();
			}
		}

		// Token: 0x0400189A RID: 6298
		private readonly TraceLoggingMetadataCollector.Impl impl;

		// Token: 0x0400189B RID: 6299
		private readonly FieldMetadata currentGroup;

		// Token: 0x0400189C RID: 6300
		private int bufferedArrayFieldCount = int.MinValue;

		// Token: 0x02000B9E RID: 2974
		private class Impl
		{
			// Token: 0x06006CA1 RID: 27809 RVA: 0x00177F05 File Offset: 0x00176105
			public void AddScalar(int size)
			{
				checked
				{
					if (this.bufferNesting == 0)
					{
						if (!this.scalar)
						{
							this.dataCount += 1;
						}
						this.scalar = true;
						this.scratchSize = (short)((int)this.scratchSize + size);
					}
				}
			}

			// Token: 0x06006CA2 RID: 27810 RVA: 0x00177F3C File Offset: 0x0017613C
			public void AddNonscalar()
			{
				checked
				{
					if (this.bufferNesting == 0)
					{
						this.scalar = false;
						this.pinCount += 1;
						this.dataCount += 1;
					}
				}
			}

			// Token: 0x06006CA3 RID: 27811 RVA: 0x00177F6B File Offset: 0x0017616B
			public void BeginBuffered()
			{
				if (this.bufferNesting == 0)
				{
					this.AddNonscalar();
				}
				this.bufferNesting++;
			}

			// Token: 0x06006CA4 RID: 27812 RVA: 0x00177F89 File Offset: 0x00176189
			public void EndBuffered()
			{
				this.bufferNesting--;
			}

			// Token: 0x06006CA5 RID: 27813 RVA: 0x00177F9C File Offset: 0x0017619C
			public int Encode(byte[] metadata)
			{
				int result = 0;
				foreach (FieldMetadata fieldMetadata in this.fields)
				{
					fieldMetadata.Encode(ref result, metadata);
				}
				return result;
			}

			// Token: 0x0400352E RID: 13614
			internal readonly List<FieldMetadata> fields = new List<FieldMetadata>();

			// Token: 0x0400352F RID: 13615
			internal short scratchSize;

			// Token: 0x04003530 RID: 13616
			internal sbyte dataCount;

			// Token: 0x04003531 RID: 13617
			internal sbyte pinCount;

			// Token: 0x04003532 RID: 13618
			private int bufferNesting;

			// Token: 0x04003533 RID: 13619
			private bool scalar;
		}
	}
}
