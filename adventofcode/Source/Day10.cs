namespace adventofcode {
    public static class Day10 {
        public static void Run(string path) {
            var map = Utility.ReadDigitLines(path).ToArray();
            int sx = map.Length;
            int sy = map[0].Length;

            var point0 = new List<(int, int)>();
            var point9 = new List<(int, int)>();

            for (int x = 0; x < sx; x++) {
                for (int y = 0; y < sy; y++) {
                    if (map[x][y] == 0)
                        point0.Add((x, y));
                    else if (map[x][y] == 9)
                        point9.Add((x, y));
                }
            }

            int Distance((int, int) start, (int, int) end) {
                return Math.Abs(start.Item1 - end.Item1) + Math.Abs(start.Item2 - end.Item2);
            }

            var paths = 0;

            foreach (var start in point0) {
                foreach (var end in point9) {
                    if (Distance(start, end) > 9)
                        continue;


                    var next = 0;
                    var acceptable = new List<(int, int)>() { start };
                    while (true) {
                        next++;
                        var cu = new List<(int, int)>(acceptable);
                        acceptable.Clear();

                        if (next == 9) {
                            foreach (var point in cu) {
                                if (point.Item1 == end.Item1) {
                                    if (point.Item2 + 1 == end.Item2 || point.Item2 - 1 == end.Item2) {
                                        paths++;
                                        break;
                                    }
                                } else if (point.Item2 == end.Item2) {
                                    if (point.Item1 + 1 == end.Item1 || point.Item1 - 1 == end.Item1) {
                                        paths++;
                                        break;
                                    }
                                }
                            }

                            break;
                        }

                        foreach (var point in cu) {
                            var x = point.Item1;
                            var y = point.Item2;

                            if (x + 1 < sx)
                                if (map[x + 1][y] == next)
                                    acceptable.Add((x + 1, y));

                            if (x - 1 >= 0)
                                if (map[x - 1][y] == next)
                                    acceptable.Add((x - 1, y));

                            if (y + 1 < sy)
                                if (map[x][y + 1] == next)
                                    acceptable.Add((x, y + 1));

                            if (y - 1 >= 0)
                                if (map[x][y - 1] == next)
                                    acceptable.Add((x, y - 1));
                        }
                    }

                }
            }

            Console.WriteLine(paths);

            // Part 2
            paths = 0;

            foreach (var start in point0) {
                foreach (var end in point9) {
                    if (Distance(start, end) > 9)
                        continue;


                    var next = 0;
                    var acceptable = new List<(int, int)>() { start };
                    while (true) {
                        next++;
                        var cu = new List<(int, int)>(acceptable);
                        acceptable.Clear();

                        if (next == 9) {
                            foreach (var point in cu) {
                                if (point.Item1 == end.Item1) {
                                    if (point.Item2 + 1 == end.Item2 || point.Item2 - 1 == end.Item2) {
                                        paths++;
                                    }
                                } else if (point.Item2 == end.Item2) {
                                    if (point.Item1 + 1 == end.Item1 || point.Item1 - 1 == end.Item1) {
                                        paths++;
                                    }
                                }
                            }

                            break;
                        }

                        foreach (var point in cu) {
                            var x = point.Item1;
                            var y = point.Item2;

                            if (x + 1 < sx)
                                if (map[x + 1][y] == next)
                                    acceptable.Add((x + 1, y));

                            if (x - 1 >= 0)
                                if (map[x - 1][y] == next)
                                    acceptable.Add((x - 1, y));

                            if (y + 1 < sy)
                                if (map[x][y + 1] == next)
                                    acceptable.Add((x, y + 1));

                            if (y - 1 >= 0)
                                if (map[x][y - 1] == next)
                                    acceptable.Add((x, y - 1));
                        }
                    }

                }
            }

            Console.WriteLine(paths);
        }
    }
}