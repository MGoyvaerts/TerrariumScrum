using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public class Dier:Organisme
    {
        Random rnd = new Random();
        private int levenskrachtValue;
        public override int Levenskracht { get; set; }
        public Dier(int rij, int kolom, int levenskracht)
            : base(rij, kolom,levenskracht)
        {

        }
        public Dier()
        {

        }
        
        public bool IsVerplaatst = false;
        public IOrganisme[,] Verplaatsen(IOrganisme[,] grid, Dier dier)
        {
            //voor dat deze method wordt opgeroepen moet er gecontrolleerd worden of het dier zich mag verplaatsen (geen organisme aan zijn rechterkant).
            //hierdoor moet er ook apart de methode opgeroepen worden als het dier zich helemaal op de rechterkant bevindt.
            //Als alle dieren verplaatst zijn moet ook de IsVerplaatst van alle dieren terug op false gezet worden. Dat gebeurd in deze method dus niet!


            //*****werking van verplaatsen*****//
            //comments staan bij elke stap


            //voorbereiding op het gebruik van random getallekes.
            Random random = new Random();
            int willGetal;


            //op de plaats waar het dier nu staat wordt alvast leeg gemaakt (er wordt GeenOrganisme geplaatst.
            grid[dier.Rij, dier.Kolom] = new GeenOrganisme(dier.Rij, dier.Kolom);


            //de positie van het dier wordt in variabelen gestopt om verder in de method te gebruiken.
            int rij = dier.Rij;
            int kolom = dier.Kolom;



            while (!dier.IsVerplaatst)//Eerst wordt gecontroleerd of het dier al verplaatst is of niet.
            //Deze while is er ook om te zorgen dat het dier zich sowieso verplaatst, 
            //als er al een dier op de te verplaatsen plek staat komt er een nieuw random getalleke en wordt de lus opnieuw doorlopen
            {

                willGetal = random.Next(1, 5);//random getalleke...

                switch (willGetal)//switch op het random getalleke
                //er zijn 4 random getallen mogelijk.
                //elk getal stelt een richting voor.
                //1:rechts   2:links     3:onder    4:boven
                //in elke case wordt gecontrolleerd of het dier zich niet op de rand van het grid bevind
                //en zich dan buiten het grid wil verplaatsen.
                //bv: als het dier helemaal links staat en het random nummerke 2 (om naar links te gaan) wordt gegenereerd,
                //gebeurd er niets en wordt de whilelus terug opnieuw doorlopen.

                //Pas als aan alle voorwaarden voldaan zijn wordt de kolom en/of rij van het dier aangepast.
                //en wordt IsVerplaatst op true gezet.
                {
                    case 1:// verplaatsen naar rechts
                        if (dier.Kolom < 5)//controle of het dier op de rand rechts staat
                        {
                            if (!(grid[rij, kolom + 1] is Organisme))// hier wordt gecontroleerd of er geen dier staat op de te verplaatsen plek.
                            {
                                dier.Kolom += 1;
                                dier.IsVerplaatst = true;
                            }
                        }
                        break;
                    case 2://verplaatsen naar links
                        if (dier.Kolom > 0)//controle of het dier op de rand links staat
                        {
                            if (!(grid[rij, kolom - 1] is Organisme))// hier wordt gecontroleerd of er geen dier staat op de te verplaatsen plek.
                            {
                                dier.Kolom -= 1;
                                dier.IsVerplaatst = true;
                            }
                        }

                        break;
                    case 3://verplaatsen naar onder
                        if (dier.Rij < 5)//controle of het dier op de rand onder staat
                        {
                            if (!(grid[rij + 1, kolom] is Organisme))// hier wordt gecontroleerd of er geen dier staat op de te verplaatsen plek.
                            {
                                dier.Rij += 1;
                                dier.IsVerplaatst = true;
                            }
                        }
                        break;
                    case 4://verplaatsen naar boven.
                        if (dier.Rij > 0)//controle of het dier op de rand boven staat
                        {
                            if (!(grid[rij - 1, kolom] is Organisme))// hier wordt gecontroleerd of er geen dier staat op de te verplaatsen plek.
                            {
                                dier.Rij -= 1;
                                dier.IsVerplaatst = true;
                            }
                        }
                        break;
                }
            }


            //het dier met aangepaste positie wordt in het grid gezet.
            grid[dier.Rij, dier.Kolom] = dier;


            //en vervolgens wordt de aangepaste grid terug gestuurd.
            return grid;
        }
        public Dier Eten(Dier dier, Organisme organisme)
        {
            //geeft het dier terug met de levenskracht van het organisme dat ie gaat opeten.
            dier.Levenskracht += organisme.Levenskracht;
            return dier;
        }
    }
}
