using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Services;

public class CuttingOptimizerService(IStockSheetRepository stockSheetRepository, IGlassPanelRepository glassPanelRepository) : ICuttingOptimizer
{
    public CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        // Basic Greedy Algorithm: Sort panels and attempt to place them on the smallest available space
        var layout = new CutLayout();
        // Sorting panels by area descending
        var sortedPanels = panels.OrderByDescending(p => p.Width * p.Height).ToList();

        foreach (var sheet in sheets)
        {
            double remainingWidth = sheet.Width;
            double remainingHeight = sheet.Height;

            foreach (var panel in sortedPanels)
            {
                if (panel.Width <= remainingWidth && panel.Height <= remainingHeight)
                {
                    // Place panel and update remaining dimensions
                    layout.CutPositions.Add(new CutPosition
                    {
                        X = sheet.Width - remainingWidth,
                        Y = sheet.Height - remainingHeight,
                        Width = panel.Width,
                        Height = panel.Height
                    });
                    remainingWidth -= panel.Width;
                    remainingHeight -= panel.Height;
                }
            }
        }

        // Calculate waste percentage
        layout.WastePercentage = CalculateWaste(sheets, layout.CutPositions);
        return layout;
    }

    private static double CalculateWaste(IEnumerable<StockSheet> sheets, List<CutPosition> positions)
    {
        // Logic to calculate total waste based on placed panels and total available sheet area
        double totalArea = sheets.Sum(s => s.Width * s.Height);
        double usedArea = positions.Sum(p => p.Width * p.Height);
        return (totalArea - usedArea) / totalArea * 100;
    }
}

