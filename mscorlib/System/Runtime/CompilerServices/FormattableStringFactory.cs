using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008FA RID: 2298
	[__DynamicallyInvokable]
	public static class FormattableStringFactory
	{
		// Token: 0x06005E4A RID: 24138 RVA: 0x0014B406 File Offset: 0x00149606
		[__DynamicallyInvokable]
		public static FormattableString Create(string format, params object[] arguments)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			if (arguments == null)
			{
				throw new ArgumentNullException("arguments");
			}
			return new FormattableStringFactory.ConcreteFormattableString(format, arguments);
		}

		// Token: 0x02000C95 RID: 3221
		private sealed class ConcreteFormattableString : FormattableString
		{
			// Token: 0x0600710A RID: 28938 RVA: 0x00185258 File Offset: 0x00183458
			internal ConcreteFormattableString(string format, object[] arguments)
			{
				this._format = format;
				this._arguments = arguments;
			}

			// Token: 0x17001363 RID: 4963
			// (get) Token: 0x0600710B RID: 28939 RVA: 0x0018526E File Offset: 0x0018346E
			public override string Format
			{
				get
				{
					return this._format;
				}
			}

			// Token: 0x0600710C RID: 28940 RVA: 0x00185276 File Offset: 0x00183476
			public override object[] GetArguments()
			{
				return this._arguments;
			}

			// Token: 0x17001364 RID: 4964
			// (get) Token: 0x0600710D RID: 28941 RVA: 0x0018527E File Offset: 0x0018347E
			public override int ArgumentCount
			{
				get
				{
					return this._arguments.Length;
				}
			}

			// Token: 0x0600710E RID: 28942 RVA: 0x00185288 File Offset: 0x00183488
			public override object GetArgument(int index)
			{
				return this._arguments[index];
			}

			// Token: 0x0600710F RID: 28943 RVA: 0x00185292 File Offset: 0x00183492
			public override string ToString(IFormatProvider formatProvider)
			{
				return string.Format(formatProvider, this._format, this._arguments);
			}

			// Token: 0x0400384D RID: 14413
			private readonly string _format;

			// Token: 0x0400384E RID: 14414
			private readonly object[] _arguments;
		}
	}
}
