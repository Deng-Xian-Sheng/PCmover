using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
	// Token: 0x020001A6 RID: 422
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class TextReader : MarshalByRefObject, IDisposable
	{
		// Token: 0x06001A2B RID: 6699 RVA: 0x000577BE File Offset: 0x000559BE
		[__DynamicallyInvokable]
		protected TextReader()
		{
		}

		// Token: 0x06001A2C RID: 6700 RVA: 0x000577C6 File Offset: 0x000559C6
		public virtual void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x000577D5 File Offset: 0x000559D5
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x000577E4 File Offset: 0x000559E4
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x000577E6 File Offset: 0x000559E6
		[__DynamicallyInvokable]
		public virtual int Peek()
		{
			return -1;
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x000577E9 File Offset: 0x000559E9
		[__DynamicallyInvokable]
		public virtual int Read()
		{
			return -1;
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x000577EC File Offset: 0x000559EC
		[__DynamicallyInvokable]
		public virtual int Read([In] [Out] char[] buffer, int index, int count)
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
			int num = 0;
			do
			{
				int num2 = this.Read();
				if (num2 == -1)
				{
					break;
				}
				buffer[index + num++] = (char)num2;
			}
			while (num < count);
			return num;
		}

		// Token: 0x06001A32 RID: 6706 RVA: 0x00057878 File Offset: 0x00055A78
		[__DynamicallyInvokable]
		public virtual string ReadToEnd()
		{
			char[] array = new char[4096];
			StringBuilder stringBuilder = new StringBuilder(4096);
			int charCount;
			while ((charCount = this.Read(array, 0, array.Length)) != 0)
			{
				stringBuilder.Append(array, 0, charCount);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06001A33 RID: 6707 RVA: 0x000578BC File Offset: 0x00055ABC
		[__DynamicallyInvokable]
		public virtual int ReadBlock([In] [Out] char[] buffer, int index, int count)
		{
			int num = 0;
			int num2;
			do
			{
				num += (num2 = this.Read(buffer, index + num, count - num));
			}
			while (num2 > 0 && num < count);
			return num;
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x000578E8 File Offset: 0x00055AE8
		[__DynamicallyInvokable]
		public virtual string ReadLine()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			for (;;)
			{
				num = this.Read();
				if (num == -1)
				{
					goto IL_43;
				}
				if (num == 13 || num == 10)
				{
					break;
				}
				stringBuilder.Append((char)num);
			}
			if (num == 13 && this.Peek() == 10)
			{
				this.Read();
			}
			return stringBuilder.ToString();
			IL_43:
			if (stringBuilder.Length > 0)
			{
				return stringBuilder.ToString();
			}
			return null;
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x00057949 File Offset: 0x00055B49
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<string> ReadLineAsync()
		{
			return Task<string>.Factory.StartNew(TextReader._ReadLineDelegate, this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x00057968 File Offset: 0x00055B68
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<string> ReadToEndAsync()
		{
			TextReader.<ReadToEndAsync>d__14 <ReadToEndAsync>d__;
			<ReadToEndAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<ReadToEndAsync>d__.<>4__this = this;
			<ReadToEndAsync>d__.<>1__state = -1;
			<ReadToEndAsync>d__.<>t__builder.Start<TextReader.<ReadToEndAsync>d__14>(ref <ReadToEndAsync>d__);
			return <ReadToEndAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x000579AC File Offset: 0x00055BAC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<int> ReadAsync(char[] buffer, int index, int count)
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
			return this.ReadAsyncInternal(buffer, index, count);
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00057A1C File Offset: 0x00055C1C
		internal virtual Task<int> ReadAsyncInternal(char[] buffer, int index, int count)
		{
			Tuple<TextReader, char[], int, int> state = new Tuple<TextReader, char[], int, int>(this, buffer, index, count);
			return Task<int>.Factory.StartNew(TextReader._ReadDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x00057A50 File Offset: 0x00055C50
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task<int> ReadBlockAsync(char[] buffer, int index, int count)
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
			return this.ReadBlockAsyncInternal(buffer, index, count);
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x00057AC0 File Offset: 0x00055CC0
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		private Task<int> ReadBlockAsyncInternal(char[] buffer, int index, int count)
		{
			TextReader.<ReadBlockAsyncInternal>d__18 <ReadBlockAsyncInternal>d__;
			<ReadBlockAsyncInternal>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<ReadBlockAsyncInternal>d__.<>4__this = this;
			<ReadBlockAsyncInternal>d__.buffer = buffer;
			<ReadBlockAsyncInternal>d__.index = index;
			<ReadBlockAsyncInternal>d__.count = count;
			<ReadBlockAsyncInternal>d__.<>1__state = -1;
			<ReadBlockAsyncInternal>d__.<>t__builder.Start<TextReader.<ReadBlockAsyncInternal>d__18>(ref <ReadBlockAsyncInternal>d__);
			return <ReadBlockAsyncInternal>d__.<>t__builder.Task;
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x00057B1B File Offset: 0x00055D1B
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static TextReader Synchronized(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader is TextReader.SyncTextReader)
			{
				return reader;
			}
			return new TextReader.SyncTextReader(reader);
		}

		// Token: 0x04000922 RID: 2338
		[NonSerialized]
		private static Func<object, string> _ReadLineDelegate = (object state) => ((TextReader)state).ReadLine();

		// Token: 0x04000923 RID: 2339
		[NonSerialized]
		private static Func<object, int> _ReadDelegate = delegate(object state)
		{
			Tuple<TextReader, char[], int, int> tuple = (Tuple<TextReader, char[], int, int>)state;
			return tuple.Item1.Read(tuple.Item2, tuple.Item3, tuple.Item4);
		};

		// Token: 0x04000924 RID: 2340
		[__DynamicallyInvokable]
		public static readonly TextReader Null = new TextReader.NullTextReader();

		// Token: 0x02000B22 RID: 2850
		[Serializable]
		private sealed class NullTextReader : TextReader
		{
			// Token: 0x06006AFE RID: 27390 RVA: 0x00172D9E File Offset: 0x00170F9E
			public override int Read(char[] buffer, int index, int count)
			{
				return 0;
			}

			// Token: 0x06006AFF RID: 27391 RVA: 0x00172DA1 File Offset: 0x00170FA1
			public override string ReadLine()
			{
				return null;
			}
		}

		// Token: 0x02000B23 RID: 2851
		[Serializable]
		internal sealed class SyncTextReader : TextReader
		{
			// Token: 0x06006B00 RID: 27392 RVA: 0x00172DA4 File Offset: 0x00170FA4
			internal SyncTextReader(TextReader t)
			{
				this._in = t;
			}

			// Token: 0x06006B01 RID: 27393 RVA: 0x00172DB3 File Offset: 0x00170FB3
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Close()
			{
				this._in.Close();
			}

			// Token: 0x06006B02 RID: 27394 RVA: 0x00172DC0 File Offset: 0x00170FC0
			[MethodImpl(MethodImplOptions.Synchronized)]
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					((IDisposable)this._in).Dispose();
				}
			}

			// Token: 0x06006B03 RID: 27395 RVA: 0x00172DD0 File Offset: 0x00170FD0
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Peek()
			{
				return this._in.Peek();
			}

			// Token: 0x06006B04 RID: 27396 RVA: 0x00172DDD File Offset: 0x00170FDD
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Read()
			{
				return this._in.Read();
			}

			// Token: 0x06006B05 RID: 27397 RVA: 0x00172DEA File Offset: 0x00170FEA
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int Read([In] [Out] char[] buffer, int index, int count)
			{
				return this._in.Read(buffer, index, count);
			}

			// Token: 0x06006B06 RID: 27398 RVA: 0x00172DFA File Offset: 0x00170FFA
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override int ReadBlock([In] [Out] char[] buffer, int index, int count)
			{
				return this._in.ReadBlock(buffer, index, count);
			}

			// Token: 0x06006B07 RID: 27399 RVA: 0x00172E0A File Offset: 0x0017100A
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override string ReadLine()
			{
				return this._in.ReadLine();
			}

			// Token: 0x06006B08 RID: 27400 RVA: 0x00172E17 File Offset: 0x00171017
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override string ReadToEnd()
			{
				return this._in.ReadToEnd();
			}

			// Token: 0x06006B09 RID: 27401 RVA: 0x00172E24 File Offset: 0x00171024
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<string> ReadLineAsync()
			{
				return Task.FromResult<string>(this.ReadLine());
			}

			// Token: 0x06006B0A RID: 27402 RVA: 0x00172E31 File Offset: 0x00171031
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task<string> ReadToEndAsync()
			{
				return Task.FromResult<string>(this.ReadToEnd());
			}

			// Token: 0x06006B0B RID: 27403 RVA: 0x00172E40 File Offset: 0x00171040
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
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

			// Token: 0x06006B0C RID: 27404 RVA: 0x00172EB4 File Offset: 0x001710B4
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
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

			// Token: 0x04003321 RID: 13089
			internal TextReader _in;
		}
	}
}
