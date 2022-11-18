using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class NombresNegatifsException : Exception
    {
        internal NombresNegatifsException(int nombreFautif, int position)
        {
            nombreFautif = nombreFautif;
            position = position;
        }

        public int nombreFautif { get; }
        public int position { get; }
    }
}
