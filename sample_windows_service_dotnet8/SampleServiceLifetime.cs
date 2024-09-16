using Microsoft.Extensions.Hosting.WindowsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace sample_windows_service_dotnet8
{
    internal class SampleServiceLifetime : WindowsServiceLifetime
    {
        public SampleServiceLifetime(IHostEnvironment environment, IHostApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory, IOptions<HostOptions> optionsAccessor, ILogger<SampleServiceLifetime> logger) : base(environment, applicationLifetime, loggerFactory, optionsAccessor)
        {
            _logger = logger;
            CommonSetParams();
        }

        public SampleServiceLifetime(IHostEnvironment environment, IHostApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory, IOptions<HostOptions> optionsAccessor, IOptions<WindowsServiceLifetimeOptions> windowsServiceOptionsAccessor, ILogger<SampleServiceLifetime> logger) : base(environment, applicationLifetime, loggerFactory, optionsAccessor, windowsServiceOptionsAccessor)
        {
            _logger = logger;
            CommonSetParams();
        }

        private readonly ILogger<SampleServiceLifetime> _logger;

        private void CommonSetParams()
        {
            CanHandleSessionChangeEvent = true;
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            base.OnSessionChange(changeDescription);
        }

        protected override void OnStart(string[] args)
        {
            _logger.LogInformation("OnStart");
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

    }
}
