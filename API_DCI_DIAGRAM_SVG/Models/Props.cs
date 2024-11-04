namespace API_DCI_DIAGRAM_SVG.Models
{
    public class Props
    {
    }
    public class PropsStockSubline
    {
        public List<ApsSublineStockBalance> stockHistory { get; set; } = new List<ApsSublineStockBalance>();
        public List<ViApsPartStockScr> stockCurrent { get; set; } = new List<ViApsPartStockScr>();
    }
}
