using System;
using System.Security;
using System.Threading;

namespace System.Runtime.Versioning
{
	// Token: 0x02000725 RID: 1829
	internal static class MultitargetingHelpers
	{
		// Token: 0x06005160 RID: 20832 RVA: 0x0011EF88 File Offset: 0x0011D188
		internal static string GetAssemblyQualifiedName(Type type, Func<Type, string> converter)
		{
			string text = null;
			if (type != null)
			{
				if (converter != null)
				{
					try
					{
						text = converter(type);
					}
					catch (Exception ex)
					{
						if (MultitargetingHelpers.IsSecurityOrCriticalException(ex))
						{
							throw;
						}
					}
				}
				if (text == null)
				{
					text = MultitargetingHelpers.defaultConverter(type);
				}
			}
			return text;
		}

		// Token: 0x06005161 RID: 20833 RVA: 0x0011EFDC File Offset: 0x0011D1DC
		private static bool IsCriticalException(Exception ex)
		{
			return ex is NullReferenceException || ex is StackOverflowException || ex is OutOfMemoryException || ex is ThreadAbortException || ex is IndexOutOfRangeException || ex is AccessViolationException;
		}

		// Token: 0x06005162 RID: 20834 RVA: 0x0011F011 File Offset: 0x0011D211
		private static bool IsSecurityOrCriticalException(Exception ex)
		{
			return ex is SecurityException || MultitargetingHelpers.IsCriticalException(ex);
		}

		// Token: 0x04002427 RID: 9255
		private static Func<Type, string> defaultConverter = (Type t) => t.AssemblyQualifiedName;
	}
}
