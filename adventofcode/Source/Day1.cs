namespace adventofcode {
    public static class Day1 {
        public static void Run(string path) {
            var List1 = new List<int>();
            var List2 = new List<int>();

            foreach (var line in Utility.ReadAllLines(path)) {
                var vals = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                List1.Add(int.Parse(vals[0]));
                List2.Add(int.Parse(vals[1]));
            }

            List1.Sort();
            List2.Sort();

            var total = 0L;
            for (int i = 0; i < List1.Count; i++) {
                total += Math.Abs(List1[i] - List2[i]);
            }

            Console.WriteLine(total);

            // part 2
            total = 0;
            foreach (var i1 in List1) {
                var count = 0;
                foreach (var i2 in List2) {
                    if (i2 == i1)
                        count++;

                    if (i2 > i1)
                        break;
                }

                total += count * i1;
            }


            Console.WriteLine(total);
        }
    }
}