using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Windows;

namespace MahApps.Metro
{
	// Token: 0x02000007 RID: 7
	public static class ThemeManager
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002230 File Offset: 0x00000430
		public static IEnumerable<Accent> Accents
		{
			get
			{
				if (ThemeManager._accents != null)
				{
					return ThemeManager._accents;
				}
				string[] array = new string[]
				{
					"Red",
					"Green",
					"Blue",
					"Purple",
					"Orange",
					"Lime",
					"Emerald",
					"Teal",
					"Cyan",
					"Cobalt",
					"Indigo",
					"Violet",
					"Pink",
					"Magenta",
					"Crimson",
					"Amber",
					"Yellow",
					"Brown",
					"Olive",
					"Steel",
					"Mauve",
					"Taupe",
					"Sienna"
				};
				ThemeManager._accents = new List<Accent>(array.Length);
				try
				{
					foreach (string text in array)
					{
						Uri resourceAddress = new Uri(string.Format("pack://application:,,,/MahApps.Metro;component/Styles/Accents/{0}.xaml", text));
						ThemeManager._accents.Add(new Accent(text, resourceAddress));
					}
				}
				catch (Exception innerException)
				{
					throw new MahAppsException("This exception happens because you are maybe running that code out of the scope of a WPF application. Most likely because you are testing your configuration inside a unit test.", innerException);
				}
				return ThemeManager._accents;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002384 File Offset: 0x00000584
		public static IEnumerable<AppTheme> AppThemes
		{
			get
			{
				if (ThemeManager._appThemes != null)
				{
					return ThemeManager._appThemes;
				}
				string[] array = new string[]
				{
					"BaseLight",
					"BaseDark"
				};
				ThemeManager._appThemes = new List<AppTheme>(array.Length);
				try
				{
					foreach (string text in array)
					{
						Uri resourceAddress = new Uri(string.Format("pack://application:,,,/MahApps.Metro;component/Styles/Accents/{0}.xaml", text));
						ThemeManager._appThemes.Add(new AppTheme(text, resourceAddress));
					}
				}
				catch (Exception innerException)
				{
					throw new MahAppsException("This exception happens because you are maybe running that code out of the scope of a WPF application. Most likely because you are testing your configuration inside a unit test.", innerException);
				}
				return ThemeManager._appThemes;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002420 File Offset: 0x00000620
		public static bool AddAccent(string name, Uri resourceAddress)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceAddress == null)
			{
				throw new ArgumentNullException("resourceAddress");
			}
			if (ThemeManager.GetAccent(name) != null)
			{
				return false;
			}
			ThemeManager._accents.Add(new Accent(name, resourceAddress));
			return true;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000246E File Offset: 0x0000066E
		public static bool AddAccent(string name, ResourceDictionary resourceDictionary)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceDictionary == null)
			{
				throw new ArgumentNullException("resourceDictionary");
			}
			if (ThemeManager.GetAccent(name) != null)
			{
				return false;
			}
			ThemeManager._accents.Add(new Accent(name, resourceDictionary));
			return true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000024AC File Offset: 0x000006AC
		public static bool AddAppTheme(string name, Uri resourceAddress)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceAddress == null)
			{
				throw new ArgumentNullException("resourceAddress");
			}
			if (ThemeManager.GetAppTheme(name) != null)
			{
				return false;
			}
			ThemeManager._appThemes.Add(new AppTheme(name, resourceAddress));
			return true;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000024FA File Offset: 0x000006FA
		public static bool AddAppTheme(string name, ResourceDictionary resourceDictionary)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceDictionary == null)
			{
				throw new ArgumentNullException("resourceDictionary");
			}
			if (ThemeManager.GetAppTheme(name) != null)
			{
				return false;
			}
			ThemeManager._appThemes.Add(new AppTheme(name, resourceDictionary));
			return true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002538 File Offset: 0x00000738
		public static AppTheme GetAppTheme(ResourceDictionary resources)
		{
			if (resources == null)
			{
				throw new ArgumentNullException("resources");
			}
			return ThemeManager.AppThemes.FirstOrDefault((AppTheme x) => ThemeManager.AreResourceDictionarySourcesEqual(x.Resources, resources));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000257C File Offset: 0x0000077C
		public static AppTheme GetAppTheme(string appThemeName)
		{
			if (appThemeName == null)
			{
				throw new ArgumentNullException("appThemeName");
			}
			return ThemeManager.AppThemes.FirstOrDefault((AppTheme x) => x.Name.Equals(appThemeName, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000025C0 File Offset: 0x000007C0
		public static AppTheme GetInverseAppTheme(AppTheme appTheme)
		{
			if (appTheme == null)
			{
				throw new ArgumentNullException("appTheme");
			}
			if (appTheme.Name.EndsWith("dark", StringComparison.OrdinalIgnoreCase))
			{
				return ThemeManager.GetAppTheme(appTheme.Name.ToLower().Replace("dark", "light"));
			}
			if (appTheme.Name.EndsWith("light", StringComparison.OrdinalIgnoreCase))
			{
				return ThemeManager.GetAppTheme(appTheme.Name.ToLower().Replace("light", "dark"));
			}
			return null;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002644 File Offset: 0x00000844
		public static Accent GetAccent(string accentName)
		{
			if (accentName == null)
			{
				throw new ArgumentNullException("accentName");
			}
			return ThemeManager.Accents.FirstOrDefault((Accent x) => x.Name.Equals(accentName, StringComparison.OrdinalIgnoreCase));
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002688 File Offset: 0x00000888
		public static Accent GetAccent(ResourceDictionary resources)
		{
			if (resources == null)
			{
				throw new ArgumentNullException("resources");
			}
			Accent accent = ThemeManager.Accents.FirstOrDefault((Accent x) => ThemeManager.AreResourceDictionarySourcesEqual(x.Resources, resources));
			if (accent != null)
			{
				return accent;
			}
			if (resources.Source == null && ThemeManager.IsAccentDictionary(resources))
			{
				return new Accent
				{
					Name = "Runtime accent",
					Resources = resources
				};
			}
			return null;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002710 File Offset: 0x00000910
		public static bool IsAccentDictionary(ResourceDictionary resources)
		{
			if (resources == null)
			{
				throw new ArgumentNullException("resources");
			}
			using (List<string>.Enumerator enumerator = new List<string>(new string[]
			{
				"HighlightColor",
				"AccentBaseColor",
				"AccentColor",
				"AccentColor2",
				"AccentColor3",
				"AccentColor4",
				"HighlightBrush",
				"AccentBaseColorBrush",
				"AccentColorBrush",
				"AccentColorBrush2",
				"AccentColorBrush3",
				"AccentColorBrush4"
			}).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string styleKey = enumerator.Current;
					if (!(from object resourceKey in resources.Keys
					select resourceKey as string).Any((string keyAsString) => string.Equals(keyAsString, styleKey)))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002828 File Offset: 0x00000A28
		public static object GetResourceFromAppStyle(Window window, string key)
		{
			Tuple<AppTheme, Accent> tuple = (window != null) ? ThemeManager.DetectAppStyle(window) : ThemeManager.DetectAppStyle(Application.Current);
			if (tuple == null && window != null)
			{
				tuple = ThemeManager.DetectAppStyle(Application.Current);
			}
			if (tuple == null)
			{
				return null;
			}
			object result = tuple.Item1.Resources[key];
			object obj = tuple.Item2.Resources[key];
			if (obj != null)
			{
				return obj;
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000288C File Offset: 0x00000A8C
		[SecurityCritical]
		public static void ChangeAppTheme(Application app, string themeName)
		{
			if (app == null)
			{
				throw new ArgumentNullException("app");
			}
			if (themeName == null)
			{
				throw new ArgumentNullException("themeName");
			}
			Tuple<AppTheme, Accent> tuple = ThemeManager.DetectAppStyle(app);
			AppTheme appTheme;
			if ((appTheme = ThemeManager.GetAppTheme(themeName)) != null)
			{
				ThemeManager.ChangeAppStyle(app.Resources, tuple, tuple.Item2, appTheme);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000028DC File Offset: 0x00000ADC
		[SecurityCritical]
		public static void ChangeAppTheme(Window window, string themeName)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (themeName == null)
			{
				throw new ArgumentNullException("themeName");
			}
			Tuple<AppTheme, Accent> tuple = ThemeManager.DetectAppStyle(window);
			AppTheme appTheme;
			if ((appTheme = ThemeManager.GetAppTheme(themeName)) != null)
			{
				ThemeManager.ChangeAppStyle(window.Resources, tuple, tuple.Item2, appTheme);
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000292C File Offset: 0x00000B2C
		[SecurityCritical]
		public static void ChangeAppStyle(Application app, Accent newAccent, AppTheme newTheme)
		{
			if (app == null)
			{
				throw new ArgumentNullException("app");
			}
			if (newAccent == null)
			{
				throw new ArgumentNullException("newAccent");
			}
			if (newTheme == null)
			{
				throw new ArgumentNullException("newTheme");
			}
			Tuple<AppTheme, Accent> oldThemeInfo = ThemeManager.DetectAppStyle(app);
			ThemeManager.ChangeAppStyle(app.Resources, oldThemeInfo, newAccent, newTheme);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002978 File Offset: 0x00000B78
		[SecurityCritical]
		public static void ChangeAppStyle(Window window, Accent newAccent, AppTheme newTheme)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (newAccent == null)
			{
				throw new ArgumentNullException("newAccent");
			}
			if (newTheme == null)
			{
				throw new ArgumentNullException("newTheme");
			}
			Tuple<AppTheme, Accent> oldThemeInfo = ThemeManager.DetectAppStyle(window);
			ThemeManager.ChangeAppStyle(window.Resources, oldThemeInfo, newAccent, newTheme);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000029C4 File Offset: 0x00000BC4
		[SecurityCritical]
		private static void ChangeAppStyle(ResourceDictionary resources, Tuple<AppTheme, Accent> oldThemeInfo, Accent newAccent, AppTheme newTheme)
		{
			bool flag = false;
			if (oldThemeInfo != null)
			{
				Accent oldAccent = oldThemeInfo.Item2;
				if (oldAccent != null && oldAccent.Name != newAccent.Name)
				{
					ResourceDictionary resourceDictionary = resources.MergedDictionaries.FirstOrDefault((ResourceDictionary d) => ThemeManager.AreResourceDictionarySourcesEqual(d, oldAccent.Resources));
					if (resourceDictionary != null)
					{
						resources.MergedDictionaries.Remove(resourceDictionary);
					}
					resources.MergedDictionaries.Add(newAccent.Resources);
					flag = true;
				}
				AppTheme oldTheme = oldThemeInfo.Item1;
				if (oldTheme != null && oldTheme != newTheme)
				{
					ResourceDictionary resourceDictionary2 = resources.MergedDictionaries.FirstOrDefault((ResourceDictionary d) => ThemeManager.AreResourceDictionarySourcesEqual(d, oldTheme.Resources));
					if (resourceDictionary2 != null)
					{
						resources.MergedDictionaries.Remove(resourceDictionary2);
					}
					resources.MergedDictionaries.Add(newTheme.Resources);
					flag = true;
				}
			}
			else
			{
				ThemeManager.ChangeAppStyle(resources, newAccent, newTheme);
				flag = true;
			}
			if (flag)
			{
				ThemeManager.OnThemeChanged(newAccent, newTheme);
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002AB4 File Offset: 0x00000CB4
		[SecurityCritical]
		public static void ChangeAppStyle(ResourceDictionary resources, Accent newAccent, AppTheme newTheme)
		{
			if (resources == null)
			{
				throw new ArgumentNullException("resources");
			}
			if (newAccent == null)
			{
				throw new ArgumentNullException("newAccent");
			}
			if (newTheme == null)
			{
				throw new ArgumentNullException("newTheme");
			}
			ThemeManager.ApplyResourceDictionary(newAccent.Resources, resources);
			ThemeManager.ApplyResourceDictionary(newTheme.Resources, resources);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002B04 File Offset: 0x00000D04
		[SecurityCritical]
		private static void ApplyResourceDictionary(ResourceDictionary newRd, ResourceDictionary oldRd)
		{
			oldRd.BeginInit();
			foreach (object obj in newRd)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (oldRd.Contains(dictionaryEntry.Key))
				{
					oldRd.Remove(dictionaryEntry.Key);
				}
				oldRd.Add(dictionaryEntry.Key, dictionaryEntry.Value);
			}
			oldRd.EndInit();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002B90 File Offset: 0x00000D90
		internal static void CopyResource(ResourceDictionary fromRD, ResourceDictionary toRD)
		{
			if (fromRD == null)
			{
				throw new ArgumentNullException("fromRD");
			}
			if (toRD == null)
			{
				throw new ArgumentNullException("toRD");
			}
			ThemeManager.ApplyResourceDictionary(fromRD, toRD);
			foreach (ResourceDictionary fromRD2 in fromRD.MergedDictionaries)
			{
				ThemeManager.CopyResource(fromRD2, toRD);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002C00 File Offset: 0x00000E00
		public static Tuple<AppTheme, Accent> DetectAppStyle()
		{
			try
			{
				Tuple<AppTheme, Accent> tuple = ThemeManager.DetectAppStyle(Application.Current.MainWindow);
				if (tuple != null)
				{
					return tuple;
				}
			}
			catch (Exception)
			{
			}
			return ThemeManager.DetectAppStyle(Application.Current);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002C48 File Offset: 0x00000E48
		public static Tuple<AppTheme, Accent> DetectAppStyle(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			Tuple<AppTheme, Accent> tuple = ThemeManager.DetectAppStyle(window.Resources);
			if (tuple == null)
			{
				tuple = ThemeManager.DetectAppStyle(Application.Current.Resources);
			}
			return tuple;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C83 File Offset: 0x00000E83
		public static Tuple<AppTheme, Accent> DetectAppStyle(Application app)
		{
			if (app == null)
			{
				throw new ArgumentNullException("app");
			}
			return ThemeManager.DetectAppStyle(app.Resources);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002CA0 File Offset: 0x00000EA0
		private static Tuple<AppTheme, Accent> DetectAppStyle(ResourceDictionary resources)
		{
			if (resources == null)
			{
				throw new ArgumentNullException("resources");
			}
			AppTheme presetTheme = null;
			Tuple<AppTheme, Accent> tuple = null;
			if (ThemeManager.DetectThemeFromResources(ref presetTheme, resources) && ThemeManager.GetThemeFromResources(presetTheme, resources, ref tuple))
			{
				return new Tuple<AppTheme, Accent>(tuple.Item1, tuple.Item2);
			}
			return null;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002CE7 File Offset: 0x00000EE7
		internal static bool DetectThemeFromAppResources(out AppTheme detectedTheme)
		{
			detectedTheme = null;
			return ThemeManager.DetectThemeFromResources(ref detectedTheme, Application.Current.Resources);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002CFC File Offset: 0x00000EFC
		private static bool DetectThemeFromResources(ref AppTheme detectedTheme, ResourceDictionary dict)
		{
			IEnumerator<ResourceDictionary> enumerator = dict.MergedDictionaries.Reverse<ResourceDictionary>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ResourceDictionary resourceDictionary = enumerator.Current;
				AppTheme appTheme;
				if ((appTheme = ThemeManager.GetAppTheme(resourceDictionary)) != null)
				{
					detectedTheme = appTheme;
					enumerator.Dispose();
					return true;
				}
				if (ThemeManager.DetectThemeFromResources(ref detectedTheme, resourceDictionary))
				{
					return true;
				}
			}
			enumerator.Dispose();
			return false;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002D54 File Offset: 0x00000F54
		internal static bool GetThemeFromResources(AppTheme presetTheme, ResourceDictionary dict, ref Tuple<AppTheme, Accent> detectedAccentTheme)
		{
			Accent accent;
			if ((accent = ThemeManager.GetAccent(dict)) != null)
			{
				detectedAccentTheme = Tuple.Create<AppTheme, Accent>(presetTheme, accent);
				return true;
			}
			foreach (ResourceDictionary dict2 in dict.MergedDictionaries.Reverse<ResourceDictionary>())
			{
				if (ThemeManager.GetThemeFromResources(presetTheme, dict2, ref detectedAccentTheme))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000033 RID: 51 RVA: 0x00002DCC File Offset: 0x00000FCC
		// (remove) Token: 0x06000034 RID: 52 RVA: 0x00002E00 File Offset: 0x00001000
		public static event EventHandler<OnThemeChangedEventArgs> IsThemeChanged;

		// Token: 0x06000035 RID: 53 RVA: 0x00002E33 File Offset: 0x00001033
		[SecurityCritical]
		private static void OnThemeChanged(Accent newAccent, AppTheme newTheme)
		{
			EventHandler<OnThemeChangedEventArgs> isThemeChanged = ThemeManager.IsThemeChanged;
			if (isThemeChanged == null)
			{
				return;
			}
			isThemeChanged(Application.Current, new OnThemeChangedEventArgs(newTheme, newAccent));
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002E50 File Offset: 0x00001050
		private static bool AreResourceDictionarySourcesEqual(ResourceDictionary first, ResourceDictionary second)
		{
			if (first == null || second == null)
			{
				return false;
			}
			if (first.Source == null || second.Source == null)
			{
				try
				{
					foreach (object key in first.Keys)
					{
						if (!second.Contains(key) || !object.Equals(first[key], second[key]))
						{
							return false;
						}
					}
				}
				catch (Exception)
				{
					return false;
				}
				return true;
			}
			return Uri.Compare(first.Source, second.Source, UriComponents.Host | UriComponents.Path, UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase) == 0;
		}

		// Token: 0x04000006 RID: 6
		private static IList<Accent> _accents;

		// Token: 0x04000007 RID: 7
		private static IList<AppTheme> _appThemes;
	}
}
