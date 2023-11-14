using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caTrabalhoFinalED
{
    internal class ListaEncadeada<ADT>
    {
        private NoLista<ADT> inicio;
        private NoLista<ADT> fim;

        public ListaEncadeada()
        {
            inicio = null; fim = null;
        }

        internal NoLista<ADT> Inicio { get => inicio; set => inicio = value; }
        internal NoLista<ADT> Fim { get => fim; set => fim = value; }

        public bool estaVazia()
        {
            if (inicio == null)
                return true;
            return false;
        }

        public void insereInicio(ADT _info)
        {
            NoLista<ADT> auxNovo = new NoLista<ADT>(_info);
            if (estaVazia())
            {
                inicio = auxNovo; fim = auxNovo;
            }
            else
            {
                auxNovo.Posterior = inicio;
                inicio.Anterior = auxNovo;
                inicio = auxNovo;
            }
        }

        //public bool checarPresenca(ADT objetivo)
        //{
        //    NoLista<ADT> aux = inicio;
        //    while(aux != null)
        //    {

        //    }
        //}


        public int tamanho()
       {
            int tam = 0;
            NoLista<ADT> aux = inicio;
            if(aux != null)
            {
                while (aux != null)
                {
                    tam++;
                    aux = aux.Posterior;
                }
            }
            return tam;
       }


        //remove um elemento específico da lista
        public void remove(ADT aremover)
        {
            if (EqualityComparer<ADT>.Default.Equals(this.inicio.Info, aremover))
            {
                inicio = inicio.Posterior;
                inicio.Anterior = null;
            }
            else if (EqualityComparer<ADT>.Default.Equals(this.fim.Info, aremover))
            {
                fim = fim.Anterior;
                fim.Posterior = null;
            }
            else
            {
                NoLista<ADT> temp = inicio.Posterior;
                while (temp != fim)
                {
                    if (EqualityComparer<ADT>.Default.Equals(temp.Info, aremover))
                    {
                        temp.Anterior.Posterior = temp.Posterior;
                        temp.Posterior.Anterior = temp.Anterior;
                    }
                    temp = temp.Posterior;
                }
            }
        }

        //limpa a lista toda
        public void removeTodosOsElementos()
        {
            this.inicio = null;
            this.fim = null;
        }

    }
}
