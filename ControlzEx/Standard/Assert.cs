using System;
using System.Diagnostics;
using System.Threading;

namespace ControlzEx.Standard
{
	// Token: 0x02000018 RID: 24
	[Obsolete("Use this element with caution and only if you know what you are doing. It's only meant to be used internally by MahApps.Metro and Fluent.Ribbon. Breaking changes might occur anytime without prior warning.")]
	public static class Assert
	{
		// Token: 0x06000118 RID: 280 RVA: 0x00007238 File Offset: 0x00005438
		private static void _Break()
		{
			Debugger.Break();
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000723F File Offset: 0x0000543F
		[Conditional("DEBUG")]
		public static void Evaluate(Assert.EvaluateFunction argument)
		{
			argument();
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007247 File Offset: 0x00005447
		[Obsolete("Use Assert.AreEqual instead of Assert.Equals", false)]
		[Conditional("DEBUG")]
		public static void Equals<T>(T expected, T actual)
		{
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000724C File Offset: 0x0000544C
		[Conditional("DEBUG")]
		public static void AreEqual<T>(T expected, T actual)
		{
			if (expected == null)
			{
				if (actual != null && !actual.Equals(expected))
				{
					Assert._Break();
					return;
				}
			}
			else if (!expected.Equals(actual))
			{
				Assert._Break();
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000072A0 File Offset: 0x000054A0
		[Conditional("DEBUG")]
		public static void LazyAreEqual<T>(Func<T> expectedResult, Func<T> actualResult)
		{
			T t = actualResult();
			T t2 = expectedResult();
			if (t2 == null)
			{
				if (t != null && !t.Equals(t2))
				{
					Assert._Break();
					return;
				}
			}
			else if (!t2.Equals(t))
			{
				Assert._Break();
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00007300 File Offset: 0x00005500
		[Conditional("DEBUG")]
		public static void AreNotEqual<T>(T notExpected, T actual)
		{
			if (notExpected == null)
			{
				if (actual == null || actual.Equals(notExpected))
				{
					Assert._Break();
					return;
				}
			}
			else if (notExpected.Equals(actual))
			{
				Assert._Break();
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00007352 File Offset: 0x00005552
		[Conditional("DEBUG")]
		public static void Implies(bool condition, bool result)
		{
			if (condition && !result)
			{
				Assert._Break();
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000735F File Offset: 0x0000555F
		[Conditional("DEBUG")]
		public static void Implies(bool condition, Assert.ImplicationFunction result)
		{
			if (condition && !result())
			{
				Assert._Break();
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00007247 File Offset: 0x00005447
		[Conditional("DEBUG")]
		public static void IsNeitherNullNorEmpty(string value)
		{
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00007371 File Offset: 0x00005571
		[Conditional("DEBUG")]
		public static void IsNeitherNullNorWhitespace(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				Assert._Break();
			}
			if (value.Trim().Length == 0)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00007392 File Offset: 0x00005592
		[Conditional("DEBUG")]
		public static void IsNotNull<T>(T value) where T : class
		{
			if (value == null)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000073A4 File Offset: 0x000055A4
		[Conditional("DEBUG")]
		public static void IsDefault<T>(T value) where T : struct
		{
			value.Equals(default(T));
		}

		// Token: 0x06000124 RID: 292 RVA: 0x000073D0 File Offset: 0x000055D0
		[Conditional("DEBUG")]
		public static void IsNotDefault<T>(T value) where T : struct
		{
			value.Equals(default(T));
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000073F9 File Offset: 0x000055F9
		[Conditional("DEBUG")]
		public static void IsFalse(bool condition)
		{
			if (condition)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000073F9 File Offset: 0x000055F9
		[Conditional("DEBUG")]
		public static void IsFalse(bool condition, string message)
		{
			if (condition)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00007403 File Offset: 0x00005603
		[Conditional("DEBUG")]
		public static void IsTrue(bool condition)
		{
			if (!condition)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000740D File Offset: 0x0000560D
		[Conditional("DEBUG")]
		public static void IsTrue<T>(Predicate<T> predicate, T arg)
		{
			if (!predicate(arg))
			{
				Assert._Break();
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00007403 File Offset: 0x00005603
		[Conditional("DEBUG")]
		public static void IsTrue(bool condition, string message)
		{
			if (!condition)
			{
				Assert._Break();
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000741D File Offset: 0x0000561D
		[Conditional("DEBUG")]
		public static void Fail()
		{
			Assert._Break();
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000741D File Offset: 0x0000561D
		[Conditional("DEBUG")]
		public static void Fail(string message)
		{
			Assert._Break();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00007424 File Offset: 0x00005624
		[Conditional("DEBUG")]
		public static void IsNull<T>(T item) where T : class
		{
			if (item != null)
			{
				Assert._Break();
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00007433 File Offset: 0x00005633
		[Conditional("DEBUG")]
		public static void BoundedDoubleInc(double lowerBoundInclusive, double value, double upperBoundInclusive)
		{
			if (value < lowerBoundInclusive || value > upperBoundInclusive)
			{
				Assert._Break();
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00007442 File Offset: 0x00005642
		[Conditional("DEBUG")]
		public static void BoundedInteger(int lowerBoundInclusive, int value, int upperBoundExclusive)
		{
			if (value < lowerBoundInclusive || value >= upperBoundExclusive)
			{
				Assert._Break();
			}
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00007451 File Offset: 0x00005651
		[Conditional("DEBUG")]
		public static void IsApartmentState(ApartmentState expectedState)
		{
			if (Thread.CurrentThread.GetApartmentState() != expectedState)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00007465 File Offset: 0x00005665
		[Conditional("DEBUG")]
		public static void NullableIsNotNull<T>(T? value) where T : struct
		{
			if (value == null)
			{
				Assert._Break();
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00007475 File Offset: 0x00005675
		[Conditional("DEBUG")]
		public static void NullableIsNull<T>(T? value) where T : struct
		{
			if (value != null)
			{
				Assert._Break();
			}
		}

		// Token: 0x020000CF RID: 207
		// (Invoke) Token: 0x0600043E RID: 1086
		public delegate void EvaluateFunction();

		// Token: 0x020000D0 RID: 208
		// (Invoke) Token: 0x06000442 RID: 1090
		public delegate bool ImplicationFunction();
	}
}
