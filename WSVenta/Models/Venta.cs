using System;
using System.Collections.Generic;

namespace WSVenta.Models
{
    public partial class Venta
    {
        public Venta()
        {
            Concepto = new HashSet<Concepto>();
        }

        public long Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Total { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<Concepto> Concepto { get; set; }
    }
}
