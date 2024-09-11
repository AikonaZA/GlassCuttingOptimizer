using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Optimizers;

public class DynamicProgrammingCuttingStrategy : ICuttingStrategy
{
    public CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        var layout = new CutLayout();
        var dpTable = new Dictionary<string, double>(); // To store the best arrangement states
        var sortedPanels = panels.OrderByDescending(p => p.Width * p.Height).ToList();

        foreach (var sheet in sheets)
        {
            var bestArrangement = FindBestArrangement(sortedPanels, sheet, dpTable);
            layout.CutPositions.AddRange(bestArrangement.CutPositions);
        }

        layout.WastePercentage = CalculateWaste(layout, sheets);
        return layout;
    }

    private CutLayout FindBestArrangement(List<GlassPanel> panels, StockSheet sheet, Dictionary<string, double> dpTable)
    {
        // Logic to recursively find the best arrangement using a DP approach
        // Placeholder implementation, typically involves recursive function with memorization
        var layout = new CutLayout();

        foreach (var panel in panels)
        {
            if (CanPlacePanel(sheet, layout, panel))
                PlacePanel(sheet, layout, panel);
        }

        return layout;
    }

    private bool CanPlacePanel(StockSheet sheet, CutLayout layout, GlassPanel panel)
    {
        // Check if the panel fits within the available space on the sheet
        // Placeholder for detailed checking logic
        return true;
    }

    private void PlacePanel(StockSheet sheet, CutLayout layout, GlassPanel panel)
    {
        // Update layout by placing the panel on the sheet
        var position = new CutPosition
        {
            X = 0, // Logic for actual placement
            Y = 0,
            Width = panel.Width,
            Height = panel.Height
        };

        layout.CutPositions.Add(position);
    }

    private double CalculateWaste(CutLayout layout, IEnumerable<StockSheet> sheets)
    {
        double totalArea = sheets.Sum(s => s.Width * s.Height);
        double usedArea = layout.CutPositions.Sum(p => p.Width * p.Height);
        return (totalArea - usedArea) / totalArea * 100;
    }
}
