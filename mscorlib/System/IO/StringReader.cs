using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace System.IO
{
	// Token: 0x020001A4 RID: 420
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class StringReader : TextReader
	{
		// Token: 0x06001A0C RID: 6668 RVA: 0x00057237 File Offset: 0x00055437
		[__DynamicallyInvokable]
		public StringReader(string s)
		{
			if (s == null)
			{
				throw new ArgumentNullException("s");
			}
			this._s = s;
			this._length = ((s == null) ? 0 : s.Length);
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x00057266 File Offset: 0x00055466
		public override void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0005726F File Offset: 0x0005546F
		[__DynamicallyInvokable]
		protected override void Dispose(bool disposing)
		{
			this._s = null;
			this._pos = 0;
			this._length = 0;
			base.Dispose(disposing);
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x0005728D File Offset: 0x0005548D
		[__DynamicallyInvokable]
		public override int Peek()
		{
			if (this._s == null)
			{
				__Error.ReaderClosed();
			}
			if (this._pos == this._length)
			{
				return -1;
			}
			return (int)this._s[this._pos];
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x000572C0 File Offset: 0x000554C0
		[__DynamicallyInvokable]
		public override int Read()
		{
			if (this._s == null)
			{
				__Error.ReaderClosed();
			}
			if (this._pos == this._length)
			{
				return -1;
			}
			string s = this._s;
			int pos = this._pos;
			this._pos = pos + 1;
			return (int)s[pos];
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x00057308 File Offset: 0x00055508
		[__DynamicallyInvokable]
		public override int Read([In] [Out] char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			if (this._s == null)
			{
				__Error.ReaderClosed();
			}
			int num = this._length - this._pos;
			if (num > 0)
			{
				if (num > count)
				{
					num = count;
				}
				this._s.CopyTo(this._pos, buffer, index, num);
				this._pos += num;
			}
			return num;
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x000573C0 File Offset: 0x000555C0
		[__DynamicallyInvokable]
		public override string ReadToEnd()
		{
			if (this._s == null)
			{
				__Error.ReaderClosed();
			}
			string result;
			if (this._pos == 0)
			{
				result = this._s;
			}
			else
			{
				result = this._s.Substring(this._pos, this._length - this._pos);
			}
			this._pos = this._length;
			return result;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x00057418 File Offset: 0x00055618
		[__DynamicallyInvokable]
		public override string ReadLine()
		{
			if (this._s == null)
			{
				__Error.ReaderClosed();
			}
			int i;
			for (i = this._pos; i < this._length; i++)
			{
				char c = this._s[i];
				if (c == '\r' || c == '\n')
				{
					string result = this._s.Substring(this._pos, i - this._pos);
					this._pos = i + 1;
					if (c == '\r' && this._pos < this._length && this._s[this._pos] == '\n')
					{
						this._pos++;
					}
					return result;
				}
			}
			if (i > this._pos)
			{
				string result2 = this._s.Substring(this._pos, i - this._pos);
				this._pos = i;
				return result2;
			}
			return null;
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x000574E7 File Offset: 0x000556E7
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override Task<string> ReadLineAsync()
		{
			return Task.FromResult<string>(this.ReadLine());
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x000574F4 File Offset: 0x000556F4
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override Task<string> ReadToEndAsync()
		{
			return Task.FromResult<string>(this.ReadToEnd());
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x00057504 File Offset: 0x00055704
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override Task<int> ReadBlockAsync(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			return Task.FromResult<int>(this.ReadBlock(buffer, index, count));
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x00057578 File Offset: 0x00055778
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public override Task<int> ReadAsync(char[] buffer, int index, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			if (index < 0 || count < 0)
			{
				throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			if (buffer.Length - index < count)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidOffLen"));
			}
			return Task.FromResult<int>(this.Read(buffer, index, count));
		}

		// Token: 0x0400091C RID: 2332
		private string _s;

		// Token: 0x0400091D RID: 2333
		private int _pos;

		// Token: 0x0400091E RID: 2334
		private int _length;
	}
}
