using System;

namespace CityData.Domain.Models
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public string StateCode { get; set; }
        private string UF 
        {
            get
            {
                return UF;
            }
            set
            {
                if (value.Length <= 2)
                {
                    UF = value;
                }
                else
                    throw new Exception("UF digitada inválida.");
            }
        }
        public int Population { get; set; }

        public State(string UF) 
        { 
            this.UF = UF;
        }
    }
}
