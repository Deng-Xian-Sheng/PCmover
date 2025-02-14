﻿using System;
using System.Text;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000448 RID: 1096
	internal class FieldMetadata
	{
		// Token: 0x0600363A RID: 13882 RVA: 0x000D297A File Offset: 0x000D0B7A
		public FieldMetadata(string name, TraceLoggingDataType type, EventFieldTags tags, bool variableCount) : this(name, type, tags, variableCount ? 64 : 0, 0, null)
		{
		}

		// Token: 0x0600363B RID: 13883 RVA: 0x000D2990 File Offset: 0x000D0B90
		public FieldMetadata(string name, TraceLoggingDataType type, EventFieldTags tags, ushort fixedCount) : this(name, type, tags, 32, fixedCount, null)
		{
		}

		// Token: 0x0600363C RID: 13884 RVA: 0x000D29A0 File Offset: 0x000D0BA0
		public FieldMetadata(string name, TraceLoggingDataType type, EventFieldTags tags, byte[] custom) : this(name, type, tags, 96, checked((ushort)((custom == null) ? 0 : custom.Length)), custom)
		{
		}

		// Token: 0x0600363D RID: 13885 RVA: 0x000D29BC File Offset: 0x000D0BBC
		private FieldMetadata(string name, TraceLoggingDataType dataType, EventFieldTags tags, byte countFlags, ushort fixedCount = 0, byte[] custom = null)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "This usually means that the object passed to Write is of a type that does not support being used as the top-level object in an event, e.g. a primitive or built-in type.");
			}
			Statics.CheckName(name);
			int num = (int)(dataType & (TraceLoggingDataType)31);
			this.name = name;
			this.nameSize = Encoding.UTF8.GetByteCount(this.name) + 1;
			this.inType = (byte)(num | (int)countFlags);
			this.outType = (byte)(dataType >> 8 & (TraceLoggingDataType)127);
			this.tags = tags;
			this.fixedCount = fixedCount;
			this.custom = custom;
			if (countFlags != 0)
			{
				if (num == 0)
				{
					throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedArrayOfNil"));
				}
				if (num == 14)
				{
					throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedArrayOfBinary"));
				}
				if (num == 1 || num == 2)
				{
					throw new NotSupportedException(Environment.GetResourceString("EventSource_NotSupportedArrayOfNullTerminatedString"));
				}
			}
			if ((this.tags & (EventFieldTags)268435455) != EventFieldTags.None)
			{
				this.outType |= 128;
			}
			if (this.outType != 0)
			{
				this.inType |= 128;
			}
		}

		// Token: 0x0600363E RID: 13886 RVA: 0x000D2ABB File Offset: 0x000D0CBB
		public void IncrementStructFieldCount()
		{
			this.inType |= 128;
			this.outType += 1;
			if ((this.outType & 127) == 0)
			{
				throw new NotSupportedException(Environment.GetResourceString("EventSource_TooManyFields"));
			}
		}

		// Token: 0x0600363F RID: 13887 RVA: 0x000D2AFC File Offset: 0x000D0CFC
		public void Encode(ref int pos, byte[] metadata)
		{
			if (metadata != null)
			{
				Encoding.UTF8.GetBytes(this.name, 0, this.name.Length, metadata, pos);
			}
			pos += this.nameSize;
			if (metadata != null)
			{
				metadata[pos] = this.inType;
			}
			pos++;
			if ((this.inType & 128) != 0)
			{
				if (metadata != null)
				{
					metadata[pos] = this.outType;
				}
				pos++;
				if ((this.outType & 128) != 0)
				{
					Statics.EncodeTags((int)this.tags, ref pos, metadata);
				}
			}
			if ((this.inType & 32) != 0)
			{
				if (metadata != null)
				{
					metadata[pos] = (byte)this.fixedCount;
					metadata[pos + 1] = (byte)(this.fixedCount >> 8);
				}
				pos += 2;
				if (96 == (this.inType & 96) && this.fixedCount != 0)
				{
					if (metadata != null)
					{
						Buffer.BlockCopy(this.custom, 0, metadata, pos, (int)this.fixedCount);
					}
					pos += (int)this.fixedCount;
				}
			}
		}

		// Token: 0x0400183B RID: 6203
		private readonly string name;

		// Token: 0x0400183C RID: 6204
		private readonly int nameSize;

		// Token: 0x0400183D RID: 6205
		private readonly EventFieldTags tags;

		// Token: 0x0400183E RID: 6206
		private readonly byte[] custom;

		// Token: 0x0400183F RID: 6207
		private readonly ushort fixedCount;

		// Token: 0x04001840 RID: 6208
		private byte inType;

		// Token: 0x04001841 RID: 6209
		private byte outType;
	}
}
