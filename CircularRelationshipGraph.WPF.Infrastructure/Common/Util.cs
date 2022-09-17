using System;
using System.Windows;

namespace CircularRelationshipGraph.WPF.Infrastructure.Common
{
    public static class WPFUtil
    {
        private static readonly double factor = 2 * Math.PI / 360;

        public static Point RadialToCartesian(double angle, double radius, Point centre)
        {
            return new Point()
            {
                X = Math.Sin(angle * factor) * radius + centre.X,
                Y = Math.Cos(angle * factor) * radius + centre.Y
            };
        }
    }
}