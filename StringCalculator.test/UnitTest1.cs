namespace StringCalculator.test
{
    public class UnitTest1
    {
        [Theory(DisplayName = "ETANT DONNE une chaine \"x,y\" " +
                              "QUAND on appelle Add " +
                              "ALORS on obtient x + y")]
        [InlineData(1, 2)]
        [InlineData(0, 0)]
        [InlineData(1000, 0)]
        public void TestAjouter(int x, int y)
        {
            // ETANT DONNE une chaine "1,2"

            var entrée = $"{x},{y}";

            // QUAND on appelle Add
            var résultat = AddString.Add(entrée);

            // ALORS on obtient x + y
            Assert.Equal(x + y, résultat);
        }

        [Theory(DisplayName = "ETANT DONNE n nombres \"x,y,z\" " +
                              "QUAND on appelle Add " +
                              "ALORS on obtient  Σ n nombres")]

        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 4)]
        public void TestNNombres(int x, int y, int z)

        {
            //ETANT DONNE n nombres "1,2,3"

            var entrée = $"{x},{y},{z}";

            // QUAND on appelle Add
            var résultat = AddString.Add(entrée);

            // ALORS on obtient Σ n nombres
            Assert.Equal(x + y + z, résultat);
        }


        [Fact]
        public void LesSautsDeLignesSontIgnorés()
        {
            // ETANT DONNE une liste de nombres de la forme "1,2,..."comportant un saut de ligne
            var entrée = string.Join(',', new int[] { 1, 2, 3 });
            var entréeAvecSautDeLigne = AddString.Add(entrée);

            // QUAND on appelle Add
            var résultatAvecSautDeLigne = AddString.Add(entrée);

            // ALORS le résultat est le même que pour une entrée n'en ayant pas

            var résultatSansSautDeLigne = AddString.Add(entrée);

            Assert.Equal(résultatSansSautDeLigne, résultatAvecSautDeLigne);
        }


        [Fact]
        public void ErreurSiNomnbresNégatifs()
        {
            // ETANT DONNE une liste de nombres de la forme "1,2,..."comportant un nopmbre négatif
            var entrée = string.Join(',', new int[] { -1, 2, 3 });

            // QUAND on appelle Add
            void Act() => AddString.Add(entrée);

            // ALORS une exception est lancée, contenant le nombre et sa position
            var exception = Assert.Throws<NombresNegatifsException>(Act);

            Assert.Equal(-1, exception.nombreFautif);
            Assert.Equal(-1, exception.position);
        }

        [Fact]
        public void GrandNombresIgnorés()
        {
            // ETANT DONNE une liste de nombres de la forme "1,2,..."comportant un grand nombre

            var nombres = new int[] { 1001, 2, 3 };
            var entrée = string.Join(',', nombres);

            // QUAND on appelle Add

            var résultatAvecGrandNombres = AddString.Add(entrée);

            // ALORS le résultat est le même que pour une entrée n'en ayant pas

            var nombresSansGrandNombres = nombres.Where(nombres => nombres <= 1000);
            var entréeSansGrandNombres = string.Join(',', nombresSansGrandNombres);
            var résultatSansGrandNombres = AddString.Add(entréeSansGrandNombres);

            Assert.Equal(résultatSansGrandNombres, résultatAvecGrandNombres);

        }


        /* [Fact]
         public void ChangementDélimitateur()
         {
             // ETANT DONNE uneligne "//🐶" avant tout nombre

             const string nouveauDélimitateur = "🐶";
             var ligneChangementDélimitateur = $"//{nouveauDélimitateur}" + Environment.NewLine;

             // QUAND on appelle Add avec une chaîne "1🐶2🐶3"

             const string chaîne = "1🐶2🐶3";
             var résultatAvecDélimitateurCustom = AddString.Add(chaîneAvecVirgules);

             // ALORS on obtient le même résultat que "1,2,3" en temps normal

             var chaîneAvecVirgules = chaîne.Replace("🐶", ",");
             var résultatAvecVirgules = AddString.Add(chaîneAvecVirgules);
         }*/

    }
}