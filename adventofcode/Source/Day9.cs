namespace adventofcode {
    public static class Day9 {
        private class Block {
            public readonly int ID;
            public readonly int Files;
            public readonly int Space;

            public Block(int id, int files, int space) {
                ID = id;
                Files = files;
                Space = space;
            }
        }

        private class Space {
            public int Amount;
            public Block? Block;
            public readonly List<Block> AdditionalBlocks = new List<Block>();

            public Space(Block block) {
                Amount = block.Space;
                Block = block;
            }
        }

        private static void Part1(IList<Block> blocks) {
            var files = new List<int>(0x10000);

            for (var i = 0; i < blocks.Count; i++) {
                var block = blocks[i];
                for (int j = 0; j < block.Files; j++)
                    files.Add(i);

                for (int j = 0; j < block.Space; j++)
                    files.Add(-1);
            }


            var start = 0;
            var end = files.Count - 1;

            while (start < end) {
                if (files[start] < 0) {
                    while (files[end] < 0) {
                        end--;
                    }

                    if (end < start)
                        break;


                    files[start] = files[end];
                    end--;
                }

                start++;
            }

            if (files[start] > 0)
                start++;

            long sum = 0;

            for (int i = 0; i < start; i++) {
                sum += (long) files[i] * i;
            }

            Console.WriteLine(sum);
        }

        private static void Part2(IList<Block> blocks) {
            var spaces = blocks.Select(q => new Space(q)).ToArray();

            for (int i = spaces.Length - 1; i > 0; i--) {
                var block = spaces[i].Block;
                if (block == null)
                    continue;


                for (int j = 0; j < i; j++) {
                    if (spaces[j].Amount >= block.Files) {
                        spaces[j].Amount -= block.Files;
                        spaces[j].AdditionalBlocks.Add(block);
                        spaces[i - 1].Amount += block.Files;
                        spaces[i].Block = null;
                        break;
                    }
                }
            }

            var cid = 0L;
            var sum = 0L;

            void AddFiles(Block block) {
                for (int i = 0; i < block.Files; i++) {
                    //Console.Write(block.ID);
                    sum += block.ID * cid;
                    cid++;
                }
            }

            foreach (var space in spaces) {
                if (space.Block != null)
                    AddFiles(space.Block);

                foreach (var additional_block in space.AdditionalBlocks)
                    AddFiles(additional_block);

                cid += space.Amount;
                for (int i = 0; i < space.Amount; i++) {
                    //Console.Write(".");
                }
            }

            //Console.WriteLine();

            Console.WriteLine(sum);
        }

        public static void Run(string path) {
            var digits = Utility.ReadAllDigits(path).ToArray();

            var blocks = new List<Block>();
            var c = 0;
            var id = -1;
            while (true) {
                var f = digits[c];
                if (++c >= digits.Length) {
                    blocks.Add(new Block(++id, f, 0));
                    break;
                }

                var s = digits[c];
                blocks.Add(new Block(++id, f, s));

                if (++c >= digits.Length) {
                    break;
                }
            }

            // Part 1
            Part1(blocks);

            // Part 2
            Part2(blocks);
        }
    }
}