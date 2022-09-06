using System;
using System.Collections.Generic;

namespace CityData.Domain.Models
{
    public class State : BaseEntity
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string UF { get; private set; }
        private string _UF
        {
            get => _UF;
            set
            {
                if (value.Length <= 2)
                {
                    UF = value.ToUpper();
                }
                else
                {
                    throw new Exception("UF digitada inválida.");
                }
            }
        }
        public int Population { get; set; }
        public ICollection<City> Cities { get; set; }

        public State() 
        { 
        }
        public State(string UF) 
        { 
            _UF = UF;
        }
    }
}
