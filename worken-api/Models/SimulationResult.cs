
using Solnet.Rpc.Models;

namespace worken_api.Models
{
    public class SimulationResult
    {
        public SimulationLogs Result { get; }
        public Exception Exception { get; }

        public SimulationResult(SimulationLogs value, Exception exception = null)
        {
            this.Result = value;
            this.Exception = exception;
        }
    }
}