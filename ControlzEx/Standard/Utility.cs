using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ControlzEx.Standard
{
	// Token: 0x020000BE RID: 190
	internal static class Utility
	{
		// Token: 0x06000398 RID: 920 RVA: 0x00009CBC File Offset: 0x00007EBC
		private static bool _MemCmp(IntPtr left, IntPtr right, long cb)
		{
			int num = 0;
			while ((long)num < cb - 8L)
			{
				long num2 = Marshal.ReadInt64(left, num);
				long num3 = Marshal.ReadInt64(right, num);
				if (num2 != num3)
				{
					return false;
				}
				num += 8;
			}
			while ((long)num < cb)
			{
				byte b = Marshal.ReadByte(left, num);
				byte b2 = Marshal.ReadByte(right, num);
				if (b != b2)
				{
					return false;
				}
				num++;
			}
			return true;
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00009D0D File Offset: 0x00007F0D
		public static Exception FailableFunction<T>(Func<T> function, out T result)
		{
			return Utility.FailableFunction<T>(5, function, out result);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00009D18 File Offset: 0x00007F18
		public static T FailableFunction<T>(Func<T> function)
		{
			T result;
			Exception ex = Utility.FailableFunction<T>(function, out result);
			if (ex != null)
			{
				throw ex;
			}
			return result;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x00009D34 File Offset: 0x00007F34
		public static T FailableFunction<T>(int maxRetries, Func<T> function)
		{
			T result;
			Exception ex = Utility.FailableFunction<T>(maxRetries, function, out result);
			if (ex != null)
			{
				throw ex;
			}
			return result;
		}

		// Token: 0x0600039C RID: 924 RVA: 0x00009D54 File Offset: 0x00007F54
		public static Exception FailableFunction<T>(int maxRetries, Func<T> function, out T result)
		{
			int num = 0;
			Exception result2;
			for (;;)
			{
				try
				{
					result = function();
					result2 = null;
					break;
				}
				catch (Exception ex)
				{
					if (num == maxRetries)
					{
						result = default(T);
						result2 = ex;
						break;
					}
				}
				num++;
			}
			return result2;
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00009DA0 File Offset: 0x00007FA0
		public static string GetHashString(string value)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				result = md.ComputeHash(Encoding.UTF8.GetBytes(value)).Aggregate(new StringBuilder(), (StringBuilder sb, byte b) => sb.Append(b.ToString("x2", CultureInfo.InvariantCulture))).ToString();
			}
			return result;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00009E10 File Offset: 0x00008010
		public static Point GetPoint(IntPtr ptr)
		{
			uint num = Environment.Is64BitProcess ? ((uint)ptr.ToInt64()) : ((uint)ptr.ToInt32());
			short num2 = (short)num;
			short num3 = (short)(num >> 16);
			return new Point((double)num2, (double)num3);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00009E46 File Offset: 0x00008046
		public static int GET_X_LPARAM(IntPtr lParam)
		{
			return Utility.LOWORD(lParam.ToInt32());
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00009E54 File Offset: 0x00008054
		public static int GET_Y_LPARAM(IntPtr lParam)
		{
			return Utility.HIWORD(lParam.ToInt32());
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00009E62 File Offset: 0x00008062
		public static int HIWORD(int i)
		{
			return (int)((short)(i >> 16));
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00002B62 File Offset: 0x00000D62
		public static int LOWORD(int i)
		{
			return (int)((short)(i & 65535));
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00009E6C File Offset: 0x0000806C
		public static bool AreStreamsEqual(Stream left, Stream right)
		{
			if (left == null)
			{
				return right == null;
			}
			if (right == null)
			{
				return false;
			}
			if (!left.CanRead || !right.CanRead)
			{
				throw new NotSupportedException("The streams can't be read for comparison");
			}
			if (left.Length != right.Length)
			{
				return false;
			}
			int num = (int)left.Length;
			left.Position = 0L;
			right.Position = 0L;
			int i = 0;
			int num2 = 0;
			byte[] array = new byte[512];
			byte[] array2 = new byte[512];
			GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			IntPtr left2 = gchandle.AddrOfPinnedObject();
			GCHandle gchandle2 = GCHandle.Alloc(array2, GCHandleType.Pinned);
			IntPtr right2 = gchandle2.AddrOfPinnedObject();
			bool result;
			try
			{
				while (i < num)
				{
					int num3 = left.Read(array, 0, array.Length);
					int num4 = right.Read(array2, 0, array2.Length);
					if (num3 != num4)
					{
						return false;
					}
					if (!Utility._MemCmp(left2, right2, (long)num3))
					{
						return false;
					}
					i += num3;
					num2 += num4;
				}
				result = true;
			}
			finally
			{
				gchandle.Free();
				gchandle2.Free();
			}
			return result;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00009F80 File Offset: 0x00008180
		public static bool GuidTryParse(string guidString, out Guid guid)
		{
			Verify.IsNeitherNullNorEmpty(guidString, "guidString");
			try
			{
				guid = new Guid(guidString);
				return true;
			}
			catch (FormatException)
			{
			}
			catch (OverflowException)
			{
			}
			guid = default(Guid);
			return false;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00009FD4 File Offset: 0x000081D4
		public static bool IsFlagSet(int value, int mask)
		{
			return (value & mask) != 0;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00009FD4 File Offset: 0x000081D4
		public static bool IsFlagSet(uint value, uint mask)
		{
			return (value & mask) > 0U;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00009FDC File Offset: 0x000081DC
		public static bool IsFlagSet(long value, long mask)
		{
			return (value & mask) != 0L;
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00009FDC File Offset: 0x000081DC
		public static bool IsFlagSet(ulong value, ulong mask)
		{
			return (value & mask) > 0UL;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00009FE8 File Offset: 0x000081E8
		public static bool IsInterfaceImplemented(Type objectType, Type interfaceType)
		{
			return objectType.GetInterfaces().Any((Type type) => type == interfaceType);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000A01C File Offset: 0x0000821C
		public static string SafeCopyFile(string sourceFileName, string destFileName, SafeCopyFileOptions options)
		{
			switch (options)
			{
			case SafeCopyFileOptions.PreserveOriginal:
				if (!File.Exists(destFileName))
				{
					File.Copy(sourceFileName, destFileName);
					return destFileName;
				}
				return null;
			case SafeCopyFileOptions.Overwrite:
				File.Copy(sourceFileName, destFileName, true);
				return destFileName;
			case SafeCopyFileOptions.FindBetterName:
			{
				string directoryName = Path.GetDirectoryName(destFileName);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(destFileName);
				string extension = Path.GetExtension(destFileName);
				foreach (string text in Utility.GenerateFileNames(directoryName, fileNameWithoutExtension, extension))
				{
					if (!File.Exists(text))
					{
						File.Copy(sourceFileName, text);
						return text;
					}
				}
				return null;
			}
			default:
				throw new ArgumentException("Invalid enumeration value", "options");
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000A0D0 File Offset: 0x000082D0
		public static void SafeDeleteFile(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				File.Delete(path);
			}
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000A0E0 File Offset: 0x000082E0
		public static void SafeDispose<T>(ref T disposable) where T : IDisposable
		{
			IDisposable disposable2 = disposable;
			disposable = default(T);
			if (disposable2 != null)
			{
				disposable2.Dispose();
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000A10C File Offset: 0x0000830C
		public static void GeneratePropertyString(StringBuilder source, string propertyName, string value)
		{
			if (source.Length != 0)
			{
				source.Append(' ');
			}
			source.Append(propertyName);
			source.Append(": ");
			if (string.IsNullOrEmpty(value))
			{
				source.Append("<null>");
				return;
			}
			source.Append('"');
			source.Append(value);
			source.Append('"');
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000A170 File Offset: 0x00008370
		[Obsolete]
		public static string GenerateToString<T>(T @object) where T : struct
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (PropertyInfo propertyInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(", ");
				}
				object value = propertyInfo.GetValue(@object, null);
				string format = (value == null) ? "{0}: <null>" : "{0}: \"{1}\"";
				stringBuilder.AppendFormat(format, propertyInfo.Name, value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000A1F4 File Offset: 0x000083F4
		public static void CopyStream(Stream destination, Stream source)
		{
			destination.Position = 0L;
			if (source.CanSeek)
			{
				source.Position = 0L;
				destination.SetLength(source.Length);
			}
			byte[] array = new byte[4096];
			int num;
			do
			{
				num = source.Read(array, 0, array.Length);
				if (num != 0)
				{
					destination.Write(array, 0, num);
				}
			}
			while (array.Length == num);
			destination.Position = 0L;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000A258 File Offset: 0x00008458
		public static string HashStreamMD5(Stream stm)
		{
			stm.Position = 0L;
			StringBuilder stringBuilder = new StringBuilder();
			using (MD5 md = MD5.Create())
			{
				foreach (byte b in md.ComputeHash(stm))
				{
					stringBuilder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000A2D0 File Offset: 0x000084D0
		public static void EnsureDirectory(string path)
		{
			if (!path.EndsWith("\\", StringComparison.Ordinal))
			{
				path += "\\";
			}
			path = Path.GetDirectoryName(path);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000A304 File Offset: 0x00008504
		public static bool MemCmp(byte[] left, byte[] right, int cb)
		{
			GCHandle gchandle = GCHandle.Alloc(left, GCHandleType.Pinned);
			IntPtr left2 = gchandle.AddrOfPinnedObject();
			GCHandle gchandle2 = GCHandle.Alloc(right, GCHandleType.Pinned);
			IntPtr right2 = gchandle2.AddrOfPinnedObject();
			bool result = Utility._MemCmp(left2, right2, (long)cb);
			gchandle.Free();
			gchandle2.Free();
			return result;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000A348 File Offset: 0x00008548
		public static string UrlDecode(string url)
		{
			if (url == null)
			{
				return null;
			}
			Utility._UrlDecoder urlDecoder = new Utility._UrlDecoder(url.Length, Encoding.UTF8);
			int length = url.Length;
			for (int i = 0; i < length; i++)
			{
				char c = url[i];
				if (c == '+')
				{
					urlDecoder.AddByte(32);
				}
				else
				{
					if (c == '%' && i < length - 2)
					{
						if (url[i + 1] == 'u' && i < length - 5)
						{
							int num = Utility._HexToInt(url[i + 2]);
							int num2 = Utility._HexToInt(url[i + 3]);
							int num3 = Utility._HexToInt(url[i + 4]);
							int num4 = Utility._HexToInt(url[i + 5]);
							if (num >= 0 && num2 >= 0 && num3 >= 0 && num4 >= 0)
							{
								urlDecoder.AddChar((char)(num << 12 | num2 << 8 | num3 << 4 | num4));
								i += 5;
								goto IL_12D;
							}
						}
						else
						{
							int num5 = Utility._HexToInt(url[i + 1]);
							int num6 = Utility._HexToInt(url[i + 2]);
							if (num5 >= 0 && num6 >= 0)
							{
								urlDecoder.AddByte((byte)(num5 << 4 | num6));
								i += 2;
								goto IL_12D;
							}
						}
					}
					if ((c & 'ﾀ') == '\0')
					{
						urlDecoder.AddByte((byte)c);
					}
					else
					{
						urlDecoder.AddChar(c);
					}
				}
				IL_12D:;
			}
			return urlDecoder.GetString();
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000A494 File Offset: 0x00008694
		public static string UrlEncode(string url)
		{
			if (url == null)
			{
				return null;
			}
			byte[] array = Encoding.UTF8.GetBytes(url);
			bool flag = false;
			int num = 0;
			foreach (byte b in array)
			{
				if (b == 32)
				{
					flag = true;
				}
				else if (!Utility._UrlEncodeIsSafe(b))
				{
					num++;
					flag = true;
				}
			}
			if (flag)
			{
				byte[] array3 = new byte[array.Length + num * 2];
				int num2 = 0;
				foreach (byte b2 in array)
				{
					if (Utility._UrlEncodeIsSafe(b2))
					{
						array3[num2++] = b2;
					}
					else if (b2 == 32)
					{
						array3[num2++] = 43;
					}
					else
					{
						array3[num2++] = 37;
						array3[num2++] = Utility._IntToHex(b2 >> 4 & 15);
						array3[num2++] = Utility._IntToHex((int)(b2 & 15));
					}
				}
				array = array3;
			}
			return Encoding.ASCII.GetString(array);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000A58C File Offset: 0x0000878C
		private static bool _UrlEncodeIsSafe(byte b)
		{
			if (Utility._IsAsciiAlphaNumeric(b))
			{
				return true;
			}
			if (b != 33)
			{
				switch (b)
				{
				case 39:
				case 40:
				case 41:
				case 42:
				case 45:
				case 46:
					return true;
				case 43:
				case 44:
					break;
				default:
					if (b == 95)
					{
						return true;
					}
					break;
				}
				return false;
			}
			return true;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000A5DB File Offset: 0x000087DB
		private static bool _IsAsciiAlphaNumeric(byte b)
		{
			return (b >= 97 && b <= 122) || (b >= 65 && b <= 90) || (b >= 48 && b <= 57);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000A602 File Offset: 0x00008802
		private static byte _IntToHex(int n)
		{
			if (n <= 9)
			{
				return (byte)(n + 48);
			}
			return (byte)(n - 10 + 65);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000A617 File Offset: 0x00008817
		private static int _HexToInt(char h)
		{
			if (h >= '0' && h <= '9')
			{
				return (int)(h - '0');
			}
			if (h >= 'a' && h <= 'f')
			{
				return (int)(h - 'a' + '\n');
			}
			if (h >= 'A' && h <= 'F')
			{
				return (int)(h - 'A' + '\n');
			}
			return -1;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000A650 File Offset: 0x00008850
		public static string MakeValidFileName(string invalidPath)
		{
			return invalidPath.Replace('\\', '_').Replace('/', '_').Replace(':', '_').Replace('*', '_').Replace('?', '_').Replace('"', '_').Replace('<', '_').Replace('>', '_').Replace('|', '_');
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000A6AF File Offset: 0x000088AF
		public static IEnumerable<string> GenerateFileNames(string directory, string primaryFileName, string extension)
		{
			Verify.IsNeitherNullNorEmpty(directory, "directory");
			Verify.IsNeitherNullNorEmpty(primaryFileName, "primaryFileName");
			primaryFileName = Utility.MakeValidFileName(primaryFileName);
			int num;
			for (int i = 0; i <= 50; i = num)
			{
				if (i == 0)
				{
					yield return Path.Combine(directory, primaryFileName) + extension;
				}
				else if (40 >= i)
				{
					yield return string.Concat(new string[]
					{
						Path.Combine(directory, primaryFileName),
						" (",
						i.ToString(null),
						")",
						extension
					});
				}
				else
				{
					yield return string.Concat(new object[]
					{
						Path.Combine(directory, primaryFileName),
						" (",
						Utility._randomNumberGenerator.Next(41, 9999),
						")",
						extension
					});
				}
				num = i + 1;
			}
			yield break;
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000A6D0 File Offset: 0x000088D0
		public static bool TryFileMove(string sourceFileName, string destFileName)
		{
			if (!File.Exists(destFileName))
			{
				try
				{
					File.Move(sourceFileName, destFileName);
				}
				catch (IOException)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000A708 File Offset: 0x00008908
		public static void SafeDestroyIcon(ref IntPtr hicon)
		{
			IntPtr intPtr = hicon;
			hicon = IntPtr.Zero;
			if (IntPtr.Zero != intPtr)
			{
				NativeMethods.DestroyIcon(intPtr);
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000A734 File Offset: 0x00008934
		public static void SafeDeleteObject(ref IntPtr gdiObject)
		{
			IntPtr intPtr = gdiObject;
			gdiObject = IntPtr.Zero;
			if (IntPtr.Zero != intPtr)
			{
				NativeMethods.DeleteObject(intPtr);
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0000A760 File Offset: 0x00008960
		public static void SafeDestroyWindow(ref IntPtr hwnd)
		{
			IntPtr hwnd2 = hwnd;
			hwnd = IntPtr.Zero;
			if (NativeMethods.IsWindow(hwnd2))
			{
				NativeMethods.DestroyWindow(hwnd2);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000A788 File Offset: 0x00008988
		public static void SafeDisposeImage(ref IntPtr gdipImage)
		{
			IntPtr intPtr = gdipImage;
			gdipImage = IntPtr.Zero;
			if (IntPtr.Zero != intPtr)
			{
				NativeMethods.GdipDisposeImage(intPtr);
			}
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x0000A7B4 File Offset: 0x000089B4
		public static void SafeCoTaskMemFree(ref IntPtr ptr)
		{
			IntPtr intPtr = ptr;
			ptr = IntPtr.Zero;
			if (IntPtr.Zero != intPtr)
			{
				Marshal.FreeCoTaskMem(intPtr);
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0000A7E0 File Offset: 0x000089E0
		public static void SafeFreeHGlobal(ref IntPtr hglobal)
		{
			IntPtr intPtr = hglobal;
			hglobal = IntPtr.Zero;
			if (IntPtr.Zero != intPtr)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000A80C File Offset: 0x00008A0C
		public static void SafeRelease<T>(ref T comObject) where T : class
		{
			T t = comObject;
			comObject = default(T);
			if (t != null)
			{
				Marshal.ReleaseComObject(t);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000A83B File Offset: 0x00008A3B
		public static bool IsOSVistaOrNewer
		{
			get
			{
				return Utility._osVersion >= new Version(6, 0);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0000A84E File Offset: 0x00008A4E
		public static bool IsOSWindows7OrNewer
		{
			get
			{
				return Utility._osVersion >= new Version(6, 1);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000A861 File Offset: 0x00008A61
		public static bool IsPresentationFrameworkVersionLessThan4
		{
			get
			{
				return Utility._presentationFrameworkVersion < new Version(4, 0);
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0000A874 File Offset: 0x00008A74
		public static byte[] GetBytesFromBitmapSource(BitmapSource bmp)
		{
			int pixelWidth = bmp.PixelWidth;
			int pixelHeight = bmp.PixelHeight;
			int num = pixelWidth * ((bmp.Format.BitsPerPixel + 7) / 8);
			byte[] array = new byte[pixelHeight * num];
			bmp.CopyPixels(array, num, 0);
			return array;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0000A8B5 File Offset: 0x00008AB5
		public static BitmapSource GenerateBitmapSource(ImageSource img)
		{
			return Utility.GenerateBitmapSource(img, img.Width, img.Height);
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000A8CC File Offset: 0x00008ACC
		public static BitmapSource GenerateBitmapSource(ImageSource img, double renderWidth, double renderHeight)
		{
			DrawingVisual drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				drawingContext.DrawImage(img, new Rect(0.0, 0.0, renderWidth, renderHeight));
			}
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(drawingVisual);
			return renderTargetBitmap;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0000A94C File Offset: 0x00008B4C
		public static BitmapSource GenerateBitmapSource(UIElement element, double renderWidth, double renderHeight, bool performLayout)
		{
			if (performLayout)
			{
				element.Measure(new Size(renderWidth, renderHeight));
				element.Arrange(new Rect(new Size(renderWidth, renderHeight)));
			}
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)renderWidth, (int)renderHeight, 96.0, 96.0, PixelFormats.Pbgra32);
			DrawingVisual drawingVisual = new DrawingVisual();
			using (DrawingContext drawingContext = drawingVisual.RenderOpen())
			{
				drawingContext.DrawRectangle(new VisualBrush(element), null, new Rect(0.0, 0.0, renderWidth, renderHeight));
			}
			renderTargetBitmap.Render(drawingVisual);
			return renderTargetBitmap;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0000A9F4 File Offset: 0x00008BF4
		public static void SaveToPng(BitmapSource source, string fileName)
		{
			PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
			pngBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
			using (FileStream fileStream = File.Create(fileName))
			{
				pngBitmapEncoder.Save(fileStream);
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000AA44 File Offset: 0x00008C44
		private static int _GetBitDepth()
		{
			if (Utility.s_bitDepth == 0)
			{
				using (SafeDC desktop = SafeDC.GetDesktop())
				{
					Utility.s_bitDepth = NativeMethods.GetDeviceCaps(desktop, DeviceCap.BITSPIXEL) * NativeMethods.GetDeviceCaps(desktop, DeviceCap.PLANES);
				}
			}
			return Utility.s_bitDepth;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000AA98 File Offset: 0x00008C98
		public static BitmapFrame GetBestMatch(IList<BitmapFrame> frames, int width, int height)
		{
			return Utility._GetBestMatch(frames, Utility._GetBitDepth(), width, height);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0000AAA7 File Offset: 0x00008CA7
		private static int _MatchImage(BitmapFrame frame, int bitDepth, int width, int height, int bpp)
		{
			return 2 * Utility._WeightedAbs(bpp, bitDepth, false) + Utility._WeightedAbs(frame.PixelWidth, width, true) + Utility._WeightedAbs(frame.PixelHeight, height, true);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x0000AAD0 File Offset: 0x00008CD0
		private static int _WeightedAbs(int valueHave, int valueWant, bool fPunish)
		{
			int num = valueHave - valueWant;
			if (num < 0)
			{
				num = (fPunish ? -2 : -1) * num;
			}
			return num;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000AAF4 File Offset: 0x00008CF4
		private static BitmapFrame _GetBestMatch(IList<BitmapFrame> frames, int bitDepth, int width, int height)
		{
			int num = int.MaxValue;
			int num2 = 0;
			int index = 0;
			bool flag = frames[0].Decoder is IconBitmapDecoder;
			int num3 = 0;
			while (num3 < frames.Count && num != 0)
			{
				int num4 = flag ? frames[num3].Thumbnail.Format.BitsPerPixel : frames[num3].Format.BitsPerPixel;
				if (num4 == 0)
				{
					num4 = 8;
				}
				int num5 = Utility._MatchImage(frames[num3], bitDepth, width, height, num4);
				if (num5 < num)
				{
					index = num3;
					num2 = num4;
					num = num5;
				}
				else if (num5 == num && num2 < num4)
				{
					index = num3;
					num2 = num4;
				}
				num3++;
			}
			return frames[index];
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000ABB5 File Offset: 0x00008DB5
		public static int RGB(Color c)
		{
			return (int)c.B | (int)c.G << 8 | (int)c.R << 16;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000ABD3 File Offset: 0x00008DD3
		public static int AlphaRGB(Color c)
		{
			return (int)c.B | (int)c.G << 8 | (int)c.R << 16 | (int)c.A << 24;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000ABFC File Offset: 0x00008DFC
		public static Color ColorFromArgbDword(uint color)
		{
			return Color.FromArgb((byte)((color & 4278190080U) >> 24), (byte)((color & 16711680U) >> 16), (byte)((color & 65280U) >> 8), (byte)(color & 255U));
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000AC2C File Offset: 0x00008E2C
		public static bool AreImageSourcesEqual(ImageSource left, ImageSource right)
		{
			if (left == null)
			{
				return right == null;
			}
			if (right == null)
			{
				return false;
			}
			BitmapSource bmp = Utility.GenerateBitmapSource(left);
			BitmapSource bmp2 = Utility.GenerateBitmapSource(right);
			byte[] bytesFromBitmapSource = Utility.GetBytesFromBitmapSource(bmp);
			byte[] bytesFromBitmapSource2 = Utility.GetBytesFromBitmapSource(bmp2);
			return bytesFromBitmapSource.Length == bytesFromBitmapSource2.Length && Utility.MemCmp(bytesFromBitmapSource, bytesFromBitmapSource2, bytesFromBitmapSource.Length);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000AC74 File Offset: 0x00008E74
		public static IntPtr GenerateHICON(ImageSource image, Size dimensions)
		{
			if (image == null)
			{
				return IntPtr.Zero;
			}
			BitmapFrame bitmapFrame = image as BitmapFrame;
			if (bitmapFrame != null)
			{
				bitmapFrame = Utility.GetBestMatch(bitmapFrame.Decoder.Frames, (int)dimensions.Width, (int)dimensions.Height);
			}
			else
			{
				Rect rectangle = new Rect(0.0, 0.0, dimensions.Width, dimensions.Height);
				double num = dimensions.Width / dimensions.Height;
				double num2 = image.Width / image.Height;
				if (image.Width <= dimensions.Width && image.Height <= dimensions.Height)
				{
					rectangle = new Rect((dimensions.Width - image.Width) / 2.0, (dimensions.Height - image.Height) / 2.0, image.Width, image.Height);
				}
				else if (num > num2)
				{
					double num3 = image.Width / image.Height * dimensions.Width;
					rectangle = new Rect((dimensions.Width - num3) / 2.0, 0.0, num3, dimensions.Height);
				}
				else if (num < num2)
				{
					double num4 = image.Height / image.Width * dimensions.Height;
					rectangle = new Rect(0.0, (dimensions.Height - num4) / 2.0, dimensions.Width, num4);
				}
				DrawingVisual drawingVisual = new DrawingVisual();
				DrawingContext drawingContext = drawingVisual.RenderOpen();
				drawingContext.DrawImage(image, rectangle);
				drawingContext.Close();
				RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)dimensions.Width, (int)dimensions.Height, 96.0, 96.0, PixelFormats.Pbgra32);
				renderTargetBitmap.Render(drawingVisual);
				bitmapFrame = BitmapFrame.Create(renderTargetBitmap);
			}
			IntPtr result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				new PngBitmapEncoder
				{
					Frames = 
					{
						bitmapFrame
					}
				}.Save(memoryStream);
				using (ManagedIStream managedIStream = new ManagedIStream(memoryStream))
				{
					IntPtr zero = IntPtr.Zero;
					try
					{
						Status status = NativeMethods.GdipCreateBitmapFromStream(managedIStream, out zero);
						if (status != Status.Ok)
						{
							result = IntPtr.Zero;
						}
						else
						{
							IntPtr intPtr;
							status = NativeMethods.GdipCreateHICONFromBitmap(zero, out intPtr);
							if (status != Status.Ok)
							{
								result = IntPtr.Zero;
							}
							else
							{
								result = intPtr;
							}
						}
					}
					finally
					{
						Utility.SafeDisposeImage(ref zero);
					}
				}
			}
			return result;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000AEFC File Offset: 0x000090FC
		public static void AddDependencyPropertyChangeListener(object component, DependencyProperty property, EventHandler listener)
		{
			if (component == null)
			{
				return;
			}
			DependencyPropertyDescriptor.FromProperty(property, component.GetType()).AddValueChanged(component, listener);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000AF15 File Offset: 0x00009115
		public static void RemoveDependencyPropertyChangeListener(object component, DependencyProperty property, EventHandler listener)
		{
			if (component == null)
			{
				return;
			}
			DependencyPropertyDescriptor.FromProperty(property, component.GetType()).RemoveValueChanged(component, listener);
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000AF30 File Offset: 0x00009130
		public static bool IsNonNegative(this Thickness thickness)
		{
			return thickness.Top.IsFiniteAndNonNegative() && thickness.Left.IsFiniteAndNonNegative() && thickness.Bottom.IsFiniteAndNonNegative() && thickness.Right.IsFiniteAndNonNegative();
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000AF80 File Offset: 0x00009180
		public static bool IsValid(this CornerRadius cornerRadius)
		{
			return cornerRadius.TopLeft.IsFiniteAndNonNegative() && cornerRadius.TopRight.IsFiniteAndNonNegative() && cornerRadius.BottomLeft.IsFiniteAndNonNegative() && cornerRadius.BottomRight.IsFiniteAndNonNegative();
		}

		// Token: 0x040006BE RID: 1726
		private static readonly Random _randomNumberGenerator = new Random();

		// Token: 0x040006BF RID: 1727
		private static readonly Version _osVersion = Environment.OSVersion.Version;

		// Token: 0x040006C0 RID: 1728
		private static readonly Version _presentationFrameworkVersion = Assembly.GetAssembly(typeof(Window)).GetName().Version;

		// Token: 0x040006C1 RID: 1729
		private static int s_bitDepth;

		// Token: 0x020000D8 RID: 216
		private class _UrlDecoder
		{
			// Token: 0x06000450 RID: 1104 RVA: 0x0000C4F7 File Offset: 0x0000A6F7
			public _UrlDecoder(int size, Encoding encoding)
			{
				this._encoding = encoding;
				this._charBuffer = new char[size];
				this._byteBuffer = new byte[size];
			}

			// Token: 0x06000451 RID: 1105 RVA: 0x0000C520 File Offset: 0x0000A720
			public void AddByte(byte b)
			{
				byte[] byteBuffer = this._byteBuffer;
				int byteCount = this._byteCount;
				this._byteCount = byteCount + 1;
				byteBuffer[byteCount] = b;
			}

			// Token: 0x06000452 RID: 1106 RVA: 0x0000C548 File Offset: 0x0000A748
			public void AddChar(char ch)
			{
				this._FlushBytes();
				char[] charBuffer = this._charBuffer;
				int charCount = this._charCount;
				this._charCount = charCount + 1;
				charBuffer[charCount] = ch;
			}

			// Token: 0x06000453 RID: 1107 RVA: 0x0000C574 File Offset: 0x0000A774
			private void _FlushBytes()
			{
				if (this._byteCount > 0)
				{
					this._charCount += this._encoding.GetChars(this._byteBuffer, 0, this._byteCount, this._charBuffer, this._charCount);
					this._byteCount = 0;
				}
			}

			// Token: 0x06000454 RID: 1108 RVA: 0x0000C5C2 File Offset: 0x0000A7C2
			public string GetString()
			{
				this._FlushBytes();
				if (this._charCount > 0)
				{
					return new string(this._charBuffer, 0, this._charCount);
				}
				return "";
			}

			// Token: 0x04000724 RID: 1828
			private readonly Encoding _encoding;

			// Token: 0x04000725 RID: 1829
			private readonly char[] _charBuffer;

			// Token: 0x04000726 RID: 1830
			private readonly byte[] _byteBuffer;

			// Token: 0x04000727 RID: 1831
			private int _byteCount;

			// Token: 0x04000728 RID: 1832
			private int _charCount;
		}
	}
}
