using GlassCutting.Core.Entities;
using GlassCutting.Core.Interfaces;

namespace GlassCutting.Application.Optimizers;

public class GeneticCuttingStrategy : ICuttingStrategy
{
    private const int PopulationSize = 100;
    private const int Generations = 50;
    private const double MutationRate = 0.1;

    public CutLayout Optimize(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        var population = InitializePopulation(panels, sheets);

        for (int generation = 0; generation < Generations; generation++)
        {
            foreach (var layout in population)
            {
                layout.WastePercentage = CalculateWaste(layout, sheets);
            }

            var selected = SelectBestLayouts(population);
            population = Reproduce(selected, panels, sheets);
        }

        return population.OrderBy(p => p.WastePercentage).First();
    }

    private List<CutLayout> InitializePopulation(IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        var population = new List<CutLayout>();
        var random = new Random();

        for (int i = 0; i < PopulationSize; i++)
        {
            var layout = new CutLayout();
            foreach (var panel in panels.OrderBy(_ => random.Next()))
            {
                var sheet = sheets.ElementAt(random.Next(sheets.Count()));
                if (CanPlacePanel(sheet, layout, panel))
                    PlacePanel(sheet, layout, panel);
            }
            population.Add(layout);
        }
        return population;
    }

    private bool CanPlacePanel(StockSheet sheet, CutLayout layout, GlassPanel panel)
    {
        // Logic to check if a panel can be placed on the sheet without overlapping others
        // Consider the dimensions of the sheet and current panels placed
        // Placeholder for actual placement checking logic
        return true;
    }

    private void PlacePanel(StockSheet sheet, CutLayout layout, GlassPanel panel)
    {
        // Add the panel position to the layout
        var position = new CutPosition
        {
            X = new Random().Next(0, (int)(sheet.Width - panel.Width)),
            Y = new Random().Next(0, (int)(sheet.Height - panel.Height)),
            Width = panel.Width,
            Height = panel.Height
        };

        layout.CutPositions.Add(position);
    }

    private List<CutLayout> SelectBestLayouts(List<CutLayout> population)
    {
        // Select the top 50% based on waste percentage
        return population.OrderBy(p => p.WastePercentage).Take(PopulationSize / 2).ToList();
    }

    private List<CutLayout> Reproduce(List<CutLayout> selected, IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        var newPopulation = new List<CutLayout>();
        var random = new Random();

        // Crossover and mutation to create new layouts
        while (newPopulation.Count < PopulationSize)
        {
            var parent1 = selected[random.Next(selected.Count)];
            var parent2 = selected[random.Next(selected.Count)];

            // Crossover: Combine two parents to form a child
            var child = Crossover(parent1, parent2);

            // Mutation: Randomly alter some aspects of the child layout
            if (random.NextDouble() < MutationRate)
                Mutate(child, panels, sheets);

            newPopulation.Add(child);
        }

        return newPopulation;
    }

    private CutLayout Crossover(CutLayout parent1, CutLayout parent2)
    {
        // Combine two layouts into one, mixing cut positions
        var child = new CutLayout
        {
            CutPositions = parent1.CutPositions.Take(parent1.CutPositions.Count / 2)
                .Concat(parent2.CutPositions.Skip(parent2.CutPositions.Count / 2)).ToList()
        };
        return child;
    }

    private void Mutate(CutLayout layout, IEnumerable<GlassPanel> panels, IEnumerable<StockSheet> sheets)
    {
        // Randomly alter the layout (e.g., move a panel or replace one)
        var random = new Random();
        if (layout.CutPositions.Any())
        {
            var position = layout.CutPositions[random.Next(layout.CutPositions.Count)];
            position.X += random.Next(-10, 10); // Random adjustment to position
            position.Y += random.Next(-10, 10);
        }
    }

    private double CalculateWaste(CutLayout layout, IEnumerable<StockSheet> sheets)
    {
        // Calculate total used and available area to determine waste
        double totalArea = sheets.Sum(s => s.Width * s.Height);
        double usedArea = layout.CutPositions.Sum(p => p.Width * p.Height);
        return (totalArea - usedArea) / totalArea * 100;
    }
}