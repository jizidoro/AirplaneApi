using System;
using AirplaneProject.Core.Bus;
using AirplaneProject.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneProject.Services.Api.Controllers
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
            return Response(_AirplaneAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane-management/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var AirplaneViewModel = _AirplaneAppService.GetById(id);

            return Response(AirplaneViewModel);
        }     

        [HttpPost]
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Post([FromBody]AirplaneViewModel AirplaneViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(AirplaneViewModel);
            }

            _AirplaneAppService.Register(AirplaneViewModel);

            return Response(AirplaneViewModel);
        }
        
        [HttpPut]
        [Authorize(Policy = "CanWriteAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Put([FromBody]AirplaneViewModel AirplaneViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(AirplaneViewModel);
            }

            _AirplaneAppService.Update(AirplaneViewModel);

            return Response(AirplaneViewModel);
        }

        [HttpDelete]
        [Authorize(Policy = "CanRemoveAirplaneData")]
        [Route("Airplane-management")]
        public IActionResult Delete(Guid id)
        {
            _AirplaneAppService.Remove(id);
            
            return Response();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Airplane-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var AirplaneHistoryData = _AirplaneAppService.GetAllHistory(id);
            return Response(AirplaneHistoryData);
        }
    }
}
