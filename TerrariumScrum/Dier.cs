using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariumScrum
{
    public abstract class Dier:Organisme
    {
        Random rnd = new Random();
        public override int Levenskracht { get; set; }
        public Dier(int rij, int kolom, int levenskracht)
            : base(rij, kolom, levenskracht)
        {

        }
        public Dier()
        {

        }
        public bool IsVerplaatst = false;


        Random random = new Random();// gebruikt voor Verplaatsen. Wordt buiten de method geschreven om zo de instantie te bewaren
                                    //Als je dit niet doet krijg je teveel dezelfde waardes in de randomgetallen.
        public IOrganisme[,] Verplaatsen(IOrganisme[,] grid, Dier dier)
        {
            //voor dat deze method wordt opgeroepen moet er gecontrolleerd worden of het dier zich mag verplaatsen (geen organisme aan zijn rechterkant).
            //hierdoor moet er ook apart de methode opgeroepen worden als het dier zich helemaal op de rechterkant bevindt.
            //Als alle dieren verplaatst zijn moet ook de IsVerplaatst van alle dieren terug op false gezet worden. Dat gebeurd in deze method dus niet!


            //*****werking van verplaatsen*****//
            //comments staan bij elke stap


            //voorbereiding op het gebruik van random getallekes.
            int willGetal;


            //De plaats waar het dier nu staat wordt alvast leeg gemaakt (er wordt GeenOrganisme geplaatst).
            grid[dier.Rij, dier.Kolom] = new GeenOrganisme(dier.Rij, dier.Kolom);


            //de positie van het dier wordt in variabelen gestopt om verder in de method te gebruiken.
            int rij = dier.Rij;
            int kolom = dier.Kolom;



            //Hier wordt er nagegaan of het dier zich helemaal rechts bevind en er overal dieren rondom staan.
            //Als dit het geval is wordt het dier niet verplaatst maar wordt de IsVerplaatst wel op true gezet.
            //dit om te voorkomen dat de method niet in een onneindige lus terecht komt.
            if (kolom == 5)
            {
                if (grid[rij, kolom - 1] is Organisme )
                {
                    if (rij == 0)//niet naar boven controlleren
                    {
                        if (grid[rij + 1, kolom] is Organisme)
                        {
                            dier.IsVerplaatst = true;
                        }
                    }
                    else if(rij == 5){//niet naar onder controlleren.
                        if (grid[rij - 1, kolom] is Organisme)
                        {
                            dier.IsVerplaatst = true;
                        }
                    }
                    else if (grid[rij + 1, kolom] is Organisme && grid[rij - 1, kolom] is Organisme)
                    {
                        dier.IsVerplaatst = true;
                    }        
                }           
            }



            while (!dier.IsVerplaatst)//Nu wordt gecontroleerd of het dier al verplaatst is of niet.
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
                //gebeurd er niets en wordt de while-lus terug opnieuw doorlopen.

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
        public IOrganisme[,] Eten(Organisme organisme, IOrganisme[,] raster)      //Het dier moet het organisme dat die gaat opeten binnenkrijgen als parameter. 
        {
            this.Levenskracht += organisme.Levenskracht;    //Het dier krijgt de levenskracht van het organisme dat die gaat opeten.
            raster[organisme.Rij, organisme.Kolom] = new GeenOrganisme(organisme.Rij, organisme.Kolom);     //Het opgegeten organisme wordt vervangen door een GeenOrganisme.
            return raster;
        }
    }
}
