namespace WorkshopIEnumerables.Logic
{
    public class ChessHorseConflict
    {
        public static List<string> GetConflicts(string currentHorse, string[] allHorses)
        {
            List<string> conflicts = new List<string>();

            foreach (string horse in allHorses)
            {
                if (horse != currentHorse && IsHorseInConflict(currentHorse, horse))
                {
                    conflicts.Add(horse);
                }
            }

            return conflicts;
        }

        private static bool IsHorseInConflict(string horse1, string horse2)
        {
            // Obtener las coordenadas de los caballos
            int row1 = int.Parse(horse1[1].ToString());
            int col1 = horse1[0] - 'A' + 1;

            int row2 = int.Parse(horse2[1].ToString());
            int col2 = horse2[0] - 'A' + 1;

            // Verificar si los caballos están en conflicto
            int rowDiff = Math.Abs(row1 - row2);
            int colDiff = Math.Abs(col1 - col2);

            return rowDiff == 2 && colDiff == 1 || rowDiff == 1 && colDiff == 2;
        }
    }
}
