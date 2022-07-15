// Datei StringExt
using System;
namespace StringExt {
	public static class StringExt {
		public static bool Empty(this String arg) {
			return (arg != null && arg.Length == 0) ? true : false;
		}
	}
}

