using System;
using System.Collections.Generic;

namespace System
{
	// Token: 0x02000003 RID: 3
	public static class ExceptionExtensions
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020A8 File Offset: 0x000002A8
		public static void RegisterFrameworkExceptionType(Type frameworkExceptionType)
		{
			if (frameworkExceptionType == null)
			{
				throw new ArgumentNullException("frameworkExceptionType");
			}
			if (!ExceptionExtensions.frameworkExceptionTypes.Contains(frameworkExceptionType))
			{
				ExceptionExtensions.frameworkExceptionTypes.Add(frameworkExceptionType);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020D6 File Offset: 0x000002D6
		public static bool IsFrameworkExceptionRegistered(Type frameworkExceptionType)
		{
			return ExceptionExtensions.frameworkExceptionTypes.Contains(frameworkExceptionType);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020E4 File Offset: 0x000002E4
		public static Exception GetRootException(this Exception exception)
		{
			Exception ex = exception;
			try
			{
				while (ex != null)
				{
					if (!ExceptionExtensions.IsFrameworkException(ex))
					{
						return ex;
					}
					ex = ex.InnerException;
				}
				ex = exception;
			}
			catch (Exception)
			{
				ex = exception;
			}
			return ex;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002124 File Offset: 0x00000324
		private static bool IsFrameworkException(Exception exception)
		{
			bool flag = ExceptionExtensions.frameworkExceptionTypes.Contains(exception.GetType());
			bool flag2 = false;
			if (exception.InnerException != null)
			{
				flag2 = ExceptionExtensions.frameworkExceptionTypes.Contains(exception.InnerException.GetType());
			}
			return flag || flag2;
		}

		// Token: 0x04000001 RID: 1
		private static List<Type> frameworkExceptionTypes = new List<Type>();
	}
}
