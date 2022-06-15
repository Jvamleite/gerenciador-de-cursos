using System;

namespace GerenciadorDeCursos.Shared.Models
{
    public class ResultBase
    {
        public string Message { get; set; }
        public bool Sucess { get; set; }
        public Object Data { get ; set; }

        public ResultBase()
        {
            Sucess = true;       
        }
        public ResultBase(object data)
        {
            Data = data;
        }
    }

    
}
