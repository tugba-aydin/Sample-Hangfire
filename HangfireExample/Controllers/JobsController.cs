using Hangfire;
using HangfireExample.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HangfireExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IBackgroundJobClient backgroundJobClient;
        private readonly IRecurringJobManager recurringJobManager;
        private readonly IJobService jobService;
        public JobsController(IBackgroundJobClient _backgroundJobClient, IRecurringJobManager _recurringJobManager, IJobService _jobService)
        {
            backgroundJobClient = _backgroundJobClient;
            recurringJobManager = _recurringJobManager;
            jobService = _jobService;
        }

        [HttpGet("/ReccuringJob")]
        public IActionResult CreateRecurringJob()
        {
            recurringJobManager.AddOrUpdate("Recurring_job", () => jobService.ReccuringJob(), Cron.Minutely());
            return Ok();
        }

        [HttpGet("/FireAndForgetJob")]
        public IActionResult CreateFireAndForgetJob()
        {
            backgroundJobClient.Enqueue(() => jobService.FireAndForgetJob());
            return Ok();
        }
        [HttpGet("/DelayedJob")]
        public IActionResult CreateDelayedJob()
        {
            backgroundJobClient.Schedule(() => jobService.DelayedJob(), TimeSpan.FromSeconds(10));
            return Ok();
        }

        [HttpGet("/ContinuationsJob")]
        public IActionResult CreateContinuationsJob()
        {
            var parentJobId = backgroundJobClient.Schedule(() => jobService.DelayedJob(), TimeSpan.FromSeconds(10));
            backgroundJobClient.ContinueWith(parentJobId, () => jobService.ContinuationJob());
            return Ok();
        }
    }
}
