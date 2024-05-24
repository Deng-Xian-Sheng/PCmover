using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics.Tracing
{
	// Token: 0x0200043C RID: 1084
	[SecurityCritical]
	internal struct DataCollector
	{
		// Token: 0x060035DD RID: 13789 RVA: 0x000D1D28 File Offset: 0x000CFF28
		internal unsafe void Enable(byte* scratch, int scratchSize, EventSource.EventData* datas, int dataCount, GCHandle* pins, int pinCount)
		{
			this.datasStart = datas;
			this.scratchEnd = scratch + scratchSize;
			this.datasEnd = datas + dataCount;
			this.pinsEnd = pins + pinCount;
			this.scratch = scratch;
			this.datas = datas;
			this.pins = pins;
			this.writingScalars = false;
		}

		// Token: 0x060035DE RID: 13790 RVA: 0x000D1D87 File Offset: 0x000CFF87
		internal void Disable()
		{
			this = default(DataCollector);
		}

		// Token: 0x060035DF RID: 13791 RVA: 0x000D1D90 File Offset: 0x000CFF90
		internal unsafe EventSource.EventData* Finish()
		{
			this.ScalarsEnd();
			return this.datas;
		}

		// Token: 0x060035E0 RID: 13792 RVA: 0x000D1DA0 File Offset: 0x000CFFA0
		internal unsafe void AddScalar(void* value, int size)
		{
			if (this.bufferNesting != 0)
			{
				int num = this.bufferPos;
				int num2;
				checked
				{
					this.bufferPos += size;
					this.EnsureBuffer();
					num2 = 0;
				}
				while (num2 != size)
				{
					this.buffer[num] = ((byte*)value)[num2];
					num2++;
					num++;
				}
				return;
			}
			byte* ptr = this.scratch;
			byte* ptr2 = ptr + size;
			if (this.scratchEnd < ptr2)
			{
				throw new IndexOutOfRangeException(Environment.GetResourceString("EventSource_AddScalarOutOfRange"));
			}
			this.ScalarsBegin();
			this.scratch = ptr2;
			for (int num3 = 0; num3 != size; num3++)
			{
				ptr[num3] = ((byte*)value)[num3];
			}
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x000D1E40 File Offset: 0x000D0040
		internal unsafe void AddBinary(string value, int size)
		{
			if (size > 65535)
			{
				size = 65534;
			}
			if (this.bufferNesting != 0)
			{
				this.EnsureBuffer(size + 2);
			}
			this.AddScalar((void*)(&size), 2);
			if (size != 0)
			{
				if (this.bufferNesting == 0)
				{
					this.ScalarsEnd();
					this.PinArray(value, size);
					return;
				}
				int startIndex = this.bufferPos;
				checked
				{
					this.bufferPos += size;
					this.EnsureBuffer();
				}
				fixed (string text = value)
				{
					void* ptr = text;
					if (ptr != null)
					{
						ptr = (void*)((byte*)ptr + RuntimeHelpers.OffsetToStringData);
					}
					Marshal.Copy((IntPtr)ptr, this.buffer, startIndex, size);
				}
			}
		}

		// Token: 0x060035E2 RID: 13794 RVA: 0x000D1ED1 File Offset: 0x000D00D1
		internal void AddBinary(Array value, int size)
		{
			this.AddArray(value, size, 1);
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x000D1EDC File Offset: 0x000D00DC
		internal unsafe void AddArray(Array value, int length, int itemSize)
		{
			if (length > 65535)
			{
				length = 65535;
			}
			int num = length * itemSize;
			if (this.bufferNesting != 0)
			{
				this.EnsureBuffer(num + 2);
			}
			this.AddScalar((void*)(&length), 2);
			checked
			{
				if (length != 0)
				{
					if (this.bufferNesting == 0)
					{
						this.ScalarsEnd();
						this.PinArray(value, num);
						return;
					}
					int dstOffset = this.bufferPos;
					this.bufferPos += num;
					this.EnsureBuffer();
					Buffer.BlockCopy(value, 0, this.buffer, dstOffset, num);
				}
			}
		}

		// Token: 0x060035E4 RID: 13796 RVA: 0x000D1F5B File Offset: 0x000D015B
		internal int BeginBufferedArray()
		{
			this.BeginBuffered();
			this.bufferPos += 2;
			return this.bufferPos;
		}

		// Token: 0x060035E5 RID: 13797 RVA: 0x000D1F77 File Offset: 0x000D0177
		internal void EndBufferedArray(int bookmark, int count)
		{
			this.EnsureBuffer();
			this.buffer[bookmark - 2] = (byte)count;
			this.buffer[bookmark - 1] = (byte)(count >> 8);
			this.EndBuffered();
		}

		// Token: 0x060035E6 RID: 13798 RVA: 0x000D1F9F File Offset: 0x000D019F
		internal void BeginBuffered()
		{
			this.ScalarsEnd();
			this.bufferNesting++;
		}

		// Token: 0x060035E7 RID: 13799 RVA: 0x000D1FB5 File Offset: 0x000D01B5
		internal void EndBuffered()
		{
			this.bufferNesting--;
			if (this.bufferNesting == 0)
			{
				this.EnsureBuffer();
				this.PinArray(this.buffer, this.bufferPos);
				this.buffer = null;
				this.bufferPos = 0;
			}
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x000D1FF4 File Offset: 0x000D01F4
		private void EnsureBuffer()
		{
			int num = this.bufferPos;
			if (this.buffer == null || this.buffer.Length < num)
			{
				this.GrowBuffer(num);
			}
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x000D2024 File Offset: 0x000D0224
		private void EnsureBuffer(int additionalSize)
		{
			int num = this.bufferPos + additionalSize;
			if (this.buffer == null || this.buffer.Length < num)
			{
				this.GrowBuffer(num);
			}
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x000D2054 File Offset: 0x000D0254
		private void GrowBuffer(int required)
		{
			int num = (this.buffer == null) ? 64 : this.buffer.Length;
			do
			{
				num *= 2;
			}
			while (num < required);
			Array.Resize<byte>(ref this.buffer, num);
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x000D208C File Offset: 0x000D028C
		private unsafe void PinArray(object value, int size)
		{
			GCHandle* ptr = this.pins;
			if (this.pinsEnd == ptr)
			{
				throw new IndexOutOfRangeException(Environment.GetResourceString("EventSource_PinArrayOutOfRange"));
			}
			EventSource.EventData* ptr2 = this.datas;
			if (this.datasEnd == ptr2)
			{
				throw new IndexOutOfRangeException(Environment.GetResourceString("EventSource_DataDescriptorsOutOfRange"));
			}
			this.pins = ptr + 1;
			this.datas = ptr2 + 1;
			*ptr = GCHandle.Alloc(value, GCHandleType.Pinned);
			ptr2->DataPointer = ptr->AddrOfPinnedObject();
			ptr2->m_Size = size;
		}

		// Token: 0x060035EC RID: 13804 RVA: 0x000D2118 File Offset: 0x000D0318
		private unsafe void ScalarsBegin()
		{
			if (!this.writingScalars)
			{
				EventSource.EventData* ptr = this.datas;
				if (this.datasEnd == ptr)
				{
					throw new IndexOutOfRangeException(Environment.GetResourceString("EventSource_DataDescriptorsOutOfRange"));
				}
				ptr->DataPointer = (IntPtr)((void*)this.scratch);
				this.writingScalars = true;
			}
		}

		// Token: 0x060035ED RID: 13805 RVA: 0x000D2168 File Offset: 0x000D0368
		private unsafe void ScalarsEnd()
		{
			if (this.writingScalars)
			{
				EventSource.EventData* ptr = this.datas;
				ptr->m_Size = (this.scratch - checked((UIntPtr)ptr->m_Ptr)) / 1;
				this.datas = ptr + 1;
				this.writingScalars = false;
			}
		}

		// Token: 0x04001808 RID: 6152
		[ThreadStatic]
		internal static DataCollector ThreadInstance;

		// Token: 0x04001809 RID: 6153
		private unsafe byte* scratchEnd;

		// Token: 0x0400180A RID: 6154
		private unsafe EventSource.EventData* datasEnd;

		// Token: 0x0400180B RID: 6155
		private unsafe GCHandle* pinsEnd;

		// Token: 0x0400180C RID: 6156
		private unsafe EventSource.EventData* datasStart;

		// Token: 0x0400180D RID: 6157
		private unsafe byte* scratch;

		// Token: 0x0400180E RID: 6158
		private unsafe EventSource.EventData* datas;

		// Token: 0x0400180F RID: 6159
		private unsafe GCHandle* pins;

		// Token: 0x04001810 RID: 6160
		private byte[] buffer;

		// Token: 0x04001811 RID: 6161
		private int bufferPos;

		// Token: 0x04001812 RID: 6162
		private int bufferNesting;

		// Token: 0x04001813 RID: 6163
		private bool writingScalars;
	}
}
