using Grpc.Core;

namespace GrpcServer.Services
{
    public class HubService : Hub.HubBase
    {
        private readonly ILogger<HubService> _logger;
        public HubService(ILogger<HubService> logger)
        {
            _logger = logger;
        }

        public override Task<MessageResponse> Send(MessageRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MessageResponse
            {
                // aplicamos una logica de transformacion de ejemplo del mensaje recibido
                Output = $"Mensaje recibido: {request.Input.ToLower()}"
            });
        }
    }
}