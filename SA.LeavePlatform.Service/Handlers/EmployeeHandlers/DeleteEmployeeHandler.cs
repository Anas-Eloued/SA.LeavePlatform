using MediatR;
using SA.LeavePlatform.Service.MediatRrequests.EmployeeRequests;
using SA.LeavePlatform.Service.Query;


namespace SA.LeavePlatform.Service.Handlers.EmployeeHandlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, bool>
    {
        private readonly IEmployeeQueryRepository _repository;

        public DeleteEmployeeHandler(IEmployeeQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteEmployeeAsync(request.Id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}