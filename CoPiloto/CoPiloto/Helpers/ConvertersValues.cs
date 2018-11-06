using System;
using System.Collections.Generic;
using System.Text;

namespace CoPiloto.Helpers
{
    public class ConvertersValues
    {
        const decimal feetsConverter = 0.3048M;

        const decimal KnotsToKmH = 1.85M;

        const decimal NmToKm = 1.8532M;

        public static decimal AltitudeSI(decimal feets) => feets * feetsConverter;

        public static decimal AltitudeUK(decimal meter) => meter / feetsConverter;

        public static decimal VelocitySI(decimal knots) => knots * KnotsToKmH;

        public static decimal VelocityUK(decimal kmh) => kmh / KnotsToKmH;

        public static decimal DistanceSI(decimal nm) => NmToKm * nm;
    }
}
