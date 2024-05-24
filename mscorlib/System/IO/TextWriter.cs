using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
	// Token: 0x020001A7 RID: 423
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class TextWriter : MarshalByRefObject, IDisposable
	{
		// Token: 0x06001A3D RID: 6717 RVA: 0x00057B71 File Offset: 0x00055D71
		[__DynamicallyInvokable]
		protected TextWriter()
		{
			this.InternalFormatProvider = null;
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x00057B96 File Offset: 0x00055D96
		[__DynamicallyInvokable]
		protected TextWriter(IFormatProvider formatProvider)
		{
			this.InternalFormatProvider = formatProvider;
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06001A3F RID: 6719 RVA: 0x00057BBB File Offset: 0x00055DBB
		[__DynamicallyInvokable]
		public virtual IFormatProvider FormatProvider
		{
			[__DynamicallyInvokable]
			get
			{
				if (this.InternalFormatProvider == null)
				{
					return Thread.CurrentThread.CurrentCulture;
				}
				return this.InternalFormatProvider;
			}
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x00057BD6 File Offset: 0x00055DD6
		public virtual void Close()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x00057BE5 File Offset: 0x00055DE5
		[__DynamicallyInvokable]
		protected virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x00057BE7 File Offset: 0x00055DE7
		[__DynamicallyInvokable]
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x00057BF6 File Offset: 0x00055DF6
		[__DynamicallyInvokable]
		public virtual void Flush()
		{
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06001A44 RID: 6724
		[__DynamicallyInvokable]
		public abstract Encoding Encoding { [__DynamicallyInvokable] get; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06001A45 RID: 6725 RVA: 0x00057BF8 File Offset: 0x00055DF8
		// (set) Token: 0x06001A46 RID: 6726 RVA: 0x00057C05 File Offset: 0x00055E05
		[__DynamicallyInvokable]
		public virtual string NewLine
		{
			[__DynamicallyInvokable]
			get
			{
				return new string(this.CoreNewLine);
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					value = "\r\n";
				}
				this.CoreNewLine = value.ToCharArray();
			}
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x00057C1D File Offset: 0x00055E1D
		[HostProtection(SecurityAction.LinkDemand, Synchronization = true)]
		public static TextWriter Synchronized(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (writer is TextWriter.SyncTextWriter)
			{
				return writer;
			}
			return new TextWriter.SyncTextWriter(writer);
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x00057C3D File Offset: 0x00055E3D
		[__DynamicallyInvokable]
		public virtual void Write(char value)
		{
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x00057C3F File Offset: 0x00055E3F
		[__DynamicallyInvokable]
		public virtual void Write(char[] buffer)
		{
			if (buffer != null)
			{
				this.Write(buffer, 0, buffer.Length);
			}
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x00057C50 File Offset: 0x00055E50
		[__DynamicallyInvokable]
		public virtual void Write(char[] buffer, int index, int count)
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
			for (int i = 0; i < count; i++)
			{
				this.Write(buffer[index + i]);
			}
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x00057CD6 File Offset: 0x00055ED6
		[__DynamicallyInvokable]
		public virtual void Write(bool value)
		{
			this.Write(value ? "True" : "False");
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00057CED File Offset: 0x00055EED
		[__DynamicallyInvokable]
		public virtual void Write(int value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x00057D02 File Offset: 0x00055F02
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual void Write(uint value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00057D17 File Offset: 0x00055F17
		[__DynamicallyInvokable]
		public virtual void Write(long value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x00057D2C File Offset: 0x00055F2C
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual void Write(ulong value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x00057D41 File Offset: 0x00055F41
		[__DynamicallyInvokable]
		public virtual void Write(float value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x00057D56 File Offset: 0x00055F56
		[__DynamicallyInvokable]
		public virtual void Write(double value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x00057D6B File Offset: 0x00055F6B
		[__DynamicallyInvokable]
		public virtual void Write(decimal value)
		{
			this.Write(value.ToString(this.FormatProvider));
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x00057D80 File Offset: 0x00055F80
		[__DynamicallyInvokable]
		public virtual void Write(string value)
		{
			if (value != null)
			{
				this.Write(value.ToCharArray());
			}
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00057D94 File Offset: 0x00055F94
		[__DynamicallyInvokable]
		public virtual void Write(object value)
		{
			if (value != null)
			{
				IFormattable formattable = value as IFormattable;
				if (formattable != null)
				{
					this.Write(formattable.ToString(null, this.FormatProvider));
					return;
				}
				this.Write(value.ToString());
			}
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x00057DCE File Offset: 0x00055FCE
		[__DynamicallyInvokable]
		public virtual void Write(string format, object arg0)
		{
			this.Write(string.Format(this.FormatProvider, format, arg0));
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00057DE3 File Offset: 0x00055FE3
		[__DynamicallyInvokable]
		public virtual void Write(string format, object arg0, object arg1)
		{
			this.Write(string.Format(this.FormatProvider, format, arg0, arg1));
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00057DF9 File Offset: 0x00055FF9
		[__DynamicallyInvokable]
		public virtual void Write(string format, object arg0, object arg1, object arg2)
		{
			this.Write(string.Format(this.FormatProvider, format, arg0, arg1, arg2));
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00057E11 File Offset: 0x00056011
		[__DynamicallyInvokable]
		public virtual void Write(string format, params object[] arg)
		{
			this.Write(string.Format(this.FormatProvider, format, arg));
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x00057E26 File Offset: 0x00056026
		[__DynamicallyInvokable]
		public virtual void WriteLine()
		{
			this.Write(this.CoreNewLine);
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x00057E34 File Offset: 0x00056034
		[__DynamicallyInvokable]
		public virtual void WriteLine(char value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x00057E43 File Offset: 0x00056043
		[__DynamicallyInvokable]
		public virtual void WriteLine(char[] buffer)
		{
			this.Write(buffer);
			this.WriteLine();
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x00057E52 File Offset: 0x00056052
		[__DynamicallyInvokable]
		public virtual void WriteLine(char[] buffer, int index, int count)
		{
			this.Write(buffer, index, count);
			this.WriteLine();
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00057E63 File Offset: 0x00056063
		[__DynamicallyInvokable]
		public virtual void WriteLine(bool value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00057E72 File Offset: 0x00056072
		[__DynamicallyInvokable]
		public virtual void WriteLine(int value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x00057E81 File Offset: 0x00056081
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual void WriteLine(uint value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00057E90 File Offset: 0x00056090
		[__DynamicallyInvokable]
		public virtual void WriteLine(long value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00057E9F File Offset: 0x0005609F
		[CLSCompliant(false)]
		[__DynamicallyInvokable]
		public virtual void WriteLine(ulong value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x00057EAE File Offset: 0x000560AE
		[__DynamicallyInvokable]
		public virtual void WriteLine(float value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00057EBD File Offset: 0x000560BD
		[__DynamicallyInvokable]
		public virtual void WriteLine(double value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x00057ECC File Offset: 0x000560CC
		[__DynamicallyInvokable]
		public virtual void WriteLine(decimal value)
		{
			this.Write(value);
			this.WriteLine();
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x00057EDC File Offset: 0x000560DC
		[__DynamicallyInvokable]
		public virtual void WriteLine(string value)
		{
			if (value == null)
			{
				this.WriteLine();
				return;
			}
			int length = value.Length;
			int num = this.CoreNewLine.Length;
			char[] array = new char[length + num];
			value.CopyTo(0, array, 0, length);
			if (num == 2)
			{
				array[length] = this.CoreNewLine[0];
				array[length + 1] = this.CoreNewLine[1];
			}
			else if (num == 1)
			{
				array[length] = this.CoreNewLine[0];
			}
			else
			{
				Buffer.InternalBlockCopy(this.CoreNewLine, 0, array, length * 2, num * 2);
			}
			this.Write(array, 0, length + num);
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x00057F64 File Offset: 0x00056164
		[__DynamicallyInvokable]
		public virtual void WriteLine(object value)
		{
			if (value == null)
			{
				this.WriteLine();
				return;
			}
			IFormattable formattable = value as IFormattable;
			if (formattable != null)
			{
				this.WriteLine(formattable.ToString(null, this.FormatProvider));
				return;
			}
			this.WriteLine(value.ToString());
		}

		// Token: 0x06001A67 RID: 6759 RVA: 0x00057FA5 File Offset: 0x000561A5
		[__DynamicallyInvokable]
		public virtual void WriteLine(string format, object arg0)
		{
			this.WriteLine(string.Format(this.FormatProvider, format, arg0));
		}

		// Token: 0x06001A68 RID: 6760 RVA: 0x00057FBA File Offset: 0x000561BA
		[__DynamicallyInvokable]
		public virtual void WriteLine(string format, object arg0, object arg1)
		{
			this.WriteLine(string.Format(this.FormatProvider, format, arg0, arg1));
		}

		// Token: 0x06001A69 RID: 6761 RVA: 0x00057FD0 File Offset: 0x000561D0
		[__DynamicallyInvokable]
		public virtual void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			this.WriteLine(string.Format(this.FormatProvider, format, arg0, arg1, arg2));
		}

		// Token: 0x06001A6A RID: 6762 RVA: 0x00057FE8 File Offset: 0x000561E8
		[__DynamicallyInvokable]
		public virtual void WriteLine(string format, params object[] arg)
		{
			this.WriteLine(string.Format(this.FormatProvider, format, arg));
		}

		// Token: 0x06001A6B RID: 6763 RVA: 0x00058000 File Offset: 0x00056200
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteAsync(char value)
		{
			Tuple<TextWriter, char> state = new Tuple<TextWriter, char>(this, value);
			return Task.Factory.StartNew(TextWriter._WriteCharDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A6C RID: 6764 RVA: 0x00058030 File Offset: 0x00056230
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteAsync(string value)
		{
			Tuple<TextWriter, string> state = new Tuple<TextWriter, string>(this, value);
			return Task.Factory.StartNew(TextWriter._WriteStringDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A6D RID: 6765 RVA: 0x00058060 File Offset: 0x00056260
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public Task WriteAsync(char[] buffer)
		{
			if (buffer == null)
			{
				return Task.CompletedTask;
			}
			return this.WriteAsync(buffer, 0, buffer.Length);
		}

		// Token: 0x06001A6E RID: 6766 RVA: 0x00058078 File Offset: 0x00056278
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteAsync(char[] buffer, int index, int count)
		{
			Tuple<TextWriter, char[], int, int> state = new Tuple<TextWriter, char[], int, int>(this, buffer, index, count);
			return Task.Factory.StartNew(TextWriter._WriteCharArrayRangeDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A6F RID: 6767 RVA: 0x000580AC File Offset: 0x000562AC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteLineAsync(char value)
		{
			Tuple<TextWriter, char> state = new Tuple<TextWriter, char>(this, value);
			return Task.Factory.StartNew(TextWriter._WriteLineCharDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A70 RID: 6768 RVA: 0x000580DC File Offset: 0x000562DC
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteLineAsync(string value)
		{
			Tuple<TextWriter, string> state = new Tuple<TextWriter, string>(this, value);
			return Task.Factory.StartNew(TextWriter._WriteLineStringDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x0005810C File Offset: 0x0005630C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public Task WriteLineAsync(char[] buffer)
		{
			if (buffer == null)
			{
				return Task.CompletedTask;
			}
			return this.WriteLineAsync(buffer, 0, buffer.Length);
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x00058124 File Offset: 0x00056324
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteLineAsync(char[] buffer, int index, int count)
		{
			Tuple<TextWriter, char[], int, int> state = new Tuple<TextWriter, char[], int, int>(this, buffer, index, count);
			return Task.Factory.StartNew(TextWriter._WriteLineCharArrayRangeDelegate, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x00058156 File Offset: 0x00056356
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task WriteLineAsync()
		{
			return this.WriteAsync(this.CoreNewLine);
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x00058164 File Offset: 0x00056364
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public virtual Task FlushAsync()
		{
			return Task.Factory.StartNew(TextWriter._FlushDelegate, this, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
		}

		// Token: 0x04000925 RID: 2341
		[__DynamicallyInvokable]
		public static readonly TextWriter Null = new TextWriter.NullTextWriter();

		// Token: 0x04000926 RID: 2342
		[NonSerialized]
		private static Action<object> _WriteCharDelegate = delegate(object state)
		{
			Tuple<TextWriter, char> tuple = (Tuple<TextWriter, char>)state;
			tuple.Item1.Write(tuple.Item2);
		};

		// Token: 0x04000927 RID: 2343
		[NonSerialized]
		private static Action<object> _WriteStringDelegate = delegate(object state)
		{
			Tuple<TextWriter, string> tuple = (Tuple<TextWriter, string>)state;
			tuple.Item1.Write(tuple.Item2);
		};

		// Token: 0x04000928 RID: 2344
		[NonSerialized]
		private static Action<object> _WriteCharArrayRangeDelegate = delegate(object state)
		{
			Tuple<TextWriter, char[], int, int> tuple = (Tuple<TextWriter, char[], int, int>)state;
			tuple.Item1.Write(tuple.Item2, tuple.Item3, tuple.Item4);
		};

		// Token: 0x04000929 RID: 2345
		[NonSerialized]
		private static Action<object> _WriteLineCharDelegate = delegate(object state)
		{
			Tuple<TextWriter, char> tuple = (Tuple<TextWriter, char>)state;
			tuple.Item1.WriteLine(tuple.Item2);
		};

		// Token: 0x0400092A RID: 2346
		[NonSerialized]
		private static Action<object> _WriteLineStringDelegate = delegate(object state)
		{
			Tuple<TextWriter, string> tuple = (Tuple<TextWriter, string>)state;
			tuple.Item1.WriteLine(tuple.Item2);
		};

		// Token: 0x0400092B RID: 2347
		[NonSerialized]
		private static Action<object> _WriteLineCharArrayRangeDelegate = delegate(object state)
		{
			Tuple<TextWriter, char[], int, int> tuple = (Tuple<TextWriter, char[], int, int>)state;
			tuple.Item1.WriteLine(tuple.Item2, tuple.Item3, tuple.Item4);
		};

		// Token: 0x0400092C RID: 2348
		[NonSerialized]
		private static Action<object> _FlushDelegate = delegate(object state)
		{
			((TextWriter)state).Flush();
		};

		// Token: 0x0400092D RID: 2349
		private const string InitialNewLine = "\r\n";

		// Token: 0x0400092E RID: 2350
		[__DynamicallyInvokable]
		protected char[] CoreNewLine = new char[]
		{
			'\r',
			'\n'
		};

		// Token: 0x0400092F RID: 2351
		private IFormatProvider InternalFormatProvider;

		// Token: 0x02000B27 RID: 2855
		[Serializable]
		private sealed class NullTextWriter : TextWriter
		{
			// Token: 0x06006B15 RID: 27413 RVA: 0x001731F5 File Offset: 0x001713F5
			internal NullTextWriter() : base(CultureInfo.InvariantCulture)
			{
			}

			// Token: 0x1700121A RID: 4634
			// (get) Token: 0x06006B16 RID: 27414 RVA: 0x00173202 File Offset: 0x00171402
			public override Encoding Encoding
			{
				get
				{
					return Encoding.Default;
				}
			}

			// Token: 0x06006B17 RID: 27415 RVA: 0x00173209 File Offset: 0x00171409
			public override void Write(char[] buffer, int index, int count)
			{
			}

			// Token: 0x06006B18 RID: 27416 RVA: 0x0017320B File Offset: 0x0017140B
			public override void Write(string value)
			{
			}

			// Token: 0x06006B19 RID: 27417 RVA: 0x0017320D File Offset: 0x0017140D
			public override void WriteLine()
			{
			}

			// Token: 0x06006B1A RID: 27418 RVA: 0x0017320F File Offset: 0x0017140F
			public override void WriteLine(string value)
			{
			}

			// Token: 0x06006B1B RID: 27419 RVA: 0x00173211 File Offset: 0x00171411
			public override void WriteLine(object value)
			{
			}
		}

		// Token: 0x02000B28 RID: 2856
		[Serializable]
		internal sealed class SyncTextWriter : TextWriter, IDisposable
		{
			// Token: 0x06006B1C RID: 27420 RVA: 0x00173213 File Offset: 0x00171413
			internal SyncTextWriter(TextWriter t) : base(t.FormatProvider)
			{
				this._out = t;
			}

			// Token: 0x1700121B RID: 4635
			// (get) Token: 0x06006B1D RID: 27421 RVA: 0x00173228 File Offset: 0x00171428
			public override Encoding Encoding
			{
				get
				{
					return this._out.Encoding;
				}
			}

			// Token: 0x1700121C RID: 4636
			// (get) Token: 0x06006B1E RID: 27422 RVA: 0x00173235 File Offset: 0x00171435
			public override IFormatProvider FormatProvider
			{
				get
				{
					return this._out.FormatProvider;
				}
			}

			// Token: 0x1700121D RID: 4637
			// (get) Token: 0x06006B1F RID: 27423 RVA: 0x00173242 File Offset: 0x00171442
			// (set) Token: 0x06006B20 RID: 27424 RVA: 0x0017324F File Offset: 0x0017144F
			public override string NewLine
			{
				[MethodImpl(MethodImplOptions.Synchronized)]
				get
				{
					return this._out.NewLine;
				}
				[MethodImpl(MethodImplOptions.Synchronized)]
				set
				{
					this._out.NewLine = value;
				}
			}

			// Token: 0x06006B21 RID: 27425 RVA: 0x0017325D File Offset: 0x0017145D
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Close()
			{
				this._out.Close();
			}

			// Token: 0x06006B22 RID: 27426 RVA: 0x0017326A File Offset: 0x0017146A
			[MethodImpl(MethodImplOptions.Synchronized)]
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					((IDisposable)this._out).Dispose();
				}
			}

			// Token: 0x06006B23 RID: 27427 RVA: 0x0017327A File Offset: 0x0017147A
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Flush()
			{
				this._out.Flush();
			}

			// Token: 0x06006B24 RID: 27428 RVA: 0x00173287 File Offset: 0x00171487
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(char value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B25 RID: 27429 RVA: 0x00173295 File Offset: 0x00171495
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(char[] buffer)
			{
				this._out.Write(buffer);
			}

			// Token: 0x06006B26 RID: 27430 RVA: 0x001732A3 File Offset: 0x001714A3
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(char[] buffer, int index, int count)
			{
				this._out.Write(buffer, index, count);
			}

			// Token: 0x06006B27 RID: 27431 RVA: 0x001732B3 File Offset: 0x001714B3
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(bool value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B28 RID: 27432 RVA: 0x001732C1 File Offset: 0x001714C1
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(int value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B29 RID: 27433 RVA: 0x001732CF File Offset: 0x001714CF
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(uint value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2A RID: 27434 RVA: 0x001732DD File Offset: 0x001714DD
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(long value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2B RID: 27435 RVA: 0x001732EB File Offset: 0x001714EB
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(ulong value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2C RID: 27436 RVA: 0x001732F9 File Offset: 0x001714F9
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(float value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2D RID: 27437 RVA: 0x00173307 File Offset: 0x00171507
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(double value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2E RID: 27438 RVA: 0x00173315 File Offset: 0x00171515
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(decimal value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B2F RID: 27439 RVA: 0x00173323 File Offset: 0x00171523
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(string value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B30 RID: 27440 RVA: 0x00173331 File Offset: 0x00171531
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(object value)
			{
				this._out.Write(value);
			}

			// Token: 0x06006B31 RID: 27441 RVA: 0x0017333F File Offset: 0x0017153F
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(string format, object arg0)
			{
				this._out.Write(format, arg0);
			}

			// Token: 0x06006B32 RID: 27442 RVA: 0x0017334E File Offset: 0x0017154E
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(string format, object arg0, object arg1)
			{
				this._out.Write(format, arg0, arg1);
			}

			// Token: 0x06006B33 RID: 27443 RVA: 0x0017335E File Offset: 0x0017155E
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(string format, object arg0, object arg1, object arg2)
			{
				this._out.Write(format, arg0, arg1, arg2);
			}

			// Token: 0x06006B34 RID: 27444 RVA: 0x00173370 File Offset: 0x00171570
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void Write(string format, params object[] arg)
			{
				this._out.Write(format, arg);
			}

			// Token: 0x06006B35 RID: 27445 RVA: 0x0017337F File Offset: 0x0017157F
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine()
			{
				this._out.WriteLine();
			}

			// Token: 0x06006B36 RID: 27446 RVA: 0x0017338C File Offset: 0x0017158C
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(char value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B37 RID: 27447 RVA: 0x0017339A File Offset: 0x0017159A
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(decimal value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B38 RID: 27448 RVA: 0x001733A8 File Offset: 0x001715A8
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(char[] buffer)
			{
				this._out.WriteLine(buffer);
			}

			// Token: 0x06006B39 RID: 27449 RVA: 0x001733B6 File Offset: 0x001715B6
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(char[] buffer, int index, int count)
			{
				this._out.WriteLine(buffer, index, count);
			}

			// Token: 0x06006B3A RID: 27450 RVA: 0x001733C6 File Offset: 0x001715C6
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(bool value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B3B RID: 27451 RVA: 0x001733D4 File Offset: 0x001715D4
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(int value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B3C RID: 27452 RVA: 0x001733E2 File Offset: 0x001715E2
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(uint value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B3D RID: 27453 RVA: 0x001733F0 File Offset: 0x001715F0
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(long value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B3E RID: 27454 RVA: 0x001733FE File Offset: 0x001715FE
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(ulong value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B3F RID: 27455 RVA: 0x0017340C File Offset: 0x0017160C
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(float value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B40 RID: 27456 RVA: 0x0017341A File Offset: 0x0017161A
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(double value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B41 RID: 27457 RVA: 0x00173428 File Offset: 0x00171628
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(string value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B42 RID: 27458 RVA: 0x00173436 File Offset: 0x00171636
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(object value)
			{
				this._out.WriteLine(value);
			}

			// Token: 0x06006B43 RID: 27459 RVA: 0x00173444 File Offset: 0x00171644
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(string format, object arg0)
			{
				this._out.WriteLine(format, arg0);
			}

			// Token: 0x06006B44 RID: 27460 RVA: 0x00173453 File Offset: 0x00171653
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(string format, object arg0, object arg1)
			{
				this._out.WriteLine(format, arg0, arg1);
			}

			// Token: 0x06006B45 RID: 27461 RVA: 0x00173463 File Offset: 0x00171663
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(string format, object arg0, object arg1, object arg2)
			{
				this._out.WriteLine(format, arg0, arg1, arg2);
			}

			// Token: 0x06006B46 RID: 27462 RVA: 0x00173475 File Offset: 0x00171675
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override void WriteLine(string format, params object[] arg)
			{
				this._out.WriteLine(format, arg);
			}

			// Token: 0x06006B47 RID: 27463 RVA: 0x00173484 File Offset: 0x00171684
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteAsync(char value)
			{
				this.Write(value);
				return Task.CompletedTask;
			}

			// Token: 0x06006B48 RID: 27464 RVA: 0x00173492 File Offset: 0x00171692
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteAsync(string value)
			{
				this.Write(value);
				return Task.CompletedTask;
			}

			// Token: 0x06006B49 RID: 27465 RVA: 0x001734A0 File Offset: 0x001716A0
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteAsync(char[] buffer, int index, int count)
			{
				this.Write(buffer, index, count);
				return Task.CompletedTask;
			}

			// Token: 0x06006B4A RID: 27466 RVA: 0x001734B0 File Offset: 0x001716B0
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteLineAsync(char value)
			{
				this.WriteLine(value);
				return Task.CompletedTask;
			}

			// Token: 0x06006B4B RID: 27467 RVA: 0x001734BE File Offset: 0x001716BE
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteLineAsync(string value)
			{
				this.WriteLine(value);
				return Task.CompletedTask;
			}

			// Token: 0x06006B4C RID: 27468 RVA: 0x001734CC File Offset: 0x001716CC
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task WriteLineAsync(char[] buffer, int index, int count)
			{
				this.WriteLine(buffer, index, count);
				return Task.CompletedTask;
			}

			// Token: 0x06006B4D RID: 27469 RVA: 0x001734DC File Offset: 0x001716DC
			[ComVisible(false)]
			[MethodImpl(MethodImplOptions.Synchronized)]
			public override Task FlushAsync()
			{
				this.Flush();
				return Task.CompletedTask;
			}

			// Token: 0x04003331 RID: 13105
			private TextWriter _out;
		}
	}
}
