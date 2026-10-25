namespace Renoveringskalkylator.Calculators
{
    public class PackageCalculator
    {
        // Beräknar materialet som behövs för att fylla ytan + spillmaterial
        public decimal CalculateMaterialArea(decimal area, decimal waste)
        {
            return area * (1 + waste / 100);
        }

        // Beräknar hur många hela paket som behövs för att täcka ytan
        public decimal CalculatePackageCount(decimal materialArea, decimal packageCoverage)
        {
            // Math.Ceiling används för att avrunda uppåt till närmaste heltal
            return Math.Ceiling(materialArea / packageCoverage);
        }
    }
}