using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace ControlzEx.Standard
{
	// Token: 0x020000BF RID: 191
	internal static class Verify
	{
		// Token: 0x060003DA RID: 986 RVA: 0x0000B007 File Offset: 0x00009207
		[DebuggerStepThrough]
		public static void IsApartmentState(ApartmentState requiredState, string message)
		{
			if (Thread.CurrentThread.GetApartmentState() != requiredState)
			{
				throw new InvalidOperationException(message);
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000B01D File Offset: 0x0000921D
		[DebuggerStepThrough]
		public static void IsNeitherNullNorEmpty(string value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name, "The parameter can not be either null or empty.");
			}
			if ("" == value)
			{
				throw new ArgumentException("The parameter can not be either null or empty.", name);
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000B047 File Offset: 0x00009247
		[DebuggerStepThrough]
		public static void IsNeitherNullNorWhitespace(string value, string name)
		{
			if (value == null)
			{
				throw new ArgumentNullException(name, "The parameter can not be either null or empty or consist only of white space characters.");
			}
			if ("" == value.Trim())
			{
				throw new ArgumentException("The parameter can not be either null or empty or consist only of white space characters.", name);
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000B078 File Offset: 0x00009278
		[DebuggerStepThrough]
		public static void IsNotDefault<T>(T obj, string name) where T : struct
		{
			T t = default(T);
			if (t.Equals(obj))
			{
				throw new ArgumentException("The parameter must not be the default value.", name);
			}
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000B0B0 File Offset: 0x000092B0
		[DebuggerStepThrough]
		public static void IsNotNull<T>(T obj, string name) where T : class
		{
			if (obj == null)
			{
				throw new ArgumentNullException(name);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000B0C1 File Offset: 0x000092C1
		[DebuggerStepThrough]
		public static void IsNull<T>(T obj, string name) where T : class
		{
			if (obj != null)
			{
				throw new ArgumentException("The parameter must be null.", name);
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000B0D7 File Offset: 0x000092D7
		[DebuggerStepThrough]
		public static void PropertyIsNotNull<T>(T obj, string name) where T : class
		{
			if (obj == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The property {0} cannot be null at this time.", name));
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000B0F7 File Offset: 0x000092F7
		[DebuggerStepThrough]
		public static void PropertyIsNull<T>(T obj, string name) where T : class
		{
			if (obj != null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The property {0} must be null at this time.", name));
			}
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000B117 File Offset: 0x00009317
		[DebuggerStepThrough]
		public static void IsTrue(bool statement, string name, string message = null)
		{
			if (!statement)
			{
				throw new ArgumentException(message ?? "", name);
			}
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000B12D File Offset: 0x0000932D
		[DebuggerStepThrough]
		public static void IsFalse(bool statement, string name, string message = null)
		{
			if (statement)
			{
				throw new ArgumentException(message ?? "", name);
			}
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000B144 File Offset: 0x00009344
		[DebuggerStepThrough]
		public static void AreEqual<T>(T expected, T actual, string parameterName, string message)
		{
			if (expected == null)
			{
				if (actual != null && !actual.Equals(expected))
				{
					throw new ArgumentException(message, parameterName);
				}
			}
			else if (!expected.Equals(actual))
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000B19C File Offset: 0x0000939C
		[DebuggerStepThrough]
		public static void AreNotEqual<T>(T notExpected, T actual, string parameterName, string message)
		{
			if (notExpected == null)
			{
				if (actual == null || actual.Equals(notExpected))
				{
					throw new ArgumentException(message, parameterName);
				}
			}
			else if (notExpected.Equals(actual))
			{
				throw new ArgumentException(message, parameterName);
			}
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000B1F3 File Offset: 0x000093F3
		[DebuggerStepThrough]
		public static void UriIsAbsolute(Uri uri, string parameterName)
		{
			Verify.IsNotNull<Uri>(uri, parameterName);
			if (!uri.IsAbsoluteUri)
			{
				throw new ArgumentException("The URI must be absolute.", parameterName);
			}
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000B210 File Offset: 0x00009410
		[DebuggerStepThrough]
		public static void BoundedInteger(int lowerBoundInclusive, int value, int upperBoundExclusive, string parameterName)
		{
			if (value < lowerBoundInclusive || value >= upperBoundExclusive)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The integer value must be bounded with [{0}, {1})", lowerBoundInclusive, upperBoundExclusive), parameterName);
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000B23C File Offset: 0x0000943C
		[DebuggerStepThrough]
		public static void BoundedDoubleInc(double lowerBoundInclusive, double value, double upperBoundInclusive, string message, string parameter)
		{
			if (value < lowerBoundInclusive || value > upperBoundInclusive)
			{
				throw new ArgumentException(message, parameter);
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000B24F File Offset: 0x0000944F
		[DebuggerStepThrough]
		public static void TypeSupportsInterface(Type type, Type interfaceType, string parameterName)
		{
			Verify.IsNotNull<Type>(type, "type");
			Verify.IsNotNull<Type>(interfaceType, "interfaceType");
			if (type.GetInterface(interfaceType.Name) == null)
			{
				throw new ArgumentException("The type of this parameter does not support a required interface", parameterName);
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000B287 File Offset: 0x00009487
		[DebuggerStepThrough]
		public static void FileExists(string filePath, string parameterName)
		{
			Verify.IsNeitherNullNorEmpty(filePath, parameterName);
			if (!File.Exists(filePath))
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "No file exists at \"{0}\"", filePath), parameterName);
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000B2B0 File Offset: 0x000094B0
		[DebuggerStepThrough]
		internal static void ImplementsInterface(object parameter, Type interfaceType, string parameterName)
		{
			bool flag = false;
			Type[] interfaces = parameter.GetType().GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (interfaces[i] == interfaceType)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The parameter must implement interface {0}.", interfaceType.ToString()), parameterName);
			}
		}
	}
}
