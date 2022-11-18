using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class AddString
    {
        /* public static int Add(string entrée)
        {
            var parties = entrée.Split(',');
            var firstInt = int.Parse(parties.First());
            var secondInt = int.Parse(parties.Last());
            return firstInt + secondInt;
        } */

        public static int Add(string entrée)
        {
            var délimitateur = ",";
            var spécifieDélimitateurc = entrée.StartsWith("//");

            if (spécifieDélimitateurc)
            {
                var lignesEntrée = entrée.Split(Environment.NewLine);

                délimitateur = lignesEntrée
                    .First()
                    .TrimStart('/');
                entrée = String.Join(Environment.NewLine, lignesEntrée.Skip(1));

            }

            var parties = entrée
                .Split(délimitateur)
                .Select(int.Parse)
                .Where(nombres => nombres <= 1000)
                .ToList();

            var nombreNégatif = parties.FirstOrDefault(nombre => nombre < 0);

            if (nombreNégatif == default) return parties.Sum();

            var positionNombreNégatif = parties.IndexOf(nombreNégatif) + 1;
            throw new NombresNegatifsException(nombreNégatif, positionNombreNégatif);


                //var parties = entrée.Split(',');

            //return parties.Select(int.Parse.Sum();
        }
    }
}
