namespace adventofcode {
    public static class Utility {
        public const string Root = @"..\..\..\Data\";
        public static IList<string> ReadAllLines(string path) 
            => File.ReadAllLines(Path.Combine(Root, path));

        public static IEnumerable<int[]> ReadNumberLines(string path)
            => File.ReadAllLines(Path.Combine(Root, path))
                .Select(q => 
                    q.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray());

        public static IEnumerable<byte[]> ReadDigitLines(string path)
            => File.ReadAllLines(Path.Combine(Root, path))
                .Select(q => q.Select(p=>(byte)(p - '0')).ToArray());

        public static IEnumerable<byte> ReadAllDigits(string path)
            => File.ReadAllText(Path.Combine(Root, path))
                .Select(p => (byte) (p - '0'));
    }

    internal class Program {
        static void Main(string[] args) {
            Day10.Run("Day10.txt");
        }
    }
}