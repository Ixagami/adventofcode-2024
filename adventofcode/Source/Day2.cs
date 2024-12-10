namespace adventofcode {
    public static class Day2 {
        public static bool CheckUp(int[] line) {
            for (int i = 1; i < line.Length; i++) {
                var d = line[i] - line[i - 1];
                if (d < 1 || d > 3)
                    return false;
            }

            return true;
        }

        public static bool CheckDown(int[] line) {
            for (int i = 1; i < line.Length; i++) {
                var d = line[i - 1] - line[i];
                if (d < 1 || d > 3)
                    return false;
            }

            return true;
        }

        private static int[] Remove(int[] line, int i) {
            var nl = new int[line.Length - 1];

            for (int j = 0; j < i; j++)
                nl[j] = line[j];

            for (int j = i + 1; j < line.Length; j++)
                nl[j - 1] = line[j];

            return nl;
        }

        public static void Run(string path) {
            var right = 0;
            foreach (var line in Utility.ReadNumberLines(path)) {
                if (line.Length > 1) {
                    var d = line[1] - line[0];
                    if (d > 0) {
                        if (CheckUp(line))
                            ++right;
                    } else if (d < 0) {
                        if (CheckDown(line))
                            ++right;
                    }
                } else
                    ++right;
            }

            Console.WriteLine(right);

            // Part 2
            right = 0;
            foreach (var line in Utility.ReadNumberLines(path)) {
                if (line.Length > 1) {
                    if (CheckUp(line)) {
                        ++right;
                        continue;
                    }

                    if (CheckDown(line)) {
                        ++right;
                        continue;
                    }

                    bool ok = false;

                    for (int i = 0; i < line.Length; i++) {
                        var arr = Remove(line, i);
                        if (CheckUp(arr)) {
                            ok = true;
                            break;
                        }

                        if (CheckDown(arr)) {
                            ok = true;
                            break;
                        }
                    }

                    if (ok)
                        ++right;

                } else
                    ++right;
            }

            Console.WriteLine(right);
        }
    }
}