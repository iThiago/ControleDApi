﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            this.Agendamentos = new List<Agendamento>();
            this.Refeicoes = new List<Refeicao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public decimal? QtdInsulinaPorGramaCarbo { get; set; }
        public long Cpf { get; set; }
        public int? Crm { get; set; }
        public virtual List<Agendamento> Agendamentos { get; set; }
        public virtual List<Refeicao> Refeicoes { get; set; }
    }
}