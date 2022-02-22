using System;
using System.Collections.Generic;
using System.Linq;

namespace SisCom.Aplicacao.Controllers
{
    //[ApiController]
    //public abstract class MainController : ControllerBase
    //{
    //    private readonly INotifier _notifier;
    //    public readonly IUser AppUser;

    //    protected Guid UserId { get; set; }
    //    protected bool UserAuthenticated { get; set; }

    //    protected MainController(INotifier notifier,
    //                             IUser appUser)
    //    {
    //        _notifier = notifier;
    //        AppUser = appUser;

    //        if (appUser.IsAuthenticated())
    //        {
    //            UserId = appUser.GetUserId();
    //            UserAuthenticated = true;
    //        }
    //    }

    //    protected bool ValidOperation()
    //    {
    //        return !_notifier.HasNotification();
    //    }

    //    protected ActionResult CustomResponse(object result = null)
    //    {
    //        if (ValidOperation())
    //        {
    //            return Ok(new
    //            {
    //                success = true,
    //                data = result
    //            });
    //        }

    //        return BadRequest(new
    //        {
    //            success = false,
    //            errors = _notifier.GetNotifications()
    //        });
    //    }

    //    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    //    {
    //        if (!modelState.IsValid) NotifyInvalidModelError(modelState);
    //        return CustomResponse();
    //    }

    //    protected void NotifyInvalidModelError(ModelStateDictionary modelState)
    //    {
    //        var errors = modelState.Values.SelectMany(e => e.Errors);
    //        foreach (var error in errors)
    //        {
    //            var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
    //            NotifyError(errorMsg);
    //        }
    //    }

    //    protected void NotifyError(string message)
    //    {
    //        _notifier.Handle(new Notification(message));
    //    }
    //    protected void NotifyError(Notification notification)
    //    {
    //        _notifier.Handle(notification);
    //    }
    //}

    //public class ResultSuccess<T>
    //{
    //    public bool Success { get; set; }
    //    public T Data { get; set; }
    //}
    //public class ResultError
    //{
    //    public bool Success { get; set; }
    //    public IEnumerable<string> Errors { get; set; }
    //}
}
