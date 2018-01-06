using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün adi")]
        public string Name { get; set; }
        [DisplayName("Açıklaması")]
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsApproved { get; set; } //ürün onaylı mı?
        public bool IsHome { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }  //diger tablonun ismi+ pk ismi birleşik 
        //Her bir ürünün bir kategorisi var  
        public Category Category { get; set; }


    }
}