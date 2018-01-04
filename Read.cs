using System;
using System.IO;
using System.Globalization;

namespace Input {
    public static class Read {
        static string line;
        static int pos;

        public static void UseFile(string name) {
            using (StreamReader file = new StreamReader(name)) {
                line = file.ReadToEnd();
            }
            pos = 0;
        }

        public static void UseInput(string input) {
            line = input;
            pos = 0;
        }

        static string GetLine() {
            return Console.ReadLine();
        }

        static char Next() {
            if (line == null || pos >= line.Length) {
                line = GetLine();
                pos = -1;
            }
            pos++;
            return Last();
        }

        static char Last() {
            if (line == null)
                Next();
            if (pos >= line.Length)
                return '\n';
            return line[pos];
        }

        public static string IntegerString() {
            while (!char.IsDigit(Last()) && Last() != '-')
                Next();
            string num = new string(Last(), 1);
            while (char.IsDigit(Next())) {
                num += Last();
            }
            return num;
        }

        public static long Long() {
            return long.Parse(IntegerString());
        }

        public static int Int() {
            return int.Parse(IntegerString());
        }

        public static string FloatString() {
            while (!char.IsDigit(Last()) && Last() != '-')
                Next();
            string num = new string(Last(), 1);
            bool dot = false;
            while (char.IsDigit(Next()) || (!dot && (Last() == '.' || Last() == ','))) {
                dot |= !char.IsDigit(Last());
                num += Last();
            }
            return num;
        }

        public static double Double() {
            return double.Parse(FloatString().Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        public static float Float() {
            return float.Parse(FloatString().Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        public static char Char() {
            while (char.IsWhiteSpace(Last()))
                Next();
            char ret = Last();
            Next();
            return ret;
        }

        public static string String() {
            while (char.IsWhiteSpace(Last()))
                Next();
            string ret = "";
            ret += Last();
            while (!char.IsWhiteSpace(Next()))
                ret += Last();

            return ret;
        }

        public static int To(out int a) {
            return a = Int();
        }

        public static long To(out long a) {
            return a = Long();
        }

        public static char To(out char a) {
            return a = Char();
        }

        public static string To(out string a) {
            return a = String();
        }

        public static double To(out double a) {
            return a = Double();
        }
    }
}
