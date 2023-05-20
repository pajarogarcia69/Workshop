namespace WorkshopIEnumerables.Logic
{
    public class HarvestingOnHorseback
    {
        public string? Fruits { get; set; }
        public string? PositionHorse { get; set; }
        public string? Movements { get; set; }
        public int FruitsLength { get; set; }
        public int PositionLength { get; set; }
        public int MovementsLength { get; set; }

        public HarvestingOnHorseback(string? fruits, string? positionHorse, string? movements)
        {
            Fruits = fruits;
            PositionHorse = positionHorse;
            Movements = movements;
            FruitsLength = fruits!.Length;
            PositionLength = positionHorse!.Length;
            MovementsLength = movements!.Length;
        }

        public string Result()
        {
            var field = new char[8, 8];
            var frutos = string.Empty;

            for (int i = 0; i < FruitsLength; i += 4)
            {
                var fruit = Fruits!.Substring(i, 3);

                int row = PositionRow(fruit[1], "Fruit");
                int column = PositionColumn(fruit[0], "Fruit");

                if (fruit[2] != '+' && fruit[2] != '-' && fruit[2] != '*' && fruit[2] != '=')
                {
                    throw new Exception("The Fruits Are Invalid. Check Again");
                }

                field[row, column] = fruit[2];
            }

            int rowhorse = PositionRow(PositionHorse![1], "Horse");
            int columnHorse = PositionColumn(PositionHorse[0], "Horse");
            int newRow, newColumn;

            for (int i = 0; i < MovementsLength; i += 3)
            {
                var indication = Movements!.Substring(i, 2);

                if (indication.Equals("UL"))
                {
                    newRow = rowhorse - 2;
                    newColumn = columnHorse - 1;
                }
                else if (indication.Equals("UR"))
                {
                    newRow = rowhorse - 2;
                    newColumn = columnHorse + 1;
                }
                else if (indication.Equals("LU"))
                {
                    newRow = rowhorse - 1;
                    newColumn = columnHorse - 2;
                }
                else if (indication.Equals("LD"))
                {
                    newRow = rowhorse + 1;
                    newColumn = columnHorse - 2;
                }
                else if (indication.Equals("RU"))
                {
                    newRow = rowhorse - 1;
                    newColumn = columnHorse + 2;
                }
                else if (indication.Equals("RD"))
                {
                    newRow = rowhorse + 1;
                    newColumn = columnHorse + 2;
                }
                else if (indication.Equals("DL"))
                {
                    newRow = rowhorse + 2;
                    newColumn = columnHorse - 1;
                }
                else if (indication.Equals("DR"))
                {
                    newRow = rowhorse + 2;
                    newColumn = columnHorse + 1;
                }
                else
                {
                    throw new Exception("Incorrect Movements");
                }

                if ((field[newRow, newColumn] == '+')
                    || (field[newRow, newColumn] == '-')
                    || (field[newRow, newColumn] == '*')
                    || (field[newRow, newColumn] == '='))
                {
                    frutos += $"{field[newRow, newColumn]} ";
                }

                rowhorse = newRow;
                columnHorse = newColumn;
            }

            return frutos;
        }

        private static int PositionRow(char? data, string? type)
        {
            return data switch
            {
                '8' => 0,
                '7' => 1,
                '6' => 2,
                '5' => 3,
                '4' => 4,
                '3' => 5,
                '2' => 6,
                '1' => 7,
                _ => throw new Exception($"{type} Invalid Position"),
            };
        }

        private static int PositionColumn(char? data, string? type)
        {
            return data switch
            {
                'A' => 0,
                'B' => 1,
                'C' => 2,
                'D' => 3,
                'E' => 4,
                'F' => 5,
                'G' => 6,
                'H' => 7,
                _ => throw new Exception($"{type} Invalid Position"),
            };
        }
    }
}
