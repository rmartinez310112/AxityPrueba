using modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class productosGet
    {
        public bool Success { get; set; }
        public List<productos> Data { get; set; }
    }
}