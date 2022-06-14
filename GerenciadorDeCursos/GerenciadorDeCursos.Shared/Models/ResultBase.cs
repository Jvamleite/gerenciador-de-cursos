using System;

namespace GerenciadorDeCursos.Shared.Models
{
    public class ResultBase
    {
        public string Message { get; set; }
        public bool sucess { get; set; }
        public Object Data { get ; set; }

        public ResultBase()
        {
                
        }
        public ResultBase(object data)
        {
            Data = data;
        }
    }

    
}
