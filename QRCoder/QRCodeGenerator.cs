using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QRCoder.Exceptions;

namespace QRCoder
{
	// Token: 0x02000017 RID: 23
	public class QRCodeGenerator : IDisposable
	{
		// Token: 0x06000064 RID: 100 RVA: 0x000049B6 File Offset: 0x00002BB6
		public QRCodeData CreateQrCode(PayloadGenerator.Payload payload)
		{
			return QRCodeGenerator.GenerateQrCode(payload);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000049BE File Offset: 0x00002BBE
		public QRCodeData CreateQrCode(PayloadGenerator.Payload payload, QRCodeGenerator.ECCLevel eccLevel)
		{
			return QRCodeGenerator.GenerateQrCode(payload, eccLevel);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000049C7 File Offset: 0x00002BC7
		public QRCodeData CreateQrCode(string plainText, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1)
		{
			return QRCodeGenerator.GenerateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000049D7 File Offset: 0x00002BD7
		public QRCodeData CreateQrCode(byte[] binaryData, QRCodeGenerator.ECCLevel eccLevel)
		{
			return QRCodeGenerator.GenerateQrCode(binaryData, eccLevel);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000049E0 File Offset: 0x00002BE0
		public static QRCodeData GenerateQrCode(PayloadGenerator.Payload payload)
		{
			return QRCodeGenerator.GenerateQrCode(payload.ToString(), payload.EccLevel, false, false, payload.EciMode, payload.Version);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004A01 File Offset: 0x00002C01
		public static QRCodeData GenerateQrCode(PayloadGenerator.Payload payload, QRCodeGenerator.ECCLevel eccLevel)
		{
			return QRCodeGenerator.GenerateQrCode(payload.ToString(), eccLevel, false, false, payload.EciMode, payload.Version);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004A20 File Offset: 0x00002C20
		public static QRCodeData GenerateQrCode(string plainText, QRCodeGenerator.ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, QRCodeGenerator.EciMode eciMode = QRCodeGenerator.EciMode.Default, int requestedVersion = -1)
		{
			QRCodeGenerator.EncodingMode encodingFromPlaintext = QRCodeGenerator.GetEncodingFromPlaintext(plainText, forceUtf8);
			string text = QRCodeGenerator.PlainTextToBinary(plainText, encodingFromPlaintext, eciMode, utf8BOM, forceUtf8);
			int dataLength = QRCodeGenerator.GetDataLength(encodingFromPlaintext, plainText, text, forceUtf8);
			int num = requestedVersion;
			if (num == -1)
			{
				num = QRCodeGenerator.GetVersion(dataLength + ((eciMode != QRCodeGenerator.EciMode.Default) ? 2 : 0), encodingFromPlaintext, eccLevel);
			}
			else if (QRCodeGenerator.GetVersion(dataLength + ((eciMode != QRCodeGenerator.EciMode.Default) ? 2 : 0), encodingFromPlaintext, eccLevel) > num)
			{
				int maxSizeByte = QRCodeGenerator.capacityTable[num - 1].Details.First((QRCodeGenerator.VersionInfoDetails x) => x.ErrorCorrectionLevel == eccLevel).CapacityDict[encodingFromPlaintext];
				throw new DataTooLongException(eccLevel.ToString(), encodingFromPlaintext.ToString(), num, maxSizeByte);
			}
			string str = string.Empty;
			if (eciMode != QRCodeGenerator.EciMode.Default)
			{
				str = QRCodeGenerator.DecToBin(7, 4);
				str += QRCodeGenerator.DecToBin((int)eciMode, 8);
			}
			str += QRCodeGenerator.DecToBin((int)encodingFromPlaintext, 4);
			string str2 = QRCodeGenerator.DecToBin(dataLength, QRCodeGenerator.GetCountIndicatorLength(num, encodingFromPlaintext));
			return QRCodeGenerator.GenerateQrCode(str + str2 + text, eccLevel, num);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004B58 File Offset: 0x00002D58
		public static QRCodeData GenerateQrCode(byte[] binaryData, QRCodeGenerator.ECCLevel eccLevel)
		{
			int version = QRCodeGenerator.GetVersion(binaryData.Length, QRCodeGenerator.EncodingMode.Byte, eccLevel);
			string str = QRCodeGenerator.DecToBin(4, 4);
			string str2 = QRCodeGenerator.DecToBin(binaryData.Length, QRCodeGenerator.GetCountIndicatorLength(version, QRCodeGenerator.EncodingMode.Byte));
			string text = str + str2;
			foreach (byte decNum in binaryData)
			{
				text += QRCodeGenerator.DecToBin((int)decNum, 8);
			}
			return QRCodeGenerator.GenerateQrCode(text, eccLevel, version);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004BC0 File Offset: 0x00002DC0
		private static QRCodeData GenerateQrCode(string bitString, QRCodeGenerator.ECCLevel eccLevel, int version)
		{
			QRCodeGenerator.ECCInfo eccInfo = QRCodeGenerator.capacityECCTable.Single((QRCodeGenerator.ECCInfo x) => x.Version == version && x.ErrorCorrectionLevel == eccLevel);
			int num = eccInfo.TotalDataCodewords * 8;
			int num2 = num - bitString.Length;
			if (num2 > 0)
			{
				bitString += new string('0', Math.Min(num2, 4));
			}
			if (bitString.Length % 8 != 0)
			{
				bitString += new string('0', 8 - bitString.Length % 8);
			}
			while (bitString.Length < num)
			{
				bitString += "1110110000010001";
			}
			if (bitString.Length > num)
			{
				bitString = bitString.Substring(0, num);
			}
			List<QRCodeGenerator.CodewordBlock> list = new List<QRCodeGenerator.CodewordBlock>(eccInfo.BlocksInGroup1 + eccInfo.BlocksInGroup2);
			for (int i = 0; i < eccInfo.BlocksInGroup1; i++)
			{
				string bitString2 = bitString.Substring(i * eccInfo.CodewordsInGroup1 * 8, eccInfo.CodewordsInGroup1 * 8);
				List<string> list2 = QRCodeGenerator.BinaryStringToBitBlockList(bitString2);
				List<int> codeWordsInt = QRCodeGenerator.BinaryStringListToDecList(list2);
				List<string> list3 = QRCodeGenerator.CalculateECCWords(bitString2, eccInfo);
				List<int> eccWordsInt = QRCodeGenerator.BinaryStringListToDecList(list3);
				list.Add(new QRCodeGenerator.CodewordBlock(1, i + 1, bitString2, list2, list3, codeWordsInt, eccWordsInt));
			}
			bitString = bitString.Substring(eccInfo.BlocksInGroup1 * eccInfo.CodewordsInGroup1 * 8);
			for (int j = 0; j < eccInfo.BlocksInGroup2; j++)
			{
				string bitString3 = bitString.Substring(j * eccInfo.CodewordsInGroup2 * 8, eccInfo.CodewordsInGroup2 * 8);
				List<string> list4 = QRCodeGenerator.BinaryStringToBitBlockList(bitString3);
				List<int> codeWordsInt2 = QRCodeGenerator.BinaryStringListToDecList(list4);
				List<string> list5 = QRCodeGenerator.CalculateECCWords(bitString3, eccInfo);
				List<int> eccWordsInt2 = QRCodeGenerator.BinaryStringListToDecList(list5);
				list.Add(new QRCodeGenerator.CodewordBlock(2, j + 1, bitString3, list4, list5, codeWordsInt2, eccWordsInt2));
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int k = 0; k < Math.Max(eccInfo.CodewordsInGroup1, eccInfo.CodewordsInGroup2); k++)
			{
				foreach (QRCodeGenerator.CodewordBlock codewordBlock in list)
				{
					if (codewordBlock.CodeWords.Count > k)
					{
						stringBuilder.Append(codewordBlock.CodeWords[k]);
					}
				}
			}
			for (int l = 0; l < eccInfo.ECCPerBlock; l++)
			{
				foreach (QRCodeGenerator.CodewordBlock codewordBlock2 in list)
				{
					if (codewordBlock2.ECCWords.Count > l)
					{
						stringBuilder.Append(codewordBlock2.ECCWords[l]);
					}
				}
			}
			stringBuilder.Append(new string('0', QRCodeGenerator.remainderBits[version - 1]));
			string data = stringBuilder.ToString();
			QRCodeData qrcodeData = new QRCodeData(version);
			List<QRCodeGenerator.Rectangle> list6 = new List<QRCodeGenerator.Rectangle>();
			QRCodeGenerator.ModulePlacer.PlaceFinderPatterns(ref qrcodeData, ref list6);
			QRCodeGenerator.ModulePlacer.ReserveSeperatorAreas(qrcodeData.ModuleMatrix.Count, ref list6);
			QRCodeGenerator.ModulePlacer.PlaceAlignmentPatterns(ref qrcodeData, (from x in QRCodeGenerator.alignmentPatternTable
			where x.Version == version
			select x.PatternPositions).First<List<QRCodeGenerator.Point>>(), ref list6);
			QRCodeGenerator.ModulePlacer.PlaceTimingPatterns(ref qrcodeData, ref list6);
			QRCodeGenerator.ModulePlacer.PlaceDarkModule(ref qrcodeData, version, ref list6);
			QRCodeGenerator.ModulePlacer.ReserveVersionAreas(qrcodeData.ModuleMatrix.Count, version, ref list6);
			QRCodeGenerator.ModulePlacer.PlaceDataWords(ref qrcodeData, data, ref list6);
			int maskVersion = QRCodeGenerator.ModulePlacer.MaskCode(ref qrcodeData, version, ref list6, eccLevel);
			string formatString = QRCodeGenerator.GetFormatString(eccLevel, maskVersion);
			QRCodeGenerator.ModulePlacer.PlaceFormat(ref qrcodeData, formatString);
			if (version >= 7)
			{
				string versionString = QRCodeGenerator.GetVersionString(version);
				QRCodeGenerator.ModulePlacer.PlaceVersion(ref qrcodeData, versionString);
			}
			QRCodeGenerator.ModulePlacer.AddQuietZone(ref qrcodeData);
			return qrcodeData;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004FBC File Offset: 0x000031BC
		private static string GetFormatString(QRCodeGenerator.ECCLevel level, int maskVersion)
		{
			string text = "10100110111";
			string text2 = "101010000010010";
			string text3 = (level == QRCodeGenerator.ECCLevel.L) ? "01" : ((level == QRCodeGenerator.ECCLevel.M) ? "00" : ((level == QRCodeGenerator.ECCLevel.Q) ? "11" : "10"));
			text3 += QRCodeGenerator.DecToBin(maskVersion, 3);
			string text4 = text3.PadRight(15, '0').TrimStart(new char[]
			{
				'0'
			});
			while (text4.Length > 10)
			{
				StringBuilder stringBuilder = new StringBuilder();
				text = text.PadRight(text4.Length, '0');
				for (int i = 0; i < text4.Length; i++)
				{
					stringBuilder.Append((Convert.ToInt32(text4[i]) ^ Convert.ToInt32(text[i])).ToString());
				}
				text4 = stringBuilder.ToString().TrimStart(new char[]
				{
					'0'
				});
			}
			text4 = text4.PadLeft(10, '0');
			text3 += text4;
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int j = 0; j < text3.Length; j++)
			{
				stringBuilder2.Append((Convert.ToInt32(text3[j]) ^ Convert.ToInt32(text2[j])).ToString());
			}
			return stringBuilder2.ToString();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005104 File Offset: 0x00003304
		private static string GetVersionString(int version)
		{
			string text = "1111100100101";
			string text2 = QRCodeGenerator.DecToBin(version, 6);
			string text3 = text2.PadRight(18, '0').TrimStart(new char[]
			{
				'0'
			});
			while (text3.Length > 12)
			{
				StringBuilder stringBuilder = new StringBuilder();
				text = text.PadRight(text3.Length, '0');
				for (int i = 0; i < text3.Length; i++)
				{
					stringBuilder.Append((Convert.ToInt32(text3[i]) ^ Convert.ToInt32(text[i])).ToString());
				}
				text3 = stringBuilder.ToString().TrimStart(new char[]
				{
					'0'
				});
			}
			text3 = text3.PadLeft(12, '0');
			return text2 + text3;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000051C8 File Offset: 0x000033C8
		private static List<string> CalculateECCWords(string bitString, QRCodeGenerator.ECCInfo eccInfo)
		{
			int eccperBlock = eccInfo.ECCPerBlock;
			QRCodeGenerator.Polynom polynom = QRCodeGenerator.CalculateMessagePolynom(bitString);
			QRCodeGenerator.Polynom polynom2 = QRCodeGenerator.CalculateGeneratorPolynom(eccperBlock);
			for (int i = 0; i < polynom.PolyItems.Count; i++)
			{
				polynom.PolyItems[i] = new QRCodeGenerator.PolynomItem(polynom.PolyItems[i].Coefficient, polynom.PolyItems[i].Exponent + eccperBlock);
			}
			for (int j = 0; j < polynom2.PolyItems.Count; j++)
			{
				polynom2.PolyItems[j] = new QRCodeGenerator.PolynomItem(polynom2.PolyItems[j].Coefficient, polynom2.PolyItems[j].Exponent + (polynom.PolyItems.Count - 1));
			}
			QRCodeGenerator.Polynom polynom3 = polynom;
			int num = 0;
			while (polynom3.PolyItems.Count > 0 && polynom3.PolyItems[polynom3.PolyItems.Count - 1].Exponent > 0)
			{
				if (polynom3.PolyItems[0].Coefficient == 0)
				{
					polynom3.PolyItems.RemoveAt(0);
					polynom3.PolyItems.Add(new QRCodeGenerator.PolynomItem(0, polynom3.PolyItems[polynom3.PolyItems.Count - 1].Exponent - 1));
				}
				else
				{
					QRCodeGenerator.Polynom polynom4 = QRCodeGenerator.MultiplyGeneratorPolynomByLeadterm(polynom2, QRCodeGenerator.ConvertToAlphaNotation(polynom3).PolyItems[0], num);
					polynom4 = QRCodeGenerator.ConvertToDecNotation(polynom4);
					polynom4 = QRCodeGenerator.XORPolynoms(polynom3, polynom4);
					polynom3 = polynom4;
				}
				num++;
			}
			return (from x in polynom3.PolyItems
			select QRCodeGenerator.DecToBin(x.Coefficient, 8)).ToList<string>();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000053AC File Offset: 0x000035AC
		private static QRCodeGenerator.Polynom ConvertToAlphaNotation(QRCodeGenerator.Polynom poly)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			for (int i = 0; i < poly.PolyItems.Count; i++)
			{
				polynom.PolyItems.Add(new QRCodeGenerator.PolynomItem((poly.PolyItems[i].Coefficient != 0) ? QRCodeGenerator.GetAlphaExpFromIntVal(poly.PolyItems[i].Coefficient) : 0, poly.PolyItems[i].Exponent));
			}
			return polynom;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000542C File Offset: 0x0000362C
		private static QRCodeGenerator.Polynom ConvertToDecNotation(QRCodeGenerator.Polynom poly)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			for (int i = 0; i < poly.PolyItems.Count; i++)
			{
				polynom.PolyItems.Add(new QRCodeGenerator.PolynomItem(QRCodeGenerator.GetIntValFromAlphaExp(poly.PolyItems[i].Coefficient), poly.PolyItems[i].Exponent));
			}
			return polynom;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00005494 File Offset: 0x00003694
		private static int GetVersion(int length, QRCodeGenerator.EncodingMode encMode, QRCodeGenerator.ECCLevel eccLevel)
		{
			Func<QRCodeGenerator.VersionInfoDetails, bool> <>9__5;
			Func<QRCodeGenerator.VersionInfoDetails, bool> <>9__6;
			var source = QRCodeGenerator.capacityTable.Where(delegate(QRCodeGenerator.VersionInfo x)
			{
				IEnumerable<QRCodeGenerator.VersionInfoDetails> details = x.Details;
				Func<QRCodeGenerator.VersionInfoDetails, bool> predicate;
				if ((predicate = <>9__5) == null)
				{
					predicate = (<>9__5 = ((QRCodeGenerator.VersionInfoDetails y) => y.ErrorCorrectionLevel == eccLevel && y.CapacityDict[encMode] >= Convert.ToInt32(length)));
				}
				return details.Any(predicate);
			}).Select(delegate(QRCodeGenerator.VersionInfo x)
			{
				int version = x.Version;
				IEnumerable<QRCodeGenerator.VersionInfoDetails> details = x.Details;
				Func<QRCodeGenerator.VersionInfoDetails, bool> predicate;
				if ((predicate = <>9__6) == null)
				{
					predicate = (<>9__6 = ((QRCodeGenerator.VersionInfoDetails y) => y.ErrorCorrectionLevel == eccLevel));
				}
				return new
				{
					version = version,
					capacity = details.Single(predicate).CapacityDict[encMode]
				};
			});
			if (source.Any())
			{
				return source.Min(x => x.version);
			}
			Func<QRCodeGenerator.VersionInfoDetails, bool> <>9__7;
			Func<QRCodeGenerator.VersionInfoDetails, bool> <>9__8;
			int maxSizeByte = QRCodeGenerator.capacityTable.Where(delegate(QRCodeGenerator.VersionInfo x)
			{
				IEnumerable<QRCodeGenerator.VersionInfoDetails> details = x.Details;
				Func<QRCodeGenerator.VersionInfoDetails, bool> predicate;
				if ((predicate = <>9__7) == null)
				{
					predicate = (<>9__7 = ((QRCodeGenerator.VersionInfoDetails y) => y.ErrorCorrectionLevel == eccLevel));
				}
				return details.Any(predicate);
			}).Max(delegate(QRCodeGenerator.VersionInfo x)
			{
				IEnumerable<QRCodeGenerator.VersionInfoDetails> details = x.Details;
				Func<QRCodeGenerator.VersionInfoDetails, bool> predicate;
				if ((predicate = <>9__8) == null)
				{
					predicate = (<>9__8 = ((QRCodeGenerator.VersionInfoDetails y) => y.ErrorCorrectionLevel == eccLevel));
				}
				return details.Single(predicate).CapacityDict[encMode];
			});
			throw new DataTooLongException(eccLevel.ToString(), encMode.ToString(), maxSizeByte);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00005564 File Offset: 0x00003764
		private static QRCodeGenerator.EncodingMode GetEncodingFromPlaintext(string plainText, bool forceUtf8)
		{
			if (forceUtf8)
			{
				return QRCodeGenerator.EncodingMode.Byte;
			}
			QRCodeGenerator.EncodingMode result = QRCodeGenerator.EncodingMode.Numeric;
			foreach (char c in plainText)
			{
				if (!QRCodeGenerator.IsInRange(c, '0', '9'))
				{
					result = QRCodeGenerator.EncodingMode.Alphanumeric;
					if (!QRCodeGenerator.IsInRange(c, 'A', 'Z') && !QRCodeGenerator.alphanumEncTable.Contains(c))
					{
						return QRCodeGenerator.EncodingMode.Byte;
					}
				}
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000055BD File Offset: 0x000037BD
		private static bool IsInRange(char c, char min, char max)
		{
			return c - min <= max - min;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000055CC File Offset: 0x000037CC
		private static QRCodeGenerator.Polynom CalculateMessagePolynom(string bitString)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			for (int i = bitString.Length / 8 - 1; i >= 0; i--)
			{
				polynom.PolyItems.Add(new QRCodeGenerator.PolynomItem(QRCodeGenerator.BinToDec(bitString.Substring(0, 8)), i));
				bitString = bitString.Remove(0, 8);
			}
			return polynom;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00005620 File Offset: 0x00003820
		private static QRCodeGenerator.Polynom CalculateGeneratorPolynom(int numEccWords)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			polynom.PolyItems.AddRange(new QRCodeGenerator.PolynomItem[]
			{
				new QRCodeGenerator.PolynomItem(0, 1),
				new QRCodeGenerator.PolynomItem(0, 0)
			});
			for (int i = 1; i <= numEccWords - 1; i++)
			{
				QRCodeGenerator.Polynom polynom2 = new QRCodeGenerator.Polynom();
				polynom2.PolyItems.AddRange(new QRCodeGenerator.PolynomItem[]
				{
					new QRCodeGenerator.PolynomItem(0, 1),
					new QRCodeGenerator.PolynomItem(i, 0)
				});
				polynom = QRCodeGenerator.MultiplyAlphaPolynoms(polynom, polynom2);
			}
			return polynom;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000056AC File Offset: 0x000038AC
		private static List<string> BinaryStringToBitBlockList(string bitString)
		{
			List<string> list = new List<string>((int)Math.Ceiling((double)bitString.Length / 8.0));
			for (int i = 0; i < bitString.Length; i += 8)
			{
				list.Add(bitString.Substring(i, 8));
			}
			return list;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000056F6 File Offset: 0x000038F6
		private static List<int> BinaryStringListToDecList(List<string> binaryStringList)
		{
			return (from binaryString in binaryStringList
			select QRCodeGenerator.BinToDec(binaryString)).ToList<int>();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005722 File Offset: 0x00003922
		private static int BinToDec(string binStr)
		{
			return Convert.ToInt32(binStr, 2);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000572B File Offset: 0x0000392B
		private static string DecToBin(int decNum)
		{
			return Convert.ToString(decNum, 2);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00005734 File Offset: 0x00003934
		private static string DecToBin(int decNum, int padLeftUpTo)
		{
			return QRCodeGenerator.DecToBin(decNum).PadLeft(padLeftUpTo, '0');
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00005744 File Offset: 0x00003944
		private static int GetCountIndicatorLength(int version, QRCodeGenerator.EncodingMode encMode)
		{
			if (version < 10)
			{
				if (encMode == QRCodeGenerator.EncodingMode.Numeric)
				{
					return 10;
				}
				if (encMode == QRCodeGenerator.EncodingMode.Alphanumeric)
				{
					return 9;
				}
				return 8;
			}
			else if (version < 27)
			{
				if (encMode == QRCodeGenerator.EncodingMode.Numeric)
				{
					return 12;
				}
				if (encMode == QRCodeGenerator.EncodingMode.Alphanumeric)
				{
					return 11;
				}
				if (encMode == QRCodeGenerator.EncodingMode.Byte)
				{
					return 16;
				}
				return 10;
			}
			else
			{
				if (encMode == QRCodeGenerator.EncodingMode.Numeric)
				{
					return 14;
				}
				if (encMode == QRCodeGenerator.EncodingMode.Alphanumeric)
				{
					return 13;
				}
				if (encMode == QRCodeGenerator.EncodingMode.Byte)
				{
					return 16;
				}
				return 12;
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000579A File Offset: 0x0000399A
		private static int GetDataLength(QRCodeGenerator.EncodingMode encoding, string plainText, string codedText, bool forceUtf8)
		{
			if (!forceUtf8 && !QRCodeGenerator.IsUtf8(encoding, plainText, forceUtf8))
			{
				return plainText.Length;
			}
			return codedText.Length / 8;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000057B8 File Offset: 0x000039B8
		private static bool IsUtf8(QRCodeGenerator.EncodingMode encoding, string plainText, bool forceUtf8)
		{
			return encoding == QRCodeGenerator.EncodingMode.Byte && (!QRCodeGenerator.IsValidISO(plainText) || forceUtf8);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000057CC File Offset: 0x000039CC
		private static bool IsValidISO(string input)
		{
			byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(input);
			string @string = Encoding.GetEncoding("ISO-8859-1").GetString(bytes, 0, bytes.Length);
			return string.Equals(input, @string);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005808 File Offset: 0x00003A08
		private static string PlainTextToBinary(string plainText, QRCodeGenerator.EncodingMode encMode, QRCodeGenerator.EciMode eciMode, bool utf8BOM, bool forceUtf8)
		{
			switch (encMode)
			{
			case QRCodeGenerator.EncodingMode.Numeric:
				return QRCodeGenerator.PlainTextToBinaryNumeric(plainText);
			case QRCodeGenerator.EncodingMode.Alphanumeric:
				return QRCodeGenerator.PlainTextToBinaryAlphanumeric(plainText);
			case QRCodeGenerator.EncodingMode.Byte:
				return QRCodeGenerator.PlainTextToBinaryByte(plainText, eciMode, utf8BOM, forceUtf8);
			case QRCodeGenerator.EncodingMode.Kanji:
				return string.Empty;
			}
			return string.Empty;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005864 File Offset: 0x00003A64
		private static string PlainTextToBinaryNumeric(string plainText)
		{
			string text = string.Empty;
			while (plainText.Length >= 3)
			{
				int decNum = Convert.ToInt32(plainText.Substring(0, 3));
				text += QRCodeGenerator.DecToBin(decNum, 10);
				plainText = plainText.Substring(3);
			}
			if (plainText.Length == 2)
			{
				int decNum2 = Convert.ToInt32(plainText);
				text += QRCodeGenerator.DecToBin(decNum2, 7);
			}
			else if (plainText.Length == 1)
			{
				int decNum3 = Convert.ToInt32(plainText);
				text += QRCodeGenerator.DecToBin(decNum3, 4);
			}
			return text;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000058E8 File Offset: 0x00003AE8
		private static string PlainTextToBinaryAlphanumeric(string plainText)
		{
			string text = string.Empty;
			while (plainText.Length >= 2)
			{
				string text2 = plainText.Substring(0, 2);
				int decNum = QRCodeGenerator.alphanumEncDict[text2[0]] * 45 + QRCodeGenerator.alphanumEncDict[text2[1]];
				text += QRCodeGenerator.DecToBin(decNum, 11);
				plainText = plainText.Substring(2);
			}
			if (plainText.Length > 0)
			{
				text += QRCodeGenerator.DecToBin(QRCodeGenerator.alphanumEncDict[plainText[0]], 6);
			}
			return text;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005978 File Offset: 0x00003B78
		private string PlainTextToBinaryECI(string plainText)
		{
			string text = string.Empty;
			foreach (byte decNum in Encoding.GetEncoding("ascii").GetBytes(plainText))
			{
				text += QRCodeGenerator.DecToBin((int)decNum, 8);
			}
			return text;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000059C0 File Offset: 0x00003BC0
		private static string ConvertToIso8859(string value, string Iso = "ISO-8859-2")
		{
			Encoding encoding = Encoding.GetEncoding(Iso);
			Encoding utf = Encoding.UTF8;
			byte[] bytes = utf.GetBytes(value);
			byte[] bytes2 = Encoding.Convert(utf, encoding, bytes);
			return encoding.GetString(bytes2);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000059F0 File Offset: 0x00003BF0
		private static string PlainTextToBinaryByte(string plainText, QRCodeGenerator.EciMode eciMode, bool utf8BOM, bool forceUtf8)
		{
			string text = string.Empty;
			byte[] array;
			if (QRCodeGenerator.IsValidISO(plainText) && !forceUtf8)
			{
				array = Encoding.GetEncoding("ISO-8859-1").GetBytes(plainText);
			}
			else
			{
				switch (eciMode)
				{
				case QRCodeGenerator.EciMode.Default:
				case (QRCodeGenerator.EciMode)1:
				case (QRCodeGenerator.EciMode)2:
					break;
				case QRCodeGenerator.EciMode.Iso8859_1:
					array = Encoding.GetEncoding("ISO-8859-1").GetBytes(QRCodeGenerator.ConvertToIso8859(plainText, "ISO-8859-1"));
					goto IL_B2;
				case QRCodeGenerator.EciMode.Iso8859_2:
					array = Encoding.GetEncoding("ISO-8859-2").GetBytes(QRCodeGenerator.ConvertToIso8859(plainText, "ISO-8859-2"));
					goto IL_B2;
				default:
					if (eciMode != QRCodeGenerator.EciMode.Utf8)
					{
					}
					break;
				}
				array = (utf8BOM ? Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(plainText)).ToArray<byte>() : Encoding.UTF8.GetBytes(plainText));
			}
			IL_B2:
			foreach (byte decNum in array)
			{
				text += QRCodeGenerator.DecToBin((int)decNum, 8);
			}
			return text;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005AD4 File Offset: 0x00003CD4
		private static QRCodeGenerator.Polynom XORPolynoms(QRCodeGenerator.Polynom messagePolynom, QRCodeGenerator.Polynom resPolynom)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			QRCodeGenerator.Polynom polynom2;
			QRCodeGenerator.Polynom polynom3;
			if (messagePolynom.PolyItems.Count >= resPolynom.PolyItems.Count)
			{
				polynom2 = messagePolynom;
				polynom3 = resPolynom;
			}
			else
			{
				polynom2 = resPolynom;
				polynom3 = messagePolynom;
			}
			for (int i = 0; i < polynom2.PolyItems.Count; i++)
			{
				QRCodeGenerator.PolynomItem item = new QRCodeGenerator.PolynomItem(polynom2.PolyItems[i].Coefficient ^ ((polynom3.PolyItems.Count > i) ? polynom3.PolyItems[i].Coefficient : 0), messagePolynom.PolyItems[0].Exponent - i);
				polynom.PolyItems.Add(item);
			}
			polynom.PolyItems.RemoveAt(0);
			return polynom;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005B94 File Offset: 0x00003D94
		private static QRCodeGenerator.Polynom MultiplyGeneratorPolynomByLeadterm(QRCodeGenerator.Polynom genPolynom, QRCodeGenerator.PolynomItem leadTerm, int lowerExponentBy)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			foreach (QRCodeGenerator.PolynomItem polynomItem in genPolynom.PolyItems)
			{
				QRCodeGenerator.PolynomItem item = new QRCodeGenerator.PolynomItem((polynomItem.Coefficient + leadTerm.Coefficient) % 255, polynomItem.Exponent - lowerExponentBy);
				polynom.PolyItems.Add(item);
			}
			return polynom;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005C18 File Offset: 0x00003E18
		private static QRCodeGenerator.Polynom MultiplyAlphaPolynoms(QRCodeGenerator.Polynom polynomBase, QRCodeGenerator.Polynom polynomMultiplier)
		{
			QRCodeGenerator.Polynom polynom = new QRCodeGenerator.Polynom();
			foreach (QRCodeGenerator.PolynomItem polynomItem in polynomMultiplier.PolyItems)
			{
				foreach (QRCodeGenerator.PolynomItem polynomItem2 in polynomBase.PolyItems)
				{
					QRCodeGenerator.PolynomItem item = new QRCodeGenerator.PolynomItem(QRCodeGenerator.ShrinkAlphaExp(polynomItem.Coefficient + polynomItem2.Coefficient), polynomItem.Exponent + polynomItem2.Exponent);
					polynom.PolyItems.Add(item);
				}
			}
			IEnumerable<int> enumerable = from x in polynom.PolyItems
			group x by x.Exponent into x
			where x.Count<QRCodeGenerator.PolynomItem>() > 1
			select x.First<QRCodeGenerator.PolynomItem>().Exponent;
			IList<int> toGlue = (enumerable as IList<int>) ?? enumerable.ToList<int>();
			List<QRCodeGenerator.PolynomItem> list = new List<QRCodeGenerator.PolynomItem>(toGlue.Count);
			using (IEnumerator<int> enumerator3 = toGlue.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					int exponent = enumerator3.Current;
					int intVal = (from x in polynom.PolyItems
					where x.Exponent == exponent
					select x).Aggregate(0, (int current, QRCodeGenerator.PolynomItem polynomOld) => current ^ QRCodeGenerator.GetIntValFromAlphaExp(polynomOld.Coefficient));
					QRCodeGenerator.PolynomItem item2 = new QRCodeGenerator.PolynomItem(QRCodeGenerator.GetAlphaExpFromIntVal(intVal), exponent);
					list.Add(item2);
				}
			}
			polynom.PolyItems.RemoveAll((QRCodeGenerator.PolynomItem x) => toGlue.Contains(x.Exponent));
			polynom.PolyItems.AddRange(list);
			polynom.PolyItems.Sort((QRCodeGenerator.PolynomItem x, QRCodeGenerator.PolynomItem y) => -x.Exponent.CompareTo(y.Exponent));
			return polynom;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005E74 File Offset: 0x00004074
		private static int GetIntValFromAlphaExp(int exp)
		{
			return QRCodeGenerator.galoisField.Find((QRCodeGenerator.Antilog alog) => alog.ExponentAlpha == exp).IntegerValue;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00005EAC File Offset: 0x000040AC
		private static int GetAlphaExpFromIntVal(int intVal)
		{
			return QRCodeGenerator.galoisField.Find((QRCodeGenerator.Antilog alog) => alog.IntegerValue == intVal).ExponentAlpha;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00005EE4 File Offset: 0x000040E4
		private static int ShrinkAlphaExp(int alphaExp)
		{
			return (int)((double)(alphaExp % 256) + Math.Floor((double)(alphaExp / 256)));
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00005F00 File Offset: 0x00004100
		private static Dictionary<char, int> CreateAlphanumEncDict()
		{
			Dictionary<char, int> dictionary = new Dictionary<char, int>(45);
			for (int i = 0; i < 10; i++)
			{
				dictionary.Add(string.Format("{0}", i)[0], i);
			}
			for (char c = 'A'; c <= 'Z'; c += '\u0001')
			{
				dictionary.Add(c, dictionary.Count<KeyValuePair<char, int>>());
			}
			for (int j = 0; j < QRCodeGenerator.alphanumEncTable.Length; j++)
			{
				dictionary.Add(QRCodeGenerator.alphanumEncTable[j], dictionary.Count<KeyValuePair<char, int>>());
			}
			return dictionary;
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00005F84 File Offset: 0x00004184
		private static List<QRCodeGenerator.AlignmentPattern> CreateAlignmentPatternTable()
		{
			List<QRCodeGenerator.AlignmentPattern> list = new List<QRCodeGenerator.AlignmentPattern>(40);
			for (int i = 0; i < 280; i += 7)
			{
				List<QRCodeGenerator.Point> list2 = new List<QRCodeGenerator.Point>();
				for (int j = 0; j < 7; j++)
				{
					if (QRCodeGenerator.alignmentPatternBaseValues[i + j] != 0)
					{
						for (int k = 0; k < 7; k++)
						{
							if (QRCodeGenerator.alignmentPatternBaseValues[i + k] != 0)
							{
								QRCodeGenerator.Point item = new QRCodeGenerator.Point(QRCodeGenerator.alignmentPatternBaseValues[i + j] - 2, QRCodeGenerator.alignmentPatternBaseValues[i + k] - 2);
								if (!list2.Contains(item))
								{
									list2.Add(item);
								}
							}
						}
					}
				}
				list.Add(new QRCodeGenerator.AlignmentPattern
				{
					Version = (i + 7) / 7,
					PatternPositions = list2
				});
			}
			return list;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006040 File Offset: 0x00004240
		private static List<QRCodeGenerator.ECCInfo> CreateCapacityECCTable()
		{
			List<QRCodeGenerator.ECCInfo> list = new List<QRCodeGenerator.ECCInfo>(160);
			for (int i = 0; i < 960; i += 24)
			{
				list.AddRange(new QRCodeGenerator.ECCInfo[]
				{
					new QRCodeGenerator.ECCInfo((i + 24) / 24, QRCodeGenerator.ECCLevel.L, QRCodeGenerator.capacityECCBaseValues[i], QRCodeGenerator.capacityECCBaseValues[i + 1], QRCodeGenerator.capacityECCBaseValues[i + 2], QRCodeGenerator.capacityECCBaseValues[i + 3], QRCodeGenerator.capacityECCBaseValues[i + 4], QRCodeGenerator.capacityECCBaseValues[i + 5]),
					new QRCodeGenerator.ECCInfo((i + 24) / 24, QRCodeGenerator.ECCLevel.M, QRCodeGenerator.capacityECCBaseValues[i + 6], QRCodeGenerator.capacityECCBaseValues[i + 7], QRCodeGenerator.capacityECCBaseValues[i + 8], QRCodeGenerator.capacityECCBaseValues[i + 9], QRCodeGenerator.capacityECCBaseValues[i + 10], QRCodeGenerator.capacityECCBaseValues[i + 11]),
					new QRCodeGenerator.ECCInfo((i + 24) / 24, QRCodeGenerator.ECCLevel.Q, QRCodeGenerator.capacityECCBaseValues[i + 12], QRCodeGenerator.capacityECCBaseValues[i + 13], QRCodeGenerator.capacityECCBaseValues[i + 14], QRCodeGenerator.capacityECCBaseValues[i + 15], QRCodeGenerator.capacityECCBaseValues[i + 16], QRCodeGenerator.capacityECCBaseValues[i + 17]),
					new QRCodeGenerator.ECCInfo((i + 24) / 24, QRCodeGenerator.ECCLevel.H, QRCodeGenerator.capacityECCBaseValues[i + 18], QRCodeGenerator.capacityECCBaseValues[i + 19], QRCodeGenerator.capacityECCBaseValues[i + 20], QRCodeGenerator.capacityECCBaseValues[i + 21], QRCodeGenerator.capacityECCBaseValues[i + 22], QRCodeGenerator.capacityECCBaseValues[i + 23])
				});
			}
			return list;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000061B4 File Offset: 0x000043B4
		private static List<QRCodeGenerator.VersionInfo> CreateCapacityTable()
		{
			List<QRCodeGenerator.VersionInfo> list = new List<QRCodeGenerator.VersionInfo>(40);
			for (int i = 0; i < 640; i += 16)
			{
				list.Add(new QRCodeGenerator.VersionInfo((i + 16) / 16, new List<QRCodeGenerator.VersionInfoDetails>(4)
				{
					new QRCodeGenerator.VersionInfoDetails(QRCodeGenerator.ECCLevel.L, new Dictionary<QRCodeGenerator.EncodingMode, int>
					{
						{
							QRCodeGenerator.EncodingMode.Numeric,
							QRCodeGenerator.capacityBaseValues[i]
						},
						{
							QRCodeGenerator.EncodingMode.Alphanumeric,
							QRCodeGenerator.capacityBaseValues[i + 1]
						},
						{
							QRCodeGenerator.EncodingMode.Byte,
							QRCodeGenerator.capacityBaseValues[i + 2]
						},
						{
							QRCodeGenerator.EncodingMode.Kanji,
							QRCodeGenerator.capacityBaseValues[i + 3]
						}
					}),
					new QRCodeGenerator.VersionInfoDetails(QRCodeGenerator.ECCLevel.M, new Dictionary<QRCodeGenerator.EncodingMode, int>
					{
						{
							QRCodeGenerator.EncodingMode.Numeric,
							QRCodeGenerator.capacityBaseValues[i + 4]
						},
						{
							QRCodeGenerator.EncodingMode.Alphanumeric,
							QRCodeGenerator.capacityBaseValues[i + 5]
						},
						{
							QRCodeGenerator.EncodingMode.Byte,
							QRCodeGenerator.capacityBaseValues[i + 6]
						},
						{
							QRCodeGenerator.EncodingMode.Kanji,
							QRCodeGenerator.capacityBaseValues[i + 7]
						}
					}),
					new QRCodeGenerator.VersionInfoDetails(QRCodeGenerator.ECCLevel.Q, new Dictionary<QRCodeGenerator.EncodingMode, int>
					{
						{
							QRCodeGenerator.EncodingMode.Numeric,
							QRCodeGenerator.capacityBaseValues[i + 8]
						},
						{
							QRCodeGenerator.EncodingMode.Alphanumeric,
							QRCodeGenerator.capacityBaseValues[i + 9]
						},
						{
							QRCodeGenerator.EncodingMode.Byte,
							QRCodeGenerator.capacityBaseValues[i + 10]
						},
						{
							QRCodeGenerator.EncodingMode.Kanji,
							QRCodeGenerator.capacityBaseValues[i + 11]
						}
					}),
					new QRCodeGenerator.VersionInfoDetails(QRCodeGenerator.ECCLevel.H, new Dictionary<QRCodeGenerator.EncodingMode, int>
					{
						{
							QRCodeGenerator.EncodingMode.Numeric,
							QRCodeGenerator.capacityBaseValues[i + 12]
						},
						{
							QRCodeGenerator.EncodingMode.Alphanumeric,
							QRCodeGenerator.capacityBaseValues[i + 13]
						},
						{
							QRCodeGenerator.EncodingMode.Byte,
							QRCodeGenerator.capacityBaseValues[i + 14]
						},
						{
							QRCodeGenerator.EncodingMode.Kanji,
							QRCodeGenerator.capacityBaseValues[i + 15]
						}
					})
				}));
			}
			return list;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006344 File Offset: 0x00004544
		private static List<QRCodeGenerator.Antilog> CreateAntilogTable()
		{
			List<QRCodeGenerator.Antilog> list = new List<QRCodeGenerator.Antilog>(256);
			int num = 1;
			for (int i = 0; i < 256; i++)
			{
				list.Add(new QRCodeGenerator.Antilog(i, num));
				num *= 2;
				if (num > 255)
				{
					num ^= 285;
				}
			}
			return list;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006390 File Offset: 0x00004590
		public void Dispose()
		{
		}

		// Token: 0x0400000B RID: 11
		private static readonly char[] alphanumEncTable = new char[]
		{
			' ',
			'$',
			'%',
			'*',
			'+',
			'-',
			'.',
			'/',
			':'
		};

		// Token: 0x0400000C RID: 12
		private static readonly int[] capacityBaseValues = new int[]
		{
			41,
			25,
			17,
			10,
			34,
			20,
			14,
			8,
			27,
			16,
			11,
			7,
			17,
			10,
			7,
			4,
			77,
			47,
			32,
			20,
			63,
			38,
			26,
			16,
			48,
			29,
			20,
			12,
			34,
			20,
			14,
			8,
			127,
			77,
			53,
			32,
			101,
			61,
			42,
			26,
			77,
			47,
			32,
			20,
			58,
			35,
			24,
			15,
			187,
			114,
			78,
			48,
			149,
			90,
			62,
			38,
			111,
			67,
			46,
			28,
			82,
			50,
			34,
			21,
			255,
			154,
			106,
			65,
			202,
			122,
			84,
			52,
			144,
			87,
			60,
			37,
			106,
			64,
			44,
			27,
			322,
			195,
			134,
			82,
			255,
			154,
			106,
			65,
			178,
			108,
			74,
			45,
			139,
			84,
			58,
			36,
			370,
			224,
			154,
			95,
			293,
			178,
			122,
			75,
			207,
			125,
			86,
			53,
			154,
			93,
			64,
			39,
			461,
			279,
			192,
			118,
			365,
			221,
			152,
			93,
			259,
			157,
			108,
			66,
			202,
			122,
			84,
			52,
			552,
			335,
			230,
			141,
			432,
			262,
			180,
			111,
			312,
			189,
			130,
			80,
			235,
			143,
			98,
			60,
			652,
			395,
			271,
			167,
			513,
			311,
			213,
			131,
			364,
			221,
			151,
			93,
			288,
			174,
			119,
			74,
			772,
			468,
			321,
			198,
			604,
			366,
			251,
			155,
			427,
			259,
			177,
			109,
			331,
			200,
			137,
			85,
			883,
			535,
			367,
			226,
			691,
			419,
			287,
			177,
			489,
			296,
			203,
			125,
			374,
			227,
			155,
			96,
			1022,
			619,
			425,
			262,
			796,
			483,
			331,
			204,
			580,
			352,
			241,
			149,
			427,
			259,
			177,
			109,
			1101,
			667,
			458,
			282,
			871,
			528,
			362,
			223,
			621,
			376,
			258,
			159,
			468,
			283,
			194,
			120,
			1250,
			758,
			520,
			320,
			991,
			600,
			412,
			254,
			703,
			426,
			292,
			180,
			530,
			321,
			220,
			136,
			1408,
			854,
			586,
			361,
			1082,
			656,
			450,
			277,
			775,
			470,
			322,
			198,
			602,
			365,
			250,
			154,
			1548,
			938,
			644,
			397,
			1212,
			734,
			504,
			310,
			876,
			531,
			364,
			224,
			674,
			408,
			280,
			173,
			1725,
			1046,
			718,
			442,
			1346,
			816,
			560,
			345,
			948,
			574,
			394,
			243,
			746,
			452,
			310,
			191,
			1903,
			1153,
			792,
			488,
			1500,
			909,
			624,
			384,
			1063,
			644,
			442,
			272,
			813,
			493,
			338,
			208,
			2061,
			1249,
			858,
			528,
			1600,
			970,
			666,
			410,
			1159,
			702,
			482,
			297,
			919,
			557,
			382,
			235,
			2232,
			1352,
			929,
			572,
			1708,
			1035,
			711,
			438,
			1224,
			742,
			509,
			314,
			969,
			587,
			403,
			248,
			2409,
			1460,
			1003,
			618,
			1872,
			1134,
			779,
			480,
			1358,
			823,
			565,
			348,
			1056,
			640,
			439,
			270,
			2620,
			1588,
			1091,
			672,
			2059,
			1248,
			857,
			528,
			1468,
			890,
			611,
			376,
			1108,
			672,
			461,
			284,
			2812,
			1704,
			1171,
			721,
			2188,
			1326,
			911,
			561,
			1588,
			963,
			661,
			407,
			1228,
			744,
			511,
			315,
			3057,
			1853,
			1273,
			784,
			2395,
			1451,
			997,
			614,
			1718,
			1041,
			715,
			440,
			1286,
			779,
			535,
			330,
			3283,
			1990,
			1367,
			842,
			2544,
			1542,
			1059,
			652,
			1804,
			1094,
			751,
			462,
			1425,
			864,
			593,
			365,
			3517,
			2132,
			1465,
			902,
			2701,
			1637,
			1125,
			692,
			1933,
			1172,
			805,
			496,
			1501,
			910,
			625,
			385,
			3669,
			2223,
			1528,
			940,
			2857,
			1732,
			1190,
			732,
			2085,
			1263,
			868,
			534,
			1581,
			958,
			658,
			405,
			3909,
			2369,
			1628,
			1002,
			3035,
			1839,
			1264,
			778,
			2181,
			1322,
			908,
			559,
			1677,
			1016,
			698,
			430,
			4158,
			2520,
			1732,
			1066,
			3289,
			1994,
			1370,
			843,
			2358,
			1429,
			982,
			604,
			1782,
			1080,
			742,
			457,
			4417,
			2677,
			1840,
			1132,
			3486,
			2113,
			1452,
			894,
			2473,
			1499,
			1030,
			634,
			1897,
			1150,
			790,
			486,
			4686,
			2840,
			1952,
			1201,
			3693,
			2238,
			1538,
			947,
			2670,
			1618,
			1112,
			684,
			2022,
			1226,
			842,
			518,
			4965,
			3009,
			2068,
			1273,
			3909,
			2369,
			1628,
			1002,
			2805,
			1700,
			1168,
			719,
			2157,
			1307,
			898,
			553,
			5253,
			3183,
			2188,
			1347,
			4134,
			2506,
			1722,
			1060,
			2949,
			1787,
			1228,
			756,
			2301,
			1394,
			958,
			590,
			5529,
			3351,
			2303,
			1417,
			4343,
			2632,
			1809,
			1113,
			3081,
			1867,
			1283,
			790,
			2361,
			1431,
			983,
			605,
			5836,
			3537,
			2431,
			1496,
			4588,
			2780,
			1911,
			1176,
			3244,
			1966,
			1351,
			832,
			2524,
			1530,
			1051,
			647,
			6153,
			3729,
			2563,
			1577,
			4775,
			2894,
			1989,
			1224,
			3417,
			2071,
			1423,
			876,
			2625,
			1591,
			1093,
			673,
			6479,
			3927,
			2699,
			1661,
			5039,
			3054,
			2099,
			1292,
			3599,
			2181,
			1499,
			923,
			2735,
			1658,
			1139,
			701,
			6743,
			4087,
			2809,
			1729,
			5313,
			3220,
			2213,
			1362,
			3791,
			2298,
			1579,
			972,
			2927,
			1774,
			1219,
			750,
			7089,
			4296,
			2953,
			1817,
			5596,
			3391,
			2331,
			1435,
			3993,
			2420,
			1663,
			1024,
			3057,
			1852,
			1273,
			784
		};

		// Token: 0x0400000D RID: 13
		private static readonly int[] capacityECCBaseValues = new int[]
		{
			19,
			7,
			1,
			19,
			0,
			0,
			16,
			10,
			1,
			16,
			0,
			0,
			13,
			13,
			1,
			13,
			0,
			0,
			9,
			17,
			1,
			9,
			0,
			0,
			34,
			10,
			1,
			34,
			0,
			0,
			28,
			16,
			1,
			28,
			0,
			0,
			22,
			22,
			1,
			22,
			0,
			0,
			16,
			28,
			1,
			16,
			0,
			0,
			55,
			15,
			1,
			55,
			0,
			0,
			44,
			26,
			1,
			44,
			0,
			0,
			34,
			18,
			2,
			17,
			0,
			0,
			26,
			22,
			2,
			13,
			0,
			0,
			80,
			20,
			1,
			80,
			0,
			0,
			64,
			18,
			2,
			32,
			0,
			0,
			48,
			26,
			2,
			24,
			0,
			0,
			36,
			16,
			4,
			9,
			0,
			0,
			108,
			26,
			1,
			108,
			0,
			0,
			86,
			24,
			2,
			43,
			0,
			0,
			62,
			18,
			2,
			15,
			2,
			16,
			46,
			22,
			2,
			11,
			2,
			12,
			136,
			18,
			2,
			68,
			0,
			0,
			108,
			16,
			4,
			27,
			0,
			0,
			76,
			24,
			4,
			19,
			0,
			0,
			60,
			28,
			4,
			15,
			0,
			0,
			156,
			20,
			2,
			78,
			0,
			0,
			124,
			18,
			4,
			31,
			0,
			0,
			88,
			18,
			2,
			14,
			4,
			15,
			66,
			26,
			4,
			13,
			1,
			14,
			194,
			24,
			2,
			97,
			0,
			0,
			154,
			22,
			2,
			38,
			2,
			39,
			110,
			22,
			4,
			18,
			2,
			19,
			86,
			26,
			4,
			14,
			2,
			15,
			232,
			30,
			2,
			116,
			0,
			0,
			182,
			22,
			3,
			36,
			2,
			37,
			132,
			20,
			4,
			16,
			4,
			17,
			100,
			24,
			4,
			12,
			4,
			13,
			274,
			18,
			2,
			68,
			2,
			69,
			216,
			26,
			4,
			43,
			1,
			44,
			154,
			24,
			6,
			19,
			2,
			20,
			122,
			28,
			6,
			15,
			2,
			16,
			324,
			20,
			4,
			81,
			0,
			0,
			254,
			30,
			1,
			50,
			4,
			51,
			180,
			28,
			4,
			22,
			4,
			23,
			140,
			24,
			3,
			12,
			8,
			13,
			370,
			24,
			2,
			92,
			2,
			93,
			290,
			22,
			6,
			36,
			2,
			37,
			206,
			26,
			4,
			20,
			6,
			21,
			158,
			28,
			7,
			14,
			4,
			15,
			428,
			26,
			4,
			107,
			0,
			0,
			334,
			22,
			8,
			37,
			1,
			38,
			244,
			24,
			8,
			20,
			4,
			21,
			180,
			22,
			12,
			11,
			4,
			12,
			461,
			30,
			3,
			115,
			1,
			116,
			365,
			24,
			4,
			40,
			5,
			41,
			261,
			20,
			11,
			16,
			5,
			17,
			197,
			24,
			11,
			12,
			5,
			13,
			523,
			22,
			5,
			87,
			1,
			88,
			415,
			24,
			5,
			41,
			5,
			42,
			295,
			30,
			5,
			24,
			7,
			25,
			223,
			24,
			11,
			12,
			7,
			13,
			589,
			24,
			5,
			98,
			1,
			99,
			453,
			28,
			7,
			45,
			3,
			46,
			325,
			24,
			15,
			19,
			2,
			20,
			253,
			30,
			3,
			15,
			13,
			16,
			647,
			28,
			1,
			107,
			5,
			108,
			507,
			28,
			10,
			46,
			1,
			47,
			367,
			28,
			1,
			22,
			15,
			23,
			283,
			28,
			2,
			14,
			17,
			15,
			721,
			30,
			5,
			120,
			1,
			121,
			563,
			26,
			9,
			43,
			4,
			44,
			397,
			28,
			17,
			22,
			1,
			23,
			313,
			28,
			2,
			14,
			19,
			15,
			795,
			28,
			3,
			113,
			4,
			114,
			627,
			26,
			3,
			44,
			11,
			45,
			445,
			26,
			17,
			21,
			4,
			22,
			341,
			26,
			9,
			13,
			16,
			14,
			861,
			28,
			3,
			107,
			5,
			108,
			669,
			26,
			3,
			41,
			13,
			42,
			485,
			30,
			15,
			24,
			5,
			25,
			385,
			28,
			15,
			15,
			10,
			16,
			932,
			28,
			4,
			116,
			4,
			117,
			714,
			26,
			17,
			42,
			0,
			0,
			512,
			28,
			17,
			22,
			6,
			23,
			406,
			30,
			19,
			16,
			6,
			17,
			1006,
			28,
			2,
			111,
			7,
			112,
			782,
			28,
			17,
			46,
			0,
			0,
			568,
			30,
			7,
			24,
			16,
			25,
			442,
			24,
			34,
			13,
			0,
			0,
			1094,
			30,
			4,
			121,
			5,
			122,
			860,
			28,
			4,
			47,
			14,
			48,
			614,
			30,
			11,
			24,
			14,
			25,
			464,
			30,
			16,
			15,
			14,
			16,
			1174,
			30,
			6,
			117,
			4,
			118,
			914,
			28,
			6,
			45,
			14,
			46,
			664,
			30,
			11,
			24,
			16,
			25,
			514,
			30,
			30,
			16,
			2,
			17,
			1276,
			26,
			8,
			106,
			4,
			107,
			1000,
			28,
			8,
			47,
			13,
			48,
			718,
			30,
			7,
			24,
			22,
			25,
			538,
			30,
			22,
			15,
			13,
			16,
			1370,
			28,
			10,
			114,
			2,
			115,
			1062,
			28,
			19,
			46,
			4,
			47,
			754,
			28,
			28,
			22,
			6,
			23,
			596,
			30,
			33,
			16,
			4,
			17,
			1468,
			30,
			8,
			122,
			4,
			123,
			1128,
			28,
			22,
			45,
			3,
			46,
			808,
			30,
			8,
			23,
			26,
			24,
			628,
			30,
			12,
			15,
			28,
			16,
			1531,
			30,
			3,
			117,
			10,
			118,
			1193,
			28,
			3,
			45,
			23,
			46,
			871,
			30,
			4,
			24,
			31,
			25,
			661,
			30,
			11,
			15,
			31,
			16,
			1631,
			30,
			7,
			116,
			7,
			117,
			1267,
			28,
			21,
			45,
			7,
			46,
			911,
			30,
			1,
			23,
			37,
			24,
			701,
			30,
			19,
			15,
			26,
			16,
			1735,
			30,
			5,
			115,
			10,
			116,
			1373,
			28,
			19,
			47,
			10,
			48,
			985,
			30,
			15,
			24,
			25,
			25,
			745,
			30,
			23,
			15,
			25,
			16,
			1843,
			30,
			13,
			115,
			3,
			116,
			1455,
			28,
			2,
			46,
			29,
			47,
			1033,
			30,
			42,
			24,
			1,
			25,
			793,
			30,
			23,
			15,
			28,
			16,
			1955,
			30,
			17,
			115,
			0,
			0,
			1541,
			28,
			10,
			46,
			23,
			47,
			1115,
			30,
			10,
			24,
			35,
			25,
			845,
			30,
			19,
			15,
			35,
			16,
			2071,
			30,
			17,
			115,
			1,
			116,
			1631,
			28,
			14,
			46,
			21,
			47,
			1171,
			30,
			29,
			24,
			19,
			25,
			901,
			30,
			11,
			15,
			46,
			16,
			2191,
			30,
			13,
			115,
			6,
			116,
			1725,
			28,
			14,
			46,
			23,
			47,
			1231,
			30,
			44,
			24,
			7,
			25,
			961,
			30,
			59,
			16,
			1,
			17,
			2306,
			30,
			12,
			121,
			7,
			122,
			1812,
			28,
			12,
			47,
			26,
			48,
			1286,
			30,
			39,
			24,
			14,
			25,
			986,
			30,
			22,
			15,
			41,
			16,
			2434,
			30,
			6,
			121,
			14,
			122,
			1914,
			28,
			6,
			47,
			34,
			48,
			1354,
			30,
			46,
			24,
			10,
			25,
			1054,
			30,
			2,
			15,
			64,
			16,
			2566,
			30,
			17,
			122,
			4,
			123,
			1992,
			28,
			29,
			46,
			14,
			47,
			1426,
			30,
			49,
			24,
			10,
			25,
			1096,
			30,
			24,
			15,
			46,
			16,
			2702,
			30,
			4,
			122,
			18,
			123,
			2102,
			28,
			13,
			46,
			32,
			47,
			1502,
			30,
			48,
			24,
			14,
			25,
			1142,
			30,
			42,
			15,
			32,
			16,
			2812,
			30,
			20,
			117,
			4,
			118,
			2216,
			28,
			40,
			47,
			7,
			48,
			1582,
			30,
			43,
			24,
			22,
			25,
			1222,
			30,
			10,
			15,
			67,
			16,
			2956,
			30,
			19,
			118,
			6,
			119,
			2334,
			28,
			18,
			47,
			31,
			48,
			1666,
			30,
			34,
			24,
			34,
			25,
			1276,
			30,
			20,
			15,
			61,
			16
		};

		// Token: 0x0400000E RID: 14
		private static readonly int[] alignmentPatternBaseValues = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			6,
			18,
			0,
			0,
			0,
			0,
			0,
			6,
			22,
			0,
			0,
			0,
			0,
			0,
			6,
			26,
			0,
			0,
			0,
			0,
			0,
			6,
			30,
			0,
			0,
			0,
			0,
			0,
			6,
			34,
			0,
			0,
			0,
			0,
			0,
			6,
			22,
			38,
			0,
			0,
			0,
			0,
			6,
			24,
			42,
			0,
			0,
			0,
			0,
			6,
			26,
			46,
			0,
			0,
			0,
			0,
			6,
			28,
			50,
			0,
			0,
			0,
			0,
			6,
			30,
			54,
			0,
			0,
			0,
			0,
			6,
			32,
			58,
			0,
			0,
			0,
			0,
			6,
			34,
			62,
			0,
			0,
			0,
			0,
			6,
			26,
			46,
			66,
			0,
			0,
			0,
			6,
			26,
			48,
			70,
			0,
			0,
			0,
			6,
			26,
			50,
			74,
			0,
			0,
			0,
			6,
			30,
			54,
			78,
			0,
			0,
			0,
			6,
			30,
			56,
			82,
			0,
			0,
			0,
			6,
			30,
			58,
			86,
			0,
			0,
			0,
			6,
			34,
			62,
			90,
			0,
			0,
			0,
			6,
			28,
			50,
			72,
			94,
			0,
			0,
			6,
			26,
			50,
			74,
			98,
			0,
			0,
			6,
			30,
			54,
			78,
			102,
			0,
			0,
			6,
			28,
			54,
			80,
			106,
			0,
			0,
			6,
			32,
			58,
			84,
			110,
			0,
			0,
			6,
			30,
			58,
			86,
			114,
			0,
			0,
			6,
			34,
			62,
			90,
			118,
			0,
			0,
			6,
			26,
			50,
			74,
			98,
			122,
			0,
			6,
			30,
			54,
			78,
			102,
			126,
			0,
			6,
			26,
			52,
			78,
			104,
			130,
			0,
			6,
			30,
			56,
			82,
			108,
			134,
			0,
			6,
			34,
			60,
			86,
			112,
			138,
			0,
			6,
			30,
			58,
			86,
			114,
			142,
			0,
			6,
			34,
			62,
			90,
			118,
			146,
			0,
			6,
			30,
			54,
			78,
			102,
			126,
			150,
			6,
			24,
			50,
			76,
			102,
			128,
			154,
			6,
			28,
			54,
			80,
			106,
			132,
			158,
			6,
			32,
			58,
			84,
			110,
			136,
			162,
			6,
			26,
			54,
			82,
			110,
			138,
			166,
			6,
			30,
			58,
			86,
			114,
			142,
			170
		};

		// Token: 0x0400000F RID: 15
		private static readonly int[] remainderBits = new int[]
		{
			0,
			7,
			7,
			7,
			7,
			7,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			4,
			4,
			4,
			4,
			4,
			4,
			4,
			3,
			3,
			3,
			3,
			3,
			3,
			3,
			0,
			0,
			0,
			0,
			0,
			0
		};

		// Token: 0x04000010 RID: 16
		private static readonly List<QRCodeGenerator.AlignmentPattern> alignmentPatternTable = QRCodeGenerator.CreateAlignmentPatternTable();

		// Token: 0x04000011 RID: 17
		private static readonly List<QRCodeGenerator.ECCInfo> capacityECCTable = QRCodeGenerator.CreateCapacityECCTable();

		// Token: 0x04000012 RID: 18
		private static readonly List<QRCodeGenerator.VersionInfo> capacityTable = QRCodeGenerator.CreateCapacityTable();

		// Token: 0x04000013 RID: 19
		private static readonly List<QRCodeGenerator.Antilog> galoisField = QRCodeGenerator.CreateAntilogTable();

		// Token: 0x04000014 RID: 20
		private static readonly Dictionary<char, int> alphanumEncDict = QRCodeGenerator.CreateAlphanumEncDict();

		// Token: 0x0200003F RID: 63
		public enum EciMode
		{
			// Token: 0x040000CC RID: 204
			Default,
			// Token: 0x040000CD RID: 205
			Iso8859_1 = 3,
			// Token: 0x040000CE RID: 206
			Iso8859_2,
			// Token: 0x040000CF RID: 207
			Utf8 = 26
		}

		// Token: 0x02000040 RID: 64
		private static class ModulePlacer
		{
			// Token: 0x0600011E RID: 286 RVA: 0x0000ADC4 File Offset: 0x00008FC4
			public static void AddQuietZone(ref QRCodeData qrCode)
			{
				bool[] array = new bool[qrCode.ModuleMatrix.Count + 8];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = false;
				}
				for (int j = 0; j < 4; j++)
				{
					qrCode.ModuleMatrix.Insert(0, new BitArray(array));
				}
				for (int k = 0; k < 4; k++)
				{
					qrCode.ModuleMatrix.Add(new BitArray(array));
				}
				for (int l = 4; l < qrCode.ModuleMatrix.Count - 4; l++)
				{
					bool[] collection = new bool[4];
					List<bool> list = new List<bool>(collection);
					list.AddRange(qrCode.ModuleMatrix[l].Cast<bool>());
					list.AddRange(collection);
					qrCode.ModuleMatrix[l] = new BitArray(list.ToArray());
				}
			}

			// Token: 0x0600011F RID: 287 RVA: 0x0000AEA0 File Offset: 0x000090A0
			private static string ReverseString(string inp)
			{
				string text = string.Empty;
				if (inp.Length > 0)
				{
					for (int i = inp.Length - 1; i >= 0; i--)
					{
						text += inp[i].ToString();
					}
				}
				return text;
			}

			// Token: 0x06000120 RID: 288 RVA: 0x0000AEE8 File Offset: 0x000090E8
			public static void PlaceVersion(ref QRCodeData qrCode, string versionStr)
			{
				int count = qrCode.ModuleMatrix.Count;
				string text = QRCodeGenerator.ModulePlacer.ReverseString(versionStr);
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						qrCode.ModuleMatrix[j + count - 11][i] = (text[i * 3 + j] == '1');
						qrCode.ModuleMatrix[i][j + count - 11] = (text[i * 3 + j] == '1');
					}
				}
			}

			// Token: 0x06000121 RID: 289 RVA: 0x0000AF70 File Offset: 0x00009170
			public static void PlaceFormat(ref QRCodeData qrCode, string formatStr)
			{
				int count = qrCode.ModuleMatrix.Count;
				string text = QRCodeGenerator.ModulePlacer.ReverseString(formatStr);
				int[,] array = new int[,]
				{
					{
						8,
						0,
						0,
						8
					},
					{
						8,
						1,
						0,
						8
					},
					{
						8,
						2,
						0,
						8
					},
					{
						8,
						3,
						0,
						8
					},
					{
						8,
						4,
						0,
						8
					},
					{
						8,
						5,
						0,
						8
					},
					{
						8,
						7,
						0,
						8
					},
					{
						8,
						8,
						0,
						8
					},
					{
						7,
						8,
						8,
						0
					},
					{
						5,
						8,
						8,
						0
					},
					{
						4,
						8,
						8,
						0
					},
					{
						3,
						8,
						8,
						0
					},
					{
						2,
						8,
						8,
						0
					},
					{
						1,
						8,
						8,
						0
					},
					{
						0,
						8,
						8,
						0
					}
				};
				array[0, 2] = count - 1;
				array[1, 2] = count - 2;
				array[2, 2] = count - 3;
				array[3, 2] = count - 4;
				array[4, 2] = count - 5;
				array[5, 2] = count - 6;
				array[6, 2] = count - 7;
				array[7, 2] = count - 8;
				array[8, 3] = count - 7;
				array[9, 3] = count - 6;
				array[10, 3] = count - 5;
				array[11, 3] = count - 4;
				array[12, 3] = count - 3;
				array[13, 3] = count - 2;
				array[14, 3] = count - 1;
				int[,] array2 = array;
				for (int i = 0; i < 15; i++)
				{
					QRCodeGenerator.Point point = new QRCodeGenerator.Point(array2[i, 0], array2[i, 1]);
					QRCodeGenerator.Point point2 = new QRCodeGenerator.Point(array2[i, 2], array2[i, 3]);
					qrCode.ModuleMatrix[point.Y][point.X] = (text[i] == '1');
					qrCode.ModuleMatrix[point2.Y][point2.X] = (text[i] == '1');
				}
			}

			// Token: 0x06000122 RID: 290 RVA: 0x0000B0E8 File Offset: 0x000092E8
			public static int MaskCode(ref QRCodeData qrCode, int version, ref List<QRCodeGenerator.Rectangle> blockedModules, QRCodeGenerator.ECCLevel eccLevel)
			{
				int? num = null;
				int num2 = 0;
				int count = qrCode.ModuleMatrix.Count;
				Dictionary<int, Func<int, int, bool>> dictionary = new Dictionary<int, Func<int, int, bool>>(8)
				{
					{
						1,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern1)
					},
					{
						2,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern2)
					},
					{
						3,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern3)
					},
					{
						4,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern4)
					},
					{
						5,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern5)
					},
					{
						6,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern6)
					},
					{
						7,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern7)
					},
					{
						8,
						new Func<int, int, bool>(QRCodeGenerator.ModulePlacer.MaskPattern.Pattern8)
					}
				};
				foreach (KeyValuePair<int, Func<int, int, bool>> keyValuePair in dictionary)
				{
					QRCodeData qrcodeData = new QRCodeData(version);
					for (int i = 0; i < count; i++)
					{
						for (int j = 0; j < count; j++)
						{
							qrcodeData.ModuleMatrix[i][j] = qrCode.ModuleMatrix[i][j];
						}
					}
					string formatString = QRCodeGenerator.GetFormatString(eccLevel, keyValuePair.Key - 1);
					QRCodeGenerator.ModulePlacer.PlaceFormat(ref qrcodeData, formatString);
					if (version >= 7)
					{
						string versionString = QRCodeGenerator.GetVersionString(version);
						QRCodeGenerator.ModulePlacer.PlaceVersion(ref qrcodeData, versionString);
					}
					for (int k = 0; k < count; k++)
					{
						for (int l = 0; l < k; l++)
						{
							if (!QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(k, l, 1, 1), blockedModules))
							{
								BitArray bitArray = qrcodeData.ModuleMatrix[l];
								int index = k;
								bitArray[index] ^= keyValuePair.Value(k, l);
								bitArray = qrcodeData.ModuleMatrix[k];
								index = l;
								bitArray[index] ^= keyValuePair.Value(l, k);
							}
						}
						if (!QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(k, k, 1, 1), blockedModules))
						{
							BitArray bitArray = qrcodeData.ModuleMatrix[k];
							int index = k;
							bitArray[index] ^= keyValuePair.Value(k, k);
						}
					}
					int num3 = QRCodeGenerator.ModulePlacer.MaskPattern.Score(ref qrcodeData);
					if (num == null || num2 > num3)
					{
						num = new int?(keyValuePair.Key);
						num2 = num3;
					}
				}
				for (int m = 0; m < count; m++)
				{
					for (int n = 0; n < m; n++)
					{
						if (!QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(m, n, 1, 1), blockedModules))
						{
							BitArray bitArray = qrCode.ModuleMatrix[n];
							int index = m;
							bitArray[index] ^= dictionary[num.Value](m, n);
							bitArray = qrCode.ModuleMatrix[m];
							index = n;
							bitArray[index] ^= dictionary[num.Value](n, m);
						}
					}
					if (!QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(m, m, 1, 1), blockedModules))
					{
						BitArray bitArray = qrCode.ModuleMatrix[m];
						int index = m;
						bitArray[index] ^= dictionary[num.Value](m, m);
					}
				}
				return num.Value - 1;
			}

			// Token: 0x06000123 RID: 291 RVA: 0x0000B4B0 File Offset: 0x000096B0
			public static void PlaceDataWords(ref QRCodeData qrCode, string data, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				int count = qrCode.ModuleMatrix.Count;
				bool flag = true;
				Queue<bool> queue = new Queue<bool>();
				for (int i = 0; i < data.Length; i++)
				{
					queue.Enqueue(data[i] != '0');
				}
				for (int j = count - 1; j >= 0; j -= 2)
				{
					if (j == 6)
					{
						j = 5;
					}
					for (int k = 1; k <= count; k++)
					{
						if (flag)
						{
							int num = count - k;
							if (queue.Count > 0 && !QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(j, num, 1, 1), blockedModules))
							{
								qrCode.ModuleMatrix[num][j] = queue.Dequeue();
							}
							if (queue.Count > 0 && j > 0 && !QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(j - 1, num, 1, 1), blockedModules))
							{
								qrCode.ModuleMatrix[num][j - 1] = queue.Dequeue();
							}
						}
						else
						{
							int num = k - 1;
							if (queue.Count > 0 && !QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(j, num, 1, 1), blockedModules))
							{
								qrCode.ModuleMatrix[num][j] = queue.Dequeue();
							}
							if (queue.Count > 0 && j > 0 && !QRCodeGenerator.ModulePlacer.IsBlocked(new QRCodeGenerator.Rectangle(j - 1, num, 1, 1), blockedModules))
							{
								qrCode.ModuleMatrix[num][j - 1] = queue.Dequeue();
							}
						}
					}
					flag = !flag;
				}
			}

			// Token: 0x06000124 RID: 292 RVA: 0x0000B644 File Offset: 0x00009844
			public static void ReserveSeperatorAreas(int size, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				blockedModules.AddRange(new QRCodeGenerator.Rectangle[]
				{
					new QRCodeGenerator.Rectangle(7, 0, 1, 8),
					new QRCodeGenerator.Rectangle(0, 7, 7, 1),
					new QRCodeGenerator.Rectangle(0, size - 8, 8, 1),
					new QRCodeGenerator.Rectangle(7, size - 7, 1, 7),
					new QRCodeGenerator.Rectangle(size - 8, 0, 1, 8),
					new QRCodeGenerator.Rectangle(size - 7, 7, 7, 1)
				});
			}

			// Token: 0x06000125 RID: 293 RVA: 0x0000B6B0 File Offset: 0x000098B0
			public static void ReserveVersionAreas(int size, int version, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				blockedModules.AddRange(new QRCodeGenerator.Rectangle[]
				{
					new QRCodeGenerator.Rectangle(8, 0, 1, 6),
					new QRCodeGenerator.Rectangle(8, 7, 1, 1),
					new QRCodeGenerator.Rectangle(0, 8, 6, 1),
					new QRCodeGenerator.Rectangle(7, 8, 2, 1),
					new QRCodeGenerator.Rectangle(size - 8, 8, 8, 1),
					new QRCodeGenerator.Rectangle(8, size - 7, 1, 7)
				});
				if (version >= 7)
				{
					blockedModules.AddRange(new QRCodeGenerator.Rectangle[]
					{
						new QRCodeGenerator.Rectangle(size - 11, 0, 3, 6),
						new QRCodeGenerator.Rectangle(0, size - 11, 6, 3)
					});
				}
			}

			// Token: 0x06000126 RID: 294 RVA: 0x0000B745 File Offset: 0x00009945
			public static void PlaceDarkModule(ref QRCodeData qrCode, int version, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				qrCode.ModuleMatrix[4 * version + 9][8] = true;
				blockedModules.Add(new QRCodeGenerator.Rectangle(8, 4 * version + 9, 1, 1));
			}

			// Token: 0x06000127 RID: 295 RVA: 0x0000B778 File Offset: 0x00009978
			public static void PlaceFinderPatterns(ref QRCodeData qrCode, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				int count = qrCode.ModuleMatrix.Count;
				int[] array = new int[]
				{
					0,
					0,
					count - 7,
					0,
					0,
					count - 7
				};
				for (int i = 0; i < 6; i += 2)
				{
					for (int j = 0; j < 7; j++)
					{
						for (int k = 0; k < 7; k++)
						{
							if (((j != 1 && j != 5) || k <= 0 || k >= 6) && (j <= 0 || j >= 6 || (k != 1 && k != 5)))
							{
								qrCode.ModuleMatrix[k + array[i + 1]][j + array[i]] = true;
							}
						}
					}
					blockedModules.Add(new QRCodeGenerator.Rectangle(array[i], array[i + 1], 7, 7));
				}
			}

			// Token: 0x06000128 RID: 296 RVA: 0x0000B828 File Offset: 0x00009A28
			public static void PlaceAlignmentPatterns(ref QRCodeData qrCode, List<QRCodeGenerator.Point> alignmentPatternLocations, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				foreach (QRCodeGenerator.Point point in alignmentPatternLocations)
				{
					QRCodeGenerator.Rectangle r = new QRCodeGenerator.Rectangle(point.X, point.Y, 5, 5);
					bool flag = false;
					foreach (QRCodeGenerator.Rectangle r2 in blockedModules)
					{
						if (QRCodeGenerator.ModulePlacer.Intersects(r, r2))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						for (int i = 0; i < 5; i++)
						{
							for (int j = 0; j < 5; j++)
							{
								if (j == 0 || j == 4 || i == 0 || i == 4 || (i == 2 && j == 2))
								{
									qrCode.ModuleMatrix[point.Y + j][point.X + i] = true;
								}
							}
						}
						blockedModules.Add(new QRCodeGenerator.Rectangle(point.X, point.Y, 5, 5));
					}
				}
			}

			// Token: 0x06000129 RID: 297 RVA: 0x0000B950 File Offset: 0x00009B50
			public static void PlaceTimingPatterns(ref QRCodeData qrCode, ref List<QRCodeGenerator.Rectangle> blockedModules)
			{
				int count = qrCode.ModuleMatrix.Count;
				for (int i = 8; i < count - 8; i++)
				{
					if (i % 2 == 0)
					{
						qrCode.ModuleMatrix[6][i] = true;
						qrCode.ModuleMatrix[i][6] = true;
					}
				}
				blockedModules.AddRange(new QRCodeGenerator.Rectangle[]
				{
					new QRCodeGenerator.Rectangle(6, 8, 1, count - 16),
					new QRCodeGenerator.Rectangle(8, 6, count - 16, 1)
				});
			}

			// Token: 0x0600012A RID: 298 RVA: 0x0000B9D0 File Offset: 0x00009BD0
			private static bool Intersects(QRCodeGenerator.Rectangle r1, QRCodeGenerator.Rectangle r2)
			{
				return r2.X < r1.X + r1.Width && r1.X < r2.X + r2.Width && r2.Y < r1.Y + r1.Height && r1.Y < r2.Y + r2.Height;
			}

			// Token: 0x0600012B RID: 299 RVA: 0x0000BA34 File Offset: 0x00009C34
			private static bool IsBlocked(QRCodeGenerator.Rectangle r1, List<QRCodeGenerator.Rectangle> blockedModules)
			{
				using (List<QRCodeGenerator.Rectangle>.Enumerator enumerator = blockedModules.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (QRCodeGenerator.ModulePlacer.Intersects(enumerator.Current, r1))
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x02000086 RID: 134
			private static class MaskPattern
			{
				// Token: 0x06000205 RID: 517 RVA: 0x0000D6E6 File Offset: 0x0000B8E6
				public static bool Pattern1(int x, int y)
				{
					return (x + y) % 2 == 0;
				}

				// Token: 0x06000206 RID: 518 RVA: 0x0000D6F0 File Offset: 0x0000B8F0
				public static bool Pattern2(int x, int y)
				{
					return y % 2 == 0;
				}

				// Token: 0x06000207 RID: 519 RVA: 0x0000D6F8 File Offset: 0x0000B8F8
				public static bool Pattern3(int x, int y)
				{
					return x % 3 == 0;
				}

				// Token: 0x06000208 RID: 520 RVA: 0x0000D700 File Offset: 0x0000B900
				public static bool Pattern4(int x, int y)
				{
					return (x + y) % 3 == 0;
				}

				// Token: 0x06000209 RID: 521 RVA: 0x0000D70A File Offset: 0x0000B90A
				public static bool Pattern5(int x, int y)
				{
					return (int)(Math.Floor((double)y / 2.0) + Math.Floor((double)x / 3.0)) % 2 == 0;
				}

				// Token: 0x0600020A RID: 522 RVA: 0x0000D735 File Offset: 0x0000B935
				public static bool Pattern6(int x, int y)
				{
					return x * y % 2 + x * y % 3 == 0;
				}

				// Token: 0x0600020B RID: 523 RVA: 0x0000D745 File Offset: 0x0000B945
				public static bool Pattern7(int x, int y)
				{
					return (x * y % 2 + x * y % 3) % 2 == 0;
				}

				// Token: 0x0600020C RID: 524 RVA: 0x0000D757 File Offset: 0x0000B957
				public static bool Pattern8(int x, int y)
				{
					return ((x + y) % 2 + x * y % 3) % 2 == 0;
				}

				// Token: 0x0600020D RID: 525 RVA: 0x0000D76C File Offset: 0x0000B96C
				public static int Score(ref QRCodeData qrCode)
				{
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					int count = qrCode.ModuleMatrix.Count;
					for (int i = 0; i < count; i++)
					{
						int num4 = 0;
						int num5 = 0;
						bool flag = qrCode.ModuleMatrix[i][0];
						bool flag2 = qrCode.ModuleMatrix[0][i];
						for (int j = 0; j < count; j++)
						{
							if (qrCode.ModuleMatrix[i][j] == flag)
							{
								num4++;
							}
							else
							{
								num4 = 1;
							}
							if (num4 == 5)
							{
								num += 3;
							}
							else if (num4 > 5)
							{
								num++;
							}
							flag = qrCode.ModuleMatrix[i][j];
							if (qrCode.ModuleMatrix[j][i] == flag2)
							{
								num5++;
							}
							else
							{
								num5 = 1;
							}
							if (num5 == 5)
							{
								num += 3;
							}
							else if (num5 > 5)
							{
								num++;
							}
							flag2 = qrCode.ModuleMatrix[j][i];
						}
					}
					for (int k = 0; k < count - 1; k++)
					{
						for (int l = 0; l < count - 1; l++)
						{
							if (qrCode.ModuleMatrix[k][l] == qrCode.ModuleMatrix[k][l + 1] && qrCode.ModuleMatrix[k][l] == qrCode.ModuleMatrix[k + 1][l] && qrCode.ModuleMatrix[k][l] == qrCode.ModuleMatrix[k + 1][l + 1])
							{
								num2 += 3;
							}
						}
					}
					for (int m = 0; m < count; m++)
					{
						for (int n = 0; n < count - 10; n++)
						{
							if ((qrCode.ModuleMatrix[m][n] && !qrCode.ModuleMatrix[m][n + 1] && qrCode.ModuleMatrix[m][n + 2] && qrCode.ModuleMatrix[m][n + 3] && qrCode.ModuleMatrix[m][n + 4] && !qrCode.ModuleMatrix[m][n + 5] && qrCode.ModuleMatrix[m][n + 6] && !qrCode.ModuleMatrix[m][n + 7] && !qrCode.ModuleMatrix[m][n + 8] && !qrCode.ModuleMatrix[m][n + 9] && !qrCode.ModuleMatrix[m][n + 10]) || (!qrCode.ModuleMatrix[m][n] && !qrCode.ModuleMatrix[m][n + 1] && !qrCode.ModuleMatrix[m][n + 2] && !qrCode.ModuleMatrix[m][n + 3] && qrCode.ModuleMatrix[m][n + 4] && !qrCode.ModuleMatrix[m][n + 5] && qrCode.ModuleMatrix[m][n + 6] && qrCode.ModuleMatrix[m][n + 7] && qrCode.ModuleMatrix[m][n + 8] && !qrCode.ModuleMatrix[m][n + 9] && qrCode.ModuleMatrix[m][n + 10]))
							{
								num3 += 40;
							}
							if ((qrCode.ModuleMatrix[n][m] && !qrCode.ModuleMatrix[n + 1][m] && qrCode.ModuleMatrix[n + 2][m] && qrCode.ModuleMatrix[n + 3][m] && qrCode.ModuleMatrix[n + 4][m] && !qrCode.ModuleMatrix[n + 5][m] && qrCode.ModuleMatrix[n + 6][m] && !qrCode.ModuleMatrix[n + 7][m] && !qrCode.ModuleMatrix[n + 8][m] && !qrCode.ModuleMatrix[n + 9][m] && !qrCode.ModuleMatrix[n + 10][m]) || (!qrCode.ModuleMatrix[n][m] && !qrCode.ModuleMatrix[n + 1][m] && !qrCode.ModuleMatrix[n + 2][m] && !qrCode.ModuleMatrix[n + 3][m] && qrCode.ModuleMatrix[n + 4][m] && !qrCode.ModuleMatrix[n + 5][m] && qrCode.ModuleMatrix[n + 6][m] && qrCode.ModuleMatrix[n + 7][m] && qrCode.ModuleMatrix[n + 8][m] && !qrCode.ModuleMatrix[n + 9][m] && qrCode.ModuleMatrix[n + 10][m]))
							{
								num3 += 40;
							}
						}
					}
					double num6 = 0.0;
					foreach (BitArray bitArray in qrCode.ModuleMatrix)
					{
						using (IEnumerator enumerator2 = bitArray.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								if ((bool)enumerator2.Current)
								{
									num6 += 1.0;
								}
							}
						}
					}
					double num7 = num6 / (double)(qrCode.ModuleMatrix.Count * qrCode.ModuleMatrix.Count) * 100.0;
					int val = Math.Abs((int)Math.Floor(num7 / 5.0) * 5 - 50) / 5;
					int val2 = Math.Abs((int)Math.Floor(num7 / 5.0) * 5 - 45) / 5;
					int num8 = Math.Min(val, val2) * 10;
					return num + num2 + num3 + num8;
				}
			}
		}

		// Token: 0x02000041 RID: 65
		public enum ECCLevel
		{
			// Token: 0x040000D1 RID: 209
			L,
			// Token: 0x040000D2 RID: 210
			M,
			// Token: 0x040000D3 RID: 211
			Q,
			// Token: 0x040000D4 RID: 212
			H
		}

		// Token: 0x02000042 RID: 66
		private enum EncodingMode
		{
			// Token: 0x040000D6 RID: 214
			Numeric = 1,
			// Token: 0x040000D7 RID: 215
			Alphanumeric,
			// Token: 0x040000D8 RID: 216
			Byte = 4,
			// Token: 0x040000D9 RID: 217
			Kanji = 8,
			// Token: 0x040000DA RID: 218
			ECI = 7
		}

		// Token: 0x02000043 RID: 67
		private struct AlignmentPattern
		{
			// Token: 0x040000DB RID: 219
			public int Version;

			// Token: 0x040000DC RID: 220
			public List<QRCodeGenerator.Point> PatternPositions;
		}

		// Token: 0x02000044 RID: 68
		private struct CodewordBlock
		{
			// Token: 0x0600012C RID: 300 RVA: 0x0000BA8C File Offset: 0x00009C8C
			public CodewordBlock(int groupNumber, int blockNumber, string bitString, List<string> codeWords, List<string> eccWords, List<int> codeWordsInt, List<int> eccWordsInt)
			{
				this.GroupNumber = groupNumber;
				this.BlockNumber = blockNumber;
				this.BitString = bitString;
				this.CodeWords = codeWords;
				this.ECCWords = eccWords;
				this.CodeWordsInt = codeWordsInt;
				this.ECCWordsInt = eccWordsInt;
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x0600012D RID: 301 RVA: 0x0000BAC3 File Offset: 0x00009CC3
			public int GroupNumber { get; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x0600012E RID: 302 RVA: 0x0000BACB File Offset: 0x00009CCB
			public int BlockNumber { get; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600012F RID: 303 RVA: 0x0000BAD3 File Offset: 0x00009CD3
			public string BitString { get; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000130 RID: 304 RVA: 0x0000BADB File Offset: 0x00009CDB
			public List<string> CodeWords { get; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000131 RID: 305 RVA: 0x0000BAE3 File Offset: 0x00009CE3
			public List<int> CodeWordsInt { get; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000132 RID: 306 RVA: 0x0000BAEB File Offset: 0x00009CEB
			public List<string> ECCWords { get; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000133 RID: 307 RVA: 0x0000BAF3 File Offset: 0x00009CF3
			public List<int> ECCWordsInt { get; }
		}

		// Token: 0x02000045 RID: 69
		private struct ECCInfo
		{
			// Token: 0x06000134 RID: 308 RVA: 0x0000BAFB File Offset: 0x00009CFB
			public ECCInfo(int version, QRCodeGenerator.ECCLevel errorCorrectionLevel, int totalDataCodewords, int eccPerBlock, int blocksInGroup1, int codewordsInGroup1, int blocksInGroup2, int codewordsInGroup2)
			{
				this.Version = version;
				this.ErrorCorrectionLevel = errorCorrectionLevel;
				this.TotalDataCodewords = totalDataCodewords;
				this.ECCPerBlock = eccPerBlock;
				this.BlocksInGroup1 = blocksInGroup1;
				this.CodewordsInGroup1 = codewordsInGroup1;
				this.BlocksInGroup2 = blocksInGroup2;
				this.CodewordsInGroup2 = codewordsInGroup2;
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000135 RID: 309 RVA: 0x0000BB3A File Offset: 0x00009D3A
			public int Version { get; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000136 RID: 310 RVA: 0x0000BB42 File Offset: 0x00009D42
			public QRCodeGenerator.ECCLevel ErrorCorrectionLevel { get; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000137 RID: 311 RVA: 0x0000BB4A File Offset: 0x00009D4A
			public int TotalDataCodewords { get; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000138 RID: 312 RVA: 0x0000BB52 File Offset: 0x00009D52
			public int ECCPerBlock { get; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x06000139 RID: 313 RVA: 0x0000BB5A File Offset: 0x00009D5A
			public int BlocksInGroup1 { get; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600013A RID: 314 RVA: 0x0000BB62 File Offset: 0x00009D62
			public int CodewordsInGroup1 { get; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600013B RID: 315 RVA: 0x0000BB6A File Offset: 0x00009D6A
			public int BlocksInGroup2 { get; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600013C RID: 316 RVA: 0x0000BB72 File Offset: 0x00009D72
			public int CodewordsInGroup2 { get; }
		}

		// Token: 0x02000046 RID: 70
		private struct VersionInfo
		{
			// Token: 0x0600013D RID: 317 RVA: 0x0000BB7A File Offset: 0x00009D7A
			public VersionInfo(int version, List<QRCodeGenerator.VersionInfoDetails> versionInfoDetails)
			{
				this.Version = version;
				this.Details = versionInfoDetails;
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x0600013E RID: 318 RVA: 0x0000BB8A File Offset: 0x00009D8A
			public int Version { get; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600013F RID: 319 RVA: 0x0000BB92 File Offset: 0x00009D92
			public List<QRCodeGenerator.VersionInfoDetails> Details { get; }
		}

		// Token: 0x02000047 RID: 71
		private struct VersionInfoDetails
		{
			// Token: 0x06000140 RID: 320 RVA: 0x0000BB9A File Offset: 0x00009D9A
			public VersionInfoDetails(QRCodeGenerator.ECCLevel errorCorrectionLevel, Dictionary<QRCodeGenerator.EncodingMode, int> capacityDict)
			{
				this.ErrorCorrectionLevel = errorCorrectionLevel;
				this.CapacityDict = capacityDict;
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000141 RID: 321 RVA: 0x0000BBAA File Offset: 0x00009DAA
			public QRCodeGenerator.ECCLevel ErrorCorrectionLevel { get; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000142 RID: 322 RVA: 0x0000BBB2 File Offset: 0x00009DB2
			public Dictionary<QRCodeGenerator.EncodingMode, int> CapacityDict { get; }
		}

		// Token: 0x02000048 RID: 72
		private struct Antilog
		{
			// Token: 0x06000143 RID: 323 RVA: 0x0000BBBA File Offset: 0x00009DBA
			public Antilog(int exponentAlpha, int integerValue)
			{
				this.ExponentAlpha = exponentAlpha;
				this.IntegerValue = integerValue;
			}

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000144 RID: 324 RVA: 0x0000BBCA File Offset: 0x00009DCA
			public int ExponentAlpha { get; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000145 RID: 325 RVA: 0x0000BBD2 File Offset: 0x00009DD2
			public int IntegerValue { get; }
		}

		// Token: 0x02000049 RID: 73
		private struct PolynomItem
		{
			// Token: 0x06000146 RID: 326 RVA: 0x0000BBDA File Offset: 0x00009DDA
			public PolynomItem(int coefficient, int exponent)
			{
				this.Coefficient = coefficient;
				this.Exponent = exponent;
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000147 RID: 327 RVA: 0x0000BBEA File Offset: 0x00009DEA
			public int Coefficient { get; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000148 RID: 328 RVA: 0x0000BBF2 File Offset: 0x00009DF2
			public int Exponent { get; }
		}

		// Token: 0x0200004A RID: 74
		private class Polynom
		{
			// Token: 0x06000149 RID: 329 RVA: 0x0000BBFA File Offset: 0x00009DFA
			public Polynom()
			{
				this.PolyItems = new List<QRCodeGenerator.PolynomItem>();
			}

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x0600014A RID: 330 RVA: 0x0000BC0D File Offset: 0x00009E0D
			// (set) Token: 0x0600014B RID: 331 RVA: 0x0000BC15 File Offset: 0x00009E15
			public List<QRCodeGenerator.PolynomItem> PolyItems { get; set; }

			// Token: 0x0600014C RID: 332 RVA: 0x0000BC20 File Offset: 0x00009E20
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (QRCodeGenerator.PolynomItem polynomItem in this.PolyItems)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"a^",
						polynomItem.Coefficient.ToString(),
						"*x^",
						polynomItem.Exponent.ToString(),
						" + "
					}));
				}
				return stringBuilder.ToString().TrimEnd(new char[]
				{
					' ',
					'+'
				});
			}
		}

		// Token: 0x0200004B RID: 75
		private class Point
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x0600014D RID: 333 RVA: 0x0000BCDC File Offset: 0x00009EDC
			public int X { get; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x0600014E RID: 334 RVA: 0x0000BCE4 File Offset: 0x00009EE4
			public int Y { get; }

			// Token: 0x0600014F RID: 335 RVA: 0x0000BCEC File Offset: 0x00009EEC
			public Point(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}
		}

		// Token: 0x0200004C RID: 76
		private class Rectangle
		{
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000150 RID: 336 RVA: 0x0000BD02 File Offset: 0x00009F02
			public int X { get; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000151 RID: 337 RVA: 0x0000BD0A File Offset: 0x00009F0A
			public int Y { get; }

			// Token: 0x17000032 RID: 50
			// (get) Token: 0x06000152 RID: 338 RVA: 0x0000BD12 File Offset: 0x00009F12
			public int Width { get; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x06000153 RID: 339 RVA: 0x0000BD1A File Offset: 0x00009F1A
			public int Height { get; }

			// Token: 0x06000154 RID: 340 RVA: 0x0000BD22 File Offset: 0x00009F22
			public Rectangle(int x, int y, int w, int h)
			{
				this.X = x;
				this.Y = y;
				this.Width = w;
				this.Height = h;
			}
		}
	}
}
