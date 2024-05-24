using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x020009A9 RID: 2473
	public struct OSPlatform : IEquatable<OSPlatform>
	{
		// Token: 0x17001118 RID: 4376
		// (get) Token: 0x060062F5 RID: 25333 RVA: 0x0015169C File Offset: 0x0014F89C
		public static OSPlatform Linux { get; } = new OSPlatform("LINUX");

		// Token: 0x17001119 RID: 4377
		// (get) Token: 0x060062F6 RID: 25334 RVA: 0x001516A3 File Offset: 0x0014F8A3
		public static OSPlatform OSX { get; } = new OSPlatform("OSX");

		// Token: 0x1700111A RID: 4378
		// (get) Token: 0x060062F7 RID: 25335 RVA: 0x001516AA File Offset: 0x0014F8AA
		public static OSPlatform Windows { get; } = new OSPlatform("WINDOWS");

		// Token: 0x060062F8 RID: 25336 RVA: 0x001516B1 File Offset: 0x0014F8B1
		private OSPlatform(string osPlatform)
		{
			if (osPlatform == null)
			{
				throw new ArgumentNullException("osPlatform");
			}
			if (osPlatform.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyValue"), "osPlatform");
			}
			this._osPlatform = osPlatform;
		}

		// Token: 0x060062F9 RID: 25337 RVA: 0x001516E5 File Offset: 0x0014F8E5
		public static OSPlatform Create(string osPlatform)
		{
			return new OSPlatform(osPlatform);
		}

		// Token: 0x060062FA RID: 25338 RVA: 0x001516ED File Offset: 0x0014F8ED
		public bool Equals(OSPlatform other)
		{
			return this.Equals(other._osPlatform);
		}

		// Token: 0x060062FB RID: 25339 RVA: 0x001516FB File Offset: 0x0014F8FB
		internal bool Equals(string other)
		{
			return string.Equals(this._osPlatform, other, StringComparison.Ordinal);
		}

		// Token: 0x060062FC RID: 25340 RVA: 0x0015170A File Offset: 0x0014F90A
		public override bool Equals(object obj)
		{
			return obj is OSPlatform && this.Equals((OSPlatform)obj);
		}

		// Token: 0x060062FD RID: 25341 RVA: 0x00151722 File Offset: 0x0014F922
		public override int GetHashCode()
		{
			if (this._osPlatform != null)
			{
				return this._osPlatform.GetHashCode();
			}
			return 0;
		}

		// Token: 0x060062FE RID: 25342 RVA: 0x00151739 File Offset: 0x0014F939
		public override string ToString()
		{
			return this._osPlatform ?? string.Empty;
		}

		// Token: 0x060062FF RID: 25343 RVA: 0x0015174A File Offset: 0x0014F94A
		public static bool operator ==(OSPlatform left, OSPlatform right)
		{
			return left.Equals(right);
		}

		// Token: 0x06006300 RID: 25344 RVA: 0x00151754 File Offset: 0x0014F954
		public static bool operator !=(OSPlatform left, OSPlatform right)
		{
			return !(left == right);
		}

		// Token: 0x04002CA3 RID: 11427
		private readonly string _osPlatform;
	}
}
