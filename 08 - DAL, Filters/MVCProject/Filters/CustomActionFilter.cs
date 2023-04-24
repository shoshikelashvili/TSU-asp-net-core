using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCProject.Repository;

namespace MVCProject.Filters
{
    public class CustomActionFilter : IAsyncActionFilter
    {
        private UnitOfWork _unitOfWork;
        public CustomActionFilter(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            controller.ViewData["Filter"] = "Test Data From Filter";
            await next();
            _unitOfWork.HistoryRepo.AddNewRecord(new Models.History
            {
                EntityName = "CustomActionFilter",
                Operation = $"Filter has been run on action: ActionName:{context.ActionDescriptor.DisplayName}",
                OperationDate = DateTime.Now,
            });
            _unitOfWork.Save();
        }
    }
}
