using System;
using System.ComponentModel.DataAnnotations;

namespace SBD.Models
{
    public class Bilet
    {
    
        [Key]
        [Display(Name = "ID")]
        public int id_biletu { get; set; }
        [Display(Name = "Pasażer")]
        public int id_pasazera { get; set; }
        public virtual Pasazer Pasazer { get; set; }
        [Display(Name = "Nr Miejsca w samolocie")]
        public int nr_miejsca { get; set; }
        [Display(Name = "Lot")]
        public int id_lotu { get; set; }
        public virtual Lot Lot { get; set; }
        [Display(Name = "Bagaż")]
        public int id_bagazu { get; set; }
        public virtual Bagaz Bagaz { get; set; }
        public bool przydziel_miejsce(int nr)
        {
                    this.nr_miejsca = nr;
                    return true;
        }

            //public bool przydziel_miejsce(int nr)
            //{
            //    if (Lot.miejsca.Count > 0)
            //    {
            //        if (!Lot.miejsca.ContainsKey(nr))
            //        {
            //            Lot.miejsca.Add(nr, true);
            //            this.nr_miejsca = nr;
            //            return true;
            //        }
            //    }

            //    return false;          
            //}
            //public void przydziel_miejsce()
            //{

            //    Random rnd = new Random();
            //    int nr = 0;
            //    do
            //    {
            //        nr = rnd.Next() % Lot.Samolot.pobierz_ilosc_miejsc() + 1;
            //    }
            //    while (Lot.miejsca.ContainsKey(nr));

            //    Lot.miejsca.Add(nr, true);            
            //    this.nr_miejsca = nr;
            //}

        }



}
