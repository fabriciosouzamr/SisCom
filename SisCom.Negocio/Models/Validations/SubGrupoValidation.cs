﻿using FluentValidation;
using SisCom.Entidade.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Negocio.Models.Validations
{
    public class SubGrupoValidation : AbstractValidator<SubGrupoMercadoria>
    {
        public SubGrupoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("GERAL.REQUIRED|O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres|{PropertyName};{MinLength};{MaxLength}")
                .WithMessage("GERAL.REQUIRED|O campo Nome precisa ter entre 2 e 100 caracteres|Nome;2;100")
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
