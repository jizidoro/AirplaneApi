using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Messages;
using FluentValidation;
using System;

namespace AirplaneProject.Application.Validations
{
	public class AirplaneValidation<TDto> : DtoValidation<TDto>
		where TDto : AirplaneDto
	{
		protected void ValidarCodigo()
		{
			RuleFor(v => v.Codigo)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.WithName("Codigo");
		}

		protected void ValidarModelo()
		{
			RuleFor(v => v.Modelo)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.WithName("Modelo");
		}

		protected void ValidarQuantidadePassageiros()
		{
			RuleFor(v => v.QuantidadePassageiros)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.WithName("QuantidadePassageiros");
		}
	}
}
