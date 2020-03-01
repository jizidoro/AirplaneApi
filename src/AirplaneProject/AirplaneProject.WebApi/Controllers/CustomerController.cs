using AirplaneProject.Application.Dtos;
using AirplaneProject.Application.Interfaces;
using AirplaneProject.Core.Bus;
using AirplaneProject.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneProject.WebApi.Controllers
{
    [Authorize]
    public class AirplaneController : ApiController
    {
        private readonly IAirplaneAppService _AirplaneAppService;

        public AirplaneController(
            IAirplaneAppService AirplaneAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _AirplaneAppService = AirplaneAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane-management")]
        public IActionResult Get()
        {
            return Response(_AirplaneAppService.Listar());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane-management/{id:int}")]
        public IActionResult Get(int id)
        {
            var AirplaneDto = _AirplaneAppService.Obter(id);

            return Response(AirplaneDto);
        }     

        [HttpPost]
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Post([FromBody]AirplaneIncluirDto AirplaneDto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(AirplaneDto);
            }

            _AirplaneAppService.Incluir(AirplaneDto);

            return Response(AirplaneDto);
        }
        
        [HttpPut]
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Put([FromBody]AirplaneEditarDto AirplaneDto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(AirplaneDto);
            }

            _AirplaneAppService.Editar(AirplaneDto);

            return Response(AirplaneDto);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Delete([FromBody]AirplaneExcluirDto AirplaneDto)
        {
            _AirplaneAppService.Excluir(AirplaneDto);
            
            return Response();
        }
    }
}
