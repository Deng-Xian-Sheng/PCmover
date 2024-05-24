using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Globalization
{
	// Token: 0x020003D2 RID: 978
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class TextElementEnumerator : IEnumerator
	{
		// Token: 0x06003192 RID: 12690 RVA: 0x000BE220 File Offset: 0x000BC420
		internal TextElementEnumerator(string str, int startIndex, int strLen)
		{
			this.str = str;
			this.startIndex = startIndex;
			this.strLen = strLen;
			this.Reset();
		}

		// Token: 0x06003193 RID: 12691 RVA: 0x000BE243 File Offset: 0x000BC443
		[OnDeserializing]
		private void OnDeserializing(StreamingContext ctx)
		{
			this.charLen = -1;
		}

		// Token: 0x06003194 RID: 12692 RVA: 0x000BE24C File Offset: 0x000BC44C
		[OnDeserialized]
		private void OnDeserialized(StreamingContext ctx)
		{
			this.strLen = this.endIndex + 1;
			this.currTextElementLen = this.nextTextElementLen;
			if (this.charLen == -1)
			{
				this.uc = CharUnicodeInfo.InternalGetUnicodeCategory(this.str, this.index, out this.charLen);
			}
		}

		// Token: 0x06003195 RID: 12693 RVA: 0x000BE299 File Offset: 0x000BC499
		[OnSerializing]
		private void OnSerializing(StreamingContext ctx)
		{
			this.endIndex = this.strLen - 1;
			this.nextTextElementLen = this.currTextElementLen;
		}

		// Token: 0x06003196 RID: 12694 RVA: 0x000BE2B8 File Offset: 0x000BC4B8
		[__DynamicallyInvokable]
		public bool MoveNext()
		{
			if (this.index >= this.strLen)
			{
				this.index = this.strLen + 1;
				return false;
			}
			this.currTextElementLen = StringInfo.GetCurrentTextElementLen(this.str, this.index, this.strLen, ref this.uc, ref this.charLen);
			this.index += this.currTextElementLen;
			return true;
		}

		// Token: 0x170006F2 RID: 1778
		// (get) Token: 0x06003197 RID: 12695 RVA: 0x000BE320 File Offset: 0x000BC520
		[__DynamicallyInvokable]
		public object Current
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetTextElement();
			}
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x000BE328 File Offset: 0x000BC528
		[__DynamicallyInvokable]
		public string GetTextElement()
		{
			if (this.index == this.startIndex)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
			}
			if (this.index > this.strLen)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumEnded"));
			}
			return this.str.Substring(this.index - this.currTextElementLen, this.currTextElementLen);
		}

		// Token: 0x170006F3 RID: 1779
		// (get) Token: 0x06003199 RID: 12697 RVA: 0x000BE38F File Offset: 0x000BC58F
		[__DynamicallyInvokable]
		public int ElementIndex
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.index == this.startIndex)
				{
					throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumNotStarted"));
				}
				return this.index - this.currTextElementLen;
			}
		}

		// Token: 0x0600319A RID: 12698 RVA: 0x000BE3BC File Offset: 0x000BC5BC
		[__DynamicallyInvokable]
		public void Reset()
		{
			this.index = this.startIndex;
			if (this.index < this.strLen)
			{
				this.uc = CharUnicodeInfo.InternalGetUnicodeCategory(this.str, this.index, out this.charLen);
			}
		}

		// Token: 0x0400151E RID: 5406
		private string str;

		// Token: 0x0400151F RID: 5407
		private int index;

		// Token: 0x04001520 RID: 5408
		private int startIndex;

		// Token: 0x04001521 RID: 5409
		[NonSerialized]
		private int strLen;

		// Token: 0x04001522 RID: 5410
		[NonSerialized]
		private int currTextElementLen;

		// Token: 0x04001523 RID: 5411
		[OptionalField(VersionAdded = 2)]
		private UnicodeCategory uc;

		// Token: 0x04001524 RID: 5412
		[OptionalField(VersionAdded = 2)]
		private int charLen;

		// Token: 0x04001525 RID: 5413
		private int endIndex;

		// Token: 0x04001526 RID: 5414
		private int nextTextElementLen;
	}
}
