    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caTrabalhoFinalED
{
    internal class Cidade
    {
        private string nome;
        private ListaEncadeada<Cidade> listaDeConexoes;
        private ListaEncadeada<int> listaDeDistancias;
        //private ListaEncadeada<Tag> listaDeTags;
        private Tag tag;
        private bool visitada;
        private bool expandida;


        public string Nome { get => nome; set => nome = value; }
        internal ListaEncadeada<Cidade> ListaDeConexoes { get => listaDeConexoes; set => listaDeConexoes = value; }
        internal ListaEncadeada<int> ListaDeDistancias { get => listaDeDistancias; set => listaDeDistancias = value; }
        //internal ListaEncadeada<Tag> ListaDeTags { get => listaDeTags; set => listaDeTags = value; }
        public bool Visitada { get => visitada; set => visitada = value; }
        internal Tag Tag { get => tag; set => tag = value; }
        public bool Expandida { get => expandida; set => expandida = value; }

        //construtor defaut
        public Cidade()
        {

        }

        //construtor com nome
        public Cidade(string _nome)
        {
            nome = _nome;
            listaDeConexoes = new ListaEncadeada<Cidade>();
            listaDeDistancias = new ListaEncadeada<int>();
            tag = null;
            visitada = false;
            expandida = false;
        }

        public void addConexao(Cidade conectada, int distancia)//insere conexoes de ida e volta, nas duas cidades
        {
            //inserindo na cidade que está trabalhando a outra cidade
            this.listaDeConexoes.insereInicio(conectada);
            this.listaDeDistancias.insereInicio(distancia);

            //inserindo na outra cidade a que se está trabalhando
            conectada.listaDeConexoes.insereInicio(this);
            conectada.listaDeDistancias.insereInicio(distancia);
        }

        //public void cleanTags()
        //{
        //    //pega-se o termo inicial da lista e o seu valor
        //    NoLista<Tag> aux = listaDeTags.Inicio;
        //    int auxInt = aux.Info.Tamanho;

        //    //checa qual é a tag com menor valor
        //    while(aux != null)
        //    {
        //        if (aux.Info.Tamanho < auxInt)
        //        {
        //            auxInt = aux.Info.Tamanho;
        //        }
        //        aux = aux.Posterior;
        //    }

        //    //reseta as variaveis iniciais
        //    aux = listaDeTags.Inicio;
        //    auxInt = aux.Info.Tamanho;

        //    //remove as tags com valor grande
        //    while (aux != null)
        //    {
        //        if (aux.Info.Tamanho != auxInt)
        //        {
        //            listaDeTags.remove(aux.Info);
        //        }
        //        aux = aux.Posterior;
        //    }
        //}

        //public void tagsAPartirDaqui(Cidade destino)
        //{
        //    //Cria uma lista para saber por quais cidades já passamos, coloca tag no início e diz que ele já foi visitado
        //    this.Tag = new Tag(0, null);
        //    this.visitada = true;
        //    this.tagNasConexoes();
        //    //pegamos a primeira conexão do inicio como auxiliar

        //    NoLista<Cidade> aux = this.listaDeConexoes.Inicio;

        //    while(aux != null)
        //    {
        //        if(aux.Info == destino)
        //        {
        //            continue;
        //        }
        //        if(!aux.Info.expandida)
        //            aux.Info.tagNasConexoes();
        //        aux = aux.Posterior;
        //    }

        //}

        public void tagNasConexoes()
        {
            //analisa as cidades que fazem conexão com a cidade que eu estou analisando e anda junto com a lista de distâncias
            NoLista<Cidade> noCidadeAnalisada = listaDeConexoes.Inicio;
            NoLista<int> noDistancia = listaDeDistancias.Inicio;
            //para todas as cidades conectadas
            while (noCidadeAnalisada != null) 
            {

                //adicione a tag na cidade que estamos analisando com a distância até ela+a inicial e o nome da origem(caso n tenha sido visitada)
                if (!noCidadeAnalisada.Info.visitada)
                    noCidadeAnalisada.Info.Tag = new Tag(noDistancia.Info + this.Tag.Tamanho, this);
                //se foi visitada, compare as tags
                else
                    if(noDistancia.Info + this.Tag.Tamanho < noCidadeAnalisada.Info.Tag.Tamanho)
                        noCidadeAnalisada.Info.Tag = new Tag(noDistancia.Info + this.Tag.Tamanho, this);
                
                //visitamos a cidade
                noCidadeAnalisada.Info.visitada = true;
                //passe para a proxima
                noCidadeAnalisada = noCidadeAnalisada.Posterior;
                noDistancia = noDistancia.Posterior;
            }
            //ja colocou tag nas conexoes
            this.expandida = true;
        }

        //public void colocandoTags1grau(Cidade destino)
        //{
        //    NoLista<Cidade> aux = this.listaDeConexoes.Inicio;

        //    while (aux != null)
        //    {
        //        if(!aux.Info.redondezaExpandida())
        //            if (!aux.Info.expandida)
        //                aux.Info.tagNasConexoes();
        //        aux = aux.Posterior;
        //    }
        //}


        //diz se as cidades da redondeza dessa estão expandidas
        //public bool redondezaExpandida()
        //{
        //    NoLista<Cidade> aux = this.listaDeConexoes.Inicio;

        //    while (aux != null)
        //    {
        //        if (aux.Info.expandida)
        //            aux = aux.Posterior;
        //        else
        //            return false;
        //    }

        //    return true;
        //}

    }
}
