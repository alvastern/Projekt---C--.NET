namespace Renoveringskalkylator.Calculators
{
    // Klass för att beräkna hur mycket färg och burkar som behövs
    public class PaintCalculator
    {
        // Beräknar hur många liter färg som behövs för att måla den angivna ytan
        public decimal CalculateLiters(decimal area, int strokes, decimal litersMeter)
        {
            return area * strokes * litersMeter;
        }

        // Beräknar hur många hela burkar som går åt
        public decimal CalculateCanCount(decimal liters, decimal litersPerCan)
        {
            return Math.Ceiling(liters / litersPerCan);
        }
    }
}