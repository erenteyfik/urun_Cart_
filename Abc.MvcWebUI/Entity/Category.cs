using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Category
    {
        public int Id { get; set; }

        //Data annotations deniyor bunlara
        [DisplayName("Kategori adi")]
        [StringLength(maximumLength:20,ErrorMessage = "En fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        //bir kategorideyken ona ait ürünleri getirmek icin
        public List<Product> Products { get; set; }
    }
}