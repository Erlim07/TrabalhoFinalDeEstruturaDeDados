using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caTrabalhoFinalED
{
    internal class Tag
    {
        private int tamanho;
        private Cidade previo;

        public int Tamanho { get => tamanho; set => tamanho = value; }
        public Cidade Previo { get => previo; set => previo = value; }

        public Tag(int _tamanho, Cidade _previo) 
        {
            tamanho = _tamanho;
            previo = _previo;
        }
    }
}
