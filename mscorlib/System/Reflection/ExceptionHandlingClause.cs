using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x02000611 RID: 1553
	[ComVisible(true)]
	public class ExceptionHandlingClause
	{
		// Token: 0x060047F6 RID: 18422 RVA: 0x00105D5F File Offset: 0x00103F5F
		protected ExceptionHandlingClause()
		{
		}

		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x060047F7 RID: 18423 RVA: 0x00105D67 File Offset: 0x00103F67
		public virtual ExceptionHandlingClauseOptions Flags
		{
			get
			{
				return this.m_flags;
			}
		}

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x060047F8 RID: 18424 RVA: 0x00105D6F File Offset: 0x00103F6F
		public virtual int TryOffset
		{
			get
			{
				return this.m_tryOffset;
			}
		}

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x060047F9 RID: 18425 RVA: 0x00105D77 File Offset: 0x00103F77
		public virtual int TryLength
		{
			get
			{
				return this.m_tryLength;
			}
		}

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x060047FA RID: 18426 RVA: 0x00105D7F File Offset: 0x00103F7F
		public virtual int HandlerOffset
		{
			get
			{
				return this.m_handlerOffset;
			}
		}

		// Token: 0x17000B1A RID: 2842
		// (get) Token: 0x060047FB RID: 18427 RVA: 0x00105D87 File Offset: 0x00103F87
		public virtual int HandlerLength
		{
			get
			{
				return this.m_handlerLength;
			}
		}

		// Token: 0x17000B1B RID: 2843
		// (get) Token: 0x060047FC RID: 18428 RVA: 0x00105D8F File Offset: 0x00103F8F
		public virtual int FilterOffset
		{
			get
			{
				if (this.m_flags != ExceptionHandlingClauseOptions.Filter)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_EHClauseNotFilter"));
				}
				return this.m_filterOffset;
			}
		}

		// Token: 0x17000B1C RID: 2844
		// (get) Token: 0x060047FD RID: 18429 RVA: 0x00105DB0 File Offset: 0x00103FB0
		public virtual Type CatchType
		{
			get
			{
				if (this.m_flags != ExceptionHandlingClauseOptions.Clause)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Arg_EHClauseNotClause"));
				}
				Type result = null;
				if (!MetadataToken.IsNullToken(this.m_catchMetadataToken))
				{
					Type declaringType = this.m_methodBody.m_methodBase.DeclaringType;
					Module module = (declaringType == null) ? this.m_methodBody.m_methodBase.Module : declaringType.Module;
					result = module.ResolveType(this.m_catchMetadataToken, (declaringType == null) ? null : declaringType.GetGenericArguments(), (this.m_methodBody.m_methodBase is MethodInfo) ? this.m_methodBody.m_methodBase.GetGenericArguments() : null);
				}
				return result;
			}
		}

		// Token: 0x060047FE RID: 18430 RVA: 0x00105E5C File Offset: 0x0010405C
		public override string ToString()
		{
			if (this.Flags == ExceptionHandlingClauseOptions.Clause)
			{
				return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}, CatchType={5}", new object[]
				{
					this.Flags,
					this.TryOffset,
					this.TryLength,
					this.HandlerOffset,
					this.HandlerLength,
					this.CatchType
				});
			}
			if (this.Flags == ExceptionHandlingClauseOptions.Filter)
			{
				return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}, FilterOffset={5}", new object[]
				{
					this.Flags,
					this.TryOffset,
					this.TryLength,
					this.HandlerOffset,
					this.HandlerLength,
					this.FilterOffset
				});
			}
			return string.Format(CultureInfo.CurrentUICulture, "Flags={0}, TryOffset={1}, TryLength={2}, HandlerOffset={3}, HandlerLength={4}", new object[]
			{
				this.Flags,
				this.TryOffset,
				this.TryLength,
				this.HandlerOffset,
				this.HandlerLength
			});
		}

		// Token: 0x04001DC7 RID: 7623
		private MethodBody m_methodBody;

		// Token: 0x04001DC8 RID: 7624
		private ExceptionHandlingClauseOptions m_flags;

		// Token: 0x04001DC9 RID: 7625
		private int m_tryOffset;

		// Token: 0x04001DCA RID: 7626
		private int m_tryLength;

		// Token: 0x04001DCB RID: 7627
		private int m_handlerOffset;

		// Token: 0x04001DCC RID: 7628
		private int m_handlerLength;

		// Token: 0x04001DCD RID: 7629
		private int m_catchMetadataToken;

		// Token: 0x04001DCE RID: 7630
		private int m_filterOffset;
	}
}
