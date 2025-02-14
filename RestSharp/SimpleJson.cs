﻿using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace RestSharp
{
	// Token: 0x0200002B RID: 43
	[NullableContext(1)]
	[Nullable(0)]
	[GeneratedCode("simple-json", "1.0.0")]
	public static class SimpleJson
	{
		// Token: 0x060003DA RID: 986 RVA: 0x000076D4 File Offset: 0x000058D4
		public static object DeserializeObject(string json)
		{
			object result;
			if (SimpleJson.TryDeserializeObject(json, out result))
			{
				return result;
			}
			throw new SerializationException("Invalid JSON string");
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000076F8 File Offset: 0x000058F8
		public static object DeserializeObject(char[] json)
		{
			object result;
			if (SimpleJson.TryDeserializeObject(json, out result))
			{
				return result;
			}
			throw new SerializationException("Invalid JSON string");
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000771C File Offset: 0x0000591C
		public static bool TryDeserializeObject(char[] json, out object obj)
		{
			bool result = true;
			if (json != null)
			{
				int num = 0;
				obj = SimpleJson.ParseValue(json, ref num, ref result);
			}
			else
			{
				obj = null;
			}
			return result;
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00007742 File Offset: 0x00005942
		public static bool TryDeserializeObject(string json, out object obj)
		{
			return SimpleJson.TryDeserializeObject(json.ToCharArray(), out obj);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00007750 File Offset: 0x00005950
		public static object DeserializeObject(string json, Type type, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			return SimpleJson.GetJsonObject(SimpleJson.DeserializeObject(json), type, jsonSerializerStrategy);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000775F File Offset: 0x0000595F
		public static object DeserializeObject(char[] json, Type type, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			return SimpleJson.GetJsonObject(SimpleJson.DeserializeObject(json), type, jsonSerializerStrategy);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000776E File Offset: 0x0000596E
		private static object GetJsonObject(object jsonObject, Type type, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			if (!(type == null) && (jsonObject == null || !ReflectionUtils.IsAssignableFrom(jsonObject.GetType(), type)))
			{
				return (jsonSerializerStrategy ?? SimpleJson.CurrentJsonSerializerStrategy).DeserializeObject(jsonObject, type);
			}
			return jsonObject;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000779D File Offset: 0x0000599D
		public static object DeserializeObject(string json, Type type)
		{
			return SimpleJson.DeserializeObject(json, type, null);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x000077A7 File Offset: 0x000059A7
		public static T DeserializeObject<[Nullable(2)] T>(string json, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			return (T)((object)SimpleJson.DeserializeObject(json, typeof(T), jsonSerializerStrategy));
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x000077BF File Offset: 0x000059BF
		public static T DeserializeObject<[Nullable(2)] T>(string json)
		{
			return (T)((object)SimpleJson.DeserializeObject(json, typeof(T), null));
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x000077D8 File Offset: 0x000059D8
		public static string SerializeObject(object json, IJsonSerializerStrategy jsonSerializerStrategy)
		{
			StringBuilder stringBuilder = new StringBuilder(2000);
			if (!SimpleJson.SerializeValue(jsonSerializerStrategy, json, stringBuilder))
			{
				return null;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00007802 File Offset: 0x00005A02
		public static string SerializeObject(object json)
		{
			return SimpleJson.SerializeObject(json, SimpleJson.CurrentJsonSerializerStrategy);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x00007810 File Offset: 0x00005A10
		public static string EscapeToJavascriptString(string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return jsonString;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			while (i < jsonString.Length)
			{
				char c = jsonString[i++];
				if (c == '\\')
				{
					if (jsonString.Length - i >= 2)
					{
						char c2 = jsonString[i];
						if (c2 == '\\')
						{
							stringBuilder.Append('\\');
							i++;
						}
						else if (c2 == '"')
						{
							stringBuilder.Append("\"");
							i++;
						}
						else if (c2 == 't')
						{
							stringBuilder.Append('\t');
							i++;
						}
						else if (c2 == 'b')
						{
							stringBuilder.Append('\b');
							i++;
						}
						else if (c2 == 'n')
						{
							stringBuilder.Append('\n');
							i++;
						}
						else if (c2 == 'r')
						{
							stringBuilder.Append('\r');
							i++;
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x000078F4 File Offset: 0x00005AF4
		private static IDictionary<string, object> ParseObject(char[] json, ref int index, ref bool success)
		{
			IDictionary<string, object> dictionary = new JsonObject();
			SimpleJson.NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				int num = SimpleJson.LookAhead(json, index);
				if (num == 0)
				{
					success = false;
					return null;
				}
				if (num == 6)
				{
					SimpleJson.NextToken(json, ref index);
				}
				else
				{
					if (num == 2)
					{
						SimpleJson.NextToken(json, ref index);
						return dictionary;
					}
					string key = SimpleJson.ParseString(json, ref index, ref success);
					if (!success)
					{
						success = false;
						return null;
					}
					num = SimpleJson.NextToken(json, ref index);
					if (num != 5)
					{
						success = false;
						return null;
					}
					object value = SimpleJson.ParseValue(json, ref index, ref success);
					if (!success)
					{
						success = false;
						return null;
					}
					dictionary[key] = value;
				}
			}
			return dictionary;
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00007984 File Offset: 0x00005B84
		private static JsonArray ParseArray(char[] json, ref int index, ref bool success)
		{
			JsonArray jsonArray = new JsonArray();
			SimpleJson.NextToken(json, ref index);
			bool flag = false;
			while (!flag)
			{
				int num = SimpleJson.LookAhead(json, index);
				if (num == 0)
				{
					success = false;
					return null;
				}
				if (num == 6)
				{
					SimpleJson.NextToken(json, ref index);
				}
				else
				{
					if (num == 4)
					{
						SimpleJson.NextToken(json, ref index);
						break;
					}
					object item = SimpleJson.ParseValue(json, ref index, ref success);
					if (!success)
					{
						return null;
					}
					jsonArray.Add(item);
				}
			}
			return jsonArray;
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x000079EC File Offset: 0x00005BEC
		private static object ParseValue(char[] json, ref int index, ref bool success)
		{
			switch (SimpleJson.LookAhead(json, index))
			{
			case 1:
				return SimpleJson.ParseObject(json, ref index, ref success);
			case 3:
				return SimpleJson.ParseArray(json, ref index, ref success);
			case 7:
				return SimpleJson.ParseString(json, ref index, ref success);
			case 8:
				return SimpleJson.ParseNumber(json, ref index, ref success);
			case 9:
				SimpleJson.NextToken(json, ref index);
				return true;
			case 10:
				SimpleJson.NextToken(json, ref index);
				return false;
			case 11:
				SimpleJson.NextToken(json, ref index);
				return null;
			}
			success = false;
			return null;
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00007A8C File Offset: 0x00005C8C
		private static string ParseString(char[] json, ref int index, ref bool success)
		{
			StringBuilder stringBuilder = new StringBuilder(2000);
			SimpleJson.EatWhitespace(json, ref index);
			int num = index;
			index = num + 1;
			char c = json[num];
			bool flag = false;
			while (!flag && index != json.Length)
			{
				num = index;
				index = num + 1;
				c = json[num];
				if (c == '"')
				{
					flag = true;
					break;
				}
				if (c == '\\')
				{
					if (index == json.Length)
					{
						break;
					}
					num = index;
					index = num + 1;
					c = json[num];
					if (c == '"')
					{
						stringBuilder.Append('"');
					}
					else if (c == '\\')
					{
						stringBuilder.Append('\\');
					}
					else if (c == '/')
					{
						stringBuilder.Append('/');
					}
					else if (c == 'b')
					{
						stringBuilder.Append('\b');
					}
					else if (c == 'f')
					{
						stringBuilder.Append('\f');
					}
					else if (c == 'n')
					{
						stringBuilder.Append('\n');
					}
					else if (c == 'r')
					{
						stringBuilder.Append('\r');
					}
					else if (c == 't')
					{
						stringBuilder.Append('\t');
					}
					else if (c == 'u')
					{
						if (json.Length - index < 4)
						{
							break;
						}
						uint num2;
						if (!(success = uint.TryParse(new string(json, index, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num2)))
						{
							return "";
						}
						if (55296U <= num2 && num2 <= 56319U)
						{
							index += 4;
							uint num3;
							if (json.Length - index < 6 || !(new string(json, index, 2) == "\\u") || !uint.TryParse(new string(json, index + 2, 4), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num3) || 56320U > num3 || num3 > 57343U)
							{
								success = false;
								return "";
							}
							stringBuilder.Append((char)num2);
							stringBuilder.Append((char)num3);
							index += 6;
						}
						else
						{
							stringBuilder.Append(SimpleJson.ConvertFromUtf32((int)num2));
							index += 4;
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (!flag)
			{
				success = false;
				return null;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00007C94 File Offset: 0x00005E94
		private static string ConvertFromUtf32(int utf32)
		{
			if (utf32 < 0 || utf32 > 1114111)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must be from 0 to 0x10FFFF.");
			}
			if (55296 <= utf32 && utf32 <= 57343)
			{
				throw new ArgumentOutOfRangeException("utf32", "The argument must not be in surrogate pair range.");
			}
			if (utf32 < 65536)
			{
				return new string((char)utf32, 1);
			}
			utf32 -= 65536;
			return new string(new char[]
			{
				(char)((utf32 >> 10) + 55296),
				(char)(utf32 % 1024 + 56320)
			});
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00007D24 File Offset: 0x00005F24
		private static object ParseNumber(char[] json, ref int index, ref bool success)
		{
			SimpleJson.EatWhitespace(json, ref index);
			int lastIndexOfNumber = SimpleJson.GetLastIndexOfNumber(json, index);
			int length = lastIndexOfNumber - index + 1;
			string text = new string(json, index, length);
			object result;
			if (text.IndexOf(".", StringComparison.OrdinalIgnoreCase) != -1 || text.IndexOf("e", StringComparison.OrdinalIgnoreCase) != -1)
			{
				double num;
				success = double.TryParse(new string(json, index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out num);
				result = num;
			}
			else
			{
				long num2;
				success = long.TryParse(new string(json, index, length), NumberStyles.Any, CultureInfo.InvariantCulture, out num2);
				result = num2;
			}
			index = lastIndexOfNumber + 1;
			return result;
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x00007DC0 File Offset: 0x00005FC0
		private static int GetLastIndexOfNumber(char[] json, int index)
		{
			int num = index;
			while (num < json.Length && "0123456789+-.eE".IndexOf(json[num]) != -1)
			{
				num++;
			}
			return num - 1;
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00007DEE File Offset: 0x00005FEE
		private static void EatWhitespace(char[] json, ref int index)
		{
			while (index < json.Length && " \t\n\r\b\f".IndexOf(json[index]) != -1)
			{
				index++;
			}
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00007E10 File Offset: 0x00006010
		private static int LookAhead(char[] json, int index)
		{
			int num = index;
			return SimpleJson.NextToken(json, ref num);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00007E28 File Offset: 0x00006028
		private static int NextToken(char[] json, ref int index)
		{
			SimpleJson.EatWhitespace(json, ref index);
			if (index == json.Length)
			{
				return 0;
			}
			char c = json[index];
			index++;
			if (c <= '[')
			{
				switch (c)
				{
				case '"':
					return 7;
				case '#':
				case '$':
				case '%':
				case '&':
				case '\'':
				case '(':
				case ')':
				case '*':
				case '+':
				case '.':
				case '/':
					break;
				case ',':
					return 6;
				case '-':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
					return 8;
				case ':':
					return 5;
				default:
					if (c == '[')
					{
						return 3;
					}
					break;
				}
			}
			else
			{
				if (c == ']')
				{
					return 4;
				}
				if (c == '{')
				{
					return 1;
				}
				if (c == '}')
				{
					return 2;
				}
			}
			index--;
			int num = json.Length - index;
			if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
			{
				index += 5;
				return 10;
			}
			if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
			{
				index += 4;
				return 9;
			}
			if (num >= 4 && json[index] == 'n' && json[index + 1] == 'u' && json[index + 2] == 'l' && json[index + 3] == 'l')
			{
				index += 4;
				return 11;
			}
			return 0;
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00007F9C File Offset: 0x0000619C
		private static bool SerializeValue(IJsonSerializerStrategy jsonSerializerStrategy, object value, StringBuilder builder)
		{
			bool flag = true;
			string text = value as string;
			if (text != null)
			{
				flag = SimpleJson.SerializeString(text, builder);
			}
			else
			{
				IDictionary<string, object> dictionary = value as IDictionary<string, object>;
				if (dictionary != null)
				{
					flag = SimpleJson.SerializeObject(jsonSerializerStrategy, dictionary.Keys, dictionary.Values, builder);
				}
				else
				{
					IDictionary<string, string> dictionary2 = value as IDictionary<string, string>;
					if (dictionary2 != null)
					{
						flag = SimpleJson.SerializeObject(jsonSerializerStrategy, dictionary2.Keys, dictionary2.Values, builder);
					}
					else
					{
						IEnumerable enumerable = value as IEnumerable;
						if (enumerable != null)
						{
							flag = SimpleJson.SerializeArray(jsonSerializerStrategy, enumerable, builder);
						}
						else if (SimpleJson.IsNumeric(value))
						{
							flag = SimpleJson.SerializeNumber(value, builder);
						}
						else if (value is bool)
						{
							builder.Append(((bool)value) ? "true" : "false");
						}
						else if (value == null)
						{
							builder.Append("null");
						}
						else
						{
							object value2;
							flag = jsonSerializerStrategy.TrySerializeNonPrimitiveObject(value, out value2);
							if (flag)
							{
								SimpleJson.SerializeValue(jsonSerializerStrategy, value2, builder);
							}
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00008080 File Offset: 0x00006280
		private static bool SerializeObject(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable keys, IEnumerable values, StringBuilder builder)
		{
			builder.Append("{");
			IEnumerator enumerator = keys.GetEnumerator();
			IEnumerator enumerator2 = values.GetEnumerator();
			bool flag = true;
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				object obj = enumerator.Current;
				object value = enumerator2.Current;
				if (!flag)
				{
					builder.Append(",");
				}
				string text = obj as string;
				if (text != null)
				{
					SimpleJson.SerializeString(text, builder);
				}
				else if (!SimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
				{
					return false;
				}
				builder.Append(":");
				if (!SimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
				{
					return false;
				}
				flag = false;
			}
			builder.Append("}");
			return true;
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x00008120 File Offset: 0x00006320
		private static bool SerializeArray(IJsonSerializerStrategy jsonSerializerStrategy, IEnumerable anArray, StringBuilder builder)
		{
			builder.Append("[");
			bool flag = true;
			foreach (object value in anArray)
			{
				if (!flag)
				{
					builder.Append(",");
				}
				if (!SimpleJson.SerializeValue(jsonSerializerStrategy, value, builder))
				{
					return false;
				}
				flag = false;
			}
			builder.Append("]");
			return true;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x000081A8 File Offset: 0x000063A8
		private static bool SerializeString(string aString, StringBuilder builder)
		{
			builder.Append("\"");
			foreach (char c in aString.ToCharArray())
			{
				if (c == '"')
				{
					builder.Append("\\\"");
				}
				else if (c == '\\')
				{
					builder.Append("\\\\");
				}
				else if (c == '\b')
				{
					builder.Append("\\b");
				}
				else if (c == '\f')
				{
					builder.Append("\\f");
				}
				else if (c == '\n')
				{
					builder.Append("\\n");
				}
				else if (c == '\r')
				{
					builder.Append("\\r");
				}
				else if (c == '\t')
				{
					builder.Append("\\t");
				}
				else
				{
					builder.Append(c);
				}
			}
			builder.Append("\"");
			return true;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000827C File Offset: 0x0000647C
		private static bool SerializeNumber(object number, StringBuilder builder)
		{
			if (number is long)
			{
				builder.Append(((long)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is ulong)
			{
				builder.Append(((ulong)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is int)
			{
				builder.Append(((int)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is uint)
			{
				builder.Append(((uint)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is decimal)
			{
				builder.Append(((decimal)number).ToString(CultureInfo.InvariantCulture));
			}
			else if (number is float)
			{
				builder.Append(((float)number).ToString(CultureInfo.InvariantCulture));
			}
			else
			{
				builder.Append(Convert.ToDouble(number, CultureInfo.InvariantCulture).ToString("r", CultureInfo.InvariantCulture));
			}
			return true;
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x00008394 File Offset: 0x00006594
		private static bool IsNumeric(object value)
		{
			return value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong || value is float || value is double || value is decimal;
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00008410 File Offset: 0x00006610
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x00008426 File Offset: 0x00006626
		public static IJsonSerializerStrategy CurrentJsonSerializerStrategy
		{
			get
			{
				IJsonSerializerStrategy result;
				if ((result = SimpleJson._currentJsonSerializerStrategy) == null)
				{
					result = (SimpleJson._currentJsonSerializerStrategy = SimpleJson.PocoJsonSerializerStrategy);
				}
				return result;
			}
			set
			{
				SimpleJson._currentJsonSerializerStrategy = value;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0000842E File Offset: 0x0000662E
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static PocoJsonSerializerStrategy PocoJsonSerializerStrategy
		{
			get
			{
				PocoJsonSerializerStrategy result;
				if ((result = SimpleJson._pocoJsonSerializerStrategy) == null)
				{
					result = (SimpleJson._pocoJsonSerializerStrategy = new PocoJsonSerializerStrategy());
				}
				return result;
			}
		}

		// Token: 0x040000E1 RID: 225
		private const int TOKEN_NONE = 0;

		// Token: 0x040000E2 RID: 226
		private const int TOKEN_CURLY_OPEN = 1;

		// Token: 0x040000E3 RID: 227
		private const int TOKEN_CURLY_CLOSE = 2;

		// Token: 0x040000E4 RID: 228
		private const int TOKEN_SQUARED_OPEN = 3;

		// Token: 0x040000E5 RID: 229
		private const int TOKEN_SQUARED_CLOSE = 4;

		// Token: 0x040000E6 RID: 230
		private const int TOKEN_COLON = 5;

		// Token: 0x040000E7 RID: 231
		private const int TOKEN_COMMA = 6;

		// Token: 0x040000E8 RID: 232
		private const int TOKEN_STRING = 7;

		// Token: 0x040000E9 RID: 233
		private const int TOKEN_NUMBER = 8;

		// Token: 0x040000EA RID: 234
		private const int TOKEN_TRUE = 9;

		// Token: 0x040000EB RID: 235
		private const int TOKEN_FALSE = 10;

		// Token: 0x040000EC RID: 236
		private const int TOKEN_NULL = 11;

		// Token: 0x040000ED RID: 237
		private const int BUILDER_CAPACITY = 2000;

		// Token: 0x040000EE RID: 238
		private static IJsonSerializerStrategy _currentJsonSerializerStrategy;

		// Token: 0x040000EF RID: 239
		private static PocoJsonSerializerStrategy _pocoJsonSerializerStrategy;
	}
}
