using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Optimizers;

public class GreedyCuttingStrategy : ICuttingStrategy
{
    public CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        var layout = new CutLayout();
        var sortedPanels = panels.OrderByDescending(p => p.Width * p.Height).ToList(); // Sort panels by area
        var availableSheets = sheets.ToList();

        foreach (var panel in sortedPanels)
        {
            var sheet = FindBestFitSheet(panel, availableSheets);

            if (sheet != null)
                PlacePanel(sheet, layout, panel);
        }

        layout.WastePercentage = CalculateWaste(layout, availableSheets);
        return layout;
    }

    private StockSheet FindBestFitSheet(GlassPanel panel, List<StockSheet> sheets)
    {
        // Find the first sheet where the panel can fit
        return sheets.FirstOrDefault(sheet => sheet.Width >= panel.Width && sheet.Height >= panel.Height);
    }

    private void PlacePanel(StockSheet sheet, CutLayout layout, GlassPanel panel)
    {
        var position = new CutPosition
        {
            X = 0, // Position logic can be refined
            Y = 0, // Position logic can be refined
            Width = panel.Width,
            Height = panel.Height
        };

        layout.CutPositions.Add(position);

        // Update available space logic can be added if more complex placement is needed
    }

    private double CalculateWaste(CutLayout layout, List<StockSheet> sheets)
    {
        double totalArea = sheets.Sum(s => s.Width * s.Height);
        double usedArea = layout.CutPositions.Sum(p => p.Width * p.Height);
        return (totalArea - usedArea) / totalArea * 100;
    }
}
