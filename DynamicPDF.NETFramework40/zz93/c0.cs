using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x02000087 RID: 135
	internal class c0
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x00056880 File Offset: 0x00055880
		internal c0()
		{
			if (c0.b == null)
			{
				c0.b = new Hashtable();
				c0.b();
			}
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000568C0 File Offset: 0x000558C0
		internal c0(Hashtable A_0, string A_1)
		{
			if (c0.b == null)
			{
				c0.b = new Hashtable();
				c0.b();
			}
			this.a(A_0, A_1);
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x00056908 File Offset: 0x00055908
		internal string a(byte[] A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < A_0.Length; i++)
			{
				stringBuilder.Append((char)this.c[(int)A_0[i]]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0005694C File Offset: 0x0005594C
		internal string a(string A_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < A_0.Length; i += 2)
			{
				int num;
				if (A_0.Length > 2)
				{
					num = Convert.ToInt32(A_0.Substring(i, 2), 16);
				}
				else
				{
					num = Convert.ToInt32(A_0, 16);
				}
				stringBuilder.Append((char)this.c[num]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000569C0 File Offset: 0x000559C0
		internal char a(byte A_0)
		{
			return (char)this.c[(int)A_0];
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000569DC File Offset: 0x000559DC
		internal int b(string A_0)
		{
			return c0.b.ContainsKey(A_0) ? ((int)c0.b[A_0]) : -1;
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x00056A10 File Offset: 0x00055A10
		private void a(Hashtable A_0, string A_1)
		{
			this.c = new int[c0.d.Length];
			if (A_1 != null && A_1.Equals("MacRomanEncoding"))
			{
				Array.Copy(c0.e, this.c, c0.e.Length);
			}
			else
			{
				Array.Copy(c0.d, this.c, c0.d.Length);
			}
			foreach (object obj in A_0)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				if (c0.b.ContainsKey(dictionaryEntry.Value))
				{
					int num = (int)dictionaryEntry.Key;
					this.c[num] = (int)c0.b[dictionaryEntry.Value];
				}
				else if (((string)dictionaryEntry.Value).StartsWith("#"))
				{
					int num = (int)dictionaryEntry.Key;
					string text = ((string)dictionaryEntry.Value).Substring(1);
					this.c[num] = Convert.ToInt32(text, 16);
				}
				else if (((string)dictionaryEntry.Value).StartsWith("uni"))
				{
					int num = (int)dictionaryEntry.Key;
					string text = ((string)dictionaryEntry.Value).Substring(3, 4);
					if (text[0] > '/' && text[0] < ':')
					{
						this.c[num] = Convert.ToInt32(text, 16);
					}
				}
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00056BEC File Offset: 0x00055BEC
		private static void b()
		{
			c0.b.Add("space", 32);
			c0.b.Add("exclam", 33);
			c0.b.Add("!", 33);
			c0.b.Add("quotedbl", 34);
			c0.b.Add("\"", 34);
			c0.b.Add("numbersign", 35);
			c0.b.Add("dollar", 36);
			c0.b.Add("$", 36);
			c0.b.Add("percent", 37);
			c0.b.Add("%", 37);
			c0.b.Add("ampersand", 38);
			c0.b.Add("&", 38);
			c0.b.Add("parenleft", 40);
			c0.b.Add("(", 40);
			c0.b.Add("parenright", 41);
			c0.b.Add(")", 41);
			c0.b.Add("asterisk", 42);
			c0.b.Add("*", 42);
			c0.b.Add("plus", 43);
			c0.b.Add("+", 43);
			c0.b.Add("comma", 44);
			c0.b.Add(",", 44);
			c0.b.Add("hyphen", 45);
			c0.b.Add("period", 46);
			c0.b.Add(".", 46);
			c0.b.Add("slash", 47);
			c0.b.Add("/", 47);
			c0.b.Add("zero", 48);
			c0.b.Add("0", 48);
			c0.b.Add("one", 49);
			c0.b.Add("1", 49);
			c0.b.Add("two", 50);
			c0.b.Add("2", 50);
			c0.b.Add("three", 51);
			c0.b.Add("3", 51);
			c0.b.Add("four", 52);
			c0.b.Add("4", 52);
			c0.b.Add("five", 53);
			c0.b.Add("5", 53);
			c0.b.Add("six", 54);
			c0.b.Add("6", 54);
			c0.b.Add("seven", 55);
			c0.b.Add("7", 55);
			c0.b.Add("eight", 56);
			c0.b.Add("8", 56);
			c0.b.Add("nine", 57);
			c0.b.Add("9", 57);
			c0.b.Add("colon", 58);
			c0.b.Add(":", 58);
			c0.b.Add("semicolon", 59);
			c0.b.Add(";", 59);
			c0.b.Add("less", 60);
			c0.b.Add("lessthan", 60);
			c0.b.Add("<", 60);
			c0.b.Add("equal", 61);
			c0.b.Add("=", 61);
			c0.b.Add("greater", 62);
			c0.b.Add("greaterthan", 62);
			c0.b.Add(">", 62);
			c0.b.Add("question", 63);
			c0.b.Add("?", 63);
			c0.b.Add("at", 64);
			c0.b.Add("@", 64);
			c0.b.Add("A", 65);
			c0.b.Add("B", 66);
			c0.b.Add("C", 67);
			c0.b.Add("D", 68);
			c0.b.Add("E", 69);
			c0.b.Add("F", 70);
			c0.b.Add("G", 71);
			c0.b.Add("H", 72);
			c0.b.Add("I", 73);
			c0.b.Add("J", 74);
			c0.b.Add("K", 75);
			c0.b.Add("L", 76);
			c0.b.Add("M", 77);
			c0.b.Add("N", 78);
			c0.b.Add("O", 79);
			c0.b.Add("P", 80);
			c0.b.Add("Q", 81);
			c0.b.Add("R", 82);
			c0.b.Add("S", 83);
			c0.b.Add("T", 84);
			c0.b.Add("U", 85);
			c0.b.Add("V", 86);
			c0.b.Add("W", 87);
			c0.b.Add("X", 88);
			c0.b.Add("Y", 89);
			c0.b.Add("Z", 90);
			c0.b.Add("bracketleft", 91);
			c0.b.Add("[", 91);
			c0.b.Add("backslash", 92);
			c0.b.Add("\\", 92);
			c0.b.Add("bracketright", 93);
			c0.b.Add("]", 93);
			c0.b.Add("asciicircum", 94);
			c0.b.Add("underscore", 95);
			c0.b.Add("_", 95);
			c0.b.Add("a", 97);
			c0.b.Add("b", 98);
			c0.b.Add("c", 99);
			c0.b.Add("d", 100);
			c0.b.Add("e", 101);
			c0.b.Add("f", 102);
			c0.b.Add("g", 103);
			c0.b.Add("h", 104);
			c0.b.Add("i", 105);
			c0.b.Add("j", 106);
			c0.b.Add("k", 107);
			c0.b.Add("l", 108);
			c0.b.Add("m", 109);
			c0.b.Add("n", 110);
			c0.b.Add("o", 111);
			c0.b.Add("p", 112);
			c0.b.Add("q", 113);
			c0.b.Add("r", 114);
			c0.b.Add("s", 115);
			c0.b.Add("t", 116);
			c0.b.Add("u", 117);
			c0.b.Add("v", 118);
			c0.b.Add("w", 119);
			c0.b.Add("x", 120);
			c0.b.Add("y", 121);
			c0.b.Add("z", 122);
			c0.b.Add("braceleft", 123);
			c0.b.Add("{", 123);
			c0.b.Add("bar", 124);
			c0.b.Add("|", 124);
			c0.b.Add("braceright", 125);
			c0.b.Add("}", 125);
			c0.b.Add("asciitilde", 126);
			c0.b.Add("~", 126);
			c0.b.Add(".notdef", 61470);
			c0.b.Add("quotesingle", 39);
			c0.b.Add("'", 39);
			c0.b.Add("grave", 96);
			c0.b.Add("exclamdown", 161);
			c0.b.Add("iexcl", 161);
			c0.b.Add("cent", 162);
			c0.b.Add("pound", 163);
			c0.b.Add("sterling", 163);
			c0.b.Add("curren", 164);
			c0.b.Add("currency", 164);
			c0.b.Add("yen", 165);
			c0.b.Add("brvbar", 166);
			c0.b.Add("brkbar", 166);
			c0.b.Add("brokenbar", 166);
			c0.b.Add("sect", 167);
			c0.b.Add("section", 167);
			c0.b.Add("uml", 168);
			c0.b.Add("die", 168);
			c0.b.Add("diaeresis", 168);
			c0.b.Add("umlaut", 168);
			c0.b.Add("copy", 169);
			c0.b.Add("copyright", 169);
			c0.b.Add("ordf", 170);
			c0.b.Add("ordfeminine", 170);
			c0.b.Add("laquo", 171);
			c0.b.Add("guillemotleft", 171);
			c0.b.Add("not", 172);
			c0.b.Add("logicalnot", 172);
			c0.b.Add("shy", 173);
			c0.b.Add("reg", 174);
			c0.b.Add("registered", 174);
			c0.b.Add("macr", 175);
			c0.b.Add("hibar", 175);
			c0.b.Add("macron", 175);
			c0.b.Add("accent", 175);
			c0.b.Add("deg", 176);
			c0.b.Add("degree", 176);
			c0.b.Add("plusmn", 177);
			c0.b.Add("plusminus", 177);
			c0.b.Add("sup2", 178);
			c0.b.Add("twosuperior", 178);
			c0.b.Add("sup3", 179);
			c0.b.Add("threesuperior", 179);
			c0.b.Add("acute", 180);
			c0.b.Add("acuteaccent", 180);
			c0.b.Add("micro", 181);
			c0.b.Add("para", 182);
			c0.b.Add("paragraph", 182);
			c0.b.Add("pilcrow", 182);
			c0.b.Add("middot", 183);
			c0.b.Add("periodcentered", 183);
			c0.b.Add("cedil", 184);
			c0.b.Add("cedilla", 184);
			c0.b.Add("Cedilla", 184);
			c0.b.Add("sup1", 185);
			c0.b.Add("onesuperior", 185);
			c0.b.Add("ordm", 186);
			c0.b.Add("ordmasculine", 186);
			c0.b.Add("raquo", 187);
			c0.b.Add("guillemotright", 187);
			c0.b.Add("frac14", 188);
			c0.b.Add("onequarter", 188);
			c0.b.Add("frac12", 189);
			c0.b.Add("onehalf", 189);
			c0.b.Add("frac34", 190);
			c0.b.Add("threequarters", 190);
			c0.b.Add("iquest", 191);
			c0.b.Add("questiondown", 191);
			c0.b.Add("Agrave", 192);
			c0.b.Add("Aacute", 193);
			c0.b.Add("Acirc", 194);
			c0.b.Add("Acircumflex", 194);
			c0.b.Add("Atilde", 195);
			c0.b.Add("Auml", 196);
			c0.b.Add("Adiaeresis", 196);
			c0.b.Add("Aumlaut", 196);
			c0.b.Add("Aring", 197);
			c0.b.Add("AElig", 198);
			c0.b.Add("AE", 198);
			c0.b.Add("AEligature", 198);
			c0.b.Add("Ccedil", 199);
			c0.b.Add("Ccedilla", 199);
			c0.b.Add("Egrave", 200);
			c0.b.Add("Eacute", 201);
			c0.b.Add("Ecirc", 202);
			c0.b.Add("Ecircumflex", 202);
			c0.b.Add("Euml", 203);
			c0.b.Add("Ediaeresis", 203);
			c0.b.Add("Eumlaut", 203);
			c0.b.Add("Igrave", 204);
			c0.b.Add("Iacute", 205);
			c0.b.Add("Icirc", 206);
			c0.b.Add("Icircumflex", 206);
			c0.b.Add("Iuml", 207);
			c0.b.Add("Idiaeresis", 207);
			c0.b.Add("Iumlaut", 207);
			c0.b.Add("ETH", 208);
			c0.b.Add("Eth", 208);
			c0.b.Add("ETHIcelandic", 208);
			c0.b.Add("Ntilde", 209);
			c0.b.Add("Ograve", 210);
			c0.b.Add("Oacute", 211);
			c0.b.Add("Ocirc", 212);
			c0.b.Add("Ocircumflex", 212);
			c0.b.Add("Otilde", 213);
			c0.b.Add("Ouml", 214);
			c0.b.Add("Odiaeresis", 214);
			c0.b.Add("Oumlaut", 214);
			c0.b.Add("times", 215);
			c0.b.Add("multiply", 215);
			c0.b.Add("Oslash", 216);
			c0.b.Add("ostroke", 216);
			c0.b.Add("Ugrave", 217);
			c0.b.Add("Uacute", 218);
			c0.b.Add("Ucirc", 219);
			c0.b.Add("Ucircumflex", 219);
			c0.b.Add("Uuml", 220);
			c0.b.Add("Udiaeresis", 220);
			c0.b.Add("Uumlaut", 220);
			c0.b.Add("Yacute", 221);
			c0.b.Add("Thorn", 222);
			c0.b.Add("ThornIcelandic", 222);
			c0.b.Add("szlig", 223);
			c0.b.Add("sharps", 223);
			c0.b.Add("germandbls", 223);
			c0.b.Add("agrave", 224);
			c0.b.Add("aacute", 225);
			c0.b.Add("acirc", 226);
			c0.b.Add("acircumflex", 226);
			c0.b.Add("atilde", 227);
			c0.b.Add("auml", 228);
			c0.b.Add("adiaeresis", 228);
			c0.b.Add("aumlaut", 228);
			c0.b.Add("aring", 229);
			c0.b.Add("aringaccent", 229);
			c0.b.Add("aelig", 230);
			c0.b.Add("ae", 230);
			c0.b.Add("aeligature", 230);
			c0.b.Add("ccedil", 231);
			c0.b.Add("ccedilla", 231);
			c0.b.Add("egrave", 232);
			c0.b.Add("eacute", 233);
			c0.b.Add("ecirc", 234);
			c0.b.Add("ecircumflex", 234);
			c0.b.Add("euml", 235);
			c0.b.Add("ediaeresis", 235);
			c0.b.Add("eumlaut", 235);
			c0.b.Add("igrave", 236);
			c0.b.Add("iacute", 237);
			c0.b.Add("icirc", 238);
			c0.b.Add("icircumflex", 238);
			c0.b.Add("iuml", 239);
			c0.b.Add("idiaeresis", 239);
			c0.b.Add("iumlaut", 239);
			c0.b.Add("eth", 240);
			c0.b.Add("ethIcelandic", 240);
			c0.b.Add("ntilde", 241);
			c0.b.Add("ograve", 242);
			c0.b.Add("oacute", 243);
			c0.b.Add("ocirc", 244);
			c0.b.Add("ocircumflex", 244);
			c0.b.Add("otilde", 245);
			c0.b.Add("ouml", 246);
			c0.b.Add("odiaeresis", 246);
			c0.b.Add("oumlaut", 246);
			c0.b.Add("divide", 247);
			c0.b.Add("oslash", 248);
			c0.b.Add("ugrave", 249);
			c0.b.Add("uacute", 250);
			c0.b.Add("ucirc", 251);
			c0.b.Add("ucircumflex", 251);
			c0.b.Add("uuml", 252);
			c0.b.Add("udiaeresis", 252);
			c0.b.Add("uumlaut", 252);
			c0.b.Add("yacute", 253);
			c0.b.Add("thorn", 254);
			c0.b.Add("thornIcelandic", 254);
			c0.b.Add("yuml", 255);
			c0.b.Add("ydiaeresis", 255);
			c0.b.Add("yumlaut", 255);
			c0.b.Add("nbsp", 160);
			c0.b.Add("tilde", 152);
			c0.b.Add("Amacron", 256);
			c0.b.Add("amacron", 257);
			c0.b.Add("Abreve", 258);
			c0.b.Add("abreve", 259);
			c0.b.Add("Aogonek", 260);
			c0.b.Add("aogonek", 261);
			c0.b.Add("Cacute", 262);
			c0.b.Add("cacute", 263);
			c0.b.Add("Ccircumflex", 264);
			c0.b.Add("ccircumflex", 265);
			c0.b.Add("Cdotaccent", 266);
			c0.b.Add("cdotaccent", 267);
			c0.b.Add("Ccaron", 268);
			c0.b.Add("ccaron", 269);
			c0.b.Add("Dcaron", 270);
			c0.b.Add("dcaron", 271);
			c0.b.Add("Dcroat", 272);
			c0.b.Add("dcroat", 273);
			c0.b.Add("Emacron", 274);
			c0.b.Add("emacron", 275);
			c0.b.Add("Ebreve", 276);
			c0.b.Add("ebreve", 277);
			c0.b.Add("Edotaccent", 278);
			c0.b.Add("edotaccent", 279);
			c0.b.Add("Eogonek", 280);
			c0.b.Add("eogonek", 281);
			c0.b.Add("Ecaron", 282);
			c0.b.Add("ecaron", 283);
			c0.b.Add("Gcircumflex", 284);
			c0.b.Add("gcircumflex", 285);
			c0.b.Add("Gbreve", 286);
			c0.b.Add("gbreve", 287);
			c0.b.Add("Gdotaccent", 288);
			c0.b.Add("gdotaccent", 289);
			c0.b.Add("Gcommaaccent", 290);
			c0.b.Add("Gcedilla", 290);
			c0.b.Add("gcommaaccent", 291);
			c0.b.Add("gcedilla", 291);
			c0.b.Add("Hcircumflex", 292);
			c0.b.Add("hcircumflex", 293);
			c0.b.Add("Hstroke", 294);
			c0.b.Add("hstroke", 295);
			c0.b.Add("Itilde", 296);
			c0.b.Add("itilde", 297);
			c0.b.Add("Imacron", 298);
			c0.b.Add("imacron", 299);
			c0.b.Add("Ibreve", 300);
			c0.b.Add("ibreve", 301);
			c0.b.Add("Iogonek", 302);
			c0.b.Add("iogonek", 303);
			c0.b.Add("Idotaccent", 304);
			c0.b.Add("dotlessi", 305);
			c0.b.Add("IJ", 306);
			c0.b.Add("ij", 307);
			c0.b.Add("Jcircumflex", 308);
			c0.b.Add("jcircumflex", 309);
			c0.b.Add("Kcommaaccent", 310);
			c0.b.Add("Kcedilla", 310);
			c0.b.Add("kcommaaccent", 311);
			c0.b.Add("kcedilla", 311);
			c0.b.Add("kra", 312);
			c0.b.Add("Lacute", 313);
			c0.b.Add("lacute", 314);
			c0.b.Add("Lcommaaccent", 315);
			c0.b.Add("Lcedilla", 315);
			c0.b.Add("lcommaaccent", 316);
			c0.b.Add("lcedilla", 316);
			c0.b.Add("Lcaron", 317);
			c0.b.Add("lcaron", 318);
			c0.b.Add("Lslash", 321);
			c0.b.Add("Lstroke", 321);
			c0.b.Add("lslash", 322);
			c0.b.Add("lstroke", 322);
			c0.b.Add("Nacute", 323);
			c0.b.Add("nacute", 324);
			c0.b.Add("Ncommaaccent", 325);
			c0.b.Add("Ncedilla", 325);
			c0.b.Add("ncommaaccent", 326);
			c0.b.Add("ncedilla", 326);
			c0.b.Add("Ncaron", 327);
			c0.b.Add("ncaron", 328);
			c0.b.Add("Eng", 330);
			c0.b.Add("eng", 331);
			c0.b.Add("Omacron", 332);
			c0.b.Add("omacron", 333);
			c0.b.Add("Obreve", 334);
			c0.b.Add("obreve", 335);
			c0.b.Add("Ohungarumlaut", 336);
			c0.b.Add("ohungarumlaut", 337);
			c0.b.Add("OE", 338);
			c0.b.Add("oe", 339);
			c0.b.Add("Racute", 340);
			c0.b.Add("racute", 341);
			c0.b.Add("Rcommaaccent", 342);
			c0.b.Add("Rcedilla", 342);
			c0.b.Add("rcommaaccent", 343);
			c0.b.Add("rcedilla", 343);
			c0.b.Add("Rcaron", 344);
			c0.b.Add("rcaron", 345);
			c0.b.Add("Sacute", 346);
			c0.b.Add("sacute", 347);
			c0.b.Add("Scircumflex", 348);
			c0.b.Add("scircumflex", 349);
			c0.b.Add("Scedilla", 350);
			c0.b.Add("scedilla", 351);
			c0.b.Add("Scaron", 352);
			c0.b.Add("scaron", 353);
			c0.b.Add("Tcommadecent", 354);
			c0.b.Add("Tcedilla", 354);
			c0.b.Add("tcommadecent", 355);
			c0.b.Add("tcedilla", 355);
			c0.b.Add("Tcaron", 356);
			c0.b.Add("tcaron", 357);
			c0.b.Add("Tstroke", 358);
			c0.b.Add("Tslash", 358);
			c0.b.Add("tstroke", 359);
			c0.b.Add("tslash", 359);
			c0.b.Add("Utilde", 360);
			c0.b.Add("utilde", 361);
			c0.b.Add("Umacron", 362);
			c0.b.Add("umacron", 363);
			c0.b.Add("Ubreve", 364);
			c0.b.Add("ubreve", 365);
			c0.b.Add("Uring", 366);
			c0.b.Add("uring", 367);
			c0.b.Add("Uhungarumlaut", 368);
			c0.b.Add("Udblacute", 368);
			c0.b.Add("uhungarumlaut", 369);
			c0.b.Add("udblacute", 369);
			c0.b.Add("Uogonek", 370);
			c0.b.Add("uogonek", 371);
			c0.b.Add("Wcircumflex", 372);
			c0.b.Add("wcircumflex", 373);
			c0.b.Add("Ycircumflex", 374);
			c0.b.Add("ycircumflex", 375);
			c0.b.Add("Ydieresis", 376);
			c0.b.Add("Zacute", 377);
			c0.b.Add("zacute", 378);
			c0.b.Add("Zdotaccent", 379);
			c0.b.Add("zdotaccent", 380);
			c0.b.Add("Zcaron", 381);
			c0.b.Add("zcaron", 382);
			c0.b.Add("bstroke", 384);
			c0.b.Add("bslash", 384);
			c0.b.Add("Fhook", 401);
			c0.b.Add("fhook", 402);
			c0.b.Add("florin", 402);
			c0.b.Add("Istroke", 407);
			c0.b.Add("Islash", 407);
			c0.b.Add("lbar", 410);
			c0.b.Add("Ohorn", 416);
			c0.b.Add("ohorn", 417);
			c0.b.Add("tpalatalhook", 427);
			c0.b.Add("Tretroflexhook", 430);
			c0.b.Add("Uhorn", 431);
			c0.b.Add("uhorn", 432);
			c0.b.Add("zstroke", 438);
			c0.b.Add("Acaron", 461);
			c0.b.Add("acaron", 462);
			c0.b.Add("Icaron", 463);
			c0.b.Add("icaron", 464);
			c0.b.Add("Ocaron", 465);
			c0.b.Add("ocaron", 466);
			c0.b.Add("Ucaron", 467);
			c0.b.Add("ucaron", 468);
			c0.b.Add("Udiaeresismacron", 469);
			c0.b.Add("udiaeresismacron", 470);
			c0.b.Add("Udiaeresisacute", 471);
			c0.b.Add("udiaeresisacute", 472);
			c0.b.Add("Udiaeresiscaron", 473);
			c0.b.Add("udiaeresiscaron", 474);
			c0.b.Add("Udiaeresisgrave", 475);
			c0.b.Add("udiaeresisgrave", 476);
			c0.b.Add("Gstroke", 484);
			c0.b.Add("gstroke", 485);
			c0.b.Add("Gcaron", 486);
			c0.b.Add("gcaron", 487);
			c0.b.Add("Kcaron", 488);
			c0.b.Add("kcaron", 489);
			c0.b.Add("Oogonek", 490);
			c0.b.Add("oogonek", 491);
			c0.b.Add("Oogonekmacron", 492);
			c0.b.Add("oogonekmacron", 493);
			c0.b.Add("jcaron", 496);
			c0.b.Add("Aringaccentacute", 506);
			c0.b.Add("aringaccentacute", 507);
			c0.b.Add("AEacute", 508);
			c0.b.Add("aeacute", 509);
			c0.b.Add("Ostrokeacute", 510);
			c0.b.Add("Oslashacute", 510);
			c0.b.Add("ostrokeacute", 511);
			c0.b.Add("oslashacute", 511);
			c0.b.Add("Scommadecent", 536);
			c0.b.Add("scommadecent", 537);
			c0.b.Add("schwa", 601);
			c0.b.Add("caron", 711);
			c0.b.Add("breve", 728);
			c0.b.Add("dotaccent", 729);
			c0.b.Add("ringaccent", 730);
			c0.b.Add("ogonek", 731);
			c0.b.Add("hungarumlaut", 733);
			c0.b.Add("combininggraveaccent", 768);
			c0.b.Add("combiningacuteaccent", 769);
			c0.b.Add("combiningcircumflexaccent", 770);
			c0.b.Add("combiningtilde", 771);
			c0.b.Add("combiningmacron", 772);
			c0.b.Add("combiningoverline", 773);
			c0.b.Add("combiningdiaeresis", 776);
			c0.b.Add("combininghookaccent", 777);
			c0.b.Add("combiningringaccent", 778);
			c0.b.Add("combiningcaron", 780);
			c0.b.Add("combiningdotdecent", 803);
			c0.b.Add("Alpha", 913);
			c0.b.Add("Beta", 914);
			c0.b.Add("Gamma", 915);
			c0.b.Add("Delta", 916);
			c0.b.Add("Epsilon", 917);
			c0.b.Add("Zeta", 918);
			c0.b.Add("Eta", 919);
			c0.b.Add("Theta", 920);
			c0.b.Add("Iota", 921);
			c0.b.Add("Kappa", 922);
			c0.b.Add("Lamda", 923);
			c0.b.Add("Mu", 924);
			c0.b.Add("Nu", 925);
			c0.b.Add("Xi", 926);
			c0.b.Add("Omicron", 927);
			c0.b.Add("Pi", 928);
			c0.b.Add("Rho", 929);
			c0.b.Add("Sigma", 931);
			c0.b.Add("Phi", 934);
			c0.b.Add("Chi", 935);
			c0.b.Add("Psi", 936);
			c0.b.Add("Omega", 937);
			c0.b.Add("alpha", 945);
			c0.b.Add("beta", 946);
			c0.b.Add("gamma", 947);
			c0.b.Add("delta", 948);
			c0.b.Add("epsilon", 949);
			c0.b.Add("zeta", 950);
			c0.b.Add("eta", 951);
			c0.b.Add("theta", 952);
			c0.b.Add("iota", 953);
			c0.b.Add("kappa", 954);
			c0.b.Add("lamda", 955);
			c0.b.Add("mu", 956);
			c0.b.Add("nu", 957);
			c0.b.Add("xi", 958);
			c0.b.Add("omicron", 959);
			c0.b.Add("pi", 960);
			c0.b.Add("rho", 961);
			c0.b.Add("sigma", 963);
			c0.b.Add("tau", 964);
			c0.b.Add("upsilon", 965);
			c0.b.Add("phi", 966);
			c0.b.Add("chi", 967);
			c0.b.Add("psi", 968);
			c0.b.Add("omega", 969);
			c0.b.Add("Wgrave", 7808);
			c0.b.Add("wgrave", 7809);
			c0.b.Add("Wacute", 7810);
			c0.b.Add("wacute", 7811);
			c0.b.Add("Wdiaeresis", 7812);
			c0.b.Add("wdiaeresis", 7813);
			c0.b.Add("Adotdecent", 7840);
			c0.b.Add("adotdecent", 7841);
			c0.b.Add("Ahookaccent", 7842);
			c0.b.Add("ahookaccent", 7843);
			c0.b.Add("Acircumflexacute", 7844);
			c0.b.Add("acircumflexacute", 7845);
			c0.b.Add("Acircumflexgrave", 7846);
			c0.b.Add("acircumflexgrave", 7847);
			c0.b.Add("Acircumflexhookaccent", 7848);
			c0.b.Add("acircumflexhookaccent", 7849);
			c0.b.Add("Acircumflextilde", 7850);
			c0.b.Add("acircumflextilde", 7851);
			c0.b.Add("Acircumflexdotdecent", 7852);
			c0.b.Add("acircumflexdotdecent", 7853);
			c0.b.Add("Abreveacute", 7854);
			c0.b.Add("abreveacute", 7855);
			c0.b.Add("Abrevegrave", 7856);
			c0.b.Add("abrevegrave", 7857);
			c0.b.Add("Abrevehookaccent", 7858);
			c0.b.Add("abrevehookaccent", 7859);
			c0.b.Add("Abrevetilde", 7860);
			c0.b.Add("abrevetilde", 7861);
			c0.b.Add("Abrevedotdecent", 7862);
			c0.b.Add("abrevedotdecent", 7863);
			c0.b.Add("Edotdecent", 7864);
			c0.b.Add("edotdecent", 7865);
			c0.b.Add("Ehookaccent", 7866);
			c0.b.Add("ehookaccent", 7867);
			c0.b.Add("Etilde", 7868);
			c0.b.Add("etilde", 7869);
			c0.b.Add("Ecircumflexacute", 7870);
			c0.b.Add("ecircumflexacute", 7871);
			c0.b.Add("Ecircumflexgrave", 7872);
			c0.b.Add("ecircumflexgrave", 7873);
			c0.b.Add("Ecircumflexhookaccent", 7874);
			c0.b.Add("ecircumflexhookaccent", 7875);
			c0.b.Add("Ecircumflextilde", 7876);
			c0.b.Add("ecircumflextilde", 7877);
			c0.b.Add("Ecircumflexdotdecent", 7878);
			c0.b.Add("ecircumflexdotdecent", 7879);
			c0.b.Add("Ihookaccent", 7880);
			c0.b.Add("ihookaccent", 7881);
			c0.b.Add("Idotdecent", 7882);
			c0.b.Add("idotdecent", 7883);
			c0.b.Add("Odotdecent", 7884);
			c0.b.Add("odotdecent", 7885);
			c0.b.Add("Ohookaccent", 7886);
			c0.b.Add("ohookaccent", 7887);
			c0.b.Add("Ocircumflexacute", 7888);
			c0.b.Add("ocircumflexacute", 7889);
			c0.b.Add("Ocircumflexgrave", 7890);
			c0.b.Add("ocircumflexgrave", 7891);
			c0.b.Add("Ocircumflexhookaccent", 7892);
			c0.b.Add("ocircumflexhookaccent", 7893);
			c0.b.Add("Ocircumflextilde", 7894);
			c0.b.Add("ocircumflextilde", 7895);
			c0.b.Add("Ocircumflexdotdecent", 7896);
			c0.b.Add("ocircumflexdotdecent", 7897);
			c0.b.Add("Ohorntilde", 7904);
			c0.b.Add("ohorntilde", 7905);
			c0.b.Add("Ohorndotdecent", 7906);
			c0.b.Add("ohorndotdecent", 7907);
			c0.b.Add("Udotdecent", 7908);
			c0.b.Add("udotdecent", 7909);
			c0.b.Add("Uhookaccent", 7910);
			c0.b.Add("uhookaccent", 7911);
			c0.b.Add("Uhornacute", 7912);
			c0.b.Add("uhornacute", 7913);
			c0.b.Add("Uhorngrave", 7914);
			c0.b.Add("uhorngrave", 7915);
			c0.b.Add("Uhornhookaccent", 7916);
			c0.b.Add("uhornhookaccent", 7917);
			c0.b.Add("Uhorntilde", 7918);
			c0.b.Add("uhorntilde", 7919);
			c0.b.Add("Uhorndotdecent", 7920);
			c0.b.Add("uhorndotdecent", 7921);
			c0.b.Add("Ygrave", 7922);
			c0.b.Add("ygrave", 7923);
			c0.b.Add("Ydotdecent", 7924);
			c0.b.Add("ydotdecent", 7925);
			c0.b.Add("Yhookaccent", 7926);
			c0.b.Add("yhookaccent", 7927);
			c0.b.Add("Ytilde", 7928);
			c0.b.Add("ytilde", 7929);
			c0.b.Add("endash", 8211);
			c0.b.Add("emdash", 8212);
			c0.b.Add("horizontalbar", 8213);
			c0.b.Add("doublelowline", 8215);
			c0.b.Add("dbllowline", 8215);
			c0.b.Add("quotesinglleft", 8216);
			c0.b.Add("quoteleft", 8216);
			c0.b.Add("quotesinglright", 8217);
			c0.b.Add("quoteright", 8217);
			c0.b.Add("quotesinglbase", 8218);
			c0.b.Add("quotedblleft", 8220);
			c0.b.Add("quotedblright", 8221);
			c0.b.Add("quotedblbase", 8222);
			c0.b.Add("dagger", 8224);
			c0.b.Add("daggerdbl", 8225);
			c0.b.Add("bullet", 8226);
			c0.b.Add("horizontalellipsis", 8230);
			c0.b.Add("ellipsis", 8230);
			c0.b.Add("perthousand", 8240);
			c0.b.Add("prime", 8242);
			c0.b.Add("primedbl", 8243);
			c0.b.Add("guilsinglleft", 8249);
			c0.b.Add("guilsinglright", 8250);
			c0.b.Add("interrobang", 8253);
			c0.b.Add("overline", 8254);
			c0.b.Add("fraction", 8260);
			c0.b.Add("lira", 8356);
			c0.b.Add("peseta", 8359);
			c0.b.Add("sheqel", 8362);
			c0.b.Add("dong", 8363);
			c0.b.Add("Euro", 8364);
			c0.b.Add("careof", 8453);
			c0.b.Add("numero", 8470);
			c0.b.Add("servicemark", 8480);
			c0.b.Add("trademark", 8482);
			c0.b.Add("ohm", 8486);
			c0.b.Add("estimated", 8494);
			c0.b.Add("arrowleft", 8592);
			c0.b.Add("arrowup", 8593);
			c0.b.Add("arrowright", 8594);
			c0.b.Add("arrowdown", 8595);
			c0.b.Add("arrowboth", 8596);
			c0.b.Add("leftrightarrow", 8596);
			c0.b.Add("upbottomarrow", 8596);
			c0.b.Add("increment", 8710);
			c0.b.Add("summation", 8721);
			c0.b.Add("minus", 8722);
			c0.b.Add("-", 8722);
			c0.b.Add("division", 8725);
			c0.b.Add("squareroot", 8730);
			c0.b.Add("infinity", 8734);
			c0.b.Add("rightangle", 8735);
			c0.b.Add("intersection", 8745);
			c0.b.Add("integral", 8747);
			c0.b.Add("approxequal", 8776);
			c0.b.Add("almostequal", 8776);
			c0.b.Add("notequalto", 8800);
			c0.b.Add("identicalto", 8801);
			c0.b.Add("lessequal", 8804);
			c0.b.Add("greaterequal", 8805);
			c0.b.Add("house", 8962);
			c0.b.Add("integraltp", 8992);
			c0.b.Add("integralbt", 8993);
			c0.b.Add("blacksquare", 9632);
			c0.b.Add("whitesquare", 9633);
			c0.b.Add("lozenge", 9674);
			c0.b.Add("whitecircle", 9675);
			c0.b.Add("blackcircle", 9679);
			c0.b.Add("spade", 9824);
			c0.b.Add("club", 9825);
			c0.b.Add("heart", 9829);
			c0.b.Add("blackheart", 9829);
			c0.b.Add("diamond", 9830);
			c0.b.Add("blackdiamond", 9830);
			c0.b.Add("ff", 64256);
			c0.b.Add("fi", 64257);
			c0.b.Add("fl", 64258);
			c0.b.Add("ffi", 64259);
			c0.b.Add("ffl", 64260);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0005B5C4 File Offset: 0x0005A5C4
		internal static ushort[] a()
		{
			return c0.e;
		}

		// Token: 0x04000342 RID: 834
		private const string a = "MacRomanEncoding";

		// Token: 0x04000343 RID: 835
		private static Hashtable b = null;

		// Token: 0x04000344 RID: 836
		private int[] c = null;

		// Token: 0x04000345 RID: 837
		private static ushort[] d = new ushort[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			96,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			126,
			127,
			8364,
			0,
			8218,
			402,
			8222,
			8230,
			8224,
			8225,
			710,
			8240,
			352,
			8249,
			338,
			0,
			381,
			0,
			0,
			8216,
			8217,
			8220,
			8221,
			8226,
			8211,
			8212,
			732,
			8482,
			353,
			8250,
			339,
			0,
			382,
			376,
			160,
			161,
			162,
			163,
			164,
			165,
			166,
			167,
			168,
			169,
			170,
			171,
			172,
			173,
			174,
			175,
			176,
			177,
			178,
			179,
			180,
			181,
			182,
			183,
			184,
			185,
			186,
			187,
			188,
			189,
			190,
			191,
			192,
			193,
			194,
			195,
			196,
			197,
			198,
			199,
			200,
			201,
			202,
			203,
			204,
			205,
			206,
			207,
			208,
			209,
			210,
			211,
			212,
			213,
			214,
			215,
			216,
			217,
			218,
			219,
			220,
			221,
			222,
			223,
			224,
			225,
			226,
			227,
			228,
			229,
			230,
			231,
			232,
			233,
			234,
			235,
			236,
			237,
			238,
			239,
			240,
			241,
			242,
			243,
			244,
			245,
			246,
			247,
			248,
			249,
			250,
			251,
			252,
			253,
			254,
			255
		};

		// Token: 0x04000346 RID: 838
		private static ushort[] e = new ushort[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			28,
			29,
			30,
			31,
			32,
			33,
			34,
			35,
			36,
			37,
			38,
			39,
			40,
			41,
			42,
			43,
			44,
			45,
			46,
			47,
			48,
			49,
			50,
			51,
			52,
			53,
			54,
			55,
			56,
			57,
			58,
			59,
			60,
			61,
			62,
			63,
			64,
			65,
			66,
			67,
			68,
			69,
			70,
			71,
			72,
			73,
			74,
			75,
			76,
			77,
			78,
			79,
			80,
			81,
			82,
			83,
			84,
			85,
			86,
			87,
			88,
			89,
			90,
			91,
			92,
			93,
			94,
			95,
			96,
			97,
			98,
			99,
			100,
			101,
			102,
			103,
			104,
			105,
			106,
			107,
			108,
			109,
			110,
			111,
			112,
			113,
			114,
			115,
			116,
			117,
			118,
			119,
			120,
			121,
			122,
			123,
			124,
			125,
			126,
			127,
			196,
			197,
			199,
			201,
			209,
			214,
			220,
			225,
			224,
			226,
			228,
			227,
			229,
			231,
			233,
			232,
			234,
			235,
			237,
			236,
			238,
			239,
			241,
			243,
			242,
			244,
			246,
			245,
			250,
			249,
			251,
			252,
			8224,
			176,
			162,
			163,
			167,
			8226,
			182,
			223,
			174,
			169,
			8482,
			180,
			171,
			8800,
			198,
			219,
			8734,
			177,
			8804,
			8805,
			165,
			181,
			8706,
			8721,
			8719,
			960,
			8747,
			170,
			186,
			937,
			230,
			248,
			191,
			161,
			172,
			8730,
			402,
			8776,
			8710,
			171,
			187,
			8230,
			160,
			192,
			195,
			213,
			338,
			339,
			8211,
			8212,
			8220,
			8221,
			8216,
			8217,
			247,
			9674,
			255,
			376,
			8260,
			8364,
			8249,
			8250,
			64257,
			64258,
			8225,
			183,
			8218,
			8222,
			8240,
			194,
			202,
			193,
			203,
			200,
			205,
			206,
			207,
			204,
			211,
			212,
			64511,
			210,
			218,
			219,
			217,
			305,
			710,
			732,
			175,
			731,
			729,
			730,
			184,
			733,
			731,
			711
		};
	}
}
