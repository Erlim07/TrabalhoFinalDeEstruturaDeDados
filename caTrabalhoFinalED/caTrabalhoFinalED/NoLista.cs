using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caTrabalhoFinalED
{
    internal class NoLista<ADT>
    {
        private ADT info;
        private NoLista<ADT> anterior;
        private NoLista<ADT> posterior;

        public NoLista()
        {

        }

        public NoLista(ADT info)
        {
            this.info = info;
            this.anterior = null;
            this.posterior = null;
        }

        public ADT Info { get => info; set => info = value; }
        internal NoLista<ADT> Anterior { get => anterior; set => anterior = value; }
        internal NoLista<ADT> Posterior { get => posterior; set => posterior = value; }
    }
}
