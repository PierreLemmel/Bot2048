namespace Bot2048.Model
{
    public struct GridUpdateInput
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public CellValue Value { get; set; }
    }
}