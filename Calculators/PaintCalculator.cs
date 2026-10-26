namespace Renoveringskalkylator.Calculators
{
    public class PaintCalculator
    {
        public decimal CalculateLiters(decimal area, int strokes, decimal litersMeter)
        {
            return area * strokes * litersMeter;
        }

        public decimal CalculateCanCount(decimal liters, decimal litersPerCan)
        {
            return Math.Ceiling(liters / litersPerCan);
        }
    }
}