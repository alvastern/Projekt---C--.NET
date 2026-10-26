using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Renoveringskalkylator.Calculators;

namespace Renoveringskalkylator.Pages
{
    public class IndexModel : PageModel
    {
        public decimal? FloorMaterialArea { get; private set; }
        public decimal? FloorPackageCount { get; private set; }
        public decimal? CeilingMaterialArea { get; private set; }
        public decimal? CeilingPackageCount { get; private set; }
        public decimal? PaintLiters { get; private set; }
        public decimal? PaintCanCount { get; private set; }

        public void OnGet()
        {
            
        }

        public void OnPostFloor(decimal floorArea, decimal floorWaste, decimal floorPackageCoverage)
        {
            // Kontrollerar att inmatningen kan tolkas som tal
            if (!ModelState.IsValid)
            {
                return;
            }

            // Kontrollera att värderna är tillåtna
            if (floorArea <= 0 || floorWaste < 0 || floorPackageCoverage <= 0)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ange en yta och paketstorlek större än noll samt spill på minst 0 %.");

                return;
            }

            // Skapar ett objekt av klassen PackageCalculator
            PackageCalculator calculator = new PackageCalculator();

            FloorMaterialArea = calculator.CalculateMaterialArea(floorArea, floorWaste);
            FloorPackageCount = calculator.CalculatePackageCount(FloorMaterialArea.Value, floorPackageCoverage);
        }

        public void OnPostCeiling(decimal ceilingArea, decimal ceilingWaste, decimal ceilingPackageCoverage)
        {
            // Kontrollerar att inmatningen kan tolkas som tal.
            if (!ModelState.IsValid)
            {
                return;
            }

            // Kontrollerar att värdena är tillåtna.
            if (ceilingArea <= 0 || ceilingWaste < 0 || ceilingPackageCoverage <= 0)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ange en yta och paketstorlek större än noll samt spill på minst 0 %.");

                return;
            }

            // Återanvänder samma kalkylklass som för golv.
            PackageCalculator calculator = new PackageCalculator();

            CeilingMaterialArea = calculator.CalculateMaterialArea(
                ceilingArea, ceilingWaste);

            CeilingPackageCount = calculator.CalculatePackageCount(
                CeilingMaterialArea.Value, ceilingPackageCoverage);
        }

        public void OnPostPaint(decimal colorArea, int strokeNumber, decimal litersMeters, decimal litersCan)
        {
            // Kontrollerar att inmatningen kunde tolkas som rätt datatyper.
            if (!ModelState.IsValid)
            {
                return;
            }

            // Alla värden måste vara större än noll.
            if (colorArea <= 0 || strokeNumber <= 0 ||
                litersMeters <= 0 || litersCan <= 0)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Ange värden större än noll. Antal strykningar ska vara ett heltal.");

                return;
            }

            PaintCalculator calculator = new PaintCalculator();

            PaintLiters = calculator.CalculateLiters(
                colorArea, strokeNumber, litersMeters);

            PaintCanCount = calculator.CalculateCanCount(
                PaintLiters.Value, litersCan);
        }
    }
}