using Microsoft.Extensions.Configuration;
using ReportManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Application.Utilities
{
    public class FirstLogger : ILogger
    {
        private readonly IConfiguration _configuration;
        private readonly string _filePath;
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public FirstLogger(IConfiguration configuration)
        {
            _configuration = configuration;
            _filePath = _configuration.GetSection("LoggerFilePath").Value;
        }
        private async Task Log(string level, string message) 
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                using var outputFile = new StreamWriter(_filePath, true);
                await outputFile.WriteLineAsync($"Level: {level} {message}");
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
        public async Task Debug(string message)
        {
            await Log(nameof(Debug), message);
        }

        public async Task Error(string message)
        {
            await Log(nameof(Error), message);
        }

        public async Task Information(string message)
        {
            await Log(nameof(Information), message);
        }

        public async Task Warning(string message)
        {
            await Log(nameof(Warning), message);
        }
    }
}
