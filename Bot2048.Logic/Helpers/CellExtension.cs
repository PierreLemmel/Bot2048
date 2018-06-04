using Bot2048.Model;

namespace Bot2048.Logic
{
    public static class CellExtension
    {
        public static bool IsEmpty(this CellValue cell)
        {
            return cell == CellValue.Empty;
        }
    }
}