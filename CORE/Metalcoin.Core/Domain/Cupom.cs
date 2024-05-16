﻿using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Domain
{
    public class Cupom:Entidade
    {
        public Guid CodigoCupom { get; set; }
        public string Descricao { get; set; }
        public decimal ValorDesconto { get; set; }
        public TipoDesconto TipoDescontoCupon { get; set; }
        public TipoStatusCupom statusCupom { get; set; }
        public DateTime DataValidade { get; set; }
        //public int QuantidadeDeCupomLiberado { get; set; }
        //public int QuantidadeDeCupomUsados { get; set; }


    }
}