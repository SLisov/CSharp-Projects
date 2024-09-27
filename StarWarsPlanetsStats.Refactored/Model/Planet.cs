public readonly record struct Planet
{
    public readonly string Name { get; init; }
    public readonly long Diameter { get; init; }
    public readonly long? SurfaceWater { get; init; }
    public readonly long? Population { get; init; }

    public Planet(string name, long diameter, long? surfaceWater, long? population)
    {
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }
    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.Name;
        long diameter = int.Parse(planetDto.Diameter);

        long? population = planetDto.Population.ToIntOrNull();
        long? surfaceWater = planetDto.SurfaceWater.ToIntOrNull();

        return new Planet(name, diameter, surfaceWater, population);
    }
}