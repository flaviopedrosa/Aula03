using System;

namespace ApiAuditoria.Models
{
    public class Log
    {
        public Log()
        {
            Id = Guid.NewGuid().ToString();
            DataAcesso = DateTime.Now;
        }

        public string Id { get; set; }
        public string Uri { get; set; }
        public string UserId { get; set; }
        public DateTime DataAcesso { get; set; }
    }
}
