using System;
using System.Linq;
using System.Collections.Generic;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public override bool Equals(Object obj) {
        var coord = (Coord) obj;
        return X == coord.X && Y == coord.Y;
    }

    public double Distance(Coord c) {
        int deltaX = X - c.X;
        int deltaY = Y - c.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}

public struct Plot
{
    public Coord coord1 { get; }
    public Coord coord2 { get; }
    public Coord coord3 { get; }
    public Coord coord4 { get; }

    public double LongestSide {
        get {
            var sideLen1 = coord1.Distance(coord2);
            var sideLen2 = coord2.Distance(coord3);
            var sideLen3 = coord3.Distance(coord4);
            var sideLen4 = coord4.Distance(coord1);

            return Math.Max(Math.Max(sideLen1, sideLen2), Math.Max(sideLen3, sideLen4));
        }
    }
    
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4) {
        coord1 = c1;
        coord2 = c2;
        coord3 = c3;
        coord4 = c4;
    }

    public override bool Equals(Object obj) {
        var plot = (Plot) obj;
        return coord1.Equals(plot.coord1) && coord2.Equals(plot.coord2) && coord3.Equals(plot.coord3) && coord4.Equals(plot.coord4);
    }

}


public class ClaimsHandler
{
    private List<Plot> plots = new();
    
    public void StakeClaim(Plot plot)
    {
        plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        return plots.Any(p => p.Equals(plot));
    }

    public bool IsLastClaim(Plot plot)
    {
        return plots.Last().Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        return plots.OrderByDescending(p => p.LongestSide).First();
    }
}
