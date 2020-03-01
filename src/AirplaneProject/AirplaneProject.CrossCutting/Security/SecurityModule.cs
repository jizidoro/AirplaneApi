using AirplaneProject.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using System;

namespace AirplaneProject.CrossCutting.Security
{
	public static class SecurityModule
	{
		public static void RegisterPolicies(AuthorizationOptions options)
		{
			foreach (EnumRecursos recurso in Enum.GetValues(typeof(EnumRecursos)))
			{
				options.AddPolicy(recurso.ToString(), policy =>
					policy.RequireClaim("Recurso", recurso.ToString()));
			}
		}
	}
}
