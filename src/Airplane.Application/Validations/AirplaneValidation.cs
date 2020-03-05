using Airplaneproject.Application.Messages;
using AirplaneProject.Application.Bases;
using AirplaneProject.Application.Dtos;
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
				.MaximumLength(255).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
				.WithName("Codigo");
		}

		protected void ValidarModelo()
		{
			RuleFor(v => v.Modelo)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.MaximumLength(255).WithMessage(MensagensAplicacao.TAMANHO_ESPECIFICO_CAMPO)
				.WithName("Modelo");
		}

		protected void ValidarQuantidadePassageiros()
		{
			RuleFor(v => v.QuantidadePassageiros)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.GreaterThanOrEqualTo(0).WithMessage(MensagensAplicacao.CAMPO_MAIOR_IGUAL_ZERO)
				.WithName("QuantidadePassageiros");
		}
	}
}
