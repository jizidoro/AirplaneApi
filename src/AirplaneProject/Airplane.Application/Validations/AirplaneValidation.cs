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
		protected void ValidarNome()
		{
			RuleFor(v => v.Codigo)
				.NotEmpty().WithMessage(MensagensAplicacao.CAMPO_OBRIGATORIO)
				.WithName("Nome");
		}
	}
}
