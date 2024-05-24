﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
	// Token: 0x020001A5 RID: 421
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class StringWriter : TextWriter
	{
		// Token: 0x06001A18 RID: 6680 RVA: 0x000575EB File Offset: 0x000557EB
		[__DynamicallyInvokable]
		public StringWriter() : this(new StringBuilder(), CultureInfo.CurrentCulture)
		{
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x000575FD File Offset: 0x000557FD
		[__DynamicallyInvokable]
		public StringWriter(IFormatProvider formatProvider) : this(new StringBuilder(), formatProvider)
		{
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x0005760B File Offset: 0x0005580B
		[__DynamicallyInvokable]
		public StringWriter(StringBuilder sb) : this(sb, CultureInfo.CurrentCulture)
		{
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x00057619 File Offset: 0x00055819
		[__DynamicallyInvokable]
		public StringWriter(StringBuilder sb, IFormatProvider formatProvider) : base(formatProvider)
		{
			if (sb == null)
			{
				throw new ArgumentNullException("sb", Environment.GetResourceString("ArgumentNull_Buffer"));
			}
			this._sb = sb;
			this._isOpen = true;
		}

		// Token: 0x06001A1C RID: 6684 RVA: 0x00057648 File Offset: 0x00055848
		public override void Close()
		{
			this.Dispose(true);
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x00057651 File Offset: 0x00055851
		[__DynamicallyInvokable]
		protected override void Dispose(bool disposing)
		{
			this._isOpen = false;
			base.Dispose(disposing);
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06001A1E RID: 6686 RVA: 0x00057661 File Offset: 0x00055861
		[__DynamicallyInvokable]
		public override Encoding Encoding
		{
			[__DynamicallyInvokable]
			get
			{
				if (StringWriter.m_encoding == null)
				{
					StringWriter.m_encoding = new UnicodeEncoding(false, false);
				}
				return StringWriter.m_encoding;
			}
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x00057681 File Offset: 0x00055881
		[__DynamicallyInvokable]
		public virtual StringBuilder GetStringBuilder()
		{
			return this._sb;
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x00057689 File Offset: 0x00055889
		[__DynamicallyInvokable]
		public override void Write(char value)
		{
			if (!this._isOpen)
			{
				__Error.WriterClosed();
			}
			this._sb.Append(value);
		}

		// Token: 0x06001A21 RID: 6689 RVA: 0x000576A8 File Offset: 0x000558A8
		[__DynamicallyInvokable]
		public override void Write(char[] buffer, int index, int count)
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
			if (!this._isOpen)
			{
				__Error.WriterClosed();
			}
			this._sb.Append(buffer, index, count);
		}

		// Token: 0x06001A22 RID: 6690 RVA: 0x00057733 File Offset: 0x00055933
		[__DynamicallyInvokable]
		public override void Write(string value)
		{
			if (!this._isOpen)
			{
				__Error.WriterClosed();
			}
			if (value != null)
			{
				this._sb.Append(value);
			}
		}

		// Token: 0x06001A23 RID: 6691 RVA: 0x00057752 File Offset: 0x00055952
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(char value)
		{
			this.Write(value);
			return Task.CompletedTask;
		}

		// Token: 0x06001A24 RID: 6692 RVA: 0x00057760 File Offset: 0x00055960
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(string value)
		{
			this.Write(value);
			return Task.CompletedTask;
		}

		// Token: 0x06001A25 RID: 6693 RVA: 0x0005776E File Offset: 0x0005596E
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteAsync(char[] buffer, int index, int count)
		{
			this.Write(buffer, index, count);
			return Task.CompletedTask;
		}

		// Token: 0x06001A26 RID: 6694 RVA: 0x0005777E File Offset: 0x0005597E
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(char value)
		{
			this.WriteLine(value);
			return Task.CompletedTask;
		}

		// Token: 0x06001A27 RID: 6695 RVA: 0x0005778C File Offset: 0x0005598C
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(string value)
		{
			this.WriteLine(value);
			return Task.CompletedTask;
		}

		// Token: 0x06001A28 RID: 6696 RVA: 0x0005779A File Offset: 0x0005599A
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task WriteLineAsync(char[] buffer, int index, int count)
		{
			this.WriteLine(buffer, index, count);
			return Task.CompletedTask;
		}

		// Token: 0x06001A29 RID: 6697 RVA: 0x000577AA File Offset: 0x000559AA
		[ComVisible(false)]
		[__DynamicallyInvokable]
		[HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
		public override Task FlushAsync()
		{
			return Task.CompletedTask;
		}

		// Token: 0x06001A2A RID: 6698 RVA: 0x000577B1 File Offset: 0x000559B1
		[__DynamicallyInvokable]
		public override string ToString()
		{
			return this._sb.ToString();
		}

		// Token: 0x0400091F RID: 2335
		private static volatile UnicodeEncoding m_encoding;

		// Token: 0x04000920 RID: 2336
		private StringBuilder _sb;

		// Token: 0x04000921 RID: 2337
		private bool _isOpen;
	}
}
