using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200000E RID: 14
	public static class SearchConditionFactory
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00003478 File Offset: 0x00001678
		public static SearchCondition CreateLeafCondition(string propertyName, string value, SearchConditionOperation operation)
		{
			SearchCondition result;
			using (PropVariant propVariant = new PropVariant(value))
			{
				result = SearchConditionFactory.CreateLeafCondition(propertyName, propVariant, null, operation);
			}
			return result;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000034BC File Offset: 0x000016BC
		public static SearchCondition CreateLeafCondition(string propertyName, DateTime value, SearchConditionOperation operation)
		{
			SearchCondition result;
			using (PropVariant propVariant = new PropVariant(value))
			{
				result = SearchConditionFactory.CreateLeafCondition(propertyName, propVariant, "System.StructuredQuery.CustomProperty.DateTime", operation);
			}
			return result;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003504 File Offset: 0x00001704
		public static SearchCondition CreateLeafCondition(string propertyName, int value, SearchConditionOperation operation)
		{
			SearchCondition result;
			using (PropVariant propVariant = new PropVariant(value))
			{
				result = SearchConditionFactory.CreateLeafCondition(propertyName, propVariant, "System.StructuredQuery.CustomProperty.Integer", operation);
			}
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000354C File Offset: 0x0000174C
		public static SearchCondition CreateLeafCondition(string propertyName, bool value, SearchConditionOperation operation)
		{
			SearchCondition result;
			using (PropVariant propVariant = new PropVariant(value))
			{
				result = SearchConditionFactory.CreateLeafCondition(propertyName, propVariant, "System.StructuredQuery.CustomProperty.Boolean", operation);
			}
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003594 File Offset: 0x00001794
		public static SearchCondition CreateLeafCondition(string propertyName, double value, SearchConditionOperation operation)
		{
			SearchCondition result;
			using (PropVariant propVariant = new PropVariant(value))
			{
				result = SearchConditionFactory.CreateLeafCondition(propertyName, propVariant, "System.StructuredQuery.CustomProperty.FloatingPoint", operation);
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000035DC File Offset: 0x000017DC
		private static SearchCondition CreateLeafCondition(string propertyName, PropVariant propVar, string valueType, SearchConditionOperation operation)
		{
			IConditionFactory conditionFactory = null;
			SearchCondition result = null;
			try
			{
				conditionFactory = (IConditionFactory)new ConditionFactoryCoClass();
				ICondition nativeSearchCondition = null;
				if (string.IsNullOrEmpty(propertyName) || propertyName.ToUpperInvariant() == "SYSTEM.NULL")
				{
					propertyName = null;
				}
				HResult result2 = conditionFactory.MakeLeaf(propertyName, operation, valueType, propVar, null, null, null, false, out nativeSearchCondition);
				if (!CoreErrorHelper.Succeeded(result2))
				{
					throw new ShellException(result2);
				}
				result = new SearchCondition(nativeSearchCondition);
			}
			finally
			{
				if (conditionFactory != null)
				{
					Marshal.ReleaseComObject(conditionFactory);
				}
			}
			return result;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000368C File Offset: 0x0000188C
		public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, string value, SearchConditionOperation operation)
		{
			string text;
			PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out text);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, "propertyKey");
			}
			return SearchConditionFactory.CreateLeafCondition(text, value, operation);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000036D0 File Offset: 0x000018D0
		public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, DateTime value, SearchConditionOperation operation)
		{
			string text;
			PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out text);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, "propertyKey");
			}
			return SearchConditionFactory.CreateLeafCondition(text, value, operation);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003714 File Offset: 0x00001914
		public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, bool value, SearchConditionOperation operation)
		{
			string text;
			PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out text);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, "propertyKey");
			}
			return SearchConditionFactory.CreateLeafCondition(text, value, operation);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003758 File Offset: 0x00001958
		public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, double value, SearchConditionOperation operation)
		{
			string text;
			PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out text);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, "propertyKey");
			}
			return SearchConditionFactory.CreateLeafCondition(text, value, operation);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000379C File Offset: 0x0000199C
		public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, int value, SearchConditionOperation operation)
		{
			string text;
			PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out text);
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, "propertyKey");
			}
			return SearchConditionFactory.CreateLeafCondition(text, value, operation);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000037E0 File Offset: 0x000019E0
		public static SearchCondition CreateAndOrCondition(SearchConditionType conditionType, bool simplify, params SearchCondition[] conditionNodes)
		{
			IConditionFactory conditionFactory = (IConditionFactory)new ConditionFactoryCoClass();
			ICondition nativeSearchCondition = null;
			try
			{
				List<ICondition> list = new List<ICondition>();
				if (conditionNodes != null)
				{
					foreach (SearchCondition searchCondition in conditionNodes)
					{
						list.Add(searchCondition.NativeSearchCondition);
					}
				}
				IEnumUnknown peuSubs = new EnumUnknownClass(list.ToArray());
				HResult result = conditionFactory.MakeAndOr(conditionType, peuSubs, simplify, out nativeSearchCondition);
				if (!CoreErrorHelper.Succeeded(result))
				{
					throw new ShellException(result);
				}
			}
			finally
			{
				if (conditionFactory != null)
				{
					Marshal.ReleaseComObject(conditionFactory);
				}
			}
			return new SearchCondition(nativeSearchCondition);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000038A8 File Offset: 0x00001AA8
		public static SearchCondition CreateNotCondition(SearchCondition conditionToBeNegated, bool simplify)
		{
			if (conditionToBeNegated == null)
			{
				throw new ArgumentNullException("conditionToBeNegated");
			}
			IConditionFactory conditionFactory = (IConditionFactory)new ConditionFactoryCoClass();
			ICondition nativeSearchCondition;
			try
			{
				HResult result = conditionFactory.MakeNot(conditionToBeNegated.NativeSearchCondition, simplify, out nativeSearchCondition);
				if (!CoreErrorHelper.Succeeded(result))
				{
					throw new ShellException(result);
				}
			}
			finally
			{
				if (conditionFactory != null)
				{
					Marshal.ReleaseComObject(conditionFactory);
				}
			}
			return new SearchCondition(nativeSearchCondition);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00003934 File Offset: 0x00001B34
		public static SearchCondition ParseStructuredQuery(string query)
		{
			return SearchConditionFactory.ParseStructuredQuery(query, null);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003950 File Offset: 0x00001B50
		public static SearchCondition ParseStructuredQuery(string query, CultureInfo cultureInfo)
		{
			if (string.IsNullOrEmpty(query))
			{
				throw new ArgumentNullException("query");
			}
			IQueryParserManager queryParserManager = (IQueryParserManager)new QueryParserManagerCoClass();
			IQueryParser queryParser = null;
			IQuerySolution querySolution = null;
			ICondition nativeSearchCondition = null;
			IEntity entity = null;
			SearchCondition searchCondition = null;
			SearchCondition result2;
			try
			{
				Guid guid = new Guid("2EBDEE67-3505-43f8-9946-EA44ABC8E5B0");
				HResult result = queryParserManager.CreateLoadedParser("SystemIndex", (cultureInfo == null) ? 0 : ((ushort)cultureInfo.LCID), ref guid, out queryParser);
				if (!CoreErrorHelper.Succeeded(result))
				{
					throw new ShellException(result);
				}
				if (queryParser != null)
				{
					using (PropVariant propVariant = new PropVariant(true))
					{
						result = queryParser.SetOption(StructuredQuerySingleOption.NaturalSyntax, propVariant);
					}
					if (!CoreErrorHelper.Succeeded(result))
					{
						throw new ShellException(result);
					}
					result = queryParser.Parse(query, null, out querySolution);
					if (!CoreErrorHelper.Succeeded(result))
					{
						throw new ShellException(result);
					}
					if (querySolution != null)
					{
						result = querySolution.GetQuery(out nativeSearchCondition, out entity);
						if (!CoreErrorHelper.Succeeded(result))
						{
							throw new ShellException(result);
						}
					}
				}
				searchCondition = new SearchCondition(nativeSearchCondition);
				result2 = searchCondition;
			}
			catch
			{
				if (searchCondition != null)
				{
					searchCondition.Dispose();
				}
				throw;
			}
			finally
			{
				if (queryParserManager != null)
				{
					Marshal.ReleaseComObject(queryParserManager);
				}
				if (queryParser != null)
				{
					Marshal.ReleaseComObject(queryParser);
				}
				if (querySolution != null)
				{
					Marshal.ReleaseComObject(querySolution);
				}
				if (entity != null)
				{
					Marshal.ReleaseComObject(entity);
				}
			}
			return result2;
		}
	}
}
